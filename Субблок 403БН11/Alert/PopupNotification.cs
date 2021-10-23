using Serialport_communication.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serialport_communication
{
    public partial class Popup_notification : Form
    {
        enum enmAction
        {
            start,
            wait,
            stop
        }
        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info
        }

        private enmAction action = enmAction.start;
        private int x, y;

        //---------------------------------------------------------------------------

        public Popup_notification()
        {
            InitializeComponent();
        }
        public static void Show(string msg, Popup_notification.enmType type, Form parentForm, int fontSize = 16)
        {
            Popup_notification frm = new Popup_notification();
            frm.showAlert(msg, type, parentForm, fontSize);
            if (parentForm != null) parentForm.Focus();
        }

        //---------------------------------------------------------------------------

        public void showAlert(string msg, enmType type, Form parentForm, int fontSize = 16)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;
            
            Screen screen = parentForm == null || Screen.FromControl(parentForm) == null? Screen.PrimaryScreen : Screen.FromControl(parentForm);

            int heightFrom_lastAlert = screen.WorkingArea.Y + screen.WorkingArea.Height;
            for (int i = 1, height = screen.WorkingArea.Y + screen.WorkingArea.Height; i <= 8  && height > this.Height; i++, height -= this.Height)
            {
                fname = "alert" + i.ToString();
                Popup_notification frm = (Popup_notification)Application.OpenForms[fname];

                
                if(frm != null && (i == 8 || heightFrom_lastAlert < this.Height + 5))
                {
                    frm.Close();
                    frm = null;
                }
                heightFrom_lastAlert -= (this.Height + 5);
                if (frm == null)
                {
                    this.Name = fname;
                    this.x = screen.WorkingArea.X + screen.WorkingArea.Width - this.Width + 15;
                    this.y = heightFrom_lastAlert;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
            }
            this.x = screen.WorkingArea.X + screen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                    this.pictureBox1.Image = Resources.success;
                    this.BackColor = Color.SeaGreen;
                    break;
                case enmType.Error:
                    this.pictureBox1.Image = Resources.error;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.pictureBox1.Image = Resources.info;
                    this.BackColor = Color.RoyalBlue;
                    break;
                case enmType.Warning:
                    this.pictureBox1.Image = Resources.warning;
                    this.BackColor = Color.DarkOrange;
                    break;
            }


            this.label1.Text = msg;
            this.label1.Font = new Font(label1.Font.Name, fontSize, label1.Font.Style);

            this.TopMost = true;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            this.timer1.Start();
        }

        private void stopAlert()
        {
            action = enmAction.stop;
            timer1.Interval = 1;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            stopAlert();
        }
        private void label1_Click(object sender, EventArgs e)
        {
            stopAlert();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            stopAlert();
        }
        private void Form_alert_MouseClick(object sender, MouseEventArgs e)
        {
            stopAlert();
        }

        //---------------------------------------------------------------------------

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.stop;
                    break;
                case enmAction.start:
                    this.timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.stop:
                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        //---------------------------------------------------------------------------


    }
}
