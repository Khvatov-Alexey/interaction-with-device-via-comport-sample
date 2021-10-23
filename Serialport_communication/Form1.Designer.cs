
namespace Serialport_communication
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.аОМЗРИПToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testDeviceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.техническиеУсловияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cRC7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Mess = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.очиститьToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.логКомандToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.voltagebox3 = new Serialport_communication.UserControls.Voltagebox();
            this.voltagebox2 = new Serialport_communication.UserControls.Voltagebox();
            this.voltagebox1 = new Serialport_communication.UserControls.Voltagebox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.indicator1 = new Serialport_communication.UserControls.Indicator();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.voltage_result_box7 = new Serialport_communication.UserControls.Voltage_result_box();
            this.voltage_result_box6 = new Serialport_communication.UserControls.Voltage_result_box();
            this.voltage_result_box5 = new Serialport_communication.UserControls.Voltage_result_box();
            this.voltage_result_box4 = new Serialport_communication.UserControls.Voltage_result_box();
            this.voltage_result_box3 = new Serialport_communication.UserControls.Voltage_result_box();
            this.voltage_result_box2 = new Serialport_communication.UserControls.Voltage_result_box();
            this.voltage_result_box1 = new Serialport_communication.UserControls.Voltage_result_box();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(12)))));
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.аОМЗРИПToolStripMenuItem,
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1018, 43);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // аОМЗРИПToolStripMenuItem
            // 
            this.аОМЗРИПToolStripMenuItem.AutoSize = false;
            this.аОМЗРИПToolStripMenuItem.AutoToolTip = true;
            this.аОМЗРИПToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.аОМЗРИПToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.аОМЗРИПToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.аОМЗРИПToolStripMenuItem.Name = "аОМЗРИПToolStripMenuItem";
            this.аОМЗРИПToolStripMenuItem.Size = new System.Drawing.Size(35, 35);
            this.аОМЗРИПToolStripMenuItem.Text = "АО \"МЗ РИП\"";
            this.аОМЗРИПToolStripMenuItem.ToolTipText = "АО \"МЗ РИП\"";
            this.аОМЗРИПToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem1_Click);
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItem3,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(57, 39);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.очиститьToolStripMenuItem.Text = "Новый";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.открытьToolStripMenuItem.Text = "Открыть";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(188, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testDeviceToolStripMenuItem});
            this.настройкиToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(91, 39);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // testDeviceToolStripMenuItem
            // 
            this.testDeviceToolStripMenuItem.Name = "testDeviceToolStripMenuItem";
            this.testDeviceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.testDeviceToolStripMenuItem.Text = "Устройство";
            this.testDeviceToolStripMenuItem.Click += new System.EventHandler(this.testDeviceToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.техническиеУсловияToolStripMenuItem,
            this.cRC7ToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(75, 39);
            this.оПрограммеToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem1
            // 
            this.оПрограммеToolStripMenuItem1.Name = "оПрограммеToolStripMenuItem1";
            this.оПрограммеToolStripMenuItem1.Size = new System.Drawing.Size(209, 22);
            this.оПрограммеToolStripMenuItem1.Text = "О программе";
            this.оПрограммеToolStripMenuItem1.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(206, 6);
            // 
            // техническиеУсловияToolStripMenuItem
            // 
            this.техническиеУсловияToolStripMenuItem.Name = "техническиеУсловияToolStripMenuItem";
            this.техническиеУсловияToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.техническиеУсловияToolStripMenuItem.Text = "Схема подключения";
            this.техническиеУсловияToolStripMenuItem.Click += new System.EventHandler(this.viewImageToolStripMenuItem_Click);
            // 
            // cRC7ToolStripMenuItem
            // 
            this.cRC7ToolStripMenuItem.Name = "cRC7ToolStripMenuItem";
            this.cRC7ToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
            this.cRC7ToolStripMenuItem.Text = "CRC7";
            this.cRC7ToolStripMenuItem.Click += new System.EventHandler(this.cRC7ToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.Mess);
            this.groupBox4.Location = new System.Drawing.Point(553, 24);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(452, 411);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Сообщения";
            // 
            // Mess
            // 
            this.Mess.ContextMenuStrip = this.contextMenuStrip1;
            this.Mess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Mess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Mess.Location = new System.Drawing.Point(4, 20);
            this.Mess.Margin = new System.Windows.Forms.Padding(4);
            this.Mess.Name = "Mess";
            this.Mess.ReadOnly = true;
            this.Mess.Size = new System.Drawing.Size(444, 387);
            this.Mess.TabIndex = 1;
            this.Mess.TabStop = false;
            this.Mess.Text = "";
            this.Mess.DoubleClick += new System.EventHandler(this.Mess_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem1,
            this.логКомандToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 48);
            // 
            // очиститьToolStripMenuItem1
            // 
            this.очиститьToolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.очиститьToolStripMenuItem1.Name = "очиститьToolStripMenuItem1";
            this.очиститьToolStripMenuItem1.Size = new System.Drawing.Size(138, 22);
            this.очиститьToolStripMenuItem1.Text = "Очистить";
            this.очиститьToolStripMenuItem1.Click += new System.EventHandler(this.очиститьToolStripMenuItem1_Click);
            // 
            // логКомандToolStripMenuItem
            // 
            this.логКомандToolStripMenuItem.CheckOnClick = true;
            this.логКомандToolStripMenuItem.Name = "логКомандToolStripMenuItem";
            this.логКомандToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.логКомандToolStripMenuItem.Text = "Лог команд";
            this.логКомандToolStripMenuItem.Click += new System.EventHandler(this.логКомандToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.voltagebox3);
            this.groupBox2.Controls.Add(this.voltagebox2);
            this.groupBox2.Controls.Add(this.voltagebox1);
            this.groupBox2.Location = new System.Drawing.Point(0, 103);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(262, 158);
            this.groupBox2.TabIndex = 69;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Установка напряжений";
            // 
            // voltagebox3
            // 
            this.voltagebox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voltagebox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voltagebox3.label_text = "+50 В:";
            this.voltagebox3.Location = new System.Drawing.Point(8, 115);
            this.voltagebox3.Margin = new System.Windows.Forms.Padding(4);
            this.voltagebox3.Name = "voltagebox3";
            this.voltagebox3.Size = new System.Drawing.Size(236, 29);
            this.voltagebox3.TabIndex = 3;
            this.voltagebox3.VoltageChanged += new System.EventHandler(this.voltagebox_VoltageChanged);
            // 
            // voltagebox2
            // 
            this.voltagebox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voltagebox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voltagebox2.label_text = "+50 В ДОП:";
            this.voltagebox2.Location = new System.Drawing.Point(8, 78);
            this.voltagebox2.Margin = new System.Windows.Forms.Padding(4);
            this.voltagebox2.Name = "voltagebox2";
            this.voltagebox2.Size = new System.Drawing.Size(236, 29);
            this.voltagebox2.TabIndex = 2;
            this.voltagebox2.VoltageChanged += new System.EventHandler(this.voltagebox_VoltageChanged);
            // 
            // voltagebox1
            // 
            this.voltagebox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voltagebox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.voltagebox1.label_text = "+50 В ОСН:";
            this.voltagebox1.Location = new System.Drawing.Point(8, 41);
            this.voltagebox1.Margin = new System.Windows.Forms.Padding(4);
            this.voltagebox1.Name = "voltagebox1";
            this.voltagebox1.Size = new System.Drawing.Size(236, 29);
            this.voltagebox1.TabIndex = 1;
            this.voltagebox1.VoltageChanged += new System.EventHandler(this.voltagebox_VoltageChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.indicator1);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(532, 95);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Обмен данными";
            // 
            // indicator1
            // 
            this.indicator1.AutoSize = true;
            this.indicator1.color_result = System.Drawing.Color.Silver;
            this.indicator1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.indicator1.label_text = "Связь";
            this.indicator1.Location = new System.Drawing.Point(8, 40);
            this.indicator1.Margin = new System.Windows.Forms.Padding(4);
            this.indicator1.Name = "indicator1";
            this.indicator1.Size = new System.Drawing.Size(109, 25);
            this.indicator1.TabIndex = 4;
            this.indicator1.TabStop = false;
            // 
            // checkBox3
            // 
            this.checkBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox3.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox3.Location = new System.Drawing.Point(197, 37);
            this.checkBox3.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(133, 31);
            this.checkBox3.TabIndex = 1;
            this.checkBox3.Text = "Однократный";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            this.checkBox3.Click += new System.EventHandler(this.checkBox3_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.checkBox2.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkBox2.Location = new System.Drawing.Point(354, 37);
            this.checkBox2.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(133, 31);
            this.checkBox2.TabIndex = 2;
            this.checkBox2.Text = "Циклический";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.groupBox4);
            this.panel7.Controls.Add(this.panel1);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 43);
            this.panel7.Margin = new System.Windows.Forms.Padding(4);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1018, 462);
            this.panel7.TabIndex = 34;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Location = new System.Drawing.Point(13, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 411);
            this.panel1.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.voltage_result_box7);
            this.groupBox1.Controls.Add(this.voltage_result_box6);
            this.groupBox1.Controls.Add(this.voltage_result_box5);
            this.groupBox1.Controls.Add(this.voltage_result_box4);
            this.groupBox1.Controls.Add(this.voltage_result_box3);
            this.groupBox1.Controls.Add(this.voltage_result_box2);
            this.groupBox1.Controls.Add(this.voltage_result_box1);
            this.groupBox1.Location = new System.Drawing.Point(270, 103);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(262, 308);
            this.groupBox1.TabIndex = 71;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Выходные напряжения";
            // 
            // voltage_result_box7
            // 
            this.voltage_result_box7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.voltage_result_box7.label_text = "-12 В:";
            this.voltage_result_box7.Location = new System.Drawing.Point(8, 263);
            this.voltage_result_box7.Margin = new System.Windows.Forms.Padding(4);
            this.voltage_result_box7.Name = "voltage_result_box7";
            this.voltage_result_box7.Size = new System.Drawing.Size(236, 29);
            this.voltage_result_box7.TabIndex = 13;
            this.voltage_result_box7.TabStop = false;
            this.voltage_result_box7.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box7.Value")));
            this.voltage_result_box7.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box6
            // 
            this.voltage_result_box6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.voltage_result_box6.label_text = "+12 В:";
            this.voltage_result_box6.Location = new System.Drawing.Point(8, 226);
            this.voltage_result_box6.Margin = new System.Windows.Forms.Padding(4);
            this.voltage_result_box6.Name = "voltage_result_box6";
            this.voltage_result_box6.Size = new System.Drawing.Size(236, 29);
            this.voltage_result_box6.TabIndex = 12;
            this.voltage_result_box6.TabStop = false;
            this.voltage_result_box6.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box6.Value")));
            this.voltage_result_box6.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box5
            // 
            this.voltage_result_box5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.voltage_result_box5.label_text = "+5 В:";
            this.voltage_result_box5.Location = new System.Drawing.Point(8, 189);
            this.voltage_result_box5.Margin = new System.Windows.Forms.Padding(4);
            this.voltage_result_box5.Name = "voltage_result_box5";
            this.voltage_result_box5.Size = new System.Drawing.Size(236, 29);
            this.voltage_result_box5.TabIndex = 11;
            this.voltage_result_box5.TabStop = false;
            this.voltage_result_box5.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box5.Value")));
            this.voltage_result_box5.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box4
            // 
            this.voltage_result_box4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.voltage_result_box4.label_text = "+300 В:";
            this.voltage_result_box4.Location = new System.Drawing.Point(8, 152);
            this.voltage_result_box4.Margin = new System.Windows.Forms.Padding(4);
            this.voltage_result_box4.Name = "voltage_result_box4";
            this.voltage_result_box4.Size = new System.Drawing.Size(236, 29);
            this.voltage_result_box4.TabIndex = 10;
            this.voltage_result_box4.TabStop = false;
            this.voltage_result_box4.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box4.Value")));
            this.voltage_result_box4.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box3
            // 
            this.voltage_result_box3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.voltage_result_box3.label_text = "+50 В:";
            this.voltage_result_box3.Location = new System.Drawing.Point(8, 115);
            this.voltage_result_box3.Margin = new System.Windows.Forms.Padding(4);
            this.voltage_result_box3.Name = "voltage_result_box3";
            this.voltage_result_box3.Size = new System.Drawing.Size(236, 29);
            this.voltage_result_box3.TabIndex = 9;
            this.voltage_result_box3.TabStop = false;
            this.voltage_result_box3.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box3.Value")));
            this.voltage_result_box3.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box2
            // 
            this.voltage_result_box2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.voltage_result_box2.label_text = "+50 В ДОП:";
            this.voltage_result_box2.Location = new System.Drawing.Point(8, 78);
            this.voltage_result_box2.Margin = new System.Windows.Forms.Padding(4);
            this.voltage_result_box2.Name = "voltage_result_box2";
            this.voltage_result_box2.Size = new System.Drawing.Size(236, 29);
            this.voltage_result_box2.TabIndex = 8;
            this.voltage_result_box2.TabStop = false;
            this.voltage_result_box2.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box2.Value")));
            this.voltage_result_box2.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box1
            // 
            this.voltage_result_box1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.voltage_result_box1.label_text = "+50 В ОСН:";
            this.voltage_result_box1.Location = new System.Drawing.Point(8, 41);
            this.voltage_result_box1.Margin = new System.Windows.Forms.Padding(4);
            this.voltage_result_box1.Name = "voltage_result_box1";
            this.voltage_result_box1.Size = new System.Drawing.Size(236, 29);
            this.voltage_result_box1.TabIndex = 7;
            this.voltage_result_box1.TabStop = false;
            this.voltage_result_box1.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box1.Value")));
            this.voltage_result_box1.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(196)))), ((int)(((byte)(205)))));
            this.ClientSize = new System.Drawing.Size(1018, 505);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Device dashboard";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem аОМЗРИПToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testDeviceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem техническиеУсловияToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.RichTextBox Mess;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private UserControls.Voltagebox voltagebox1;
        private UserControls.Voltagebox voltagebox3;
        private UserControls.Voltagebox voltagebox2;
        private UserControls.Voltage_result_box voltage_result_box1;
        private UserControls.Voltage_result_box voltage_result_box7;
        private UserControls.Voltage_result_box voltage_result_box6;
        private UserControls.Voltage_result_box voltage_result_box5;
        private UserControls.Voltage_result_box voltage_result_box4;
        private UserControls.Voltage_result_box voltage_result_box3;
        private UserControls.Voltage_result_box voltage_result_box2;
        private UserControls.Indicator indicator1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem логКомандToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem cRC7ToolStripMenuItem;
    }
}

