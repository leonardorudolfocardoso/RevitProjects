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

namespace ManageLevels
{
    public partial class MainForm : Form
    {
        public Document FormDoc { get; private set; }

        public MainForm(Document formDoc)
        {
            this.FormDoc = formDoc;
            InitializeComponent();
        }

        private void btn_CreateLevel_Click(object sender, EventArgs e)
        {
            CreateLevelForm createLevelForm = new CreateLevelForm(this.FormDoc);
            createLevelForm.ShowDialog();
        }

        private void btn_DeleteLevels_Click(object sender, EventArgs e)
        {
            DeleteLevelsForm deleteLevelsForm = new DeleteLevelsForm(this.FormDoc);
            deleteLevelsForm.ShowDialog();
        }

        private void btn_Quit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_CopyLevels_Click(object sender, EventArgs e)
        {
            CopyLevelsForm copyLevelsForm = new CopyLevelsForm(this.FormDoc);
            copyLevelsForm.ShowDialog();
        }

        private void btn_AlignLevels_Click(object sender, EventArgs e)
        {
            AlignLevelsForm alignLevelsForm = new AlignLevelsForm(this.FormDoc);
            alignLevelsForm.ShowDialog();
        }

        private void btn_ManageLevels_Click(object sender, EventArgs e)
        {
            ManageLevelsForm manageLevelsForm = new ManageLevelsForm(this.FormDoc);
            manageLevelsForm.ShowDialog();
        }

        private void btn_RenameLevel_Click(object sender, EventArgs e)
        {
            RenameForm renameForm = new RenameForm(this.FormDoc);
            renameForm.ShowDialog();
        }
    }
}
