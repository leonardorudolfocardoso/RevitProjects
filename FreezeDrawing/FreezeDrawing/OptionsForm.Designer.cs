namespace FreezeDrawing
{
    partial class OptionsForm
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
            this.gbx_ExportOption = new System.Windows.Forms.GroupBox();
            this.cbbx_DWGExportOptions = new System.Windows.Forms.ComboBox();
            this.gbx_ImportColors = new System.Windows.Forms.GroupBox();
            this.rbtn_BlackAndWhite = new System.Windows.Forms.RadioButton();
            this.rbtn_Preserve = new System.Windows.Forms.RadioButton();
            this.rbtn_Invert = new System.Windows.Forms.RadioButton();
            this.gbx_View = new System.Windows.Forms.GroupBox();
            this.cbx_DeleteSourceView = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cbx_CopyDWGToFolder = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_BaseName = new System.Windows.Forms.TextBox();
            this.tbx_Folder = new System.Windows.Forms.TextBox();
            this.btn_BrowseFolder = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.gbx_ExportOption.SuspendLayout();
            this.gbx_ImportColors.SuspendLayout();
            this.gbx_View.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbx_ExportOption
            // 
            this.gbx_ExportOption.Controls.Add(this.cbbx_DWGExportOptions);
            this.gbx_ExportOption.Location = new System.Drawing.Point(13, 13);
            this.gbx_ExportOption.Name = "gbx_ExportOption";
            this.gbx_ExportOption.Size = new System.Drawing.Size(200, 56);
            this.gbx_ExportOption.TabIndex = 0;
            this.gbx_ExportOption.TabStop = false;
            this.gbx_ExportOption.Text = "Exportação";
            // 
            // cbbx_DWGExportOptions
            // 
            this.cbbx_DWGExportOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbx_DWGExportOptions.FormattingEnabled = true;
            this.cbbx_DWGExportOptions.Location = new System.Drawing.Point(39, 19);
            this.cbbx_DWGExportOptions.Name = "cbbx_DWGExportOptions";
            this.cbbx_DWGExportOptions.Size = new System.Drawing.Size(121, 21);
            this.cbbx_DWGExportOptions.Sorted = true;
            this.cbbx_DWGExportOptions.TabIndex = 0;
            this.cbbx_DWGExportOptions.Text = "Configuração";
            this.cbbx_DWGExportOptions.SelectedIndexChanged += new System.EventHandler(this.cbbx_DWGExportOptions_SelectedIndexChanged);
            // 
            // gbx_ImportColors
            // 
            this.gbx_ImportColors.Controls.Add(this.rbtn_Invert);
            this.gbx_ImportColors.Controls.Add(this.rbtn_Preserve);
            this.gbx_ImportColors.Controls.Add(this.rbtn_BlackAndWhite);
            this.gbx_ImportColors.Location = new System.Drawing.Point(234, 13);
            this.gbx_ImportColors.Name = "gbx_ImportColors";
            this.gbx_ImportColors.Size = new System.Drawing.Size(200, 114);
            this.gbx_ImportColors.TabIndex = 1;
            this.gbx_ImportColors.TabStop = false;
            this.gbx_ImportColors.Text = "Cores de importação";
            // 
            // rbtn_BlackAndWhite
            // 
            this.rbtn_BlackAndWhite.AutoSize = true;
            this.rbtn_BlackAndWhite.Location = new System.Drawing.Point(6, 23);
            this.rbtn_BlackAndWhite.Name = "rbtn_BlackAndWhite";
            this.rbtn_BlackAndWhite.Size = new System.Drawing.Size(95, 17);
            this.rbtn_BlackAndWhite.TabIndex = 0;
            this.rbtn_BlackAndWhite.TabStop = true;
            this.rbtn_BlackAndWhite.Text = "Preto e branco";
            this.rbtn_BlackAndWhite.UseVisualStyleBackColor = true;
            this.rbtn_BlackAndWhite.CheckedChanged += new System.EventHandler(this.rbtn_BlackAndWhite_CheckedChanged);
            // 
            // rbtn_Preserve
            // 
            this.rbtn_Preserve.AutoSize = true;
            this.rbtn_Preserve.Location = new System.Drawing.Point(6, 53);
            this.rbtn_Preserve.Name = "rbtn_Preserve";
            this.rbtn_Preserve.Size = new System.Drawing.Size(70, 17);
            this.rbtn_Preserve.TabIndex = 1;
            this.rbtn_Preserve.TabStop = true;
            this.rbtn_Preserve.Text = "Preservar";
            this.rbtn_Preserve.UseVisualStyleBackColor = true;
            this.rbtn_Preserve.CheckedChanged += new System.EventHandler(this.rbtn_Preserve_CheckedChanged);
            // 
            // rbtn_Invert
            // 
            this.rbtn_Invert.AutoSize = true;
            this.rbtn_Invert.Location = new System.Drawing.Point(6, 82);
            this.rbtn_Invert.Name = "rbtn_Invert";
            this.rbtn_Invert.Size = new System.Drawing.Size(61, 17);
            this.rbtn_Invert.TabIndex = 2;
            this.rbtn_Invert.TabStop = true;
            this.rbtn_Invert.Text = "Inverter";
            this.rbtn_Invert.UseVisualStyleBackColor = true;
            this.rbtn_Invert.CheckedChanged += new System.EventHandler(this.rbtn_Invert_CheckedChanged);
            // 
            // gbx_View
            // 
            this.gbx_View.Controls.Add(this.cbx_DeleteSourceView);
            this.gbx_View.Location = new System.Drawing.Point(13, 76);
            this.gbx_View.Name = "gbx_View";
            this.gbx_View.Size = new System.Drawing.Size(200, 51);
            this.gbx_View.TabIndex = 2;
            this.gbx_View.TabStop = false;
            this.gbx_View.Text = "Vista";
            // 
            // cbx_DeleteSourceView
            // 
            this.cbx_DeleteSourceView.AutoSize = true;
            this.cbx_DeleteSourceView.Location = new System.Drawing.Point(6, 19);
            this.cbx_DeleteSourceView.Name = "cbx_DeleteSourceView";
            this.cbx_DeleteSourceView.Size = new System.Drawing.Size(134, 17);
            this.cbx_DeleteSourceView.TabIndex = 0;
            this.cbx_DeleteSourceView.Text = "Deletar vista de origem";
            this.cbx_DeleteSourceView.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_BrowseFolder);
            this.groupBox4.Controls.Add(this.tbx_Folder);
            this.groupBox4.Controls.Add(this.tbx_BaseName);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cbx_CopyDWGToFolder);
            this.groupBox4.Location = new System.Drawing.Point(13, 133);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(421, 96);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Arquivos";
            // 
            // cbx_CopyDWGToFolder
            // 
            this.cbx_CopyDWGToFolder.AutoSize = true;
            this.cbx_CopyDWGToFolder.Location = new System.Drawing.Point(9, 19);
            this.cbx_CopyDWGToFolder.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.cbx_CopyDWGToFolder.Name = "cbx_CopyDWGToFolder";
            this.cbx_CopyDWGToFolder.Size = new System.Drawing.Size(139, 17);
            this.cbx_CopyDWGToFolder.TabIndex = 0;
            this.cbx_CopyDWGToFolder.Text = "Copiar DWG para pasta";
            this.cbx_CopyDWGToFolder.UseVisualStyleBackColor = true;
            this.cbx_CopyDWGToFolder.CheckedChanged += new System.EventHandler(this.cbx_CopyDWGToFolder_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nome base";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 69);
            this.label2.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Pasta";
            // 
            // tbx_BaseName
            // 
            this.tbx_BaseName.Location = new System.Drawing.Point(83, 41);
            this.tbx_BaseName.Name = "tbx_BaseName";
            this.tbx_BaseName.Size = new System.Drawing.Size(294, 20);
            this.tbx_BaseName.TabIndex = 3;
            // 
            // tbx_Folder
            // 
            this.tbx_Folder.Location = new System.Drawing.Point(83, 67);
            this.tbx_Folder.Name = "tbx_Folder";
            this.tbx_Folder.Size = new System.Drawing.Size(294, 20);
            this.tbx_Folder.TabIndex = 4;
            // 
            // btn_BrowseFolder
            // 
            this.btn_BrowseFolder.Location = new System.Drawing.Point(383, 65);
            this.btn_BrowseFolder.Name = "btn_BrowseFolder";
            this.btn_BrowseFolder.Size = new System.Drawing.Size(32, 23);
            this.btn_BrowseFolder.TabIndex = 1;
            this.btn_BrowseFolder.Text = "...";
            this.btn_BrowseFolder.UseVisualStyleBackColor = true;
            this.btn_BrowseFolder.Click += new System.EventHandler(this.btn_BrowseFolder_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.Location = new System.Drawing.Point(278, 235);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(75, 23);
            this.btn_OK.TabIndex = 5;
            this.btn_OK.Text = "OK";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(359, 235);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 6;
            this.btn_Cancel.Text = "Cancelar";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // OptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 271);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.gbx_View);
            this.Controls.Add(this.gbx_ImportColors);
            this.Controls.Add(this.gbx_ExportOption);
            this.Name = "OptionsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Opções";
            this.gbx_ExportOption.ResumeLayout(false);
            this.gbx_ImportColors.ResumeLayout(false);
            this.gbx_ImportColors.PerformLayout();
            this.gbx_View.ResumeLayout(false);
            this.gbx_View.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbx_ExportOption;
        private System.Windows.Forms.ComboBox cbbx_DWGExportOptions;
        private System.Windows.Forms.GroupBox gbx_ImportColors;
        private System.Windows.Forms.RadioButton rbtn_Invert;
        private System.Windows.Forms.RadioButton rbtn_Preserve;
        private System.Windows.Forms.RadioButton rbtn_BlackAndWhite;
        private System.Windows.Forms.GroupBox gbx_View;
        private System.Windows.Forms.CheckBox cbx_DeleteSourceView;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tbx_Folder;
        private System.Windows.Forms.TextBox tbx_BaseName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbx_CopyDWGToFolder;
        private System.Windows.Forms.Button btn_BrowseFolder;
        private System.Windows.Forms.Button btn_OK;
        private System.Windows.Forms.Button btn_Cancel;
    }
}