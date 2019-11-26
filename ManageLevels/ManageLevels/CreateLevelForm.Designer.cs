namespace ManageLevels
{
    partial class CreateLevelForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateLevelForm));
            this.lbl_LevelName = new System.Windows.Forms.Label();
            this.lbl_LevelElevation = new System.Windows.Forms.Label();
            this.tbx_LevelName = new System.Windows.Forms.TextBox();
            this.tbx_LevelElevation = new System.Windows.Forms.TextBox();
            this.btn_cmd_CreateLevel = new System.Windows.Forms.Button();
            this.btn_cmd_Back = new System.Windows.Forms.Button();
            this.lvl_LevelElevationUnit = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbl_LevelName
            // 
            this.lbl_LevelName.AutoSize = true;
            this.lbl_LevelName.Location = new System.Drawing.Point(14, 14);
            this.lbl_LevelName.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_LevelName.Name = "lbl_LevelName";
            this.lbl_LevelName.Size = new System.Drawing.Size(35, 13);
            this.lbl_LevelName.TabIndex = 0;
            this.lbl_LevelName.Text = "Nome";
            // 
            // lbl_LevelElevation
            // 
            this.lbl_LevelElevation.AutoSize = true;
            this.lbl_LevelElevation.Location = new System.Drawing.Point(14, 37);
            this.lbl_LevelElevation.Margin = new System.Windows.Forms.Padding(5);
            this.lbl_LevelElevation.Name = "lbl_LevelElevation";
            this.lbl_LevelElevation.Size = new System.Drawing.Size(52, 13);
            this.lbl_LevelElevation.TabIndex = 1;
            this.lbl_LevelElevation.Text = "Elevação";
            // 
            // tbx_LevelName
            // 
            this.tbx_LevelName.Location = new System.Drawing.Point(74, 11);
            this.tbx_LevelName.Name = "tbx_LevelName";
            this.tbx_LevelName.Size = new System.Drawing.Size(151, 20);
            this.tbx_LevelName.TabIndex = 3;
            // 
            // tbx_LevelElevation
            // 
            this.tbx_LevelElevation.Location = new System.Drawing.Point(74, 34);
            this.tbx_LevelElevation.Name = "tbx_LevelElevation";
            this.tbx_LevelElevation.Size = new System.Drawing.Size(57, 20);
            this.tbx_LevelElevation.TabIndex = 4;
            // 
            // btn_cmd_CreateLevel
            // 
            this.btn_cmd_CreateLevel.Location = new System.Drawing.Point(17, 61);
            this.btn_cmd_CreateLevel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cmd_CreateLevel.Name = "btn_cmd_CreateLevel";
            this.btn_cmd_CreateLevel.Size = new System.Drawing.Size(208, 23);
            this.btn_cmd_CreateLevel.TabIndex = 5;
            this.btn_cmd_CreateLevel.Text = "Criar nível";
            this.btn_cmd_CreateLevel.UseVisualStyleBackColor = true;
            this.btn_cmd_CreateLevel.Click += new System.EventHandler(this.btn_cmd_CreateLevel_Click);
            // 
            // btn_cmd_Back
            // 
            this.btn_cmd_Back.Location = new System.Drawing.Point(17, 88);
            this.btn_cmd_Back.Margin = new System.Windows.Forms.Padding(2);
            this.btn_cmd_Back.Name = "btn_cmd_Back";
            this.btn_cmd_Back.Size = new System.Drawing.Size(208, 23);
            this.btn_cmd_Back.TabIndex = 6;
            this.btn_cmd_Back.Text = "Voltar";
            this.btn_cmd_Back.UseVisualStyleBackColor = true;
            this.btn_cmd_Back.Click += new System.EventHandler(this.btn_cmd_Back_Click);
            // 
            // lvl_LevelElevationUnit
            // 
            this.lvl_LevelElevationUnit.AutoSize = true;
            this.lvl_LevelElevationUnit.Location = new System.Drawing.Point(139, 39);
            this.lvl_LevelElevationUnit.Margin = new System.Windows.Forms.Padding(5);
            this.lvl_LevelElevationUnit.Name = "lvl_LevelElevationUnit";
            this.lvl_LevelElevationUnit.Size = new System.Drawing.Size(29, 13);
            this.lvl_LevelElevationUnit.TabIndex = 7;
            this.lvl_LevelElevationUnit.Text = "(mm)";
            // 
            // CreateLevelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 122);
            this.Controls.Add(this.lvl_LevelElevationUnit);
            this.Controls.Add(this.btn_cmd_Back);
            this.Controls.Add(this.btn_cmd_CreateLevel);
            this.Controls.Add(this.tbx_LevelElevation);
            this.Controls.Add(this.tbx_LevelName);
            this.Controls.Add(this.lbl_LevelElevation);
            this.Controls.Add(this.lbl_LevelName);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateLevelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Criar nível";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_LevelName;
        private System.Windows.Forms.Label lbl_LevelElevation;
        private System.Windows.Forms.TextBox tbx_LevelName;
        private System.Windows.Forms.TextBox tbx_LevelElevation;
        private System.Windows.Forms.Button btn_cmd_CreateLevel;
        private System.Windows.Forms.Button btn_cmd_Back;
        private System.Windows.Forms.Label lvl_LevelElevationUnit;
    }
}