using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serialport_communication.Model;

namespace Serialport_communication
{
    public partial class Form1 : Form
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        /// <summary>
        /// поток для взаимодействия с устройством
        /// </summary>
        Thread thread;
        /// <summary>
        /// Собственно, само устройство
        /// </summary>
        public Device device;
        /// <summary>
        /// Флаг о имеющихся несохраненных данных
        /// </summary>
        private bool needSave = false;
        /// <summary>
        /// Количество знаков после запятой  значениях напряжений
        /// </summary>
        private static string decimalPlaces = "N1";

        //---------------------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();
            colorThemeSetup();
            logger.Info("===== ЗАПУСК ПРИЛОЖЕНИЯ =====");
        }
        private void Form1_Shown(object sender, EventArgs e)
        {
            device = new Device(this);
            thread = new Thread(new ThreadStart(device.stream)) { IsBackground = true };
            logger.Trace("Запуск потока для общения с устройством...");
            thread.Start();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needSave)
            {
                if (MessageBox.Show("Данное действие приведет к потере ранее несохраненных данных.\n\nПродолжить?", "Подтверждение действия", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    this.Focus();
                    e.Cancel = true;
                    logger.Info("Пользователь: отменил закрытие приложения, т.к. есть несохраненные данные");
                    return;
                }
                logger.Info("Пользователь: согласился на потерю несохраненных данных при закрытии приложения");
            }

            // DEBUG ???: поток является фоновым и не должен в релизе влиять на завершение процесса, но при debug вызывает исключение в VS,
            // т.к. поток посылает через invoke на UI данные и если в этот момент мы закрыли приложение, объект формы может быть уже удален и вызовется исключение в потоке
            // поэтому мы сообщаем поток о закрытии, ждем, позволяет фоновому потоку передать данные и после закрываем приложение
            if (thread != null)
            {
                logger.Trace("Система: говорим потоку о завершении работы");
                thread.Abort();
                Thread.Sleep(100);
                Application.DoEvents();
            }

        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            logger.Info("===== ЗАКРЫТИЕ ПРИЛОЖЕНИЯ =====");
        }

        //---------------------------------------------------------------------------

        #region Настройка цветов
        private void colorThemeSetup()
        {
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.White;
                foreach (ToolStripItem dd in item.DropDownItems)
                {
                    dd.ForeColor = Color.White;
                }
            }
            menuStrip1.Renderer = new ToolStripProfessionalRenderer(new Cols(menuStrip1.BackColor));
        }
        public class Cols : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.FromArgb(59, 74, 84); }
            }

            public override Color ToolStripDropDownBackground
            {
                get { return backColor; }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return backColor; }
            }

            public override Color ImageMarginGradientEnd
            {
                get { return backColor; }
            }

            public override Color ImageMarginGradientMiddle
            {
                get { return backColor; }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.FromArgb(59, 74, 84); }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.FromArgb(59, 74, 84); }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.FromArgb(59, 74, 84); }
            }

            public override Color MenuItemPressedGradientMiddle
            {
                get { return Color.FromArgb(59, 74, 84); }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.FromArgb(59, 74, 84); }
            }

            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(0, 143, 245); }
            }

            public override Color MenuBorder
            {
                get { return Color.FromArgb(0, 143, 245); }
            }

            public Cols(Color _backColor)
            {
                backColor = _backColor;
            }
            private Color backColor;
        }
        public class Cols2 : ProfessionalColorTable
        {
            public override Color MenuItemSelected
            {
                get { return Color.White; }
            }

            public override Color ToolStripDropDownBackground
            {
                get { return SystemColors.ControlLight; }
            }

            public override Color ImageMarginGradientBegin
            {
                get { return SystemColors.ControlLight; }
            }

            public override Color ImageMarginGradientEnd
            {
                get { return SystemColors.ControlLight; }
            }

            public override Color ImageMarginGradientMiddle
            {
                get { return SystemColors.ControlLight; }
            }

            public override Color MenuItemSelectedGradientBegin
            {
                get { return Color.White; }
            }
            public override Color MenuItemSelectedGradientEnd
            {
                get { return Color.White; }
            }

            public override Color MenuItemPressedGradientBegin
            {
                get { return Color.White; }
            }

            public override Color MenuItemPressedGradientMiddle
            {
                get { return Color.White; }
            }

            public override Color MenuItemPressedGradientEnd
            {
                get { return Color.White; }
            }

            public override Color MenuItemBorder
            {
                get { return Color.FromArgb(59, 74, 84); }
            }
        }
        #endregion

        //---------------------------------------------------------------------------

        #region Основное меню
        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: нажал Файл / Новый");
            if (checkMeasContinues())
            {
                Popup_notification.Show("Невозможно во время измерений", Popup_notification.enmType.Error, this, 12);
                logger.Warn("Система: Невозможно во время измерений (Файл / Новый)");
                return;
            }

            if (needSave)
            {
                if (MessageBox.Show("Данное действие приведет к потере ранее несохраненных данных.\n\nПродолжить?", "Подтверждение действия", MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    Popup_notification.Show("Очистка результатов отменено", Popup_notification.enmType.Info, this, 12);
                    logger.Info("Пользователь: отменил очистку результатов, т.к. есть несохраненные данные");
                    return;
                }
                logger.Info("Пользователь: согласился на потерю несохраненных данных при очистки результатов");
            }

            clearUI();

            Popup_notification.Show("Результаты измерений очищены", Popup_notification.enmType.Success, this, 12);
            logger.Info("Система: Результаты измерений очищены");
        }
        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: нажал Файл / Открыть");
            if (needSave)
            {
                if (MessageBox.Show(
                    "Данное действие приведет к потере ранее несохраненных данных.\n\nПродолжить?",
                    "Подтверждение действия", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                {
                    Popup_notification.Show("Открытие файла отменено", Popup_notification.enmType.Info, this, 12);
                    logger.Info("Пользователь: отменил открытие измерений, т.к. есть несохраненные данные");
                    return;
                }
                logger.Info("Пользователь: согласился на потерю несохраненных данных при открытии измерений");
            }

            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Измерения");
            openFileDialog1.Title = "Открытие измерений";
            openFileDialog1.DefaultExt = "ini";
            openFileDialog1.Filter = "All|*|ini|*.ini";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog1.FileName = openFileDialog1.FileName;
                clearUI();

                try
                {
                    string separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
                    /// Используется carnel32 ini по просьбе коллег
                    IniFile fileConfig = new IniFile(saveFileDialog1.FileName);
                    string section = "", name = "";
                    DateTime? date = null;

                    try
                    {
                        section = @"Общие сведения";
                        name = @"Дата и время сохранения";
                        date = DateTime.Parse(fileConfig.Read(section, name, null));

                        section = @"Индикатор";
                        name = @"Цвет";
                        indicator1.color_result = Color.FromArgb(int.Parse(fileConfig.Read(section, name, "")));
                        name = @"Текст";
                        string res = fileConfig.Read(section, name, null);
                        if (string.IsNullOrEmpty(res)) throw new Exception("Не может быть пустым");
                        indicator1.label_text = res;


                        section = @"Установка напряжений";
                        name = @"+ 50 В ОСН";
                        voltagebox1.voltage = double.Parse(fileConfig.Read(section, name, "").Replace(",", separator).Replace(".", separator));
                        name = @"+ 50 В ДОП";
                        voltagebox2.voltage = double.Parse(fileConfig.Read(section, name, "").Replace(",", separator).Replace(".", separator));
                        name = @"+ 50 В";
                        voltagebox3.voltage = double.Parse(fileConfig.Read(section, name, "").Replace(",", separator).Replace(".", separator));


                        section = @"Выходные напряжения";
                        name = @"+ 50 В ОСН";
                        voltage_result_box1.Value = read__voltage_result(fileConfig.Read(section, name, "error"));
                        name = @"+ 50 В ДОП";
                        voltage_result_box2.Value = read__voltage_result(fileConfig.Read(section, name, "error"));
                        name = @"+ 50 В";
                        voltage_result_box3.Value = read__voltage_result(fileConfig.Read(section, name, "error"));
                        name = @"+ 300 В";
                        voltage_result_box4.Value = read__voltage_result(fileConfig.Read(section, name, "error"));
                        name = @"+ 5 В";
                        voltage_result_box5.Value = read__voltage_result(fileConfig.Read(section, name, "error"));
                        name = @"+ 12 В";
                        voltage_result_box6.Value = read__voltage_result(fileConfig.Read(section, name, "error"));
                        name = @"- 12 В";
                        voltage_result_box7.Value = read__voltage_result(fileConfig.Read(section, name, "error"));
                    }
                    catch(Exception)
                    {
                        throw new Exception($"Ошибка при чтении параметра \"{section}/{name}\"");
                    }
                    Popup_notification.Show("Файл успешно открыт", Popup_notification.enmType.Success, this, 12);
                    logger.Info($"Система (открытие файла): Файл успешно открыт");
                }
                catch (Exception err)
                {
                    saveFileDialog1.FileName = "";
                    Popup_notification.Show("Ошибка при окрытии файла", Popup_notification.enmType.Error, this, 14);
                    MessageBox.Show("Ошибка при окрытии файла.\n\n" + err.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    logger.Warn($"Система (открытие файла): Ошибка при окрытии файла{Environment.NewLine}{err}");
                }
                finally
                {
                    needSave = false;
                }
            }
            else
            {
                Popup_notification.Show("Открытие файла отменено", Popup_notification.enmType.Info, this, 12);
                logger.Info("Система (открытие файла): отменено пользователем");
            }
        }
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: нажал Файл / Сохранить");
            System.IO.Directory.CreateDirectory(Application.StartupPath + @"\Измерения");
            saveFileDialog1.Title = "Сохранение измерений";
            saveFileDialog1.DefaultExt = "ini";
            saveFileDialog1.Filter = "All|*|ini|*.ini";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.InitialDirectory = Application.StartupPath + @"\Измерения";
            try
            {
                saveFileDialog1.FileName = System.IO.Path.GetFileName(saveFileDialog1.FileName);
            }
            catch (Exception) { }
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                /// Используется carnel32 ini по просьбе коллег
                IniFile fileConfig = new IniFile(saveFileDialog1.FileName);
                string section;

                section = @"Общие сведения";
                fileConfig.Write(section, "Дата и время сохранения", DateTime.Now.ToString());
                section = @"Индикатор";
                fileConfig.Write(section, @"Цвет", indicator1.color_result.ToArgb().ToString());
                fileConfig.Write(section, @"Текст", indicator1.label_text);

                section = @"Установка напряжений";
                fileConfig.Write(section, @"+ 50 В ОСН", voltagebox1.voltage.ToString(decimalPlaces));
                fileConfig.Write(section, @"+ 50 В ДОП", voltagebox1.voltage.ToString(decimalPlaces));
                fileConfig.Write(section, @"+ 50 В", voltagebox1.voltage.ToString(decimalPlaces));

                section = @"Выходные напряжения";
                fileConfig.Write(section, @"+ 50 В ОСН", voltage_result_box1.Value.Item1.ToString() + ";" + voltage_result_box1.Value.Item2.ToString());
                fileConfig.Write(section, @"+ 50 В ДОП", voltage_result_box2.Value.Item1.ToString() + ";" + voltage_result_box2.Value.Item2.ToString());
                fileConfig.Write(section, @"+ 50 В", voltage_result_box3.Value.Item1.ToString() + ";" + voltage_result_box3.Value.Item2.ToString());
                fileConfig.Write(section, @"+ 300 В КВУ", voltage_result_box4.Value.Item1.ToString() + ";" + voltage_result_box4.Value.Item2.ToString());
                fileConfig.Write(section, @"+ 5 В", voltage_result_box5.Value.Item1.ToString() + ";" + voltage_result_box5.Value.Item2.ToString());
                fileConfig.Write(section, @"+ 12 В", voltage_result_box6.Value.Item1.ToString() + ";" + voltage_result_box6.Value.Item2.ToString());
                fileConfig.Write(section, @"- 12 В", voltage_result_box7.Value.Item1.ToString() + ";" + voltage_result_box7.Value.Item2.ToString());

                needSave = false;
                Popup_notification.Show("Файл успешно сохранен", Popup_notification.enmType.Success, this, 14);
                logger.Info("Система (сохранение файла): успешно");
            }
            else
            {
                Popup_notification.Show("Процесс сохранения отменен", Popup_notification.enmType.Info, this, 12);
                logger.Info("Система (сохранение файла): отменено пользователем");
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: нажал Файл / Выход");
            this.Close();
        }

        private void testDeviceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: нажал Настройки / тестируемое устройство");
            Setup.UI f_setup = new Setup.UI();
            f_setup.treeView1.SelectedNode = f_setup.treeView1.Nodes[0];
            f_setup.ShowDialog(this);
        }

        private void оПрограммеToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: нажал Справка / О программе");
            Help.About aboutscreen = new Help.About();
            aboutscreen.ShowDialog();
        }
        private void viewImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: нажал Справка / Схема подключения");
            Help.ImageViewer connection_scheme = new Help.ImageViewer();
            connection_scheme.Owner = this;
            connection_scheme.changeImage(Application.StartupPath + "//Schemes//connection_scheme.jpg");
            connection_scheme.Show();
        }
        private void cRC7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: нажал Справка / CRC7");
            Help.CRC7_screen crc7 = new Help.CRC7_screen();
            crc7.Owner = this;
            crc7.Show();
        }
        #endregion

        //---------------------------------------------------------------------------

        delegate object objectReturnDelegate();
        delegate void objectSetDelegate(object values);
        delegate void objectsSetDelegate(object value1, object value2);

        //---------------------------------------------------------------------------

        #region Обмен данными
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                checkBox2.Checked = false;
                indicator1.label_text = "Связь (однократно)";
            }

        }
        private void checkBox3_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: " + (checkBox3.Checked ? "нажал" : "Отжал") + " " + checkBox3.Text);
            senddata_toThread();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox3.Checked = false;
                indicator1.label_text = "Связь";
            }
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
            logger.Info("Пользователь: " + (checkBox2.Checked ? "нажал" : "Отжал") + " " + checkBox2.Text);
            if (!checkBox2.Checked)
            {
                indicator1.color_result = Color.Silver;
            }
            senddata_toThread();
        }

        /// <summary>
        /// Проверка запущен ли сейчас обмен данными
        /// </summary>
        /// <returns>Рнзультат проверки</returns>
        private bool checkMeasContinues()
        {
            return checkBox2.Checked || checkBox3.Checked;
        }
        public object disableSINGLE()
        {
            if (checkBox3.InvokeRequired)
            {
                objectReturnDelegate d = new objectReturnDelegate(disableSINGLE);
                return checkBox3.Invoke(d);
            }
            else
            {
                checkBox3.Checked = false;
                logger.Trace("Система: отжали " + checkBox3.Text);
                return null;
            }
        }
        /// <summary>
        /// Потокобезопасная передача данных в поток взаимодействия с устройтва. Данные собираются с UI
        /// </summary>
        private void senddata_toThread()
        {
            device.setData__fromUI(checkBox3.Checked, checkBox2.Checked, логКомандToolStripMenuItem.Checked, new FDK_output(voltagebox1.voltage, voltagebox2.voltage, voltagebox3.voltage));
        }
        public void setParams__toUI(object connectivityObj, object voltagesObj)
        {
            if (this.InvokeRequired)
            {
                objectsSetDelegate d = new objectsSetDelegate(setParams__toUI);
                this.Invoke(d, connectivityObj, voltagesObj);
            }
            else
            {
                FDK_input voltages = (FDK_input)voltagesObj;
                Connectivity connectivity = (Connectivity)connectivityObj;

                switch (connectivity.connect_status)
                {
                    case Connectivity.Connect_status.disable:
                        indicator1.color_result = Color.Silver;
                        break;
                    case Connectivity.Connect_status.error:
                        indicator1.color_result = connectivity.run && !checkBox2.Checked ? Color.Silver : Color.Red;
                        voltage_result_box1.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box2.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box3.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box4.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box5.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box6.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box7.Value = new Tuple<double?, bool>(null, false);
                        break;
                    case Connectivity.Connect_status.success:
                        indicator1.color_result = connectivity.run && !checkBox2.Checked ? Color.Silver : Color.LimeGreen;
                        voltage_result_box1.Value = voltages.plus50v_osn;
                        voltage_result_box2.Value = voltages.plus50v_dop;
                        voltage_result_box3.Value = voltages.plus50v;
                        voltage_result_box4.Value = voltages.plus300v;
                        voltage_result_box5.Value = voltages.plus5v;
                        voltage_result_box6.Value = voltages.plus12v;
                        voltage_result_box7.Value = voltages.minus12v;
                        break;
                }
            }
        }
        public void setConnectivity_toUI(object connectivityObj)
        {
            if (this.InvokeRequired)
            {
                objectSetDelegate d = new objectSetDelegate(setConnectivity_toUI);
                this.Invoke(d, connectivityObj);
            }
            else
            {
                Connectivity connectivity = (Connectivity) connectivityObj;
                switch (connectivity.connect_status)
                {
                    case Connectivity.Connect_status.disable:
                        indicator1.color_result = Color.Silver;
                        break;
                    case Connectivity.Connect_status.error:
                        indicator1.color_result = connectivity.run && !checkBox2.Checked ? Color.Silver : Color.Red;
                        voltage_result_box1.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box2.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box3.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box4.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box5.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box6.Value = new Tuple<double?, bool>(null, false);
                        voltage_result_box7.Value = new Tuple<double?, bool>(null, false);
                        break;
                    case Connectivity.Connect_status.success:
                        indicator1.color_result = connectivity.run && !checkBox2.Checked ? Color.Silver : Color.LimeGreen;
                        break;
                }
            }
        }
        #endregion

        //---------------------------------------------------------------------------

        #region Окно сообщений
        delegate void StringArgReturningVoidDelegate(string Text, Color TextColor);
        public void AddLog(string Text, Color TextColor)
        {
            if (this.Mess.InvokeRequired)
            {
                StringArgReturningVoidDelegate d = new StringArgReturningVoidDelegate(AddLog);
                this.Mess.Invoke(d, new object[] { Text, TextColor });
            }
            else
            {
                int start = Mess.TextLength;
                Mess.AppendText(DateTime.Now.ToString("HH:mm:ss") + "  " + Text + System.Environment.NewLine);
                Mess.Refresh();
                int length = Mess.TextLength - start;
                Mess.SelectionStart = start;
                Mess.SelectionLength = length;
                Mess.SelectionColor = TextColor;
                Mess.SelectionFont = new Font(Mess.SelectionFont.FontFamily, Mess.SelectionFont.Size, FontStyle.Regular);
                Mess.Refresh();
                Mess.SelectionStart = Mess.TextLength;
                Mess.ScrollToCaret();
            }
        }
        private void очиститьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Mess.Clear();
            logger.Info("Пользователь: очистил сообщения");
        }
        private void логКомандToolStripMenuItem_Click(object sender, EventArgs e)
        {
            senddata_toThread();
            logger.Info("Пользователь: " + (логКомандToolStripMenuItem.Checked ? "включил" : "отключил") + " логгирование команд");
        }
        private void Mess_DoubleClick(object sender, EventArgs e)
        {
            Mess.Clear();
            logger.Info("Пользователь: очистил сообщения");
        }
        #endregion

        //---------------------------------------------------------------------------

        #region Установка напряжений
        private void voltagebox_VoltageChanged(object sender, EventArgs e)
        {
            if (sender is UserControls.Voltagebox)
            {
                logger.Info($"Пользователь: изменил значение {((UserControls.Voltagebox)sender).label_text} на {((UserControls.Voltagebox)sender).voltage:N1} В");
            }
            senddata_toThread();
        }
        #endregion

        //---------------------------------------------------------------------------

        #region Выходные напряжения
        private void voltage_result_box_ValueChanged(object sender, EventArgs e)
        {
            foreach (UserControls.Voltage_result_box box in groupBox1.Controls.OfType<UserControls.Voltage_result_box>().ToArray())
            {
                if (box.Value.Item1 != null)
                {
                    needSave = true;
                    return;
                }
            }
            needSave = false;
        }
        #endregion

        //---------------------------------------------------------------------------

        #region Clear / Open / Save
        /// <summary>
        /// Получаем из строки значения выходных напряжений. (лучше перегрузить преобразование в классе)
        /// </summary>
        /// <param name="value">Строка, содержащая значения выходного напряжения</param>
        /// <returns>выходное напряжение</returns>
        private Tuple<double?, bool> read__voltage_result(string value)
        {
            if (value == ";False") return new Tuple<double?, bool>(null, false);
            string separator = Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator;
            string[] keyValue = value.Split(';');
            if (keyValue.Length != 2) throw new Exception("Неверный формат. Количество значений должно быть равным двум");

            double? item1 = double.Parse(keyValue[0].Replace(",", separator).Replace(".", separator));
            bool item2 = bool.Parse(keyValue[1]);

            return new Tuple<double?, bool>(item1, item2);
        }
        /// <summary>
        /// Очистка результатов обмена данных с устройством
        /// </summary>
        private void clearUI()
        {
            indicator1.color_result = Color.Silver;
            indicator1.label_text = "Связь";

            Mess.Clear();

            voltagebox1.voltage = 50.0;
            voltagebox2.voltage = 50.0;
            voltagebox3.voltage = 50.0;

            voltage_result_box1.Value = new Tuple<double?, bool>(null, false);
            voltage_result_box2.Value = new Tuple<double?, bool>(null, false);
            voltage_result_box3.Value = new Tuple<double?, bool>(null, false);
            voltage_result_box4.Value = new Tuple<double?, bool>(null, false);
            voltage_result_box5.Value = new Tuple<double?, bool>(null, false);
            voltage_result_box6.Value = new Tuple<double?, bool>(null, false);
            voltage_result_box7.Value = new Tuple<double?, bool>(null, false);

            needSave = false;
        }
        #endregion

        //---------------------------------------------------------------------------




    }
}
