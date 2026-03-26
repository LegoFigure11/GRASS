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
using System.Text.Json;
//using static GRASS.Core.Encounters;
using static GRASS.Core.RNG.Util;

namespace GRASS.WinForms;

public partial class MainWindow : Form
{
    private static CancellationTokenSource Source = new();
    private static readonly Lock _connectLock = new();

    public ClientConfig Config;
    private ConnectionWrapperAsync ConnectionWrapper = default!;
    private readonly SwitchConnectionConfig ConnectionConfig;

    private bool stop;
    private bool reset;
    private bool readPause;
    private uint total;

    private PK3 _enc = new();

    internal List<string> TIDs = [];

    private RadarContinuationConfig _cfg = new();

    private List<RadarContinuationFrame> ContinuationFrames = [];

    public readonly GameStrings Strings = GameInfo.GetStrings("en");

    private readonly Version CurrentVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version!;

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

        CB_Game.SelectedIndex = Config.Game;
        //UpdateEncounterSlotsAreas();

        SetComboBoxSelectedIndex(0, CB_Filter_Shiny);

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
                            var currSeed = await ConnectionWrapper.GetCurrentRNGState(token).ConfigureAwait(false);

                            if (currSeed == prevSeed)
                                continue;

                            total = LCRNG.GetDistance(InitialRNGState, currSeed);
                            var adv = LCRNG.GetDistance(prevSeed, currSeed);


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

    private readonly Color _defaultBackColor = Color.FromArgb(0, 120, 215);
    private void B_IV_Max_Click(object sender, EventArgs e)
    {
        var st = ((Button)sender).Name.Replace("B_", string.Empty).Replace("_Max", string.Empty);
        List<string> stats = ModifierKeys == Keys.Shift ? ["HP", "Atk", "Def", "SpA", "SpD", "Spe"] : [st];
        foreach (var stat in stats)
        {
            var min = (NumericUpDown)Controls.Find($"NUD_{stat}_Min", true).FirstOrDefault()!;
            var max = (NumericUpDown)Controls.Find($"NUD_{stat}_Max", true).FirstOrDefault()!;
            min.Value = 31;
            max.Value = 31;
        }
    }

    private void B_IV_Min_Click(object sender, EventArgs e)
    {
        var st = ((Button)sender).Name.Replace("B_", string.Empty).Replace("_Min", string.Empty);
        List<string> stats = ModifierKeys == Keys.Shift ? ["HP", "Atk", "Def", "SpA", "SpD", "Spe"] : [st];
        foreach (var stat in stats)
        {
            var min = (NumericUpDown)Controls.Find($"NUD_{stat}_Min", true).FirstOrDefault()!;
            var max = (NumericUpDown)Controls.Find($"NUD_{stat}_Max", true).FirstOrDefault()!;
            min.Value = 0;
            max.Value = 0;
        }
    }

    private void IV_Label_Click(object sender, EventArgs e)
    {
        var st = ((Label)sender).Name.Replace("L_", string.Empty);
        List<string> stats = ModifierKeys == Keys.Shift ? ["HP", "Atk", "Def", "SpA", "SpD", "Spe"] : [st];
        foreach (var stat in stats)
        {
            var min = (NumericUpDown)Controls.Find($"NUD_{stat}_Min", true).FirstOrDefault()!;
            var max = (NumericUpDown)Controls.Find($"NUD_{stat}_Max", true).FirstOrDefault()!;
            var lab = (Label)Controls.Find($"L_{stat}Spacer", true).FirstOrDefault()!;
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

    private void CheckForUpdates()
    {
        Task.Run(async () =>
        {
            Version? latestVersion;
            try { latestVersion = Utils.GetLatestVersion(); }
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
        SetControlEnabledState(CB_Delay.GetIsChecked(), NUD_Delay);
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
        readPause = true;
        Task.Run(async () =>
        {
            try
            {
                // Try to connect controller
                await ConnectionWrapper.DoTurboCommand("Release Stick", Source.Token).ConfigureAwait(false);
                await Task.Delay(100, Source.Token).ConfigureAwait(false);

                List<ushort> IDs = [];

                var init = await ConnectionWrapper.GetInitialRNGState(Source.Token).ConfigureAwait(false);

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
                        await ConnectionWrapper.PressButton(input, Config.NameEntryButtonPressDelay, Source.Token).ConfigureAwait(false);
                        if (input is SwitchButton.MINUS) await Task.Delay(Config.NameEntryPageChangeDelay, Source.Token).ConfigureAwait(false);
                    }
                    await ConnectionWrapper.PressButton(SwitchButton.A, Config.NameEntryButtonPressDelay, Source.Token).ConfigureAwait(false);

                    // OT entered, check TID. Try for up to 10 sec, otherwise assume same TID was hit twice consecutively
                    var rng = await ConnectionWrapper.GetInitialRNGState(Source.Token).ConfigureAwait(false);
                    for (var tries = 0; tries < 100 && rng == init; tries++)
                    {
                        await Task.Delay(100, Source.Token).ConfigureAwait(false);
                        rng = await ConnectionWrapper.GetInitialRNGState(Source.Token).ConfigureAwait(false);
                    }

                    UpdateStatus($"Found TID: {rng:D5} | {ct}");
                    SetControlText($"{rng:X8}", TB_InitialSeed);
                    await Task.Delay(Config.NameEntryRejectDelay, Source.Token).ConfigureAwait(false);
                    init = rng;
                    if (IDs.Contains(rng)) found = true;
                    ct++;
                    if (!found) await ConnectionWrapper.PressButton(SwitchButton.B, Config.NameEntryReloadNameScreenDelay, Source.Token).ConfigureAwait(false);

                } while (!found);

                await ConnectionWrapper.PressHOME(0, Source.Token).ConfigureAwait(false);
                await ConnectionWrapper.DetachController(Source.Token);
                _ = true;
                readPause = false;
            }
            catch (Exception ex)
            {
                readPause = false;
                await ConnectionWrapper.DetachController(Source.Token);
                this.DisplayMessageBox(ex.Message);
            }
        });
    }
}

