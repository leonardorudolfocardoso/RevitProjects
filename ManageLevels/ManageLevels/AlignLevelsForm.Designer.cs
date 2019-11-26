namespace ManageLevels
{
    partial class AlignLevelsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlignLevelsForm));
            this.cbx_RevitLink = new System.Windows.Forms.ComboBox();
            this.cbx_DocLevel = new System.Windows.Forms.ComboBox();
            this.btn_Align = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.lbl_RevitLinks = new System.Windows.Forms.Label();
            this.lbl_DocLevels = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_RemoveAllLinkLevels = new System.Windows.Forms.Button();
            this.btn_AddAllLinkLevels = new System.Windows.Forms.Button();
            this.btn_RemoveLinkLevel = new System.Windows.Forms.Button();
            this.btn_MoveLinkLevelDown = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_MoveLinkLevelUp = new System.Windows.Forms.Button();
            this.cbx_LinkLevel = new System.Windows.Forms.ComboBox();
            this.btn_AddLinkLevel = new System.Windows.Forms.Button();
            this.lb_LinkLevels = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_CreateLevel = new System.Windows.Forms.Button();
            this.btn_RemoveAllDocLevels = new System.Windows.Forms.Button();
            this.btn_AddAllDocLevels = new System.Windows.Forms.Button();
            this.btn_AddDocLevel = new System.Windows.Forms.Button();
            this.btn_RemoveLevel = new System.Windows.Forms.Button();
            this.lb_DocLevels = new System.Windows.Forms.ListBox();
            this.btn_MoveLevelDown = new System.Windows.Forms.Button();
            this.btn_MoveLevelUp = new System.Windows.Forms.Button();
            this.lbl_Tip = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbx_RevitLink
            // 
            this.cbx_RevitLink.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_RevitLink.FormattingEnabled = true;
            this.cbx_RevitLink.Location = new System.Drawing.Point(72, 19);
            this.cbx_RevitLink.Name = "cbx_RevitLink";
            this.cbx_RevitLink.Size = new System.Drawing.Size(163, 21);
            this.cbx_RevitLink.Sorted = true;
            this.cbx_RevitLink.TabIndex = 0;
            this.cbx_RevitLink.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbx_DocLevel
            // 
            this.cbx_DocLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_DocLevel.FormattingEnabled = true;
            this.cbx_DocLevel.Location = new System.Drawing.Point(72, 47);
            this.cbx_DocLevel.Name = "cbx_DocLevel";
            this.cbx_DocLevel.Size = new System.Drawing.Size(163, 21);
            this.cbx_DocLevel.Sorted = true;
            this.cbx_DocLevel.TabIndex = 1;
            // 
            // btn_Align
            // 
            this.btn_Align.Location = new System.Drawing.Point(518, 302);
            this.btn_Align.Name = "btn_Align";
            this.btn_Align.Size = new System.Drawing.Size(75, 23);
            this.btn_Align.TabIndex = 2;
            this.btn_Align.Text = "Alinhar";
            this.btn_Align.UseVisualStyleBackColor = true;
            this.btn_Align.Click += new System.EventHandler(this.btn_Align_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(599, 302);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 3;
            this.btn_Back.Text = "Voltar";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // lbl_RevitLinks
            // 
            this.lbl_RevitLinks.AutoSize = true;
            this.lbl_RevitLinks.Location = new System.Drawing.Point(6, 22);
            this.lbl_RevitLinks.Name = "lbl_RevitLinks";
            this.lbl_RevitLinks.Size = new System.Drawing.Size(55, 13);
            this.lbl_RevitLinks.TabIndex = 4;
            this.lbl_RevitLinks.Text = "Revit Link";
            // 
            // lbl_DocLevels
            // 
            this.lbl_DocLevels.AutoSize = true;
            this.lbl_DocLevels.Location = new System.Drawing.Point(6, 51);
            this.lbl_DocLevels.Name = "lbl_DocLevels";
            this.lbl_DocLevels.Size = new System.Drawing.Size(38, 13);
            this.lbl_DocLevels.TabIndex = 5;
            this.lbl_DocLevels.Text = "Níveis";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_RemoveAllLinkLevels);
            this.groupBox1.Controls.Add(this.btn_AddAllLinkLevels);
            this.groupBox1.Controls.Add(this.btn_RemoveLinkLevel);
            this.groupBox1.Controls.Add(this.btn_MoveLinkLevelDown);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btn_MoveLinkLevelUp);
            this.groupBox1.Controls.Add(this.cbx_LinkLevel);
            this.groupBox1.Controls.Add(this.btn_AddLinkLevel);
            this.groupBox1.Controls.Add(this.lb_LinkLevels);
            this.groupBox1.Controls.Add(this.cbx_RevitLink);
            this.groupBox1.Controls.Add(this.lbl_RevitLinks);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(324, 284);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Níveis dos links";
            // 
            // btn_RemoveAllLinkLevels
            // 
            this.btn_RemoveAllLinkLevels.Location = new System.Drawing.Point(241, 158);
            this.btn_RemoveAllLinkLevels.Name = "btn_RemoveAllLinkLevels";
            this.btn_RemoveAllLinkLevels.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveAllLinkLevels.TabIndex = 14;
            this.btn_RemoveAllLinkLevels.Text = "Limpar";
            this.btn_RemoveAllLinkLevels.UseVisualStyleBackColor = true;
            this.btn_RemoveAllLinkLevels.Click += new System.EventHandler(this.btn_RemoveAllLinkLevels_Click);
            // 
            // btn_AddAllLinkLevels
            // 
            this.btn_AddAllLinkLevels.Location = new System.Drawing.Point(241, 75);
            this.btn_AddAllLinkLevels.Name = "btn_AddAllLinkLevels";
            this.btn_AddAllLinkLevels.Size = new System.Drawing.Size(75, 22);
            this.btn_AddAllLinkLevels.TabIndex = 13;
            this.btn_AddAllLinkLevels.Text = "Todos";
            this.btn_AddAllLinkLevels.UseVisualStyleBackColor = true;
            this.btn_AddAllLinkLevels.Click += new System.EventHandler(this.btn_AddAllLinkLevels_Click);
            // 
            // btn_RemoveLinkLevel
            // 
            this.btn_RemoveLinkLevel.Location = new System.Drawing.Point(241, 129);
            this.btn_RemoveLinkLevel.Name = "btn_RemoveLinkLevel";
            this.btn_RemoveLinkLevel.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveLinkLevel.TabIndex = 12;
            this.btn_RemoveLinkLevel.Text = "Remover";
            this.btn_RemoveLinkLevel.UseVisualStyleBackColor = true;
            this.btn_RemoveLinkLevel.Click += new System.EventHandler(this.btn_RemoveLinkLevel_Click);
            // 
            // btn_MoveLinkLevelDown
            // 
            this.btn_MoveLinkLevelDown.Location = new System.Drawing.Point(241, 251);
            this.btn_MoveLinkLevelDown.Name = "btn_MoveLinkLevelDown";
            this.btn_MoveLinkLevelDown.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveLinkLevelDown.TabIndex = 11;
            this.btn_MoveLinkLevelDown.Text = "Abaixo";
            this.btn_MoveLinkLevelDown.UseVisualStyleBackColor = true;
            this.btn_MoveLinkLevelDown.Click += new System.EventHandler(this.btn_MoveLinkLevelDown_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Níveis";
            // 
            // btn_MoveLinkLevelUp
            // 
            this.btn_MoveLinkLevelUp.Location = new System.Drawing.Point(241, 222);
            this.btn_MoveLinkLevelUp.Name = "btn_MoveLinkLevelUp";
            this.btn_MoveLinkLevelUp.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveLinkLevelUp.TabIndex = 7;
            this.btn_MoveLinkLevelUp.Text = "Acima";
            this.btn_MoveLinkLevelUp.UseVisualStyleBackColor = true;
            this.btn_MoveLinkLevelUp.Click += new System.EventHandler(this.btn_MoveLinkLevelUp_Click);
            // 
            // cbx_LinkLevel
            // 
            this.cbx_LinkLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_LinkLevel.FormattingEnabled = true;
            this.cbx_LinkLevel.Location = new System.Drawing.Point(72, 48);
            this.cbx_LinkLevel.Name = "cbx_LinkLevel";
            this.cbx_LinkLevel.Size = new System.Drawing.Size(163, 21);
            this.cbx_LinkLevel.Sorted = true;
            this.cbx_LinkLevel.TabIndex = 9;
            // 
            // btn_AddLinkLevel
            // 
            this.btn_AddLinkLevel.Location = new System.Drawing.Point(241, 48);
            this.btn_AddLinkLevel.Name = "btn_AddLinkLevel";
            this.btn_AddLinkLevel.Size = new System.Drawing.Size(75, 21);
            this.btn_AddLinkLevel.TabIndex = 6;
            this.btn_AddLinkLevel.Text = "Adicionar";
            this.btn_AddLinkLevel.UseVisualStyleBackColor = true;
            this.btn_AddLinkLevel.Click += new System.EventHandler(this.btn_AddLinkLevel_Click);
            // 
            // lb_LinkLevels
            // 
            this.lb_LinkLevels.FormattingEnabled = true;
            this.lb_LinkLevels.Location = new System.Drawing.Point(9, 75);
            this.lb_LinkLevels.Name = "lb_LinkLevels";
            this.lb_LinkLevels.Size = new System.Drawing.Size(226, 199);
            this.lb_LinkLevels.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_CreateLevel);
            this.groupBox2.Controls.Add(this.btn_RemoveAllDocLevels);
            this.groupBox2.Controls.Add(this.btn_AddAllDocLevels);
            this.groupBox2.Controls.Add(this.btn_AddDocLevel);
            this.groupBox2.Controls.Add(this.btn_RemoveLevel);
            this.groupBox2.Controls.Add(this.lb_DocLevels);
            this.groupBox2.Controls.Add(this.btn_MoveLevelDown);
            this.groupBox2.Controls.Add(this.lbl_DocLevels);
            this.groupBox2.Controls.Add(this.btn_MoveLevelUp);
            this.groupBox2.Controls.Add(this.cbx_DocLevel);
            this.groupBox2.Location = new System.Drawing.Point(358, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 284);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Níveis do documento";
            // 
            // btn_CreateLevel
            // 
            this.btn_CreateLevel.Location = new System.Drawing.Point(241, 18);
            this.btn_CreateLevel.Name = "btn_CreateLevel";
            this.btn_CreateLevel.Size = new System.Drawing.Size(75, 21);
            this.btn_CreateLevel.TabIndex = 17;
            this.btn_CreateLevel.Text = "Criar nível";
            this.btn_CreateLevel.UseVisualStyleBackColor = true;
            this.btn_CreateLevel.Click += new System.EventHandler(this.btn_CreateLevel_Click);
            // 
            // btn_RemoveAllDocLevels
            // 
            this.btn_RemoveAllDocLevels.Location = new System.Drawing.Point(241, 158);
            this.btn_RemoveAllDocLevels.Name = "btn_RemoveAllDocLevels";
            this.btn_RemoveAllDocLevels.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveAllDocLevels.TabIndex = 16;
            this.btn_RemoveAllDocLevels.Text = "Limpar";
            this.btn_RemoveAllDocLevels.UseVisualStyleBackColor = true;
            this.btn_RemoveAllDocLevels.Click += new System.EventHandler(this.btn_RemoveAllDocLevels_Click);
            // 
            // btn_AddAllDocLevels
            // 
            this.btn_AddAllDocLevels.Location = new System.Drawing.Point(241, 75);
            this.btn_AddAllDocLevels.Name = "btn_AddAllDocLevels";
            this.btn_AddAllDocLevels.Size = new System.Drawing.Size(75, 22);
            this.btn_AddAllDocLevels.TabIndex = 14;
            this.btn_AddAllDocLevels.Text = "Todos";
            this.btn_AddAllDocLevels.UseVisualStyleBackColor = true;
            this.btn_AddAllDocLevels.Click += new System.EventHandler(this.btn_AddAllDocLevels_Click);
            // 
            // btn_AddDocLevel
            // 
            this.btn_AddDocLevel.Location = new System.Drawing.Point(241, 47);
            this.btn_AddDocLevel.Name = "btn_AddDocLevel";
            this.btn_AddDocLevel.Size = new System.Drawing.Size(75, 21);
            this.btn_AddDocLevel.TabIndex = 13;
            this.btn_AddDocLevel.Text = "Adicionar";
            this.btn_AddDocLevel.UseVisualStyleBackColor = true;
            this.btn_AddDocLevel.Click += new System.EventHandler(this.btn_AddDocLevel_Click);
            // 
            // btn_RemoveLevel
            // 
            this.btn_RemoveLevel.Location = new System.Drawing.Point(241, 129);
            this.btn_RemoveLevel.Name = "btn_RemoveLevel";
            this.btn_RemoveLevel.Size = new System.Drawing.Size(75, 23);
            this.btn_RemoveLevel.TabIndex = 15;
            this.btn_RemoveLevel.Text = "Remover";
            this.btn_RemoveLevel.UseVisualStyleBackColor = true;
            this.btn_RemoveLevel.Click += new System.EventHandler(this.btn_RemoveLevel_Click);
            // 
            // lb_DocLevels
            // 
            this.lb_DocLevels.FormattingEnabled = true;
            this.lb_DocLevels.Location = new System.Drawing.Point(9, 75);
            this.lb_DocLevels.Name = "lb_DocLevels";
            this.lb_DocLevels.Size = new System.Drawing.Size(226, 199);
            this.lb_DocLevels.TabIndex = 6;
            // 
            // btn_MoveLevelDown
            // 
            this.btn_MoveLevelDown.Location = new System.Drawing.Point(241, 251);
            this.btn_MoveLevelDown.Name = "btn_MoveLevelDown";
            this.btn_MoveLevelDown.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveLevelDown.TabIndex = 14;
            this.btn_MoveLevelDown.Text = "Abaixo";
            this.btn_MoveLevelDown.UseVisualStyleBackColor = true;
            this.btn_MoveLevelDown.Click += new System.EventHandler(this.btn_MoveLevelDown_Click);
            // 
            // btn_MoveLevelUp
            // 
            this.btn_MoveLevelUp.Location = new System.Drawing.Point(241, 222);
            this.btn_MoveLevelUp.Name = "btn_MoveLevelUp";
            this.btn_MoveLevelUp.Size = new System.Drawing.Size(75, 23);
            this.btn_MoveLevelUp.TabIndex = 13;
            this.btn_MoveLevelUp.Text = "Acima";
            this.btn_MoveLevelUp.UseVisualStyleBackColor = true;
            this.btn_MoveLevelUp.Click += new System.EventHandler(this.btn_MoveLevelUp_Click);
            // 
            // lbl_Tip
            // 
            this.lbl_Tip.AutoSize = true;
            this.lbl_Tip.Location = new System.Drawing.Point(21, 309);
            this.lbl_Tip.Name = "lbl_Tip";
            this.lbl_Tip.Size = new System.Drawing.Size(353, 13);
            this.lbl_Tip.TabIndex = 8;
            this.lbl_Tip.Text = "Dica: os níveis serão alinhados em pares, conforme disposição nas listas.";
            // 
            // AlignLevelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(697, 334);
            this.Controls.Add(this.lbl_Tip);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Align);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AlignLevelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alinhar níveis";
            this.Load += new System.EventHandler(this.AlignLevelsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbx_RevitLink;
        private System.Windows.Forms.ComboBox cbx_DocLevel;
        private System.Windows.Forms.Button btn_Align;
        private System.Windows.Forms.Button btn_Back;
        private System.Windows.Forms.Label lbl_RevitLinks;
        private System.Windows.Forms.Label lbl_DocLevels;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_RemoveLinkLevel;
        private System.Windows.Forms.Button btn_MoveLinkLevelDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_MoveLinkLevelUp;
        private System.Windows.Forms.ComboBox cbx_LinkLevel;
        private System.Windows.Forms.Button btn_AddLinkLevel;
        private System.Windows.Forms.ListBox lb_LinkLevels;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_AddDocLevel;
        private System.Windows.Forms.Button btn_RemoveLevel;
        private System.Windows.Forms.ListBox lb_DocLevels;
        private System.Windows.Forms.Button btn_MoveLevelDown;
        private System.Windows.Forms.Button btn_MoveLevelUp;
        private System.Windows.Forms.Button btn_RemoveAllLinkLevels;
        private System.Windows.Forms.Button btn_AddAllLinkLevels;
        private System.Windows.Forms.Button btn_AddAllDocLevels;
        private System.Windows.Forms.Button btn_RemoveAllDocLevels;
        private System.Windows.Forms.Label lbl_Tip;
        private System.Windows.Forms.Button btn_CreateLevel;
    }
}