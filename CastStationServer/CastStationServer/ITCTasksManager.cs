using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace CastStationServer
{
    class ITCTasksManager
    {
        public static List<ITCTask> AllTasks = new List<ITCTask>();
        public static ITCTask currentTask;
        public static ITCPlayer player;

        public static DateTime startTime;

        static System.Timers.Timer primaryTimer;

        public static void InitiateTimer()
        {
            startTime = DateTime.Now;
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
                primaryTimer.Start();
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
                SaveToFile();
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
                        SaveToFile();
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
                SaveToFile();
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
                FileInfo fi = new FileInfo(Program.StartupPath + "tasks.cst");
                fi.Delete();
                return "operation complete: file deleted";
            }
            catch (Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }

        public static string SaveToFile()
        {
            try
            {
                using (FileStream fs = new FileStream(Program.StartupPath + "tasks.cst", FileMode.Create, FileAccess.ReadWrite))
                {
                    StreamWriter sw = new StreamWriter(fs);
                    foreach (ITCTask task in AllTasks)
                    {
                        sw.WriteLine(SecurityCoder.Encrypt(task.ToString_Short()));
                    }
                    sw.Close();
                }
                return "operation complete: saved to file";
            }
            catch (Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }

        public static string LoadFromFile()
        {
            try
            {
                using (FileStream fs = new FileStream(Program.StartupPath + "tasks.cst", FileMode.Open, FileAccess.Read))
                {
                    AllTasks.Clear();
                    StreamReader sr = new StreamReader(fs);
                    while (!sr.EndOfStream)
                    {
                        AllTasks.Add(ITCTask.ToITCTask_LongPath(SecurityCoder.Decrypt(sr.ReadLine())));
                    }
                    sr.Close();
                }
                return "operation complete: loaded from file";
            }
            catch (Exception ex)
            {
                return "operation failed: " + ex.ToString();
            }
        }
    }
}