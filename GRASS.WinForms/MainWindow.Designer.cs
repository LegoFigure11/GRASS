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
        B_ReadWildPokemon = new Button();
        TB_Wild = new TextBox();
        TC_Main = new TabControl();
        TP_IDs = new TabPage();
        GB_SID = new GroupBox();
        B_ReadTempTID = new Button();
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
        TP_Seed = new TabPage();
        GB_SeedReset = new GroupBox();
        B_CancelSeedReset = new Button();
        B_ResetSeed = new Button();
        L_SS_SeedList = new Label();
        B_SS_SeedList = new Button();
        RB_SS_SpecificSeed = new RadioButton();
        L_SS_SeedCount = new Label();
        TB_SS_SeedCount = new TextBox();
        B_SS_CountSeeds = new Button();
        L_SS_Adv = new Label();
        TB_SS_Adv = new TextBox();
        L_SS_NumSeeds = new Label();
        L_SS_MaxAdv = new Label();
        TB_SS_MaxAdv = new TextBox();
        B_SS_FindMax = new Button();
        NUD_SS_NumSeeds = new NumericUpDown();
        RB_SS_Distance = new RadioButton();
        TB_SS_TargetSeed = new TextBox();
        L_SS_TargetSeed = new Label();
        RB_SS_Number = new RadioButton();
        TP_Static = new TabPage();
        L_Static_Method = new Label();
        CB_Static_Method = new ComboBox();
        L_Static_Species = new Label();
        CB_Static_Species = new ComboBox();
        CB_Static_RoamerBug = new CheckBox();
        B_Static_Search = new Button();
        L_Static_Advances = new Label();
        L_Static_Initial = new Label();
        TB_Static_Advances = new TextBox();
        TB_Static_Initial = new TextBox();
        GB_Filters = new GroupBox();
        L_Static_Nature = new Label();
        CB_Static_Nature = new ComboBox();
        CB_Static_Delay = new CheckBox();
        NUD_Static_Delay = new NumericUpDown();
        CB_RareEC = new CheckBox();
        CB_Static_FiltersEnabled = new CheckBox();
        L_Static_Shiny = new Label();
        CB_Static_Shiny = new ComboBox();
        B_Static_Spe_Max = new Button();
        B_Static_Spe_Min = new Button();
        L_Static_Spe = new Label();
        L_Static_SpeSpacer = new Label();
        NUD_Static_Spe_Max = new NumericUpDown();
        NUD_Static_Spe_Min = new NumericUpDown();
        B_Static_SpD_Max = new Button();
        B_Static_SpD_Min = new Button();
        L_Static_SpD = new Label();
        L_Static_SpDSpacer = new Label();
        NUD_Static_SpD_Max = new NumericUpDown();
        NUD_Static_SpD_Min = new NumericUpDown();
        B_Static_SpA_Max = new Button();
        B_Static_SpA_Min = new Button();
        L_Static_SpA = new Label();
        L_Static_SpASpacer = new Label();
        NUD_Static_SpA_Max = new NumericUpDown();
        NUD_Static_SpA_Min = new NumericUpDown();
        B_Static_Def_Max = new Button();
        B_Static_Def_Min = new Button();
        L_Static_Def = new Label();
        L_Static_DefSpacer = new Label();
        NUD_Static_Def_Max = new NumericUpDown();
        NUD_Static_Def_Min = new NumericUpDown();
        B_Static_Atk_Max = new Button();
        B_Static_Atk_Min = new Button();
        L_Static_Atk = new Label();
        L_Static_AtkSpacer = new Label();
        NUD_Static_Atk_Max = new NumericUpDown();
        NUD_Static_Atk_Min = new NumericUpDown();
        B_Static_HP_Max = new Button();
        B_Static_HP_Min = new Button();
        L_Static_HP = new Label();
        L_Static_HPSpacer = new Label();
        NUD_Static_HP_Max = new NumericUpDown();
        NUD_Static_HP_Min = new NumericUpDown();
        GB_ConnectionSettings = new GroupBox();
        CB_BabyModeDelay = new CheckBox();
        NUD_BabyModeDelay = new NumericUpDown();
        B_BabyMode_Cancel = new Button();
        B_BabyMode_Go = new Button();
        L_BabyMode = new Label();
        TB_BabyMode = new TextBox();
        B_ConnectionSettings = new Button();
        DGV_Results = new DataGridView();
        BS_SID = new BindingSource(components);
        B_ReadParty = new Button();
        NUD_PartySlot = new NumericUpDown();
        BS_Static = new BindingSource(components);
        GB_Connection.SuspendLayout();
        GB_Seed.SuspendLayout();
        GB_SAVInfo.SuspendLayout();
        TC_Main.SuspendLayout();
        TP_IDs.SuspendLayout();
        GB_SID.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_SID_Delay).BeginInit();
        groupBox1.SuspendLayout();
        TP_Seed.SuspendLayout();
        GB_SeedReset.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_SS_NumSeeds).BeginInit();
        TP_Static.SuspendLayout();
        GB_Filters.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Delay).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Spe_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Spe_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_SpD_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_SpD_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_SpA_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_SpA_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Def_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Def_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Atk_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Atk_Min).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_HP_Max).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_HP_Min).BeginInit();
        GB_ConnectionSettings.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_BabyModeDelay).BeginInit();
        ((System.ComponentModel.ISupportInitialize)DGV_Results).BeginInit();
        ((System.ComponentModel.ISupportInitialize)BS_SID).BeginInit();
        ((System.ComponentModel.ISupportInitialize)NUD_PartySlot).BeginInit();
        ((System.ComponentModel.ISupportInitialize)BS_Static).BeginInit();
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
        // B_ReadWildPokemon
        // 
        B_ReadWildPokemon.Location = new Point(601, 146);
        B_ReadWildPokemon.Name = "B_ReadWildPokemon";
        B_ReadWildPokemon.Size = new Size(181, 25);
        B_ReadWildPokemon.TabIndex = 9;
        B_ReadWildPokemon.Text = "Read Encounter";
        B_ReadWildPokemon.UseVisualStyleBackColor = true;
        B_ReadWildPokemon.Click += B_ReadWildPokemon_Click;
        // 
        // TB_Wild
        // 
        TB_Wild.Location = new Point(601, 3);
        TB_Wild.Multiline = true;
        TB_Wild.Name = "TB_Wild";
        TB_Wild.ReadOnly = true;
        TB_Wild.Size = new Size(181, 141);
        TB_Wild.TabIndex = 8;
        TB_Wild.TabStop = false;
        TB_Wild.Text = "Shiny - Species (Gender) @ Item\r\nPID: WWWWWWWW\r\nWWWWWWW Nature\r\nAbility: WWWWWWWWWW\r\nIVs: 22/22/22/22/22/22\r\n- Move 1\r\n- Move 2\r\n- Move 3\r\n- Move 4";
        // 
        // TC_Main
        // 
        TC_Main.Controls.Add(TP_IDs);
        TC_Main.Controls.Add(TP_Seed);
        TC_Main.Controls.Add(TP_Static);
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
        B_TID_Cancel.Click += B_Reset_Cancel_Click;
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
        // TP_Seed
        // 
        TP_Seed.Controls.Add(GB_SeedReset);
        TP_Seed.Location = new Point(4, 24);
        TP_Seed.Name = "TP_Seed";
        TP_Seed.Padding = new Padding(3);
        TP_Seed.Size = new Size(380, 297);
        TP_Seed.TabIndex = 1;
        TP_Seed.Text = "Seed Reset";
        TP_Seed.UseVisualStyleBackColor = true;
        // 
        // GB_SeedReset
        // 
        GB_SeedReset.Controls.Add(B_CancelSeedReset);
        GB_SeedReset.Controls.Add(B_ResetSeed);
        GB_SeedReset.Controls.Add(L_SS_SeedList);
        GB_SeedReset.Controls.Add(B_SS_SeedList);
        GB_SeedReset.Controls.Add(RB_SS_SpecificSeed);
        GB_SeedReset.Controls.Add(L_SS_SeedCount);
        GB_SeedReset.Controls.Add(TB_SS_SeedCount);
        GB_SeedReset.Controls.Add(B_SS_CountSeeds);
        GB_SeedReset.Controls.Add(L_SS_Adv);
        GB_SeedReset.Controls.Add(TB_SS_Adv);
        GB_SeedReset.Controls.Add(L_SS_NumSeeds);
        GB_SeedReset.Controls.Add(L_SS_MaxAdv);
        GB_SeedReset.Controls.Add(TB_SS_MaxAdv);
        GB_SeedReset.Controls.Add(B_SS_FindMax);
        GB_SeedReset.Controls.Add(NUD_SS_NumSeeds);
        GB_SeedReset.Controls.Add(RB_SS_Distance);
        GB_SeedReset.Controls.Add(TB_SS_TargetSeed);
        GB_SeedReset.Controls.Add(L_SS_TargetSeed);
        GB_SeedReset.Controls.Add(RB_SS_Number);
        GB_SeedReset.Location = new Point(6, -2);
        GB_SeedReset.Name = "GB_SeedReset";
        GB_SeedReset.Size = new Size(368, 293);
        GB_SeedReset.TabIndex = 9;
        GB_SeedReset.TabStop = false;
        // 
        // B_CancelSeedReset
        // 
        B_CancelSeedReset.Enabled = false;
        B_CancelSeedReset.Location = new Point(6, 262);
        B_CancelSeedReset.Name = "B_CancelSeedReset";
        B_CancelSeedReset.Size = new Size(150, 25);
        B_CancelSeedReset.TabIndex = 31;
        B_CancelSeedReset.Text = "Cancel";
        B_CancelSeedReset.UseVisualStyleBackColor = true;
        B_CancelSeedReset.Click += B_Reset_Cancel_Click;
        // 
        // B_ResetSeed
        // 
        B_ResetSeed.Location = new Point(162, 262);
        B_ResetSeed.Name = "B_ResetSeed";
        B_ResetSeed.Size = new Size(200, 25);
        B_ResetSeed.TabIndex = 30;
        B_ResetSeed.Text = "Reset for Seed";
        B_ResetSeed.UseVisualStyleBackColor = true;
        B_ResetSeed.Click += B_ResetSeed_Click;
        // 
        // L_SS_SeedList
        // 
        L_SS_SeedList.AutoSize = true;
        L_SS_SeedList.Enabled = false;
        L_SS_SeedList.Location = new Point(94, 231);
        L_SS_SeedList.Name = "L_SS_SeedList";
        L_SS_SeedList.Size = new Size(117, 15);
        L_SS_SeedList.TabIndex = 29;
        L_SS_SeedList.Text = "Loaded Seeds: None!";
        // 
        // B_SS_SeedList
        // 
        B_SS_SeedList.Enabled = false;
        B_SS_SeedList.Location = new Point(287, 226);
        B_SS_SeedList.Name = "B_SS_SeedList";
        B_SS_SeedList.Size = new Size(75, 25);
        B_SS_SeedList.TabIndex = 28;
        B_SS_SeedList.Text = "Edit";
        B_SS_SeedList.UseVisualStyleBackColor = true;
        B_SS_SeedList.Click += B_SeedList_Click;
        // 
        // RB_SS_SpecificSeed
        // 
        RB_SS_SpecificSeed.AutoSize = true;
        RB_SS_SpecificSeed.Location = new Point(6, 201);
        RB_SS_SpecificSeed.Name = "RB_SS_SpecificSeed";
        RB_SS_SpecificSeed.Size = new Size(155, 19);
        RB_SS_SpecificSeed.TabIndex = 26;
        RB_SS_SpecificSeed.Text = "Search for Specific Seeds";
        RB_SS_SpecificSeed.UseVisualStyleBackColor = true;
        RB_SS_SpecificSeed.CheckedChanged += RB_SS_CheckChanged;
        // 
        // L_SS_SeedCount
        // 
        L_SS_SeedCount.AutoSize = true;
        L_SS_SeedCount.Enabled = false;
        L_SS_SeedCount.Location = new Point(55, 173);
        L_SS_SeedCount.Name = "L_SS_SeedCount";
        L_SS_SeedCount.Size = new Size(121, 15);
        L_SS_SeedCount.TabIndex = 24;
        L_SS_SeedCount.Text = "Initial Seeds in Range:";
        // 
        // TB_SS_SeedCount
        // 
        TB_SS_SeedCount.CharacterCasing = CharacterCasing.Lower;
        TB_SS_SeedCount.Enabled = false;
        TB_SS_SeedCount.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SS_SeedCount.Location = new Point(185, 171);
        TB_SS_SeedCount.MaxLength = 13;
        TB_SS_SeedCount.Name = "TB_SS_SeedCount";
        TB_SS_SeedCount.ReadOnly = true;
        TB_SS_SeedCount.Size = new Size(98, 22);
        TB_SS_SeedCount.TabIndex = 23;
        TB_SS_SeedCount.TabStop = false;
        TB_SS_SeedCount.Text = "0";
        TB_SS_SeedCount.TextAlign = HorizontalAlignment.Right;
        // 
        // B_SS_CountSeeds
        // 
        B_SS_CountSeeds.Enabled = false;
        B_SS_CountSeeds.Location = new Point(287, 170);
        B_SS_CountSeeds.Name = "B_SS_CountSeeds";
        B_SS_CountSeeds.Size = new Size(75, 25);
        B_SS_CountSeeds.TabIndex = 22;
        B_SS_CountSeeds.Text = "Count";
        B_SS_CountSeeds.UseVisualStyleBackColor = true;
        B_SS_CountSeeds.Click += B_SS_CountSeeds_Click;
        // 
        // L_SS_Adv
        // 
        L_SS_Adv.AutoSize = true;
        L_SS_Adv.Enabled = false;
        L_SS_Adv.Location = new Point(86, 148);
        L_SS_Adv.Name = "L_SS_Adv";
        L_SS_Adv.Size = new Size(90, 15);
        L_SS_Adv.TabIndex = 21;
        L_SS_Adv.Text = "Max. Advances:";
        // 
        // TB_SS_Adv
        // 
        TB_SS_Adv.CharacterCasing = CharacterCasing.Lower;
        TB_SS_Adv.Enabled = false;
        TB_SS_Adv.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SS_Adv.Location = new Point(287, 146);
        TB_SS_Adv.MaxLength = 13;
        TB_SS_Adv.Name = "TB_SS_Adv";
        TB_SS_Adv.Size = new Size(75, 22);
        TB_SS_Adv.TabIndex = 20;
        TB_SS_Adv.TabStop = false;
        TB_SS_Adv.Text = "2000000";
        TB_SS_Adv.TextAlign = HorizontalAlignment.Right;
        // 
        // L_SS_NumSeeds
        // 
        L_SS_NumSeeds.AutoSize = true;
        L_SS_NumSeeds.Location = new Point(136, 69);
        L_SS_NumSeeds.Name = "L_SS_NumSeeds";
        L_SS_NumSeeds.Size = new Size(40, 15);
        L_SS_NumSeeds.TabIndex = 19;
        L_SS_NumSeeds.Text = "Seeds:";
        // 
        // L_SS_MaxAdv
        // 
        L_SS_MaxAdv.AutoSize = true;
        L_SS_MaxAdv.Location = new Point(86, 95);
        L_SS_MaxAdv.Name = "L_SS_MaxAdv";
        L_SS_MaxAdv.Size = new Size(90, 15);
        L_SS_MaxAdv.TabIndex = 18;
        L_SS_MaxAdv.Text = "Max. Advances:";
        // 
        // TB_SS_MaxAdv
        // 
        TB_SS_MaxAdv.CharacterCasing = CharacterCasing.Lower;
        TB_SS_MaxAdv.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SS_MaxAdv.Location = new Point(185, 93);
        TB_SS_MaxAdv.MaxLength = 13;
        TB_SS_MaxAdv.Name = "TB_SS_MaxAdv";
        TB_SS_MaxAdv.ReadOnly = true;
        TB_SS_MaxAdv.Size = new Size(98, 22);
        TB_SS_MaxAdv.TabIndex = 17;
        TB_SS_MaxAdv.TabStop = false;
        TB_SS_MaxAdv.Text = "0";
        TB_SS_MaxAdv.TextAlign = HorizontalAlignment.Right;
        // 
        // B_SS_FindMax
        // 
        B_SS_FindMax.Location = new Point(287, 92);
        B_SS_FindMax.Name = "B_SS_FindMax";
        B_SS_FindMax.Size = new Size(75, 25);
        B_SS_FindMax.TabIndex = 10;
        B_SS_FindMax.Text = "Find Max";
        B_SS_FindMax.UseVisualStyleBackColor = true;
        B_SS_FindMax.Click += B_SS_FindMax_Click;
        // 
        // NUD_SS_NumSeeds
        // 
        NUD_SS_NumSeeds.Location = new Point(287, 67);
        NUD_SS_NumSeeds.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
        NUD_SS_NumSeeds.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        NUD_SS_NumSeeds.Name = "NUD_SS_NumSeeds";
        NUD_SS_NumSeeds.Size = new Size(75, 23);
        NUD_SS_NumSeeds.TabIndex = 9;
        NUD_SS_NumSeeds.TextAlign = HorizontalAlignment.Right;
        NUD_SS_NumSeeds.Value = new decimal(new int[] { 60, 0, 0, 0 });
        // 
        // RB_SS_Distance
        // 
        RB_SS_Distance.AutoSize = true;
        RB_SS_Distance.Location = new Point(6, 125);
        RB_SS_Distance.Name = "RB_SS_Distance";
        RB_SS_Distance.Size = new Size(173, 19);
        RB_SS_Distance.TabIndex = 1;
        RB_SS_Distance.Text = "Search by Distance to Target";
        RB_SS_Distance.UseVisualStyleBackColor = true;
        RB_SS_Distance.CheckedChanged += RB_SS_CheckChanged;
        // 
        // TB_SS_TargetSeed
        // 
        TB_SS_TargetSeed.CharacterCasing = CharacterCasing.Upper;
        TB_SS_TargetSeed.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_SS_TargetSeed.Location = new Point(300, 22);
        TB_SS_TargetSeed.MaxLength = 8;
        TB_SS_TargetSeed.Name = "TB_SS_TargetSeed";
        TB_SS_TargetSeed.Size = new Size(62, 22);
        TB_SS_TargetSeed.TabIndex = 7;
        TB_SS_TargetSeed.Text = "01234567";
        // 
        // L_SS_TargetSeed
        // 
        L_SS_TargetSeed.AutoSize = true;
        L_SS_TargetSeed.Location = new Point(224, 24);
        L_SS_TargetSeed.Name = "L_SS_TargetSeed";
        L_SS_TargetSeed.Size = new Size(70, 15);
        L_SS_TargetSeed.TabIndex = 8;
        L_SS_TargetSeed.Text = "Target Seed:";
        // 
        // RB_SS_Number
        // 
        RB_SS_Number.AutoSize = true;
        RB_SS_Number.Checked = true;
        RB_SS_Number.Location = new Point(6, 46);
        RB_SS_Number.Name = "RB_SS_Number";
        RB_SS_Number.Size = new Size(170, 19);
        RB_SS_Number.TabIndex = 0;
        RB_SS_Number.TabStop = true;
        RB_SS_Number.Text = "Search by Number of Seeds";
        RB_SS_Number.UseVisualStyleBackColor = true;
        RB_SS_Number.CheckedChanged += RB_SS_CheckChanged;
        // 
        // TP_Static
        // 
        TP_Static.Controls.Add(L_Static_Method);
        TP_Static.Controls.Add(CB_Static_Method);
        TP_Static.Controls.Add(L_Static_Species);
        TP_Static.Controls.Add(CB_Static_Species);
        TP_Static.Controls.Add(CB_Static_RoamerBug);
        TP_Static.Controls.Add(B_Static_Search);
        TP_Static.Controls.Add(L_Static_Advances);
        TP_Static.Controls.Add(L_Static_Initial);
        TP_Static.Controls.Add(TB_Static_Advances);
        TP_Static.Controls.Add(TB_Static_Initial);
        TP_Static.Controls.Add(GB_Filters);
        TP_Static.Location = new Point(4, 24);
        TP_Static.Name = "TP_Static";
        TP_Static.Size = new Size(380, 297);
        TP_Static.TabIndex = 2;
        TP_Static.Text = "Static";
        TP_Static.UseVisualStyleBackColor = true;
        // 
        // L_Static_Method
        // 
        L_Static_Method.AutoSize = true;
        L_Static_Method.Location = new Point(12, 48);
        L_Static_Method.Name = "L_Static_Method";
        L_Static_Method.Size = new Size(52, 15);
        L_Static_Method.TabIndex = 184;
        L_Static_Method.Text = "Method:";
        // 
        // CB_Static_Method
        // 
        CB_Static_Method.FormattingEnabled = true;
        CB_Static_Method.Items.AddRange(new object[] { "Method 1", "Method 4" });
        CB_Static_Method.Location = new Point(70, 45);
        CB_Static_Method.Name = "CB_Static_Method";
        CB_Static_Method.Size = new Size(101, 23);
        CB_Static_Method.TabIndex = 183;
        // 
        // L_Static_Species
        // 
        L_Static_Species.AutoSize = true;
        L_Static_Species.Location = new Point(15, 23);
        L_Static_Species.Name = "L_Static_Species";
        L_Static_Species.Size = new Size(49, 15);
        L_Static_Species.TabIndex = 182;
        L_Static_Species.Text = "Species:";
        // 
        // CB_Static_Species
        // 
        CB_Static_Species.FormattingEnabled = true;
        CB_Static_Species.Items.AddRange(new object[] { "Charmander" });
        CB_Static_Species.Location = new Point(70, 20);
        CB_Static_Species.Name = "CB_Static_Species";
        CB_Static_Species.Size = new Size(101, 23);
        CB_Static_Species.TabIndex = 181;
        // 
        // CB_Static_RoamerBug
        // 
        CB_Static_RoamerBug.AutoSize = true;
        CB_Static_RoamerBug.CheckAlign = ContentAlignment.MiddleRight;
        CB_Static_RoamerBug.Location = new Point(24, 194);
        CB_Static_RoamerBug.Name = "CB_Static_RoamerBug";
        CB_Static_RoamerBug.Size = new Size(134, 19);
        CB_Static_RoamerBug.TabIndex = 180;
        CB_Static_RoamerBug.Tag = "";
        CB_Static_RoamerBug.Text = "Bugged Roamer IVs?";
        CB_Static_RoamerBug.UseVisualStyleBackColor = true;
        // 
        // B_Static_Search
        // 
        B_Static_Search.Location = new Point(3, 269);
        B_Static_Search.Name = "B_Static_Search";
        B_Static_Search.Size = new Size(374, 25);
        B_Static_Search.TabIndex = 175;
        B_Static_Search.Text = "Generate";
        B_Static_Search.UseVisualStyleBackColor = true;
        B_Static_Search.Click += B_Static_Search_Click;
        // 
        // L_Static_Advances
        // 
        L_Static_Advances.AutoSize = true;
        L_Static_Advances.Location = new Point(49, 246);
        L_Static_Advances.Name = "L_Static_Advances";
        L_Static_Advances.Size = new Size(15, 15);
        L_Static_Advances.TabIndex = 179;
        L_Static_Advances.Text = "+";
        // 
        // L_Static_Initial
        // 
        L_Static_Initial.AutoSize = true;
        L_Static_Initial.Location = new Point(7, 221);
        L_Static_Initial.Name = "L_Static_Initial";
        L_Static_Initial.Size = new Size(57, 15);
        L_Static_Initial.TabIndex = 178;
        L_Static_Initial.Text = "Init. Adv.:";
        // 
        // TB_Static_Advances
        // 
        TB_Static_Advances.CharacterCasing = CharacterCasing.Upper;
        TB_Static_Advances.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_Static_Advances.Location = new Point(70, 243);
        TB_Static_Advances.MaxLength = 10;
        TB_Static_Advances.Name = "TB_Static_Advances";
        TB_Static_Advances.Size = new Size(101, 22);
        TB_Static_Advances.TabIndex = 177;
        TB_Static_Advances.Text = "100000";
        TB_Static_Advances.TextAlign = HorizontalAlignment.Right;
        // 
        // TB_Static_Initial
        // 
        TB_Static_Initial.CharacterCasing = CharacterCasing.Upper;
        TB_Static_Initial.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_Static_Initial.Location = new Point(70, 219);
        TB_Static_Initial.MaxLength = 10;
        TB_Static_Initial.Name = "TB_Static_Initial";
        TB_Static_Initial.Size = new Size(101, 22);
        TB_Static_Initial.TabIndex = 176;
        TB_Static_Initial.Text = "0";
        TB_Static_Initial.TextAlign = HorizontalAlignment.Right;
        // 
        // GB_Filters
        // 
        GB_Filters.Controls.Add(L_Static_Nature);
        GB_Filters.Controls.Add(CB_Static_Nature);
        GB_Filters.Controls.Add(CB_Static_Delay);
        GB_Filters.Controls.Add(NUD_Static_Delay);
        GB_Filters.Controls.Add(CB_RareEC);
        GB_Filters.Controls.Add(CB_Static_FiltersEnabled);
        GB_Filters.Controls.Add(L_Static_Shiny);
        GB_Filters.Controls.Add(CB_Static_Shiny);
        GB_Filters.Controls.Add(B_Static_Spe_Max);
        GB_Filters.Controls.Add(B_Static_Spe_Min);
        GB_Filters.Controls.Add(L_Static_Spe);
        GB_Filters.Controls.Add(L_Static_SpeSpacer);
        GB_Filters.Controls.Add(NUD_Static_Spe_Max);
        GB_Filters.Controls.Add(NUD_Static_Spe_Min);
        GB_Filters.Controls.Add(B_Static_SpD_Max);
        GB_Filters.Controls.Add(B_Static_SpD_Min);
        GB_Filters.Controls.Add(L_Static_SpD);
        GB_Filters.Controls.Add(L_Static_SpDSpacer);
        GB_Filters.Controls.Add(NUD_Static_SpD_Max);
        GB_Filters.Controls.Add(NUD_Static_SpD_Min);
        GB_Filters.Controls.Add(B_Static_SpA_Max);
        GB_Filters.Controls.Add(B_Static_SpA_Min);
        GB_Filters.Controls.Add(L_Static_SpA);
        GB_Filters.Controls.Add(L_Static_SpASpacer);
        GB_Filters.Controls.Add(NUD_Static_SpA_Max);
        GB_Filters.Controls.Add(NUD_Static_SpA_Min);
        GB_Filters.Controls.Add(B_Static_Def_Max);
        GB_Filters.Controls.Add(B_Static_Def_Min);
        GB_Filters.Controls.Add(L_Static_Def);
        GB_Filters.Controls.Add(L_Static_DefSpacer);
        GB_Filters.Controls.Add(NUD_Static_Def_Max);
        GB_Filters.Controls.Add(NUD_Static_Def_Min);
        GB_Filters.Controls.Add(B_Static_Atk_Max);
        GB_Filters.Controls.Add(B_Static_Atk_Min);
        GB_Filters.Controls.Add(L_Static_Atk);
        GB_Filters.Controls.Add(L_Static_AtkSpacer);
        GB_Filters.Controls.Add(NUD_Static_Atk_Max);
        GB_Filters.Controls.Add(NUD_Static_Atk_Min);
        GB_Filters.Controls.Add(B_Static_HP_Max);
        GB_Filters.Controls.Add(B_Static_HP_Min);
        GB_Filters.Controls.Add(L_Static_HP);
        GB_Filters.Controls.Add(L_Static_HPSpacer);
        GB_Filters.Controls.Add(NUD_Static_HP_Max);
        GB_Filters.Controls.Add(NUD_Static_HP_Min);
        GB_Filters.Location = new Point(177, 3);
        GB_Filters.Name = "GB_Filters";
        GB_Filters.Size = new Size(200, 262);
        GB_Filters.TabIndex = 127;
        GB_Filters.TabStop = false;
        GB_Filters.Text = "Search Filters";
        // 
        // L_Static_Nature
        // 
        L_Static_Nature.AutoSize = true;
        L_Static_Nature.Location = new Point(2, 196);
        L_Static_Nature.Name = "L_Static_Nature";
        L_Static_Nature.Size = new Size(46, 15);
        L_Static_Nature.TabIndex = 169;
        L_Static_Nature.Text = "Nature:";
        // 
        // CB_Static_Nature
        // 
        CB_Static_Nature.FormattingEnabled = true;
        CB_Static_Nature.Items.AddRange(new object[] { "Ignore", "Hardy", "Lonely", "Brave", "Adamant", "Naughty", "Bold", "Docile", "Relaxed", "Impish", "Lax", "Timid", "Hasty", "Serious", "Jolly", "Naive", "Modest", "Mild", "Quiet", "Bashful", "Rash", "Calm", "Gentle", "Sassy", "Careful", "Quirky" });
        CB_Static_Nature.Location = new Point(53, 193);
        CB_Static_Nature.Name = "CB_Static_Nature";
        CB_Static_Nature.Size = new Size(142, 23);
        CB_Static_Nature.TabIndex = 168;
        // 
        // CB_Static_Delay
        // 
        CB_Static_Delay.AutoSize = true;
        CB_Static_Delay.CheckAlign = ContentAlignment.MiddleRight;
        CB_Static_Delay.Location = new Point(8, 219);
        CB_Static_Delay.Name = "CB_Static_Delay";
        CB_Static_Delay.Size = new Size(58, 19);
        CB_Static_Delay.TabIndex = 167;
        CB_Static_Delay.Tag = "";
        CB_Static_Delay.Text = "Delay:";
        CB_Static_Delay.UseVisualStyleBackColor = true;
        CB_Static_Delay.CheckedChanged += CB_Static_Delay_CheckedChanged;
        // 
        // NUD_Static_Delay
        // 
        NUD_Static_Delay.Enabled = false;
        NUD_Static_Delay.Location = new Point(72, 218);
        NUD_Static_Delay.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        NUD_Static_Delay.Name = "NUD_Static_Delay";
        NUD_Static_Delay.Size = new Size(123, 23);
        NUD_Static_Delay.TabIndex = 166;
        NUD_Static_Delay.TextAlign = HorizontalAlignment.Right;
        NUD_Static_Delay.Value = new decimal(new int[] { 100, 0, 0, 0 });
        // 
        // CB_RareEC
        // 
        CB_RareEC.AutoSize = true;
        CB_RareEC.CheckAlign = ContentAlignment.MiddleRight;
        CB_RareEC.Location = new Point(7, 243);
        CB_RareEC.Name = "CB_RareEC";
        CB_RareEC.Size = new Size(75, 19);
        CB_RareEC.TabIndex = 27;
        CB_RareEC.Tag = "";
        CB_RareEC.Text = "Rare PID?";
        CB_RareEC.UseVisualStyleBackColor = true;
        CB_RareEC.Visible = false;
        // 
        // CB_Static_FiltersEnabled
        // 
        CB_Static_FiltersEnabled.AutoSize = true;
        CB_Static_FiltersEnabled.CheckAlign = ContentAlignment.MiddleRight;
        CB_Static_FiltersEnabled.Checked = true;
        CB_Static_FiltersEnabled.CheckState = CheckState.Checked;
        CB_Static_FiltersEnabled.Location = new Point(88, 243);
        CB_Static_FiltersEnabled.Name = "CB_Static_FiltersEnabled";
        CB_Static_FiltersEnabled.Size = new Size(107, 19);
        CB_Static_FiltersEnabled.TabIndex = 28;
        CB_Static_FiltersEnabled.Tag = "";
        CB_Static_FiltersEnabled.Text = "Filters Enabled?";
        CB_Static_FiltersEnabled.UseVisualStyleBackColor = true;
        // 
        // L_Static_Shiny
        // 
        L_Static_Shiny.AutoSize = true;
        L_Static_Shiny.Location = new Point(9, 171);
        L_Static_Shiny.Name = "L_Static_Shiny";
        L_Static_Shiny.Size = new Size(39, 15);
        L_Static_Shiny.TabIndex = 162;
        L_Static_Shiny.Text = "Shiny:";
        // 
        // CB_Static_Shiny
        // 
        CB_Static_Shiny.FormattingEnabled = true;
        CB_Static_Shiny.Items.AddRange(new object[] { "Ignore", "Star/Square", "Square Only", "Star Only", "Not Shiny" });
        CB_Static_Shiny.Location = new Point(53, 168);
        CB_Static_Shiny.Name = "CB_Static_Shiny";
        CB_Static_Shiny.Size = new Size(142, 23);
        CB_Static_Shiny.TabIndex = 24;
        // 
        // B_Static_Spe_Max
        // 
        B_Static_Spe_Max.Location = new Point(168, 142);
        B_Static_Spe_Max.Name = "B_Static_Spe_Max";
        B_Static_Spe_Max.Size = new Size(27, 25);
        B_Static_Spe_Max.TabIndex = 23;
        B_Static_Spe_Max.Text = "31";
        B_Static_Spe_Max.UseVisualStyleBackColor = true;
        B_Static_Spe_Max.Click += B_IV_Max_Click;
        // 
        // B_Static_Spe_Min
        // 
        B_Static_Spe_Min.Location = new Point(139, 142);
        B_Static_Spe_Min.Name = "B_Static_Spe_Min";
        B_Static_Spe_Min.Size = new Size(27, 25);
        B_Static_Spe_Min.TabIndex = 22;
        B_Static_Spe_Min.Text = "0";
        B_Static_Spe_Min.UseVisualStyleBackColor = true;
        B_Static_Spe_Min.Click += B_IV_Min_Click;
        // 
        // L_Static_Spe
        // 
        L_Static_Spe.AutoSize = true;
        L_Static_Spe.Location = new Point(19, 147);
        L_Static_Spe.Name = "L_Static_Spe";
        L_Static_Spe.Size = new Size(29, 15);
        L_Static_Spe.TabIndex = 161;
        L_Static_Spe.Text = "Spe:";
        L_Static_Spe.Click += IV_Label_Click;
        // 
        // L_Static_SpeSpacer
        // 
        L_Static_SpeSpacer.AutoSize = true;
        L_Static_SpeSpacer.Location = new Point(86, 145);
        L_Static_SpeSpacer.Name = "L_Static_SpeSpacer";
        L_Static_SpeSpacer.Size = new Size(15, 15);
        L_Static_SpeSpacer.TabIndex = 11;
        L_Static_SpeSpacer.Text = "~";
        L_Static_SpeSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_Static_Spe_Max
        // 
        NUD_Static_Spe_Max.Location = new Point(102, 143);
        NUD_Static_Spe_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_Spe_Max.Name = "NUD_Static_Spe_Max";
        NUD_Static_Spe_Max.Size = new Size(32, 23);
        NUD_Static_Spe_Max.TabIndex = 140;
        NUD_Static_Spe_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_Static_Spe_Min
        // 
        NUD_Static_Spe_Min.Location = new Point(53, 143);
        NUD_Static_Spe_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_Spe_Min.Name = "NUD_Static_Spe_Min";
        NUD_Static_Spe_Min.Size = new Size(32, 23);
        NUD_Static_Spe_Min.TabIndex = 10;
        // 
        // B_Static_SpD_Max
        // 
        B_Static_SpD_Max.Location = new Point(168, 117);
        B_Static_SpD_Max.Name = "B_Static_SpD_Max";
        B_Static_SpD_Max.Size = new Size(27, 25);
        B_Static_SpD_Max.TabIndex = 21;
        B_Static_SpD_Max.Text = "31";
        B_Static_SpD_Max.UseVisualStyleBackColor = true;
        B_Static_SpD_Max.Click += B_IV_Max_Click;
        // 
        // B_Static_SpD_Min
        // 
        B_Static_SpD_Min.Location = new Point(139, 117);
        B_Static_SpD_Min.Name = "B_Static_SpD_Min";
        B_Static_SpD_Min.Size = new Size(27, 25);
        B_Static_SpD_Min.TabIndex = 20;
        B_Static_SpD_Min.Text = "0";
        B_Static_SpD_Min.UseVisualStyleBackColor = true;
        B_Static_SpD_Min.Click += B_IV_Min_Click;
        // 
        // L_Static_SpD
        // 
        L_Static_SpD.AutoSize = true;
        L_Static_SpD.Location = new Point(17, 123);
        L_Static_SpD.Name = "L_Static_SpD";
        L_Static_SpD.Size = new Size(31, 15);
        L_Static_SpD.TabIndex = 160;
        L_Static_SpD.Text = "SpD:";
        L_Static_SpD.Click += IV_Label_Click;
        // 
        // L_Static_SpDSpacer
        // 
        L_Static_SpDSpacer.AutoSize = true;
        L_Static_SpDSpacer.Location = new Point(86, 120);
        L_Static_SpDSpacer.Name = "L_Static_SpDSpacer";
        L_Static_SpDSpacer.Size = new Size(15, 15);
        L_Static_SpDSpacer.TabIndex = 9;
        L_Static_SpDSpacer.Text = "~";
        L_Static_SpDSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_Static_SpD_Max
        // 
        NUD_Static_SpD_Max.Location = new Point(102, 118);
        NUD_Static_SpD_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_SpD_Max.Name = "NUD_Static_SpD_Max";
        NUD_Static_SpD_Max.Size = new Size(32, 23);
        NUD_Static_SpD_Max.TabIndex = 137;
        NUD_Static_SpD_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_Static_SpD_Min
        // 
        NUD_Static_SpD_Min.Location = new Point(53, 118);
        NUD_Static_SpD_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_SpD_Min.Name = "NUD_Static_SpD_Min";
        NUD_Static_SpD_Min.Size = new Size(32, 23);
        NUD_Static_SpD_Min.TabIndex = 8;
        // 
        // B_Static_SpA_Max
        // 
        B_Static_SpA_Max.Location = new Point(168, 92);
        B_Static_SpA_Max.Name = "B_Static_SpA_Max";
        B_Static_SpA_Max.Size = new Size(27, 25);
        B_Static_SpA_Max.TabIndex = 19;
        B_Static_SpA_Max.Text = "31";
        B_Static_SpA_Max.UseVisualStyleBackColor = true;
        B_Static_SpA_Max.Click += B_IV_Max_Click;
        // 
        // B_Static_SpA_Min
        // 
        B_Static_SpA_Min.Location = new Point(139, 92);
        B_Static_SpA_Min.Name = "B_Static_SpA_Min";
        B_Static_SpA_Min.Size = new Size(27, 25);
        B_Static_SpA_Min.TabIndex = 18;
        B_Static_SpA_Min.Text = "0";
        B_Static_SpA_Min.UseVisualStyleBackColor = true;
        B_Static_SpA_Min.Click += B_IV_Min_Click;
        // 
        // L_Static_SpA
        // 
        L_Static_SpA.AutoSize = true;
        L_Static_SpA.Location = new Point(17, 95);
        L_Static_SpA.Name = "L_Static_SpA";
        L_Static_SpA.Size = new Size(31, 15);
        L_Static_SpA.TabIndex = 156;
        L_Static_SpA.Text = "SpA:";
        L_Static_SpA.Click += IV_Label_Click;
        // 
        // L_Static_SpASpacer
        // 
        L_Static_SpASpacer.AutoSize = true;
        L_Static_SpASpacer.Location = new Point(86, 95);
        L_Static_SpASpacer.Name = "L_Static_SpASpacer";
        L_Static_SpASpacer.Size = new Size(15, 15);
        L_Static_SpASpacer.TabIndex = 134;
        L_Static_SpASpacer.Text = "~";
        L_Static_SpASpacer.Click += IV_Spacer_Click;
        // 
        // NUD_Static_SpA_Max
        // 
        NUD_Static_SpA_Max.Location = new Point(102, 93);
        NUD_Static_SpA_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_SpA_Max.Name = "NUD_Static_SpA_Max";
        NUD_Static_SpA_Max.Size = new Size(32, 23);
        NUD_Static_SpA_Max.TabIndex = 7;
        NUD_Static_SpA_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_Static_SpA_Min
        // 
        NUD_Static_SpA_Min.Location = new Point(53, 93);
        NUD_Static_SpA_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_SpA_Min.Name = "NUD_Static_SpA_Min";
        NUD_Static_SpA_Min.Size = new Size(32, 23);
        NUD_Static_SpA_Min.TabIndex = 6;
        // 
        // B_Static_Def_Max
        // 
        B_Static_Def_Max.Location = new Point(168, 67);
        B_Static_Def_Max.Name = "B_Static_Def_Max";
        B_Static_Def_Max.Size = new Size(27, 25);
        B_Static_Def_Max.TabIndex = 17;
        B_Static_Def_Max.Text = "31";
        B_Static_Def_Max.UseVisualStyleBackColor = true;
        B_Static_Def_Max.Click += B_IV_Max_Click;
        // 
        // B_Static_Def_Min
        // 
        B_Static_Def_Min.Location = new Point(139, 67);
        B_Static_Def_Min.Name = "B_Static_Def_Min";
        B_Static_Def_Min.Size = new Size(27, 25);
        B_Static_Def_Min.TabIndex = 16;
        B_Static_Def_Min.Text = "0";
        B_Static_Def_Min.UseVisualStyleBackColor = true;
        B_Static_Def_Min.Click += B_IV_Min_Click;
        // 
        // L_Static_Def
        // 
        L_Static_Def.AutoSize = true;
        L_Static_Def.Location = new Point(20, 70);
        L_Static_Def.Name = "L_Static_Def";
        L_Static_Def.Size = new Size(28, 15);
        L_Static_Def.TabIndex = 149;
        L_Static_Def.Text = "Def:";
        L_Static_Def.Click += IV_Label_Click;
        // 
        // L_Static_DefSpacer
        // 
        L_Static_DefSpacer.AutoSize = true;
        L_Static_DefSpacer.Location = new Point(86, 70);
        L_Static_DefSpacer.Name = "L_Static_DefSpacer";
        L_Static_DefSpacer.Size = new Size(15, 15);
        L_Static_DefSpacer.TabIndex = 129;
        L_Static_DefSpacer.Text = "~";
        L_Static_DefSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_Static_Def_Max
        // 
        NUD_Static_Def_Max.Location = new Point(102, 68);
        NUD_Static_Def_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_Def_Max.Name = "NUD_Static_Def_Max";
        NUD_Static_Def_Max.Size = new Size(32, 23);
        NUD_Static_Def_Max.TabIndex = 5;
        NUD_Static_Def_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_Static_Def_Min
        // 
        NUD_Static_Def_Min.Location = new Point(53, 68);
        NUD_Static_Def_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_Def_Min.Name = "NUD_Static_Def_Min";
        NUD_Static_Def_Min.Size = new Size(32, 23);
        NUD_Static_Def_Min.TabIndex = 4;
        // 
        // B_Static_Atk_Max
        // 
        B_Static_Atk_Max.Location = new Point(168, 42);
        B_Static_Atk_Max.Name = "B_Static_Atk_Max";
        B_Static_Atk_Max.Size = new Size(27, 25);
        B_Static_Atk_Max.TabIndex = 15;
        B_Static_Atk_Max.Text = "31";
        B_Static_Atk_Max.UseVisualStyleBackColor = true;
        B_Static_Atk_Max.Click += B_IV_Max_Click;
        // 
        // B_Static_Atk_Min
        // 
        B_Static_Atk_Min.Location = new Point(139, 42);
        B_Static_Atk_Min.Name = "B_Static_Atk_Min";
        B_Static_Atk_Min.Size = new Size(27, 25);
        B_Static_Atk_Min.TabIndex = 14;
        B_Static_Atk_Min.Text = "0";
        B_Static_Atk_Min.UseVisualStyleBackColor = true;
        B_Static_Atk_Min.Click += B_IV_Min_Click;
        // 
        // L_Static_Atk
        // 
        L_Static_Atk.AutoSize = true;
        L_Static_Atk.Location = new Point(20, 45);
        L_Static_Atk.Name = "L_Static_Atk";
        L_Static_Atk.Size = new Size(28, 15);
        L_Static_Atk.TabIndex = 142;
        L_Static_Atk.Text = "Atk:";
        L_Static_Atk.Click += IV_Label_Click;
        // 
        // L_Static_AtkSpacer
        // 
        L_Static_AtkSpacer.AutoSize = true;
        L_Static_AtkSpacer.Location = new Point(86, 45);
        L_Static_AtkSpacer.Name = "L_Static_AtkSpacer";
        L_Static_AtkSpacer.Size = new Size(15, 15);
        L_Static_AtkSpacer.TabIndex = 126;
        L_Static_AtkSpacer.Text = "~";
        L_Static_AtkSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_Static_Atk_Max
        // 
        NUD_Static_Atk_Max.Location = new Point(102, 43);
        NUD_Static_Atk_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_Atk_Max.Name = "NUD_Static_Atk_Max";
        NUD_Static_Atk_Max.Size = new Size(32, 23);
        NUD_Static_Atk_Max.TabIndex = 3;
        NUD_Static_Atk_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_Static_Atk_Min
        // 
        NUD_Static_Atk_Min.Location = new Point(53, 43);
        NUD_Static_Atk_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_Atk_Min.Name = "NUD_Static_Atk_Min";
        NUD_Static_Atk_Min.Size = new Size(32, 23);
        NUD_Static_Atk_Min.TabIndex = 2;
        // 
        // B_Static_HP_Max
        // 
        B_Static_HP_Max.Location = new Point(168, 17);
        B_Static_HP_Max.Name = "B_Static_HP_Max";
        B_Static_HP_Max.Size = new Size(27, 25);
        B_Static_HP_Max.TabIndex = 13;
        B_Static_HP_Max.Text = "31";
        B_Static_HP_Max.UseVisualStyleBackColor = true;
        B_Static_HP_Max.Click += B_IV_Max_Click;
        // 
        // B_Static_HP_Min
        // 
        B_Static_HP_Min.Location = new Point(139, 17);
        B_Static_HP_Min.Name = "B_Static_HP_Min";
        B_Static_HP_Min.Size = new Size(27, 25);
        B_Static_HP_Min.TabIndex = 12;
        B_Static_HP_Min.Text = "0";
        B_Static_HP_Min.UseVisualStyleBackColor = true;
        B_Static_HP_Min.Click += B_IV_Min_Click;
        // 
        // L_Static_HP
        // 
        L_Static_HP.AutoSize = true;
        L_Static_HP.Location = new Point(22, 20);
        L_Static_HP.Name = "L_Static_HP";
        L_Static_HP.Size = new Size(26, 15);
        L_Static_HP.TabIndex = 132;
        L_Static_HP.Text = "HP:";
        L_Static_HP.Click += IV_Label_Click;
        // 
        // L_Static_HPSpacer
        // 
        L_Static_HPSpacer.AutoSize = true;
        L_Static_HPSpacer.Location = new Point(86, 20);
        L_Static_HPSpacer.Name = "L_Static_HPSpacer";
        L_Static_HPSpacer.Size = new Size(15, 15);
        L_Static_HPSpacer.TabIndex = 130;
        L_Static_HPSpacer.Text = "~";
        L_Static_HPSpacer.Click += IV_Spacer_Click;
        // 
        // NUD_Static_HP_Max
        // 
        NUD_Static_HP_Max.Location = new Point(102, 18);
        NUD_Static_HP_Max.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_HP_Max.Name = "NUD_Static_HP_Max";
        NUD_Static_HP_Max.Size = new Size(32, 23);
        NUD_Static_HP_Max.TabIndex = 1;
        NUD_Static_HP_Max.Value = new decimal(new int[] { 31, 0, 0, 0 });
        // 
        // NUD_Static_HP_Min
        // 
        NUD_Static_HP_Min.Location = new Point(53, 18);
        NUD_Static_HP_Min.Maximum = new decimal(new int[] { 31, 0, 0, 0 });
        NUD_Static_HP_Min.Name = "NUD_Static_HP_Min";
        NUD_Static_HP_Min.Size = new Size(32, 23);
        NUD_Static_HP_Min.TabIndex = 0;
        // 
        // GB_ConnectionSettings
        // 
        GB_ConnectionSettings.Controls.Add(CB_BabyModeDelay);
        GB_ConnectionSettings.Controls.Add(NUD_BabyModeDelay);
        GB_ConnectionSettings.Controls.Add(B_BabyMode_Cancel);
        GB_ConnectionSettings.Controls.Add(B_BabyMode_Go);
        GB_ConnectionSettings.Controls.Add(L_BabyMode);
        GB_ConnectionSettings.Controls.Add(TB_BabyMode);
        GB_ConnectionSettings.Controls.Add(B_ConnectionSettings);
        GB_ConnectionSettings.Location = new Point(0, 209);
        GB_ConnectionSettings.Name = "GB_ConnectionSettings";
        GB_ConnectionSettings.Size = new Size(212, 117);
        GB_ConnectionSettings.TabIndex = 128;
        GB_ConnectionSettings.TabStop = false;
        // 
        // CB_BabyModeDelay
        // 
        CB_BabyModeDelay.AutoSize = true;
        CB_BabyModeDelay.CheckAlign = ContentAlignment.MiddleRight;
        CB_BabyModeDelay.Location = new Point(12, 66);
        CB_BabyModeDelay.Name = "CB_BabyModeDelay";
        CB_BabyModeDelay.Size = new Size(58, 19);
        CB_BabyModeDelay.TabIndex = 176;
        CB_BabyModeDelay.Tag = "";
        CB_BabyModeDelay.Text = "Delay:";
        CB_BabyModeDelay.UseVisualStyleBackColor = true;
        CB_BabyModeDelay.CheckedChanged += CB_BabyModeDelay_CheckedChanged;
        // 
        // NUD_BabyModeDelay
        // 
        NUD_BabyModeDelay.Enabled = false;
        NUD_BabyModeDelay.Location = new Point(88, 65);
        NUD_BabyModeDelay.Maximum = new decimal(new int[] { 999, 0, 0, 0 });
        NUD_BabyModeDelay.Name = "NUD_BabyModeDelay";
        NUD_BabyModeDelay.Size = new Size(117, 23);
        NUD_BabyModeDelay.TabIndex = 175;
        NUD_BabyModeDelay.TextAlign = HorizontalAlignment.Right;
        // 
        // B_BabyMode_Cancel
        // 
        B_BabyMode_Cancel.Location = new Point(11, 90);
        B_BabyMode_Cancel.Name = "B_BabyMode_Cancel";
        B_BabyMode_Cancel.Size = new Size(71, 25);
        B_BabyMode_Cancel.TabIndex = 174;
        B_BabyMode_Cancel.Text = "Cancel";
        B_BabyMode_Cancel.UseVisualStyleBackColor = true;
        B_BabyMode_Cancel.Click += B_BabyMode_Cancel_Click;
        // 
        // B_BabyMode_Go
        // 
        B_BabyMode_Go.Location = new Point(88, 90);
        B_BabyMode_Go.Name = "B_BabyMode_Go";
        B_BabyMode_Go.Size = new Size(118, 25);
        B_BabyMode_Go.TabIndex = 173;
        B_BabyMode_Go.Text = "Go!";
        B_BabyMode_Go.UseVisualStyleBackColor = true;
        B_BabyMode_Go.Click += B_BabyMode_Go_Click;
        // 
        // L_BabyMode
        // 
        L_BabyMode.AutoSize = true;
        L_BabyMode.Location = new Point(12, 43);
        L_BabyMode.Name = "L_BabyMode";
        L_BabyMode.Size = new Size(70, 15);
        L_BabyMode.TabIndex = 21;
        L_BabyMode.Text = "Baby Mode:";
        // 
        // TB_BabyMode
        // 
        TB_BabyMode.CharacterCasing = CharacterCasing.Upper;
        TB_BabyMode.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
        TB_BabyMode.Location = new Point(88, 41);
        TB_BabyMode.MaxLength = 10;
        TB_BabyMode.Name = "TB_BabyMode";
        TB_BabyMode.Size = new Size(118, 22);
        TB_BabyMode.TabIndex = 172;
        TB_BabyMode.TextAlign = HorizontalAlignment.Right;
        TB_BabyMode.KeyDown += Dec_HandlePaste;
        TB_BabyMode.KeyPress += AllowOnlyNumerical_KeyPress;
        // 
        // B_ConnectionSettings
        // 
        B_ConnectionSettings.Location = new Point(11, 11);
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
        DGV_Results.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        DGV_Results.Location = new Point(11, 332);
        DGV_Results.Name = "DGV_Results";
        DGV_Results.ReadOnly = true;
        DGV_Results.RowHeadersVisible = false;
        DGV_Results.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        DGV_Results.Size = new Size(1254, 306);
        DGV_Results.TabIndex = 129;
        DGV_Results.CellFormatting += DGV_Results_CellFormatting;
        // 
        // BS_SID
        // 
        BS_SID.DataSource = typeof(Core.Interfaces.SIDFrame);
        // 
        // B_ReadParty
        // 
        B_ReadParty.Location = new Point(601, 172);
        B_ReadParty.Name = "B_ReadParty";
        B_ReadParty.Size = new Size(147, 25);
        B_ReadParty.TabIndex = 130;
        B_ReadParty.Text = "Read Party";
        B_ReadParty.UseVisualStyleBackColor = true;
        B_ReadParty.Click += B_ReadParty_Click;
        // 
        // NUD_PartySlot
        // 
        NUD_PartySlot.Location = new Point(754, 173);
        NUD_PartySlot.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
        NUD_PartySlot.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
        NUD_PartySlot.Name = "NUD_PartySlot";
        NUD_PartySlot.Size = new Size(28, 23);
        NUD_PartySlot.TabIndex = 131;
        NUD_PartySlot.Value = new decimal(new int[] { 1, 0, 0, 0 });
        // 
        // BS_Static
        // 
        BS_Static.DataSource = typeof(Core.Interfaces.StaticFrame);
        // 
        // MainWindow
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1277, 650);
        Controls.Add(NUD_PartySlot);
        Controls.Add(B_ReadParty);
        Controls.Add(DGV_Results);
        Controls.Add(GB_Connection);
        Controls.Add(GB_SAVInfo);
        Controls.Add(GB_ConnectionSettings);
        Controls.Add(TC_Main);
        Controls.Add(TB_Wild);
        Controls.Add(B_ReadWildPokemon);
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
        TC_Main.ResumeLayout(false);
        TP_IDs.ResumeLayout(false);
        GB_SID.ResumeLayout(false);
        GB_SID.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_SID_Delay).EndInit();
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        TP_Seed.ResumeLayout(false);
        GB_SeedReset.ResumeLayout(false);
        GB_SeedReset.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_SS_NumSeeds).EndInit();
        TP_Static.ResumeLayout(false);
        TP_Static.PerformLayout();
        GB_Filters.ResumeLayout(false);
        GB_Filters.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Delay).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Spe_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Spe_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_SpD_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_SpD_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_SpA_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_SpA_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Def_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Def_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Atk_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_Atk_Min).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_HP_Max).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_Static_HP_Min).EndInit();
        GB_ConnectionSettings.ResumeLayout(false);
        GB_ConnectionSettings.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)NUD_BabyModeDelay).EndInit();
        ((System.ComponentModel.ISupportInitialize)DGV_Results).EndInit();
        ((System.ComponentModel.ISupportInitialize)BS_SID).EndInit();
        ((System.ComponentModel.ISupportInitialize)NUD_PartySlot).EndInit();
        ((System.ComponentModel.ISupportInitialize)BS_Static).EndInit();
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
    private Button B_ReadWildPokemon;
    private TextBox TB_Wild;
    private Label L_SIDPID;
    private TabControl TC_Main;
    private TabPage TP_IDs;
    private TabPage TP_Seed;
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
    private BindingSource BS_SID;
    private Button B_ReadIDs;
    private Button B_ReadTempTID;
    private Button B_ReadParty;
    private NumericUpDown NUD_PartySlot;
    private TabPage TP_Static;
    private GroupBox GB_SeedReset;
    private Label L_SS_TargetSeed;
    public TextBox TB_SS_TargetSeed;
    private RadioButton RB_SS_Distance;
    private RadioButton RB_SS_Number;
    private Button B_SS_FindMax;
    private NumericUpDown NUD_SS_NumSeeds;
    private Label L_SS_MaxAdv;
    public TextBox TB_SS_MaxAdv;
    private Label L_SS_NumSeeds;
    private Label L_SS_Adv;
    public TextBox TB_SS_Adv;
    private Button B_SS_CountSeeds;
    private Label L_SS_SeedCount;
    public TextBox TB_SS_SeedCount;
    private RadioButton RB_SS_SpecificSeed;
    private Button B_SS_SeedList;
    internal Label L_SS_SeedList;
    private Button B_ResetSeed;
    private Button B_CancelSeedReset;
    private GroupBox GB_Filters;
    public CheckBox CB_Static_Delay;
    private NumericUpDown NUD_Static_Delay;
    public CheckBox CB_RareEC;
    private CheckBox CB_Static_FiltersEnabled;
    private Label L_Static_Shiny;
    private ComboBox CB_Static_Shiny;
    private Button B_Static_Spe_Max;
    private Button B_Static_Spe_Min;
    private Label L_Static_Spe;
    private Label L_Static_SpeSpacer;
    private NumericUpDown NUD_Static_Spe_Max;
    private NumericUpDown NUD_Static_Spe_Min;
    private Button B_Static_SpD_Max;
    private Button B_Static_SpD_Min;
    private Label L_Static_SpD;
    private Label L_Static_SpDSpacer;
    private NumericUpDown NUD_Static_SpD_Max;
    private NumericUpDown NUD_Static_SpD_Min;
    private Button B_Static_SpA_Max;
    private Button B_Static_SpA_Min;
    private Label L_Static_SpA;
    private Label L_Static_SpASpacer;
    private NumericUpDown NUD_Static_SpA_Max;
    private NumericUpDown NUD_Static_SpA_Min;
    private Button B_Static_Def_Max;
    private Button B_Static_Def_Min;
    private Label L_Static_Def;
    private Label L_Static_DefSpacer;
    private NumericUpDown NUD_Static_Def_Max;
    private NumericUpDown NUD_Static_Def_Min;
    private Button B_Static_Atk_Max;
    private Button B_Static_Atk_Min;
    private Label L_Static_Atk;
    private Label L_Static_AtkSpacer;
    private NumericUpDown NUD_Static_Atk_Max;
    private NumericUpDown NUD_Static_Atk_Min;
    private Button B_Static_HP_Max;
    private Button B_Static_HP_Min;
    private Label L_Static_HP;
    private Label L_Static_HPSpacer;
    private NumericUpDown NUD_Static_HP_Max;
    private NumericUpDown NUD_Static_HP_Min;
    private Button B_Static_Search;
    private Label L_Static_Advances;
    private Label L_Static_Initial;
    public TextBox TB_Static_Advances;
    public TextBox TB_Static_Initial;
    public CheckBox CB_Static_RoamerBug;
    private Label L_Static_Species;
    public ComboBox CB_Static_Species;
    private Label L_Static_Nature;
    private ComboBox CB_Static_Nature;
    private Label L_Static_Method;
    public ComboBox CB_Static_Method;
    private BindingSource BS_Static;
    private Button B_BabyMode_Cancel;
    private Button B_BabyMode_Go;
    private Label L_BabyMode;
    public TextBox TB_BabyMode;
    public CheckBox CB_BabyModeDelay;
    private NumericUpDown NUD_BabyModeDelay;
}

