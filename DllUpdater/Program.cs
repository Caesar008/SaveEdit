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
        static void Main()
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
                if(i<20)
                    goto retry;
            }
        }
    }
}
