using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SaveEdit
{
    public static class Log
    {
        public static void Write(string log, Verbosity verbosity)
        {
            string logPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\SaveEditLog.log";
            string verbosityStr = "";
            switch (verbosity)
            {
                case Verbosity.Info:
                    verbosityStr = "Info";
                    break;
                case Verbosity.Warning:
                    verbosityStr = "Warning";
                    break;
                case Verbosity.Error:
                    verbosityStr = "Error";
                    break;
                case Verbosity.Critical:
                    verbosityStr = "Critical";
                    break;
                default:
                    verbosityStr = "Info";
                    break;

            }
            string dt = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss.fff");

            int wait = 0;
            while(IsFileLocked(new FileInfo(logPath)))
            {
                //čekání na odemčení souboru
                System.Threading.Thread.Sleep(100);
                wait++;

                if (wait > 300)
                {
                    break;
                }
            }
            try
            {
                File.AppendAllText(logPath, dt + "\t[" + verbosityStr + "]\t" + log + "\r\n");
            }
            catch { }
        }

        public static void Reset()
        {
            string logPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit";
            if (!Directory.Exists(logPath))
                Directory.CreateDirectory(logPath);
            File.WriteAllText(logPath + "\\SaveEditLog.log", System.Windows.Forms.Application.ProductVersion + "\r\n");
        }

        public enum Verbosity
        {
            Info,
            Warning,
            Error,
            Critical
        }

        static bool IsFileLocked(FileInfo file)
        {
            try
            {
                using (FileStream stream = file.Open(FileMode.Open, FileAccess.Read, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                //the file is unavailable because it is:
                //still being written to
                //or being processed by another thread
                //or does not exist (has already been processed)
                return true;
            }

            //file is not locked
            return false;
        }
    }
}
