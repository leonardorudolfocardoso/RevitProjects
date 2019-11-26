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
    public partial class ManageLevelsForm : Form
    {
        public Document FormDoc { get; private set; }
        public Dictionary<String, Level> LevelNamesDic { get; private set; }
        public ManageLevelsForm(Document formDoc)
        {
            this.FormDoc = formDoc;
            this.LevelNamesDic = new Dictionary<string, Level>();
            InitializeComponent();
        }

        private void mtb_LevelElevation_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            throw new System.ArgumentException("A elevação não está no formato requerido(numérico).");
        }

        private void ManageLevelsForm_Load(object sender, EventArgs e)
        {
            // collects the levels
            List<Level> levelsCollector = new FilteredElementCollector(this.FormDoc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType()
                .ToElements()
                .Cast<Level>()
                .OrderByDescending(x => x.Elevation)
                .ToList();

            // iterates the levels
            foreach (Level level in levelsCollector)
            {
                // adding level to LevelNamesDic and level combo box
                this.LevelNamesDic.Add(level.Name, level);
                this.cbx_Level.Items.Add(level.Name);
            }
        }

        private void cbx_Level_SelectedIndexChanged(object sender, EventArgs e)
        {
            Level selectedLevel = this.LevelNamesDic[cbx_Level.SelectedItem.ToString()];
            this.tb_LevelName.Text = selectedLevel.Name;
            this.mtb_LevelElevation.Text = (Constants._Feets2Meters*selectedLevel.Elevation).ToString();
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Apply_Click(object sender, EventArgs e)
        {
            if (cbx_Level.SelectedItem == null)
            {
                MessageBox.Show("Nenhum nível selecionado.");
            }
            else
            {
                // gets variables
                Level selectedLevel = this.LevelNamesDic[cbx_Level.SelectedItem.ToString()];
                String newLevelName = this.tb_LevelName.Text;
                double newLevelElevation = double.Parse(this.mtb_LevelElevation.Text);

                using (Transaction tx = new Transaction(this.FormDoc, "Mudar atributo de nível"))
                {
                    try
                    {
                        tx.Start();
                        selectedLevel.Name = newLevelName;
                        selectedLevel.Elevation = newLevelElevation;
                        tx.Commit();
                    }
                    catch (Exception ex)
                    {
                        tx.RollBack();
                        MessageBox.Show(ex.Message, "Erro");
                    }
                }
            }
        }
    }
}
