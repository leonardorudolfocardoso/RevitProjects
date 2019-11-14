namespace ImportLevel
{
    partial class SelectFromList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl_message = new System.Windows.Forms.Label();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btn_checkAll = new System.Windows.Forms.Button();
            this.btn_checkNone = new System.Windows.Forms.Button();
            this.btn_toggle = new System.Windows.Forms.Button();
            this.btn_select = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_message
            // 
            this.lbl_message.AutoSize = true;
            this.lbl_message.Location = new System.Drawing.Point(13, 13);
            this.lbl_message.Name = "lbl_message";
            this.lbl_message.Size = new System.Drawing.Size(35, 13);
            this.lbl_message.TabIndex = 0;
            this.lbl_message.Text = "label1";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.CheckOnClick = true;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(16, 30);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(345, 319);
            this.checkedListBox1.TabIndex = 1;
            this.checkedListBox1.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBox1_ItemCheck);
            // 
            // btn_checkAll
            // 
            this.btn_checkAll.Location = new System.Drawing.Point(16, 356);
            this.btn_checkAll.Name = "btn_checkAll";
            this.btn_checkAll.Size = new System.Drawing.Size(110, 23);
            this.btn_checkAll.TabIndex = 2;
            this.btn_checkAll.Text = "Todos";
            this.btn_checkAll.UseVisualStyleBackColor = true;
            this.btn_checkAll.Click += new System.EventHandler(this.btn_checkAll_Click);
            // 
            // btn_checkNone
            // 
            this.btn_checkNone.Location = new System.Drawing.Point(132, 356);
            this.btn_checkNone.Name = "btn_checkNone";
            this.btn_checkNone.Size = new System.Drawing.Size(110, 23);
            this.btn_checkNone.TabIndex = 3;
            this.btn_checkNone.Text = "Nenhum";
            this.btn_checkNone.UseVisualStyleBackColor = true;
            this.btn_checkNone.Click += new System.EventHandler(this.btn_checkNone_Click);
            // 
            // btn_toggle
            // 
            this.btn_toggle.Location = new System.Drawing.Point(251, 356);
            this.btn_toggle.Name = "btn_toggle";
            this.btn_toggle.Size = new System.Drawing.Size(110, 23);
            this.btn_toggle.TabIndex = 4;
            this.btn_toggle.Text = "Inverter";
            this.btn_toggle.UseVisualStyleBackColor = true;
            this.btn_toggle.Click += new System.EventHandler(this.btn_toggle_Click);
            // 
            // btn_select
            // 
            this.btn_select.Location = new System.Drawing.Point(132, 385);
            this.btn_select.Name = "btn_select";
            this.btn_select.Size = new System.Drawing.Size(110, 23);
            this.btn_select.TabIndex = 5;
            this.btn_select.Text = "Selecionar";
            this.btn_select.UseVisualStyleBackColor = true;
            this.btn_select.Click += new System.EventHandler(this.btn_select_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(251, 385);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(110, 23);
            this.btn_cancel.TabIndex = 6;
            this.btn_cancel.Text = "Cancelar";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // SelectFromList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 421);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_select);
            this.Controls.Add(this.btn_toggle);
            this.Controls.Add(this.btn_checkNone);
            this.Controls.Add(this.btn_checkAll);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.lbl_message);
            this.Name = "SelectFromList";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Selecionar";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_message;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button btn_checkAll;
        private System.Windows.Forms.Button btn_checkNone;
        private System.Windows.Forms.Button btn_toggle;
        private System.Windows.Forms.Button btn_select;
        private System.Windows.Forms.Button btn_cancel;
    }
}

