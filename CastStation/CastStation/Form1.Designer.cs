namespace CastStation
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIpAddr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupSettings = new System.Windows.Forms.GroupBox();
            this.label20 = new System.Windows.Forms.Label();
            this.txtSenName = new System.Windows.Forms.TextBox();
            this.txtSenAttr3 = new System.Windows.Forms.TextBox();
            this.txtSenAttr2 = new System.Windows.Forms.TextBox();
            this.txtSenAttr1 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnGetTerm = new System.Windows.Forms.Button();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPwd = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsr = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtTerm = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUdpPort = new System.Windows.Forms.NumericUpDown();
            this.txtTcpPort = new System.Windows.Forms.NumericUpDown();
            this.txtVol = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.labelTimerOutput = new System.Windows.Forms.Label();
            this.labelTimerStatus = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.btnDisableTimer = new System.Windows.Forms.Button();
            this.btnEnableTimer = new System.Windows.Forms.Button();
            this.btnGetCurrentTime = new System.Windows.Forms.Button();
            this.txtSchdTime = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnHide = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.btnLockUI = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnUnlockUI = new System.Windows.Forms.Button();
            this.txtUILockPwd = new System.Windows.Forms.TextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUdpPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTcpPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVol)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server IP:";
            // 
            // txtIpAddr
            // 
            this.txtIpAddr.Location = new System.Drawing.Point(123, 22);
            this.txtIpAddr.Name = "txtIpAddr";
            this.txtIpAddr.Size = new System.Drawing.Size(152, 22);
            this.txtIpAddr.TabIndex = 1;
            this.txtIpAddr.Text = "192.168.8.10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "TCP Port:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(47, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "UDP Port:";
            // 
            // groupSettings
            // 
            this.groupSettings.Controls.Add(this.label20);
            this.groupSettings.Controls.Add(this.txtSenName);
            this.groupSettings.Controls.Add(this.txtSenAttr3);
            this.groupSettings.Controls.Add(this.txtSenAttr2);
            this.groupSettings.Controls.Add(this.txtSenAttr1);
            this.groupSettings.Controls.Add(this.label9);
            this.groupSettings.Controls.Add(this.txtFileName);
            this.groupSettings.Controls.Add(this.btnGetTerm);
            this.groupSettings.Controls.Add(this.btnOpenFile);
            this.groupSettings.Controls.Add(this.label8);
            this.groupSettings.Controls.Add(this.txtPwd);
            this.groupSettings.Controls.Add(this.label7);
            this.groupSettings.Controls.Add(this.txtUsr);
            this.groupSettings.Controls.Add(this.label5);
            this.groupSettings.Controls.Add(this.txtTerm);
            this.groupSettings.Controls.Add(this.label4);
            this.groupSettings.Controls.Add(this.txtUdpPort);
            this.groupSettings.Controls.Add(this.txtTcpPort);
            this.groupSettings.Controls.Add(this.txtVol);
            this.groupSettings.Controls.Add(this.label1);
            this.groupSettings.Controls.Add(this.label3);
            this.groupSettings.Controls.Add(this.label6);
            this.groupSettings.Controls.Add(this.txtIpAddr);
            this.groupSettings.Controls.Add(this.label2);
            this.groupSettings.Location = new System.Drawing.Point(12, 12);
            this.groupSettings.Name = "groupSettings";
            this.groupSettings.Size = new System.Drawing.Size(297, 463);
            this.groupSettings.TabIndex = 6;
            this.groupSettings.TabStop = false;
            this.groupSettings.Text = "Settings";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(19, 323);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(98, 14);
            this.label20.TabIndex = 42;
            this.label20.Text = "Session Name:";
            // 
            // txtSenName
            // 
            this.txtSenName.Location = new System.Drawing.Point(123, 320);
            this.txtSenName.Name = "txtSenName";
            this.txtSenName.Size = new System.Drawing.Size(152, 22);
            this.txtSenName.TabIndex = 41;
            this.txtSenName.Text = "csstd";
            // 
            // txtSenAttr3
            // 
            this.txtSenAttr3.Location = new System.Drawing.Point(225, 348);
            this.txtSenAttr3.Name = "txtSenAttr3";
            this.txtSenAttr3.Size = new System.Drawing.Size(45, 22);
            this.txtSenAttr3.TabIndex = 34;
            this.txtSenAttr3.Text = "1";
            // 
            // txtSenAttr2
            // 
            this.txtSenAttr2.Location = new System.Drawing.Point(174, 348);
            this.txtSenAttr2.Name = "txtSenAttr2";
            this.txtSenAttr2.Size = new System.Drawing.Size(45, 22);
            this.txtSenAttr2.TabIndex = 33;
            this.txtSenAttr2.Text = "400";
            // 
            // txtSenAttr1
            // 
            this.txtSenAttr1.Location = new System.Drawing.Point(123, 348);
            this.txtSenAttr1.Name = "txtSenAttr1";
            this.txtSenAttr1.Size = new System.Drawing.Size(45, 22);
            this.txtSenAttr1.TabIndex = 32;
            this.txtSenAttr1.Text = "65794";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(98, 14);
            this.label9.TabIndex = 31;
            this.label9.Text = "Session Attr:";
            // 
            // txtFileName
            // 
            this.txtFileName.Enabled = false;
            this.txtFileName.Location = new System.Drawing.Point(123, 263);
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(152, 22);
            this.txtFileName.TabIndex = 30;
            // 
            // btnGetTerm
            // 
            this.btnGetTerm.Location = new System.Drawing.Point(42, 234);
            this.btnGetTerm.Name = "btnGetTerm";
            this.btnGetTerm.Size = new System.Drawing.Size(75, 23);
            this.btnGetTerm.TabIndex = 7;
            this.btnGetTerm.Text = "TermList";
            this.btnGetTerm.UseVisualStyleBackColor = true;
            this.btnGetTerm.Click += new System.EventHandler(this.btnGetTermInfo_Click);
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(200, 291);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 9;
            this.btnOpenFile.Text = "Open...";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(75, 266);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 14);
            this.label8.TabIndex = 10;
            this.label8.Text = "File:";
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(123, 135);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(152, 22);
            this.txtPwd.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(40, 194);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 4;
            this.label7.Text = "Terminals:";
            // 
            // txtUsr
            // 
            this.txtUsr.Location = new System.Drawing.Point(123, 107);
            this.txtUsr.Name = "txtUsr";
            this.txtUsr.Size = new System.Drawing.Size(152, 22);
            this.txtUsr.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(47, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 14);
            this.label5.TabIndex = 7;
            this.label5.Text = "Password:";
            // 
            // txtTerm
            // 
            this.txtTerm.Location = new System.Drawing.Point(123, 191);
            this.txtTerm.Multiline = true;
            this.txtTerm.Name = "txtTerm";
            this.txtTerm.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTerm.Size = new System.Drawing.Size(152, 66);
            this.txtTerm.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(47, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 14);
            this.label4.TabIndex = 6;
            this.label4.Text = "Username:";
            // 
            // txtUdpPort
            // 
            this.txtUdpPort.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtUdpPort.Location = new System.Drawing.Point(123, 79);
            this.txtUdpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtUdpPort.Name = "txtUdpPort";
            this.txtUdpPort.Size = new System.Drawing.Size(86, 22);
            this.txtUdpPort.TabIndex = 3;
            this.txtUdpPort.Value = new decimal(new int[] {
            15001,
            0,
            0,
            0});
            // 
            // txtTcpPort
            // 
            this.txtTcpPort.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.txtTcpPort.Location = new System.Drawing.Point(123, 51);
            this.txtTcpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.txtTcpPort.Name = "txtTcpPort";
            this.txtTcpPort.Size = new System.Drawing.Size(86, 22);
            this.txtTcpPort.TabIndex = 2;
            this.txtTcpPort.Value = new decimal(new int[] {
            8000,
            0,
            0,
            0});
            // 
            // txtVol
            // 
            this.txtVol.Location = new System.Drawing.Point(123, 163);
            this.txtVol.Name = "txtVol";
            this.txtVol.Size = new System.Drawing.Size(63, 22);
            this.txtVol.TabIndex = 6;
            this.txtVol.Value = new decimal(new int[] {
            23,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(61, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 14);
            this.label6.TabIndex = 6;
            this.label6.Text = "Volume:";
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(301, 21);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(65, 45);
            this.btnClearLog.TabIndex = 18;
            this.btnClearLog.Text = "Clear";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // txtLog
            // 
            this.txtLog.Location = new System.Drawing.Point(315, 373);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(372, 265);
            this.txtLog.TabIndex = 31;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(77, 21);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(65, 45);
            this.btnStop.TabIndex = 17;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(6, 21);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(65, 45);
            this.btnStart.TabIndex = 16;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("黑体", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(148, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 48);
            this.label10.TabIndex = 17;
            this.label10.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(42, 14);
            this.label12.TabIndex = 19;
            this.label12.Text = "Time:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.labelTimerOutput);
            this.groupBox1.Controls.Add(this.labelTimerStatus);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.btnDisableTimer);
            this.groupBox1.Controls.Add(this.btnEnableTimer);
            this.groupBox1.Controls.Add(this.btnGetCurrentTime);
            this.groupBox1.Controls.Add(this.txtSchdTime);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(12, 481);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(297, 185);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Scheduled Task";
            // 
            // labelTimerOutput
            // 
            this.labelTimerOutput.AutoSize = true;
            this.labelTimerOutput.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerOutput.Location = new System.Drawing.Point(120, 125);
            this.labelTimerOutput.Name = "labelTimerOutput";
            this.labelTimerOutput.Size = new System.Drawing.Size(105, 14);
            this.labelTimerOutput.TabIndex = 27;
            this.labelTimerOutput.Text = "Not Running...";
            // 
            // labelTimerStatus
            // 
            this.labelTimerStatus.AutoSize = true;
            this.labelTimerStatus.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTimerStatus.ForeColor = System.Drawing.Color.Red;
            this.labelTimerStatus.Location = new System.Drawing.Point(117, 95);
            this.labelTimerStatus.Name = "labelTimerStatus";
            this.labelTimerStatus.Size = new System.Drawing.Size(72, 17);
            this.labelTimerStatus.TabIndex = 26;
            this.labelTimerStatus.Text = "Disabled";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(13, 125);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 14);
            this.label14.TabIndex = 25;
            this.label14.Text = "Last Output: ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(105, 14);
            this.label13.TabIndex = 24;
            this.label13.Text = "Timer Status: ";
            // 
            // btnDisableTimer
            // 
            this.btnDisableTimer.Enabled = false;
            this.btnDisableTimer.Location = new System.Drawing.Point(134, 56);
            this.btnDisableTimer.Name = "btnDisableTimer";
            this.btnDisableTimer.Size = new System.Drawing.Size(75, 23);
            this.btnDisableTimer.TabIndex = 15;
            this.btnDisableTimer.Text = "Disable";
            this.btnDisableTimer.UseVisualStyleBackColor = true;
            this.btnDisableTimer.Click += new System.EventHandler(this.btnDisableTimer_Click);
            // 
            // btnEnableTimer
            // 
            this.btnEnableTimer.Location = new System.Drawing.Point(53, 55);
            this.btnEnableTimer.Name = "btnEnableTimer";
            this.btnEnableTimer.Size = new System.Drawing.Size(75, 23);
            this.btnEnableTimer.TabIndex = 14;
            this.btnEnableTimer.Text = "Enable";
            this.btnEnableTimer.UseVisualStyleBackColor = true;
            this.btnEnableTimer.Click += new System.EventHandler(this.btnEnableTimer_Click);
            // 
            // btnGetCurrentTime
            // 
            this.btnGetCurrentTime.Location = new System.Drawing.Point(215, 56);
            this.btnGetCurrentTime.Name = "btnGetCurrentTime";
            this.btnGetCurrentTime.Size = new System.Drawing.Size(75, 23);
            this.btnGetCurrentTime.TabIndex = 12;
            this.btnGetCurrentTime.Text = "Now";
            this.btnGetCurrentTime.UseVisualStyleBackColor = true;
            this.btnGetCurrentTime.Click += new System.EventHandler(this.btnGetCurrentTime_Click);
            // 
            // txtSchdTime
            // 
            this.txtSchdTime.Location = new System.Drawing.Point(54, 27);
            this.txtSchdTime.Name = "txtSchdTime";
            this.txtSchdTime.Size = new System.Drawing.Size(237, 22);
            this.txtSchdTime.TabIndex = 13;
            this.txtSchdTime.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSchdTime_KeyPress);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnHide);
            this.groupBox2.Controls.Add(this.checkedListBox1);
            this.groupBox2.Controls.Add(this.btnLockUI);
            this.groupBox2.ForeColor = System.Drawing.Color.Red;
            this.groupBox2.Location = new System.Drawing.Point(315, 103);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(372, 107);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Software Safety";
            // 
            // btnHide
            // 
            this.btnHide.BackColor = System.Drawing.Color.Aquamarine;
            this.btnHide.ForeColor = System.Drawing.Color.IndianRed;
            this.btnHide.Location = new System.Drawing.Point(192, 62);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(174, 39);
            this.btnHide.TabIndex = 21;
            this.btnHide.Text = "Hide To TaskBar";
            this.btnHide.UseVisualStyleBackColor = false;
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Save Log To D:\\",
            "Auto PowerOff",
            "Auto Exit"});
            this.checkedListBox1.Location = new System.Drawing.Point(6, 20);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(180, 72);
            this.checkedListBox1.TabIndex = 21;
            // 
            // btnLockUI
            // 
            this.btnLockUI.BackColor = System.Drawing.Color.Red;
            this.btnLockUI.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLockUI.Location = new System.Drawing.Point(192, 16);
            this.btnLockUI.Name = "btnLockUI";
            this.btnLockUI.Size = new System.Drawing.Size(174, 39);
            this.btnLockUI.TabIndex = 20;
            this.btnLockUI.Text = "Lock UI";
            this.btnLockUI.UseVisualStyleBackColor = false;
            this.btnLockUI.Click += new System.EventHandler(this.btnLockUI_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnStart);
            this.groupBox3.Controls.Add(this.btnStop);
            this.groupBox3.Controls.Add(this.btnClearLog);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Location = new System.Drawing.Point(315, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(372, 85);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Main Panel";
            // 
            // btnUnlockUI
            // 
            this.btnUnlockUI.BackColor = System.Drawing.SystemColors.Control;
            this.btnUnlockUI.Enabled = false;
            this.btnUnlockUI.Location = new System.Drawing.Point(536, 641);
            this.btnUnlockUI.Name = "btnUnlockUI";
            this.btnUnlockUI.Size = new System.Drawing.Size(150, 26);
            this.btnUnlockUI.TabIndex = 23;
            this.btnUnlockUI.Text = "Unlock UI";
            this.btnUnlockUI.UseVisualStyleBackColor = false;
            this.btnUnlockUI.Click += new System.EventHandler(this.btnUnlockUI_Click);
            // 
            // txtUILockPwd
            // 
            this.txtUILockPwd.BackColor = System.Drawing.Color.White;
            this.txtUILockPwd.Enabled = false;
            this.txtUILockPwd.Location = new System.Drawing.Point(315, 644);
            this.txtUILockPwd.Name = "txtUILockPwd";
            this.txtUILockPwd.PasswordChar = '*';
            this.txtUILockPwd.Size = new System.Drawing.Size(215, 22);
            this.txtUILockPwd.TabIndex = 22;
            this.txtUILockPwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUILockPwd_KeyPress);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "Application still running.";
            this.notifyIcon1.BalloonTipTitle = "CastStation";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "CastStation";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 26);
            // 
            // showToolStripMenuItem
            // 
            this.showToolStripMenuItem.Name = "showToolStripMenuItem";
            this.showToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.showToolStripMenuItem.Text = "Show...";
            this.showToolStripMenuItem.Click += new System.EventHandler(this.showToolStripMenuItem_Click);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            this.ofd.Filter = "MP3 Files (*.mp3)|*.mp3";
            this.ofd.RestoreDirectory = true;
            this.ofd.Title = "Select music file";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(315, 216);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(371, 151);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 678);
            this.Controls.Add(this.txtUILockPwd);
            this.Controls.Add(this.btnUnlockUI);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.groupSettings);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(715, 663);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupSettings.ResumeLayout(false);
            this.groupSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUdpPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTcpPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVol)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIpAddr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupSettings;
        private System.Windows.Forms.NumericUpDown txtTcpPort;
        private System.Windows.Forms.NumericUpDown txtUdpPort;
        private System.Windows.Forms.TextBox txtPwd;
        private System.Windows.Forms.TextBox txtUsr;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtVol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTerm;
        private System.Windows.Forms.Button btnGetTerm;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnGetCurrentTime;
        private System.Windows.Forms.TextBox txtSchdTime;
        private System.Windows.Forms.Label labelTimerOutput;
        private System.Windows.Forms.Label labelTimerStatus;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnDisableTimer;
        private System.Windows.Forms.Button btnEnableTimer;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLockUI;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnUnlockUI;
        private System.Windows.Forms.TextBox txtUILockPwd;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.TextBox txtSenAttr1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSenAttr3;
        private System.Windows.Forms.TextBox txtSenAttr2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem showToolStripMenuItem;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtSenName;
        private System.Windows.Forms.OpenFileDialog ofd;
    }
}

