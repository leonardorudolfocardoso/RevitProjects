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
    public partial class CopyLevelsForm : Form
    {
        public Document FormDoc { get; private set; }
        public Dictionary<String, RevitLinkInstance> RevitLinkNameDic { get; private set; }
        public Dictionary<String, Level> LevelNameDic { get; private set; }
        public CopyLevelsForm(Document formDoc)
        {
            this.FormDoc = formDoc;
            this.RevitLinkNameDic = new Dictionary<string, RevitLinkInstance>();
            this.LevelNameDic = new Dictionary<string, Level>();
            InitializeComponent();
        }

        private void CopyLevelsForm_Load(object sender, EventArgs e)
        {
            FilteredElementCollector revitLinksCollector = new FilteredElementCollector(this.FormDoc)
                .OfCategory(BuiltInCategory.OST_RvtLinks)
                .WhereElementIsNotElementType();

            // populating RevitLinkNameDic and cbx_RevitLinks 
            foreach (RevitLinkInstance revitLinkInstance in revitLinksCollector)
            {
                this.RevitLinkNameDic.Add(revitLinkInstance.Name, revitLinkInstance);
                this.cbx_RevitLinks.Items.Add(revitLinkInstance.Name);
            }
        }

        private void cbx_RevitLinks_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LevelNameDic.Clear();
            this.lb_RevitLinkLevels.Items.Clear();
            this.lb_Levels.Items.Clear();

            Document linkDoc = this.RevitLinkNameDic[this.cbx_RevitLinks.SelectedItem.ToString()]
                                   .GetLinkDocument();
            List<Level> revitLinkLevels = new FilteredElementCollector(linkDoc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .ToElements()
                .Cast<Level>()
                .OrderByDescending(x => x.Elevation)
                .ToList();

            // populating LevelNameDic lb_RevitLinkLevels
            foreach (Level level in revitLinkLevels)
            {
                this.LevelNameDic.Add(level.Name, level);
                this.lb_RevitLinkLevels.Items.Add(level.Name);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_AddLevels_Click(object sender, EventArgs e)
        {
            foreach (object levelName in this.lb_RevitLinkLevels.SelectedItems)
            {
                this.lb_Levels.Items.Add(levelName);
            }
            foreach (object levelName in this.lb_Levels.Items)
            {
                this.lb_RevitLinkLevels.Items.Remove(levelName);
            }
        }

        private void btn_RemoveLevels_Click(object sender, EventArgs e)
        {
            foreach (object levelName in this.lb_Levels.SelectedItems)
            {
                this.lb_RevitLinkLevels.Items.Add(levelName);
            }
            foreach (object levelName in this.lb_RevitLinkLevels.Items)
            {
                this.lb_Levels.Items.Remove(levelName);
            }
        }

        private void btn_Copy_Click(object sender, EventArgs e)
        {
            LevelFunctions.CopyLevels(this.FormDoc, 
                                      (from levelName in lb_Levels.Items.Cast<String>().ToList()
                                       select this.LevelNameDic[levelName]).ToList());
        }
    }
}
