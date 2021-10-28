
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
            this.языкToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.русскийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.английскийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(11)))), ((int)(((byte)(12)))));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.аОМЗРИПToolStripMenuItem,
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.оПрограммеToolStripMenuItem,
            this.языкToolStripMenuItem});
            this.menuStrip1.Name = "menuStrip1";
            // 
            // аОМЗРИПToolStripMenuItem
            // 
            resources.ApplyResources(this.аОМЗРИПToolStripMenuItem, "аОМЗРИПToolStripMenuItem");
            this.аОМЗРИПToolStripMenuItem.AutoToolTip = true;
            this.аОМЗРИПToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.аОМЗРИПToolStripMenuItem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.аОМЗРИПToolStripMenuItem.Name = "аОМЗРИПToolStripMenuItem";
            this.аОМЗРИПToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem1_Click);
            // 
            // файлToolStripMenuItem
            // 
            resources.ApplyResources(this.файлToolStripMenuItem, "файлToolStripMenuItem");
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem,
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.toolStripMenuItem3,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            // 
            // очиститьToolStripMenuItem
            // 
            resources.ApplyResources(this.очиститьToolStripMenuItem, "очиститьToolStripMenuItem");
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Click += new System.EventHandler(this.очиститьToolStripMenuItem_Click);
            // 
            // открытьToolStripMenuItem
            // 
            resources.ApplyResources(this.открытьToolStripMenuItem, "открытьToolStripMenuItem");
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            resources.ApplyResources(this.сохранитьToolStripMenuItem, "сохранитьToolStripMenuItem");
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            resources.ApplyResources(this.toolStripMenuItem3, "toolStripMenuItem3");
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            // 
            // выходToolStripMenuItem
            // 
            resources.ApplyResources(this.выходToolStripMenuItem, "выходToolStripMenuItem");
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            resources.ApplyResources(this.настройкиToolStripMenuItem, "настройкиToolStripMenuItem");
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testDeviceToolStripMenuItem});
            this.настройкиToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            // 
            // testDeviceToolStripMenuItem
            // 
            resources.ApplyResources(this.testDeviceToolStripMenuItem, "testDeviceToolStripMenuItem");
            this.testDeviceToolStripMenuItem.Name = "testDeviceToolStripMenuItem";
            this.testDeviceToolStripMenuItem.Click += new System.EventHandler(this.testDeviceToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            resources.ApplyResources(this.оПрограммеToolStripMenuItem, "оПрограммеToolStripMenuItem");
            this.оПрограммеToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem1,
            this.toolStripMenuItem5,
            this.техническиеУсловияToolStripMenuItem,
            this.cRC7ToolStripMenuItem});
            this.оПрограммеToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            // 
            // оПрограммеToolStripMenuItem1
            // 
            resources.ApplyResources(this.оПрограммеToolStripMenuItem1, "оПрограммеToolStripMenuItem1");
            this.оПрограммеToolStripMenuItem1.Name = "оПрограммеToolStripMenuItem1";
            this.оПрограммеToolStripMenuItem1.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem5
            // 
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            // 
            // техническиеУсловияToolStripMenuItem
            // 
            resources.ApplyResources(this.техническиеУсловияToolStripMenuItem, "техническиеУсловияToolStripMenuItem");
            this.техническиеУсловияToolStripMenuItem.Name = "техническиеУсловияToolStripMenuItem";
            this.техническиеУсловияToolStripMenuItem.Click += new System.EventHandler(this.viewImageToolStripMenuItem_Click);
            // 
            // cRC7ToolStripMenuItem
            // 
            resources.ApplyResources(this.cRC7ToolStripMenuItem, "cRC7ToolStripMenuItem");
            this.cRC7ToolStripMenuItem.Name = "cRC7ToolStripMenuItem";
            this.cRC7ToolStripMenuItem.Click += new System.EventHandler(this.cRC7ToolStripMenuItem_Click);
            // 
            // языкToolStripMenuItem
            // 
            resources.ApplyResources(this.языкToolStripMenuItem, "языкToolStripMenuItem");
            this.языкToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.русскийToolStripMenuItem,
            this.английскийToolStripMenuItem});
            this.языкToolStripMenuItem.Name = "языкToolStripMenuItem";
            // 
            // русскийToolStripMenuItem
            // 
            resources.ApplyResources(this.русскийToolStripMenuItem, "русскийToolStripMenuItem");
            this.русскийToolStripMenuItem.Checked = true;
            this.русскийToolStripMenuItem.CheckOnClick = true;
            this.русскийToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.русскийToolStripMenuItem.Name = "русскийToolStripMenuItem";
            this.русскийToolStripMenuItem.CheckedChanged += new System.EventHandler(this.languageToolStripMenuItem_CheckedChanged);
            this.русскийToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // английскийToolStripMenuItem
            // 
            resources.ApplyResources(this.английскийToolStripMenuItem, "английскийToolStripMenuItem");
            this.английскийToolStripMenuItem.CheckOnClick = true;
            this.английскийToolStripMenuItem.Name = "английскийToolStripMenuItem";
            this.английскийToolStripMenuItem.CheckedChanged += new System.EventHandler(this.languageToolStripMenuItem_CheckedChanged);
            this.английскийToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.Mess);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // Mess
            // 
            resources.ApplyResources(this.Mess, "Mess");
            this.Mess.ContextMenuStrip = this.contextMenuStrip1;
            this.Mess.Name = "Mess";
            this.Mess.ReadOnly = true;
            this.Mess.TabStop = false;
            this.Mess.DoubleClick += new System.EventHandler(this.Mess_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.очиститьToolStripMenuItem1,
            this.логКомандToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            // 
            // очиститьToolStripMenuItem1
            // 
            resources.ApplyResources(this.очиститьToolStripMenuItem1, "очиститьToolStripMenuItem1");
            this.очиститьToolStripMenuItem1.Name = "очиститьToolStripMenuItem1";
            this.очиститьToolStripMenuItem1.Click += new System.EventHandler(this.очиститьToolStripMenuItem1_Click);
            // 
            // логКомандToolStripMenuItem
            // 
            resources.ApplyResources(this.логКомандToolStripMenuItem, "логКомандToolStripMenuItem");
            this.логКомандToolStripMenuItem.CheckOnClick = true;
            this.логКомандToolStripMenuItem.Name = "логКомандToolStripMenuItem";
            this.логКомандToolStripMenuItem.Click += new System.EventHandler(this.логКомандToolStripMenuItem_Click);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.voltagebox3);
            this.groupBox2.Controls.Add(this.voltagebox2);
            this.groupBox2.Controls.Add(this.voltagebox1);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // voltagebox3
            // 
            resources.ApplyResources(this.voltagebox3, "voltagebox3");
            this.voltagebox3.Name = "voltagebox3";
            this.voltagebox3.VoltageChanged += new System.EventHandler(this.voltagebox_VoltageChanged);
            // 
            // voltagebox2
            // 
            resources.ApplyResources(this.voltagebox2, "voltagebox2");
            this.voltagebox2.Name = "voltagebox2";
            this.voltagebox2.VoltageChanged += new System.EventHandler(this.voltagebox_VoltageChanged);
            // 
            // voltagebox1
            // 
            resources.ApplyResources(this.voltagebox1, "voltagebox1");
            this.voltagebox1.Name = "voltagebox1";
            this.voltagebox1.VoltageChanged += new System.EventHandler(this.voltagebox_VoltageChanged);
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.indicator1);
            this.groupBox3.Controls.Add(this.checkBox3);
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // indicator1
            // 
            resources.ApplyResources(this.indicator1, "indicator1");
            this.indicator1.color_result = System.Drawing.Color.Silver;
            this.indicator1.Name = "indicator1";
            this.indicator1.TabStop = false;
            // 
            // checkBox3
            // 
            resources.ApplyResources(this.checkBox3, "checkBox3");
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            this.checkBox3.Click += new System.EventHandler(this.checkBox3_Click);
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            this.checkBox2.Click += new System.EventHandler(this.checkBox2_Click);
            // 
            // panel7
            // 
            resources.ApplyResources(this.panel7, "panel7");
            this.panel7.Controls.Add(this.groupBox4);
            this.panel7.Controls.Add(this.panel1);
            this.panel7.Name = "panel7";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.groupBox3);
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Name = "panel1";
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.voltage_result_box7);
            this.groupBox1.Controls.Add(this.voltage_result_box6);
            this.groupBox1.Controls.Add(this.voltage_result_box5);
            this.groupBox1.Controls.Add(this.voltage_result_box4);
            this.groupBox1.Controls.Add(this.voltage_result_box3);
            this.groupBox1.Controls.Add(this.voltage_result_box2);
            this.groupBox1.Controls.Add(this.voltage_result_box1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // voltage_result_box7
            // 
            resources.ApplyResources(this.voltage_result_box7, "voltage_result_box7");
            this.voltage_result_box7.Name = "voltage_result_box7";
            this.voltage_result_box7.TabStop = false;
            this.voltage_result_box7.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box7.Value")));
            this.voltage_result_box7.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box6
            // 
            resources.ApplyResources(this.voltage_result_box6, "voltage_result_box6");
            this.voltage_result_box6.Name = "voltage_result_box6";
            this.voltage_result_box6.TabStop = false;
            this.voltage_result_box6.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box6.Value")));
            this.voltage_result_box6.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box5
            // 
            resources.ApplyResources(this.voltage_result_box5, "voltage_result_box5");
            this.voltage_result_box5.Name = "voltage_result_box5";
            this.voltage_result_box5.TabStop = false;
            this.voltage_result_box5.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box5.Value")));
            this.voltage_result_box5.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box4
            // 
            resources.ApplyResources(this.voltage_result_box4, "voltage_result_box4");
            this.voltage_result_box4.Name = "voltage_result_box4";
            this.voltage_result_box4.TabStop = false;
            this.voltage_result_box4.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box4.Value")));
            this.voltage_result_box4.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box3
            // 
            resources.ApplyResources(this.voltage_result_box3, "voltage_result_box3");
            this.voltage_result_box3.Name = "voltage_result_box3";
            this.voltage_result_box3.TabStop = false;
            this.voltage_result_box3.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box3.Value")));
            this.voltage_result_box3.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box2
            // 
            resources.ApplyResources(this.voltage_result_box2, "voltage_result_box2");
            this.voltage_result_box2.Name = "voltage_result_box2";
            this.voltage_result_box2.TabStop = false;
            this.voltage_result_box2.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box2.Value")));
            this.voltage_result_box2.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // voltage_result_box1
            // 
            resources.ApplyResources(this.voltage_result_box1, "voltage_result_box1");
            this.voltage_result_box1.Name = "voltage_result_box1";
            this.voltage_result_box1.TabStop = false;
            this.voltage_result_box1.Value = ((System.Tuple<System.Nullable<double>, bool>)(resources.GetObject("voltage_result_box1.Value")));
            this.voltage_result_box1.ValueChanged += new System.EventHandler(this.voltage_result_box_ValueChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            resources.ApplyResources(this.openFileDialog1, "openFileDialog1");
            // 
            // saveFileDialog1
            // 
            resources.ApplyResources(this.saveFileDialog1, "saveFileDialog1");
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(183)))), ((int)(((byte)(196)))), ((int)(((byte)(205)))));
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private System.Windows.Forms.ToolStripMenuItem языкToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem русскийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem английскийToolStripMenuItem;
    }
}

