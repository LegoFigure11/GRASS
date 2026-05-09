using GRASS.Core.RNG;
using System.Diagnostics;
using System.Text.Json;

namespace GRASS.WinForms.Subforms;

public partial class TIDList : Form
{
    private readonly List<string> IDs;
    private readonly BindingSource bs = [];
    private readonly MainWindow parent;

    public TIDList(ref List<string> IDs, MainWindow parent)
    {
        InitializeComponent();

        this.IDs = IDs;
        this.parent = parent;

        CB_CombineMode.SelectedIndex = 0;

        ReloadList();
    }

    private void ReloadList()
    {
        if (bs.DataSource is null)
        {
            bs.DataSource = IDs;
            LB_IDs.DataSource = bs;
        }
        else
        {
            bs.ResetBindings(false);
        }
    }

    private void B_Add_Click(object sender, EventArgs e)
    {
        var ID = TB_ID.Text;
        if (!string.IsNullOrEmpty(ID))
        {
            ID = ID.PadLeft(5, '0');
            if (uint.Parse(ID) > ushort.MaxValue) ID = "65535";
            if (!IDs.Contains(ID))
            {
                IDs.Add(ID);
                ReloadList();
                LB_IDs.SelectedIndex = IDs.Count - 1;
            }
        }
    }

    private void B_Remove_Click(object sender, EventArgs e)
    {
        var ID = TB_ID.Text;
        if (!string.IsNullOrEmpty(ID))
        {
            ID = ID.PadLeft(5, '0');
            IDs.Remove(ID);
            ReloadList();
            LB_IDs_SelectedIndexChanged(sender, e);
        }
    }

    private void LB_IDs_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (LB_IDs.SelectedIndex is -1) return;
        var idx = LB_IDs.SelectedIndex;
        TB_ID.Text = IDs[idx];
    }

    private void IDList_FormClosing(object sender, FormClosingEventArgs e)
    {
        for (var i = 0; i < IDs.Count; i++)
        {
            IDs[i] = IDs[i].PadLeft(5, '0');
            if (IDs[i].Length > 5) IDs[i] = IDs[i][..5];
        }

        IDs.Sort();
        string output = JsonSerializer.Serialize(IDs);
        using StreamWriter sw = new(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tid-list.json"));
        sw.Write(output);
        parent.TIDs = IDs;
        parent.TIDListSubformOpen = false;
        parent.L_LoadedTIDs.Text = $"Loaded TIDs: {(IDs.Count == 0 ? "None" : IDs.Count)}";
    }

    private void TB_ID_KeyPress(object sender, KeyPressEventArgs e)
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

    private void B_Autofill_Click(object sender, EventArgs e)
    {
        var bin = 0;
        if (CB_Palindrome.GetIsChecked()) bin += 1 << 0;
        if (CB_OneNumber.GetIsChecked()) bin += 1 << 1;
        if (CB_TwoNumbers.GetIsChecked()) bin += 1 << 2;
        if (CB_Sequential.GetIsChecked()) bin += 1 << 3;
        if (CB_LessThan.GetIsChecked()) bin += 1 << 4;
        if (CB_GreaterThan.GetIsChecked()) bin += 1 << 5;

        var lt = NUD_LessThan.GetValue();
        var gt = NUD_GreaterThan.GetValue();

        var match = CB_CombineMode.GetSelectedIndex() == 0 ? -1 : bin & 0b111111;

        var ct = 0;

        for (uint i = 0; i <= ushort.MaxValue; i++)
        {
            var id = (ushort)i;
            var idbin = 0;
            if (((bin >> 0) & 1) == 1) idbin += (id.IsPalindrome() ? 1 : 0) << 0;
            if (((bin >> 1) & 1) == 1) idbin += (id.IsOneNumberOnly() ? 1 : 0) << 1;
            if (((bin >> 2) & 1) == 1) idbin += (id.IsTwoNumbersOnly() ? 1 : 0) << 2;
            if (((bin >> 3) & 1) == 1) idbin += (id.IsSequential() ? 1 : 0) << 3;
            if (((bin >> 4) & 1) == 1) idbin += (id.IsLessThan(lt) ? 1 : 0) << 4;
            if (((bin >> 5) & 1) == 1) idbin += (id.IsGreaterThan(gt) ? 1 : 0) << 5;

            // match == -1 when OR, else AND
            if ((match == -1 && idbin > 0) || (match & idbin) == match)
            {
                ct++;
                var t = $"{id:00000}";
                if (!IDs.Contains(t)) IDs.Add(t);
            }
        }

        if (ct > 0)
        {
            IDs.Sort();
            ReloadList();
            LB_IDs.SelectedIndex = IDs.Count - 1;
        }

        this.DisplayMessageBox($"Added {ct:N0} TID{(ct == 1 ? string.Empty : "s")} matching filters!", "TID List Autofill");
    }

    private void CB_LessThan_CheckedChanged(object sender, EventArgs e)
    {
        NUD_LessThan.Enabled = CB_LessThan.Checked;
    }

    private void CB_GreaterThan_CheckedChanged(object sender, EventArgs e)
    {
        NUD_GreaterThan.Enabled = CB_GreaterThan.Checked;
    }
}
