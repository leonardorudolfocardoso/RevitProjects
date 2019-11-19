using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Revit.DB;


namespace FreezeDrawing
{
    public partial class SelectForm : System.Windows.Forms.Form
    {
        List<ViewType> _types;
        List<Autodesk.Revit.DB.View> _instances;
        Dictionary<string, Autodesk.Revit.DB.View> _viewInstancesDic;
        public List<ViewType> viewTypes { get => _types; set => _types = value; }
        public List<Autodesk.Revit.DB.View> viewInstances { get => _instances; set => _instances = value; }
        Dictionary<string, Autodesk.Revit.DB.View> viewInstancesDic { get => _viewInstancesDic; set => _viewInstancesDic = value; }

        public SelectForm(List<ViewType> viewTypes, List<Autodesk.Revit.DB.View> viewInstances)
        {
            this.viewTypes = viewTypes;
            this.viewInstances = viewInstances;
            this.viewInstancesDic = new Dictionary<string, Autodesk.Revit.DB.View>();

            InitializeComponent();

            foreach (Autodesk.Revit.DB.ViewType viewType in this.viewTypes)
            {
                this.checkedListBox_types.Items.Add(viewType);
            }
        }

        public List<Autodesk.Revit.DB.View> GetCheckedViews()
        {
            List<Autodesk.Revit.DB.View> views = new List<Autodesk.Revit.DB.View>();
            foreach (string viewName in this.checkedListBox_instances.CheckedItems)
            {
                Autodesk.Revit.DB.View view;
                viewInstancesDic.TryGetValue(viewName, out view);
                views.Add(view);
            }
            return views;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_types.Items.Count; i++)
            {
                checkedListBox_types.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_types.Items.Count; i++)
            {
                checkedListBox_types.SetItemChecked(i, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_types.Items.Count; i++)
            {
                checkedListBox_types.SetItemChecked(i, !checkedListBox_types.GetItemChecked(i));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_instances.Items.Count; i++)
            {
                checkedListBox_instances.SetItemChecked(i, true);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_instances.Items.Count; i++)
            {
                checkedListBox_instances.SetItemChecked(i, false);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox_instances.Items.Count; i++)
            {
                checkedListBox_instances.SetItemChecked(i, !checkedListBox_instances.GetItemChecked(i));
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkedListBox_types_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int i = 0; i < this.viewInstances.Count; i++)
            {
                Autodesk.Revit.DB.View view = this.viewInstances[i];

                if (view.ViewType.Equals(checkedListBox_types.Items[e.Index]))
                {
                    if (!checkedListBox_types.GetItemChecked(e.Index))
                    {
                        checkedListBox_instances.Items.Add(view.ViewType + "-" + view.Title);
                        this.viewInstancesDic.Add(view.ViewType + "-" + view.Title, view);
                    }
                    else
                    {
                        checkedListBox_instances.Items.Remove(view.ViewType + "-" + view.Title);
                        this.viewInstancesDic.Remove(view.ViewType + "-" + view.Title);
                    }
                }
            }
        }
    }
}
