using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace CastStation
{
    public partial class Form1 : Form
    {
        TcpClient iTcpClient;
        NetworkStream iNetworkStream;
        FileStream iFileStream;
        UdpClient iUdpClient;
        byte[] udpBuff;
        int udpBuffPos;
        string sessionId;
        System.Timers.Timer UIClock;
        System.Timers.Timer UnmannedClock;
        UltraHighAccurateTimer uhat;
        int secCount = 0;
        int bufLenThrehold = 0;
        string fileName = "";
        long frameCount = 0;

        public delegate void generalDelegate();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = global::CastStation.Properties.Resources._1;
            this.Text = "CastStation Standalone v" + Application.ProductVersion;
            txtLog.AppendText("CastStation Standalone v" + Application.ProductVersion + "\n");
            ofd.InitialDirectory = Application.StartupPath;

            //lock UI on start-up
            groupSettings.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            btnUnlockUI.Enabled = true;
            txtUILockPwd.Enabled = true;
            txtUILockPwd.Focus();
        }

        private void btnGetTermInfo_Click(object sender, EventArgs e)
        {
            try
            {

                iTcpClient = new TcpClient(txtIpAddr.Text, Convert.ToInt32(txtTcpPort.Value));
                iNetworkStream = iTcpClient.GetStream();
                iNetworkStream.ReadTimeout = 1000;
                iNetworkStream.WriteTimeout = 1000;

                byte[] sendBytes = Encoding.Default.GetBytes("logon 0\t" + txtUsr.Text + Convert.ToChar("\t") + txtPwd.Text);
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                byte[] recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                int numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                string recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                if (recvStr != "000 1\n" && recvStr != "000 0\n") { throw new Exception("AUTH FAILED"); }
                sendBytes = Encoding.Default.GetBytes("term list");
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                recvStr = "";
                while (!recvStr.EndsWith("000 \n"))
                {
                    recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                    numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                    recvStr += Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                }
                sendBytes = Encoding.Default.GetBytes("quit");
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                iTcpClient.Close();
                iNetworkStream.Close();

                int i = 0;
                foreach (string strP in recvStr.Split(new char[] { Convert.ToChar(Convert.ToChar("\t")), Convert.ToChar("\t"),
                    Convert.ToChar("\t"), Convert.ToChar("\t"), Convert.ToChar("\t"), Convert.ToChar("\t"), Convert.ToChar("\t"),
                    Convert.ToChar("\t"), Convert.ToChar("\t"), Convert.ToChar("\t"), Convert.ToChar("\n") }))
                {
                    if (i % 11 == 0) { txtLog.AppendText(strP + "\t\t"); }
                    if (i % 11 == 1) { txtLog.AppendText(strP + "\n"); }
                    i++;
                }
                txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"TERM INFO OK\n");
            }
            catch (Exception ex)
            {
                txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"TERM INFO FAIL " + ex.Message + "\n");
            }
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            txtLog.Text = "";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            groupSettings.Enabled = false;
            itcPrepare();
        }

        private void itcPrepare()
        {
            try
            {
                //check if none
                if (txtTerm.Text == "")
                {
                    this.Invoke(new generalDelegate(() =>
                    {
                        txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"EMPTY TERMS\n");
                        groupSettings.Enabled = true;
                    }));
                    return;
                }
                if (fileName == "")
                {
                    this.Invoke(new generalDelegate(() =>
                    {
                        txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"EMPTY FILES\n");
                        groupSettings.Enabled = true;
                    }));
                    return;
                }
                btnStart.Enabled = false;
                btnStop.Enabled = true;

                //initiate the tcp connection
                iTcpClient = new TcpClient(txtIpAddr.Text, Convert.ToInt32(txtTcpPort.Value));
                iNetworkStream = iTcpClient.GetStream();
                iNetworkStream.ReadTimeout = 1000;
                iNetworkStream.WriteTimeout = 1000;
                iFileStream = new FileStream(fileName, FileMode.Open,FileAccess.Read);
                iUdpClient = new UdpClient(txtIpAddr.Text, Convert.ToInt32(txtUdpPort.Value));

                int frameTime = 0;
                analyzeMp3File(ref iFileStream, out bufLenThrehold, out frameTime);
                txtLog.AppendText("MP3 Info: Frame_Size=" + bufLenThrehold.ToString() + ";Frame_Duration=" + frameTime.ToString());

                //logon to the cast system
                byte[] sendBytes = Encoding.Default.GetBytes("logon 0\t" + txtUsr.Text + Convert.ToChar("\t") + txtPwd.Text);
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                byte[] recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                int numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                string recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                if (recvStr != "000 1\n" && recvStr != "000 0\n") { throw new Exception("AUTH FAIL"); }
                this.Invoke(new generalDelegate(() =>
                {
                    txtLog.AppendText("[" + DateTime.Now.ToString("G") + "] " + "AUTH OK\n");
                }));

                //get service stat
                sendBytes = Encoding.Default.GetBytes("service stat");
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                if (recvStr != "000 1\n" && recvStr != "000 0\n") { throw new Exception("SERVICE NOT RUNNING"); }

                //create an session
                sendBytes = Encoding.Default.GetBytes("session new " + txtSenName.Text + "\t" + txtSenAttr1.Text + "\t" + txtSenAttr2.Text + "\t" + txtSenAttr3.Text);
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                sessionId = recvStr.Split(new char[] { Convert.ToChar(" "), Convert.ToChar("\n") })[1];
                this.Invoke(new generalDelegate(() =>
                {
                    txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"SESSION ID OK #" + sessionId + "\n");
                }));

                //add terminals to the session
                sendBytes = Encoding.Default.GetBytes("session add_term " + sessionId + "," + txtTerm.Text);
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                if (recvStr != "000 \n") { throw new Exception("ADD TERMS FAIL"); }
                this.Invoke(new generalDelegate(() =>
                {
                    txtLog.AppendText("[" + DateTime.Now.ToString("G") + "] " + "ACT-TRM @"+txtTerm.Text+"\n");
                }));

                //set the session stat to 1
                sendBytes = Encoding.Default.GetBytes("session set " + sessionId + "\tSTAT=1");
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                if (recvStr != "000 \n") { throw new Exception("SET SESSION FAIL"); }
                this.Invoke(new generalDelegate(() =>
                {
                    txtLog.AppendText("[" + DateTime.Now.ToString("G") + "] " + "SET SESSION OK\n");
                }));

                //set the volume of session
                sendBytes = Encoding.Default.GetBytes("session playvol " + sessionId + "," + Convert.ToString(txtVol.Value) + ",");
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                if (recvStr != "000 \n") { throw new Exception("SET VOLUME FAIL"); }
                this.Invoke(new generalDelegate(() =>
                {
                    txtLog.AppendText("[" + DateTime.Now.ToString("G") + "] " + "SET VOLUME OK @" + txtVol.Value.ToString() + "\n");
                }));

                initUdpBuffHead(sessionId);

                secCount = 0;
                //set UI clock
                UIClock = new System.Timers.Timer(1000);
                UIClock.Elapsed += UIClock_Elapsed;
                //set udp clock
                frameCount = 0;
                uhat = new UltraHighAccurateTimer();
                uhat.Interval = frameTime;
                uhat.tick += UdpClock_Elapsed;
                //start both timer
                uhat.Start();
                UIClock.Enabled = true;
            }
            catch (Exception ex)
            {
                this.Invoke(new generalDelegate(() =>
                {
                    txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"STAGE 1 ERROR " + ex.Message + "\n");
                }));
                itcClean();
            }
        }

        private void analyzeMp3File(ref FileStream fs, out int FRAME_LENGTH, out int FRAME_TIME)
        {
            //read id3v2 from file
            byte[] ID3V2_HEADER_IDENTIFIER = new byte[3];
            byte[] ID3V2_HEADER_VERSION = new byte[2];
            byte[] ID3V2_HEADER_FLAG = new byte[1];
            byte[] ID3V2_HEADER_SIZE = new byte[4];
            fs.Read(ID3V2_HEADER_IDENTIFIER, 0, 3);
            fs.Read(ID3V2_HEADER_VERSION, 0, 2);
            fs.Read(ID3V2_HEADER_FLAG, 0, 1);
            fs.Read(ID3V2_HEADER_SIZE, 0, 4);

            int ID3V2_SIZE;

            //check id3v2
            if (ID3V2_HEADER_IDENTIFIER[0] != 0x49
                || ID3V2_HEADER_IDENTIFIER[1] != 0x44
                || ID3V2_HEADER_IDENTIFIER[2] != 0x33
                || ID3V2_HEADER_VERSION[0] != 03
                || ID3V2_HEADER_VERSION[1] != 00)
            {
                //id3v2 not exists
                fs.Seek(0, SeekOrigin.Begin);
                ID3V2_SIZE = 0;
                fs.Seek(0, SeekOrigin.Begin);
            }
            else
            {
                ID3V2_SIZE = (ID3V2_HEADER_SIZE[0] & 0x7F) * 0x200000
                    + (ID3V2_HEADER_SIZE[1] & 0x7F) * 0x4000
                    + (ID3V2_HEADER_SIZE[2] & 0x7F) * 0x80
                    + (ID3V2_HEADER_SIZE[3] & 0x7F);
                //skip the id3v2 info
                fs.Seek(ID3V2_SIZE, SeekOrigin.Current);
            }


            //repeat to read data frame
            int[] BITRATE_LIST = new int[] { 0, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320, 0 };
            float[] SMP_FREQ_LIST = new float[] { 44.1F, 48, 32, 0 };

            byte[] FRAME_HEAD = new byte[4];
            fs.Read(FRAME_HEAD, 0, 4);

            if (FRAME_HEAD[0] != 0xFF || FRAME_HEAD[1] != 251)
            {
                FRAME_LENGTH = 626;
                FRAME_TIME = 26;
            }

            int FRAME_BITRATE = BITRATE_LIST[FRAME_HEAD[2] / 0x10];
            float FRAME_SMP_FREQ = SMP_FREQ_LIST[(FRAME_HEAD[2] % 0x10) / 0x04];
            byte FRAME_OFFSET = (byte)((FRAME_HEAD[2] % 4) / 2);

            //帧长 = ((采样个数 * (1 / 采样率)) * 帧的比特率) / 8 + 帧的填充大小    （比特率单位kbps）
            FRAME_LENGTH = (int)Math.Floor(1152 * FRAME_BITRATE / FRAME_SMP_FREQ / 8 + FRAME_OFFSET);

            //帧时 = 采样个数/比特率 （比特率单位kbps、帧时单位ms）
            FRAME_TIME = 1152 / (int)FRAME_SMP_FREQ;

            //reset filestream cursor
            if (ID3V2_SIZE != 0)
            {
                fs.Seek(ID3V2_SIZE + 12, SeekOrigin.Begin);
                txtLog.AppendText("FileStream position set to " + fs.Position.ToString());
            }
            else
            {
                fs.Seek(0, SeekOrigin.Begin);
                txtLog.AppendText("FileStream position set to " + fs.Position.ToString());
            }
        }


        private void UIClock_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //UI second counter code
            secCount++;
            this.Invoke(new generalDelegate(() =>
            {
                label10.Text = Convert.ToString(secCount);
            }));
        }

        private void UdpClock_Elapsed()
        {
            try
            {
                sendNextFrame();
            }
            catch (Exception ex)
            {
                this.Invoke(new generalDelegate(() =>
                {
                    txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"STAGE 2 ERROR " + ex.Message + "\n");
                }));
                itcClean();
            }
        }

        private void initUdpBuffHead(string senId)
        {
            udpBuff = new byte[4096];
            udpBuff[0] = (byte)((Convert.ToInt32(senId) / 0x1000000) % 0x100);
            udpBuff[1] = (byte)((Convert.ToInt32(senId) / 0x10000) % 0x100);
            udpBuff[2] = (byte)((Convert.ToInt32(senId) / 0x100) % 0x100);
            udpBuff[3] = (byte)((Convert.ToInt32(senId) / 0x1) % 0x100);
            udpBuff[4] = udpBuff[5] = udpBuff[6] = udpBuff[7] = 0;
            udpBuff[8] = 255;
            udpBuff[9] = 251;
            udpBuffPos = 10;
        }

        private void moveToNextFrame()
        {
            byte buf1 = 0;
            byte buf2 = 0;
            while (iFileStream.Position < iFileStream.Length)
            {
                buf1 = buf2;
                buf2 = Convert.ToByte(iFileStream.ReadByte());
                if (buf1 == 255 && buf2 == 251) { break; }
            }
        }

        private void sendNextFrame()
        {
            while (iFileStream.Position < iFileStream.Length)
            {
                udpBuff[udpBuffPos] = Convert.ToByte(iFileStream.ReadByte());
                if (udpBuff[udpBuffPos] == 0xFB && udpBuff[udpBuffPos - 1] == 0xFF && udpBuffPos > bufLenThrehold + 7)
                {
                    udpBuffPos++;
                    break;
                }
                udpBuffPos++;
            }

            iUdpClient.Send(udpBuff, udpBuffPos - 2);
            udpBuffPos = 10;

            udpBuff[4] = (byte)((frameCount / 0x1000000) % 0x100);
            udpBuff[5] = (byte)((frameCount / 0x10000) % 0x100);
            udpBuff[6] = (byte)((frameCount / 0x100) % 0x100);
            udpBuff[7] = (byte)(frameCount % 0x100);
            frameCount++;
            
            if (iFileStream.Position == iFileStream.Length)
            {
                itcClean();
            }
        }

        private void itcClean()
        {
            try
            {
                uhat.Stop();
                UIClock.Enabled = false;

                //SET SESSION stat to 0
                byte[] sendBytes = Encoding.Default.GetBytes("session set " + sessionId + "\tSTAT=0");
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                byte[] recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                int numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                string recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                if (recvStr != "000 \n")
                {
                    this.Invoke(new generalDelegate(() =>
                    {
                        txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"UNSET SESSION FAIL\n");
                    }));
                }
                else
                {
                    this.Invoke(new generalDelegate(() =>
                    {
                        txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"UNSET SESSION OK\n");
                    }));
                }

                //remove session
                sendBytes = Encoding.Default.GetBytes("session rm " + sessionId);
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                if (recvStr != "000 \n")
                {
                    this.Invoke(new generalDelegate(() =>
                    {
                        txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"R-SEN FAIL\n");
                    }));
                }
                else
                {
                    this.Invoke(new generalDelegate(() =>
                    {
                        txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"R-SEN OK\n");
                    }));
                }

                //quit
                sendBytes = Encoding.Default.GetBytes("quit");
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();

                iFileStream.Close();
                iTcpClient.Close();
                iNetworkStream.Close();
                iUdpClient.Close();
            }
            catch (Exception ex)
            {
                this.Invoke(new generalDelegate(() =>
                {
                    txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"STAGE 3 ERROR " + ex.Message + "\n");
                }));
            }
            finally
            {
                this.Invoke(new generalDelegate(() =>
                {
                    groupSettings.Enabled = true;
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    txtLog.AppendText("["+DateTime.Now.ToString("G")+"] "+"ALL TASK END\n");
                }));
                //cleaning option
                if (checkedListBox1.GetItemChecked(0))
                {
                    try
                    {
                        using (FileStream loFs = new FileStream(Path.Combine(Application.StartupPath, "csstd_log_" + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + ".txt"), FileMode.Create, FileAccess.ReadWrite))
                        {
                            StreamWriter sw = new StreamWriter(loFs);
                            sw.Write(txtLog.Text);
                            sw.Flush();
                        }
                    }
                    catch { }
                }
                if (checkedListBox1.GetItemChecked(1))
                {
                    Process.Start("shutdown -t 10 -s");
                }
                if (checkedListBox1.GetItemChecked(2))
                {
                    Application.Exit();
                }
            }
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                fileName = ofd.FileName;
                txtFileName.Text = ofd.SafeFileName;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            itcClean();
        }

        private void btnGetCurrentTime_Click(object sender, EventArgs e)
        {
            txtSchdTime.Text = DateTime.Now.ToString("g");
        }

        private void btnEnableTimer_Click(object sender, EventArgs e)
        {
            UnmannedClock = new System.Timers.Timer();
            UnmannedClock.Interval = 60000; //set interval to 60 seconds
            UnmannedClock.Elapsed += UnmannedClock_Elapsed;
            //UI modifier
            txtSchdTime.Enabled = false;
            btnEnableTimer.Enabled = false;
            btnDisableTimer.Enabled = true;
            btnGetCurrentTime.Enabled = false;
            labelTimerStatus.Text = "Enabled";
            labelTimerStatus.ForeColor = System.Drawing.Color.Green;
            labelTimerOutput.Text = "Waiting...";
            txtLog.AppendText("[" + DateTime.Now.ToString("G") + "] " + "TIMER ON\n");
            UnmannedClock.Start();
        }

        private void UnmannedClock_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (DateTime.Now.ToString("g") == txtSchdTime.Text)
            {
                this.Invoke(new generalDelegate(() =>
                {
                    labelTimerOutput.Text = DateTime.Now.ToString("g") + "\nReturned True";
                    //UI modifier
                    txtSchdTime.Enabled = true;
                    btnEnableTimer.Enabled = true;
                    btnDisableTimer.Enabled = false;
                    btnGetCurrentTime.Enabled = true;
                    labelTimerStatus.Text = "Disabled";
                    labelTimerStatus.ForeColor = System.Drawing.Color.Red;
                    labelTimerOutput.Text = "Not Running...";
                    txtLog.AppendText("[" + DateTime.Now.ToString("G") + "] " + "TIMER TRIGGED\n");
                    UnmannedClock.Stop();
                    groupSettings.Enabled = false;
                }));
                //trig itc prepare
                itcPrepare();
            }
            else
            {
                this.Invoke(new generalDelegate(() =>
                {
                    labelTimerOutput.Text = DateTime.Now.ToString("g") + "\nReturned False";
                }));
            }
        }

        private void btnDisableTimer_Click(object sender, EventArgs e)
        {
            //UI modifier
            txtSchdTime.Enabled = true;
            btnEnableTimer.Enabled = true;
            btnDisableTimer.Enabled = false;
            btnGetCurrentTime.Enabled = true;
            labelTimerStatus.Text = "Disabled";
            labelTimerStatus.ForeColor = System.Drawing.Color.Red;
            labelTimerOutput.Text = "Not Running...";
            txtLog.AppendText("[" + DateTime.Now.ToString("G") + "] " + "TIMER OFF\n");
            UnmannedClock.Stop();
        }

        private void btnLockUI_Click(object sender, EventArgs e)
        {
            groupSettings.Enabled = false;
            groupBox1.Enabled = false;
            groupBox2.Enabled = false;
            groupBox3.Enabled = false;
            btnUnlockUI.Enabled = true;
            txtUILockPwd.Enabled = true;
            txtUILockPwd.Focus();
        }

        private void btnUnlockUI_Click(object sender, EventArgs e)
        {
            if (txtUILockPwd.Text == "caststation")
            {
                groupSettings.Enabled = true;
                groupBox1.Enabled = true;
                groupBox2.Enabled = true;
                groupBox3.Enabled = true;
                btnUnlockUI.Enabled = false;
                txtUILockPwd.Enabled = false;
                txtUILockPwd.Text = "";
                txtUILockPwd.BackColor = System.Drawing.Color.White;
            }
            else
            {
                txtUILockPwd.Text = "";
                txtUILockPwd.BackColor = System.Drawing.Color.PaleVioletRed;
            }
        }

        private void txtSchdTime_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnEnableTimer_Click(this,null);
            }
        }

        private void txtUILockPwd_KeyPress(object sender,KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnUnlockUI_Click(this, null);
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            txtUILockPwd.Focus();
        }

        private void btnHide_Click(object sender, EventArgs e)
        {
            Hide();
            btnLockUI_Click(this, null);
            notifyIcon1.Visible = true;
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            notifyIcon1.Visible = false;
            txtUILockPwd.Focus();
        }
    }
}
