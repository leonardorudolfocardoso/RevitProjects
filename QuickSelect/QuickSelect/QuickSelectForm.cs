using Autodesk.Revit.DB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Form = System.Windows.Forms.Form;

namespace QuickSelect
{
    public partial class QuickSelectForm : Form
    {
        public Document FormDoc { get; private set; }
        public QuickSelectForm(Document formDoc)
        {
            this.FormDoc = formDoc;
            InitializeComponent();
        }

        private void QuickSelectorForm_Load(object sender, EventArgs e)
        {
            this.FillTreeView();
        }

        public void FillTreeView()
        {
            List<Category> categories = new List<Category>();
            List<HashSet<String>> parametersList = new List<HashSet<String>>();
            List<FamilyInstance> familyInstances;
            FamilySymbol familySymbol;
            Family family;

            this.treeView1.BeginUpdate();
            foreach (Category category in this.FormDoc.Settings.Categories)
            {
                if (category.AllowsBoundParameters &&
                    category.get_AllowsVisibilityControl(this.FormDoc.ActiveView))
                {
                    familyInstances = new FilteredElementCollector(this.FormDoc)
                        .OfClass(typeof(FamilyInstance))
                        .OfCategoryId(category.Id)
                        .ToElements()
                        .Cast<FamilyInstance>()
                        .ToList();

                    if (!familyInstances.Any())
                    {
                        continue;
                    }

                    categories.Add(category);
                    treeView1.Nodes.Add(category.Name);

                    // set of parameters
                    HashSet<String> parameters = new HashSet<String>();

                    foreach (FamilyInstance familyInstance in familyInstances)
                    {
                        familySymbol = familyInstance.Symbol;
                        family = familySymbol.Family;
                        
                        foreach (Parameter parameter in familyInstance.Parameters)
                        {
                            // add instance parameters to set
                            parameters.Add(parameter.Definition.Name);
                        }

                        //foreach (Parameter parameter in familySymbol.Parameters)
                        //{
                        //    // add type parameters to set
                        //    parameters.Add(parameter.Definition.Name);
                        //}

                        //foreach (Parameter parameter in family.Parameters)
                        //{
                        //    // add family type parameter to set
                        //    parameters.Add(parameter.Definition.Name);
                        //}
                    }

                    foreach (String parameter in parameters)
                    {
                        treeView1.Nodes[categories.IndexOf(category)].Nodes.Add(parameter);
                    }

                    // add parameter set to list
                    parametersList.Add(parameters);
                }
            }
            this.treeView1.EndUpdate();
        }
    }
}
