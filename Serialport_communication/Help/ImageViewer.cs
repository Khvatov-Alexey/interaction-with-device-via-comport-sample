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
    public partial class ImageViewer : Form
    {
        public ImageViewer()
        {
            InitializeComponent();
            changeSize();
        }
        private void ImageViewer_Load(object sender, EventArgs e)
        {
            // Place the window in the center of the parent
            if (Owner != null && StartPosition == FormStartPosition.CenterParent)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }
        private void ImageViewer_MouseDown(object sender, MouseEventArgs e)
        {
            // Allow dragging the form
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        /// <summary>
        /// Change the currently displayed image and window size
        /// </summary>
        /// <param name="location">image location</param>
        public void changeImage(string location)
        {
            pictureBox1.ImageLocation = location;
            try
            {
                pictureBox1.Load();
            }
            catch(Exception) 
            {
                switch(System.Threading.Thread.CurrentThread.CurrentUICulture.Name)
                {
                    case "ru-RU":
                    case "ru":
                        pictureBox1.Image = Properties.Resources.error_img;
                        break;
                    default:
                        pictureBox1.Image = Properties.Resources.error_img_en;
                        break;
                }
                
            }
            changeSize();
        }

        /// <summary>
        /// Resizing the window according to the size of the displayed image
        /// </summary>
        private void changeSize()
        {
            Width = 800;
            if(pictureBox1.Image != null)
            {
                int iw = pictureBox1.Image.Width;
                int ih = pictureBox1.Image.Height;
                double price = iw / (double)ih;
                Height = (int)(pictureBox1.Width / price) + 52;
            }
            else
            {
                Height = 500;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Пользователь: закрыл окно Схема подключения");
            this.Close();
        }
        

        //private const int cGrip = 16;
        //private const int cCaption = 32;

        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x04)
        //    {
        //        Point pos = new Point
        //            (m.LParam.ToInt32());
        //        pos = this.PointToClient(pos);
        //        if(pos.Y < cCaption)
        //        {

        //            m.Result = (IntPtr)2;
        //            return;
        //        }
        //        if(pos.X < this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
        //        {
        //            m.Result = (IntPtr)17;
        //            return;
        //        }
        //    }
        //    base.WndProc(ref m);
        //}
    }
}
