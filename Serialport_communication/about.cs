using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _483ГБ24
{
    public partial class about : Form
    {
        public about()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.AcceptButton = button1;
            this.CancelButton = button1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
