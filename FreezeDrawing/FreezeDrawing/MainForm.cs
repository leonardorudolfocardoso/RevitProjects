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
using View = Autodesk.Revit.DB.View;

namespace FreezeDrawing
{
    public partial class MainForm : System.Windows.Forms.Form
    {

        public Document Doc { get; set; }
        public List<View> SelectedViews { get; set; }
        public OptionsForm OptionsForm { get; set; }

        public MainForm(Document doc)
        {
            this.Doc = doc;
            this.SelectedViews = new List<View>();
            this.OptionsForm = new OptionsForm(this.GetSetupNames());
            InitializeComponent();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            if (this.SelectedViews.Any())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Não foi selecionado nenhuma vista.", "Congelar vistas");
            }
        }

        private void rbtn_ActiveView_CheckedChanged(object sender, EventArgs e)
        {
            this.SelectedViews = new List<View>() { this.Doc.ActiveView };
        }

        private void rbtn_SelectViews_CheckedChanged(object sender, EventArgs e)
        {
            this.SelectedViews = new List<View>();
            btn_Select.Enabled = true;
        }

        private void btn_Select_Click(object sender, EventArgs e)
        {
            List<ViewType> viewTypes = new List<ViewType>();
            List<View> views = new List<View>();

            List<ViewType> allowedViewTypes = new List<ViewType>()
            {
                ViewType.FloorPlan,
                ViewType.CeilingPlan,
                ViewType.Elevation,
                ViewType.ThreeD,
                ViewType.Legend,
                ViewType.Schedule,
                ViewType.DrawingSheet,
                ViewType.Walkthrough,
                ViewType.Section,
                ViewType.Undefined,
                ViewType.AreaPlan,
                ViewType.EngineeringPlan,
                ViewType.Rendering,
                ViewType.PanelSchedule,
                ViewType.Internal,
                ViewType.DraftingView
            };

            FilteredElementCollector viewCollector = new FilteredElementCollector(this.Doc);
            viewCollector.OfClass(typeof(View));

            foreach (Element viewElement in viewCollector)
            {
                View view = viewElement as View;
                if (allowedViewTypes.Contains(view.ViewType))
                {
                    if (!viewTypes.Contains(view.ViewType))
                    {
                        viewTypes.Add(view.ViewType);

                    }
                    views.Add(view);
                }
            }
            SelectForm selectForm = new SelectForm(viewTypes, views);
            DialogResult dialogResult = selectForm.ShowDialog();

            switch (dialogResult)
            {
                case DialogResult.OK:
                    this.SelectedViews = selectForm.GetCheckedViews();
                    break;
                case DialogResult.Cancel:
                    this.SelectedViews = new List<View>() { this.Doc.ActiveView };
                    break;
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Options_Click(object sender, EventArgs e)
        {
            this.OptionsForm.ShowDialog();
        }

        private List<String> GetSetupNames()
        {
            // Get setup names
            List<string> setupNames = BaseExportOptions.GetPredefinedSetupNames(this.Doc).ToList();

            return setupNames;
        }
    }
}
