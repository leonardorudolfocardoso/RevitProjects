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
    public partial class RenameForm : Form
    {
        private Document FormDoc { get; set; }
        private Level Level { get; set; }
        private Dictionary<String, Level> LevelNameDic { get; set; }

        public RenameForm(Document formDoc)
        {
            this.FormDoc = formDoc;
            this.LevelNameDic = new Dictionary<String, Level>();
            InitializeComponent();
        }

        private void RenameForm_Load(object sender, EventArgs e)
        {
            this.LevelsUpdate();
        }

        private void LevelsUpdate()
        {
            List<Level> levels = new FilteredElementCollector(this.FormDoc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .ToElements()
                .Cast<Level>()
                .OrderByDescending(level => level.Elevation)
                .ToList();

            this.LevelNameDic.Clear();
            this.cbb_CurrentLevelName.Items.Clear();

            foreach (Level level in levels)
            {
                this.LevelNameDic.Add(level.Name, level);
                this.cbb_CurrentLevelName.Items.Add(level.Name);
            }
            this.cbb_CurrentLevelName.SelectedIndex = 0;
        }

        private void btn_Rename_Click(object sender, EventArgs e)
        {
            using (Transaction tx = new Transaction(this.FormDoc, "Renomar nível"))
            {
                try
                {
                    tx.Start();
                    this.Level.Name = tb_NewLevelName.Text;
                    tx.Commit();
                    MessageBox.Show("Nível renomeado com sucesso.", "Renomear nível");
                }
                catch (Exception ex)
                {
                    tx.RollBack();
                    MessageBox.Show(ex.Message, "Erro");
                }
            }
            this.LevelsUpdate();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbb_CurrentLevelName_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Level = this.LevelNameDic[this.cbb_CurrentLevelName.SelectedItem.ToString()];
        }
    }
}
