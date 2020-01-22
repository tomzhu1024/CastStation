using System;
using System.Text;
using System.Net.Sockets;
using System.Collections;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace CastStationServer
{
    class ControlClient
    {
        //list of all connnected clients
        public static Hashtable AllClients = new Hashtable();

        TcpClient _client;
        string _clientIP;

        byte[] data;

        public ControlClient(TcpClient client)
        {
            _client = client;
            _clientIP = client.Client.RemoteEndPoint.ToString();

            AllClients.Add(_clientIP, this);

            data = new byte[_client.ReceiveBufferSize];
            client.GetStream().BeginRead(data, 0, _client.ReceiveBufferSize, ReceiveMessage, null);
        }

        private void ReceiveMessage(IAsyncResult ar)
        {
            int bytesRead;
            try
            {
                lock (_client.GetStream())
                {
                    bytesRead = _client.GetStream().EndRead(ar);
                }
                if (bytesRead < 1)
                {
                    AllClients.Remove(_clientIP);
                    return;
                }
                else
                {
                    string messageReceived = Encoding.UTF8.GetString(data, 0, bytesRead);
                    #region MessageHandler
                    try
                    {
                        if (messageReceived.StartsWith("recvfile|"))
                        {
                            string fileName = messageReceived.Split('|')[1];
                            long totalBytes = Convert.ToInt64(messageReceived.Split('|')[2]);
                            DateTime startTime = DateTime.Now;
                            SendMessage("begin to receive file|" + fileName + "|" + totalBytes.ToString());
                            ReceiveFile(fileName, totalBytes);
                            SendMessage("transfered " + totalBytes + " Bytes in " + DateTime.Now.Subtract(startTime).TotalMilliseconds.ToString() + " milliseconds");
                        }
                        else if (messageReceived.StartsWith("addtask|"))
                        {
                            SendMessage(ServiceLayer.AddTask(ITCTask.ToITCTask_ShortName(messageReceived.Substring(8))));
                        }
                        else if (messageReceived.StartsWith("removetask|"))
                        {
                            SendMessage(ServiceLayer.RemoveTask(messageReceived.Split('|')[1]));
                        }
                        else if (messageReceived == "gettasks")
                        {
                            SendMessage(ServiceLayer.GetAllTasks());
                        }
                        else if (messageReceived.StartsWith("start|"))
                        {
                            SendMessage(ServiceLayer.Start(messageReceived.Split('|')[1]));
                            SendMessage(ServiceLayer.GetAllTasks());
                        }
                        else if (messageReceived == "stop")
                        {
                            SendMessage(ServiceLayer.Stop());
                            SendMessage(ServiceLayer.GetAllTasks());
                        }
                        else if (messageReceived == "savetasks")
                        {
                            SendMessage(ServiceLayer.SaveTasksToFile());
                        }
                        else if (messageReceived == "loadtasks")
                        {
                            SendMessage(ServiceLayer.LoadTasksFromFile());
                        }
                        else if (messageReceived == "cleartasks")
                        {
                            SendMessage(ServiceLayer.ClearTasks());
                        }
                        else if (messageReceived == "deltasksfile")
                        {
                            SendMessage(ServiceLayer.DeleteTasksFile());
                        }
                        else if (messageReceived == "enable autoboot")
                        {
                            SendMessage(SetAutoBootStatus(true));
                        }
                        else if (messageReceived == "disable autoboot")
                        {
                            SendMessage(SetAutoBootStatus(false));
                        }
                        else if (messageReceived == "delete mp3")
                        {
                            try
                            {
                                string[] allMusic = Directory.GetFiles(ServiceLayer.AppPath, "*.mp3");
                                foreach (string file in allMusic)
                                {
                                    FileInfo fi = new FileInfo(file);
                                    fi.Delete();
                                }
                                SendMessage("operation complete: all mp3 deleted");
                            }
                            catch (Exception ex)
                            {
                                SendMessage("operation failed: " + ex.ToString());
                            }
                        }
                        else if (messageReceived.StartsWith("cmd|"))
                        {
                            Process p = new Process();
                            p.StartInfo.FileName = "cmd.exe";
                            p.StartInfo.UseShellExecute = false;
                            p.StartInfo.RedirectStandardInput = true;
                            p.StartInfo.RedirectStandardOutput = true;
                            p.StartInfo.CreateNoWindow = true;
                            p.Start();
                            p.StandardInput.WriteLine(messageReceived.Split('|')[1]);
                            p.StandardInput.Flush();
                            p.StandardInput.WriteLine("exit");
                            p.StandardInput.Flush();
                            SendMessage("operation done: " + p.StandardOutput.ReadToEnd());
                        }
                        else if (messageReceived == "exit")
                        {
                            SendMessage("server stopped.");
                            Environment.Exit(0);
                        }
                        else if (messageReceived == "info")
                        {
                            SendMessage("Version: CastStation Server " + Application.ProductVersion + Environment.NewLine
                                + "StartTime: " + ServiceLayer.startTime.ToString("g") + Environment.NewLine
                                + "SysTime: " + DateTime.Now.ToString("g") + Environment.NewLine
                                + "AppPath: " + Application.StartupPath + Environment.NewLine
                                + Environment.NewLine
                                + "   #####       ####   " + Environment.NewLine
                                + "  #     #     #    #  " + Environment.NewLine
                                + " #       #   ##     # " + Environment.NewLine
                                + " #            ##      " + Environment.NewLine
                                + " #             #####  " + Environment.NewLine
                                + " #                 ## " + Environment.NewLine
                                + " #       #   #      ##" + Environment.NewLine
                                + "  #     #     #     # " + Environment.NewLine
                                + "   #####       #####  ");
                        }
                        else
                        {
                            SendMessage("unknown command: " + messageReceived);
                        }
                    }
                    catch(Exception ex)
                    {
                        SendMessage("operation failed: " + ex.ToString());
                    }
                    #endregion
                }
                lock (_client.GetStream())
                {
                    _client.GetStream().BeginRead(data, 0, _client.ReceiveBufferSize, ReceiveMessage, null);
                }
            }
            catch
            {
                AllClients.Remove(_clientIP);
            }
        }

        private void SendMessage(string message)
        {
            try
            {
                NetworkStream ns;
                lock (_client.GetStream())
                {
                    ns = _client.GetStream();
                }
                byte[] bytesToSend = Encoding.UTF8.GetBytes(message);
                ns.Write(bytesToSend, 0, bytesToSend.Length);
                ns.Flush();
            }
            catch { }
        }

        private void ReceiveFile(string fileName, long totalBytes)
        {
            long numBytesRead = 0;
            byte[] buffer = new byte[_client.ReceiveBufferSize];
            long remainedBytes = totalBytes;
            NetworkStream ns = _client.GetStream();
            FileStream fs = new FileStream(ServiceLayer.AppPath + fileName, FileMode.Create, FileAccess.ReadWrite);
            while (remainedBytes > 0)
            {
                numBytesRead = ns.Read(buffer, 0, _client.ReceiveBufferSize);
                fs.Write(buffer, 0, (int)numBytesRead);
                fs.Flush();
                remainedBytes -= numBytesRead;
            }
            fs.Close();
        }

        public static string SetAutoBootStatus(bool isAutoBoot)
        {
            string rtn = "";
            try
            {
                string execPath = Application.ExecutablePath;
                Microsoft.Win32.RegistryKey rk = Microsoft.Win32.Registry.LocalMachine;
                Microsoft.Win32.RegistryKey rk2 = rk.CreateSubKey("Software\\Microsoft\\Windows\\CurrentVersion\\Run");
                if (isAutoBoot)
                {
                    rk2.SetValue("MyExec", execPath);
                    rtn = "operation complete: enable auto-boot";
                }
                else
                {
                    rk2.DeleteValue("MyExec", false);
                    rtn = "operation complete: disable auto-boot";
                }
                rk2.Close();
                rk.Close();
                return rtn;
            }
            catch (Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }
    }
}