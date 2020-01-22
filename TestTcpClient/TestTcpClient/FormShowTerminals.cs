using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Threading;

namespace TestTcpClient
{
    public partial class FormShowTerminals : Form
    {
        public string ipAddr { get; set; }
        public string username { get; set; }
        public string password { get; set; }

        public FormShowTerminals()
        {
            InitializeComponent();
            txtSmall.KeyPress += TextBox1_KeyPress;
        }

        public delegate void finishHandler(string result);
        public event finishHandler FinishSetting;

        private void GetTerms()
        {
            textUpdate("");
            try
            {
                TcpClient  iTcpClient = new TcpClient(ipAddr, 8000);
                NetworkStream iNetworkStream = iTcpClient.GetStream();
                iNetworkStream.ReadTimeout = 1000;
                iNetworkStream.WriteTimeout = 1000;

                byte[] sendBytes = Encoding.Default.GetBytes("logon 0\t" + username + Convert.ToChar("\t") + password);
                iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                iNetworkStream.Flush();
                byte[] recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                int numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                string recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
                if (recvStr != "000 1\n" && recvStr != "000 0\n") { throw new Exception("Failed to login"); }
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
                    if (i % 11 == 0) { textAppend(strP + "\t\t"); }
                    if (i % 11 == 1) { textAppend(strP + "\n"); }
                    i++;
                }
            }
            catch (Exception ex)
            {
                textAppend(ex.ToString());
            }
        }

        public delegate void TextBoxDelegate(string text);

        private void textUpdate(string text)
        {
            if (txtBig.InvokeRequired)
            {
                txtBig.Invoke(new TextBoxDelegate(textUpdate), text);
            }
            else
            {
                txtBig.Text = text;
            }
        }

        private void textAppend(string text)
        {
            if (txtBig.InvokeRequired)
            {
                txtBig.Invoke(new TextBoxDelegate(textAppend), text);
            }
            else
            {
                txtBig.AppendText(text);
            }
        }

        private void FormShowTerminals_Load(object sender, EventArgs e)
        {
            Thread worker = new Thread(new ThreadStart(GetTerms));
            worker.Start();
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                btnFinish_Click(this, null);
                e.Handled = true;
            }
        }

        private void btnGetTerms_Click(object sender, EventArgs e)
        {
            Thread worker = new Thread(new ThreadStart(GetTerms));
            worker.Start();
        }

        private void btnFinish_Click(object sender, EventArgs e)
        {
            FinishSetting?.Invoke(txtSmall.Text);
            this.Close();
        }
    }
}
