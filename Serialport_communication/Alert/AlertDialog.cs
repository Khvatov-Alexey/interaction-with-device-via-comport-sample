using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace okr_pki
{
    public partial class AlertDialog : Form
    {
        public AlertDialog()
        {
            InitializeComponent();
        }

        public void setMsg(string _msg)
        {
            label1.Text = _msg;
        }
        public void setTextButton(string yesbtn, string nobtn, string cancelbtn)
        {
            button2.Text = yesbtn;
            button1.Text = nobtn;
            button7.Text = cancelbtn;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }
    }
}
