namespace TestTcpClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSend = new System.Windows.Forms.Button();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtServerIpAddr = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnSendFile = new System.Windows.Forms.Button();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.txtTaskName = new System.Windows.Forms.TextBox();
            this.txtTaskEnabled = new System.Windows.Forms.TextBox();
            this.txtCastIpAddr = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.txtTerminals = new System.Windows.Forms.TextBox();
            this.btnRemoveTask = new System.Windows.Forms.Button();
            this.btnGetTasks = new System.Windows.Forms.Button();
            this.btnSaveTasks = new System.Windows.Forms.Button();
            this.btnLoadTasks = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnEnableAB = new System.Windows.Forms.Button();
            this.btnDisableAB = new System.Windows.Forms.Button();
            this.btnDelCST = new System.Windows.Forms.Button();
            this.btnClearTasks = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnCmd = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btnGetFileName = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGetTerms = new System.Windows.Forms.Button();
            this.txtVolume = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnDelMp3 = new System.Windows.Forms.Button();
            this.btnTgglEnbdVal = new System.Windows.Forms.Button();
            this.taskDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVolume)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Font = new System.Drawing.Font("宋体", 9F);
            this.btnSend.Location = new System.Drawing.Point(516, 535);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 33;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtSend
            // 
            this.txtSend.Location = new System.Drawing.Point(20, 538);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(490, 21);
            this.txtSend.TabIndex = 32;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(714, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(67, 21);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Enabled = false;
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(83, 21);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // txtServerIpAddr
            // 
            this.txtServerIpAddr.Location = new System.Drawing.Point(12, 28);
            this.txtServerIpAddr.Name = "txtServerIpAddr";
            this.txtServerIpAddr.Size = new System.Drawing.Size(115, 21);
            this.txtServerIpAddr.TabIndex = 1;
            this.txtServerIpAddr.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(133, 28);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(49, 21);
            this.txtPort.TabIndex = 2;
            this.txtPort.Text = "6000";
            // 
            // btnSendFile
            // 
            this.btnSendFile.BackColor = System.Drawing.Color.Yellow;
            this.btnSendFile.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSendFile.Location = new System.Drawing.Point(6, 78);
            this.btnSendFile.Name = "btnSendFile";
            this.btnSendFile.Size = new System.Drawing.Size(75, 23);
            this.btnSendFile.TabIndex = 18;
            this.btnSendFile.Text = "SendFile";
            this.btnSendFile.UseVisualStyleBackColor = false;
            this.btnSendFile.Click += new System.EventHandler(this.btnSendFile_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.Location = new System.Drawing.Point(527, 28);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(75, 23);
            this.btnClearLog.TabIndex = 27;
            this.btnClearLog.Text = "Clr Log";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // richTextBoxLog
            // 
            this.richTextBoxLog.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.richTextBoxLog.Location = new System.Drawing.Point(20, 265);
            this.richTextBoxLog.Name = "richTextBoxLog";
            this.richTextBoxLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBoxLog.Size = new System.Drawing.Size(652, 268);
            this.richTextBoxLog.TabIndex = 31;
            this.richTextBoxLog.Text = "";
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.Yellow;
            this.btnAddTask.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAddTask.Location = new System.Drawing.Point(232, 234);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 21);
            this.btnAddTask.TabIndex = 15;
            this.btnAddTask.Text = "Add Task";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(80, 12);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(146, 21);
            this.txtTaskName.TabIndex = 3;
            this.txtTaskName.Text = "taskname";
            // 
            // txtTaskEnabled
            // 
            this.txtTaskEnabled.BackColor = System.Drawing.SystemColors.Window;
            this.txtTaskEnabled.Enabled = false;
            this.txtTaskEnabled.Location = new System.Drawing.Point(80, 40);
            this.txtTaskEnabled.Name = "txtTaskEnabled";
            this.txtTaskEnabled.Size = new System.Drawing.Size(65, 21);
            this.txtTaskEnabled.TabIndex = 5;
            this.txtTaskEnabled.Text = "true";
            // 
            // txtCastIpAddr
            // 
            this.txtCastIpAddr.Location = new System.Drawing.Point(80, 68);
            this.txtCastIpAddr.Name = "txtCastIpAddr";
            this.txtCastIpAddr.Size = new System.Drawing.Size(146, 21);
            this.txtCastIpAddr.TabIndex = 7;
            this.txtCastIpAddr.Text = "192.168.8.10";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(80, 96);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(146, 21);
            this.txtUsername.TabIndex = 8;
            this.txtUsername.Text = "user";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(80, 123);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(146, 21);
            this.txtPassword.TabIndex = 9;
            this.txtPassword.Text = "password";
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(80, 151);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(146, 21);
            this.txtFilename.TabIndex = 10;
            this.txtFilename.Text = "filename.mp3";
            // 
            // txtTerminals
            // 
            this.txtTerminals.Location = new System.Drawing.Point(80, 179);
            this.txtTerminals.Name = "txtTerminals";
            this.txtTerminals.Size = new System.Drawing.Size(146, 21);
            this.txtTerminals.TabIndex = 12;
            this.txtTerminals.Text = "130,131";
            // 
            // btnRemoveTask
            // 
            this.btnRemoveTask.Location = new System.Drawing.Point(232, 12);
            this.btnRemoveTask.Name = "btnRemoveTask";
            this.btnRemoveTask.Size = new System.Drawing.Size(75, 21);
            this.btnRemoveTask.TabIndex = 4;
            this.btnRemoveTask.Text = "Del ByNm";
            this.btnRemoveTask.UseVisualStyleBackColor = true;
            this.btnRemoveTask.Click += new System.EventHandler(this.btnRemoveTask_Click);
            // 
            // btnGetTasks
            // 
            this.btnGetTasks.BackColor = System.Drawing.Color.Aquamarine;
            this.btnGetTasks.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetTasks.Location = new System.Drawing.Point(6, 49);
            this.btnGetTasks.Name = "btnGetTasks";
            this.btnGetTasks.Size = new System.Drawing.Size(75, 23);
            this.btnGetTasks.TabIndex = 17;
            this.btnGetTasks.Text = "Get Tsks";
            this.btnGetTasks.UseVisualStyleBackColor = false;
            this.btnGetTasks.Click += new System.EventHandler(this.btnGetTasks_Click);
            // 
            // btnSaveTasks
            // 
            this.btnSaveTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnSaveTasks.Location = new System.Drawing.Point(87, 107);
            this.btnSaveTasks.Name = "btnSaveTasks";
            this.btnSaveTasks.Size = new System.Drawing.Size(75, 23);
            this.btnSaveTasks.TabIndex = 22;
            this.btnSaveTasks.Text = "Save2F";
            this.btnSaveTasks.UseVisualStyleBackColor = false;
            this.btnSaveTasks.Click += new System.EventHandler(this.btnSaveTasks_Click);
            // 
            // btnLoadTasks
            // 
            this.btnLoadTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnLoadTasks.Location = new System.Drawing.Point(87, 78);
            this.btnLoadTasks.Name = "btnLoadTasks";
            this.btnLoadTasks.Size = new System.Drawing.Size(75, 23);
            this.btnLoadTasks.TabIndex = 21;
            this.btnLoadTasks.Text = "LoadFF";
            this.btnLoadTasks.UseVisualStyleBackColor = false;
            this.btnLoadTasks.Click += new System.EventHandler(this.btnLoadTasks_Click);
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnStart.Location = new System.Drawing.Point(247, 20);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 28;
            this.btnStart.Text = "Tsk Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.btnStop.Location = new System.Drawing.Point(247, 49);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 29;
            this.btnStop.Text = "Tsk Stop";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnEnableAB
            // 
            this.btnEnableAB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnEnableAB.Location = new System.Drawing.Point(87, 20);
            this.btnEnableAB.Name = "btnEnableAB";
            this.btnEnableAB.Size = new System.Drawing.Size(75, 23);
            this.btnEnableAB.TabIndex = 19;
            this.btnEnableAB.Text = "Enable AB";
            this.btnEnableAB.UseVisualStyleBackColor = false;
            this.btnEnableAB.Click += new System.EventHandler(this.btnEnableAB_Click);
            // 
            // btnDisableAB
            // 
            this.btnDisableAB.BackColor = System.Drawing.Color.Silver;
            this.btnDisableAB.Location = new System.Drawing.Point(87, 49);
            this.btnDisableAB.Name = "btnDisableAB";
            this.btnDisableAB.Size = new System.Drawing.Size(75, 23);
            this.btnDisableAB.TabIndex = 20;
            this.btnDisableAB.Text = "Disable AB";
            this.btnDisableAB.UseVisualStyleBackColor = false;
            this.btnDisableAB.Click += new System.EventHandler(this.btnDisableAB_Click);
            // 
            // btnDelCST
            // 
            this.btnDelCST.BackColor = System.Drawing.Color.Silver;
            this.btnDelCST.Location = new System.Drawing.Point(168, 49);
            this.btnDelCST.Name = "btnDelCST";
            this.btnDelCST.Size = new System.Drawing.Size(75, 23);
            this.btnDelCST.TabIndex = 24;
            this.btnDelCST.Text = "Del TskDB";
            this.btnDelCST.UseVisualStyleBackColor = false;
            this.btnDelCST.Click += new System.EventHandler(this.btnDelCST_Click);
            // 
            // btnClearTasks
            // 
            this.btnClearTasks.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnClearTasks.Location = new System.Drawing.Point(6, 107);
            this.btnClearTasks.Name = "btnClearTasks";
            this.btnClearTasks.Size = new System.Drawing.Size(75, 23);
            this.btnClearTasks.TabIndex = 23;
            this.btnClearTasks.Text = "Clr Tasks";
            this.btnClearTasks.UseVisualStyleBackColor = false;
            this.btnClearTasks.Click += new System.EventHandler(this.btnClearTasks_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInfo.Location = new System.Drawing.Point(6, 20);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(75, 23);
            this.btnInfo.TabIndex = 16;
            this.btnInfo.Text = "Info";
            this.btnInfo.UseVisualStyleBackColor = false;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Silver;
            this.btnExit.Location = new System.Drawing.Point(167, 78);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 25;
            this.btnExit.Text = "Exit Serv";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCmd
            // 
            this.btnCmd.Location = new System.Drawing.Point(597, 535);
            this.btnCmd.Name = "btnCmd";
            this.btnCmd.Size = new System.Drawing.Size(75, 23);
            this.btnCmd.TabIndex = 34;
            this.btnCmd.Text = "Send CMD";
            this.btnCmd.UseVisualStyleBackColor = true;
            this.btnCmd.Click += new System.EventHandler(this.btnCmd_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 34;
            this.label1.Text = "TaskName";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 35;
            this.label2.Text = "Enabled";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "Server IP";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 37;
            this.label4.Text = "Username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 38;
            this.label5.Text = "Password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 12);
            this.label6.TabIndex = 39;
            this.label6.Text = "File Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 182);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 12);
            this.label7.TabIndex = 40;
            this.label7.Text = "Terminals";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 210);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 41;
            this.label8.Text = "Volume";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 240);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 42;
            this.label9.Text = "DateTime";
            // 
            // btnGetFileName
            // 
            this.btnGetFileName.Location = new System.Drawing.Point(232, 151);
            this.btnGetFileName.Name = "btnGetFileName";
            this.btnGetFileName.Size = new System.Drawing.Size(75, 21);
            this.btnGetFileName.TabIndex = 11;
            this.btnGetFileName.Text = "Get FileNm";
            this.btnGetFileName.UseVisualStyleBackColor = true;
            this.btnGetFileName.Click += new System.EventHandler(this.btnGetFileName_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGetTerms);
            this.panel1.Controls.Add(this.txtVolume);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnTgglEnbdVal);
            this.panel1.Controls.Add(this.taskDateTimePicker);
            this.panel1.Controls.Add(this.richTextBoxLog);
            this.panel1.Controls.Add(this.btnGetFileName);
            this.panel1.Controls.Add(this.btnSend);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtSend);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnAddTask);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtTaskName);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtTaskEnabled);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtCastIpAddr);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtUsername);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtPassword);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtFilename);
            this.panel1.Controls.Add(this.btnCmd);
            this.panel1.Controls.Add(this.txtTerminals);
            this.panel1.Controls.Add(this.btnRemoveTask);
            this.panel1.Enabled = false;
            this.panel1.Location = new System.Drawing.Point(12, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(694, 565);
            this.panel1.TabIndex = 44;
            // 
            // btnGetTerms
            // 
            this.btnGetTerms.BackColor = System.Drawing.Color.Yellow;
            this.btnGetTerms.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnGetTerms.Location = new System.Drawing.Point(233, 179);
            this.btnGetTerms.Name = "btnGetTerms";
            this.btnGetTerms.Size = new System.Drawing.Size(75, 21);
            this.btnGetTerms.TabIndex = 46;
            this.btnGetTerms.Text = "Terms...";
            this.btnGetTerms.UseVisualStyleBackColor = false;
            this.btnGetTerms.Click += new System.EventHandler(this.btnGetTerms_Click);
            // 
            // txtVolume
            // 
            this.txtVolume.BackColor = System.Drawing.Color.White;
            this.txtVolume.ForeColor = System.Drawing.Color.Black;
            this.txtVolume.Location = new System.Drawing.Point(80, 209);
            this.txtVolume.Margin = new System.Windows.Forms.Padding(2);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(77, 21);
            this.txtVolume.TabIndex = 13;
            this.txtVolume.Value = new decimal(new int[] {
            22,
            0,
            0,
            0});
            this.txtVolume.ValueChanged += new System.EventHandler(this.txtVolume_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnStart);
            this.groupBox1.Controls.Add(this.btnInfo);
            this.groupBox1.Controls.Add(this.btnStop);
            this.groupBox1.Controls.Add(this.btnGetTasks);
            this.groupBox1.Controls.Add(this.btnDelMp3);
            this.groupBox1.Controls.Add(this.btnSendFile);
            this.groupBox1.Controls.Add(this.btnEnableAB);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnClearTasks);
            this.groupBox1.Controls.Add(this.btnDisableAB);
            this.groupBox1.Controls.Add(this.btnDelCST);
            this.groupBox1.Controls.Add(this.btnLoadTasks);
            this.groupBox1.Controls.Add(this.btnSaveTasks);
            this.groupBox1.Location = new System.Drawing.Point(313, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(341, 248);
            this.groupBox1.TabIndex = 45;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "General Cmd";
            // 
            // btnDelMp3
            // 
            this.btnDelMp3.BackColor = System.Drawing.SystemColors.Control;
            this.btnDelMp3.Location = new System.Drawing.Point(167, 19);
            this.btnDelMp3.Margin = new System.Windows.Forms.Padding(2);
            this.btnDelMp3.Name = "btnDelMp3";
            this.btnDelMp3.Size = new System.Drawing.Size(75, 23);
            this.btnDelMp3.TabIndex = 26;
            this.btnDelMp3.Text = "Del mp3";
            this.btnDelMp3.UseVisualStyleBackColor = false;
            this.btnDelMp3.Click += new System.EventHandler(this.btnDelMp3_Click);
            // 
            // btnTgglEnbdVal
            // 
            this.btnTgglEnbdVal.Location = new System.Drawing.Point(151, 40);
            this.btnTgglEnbdVal.Name = "btnTgglEnbdVal";
            this.btnTgglEnbdVal.Size = new System.Drawing.Size(75, 21);
            this.btnTgglEnbdVal.TabIndex = 6;
            this.btnTgglEnbdVal.Text = "Toggle";
            this.btnTgglEnbdVal.UseVisualStyleBackColor = true;
            this.btnTgglEnbdVal.Click += new System.EventHandler(this.btnTgglEnbdVal_Click);
            // 
            // taskDateTimePicker
            // 
            this.taskDateTimePicker.CustomFormat = "yyyy-MM-dd HH:mm";
            this.taskDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.taskDateTimePicker.Location = new System.Drawing.Point(80, 234);
            this.taskDateTimePicker.MinDate = new System.DateTime(2010, 1, 1, 0, 0, 0, 0);
            this.taskDateTimePicker.Name = "taskDateTimePicker";
            this.taskDateTimePicker.Size = new System.Drawing.Size(146, 21);
            this.taskDateTimePicker.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(714, 628);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtServerIpAddr);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtVolume)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.TextBox txtServerIpAddr;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnSendFile;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.TextBox txtTaskName;
        private System.Windows.Forms.TextBox txtTaskEnabled;
        private System.Windows.Forms.TextBox txtCastIpAddr;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.TextBox txtTerminals;
        private System.Windows.Forms.Button btnRemoveTask;
        private System.Windows.Forms.Button btnGetTasks;
        private System.Windows.Forms.Button btnSaveTasks;
        private System.Windows.Forms.Button btnLoadTasks;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnEnableAB;
        private System.Windows.Forms.Button btnDisableAB;
        private System.Windows.Forms.Button btnDelCST;
        private System.Windows.Forms.Button btnClearTasks;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnCmd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnGetFileName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker taskDateTimePicker;
        private System.Windows.Forms.Button btnTgglEnbdVal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnDelMp3;
        private System.Windows.Forms.NumericUpDown txtVolume;
        private System.Windows.Forms.Button btnGetTerms;
    }
}

