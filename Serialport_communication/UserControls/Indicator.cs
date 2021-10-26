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
    public partial class Indicator : UserControl
    {
        public Indicator()
        {
            InitializeComponent();
            label1.Text = _label_text;
        }
        
        private string _label_text = "Наименование";
        [Localizable(true)]
        [Browsable(true), DefaultValue("Наименование"),
        DisplayName("Наименование")]
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
            }
        }

        private Color _color_result = Color.Silver;
        [Browsable(true), DefaultValue("Наименование"),
        DisplayName("Наименование")]
        public Color color_result
        {
            get
            {
                return _color_result;
            }
            set
            {
                panel2.BackColor = value;
                _color_result = value;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            e.Graphics.Clear(panel2.Parent.BackColor);
            Panel control = (Panel)sender;
            using (System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath())
            {
                path.AddEllipse(1, 1, control.Width - 3, control.Height - 3);
                using (SolidBrush brush = new SolidBrush(control.BackColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
                path.AddEllipse(0, 0, control.Width - 1, control.Height - 1);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(0x33, 0x33, 0x33)))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }
        }

    }
}
