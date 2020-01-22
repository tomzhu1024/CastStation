using System;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Diagnostics;

namespace CastStationServer
{
    //stable version
    class ITCPlayer
    {
        public ITCPlayer() { }

        public delegate void MessageHandler(string msg, bool isOver);
        public event MessageHandler MessageComing;

        public void SetUp(ITCTask task)
        {
            _ipAddr = task.ipAddr;
            _username = task.username;
            _password = task.password;
            _filePath = task.filePath;
            _terminals = task.terminals;
            _volume = task.volume;
        }

        public void Start()
        {
            ItcPrepare();
        }

        public void Stop()
        {
            ItcClean("Stopped by user.");
        }

        string _ipAddr = "";
        string _username = "";
        string _password = "";
        string _filePath = "";
        string _terminals = "";
        byte _volume = 0;

        TcpClient iTcpClient;
        NetworkStream iNetworkStream;
        UdpClient iUdpClient;
        FileStream iFileStream;
        UltraHighAccurateTimer uhat;
        string sessionId = "";
        int frameSize;
        byte[] udpBuffer;
        int udpBufferPos = 0;
        long frameCount = 0;

        private void ItcPrepare()
        {
            try
            {
                //initiate the tcp connection
                iTcpClient = new TcpClient(_ipAddr, 8000);
                iNetworkStream = iTcpClient.GetStream();
                iNetworkStream.ReadTimeout = 1000;
                iNetworkStream.WriteTimeout = 1000;
                iFileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
                iUdpClient = new UdpClient(_ipAddr, 15001);

                AnalyzeMp3File(ref iFileStream, out frameSize, out int frameLength);
                if (frameSize < 1 || frameLength < 1)
                {
                    throw new Exception("Invalid mp3 file.");
                }

                string recvStr = "";
                recvStr = TcpRequest("logon 0\t" + _username + Convert.ToChar("\t") + _password);
                if (recvStr != "000 1\n" && recvStr != "000 0\n") { throw new Exception("Authentication failed."); }

                //get service stat
                recvStr = TcpRequest("service stat");
                if (recvStr != "000 1\n" && recvStr != "000 0\n") { throw new Exception("Unknown service status."); }

                //create an session
                recvStr = TcpRequest("session new test\t65794\t400\t1");
                //000 XXXX\n
                if (!recvStr.StartsWith("000 ") || !recvStr.EndsWith("\n"))
                {
                    throw new Exception("Request session id failed.");
                }
                sessionId = recvStr.Split(new char[] { Convert.ToChar(" "), Convert.ToChar("\n") })[1];
                Debug.Print("Session ID = " + sessionId);

                //add _terminals to the session
                recvStr = TcpRequest("session add_term " + sessionId + "," + _terminals);
                if (recvStr != "000 \n") { throw new Exception("Unexpected reply while adding _terminals."); }

                //set the session stat to 1
                recvStr = TcpRequest("session set " + sessionId + "\tSTAT=1");
                if (recvStr != "000 \n") { throw new Exception("Unexpected reply while enabling session."); }

                //set the _volume of session
                recvStr = TcpRequest("session playvol " + sessionId + "," + _volume.ToString() + ",");
                if (recvStr != "000 \n") { throw new Exception("Unexpected reply while setting _volume."); }

                InitUdpBuffHead(sessionId);

                //set up udp timer
                uhat = new UltraHighAccurateTimer
                {
                    Interval = frameLength
                };
                uhat.tick += UdpClock_Elapsed;
                uhat.Start();

                MessageComing?.Invoke("OK: Playing...", false);
            }
            catch(SocketException)
            {
                ItcClean("Not Ready: Connection error.");
            }
            catch (Exception ex)
            {
                ItcClean("Not Ready: " + ex.Message);
            }
        }

        private void UdpClock_Elapsed()
        {
            try
            {
                SendNextFrame();
            }
            catch (Exception ex)
            {
                ItcClean("Task Aborted: " + ex.Message);
            }
        }

        private string TcpRequest(string sendStr)
        {
            byte[] sendBytes = Encoding.Default.GetBytes(sendStr);
            iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
            iNetworkStream.Flush();
            byte[] recvBytes = new byte[iTcpClient.ReceiveBufferSize];
            int numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
            return Encoding.Default.GetString(recvBytes, 0, numBytesRecv);
        }

        private void AnalyzeMp3File(ref FileStream fs, out int FRAME_SIZE, out int FRAME_LENGTH)
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
                    + (ID3V2_HEADER_SIZE[3] & 0x7F)
                    + 10;
                //skip the id3v2 info
                fs.Seek(ID3V2_SIZE - 10, SeekOrigin.Current);
            }


            //repeat to read data frame
            int[] BITRATE_LIST = new int[] { 0, 32, 40, 48, 56, 64, 80, 96, 112, 128, 160, 192, 224, 256, 320, 0 };
            float[] SMP_FREQ_LIST = new float[] { 44.1F, 48, 32, 0 };

            byte[] FRAME_HEAD = new byte[4];
            fs.Read(FRAME_HEAD, 0, 4);

