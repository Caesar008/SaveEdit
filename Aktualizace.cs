using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Net;

namespace SaveEdit
{
    delegate void Aktualizuj();

    partial class Form1
    {
        static bool hotovo = true;
        internal bool restart = false, itemy = false, enchantybool = false, chyba = false;
        private List<Item> vlastniItemy = new List<Item>();
        short nalezeno = 0;
        Aktualizuj aktualizace;
        WebClient webclient = new WebClient();
        bool probihaAktualizace = false;

        private void ItemyStazeny()
        {
            XmlDocument zachovatVlastni = new XmlDocument();
            zachovatVlastni.Load(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\itemy.xml");

            if (!Nekompatibilita)
            {
                foreach (Item i in vlastniItemy)
                {
                    XmlNode item = zachovatVlastni.CreateElement("Item");
                    XmlNode id = zachovatVlastni.CreateElement("ID");
                    id.InnerText = i.ID.ToString();
                    XmlNode stringId = zachovatVlastni.CreateElement("StringID");
                    stringId.InnerText = i.StringID;
                    XmlNode jmeno = zachovatVlastni.CreateElement("Jmeno");
                    jmeno.InnerText = i.Jmeno;
                    XmlNode dmg = zachovatVlastni.CreateElement("Dmg");
                    dmg.InnerText = i.MaxPoskozeni.ToString();
                    XmlNode soubor = zachovatVlastni.CreateElement("Soubor");
                    soubor.InnerText = i.Obrazek;
                    XmlNode zleva = zachovatVlastni.CreateElement("PoziceZleva");
                    zleva.InnerText = i.X.ToString();
                    XmlNode zprava = zachovatVlastni.CreateElement("PoziceShora");
                    zprava.InnerText = i.Y.ToString();
                    XmlNode stack = zachovatVlastni.CreateElement("Stackovatelnost");
                    stack.InnerText = i.Stackovatelne.ToString();
                    XmlNode kat = zachovatVlastni.CreateElement("Kategorie");
                    kat.InnerText = i.Kategorie.ToString();

                    item.AppendChild(id);
                    item.AppendChild(stringId);
                    item.AppendChild(jmeno);
                    item.AppendChild(dmg);
                    item.AppendChild(soubor);
                    item.AppendChild(zleva);
                    item.AppendChild(zprava);
                    item.AppendChild(stack);
                    item.AppendChild(kat);

                    zachovatVlastni.SelectSingleNode("Itemy/Seznam/Vlastni").AppendChild(item);
                }
                zachovatVlastni.Save(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\itemy.xml");
            }
            Serializace s = new Serializace();
            Verze ver = s.Nacist(Path.GetTempPath() + "SaveEdit");
            this.Verze.GetObjekty["itemy"] = verzeItemu = int.Parse(zachovatVlastni.SelectSingleNode("Itemy/Verze").InnerText);
            Nekompatibilita = false;
            hotovo = true;

            itemInfo = zachovatVlastni.SelectSingleNode("Itemy/Minecraft").InnerText;
        }

        private void EnchantyStazeny()
        {
            enchantyList = Enchanty.Load();
            hotovo = true;
        }

        public void RefreshItem()
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(() => itemList.Clear()));

                this.BeginInvoke(new Action(() => seznamBlocku.Clear()));
                this.BeginInvoke(new Action(() => seznamBlocku.SmallImageList.Images.Clear()));
                this.BeginInvoke(new Action(() => seznamBlocku.Items.Clear()));

                if (Nacteno)
                {
                    this.BeginInvoke(new Action(() => label7.BringToFront()));
                    this.BeginInvoke(new Action(() => label7.Visible = true));

                    //this.BeginInvoke(new Action(() => this.Update()));

                    //tohle trochu zasekává okno -> zjistit proč
                    this.BeginInvoke(new Action(() => NactiObrazky(true)));
                    //this.BeginInvoke(new Action(() => label7.Visible = false));
                    if (Nacteno)
                    {
                        this.BeginInvoke(new Action(() => Ulozit()));
                        this.BeginInvoke(new Action(() => Nacti()));
                    }
                }
                return;
            }
            else
            {

                itemList.Clear();
                seznamBlocku.Clear();
                seznamBlocku.SmallImageList.Images.Clear();
                seznamBlocku.Items.Clear();

                if (Nacteno)
                {
                    label7.Visible = true;
                    label7.BringToFront();
                }
                NactiObrazky(true);
                label7.Visible = false;
                if (Nacteno)
                {
                    Ulozit();
                    Nacti();
                }
            }
        }

