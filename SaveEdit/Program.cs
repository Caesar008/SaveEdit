using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace SaveEdit
{
    static class Program
    {
        /// <summary>
        /// Hlavní vstupní bod aplikace.
        /// </summary>
        /// 
        static bool fnbtDown = false, rozsirDown = false, czDown = false, itemyXmlDown = false, itemyDown = false, terrainDown = false, armorDown = false;
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            if (File.Exists("DllUpdater.exe"))
                File.Delete("DllUpdater.exe");

            FileVersionInfo fi = FileVersionInfo.GetVersionInfo("fNbt.dll");

            if (Properties.Settings.Default.Lang == "" && fi.ProductVersion != Properties.Settings.Default.fNbtString)
            {
                //kvůli updatu z předchozích verzí
                File.WriteAllBytes("DllUpdater.exe", Properties.Resources.DllUpdater);
                Log.Write("Removing old fNbt.dll", Log.Verbosity.Info);
                Process.Start("DllUpdater.exe", "firstRun");
                Application.Exit();
            }

            if (!File.Exists("Rozsirujici.dll"))
            {
                try
                {
                    Log.Write("Downloading Rozsirujici.dll", Log.Verbosity.Info);
                    WebClient wc = new WebClient();
                    wc.DownloadFileCompleted += Wc_DownloadFileCompletedfNbt;
                    wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/Rozsirujici.dll", "Rozsirujici.dll");
                    wc.Dispose();
                    fnbtDown = true;
                }
                catch { fnbtDown = true; }
            }
            else
                fnbtDown = true;
            if (!File.Exists("fNbt.dll"))
            {
                try
                {
                    Log.Write("Downloading fNbt.dll", Log.Verbosity.Info);
                    WebClient wc = new WebClient();
                    wc.DownloadFileCompleted += Wc_DownloadFileCompletedRozsirujici;
                    wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/fNbt.dll", "fNbt.dll");
                    wc.Dispose();
                    rozsirDown = true;
                }
                catch { rozsirDown = true; }
            }
            else
                rozsirDown = true;
            if (!File.Exists("CZ.xml") || Application.ProductVersion.Contains("dev"))
            {
                try
                {
                    Log.Write("Downloading CZ.xml", Log.Verbosity.Info);
                    WebClient wc = new WebClient();
                    wc.DownloadFileCompleted += Wc_DownloadFileCompletedczXml;
                    wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/CZ.xml", "CZ.xml");
                    wc.Dispose();
                    czDown = true;
                }
                catch { czDown = true; }
            }
            else
                czDown = true;

            if (!File.Exists("itemy.xml"))
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFileCompleted += Wc_DownloadFileCompletedItemyXml;
                    wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/itemy.xml", "itemy.xml");
                    wc.Dispose();
                    itemyXmlDown = true;
                }
                catch { itemyXmlDown = true; }
            }
            else
                itemyXmlDown = true;

            if (!File.Exists("items.png"))
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFileCompleted += Wc_DownloadFileCompletedItemy;
                    wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/items.png", "items.png");
                    wc.Dispose();
                    itemyDown = true;
                }
                catch { itemyDown = true; }
            }
            else
                itemyDown = true;

            if (!File.Exists("terrain.png"))
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFileCompleted += Wc_DownloadFileCompletedTerrain;
                    wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/terrain.png", "terrain.png");
                    wc.Dispose();
                    terrainDown = true;
                }
                catch { terrainDown = true; }
            }
            else
                terrainDown = true;

            if (!File.Exists("ArmorSlotPics.png"))
            {
                try
                {
                    WebClient wc = new WebClient();
                    wc.DownloadFileCompleted += Wc_DownloadFileCompletedArmor;
                    wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/ArmorSlotPics.png", "ArmorSlotPics.png");
                    wc.Dispose();
                    armorDown = true;
                }
                catch { armorDown = true; }
            }
            else
                armorDown = true;

            if (!Rozsirujici.Program.JednaInstance.BeziGlobalne(TimeSpan.FromSeconds(5), "Caesaruv SaveEdit"))
            {
                try
                {
                    Log.Write("Starting Application Window", Log.Verbosity.Info);
                    while (!fnbtDown || !rozsirDown || !czDown || !itemyXmlDown || !itemyDown || !terrainDown || !armorDown)
                        System.Threading.Thread.Sleep(100);
                    Application.Run(new Form1());
                }
                catch (Exception e)
                {
                    if (Application.ProductVersion.EndsWith("dev"))
                    {
                        Log.Write("Developer version crashed.", Log.Verbosity.Critical);
                        MessageBox.Show(e.Message + "\r\n\r\n" + e.StackTrace);
                    }
                    else
                    {
                        Log.Write("SaveEdit crashed. Creating report file on Desktop", Log.Verbosity.Critical);
                        fNbt.NbtFile reportFile = new fNbt.NbtFile(new fNbt.NbtCompound("report"));
                        reportFile.RootTag.Add(new fNbt.NbtString("StackTrace", e.Message + "\r\n\r\n" + e.StackTrace));
                        string logFile = "";
                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\SaveEditLog.log"))
                            logFile = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\SaveEditLog.log");
                        reportFile.RootTag.Add(new fNbt.NbtString("LogFile", logFile));
                        if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastFile"))
                        {
                            reportFile.RootTag.Add(new fNbt.NbtByteArray("SaveFile", File.ReadAllBytes(File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastFile"))));
                        }
                        reportFile.SaveToFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\SaveEdit_crash.report", fNbt.NbtCompression.GZip);
                        MessageBox.Show(new Rozsirujici.Jazyk.Jazyk("CZ.xml").ReturnPreklad("Messages/ErrorCrash"), "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                Log.Write("SaveEdit is already running", Log.Verbosity.Warning);
                MessageBox.Show(new Rozsirujici.Jazyk.Jazyk("CZ.xml").ReturnPreklad("Messages/AlreadyRunning"));
            }

        }

        private static void Wc_DownloadFileCompletedArmor(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            armorDown = true;
        }

        private static void Wc_DownloadFileCompletedTerrain(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            terrainDown = true;
        }

        private static void Wc_DownloadFileCompletedItemy(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            itemyDown = true;
        }

        private static void Wc_DownloadFileCompletedItemyXml(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            itemyXmlDown = true;
        }

        private static void Wc_DownloadFileCompletedczXml(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            czDown = true;
        }

        private static void Wc_DownloadFileCompletedRozsirujici(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            rozsirDown = true;
        }

        private static void Wc_DownloadFileCompletedfNbt(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            fnbtDown = true;
        }
    }
}
