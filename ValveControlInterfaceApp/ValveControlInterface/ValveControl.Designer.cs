namespace ValveControl
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zg1 = new ZedGraph.ZedGraphControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.cboData = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cboStop = new System.Windows.Forms.ComboBox();
            this.cmdSend = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDbuffer = new System.Windows.Forms.ComboBox();
            this.cboSamRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboParity = new System.Windows.Forms.ComboBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.cboBaud = new System.Windows.Forms.ComboBox();
            this.cboPort = new System.Windows.Forms.ComboBox();
            this.cmdOpen = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbstatus = new System.Windows.Forms.TextBox();
            this.tbDutyCycle = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbFreq = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbAmp = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cboInput = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btoRcvData = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Port = new System.IO.Ports.SerialPort(this.components);
            this.btoStopRcvData = new System.Windows.Forms.Button();
            this.cmdSControl = new System.Windows.Forms.Button();
            this.tboPGain = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmdControl = new System.Windows.Forms.Button();
            this.tboDGain = new System.Windows.Forms.TextBox();
            this.tboIGain = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // zg1
            // 
            this.zg1.Location = new System.Drawing.Point(229, 12);
            this.zg1.Name = "zg1";
            this.zg1.ScrollGrace = 0;
            this.zg1.ScrollMaxX = 0;
            this.zg1.ScrollMaxY = 0;
            this.zg1.ScrollMaxY2 = 0;
            this.zg1.ScrollMinX = 0;
            this.zg1.ScrollMinY = 0;
            this.zg1.ScrollMinY2 = 0;
            this.zg1.Size = new System.Drawing.Size(409, 275);
            this.zg1.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // cboData
            // 
            this.cboData.FormattingEnabled = true;
            this.cboData.Items.AddRange(new object[] {
            "7",
            "8",
            "9"});
            this.cboData.Location = new System.Drawing.Point(8, 210);
            this.cboData.Name = "cboData";
            this.cboData.Size = new System.Drawing.Size(79, 21);
            this.cboData.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Stop Bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Data Bits";
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(6, 57);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(102, 32);
            this.cmdClose.TabIndex = 5;
            this.cmdClose.Text = "Close Port";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click_1);
            // 
            // cboStop
            // 
            this.cboStop.FormattingEnabled = true;
            this.cboStop.Location = new System.Drawing.Point(8, 170);
            this.cboStop.Name = "cboStop";
            this.cboStop.Size = new System.Drawing.Size(79, 21);
            this.cboStop.TabIndex = 13;
            // 
            // cmdSend
            // 
            this.cmdSend.Location = new System.Drawing.Point(6, 179);
            this.cmdSend.Name = "cmdSend";
            this.cmdSend.Size = new System.Drawing.Size(102, 36);
            this.cmdSend.TabIndex = 5;
            this.cmdSend.Text = "Send";
            this.cmdSend.UseVisualStyleBackColor = true;
            this.cmdSend.Click += new System.EventHandler(this.cmdSend_Click_1);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Parity";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.cboDbuffer);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.cboSamRate);
            this.groupBox2.Controls.Add(this.cboData);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cboStop);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cboParity);
            this.groupBox2.Controls.Add(this.Label1);
            this.groupBox2.Controls.Add(this.cboBaud);
            this.groupBox2.Controls.Add(this.cboPort);
            this.groupBox2.Location = new System.Drawing.Point(12, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(94, 331);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Serial Com Settings";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(71, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Sample Rate ";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 274);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 13);
            this.label7.TabIndex = 22;
            this.label7.Text = "Data Buffer";
            // 
            // cboDbuffer
            // 
            this.cboDbuffer.FormattingEnabled = true;
            this.cboDbuffer.Location = new System.Drawing.Point(8, 290);
            this.cboDbuffer.Name = "cboDbuffer";
            this.cboDbuffer.Size = new System.Drawing.Size(79, 21);
            this.cboDbuffer.TabIndex = 21;
            // 
            // cboSamRate
            // 
            this.cboSamRate.FormattingEnabled = true;
            this.cboSamRate.Location = new System.Drawing.Point(8, 250);
            this.cboSamRate.Name = "cboSamRate";
            this.cboSamRate.Size = new System.Drawing.Size(79, 21);
            this.cboSamRate.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Baud Rate";
            // 
            // cboParity
            // 
            this.cboParity.FormattingEnabled = true;
            this.cboParity.Location = new System.Drawing.Point(8, 130);
            this.cboParity.Name = "cboParity";
            this.cboParity.Size = new System.Drawing.Size(79, 21);
            this.cboParity.TabIndex = 12;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(8, 34);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(26, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Text = "Port";
            // 
            // cboBaud
            // 
            this.cboBaud.FormattingEnabled = true;
            this.cboBaud.Items.AddRange(new object[] {
            "300",
            "600",
            "1200",
            "2400",
            "4800",
            "9600",
            "14400",
            "28800",
            "36000",
            "115000"});
            this.cboBaud.Location = new System.Drawing.Point(8, 90);
            this.cboBaud.Name = "cboBaud";
            this.cboBaud.Size = new System.Drawing.Size(79, 21);
            this.cboBaud.TabIndex = 11;
            // 
            // cboPort
            // 
            this.cboPort.FormattingEnabled = true;
            this.cboPort.Location = new System.Drawing.Point(8, 50);
            this.cboPort.Name = "cboPort";
            this.cboPort.Size = new System.Drawing.Size(79, 21);
            this.cboPort.TabIndex = 10;
            // 
            // cmdOpen
            // 
            this.cmdOpen.Location = new System.Drawing.Point(6, 19);
            this.cmdOpen.Name = "cmdOpen";
            this.cmdOpen.Size = new System.Drawing.Size(102, 32);
            this.cmdOpen.TabIndex = 8;
            this.cmdOpen.Text = "Open Port";
            this.cmdOpen.UseVisualStyleBackColor = true;
            this.cmdOpen.Click += new System.EventHandler(this.cmdOpen_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(293, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tbDutyCycle);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.tbFreq);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.tbAmp);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.cboInput);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.cmdSend);
            this.groupBox3.Location = new System.Drawing.Point(109, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(114, 220);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Input to Serial Port";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(644, 226);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(94, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Arduino Feedback";
            // 
            // tbstatus
            // 
            this.tbstatus.Location = new System.Drawing.Point(644, 242);
            this.tbstatus.Multiline = true;
            this.tbstatus.Name = "tbstatus";
            this.tbstatus.Size = new System.Drawing.Size(90, 105);
            this.tbstatus.TabIndex = 14;
            // 
            // tbDutyCycle
            // 
            this.tbDutyCycle.Location = new System.Drawing.Point(6, 152);
            this.tbDutyCycle.MaxLength = 5;
            this.tbDutyCycle.Name = "tbDutyCycle";
            this.tbDutyCycle.Size = new System.Drawing.Size(102, 20);
            this.tbDutyCycle.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 136);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Duty Cycle";
            // 
            // tbFreq
            // 
            this.tbFreq.Location = new System.Drawing.Point(6, 115);
            this.tbFreq.MaxLength = 5;
            this.tbFreq.Name = "tbFreq";
            this.tbFreq.Size = new System.Drawing.Size(102, 20);
            this.tbFreq.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 99);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(79, 13);
            this.label11.TabIndex = 10;
            this.label11.Text = "Frequency (Hz)";
            // 
            // tbAmp
            // 
            this.tbAmp.Location = new System.Drawing.Point(6, 76);
            this.tbAmp.MaxLength = 5;
            this.tbAmp.Name = "tbAmp";
            this.tbAmp.Size = new System.Drawing.Size(102, 20);
            this.tbAmp.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Amplitud";
            // 
            // cboInput
            // 
            this.cboInput.FormattingEnabled = true;
            this.cboInput.Items.AddRange(new object[] {
            "Constant",
            "Sine Waveform",
            "Rectangular Waveform"});
            this.cboInput.Location = new System.Drawing.Point(6, 36);
            this.cboInput.Name = "cboInput";
            this.cboInput.Size = new System.Drawing.Size(102, 21);
            this.cboInput.TabIndex = 7;
            this.cboInput.SelectedIndexChanged += new System.EventHandler(this.cboInput_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Select Input";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(299, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 12;
            this.label8.Text = "Current Pressure";
            // 
            // btoRcvData
            // 
            this.btoRcvData.Location = new System.Drawing.Point(6, 13);
            this.btoRcvData.Name = "btoRcvData";
            this.btoRcvData.Size = new System.Drawing.Size(99, 36);
            this.btoRcvData.TabIndex = 13;
            this.btoRcvData.Text = "Receive Data";
            this.btoRcvData.UseVisualStyleBackColor = true;
            this.btoRcvData.Click += new System.EventHandler(this.btoRcvData_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cmdOpen);
            this.groupBox1.Controls.Add(this.cmdClose);
            this.groupBox1.Location = new System.Drawing.Point(109, 242);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(114, 105);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Port Control";
            // 
            // Port
            // 
            this.Port.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.Port_DataReceived);
            // 
            // btoStopRcvData
            // 
            this.btoStopRcvData.Location = new System.Drawing.Point(122, 13);
            this.btoStopRcvData.Name = "btoStopRcvData";
            this.btoStopRcvData.Size = new System.Drawing.Size(99, 36);
            this.btoStopRcvData.TabIndex = 15;
            this.btoStopRcvData.Text = "Stop Receving Data";
            this.btoStopRcvData.UseVisualStyleBackColor = true;
            this.btoStopRcvData.Click += new System.EventHandler(this.btoStopRcvData_Click);
            // 
            // cmdSControl
            // 
            this.cmdSControl.Location = new System.Drawing.Point(6, 169);
            this.cmdSControl.Name = "cmdSControl";
            this.cmdSControl.Size = new System.Drawing.Size(79, 28);
            this.cmdSControl.TabIndex = 16;
            this.cmdSControl.Text = "Stop Control";
            this.cmdSControl.UseVisualStyleBackColor = true;
            this.cmdSControl.Click += new System.EventHandler(this.cmdSControl_Click);
            // 
            // tboPGain
            // 
            this.tboPGain.Location = new System.Drawing.Point(6, 32);
            this.tboPGain.MaxLength = 5;
            this.tboPGain.Name = "tboPGain";
            this.tboPGain.Size = new System.Drawing.Size(79, 20);
            this.tboPGain.TabIndex = 19;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(36, 13);
            this.label16.TabIndex = 18;
            this.label16.Text = "PGain";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.cmdControl);
            this.groupBox4.Controls.Add(this.tboDGain);
            this.groupBox4.Controls.Add(this.cmdSControl);
            this.groupBox4.Controls.Add(this.tboIGain);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.tboPGain);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Location = new System.Drawing.Point(644, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(93, 207);
            this.groupBox4.TabIndex = 24;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Controller";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(37, 13);
            this.label13.TabIndex = 31;
            this.label13.Text = "DGain";
            // 
            // cmdControl
            // 
            this.cmdControl.Location = new System.Drawing.Point(6, 134);
            this.cmdControl.Name = "cmdControl";
            this.cmdControl.Size = new System.Drawing.Size(79, 29);
            this.cmdControl.TabIndex = 29;
            this.cmdControl.Text = "Control";
            this.cmdControl.UseVisualStyleBackColor = true;
            this.cmdControl.Click += new System.EventHandler(this.cmdControl_Click);
            // 
            // tboDGain
            // 
            this.tboDGain.Location = new System.Drawing.Point(6, 110);
            this.tboDGain.MaxLength = 5;
            this.tboDGain.Name = "tboDGain";
            this.tboDGain.Size = new System.Drawing.Size(79, 20);
            this.tboDGain.TabIndex = 28;
            // 
            // tboIGain
            // 
            this.tboIGain.Location = new System.Drawing.Point(6, 71);
            this.tboIGain.MaxLength = 5;
            this.tboIGain.Name = "tboIGain";
            this.tboIGain.Size = new System.Drawing.Size(79, 20);
            this.tboIGain.TabIndex = 26;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 55);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(32, 13);
            this.label15.TabIndex = 25;
            this.label15.Text = "IGain";
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btoStopRcvData);
            this.groupBox5.Controls.Add(this.btoRcvData);
            this.groupBox5.Controls.Add(this.textBox1);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Location = new System.Drawing.Point(229, 293);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(409, 54);
            this.groupBox5.TabIndex = 25;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Graph ";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 351);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.tbstatus);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.zg1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl zg1;
        private System.Windows.Forms.Timer timer1;
        /// <summary>
        /// 
        /// </summary>
        private System.Windows.Forms.ComboBox cboData;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.ComboBox cboStop;
        private System.Windows.Forms.Button cmdSend;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboParity;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ComboBox cboBaud;
        private System.Windows.Forms.ComboBox cboPort;
        private System.Windows.Forms.Button cmdOpen;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDbuffer;
        private System.Windows.Forms.ComboBox cboSamRate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboInput;
        private System.Windows.Forms.TextBox tbDutyCycle;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbFreq;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbAmp;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbstatus;
        private System.Windows.Forms.Button btoRcvData;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.IO.Ports.SerialPort Port;
        private System.Windows.Forms.Button btoStopRcvData;
        private System.Windows.Forms.Button cmdSControl;
        private System.Windows.Forms.TextBox tboPGain;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox tboDGain;
        private System.Windows.Forms.TextBox tboIGain;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button cmdControl;
        private System.Windows.Forms.Label label13;
    }
}

