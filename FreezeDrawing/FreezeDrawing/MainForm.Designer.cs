namespace FreezeDrawing
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
            this.rbtn_SelectViews = new System.Windows.Forms.RadioButton();
            this.rbtn_ActiveView = new System.Windows.Forms.RadioButton();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Options = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Select = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbtn_SelectViews
            // 
            this.rbtn_SelectViews.AutoSize = true;
            this.rbtn_SelectViews.Location = new System.Drawing.Point(6, 42);
            this.rbtn_SelectViews.Name = "rbtn_SelectViews";
            this.rbtn_SelectViews.Size = new System.Drawing.Size(105, 17);
            this.rbtn_SelectViews.TabIndex = 1;
            this.rbtn_SelectViews.TabStop = true;
            this.rbtn_SelectViews.Text = "Selecionar vistas";
            this.rbtn_SelectViews.UseVisualStyleBackColor = true;
            this.rbtn_SelectViews.CheckedChanged += new System.EventHandler(this.rbtn_SelectViews_CheckedChanged);
            // 
            // rbtn_ActiveView
            // 
            this.rbtn_ActiveView.AutoSize = true;
            this.rbtn_ActiveView.Location = new System.Drawing.Point(6, 19);
            this.rbtn_ActiveView.Name = "rbtn_ActiveView";
            this.rbtn_ActiveView.Size = new System.Drawing.Size(74, 17);
            this.rbtn_ActiveView.TabIndex = 0;
            this.rbtn_ActiveView.TabStop = true;
            this.rbtn_ActiveView.Text = "Vista ativa";
            this.rbtn_ActiveView.UseVisualStyleBackColor = true;
            this.rbtn_ActiveView.CheckedChanged += new System.EventHandler(this.rbtn_ActiveView_CheckedChanged);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(148, 82);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(130, 23);
            this.btn_OK.TabIndex = 1;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Options
            // 
            this.btn_Options.Location = new System.Drawing.Point(12, 82);
            this.btn_Options.Name = "btn_Options";
            this.btn_Options.Size = new System.Drawing.Size(130, 23);
            this.btn_Options.TabIndex = 2;
            this.btn_Options.Text = "Opções";
            this.btn_Options.UseVisualStyleBackColor = true;
            this.btn_Options.Visible = false;
            this.btn_Options.Click += new System.EventHandler(this.btn_Options_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(285, 82);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(130, 23);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_Select);
            this.groupBox1.Controls.Add(this.rbtn_ActiveView);
            this.groupBox1.Controls.Add(this.rbtn_SelectViews);
            this.groupBox1.Location = new System.Drawing.Point(12, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 71);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Selecionar";
            // 
            // btn_Select
            // 
            this.btn_Select.Location = new System.Drawing.Point(322, 39);
            this.btn_Select.Name = "btn_Select";
            this.btn_Select.Size = new System.Drawing.Size(75, 23);
            this.btn_Select.TabIndex = 2;
            this.btn_Select.Text = "Selecionar...";
            this.btn_Select.UseVisualStyleBackColor = true;
            this.btn_Select.Click += new System.EventHandler(this.btn_Select_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 127);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Options);
            this.Controls.Add(this.btn_OK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Congelar vistas";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RadioButton rbtn_SelectViews;
        private System.Windows.Forms.RadioButton rbtn_ActiveView;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Options;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_Select;
    }
}