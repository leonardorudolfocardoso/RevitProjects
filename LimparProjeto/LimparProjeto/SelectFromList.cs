using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LimparProjeto
{
    public partial class SelectFromList : Form
    {
        List<string> _list;
        public List<string> List { get => _list; set => _list = value; }
        public SelectFromList(List<string> list)
        {
            this.List = list;
            InitializeComponent();

            // populate checkedListBox with items in this.List
            foreach(string item in this.List)
            {
                checkedListBox1.Items.Add(item);
            }
        }
        public List<string> GetSelectedItems()
        {
            List<string> checkedItems = new List<string>();

            foreach(string item in this.checkedListBox1.CheckedItems)
            {
                checkedItems.Add(item);
            }
            return checkedItems;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
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
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
