using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CastStationServer
{
    static class ServiceLayer
    {
        public static string AppPath
        {
            get
            {
                if (Application.StartupPath.EndsWith("\\")) { return Application.StartupPath; }
                else { return Application.StartupPath + "\\"; }
            }
        }

        public static List<ITCTask> AllTasks = new List<ITCTask>();
        public static ITCTask currentTask;
        public static ITCPlayer player;

        public static DateTime startTime;

        private static System.Threading.Timer trigTimer;
        static System.Timers.Timer primaryTimer;

        public static void InitiateTimer()
        {
            startTime = DateTime.Now;
            trigTimer = new System.Threading.Timer(new System.Threading.TimerCallback(trigTimer_Elapsed), null, 1000 * (60 - DateTime.Now.Second), 60000);
        }

        private static void trigTimer_Elapsed(object sender)
        {
            trigTimer.Dispose();
            primaryTimer = new System.Timers.Timer(30000);  //30 secends per check
            primaryTimer.Elapsed += primaryTimer_Elapsed;
            primaryTimer.Start();
        }

        private static void primaryTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                string current = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                foreach (ITCTask task in AllTasks)
                {
                    if (task.schedule.ToString("yyyy-MM-dd HH:mm") == current)
                    {
                        Start(task);
                    }
                }
            }
            catch { }
        }

        public static string Start(ITCTask task)
        {
            try
            {
                primaryTimer.Stop();
                currentTask = task;
                player = new ITCPlayer();
                player.SetUp(task);
                player.MessageComing += player_MessageComing;
                player.Start();
                return "task status: " + task.output;
            }
            catch (Exception ex)
            {
                primaryTimer.Start();
                return "operation failed: " + ex.ToString();
            }
        }

        public static string Start(string taskName)
        {
            try
            {
                foreach(ITCTask task in AllTasks)
                {
                    if (task.taskName == taskName)
                    {
                        primaryTimer.Stop();
                        currentTask = task;
                        player = new ITCPlayer();
                        player.SetUp(task);
                        player.MessageComing += player_MessageComing;
                        player.Start();
                        return "task status: " + task.output;
                    }
                }
                return "operation failed: task not found";
            }
            catch (Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }

        private static void player_MessageComing(string msg, bool isOver)
        {
            currentTask.output = msg;
            if (isOver)
            {
                currentTask.isEnabled = false;
                trigTimer = new System.Threading.Timer(new System.Threading.TimerCallback(trigTimer_Elapsed), null, 1000 * (60 - DateTime.Now.Second), 60000);
            }
        }

        public static string Stop()
        {
            try
            {
                player.Stop();
                return "operation complete: task stopped";
            }
            catch(Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }

        public static string GetAllTasks()
        {
            string result = "";
            foreach(ITCTask task in AllTasks)
            {
                result += task.ToString_Long() + Environment.NewLine;
            }
            if (result == "") { result = "no task"; }
            result = result.TrimEnd('\n');
            return result;
        }

        public static string AddTask(ITCTask task)
        {
            try
            {
                if (task != null)
                {
                    AllTasks.Add(task);
                }
                else
                {
                    return "operation failed: invalid task";
                }
                SaveTasksToFile();
                return "operation complete: added task";
            }
            catch(Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }

        public static string RemoveTask(string taskName)
        {
            try
            {
                foreach(ITCTask task in AllTasks)
                {
                    if (task.taskName == taskName)
                    {
                        AllTasks.Remove(task);
                        SaveTasksToFile();
                        return "operation complete: task removed";
                    }
                }
                return "operation failed: task not found";
            }
            catch (Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }

        public static string ClearTasks()
        {
            try
            {
                AllTasks.Clear();
                SaveTasksToFile();
                return "operation complete: list cleared";
            }
            catch(Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }

        public static string DeleteTasksFile()
        {
            try
            {
                FileInfo fi = new FileInfo(AppPath + "tasks.cst");
                fi.Delete();
                return "operation complete: tasks file deleted";
            }
            catch (Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }

        public static string SaveTasksToFile()
        {
            try
            {
                using (FileStream fs = new FileStream(AppPath + "tasks.cst", FileMode.Create, FileAccess.ReadWrite))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    foreach (ITCTask task in AllTasks)
                    {
                        sw.WriteLine(CryptoTools.Encrypt(task.ToString_Short()));
                    }
                    sw.Close();
                }
                return "operation complete: saved tasks to file";
            }
            catch (Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }

        public static string LoadTasksFromFile()
        {
            try
            {
                using (FileStream fs = new FileStream(AppPath + "tasks.cst", FileMode.Open, FileAccess.Read))
                {
                    AllTasks.Clear();
                    StreamReader sr = new StreamReader(fs);
                    while (!sr.EndOfStream)
                    {
                        AllTasks.Add(ITCTask.ToITCTask_LongPath(CryptoTools.Decrypt(sr.ReadLine())));
                    }
                    sr.Close();
                }
                return "operation complete: loaded tasks from file";
            }
            catch (Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }
    }
}