using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Threading;

namespace SaveEdit
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            bool update = false;
            if (args.Length > 0 && args[0] == "-update")
            {
                update = true;
            }
            if (!JednaInstance.Bezi(TimeSpan.FromMilliseconds(250), update))
            {
                bool aktul = false;
                if (File.Exists(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_SaveEdit.exe"))
                {
                    if (System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName == Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_SaveEdit.exe")
                    {
                        File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\SaveEdit.exe");
                        File.Copy(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_SaveEdit.exe", Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\SaveEdit.exe", true);
                        System.Diagnostics.Process.Start(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\SaveEdit.exe");
                        aktul = true;
                    }
                    else
                    {
                        try
                        {
                            File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_SaveEdit.exe");
                        }
                        catch { }
                    }
                }
                if (File.Exists(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_LibNbt.dll"))
                {

                    File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\LibNbt.dll");
                    File.Copy(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_LibNbt.dll", Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\LibNbt.dll", true);
                    try
                    {
                        File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_LibNbt.dll");
                    }
                    catch { }
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
                try
                {
                    
                    if (!aktul)
                        Application.Run(new Form1());
                }
                catch (Exception e)
                {
                    if (e.Message.Contains("assembly 'LibNbt") || e.Message.Contains("sestavení LibNbt") || e.Message.Contains(Jazyk.Strings.Sestaveni_libnbt))
                        Application.Run(new Form3());
                    else
                    {
                        MessageBox.Show(Jazyk.Strings.Pad, "SaveEdit: " + Jazyk.Strings.Kriticka_chyba);
                        string zprava = "\r\nVerze: " + Application.ProductVersion + "\r\n\r\n\r\n" + e.Message + "\r\n\r\n" + e.StackTrace + "\r\n\r\n" + e.Source;
                        OdeslaniZpravy odeslani = new OdeslaniZpravy(zprava);
                        odeslani.ShowDialog();
                    }
                }
                finally
                {
                    if(!update)
                        JednaInstance.UvolniProstredek();
                }
            }
            else
            {
                MessageBox.Show(Jazyk.Strings.SaveEdit_bezi, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
