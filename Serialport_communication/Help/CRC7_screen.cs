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
    public partial class CRC7_screen : Form
    {
        public CRC7_screen()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Количество байт
            int byteCnt = textBox1.Text.Length / 2;
            label6.Text = byteCnt.ToString();
            // Если 0 символов
            if(textBox1.Text.Length == 0)
            {
                textBox3.Text = null;
                textBox2.Text = null;
                label7.Visible = false;
                return;
            }

            if (textBox1.Text.Length >= 2 && textBox1.Text.Length % 2 == 0)  // четное количество символов
            {
                byte[] buffer = new byte[byteCnt];
                for(int i = 0, j = 0; i < textBox1.Text.Length; i+=2, j++)
                {
                    try
                    {
                        buffer[j] = (byte)Convert.ToInt32(textBox1.Text.Substring(i, 2), 16);
                        textBox3.Text += " 0x" + buffer[j].ToString("X2");
                    }
                    catch (FormatException)
                    {
                        label7.Visible = true;
                        return;
                    }
                }
                textBox2.Text = "0x" + CRC7.crc7(buffer).ToString("X2");
                label7.Visible = false;
                NLog.LogManager.GetCurrentClassLogger().Info($"Окно CRC7: Расчет CRC7" +
                    $"{Environment.NewLine}полученные данные:\"{textBox1.Text}\"" +
                    $"{Environment.NewLine}промежуточный результат:\"{textBox3.Text}\"" +
                    $"{Environment.NewLine}Результат:\"{textBox2.Text}\"" +
                    $"{Environment.NewLine}Количество байт:{label6.Text}");
            }
            else // нечетное количество символов
            {
                textBox3.Text = null;
                textBox2.Text = null;
                label7.Visible = true;
            }
        }

        private void CRC7_screen_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }
        private void label4_MouseDown(object sender, MouseEventArgs e)
        {
            base.Capture = true;
            base.Capture = false;
            Message m = Message.Create(base.Handle, 0xa1, new IntPtr(2), IntPtr.Zero);
            this.WndProc(ref m);
        }

        private void CRC7_screen_Load(object sender, EventArgs e)
        {
            if (Owner != null && StartPosition == FormStartPosition.CenterParent)
                Location = new Point(Owner.Location.X + Owner.Width / 2 - Width / 2, Owner.Location.Y + Owner.Height / 2 - Height / 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Пользователь: закрыл окно CRC7");
            this.Close();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!char.IsDigit(e.KeyChar) &&!char.IsControl(e.KeyChar) && !(e.KeyChar >= 'A' && e.KeyChar <= 'F' || e.KeyChar >= 'a' && e.KeyChar <= 'f'))
            {
                Popup_notification.Show($"Ввод недопустимого символа \"{e.KeyChar}\"", Popup_notification.enmType.Error, this, 12);
                NLog.LogManager.GetCurrentClassLogger().Warn($"Окно CRC7: Ввод недопустимого символа \"{e.KeyChar}\"");
                e.Handled = true;
            }
        }

        
    }
}
