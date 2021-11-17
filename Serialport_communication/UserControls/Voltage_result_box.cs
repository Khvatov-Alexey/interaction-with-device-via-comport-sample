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
    public partial class Voltage_result_box : UserControl
    {
        public Voltage_result_box()
        {
            InitializeComponent();
            if (_value.Item1 == null)
            {
                textBox1.Text = nullValue;
            }
            else
            {
                textBox1.Text = _value.Item1.Value.ToString("N1");
            }
            changeColors();
        }
        [Localizable(true)]
        [Browsable(true), DefaultValue("Нет данных"),
        DisplayName("nullValue"), Description("Отображаемый текст при значении null")]
        public string nullValue { get; set; } = "Нет данных";


        private string _label_text = "Наименование параметра:";
        [Localizable(true)]
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

                label1.Left = textBox1.Left - 7 - label1.Width;
            }
        }

        private Tuple<double?, bool> _value = new Tuple<double?, bool>(null, false);
        [Browsable(true), DefaultValue(false),
        DisplayName("Результат")]
        public Tuple<double?, bool> Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                if (value.Item1 == null)
                {
                    textBox1.Text = nullValue;
                }
                else
                {
                    textBox1.Text = value.Item1.Value.ToString("N1");
                }
                changeColors();
                
            }
        }

        [Browsable(true), Category("Action")]
        public event EventHandler ValueChanged;

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            changeColors();
        }

        private void changeColors()
        {
            if (_value.Item1 == null)
            {
                textBox1.BackColor = Color.White;
                textBox1.ForeColor = Color.DimGray;
            }
            else if (_value.Item2)
            {
                textBox1.BackColor = Color.OrangeRed;
                textBox1.ForeColor = Color.Black;
            }
            else
            {
                textBox1.BackColor = Color.LimeGreen;
                textBox1.ForeColor = Color.Black;
            }
            if (ValueChanged != null) ValueChanged(this, new EventArgs());
        }

        private void Voltage_result_box_SizeChanged(object sender, EventArgs e)
        {
            label2.Left = this.Width - label2.Width;
            textBox1.Left = label2.Left - 5 - textBox1.Width;
            label1.Left = textBox1.Left - 5 - label1.Width;
        }
    }
}
