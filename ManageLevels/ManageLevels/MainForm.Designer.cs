namespace ManageLevels
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btn_CreateLevel = new System.Windows.Forms.Button();
            this.btn_DeleteLevels = new System.Windows.Forms.Button();
            this.btn_CopyLevels = new System.Windows.Forms.Button();
            this.btn_AlignLevels = new System.Windows.Forms.Button();
            this.btn_Quit = new System.Windows.Forms.Button();
            this.btn_RenameLevel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_CreateLevel
            // 
            this.btn_CreateLevel.Location = new System.Drawing.Point(13, 13);
            this.btn_CreateLevel.Name = "btn_CreateLevel";
            this.btn_CreateLevel.Size = new System.Drawing.Size(204, 23);
            this.btn_CreateLevel.TabIndex = 0;
            this.btn_CreateLevel.Text = "Criar nível";
            this.btn_CreateLevel.UseVisualStyleBackColor = true;
            this.btn_CreateLevel.Click += new System.EventHandler(this.btn_CreateLevel_Click);
            // 
            // btn_DeleteLevels
            // 
            this.btn_DeleteLevels.Location = new System.Drawing.Point(13, 43);
            this.btn_DeleteLevels.Name = "btn_DeleteLevels";
            this.btn_DeleteLevels.Size = new System.Drawing.Size(204, 23);
            this.btn_DeleteLevels.TabIndex = 1;
            this.btn_DeleteLevels.Text = "Deletar níveis";
            this.btn_DeleteLevels.UseVisualStyleBackColor = true;
            this.btn_DeleteLevels.Click += new System.EventHandler(this.btn_DeleteLevels_Click);
            // 
            // btn_CopyLevels
            // 
            this.btn_CopyLevels.Location = new System.Drawing.Point(13, 101);
            this.btn_CopyLevels.Name = "btn_CopyLevels";
            this.btn_CopyLevels.Size = new System.Drawing.Size(204, 23);
            this.btn_CopyLevels.TabIndex = 2;
            this.btn_CopyLevels.Text = "Copiar níveis";
            this.btn_CopyLevels.UseVisualStyleBackColor = true;
            this.btn_CopyLevels.Click += new System.EventHandler(this.btn_CopyLevels_Click);
            // 
            // btn_AlignLevels
            // 
            this.btn_AlignLevels.Location = new System.Drawing.Point(13, 130);
            this.btn_AlignLevels.Name = "btn_AlignLevels";
            this.btn_AlignLevels.Size = new System.Drawing.Size(204, 23);
            this.btn_AlignLevels.TabIndex = 3;
            this.btn_AlignLevels.Text = "Alinhar níveis";
            this.btn_AlignLevels.UseVisualStyleBackColor = true;
            this.btn_AlignLevels.Click += new System.EventHandler(this.btn_AlignLevels_Click);
            // 
            // btn_Quit
            // 
            this.btn_Quit.Location = new System.Drawing.Point(12, 159);
            this.btn_Quit.Name = "btn_Quit";
            this.btn_Quit.Size = new System.Drawing.Size(204, 23);
            this.btn_Quit.TabIndex = 4;
            this.btn_Quit.Text = "Sair";
            this.btn_Quit.UseVisualStyleBackColor = true;
            this.btn_Quit.Click += new System.EventHandler(this.btn_Quit_Click);
            // 
            // btn_RenameLevel
            // 
            this.btn_RenameLevel.Location = new System.Drawing.Point(12, 72);
            this.btn_RenameLevel.Name = "btn_RenameLevel";
            this.btn_RenameLevel.Size = new System.Drawing.Size(204, 23);
            this.btn_RenameLevel.TabIndex = 5;
            this.btn_RenameLevel.Text = "Renomear Nível";
            this.btn_RenameLevel.UseVisualStyleBackColor = true;
            this.btn_RenameLevel.Click += new System.EventHandler(this.btn_RenameLevel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 194);
            this.Controls.Add(this.btn_RenameLevel);
            this.Controls.Add(this.btn_Quit);
            this.Controls.Add(this.btn_AlignLevels);
            this.Controls.Add(this.btn_CopyLevels);
            this.Controls.Add(this.btn_DeleteLevels);
            this.Controls.Add(this.btn_CreateLevel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerenciar níveis";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_CreateLevel;
        private System.Windows.Forms.Button btn_DeleteLevels;
        private System.Windows.Forms.Button btn_CopyLevels;
        private System.Windows.Forms.Button btn_AlignLevels;
        private System.Windows.Forms.Button btn_Quit;
        private System.Windows.Forms.Button btn_RenameLevel;
    }
}