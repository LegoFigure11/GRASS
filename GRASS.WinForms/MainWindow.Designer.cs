namespace GRASS.WinForms;

    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
        GB_Connection = new GroupBox();
        TB_AdvancesIncrease = new TextBox();
        TB_Status = new TextBox();
        L_CurrentSeed = new Label();
        L_Status = new Label();
        TB_CurrentSeed = new TextBox();
        TB_CurrentAdvances = new TextBox();
        L_CurrentAdvances = new Label();
        B_Disconnect = new Button();
        B_Connect = new Button();
        L_SwitchIP = new Label();
        TB_SwitchIP = new TextBox();
        GB_Seed = new GroupBox();
        L_InitialSeed = new Label();
        TB_InitialSeed = new TextBox();
        GB_SAVInfo = new GroupBox();
        L_Game = new Label();
        CB_Game = new ComboBox();
        L_SID = new Label();
        L_TID = new Label();
        TB_SID = new TextBox();
        TB_TID = new TextBox();
        GB_Filters = new GroupBox();
        CB_Delay = new CheckBox();
        NUD_Delay = new NumericUpDown();
        CB_RareEC = new CheckBox();
        CB_EnableFilters = new CheckBox();
        L_Filter_Shiny = new Label();
        CB_Filter_Shiny = new ComboBox();
        B_Spe_Max = new Button();
        B_Spe_Min = new Button();
        L_Spe = new Label();
        L_SpeSpacer = new Label();
        NUD_Spe_Max = new NumericUpDown();
        NUD_Spe_Min = new NumericUpDown();
        B_SpD_Max = new Button();
        B_SpD_Min = new Button();
        L_SpD = new Label();
        L_SpDSpacer = new Label();
        NUD_SpD_Max = new NumericUpDown();
        NUD_SpD_Min = new NumericUpDown();
        B_SpA_Max = new Button();
        B_SpA_Min = new Button();
        L_SpA = new Label();
        L_SpASpacer = new Label();
        NUD_SpA_Max = new NumericUpDown();
        NUD_SpA_Min = new NumericUpDown();
        B_Def_Max = new Button();
        B_Def_Min = new Button();
        L_Def = new Label();
        L_DefSpacer = new Label();
        NUD_Def_Max = new NumericUpDown();
        NUD_Def_Min = new NumericUpDown();
        B_Atk_Max = new Button();
        B_Atk_Min = new Button();
        L_Atk = new Label();
        L_AtkSpacer = new Label();
        NUD_Atk_Max = new NumericUpDown();
        NUD_Atk_Min = new NumericUpDown();
        B_HP_Max = new Button();
        B_HP_Min = new Button();
        L_HP = new Label();
        L_HPSpacer = new Label();
        NUD_HP_Max = new NumericUpDown();
        NUD_HP_Min = new NumericUpDown();
        B_ReadWildPokemon = new Button();
        TB_Wild = new TextBox();
        TC_Main = new TabControl();
        TP_IDs = new TabPage();
        GB_SID = new GroupBox();
        B_ReadIDs = new Button();
        B_SID_Generate = new Button();
        L_SIDAdvances = new Label();
        L_SIDInitial = new Label();
        TB_SIDAdvances = new TextBox();
        TB_SIDInitial = new TextBox();
        CB_SID_FiltersEnabled = new CheckBox();
        CB_SID_Delay = new CheckBox();
        NUD_SID_Delay = new NumericUpDown();
        L_SIDPID = new Label();
        L_SIDTID = new Label();
        L_SIDSID = new Label();
        TB_SIDSID = new TextBox();
        TB_SIDTID = new TextBox();
        TB_SIDPID = new TextBox();
        RB_SID_FromPID = new RadioButton();
        RB_SID_SpecificValue = new RadioButton();
        groupBox1 = new GroupBox();
        B_TID_Cancel = new Button();
        B_TID_Reset = new Button();
        B_TID_EditList = new Button();
        L_LoadedTIDs = new Label();
        tabPage2 = new TabPage();
        GB_ConnectionSettings = new GroupBox();
        B_ConnectionSettings = new Button();
        DGV_Results = new DataGridView();
        advancesDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        seedDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        sIDDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
        BS_SID = new BindingSource(components);
        B_ReadTempTID = new Button();
        GB_Connection.SuspendLayout();
        GB_Seed.SuspendLayout();
        GB_SAVInfo.SuspendLayout();
        GB_Filters.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_Delay).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Spe_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Spe_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_SpD_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_SpD_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_SpA_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_SpA_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Def_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Def_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Atk_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Atk_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_HP_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_HP_Min).BeginInit();
        TC_Main.SuspendLayout();
        TP_IDs.SuspendLayout();
        GB_SID.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_SID_Delay).BeginInit();
        groupBox1.SuspendLayout();
        GB_ConnectionSettings.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)DGV_Results).BeginInit();
        ((System.ComponentModel.ISupportInitialize)BS_SID).BeginInit();
        SuspendLayout();
        // 
        // GB_Connection
        // 
        GB_Connection.Controls.Add(TB_AdvancesIncrease);
        GB_Connection.Controls.Add(TB_Status);
        GB_Connection.Controls.Add(L_CurrentSeed);
        GB_Connection.Controls.Add(L_Status);
        GB_Connection.Controls.Add(TB_CurrentSeed);
        GB_Connection.Controls.Add(TB_CurrentAdvances);
        GB_Connection.Controls.Add(L_CurrentAdvances);
        GB_Connection.Controls.Add(B_Disconnect);
        GB_Connection.Controls.Add(B_Connect);
        GB_Connection.Controls.Add(L_SwitchIP);
        GB_Connection.Controls.Add(TB_SwitchIP);
        GB_Connection.Location = new Point(0, 19);
        GB_Connection.Margin = new Padding(3, 0, 3, 3);
        GB_Connection.Name = "GB_Connection";
        GB_Connection.RightToLeft = RightToLeft.No;
        GB_Connection.Size = new Size(212, 131);
        GB_Connection.TabIndex = 2;
        GB_Connection.TabStop = false;
        // 
        // TB_AdvancesIncrease
        // 
        TB_AdvancesIncrease.CharacterCasing = CharacterCasing.Lower;
        TB_AdvancesIncrease.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_AdvancesIncrease.Location = new Point(151, 82);
        TB_AdvancesIncrease.MaxLength = 15;
        TB_AdvancesIncrease.Name = "TB_AdvancesIncrease";
        TB_AdvancesIncrease.ReadOnly = true;
        TB_AdvancesIncrease.Size = new Size(55, 22);
        TB_AdvancesIncrease.TabIndex = 21;
        TB_AdvancesIncrease.TabStop = false;
        TB_AdvancesIncrease.Text = "123,456";
        TB_AdvancesIncrease.TextAlign = HorizontalAlignment.Right;
        // 
        // TB_Status
        // 
        TB_Status.BackColor = SystemColors.Control;
        TB_Status.BorderStyle = BorderStyle.None;
        TB_Status.Location = new Point(74, 64);
        TB_Status.Name = "TB_Status";
        TB_Status.ReadOnly = true;
        TB_Status.RightToLeft = RightToLeft.No;
        TB_Status.Size = new Size(132, 16);
        TB_Status.TabIndex = 18;
        TB_Status.TabStop = false;
        TB_Status.Text = "wwwwwwwwwwwwww";
        TB_Status.TextAlign = HorizontalAlignment.Right;
        // 
        // L_CurrentSeed
        // 
        L_CurrentSeed.AutoSize = true;
        L_CurrentSeed.Location = new Point(11, 108);
        L_CurrentSeed.Name = "L_CurrentSeed";
        L_CurrentSeed.Size = new Size(78, 15);
        L_CurrentSeed.TabIndex = 10;
        L_CurrentSeed.Text = "Current Seed:";
        // 
        // L_Status
        // 
        L_Status.AutoSize = true;
        L_Status.Location = new Point(11, 64);
        L_Status.Name = "L_Status";
        L_Status.Size = new Size(42, 15);
        L_Status.TabIndex = 17;
        L_Status.Text = "Status:";
        // 
        // TB_CurrentSeed
        // 
        TB_CurrentSeed.CharacterCasing = CharacterCasing.Upper;
        TB_CurrentSeed.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_CurrentSeed.Location = new Point(144, 106);
        TB_CurrentSeed.MaxLength = 8;
        TB_CurrentSeed.Name = "TB_CurrentSeed";
        TB_CurrentSeed.ReadOnly = true;
        TB_CurrentSeed.Size = new Size(62, 22);
        TB_CurrentSeed.TabIndex = 8;
        TB_CurrentSeed.TabStop = false;
        TB_CurrentSeed.Text = "01234567";
        // 
        // TB_CurrentAdvances
        // 
        TB_CurrentAdvances.CharacterCasing = CharacterCasing.Lower;
        TB_CurrentAdvances.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_CurrentAdvances.Location = new Point(51, 82);
        TB_CurrentAdvances.MaxLength = 13;
        TB_CurrentAdvances.Name = "TB_CurrentAdvances";
        TB_CurrentAdvances.ReadOnly = true;
        TB_CurrentAdvances.Size = new Size(98, 22);
        TB_CurrentAdvances.TabIndex = 16;
        TB_CurrentAdvances.TabStop = false;
        TB_CurrentAdvances.Text = "4,294,967,295";
        TB_CurrentAdvances.TextAlign = HorizontalAlignment.Right;
        // 
        // L_CurrentAdvances
        // 
        L_CurrentAdvances.AutoSize = true;
        L_CurrentAdvances.Location = new Point(11, 87);
        L_CurrentAdvances.Name = "L_CurrentAdvances";
        L_CurrentAdvances.Size = new Size(34, 15);
        L_CurrentAdvances.TabIndex = 15;
        L_CurrentAdvances.Text = "Adv.:";
        // 
        // B_Disconnect
        // 
        B_Disconnect.Enabled = false;
        B_Disconnect.Location = new Point(109, 36);
        B_Disconnect.Name = "B_Disconnect";
        B_Disconnect.Size = new Size(97, 25);
        B_Disconnect.TabIndex = 2;
        B_Disconnect.Text = "Disconnect";
        B_Disconnect.UseVisualStyleBackColor = true;
        B_Disconnect.Click += B_Disconnect_Click;
        // 
        // B_Connect
        // 
        B_Connect.Location = new Point(11, 36);
        B_Connect.Name = "B_Connect";
        B_Connect.Size = new Size(97, 25);
        B_Connect.TabIndex = 1;
        B_Connect.Text = "Connect";
        B_Connect.UseVisualStyleBackColor = true;
        B_Connect.Click += B_Connect_Click;
        // 
        // L_SwitchIP
        // 
        L_SwitchIP.AutoSize = true;
        L_SwitchIP.Location = new Point(11, 17);
        L_SwitchIP.Name = "L_SwitchIP";
        L_SwitchIP.Size = new Size(58, 15);
        L_SwitchIP.TabIndex = 12;
        L_SwitchIP.Text = "Switch IP:";
        // 
        // TB_SwitchIP
        // 
        TB_SwitchIP.CharacterCasing = CharacterCasing.Lower;
        TB_SwitchIP.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SwitchIP.Location = new Point(95, 12);
        TB_SwitchIP.MaxLength = 15;
        TB_SwitchIP.Name = "TB_SwitchIP";
        TB_SwitchIP.Size = new Size(111, 22);
        TB_SwitchIP.TabIndex = 0;
        TB_SwitchIP.Text = "123.123.123.123";
        TB_SwitchIP.TextChanged += TB_SwitchIP_TextChanged;
        TB_SwitchIP.KeyDown += IP_HandlePaste;
        TB_SwitchIP.KeyPress += AllowOnlyIP_KeyPress;
        // 
        // GB_Seed
        // 
        GB_Seed.Controls.Add(L_InitialSeed);
        GB_Seed.Controls.Add(TB_InitialSeed);
        GB_Seed.Location = new Point(0, -8);
        GB_Seed.Name = "GB_Seed";
        GB_Seed.RightToLeft = RightToLeft.No;
        GB_Seed.Size = new Size(212, 36);
        GB_Seed.TabIndex = 3;
        GB_Seed.TabStop = false;
        // 
        // L_InitialSeed
        // 
        L_InitialSeed.AutoSize = true;
        L_InitialSeed.Location = new Point(11, 11);
        L_InitialSeed.Name = "L_InitialSeed";
        L_InitialSeed.Size = new Size(67, 15);
        L_InitialSeed.TabIndex = 6;
        L_InitialSeed.Text = "Initial Seed:";
        // 
        // TB_InitialSeed
        // 
        TB_InitialSeed.CharacterCasing = CharacterCasing.Upper;
        TB_InitialSeed.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_InitialSeed.Location = new Point(144, 9);
        TB_InitialSeed.MaxLength = 8;
        TB_InitialSeed.Name = "TB_InitialSeed";
        TB_InitialSeed.Size = new Size(62, 22);
        TB_InitialSeed.TabIndex = 0;
        TB_InitialSeed.Text = "01234567";
        TB_InitialSeed.KeyDown += State_HandlePaste;
        TB_InitialSeed.KeyPress += AllowOnlyHex_KeyPress;
        // 
        // GB_SAVInfo
        // 
        GB_SAVInfo.Controls.Add(L_Game);
        GB_SAVInfo.Controls.Add(CB_Game);
        GB_SAVInfo.Controls.Add(L_SID);
        GB_SAVInfo.Controls.Add(L_TID);
        GB_SAVInfo.Controls.Add(TB_SID);
        GB_SAVInfo.Controls.Add(TB_TID);
        GB_SAVInfo.Location = new Point(0, 141);
        GB_SAVInfo.Name = "GB_SAVInfo";
        GB_SAVInfo.Size = new Size(212, 77);
        GB_SAVInfo.TabIndex = 4;
        GB_SAVInfo.TabStop = false;
        // 
        // L_Game
        // 
        L_Game.AutoSize = true;
        L_Game.Location = new Point(11, 47);
        L_Game.Name = "L_Game";
        L_Game.Size = new Size(41, 15);
        L_Game.TabIndex = 11;
        L_Game.Text = "Game:";
        // 
        // CB_Game
        // 
        CB_Game.FormattingEnabled = true;
        CB_Game.Items.AddRange(new object[] { "FireRed", "LeafGreen" });
        CB_Game.Location = new Point(71, 44);
        CB_Game.Name = "CB_Game";
        CB_Game.Size = new Size(135, 23);
        CB_Game.TabIndex = 2;
        CB_Game.SelectedIndexChanged += CB_Game_SelectedIndexChanged;
        // 
        // L_SID
        // 
        L_SID.AutoSize = true;
        L_SID.Location = new Point(132, 18);
        L_SID.Name = "L_SID";
        L_SID.Size = new Size(27, 15);
        L_SID.TabIndex = 20;
        L_SID.Text = "SID:";
        // 
        // L_TID
        // 
        L_TID.AutoSize = true;
        L_TID.Location = new Point(25, 18);
        L_TID.Name = "L_TID";
        L_TID.Size = new Size(27, 15);
        L_TID.TabIndex = 19;
        L_TID.Text = "TID:";
        // 
        // TB_SID
        // 
        TB_SID.CharacterCasing = CharacterCasing.Upper;
        TB_SID.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SID.Location = new Point(165, 16);
        TB_SID.MaxLength = 5;
        TB_SID.Name = "TB_SID";
        TB_SID.Size = new Size(41, 22);
        TB_SID.TabIndex = 1;
        TB_SID.Text = "54321";
        TB_SID.TextChanged += TB_SID_TextChanged;
        // 
        // TB_TID
        // 
        TB_TID.CharacterCasing = CharacterCasing.Upper;
        TB_TID.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_TID.Location = new Point(71, 16);
        TB_TID.MaxLength = 5;
        TB_TID.Name = "TB_TID";
        TB_TID.Size = new Size(41, 22);
        TB_TID.TabIndex = 0;
        TB_TID.Text = "12345";
        TB_TID.TextChanged += TB_TID_TextChanged;
        // 
        // GB_Filters
        // 
        GB_Filters.Controls.Add(CB_Delay);
        GB_Filters.Controls.Add(NUD_Delay);
        GB_Filters.Controls.Add(CB_RareEC);
        GB_Filters.Controls.Add(CB_EnableFilters);
        GB_Filters.Controls.Add(L_Filter_Shiny);
        GB_Filters.Controls.Add(CB_Filter_Shiny);
        GB_Filters.Controls.Add(B_Spe_Max);
        GB_Filters.Controls.Add(B_Spe_Min);
        GB_Filters.Controls.Add(L_Spe);
        GB_Filters.Controls.Add(L_SpeSpacer);
        GB_Filters.Controls.Add(NUD_Spe_Max);
        GB_Filters.Controls.Add(NUD_Spe_Min);
        GB_Filters.Controls.Add(B_SpD_Max);
        GB_Filters.Controls.Add(B_SpD_Min);
        GB_Filters.Controls.Add(L_SpD);
        GB_Filters.Controls.Add(L_SpDSpacer);
        GB_Filters.Controls.Add(NUD_SpD_Max);
        GB_Filters.Controls.Add(NUD_SpD_Min);
        GB_Filters.Controls.Add(B_SpA_Max);
        GB_Filters.Controls.Add(B_SpA_Min);
        GB_Filters.Controls.Add(L_SpA);
        GB_Filters.Controls.Add(L_SpASpacer);
        GB_Filters.Controls.Add(NUD_SpA_Max);
        GB_Filters.Controls.Add(NUD_SpA_Min);
        GB_Filters.Controls.Add(B_Def_Max);
        GB_Filters.Controls.Add(B_Def_Min);
        GB_Filters.Controls.Add(L_Def);
        GB_Filters.Controls.Add(L_DefSpacer);
        GB_Filters.Controls.Add(NUD_Def_Max);
        GB_Filters.Controls.Add(NUD_Def_Min);
        GB_Filters.Controls.Add(B_Atk_Max);
        GB_Filters.Controls.Add(B_Atk_Min);
        GB_Filters.Controls.Add(L_Atk);
        GB_Filters.Controls.Add(L_AtkSpacer);
        GB_Filters.Controls.Add(NUD_Atk_Max);
        GB_Filters.Controls.Add(NUD_Atk_Min);
        GB_Filters.Controls.Add(B_HP_Max);
        GB_Filters.Controls.Add(B_HP_Min);
        GB_Filters.Controls.Add(L_HP);
        GB_Filters.Controls.Add(L_HPSpacer);
        GB_Filters.Controls.Add(NUD_HP_Max);
        GB_Filters.Controls.Add(NUD_HP_Min);
        GB_Filters.Location = new Point(799, 3);
        GB_Filters.Name = "GB_Filters";
        GB_Filters.Size = new Size(229, 254);
        GB_Filters.TabIndex = 126;
        GB_Filters.TabStop = false;
        GB_Filters.Text = "Search Filters";
        GB_Filters.Visible = false;
        // 
        // CB_Delay
        // 
        CB_Delay.AutoSize = true;
        CB_Delay.CheckAlign = ContentAlignment.MiddleRight;
        CB_Delay.Location = new Point(37, 196);
        CB_Delay.Name = "CB_Delay";
        CB_Delay.Size = new Size(58, 19);
        CB_Delay.TabIndex = 167;
        CB_Delay.Tag = "";
        CB_Delay.Text = "Delay:";
        CB_Delay.UseVisualStyleBackColor = true;
        CB_Delay.CheckedChanged += CB_Delay_CheckedChanged;
        // 
        // NUD_Delay
        // 
        NUD_Delay.Enabled = false;
        NUD_Delay.Location = new Point(101, 195);
        NUD_Delay.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        NUD_Delay.Name = "NUD_Delay";
        NUD_Delay.Size = new Size(123, 23);
        NUD_Delay.TabIndex = 166;
        NUD_Delay.TextAlign = HorizontalAlignment.Right;
        NUD_Delay.Value = new decimal(new int[] { 100, 0, 0, 0 });
        // 
        // CB_RareEC
        // 
        CB_RareEC.AutoSize = true;
        CB_RareEC.CheckAlign = ContentAlignment.MiddleRight;
        CB_RareEC.Location = new Point(43, 226);
        CB_RareEC.Name = "CB_RareEC";
        CB_RareEC.Size = new Size(71, 19);
        CB_RareEC.TabIndex = 27;
        CB_RareEC.Tag = "";
        CB_RareEC.Text = "Rare EC?";
        CB_RareEC.UseVisualStyleBackColor = true;
        // 
        // CB_EnableFilters
        // 
        CB_EnableFilters.AutoSize = true;
        CB_EnableFilters.CheckAlign = ContentAlignment.MiddleRight;
        CB_EnableFilters.Checked = true;
        CB_EnableFilters.CheckState = CheckState.Checked;
        CB_EnableFilters.Location = new Point(117, 228);
        CB_EnableFilters.Name = "CB_EnableFilters";
        CB_EnableFilters.Size = new Size(107, 19);
        CB_EnableFilters.TabIndex = 28;
        CB_EnableFilters.Tag = "";
        CB_EnableFilters.Text = "Filters Enabled?";
        CB_EnableFilters.UseVisualStyleBackColor = true;
        // 
        // L_Filter_Shiny
        // 
        L_Filter_Shiny.AutoSize = true;
        L_Filter_Shiny.Location = new Point(38, 171);
        L_Filter_Shiny.Name = "L_Filter_Shiny";
        L_Filter_Shiny.Size = new Size(39, 15);
        L_Filter_Shiny.TabIndex = 162;
        L_Filter_Shiny.Text = "Shiny:";
        // 
        // CB_Filter_Shiny
        // 
        CB_Filter_Shiny.FormattingEnabled = true;
        CB_Filter_Shiny.Items.AddRange(new object[] { "Ignore", "Star/Square", "Square Only", "Star Only", "Not Shiny" });
        CB_Filter_Shiny.Location = new Point(82, 168);
        CB_Filter_Shiny.Name = "CB_Filter_Shiny";
        CB_Filter_Shiny.Size = new Size(142, 23);
        CB_Filter_Shiny.TabIndex = 24;
        // 
        // B_Spe_Max
        // 
        B_Spe_Max.Location = new Point(197, 142);
        B_Spe_Max.Name = "B_Spe_Max";
        B_Spe_Max.Size = new Size(27, 25);
        B_Spe_Max.TabIndex = 23;
        B_Spe_Max.Text = "31";
        B_Spe_Max.UseVisualStyleBackColor = true;
        B_Spe_Max.Click += B_IV_Max_Click;
        // 
        // B_Spe_Min
        // 
        B_Spe_Min.Location = new Point(168, 142);
        B_Spe_Min.Name = "B_Spe_Min";
        B_Spe_Min.Size = new Size(27, 25);
        B_Spe_Min.TabIndex = 22;
        B_Spe_Min.Text = "0";
        B_Spe_Min.UseVisualStyleBackColor = true;
        B_Spe_Min.Click += B_IV_Min_Click;
        // 
        // L_Spe
        // 
        L_Spe.AutoSize = true;
        L_Spe.Location = new Point(48, 147);
        L_Spe.Name = "L_Spe";
        L_Spe.Size = new Size(29, 15);
        L_Spe.TabIndex = 161;
        L_Spe.Text = "Spe:";
        L_Spe.Click += IV_Label_Click;
        // 
        // L_SpeSpacer
        // 
        L_SpeSpacer.AutoSize = true;
        L_SpeSpacer.Location = new Point(115, 145);
        L_SpeSpacer.Name = "L_SpeSpacer";
        L_SpeSpacer.Size = new Size(15, 15);
        L_SpeSpacer.TabIndex = 11;
        L_SpeSpacer.Text = "~";
        L_SpeSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_Spe_Max
        // 
        NUD_Spe_Max.Location = new Point(131, 143);
        NUD_Spe_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Spe_Max.Name = "NUD_Spe_Max";
        NUD_Spe_Max.Size = new Size(32, 23);
        NUD_Spe_Max.TabIndex = 140;
        NUD_Spe_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_Spe_Min
        // 
        NUD_Spe_Min.Location = new Point(82, 143);
        NUD_Spe_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Spe_Min.Name = "NUD_Spe_Min";
        NUD_Spe_Min.Size = new Size(32, 23);
        NUD_Spe_Min.TabIndex = 10;
        // 
        // B_SpD_Max
        // 
        B_SpD_Max.Location = new Point(197, 117);
        B_SpD_Max.Name = "B_SpD_Max";
        B_SpD_Max.Size = new Size(27, 25);
        B_SpD_Max.TabIndex = 21;
        B_SpD_Max.Text = "31";
        B_SpD_Max.UseVisualStyleBackColor = true;
        B_SpD_Max.Click += B_IV_Max_Click;
        // 
        // B_SpD_Min
        // 
        B_SpD_Min.Location = new Point(168, 117);
        B_SpD_Min.Name = "B_SpD_Min";
        B_SpD_Min.Size = new Size(27, 25);
        B_SpD_Min.TabIndex = 20;
        B_SpD_Min.Text = "0";
        B_SpD_Min.UseVisualStyleBackColor = true;
        B_SpD_Min.Click += B_IV_Min_Click;
        // 
        // L_SpD
        // 
        L_SpD.AutoSize = true;
        L_SpD.Location = new Point(46, 123);
        L_SpD.Name = "L_SpD";
        L_SpD.Size = new Size(31, 15);
        L_SpD.TabIndex = 160;
        L_SpD.Text = "SpD:";
        L_SpD.Click += IV_Label_Click;
        // 
        // L_SpDSpacer
        // 
        L_SpDSpacer.AutoSize = true;
        L_SpDSpacer.Location = new Point(115, 120);
        L_SpDSpacer.Name = "L_SpDSpacer";
        L_SpDSpacer.Size = new Size(15, 15);
        L_SpDSpacer.TabIndex = 9;
        L_SpDSpacer.Text = "~";
        L_SpDSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_SpD_Max
        // 
        NUD_SpD_Max.Location = new Point(131, 118);
        NUD_SpD_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_SpD_Max.Name = "NUD_SpD_Max";
        NUD_SpD_Max.Size = new Size(32, 23);
        NUD_SpD_Max.TabIndex = 137;
        NUD_SpD_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_SpD_Min
        // 
        NUD_SpD_Min.Location = new Point(82, 118);
        NUD_SpD_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_SpD_Min.Name = "NUD_SpD_Min";
        NUD_SpD_Min.Size = new Size(32, 23);
        NUD_SpD_Min.TabIndex = 8;
        // 
        // B_SpA_Max
        // 
        B_SpA_Max.Location = new Point(197, 92);
        B_SpA_Max.Name = "B_SpA_Max";
        B_SpA_Max.Size = new Size(27, 25);
        B_SpA_Max.TabIndex = 19;
        B_SpA_Max.Text = "31";
        B_SpA_Max.UseVisualStyleBackColor = true;
        B_SpA_Max.Click += B_IV_Max_Click;
        // 
        // B_SpA_Min
        // 
        B_SpA_Min.Location = new Point(168, 92);
        B_SpA_Min.Name = "B_SpA_Min";
        B_SpA_Min.Size = new Size(27, 25);
        B_SpA_Min.TabIndex = 18;
        B_SpA_Min.Text = "0";
        B_SpA_Min.UseVisualStyleBackColor = true;
        B_SpA_Min.Click += B_IV_Min_Click;
        // 
        // L_SpA
        // 
        L_SpA.AutoSize = true;
        L_SpA.Location = new Point(46, 95);
        L_SpA.Name = "L_SpA";
        L_SpA.Size = new Size(31, 15);
        L_SpA.TabIndex = 156;
        L_SpA.Text = "SpA:";
        L_SpA.Click += IV_Label_Click;
        // 
        // L_SpASpacer
        // 
        L_SpASpacer.AutoSize = true;
        L_SpASpacer.Location = new Point(115, 95);
        L_SpASpacer.Name = "L_SpASpacer";
        L_SpASpacer.Size = new Size(15, 15);
        L_SpASpacer.TabIndex = 134;
        L_SpASpacer.Text = "~";
        L_SpASpacer.Click += IV_Spacer_Click;
        // 
        // NUD_SpA_Max
        // 
        NUD_SpA_Max.Location = new Point(131, 93);
        NUD_SpA_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_SpA_Max.Name = "NUD_SpA_Max";
        NUD_SpA_Max.Size = new Size(32, 23);
        NUD_SpA_Max.TabIndex = 7;
        NUD_SpA_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_SpA_Min
        // 
        NUD_SpA_Min.Location = new Point(82, 93);
        NUD_SpA_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_SpA_Min.Name = "NUD_SpA_Min";
        NUD_SpA_Min.Size = new Size(32, 23);
        NUD_SpA_Min.TabIndex = 6;
        // 
        // B_Def_Max
        // 
        B_Def_Max.Location = new Point(197, 67);
        B_Def_Max.Name = "B_Def_Max";
        B_Def_Max.Size = new Size(27, 25);
        B_Def_Max.TabIndex = 17;
        B_Def_Max.Text = "31";
        B_Def_Max.UseVisualStyleBackColor = true;
        B_Def_Max.Click += B_IV_Max_Click;
        // 
        // B_Def_Min
        // 
        B_Def_Min.Location = new Point(168, 67);
        B_Def_Min.Name = "B_Def_Min";
        B_Def_Min.Size = new Size(27, 25);
        B_Def_Min.TabIndex = 16;
        B_Def_Min.Text = "0";
        B_Def_Min.UseVisualStyleBackColor = true;
        B_Def_Min.Click += B_IV_Min_Click;
        // 
        // L_Def
        // 
        L_Def.AutoSize = true;
        L_Def.Location = new Point(49, 70);
        L_Def.Name = "L_Def";
        L_Def.Size = new Size(28, 15);
        L_Def.TabIndex = 149;
        L_Def.Text = "Def:";
        L_Def.Click += IV_Label_Click;
        // 
        // L_DefSpacer
        // 
        L_DefSpacer.AutoSize = true;
        L_DefSpacer.Location = new Point(115, 70);
        L_DefSpacer.Name = "L_DefSpacer";
        L_DefSpacer.Size = new Size(15, 15);
        L_DefSpacer.TabIndex = 129;
        L_DefSpacer.Text = "~";
        L_DefSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_Def_Max
        // 
        NUD_Def_Max.Location = new Point(131, 68);
        NUD_Def_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Def_Max.Name = "NUD_Def_Max";
        NUD_Def_Max.Size = new Size(32, 23);
        NUD_Def_Max.TabIndex = 5;
        NUD_Def_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_Def_Min
        // 
        NUD_Def_Min.Location = new Point(82, 68);
        NUD_Def_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Def_Min.Name = "NUD_Def_Min";
        NUD_Def_Min.Size = new Size(32, 23);
        NUD_Def_Min.TabIndex = 4;
        // 
        // B_Atk_Max
        // 
        B_Atk_Max.Location = new Point(197, 42);
        B_Atk_Max.Name = "B_Atk_Max";
        B_Atk_Max.Size = new Size(27, 25);
        B_Atk_Max.TabIndex = 15;
        B_Atk_Max.Text = "31";
        B_Atk_Max.UseVisualStyleBackColor = true;
        B_Atk_Max.Click += B_IV_Max_Click;
        // 
        // B_Atk_Min
        // 
        B_Atk_Min.Location = new Point(168, 42);
        B_Atk_Min.Name = "B_Atk_Min";
        B_Atk_Min.Size = new Size(27, 25);
        B_Atk_Min.TabIndex = 14;
        B_Atk_Min.Text = "0";
        B_Atk_Min.UseVisualStyleBackColor = true;
        B_Atk_Min.Click += B_IV_Min_Click;
        // 
        // L_Atk
        // 
        L_Atk.AutoSize = true;
        L_Atk.Location = new Point(49, 45);
        L_Atk.Name = "L_Atk";
        L_Atk.Size = new Size(28, 15);
        L_Atk.TabIndex = 142;
        L_Atk.Text = "Atk:";
        L_Atk.Click += IV_Label_Click;
        // 
        // L_AtkSpacer
        // 
        L_AtkSpacer.AutoSize = true;
        L_AtkSpacer.Location = new Point(115, 45);
        L_AtkSpacer.Name = "L_AtkSpacer";
        L_AtkSpacer.Size = new Size(15, 15);
        L_AtkSpacer.TabIndex = 126;
        L_AtkSpacer.Text = "~";
        L_AtkSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_Atk_Max
        // 
        NUD_Atk_Max.Location = new Point(131, 43);
        NUD_Atk_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Atk_Max.Name = "NUD_Atk_Max";
        NUD_Atk_Max.Size = new Size(32, 23);
        NUD_Atk_Max.TabIndex = 3;
        NUD_Atk_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_Atk_Min
        // 
        NUD_Atk_Min.Location = new Point(82, 43);
        NUD_Atk_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Atk_Min.Name = "NUD_Atk_Min";
        NUD_Atk_Min.Size = new Size(32, 23);
        NUD_Atk_Min.TabIndex = 2;
        // 
        // B_HP_Max
        // 
        B_HP_Max.Location = new Point(197, 17);
        B_HP_Max.Name = "B_HP_Max";
        B_HP_Max.Size = new Size(27, 25);
        B_HP_Max.TabIndex = 13;
        B_HP_Max.Text = "31";
        B_HP_Max.UseVisualStyleBackColor = true;
        B_HP_Max.Click += B_IV_Max_Click;
        // 
        // B_HP_Min
        // 
        B_HP_Min.Location = new Point(168, 17);
        B_HP_Min.Name = "B_HP_Min";
        B_HP_Min.Size = new Size(27, 25);
        B_HP_Min.TabIndex = 12;
        B_HP_Min.Text = "0";
        B_HP_Min.UseVisualStyleBackColor = true;
        B_HP_Min.Click += B_IV_Min_Click;
        // 
        // L_HP
        // 
        L_HP.AutoSize = true;
        L_HP.Location = new Point(51, 20);
        L_HP.Name = "L_HP";
        L_HP.Size = new Size(26, 15);
        L_HP.TabIndex = 132;
        L_HP.Text = "HP:";
        L_HP.Click += IV_Label_Click;
        // 
        // L_HPSpacer
        // 
        L_HPSpacer.AutoSize = true;
        L_HPSpacer.Location = new Point(115, 20);
        L_HPSpacer.Name = "L_HPSpacer";
        L_HPSpacer.Size = new Size(15, 15);
        L_HPSpacer.TabIndex = 130;
        L_HPSpacer.Text = "~";
        L_HPSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_HP_Max
        // 
        NUD_HP_Max.Location = new Point(131, 18);
        NUD_HP_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_HP_Max.Name = "NUD_HP_Max";
        NUD_HP_Max.Size = new Size(32, 23);
        NUD_HP_Max.TabIndex = 1;
        NUD_HP_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_HP_Min
        // 
        NUD_HP_Min.Location = new Point(82, 18);
        NUD_HP_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_HP_Min.Name = "NUD_HP_Min";
        NUD_HP_Min.Size = new Size(32, 23);
        NUD_HP_Min.TabIndex = 0;
        // 
        // B_ReadWildPokemon
        // 
        B_ReadWildPokemon.Location = new Point(1034, 200);
        B_ReadWildPokemon.Name = "B_ReadWildPokemon";
        B_ReadWildPokemon.Size = new Size(181, 25);
        B_ReadWildPokemon.TabIndex = 9;
        B_ReadWildPokemon.Text = "Read Encounter";
        B_ReadWildPokemon.UseVisualStyleBackColor = true;
        B_ReadWildPokemon.Visible = false;
        B_ReadWildPokemon.Click += B_ReadWildPokemon_Click;
        // 
        // TB_Wild
        // 
        TB_Wild.Location = new Point(1034, 12);
        TB_Wild.Multiline = true;
        TB_Wild.Name = "TB_Wild";
        TB_Wild.ReadOnly = true;
        TB_Wild.Size = new Size(181, 186);
        TB_Wild.TabIndex = 8;
        TB_Wild.TabStop = false;
        TB_Wild.Text = "Shiny - Species (Gender) @ Item\r\nEC: WWWWWWWW\r\nPID: WWWWWWWW\r\nWWWWWWW Nature\r\nAbility: WWWWWWWWWW\r\nIVs: 22/22/22/22/22/22\r\nHeight: 255 (XXXL)\r\nMark: WWWWWWWWWW\r\n- Move 1\r\n- Move 2\r\n- Move 3\r\n- Move 4";
        TB_Wild.Visible = false;
        // 
        // TC_Main
        // 
        TC_Main.Controls.Add(TP_IDs);
        TC_Main.Controls.Add(tabPage2);
        TC_Main.Location = new Point(211, 1);
        TC_Main.Name = "TC_Main";
        TC_Main.SelectedIndex = 0;
        TC_Main.Size = new Size(388, 325);
        TC_Main.TabIndex = 127;
        // 
        // TP_IDs
        // 
        TP_IDs.Controls.Add(GB_SID);
        TP_IDs.Controls.Add(groupBox1);
        TP_IDs.Location = new Point(4, 24);
        TP_IDs.Name = "TP_IDs";
        TP_IDs.Padding = new Padding(3);
        TP_IDs.Size = new Size(380, 297);
        TP_IDs.TabIndex = 0;
        TP_IDs.Text = "TID/SID";
        TP_IDs.UseVisualStyleBackColor = true;
        // 
        // GB_SID
        // 
        GB_SID.Controls.Add(B_ReadTempTID);
        GB_SID.Controls.Add(B_ReadIDs);
        GB_SID.Controls.Add(B_SID_Generate);
        GB_SID.Controls.Add(L_SIDAdvances);
        GB_SID.Controls.Add(L_SIDInitial);
        GB_SID.Controls.Add(TB_SIDAdvances);
        GB_SID.Controls.Add(TB_SIDInitial);
        GB_SID.Controls.Add(CB_SID_FiltersEnabled);
        GB_SID.Controls.Add(CB_SID_Delay);
        GB_SID.Controls.Add(NUD_SID_Delay);
        GB_SID.Controls.Add(L_SIDPID);
        GB_SID.Controls.Add(L_SIDTID);
        GB_SID.Controls.Add(L_SIDSID);
        GB_SID.Controls.Add(TB_SIDSID);
        GB_SID.Controls.Add(TB_SIDTID);
        GB_SID.Controls.Add(TB_SIDPID);
        GB_SID.Controls.Add(RB_SID_FromPID);
        GB_SID.Controls.Add(RB_SID_SpecificValue);
        GB_SID.Location = new Point(6, 89);
        GB_SID.Name = "GB_SID";
        GB_SID.Size = new Size(367, 202);
        GB_SID.TabIndex = 1;
        GB_SID.TabStop = false;
        GB_SID.Text = "SID";
        // 
        // B_ReadIDs
        // 
        B_ReadIDs.Location = new Point(6, 169);
        B_ReadIDs.Name = "B_ReadIDs";
        B_ReadIDs.Size = new Size(150, 25);
        B_ReadIDs.TabIndex = 175;
        B_ReadIDs.Text = "Read IDs from RAM";
        B_ReadIDs.UseVisualStyleBackColor = true;
        B_ReadIDs.Click += B_ReadIDs_Click;
        // 
        // B_SID_Generate
        // 
        B_SID_Generate.Location = new Point(162, 169);
        B_SID_Generate.Name = "B_SID_Generate";
        B_SID_Generate.Size = new Size(200, 25);
        B_SID_Generate.TabIndex = 4;
        B_SID_Generate.Text = "Generate";
        B_SID_Generate.UseVisualStyleBackColor = true;
        B_SID_Generate.Click += B_SID_Generate_Click;
        // 
        // L_SIDAdvances
        // 
        L_SIDAdvances.AutoSize = true;
        L_SIDAdvances.Location = new Point(240, 147);
        L_SIDAdvances.Name = "L_SIDAdvances";
        L_SIDAdvances.Size = new Size(15, 15);
        L_SIDAdvances.TabIndex = 174;
        L_SIDAdvances.Text = "+";
        // 
        // L_SIDInitial
        // 
        L_SIDInitial.AutoSize = true;
        L_SIDInitial.Location = new Point(162, 123);
        L_SIDInitial.Name = "L_SIDInitial";
        L_SIDInitial.Size = new Size(93, 15);
        L_SIDInitial.TabIndex = 173;
        L_SIDInitial.Text = "Initial Advances:";
        // 
        // TB_SIDAdvances
        // 
        TB_SIDAdvances.CharacterCasing = CharacterCasing.Upper;
        TB_SIDAdvances.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SIDAdvances.Location = new Point(261, 145);
        TB_SIDAdvances.MaxLength = 10;
        TB_SIDAdvances.Name = "TB_SIDAdvances";
        TB_SIDAdvances.Size = new Size(101, 22);
        TB_SIDAdvances.TabIndex = 172;
        TB_SIDAdvances.Text = "100000";
        TB_SIDAdvances.TextAlign = HorizontalAlignment.Right;
        TB_SIDAdvances.KeyDown += Dec_HandlePaste;
        TB_SIDAdvances.KeyPress += AllowOnlyNumerical_KeyPress;
        // 
        // TB_SIDInitial
        // 
        TB_SIDInitial.CharacterCasing = CharacterCasing.Upper;
        TB_SIDInitial.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SIDInitial.Location = new Point(261, 121);
        TB_SIDInitial.MaxLength = 10;
        TB_SIDInitial.Name = "TB_SIDInitial";
        TB_SIDInitial.Size = new Size(101, 22);
        TB_SIDInitial.TabIndex = 171;
        TB_SIDInitial.Text = "0";
        TB_SIDInitial.TextAlign = HorizontalAlignment.Right;
        TB_SIDInitial.KeyDown += Dec_HandlePaste;
        TB_SIDInitial.KeyPress += AllowOnlyNumerical_KeyPress;
        // 
        // CB_SID_FiltersEnabled
        // 
        CB_SID_FiltersEnabled.AutoSize = true;
        CB_SID_FiltersEnabled.CheckAlign = ContentAlignment.MiddleRight;
        CB_SID_FiltersEnabled.Checked = true;
        CB_SID_FiltersEnabled.CheckState = CheckState.Checked;
        CB_SID_FiltersEnabled.Location = new Point(255, 90);
        CB_SID_FiltersEnabled.Name = "CB_SID_FiltersEnabled";
        CB_SID_FiltersEnabled.Size = new Size(107, 19);
        CB_SID_FiltersEnabled.TabIndex = 170;
        CB_SID_FiltersEnabled.Tag = "";
        CB_SID_FiltersEnabled.Text = "Filters Enabled?";
        CB_SID_FiltersEnabled.UseVisualStyleBackColor = true;
        // 
        // CB_SID_Delay
        // 
        CB_SID_Delay.AutoSize = true;
        CB_SID_Delay.CheckAlign = ContentAlignment.MiddleRight;
        CB_SID_Delay.Location = new Point(162, 66);
        CB_SID_Delay.Name = "CB_SID_Delay";
        CB_SID_Delay.Size = new Size(58, 19);
        CB_SID_Delay.TabIndex = 169;
        CB_SID_Delay.Tag = "";
        CB_SID_Delay.Text = "Delay:";
        CB_SID_Delay.UseVisualStyleBackColor = true;
        CB_SID_Delay.CheckedChanged += CB_SID_Delay_CheckedChanged;
        // 
        // NUD_SID_Delay
        // 
        NUD_SID_Delay.Enabled = false;
        NUD_SID_Delay.Location = new Point(238, 65);
        NUD_SID_Delay.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        NUD_SID_Delay.Name = "NUD_SID_Delay";
        NUD_SID_Delay.Size = new Size(123, 23);
        NUD_SID_Delay.TabIndex = 168;
        NUD_SID_Delay.TextAlign = HorizontalAlignment.Right;
        NUD_SID_Delay.Value = new decimal(new int[] { 465, 0, 0, 0 });
        // 
        // L_SIDPID
        // 
        L_SIDPID.AutoSize = true;
        L_SIDPID.Enabled = false;
        L_SIDPID.Location = new Point(162, 45);
        L_SIDPID.Name = "L_SIDPID";
        L_SIDPID.Size = new Size(28, 15);
        L_SIDPID.TabIndex = 7;
        L_SIDPID.Text = "PID:";
        // 
        // L_SIDTID
        // 
        L_SIDTID.AutoSize = true;
        L_SIDTID.Enabled = false;
        L_SIDTID.Location = new Point(278, 45);
        L_SIDTID.Name = "L_SIDTID";
        L_SIDTID.Size = new Size(27, 15);
        L_SIDTID.TabIndex = 6;
        L_SIDTID.Text = "TID:";
        // 
        // L_SIDSID
        // 
        L_SIDSID.AutoSize = true;
        L_SIDSID.Location = new Point(278, 19);
        L_SIDSID.Name = "L_SIDSID";
        L_SIDSID.Size = new Size(27, 15);
        L_SIDSID.TabIndex = 5;
        L_SIDSID.Text = "SID:";
        // 
        // TB_SIDSID
        // 
        TB_SIDSID.CharacterCasing = CharacterCasing.Upper;
        TB_SIDSID.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SIDSID.Location = new Point(320, 17);
        TB_SIDSID.MaxLength = 5;
        TB_SIDSID.Name = "TB_SIDSID";
        TB_SIDSID.Size = new Size(41, 22);
        TB_SIDSID.TabIndex = 4;
        TB_SIDSID.Text = "12345";
        TB_SIDSID.KeyDown += Dec_HandlePaste;
        TB_SIDSID.KeyPress += AllowOnlyNumerical_KeyPress;
        // 
        // TB_SIDTID
        // 
        TB_SIDTID.CharacterCasing = CharacterCasing.Upper;
        TB_SIDTID.Enabled = false;
        TB_SIDTID.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SIDTID.Location = new Point(321, 41);
        TB_SIDTID.MaxLength = 5;
        TB_SIDTID.Name = "TB_SIDTID";
        TB_SIDTID.Size = new Size(41, 22);
        TB_SIDTID.TabIndex = 3;
        TB_SIDTID.Text = "12345";
        TB_SIDTID.KeyDown += Dec_HandlePaste;
        TB_SIDTID.KeyPress += AllowOnlyNumerical_KeyPress;
        // 
        // TB_SIDPID
        // 
        TB_SIDPID.CharacterCasing = CharacterCasing.Upper;
        TB_SIDPID.Enabled = false;
        TB_SIDPID.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SIDPID.Location = new Point(205, 41);
        TB_SIDPID.MaxLength = 8;
        TB_SIDPID.Name = "TB_SIDPID";
        TB_SIDPID.Size = new Size(62, 22);
        TB_SIDPID.TabIndex = 2;
        TB_SIDPID.Text = "01234567";
        TB_SIDPID.KeyDown += State_HandlePaste;
        TB_SIDPID.KeyPress += AllowOnlyHex_KeyPress;
        // 
        // RB_SID_FromPID
        // 
        RB_SID_FromPID.AutoSize = true;
        RB_SID_FromPID.Location = new Point(6, 41);
        RB_SID_FromPID.Name = "RB_SID_FromPID";
        RB_SID_FromPID.Size = new Size(118, 19);
        RB_SID_FromPID.TabIndex = 1;
        RB_SID_FromPID.Text = "SIDs for Shiny PID";
        RB_SID_FromPID.UseVisualStyleBackColor = true;
        // 
        // RB_SID_SpecificValue
        // 
        RB_SID_SpecificValue.AutoSize = true;
        RB_SID_SpecificValue.Checked = true;
        RB_SID_SpecificValue.Location = new Point(6, 17);
        RB_SID_SpecificValue.Name = "RB_SID_SpecificValue";
        RB_SID_SpecificValue.Size = new Size(86, 19);
        RB_SID_SpecificValue.TabIndex = 0;
        RB_SID_SpecificValue.TabStop = true;
        RB_SID_SpecificValue.Text = "Specific SID";
        RB_SID_SpecificValue.UseVisualStyleBackColor = true;
        RB_SID_SpecificValue.CheckedChanged += RB_SID_SpecificValue_CheckedChanged;
        // 
        // groupBox1
        // 
        groupBox1.Controls.Add(B_TID_Cancel);
        groupBox1.Controls.Add(B_TID_Reset);
        groupBox1.Controls.Add(B_TID_EditList);
        groupBox1.Controls.Add(L_LoadedTIDs);
        groupBox1.Location = new Point(6, 6);
        groupBox1.Name = "groupBox1";
        groupBox1.Size = new Size(367, 82);
        groupBox1.TabIndex = 0;
        groupBox1.TabStop = false;
        groupBox1.Text = "TID";
        // 
        // B_TID_Cancel
        // 
        B_TID_Cancel.Enabled = false;
        B_TID_Cancel.Location = new Point(162, 49);
        B_TID_Cancel.Name = "B_TID_Cancel";
        B_TID_Cancel.Size = new Size(200, 25);
        B_TID_Cancel.TabIndex = 3;
        B_TID_Cancel.Text = "Cancel";
        B_TID_Cancel.UseVisualStyleBackColor = true;
        B_TID_Cancel.Click += B_TID_Cancel_Click;
        // 
        // B_TID_Reset
        // 
        B_TID_Reset.Location = new Point(162, 22);
        B_TID_Reset.Name = "B_TID_Reset";
        B_TID_Reset.Size = new Size(200, 25);
        B_TID_Reset.TabIndex = 2;
        B_TID_Reset.Text = "Reset for TID";
        B_TID_Reset.UseVisualStyleBackColor = true;
        B_TID_Reset.Click += B_TID_Reset_Click;
        // 
        // B_TID_EditList
        // 
        B_TID_EditList.Location = new Point(6, 22);
        B_TID_EditList.Name = "B_TID_EditList";
        B_TID_EditList.Size = new Size(150, 25);
        B_TID_EditList.TabIndex = 1;
        B_TID_EditList.Text = "Edit TID List";
        B_TID_EditList.UseVisualStyleBackColor = true;
        B_TID_EditList.Click += B_TID_EditList_Click;
        // 
        // L_LoadedTIDs
        // 
        L_LoadedTIDs.AutoSize = true;
        L_LoadedTIDs.Location = new Point(6, 54);
        L_LoadedTIDs.Name = "L_LoadedTIDs";
        L_LoadedTIDs.Size = new Size(109, 15);
        L_LoadedTIDs.TabIndex = 0;
        L_LoadedTIDs.Text = "Loaded TIDs: None!";
        // 
        // tabPage2
        // 
        tabPage2.Location = new Point(4, 24);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(380, 297);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "tabPage2";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // GB_ConnectionSettings
        // 
        GB_ConnectionSettings.Controls.Add(B_ConnectionSettings);
        GB_ConnectionSettings.Location = new Point(0, 209);
        GB_ConnectionSettings.Name = "GB_ConnectionSettings";
        GB_ConnectionSettings.Size = new Size(212, 48);
        GB_ConnectionSettings.TabIndex = 128;
        GB_ConnectionSettings.TabStop = false;
        // 
        // B_ConnectionSettings
        // 
        B_ConnectionSettings.Location = new Point(11, 15);
        B_ConnectionSettings.Name = "B_ConnectionSettings";
        B_ConnectionSettings.Size = new Size(195, 25);
        B_ConnectionSettings.TabIndex = 0;
        B_ConnectionSettings.Text = "Connection/Reset Settings";
        B_ConnectionSettings.UseVisualStyleBackColor = true;
        B_ConnectionSettings.Click += B_ResetSettings_Click;
        // 
        // DGV_Results
        // 
        DGV_Results.AllowUserToAddRows = false;
        DGV_Results.AllowUserToDeleteRows = false;
        dataGridViewCellStyle1.BackColor = Color.WhiteSmoke;
        DGV_Results.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
        DGV_Results.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        DGV_Results.AutoGenerateColumns = false;
        DGV_Results.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        DGV_Results.Columns.AddRange(new DataGridViewColumn[] { advancesDataGridViewTextBoxColumn, seedDataGridViewTextBoxColumn, sIDDataGridViewTextBoxColumn });
        DGV_Results.DataSource = BS_SID;
        DGV_Results.Location = new Point(11, 332);
        DGV_Results.Name = "DGV_Results";
        DGV_Results.ReadOnly = true;
        DGV_Results.RowHeadersVisible = false;
        DGV_Results.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        DGV_Results.Size = new Size(584, 306);
        DGV_Results.TabIndex = 129;
        // 
        // advancesDataGridViewTextBoxColumn
        // 
        advancesDataGridViewTextBoxColumn.DataPropertyName = "Advances";
        advancesDataGridViewTextBoxColumn.HeaderText = "Advances";
        advancesDataGridViewTextBoxColumn.Name = "advancesDataGridViewTextBoxColumn";
        advancesDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // seedDataGridViewTextBoxColumn
        // 
        seedDataGridViewTextBoxColumn.DataPropertyName = "Seed";
        seedDataGridViewTextBoxColumn.HeaderText = "Seed";
        seedDataGridViewTextBoxColumn.Name = "seedDataGridViewTextBoxColumn";
        seedDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // sIDDataGridViewTextBoxColumn
        // 
        sIDDataGridViewTextBoxColumn.DataPropertyName = "SID";
        sIDDataGridViewTextBoxColumn.HeaderText = "SID";
        sIDDataGridViewTextBoxColumn.Name = "sIDDataGridViewTextBoxColumn";
        sIDDataGridViewTextBoxColumn.ReadOnly = true;
        // 
        // BS_SID
        // 
        BS_SID.DataSource = typeof(Core.Interfaces.SIDFrame);
        // 
        // B_ReadTempTID
        // 
        B_ReadTempTID.Location = new Point(6, 142);
        B_ReadTempTID.Name = "B_ReadTempTID";
        B_ReadTempTID.Size = new Size(150, 25);
        B_ReadTempTID.TabIndex = 176;
        B_ReadTempTID.Text = "Read Temp TID";
        B_ReadTempTID.UseVisualStyleBackColor = true;
        B_ReadTempTID.Click += B_ReadTempTID_Click;
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(607, 650);
        Controls.Add(DGV_Results);
        Controls.Add(GB_Connection);
        Controls.Add(GB_SAVInfo);
        Controls.Add(GB_ConnectionSettings);
        Controls.Add(TC_Main);
        Controls.Add(TB_Wild);
        Controls.Add(B_ReadWildPokemon);
        Controls.Add(GB_Filters);
        Controls.Add(GB_Seed);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "MainWindow";
        FormClosing += MainWindow_FormClosing;
        Load += MainWindow_Load;
        GB_Connection.ResumeLayout(false);
        GB_Connection.PerformLayout();
        GB_Seed.ResumeLayout(false);
        GB_Seed.PerformLayout();
        GB_SAVInfo.ResumeLayout(false);
        GB_SAVInfo.PerformLayout();
        GB_Filters.ResumeLayout(false);
        GB_Filters.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_Delay).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Spe_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Spe_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_SpD_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_SpD_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_SpA_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_SpA_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Def_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Def_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Atk_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Atk_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_HP_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_HP_Min).EndInit();
        TC_Main.ResumeLayout(false);
        TP_IDs.ResumeLayout(false);
        GB_SID.ResumeLayout(false);
        GB_SID.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_SID_Delay).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        GB_ConnectionSettings.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)DGV_Results).EndInit();
        ((System.ComponentModel.ISupportInitialize)BS_SID).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private GroupBox GB_Connection;
    private TextBox TB_AdvancesIncrease;
    private TextBox TB_Status;
    private Label L_CurrentSeed;
    private Label L_Status;
    private TextBox TB_CurrentSeed;
    public TextBox TB_CurrentAdvances;
    private Label L_CurrentAdvances;
    private Button B_Disconnect;
    private Button B_Connect;
    private Label L_SwitchIP;
    private TextBox TB_SwitchIP;
    private GroupBox GB_Seed;
    private Label L_InitialSeed;
    public TextBox TB_InitialSeed;
    private GroupBox GB_SAVInfo;
    private Label L_Game;
    public ComboBox CB_Game;
    private Label L_SID;
    private Label L_TID;
    public TextBox TB_SID;
    public TextBox TB_TID;
    private GroupBox GB_Filters;
    public CheckBox CB_RareEC;
    private CheckBox CB_EnableFilters;
    private Label L_Filter_Shiny;
    private ComboBox CB_Filter_Shiny;
    private Button B_Spe_Max;
    private Button B_Spe_Min;
    private Label L_Spe;
    private Label L_SpeSpacer;
    private NumericUpDown NUD_Spe_Max;
    private NumericUpDown NUD_Spe_Min;
    private Button B_SpD_Max;
    private Button B_SpD_Min;
    private Label L_SpD;
    private Label L_SpDSpacer;
    private NumericUpDown NUD_SpD_Max;
    private NumericUpDown NUD_SpD_Min;
    private Button B_SpA_Max;
    private Button B_SpA_Min;
    private Label L_SpA;
    private Label L_SpASpacer;
    private NumericUpDown NUD_SpA_Max;
    private NumericUpDown NUD_SpA_Min;
    private Button B_Def_Max;
    private Button B_Def_Min;
    private Label L_Def;
    private Label L_DefSpacer;
    private NumericUpDown NUD_Def_Max;
    private NumericUpDown NUD_Def_Min;
    private Button B_Atk_Max;
    private Button B_Atk_Min;
    private Label L_Atk;
    private Label L_AtkSpacer;
    private NumericUpDown NUD_Atk_Max;
    private NumericUpDown NUD_Atk_Min;
    private Button B_HP_Max;
    private Button B_HP_Min;
    private Label L_HP;
    private Label L_HPSpacer;
    private NumericUpDown NUD_HP_Max;
    private NumericUpDown NUD_HP_Min;
    private Button B_ReadWildPokemon;
    private TextBox TB_Wild;
    private NumericUpDown NUD_Delay;
    public CheckBox CB_Delay;
    private Label L_SIDPID;
    private TabControl TC_Main;
    private TabPage TP_IDs;
    private TabPage tabPage2;
    private GroupBox groupBox1;
    private Button B_TID_EditList;
    private Button B_TID_Reset;
    private GroupBox GB_ConnectionSettings;
    private Button B_ConnectionSettings;
    internal Label L_LoadedTIDs;
    private Button B_TID_Cancel;
    private GroupBox GB_SID;
    private RadioButton RB_SID_FromPID;
    private RadioButton RB_SID_SpecificValue;
    public TextBox TB_SIDSID;
    public TextBox TB_SIDTID;
    public TextBox TB_SIDPID;
    private Label L_SIDTID;
    private Label L_SIDSID;
    public CheckBox CB_SID_Delay;
    private NumericUpDown NUD_SID_Delay;
    private CheckBox CB_SID_FiltersEnabled;
    public TextBox TB_SIDAdvances;
    public TextBox TB_SIDInitial;
    private Button B_SID_Generate;
    private Label L_SIDAdvances;
    private Label L_SIDInitial;
    private DataGridView DGV_Results;
    private DataGridViewTextBoxColumn advancesDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn seedDataGridViewTextBoxColumn;
    private DataGridViewTextBoxColumn sIDDataGridViewTextBoxColumn;
    private BindingSource BS_SID;
    private Button B_ReadIDs;
    private Button B_ReadTempTID;
}

