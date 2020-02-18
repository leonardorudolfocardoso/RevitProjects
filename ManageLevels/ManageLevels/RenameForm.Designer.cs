namespace ManageLevels
{
    partial class RenameForm
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
            this.lbl_CurrentLevelName = new System.Windows.Forms.Label();
            this.lbl_NewLevelName = new System.Windows.Forms.Label();
            this.tb_NewLevelName = new System.Windows.Forms.TextBox();
            this.btn_Rename = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.cbb_CurrentLevelName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lbl_CurrentLevelName
            // 
            this.lbl_CurrentLevelName.AutoSize = true;
            this.lbl_CurrentLevelName.Location = new System.Drawing.Point(14, 14);
            this.lbl_CurrentLevelName.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_CurrentLevelName.Name = "lbl_CurrentLevelName";
            this.lbl_CurrentLevelName.Size = new System.Drawing.Size(31, 13);
            this.lbl_CurrentLevelName.TabIndex = 0;
            this.lbl_CurrentLevelName.Text = "Atual";
            // 
            // lbl_NewLevelName
            // 
            this.lbl_NewLevelName.AutoSize = true;
            this.lbl_NewLevelName.Location = new System.Drawing.Point(14, 39);
            this.lbl_NewLevelName.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_NewLevelName.Name = "lbl_NewLevelName";
            this.lbl_NewLevelName.Size = new System.Drawing.Size(33, 13);
            this.lbl_NewLevelName.TabIndex = 1;
            this.lbl_NewLevelName.Text = "Novo";
            // 
            // tb_NewLevelName
            // 
            this.tb_NewLevelName.Location = new System.Drawing.Point(62, 36);
            this.tb_NewLevelName.Name = "tb_NewLevelName";
            this.tb_NewLevelName.Size = new System.Drawing.Size(126, 20);
            this.tb_NewLevelName.TabIndex = 3;
            // 
            // btn_Rename
            // 
            this.btn_Rename.Location = new System.Drawing.Point(17, 62);
            this.btn_Rename.Name = "btn_Rename";
            this.btn_Rename.Size = new System.Drawing.Size(82, 23);
            this.btn_Rename.TabIndex = 4;
            this.btn_Rename.Text = "Renomear";
            this.btn_Rename.UseVisualStyleBackColor = true;
            this.btn_Rename.Click += new System.EventHandler(this.btn_Rename_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(106, 62);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(82, 23);
            this.btn_Back.TabIndex = 5;
            this.btn_Back.Text = "Voltar";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // cbb_CurrentLevelName
            // 
            this.cbb_CurrentLevelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbb_CurrentLevelName.FormattingEnabled = true;
            this.cbb_CurrentLevelName.Location = new System.Drawing.Point(62, 11);
            this.cbb_CurrentLevelName.Name = "cbb_CurrentLevelName";
            this.cbb_CurrentLevelName.Size = new System.Drawing.Size(126, 21);
            this.cbb_CurrentLevelName.TabIndex = 6;
            this.cbb_CurrentLevelName.SelectedIndexChanged += new System.EventHandler(this.cbb_CurrentLevelName_SelectedIndexChanged);
            // 
            // RenameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 95);
            this.Controls.Add(this.cbb_CurrentLevelName);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Rename);
            this.Controls.Add(this.tb_NewLevelName);
            this.Controls.Add(this.lbl_NewLevelName);
            this.Controls.Add(this.lbl_CurrentLevelName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RenameForm";
            this.ShowIcon = false;
            this.Text = "Renomear nível";
            this.Load += new System.EventHandler(this.RenameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_CurrentLevelName;
        private System.Windows.Forms.Label lbl_NewLevelName;
        private System.Windows.Forms.TextBox tb_NewLevelName;
        private System.Windows.Forms.Button btn_Rename;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.ComboBox cbb_CurrentLevelName;
    }
}