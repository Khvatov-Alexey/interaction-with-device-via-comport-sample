using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serialport_communication.UserControls
{
    public partial class Voltagebox : UserControl
    {
        public Voltagebox()
        {
            InitializeComponent();
            numericUpDown1.Value = (decimal)_voltage;
        }

        private string _label_text = "Наименование параметра:";
        [Browsable(true), DefaultValue("Наименование параметра:"),
        DisplayName("Наименование параметра")]
        public string label_text
        {
            get
            {
                return _label_text;
            }
            set
            {
                label1.Text = value;
                _label_text = value;

                label1.Left = numericUpDown1.Left - 7 - label1.Width;

                //numericUpDown1.Left = label1.Left + label1.Width + 7;
                //int width = this.Width - numericUpDown1.Left - 7 - label2.Width - 4;
                //if (width < 0) width = 0;
                //numericUpDown1.Width = width;
            }
        }

        private double _voltage = 50.0;
        [Browsable(true), DefaultValue(50.0),
        DisplayName("Вольтаж")]
        public double voltage
        {
            get
            {
                return (double)numericUpDown1.Value;
            }
            set
            {
                _voltage = value;
                numericUpDown1.Value = (decimal)value;
            }
        }

        [Browsable(true), Category("Action")]
        public event EventHandler VoltageChanged;
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            _voltage = (double)numericUpDown1.Value;
            if (VoltageChanged != null) VoltageChanged(this, e);
        }
    }
}
