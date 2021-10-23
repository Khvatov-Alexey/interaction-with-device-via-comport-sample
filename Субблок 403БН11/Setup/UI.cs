using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serialport_communication.Setup
{
    public partial class UI : Form
    {
        bool flag_save = false;
        TestDevice testDevice = null;
        public UI()
        {
            InitializeComponent();
            testDevice = new TestDevice();
            testDevice.Owner = this;
            testDevice.TopLevel = false;
            splitContainer1.Panel2.Controls.Add(testDevice);
            testDevice.Dock = DockStyle.Fill;
            testDevice.Show();
        }
        private void UI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (flag_save)
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Пользователь: закрыл окно Настройки с сохранением результатов");
                testDevice.apply();
                Properties.Settings.Default.Save();
            }
            else
            {
                NLog.LogManager.GetCurrentClassLogger().Info("Пользователь: закрыл окно Настройки без сохранения результатов");
            }
            flag_save = false;
        }

        private void chb_advancedSettings_CheckedChanged(object sender, EventArgs e)
        {
            testDevice.advancedSettings(chb_advancedSettings.Checked);
        }
        private void chb_advancedSettings_Click(object sender, EventArgs e)
        {
            NLog.LogManager.GetCurrentClassLogger().Info("Пользователь: " + (chb_advancedSettings.Checked ? "включил" : "отключил") + " расширенные настройки");
        }
        private void button2_Click(object sender, EventArgs e)
        {
            chb_advancedSettings.Checked = false;
            testDevice.resetSettings();
            NLog.LogManager.GetCurrentClassLogger().Info("Пользователь: сбросил все настройки");
        }

        private void bt_ok_Click(object sender, EventArgs e)
        {
            flag_save = true;
            this.Close();
        }
        private void bt_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