        private void Restart()
        {
            hotovo = true;
            if (File.Exists(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_SaveEdit.exe"))
            {
                System.Diagnostics.Process.Start(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_SaveEdit.exe", "-update");
            }
            else
                System.Diagnostics.Process.Start(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\SaveEdit.exe");
            this.Close();
        }

        private void HledejAuktualizaceAuto()
        {
            chyba = false;
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(() => aktualizovatToolStripMenuItem.Enabled = false));
            }
            else
                aktualizovatToolStripMenuItem.Enabled = false;
            
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(() => nalezeno = 0));
            }
            else
            {
                nalezeno = 0;
            }

            aktualizaceInfo.Text = "    " + Jazyk.Strings.Vyhledavam_aktualizace;
            try
            {
                WebClient webclient = new WebClient();
                webclient.Proxy = new WebProxy();
                webclient.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(webclient_Completed);
                /*try
                {*/
                    webclient.DownloadFileAsync(new Uri("https://goo.gl/FC4U27"), Path.GetTempPath() + "SaveEdit");
                /*}
                catch
                {
                    webclient.DownloadFileAsync(new Uri("http://dl.dropbox.com/u/65760892/SaveEdit"), Path.GetTempPath() + "SaveEdit");
                }*/
            }
            catch
            {
                aktualizaceInfo.Text = ("    " + Jazyk.Strings.Vyhledavam_aktualizace_chyba);
                hotovo = true;
                chyba = true;
                if (InvokeRequired)
                {
                    this.BeginInvoke(new Action(() => aktualizovatToolStripMenuItem.Enabled = true));
                }
                else
                    aktualizovatToolStripMenuItem.Enabled = true;
                if(backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();
            }
        }

        private void webclient_Completed(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            hotovo = true;
            try
            {
                Serializace s = new Serializace();
                Verze ver = s.Nacist(Path.GetTempPath() + "SaveEdit");
                if (verze < ver.GetObjekty["program"])
                {
                    nalezeno += 1;
                    aktualizace += AktualizujProgram;
                }
                if (verzeItemu < ver.GetObjekty["itemy"])
                {
                    nalezeno += 2;
                    aktualizace += AktualizujItemy;
                }
                try
                {
                    if (Enchanty.Verze < ver.GetObjekty["enchanty"])
                    {
                        nalezeno += 4;
                        aktualizace += AktualizujEnchanty;
                    }
                }
                catch
                {
                    nalezeno += 0;
                }
                try
                {
                    int verzeLibNtbt;
                    try
                    {
                        verzeLibNtbt = LibNbt.LibNbt.Version;
                    }
                    catch { verzeLibNtbt = 1; }
                    if (LibNbt.LibNbt.Version < ver.GetObjekty["dll"])
                    {
                        nalezeno += 8;
                        aktualizace += AktualizujDll;
                    }
                }
                catch
                {
                    nalezeno += 0;
                }
                switch (nalezeno)
                {
                    case 0:
                        aktualizaceInfo.Text = "";
                        break;
                    case 1:
                        aktualizaceInfo.Text = "    "+ Jazyk.Strings.Novy_program;
                        updateButton.Visible = true;
                        break;
                    case 2:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_item;
                        updateButton.Visible = true;
                        break;
                    case 3:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_program_item;
                        updateButton.Visible = true;
                        break;
                    case 4:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_enchant;
                        updateButton.Visible = true;
                        break;
                    case 5:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_program_enchant;
                        updateButton.Visible = true;
                        break;
                    case 6:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_item_enchant;
                        updateButton.Visible = true;
                        break;
                    case 7:
                        aktualizaceInfo.Text = "    " +  Jazyk.Strings.Novy_program_item_enchant;
                        updateButton.Visible = true;
                        break;
                    case 8:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_libnbt;
                        updateButton.Visible = true;
                        break;
                    case 9:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_program_libnbt;
                        updateButton.Visible = true;
                        break;
                    case 10:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_item_libnbt;
                        updateButton.Visible = true;
                        break;
                    case 11:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_program_item_libnbt;
                        updateButton.Visible = true;
                        break;
                    case 12:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_libnbt_enchant;
                        updateButton.Visible = true;
                        break;
                    case 13:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_program_libnbt_enchant;
                        updateButton.Visible = true;
                        break;
                    case 14:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_item_libnbt_enchant;
                        updateButton.Visible = true;
                        break;
                    case 15:
                        aktualizaceInfo.Text = "    " + Jazyk.Strings.Novy_program_item_libnbt_enchant;
                        updateButton.Visible = true;
                        break;
                    default:
                        {
                            aktualizaceInfo.Text = ("    " + Jazyk.Strings.Vyhledavam_aktualizace_chyba);
                            hotovo = true;
                            if (InvokeRequired)
                            {
                                this.BeginInvoke(new Action(() => aktualizovatToolStripMenuItem.Enabled = true));
                            }
                            else
                                aktualizovatToolStripMenuItem.Enabled = true;
                        }
                        break;
                }
            }
            catch
            {
                aktualizaceInfo.Text = ("    " + Jazyk.Strings.Vyhledavam_aktualizace_chyba);
                hotovo = true;
                chyba = true;
                aktualizovatToolStripMenuItem.Enabled = true;
            }
        }

        private void AktualizujProgram()
        {
            hotovo = false;
            aktualizaceInfo.Text = "    " + Jazyk.Strings.Stahuji_program;
            string mut = "EN";
            if (Properties.Settings.Default.jazyk == "CZ")
                mut = "";

            try
            {
                
                if(mut == "EN")
                {
                    webclient.DownloadFile(new Uri("https://goo.gl/ZewMB3"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\ChangelogEN.txt");
                }
                else
                {
                    webclient.DownloadFile(new Uri("https://goo.gl/ghQYLO"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Changelog.txt");
                }
                //webclient.DownloadFile(new Uri("http://dl.dropbox.com/u/65760892/Changelog" + mut + ".TXT"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Changelog" + mut + ".txt");
                try
                {
                    File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Návod" + mut + ".txt");
                }
                catch { }
                if (mut == "EN")
                {
                    webclient.DownloadFile(new Uri("https://goo.gl/oKLCRo"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\NávodEN.txt");
                }
                else
                {
                    webclient.DownloadFile(new Uri("https://goo.gl/N7o8mU"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Návod.txt");
                }
                //webclient.DownloadFile(new Uri("http://dl.dropbox.com/u/65760892/N%C3%A1vod" + mut + ".TXT"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Návod" + mut + ".txt");
                webclient.DownloadFile(new Uri("https://goo.gl/ScgPLx"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_SaveEdit.exe");
                //webclient.DownloadFile(new Uri("http://dl.dropbox.com/u/65760892/SaveEdit.exe"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_SaveEdit.exe");
                restart = true;
            }
            catch
            {
                aktualizaceInfo.Text = ("    " + Jazyk.Strings.Chyba_stahovani_programu);
                hotovo = true;
                chyba = true;
                System.Threading.Thread.Sleep(500);
            }
        }

        private void AktualizujItemy()
        {
            try
            {
                hotovo = false;
                aktualizaceInfo.Text = "    " + Jazyk.Strings.Stahovani_itemu;
                vlastniItemy = new List<Item>();
                string posledniRadek = "";
                string radek = "";
                int b = 0;
                if (!Nekompatibilita)
                {
                    try
                    {
                        if (File.Exists(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "//itemy.txt"))
                        {
                            TextReader vlastni = File.OpenText(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "//itemy.txt");
                            vlastni.ReadLine();
                            string test = vlastni.ReadLine();

                            if(test.Length == 3)
                                konec = test;
                            else
                                konec = vlastni.ReadLine();

                            while ((radek = vlastni.ReadLine()) != null)
                            {
                                try
                                {
                                    if (b > 10 && radek.Remove(radek.IndexOf('\t')) != konec.ToString() && posledniRadek.Remove(posledniRadek.IndexOf('\t')) == konec.ToString())
                                    {
                                        string[] poleCasti = radek.Split(new char[1] { '\t' });
                                        if (poleCasti.Length == 8)
                                            vlastniItemy.Add(new Item(Int32.Parse(poleCasti[0]), "", poleCasti[1], Int32.Parse(poleCasti[2]), poleCasti[3], Int16.Parse(poleCasti[4]), Int16.Parse(poleCasti[5]), Convert.ToBoolean(poleCasti[6]), short.Parse(poleCasti[7]), true, null, -1));
                                        else
                                            vlastniItemy.Add(new Item(Int32.Parse(poleCasti[0]), "", poleCasti[1], Int32.Parse(poleCasti[2]), poleCasti[3], Int16.Parse(poleCasti[4]), Int16.Parse(poleCasti[5]), Convert.ToBoolean(poleCasti[6]), 9929, true, null, -1));
                                    }
                                    else
                                    {
                                        posledniRadek = radek;
                                    }
                                }
                                catch { }

                                b++;
                            }
                            vlastni.Close();
                            File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "//itemy.txt");
                        }

                        try
                        {
                            XmlDocument vlastniXml = new XmlDocument();
                            vlastniXml.Load(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\itemy.xml");

                            XmlNodeList itemyVlastni = vlastniXml.SelectNodes("Itemy/Seznam/Vlastni/Item");
                            foreach (XmlNode item in itemyVlastni)
                            {
                                vlastniItemy.Add(new Item(Int32.Parse(item.SelectSingleNode("ID").InnerText), item.SelectSingleNode("StringID").InnerText, item.SelectSingleNode("Jmeno").InnerText, Int32.Parse(item.SelectSingleNode("Dmg").InnerText), item.SelectSingleNode("Soubor").InnerText, Int16.Parse(item.SelectSingleNode("PoziceZleva").InnerText), Int16.Parse(item.SelectSingleNode("PoziceShora").InnerText), Convert.ToBoolean(item.SelectSingleNode("Stackovatelnost").InnerText), short.Parse(item.SelectSingleNode("Kategorie").InnerText), true, null, -1));
                            }
                        }
                        catch { }
                    }
                    catch {  }
                }
                int pocetLoopu = 0; 
            loop:
                try
                {
                    File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\items.png");
                    webclient.DownloadFile(new Uri("https://goo.gl/xPQpDv"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\items.png");
                    //webclient.DownloadFile(new Uri("http://dl.dropbox.com/u/65760892/items.png"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\items.png");
                }
                catch
                {
                    this.Refresh();
                    System.Threading.Thread.Sleep(50);
                    pocetLoopu++;
                    if (pocetLoopu < 100)
                        goto loop;
                    else
                        throw new Exception();
                }
                pocetLoopu = 0;
            loop2:
                try
                {
                    File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\terrain.png");
                    webclient.DownloadFile(new Uri("https://goo.gl/GjwdPq"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\terrain.png");
                    //webclient.DownloadFile(new Uri("http://dl.dropbox.com/u/65760892/terrain.png"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\terrain.png");
                }
                catch
                {

                    this.Refresh();
                    System.Threading.Thread.Sleep(50);
                    pocetLoopu++;
                    if (pocetLoopu < 100)
                        goto loop2;
                    else
                        throw new Exception();
                }
                pocetLoopu = 0;
            loop3:
                try
                {
                    File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\itemy.xml");
                    webclient.DownloadFile(new Uri("https://goo.gl/X5fAj3"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\itemy.xml");
                    //webclient.DownloadFile(new Uri("http://dl.dropbox.com/u/65760892/itemy.xml"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\itemy.xml");
                    itemy = true;
                }
                catch
                {
                    this.Refresh();
                    System.Threading.Thread.Sleep(50);
                    pocetLoopu++;
                    if (pocetLoopu < 100)
                        goto loop3;
                    else
                        throw new Exception();
                }
            }
            catch
            {
                aktualizaceInfo.Text = ("    " + Jazyk.Strings.Chyba_stahovani_item);
                hotovo = true;
                chyba = true;
                System.Threading.Thread.Sleep(500);
            }
        }

        private void AktualizujEnchanty()
        {
            try
            {
                hotovo = false;
                aktualizaceInfo.Text = "    " + Jazyk.Strings.Stahovani_enchantu;
                webclient.Proxy = new WebProxy();
                if (File.Exists(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Enchanty.txt"))
                    File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Enchanty.txt");

                //TODO udělat zachování vlastních enchantů
                

                File.Delete(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Enchanty.xml");
                webclient.DownloadFile(new Uri("https://goo.gl/NuVgDi"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Enchanty.xml");
                //webclient.DownloadFile(new Uri("http://dl.dropbox.com/u/65760892/Enchanty.xml"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Enchanty.xml");
                enchantybool = true;

            }
            catch
            {
                aktualizaceInfo.Text = ("    " + Jazyk.Strings.Chyba_stahovani_enchant);
                hotovo = true;
                chyba = true;
                System.Threading.Thread.Sleep(500);
            }
        }

        private void AktualizujDll()
        {
            try
            {
                hotovo = false;
                aktualizaceInfo.Text = "    " + Jazyk.Strings.Stahovani_libnbt;
                webclient.Proxy = new WebProxy();
                webclient.DownloadFile(new Uri("https://goo.gl/9uRceZ"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_LibNbt.dll");
                //webclient.DownloadFile(new Uri("http://dl.dropbox.com/u/65760892/LibNbt.dll"), Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\_LibNbt.dll");
                restart = true;

            }
            catch
            {
                aktualizaceInfo.Text = ("    " + Jazyk.Strings.Chyba_stahovani_libnbt);
                hotovo = true;
                chyba = true;
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
