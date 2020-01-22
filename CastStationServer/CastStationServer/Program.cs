using System;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CastStationServer
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ServiceLayer.LoadTasksFromFile();
            ServiceLayer.InitiateTimer();
            try
            {
                IPAddress localIP = IPAddress.Parse("0.0.0.0");
                TcpListener listener = new TcpListener(localIP, 6000);
                listener.Start();
                while (true)
                {
                    ControlClient user = new ControlClient(listener.AcceptTcpClient());
                }
            }
            catch { }
        }
    }
}