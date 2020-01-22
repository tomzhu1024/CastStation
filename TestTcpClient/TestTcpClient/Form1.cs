using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Drawing;

namespace TestTcpClient
{
    public partial class Form1 : Form
    {
        bool Connected = false;
        TcpClient client;
        byte[] data;
        OpenFileDialog ofd = new OpenFileDialog();

        public Form1()
        {
            InitializeComponent();
            txtSend.KeyPress += txtSend_KeyPress;
            txtServerIpAddr.KeyPress += txtServerIpAddr_KeyPress;
            txtPort.KeyPress += TxtPort_KeyPress;
        }

        private void Connect()
        {
            try
            {
                client = new TcpClient(txtServerIpAddr.Text, Convert.ToInt32(txtPort.Text));
                data = new byte[client.ReceiveBufferSize];
                client.GetStream().BeginRead(data, 0, client.ReceiveBufferSize, ReceiveMessage, null);
                connectToolStripMenuItem.Enabled = false;
                disconnectToolStripMenuItem.Enabled = true;
                panel1.Enabled=true;
                Connected = true;
                LogSystem("Connected!");
                SendMessage("info");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Disconnect()
        {
            try
            {
                LogSystem("Disconnected!");
                client.GetStream().Close();
                client.Close();
            }
            catch { }
            finally
            {
                connectToolStripMenuItem.Enabled = true;
                disconnectToolStripMenuItem.Enabled = false;
                panel1.Enabled = false;
                Connected = false;
            }
        }

        private void SendMessage(string message)
        {
            try
            {
                NetworkStream ns = client.GetStream();
                byte[] data = Encoding.UTF8.GetBytes(message);
                ns.Write(data, 0, data.Length);
                ns.Flush();
                LogClient(message);
            }
            catch (Exception ex)
            {
                Disconnect();
                MessageBox.Show(ex.Message);
            }
        }

        private void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                int bytesRead;
                bytesRead = client.GetStream().EndRead(ar);
                if (bytesRead < 1)
                {
                    Connected = false;
                    client.GetStream().Close();
                    client.Close();
                    return;
                }
                else
                {
                    LogServer(Encoding.UTF8.GetString(data, 0, bytesRead));
                }
                client.GetStream().BeginRead(data, 0, client.ReceiveBufferSize, ReceiveMessage, null);
            }
            catch { }
        }

        private void Form_Closing(object sender,FormClosingEventArgs e)
        {
            if (Connected)
            {
                Disconnect();
            }
        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Connect();
            txtSend.Focus();
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Disconnect();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtSend.Text != "")
            {
                if (txtSend.Text == "clear")
                {
                    btnClearLog_Click(this, null);
                }
                else
                {
                    SendMessage(txtSend.Text);
                }
                txtSend.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = Application.ProductName + " " + Application.ProductVersion;
            ofd.InitialDirectory = Application.StartupPath;
            ofd.Multiselect = false;
            ofd.Filter = "All Files(*.*)|*.*";
            ofd.RestoreDirectory = true;
            ofd.FilterIndex = 1;
            taskDateTimePicker.Value = DateTime.Now;
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            richTextBoxLog.Text = "";
        }

