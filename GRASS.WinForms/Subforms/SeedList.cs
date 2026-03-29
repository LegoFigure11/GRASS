using System.Text.Json;

namespace GRASS.WinForms.Subforms;

public partial class SeedList : Form
{
    private readonly List<string> Seeds;
    private readonly BindingSource bs = [];
    private readonly MainWindow parent;

    public SeedList(ref List<string> Seeds, MainWindow parent)
    {
        InitializeComponent();

        this.Seeds = Seeds;
        this.parent = parent;

        ReloadList();
    }

    private void ReloadList()
    {
        if (bs.DataSource is null)
        {
            bs.DataSource = Seeds;
            LB_Seeds.DataSource = bs;
        }
        else
        {
            bs.ResetBindings(false);
        }
    }

    private void B_Add_Click(object sender, EventArgs e)
    {
        var Seed = TB_Seed.Text;
        if (!string.IsNullOrEmpty(Seed))
        {
            Seed = Seed.PadLeft(4, '0');
            if (uint.Parse(Seed, System.Globalization.NumberStyles.AllowHexSpecifier) > ushort.MaxValue) Seed = "FFFF";
            if (!Seeds.Contains(Seed))
            {
                Seeds.Add(Seed);
                ReloadList();
                LB_Seeds.SelectedIndex = Seeds.Count - 1;
            }
        }
    }

    private void B_Remove_Click(object sender, EventArgs e)
    {
        var Seed = TB_Seed.Text;
        if (!string.IsNullOrEmpty(Seed))
        {
            Seed = Seed.PadLeft(4, '0');
            Seeds.Remove(Seed);
            ReloadList();
            LB_Seeds_SelectedIndexChanged(sender, e);
        }
    }

    private void LB_Seeds_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LB_Seeds.SelectedIndex is -1) return;
        var idx = LB_Seeds.SelectedIndex;
        TB_Seed.Text = Seeds[idx];
    }

    private void SeedList_FormClosing(object sender, FormClosingEventArgs e)
    {
        for (var i = 0; i < Seeds.Count; i++)
        {
            Seeds[i] = Seeds[i].PadLeft(4, '0');
            if (Seeds[i].Length > 4) Seeds[i] = Seeds[i][..4];
        }

        Seeds.Sort();
        string output = JsonSerializer.Serialize(Seeds);
        using StreamWriter sw = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "seed-list.json"));
        sw.Write(output);
        parent.Seeds = Seeds;
        parent.SeedListFormOpen = false;
        parent.L_SS_SeedList.Text = $"Loaded Seeds: {(Seeds.Count == 0 ? "None" : Seeds.Count)}";
    }

    private void TB_Seed_KeyPress(object sender, KeyPressEventArgs e)
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
}
