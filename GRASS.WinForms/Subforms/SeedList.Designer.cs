namespace GRASS.WinForms.Subforms
{
    partial class SeedList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SeedList));
            LB_Seeds = new ListBox();
            B_Add = new Button();
            L_ID = new Label();
            TB_Seed = new TextBox();
            B_Remove = new Button();
            SuspendLayout();
            // 
            // LB_Seeds
            // 
            LB_Seeds.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            LB_Seeds.FormattingEnabled = true;
            LB_Seeds.Location = new Point(8, 8);
            LB_Seeds.Name = "LB_Seeds";
            LB_Seeds.Size = new Size(120, 139);
            LB_Seeds.TabIndex = 3;
            LB_Seeds.SelectedIndexChanged += LB_Seeds_SelectedIndexChanged;
            // 
            // B_Add
            // 
            B_Add.Location = new Point(134, 32);
            B_Add.Name = "B_Add";
            B_Add.Size = new Size(75, 25);
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
            L_ID.Size = new Size(35, 15);
            L_ID.TabIndex = 2;
            L_ID.Text = "Seed:";
            // 
            // TB_Seed
            // 
            TB_Seed.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TB_Seed.Location = new Point(174, 8);
            TB_Seed.MaxLength = 4;
            TB_Seed.Name = "TB_Seed";
            TB_Seed.Size = new Size(35, 22);
            TB_Seed.TabIndex = 0;
            TB_Seed.Text = "ABCD";
            TB_Seed.KeyPress += TB_Seed_KeyPress;
            // 
            // B_Remove
            // 
            B_Remove.Location = new Point(134, 59);
            B_Remove.Name = "B_Remove";
            B_Remove.Size = new Size(75, 25);
            B_Remove.TabIndex = 2;
            B_Remove.Text = "Remove";
            B_Remove.UseVisualStyleBackColor = true;
            B_Remove.Click += B_Remove_Click;
            // 
            // SeedList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(215, 153);
            Controls.Add(B_Remove);
            Controls.Add(TB_Seed);
            Controls.Add(L_ID);
            Controls.Add(B_Add);
            Controls.Add(LB_Seeds);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "SeedList";
            Text = "Seed List";
            FormClosing += SeedList_FormClosing;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListBox LB_Seeds;
        private Button B_Add;
        private Label L_ID;
        private TextBox TB_Seed;
        private Button B_Remove;
    }
}
