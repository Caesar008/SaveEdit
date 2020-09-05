using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Xml;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace SaveEdit
{
    public partial class NovyItem : Form
    {
        string obrazekURL = "";
        XmlDocument zapis = new XmlDocument();

        public NovyItem()
        {
            InitializeComponent();
            pridanyItemInfo.Text = "";
            if(File.Exists((Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\itemy.xml")))
                zapis.Load(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\itemy.xml");
            else
            {
                MessageBox.Show("Soubor se seznamem itemů nebyl nalezen.\r\nProsím prosím aktualizuj seznam itemů");
            }
        }

        public NovyItem(short id, decimal dmg)
        {
            InitializeComponent();
            pridanyItemInfo.Text = "";
            if (File.Exists((Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\itemy.xml")))
            {
                zapis.Load(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\itemy.xml");
                this.id.Text = id.ToString();
                this.poskozeni.Text = dmg.ToString();
            }
            else
            {
                MessageBox.Show("Soubor se seznamem itemů nebyl nalezen.\r\nProsím prosím aktualizuj seznam itemů");
            }
        }

        private void cesta_Click(object sender, EventArgs e)
        {
            otevritObrazek.ShowDialog();
        }

        private void najit_Click(object sender, EventArgs e)
        {
            otevritObrazek.ShowDialog();
        }

        private void otevritObrazek_FileOk(object sender, CancelEventArgs e)
        {
            cesta.Text = obrazekURL = otevritObrazek.FileName;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            if (jmeno.Text != "" && poskozeni.Text != "" && x.Text != "" && y.Text != "" && obrazekURL != "" && id.Text != "" && stringID.Text != "")
            {
                obrazekURL = obrazekURL.ToLower();
                int kategorie = 1;

                if (stavebni.Checked)
                    kategorie *= 11;
                if (dekorace.Checked)
                    kategorie *= 13;
                if (redstone.Checked)
                    kategorie *= 17;
                if (doprava.Checked)
                    kategorie *= 19;
                if (ruzne.Checked)
                    kategorie *= 23;
                if (jidlo.Checked)
                    kategorie *= 29;
                if (nastroje.Checked)
                    kategorie *= 31;
                if (bojove.Checked)
                    kategorie *= 37;
                if (lektvary.Checked)
                    kategorie *= 41;
                if (materialy.Checked)
                    kategorie *= 43;

                if (kategorie == 1)
                    kategorie = 9929;

                XmlNode item = zapis.CreateElement("Item");
                XmlNode idItemu = zapis.CreateElement("ID");
                idItemu.InnerText = id.Text;
                XmlNode stringId = zapis.CreateElement("StringID");
                stringId.InnerText = stringID.Text;
                XmlNode jmenoItemu = zapis.CreateElement("Jmeno");
                jmenoItemu.InnerText = jmeno.Text;
                XmlNode dmg = zapis.CreateElement("Dmg");
                dmg.InnerText = poskozeni.Text;
                XmlNode soubor = zapis.CreateElement("Soubor");
                soubor.InnerText = obrazekURL.Remove(0, obrazekURL.LastIndexOf('\\'));
                XmlNode zleva = zapis.CreateElement("PoziceZleva");
                zleva.InnerText = x.Text;
                XmlNode zprava = zapis.CreateElement("PoziceShora");
                zprava.InnerText = y.Text;
                XmlNode stack = zapis.CreateElement("Stackovatelnost");
                stack.InnerText = stackovatelny.Checked.ToString();
                XmlNode kat = zapis.CreateElement("Kategorie");
                kat.InnerText = kategorie.ToString();



                item.AppendChild(idItemu);
                item.AppendChild(stringId);
                item.AppendChild(jmenoItemu);
                item.AppendChild(dmg);
                item.AppendChild(soubor);
                item.AppendChild(zleva);
                item.AppendChild(zprava);
                item.AppendChild(stack);
                item.AppendChild(kat);

                if (File.Exists((Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\itemy.xml")))
                {
                    zapis.SelectSingleNode("Itemy/Seznam/Vlastni").AppendChild(item);
                    zapis.Save(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\itemy.xml");

                    pridanyItemInfo.Text = "Item s názvem \"" + jmeno.Text + "\" byl přidán.";
                }
                else
                {
                    MessageBox.Show("Soubor se seznamem itemů nebyl nalezen.\r\nProsím prosím aktualizuj seznam itemů");
                }
            }
            else
                MessageBox.Show("Některá položka je prázdná!");
        }
    }
}
