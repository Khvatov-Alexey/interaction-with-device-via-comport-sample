using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serialport_communication.Model;

namespace Serialport_communication.Setup
{
    public partial class TestDevice : Form
    {
        //---------------------------------------------------------------------------

        public TestDevice()
        {
            InitializeComponent();
        }
        private void TestDevice_Shown(object sender, EventArgs e)
        {
            loadComports();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.portname) && comboBox1.Items.Contains(Properties.Settings.Default.portname)) 
                comboBox1.SelectedIndex = comboBox1.Items.IndexOf(Properties.Settings.Default.portname);
            if (comboBox2.Items.Contains(Properties.Settings.Default.baudrate.ToString())) 
                comboBox2.SelectedIndex = comboBox2.Items.IndexOf(Properties.Settings.Default.baudrate.ToString());
            else
            {
                comboBox2.SelectedIndex = comboBox2.Items.IndexOf("custom..");
                try
                {
                    numericUpDown1.Value = Properties.Settings.Default.baudrate;
                }
                catch (Exception) { }
            }
            comboBox3.SelectedIndex = comboBox3.Items.IndexOf(Properties.Settings.Default.dataBits.ToString());
            comboBox4.DataSource = Enum.GetValues(typeof(System.IO.Ports.Parity));
            comboBox4.SelectedIndex = comboBox4.Items.IndexOf(Properties.Settings.Default.parity);
            comboBox5.DataSource = Enum.GetValues(typeof(System.IO.Ports.StopBits));
            comboBox5.SelectedIndex = comboBox5.Items.IndexOf(Properties.Settings.Default.stopBits);
        }

        //---------------------------------------------------------------------------

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Пользователь: нажал Настройки / Тестируемое устройство / Проверка соединения");
                try
                {
                    if (string.IsNullOrEmpty(comboBox1.Text))
                    {
                        Popup_notification.Show("Номер COM-порта не указан", Popup_notification.enmType.Error, this, 12);
                        NLog.LogManager.GetCurrentClassLogger().Warn("Система (проверка соединения): Номер COM-порта не указан");
                        return;
                    }
                    int baudrate = comboBox2.Text == "custom.." ? (int)numericUpDown1.Value : int.Parse(comboBox2.Text);

                    /// <summary>
                    /// Попытка открыть порт -> Если не ок, то результат "Ошибка создания соединения"
                    /// Если ок, то попытка определение устройства->Если не ок, то результат "Соединение возможно", "Определить устройство не удалось"
                    /// Если все ок, то "Соединение возможно"
                    /// </summary>
                    Device.checkConnect(comboBox1.Text, baudrate, (System.IO.Ports.Parity)comboBox4.SelectedValue,
                        int.Parse(comboBox3.Text), (System.IO.Ports.StopBits)comboBox5.SelectedValue, this);
                }
                finally
                {
                    checkBox1.Checked = false;
                }
            }
        }

        //---------------------------------------------------------------------------

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Пользователь: нажал Настройки / Тестируемое устройство / Определить...");
                int baudrate = comboBox2.Text == "custom.." ? (int)numericUpDown1.Value : int.Parse(comboBox2.Text);
                string portname = Device.findDevice(baudrate, (System.IO.Ports.Parity)comboBox4.SelectedValue, int.Parse(comboBox3.Text),
                    (System.IO.Ports.StopBits)comboBox5.SelectedValue);

                if (string.IsNullOrEmpty(portname))
                {
                    Popup_notification.Show("Тестируемое устройство не найдено", Popup_notification.enmType.Error, this.Owner, 11);
                    NLog.LogManager.GetCurrentClassLogger().Warn("Система (определение устройства): Тестируемое устройство не найдено");
                    comboBox1.SelectedIndex = -1;
                }
                else
                {
                    if (!comboBox1.Items.Contains(portname)) comboBox1.Items.Add(portname);
                    comboBox1.SelectedIndex = comboBox1.Items.IndexOf(portname);
                    Popup_notification.Show($"Устройство определено ({portname})", Popup_notification.enmType.Success, this.Owner, 12);
                    NLog.LogManager.GetCurrentClassLogger().Info($"Система (определение устройства): Устройство определено ({portname})");
                }
                checkBox2.Checked = false;
            }
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            loadComports();
        }
        private void loadComports()
        {
            string selectedItem = comboBox1.Text;
            comboBox1.Items.Clear();
            comboBox1.Items.AddRange(System.IO.Ports.SerialPort.GetPortNames());
            if (comboBox1.Items.Contains(selectedItem)) comboBox1.SelectedIndex = comboBox1.Items.IndexOf(selectedItem);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Visible = comboBox2.Text == "custom..";
        }

        //---------------------------------------------------------------------------

        private void button1_Click(object sender, EventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Пользователь: нажал Настройки / Тестируемое устройство / Восстановить умолчания");
            resetSettings();
        }

        //---------------------------------------------------------------------------

        public void apply()
        {
            Properties.Settings.Default.portname = comboBox1.Text;
            Properties.Settings.Default.baudrate = comboBox2.Text == "custom.." ? (int)numericUpDown1.Value : int.Parse(comboBox2.Text);
            Properties.Settings.Default.parity = (System.IO.Ports.Parity)comboBox4.SelectedValue;
            Properties.Settings.Default.dataBits = int.Parse(comboBox3.Text);
            Properties.Settings.Default.stopBits = (System.IO.Ports.StopBits)comboBox5.SelectedValue;
        }
        public void resetSettings()
        {
            comboBox2.SelectedIndex = comboBox2.Items.IndexOf("750000");
            comboBox3.SelectedIndex = comboBox3.Items.IndexOf("8");
            comboBox4.SelectedIndex = comboBox4.Items.IndexOf(System.IO.Ports.Parity.Even);
            comboBox5.SelectedIndex = comboBox5.Items.IndexOf(System.IO.Ports.StopBits.One);
        }
        public void advancedSettings(bool enabled)
        {
            comboBox2.Enabled = enabled;
            comboBox3.Enabled = enabled;
            comboBox4.Enabled = enabled;
            comboBox5.Enabled = enabled;
            numericUpDown1.Enabled = enabled;
        }

    }
}
