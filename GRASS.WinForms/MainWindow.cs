using GRASS.Core;
using GRASS.Core.Connection;
using GRASS.Core.Enums;
using GRASS.Core.Interfaces;
using GRASS.Core.KeyboardEntry;
using GRASS.WinForms.Subforms;
using PKHeX.Core;
using SysBot.Base;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Text.Json;
using static GRASS.Core.Utils;
using static GRASS.Core.Encounters;

namespace GRASS.WinForms;

public partial class MainWindow : Form
{
    private static CancellationTokenSource Source = new();
    private static CancellationTokenSource GameResetSource = new();

    private static readonly Lock _connectLock = new();

    public ClientConfig Config;
    private ConnectionWrapperAsync ConnectionWrapper = default!;
    private readonly SwitchConnectionConfig ConnectionConfig;

    private bool stop;
    private bool reset;
    private bool readPause;
    private uint total;

    private bool babyMode;
    private bool babyModePrimed;
    private uint babyModeTarget = 0;
    private SwitchButton babyModeButton = SwitchButton.A;

    private PK3 _enc = new();

    internal List<string> TIDs = [];
    internal List<string> Seeds = [];

    internal List<object> Frames = [];

    private readonly Version CurrentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version!;
    public static readonly Font BoldFont = new("Microsoft Sans Serif", 8, FontStyle.Bold);

    public MainWindow()
    {
        Config = new ClientConfig();
        var configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        if (File.Exists(configPath))
        {
            var text = File.ReadAllText(configPath);
            Config = JsonSerializer.Deserialize<ClientConfig>(text)!;
        }
        else
        {
            Config = new();
        }

        ConnectionConfig = new()
        {
            IP = Config.IP,
            Port = Config.Protocol is SwitchProtocol.WiFi ? 6000 : Config.UsbPort,
            Protocol = Config.Protocol,
        };

        var idsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tid-list.json");
        if (File.Exists(idsPath))
            TIDs = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(idsPath)) ?? [];

        var seedsPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "seed-list.json");
        if (File.Exists(seedsPath))
            Seeds = JsonSerializer.Deserialize<List<string>>(File.ReadAllText(seedsPath)) ?? [];

        var v = CurrentVersion;
#if DEBUG
        var build = "";

        var asm = System.Reflection.Assembly.GetEntryAssembly();
        var gitVersionInformationType = asm?.GetType("GitVersionInformation");
        var sha = gitVersionInformationType?.GetField("ShortSha");

        if (sha is not null) build += $"#{sha.GetValue(null)}";

        var date = File.GetLastWriteTime(AppContext.BaseDirectory);
        build += $" (dev-{date:yyyyMMdd})";

#else
        var build = "";
