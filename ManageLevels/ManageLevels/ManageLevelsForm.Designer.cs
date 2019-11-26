namespace ManageLevels
{
    partial class ManageLevelsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ManageLevelsForm));
            this.gb_ManageLevels = new System.Windows.Forms.GroupBox();
            this.btn_Back = new System.Windows.Forms.Button();
            this.btn_Apply = new System.Windows.Forms.Button();
            this.mtb_LevelElevation = new System.Windows.Forms.MaskedTextBox();
            this.lbl_ElevationUnit = new System.Windows.Forms.Label();
            this.tb_LevelName = new System.Windows.Forms.TextBox();
            this.lvl_LevelName = new System.Windows.Forms.Label();
            this.lbl_LevelElevation = new System.Windows.Forms.Label();
            this.cbx_Level = new System.Windows.Forms.ComboBox();
            this.lbl_level = new System.Windows.Forms.Label();
            this.gb_ManageLevels.SuspendLayout();
            this.SuspendLayout();
            // 
            // gb_ManageLevels
            // 
            this.gb_ManageLevels.Controls.Add(this.btn_Back);
            this.gb_ManageLevels.Controls.Add(this.btn_Apply);
            this.gb_ManageLevels.Controls.Add(this.mtb_LevelElevation);
            this.gb_ManageLevels.Controls.Add(this.lbl_ElevationUnit);
            this.gb_ManageLevels.Controls.Add(this.tb_LevelName);
            this.gb_ManageLevels.Controls.Add(this.lvl_LevelName);
            this.gb_ManageLevels.Controls.Add(this.lbl_LevelElevation);
            this.gb_ManageLevels.Controls.Add(this.cbx_Level);
            this.gb_ManageLevels.Controls.Add(this.lbl_level);
            this.gb_ManageLevels.Location = new System.Drawing.Point(13, 13);
            this.gb_ManageLevels.Name = "gb_ManageLevels";
            this.gb_ManageLevels.Size = new System.Drawing.Size(263, 125);
            this.gb_ManageLevels.TabIndex = 0;
            this.gb_ManageLevels.TabStop = false;
            this.gb_ManageLevels.Text = "Gerenciar níveis";
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(173, 90);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 10;
            this.btn_Back.Text = "Voltar";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // btn_Apply
            // 
            this.btn_Apply.Location = new System.Drawing.Point(92, 90);
            this.btn_Apply.Name = "btn_Apply";
            this.btn_Apply.Size = new System.Drawing.Size(75, 23);
            this.btn_Apply.TabIndex = 8;
            this.btn_Apply.Text = "Aplicar";
            this.btn_Apply.UseVisualStyleBackColor = true;
            this.btn_Apply.Click += new System.EventHandler(this.btn_Apply_Click);
            // 
            // mtb_LevelElevation
            // 
            this.mtb_LevelElevation.Location = new System.Drawing.Point(74, 64);
            this.mtb_LevelElevation.Mask = "9999999990";
            this.mtb_LevelElevation.Name = "mtb_LevelElevation";
            this.mtb_LevelElevation.PromptChar = ' ';
            this.mtb_LevelElevation.Size = new System.Drawing.Size(60, 20);
            this.mtb_LevelElevation.TabIndex = 7;
            this.mtb_LevelElevation.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.mtb_LevelElevation_MaskInputRejected);
            // 
            // lbl_ElevationUnit
            // 
            this.lbl_ElevationUnit.AutoSize = true;
            this.lbl_ElevationUnit.Location = new System.Drawing.Point(142, 67);
            this.lbl_ElevationUnit.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_ElevationUnit.Name = "lbl_ElevationUnit";
            this.lbl_ElevationUnit.Size = new System.Drawing.Size(29, 13);
            this.lbl_ElevationUnit.TabIndex = 6;
            this.lbl_ElevationUnit.Text = "(mm)";
            // 
            // tb_LevelName
            // 
            this.tb_LevelName.Location = new System.Drawing.Point(74, 41);
            this.tb_LevelName.Margin = new System.Windows.Forms.Padding(5);
            this.tb_LevelName.Name = "tb_LevelName";
            this.tb_LevelName.Size = new System.Drawing.Size(174, 20);
            this.tb_LevelName.TabIndex = 4;
            // 
            // lvl_LevelName
            // 
            this.lvl_LevelName.AutoSize = true;
            this.lvl_LevelName.Location = new System.Drawing.Point(8, 44);
            this.lvl_LevelName.Margin = new System.Windows.Forms.Padding(5);
            this.lvl_LevelName.Name = "lvl_LevelName";
            this.lvl_LevelName.Size = new System.Drawing.Size(35, 13);
            this.lvl_LevelName.TabIndex = 3;
            this.lvl_LevelName.Text = "Nome";
            // 
            // lbl_LevelElevation
            // 
            this.lbl_LevelElevation.AutoSize = true;
            this.lbl_LevelElevation.Location = new System.Drawing.Point(8, 67);
            this.lbl_LevelElevation.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_LevelElevation.Name = "lbl_LevelElevation";
            this.lbl_LevelElevation.Size = new System.Drawing.Size(52, 13);
            this.lbl_LevelElevation.TabIndex = 2;
            this.lbl_LevelElevation.Text = "Elevação";
            // 
            // cbx_Level
            // 
            this.cbx_Level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_Level.FormattingEnabled = true;
            this.cbx_Level.Location = new System.Drawing.Point(74, 18);
            this.cbx_Level.Margin = new System.Windows.Forms.Padding(5);
            this.cbx_Level.Name = "cbx_Level";
            this.cbx_Level.Size = new System.Drawing.Size(174, 21);
            this.cbx_Level.TabIndex = 1;
            this.cbx_Level.SelectedIndexChanged += new System.EventHandler(this.cbx_Level_SelectedIndexChanged);
            // 
            // lbl_level
            // 
            this.lbl_level.AutoSize = true;
            this.lbl_level.Location = new System.Drawing.Point(8, 21);
            this.lbl_level.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_level.Name = "lbl_level";
            this.lbl_level.Size = new System.Drawing.Size(33, 13);
            this.lbl_level.TabIndex = 0;
            this.lbl_level.Text = "Nível";
            // 
            // ManageLevelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 150);
            this.Controls.Add(this.gb_ManageLevels);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ManageLevelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Gerenciar níveis";
            this.Load += new System.EventHandler(this.ManageLevelsForm_Load);
            this.gb_ManageLevels.ResumeLayout(false);
            this.gb_ManageLevels.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gb_ManageLevels;
        private System.Windows.Forms.MaskedTextBox mtb_LevelElevation;
        private System.Windows.Forms.Label lbl_ElevationUnit;
        private System.Windows.Forms.TextBox tb_LevelName;
        private System.Windows.Forms.Label lvl_LevelName;
        private System.Windows.Forms.Label lbl_LevelElevation;
        private System.Windows.Forms.ComboBox cbx_Level;
        private System.Windows.Forms.Label lbl_level;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Button btn_Apply;
    }
}