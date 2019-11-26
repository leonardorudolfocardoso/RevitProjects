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
    public partial class AlignLevelsForm : Form
    {
        public Document FormDoc { get; private set; }
        public Dictionary<String, RevitLinkInstance> LinkNamesDic { get; private set; }
        public Dictionary<String, Level> LinkLevelNamesDic { get; private set; }
        public Dictionary<String, Level> DocLevelNamesDic { get; private set; }
        public AlignLevelsForm(Document formDoc)
        {
            this.FormDoc = formDoc;
            this.LinkNamesDic = new Dictionary<String, RevitLinkInstance>();
            this.LinkLevelNamesDic = new Dictionary<String, Level>();
            this.DocLevelNamesDic = new Dictionary<String, Level>();
            InitializeComponent();
        }

        private void AlignLevelsForm_Load(object sender, EventArgs e)
        {
            // LINKS ITEMS
            FilteredElementCollector linksCollector = new FilteredElementCollector(this.FormDoc)
                .OfCategory(BuiltInCategory.OST_RvtLinks)
                .WhereElementIsNotElementType();

            // iterates the links
            foreach (RevitLinkInstance revitLinkInstance in linksCollector)
            {
                // populates the LinkNamesDic
                this.LinkNamesDic.Add(revitLinkInstance.Name, revitLinkInstance);

                // add the revitLinkInstance name to combobox
                this.cbx_RevitLink.Items.Add(revitLinkInstance.Name);
            }

            // DOC ITEMS
            FilteredElementCollector docLevelsCollector = new FilteredElementCollector(this.FormDoc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType();

            // iterates the levels
            foreach (Level level in docLevelsCollector)
            {
                // populates the docLevelNamesDic
                this.DocLevelNamesDic.Add(level.Name, level);

                // add the level name to combobox
                this.cbx_DocLevel.Items.Add(level.Name);
            }
        }

        private void btn_Align_Click(object sender, EventArgs e)
        {
            if (!lb_LinkLevels.Items.Count.Equals(lb_DocLevels.Items.Count))
            {
                MessageBox.Show("As listas devem possuir a mesma quantidade de níveis, " +
                    "afim de alinha-los em pares.", "Erro");
            }
            else if (lb_LinkLevels.Items.Count.Equals(0))
            {
                MessageBox.Show("Nenhum nível a alinhar. Adicione níveis nas listas.", "Aviso");
            }
            else
            {
                int n = lb_LinkLevels.Items.Count;
                List<Level> levelsToBeAligned = (from levelName in lb_DocLevels.Items.Cast<String>()
                                                 select this.DocLevelNamesDic[levelName])
                                                 .ToList();
                List<Level> levelsBase = (from levelName in lb_LinkLevels.Items.Cast<String>()
                                          select this.LinkLevelNamesDic[levelName])
                                          .ToList();

                LevelFunctions.AlignLevels(levelsToBeAligned, levelsBase);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // gets the variable selected
            ComboBox comboBox = sender as ComboBox;
            String selectedLinkName = comboBox.SelectedItem as String;
            RevitLinkInstance selectedLink = this.LinkNamesDic[selectedLinkName];
            Document selectedLinkDoc = selectedLink.GetLinkDocument();

            // clears the link levels, link levels list box and link level names dic
            cbx_LinkLevel.Items.Clear();
            lb_LinkLevels.Items.Clear();
            this.LinkLevelNamesDic.Clear();

            // collects link levels
            FilteredElementCollector linkLevelsCollector = new FilteredElementCollector(selectedLinkDoc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType();

            // populates the link levels list box and link levels name dic
            foreach (Level level in linkLevelsCollector)
            {
                cbx_LinkLevel.Items.Add(level.Name);
                this.LinkLevelNamesDic.Add(level.Name, level);
            }
        }

        private void cmd_MoveItemUp(object sender, EventArgs e)
        {
            // get the selected item index
            ListBox listBox = sender as ListBox;
            int index = listBox.SelectedIndex;

            // item can not be the first one
            if (index > 0)
            {
                // copying the item above (sender upper neighbor)
                var aboveItem = listBox.Items[index - 1];
                // copying the item bellow (sender)
                var bellowItem = listBox.Items[index];

                // inverting order (moving sender up)
                listBox.Items[index - 1] = bellowItem;
                listBox.Items[index] = aboveItem;

                // changing the selected index (in order to maintain the sender selected)
                listBox.SelectedIndex = index - 1;
            }

        }

        private void cmd_MoveItemDown(object sender, EventArgs e)
        {
            // get the selected item index
            ListBox listBox = sender as ListBox;
            int index = listBox.SelectedIndex;

            // item can not be the last one
            if (index < listBox.Items.Count - 1)
            {
                // copying the item above (sender)
                var aboveItem = listBox.Items[index];
                // copying the item bellow (sender lower neighbor)
                var bellowItem = listBox.Items[index + 1];

                // inverting order (moving sender down)
                listBox.Items[index] = bellowItem;
                listBox.Items[index + 1] = aboveItem;

                // changing the selected index (in order to maintain the sender selected)
                listBox.SelectedIndex = index + 1;
            }

        }

        private void cmd_RemoveItem(object sender, EventArgs e)
        {
            // get the selected item
            ListBox listBox = sender as ListBox;
            int index = listBox.SelectedIndex;

            // if there is no item selected
            if (index.Equals(-1))
            {
                MessageBox.Show("Nenhum item selecionado.", "Erro");
            }
            else
            {
                // remove item
                listBox.Items.RemoveAt(index);
            }
        }

        private void btn_AddLinkLevel_Click(object sender, EventArgs e)
        {
            // get link level name
            String levelName = this.cbx_LinkLevel.SelectedItem as String;
            if (levelName!=null)
            {
                if (lb_LinkLevels.Items.Contains(levelName))
                {
                    DialogResult dialogResult = MessageBox.Show("A lista já possui este nível. " +
                        "Deseja adiciona-lo mesmo assim?", "Aviso", MessageBoxButtons.YesNo);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        lb_LinkLevels.Items.Add(levelName);
                    }
                }
                else
                {
                    lb_LinkLevels.Items.Add(levelName);
                }
            }
            else
            {
                MessageBox.Show("Nenhum nível selecionado.", "Aviso");
            }
        }

        private void btn_AddDocLevel_Click(object sender, EventArgs e)
        {
            // get doc level name
            String levelName = this.cbx_DocLevel.SelectedItem as String;
            if (levelName!=null)
            {
                if (lb_DocLevels.Items.Contains(levelName))
                {
                    DialogResult dialogResult = MessageBox.Show("A lista já possui este nível. " +
                        "Deseja adicina-lo mesmo assim?", "Aviso", MessageBoxButtons.YesNo);
                    if (dialogResult.Equals(DialogResult.Yes))
                    {
                        lb_DocLevels.Items.Add(levelName);
                    }
                }
                else
                {
                    lb_DocLevels.Items.Add(levelName);
                }
            }
            else
            {
                MessageBox.Show("Nenhum nível selecionado.", "Aviso");
            }

        }

        private void btn_MoveLinkLevelUp_Click(object sender, EventArgs e)
        {
            object obj = this.lb_LinkLevels as object;
            cmd_MoveItemUp(obj, e);
        }

        private void btn_MoveLinkLevelDown_Click(object sender, EventArgs e)
        {
            object obj = this.lb_LinkLevels as object;
            cmd_MoveItemDown(obj, e);
        }

        private void btn_RemoveLinkLevel_Click(object sender, EventArgs e)
        {
            object obj = this.lb_LinkLevels as object;
            cmd_RemoveItem(obj, e);
        }

        private void btn_MoveLevelUp_Click(object sender, EventArgs e)
        {
            object obj = this.lb_DocLevels as object;
            cmd_MoveItemUp(obj, e);
        }

        private void btn_MoveLevelDown_Click(object sender, EventArgs e)
        {
            object obj = this.lb_DocLevels as object;
            cmd_MoveItemDown(obj, e);
        }

        private void btn_RemoveLevel_Click(object sender, EventArgs e)
        {
            object obj = this.lb_DocLevels as object;
            cmd_RemoveItem(obj, e);
        }

        private void btn_AddAllLinkLevels_Click(object sender, EventArgs e)
        {
            // clear list box
            lb_LinkLevels.Items.Clear();

            foreach (String levelName in cbx_LinkLevel.Items)
            {
                lb_LinkLevels.Items.Add(levelName);
            }
        }

        private void btn_RemoveAllLinkLevels_Click(object sender, EventArgs e)
        {
            // clear list box
            lb_LinkLevels.Items.Clear();
        }

        private void btn_AddAllDocLevels_Click(object sender, EventArgs e)
        {
            // clear list box
            lb_DocLevels.Items.Clear();

            foreach (String levelName in cbx_DocLevel.Items)
            {
                lb_DocLevels.Items.Add(levelName);
            }
        }

        private void btn_RemoveAllDocLevels_Click(object sender, EventArgs e)
        {
            // clear list box
            lb_DocLevels.Items.Clear();
        }

        private void btn_CreateLevel_Click(object sender, EventArgs e)
        {
            // creating level
            CreateLevelForm createLevelForm = new CreateLevelForm(this.FormDoc);
            createLevelForm.ShowDialog();

            // updating doc levels combo box
            FilteredElementCollector docLevelsCollector = new FilteredElementCollector(this.FormDoc)
                .OfCategory(BuiltInCategory.OST_Levels)
                .WhereElementIsNotElementType();

            this.cbx_DocLevel.Items.Clear();
            this.DocLevelNamesDic.Clear();

            foreach (Level level in docLevelsCollector)
            {
                this.cbx_DocLevel.Items.Add(level.Name);
                this.DocLevelNamesDic.Add(level.Name, level);
            }
        }
    }
}
