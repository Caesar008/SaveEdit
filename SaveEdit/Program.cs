﻿using System;
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
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            if (File.Exists("DllUpdater.exe"))
                File.Delete("DllUpdater.exe");

            FileVersionInfo fi = FileVersionInfo.GetVersionInfo("fNbt.dll");

            if (Properties.Settings.Default.Lang == "" && fi.ProductVersion != "0.6.4.0")
            {
                //kvůli updatu z předchozích verzí
                File.WriteAllBytes("DllUpdater.exe", Properties.Resources.DllUpdater);
                Log.Write("Removing old fNbt.dll", Log.Verbosity.Info);
                Process.Start("DllUpdater.exe");
                Application.Exit();
            }

            if (!File.Exists("Rozsirujici.dll"))
            {
                Log.Write("Downloading Rozsirujici.dll", Log.Verbosity.Info);
                WebClient wc = new WebClient();
                wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/Rozsirujici.dll", "Rozsirujici.dll");
                wc.Dispose();
            }
            if (!File.Exists("fNbt.dll"))
            {
                Log.Write("Downloading fNbt.dll", Log.Verbosity.Info);
                WebClient wc = new WebClient();
                wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/fNbt.dll", "fNbt.dll");
                wc.Dispose();
            }
            if (!File.Exists("CZ.xml") || Application.ProductVersion.Contains("dev"))
            {
                Log.Write("Downloading CZ.xml", Log.Verbosity.Info);
                WebClient wc = new WebClient();
                wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/CZ.xml", "CZ.xml");
                wc.Dispose();
            }

            if(!File.Exists("itemy.xml"))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/itemy.xml", "itemy.xml");
                wc.Dispose();
            }

            if (!File.Exists("items.png"))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/items.png", "items.png");
                wc.Dispose();
            }

            if (!File.Exists("terrain.png"))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/terrain.png", "terrain.png");
                wc.Dispose();
            }

            if (!File.Exists("ArmorSlotPics.png"))
            {
                WebClient wc = new WebClient();
                wc.DownloadFile("https://raw.githubusercontent.com/Caesar008/SaveEdit/master/SaveEdit/bin/Release/ArmorSlotPics.png", "ArmorSlotPics.png");
                wc.Dispose();
            }

            if (args.Length > 0 && args[0] == "-update")
            {
                //updatování sebe sama
                Log.Write("Updating SaveEdit using parameter -update", Log.Verbosity.Info);
            }
            else
            {
                if (!Rozsirujici.Program.JednaInstance.BeziGlobalne(TimeSpan.FromSeconds(5), "Caesaruv SaveEdit"))
                {
                    try
                    {
                        Log.Write("Starting Application Window", Log.Verbosity.Info);
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
        }
    }
}
