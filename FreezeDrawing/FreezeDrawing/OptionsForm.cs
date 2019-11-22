using Autodesk.Revit.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace FreezeDrawing
{
    public partial class OptionsForm : Form
    {
        public String DWGExportOptionsName { get; private set; }
        public DWGImportOptions DWGImportOptions { get; private set; }
        public String Folder { get; private set; }
        public String FolderToSave { get; private set; }
        public bool CopyDWGToFolder { get; private set; }
        public bool DeleteView { get; private set; }
        public OptionsForm(List<String> dWGExportOptionsNames)
        {
            this.DWGImportOptions = new DWGImportOptions();

            InitializeComponent();
            foreach (String dWGExportOptionsName in dWGExportOptionsNames)
            {
                cbbx_DWGExportOptions.Items.Add(dWGExportOptionsName); 
            }
            this.cbbx_DWGExportOptions.SelectedIndex = 0;
            this.cbx_DeleteSourceView.Checked = false;
            this.rbtn_Preserve.Checked = true;
            this.cbx_CopyDWGToFolder.Checked = false;
        }

        private void cbx_CopyDWGToFolder_CheckedChanged(object sender, EventArgs e)
        {
            tbx_FolderToSave.Enabled = cbx_CopyDWGToFolder.Checked;
            btn_BrowseFolder.Enabled = cbx_CopyDWGToFolder.Checked;

            this.CopyDWGToFolder = cbx_CopyDWGToFolder.Checked;
        }

        private void rbtn_BlackAndWhite_CheckedChanged(object sender, EventArgs e)
        {
            this.DWGImportOptions.ColorMode = ImportColorMode.BlackAndWhite;
        }

        private void rbtn_Invert_CheckedChanged(object sender, EventArgs e)
        {
            this.DWGImportOptions.ColorMode = ImportColorMode.Inverted;
        }

        private void rbtn_Preserve_CheckedChanged(object sender, EventArgs e)
        {
            this.DWGImportOptions.ColorMode = ImportColorMode.Preserved;
        }

        private void btn_BrowseFolder_Click(object sender, EventArgs e)
        {
            // SaveFileDialog form
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            DialogResult dialogResult = folderBrowserDialog.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:
                    tbx_FolderToSave.Text = folderBrowserDialog.SelectedPath;
                    break;
                case DialogResult.Cancel:
                    break;
            }

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cbbx_DWGExportOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DWGExportOptionsName = cbbx_DWGExportOptions.SelectedItem.ToString();
        }

        private void OptionsForm_Load(object sender, EventArgs e)
        {
        }

        private void cbx_DeleteSourceView_CheckedChanged(object sender, EventArgs e)
        {
            this.DeleteView = cbx_DeleteSourceView.Checked;
        }

        private void tbx_FolderToSave_TextChanged(object sender, EventArgs e)
        {
            this.FolderToSave = tbx_FolderToSave.Text;
        }
    }
}
