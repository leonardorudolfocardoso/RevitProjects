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
    public partial class DeleteLevelsForm : Form
    {
        public Document FormDoc { get; private set; }
        public Dictionary<String, Level> LevelNameDic { get; private set; }
        public DeleteLevelsForm(Document formDoc)
        {
            this.FormDoc = formDoc;
            this.LevelNameDic = new Dictionary<string, Level>();
            InitializeComponent();
        }

        private void DeleteLevelsForm_Load(object sender, EventArgs e)
        {
            // clearing LevelNameDic and clb_Levels.Items
            this.LevelNameDic.Clear();
            this.clb_Levels.Items.Clear();

            // collecting the levels
            FilteredElementCollector levelCollector = new FilteredElementCollector(this.FormDoc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType();

            // populating levelNameDic and clb_Levels
            foreach (Level level in levelCollector)
            {
                this.LevelNameDic.Add(level.Name, level);
                this.clb_Levels.Items.Add(level.Name);
            }
        }

        private void btn_CheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i< this.clb_Levels.Items.Count; i++)
            {
                clb_Levels.SetItemChecked(i, true);
            }
        }

        private void btn_CheckNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.clb_Levels.Items.Count; i++)
            {
                clb_Levels.SetItemChecked(i, false);
            }
        }

        private void btn_Toggle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.clb_Levels.Items.Count; i++)
            {
                clb_Levels.SetItemChecked(i, !clb_Levels.GetItemChecked(i));
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            List<Level> levelsToDelete = (from level in clb_Levels.CheckedItems.Cast<String>().ToList()
                                          select this.LevelNameDic[level]).ToList();

            // deleting levels
            LevelFunctions.DeleteLevels(this.FormDoc, levelsToDelete);


            // reloading form
            this.DeleteLevelsForm_Load(sender, e);
        }
    }
}
