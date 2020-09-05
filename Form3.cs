using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SaveEdit
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            Aktualizuj();
        }

        internal void Aktualizuj()
        {
            textBox1.Text = Jazyk.Strings.Stahuji_LibNBT;

            try
            {
                WebClient webclient = new WebClient();
                webclient.Proxy = new WebProxy();
                webclient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webclient_DownloadCompleted);
                webclient.DownloadFileAsync(new Uri("http://dl.dropbox.com/u/65760892/LibNbt.dll"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_LibNbt.dll");
                
            }
            catch
            {
                textBox1.Text += ("\n\n" + Jazyk.Strings.Stahuji_LibNBT_err);
                this.ControlBox = true;
            }
        }
    

        private void webclient_DownloadCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Error == null)
                System.Diagnostics.Process.Start(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\SaveEdit.exe");
            else
                MessageBox.Show(Jazyk.Strings.Stahuji_LibNBT_err2);
            this.Close();
        }
    }
}
