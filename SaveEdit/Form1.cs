using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using fNbt;
using Rozsirujici;
using System.IO;
using System.Xml;
using System.Net;

namespace SaveEdit
{
    /*interní changelog 5.0.0.0
     - Podpora více jazyků 
     - Zrušena komppatibilita starších verzí hry než 1.13
     - Program od základů přepeacován
     - Přidávání vlastních itemů přes menu programu dočasně zrušeno
     - Zrušeno odesílání nápadů a chyb přímo v programu
     - Zrychleno načítání itemů a savu při použití ctrl+R
     */

    //VyberItem, řádek skoro 900 - upravit vybírání, nastavení co za okno vlastností se má otevřít

    public partial class Form1 : Form
    {
        #region Proměnné

        internal int verze = 5000000, minMcVerze = 0, mcVerze = 0, saveVerze = 0;
        internal Rozsirujici.Jazyk.Jazyk jazyk = new Rozsirujici.Jazyk.Jazyk("CZ.xml");
        internal bool en = true, dokoncenoNacitaniBloku = false, nacteno = false, naTlacitku = false;
        internal bool neulozeno = false, muzeHledat = false, toLoad = false, custom = false, zmena = true, canHide = true;
        string vybranySave, cesta, fullPath;
        NbtFile file, testFile;
        NacitamSave ns = null;
        string editor = "";
        internal Item itemToEdit = null;
        NovyItem novyItemWindows = null;
        int itemNum = 0;
        int itemTotal = 0;
        NacitamSave nsStart = null;
        internal List<Enchantment> enchanty = new List<Enchantment>();
        internal List<string> enchantySpecialTag = new List<string>();
        string tempFile = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\WorkingFile";

        #endregion

        #region Konstruktor

        public Form1()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            Log.Write("Starting SaveEdit", Log.Verbosity.Info);
            Log.Write("Initializing components", Log.Verbosity.Info);

            InitializeComponent();

            Log.Write("Opening loading screen", Log.Verbosity.Info);
            nsStart = new NacitamSave(this, true);
            nsStart.StartPosition = FormStartPosition.Manual;
            nsStart.Location = new Point(this.Location.X + (this.Width / 2) - (nsStart.Width / 2), this.Location.Y + (this.Height / 2) - (nsStart.Height / 2));
            nsStart.Show();

            kopirovatBtn.Enabled = false;
            vlozitBtn.Enabled = false;
            poNacteni.BringToFront();
            seznamBlocku.SmallImageList = new ImageList { ColorDepth = ColorDepth.Depth24Bit };
            seznamBlockuSearch.SmallImageList = new ImageList { ColorDepth = ColorDepth.Depth24Bit };
            seznamBlockuSearch.Visible = false;

            novy.Visible = false;
            poslatNápadToolStripMenuItem.Visible = false;
            nahlásitChybuToolStripMenuItem.Visible = false;
            poskozeni.Enabled = false;
            poskozeni.Minimum = 0;
            pocet.Minimum = 0;

            Log.Write("Checking language", Log.Verbosity.Info);
            if (Properties.Settings.Default.Lang == "")
            {
                Log.Write("First run of this file version found", Log.Verbosity.Info);
                if (DialogResult.Yes == MessageBox.Show("We have found first run of this program.\r\nDo you want to keep English?\r\nIf you will select \"No\", Czech will be set.\r\n\r\nZjistitli jsme první spuštění tohoto programu.\r\nPřejete si ponechat angličtinu?\r\nPokud vyberete \"Ne\", bude nastavena čeština.", "Language / Jazyk", MessageBoxButtons.YesNo))
                {
                    Properties.Settings.Default.Lang = "EN";
                    Log.Write("Settings EN language", Log.Verbosity.Info);
                }
                else
                {
                    Properties.Settings.Default.Lang = "CZ";
                    Log.Write("Setting CZ language", Log.Verbosity.Info);
                }
                Properties.Settings.Default.Save();
            }

            NastavJazyk();
            ResetItems();

            Log.Write("Starting async load of images", Log.Verbosity.Info);
            backgroundWorker2.RunWorkerAsync();

