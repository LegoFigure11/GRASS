namespace GRASS.WinForms.Subforms
{
    partial class TIDList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TIDList));
            LB_IDs = new ListBox();
            B_Add = new Button();
            L_ID = new Label();
            TB_ID = new TextBox();
            B_Remove = new Button();
            B_Autofill = new Button();
            CB_Palindrome = new CheckBox();
            CB_CombineMode = new ComboBox();
            L_CombineMode = new Label();
            CB_OneNumber = new CheckBox();
            CB_TwoNumbers = new CheckBox();
            CB_Sequential = new CheckBox();
            CB_LessThan = new CheckBox();
            CB_GreaterThan = new CheckBox();
            NUD_LessThan = new NumericUpDown();
            NUD_GreaterThan = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)NUD_LessThan).BeginInit();
            ((System.ComponentModel.ISupportInitialize)NUD_GreaterThan).BeginInit();
            SuspendLayout();
            // 
            // LB_IDs
            // 
            LB_IDs.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            LB_IDs.FormattingEnabled = true;
            LB_IDs.Location = new Point(8, 8);
            LB_IDs.Name = "LB_IDs";
            LB_IDs.Size = new Size(120, 319);
            LB_IDs.TabIndex = 3;
            LB_IDs.SelectedIndexChanged += LB_IDs_SelectedIndexChanged;
            // 
            // B_Add
            // 
            B_Add.Location = new Point(134, 32);
            B_Add.Name = "B_Add";
            B_Add.Size = new Size(149, 25);
            B_Add.TabIndex = 1;
            B_Add.Text = "Add";
            B_Add.UseVisualStyleBackColor = true;
            B_Add.Click += B_Add_Click;
            // 
            // L_ID
            // 
            L_ID.AutoSize = true;
            L_ID.Location = new Point(134, 11);
            L_ID.Name = "L_ID";
            L_ID.Size = new Size(59, 15);
            L_ID.TabIndex = 2;
            L_ID.Text = "Trainer ID:";
            // 
            // TB_ID
            // 
            TB_ID.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TB_ID.Location = new Point(242, 9);
            TB_ID.MaxLength = 5;
            TB_ID.Name = "TB_ID";
            TB_ID.Size = new Size(41, 22);
            TB_ID.TabIndex = 0;
            TB_ID.Text = "12345";
            TB_ID.KeyPress += TB_ID_KeyPress;
            // 
            // B_Remove
            // 
            B_Remove.Location = new Point(134, 59);
            B_Remove.Name = "B_Remove";
            B_Remove.Size = new Size(149, 25);
            B_Remove.TabIndex = 2;
            B_Remove.Text = "Remove";
            B_Remove.UseVisualStyleBackColor = true;
            B_Remove.Click += B_Remove_Click;
            // 
            // B_Autofill
            // 
            B_Autofill.Location = new Point(134, 122);
            B_Autofill.Name = "B_Autofill";
            B_Autofill.Size = new Size(149, 25);
            B_Autofill.TabIndex = 4;
            B_Autofill.Text = "Autofill";
            B_Autofill.UseVisualStyleBackColor = true;
            B_Autofill.Click += B_Autofill_Click;
            // 
            // CB_Palindrome
            // 
            CB_Palindrome.AutoSize = true;
            CB_Palindrome.Location = new Point(134, 177);
            CB_Palindrome.Name = "CB_Palindrome";
            CB_Palindrome.Size = new Size(87, 19);
            CB_Palindrome.TabIndex = 5;
            CB_Palindrome.Text = "Palindrome";
            CB_Palindrome.UseVisualStyleBackColor = true;
            // 
            // CB_CombineMode
            // 
            CB_CombineMode.FormattingEnabled = true;
            CB_CombineMode.Items.AddRange(new object[] { "Any (OR)", "All (AND)" });
            CB_CombineMode.Location = new Point(194, 149);
            CB_CombineMode.Name = "CB_CombineMode";
            CB_CombineMode.Size = new Size(89, 23);
            CB_CombineMode.TabIndex = 6;
            // 
            // L_CombineMode
            // 
            L_CombineMode.AutoSize = true;
            L_CombineMode.Location = new Point(134, 152);
            L_CombineMode.Name = "L_CombineMode";
            L_CombineMode.Size = new Size(44, 15);
            L_CombineMode.TabIndex = 7;
            L_CombineMode.Text = "Satisfy:";
            // 
            // CB_OneNumber
            // 
            CB_OneNumber.AutoSize = true;
            CB_OneNumber.Location = new Point(134, 202);
            CB_OneNumber.Name = "CB_OneNumber";
            CB_OneNumber.Size = new Size(124, 19);
            CB_OneNumber.TabIndex = 8;
            CB_OneNumber.Text = "Made of 1 number";
            CB_OneNumber.UseVisualStyleBackColor = true;
            // 
            // CB_TwoNumbers
            // 
            CB_TwoNumbers.AutoSize = true;
            CB_TwoNumbers.Location = new Point(134, 227);
            CB_TwoNumbers.Name = "CB_TwoNumbers";
            CB_TwoNumbers.Size = new Size(129, 19);
            CB_TwoNumbers.TabIndex = 9;
            CB_TwoNumbers.Text = "Made of 2 numbers";
            CB_TwoNumbers.UseVisualStyleBackColor = true;
            // 
            // CB_Sequential
            // 
            CB_Sequential.AutoSize = true;
            CB_Sequential.Location = new Point(134, 252);
            CB_Sequential.Name = "CB_Sequential";
            CB_Sequential.Size = new Size(113, 19);
            CB_Sequential.TabIndex = 10;
            CB_Sequential.Text = "Sequential digits";
            CB_Sequential.UseVisualStyleBackColor = true;
            // 
            // CB_LessThan
            // 
            CB_LessThan.AutoSize = true;
            CB_LessThan.Location = new Point(134, 277);
            CB_LessThan.Name = "CB_LessThan";
            CB_LessThan.Size = new Size(75, 19);
            CB_LessThan.TabIndex = 11;
            CB_LessThan.Text = "Less than";
            CB_LessThan.UseVisualStyleBackColor = true;
            CB_LessThan.CheckedChanged += CB_LessThan_CheckedChanged;
            // 
            // CB_GreaterThan
            // 
            CB_GreaterThan.AutoSize = true;
            CB_GreaterThan.Location = new Point(134, 302);
            CB_GreaterThan.Name = "CB_GreaterThan";
            CB_GreaterThan.Size = new Size(91, 19);
            CB_GreaterThan.TabIndex = 12;
            CB_GreaterThan.Text = "Greater than";
            CB_GreaterThan.UseVisualStyleBackColor = true;
            CB_GreaterThan.CheckedChanged += CB_GreaterThan_CheckedChanged;
            // 
            // NUD_LessThan
            // 
            NUD_LessThan.Enabled = false;
            NUD_LessThan.Location = new Point(231, 276);
            NUD_LessThan.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NUD_LessThan.Name = "NUD_LessThan";
            NUD_LessThan.Size = new Size(52, 23);
            NUD_LessThan.TabIndex = 13;
            NUD_LessThan.TextAlign = HorizontalAlignment.Right;
            NUD_LessThan.Value = new decimal(new int[] { 100, 0, 0, 0 });
            // 
            // NUD_GreaterThan
            // 
            NUD_GreaterThan.Enabled = false;
            NUD_GreaterThan.Location = new Point(231, 301);
            NUD_GreaterThan.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            NUD_GreaterThan.Name = "NUD_GreaterThan";
            NUD_GreaterThan.Size = new Size(52, 23);
            NUD_GreaterThan.TabIndex = 14;
            NUD_GreaterThan.TextAlign = HorizontalAlignment.Right;
            NUD_GreaterThan.Value = new decimal(new int[] { 65435, 0, 0, 0 });
            // 
            // TIDList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(286, 342);
            Controls.Add(NUD_GreaterThan);
            Controls.Add(NUD_LessThan);
            Controls.Add(CB_GreaterThan);
            Controls.Add(CB_LessThan);
            Controls.Add(CB_Sequential);
            Controls.Add(CB_TwoNumbers);
            Controls.Add(CB_OneNumber);
            Controls.Add(L_CombineMode);
            Controls.Add(CB_CombineMode);
            Controls.Add(CB_Palindrome);
            Controls.Add(B_Autofill);
            Controls.Add(B_Remove);
            Controls.Add(TB_ID);
            Controls.Add(L_ID);
            Controls.Add(B_Add);
            Controls.Add(LB_IDs);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "TIDList";
            Text = "TID List";
            FormClosing += IDList_FormClosing;
            ((System.ComponentModel.ISupportInitialize)NUD_LessThan).EndInit();
            ((System.ComponentModel.ISupportInitialize)NUD_GreaterThan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox LB_IDs;
        private Button B_Add;
        private Label L_ID;
        private TextBox TB_ID;
        private Button B_Remove;
        private Button B_Autofill;
        private CheckBox CB_Palindrome;
        private ComboBox CB_CombineMode;
        private Label L_CombineMode;
        private CheckBox CB_OneNumber;
        private CheckBox CB_TwoNumbers;
        private CheckBox CB_Sequential;
        private CheckBox CB_LessThan;
        private CheckBox CB_GreaterThan;
        private NumericUpDown NUD_LessThan;
        private NumericUpDown NUD_GreaterThan;
    }
}
