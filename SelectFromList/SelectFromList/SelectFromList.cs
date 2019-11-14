using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SelectFromList
{
    public partial class SelectFromList : Form
    {
        #region Properties
        public Dictionary<string, object> KeyValuePairs { get; private set; }
        public bool MultiSelect { get; private set; }
        public string MessageText { get; private set; }
        public string FormTitle { get; private set; }
        public List<object> SelectedValues { get; private set; }

        #endregion
        public SelectFromList(Dictionary<string, object> keyValuePairs, bool multiSelect)
        {
            this.SelectedValues = new List<object>();
            this.KeyValuePairs = keyValuePairs;
            this.MultiSelect = multiSelect;
            this.MessageText = "Select";
            this.FormTitle = "Selecionar";
            InitializeComponent();
        }

        public SelectFromList(Dictionary<string, object> keyValuePairs, bool multiSelect, string messageText)
        {
            this.SelectedValues = new List<object>();
            this.KeyValuePairs = keyValuePairs;
            this.MultiSelect = multiSelect;
            this.MessageText = messageText;
            this.FormTitle = "Selecionar";
            InitializeComponent();
        }

        public SelectFromList(Dictionary<string, object> keyValuePairs, bool multiSelect, string messageText, string formTitle)
        {
            this.SelectedValues = new List<object>();
            this.KeyValuePairs = keyValuePairs;
            this.MultiSelect = multiSelect;
            this.MessageText = messageText;
            this.FormTitle = formTitle;
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = this.FormTitle;
            lbl_message.Text = this.MessageText;

            if (!this.MultiSelect)
            {
                btn_checkAll.Visible = false;
                btn_checkNone.Visible = false;
                btn_toggle.Visible = false;
            }

            foreach (string key in this.KeyValuePairs.Keys)
            {
                checkedListBox1.Items.Add(key);
            }
        }

        private void btn_checkAll_Click(object sender, EventArgs e)
        {
            for (int i=0; i<checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, true);
            }
        }

        private void btn_checkNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, !checkedListBox1.GetItemChecked(i));
            }
        }

        private void btn_select_Click(object sender, EventArgs e)
        {
            foreach (object selectedValue in checkedListBox1.CheckedItems) {
                this.SelectedValues.Add(this.KeyValuePairs[selectedValue]);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (!this.MultiSelect){
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    if (i != e.Index)
                    {
                        checkedListBox1.SetItemChecked(i, false);
                    }
                }
            }
        }
    }
}
