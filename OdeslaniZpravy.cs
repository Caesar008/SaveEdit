using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Mail;

namespace SaveEdit
{
    public partial class OdeslaniZpravy : Form
    {
        string zprava;
        string soubor = null;
        sbyte co = 0;
        public OdeslaniZpravy(string zprava, sbyte co = 0)
        {
            InitializeComponent();
            this.co = co;
            this.zprava = richTextBox2.Text = zprava;
            if (co == 1)
                this.Text = Jazyk.Strings.Nahlasit_chybu;
            else if (co == 2)
                this.Text = Jazyk.Strings.Poslat_napad;
            try
            {
                if (System.IO.File.Exists(Properties.Settings.Default.cesta + "\\level.dat"))
                    soubor = Properties.Settings.Default.cesta + "\\level.dat";
                //MessageBox.Show(soubor);
            }
            catch { };
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            string save = "";
            if (co == 0)
            {
                if (novy.Checked)
                    save = "Nový save";
                else
                    save = "Save s použitým inventářem";
            }
            richTextBox2.Text = richTextBox1.Text + "\r\n\r\n" + save +  "\r\n" + zprava;
        }

        private void odeslat_Click(object sender, EventArgs e)
        {
            InfoZprava info = new InfoZprava();
            info.Show();
            info.Refresh();
            try
            {
                MailMessage objeto_mail = new MailMessage();
                SmtpClient client = new SmtpClient();
                client.UseDefaultCredentials = false;
                client.Port = 587;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new System.Net.NetworkCredential("saveedit.error@gmail.com", "GajusJuliusCaesar100prnl");
                objeto_mail.From = new MailAddress("info@saveedit.cz");
                objeto_mail.To.Add(new MailAddress("saveedit.error@gmail.com"));
                objeto_mail.Subject = "SaveEdit chyba";
                objeto_mail.Body = richTextBox2.Text;
                if(soubor != null)
                {
                    Attachment attachment;
                    attachment = new System.Net.Mail.Attachment(soubor);
                    objeto_mail.Attachments.Add(attachment);
                }
                client.Send(objeto_mail);
            }
            catch { MessageBox.Show(Jazyk.Strings.Error_error); }
            info.Close();
        }

        private void novy_CheckedChanged(object sender, EventArgs e)
        {
            string save = "";
            if (co == 0)
            {
                if (novy.Checked)
                    save = "Nový save";
                else
                    save = "Save s použitým inventářem";
            }
            else if (co == 1)
                save = "Hlášení chyby";
            else if (co == 2)
                save = "Nový nápad";
            richTextBox2.Text = richTextBox1.Text + "\r\n\r\n" + save + "\r\n\r\n" + zprava;
        }

        private void pripojit_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves";
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            if(openFileDialog1.FileName != null)
            {
                soubor = openFileDialog1.FileName;
            }
        }
    }
}
