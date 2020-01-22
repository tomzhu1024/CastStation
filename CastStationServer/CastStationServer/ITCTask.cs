using System;
using System.Windows.Forms;

namespace CastStationServer
{
    class ITCTask
    {
        //main info
        public string taskName;
        public bool isEnabled;
        //info for ITCPlayer
        public string ipAddr;
        public string username;
        public string password;
        public string filePath;
        public string terminals;
        public byte volume;
        //info for ITCTaskManager
        public DateTime schedule;
        //task output
        public string output = "no output";

        /// <summary>
        /// return all the info except output, for saving to file
        /// </summary>
        /// <returns></returns>
        public string ToString_Short()
        {
            return taskName + "|"
                + isEnabled.ToString() + "|"
                + ipAddr + "|"
                + username + "|"
                + password + "|"
                + filePath + "|"
                + terminals + "|"
                + volume.ToString() + "|"
                + schedule.ToString("yyyy-MM-dd HH:mm");
        }

        /// <summary>
        /// return all the info include output, for tcp send
        /// </summary>
        /// <returns></returns>
        public string ToString_Long()
        {
            return taskName + "|"
                + isEnabled.ToString() + "|"
                + ipAddr + "|"
                + username + "|"
                + password + "|"
                + filePath + "|"
                + terminals + "|"
                + volume.ToString() + "|"
                + schedule.ToString("yyyy-MM-dd HH:mm") + "|"
                + output;
        }

        /// <summary>
        /// giving the whole file path
        /// </summary>
        /// <param name="info">including file path</param>
        /// <returns></returns>
        public static ITCTask ToITCTask_LongPath(string info)
        {
            try
            {
                ITCTask tmp = new ITCTask();
                tmp.taskName = info.Split('|')[0];
                tmp.isEnabled = Convert.ToBoolean(info.Split('|')[1]);
                tmp.ipAddr = info.Split('|')[2];
                tmp.username = info.Split('|')[3];
                tmp.password = info.Split('|')[4];
                tmp.filePath = info.Split('|')[5];
                tmp.terminals = info.Split('|')[6];
                tmp.volume = Convert.ToByte(info.Split('|')[7]);
                tmp.schedule = Convert.ToDateTime(info.Split('|')[8]);
                return tmp;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// giving file name only
        /// </summary>
        /// <param name="info">including file name</param>
        /// <returns></returns>
        public static ITCTask ToITCTask_ShortName(string info)
        {
            try
            {
                ITCTask tmp = new ITCTask();
                tmp.taskName = info.Split('|')[0];
                tmp.isEnabled = Convert.ToBoolean(info.Split('|')[1]);
                tmp.ipAddr = info.Split('|')[2];
                tmp.username = info.Split('|')[3];
                tmp.password = info.Split('|')[4];
                tmp.filePath = ServiceLayer.AppPath + info.Split('|')[5];
                tmp.terminals = info.Split('|')[6];
                tmp.volume = Convert.ToByte(info.Split('|')[7]);
                tmp.schedule = Convert.ToDateTime(info.Split('|')[8]);
                return tmp;
            }
            catch
            {
                return null;
            }
        }
    }
}