            try
            {
                Log.Write("Checking default Minecraft saves path", Log.Verbosity.Info);
                cesta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves";
                if (Properties.Settings.Default.cesta != string.Empty && Directory.Exists(Properties.Settings.Default.cesta))
                {
                    cesta = Properties.Settings.Default.cesta;
                    otevritDial.InitialDirectory = cesta;
                }
                string[] soubory = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves");
                foreach (string s in soubory)
                {
                    if(File.Exists(s + "\\level.dat"))
                        otevrit.DropDownItems.Add(s.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\", ""));
                }
                otevritDial.InitialDirectory = cesta;
            }
            catch (Exception e)
            {
                Log.Write("No save in default path found", Log.Verbosity.Info);
                MessageBox.Show(e.Message + "\r\n\r\n" + jazyk.ReturnPreklad("Messages/NotInstalled"), "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

        private void Form1_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if(neulozeno)
            {
                DialogResult diagRes = MessageBox.Show(jazyk.ReturnPreklad("Messages/WannaSave", en), "SaveEdit", MessageBoxButtons.YesNoCancel);
                if (diagRes == DialogResult.Yes)
                    Ulozit();
                else if (diagRes == DialogResult.No)
                {
                    Log.Write("Removing WorkingFile without saving", Log.Verbosity.Info);
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\WorkingFile");
                }
                else
                {
                    e.Cancel = true;
                    return;
                }
            }

            Log.Write("Removing copy of working file", Log.Verbosity.Info);
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\WorkingFile"))
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\WorkingFile");
            
            Log.Write("Removing last edit file", Log.Verbosity.Info);
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastEditFile"))
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastEditFile");

            Log.Write("Closing SaveEdit", Log.Verbosity.Info);
            Rozsirujici.Program.JednaInstance.UvolniProstredek();
        }

        private void ResetItems()
        {
            Log.Write("Setting inventory to default state", Log.Verbosity.Info);
            i0.Tag = new Tag(0, null);
            popisek.SetToolTip(i0, null);
            i1.Tag = new Tag(1, null);
            popisek.SetToolTip(i1, null);
            i10.Tag = new Tag(10, null);
            popisek.SetToolTip(i10, null);
            Bitmap brObr = new Bitmap("ArmorSlotPics.png");
            i100.Tag = new Tag(100, null);
            popisek.SetToolTip(i100, null);
            i100.Image = Rozsirujici.Grafika.Obrazek.ResizeBMP((Bitmap)brObr.Clone(new Rectangle(0, 48 , 16, 16), brObr.PixelFormat), 32, 32, Rozsirujici.Grafika.Obrazek.PomerStran.Cílový, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
            i101.Tag = new Tag(101, null);
            popisek.SetToolTip(i101, null);
            i101.Image = Rozsirujici.Grafika.Obrazek.ResizeBMP((Bitmap)brObr.Clone(new Rectangle(0, 32, 16, 16), brObr.PixelFormat), 32, 32, Rozsirujici.Grafika.Obrazek.PomerStran.Cílový, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
            i102.Tag = new Tag(102, null);
            popisek.SetToolTip(i102, null);
            i102.Image = Rozsirujici.Grafika.Obrazek.ResizeBMP((Bitmap)brObr.Clone(new Rectangle(0, 16, 16, 16), brObr.PixelFormat), 32, 32, Rozsirujici.Grafika.Obrazek.PomerStran.Cílový, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
            i103.Tag = new Tag(103, null);
            popisek.SetToolTip(i103, null);
            i103.Image = Rozsirujici.Grafika.Obrazek.ResizeBMP((Bitmap)brObr.Clone(new Rectangle(0, 0, 16, 16), brObr.PixelFormat), 32, 32, Rozsirujici.Grafika.Obrazek.PomerStran.Cílový, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
            i11.Tag = new Tag(11, null);
            popisek.SetToolTip(i11, null);
            i12.Tag = new Tag(12, null);
            popisek.SetToolTip(i12, null);
            i13.Tag = new Tag(13, null);
            popisek.SetToolTip(i13, null);
            i14.Tag = new Tag(14, null);
            popisek.SetToolTip(i14, null);
            i15.Tag = new Tag(15, null);
            popisek.SetToolTip(i15, null);
            i150.Tag = new Tag(150, null);
            popisek.SetToolTip(i150, null);
            i150.Image = Rozsirujici.Grafika.Obrazek.ResizeBMP((Bitmap)brObr.Clone(new Rectangle(0, 64, 16, 16), brObr.PixelFormat), 32, 32, Rozsirujici.Grafika.Obrazek.PomerStran.Cílový, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
            i16.Tag = new Tag(16, null);
            popisek.SetToolTip(i16, null);
            i17.Tag = new Tag(17, null);
            popisek.SetToolTip(i17, null);
            i18.Tag = new Tag(18, null);
            popisek.SetToolTip(i18, null);
            i19.Tag = new Tag(19, null);
            popisek.SetToolTip(i19, null);
            i2.Tag = new Tag(2, null);
            popisek.SetToolTip(i2, null);
            i20.Tag = new Tag(20, null);
            popisek.SetToolTip(i20, null);
            i21.Tag = new Tag(21, null);
            popisek.SetToolTip(i21, null);
            i22.Tag = new Tag(22, null);
            popisek.SetToolTip(i22, null);
            i23.Tag = new Tag(23, null);
            popisek.SetToolTip(i23, null);
            i24.Tag = new Tag(24, null);
            popisek.SetToolTip(i24, null);
            i25.Tag = new Tag(25, null);
            popisek.SetToolTip(i25, null);
            i26.Tag = new Tag(26, null);
            popisek.SetToolTip(i26, null);
            i27.Tag = new Tag(27, null);
            popisek.SetToolTip(i27, null);
            i28.Tag = new Tag(28, null);
            popisek.SetToolTip(i28, null);
            i29.Tag = new Tag(29, null);
            popisek.SetToolTip(i29, null);
            i3.Tag = new Tag(3, null);
            popisek.SetToolTip(i3, null);
            i30.Tag = new Tag(30, null);
            popisek.SetToolTip(i30, null);
            i31.Tag = new Tag(31, null);
            popisek.SetToolTip(i31, null);
            i32.Tag = new Tag(32, null);
            popisek.SetToolTip(i32, null);
            i33.Tag = new Tag(33, null);
            popisek.SetToolTip(i33, null);
            i34.Tag = new Tag(34, null);
            popisek.SetToolTip(i34, null);
            i35.Tag = new Tag(35, null);
            popisek.SetToolTip(i35, null);
            i4.Tag = new Tag(4, null);
            popisek.SetToolTip(i4, null);
            i5.Tag = new Tag(5, null);
            popisek.SetToolTip(i5, null);
            i6.Tag = new Tag(6, null);
            popisek.SetToolTip(i6, null);
            i7.Tag = new Tag(7, null);
            popisek.SetToolTip(i7, null);
            i8.Tag = new Tag(8, null);
            popisek.SetToolTip(i8, null);
            i9.Tag = new Tag(9, null);
            popisek.SetToolTip(i9, null);
        }

        private void NastavJazyk()
        {
            Log.Write("Settings language for main window components", Log.Verbosity.Info);
            if (Properties.Settings.Default.Lang != "EN")
                en = false;
            Log.Write("Language property en = " + en.ToString(), Log.Verbosity.Info);
            lbl_pocet.Text = jazyk.ReturnPreklad("MainWindow/Count", en);
            lbl_poskozeni.Text = jazyk.ReturnPreklad("MainWindow/Damage", en);
            lbl_xpLevel.Text = jazyk.ReturnPreklad("MainWindow/XpLevel", en);
            lbl_zacit.Text = jazyk.ReturnPreklad("MainWindow/Begin", en);
            muzeHledat = false;
            vyhledavani.Text = jazyk.ReturnPreklad("MainWindow/Search", en);
        }

        private void otevrit_Click(object sender, System.EventArgs e)
        {
            if (!otevrit.DropDownButtonPressed)
                otevritDial.ShowDialog();
        }

        private void otevrit_DropDownItemClicked(object sender, System.Windows.Forms.ToolStripItemClickedEventArgs e)
        {
            custom = false;
            ClearButtonsAndShowInfo();
            vybranySave = e.ClickedItem.ToString();

            if (!backgroundWorker2.IsBusy)
            {
                    Nacti();
                if (ns != null)
                {
                    foreach (Control c in this.Controls)
                        c.Enabled = true;
                    ns.Close();
                }
            }
            else
            {
                toLoad = true;
            }
        }

        void ClearButtonsAndShowInfo()
        {
            ns = new NacitamSave(this);
            ns.StartPosition = FormStartPosition.Manual;
            ns.Location = new Point(this.Location.X + (this.Width/2) - (ns.Width/2), this.Location.Y + (this.Height / 2) - (ns.Height / 2));

            DialogResult res = new DialogResult();
            if (neulozeno)
                res = MessageBox.Show(jazyk.ReturnPreklad("Messages/WannaSave"), "SaveEdit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.No)
            {
                neulozeno = false;
                this.Text = "SaveEdit";
                Log.Write("Removing WorkingFile without saving", Log.Verbosity.Info);
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\WorkingFile");
            }
            else if (res == DialogResult.Yes)
                Ulozit();

            //čištění tlačítek
            Log.Write("Clearing inventory buttons properties", Log.Verbosity.Info);
            foreach (Control c in Controls)
                if (c.Tag != null && ((Tag)c.Tag).JeInvSlot)
                {
                    c.Text = "";
                    ((Button)c).Image = null;
                    ((Button)c).ForeColor = Color.Black;
                }
            ResetItems();

            foreach (Control c in this.Controls)
                c.Enabled = false;
            ns.Show();
            ns.Refresh();
        }

        internal void LastEditFile()
        {
            Log.Write("Creating last edit file", Log.Verbosity.Info);
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastEditFile"))
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastEditFile");
            file.SaveToFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastEditFile", file.FileCompression);
        }

        internal void Nacti(bool ignorovatNeulozeno = false)
        {
            if (!ignorovatNeulozeno)
            {
                if (neulozeno)
                {
                    DialogResult diagRes = MessageBox.Show(jazyk.ReturnPreklad("Messages/WannaSave", en), "SaveEdit", MessageBoxButtons.YesNoCancel);
                    if (diagRes == DialogResult.Yes)
                        Ulozit();
                    else if (diagRes == DialogResult.No)
                    {
                        Log.Write("Removing WorkingFile without saving", Log.Verbosity.Info);
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\WorkingFile");
                    }
                    else
                    {
                        return;
                    }
                }

                Log.Write("Loading save", Log.Verbosity.Info);
                testFile = null;
                //string player = string.Empty;
                if (!vybranySave.Contains(@".minecraft\saves"))
                {
                    Log.Write("Loading save " + vybranySave, Log.Verbosity.Info);
                    testFile = new NbtFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + vybranySave + @"\level.dat");

                    Log.Write("Creating working copy file", Log.Verbosity.Info);
                    if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\WorkingFile"))
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\WorkingFile");
                    File.Copy(Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + vybranySave + @"\playerdata")[0], tempFile);

                    fullPath = Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + vybranySave + @"\playerdata")[0];
                }
                else
                {
                    Log.Write("Loading save " + vybranySave, Log.Verbosity.Info);
                    fullPath = Directory.GetFiles(vybranySave + @"\playerdata")[0];
                    testFile = new NbtFile(vybranySave + @"\level.dat");
                }
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastFile", fullPath);

                //tady bude kontrola verze.
                //https://minecraft.gamepedia.com/Java_Edition_data_values#Protocol_and_data_versions
                //minimální podporovaná verze uvedena v itemy.xml
            }
            Log.Write("Checking if save is from at least version " + minMcVerze, Log.Verbosity.Info);
            if (testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version") != null && testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version").Get<NbtInt>("Id").Value >= minMcVerze)
            {
                saveVerze = testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version").Get<NbtInt>("Id").Value;
                Log.Write("Save is version " + saveVerze, Log.Verbosity.Info);

                file = new NbtFile(tempFile);

                Log.Write("Loading inventory", Log.Verbosity.Info);
                foreach (NbtCompound item in file.RootTag.Get<NbtList>("Inventory"))
                {
                    foreach (Control c in Controls)
                    {
                        if (c.Tag != null && ((Tag)c.Tag).JeInvSlot && ((Tag)c.Tag).Slot == item.Get<NbtByte>("Slot").Value)
                        {
                            ((Tag)c.Tag).Item = new Item(item, this);
                            Log.Write("Loading item " + ((Tag)c.Tag).Item.ID + " into slot " + ((Tag)c.Tag).Slot, Log.Verbosity.Info);

                            Bitmap b = new Bitmap(36, 36);
                            Graphics g = Graphics.FromImage(b);
                            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                            g.DrawImage(Rozsirujici.Grafika.Obrazek.ResizeBMP(((Tag)c.Tag).Item.Image, 32, 32, Rozsirujici.Grafika.Obrazek.PomerStran.Originální, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor), 2, 3);
                            //Bitmap img = Rozsirujici.Grafika.Obrazek.ResizeBMP(((Tag)c.Tag).Item.Image, 32, 32, Rozsirujici.Grafika.Obrazek.PomerStran.Originální, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
                            float size = 13;
                            int x, y;
                            if (((Tag)c.Tag).Item.Count.ToString().Length == 2)
                            {
                                x = 15;
                                y = 20;
                            }
                            else if (((Tag)c.Tag).Item.Count.ToString().Length == 1)
                            {
                                x = 24;
                                y = 20;
                            }
                            else if (((Tag)c.Tag).Item.Count.ToString().Length == 3)
                            {
                                x = 6;
                                y = 20;
                            }
                            else
                            {
                                x = 0;
                                y = 0;
                                size = 12.25f;
                            }

                            if (((Tag)c.Tag).Item.MaxDamage <= 0 || ((Tag)c.Tag).Item.Damage <= 0)
                                ((Button)c).Image = Rozsirujici.Grafika.Obrazek.AddText(b, ((Tag)c.Tag).Item.Count.ToString(), Brushes.White, Color.Black, new FontFamily("Arial Black"), FontStyle.Bold, size, new Point(x, y));
                            else
                                ((Button)c).Image = DamageBar(Rozsirujici.Grafika.Obrazek.AddText(b, ((Tag)c.Tag).Item.Count.ToString(), Brushes.White, Color.Black, new FontFamily("Arial Black"), FontStyle.Bold, size, new Point(x, y)), ((Tag)c.Tag).Item.MaxDamage, ((Tag)c.Tag).Item.Damage);
                            g.Dispose();
                            g = null;
                            //přidat nénchant pozadí když má Enchantments tag
                            if (((Tag)c.Tag).Item.Enchanty != null && ((Tag)c.Tag).Item.Enchanty.Count > 0)
                            {
                                ((Button)c).Image = EnchantLabel((Bitmap)((Button)c).Image);
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                Log.Write("Save from too old version", Log.Verbosity.Warning);
                //tohle uzdělat v případě savu před 1.13. Upozornění, že nepodporováno.
                if (testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version") != null)
                {
                    Log.Write("Save version is " + testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version").Get<NbtString>("Name").Value, Log.Verbosity.Warning);
                    MessageBox.Show(jazyk.ReturnPreklad("Messages/NotSupported", en) + " (" + testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version").Get<NbtString>("Name").Value + ")");
                }
                else
                {
                    Log.Write("Save version is empty", Log.Verbosity.Warning);
                    MessageBox.Show(jazyk.ReturnPreklad("Messages/NotSupported", en));
                }
                return;
            }

            /*}
            else
            {
                string player = Directory.GetFiles(vybranySave + @"\playerdata")[0];
                
                //save.LoadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + item + @"\playerdata\");
                //tady bude kontrola verze. id 1483 je 18w16a
            }*/

            nacteno = true;
            if (!ignorovatNeulozeno)
            {
                i0.Focus();
                i0.Select();
            }

            poNacteni.Dispose();

            Log.Write("Selecting slot 0", Log.Verbosity.Info);
            VyberItem(0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }

        void NactiCustom(bool ignorovatNeulozeno = false)
        {
            if (!ignorovatNeulozeno)
            {
                if (neulozeno)
                {
                    DialogResult diagRes = MessageBox.Show(jazyk.ReturnPreklad("Messages/WannaSave", en), "SaveEdit", MessageBoxButtons.YesNoCancel);
                    if (diagRes == DialogResult.Yes)
                        Ulozit();
                    else if (diagRes == DialogResult.No)
                    {
                        Log.Write("Removing WorkingFile without saving", Log.Verbosity.Info);
                        File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\WorkingFile");
                    }
                    else
                    {
                        return;
                    }
                }

                Log.Write("Loading custom save file", Log.Verbosity.Info);
                NbtFile testFile = new NbtFile(vybranySave);
                fullPath = vybranySave;
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastFile", vybranySave);

                //tady bude kontrola verze.
                //https://minecraft.gamepedia.com/Java_Edition_data_values#Protocol_and_data_versions
                //minimální podporovaná verze uvedena v itemy.xml
            }
            Log.Write("Checking if save is from at least version " + minMcVerze, Log.Verbosity.Info);
            if (testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version") != null && testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version").Get<NbtInt>("Id").Value >= minMcVerze)
            {
                saveVerze = testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version").Get<NbtInt>("Id").Value;
                Log.Write("Save is version " + saveVerze, Log.Verbosity.Info);

                file = new NbtFile(tempFile);

                Log.Write("Loading inventory", Log.Verbosity.Info);
                foreach (NbtCompound item in file.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory"))
                {
                    foreach (Control c in Controls)
                    {
                        if (c.Tag != null && ((Tag)c.Tag).JeInvSlot && ((Tag)c.Tag).Slot == item.Get<NbtByte>("Slot").Value)
                        {

                            PridejObrazek(c, item);
                            break;
                        }
                    }
                }
            }
            else
            {
                //tohle uzdělat v případě savu před 1.13. Upozornění, že nepodporováno.
                Log.Write("Save from too old version", Log.Verbosity.Warning);
                if (testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version") != null)
                {
                    Log.Write("Save version is " + testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version").Get<NbtString>("Name").Value, Log.Verbosity.Warning);
                    MessageBox.Show(jazyk.ReturnPreklad("Messages/NotSupported", en) + " (" + testFile.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Version").Get<NbtString>("Name").Value + ")");
                }
                else
                {
                    Log.Write("Save version is empty", Log.Verbosity.Warning);
                    MessageBox.Show(jazyk.ReturnPreklad("Messages/NotSupported", en));
                }
            }

            nacteno = true;
            if (!ignorovatNeulozeno)
            {
                i0.Focus();
                i0.Select();
            }

            poNacteni.Dispose();

            Log.Write("Selecting slot 0", Log.Verbosity.Info);
            VyberItem(0);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
        }

        private void otevritDial_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            vybranySave = otevritDial.FileName;
            custom = true;
            ClearButtonsAndShowInfo();
            if (!backgroundWorker2.IsBusy)
            {
                NactiCustom();
                if (ns != null)
                {
                    foreach (Control c in this.Controls)
                        c.Enabled = true;
                    ns.Close();
                }
            }
            else
            {
                toLoad = true;
            }
            
        }

        private Bitmap DamageBar(Bitmap bitmapa, int maxPoskozeni, int aktualniPoskozeni)
        {
            if (aktualniPoskozeni < 0)
                aktualniPoskozeni = 0;
            int sirka = 36 - (int)((double)36 / (double)maxPoskozeni * (double)aktualniPoskozeni);
            if (sirka < 0)
                sirka = 0;
            if (maxPoskozeni > 0 && aktualniPoskozeni > 0)
            {
                Log.Write("Drawing damage bar in item image", Log.Verbosity.Info);
                Graphics g = Graphics.FromImage((Image)bitmapa);
                Bitmap bod2 = new Bitmap(1, 1);
                bod2.SetPixel(0, 0, Color.FromArgb(180, 180, 180));
                bod2 = Rozsirujici.Grafika.Obrazek.ResizeBMP(bod2, 36, 3, Rozsirujici.Grafika.Obrazek.PomerStran.Cílový, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
                g.DrawImage(bod2, 0, 0);
                if (sirka > 0)
                {
                    Bitmap bod = new Bitmap(1, 1);
                    bod.SetPixel(0, 0, Color.FromArgb((int)((double)255 / (double)maxPoskozeni * (double)aktualniPoskozeni), (int)((double)255 - ((double)255 / (double)maxPoskozeni * (double)aktualniPoskozeni)), 0));
                    bod = Rozsirujici.Grafika.Obrazek.ResizeBMP(bod, sirka, 3, Rozsirujici.Grafika.Obrazek.PomerStran.Cílový, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
                    g.DrawImage(bod, 0, 0);
                }
                g.Dispose();
                g = null;
            }
            return bitmapa;
        }

        private void backgroundWorker2_Complete(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (nsStart != null)
            {
                canHide = false;
                this.Show();
                nsStart.Close();
            }
            //if (nacteno)
            //{
            Log.Write("Loading MC items and images complete", Log.Verbosity.Info);
            Log.Write("Loaded " + itemNum + " items out of " + itemTotal, Log.Verbosity.Info);
            seznamBlocku.Visible = true;
            seznamBlockuSearch.Visible = false;
            dokoncenoNacitaniBloku = true;
            vyhledavani.Enabled = true;
            if(toLoad)
            {
                toLoad = false;
                if (!custom)
                    Nacti();
                else
                    NactiCustom();
                if (ns != null)
                {
                    foreach (Control c in this.Controls)
                        c.Enabled = true;
                    ns.Close();
                }
            }
            //label7.BackColor = Color.White;
            //}
        }

        internal void backgroundWorker2_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Log.Write("Starting async loading of MC items and images", Log.Verbosity.Info);
            try
            {
                NactiObrazky(true);
            }
            catch (Exception ee){ Log.Write("Error during loading items for list: " + ee.Message, Log.Verbosity.Error); }
        }

        void NactiObrazky(bool seznam, string text = "")
        {
            if (!File.Exists("terrain.png"))
            {
                Log.Write("Extracting terrain.png", Log.Verbosity.Info);
            }
            if (!File.Exists("items.png"))
            {
                Log.Write("Extracting items.png", Log.Verbosity.Info);
            }
            if (!File.Exists("itemy.xml"))
            {
                Log.Write("Extracting itemy.xml", Log.Verbosity.Info);
            }
            if (!File.Exists("ArmorSlotPics.png"))
            {
                Log.Write("Extracting ArmorSlotPics.png", Log.Verbosity.Info);
            }

            itemNum = 0;
            itemTotal = 0;

            //načítání pro seznam
            if (seznam)
            {
                Log.Write("Starting loading images and items for list", Log.Verbosity.Info);
                //aktualizaceInfo.Text = "  ";

                dokoncenoNacitaniBloku = false;
                if (!InvokeRequired)
                {
                    seznamBlocku.BeginUpdate();
                    seznamBlocku.Items.Clear();
                    seznamBlocku.SmallImageList.Images.Clear();
                    seznamBlocku.Update();
                    seznamBlockuSearch.BeginUpdate();
                    seznamBlockuSearch.Items.Clear();
                    seznamBlockuSearch.SmallImageList.Images.Clear();
                }
                else
                {
                    this.Invoke(new Action(() => seznamBlocku.BeginUpdate()));
                    this.Invoke(new Action(() => seznamBlocku.Items.Clear()));
                    this.Invoke(new Action(() => seznamBlocku.SmallImageList.Images.Clear()));
                    this.Invoke(new Action(() => seznamBlockuSearch.BeginUpdate()));
                    this.Invoke(new Action(() => seznamBlockuSearch.Items.Clear()));
                    this.Invoke(new Action(() => seznamBlockuSearch.SmallImageList.Images.Clear()));
                }

                Log.Write("Loading itemy.xml", Log.Verbosity.Info);
                XmlDocument xmlItemy = new XmlDocument();
                enchanty = new List<Enchantment>();
                enchantySpecialTag = new List<string>();
                xmlItemy.Load("itemy.xml");
                minMcVerze = int.Parse(xmlItemy.SelectSingleNode("Itemy/Minecraft").Attributes["min"].Value);
                mcVerze = int.Parse(xmlItemy.SelectSingleNode("Itemy/Minecraft").Attributes["mc"].Value);
                itemTotal = int.Parse(xmlItemy.SelectSingleNode("Itemy/Itemy").Attributes["total"].Value);

                Log.Write("Property minMcVerze = " + minMcVerze, Log.Verbosity.Info);
                Log.Write("Property mcVerze = " + mcVerze, Log.Verbosity.Info);

                XmlNodeList xmlItemList = xmlItemy.SelectNodes("Itemy/Itemy/Item");

                foreach (XmlNode xmlItem in xmlItemList)
                {
                    string id = xmlItem.SelectSingleNode("ID").InnerText;
                    string jmeno = xmlItem.SelectSingleNode("Name").InnerText;
                    byte stack = byte.Parse(xmlItem.SelectSingleNode("Stack").InnerText);
                    string[] kategorie = xmlItem.SelectSingleNode("Kategorie").InnerText.Split(';');
                    int maxDamage = -1, damage = -1;
                    NbtCompound tag = null;
                    byte[] povoleneSloty = null;
                    bool canChangeCollor = false;
                    bool banner = false;
                    bool firework = false;
                    bool vlastnostiItemu = false;
                    List<string> mandatory = new List<string>();

                    if (xmlItem.Attributes.Count > 0 && xmlItem.Attributes["canChangeColor"] != null)
                    {
                        canChangeCollor = true;
                        vlastnostiItemu = true;
                    }

                    if (xmlItem.Attributes.Count > 0 && xmlItem.Attributes["banner"] != null)
                    {
                        banner = true;
                        vlastnostiItemu = true;
                    }

                    if (xmlItem.Attributes.Count > 0 && xmlItem.Attributes["firework"] != null)
                    {
                        firework = true;
                        vlastnostiItemu = true;
                    }

                    if (xmlItem.SelectSingleNode("Damage") != null)
                    {
                        maxDamage = int.Parse(xmlItem.SelectSingleNode("Damage").InnerText);
                        damage = 0;
                    }


                    if (xmlItem.SelectSingleNode("Tag") != null)
                    {
                        vlastnostiItemu = true;
                        tag = new NbtCompound("tag");
                        foreach (XmlNode tagValue in xmlItem.SelectNodes("Tag/Value"))
                        {
                            //parametry v tagu itemu
                            switch (tagValue.Attributes["type"].InnerText)
                            {
                                case "string":
                                    tag.Add(new NbtString(tagValue.Attributes["name"].InnerText, tagValue.InnerText));
                                    break;
                                case "byte":
                                    tag.Add(new NbtByte(tagValue.Attributes["name"].InnerText, byte.Parse(tagValue.InnerText)));
                                    break;
                                case "int":
                                    tag.Add(new NbtInt(tagValue.Attributes["name"].InnerText, int.Parse(tagValue.InnerText)));
                                    break;
                                case "list":
                                    tag.Add(new NbtList(tagValue.Attributes["name"].InnerText));
                                    foreach (XmlNode tagListValue in tagValue.SelectNodes("Value"))
                                    {
                                        switch (tagListValue.Attributes["type"].InnerText)
                                        {
                                            case "string":
                                                tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtString(tagListValue.InnerText));
                                                break;
                                            case "byte":
                                                tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtByte(byte.Parse(tagListValue.InnerText)));
                                                break;
                                            case "int":
                                                tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtInt(int.Parse(tagListValue.InnerText)));
                                                break;
                                            case "compound":
                                                tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(RecursiveTagLoad(tagListValue, new NbtCompound(tagValue.Attributes["name"].InnerText), mandatory));
                                                break;
                                        }
                                    }
                                    break;
                                case "compound":
                                    tag.Add(RecursiveTagLoad(tagValue, new NbtCompound(tagValue.Attributes["name"].InnerText), mandatory));
                                    break;
                            }
                            if (tagValue.Attributes["req"] != null)
                                mandatory.Add(tagValue.Attributes["name"].InnerText + ";" + tagValue.InnerText);
                        }
                    }
                    if (xmlItem.SelectSingleNode("PovoleneSloty") != null)
                    {
                        List<byte> sloty = new List<byte>();

                        foreach (string s in xmlItem.SelectSingleNode("PovoleneSloty").InnerText.Split(';'))
                        {
                            sloty.Add(byte.Parse(s));
                        }

                        povoleneSloty = sloty.ToArray();
                    }

                    Bitmap obrazek = new Bitmap(xmlItem.SelectSingleNode("Image/File").InnerText);
                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle((int.Parse(xmlItem.SelectSingleNode("Image/X").InnerText) - 1) * 16, (int.Parse(xmlItem.SelectSingleNode("Image/Y").InnerText) - 1) * 16, 16, 16), obrazek.PixelFormat);

                    Item i = new Item(jmeno, id, damage, maxDamage, stack, stack, 0, tag, kategorie, povoleneSloty, subObrazek, this, canChangeCollor, banner, firework, vlastnostiItemu, mandatory);

                    //různé ID bude v xml samostatný uzel s verzováním pro daný item

                    if (xmlItem.SelectSingleNode("MultipleID") != null)
                    {
                        foreach (XmlNode multID in xmlItem.SelectNodes("MultipleID/ID"))
                        {
                            int minVerze = minMcVerze;
                            int maxVerze = int.MaxValue;

                            if (multID.Attributes["minVerze"] != null)
                            {
                                minVerze = int.Parse(multID.Attributes["minVerze"].Value);
                            }

                            if (multID.Attributes["maxVerze"] != null)
                            {
                                maxVerze = int.Parse(multID.Attributes["maxVerze"].Value);
                            }

                            i.AddVerze(minVerze, maxVerze, multID.InnerText);
                        }
                    }

                    if (!InvokeRequired)
                    {
                        seznamBlocku.SmallImageList.Images.Add(i.Image);
                        seznamBlockuSearch.SmallImageList.Images.Add(i.Image);
                    }
                    else
                    {
                        this.Invoke(new Action(() => seznamBlocku.SmallImageList.Images.Add(i.Image)));
                        this.Invoke(new Action(() => seznamBlockuSearch.SmallImageList.Images.Add(i.Image)));
                    }
                    ListViewItem lvi = new ListViewItem(i.Name, seznamBlocku.SmallImageList.Images.Count - 1);
                    lvi.Tag = new Tag(i);
                    if (!InvokeRequired)
                        seznamBlocku.Items.Add(lvi);
                    else
                        this.Invoke(new Action(() => seznamBlocku.Items.Add(lvi)));
                    itemNum++;

                    if (nsStart != null)
                    {
                        if (!InvokeRequired)
                            nsStart.ReportProgress((int)((float)itemNum / (float)itemTotal * 100), itemNum, itemTotal);
                        else
                            this.Invoke(new Action(() => nsStart.ReportProgress((int)((float)itemNum / (float)itemTotal * 100), itemNum, itemTotal)));
                    }
                    if (ns != null)
                    {
                        if (!InvokeRequired)
                            ns.ReportProgress((int)((float)itemNum / (float)itemTotal * 100), itemNum, itemTotal);
                        else
                            this.Invoke(new Action(() => ns.ReportProgress((int)((float)itemNum / (float)itemTotal * 100), itemNum, itemTotal)));
                    }
                }

                if (!InvokeRequired)
                {
                    columnHeader1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    columnHeader1.AutoResize(ColumnHeaderAutoResizeStyle.None);
                    columnHeader2.Width = columnHeader1.Width;
                }
                else
                {
                    this.Invoke(new Action(() => columnHeader1.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent)));
                    this.Invoke(new Action(() => columnHeader1.AutoResize(ColumnHeaderAutoResizeStyle.None)));
                    this.Invoke(new Action(() => columnHeader2.Width = columnHeader1.Width));
                }

                if (!InvokeRequired)
                {
                    seznamBlocku.EndUpdate();
                    seznamBlockuSearch.EndUpdate();
                    vyhledavani.Enabled = true;
                    Log.Write("Loading images and items for list complete", Log.Verbosity.Info);
                    Log.Write("Loaded " + itemNum + " items out of " + itemTotal, Log.Verbosity.Info);
                }
                else
                {
                    this.Invoke(new Action(() => seznamBlocku.EndUpdate()));
                    this.Invoke(new Action(() => seznamBlockuSearch.EndUpdate()));
                }
                //dokoncenoNacitaniBloku = true;

                //Načtení enchantů
                if (!InvokeRequired)
                    nsStart.ReportProgress(-1, 100, 100);
                else
                    this.Invoke(new Action(() => nsStart.ReportProgress(-1, 100, 100)));

                Log.Write("Loading enchantments", Log.Verbosity.Info);
                List<string> allEnch = new List<string>();

                XmlNodeList allEnchList = xmlItemy.SelectNodes("Itemy/Enchanty/AllEnchantments/ID");
                foreach (XmlNode itemID in allEnchList)
                    allEnch.Add(itemID.InnerText);

                XmlNodeList specialEnchList = xmlItemy.SelectNodes("Itemy/Enchanty/SpecialTag/ID");
                foreach (XmlNode itemID in specialEnchList)
                    allEnch.Add(itemID.InnerText);

                XmlNodeList enchantyXml = xmlItemy.SelectNodes("Itemy/Enchanty/Enchant");
                foreach(XmlNode enchantNode in enchantyXml)
                {
                    Enchantment enchantment = new Enchantment(enchantNode.SelectSingleNode("Name").InnerText, enchantNode.SelectSingleNode("ID").InnerText, short.Parse(enchantNode.SelectSingleNode("MaxLevel").InnerText));
                    foreach(XmlNode povoleneID in enchantNode.SelectNodes("Applicable/ID"))
                    {
                        enchantment.Add(povoleneID.InnerText);
                    }
                    foreach (string vsechnyEnch in allEnch)
                        enchantment.Add(vsechnyEnch);
                    enchanty.Add(enchantment);
                }

                Log.Write("Loading enchantments complete", Log.Verbosity.Info);
            }
            /*if (nacteno)
                VyberItem(0);*/
        }

        private NbtCompound RecursiveTagLoad(XmlNode xmlItemTag, NbtCompound tag, List<string> mandatory)
        {
            foreach (XmlNode tagValue in xmlItemTag.SelectNodes("Tag/Value"))
            {
                //parametry v tagu itemu
                switch (tagValue.Attributes["type"].InnerText)
                {
                    case "string":
                        tag.Add(new NbtString(tagValue.Attributes["name"].InnerText, tagValue.InnerText));
                        break;
                    case "byte":
                        tag.Add(new NbtByte(tagValue.Attributes["name"].InnerText, byte.Parse(tagValue.InnerText)));
                        break;
                    case "int":
                        tag.Add(new NbtInt(tagValue.Attributes["name"].InnerText, int.Parse(tagValue.InnerText)));
                        break;
                    case "list":
                        tag.Add(new NbtList(tagValue.Attributes["name"].InnerText));
                        foreach (XmlNode tagListValue in tagValue.SelectNodes("Value"))
                        {
                            switch (tagListValue.Attributes["type"].InnerText)
                            {
                                case "string":
                                    tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtString(tagListValue.InnerText));
                                    break;
                                case "byte":
                                    tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtByte(byte.Parse(tagListValue.InnerText)));
                                    break;
                                case "int":
                                    tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtInt(int.Parse(tagListValue.InnerText)));
                                    break;
                                case "compound":
                                    tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(RecursiveTagLoad(tagListValue, new NbtCompound(tagValue.Attributes["name"].InnerText), mandatory));
                                    break;
                            }
                        }
                        break;
                    case "compound":
                        tag.Add(RecursiveTagLoad(tagValue, new NbtCompound(tagValue.Attributes["name"].InnerText), mandatory));
                        break;
                }
                if (tagValue.Attributes["req"] != null)
                    mandatory.Add(tagValue.Attributes["name"].InnerText + ";" + tagValue.InnerText);
            }
            return tag;
        }
        private void KlavesovaZkratka(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                Log.Write("Forced item reload", Log.Verbosity.Info);
                if (nacteno && dokoncenoNacitaniBloku)
                {
                    //seznamBlocku.Focus();
                    muzeHledat = false;
                    seznamBlockuSearch.Visible = false;
                    seznamBlocku.Visible = true;
                    vyhledavani.Text = jazyk.ReturnPreklad("MainWindow/Search", en);
                    vyhledavani.ForeColor = Color.Gray;
                    vyhledavani.Font = new Font(vyhledavani.Font, FontStyle.Italic);
                    vyhledavani.Enabled = false;
                    toLoad = true;
                    ClearButtonsAndShowInfo();
                    backgroundWorker2.RunWorkerAsync();
                    muzeHledat = true;
                    //Nacti();
                }
            }

            if (e.KeyCode == Keys.E && e.Modifiers == (Keys.Control | Keys.Shift))
            {
                Log.Write("Crashing program with Ctrl+Shift+E", Log.Verbosity.Warning);
                throw new Exception("Forced program crash with key shortcut.");
            }

            if (e.KeyCode == Keys.I && e.Modifiers == (Keys.Control | Keys.Shift))
            {
                novyItemWindows = new NovyItem();
                novyItemWindows.Show();
            }
        }

        private void vyhledavani_Enter(object sender, System.EventArgs e)
        {
            if (vyhledavani.Text == jazyk.ReturnPreklad("MainWindow/Search", en))
            {
                muzeHledat = false;
                vyhledavani.Text = "";
                vyhledavani.ForeColor = Color.Black;
                vyhledavani.Font = new Font(vyhledavani.Font, FontStyle.Regular);
            }
        }

        private void vyhledavani_Leave(object sender, System.EventArgs e)
        {
            if (vyhledavani.Text == "")
            {
                vyhledavani.Text = jazyk.ReturnPreklad("MainWindow/Search", en);
                vyhledavani.ForeColor = Color.Gray;
                vyhledavani.Font = new Font(vyhledavani.Font, FontStyle.Italic);
            }
        }

        private void vyhledavani_TextChanged(object sender, System.EventArgs e)
        {
            if (vyhledavani.Text != jazyk.ReturnPreklad("MainWindow/Search", en) && muzeHledat && !backgroundWorker2.IsBusy)
            {
                ListView lv2 = new ListView();
                foreach (ListViewItem lvi in seznamBlocku.Items)
                    lv2.Items.Add((ListViewItem)lvi.Clone());
                if (vyhledavani.Text != "")
                {
                    seznamBlockuSearch.Visible = true;
                    seznamBlocku.Visible = false;
                    seznamBlockuSearch.BeginUpdate();
                    seznamBlockuSearch.Items.Clear();
                    Log.Write("Looking for item containing '" + vyhledavani.Text + "'", Log.Verbosity.Info);

                    foreach (ListViewItem lvi in seznamBlocku.Items)
                    {
                        if(((Tag)lvi.Tag).Item.Name.ToLower().Contains(vyhledavani.Text.ToLower()))
                        {
                            ListViewItem novyItem = new ListViewItem(((Tag)lvi.Tag).Item.Name, lvi.ImageIndex);
                            novyItem.Tag = lvi.Tag;
                            seznamBlockuSearch.Items.Add(novyItem);
                        }
                    }
                    /*int count = 0;
                    foreach (Item i in itemList)
                    {
                        if (i.Jmeno.ToLower().Contains(vyhledavani.Text.ToLower()) && i.Kategorie % vybranaKategorie == 0)
                        {
                            ListViewItem novyItem = new ListViewItem(i.Jmeno, lv2.Items.IndexOfKey(i.Jmeno));
                            seznamBlocku.Items.Add(new ListViewItem(i.Jmeno, count));
                        }
                        count++;
                    }*/
                }
                else if (vyhledavani.Text == "" || vyhledavani.Text == jazyk.ReturnPreklad("MainWindow/Search", en))
                {
                    seznamBlockuSearch.BeginUpdate();
                    seznamBlockuSearch.Items.Clear();
                    seznamBlocku.Visible = true;
                    seznamBlockuSearch.Visible = false;
                    /*int count = 0;
                    foreach (Item i in itemList)
                    {
                        if (i.Kategorie % vybranaKategorie == 0)
                        {
                            ListViewItem novyItem = new ListViewItem(i.Jmeno, lv2.Items.IndexOfKey(i.Jmeno));
                            seznamBlocku.Items.Add(new ListViewItem(i.Jmeno, count));
                        }
                        count++;
                    }*/
                }
                seznamBlockuSearch.EndUpdate();
            }
            else
            {
                muzeHledat = true;
                seznamBlockuSearch.Visible = false;
                seznamBlocku.Visible = true;
            }
        }

        private void UkazPopisek(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (!naTlacitku)
            {
                if ((((Tag)((Button)sender).Tag).Item == null) && popisek.GetToolTip((Button)sender) != null)
                {
                    popisek.SetToolTip((Control)sender, null);
                }
                else
                {
                    if (((Tag)((Button)sender).Tag).Item != null && ((Tag)((Button)sender).Tag).Item.Tag != null && ((Tag)((Button)sender).Tag).Item.Tag.Get<NbtCompound>("display") != null && ((Tag)((Button)sender).Tag).Item.Tag.Get<NbtCompound>("display").Get<NbtString>("Name") != null)
                    {
                        popisek.SetToolTip((Control)sender, ((Tag)((Button)sender).Tag).Item.Tag.Get<NbtCompound>("display").Get<NbtString>("Name").Value);
                    }
                    else if (((Tag)((Button)sender).Tag).Item != null)
                    {
                        if (((Tag)((Button)sender).Tag).Item.Name != null)
                            popisek.SetToolTip((Control)sender, ((Tag)((Button)sender).Tag).Item.Name);
                        else
                        {
                            string text = ((Tag)((Button)sender).Tag).Item.ID;
                            if (((Tag)((Button)sender).Tag).Item.Tag != null)
                            {
                                text += "\n" + ((Tag)((Button)sender).Tag).Item.Tag.ToString();
                            }
                            popisek.SetToolTip((Control)sender, text);
                        }
                    }
                    popisek.AutoPopDelay = 32000;
                    popisek.ShowAlways = true;
                    naTlacitku = true;
                }
            }
        }

        private void Vylez(object sender, System.EventArgs e)
        {
            naTlacitku = false;
            popisek.Hide((IWin32Window)sender);
        }

        private void VyjmoutZTlacitka(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left && ((Tag)((Button)sender).Tag).Item != null)
            {
                //načtení infa a udělat efekt přesunu
                VyberItem(((Tag)((Button)sender).Tag).Slot);
                seznamBlocku.SelectedItems.Clear();
                seznamBlockuSearch.SelectedItems.Clear();
                //Drag&Drop data je Tag Item
                ((Button)sender).DoDragDrop(((Tag)((Button)sender).Tag).Item, DragDropEffects.Move);
            }
            else
            {
                vlastnosti.Enabled = false;
                itemToEdit = null;
            }
        }

        void VyberItem (byte slot)
        {

            foreach (Control c in Controls)
            {
                if(c.Tag != null && ((Tag)c.Tag).Slot == slot && ((Tag)c.Tag).Item != null)
                {
                    Log.Write("Selecting item " + ((Tag)c.Tag).Item.ID + " at slot " + ((Tag)c.Tag).Item.Slot, Log.Verbosity.Info);
                    zmena = false;
                    if (((Tag)c.Tag).Item.MaxDamage > 0)
                    {
                        poskozeni.Maximum = ((Tag)c.Tag).Item.MaxDamage;
                        poskozeni.Value = ((Tag)c.Tag).Item.Damage;
                        poskozeni.Enabled = true;
                    }
                    else
                    {
                        poskozeni.Enabled = false;
                        poskozeni.Value = 0;
                        poskozeni.Maximum = 0;
                    }

                    pocet.Maximum = ((Tag)c.Tag).Item.Stack;
                    if (((Tag)c.Tag).Item.Count > ((Tag)c.Tag).Item.Stack)
                        pocet.Maximum = ((Tag)c.Tag).Item.Count;
                    pocet.Value = ((Tag)c.Tag).Item.Count;

                    if (((Tag)c.Tag).Item.Unknown)
                    {

                        //Unknown otevře NBT editor
                        //ostatní podle itemu v else
                        vlastnosti.Enabled = true;
                        editor = "nbt";
                        itemToEdit = ((Tag)c.Tag).Item;
                    }
                    else
                    {
                        //TODO: tady bude rozdělení a výběr toho, jaké okno vlastností se má otevřít. V prop. editor pak je které okno.
                        if(((Tag)c.Tag).Item.Banner)
                            editor = "banner";
                        else if(((Tag)c.Tag).Item.Firework)
                            editor = "firework";
                        else
                            editor = "item";

                        vlastnosti.Enabled = true;
                        itemToEdit = ((Tag)c.Tag).Item;
                    }

                    break;
                }
            }
            zmena = true;
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            if (ns != null)
                ns.BringToFront();
        }

        private void VstupPresunuSeznam(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data != null)
            {
                Item item = (Item)e.Data.GetData(typeof(Item));
                Log.Write("Moving item " + item.ID + " from slot " + item.Slot + " over " + ((Control)sender).Name, Log.Verbosity.Info);
                e.Effect = DragDropEffects.Move;
            }
        }

        private void VstupPresunu(object sender, System.Windows.Forms.DragEventArgs e)
        {
            //Log.Write("Drag Data " + ((Item)e.Data.GetData(typeof(Item))).Slot + " sender " + ((Tag)((Button)sender).Tag).Slot, Log.Verbosity.Info);
            if (((Item)e.Data.GetData(typeof(Item))).Slot != ((Tag)((Button)sender).Tag).Slot)
            {
                Item item = (Item)e.Data.GetData(typeof(Item));
                Log.Write("Moving item " + item.ID + " from slot " + item.Slot + " over slot " + ((Tag)((Button)sender).Tag).Slot, Log.Verbosity.Info);
                if (((Item)e.Data.GetData(typeof(Item))).PovoleneSloty == null && (((Tag)((Button)sender).Tag).Slot < 100 || ((Tag)((Button)sender).Tag).Slot == 150))
                    e.Effect = DragDropEffects.Move;
                else if (((Item)e.Data.GetData(typeof(Item))).PovoleneSloty.Contains(((Tag)((Button)sender).Tag).Slot) && 
                    ((Tag)((Button)sender).Tag).Slot >= 100 || ((Tag)((Button)sender).Tag).Slot < 100)
                    e.Effect = DragDropEffects.Move;
                else
                    e.Effect = DragDropEffects.None;
            }
            else
                e.Effect = DragDropEffects.None;
        }

        private void vlastnosti_Click(object sender, System.EventArgs e)
        {
            switch (editor)
            {
                case "nbt":
                    Log.Write("Openning NBT Editor for item " + itemToEdit.ID + " at slot " + itemToEdit.Slot, Log.Verbosity.Info);
                    if(new NbtEditor(this).ShowDialog() != DialogResult.OK)
                    {
                        Log.Write("Reverting changes made in NbtEditor", Log.Verbosity.Info);
                        File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastEditFile", tempFile, true);
                        Nacti(true);
                    }
                    break;
                default:
                    Log.Write("Openning NBT Editor for item " + itemToEdit.ID + " at slot " + itemToEdit.Slot, Log.Verbosity.Info);
                    if(new NbtEditor(this).ShowDialog() != DialogResult.OK)
                    {
                        Log.Write("Reverting changes made in NbtEditor", Log.Verbosity.Info);
                        File.Copy(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\SaveEdit\LastEditFile", tempFile, true);
                        Nacti(true);
                    }
                    break;
            }
        }

        internal Bitmap EnchantLabel(Bitmap bitmapa)
        {
            Log.Write("Drawing enchant background", Log.Verbosity.Info);
            Graphics g = Graphics.FromImage(bitmapa);
            Bitmap b = new Bitmap(bitmapa);
            Bitmap bod = new Bitmap(1, 1);
            bod.SetPixel(0, 0, Color.FromArgb(211, 173, 255));
            bod = Rozsirujici.Grafika.Obrazek.ResizeBMP(bod, 72, 72, Rozsirujici.Grafika.Obrazek.PomerStran.Cílový);
            g.DrawImage(bod, 0, 0);
            g.DrawImage(b, 0, 0);
            g.Dispose();
            return bitmapa;
        }

        private void Pusunuto(object sender, System.EventArgs e)
        {
            if (ns != null)
                ns.Location = new Point(this.Location.X + (this.Width / 2) - (ns.Width / 2), this.Location.Y + (this.Height / 2) - (ns.Height / 2));
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Hide();
        }


        internal void Ulozit()
        {
            neulozeno = false;
            file.SaveToFile(fullPath, file.FileCompression);
        }

        internal void UlozitWorking()
        {
            file.SaveToFile(tempFile, file.FileCompression);
        }

        private void Presun(object sender, DragEventArgs e)
        {
            Item data = (Item)e.Data.GetData(e.Data.GetFormats()[0]);
            foreach (Control c in Controls)
            {
                if (c.Tag != null && ((Tag)c.Tag).JeInvSlot && ((Tag)c.Tag).Slot == data.Slot)
                {
                    ((Tag)((Button)c).Tag).Item = null;
                    ((Button)c).Image = null;
                    break;
                }
            }
            data.ChangeSlot(((Tag)((Button)sender).Tag).Slot);
            ((Tag)((Button)sender).Tag).Item = data;
            ((Button)sender).Image = ((Tag)((Button)sender).Tag).Item.Image;
            PridejObrazek((Control)sender, ((Tag)((Button)sender).Tag).Item.NbtItem);
        }

        void PridejObrazek(Control c, NbtCompound item)
        {
            ((Tag)c.Tag).Item = new Item(item, this);
            Log.Write("Loading item " + ((Tag)c.Tag).Item.ID + " into slot " + ((Tag)c.Tag).Slot, Log.Verbosity.Info);

            Bitmap b = new Bitmap(36, 36);
            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(Rozsirujici.Grafika.Obrazek.ResizeBMP(((Tag)c.Tag).Item.Image, 32, 32, Rozsirujici.Grafika.Obrazek.PomerStran.Originální, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor), 2, 3);
            //Bitmap img = Rozsirujici.Grafika.Obrazek.ResizeBMP(((Tag)c.Tag).Item.Image, 32, 32, Rozsirujici.Grafika.Obrazek.PomerStran.Originální, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
            float size = 13;
            int x, y;
            if (((Tag)c.Tag).Item.Count.ToString().Length == 2)
            {
                x = 15;
                y = 20;
            }
            else if (((Tag)c.Tag).Item.Count.ToString().Length == 1)
            {
                x = 24;
                y = 20;
            }
            else if (((Tag)c.Tag).Item.Count.ToString().Length == 3)
            {
                x = 6;
                y = 20;
            }
            else
            {
                x = 0;
                y = 0;
                size = 12.25f;
            }

            if (((Tag)c.Tag).Item.MaxDamage <= 0 || ((Tag)c.Tag).Item.Damage <= 0)
                ((Button)c).Image = Rozsirujici.Grafika.Obrazek.AddText(b, ((Tag)c.Tag).Item.Count.ToString(), Brushes.White, Color.Black, new FontFamily("Arial Black"), FontStyle.Bold, size, new Point(x, y));
            else
                ((Button)c).Image = DamageBar(Rozsirujici.Grafika.Obrazek.AddText(b, ((Tag)c.Tag).Item.Count.ToString(), Brushes.White, Color.Black, new FontFamily("Arial Black"), FontStyle.Bold, size, new Point(x, y)), ((Tag)c.Tag).Item.MaxDamage, ((Tag)c.Tag).Item.Damage);
            g.Dispose();
            g = null;
            //přidat nénchant pozadí když má Enchantments tag
            if (((Tag)c.Tag).Item.Enchanty != null && ((Tag)c.Tag).Item.Enchanty.Count > 0)
            {
                ((Button)c).Image = EnchantLabel((Bitmap)((Button)c).Image);
            }
        }

        private void aktualizovatProgram_Click(object sender, System.EventArgs e)
        {
            
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            
        }

        private void backgroundWorker3_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            
        }

        private void backgroundWorker4_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            
        }

        private void češtinaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void englishToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void enchantyButton_Click(object sender, System.EventArgs e)
        {
            
        }

        private void changelogToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void kopirovatBtn_Click(object sender, System.EventArgs e)
        {
            
        }

        private void moznostiHry_Click(object sender, System.EventArgs e)
        {
            
        }

        private void nápovědaToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void novy_Click(object sender, System.EventArgs e)
        {
            
        }

        private void odeslatInfoOChyběnápadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void oProgramu_Click(object sender, System.EventArgs e)
        {
            
        }

        private void pocet_ValueChanged(object sender, System.EventArgs e)
        {
            
        }

        private void poskozeni_ValueChanged(object sender, System.EventArgs e)
        {
            
        }

        private void poslatNápadToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void přidatItemDoSeznamuItemůToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            
        }

        private void seznam_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
        {
            
        }

        private void SeznamAktivuj(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            
        }

        private void SeznamDeaktivuj(object sender, System.EventArgs e)
        {
            
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            
        }

        private void ulozit_Click(object sender, System.EventArgs e)
        {
            
        }

        private void updateButton_Click(object sender, System.EventArgs e)
        {
            
        }

        private void VhoditItem(object sender, System.Windows.Forms.DragEventArgs e)
        {
            
        }

        private void vlozitBtn_Click(object sender, System.EventArgs e)
        {
            
        }

        private void xplevel_TextChanged(object sender, System.EventArgs e)
        {

        }
    }
}
