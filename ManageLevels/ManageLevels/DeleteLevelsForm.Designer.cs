namespace ManageLevels
{
    partial class DeleteLevelsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeleteLevelsForm));
            this.clb_Levels = new System.Windows.Forms.CheckedListBox();
            this.btn_CheckAll = new System.Windows.Forms.Button();
            this.btn_CheckNone = new System.Windows.Forms.Button();
            this.btn_Toggle = new System.Windows.Forms.Button();
            this.btn_Select = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // clb_Levels
            // 
            this.clb_Levels.CheckOnClick = true;
            this.clb_Levels.FormattingEnabled = true;
            this.clb_Levels.HorizontalScrollbar = true;
            this.clb_Levels.Location = new System.Drawing.Point(12, 12);
            this.clb_Levels.Name = "clb_Levels";
            this.clb_Levels.Size = new System.Drawing.Size(238, 169);
            this.clb_Levels.Sorted = true;
            this.clb_Levels.TabIndex = 0;
            // 
            // btn_CheckAll
            // 
            this.btn_CheckAll.Location = new System.Drawing.Point(13, 188);
            this.btn_CheckAll.Name = "btn_CheckAll";
            this.btn_CheckAll.Size = new System.Drawing.Size(75, 23);
            this.btn_CheckAll.TabIndex = 1;
            this.btn_CheckAll.Text = "Todos";
            this.btn_CheckAll.UseVisualStyleBackColor = true;
            this.btn_CheckAll.Click += new System.EventHandler(this.btn_CheckAll_Click);
            // 
            // btn_CheckNone
            // 
            this.btn_CheckNone.Location = new System.Drawing.Point(94, 188);
            this.btn_CheckNone.Name = "btn_CheckNone";
            this.btn_CheckNone.Size = new System.Drawing.Size(75, 23);
            this.btn_CheckNone.TabIndex = 2;
            this.btn_CheckNone.Text = "Nenhum";
            this.btn_CheckNone.UseVisualStyleBackColor = true;
            this.btn_CheckNone.Click += new System.EventHandler(this.btn_CheckNone_Click);
            // 
            // btn_Toggle
            // 
            this.btn_Toggle.Location = new System.Drawing.Point(175, 188);
            this.btn_Toggle.Name = "btn_Toggle";
            this.btn_Toggle.Size = new System.Drawing.Size(75, 23);
            this.btn_Toggle.TabIndex = 3;
            this.btn_Toggle.Text = "Inverter";
            this.btn_Toggle.UseVisualStyleBackColor = true;
            this.btn_Toggle.Click += new System.EventHandler(this.btn_Toggle_Click);
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(94, 217);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 4;
            this.btn_Select.Text = "Selecionar";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(175, 217);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 5;
            this.btn_Cancel.Text = "Voltar";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // DeleteLevelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 250);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Select);
            this.Controls.Add(this.btn_Toggle);
            this.Controls.Add(this.btn_CheckNone);
            this.Controls.Add(this.btn_CheckAll);
            this.Controls.Add(this.clb_Levels);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeleteLevelsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Deletar níveis";
            this.Load += new System.EventHandler(this.DeleteLevelsForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox clb_Levels;
        private System.Windows.Forms.Button btn_CheckAll;
        private System.Windows.Forms.Button btn_CheckNone;
        private System.Windows.Forms.Button btn_Toggle;
        private System.Windows.Forms.Button btn_Select;
        private System.Windows.Forms.Button btn_Cancel;
    }
}