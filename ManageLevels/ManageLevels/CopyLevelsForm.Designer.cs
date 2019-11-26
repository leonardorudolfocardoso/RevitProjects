namespace ManageLevels
{
    partial class CopyLevelsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CopyLevelsForm));
            this.cbx_RevitLinks = new System.Windows.Forms.ComboBox();
            this.btn_RemoveLevels = new System.Windows.Forms.Button();
            this.btn_AddLevels = new System.Windows.Forms.Button();
            this.lbl_RevitLink = new System.Windows.Forms.Label();
            this.lb_RevitLinkLevels = new System.Windows.Forms.ListBox();
            this.lb_Levels = new System.Windows.Forms.ListBox();
            this.btn_Copy = new System.Windows.Forms.Button();
            this.btn_Back = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cbx_RevitLinks
            // 
            this.cbx_RevitLinks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbx_RevitLinks.FormattingEnabled = true;
            this.cbx_RevitLinks.Location = new System.Drawing.Point(72, 6);
            this.cbx_RevitLinks.Margin = new System.Windows.Forms.Padding(5);
            this.cbx_RevitLinks.Name = "cbx_RevitLinks";
            this.cbx_RevitLinks.Size = new System.Drawing.Size(297, 21);
            this.cbx_RevitLinks.Sorted = true;
            this.cbx_RevitLinks.TabIndex = 0;
            this.cbx_RevitLinks.SelectedIndexChanged += new System.EventHandler(this.cbx_RevitLinks_SelectedIndexChanged);
            // 
            // btn_RemoveLevels
            // 
            this.btn_RemoveLevels.BackgroundImage = global::ManageLevels.Properties.Resources.icons8_remover_dados_32;
            this.btn_RemoveLevels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_RemoveLevels.Location = new System.Drawing.Point(173, 130);
            this.btn_RemoveLevels.Margin = new System.Windows.Forms.Padding(6);
            this.btn_RemoveLevels.Name = "btn_RemoveLevels";
            this.btn_RemoveLevels.Size = new System.Drawing.Size(39, 41);
            this.btn_RemoveLevels.TabIndex = 3;
            this.btn_RemoveLevels.UseVisualStyleBackColor = true;
            this.btn_RemoveLevels.Click += new System.EventHandler(this.btn_RemoveLevels_Click);
            // 
            // btn_AddLevels
            // 
            this.btn_AddLevels.BackgroundImage = global::ManageLevels.Properties.Resources.icons8_à_direita_dentro_de_um_círculo_32;
            this.btn_AddLevels.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btn_AddLevels.Location = new System.Drawing.Point(173, 77);
            this.btn_AddLevels.Margin = new System.Windows.Forms.Padding(6);
            this.btn_AddLevels.Name = "btn_AddLevels";
            this.btn_AddLevels.Size = new System.Drawing.Size(39, 41);
            this.btn_AddLevels.TabIndex = 2;
            this.btn_AddLevels.UseVisualStyleBackColor = true;
            this.btn_AddLevels.Click += new System.EventHandler(this.btn_AddLevels_Click);
            // 
            // lbl_RevitLink
            // 
            this.lbl_RevitLink.AutoSize = true;
            this.lbl_RevitLink.Location = new System.Drawing.Point(12, 9);
            this.lbl_RevitLink.Name = "lbl_RevitLink";
            this.lbl_RevitLink.Size = new System.Drawing.Size(52, 13);
            this.lbl_RevitLink.TabIndex = 6;
            this.lbl_RevitLink.Text = "Link RVT";
            // 
            // lb_RevitLinkLevels
            // 
            this.lb_RevitLinkLevels.FormattingEnabled = true;
            this.lb_RevitLinkLevels.HorizontalScrollbar = true;
            this.lb_RevitLinkLevels.Location = new System.Drawing.Point(15, 35);
            this.lb_RevitLinkLevels.Name = "lb_RevitLinkLevels";
            this.lb_RevitLinkLevels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_RevitLinkLevels.Size = new System.Drawing.Size(149, 160);
            this.lb_RevitLinkLevels.Sorted = true;
            this.lb_RevitLinkLevels.TabIndex = 1;
            // 
            // lb_Levels
            // 
            this.lb_Levels.FormattingEnabled = true;
            this.lb_Levels.HorizontalScrollbar = true;
            this.lb_Levels.Location = new System.Drawing.Point(221, 35);
            this.lb_Levels.Name = "lb_Levels";
            this.lb_Levels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lb_Levels.Size = new System.Drawing.Size(148, 160);
            this.lb_Levels.Sorted = true;
            this.lb_Levels.TabIndex = 4;
            // 
            // btn_Copy
            // 
            this.btn_Copy.Location = new System.Drawing.Point(213, 201);
            this.btn_Copy.Name = "btn_Copy";
            this.btn_Copy.Size = new System.Drawing.Size(75, 23);
            this.btn_Copy.TabIndex = 5;
            this.btn_Copy.Text = "Copiar";
            this.btn_Copy.UseVisualStyleBackColor = true;
            this.btn_Copy.Click += new System.EventHandler(this.btn_Copy_Click);
            // 
            // btn_Back
            // 
            this.btn_Back.Location = new System.Drawing.Point(294, 201);
            this.btn_Back.Name = "btn_Back";
            this.btn_Back.Size = new System.Drawing.Size(75, 23);
            this.btn_Back.TabIndex = 6;
            this.btn_Back.Text = "Voltar";
            this.btn_Back.UseVisualStyleBackColor = true;
            this.btn_Back.Click += new System.EventHandler(this.btn_Back_Click);
            // 
            // CopyLevelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 234);
            this.Controls.Add(this.btn_Back);
            this.Controls.Add(this.btn_Copy);
            this.Controls.Add(this.lb_Levels);
            this.Controls.Add(this.lb_RevitLinkLevels);
            this.Controls.Add(this.lbl_RevitLink);
            this.Controls.Add(this.btn_RemoveLevels);
            this.Controls.Add(this.btn_AddLevels);
            this.Controls.Add(this.cbx_RevitLinks);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyLevelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Copiar níveis";
            this.Load += new System.EventHandler(this.CopyLevelsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbx_RevitLinks;
        private System.Windows.Forms.Button btn_AddLevels;
        private System.Windows.Forms.Button btn_RemoveLevels;
        private System.Windows.Forms.Label lbl_RevitLink;
        private System.Windows.Forms.ListBox lb_RevitLinkLevels;
        private System.Windows.Forms.ListBox lb_Levels;
        private System.Windows.Forms.Button btn_Copy;
        private System.Windows.Forms.Button btn_Back;
    }
}