using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Click_TV
{
    class Logger
    {
        private static string _logFileName = "Log.txt";

        public enum LogLevel
        {
            INFO, WARNING, ERROR
        }

        /* Get log file size */
        private static long getLogFileSize()
        {
            FileInfo logSize = new FileInfo(_logFileName);
            return logSize.Length / 1024;
        }
        public static void Init()
        {
            try
            {
                if (getLogFileSize() > 100)
                {
                    /* Delete file */
                    using (StreamWriter _logWritter = new StreamWriter(_logFileName, false))
                    {
                        _logWritter.WriteLine("--- Лог файл был очищен ---");
                    }
                }
            }
            catch 
            {
 
            }
        }

        /* Write to log file */
        public static void Write(LogLevel level, string message)
        {
            using (StreamWriter _logWritter = new StreamWriter(_logFileName, true))
            {
                string logMessage = "[" + DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToShortTimeString() + "]";
                if (level == LogLevel.INFO)
                {
                    logMessage += "(INF):";
                }

                if (level == LogLevel.WARNING)
                {
                    logMessage += "(!WARN!):";
                }

                if (level == LogLevel.ERROR)
                {
                    logMessage += "(!!ERR!!):";
                }
                logMessage += " " + message;

                _logWritter.WriteLine(logMessage);
            }
        }
    }
}
