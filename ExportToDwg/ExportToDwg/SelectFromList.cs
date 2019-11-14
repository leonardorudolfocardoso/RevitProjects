using System;
using System.Collections.Generic;
using Autodesk.Revit.DB;

namespace ExportToDwg
{
    public partial class SelectFromList : System.Windows.Forms.Form
    {
        #region Properties
        List<Element> _elements;
        Dictionary<string, Element> _elementsDic;
        public List<Element> Elements { get => _elements; set => _elements = value; }
        public Dictionary<string, Element> ElementsDic { get => _elementsDic; set => _elementsDic = value; }
        #endregion
        public SelectFromList(List<Element> elements)
        {
            this.Elements = elements;
            this.ElementsDic = new Dictionary<string, Element>();
            InitializeComponent();
        }

        public List<Element> GetChoosedElements()
        {
            // creating list to return
            List<Element> choosedElements = new List<Element>();
            
            // iterating over element names choosed in checkedListBox1, and adding it to choosedElements
            foreach (string elementName in checkedListBox1.CheckedItems)
            {
                choosedElements.Add(this.ElementsDic[elementName]);
            }
            return choosedElements;
        }

        private void SelectFromList_Load(object sender, EventArgs e)
        {
            foreach (Element element in this.Elements)
            {
                this.ElementsDic.Add((element as View).Title, element);
                checkedListBox1.Items.Add((element as View).Title);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i=0; i<checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int i=0; i<checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (checkedListBox1.CheckedItems.Count > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                System.Windows.Forms
                    .MessageBox.Show("Selecione ao menos uma folha.", "Selecionar folhas");
            }
            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
