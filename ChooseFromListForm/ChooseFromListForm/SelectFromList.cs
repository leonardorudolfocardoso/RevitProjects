using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChooseFromListForm
{
    public partial class SelectFromListForm : Form
    {
        string Title { get; set; }
        string Instruction { get; set; }

        public SelectFromListForm(List<string> items, string title, string instruction)
        {
            this.Title = title;
            this.Instruction = instruction;

            this.Text = this.Title;

            InitializeComponent(this.Instruction);

            foreach(string item in items)
            {
                this.checkedListBox1.Items.Add(item);
            }

        }
        public List<string> GetCheckedItems()
        {
            List<string> checkedItems = new List<string>();
            foreach (string checkedItem in this.checkedListBox1.CheckedItems)
            {
                checkedItems.Add(checkedItem);
            }
            return checkedItems;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // checks all items

            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }

        }
                     
        private void Button2_Click(object sender, EventArgs e)
        {
            // unchecks all items
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }
                     
        private void Button3_Click(object sender, EventArgs e)
        {
            // toggles check boxes
            for (int i = 0; i < this.checkedListBox1.Items.Count; i++)
            {
                if (this.checkedListBox1.GetItemChecked(i))
                {
                    this.checkedListBox1.SetItemChecked(i, false);
                }
                else
                {
                    this.checkedListBox1.SetItemChecked(i, true);
                }
            }
        }
                     
        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
