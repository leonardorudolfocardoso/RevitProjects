using System;
using System.Windows.Forms;

namespace DeleteViews
{
    public partial class ResumeDialog : Form
    {
        string _message;
        public string Message { get => _message; set => _message = value; }
        public ResumeDialog(string message)
        {
            this.Message = message;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void Resume_Load(object sender, EventArgs e)
        {
            this.label1.Text = this.Message;
        }
    }
}