        private void btnSendFile_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = ofd.SafeFileName;
                try
                {
                    SendFile(ofd.FileName, ofd.SafeFileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void SendFile(string sendFileName,string sendSafeFileName)
        {
            int splitSize = 512;
            FileStream sendFs = new FileStream(sendFileName, FileMode.Open, FileAccess.Read);
            NetworkStream ns = client.GetStream();
            long totalBytes = sendFs.Length;
            long remainedBytes = totalBytes;
            SendMessage("recvfile|" + sendSafeFileName + "|" + totalBytes.ToString());
            byte[] buffer = new byte[splitSize];
            while (remainedBytes > 0)
            {
                if (remainedBytes > splitSize)
                {
                    sendFs.Read(buffer, 0, splitSize);
                    ns.Write(buffer, 0, splitSize);
                    ns.Flush();
                    remainedBytes = remainedBytes - splitSize;
                }
                else
                {
                    sendFs.Read(buffer, 0, (int)remainedBytes);
                    ns.Write(buffer, 0, (int)remainedBytes);
                    ns.Flush();
                    remainedBytes = 0;
                    break;
                }
            }
            sendFs.Close();
        }

        public delegate void LogAppendDelegate(Color color, string text);

        private void LogAppend(Color color, string text)
        {
            richTextBoxLog.AppendText(Environment.NewLine);
            richTextBoxLog.SelectionColor = Color.DarkGray;
            richTextBoxLog.AppendText("-------------------------------" + Environment.NewLine);
            richTextBoxLog.SelectionColor = color;
            richTextBoxLog.AppendText(text);
            richTextBoxLog.ScrollToCaret();
        }

        private void LogSystem(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBoxLog.Invoke(la, Color.DarkRed, DateTime.Now.ToString("[HH:mm:ss]") + text);
        }

        private void LogServer(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBoxLog.Invoke(la, Color.Blue, DateTime.Now.ToString("[HH:mm:ss]") + text);
        }

        private void LogClient(string text)
        {
            LogAppendDelegate la = new LogAppendDelegate(LogAppend);
            richTextBoxLog.Invoke(la, Color.Green, DateTime.Now.ToString("[HH:mm:ss]") + text);
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            if (txtVolume.Value>25)
            {
                if (MessageBox.Show("Dangerous volume(" + txtVolume.Text + ") has been set. Continue?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            if (taskDateTimePicker.Value.Hour < 6 || taskDateTimePicker.Value.Hour > 20)
            {
                if (MessageBox.Show("Dangerous time(" + taskDateTimePicker.Value.ToString("yyyy-MM-dd HH:mm") + ") has been set. Continue?", "Caution", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    return;
                }
            }
            SendMessage("addtask|" + txtTaskName.Text + "|" + txtTaskEnabled.Text + "|" + txtCastIpAddr.Text + "|" + txtUsername.Text
                + "|" + txtPassword.Text + "|" + txtFilename.Text + "|" + txtTerminals.Text + "|" + txtVolume.Text + "|" + taskDateTimePicker.Text);
        }

        private void txtSend_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnSend_Click(this, null);
                e.Handled = true;
            }
        }

        private void txtServerIpAddr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                connectToolStripMenuItem_Click(this, null);
                e.Handled = true;
            }
        }

        private void TxtPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                connectToolStripMenuItem_Click(this, null);
                e.Handled = true;
            }
        }


        private void btnRemoveTask_Click(object sender, EventArgs e)
        {
            SendMessage("removetask|" + txtTaskName.Text);
        }

        private void btnEnableAB_Click(object sender, EventArgs e)
        {
            SendMessage("enable autoboot");
        }

        private void btnDisableAB_Click(object sender, EventArgs e)
        {
            SendMessage("disable autoboot");
        }

        private void btnDelCST_Click(object sender, EventArgs e)
        {
            SendMessage("deltasksfile");
        }

        private void btnSaveTasks_Click(object sender, EventArgs e)
        {
            SendMessage("savetasks");
        }

        private void btnLoadTasks_Click(object sender, EventArgs e)
        {
            SendMessage("loadtasks");
        }

        private void btnGetTasks_Click(object sender, EventArgs e)
        {
            SendMessage("gettasks");
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            SendMessage("start|" + txtTaskName.Text);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            SendMessage("stop");
        }

        private void btnClearTasks_Click(object sender, EventArgs e)
        {
            SendMessage("cleartasks");
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            SendMessage("info");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            SendMessage("exit");
            disconnectToolStripMenuItem_Click(this, null);
        }

        private void btnCmd_Click(object sender, EventArgs e)
        {
            SendMessage("cmd|" + txtSend.Text);
            txtSend.Text = "";
        }

        private void btnGetFileName_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtFilename.Text = ofd.SafeFileName;
            }
        }

        private void btnTgglEnbdVal_Click(object sender, EventArgs e)
        {
            if (txtTaskEnabled.Text == "true")
            {
                txtTaskEnabled.Text = "false";
            }
            else
            {
                txtTaskEnabled.Text = "true";
            }
        }

        private void btnDelMp3_Click(object sender, EventArgs e)
        {
            SendMessage("delete mp3");
        }

        private void txtVolume_ValueChanged(object sender, EventArgs e)
        {
            if (txtVolume.Value > 25)
            {
                txtVolume.BackColor = Color.Red;
                txtVolume.ForeColor = Color.White;
            }
            else
            {
                txtVolume.BackColor = Color.White;
                txtVolume.ForeColor = Color.Black;
            }
        }

        private void btnGetTerms_Click(object sender, EventArgs e)
        {
            FormShowTerminals fst = new FormShowTerminals();
            fst.ipAddr = txtCastIpAddr.Text;
            fst.username = txtUsername.Text;
            fst.password = txtPassword.Text;
            fst.FinishSetting += Fst_FinishSetting;
            fst.ShowDialog();
        }

        private void Fst_FinishSetting(string result)
        {
            txtTerminals.Text = result;
        }
    }
}
