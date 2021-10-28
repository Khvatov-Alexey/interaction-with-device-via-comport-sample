using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serialport_communication.Help
{
    public partial class About : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public About()
        {
            InitializeComponent();
            this.MaximumSize = this.Size;
            this.AcceptButton = button1;
            this.CancelButton = button1;
            this.Text = $"{this.Text} - {this.ProductName}";
            label5.Text = this.ProductName;
            label8.Text = this.ProductVersion;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: закрыл окно О программе");
            this.Close();
        }
    }
}
