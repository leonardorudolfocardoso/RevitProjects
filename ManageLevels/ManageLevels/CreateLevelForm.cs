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
    public partial class CreateLevelForm : Form
    {
        #region Properties
        public Document FormDoc { get; private set; }
        #endregion

        public CreateLevelForm(Document doc)
        {
            this.FormDoc = doc;
            InitializeComponent();
            this.tbx_LevelElevation.Text = "0";
        }

        private void btn_cmd_CreateLevel_Click(object sender, EventArgs e)
        {
            try
            {
                String levelName = this.tbx_LevelName.Text;
                double levelElevation = Constants._Meters2Feets * double.Parse(this.tbx_LevelElevation.Text) * 1e-3;
                LevelFunctions.CreateLevel(this.FormDoc, levelName, levelElevation);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro");
            }
        }

        private void btn_cmd_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
