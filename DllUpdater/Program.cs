using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http.Headers;
using System.Threading;

namespace DllUpdater
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (args.Length>0 && args[0].ToLower() == "firstRun".ToLower())
            {
                int i = 0;

                retry:
                try
                {

                    if (File.Exists("fNbt.dll"))
                        File.Delete("fNbt.dll");
                    if (File.Exists("Rozsirujici.dll"))
                        File.Delete("Rozsirujici.dll");
                    Process.Start("SaveEdit.exe");
                }
                catch
                {
                    i++;
                    Thread.Sleep(100);
                    if (i < 50)
                        goto retry;
                }
            }
            else
            {
                int i = 0; 
                retryUpdate:
                try
                {
                    if (File.Exists("_fNbt.dll"))
                    {
                        File.Delete("fNbt.dll");
                        File.Move("_fNbt.dll", "fNbt.dll");
                    }
                    if (File.Exists("_Rozsirujici.dll"))
                    {
                        File.Delete("Rozsirujici.dll");
                        File.Move("_Rozsirujici.dll", "Rozsirujici.dll");
                    }
                    if (File.Exists("_SaveEdit.exe"))
                    {
                        File.Delete("SaveEdit.exe");
                        File.Move("_SaveEdit.exe", "SaveEdit.exe");
                    }
                    Process.Start("SaveEdit.exe");
                }
                catch
                {
                    i++;
                    Thread.Sleep(100);
                    if (i < 50)
                        goto retryUpdate;
                }
            }
        }
    }
}
