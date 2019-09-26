using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BingAdsSyncService
{
    delegate void SetTextCallback(string text);
    class Helper
    {
        private static string path = Path.GetPathRoot(Environment.SystemDirectory) + "\\";
        private static string logFile = path + "bingads.log";
        private static string settingFile = path + "setting.ini";
        public static event SetTextCallback MyEvent;
        //   public static event SetDataGridCallback MyDataEvent;
        //   public static event SetDataGridAutomation MyAutoEvent;
        public static void WriteLine(string str)
        {
            using (StreamWriter sw = File.AppendText(logFile))
            {
                sw.WriteLine(DateTime.Now.ToString("MMMM dd HH:mm:ss") + ":" + str);
                sw.Close();
            }
            MyEvent?.Invoke("\r\n" + str);
        }
        public static void WriteLineSp(string str)
        {
            using (StreamWriter sw = File.AppendText(logFile))
            {
                sw.WriteLine(DateTime.Now.ToString("MMMM dd HH:mm:ss") + ":" + "\r\n\r\n********************************************************************************************************************************************\r\n**\r\n**       " + str + "\r\n**\r\n**\r\n*******************************************************************************************************************\r\n\r\n");
                sw.Close();
            }
            MyEvent?.Invoke("\r\n\r\n********************************************************************************************************************************************\r\n**\r\n**       " + str + "\r\n**\r\n**\r\n*******************************************************************************************************************\r\n\r\n");
        }
        public static void Write(string str)
        {
            using (StreamWriter sw = File.AppendText(logFile))
            {
                sw.Write(str);
                sw.Close();
            }
            MyEvent?.Invoke(str);
        }
    }
}
