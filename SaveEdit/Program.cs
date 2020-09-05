using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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

            if (Properties.Settings.Default.Lang == "")
            {
                //kvůli updatu z předchozích verzí
                if (File.Exists("fNbt.dll"))
                    File.Delete("fNbt.dll");
                Log.Write("Removing old fNbt.dll", Log.Verbosity.Info);
            }

            if (!File.Exists("Rozsirujici.dll"))
            {
                Log.Write("Extracting Rozsirujici.dll", Log.Verbosity.Info);
                File.WriteAllBytes("Rozsirujici.dll", Properties.Resources.Rozsirujici);
            }
            if (!File.Exists("fNbt.dll"))
            {
                Log.Write("Extracting fNbt.dll", Log.Verbosity.Info);
                File.WriteAllBytes("fNbt.dll", Properties.Resources.fNbt);
            }
            if (!File.Exists("CZ.xml") || Application.ProductVersion.Contains("dev"))
            {
                Log.Write("Extracting CZ.xml", Log.Verbosity.Info);
                File.WriteAllBytes("CZ.xml", Properties.Resources.CZ);
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