            if (FRAME_HEAD[0] != 0xFF || (FRAME_HEAD[1] != 0xFA && FRAME_HEAD[1] != 0xFB))
            {
                //perhaps this is a wrong file
                FRAME_SIZE = -1;
                FRAME_LENGTH = -1;
            }

            int FRAME_BITRATE = BITRATE_LIST[FRAME_HEAD[2] / 0x10];
            float FRAME_SMP_FREQ = SMP_FREQ_LIST[(FRAME_HEAD[2] % 0x10) / 0x04];
            byte FRAME_OFFSET = (byte)((FRAME_HEAD[2] % 4) / 2);

            //FRAME_SIZE = (int)Math.Floor(1152 * FRAME_BITRATE / FRAME_SMP_FREQ / 8 + FRAME_OFFSET);
            //Here to give the value without offset
            FRAME_SIZE = (int)Math.Floor(1152 * FRAME_BITRATE / FRAME_SMP_FREQ / 8);

            //Number of samples is 1152 in MPEG-1 Layer-3
            FRAME_LENGTH = 1152 / (int)FRAME_SMP_FREQ;

            //reset filestream cursor, skip the first FFFA/FFFB to fit other method
            if (ID3V2_SIZE != 0)
            {
                fs.Seek(ID3V2_SIZE + 2, SeekOrigin.Begin);
            }
            else
            {
                fs.Seek(2, SeekOrigin.Begin);
            }
        }

        private void InitUdpBuffHead(string sessionId)
        {
            udpBuffer = new byte[4096];
            udpBuffer[0] = (byte)((Convert.ToInt32(sessionId) / 0x1000000) % 0x100);
            udpBuffer[1] = (byte)((Convert.ToInt32(sessionId) / 0x10000) % 0x100);
            udpBuffer[2] = (byte)((Convert.ToInt32(sessionId) / 0x100) % 0x100);
            udpBuffer[3] = (byte)((Convert.ToInt32(sessionId) / 0x1) % 0x100);
            udpBuffer[4] = udpBuffer[5] = udpBuffer[6] = udpBuffer[7] = 0;
            udpBuffer[8] = 255;
            udpBuffer[9] = 251;
            udpBufferPos = 10;
            frameCount = 0;
        }

        [Obsolete]
        private void MoveToNextFrame()
        {
            byte buf1 = 0;
            byte buf2 = 0;
            while (iFileStream.Position < iFileStream.Length)
            {
                buf1 = buf2;
                buf2 = Convert.ToByte(iFileStream.ReadByte());
                if (buf1 == 0xFF && (buf2 == 0xFA || buf2 == 0xFB)) { break; }
            }
        }

        private void SendNextFrame()
        {
            while (iFileStream.Position < iFileStream.Length)
            {
                udpBuffer[udpBufferPos] = Convert.ToByte(iFileStream.ReadByte());
                if ((udpBuffer[udpBufferPos] == 0xFB || udpBuffer[udpBufferPos] == 0xFA) && udpBuffer[udpBufferPos - 1] == 0xFF && udpBufferPos > frameSize + 7)
                {
                    udpBufferPos++;
                    break;
                }
                udpBufferPos++;
            }

            iUdpClient.Send(udpBuffer, udpBufferPos - 2);
            udpBufferPos = 10;

            udpBuffer[4] = (byte)((frameCount / 0x1000000) % 0x100);
            udpBuffer[5] = (byte)((frameCount / 0x10000) % 0x100);
            udpBuffer[6] = (byte)((frameCount / 0x100) % 0x100);
            udpBuffer[7] = (byte)(frameCount % 0x100);
            frameCount++;

            if (iFileStream.Position == iFileStream.Length)
            {
                ItcClean("OK: Complete.");
            }
        }

        private void ItcClean(string msg)
        {
            try
            {
                MessageComing?.Invoke(msg, true);

                if (uhat != null) { uhat.Stop(); }

                if (iTcpClient != null)
                {
                    if (iNetworkStream != null)
                    {
                        //set session stat to 0
                        byte[] sendBytes = Encoding.Default.GetBytes("session set " + sessionId + "\tSTAT=0");
                        iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                        iNetworkStream.Flush();
                        byte[] recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                        int numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                        string recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);

                        //remove session
                        sendBytes = Encoding.Default.GetBytes("session rm " + sessionId);
                        iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                        iNetworkStream.Flush();
                        recvBytes = new byte[iTcpClient.ReceiveBufferSize];
                        numBytesRecv = iNetworkStream.Read(recvBytes, 0, iTcpClient.ReceiveBufferSize);
                        recvStr = Encoding.Default.GetString(recvBytes, 0, numBytesRecv);

                        //quit
                        sendBytes = Encoding.Default.GetBytes("quit");
                        iNetworkStream.Write(sendBytes, 0, sendBytes.Length);
                        iNetworkStream.Flush();

                        iTcpClient.Close();
                        iNetworkStream.Close();
                    }
                    else { iTcpClient.Close(); }
                }

                if (iFileStream != null) { iFileStream.Close(); }
                if (iUdpClient != null) { iUdpClient.Close(); }
            }
            catch { }
        }
    }
}