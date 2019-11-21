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
        public DWGExportOptions DWGExportOptions { get; set; }
        public DWGImportOptions DWGImportOptions { get; set; }
        public String Folder { get; set; }
        public String BaseName { get; set; }
        public OptionsForm(List<DWGExportOptions> dWGExportOptions)
        {
            this.DWGExportOptions = new DWGExportOptions();
            this.DWGImportOptions = new DWGImportOptions();
            InitializeComponent();
            foreach (DWGExportOptions dWGExportOption in dWGExportOptions)
            {
                cbbx_DWGExportOptions.Items.Add(dWGExportOption); 
            }
        }

        private void cbx_CopyDWGToFolder_CheckedChanged(object sender, EventArgs e)
        {
            tbx_BaseName.Enabled = !cbx_CopyDWGToFolder.Checked;
            tbx_Folder.Enabled = !cbx_CopyDWGToFolder.Checked;
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            DialogResult dialogResult = saveFileDialog.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:
                    List<String> splittedFileName = saveFileDialog.FileName.Split('\\').ToList();
                    this.Folder = String.Join("\\", splittedFileName.GetRange(0, splittedFileName.Count() - 2));
                    this.BaseName = splittedFileName.Last();
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
            this.DWGExportOptions = cbbx_DWGExportOptions.SelectedItem as DWGExportOptions;
        }
    }
}