#endif

        Text = $"GBA RNG Abuse for Switch Systems v{v.Major}.{v.Minor}.{v.Build}{build}";

        InitializeComponent();
    }

    private void MainWindow_Load(object sender, EventArgs e)
    {
        CenterToScreen();

        if (Config.Protocol is SwitchProtocol.WiFi)
        {
            TB_SwitchIP.Text = Config.IP;
        }
        else
        {
            L_SwitchIP.Text = "USB Port:";
            TB_SwitchIP.Text = $"{Config.UsbPort}";
        }

        TB_TID.Text = $"{Config.TID:D5}";
        TB_SID.Text = $"{Config.SID:D5}";

        L_LoadedTIDs.Text = $"Loaded TIDs: {(TIDs.Count == 0 ? "None" : TIDs.Count)}";
        L_SS_SeedList.Text = $"Loaded Seeds: {(Seeds.Count == 0 ? "None" : Seeds.Count)}";


        SetComboBoxSelectedIndex(0, CB_BabyMode_Action, CB_Static_Shiny, CB_Static_Nature, CB_Static_Method, CB_Static_Species, CB_Wild_Encounter, CB_Wild_Method, CB_Wild_Nature, CB_Wild_Shiny);

        CB_Game.SelectedIndex = Config.Game;

        UpdateStaticSpeciesList((Game)Config.Game);

        SetControlText("0", TB_InitialSeed);
        SetControlText(string.Empty, TB_CurrentAdvances, TB_AdvancesIncrease, TB_CurrentSeed);

        TB_Status.Text = "Not Connected.";
        TB_Wild.Text = string.Empty;

        CheckForUpdates();
    }

    private void Connect(CancellationToken token)
    {
        Task.Run(
            async () =>
            {
                SetControlEnabledState(false, B_Connect);
                try
                {
                    ConnectionConfig.IP = TB_SwitchIP.Text;
                    (bool success, string err) = await ConnectionWrapper
                        .Connect(token)
                        .ConfigureAwait(false);
                    if (!success)
                    {
                        SetControlEnabledState(true, B_Connect);
                        this.DisplayMessageBox(err);
                        return;
                    }
                }
                catch (Exception ex)
                {
                    SetControlEnabledState(true, B_Connect);
                    this.DisplayMessageBox(ex.Message);
                    return;
                }

                UpdateStatus("Detecting game version...");

                SetComboBoxSelectedIndex((int)ConnectionWrapper.GetSavVersion(), CB_Game);

                var (tid, sid) = await ConnectionWrapper.GetSavIDs(token).ConfigureAwait(false);
                SetControlText($"{tid:D5}", TB_TID);
                SetControlText($"{sid:D5}", TB_SID);

                UpdateStatus("Reading RNG State...");

                var flag = true;
                while (!await ConnectionWrapper.GetIsBoxPointerLoaded(token).ConfigureAwait(false))
                {
                    if (flag)
                    {
                        UpdateStatus("Waiting for RNG init...");
                        flag = false;
                    }
                    await Task.Delay(300, token).ConfigureAwait(false);
                }

                ushort InitialRNGState;
                try
                {
                    InitialRNGState = await ConnectionWrapper.GetInitialRNGState(token).ConfigureAwait(false);
                    SetControlText($"{InitialRNGState:X8}", TB_InitialSeed);
                }
                catch (Exception ex)
                {
                    this.DisplayMessageBox($"Error occurred while reading initial RNG state: {ex.Message}");
                    return;
                }

                SetControlEnabledState(true, B_Disconnect);

                UpdateStatus("Monitoring RNG State...");
                try
                {
                    stop = false;

                    uint prevSeed = InitialRNGState;
                    while (!stop)
                    {
                        if (ConnectionWrapper.Connected && !readPause)
                        {
                            if (reset)
                            {
                                InitialRNGState = await ConnectionWrapper.GetInitialRNGState(token).ConfigureAwait(false);
                                prevSeed = InitialRNGState;
                                SetControlText($"{InitialRNGState:X8}", TB_InitialSeed);
                                reset = false;
                            }

                            if (babyMode && !babyModePrimed)
                            {
                                babyModePrimed = true;
                                await ConnectionWrapper.DoTurboCommand("Release Stick", token).ConfigureAwait(false);
                            }

                            var currSeed = await ConnectionWrapper.GetCurrentRNGState(token).ConfigureAwait(false);

                            if (currSeed == prevSeed)
                                continue;

                            total = LCRNG.GetDistance(InitialRNGState, currSeed);
                            var adv = LCRNG.GetDistance(prevSeed, currSeed);

                            if (babyMode && total >= babyModeTarget)
                            {
                                await ConnectionWrapper.PressButton(babyModeButton, 0, token).ConfigureAwait(false);
                                await ConnectionWrapper.DetachController(token).ConfigureAwait(false);
                                babyMode = false;
                                babyModePrimed = false;
                                UpdateStatus("Monitoring RNG State...");
                            }

                            SetControlText($"{currSeed:X8}", TB_CurrentSeed);
                            SetControlText($"{total:N0}", TB_CurrentAdvances);
                            SetControlText($"{adv:N0}", TB_AdvancesIncrease);

                            prevSeed = currSeed;
                        }
                    }
                }
                catch
                {
                    // Ignored
                }
            },
            token
        );
    }

    private void Disconnect(CancellationToken token)
    {
        Task.Run(
            async () =>
            {
                SetControlEnabledState(false, B_Disconnect);
                stop = true;
                try
                {
                    var (success, err) = await ConnectionWrapper.DisconnectAsync(token).ConfigureAwait(false);
                    if (!success) this.DisplayMessageBox(err);
                }
                catch (Exception ex)
                {
                    this.DisplayMessageBox(ex.Message);
                }
                await Source.CancelAsync().ConfigureAwait(false);
                Source = new();
                await GameResetSource.CancelAsync().ConfigureAwait(false);
                GameResetSource = new();
                SetControlEnabledState(true, B_Connect);
            },
            token
        );
    }

    private void UpdateStatus(string status)
    {
        SetControlText(status, TB_Status);
    }

    public void SetControlText(string text, params object[] obj)
    {
        foreach (object o in obj)
        {
            if (o is not Control c)
                continue;

            if (InvokeRequired)
                Invoke(() => c.Text = text);
            else
                c.Text = text;
        }
    }

    public void SetControlEnabledState(bool state, params object[] obj)
    {
        foreach (object o in obj)
        {
            if (o is Control c)
            {
                if (InvokeRequired)
                    Invoke(() => c.Enabled = state);
                else
                    c.Enabled = state;
            }

            if (o is ToolStripMenuItem d)
            {
                if (InvokeRequired)
                    Invoke(() => d.Enabled = state);
                else
                    d.Enabled = state;
            }
        }
    }

    public void SetControlVisibleState(bool state, params object[] obj)
    {
        foreach (object o in obj)
        {
            if (o is Control c)
            {
                if (InvokeRequired)
                    Invoke(() => c.Visible = state);
                else
                    c.Visible = state;
            }

            if (o is DataGridViewColumn d)
            {
                if (InvokeRequired)
                    Invoke(() => d.Visible = state);
                else
                    d.Visible = state;
            }
        }
    }

    public void SetBindingSourceDataSource(object source, params object[] obj)
    {
        foreach (object o in obj)
        {
            if (o is not BindingSource b)
                continue;

            if (InvokeRequired)
                Invoke(() => b.DataSource = source);
            else
                b.DataSource = source;
        }
    }

    public void SetDataGridViewDataSource(object source, params object[] obj)
    {
        foreach (object o in obj)
        {
            if (o is not DataGridView d)
                continue;

            if (InvokeRequired)
            {
                Invoke(() =>
                {
                    d.AutoGenerateColumns = true;
                    d.DataSource = source;

                    d.Columns["Seed"]?.DisplayIndex = d.Columns.Count - 1;
                    d.Columns["HP"]?.Width = 50;
                    d.Columns["Atk"]?.Width = 50;
                    d.Columns["Def"]?.Width = 50;
                    d.Columns["SpA"]?.Width = 50;
                    d.Columns["SpD"]?.Width = 50;
                    d.Columns["Spe"]?.Width = 50;


                });
            }
            else
            {
                d.AutoGenerateColumns = true;
                d.DataSource = source;

                d.Columns["Seed"]?.DisplayIndex = d.Columns.Count - 1;
                d.Columns["HP"]?.Width = 50;
                d.Columns["Atk"]?.Width = 50;
                d.Columns["Def"]?.Width = 50;
                d.Columns["SpA"]?.Width = 50;
                d.Columns["SpD"]?.Width = 50;
                d.Columns["Spe"]?.Width = 50;
            }
        }
    }

    public void SetNUDValue(decimal val, params NumericUpDown[] nuds)
    {
        foreach (var nud in nuds)
        {
            if (InvokeRequired) Invoke(() => nud.Value = val);
            else nud.Value = val;
        }
    }

    public void SetComboBoxOption(string opt, params ComboBox[] cbs)
    {
        foreach (var cb in cbs)
        {
            if (InvokeRequired) Invoke(() => cb.SelectedIndex = cb.Items.IndexOf(opt));
            else cb.SelectedIndex = cb.Items.IndexOf(opt);
        }
    }

    public void SetComboBoxSelectedIndex(int idx, params ComboBox[] cbs)
    {
        foreach (var cb in cbs)
        {
            if (InvokeRequired) Invoke(() => cb.SelectedIndex = idx);
            else cb.SelectedIndex = idx;
        }
    }

    private void B_Connect_Click(object sender, EventArgs e)
    {
        lock (_connectLock)
        {
            if (ConnectionWrapper is { Connected: true })
                return;

            ConnectionWrapper = new(ConnectionConfig, UpdateStatus);
            Connect(Source.Token);
        }
    }

    private void B_Disconnect_Click(object sender, EventArgs e)
    {
        lock (_connectLock)
        {
            if (ConnectionWrapper is not { Connected: true })
                return;

            Disconnect(Source.Token);
        }
    }


    private static ShinyType GetFilterShinyType(int selected) => selected switch
    {
        1 => ShinyType.Either,
        2 => ShinyType.Square,
        3 => ShinyType.Star,
        4 => ShinyType.None,
        _ => ShinyType.Any,
    };

    private static Nature GetFilterNatureType(int selected) => selected switch
    {
        0 => Nature.Random,
        _ => (Nature)(selected - 1),
    };

    private void B_IV_Max_Click(object sender, EventArgs e)
    {
        var st = ((Button)sender).Name.Replace("B_", string.Empty).Replace("_Max", string.Empty);
        var underscore = st.IndexOf('_');
        var page = st[..underscore];
        var skill = st[(underscore + 1)..];
        List<string> stats = ModifierKeys == Keys.Shift ? ["HP", "Atk", "Def", "SpA", "SpD", "Spe"] : [skill];
        var val = ModifierKeys == Keys.Control ? 30 : 31;
        foreach (var stat in stats)
        {
            var min = (NumericUpDown)Controls.Find($"NUD_{page}_{stat}_Min", true).FirstOrDefault()!;
            var max = (NumericUpDown)Controls.Find($"NUD_{page}_{stat}_Max", true).FirstOrDefault()!;
            min.Value = val;
            max.Value = val;
        }
    }

    private void B_IV_Min_Click(object sender, EventArgs e)
    {
        var st = ((Button)sender).Name.Replace("B_", string.Empty).Replace("_Min", string.Empty);
        var underscore = st.IndexOf('_');
        var page = st[..underscore];
        var skill = st[(underscore + 1)..];
        List<string> stats = ModifierKeys == Keys.Shift ? ["HP", "Atk", "Def", "SpA", "SpD", "Spe"] : [skill];
        var val = ModifierKeys == Keys.Control ? 1 : 0;
        foreach (var stat in stats)
        {
            var min = (NumericUpDown)Controls.Find($"NUD_{page}_{stat}_Min", true).FirstOrDefault()!;
            var max = (NumericUpDown)Controls.Find($"NUD_{page}_{stat}_Max", true).FirstOrDefault()!;
            min.Value = val;
            max.Value = val;
        }
    }

    private void IV_Label_Click(object sender, EventArgs e)
    {
        var st = ((Label)sender).Name.Replace("L_", string.Empty);
        var underscore = st.IndexOf('_');
        var page = st[..underscore];
        var skill = st[(underscore + 1)..];
        List<string> stats = ModifierKeys == Keys.Shift ? ["HP", "Atk", "Def", "SpA", "SpD", "Spe"] : [skill];
        foreach (var stat in stats)
        {
            var min = (NumericUpDown)Controls.Find($"NUD_{page}_{stat}_Min", true).FirstOrDefault()!;
            var max = (NumericUpDown)Controls.Find($"NUD_{page}_{stat}_Max", true).FirstOrDefault()!;
            var lab = (Label)Controls.Find($"L_{page}_{stat}Spacer", true).FirstOrDefault()!;
            min.Value = 0;
            max.Value = 31;
            if (lab.Text == "||")
            {
                lab.Text = "~";
                lab.Location = lab.Location with { X = lab.Location.X - 1 };
            }
        }
    }

    private void IV_Spacer_Click(object sender, EventArgs e)
    {
        var l = (Label)sender;
        if (l.Text == "~")
        {
            l.Text = "||";
            l.Location = l.Location with { X = l.Location.X + 1 };
        }
        else
        {
            l.Text = "~";
            l.Location = l.Location with { X = l.Location.X - 1 };
        }
    }

    private void CB_Game_SelectedIndexChanged(object sender, EventArgs e)
    {
        Config.Game = CB_Game.SelectedIndex;
        UpdateStaticSpeciesList();
        ReloadEncounterList();
    }

    private void UpdateStaticSpeciesList() => UpdateStaticSpeciesList((Game)CB_Game.SelectedIndex);

    private void UpdateStaticSpeciesList(Game game)
    {
        var list = GetStaticEncounterSpeciesList(game);
        var combobox = CB_Static_Species;
        combobox.Items.Clear();
        foreach (var item in list)
        {
            combobox.Items.Add(item);
        }
    }

    private void UpdateEncounterSlotsSpecies()
    {
        var game = (Game)CB_Game.SelectedIndex;
    }

    private void CB_Area_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateEncounterSlotsSpecies();
    }

    private void TB_TID_TextChanged(object sender, EventArgs e)
    {
        if (TB_TID.Text.Length > 0)
        {
            var tid = int.Parse(TB_TID.Text);
            if (tid > 0xFFFF)
            {
                tid = 0xFFFF;
                SetControlText($"{tid}", TB_TID);
            }
            Config.TID = tid;
        }
    }

    private void TB_SID_TextChanged(object sender, EventArgs e)
    {
        if (TB_SID.Text.Length > 0)
        {
            var sid = int.Parse(TB_SID.Text);
            if (sid > 0xFFFF)
            {
                sid = 0xFFFF;
                SetControlText($"{sid}", TB_SID);
            }
            Config.SID = sid;
        }
    }

    private void TB_SwitchIP_TextChanged(object sender, EventArgs e)
    {
        if (Config.Protocol is SwitchProtocol.WiFi)
        {
            Config.IP = TB_SwitchIP.Text;
            ConnectionConfig.IP = TB_SwitchIP.Text;
        }
        else
        {
            if (int.TryParse(TB_SwitchIP.Text, out var port) && port >= 0)
            {
                Config.UsbPort = port;
                ConnectionConfig.Port = port;
                return;
            }

            MessageBox.Show("Please enter a valid numerical USB port.");
        }
    }

    private readonly JsonSerializerOptions options = new() { WriteIndented = true };
    private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
    {
        var configpath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
        string output = JsonSerializer.Serialize(Config, options);
        using StreamWriter sw = new(configpath);
        sw.Write(output);

        if (ConnectionWrapper is { Connected: true })
        {
            try
            {
                _ = ConnectionWrapper.DisconnectAsync(Source.Token).ConfigureAwait(false);
            }
            catch
            {
                // ignored
            }
        }

        Source.Cancel();
        Source = new();
    }

    private void B_ReadWildPokemon_Click(object sender, EventArgs e)
    {
        if (ConnectionWrapper.Connected)
        {
            Task.Run(async () =>
            {
                try
                {
                    readPause = true;
                    await Task.Delay(100, Source.Token).ConfigureAwait(false);
                    var pk = await ConnectionWrapper.ReadEncounter(Source.Token).ConfigureAwait(false);
                    readPause = false;
                    if (pk is { Valid: true, Species: > 0 })
                    {
                        _enc = pk;
                        SetControlText(ParsePK3(pk), TB_Wild);
                    }
                    else
                    {
                        SetControlText("Not found!", TB_Wild);
                    }
                }
                catch (Exception ex)
                {
                    this.DisplayMessageBox(ex.Message);
                }
            });
        }
    }

    private void B_ReadParty_Click(object sender, EventArgs e)
    {
        if (ConnectionWrapper.Connected)
        {
            Task.Run(async () =>
            {
                try
                {
                    readPause = true;
                    await Task.Delay(100, Source.Token).ConfigureAwait(false);
                    var slot = NUD_PartySlot.GetValue();
                    var pk = await ConnectionWrapper.ReadPartyPokemon(slot, Source.Token).ConfigureAwait(false);
                    readPause = false;
                    if (pk is { Valid: true, Species: > 0 })
                    {
                        _enc = pk;
                        SetControlText(ParsePK3(pk), TB_Wild);
                    }
                    else
                    {
                        SetControlText("Not found!", TB_Wild);
                    }
                }
                catch (Exception ex)
                {
                    this.DisplayMessageBox(ex.Message);
                }
            });
        }
    }


    private void AllowOnlyHex_KeyPress(object sender, KeyPressEventArgs e)
    {
        var c = e.KeyChar;
        if (c != (char)Keys.Back && !char.IsControl(c))
        {
            if (!c.IsHex())
            {
                System.Media.SystemSounds.Asterisk.Play();
                e.Handled = true;
            }
        }
    }

    public void AllowOnlyNumerical_KeyPress(object sender, KeyPressEventArgs e)
    {
        var c = e.KeyChar;
        if (c != (char)Keys.Back && !char.IsControl(c))
        {
            if (!c.IsDec())
            {
                System.Media.SystemSounds.Asterisk.Play();
                e.Handled = true;
            }
        }
    }

    public void AllowOnlyIP_KeyPress(object sender, KeyPressEventArgs e)
    {
        var c = e.KeyChar;
        if (c == (char)Keys.Return)
        {
            B_Connect_Click(sender, EventArgs.Empty);
        }
        else if (c != (char)Keys.Back && !char.IsControl(c))
        {
            if (!c.IsDec(true))
            {
                System.Media.SystemSounds.Asterisk.Play();
                e.Handled = true;
            }
        }
    }

    public void State_HandlePaste(object sender, KeyEventArgs e)
    {
        if (e is not { Modifiers: Keys.Control, KeyCode: Keys.V } && e is not { Modifiers: Keys.Shift, KeyCode: Keys.Insert }) return;
        var n = string.Empty;
        foreach (char c in Clipboard.GetText())
        {
            if (c.IsHex()) n += c;
        }

        var l = n.Length;
        if (l == 0)
        {
            Clipboard.Clear();
            return;
        }
        if (l > 8)
        {
            ((TextBox)sender).Text = n[..8];
        }
        else
        {
            Clipboard.SetText(n);
        }
    }

    public void Dec_HandlePaste(object sender, KeyEventArgs e)
    {
        if (e is not { Modifiers: Keys.Control, KeyCode: Keys.V } && e is not { Modifiers: Keys.Shift, KeyCode: Keys.Insert }) return;
        var n = string.Empty;

        foreach (char c in Clipboard.GetText())
        {
            if (c.IsDec()) n += c;
        }

        var l = n.Length;
        var tb = (TextBox)sender;
        var max = tb.MaxLength;
        if (l == 0)
        {
            Clipboard.Clear();
        }
        else if (l > max)
        {
            tb.Text = n[..max];
        }
        else
        {
            Clipboard.SetText(n);
        }
    }

    private void IP_HandlePaste(object sender, KeyEventArgs e)
    {
        if (e is not { Modifiers: Keys.Control, KeyCode: Keys.V } && e is not { Modifiers: Keys.Shift, KeyCode: Keys.Insert }) return;
        var n = string.Empty;

        foreach (char c in Clipboard.GetText())
        {
            if (c.IsDec(true)) n += c;
        }

        var l = n.Length;
        var tb = (TextBox)sender;
        var max = tb.MaxLength;
        if (l == 0)
        {
            Clipboard.Clear();
        }
        else if (l > max)
        {
            tb.Text = n[..max];
        }
        else
        {
            Clipboard.SetText(n);
        }
    }

    private void ValidateInputs()
    {
        // Initial
        if (string.IsNullOrEmpty(TB_InitialSeed.GetText())) SetControlText("0", TB_InitialSeed);
        if (string.IsNullOrEmpty(TB_SIDInitial.GetText())) SetControlText("0", TB_SIDInitial);
        if (string.IsNullOrEmpty(TB_Static_Initial.GetText())) SetControlText("0", TB_Static_Initial);
        if (string.IsNullOrEmpty(TB_Wild_Initial.GetText())) SetControlText("0", TB_Wild_Initial);
        if (string.IsNullOrEmpty(TB_SS_TargetSeed.GetText())) SetControlText("0", TB_SS_TargetSeed);
        if (string.IsNullOrEmpty(TB_SIDPID.GetText())) SetControlText("0", TB_SIDPID);

        // Advances
        if (string.IsNullOrEmpty(TB_SIDAdvances.GetText())) SetControlText("0", TB_SIDAdvances);
        if (string.IsNullOrEmpty(TB_Static_Advances.GetText())) SetControlText("0", TB_Static_Advances);
        if (string.IsNullOrEmpty(TB_Wild_Advances.GetText())) SetControlText("0", TB_Wild_Advances);
        if (string.IsNullOrEmpty(TB_SS_Adv.GetText())) SetControlText("0", TB_SS_Adv);

        // Seed
        SetControlText(TB_InitialSeed.GetText().PadLeft(8, '0'), TB_InitialSeed);
        SetControlText(TB_SS_TargetSeed.GetText().PadLeft(8, '0'), TB_SS_TargetSeed);
        SetControlText(TB_SIDPID.GetText().PadLeft(8, '0'), TB_SIDPID);

        // IDs
        if (string.IsNullOrEmpty(TB_TID.GetText())) SetControlText("0", TB_TID);
        if (string.IsNullOrEmpty(TB_SID.GetText())) SetControlText("0", TB_SID);
        if (string.IsNullOrEmpty(TB_SIDSID.GetText())) SetControlText("0", TB_SIDSID);
        if (string.IsNullOrEmpty(TB_SIDTID.GetText())) SetControlText("0", TB_SIDTID);
        SetControlText(TB_TID.GetText().PadLeft(5, '0'), TB_TID);
        SetControlText(TB_SID.GetText().PadLeft(5, '0'), TB_SID);
        SetControlText(TB_SIDSID.GetText().PadLeft(5, '0'), TB_SIDSID);
        SetControlText(TB_SIDTID.GetText().PadLeft(5, '0'), TB_SIDTID);
    }

    private void CheckForUpdates()
    {
        Task.Run(async () =>
        {
            Version? latestVersion;
            try { latestVersion = GetLatestVersion(); }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception while checking for latest version: {ex}");
                return;
            }

            if (latestVersion is null || latestVersion <= CurrentVersion)
                return;

            while (!IsHandleCreated) // Wait for form to be ready
                await Task.Delay(2_000).ConfigureAwait(false);
            await InvokeAsync(() => NotifyNewVersionAvailable(latestVersion));
        });
    }

    private void NotifyNewVersionAvailable(Version version)
    {
        Text += $" - Update v{version.Major}.{version.Minor}.{version.Build} available!";

#if !DEBUG
        using Subforms.UpdateNotifPopup nup = new(CurrentVersion, version);
        if (nup.ShowDialog() == DialogResult.OK)
        {
            Process.Start(new ProcessStartInfo("https://github.com/LegoFigure11/AutomaticRadGRASSedExtrapolator/releases/")
            {
                UseShellExecute = true
            });
        }
#endif
    }

    private void CB_Delay_CheckedChanged(object sender, EventArgs e)
    {
        SetControlEnabledState(CB_Static_Delay.GetIsChecked(), NUD_Static_Delay);
    }

    internal bool TIDListSubformOpen = false;
    private TIDList? TIDListForm;
    private void B_TID_EditList_Click(object sender, EventArgs e)
    {
        if (!TIDListSubformOpen)
        {
            TIDListSubformOpen = true;
            TIDListForm = new TIDList(ref TIDs, this);
            TIDListForm.Show();
        }
        else
        {
            TIDListForm?.Focus();
        }
    }

    internal bool SeedListFormOpen = false;
    private SeedList? SeedListForm;
    private void B_SeedList_Click(object sender, EventArgs e)
    {
        if (!SeedListFormOpen)
        {
            SeedListFormOpen = true;
            SeedListForm = new SeedList(ref Seeds, this);
            SeedListForm.Show();
        }
        else
        {
            SeedListForm?.Focus();
        }
    }

    internal bool ResetSettingsFormOpen = false;
    private ResetSettings? ResetSettingsForm;
    private void B_ResetSettings_Click(object sender, EventArgs e)
    {
        if (!ResetSettingsFormOpen)
        {
            ResetSettingsFormOpen = true;
            ResetSettingsForm = new ResetSettings(ref Config, this);
            ResetSettingsForm.Show();
        }
        else
        {
            ResetSettingsForm?.Focus();
        }
    }

    private void B_TID_Reset_Click(object sender, EventArgs e)
    {
        if (ConnectionWrapper.Connected)
        {
            readPause = true;
            reset = true;
            SetControlEnabledState(false, B_TID_Reset);
            SetControlEnabledState(true, B_TID_Cancel);
            Task.Run(async () =>
            {
                try
                {
                    // Try to connect controller
                    await ConnectionWrapper.DoTurboCommand("Release Stick", GameResetSource.Token).ConfigureAwait(false);
                    await Task.Delay(100, Source.Token).ConfigureAwait(false);

                    List<ushort> IDs = [];

                    var init = await ConnectionWrapper.GetInitialRNGState(GameResetSource.Token).ConfigureAwait(false);

                    var found = false;
                    var ct = 0;

                    // Main TID Loop
                    do
                    {
                        // ID List can be updated between resets, so we need to re-parse it every time
                        IDs.Clear();
                        foreach (string ID in TIDs)
                        {
                            if (ushort.TryParse(ID, out ushort tid)) IDs.Add(tid);
                        }


                        // Name entry, will throw if invalid
                        var name = Config.OT_Name;
                        var buttons = KeyboardTools.GetInputsForName(name);
                        UpdateStatus($"Entering name: {name}");
                        foreach (var input in buttons)
                        {
                            await ConnectionWrapper.PressButton(input, Config.NameEntryButtonPressDelay, GameResetSource.Token).ConfigureAwait(false);
                            if (input is SwitchButton.MINUS) await Task.Delay(Config.NameEntryPageChangeDelay, GameResetSource.Token).ConfigureAwait(false);
                        }
                        await ConnectionWrapper.PressButton(SwitchButton.A, Config.NameEntryButtonPressDelay, GameResetSource.Token).ConfigureAwait(false);

                        // OT entered, check TID. Try for up to 10 sec, otherwise assume same TID was hit twice consecutively
                        var rng = await ConnectionWrapper.GetInitialRNGState(GameResetSource.Token).ConfigureAwait(false);
                        for (var tries = 0; tries < 100 && rng == init; tries++)
                        {
                            await Task.Delay(100, GameResetSource.Token).ConfigureAwait(false);
                            rng = await ConnectionWrapper.GetInitialRNGState(GameResetSource.Token).ConfigureAwait(false);
                        }

                        UpdateStatus($"Found TID: {rng:D5} | {ct}");
                        SetControlText($"{rng:X8}", TB_InitialSeed);
                        SetControlText($"{rng:D5}", TB_TID, TB_SIDTID);
                        await Task.Delay(Config.NameEntryRejectDelay, GameResetSource.Token).ConfigureAwait(false);
                        init = rng;
                        if (IDs.Contains(rng)) found = true;
                        ct++;
                        if (!found) await ConnectionWrapper.PressButton(SwitchButton.B, Config.NameEntryReloadNameScreenDelay, GameResetSource.Token).ConfigureAwait(false);

                    } while (!found && !GameResetSource.IsCancellationRequested);

                    await ConnectionWrapper.PressHOME(0, Source.Token).ConfigureAwait(false);
                    await ConnectionWrapper.DetachController(Source.Token);
                    _ = true;
                    readPause = false;
                    SetControlEnabledState(true, B_TID_Reset);
                    SetControlEnabledState(false, B_TID_Cancel);
                }
                catch (Exception ex)
                {
                    readPause = false;
                    SetControlEnabledState(true, B_TID_Reset);
                    SetControlEnabledState(false, B_TID_Cancel);
                    await ConnectionWrapper.DetachController(Source.Token);
                    if (ex is not TaskCanceledException) this.DisplayMessageBox(ex.Message);
                }
            });
        }
    }

    private void B_Reset_Cancel_Click(object sender, EventArgs e)
    {
        GameResetSource.Cancel();
        GameResetSource = new();
    }

    private void CB_SID_Delay_CheckedChanged(object sender, EventArgs e)
    {
        SetControlEnabledState(CB_SID_Delay.GetIsChecked(), NUD_SID_Delay);
    }

    private void B_SID_Generate_Click(object sender, EventArgs e)
    {
        ValidateInputs();
        SetControlEnabledState(false, B_SID_Generate);
        Task.Run(async () =>
        {
            var seed = uint.Parse(TB_InitialSeed.Text, NumberStyles.AllowHexSpecifier);
            var start = uint.Parse(TB_SIDInitial.Text);
            var end = uint.Parse(TB_SIDAdvances.Text);
            var cfg = new SIDConfig()
            {
                SID = ushort.Parse(TB_SIDSID.Text),
                TID = ushort.Parse(TB_SIDTID.Text),
                PID = uint.Parse(TB_SIDPID.Text, NumberStyles.AllowHexSpecifier),

                UseDelay = CB_SID_Delay.GetIsChecked(),
                Delay = NUD_SID_Delay.GetValue(),

                FiltersEnabled = CB_SID_FiltersEnabled.GetIsChecked(),

                SearchMode = RB_SID_SpecificValue.GetIsChecked() ? SIDSearchMode.SpecificSID : SIDSearchMode.FromPID,
            };
            var sidFrames = await Core.RNG.SID.Generate(seed, start, end, cfg);

            SetBindingSourceDataSource(sidFrames, BS_SID);
            SetDataGridViewDataSource(BS_SID, DGV_Results);
            SetControlEnabledState(true, B_SID_Generate);
            Frames = [.. sidFrames.Cast<object>()];
        });
    }

    private void RB_SID_SpecificValue_CheckedChanged(object sender, EventArgs e)
    {
        SetControlEnabledState(RB_SID_SpecificValue.GetIsChecked(), L_SIDSID, TB_SIDSID);
        SetControlEnabledState(!RB_SID_SpecificValue.GetIsChecked(), L_SIDPID, TB_SIDPID, L_SIDTID, TB_SIDTID);
    }

    private void B_ReadIDs_Click(object sender, EventArgs e)
    {
        readPause = true;
        SetControlEnabledState(false, B_ReadIDs);
        Task.Run(async () =>
        {
            try
            {
                await Task.Delay(100, Source.Token).ConfigureAwait(false);
                var (tid, sid) = await ConnectionWrapper.GetSavIDs(Source.Token).ConfigureAwait(false);
                SetControlText($"{tid:D5}", TB_TID, TB_SIDTID);
                SetControlText($"{sid:D5}", TB_SID, TB_SIDSID);

                readPause = false;

                SetControlEnabledState(true, B_ReadIDs);

            }
            catch (Exception ex)
            {
                readPause = false;

                SetControlEnabledState(true, B_ReadIDs);
                this.DisplayMessageBox(ex.Message);
            }
        });
    }

    private void B_ReadTempTID_Click(object sender, EventArgs e)
    {
        readPause = true;
        SetControlEnabledState(false, B_ReadIDs);
        Task.Run(async () =>
        {
            try
            {
                await Task.Delay(100, Source.Token).ConfigureAwait(false);
                var tid = await ConnectionWrapper.GetInitialRNGState(Source.Token).ConfigureAwait(false);
                SetControlText($"{tid:D5}", TB_TID, TB_SIDTID);

                readPause = false;

                SetControlEnabledState(true, B_ReadIDs);

            }
            catch (Exception ex)
            {
                readPause = false;

                SetControlEnabledState(true, B_ReadIDs);
                this.DisplayMessageBox(ex.Message);
            }
        });
    }

    private void B_SS_FindMax_Click(object sender, EventArgs e)
    {
        ValidateInputs();
        Task.Run(async () =>
        {
            var seed = uint.Parse(TB_SS_TargetSeed.GetText(), NumberStyles.AllowHexSpecifier);
            var count = NUD_SS_NumSeeds.GetValue();

            var (advance, _) = await Core.RNG.Back16.FindMaxAdvance(seed, (ushort)count).ConfigureAwait(false);
            SetControlText($"{advance:N0}", TB_SS_MaxAdv);
        });
    }

    private void B_SS_CountSeeds_Click(object sender, EventArgs e)
    {
        ValidateInputs();
        Task.Run(async () =>
        {
            var seed = uint.Parse(TB_SS_TargetSeed.GetText(), NumberStyles.AllowHexSpecifier);
            var max = uint.Parse(TB_SS_Adv.GetText());

            var ct = await Core.RNG.Back16.CountSeedsInRange(seed, max).ConfigureAwait(false);
            SetControlText($"{ct:N0}", TB_SS_SeedCount);
        });
    }

    private void RB_SS_CheckChanged(object sender, EventArgs e)
    {
        SetControlEnabledState(RB_SS_Number.GetIsChecked(), L_SS_NumSeeds, L_SS_MaxAdv, NUD_SS_NumSeeds, TB_SS_MaxAdv, B_SS_FindMax);
        SetControlEnabledState(RB_SS_Distance.GetIsChecked(), L_SS_Adv, TB_SS_Adv, L_SS_SeedCount, TB_SS_SeedCount, B_SS_CountSeeds);
        SetControlEnabledState(RB_SS_SpecificSeed.GetIsChecked(), L_SS_SeedList, B_SS_SeedList);
    }

    private void B_ResetSeed_Click(object sender, EventArgs e)
    {
        ValidateInputs();
        if (ConnectionWrapper.Connected)
        {
            readPause = true;
            reset = true;
            SetControlEnabledState(false, B_ResetSeed);
            SetControlEnabledState(true, B_CancelSeedReset);

            Task.Run(async () =>
            {
                try
                {
                    // Try to connect controller
                    await ConnectionWrapper.DoTurboCommand("Release Stick", GameResetSource.Token).ConfigureAwait(false);
                    await Task.Delay(100, Source.Token).ConfigureAwait(false);

                    List<ushort> specificSeeds = [];

                    var found = false;
                    var ct = 0;
                    ushort init = 0;
                    var target = uint.Parse(TB_SS_TargetSeed.GetText(), NumberStyles.AllowHexSpecifier);

                    // Main Seed Reset Loop
                    do
                    {
                        List<ushort> seeds = [];

                        if (RB_SS_SpecificSeed.GetIsChecked())
                        {
                            foreach (string seed in Seeds)
                            {
                                var s = Encoding.UTF8.GetBytes(seed);
                                if (ushort.TryParse(s, NumberStyles.AllowHexSpecifier, null, out ushort sd)) seeds.Add(sd);
                            }
                        }
                        else
                        {
                            target = uint.Parse(TB_SS_TargetSeed.GetText(), NumberStyles.AllowHexSpecifier);

                            if (RB_SS_Number.GetIsChecked())
                            {
                                var count = NUD_SS_NumSeeds.GetValue();
                                seeds = await Core.RNG.Back16.GetSeedsByCount(target, count).ConfigureAwait(false);
                            }
                            else if (RB_SS_Distance.GetIsChecked())
                            {
                                var dist = uint.Parse(TB_SS_Adv.GetText());
                                seeds = await Core.RNG.Back16.GetSeedsByAdvances(target, dist).ConfigureAwait(false);
                            }
                        }

                        // Finished seed parsing
                        UpdateStatus($"Waiting for RNG | {ct}");
                        await Task.Delay(Util.Rand.Next(0, 5000), GameResetSource.Token).ConfigureAwait(false);
                        while (!await ConnectionWrapper.GetIsBoxPointerLoaded(GameResetSource.Token).ConfigureAwait(false))
                        {
                            await ConnectionWrapper.PressButton(SwitchButton.A, 50 + Util.Rand.Next(0, 950), GameResetSource.Token).ConfigureAwait(false);
                        }

                        UpdateStatus("Reading Initial Seed");
                        init = await ConnectionWrapper.GetInitialRNGState(GameResetSource.Token).ConfigureAwait(false);

                        UpdateStatus($"Found Seed: {init:X4} | {ct}");
                        SetControlText($"{init:X8}", TB_InitialSeed);

                        if (seeds.Contains(init)) found = true;
                        ct++;
                        if (!found) await ConnectionWrapper.SoftReset(GameResetSource.Token).ConfigureAwait(false);

                    } while (!found && !GameResetSource.IsCancellationRequested);

                    await ConnectionWrapper.PressHOME(0, Source.Token).ConfigureAwait(false);
                    await ConnectionWrapper.DetachController(Source.Token);
                    readPause = false;
                    SetControlEnabledState(true, B_ResetSeed);
                    SetControlEnabledState(false, B_CancelSeedReset);
                    this.DisplayMessageBox($"Found Initial Seed 0x{init:X4} after {ct} attempt{(ct == 1 ? string.Empty : "s")}\nDistance to Target Seed: {LCRNG.GetDistance(init, target):N0}", "Seed Result");
                }
                catch (Exception ex)
                {
                    readPause = false;
                    SetControlEnabledState(true, B_ResetSeed);
                    SetControlEnabledState(false, B_CancelSeedReset);
                    await ConnectionWrapper.DetachController(Source.Token);
                    if (ex is not TaskCanceledException) this.DisplayMessageBox(ex.Message);
                }
            });
        }
    }

    private void B_Static_Search_Click(object sender, EventArgs e)
    {
        SetControlEnabledState(false, B_Static_Search);
        ValidateInputs();
        Task.Run(async () =>
        {
            var seed = uint.Parse(TB_InitialSeed.GetText(), NumberStyles.AllowHexSpecifier);
            var start = uint.Parse(TB_Static_Initial.GetText());
            var end = uint.Parse(TB_Static_Advances.GetText());

            var enc = GetStaticEncounterFromSpecies(
                GetStaticEncounterSpeciesList(
                    (Game)Config.Game
                )[CB_Static_Species.GetSelectedIndex()], (Game)Config.Game
            );

            var cfg = new StaticConfig()
            {
                SID = ushort.Parse(TB_SID.GetText()),
                TID = ushort.Parse(TB_TID.GetText()),

                UseDelay = CB_Static_Delay.GetIsChecked(),
                Delay = NUD_Static_Delay.GetValue(),

                TargetShiny = GetFilterShinyType(CB_Static_Shiny.GetSelectedIndex()),
                TargetNature = GetFilterNatureType(CB_Static_Nature.GetSelectedIndex()),

                TargetMinIVs = [NUD_Static_HP_Min.GetValue(), NUD_Static_Atk_Min.GetValue(), NUD_Static_Def_Min.GetValue(), NUD_Static_SpA_Min.GetValue(), NUD_Static_SpD_Min.GetValue(), NUD_Static_Spe_Min.GetValue()],
                TargetMaxIVs = [NUD_Static_HP_Max.GetValue(), NUD_Static_Atk_Max.GetValue(), NUD_Static_Def_Max.GetValue(), NUD_Static_SpA_Max.GetValue(), NUD_Static_SpD_Max.GetValue(), NUD_Static_Spe_Max.GetValue()],
                SearchTypes = [GetIVSearchType(L_Static_HPSpacer.GetText()), GetIVSearchType(L_Static_AtkSpacer.GetText()), GetIVSearchType(L_Static_DefSpacer.GetText()), GetIVSearchType(L_Static_SpASpacer.GetText()), GetIVSearchType(L_Static_SpDSpacer.GetText()), GetIVSearchType(L_Static_SpeSpacer.GetText())],

                Encounter = enc,

                BuggedRoamer = CB_Static_RoamerBug.GetIsChecked(),

                FiltersEnabled = CB_Static_FiltersEnabled.GetIsChecked(),
            };
            var staticFrames = await Core.RNG.Static.Generate(seed, start, end, cfg);

            SetBindingSourceDataSource(staticFrames, BS_Static);
            SetDataGridViewDataSource(BS_Static, DGV_Results);
            SetControlEnabledState(true, B_Static_Search);
            Frames = [.. staticFrames.Cast<object>()];
        });
    }

    private void CB_Static_Delay_CheckedChanged(object sender, EventArgs e)
    {
        SetControlEnabledState(CB_Static_Delay.GetIsChecked(), NUD_Static_Delay);
    }

    private void B_BabyMode_Go_Click(object sender, EventArgs e)
    {
        ValidateInputs();
        babyModeTarget = uint.Parse(TB_BabyMode.GetText());
        var delay = CB_BabyModeDelay.GetIsChecked() ? NUD_BabyModeDelay.GetValue() : 0u;
        babyModeTarget -= delay;
        babyMode = true;
        babyModePrimed = false;
        UpdateStatus($"Primed: {babyModeTarget:N0}");
    }

    private void B_BabyMode_Cancel_Click(object sender, EventArgs e)
    {
        babyMode = false;
        babyModePrimed = false;
        UpdateStatus("Monitoring RNG State...");
        try
        {
            Task.Run(async () =>
            {
                await ConnectionWrapper.DetachController(Source.Token).ConfigureAwait(false);
            });
        }
        catch
        {
            // Ignored
        }
    }

    private void CB_BabyModeDelay_CheckedChanged(object sender, EventArgs e)
    {
        SetControlEnabledState(CB_BabyModeDelay.GetIsChecked(), NUD_BabyModeDelay);
    }

    private void DGV_Results_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
    {
        var index = e.RowIndex;
        if (Frames.Count <= index) return;
        var row = DGV_Results.Rows[index];
        var result = Frames[index];

        if (result is IShinyFrame s)
        {
            if (s.Shiny is "Square") row.DefaultCellStyle.BackColor = Color.LightCyan;
            else if (s.Shiny.Contains("Star")) row.DefaultCellStyle.BackColor = Color.PapayaWhip;
            else row.DefaultCellStyle.BackColor = row.Index % 2 == 0 ? Color.White : Color.WhiteSmoke;
        }

        if (Config.ColorHiddenPowerResults && result is IHiddenPowerFrame hp)
        {
            var pow = DGV_Results.Columns["Power"]!.Index;
            var typ = DGV_Results.Columns["Hidden"]!.Index;
            if (hp.Power == 70) row.Cells[pow].Style.Font = BoldFont;
            else row.Cells[pow].Style.Font = row.DefaultCellStyle.Font;

            var color = WinFormsUtil.GetHiddenPowerColor(hp.Hidden);
            row.Cells[pow].Style.BackColor = color;
            row.Cells[typ].Style.BackColor = color;
        }

        // IVs
        if (result is IIVFrame iv)
        {
            string[] stats = ["HP", "Atk", "Def", "SpA", "SpD", "Spe"];
            byte[] ivs = [iv.HP, iv.Atk, iv.Def, iv.SpA, iv.SpD, iv.Spe];
            for (var i = 0; i < stats.Length; i++)
            {
                var col = DGV_Results.Columns[stats[i]]!.Index;
                if (ivs[i] == 0)
                {
                    row.Cells[col].Style.Font = BoldFont;
                    row.Cells[col].Style.ForeColor = Color.OrangeRed;
                }
                else if (ivs[i] == 31)
                {
                    row.Cells[col].Style.Font = BoldFont;
                    row.Cells[col].Style.ForeColor = Color.SeaGreen;
                }
                else
                {
                    row.Cells[col].Style.ForeColor = row.DefaultCellStyle.ForeColor;
                    row.Cells[col].Style.Font = row.DefaultCellStyle.Font;
                }
            }
        }
    }

    private void CB_Wild_Encounter_SelectedIndexChanged(object sender, EventArgs e)
    {
        ReloadEncounterList();
    }

    private void ReloadEncounterList()
    {
        CB_Wild_Area.Items.Clear();
        var items = GetEncounterAreas((Game)CB_Game.GetSelectedIndex(), (EncounterTableType)CB_Wild_Encounter.GetSelectedIndex());
        foreach (var item in items) CB_Wild_Area.Items.Add(item);
        CB_Wild_Area.SelectedIndex = 0;
    }

    private void CB_Wild_Area_SelectedIndexChanged(object sender, EventArgs e)
    {
        CB_Wild_Species.Items.Clear();
        var items = GetEncounterAreaSpecies((Game)CB_Game.GetSelectedIndex(), (EncounterTableType)CB_Wild_Encounter.GetSelectedIndex(), CB_Wild_Area.GetSelectedIndex());
        items.Sort();

        CB_Wild_Species.Items.Add("(Any)");
        foreach (var item in items) CB_Wild_Species.Items.Add(item);

        CB_Wild_Species.SelectedIndex = 0;
    }

    private void B_Wild_Generate_Click(object sender, EventArgs e)
    {
        SetControlEnabledState(false, B_Wild_Generate);
        ValidateInputs();
        var s = CB_Wild_Species.SelectedItem!.ToString();
        Task.Run(async () =>
        {
            var seed = uint.Parse(TB_InitialSeed.GetText(), NumberStyles.AllowHexSpecifier);
            var start = uint.Parse(TB_Wild_Initial.GetText());
            var end = uint.Parse(TB_Wild_Advances.GetText());

            var enc = GetEncounterSlotEncounters((Game)CB_Game.GetSelectedIndex(), (EncounterTableType)CB_Wild_Encounter.GetSelectedIndex(), CB_Wild_Area.GetSelectedIndex());
            _ = SpeciesName.TryGetSpecies(s, 2, out var species);

            var cfg = new WildConfig()
            {
                SID = ushort.Parse(TB_SID.GetText()),
                TID = ushort.Parse(TB_TID.GetText()),

                UseDelay = CB_Wild_Delay.GetIsChecked(),
                Delay = NUD_Wild_Delay.GetValue(),

                Method = Method.MethodH1 + CB_Wild_Method.GetSelectedIndex(),

                TargetShiny = GetFilterShinyType(CB_Wild_Shiny.GetSelectedIndex()),
                TargetNature = GetFilterNatureType(CB_Wild_Nature.GetSelectedIndex()),

                TargetMinIVs = [NUD_Wild_HP_Min.GetValue(), NUD_Wild_Atk_Min.GetValue(), NUD_Wild_Def_Min.GetValue(), NUD_Wild_SpA_Min.GetValue(), NUD_Wild_SpD_Min.GetValue(), NUD_Wild_Spe_Min.GetValue()],
                TargetMaxIVs = [NUD_Wild_HP_Max.GetValue(), NUD_Wild_Atk_Max.GetValue(), NUD_Wild_Def_Max.GetValue(), NUD_Wild_SpA_Max.GetValue(), NUD_Wild_SpD_Max.GetValue(), NUD_Wild_Spe_Max.GetValue()],
                SearchTypes = [GetIVSearchType(L_Wild_HPSpacer.GetText()), GetIVSearchType(L_Wild_AtkSpacer.GetText()), GetIVSearchType(L_Wild_DefSpacer.GetText()), GetIVSearchType(L_Wild_SpASpacer.GetText()), GetIVSearchType(L_Wild_SpDSpacer.GetText()), GetIVSearchType(L_Wild_SpeSpacer.GetText())],

                Type = EncounterTableType.GrassCave + CB_Wild_Encounter.GetSelectedIndex(),
                Table = enc,

                FilterBySpecies = CB_Wild_Species.GetSelectedIndex() != 0,
                TargetSpecies = species,

                RarePID = CB_Wild_RareEC.GetIsChecked(),

                FiltersEnabled = CB_Wild_FiltersEnabled.GetIsChecked(),
            };
            var wildFrames = await Core.RNG.Wild.Generate(seed, start, end, cfg);

            SetBindingSourceDataSource(wildFrames, BS_Wild);
            SetDataGridViewDataSource(BS_Wild, DGV_Results);
            SetControlEnabledState(true, B_Wild_Generate);
            Frames = [.. wildFrames.Cast<object>()];
        });
    }

    private void B_CopyIVs_Click(object sender, EventArgs e)
    {
        foreach (Control ctrl in TC_Main.SelectedTab!.Controls)
        {
            if (ctrl is GroupBox gb)
            {
                if (gb.Name.EndsWith("_Filters"))
                {
                    foreach (Control child in gb.Controls)
                    {
                        if (child is NumericUpDown nud)
                        {
                            if (nud.Name.IndexOf("HP") > 0) nud.Value = _enc.IV_HP;
                            else if (nud.Name.IndexOf("Atk") > 0) nud.Value = _enc.IV_ATK;
                            else if (nud.Name.IndexOf("Def") > 0) nud.Value = _enc.IV_DEF;
                            else if (nud.Name.IndexOf("SpA") > 0) nud.Value = _enc.IV_SPA;
                            else if (nud.Name.IndexOf("SpD") > 0) nud.Value = _enc.IV_SPD;
                            else if (nud.Name.IndexOf("Spe") > 0) nud.Value = _enc.IV_SPE;
                        }
                    }
                }
            }
        }
    }

    private void CB_BabyMode_Action_SelectedIndexChanged(object sender, EventArgs e)
    {
        babyModeButton = CB_BabyMode_Action.GetSelectedIndex() == 0 ? SwitchButton.A : SwitchButton.HOME;
    }

    private void CB_Wild_Delay_CheckedChanged(object sender, EventArgs e)
    {
        SetControlEnabledState(CB_Wild_Delay.GetIsChecked(), NUD_Wild_Delay);
    }
}

