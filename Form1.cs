using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using LibNbt;
using System.Xml;

namespace SaveEdit
{
    public partial class Form1 : Form
    {
        #region Verze

        static int verze = 4020003;

        #endregion

        #region Globální proměnné

        string item;
        string konec;
        string cesta;
        internal NbtFile save = new NbtFile();
        internal NbtList inventarList = new LibNbt.NbtList();
        internal List<Item> itemList = new List<Item>();
        List<int> podleDamage = new List<int>();
        List<int> sestnact = new List<int>();
        List<int> neukazovatBar = new List<int>();
        internal List<Enchant> enchantyList = Enchanty.Load();
        internal List<string> enchanty = new List<string>();
        internal sbyte varianta = 0;
        bool otevreno = false;
        bool kategorie = false;
        Kategorie ktg;
        internal short vybranaKategorie = 1;
        Dictionary<string, Bitmap> obrazkyBrneni = new Dictionary<string, Bitmap>();
        internal List<int> jednaBarva = new List<int>();
        internal List<int> viceBarev = new List<int>();
        internal List<int> explosions = new List<int>();
        internal bool novyItemOtevreno = false;
        NbtCompound kopirovanyItem;
        internal static int verzeItemu;
        internal string itemInfo;
        internal short vybranyItemId = -1;
        internal bool verStringId = false;
        internal List<int> bannery = new List<int>();
        internal List<int> povoleneBoty = new List<int>();
        internal List<int> povoleneKalhoty = new List<int>();
        internal List<int> povoleneTelo = new List<int>();
        internal List<int> povoleneHelma = new List<int>();

        #endregion

        #region Konstruktor
        public Form1()
        {
            InitializeComponent();

            //updateButton.Image.Save("arr.png");
            
            kopirovatBtn.Enabled = false;
            vlozitBtn.Enabled = false;

            if (Directory.Exists("Lang"))
            {
                string[] souboryJazyku = Directory.GetFiles("Lang");

                foreach (string s in souboryJazyku)
                {
                    Jazyk.Serializace jazyky = new Jazyk.Serializace();
                    Jazyk.Ostatni jazyk = jazyky.Nacist(s.Remove(0,5));

                    ToolStripItem item = new System.Windows.Forms.ToolStripMenuItem();
                    item.Text = jazyk.NazevJazyka;
                    item.ToolTipText = jazyk.NazevJazyka + " " + jazyk.VerzeJazyka;
                    item.Click += new System.EventHandler(jazyk_Click);
                    item.Tag = s.Remove(0, 5);

                    jazykToolStripMenuItem.DropDownItems.Add(item);
                }
            }


            ktg = new Kategorie(this);

            poNacteni.BringToFront();
            try
            {
                cesta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves";
                if (Properties.Settings.Default.cesta != string.Empty && Directory.Exists(Properties.Settings.Default.cesta))
                {
                    cesta = Properties.Settings.Default.cesta;
                    otevritDial.InitialDirectory = cesta;
                }
                string[] soubory = Directory.GetDirectories(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves");
                foreach (string s in soubory)
                {
                    otevrit.DropDownItems.Add(s.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\", ""));
                }
                otevritDial.InitialDirectory = cesta;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + "\r\n\r\n" + Jazyk.Strings.Minecraft_neni_nainstalovan, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            Verze = new Verze(verze, "program");
            try
            {
                XmlDocument itemverze = new XmlDocument();
                itemverze.Load(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\itemy.xml");
                itemInfo = itemverze.SelectSingleNode("Itemy/Minecraft").InnerText;
                verzeItemu = int.Parse(itemverze.SelectSingleNode("Itemy/Verze").InnerText);
            }
            catch { 
                MessageBox.Show(Jazyk.Strings.Chybi_soubor_itemu, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Verze.GetObjekty.Add("itemy", verzeItemu);

            seznamBlocku.SmallImageList = new ImageList();
            seznamBlocku.SmallImageList.ColorDepth = ColorDepth.Depth24Bit;

            backgroundWorker2.RunWorkerAsync();
            backgroundWorker1.RunWorkerAsync();

        }

        #endregion

        #region Metody prvků

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            NactiObrazky(true);
        }


        private void backgroundWorker2_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Nacteno)
            {
                seznamBlocku.Visible = true;
                label7.Visible = false;
                label7.BackColor = Color.White;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            HledejAuktualizaceAuto();
            if (InvokeRequired)
            {
                this.BeginInvoke(new Action(() => aktualizovatToolStripMenuItem.Enabled = true));
            }
            else
                aktualizovatToolStripMenuItem.Enabled = true;
        }

        private void backgroundWorker4_DoWork(object sender, DoWorkEventArgs e)
        {
            RefreshItem();
        }

        private void vyhledavani_TextChanged(object sender, EventArgs e)
        {
            if (vyhledavani.Text != Jazyk.Strings.Hledej && HledaniZap)
            {
                ListView lv2 = new ListView();
                foreach (ListViewItem lvi in seznamBlocku.Items)
                    lv2.Items.Add((ListViewItem)lvi.Clone());
                if (vyhledavani.Text != "")
                {
                    seznamBlocku.BeginUpdate();
                    seznamBlocku.Items.Clear();
                    int count = 0;
                    foreach (Item i in itemList)
                    {
                        if (i.Jmeno.ToLower().Contains(vyhledavani.Text.ToLower()) && i.Kategorie % vybranaKategorie == 0)
                        {
                            ListViewItem novyItem = new ListViewItem(i.Jmeno, lv2.Items.IndexOfKey(i.Jmeno));
                            seznamBlocku.Items.Add(new ListViewItem(i.Jmeno, count));
                        }
                        count++;
                    }
                }
                else if (vyhledavani.Text == "" || vyhledavani.Text == Jazyk.Strings.Hledej)
                {
                    seznamBlocku.BeginUpdate();
                    seznamBlocku.Items.Clear();
                    int count = 0;
                    foreach (Item i in itemList)
                    {
                        if (i.Kategorie % vybranaKategorie == 0)
                        {
                            ListViewItem novyItem = new ListViewItem(i.Jmeno, lv2.Items.IndexOfKey(i.Jmeno));
                            seznamBlocku.Items.Add(new ListViewItem(i.Jmeno, count));
                        }
                        count++;
                    }
                }
                seznamBlocku.EndUpdate();
            }
            else
                HledaniZap = true;
        }

        private void vyhledavani_Enter(object sender, EventArgs e)
        {
            //vymazání textu Hledej... a nastavení normálního fontu
            if (vyhledavani.Text == Jazyk.Strings.Hledej)
            {
                HledaniZap = false;
                vyhledavani.Text = "";
                vyhledavani.ForeColor = Color.Black;
                vyhledavani.Font = new Font(vyhledavani.Font, FontStyle.Regular);
            }
        }

        private void vyhledavani_Leave(object sender, EventArgs e)
        {
            //nastavení šedivýho kurzíva fontu a text Hledej...
            if (vyhledavani.Text == "")
            {
                vyhledavani.Text = Jazyk.Strings.Hledej;
                vyhledavani.ForeColor = Color.Gray;
                vyhledavani.Font = new Font(vyhledavani.Font, FontStyle.Italic);
            }
        }

        private void xplevel_TextChanged(object sender, EventArgs e)
        {
            if (!Prepnuto)
            {
                NeulozenoMetoda();
                try
                {
                    if (xplevel.Text != "")
                    {
                        if (long.Parse(xplevel.Text) > int.MaxValue)
                            xplevel.Text = xplevel.Text.Remove(xplevel.Text.Length - 1);
                        else
                        {
                            if (varianta != 5)
                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("XpLevel").Value = Int32.Parse(xplevel.Text);
                            else
                                save.RootTag.Get<NbtInt>("XpLevel").Value = Int32.Parse(xplevel.Text);
                        }
                    }
                }
                catch
                {
                    xplevel.Text = xplevel.Text.Remove(xplevel.Text.Length-1);
                }
            }
        }

        private void pocet_ValueChanged(object sender, EventArgs e)
        {
            if (!Prepnuto)
            {
                foreach (NbtCompound c in inventarList)
                {
                    NeulozenoMetoda();
                    if (c.Get<NbtByte>("Slot").Value == VybraneTL)
                    {
                        int i = inventarList.IndexOf(c);
                        NactiObrazky(false, pocet.Value.ToString());
                        if(varianta != 5)
                            save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtByte>("Count").Value = (byte)pocet.Value;
                        else
                            save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtByte>("Count").Value = (byte)pocet.Value;
                        break;
                    }
                }
            }
        }

        private void poskozeni_ValueChanged(object sender, EventArgs e)
        {
            if (!Prepnuto)
            {
                foreach (NbtCompound c in inventarList)
                {
                    NeulozenoMetoda();
                    if (c.Get<NbtByte>("Slot").Value == VybraneTL)
                    {
                        int i = inventarList.IndexOf(c);
                        if (varianta != 5)
                            save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtShort>("Damage").Value = (short)poskozeni.Value;
                        else
                            save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtShort>("Damage").Value = (short)poskozeni.Value;

                            NactiObrazky(false, c.Get<NbtByte>("Count").Value.ToString());
                        
                        break;
                    }
                }
            }
        }

        //otevření okna enchantů
        private void enchantyButton_Click(object sender, EventArgs e)
        {
            EnchantWindow ew = new EnchantWindow(this);
            ew.ShowDialog();
        }

        //zavření okna novýho itemu
        private void ni_FormClosed(object sender, EventArgs e)
        {
            backgroundWorker4.RunWorkerAsync();
            novyItemOtevreno = false;
        }

        private void ni_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backgroundWorker2.IsBusy || backgroundWorker4.IsBusy)
            {
                MessageBox.Show(Jazyk.Strings.Seznam_itemu_neni_nacteny);
                e.Cancel = true;
            }
        }

        //tlačítka menu
        private void novy_Click(object sender, EventArgs e)
        {
            if (!novyItemOtevreno)
            {
                NovyItem ni = new NovyItem();
                ni.Show();
                ni.FormClosed += new FormClosedEventHandler(ni_FormClosed);
                ni.FormClosing += new FormClosingEventHandler(ni_FormClosing);
                novyItemOtevreno = true;
            }
            else
                MessageBox.Show(Jazyk.Strings.Novy_item_otevreno, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void otevrit_Click(object sender, EventArgs e)
        {
            if (!otevrit.DropDownButtonPressed)
                otevritDial.ShowDialog();
        }

        private void otevrit_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (DokoncenoNacitaniBloku)
                label7.Visible = false;
            item = e.ClickedItem.ToString();
            Nacti();
        }

        private void ulozit_Click(object sender, EventArgs e)
        {
            Ulozit();
        }

        private void otevritDial_FileOk(object sender, CancelEventArgs e)
        {
            item = otevritDial.FileName;
            cesta = otevritDial.FileName.Remove(otevritDial.FileName.LastIndexOf('\\'));
            Properties.Settings.Default.cesta = cesta;
            Properties.Settings.Default.Save();
            otevritDial.InitialDirectory = cesta;
            
            Nacti();
        }

        private void seznam_ItemDrag(object sender, ItemDragEventArgs e)
        {
            seznamBlocku.DoDragDrop(seznamBlocku.SelectedItems, DragDropEffects.Copy);
        }

        private void VstupPresunu(object sender, DragEventArgs e)
        {
            try
            {
                if (((Button)sender).Name == "i100" && ((Button)sender).Name != e.Data.GetData(typeof(string)))
                {
                    int ix = 0;
                    short id = 0;
                    foreach (NbtCompound c in inventarList)
                    {
                        if (c.Get<NbtByte>("Slot").Value.ToString() == e.Data.GetData(typeof(string)).ToString().Remove(0, 1))
                        {
                            ix = inventarList.IndexOf(c);
                            if (varianta != 5)
                            {
                                if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get("id").TagType == NbtTagType.Short)
                                    id = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtShort>("id").Value;
                                else
                                {
                                    string sid = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtString>("id").Value;
                                    
                                    foreach(Item i in itemList)
                                    {
                                        if(i.StringID == sid)
                                        {
                                            id = (short)i.ID;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get("id").TagType == NbtTagType.Short)
                                    id = save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtShort>("id").Value;
                                else
                                {
                                    foreach (Item i in itemList)
                                    {
                                        string sid = save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtString>("id").Value;
                                        if (i.StringID == sid)
                                        {
                                            id = (short)i.ID;
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                    if (id == 0)
                    {
                        foreach (Item i in itemList)
                        {
                            if (i.Jmeno == seznamBlocku.SelectedItems[0].Text)
                            {
                                id = (short)i.ID;
                                break;
                            }
                        }
                    }
                    if (povoleneBoty.Contains(id))
                    {
                        e.Effect = DragDropEffects.Copy;
                        /*if(!Boty)
                            i100.Image = null;*/
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                else if (((Button)sender).Name == "i101" && ((Button)sender).Name != e.Data.GetData(typeof(string)))
                {
                    int ix = 0;
                    short id = 0;
                    foreach (NbtCompound c in inventarList)
                    {
                        if (c.Get<NbtByte>("Slot").Value.ToString() == e.Data.GetData(typeof(string)).ToString().Remove(0, 1))
                        {
                            ix = inventarList.IndexOf(c);
                            if (varianta != 5)
                            {
                                if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get("id").TagType == NbtTagType.Short)
                                    id = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtShort>("id").Value;
                                else
                                {
                                    string sid = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtString>("id").Value;

                                    foreach (Item i in itemList)
                                    {
                                        if (i.StringID == sid)
                                        {
                                            id = (short)i.ID;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get("id").TagType == NbtTagType.Short)
                                    id = save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtShort>("id").Value;
                                else
                                {
                                    foreach (Item i in itemList)
                                    {
                                        string sid = save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtString>("id").Value;
                                        if (i.StringID == sid)
                                        {
                                            id = (short)i.ID;
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                    if (id == 0)
                    {
                        foreach (Item i in itemList)
                        {
                            if (i.Jmeno == seznamBlocku.SelectedItems[0].Text)
                            {
                                id = (short)i.ID;
                                break;
                            }
                        }
                    }
                    if (povoleneKalhoty.Contains(id))
                    {
                        e.Effect = DragDropEffects.Copy;
                        /*if (!Kalhoty)
                            i101.Image = null;*/
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                else if (((Button)sender).Name == "i102" && ((Button)sender).Name != e.Data.GetData(typeof(string)))
                {
                    int ix = 0;
                    short id = 0;
                    foreach (NbtCompound c in inventarList)
                    {
                        if (c.Get<NbtByte>("Slot").Value.ToString() == e.Data.GetData(typeof(string)).ToString().Remove(0, 1))
                        {
                            ix = inventarList.IndexOf(c);
                            if (varianta != 5)
                            {
                                if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get("id").TagType == NbtTagType.Short)
                                    id = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtShort>("id").Value;
                                else
                                {
                                    string sid = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtString>("id").Value;

                                    foreach (Item i in itemList)
                                    {
                                        if (i.StringID == sid)
                                        {
                                            id = (short)i.ID;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get("id").TagType == NbtTagType.Short)
                                    id = save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtShort>("id").Value;
                                else
                                {
                                    foreach (Item i in itemList)
                                    {
                                        string sid = save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtString>("id").Value;
                                        if (i.StringID == sid)
                                        {
                                            id = (short)i.ID;
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                    if (id == 0)
                    {
                        foreach (Item i in itemList)
                        {
                            if (i.Jmeno == seznamBlocku.SelectedItems[0].Text)
                            {
                                id = (short)i.ID;
                                break;
                            }
                        }
                    }
                    if (povoleneTelo.Contains(id))
                    {
                        e.Effect = DragDropEffects.Copy;
                        /*if (!Brneni)
                            i102.Image = null;*/
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                else if (((Button)sender).Name == "i103" && ((Button)sender).Name != e.Data.GetData(typeof(string)))
                {
                    int ix = 0;
                    short id = 0;
                    foreach (NbtCompound c in inventarList)
                    {
                        if (c.Get<NbtByte>("Slot").Value.ToString() == e.Data.GetData(typeof(string)).ToString().Remove(0, 1))
                        {
                            ix = inventarList.IndexOf(c);
                            if (varianta != 5)
                            {
                                if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get("id").TagType == NbtTagType.Short)
                                    id = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtShort>("id").Value;
                                else
                                {
                                    string sid = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtString>("id").Value;

                                    foreach (Item i in itemList)
                                    {
                                        if (i.StringID == sid)
                                        {
                                            id = (short)i.ID;
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get("id").TagType == NbtTagType.Short)
                                    id = save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtShort>("id").Value;
                                else
                                {
                                    foreach (Item i in itemList)
                                    {
                                        string sid = save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtString>("id").Value;
                                        if (i.StringID == sid)
                                        {
                                            id = (short)i.ID;
                                            break;
                                        }
                                    }
                                }
                            }
                            break;
                        }
                    }
                    if (id == 0)
                    {
                        foreach (Item i in itemList)
                        {
                            if (i.Jmeno == seznamBlocku.SelectedItems[0].Text)
                            {
                                id = (short)i.ID;
                                break;
                            }
                        }
                    }
                    if (povoleneHelma.Contains(id))
                    {
                        e.Effect = DragDropEffects.Copy;
                        /*if (!Helma)
                            i103.Image = null;*/
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                else if (((Button)sender).Name != e.Data.GetData(typeof(string)))
                    e.Effect = DragDropEffects.Copy;
            }

            catch
            {
                if (((Button)sender).Name == "i100" && ((Button)sender).Name != e.Data.GetData(typeof(string)))
                {
                    int id = 0;
                    foreach (Item i in itemList)
                    {
                        if (i.Jmeno == seznamBlocku.SelectedItems[0].Text)
                        {
                            id = i.ID;
                            break;
                        }
                    }
                    if (povoleneBoty.Contains(id))
                    {
                        e.Effect = DragDropEffects.Copy;
                        /*if (!Boty)
                            i100.Image = null;*/
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                else if (((Button)sender).Name == "i101" && ((Button)sender).Name != e.Data.GetData(typeof(string)))
                {
                    int id = 0;
                    foreach (Item i in itemList)
                    {
                        if (i.Jmeno == seznamBlocku.SelectedItems[0].Text)
                        {
                            id = i.ID;
                            break;
                        }
                    }
                    if (povoleneKalhoty.Contains(id))
                    {
                        e.Effect = DragDropEffects.Copy;
                        /*if (!Kalhoty)
                            i101.Image = null;*/
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                else if (((Button)sender).Name == "i102" && ((Button)sender).Name != e.Data.GetData(typeof(string)))
                {
                    int id = 0;
                    foreach (Item i in itemList)
                    {
                        if (i.Jmeno == seznamBlocku.SelectedItems[0].Text)
                        {
                            id = i.ID;
                            break;
                        }
                    }
                    if (povoleneTelo.Contains(id))
                    {
                        e.Effect = DragDropEffects.Copy;
                        /*if (!Brneni)
                            i102.Image = null;*/
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                else if (((Button)sender).Name == "i103" && ((Button)sender).Name != e.Data.GetData(typeof(string)))
                {
                    int id = 0;
                    foreach (Item i in itemList)
                    {
                        if (i.Jmeno == seznamBlocku.SelectedItems[0].Text)
                        {
                            id = i.ID;
                            break;
                        }
                    }
                    if (povoleneHelma.Contains(id))
                    {
                        e.Effect = DragDropEffects.Copy;
                        /*if (!Helma)
                            i103.Image = null;*/
                    }
                    else
                        e.Effect = DragDropEffects.None;
                }
                else if (((Button)sender).Name != e.Data.GetData(typeof(string)))
                    e.Effect = DragDropEffects.Copy;
            }
        }

        private void VstupPresunuSeznam(object sender, DragEventArgs e)
        {
            try
            {
                if (e.Data.GetData(typeof(string)).ToString().StartsWith("i"))
                    e.Effect = DragDropEffects.Copy;
            }
            catch { }
        }

        private void VyjmoutZTlacitka(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                VybraneTL = Int16.Parse(((Button)sender).Name.Remove(0, 1));
                seznamBlocku.SelectedItems.Clear();
                ((Button)sender).DoDragDrop(((Button)sender).Name, DragDropEffects.Copy);
                InventarVyber();
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                vybranyItemId = -1;
                VybraneTL = Int16.Parse(((Button)sender).Name.Remove(0, 1));
                seznamBlocku.SelectedItems.Clear();
                InventarVyber();

                bool nalezeno = false;
                foreach (Item i in itemList)
                {
                    if (i.ID == vybranyItemId)
                    {
                        if (!podleDamage.Contains(i.ID))
                        {
                            nalezeno = true;
                            break;
                        }
                        else
                        {
                            foreach (Item ii in itemList)
                            {
                                if(ii.ID == vybranyItemId && ii.MaxPoskozeni == poskozeni.Value)
                                {
                                    nalezeno = true;
                                    break;
                                }
                            }
                        }
                    }
                }

                if (!nalezeno && ((Button)sender).Image != null)
                {
                    contextMenu.Show(Cursor.Position);
                }
            }
        }

        private void VhoditItem(object sender, DragEventArgs e)
        {
            VybraneTL = Int16.Parse((e.Data.GetData(typeof(string))).ToString().Remove(0, 1));
            VyhoditItem(VybraneTL);
        }

        private void VyhoditItem(int tlacitko)
        {
            seznamBlocku.SelectedItems.Clear();
            foreach (NbtCompound c in inventarList)
            {
                if (c.Get<NbtByte>("Slot").Value == tlacitko)
                {
                    NeulozenoMetoda();
                    int ix = inventarList.IndexOf(c);
                    if (varianta != 5)
                        save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").RemoveAt(ix);
                    else
                        save.RootTag.Get<NbtList>("Inventory").RemoveAt(ix);

                    ((Button)Controls["i" + VybraneTL]).Image = null;
                    break;
                }
            }
            InventarVyber();
            NactiObrazky(false);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //ověření, jestli je všechno uložený a případný dotaz na uložení
            if (hotovo)
            {
                DialogResult res = new DialogResult();
                if (Neulozeno)
                    res = MessageBox.Show(Jazyk.Strings.Chcete_ulozit_zmeny, "SaveEdit", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (res == DialogResult.Cancel)
                    e.Cancel = true;
                else if (res == DialogResult.Yes)
                    Ulozit();
            }
            else
            {
                MessageBox.Show(Jazyk.Strings.Aktualizace_se_stahuje, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void Presun(object sender, DragEventArgs e)
        {
            //vytvoření novýho itemu, pokud žádnej neni
            if (((Button)Controls[((Button)sender).Name]).Image == null || ((Button)Controls[((Button)sender).Name]).Image == obrazkyBrneni["100"] || ((Button)Controls[((Button)sender).Name]).Image == obrazkyBrneni["101"] || ((Button)Controls[((Button)sender).Name]).Image == obrazkyBrneni["102"] || ((Button)Controls[((Button)sender).Name]).Image == obrazkyBrneni["103"] || ((Button)Controls[((Button)sender).Name]).Image == obrazkyBrneni["150"])
            {
                foreach (Item i in itemList)
                {
                    try
                    {
                        if (i.Jmeno == seznamBlocku.SelectedItems[0].Text)
                        {
                            NeulozenoMetoda();
                            short cislo = 1;
                            if (i.Stackovatelne && !sestnact.Contains(i.ID))
                                cislo = 64;
                            else if (i.Stackovatelne && (sestnact.Contains(i.ID)))
                                cislo = 16;
                            if (varianta != 5)
                            {
                                if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").ListType != NbtTagType.Compound)
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").ListType = NbtTagType.Compound;
                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Add(new NbtCompound());
                            }
                            else
                            {
                                if (save.RootTag.Get<NbtList>("Inventory").ListType != NbtTagType.Compound)
                                    save.RootTag.Get<NbtList>("Inventory").ListType = NbtTagType.Compound;
                                save.RootTag.Get<NbtList>("Inventory").Add(new NbtCompound());
                            }
                            NbtByte count = new NbtByte("Count", Convert.ToByte(cislo));
                            NbtByte slot = new NbtByte("Slot", (byte)Int16.Parse(((Button)sender).Name.Remove(0, 1)));
                            short poskozeni;
                            if (!podleDamage.Contains(i.ID))
                                poskozeni = 0;
                            else
                                poskozeni = (short)i.MaxPoskozeni;
                            NbtShort damage = new NbtShort("Damage", poskozeni);
                            NbtTag id;
                            if (!verStringId)
                            {
                                id = new NbtShort("id", (short)i.ID);
                            }
                            else
                                id = new NbtString("id", i.StringID);

                            if (varianta != 5)
                            {
                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Add(count);
                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Add(slot);
                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Add(damage);
                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Add(id);
                            
                                if(i.Potion != null && i.Potion.Contains("minecraft"))
                                {
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Add(new NbtCompound("tag"));
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Add(new NbtString("Potion", i.Potion));
                                }
                                else if (i.Potion != null)
                                {
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Add(new NbtCompound("tag"));
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Add(new NbtCompound("EntityTag"));
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Get<NbtCompound>("EntityTag").Add(new NbtString("id", i.Potion));
                                }

                                if (i.Barva != -1)
                                {
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Add(new NbtCompound("tag"));
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", i.Barva));

                                }

                                if (bannery.Contains(i.ID) && i.Barva == -1)
                                {
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Add(new NbtCompound("tag"));
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", i.MaxPoskozeni));

                                }

                            }
                            else
                            {
                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Add(count);
                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Add(slot);
                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Add(damage);
                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Add(id);

                                if (i.Potion != null && i.Potion.Contains("minecraft"))
                                {
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Add(new NbtCompound("tag"));
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Add(new NbtString("Potion", i.Potion));
                                }
                                else if (i.Potion != null)
                                {
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Add(new NbtCompound("tag"));
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Add(new NbtCompound("EntityTag"));
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Get<NbtCompound>("EntityTag").Add(new NbtString("id", i.Potion));
                                }

                                if(i.Barva != -1)
                                {
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Add(new NbtCompound("tag"));
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", i.Barva));
                                
                                }

                                if (bannery.Contains(i.ID) && i.Barva == -1)
                                {
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Add(new NbtCompound("tag"));
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(save.RootTag.Get<NbtList>("Inventory").Count - 1).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", i.MaxPoskozeni));

                                }
                            }
                            VybraneTL = Int16.Parse(((Button)sender).Name.Remove(0, 1));
                            ((Button)Controls[((Button)sender).Name]).Focus();
                            NactiObrazky(false, cislo.ToString());
                            InventarVyber();
                            if (((Button)sender).Name == "i100")
                                Boty = true;
                            if (((Button)sender).Name == "i101")
                                Kalhoty= true;
                            if (((Button)sender).Name == "i102")
                                Brneni = true;
                            if (((Button)sender).Name == "i103")
                                Helma = true;
                            if (((Button)sender).Name == "i150")
                                Stit = true;
                            break;
                        }
                    }
                    catch
                    {
                        NeulozenoMetoda();
                        int ix = 0;
                        foreach (NbtCompound c in inventarList)
                        {
                            if (c.Get<NbtByte>("Slot").Value.ToString() == e.Data.GetData(typeof(string)).ToString().Remove(0, 1))
                            {
                                ix = inventarList.IndexOf(c);
                                if(varianta!=5)
                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtByte>("Slot").Value = Convert.ToByte(((Button)sender).Name.Remove(0, 1));
                                else
                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtByte>("Slot").Value = Convert.ToByte(((Button)sender).Name.Remove(0, 1));
                                ((Button)Controls[e.Data.GetData(typeof(string)).ToString()]).Image = null;

                                VybraneTL = Int16.Parse(((Button)sender).Name.Remove(0, 1));
                                ((Button)Controls[((Button)sender).Name]).Focus();
                                ((Button)Controls[((Button)sender).Name]).Image = null;
                                if (varianta != 5)
                                    NactiObrazky(false, save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtByte>("Count").Value.ToString());
                                else
                                    NactiObrazky(false, save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtByte>("Count").Value.ToString());
                                InventarVyber();
                                if (((Button)sender).Name == "i100")
                                    Boty = true;
                                if (((Button)sender).Name == "i101")
                                    Kalhoty = true;
                                if (((Button)sender).Name == "i102")
                                    Brneni = true;
                                if (((Button)sender).Name == "i103")
                                    Helma = true;
                                if (((Button)sender).Name == "i150")
                                    Stit = true;
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            //změna existujícího itemu
            else
            {
                bool nalezeno = false;
                foreach (Item it in itemList)
                {
                    try
                    {
                        if (it.Jmeno == seznamBlocku.SelectedItems[0].Text)
                        {
                            NeulozenoMetoda();

                            foreach (NbtCompound c in inventarList)
                            {
                                short poskozeni;
                                if (!podleDamage.Contains(it.ID))
                                    poskozeni = 0;
                                else
                                    poskozeni = (short)it.MaxPoskozeni;
                                if (c.Get<NbtByte>("Slot").Value == Int16.Parse(((Button)sender).Name.Remove(0, 1)))
                                {
                                    int i = inventarList.IndexOf(c);
                                    short cislo = 1;
                                    if (it.Stackovatelne)
                                        cislo = 64;
                                    if (varianta != 5)
                                    {
                                        save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtByte>("Count").Value = (byte)cislo;
                                        save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtByte>("Slot").Value = (byte)Int16.Parse(((Button)sender).Name.Remove(0, 1));
                                        save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtShort>("Damage").Value = poskozeni;
                                        if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get("id").TagType == NbtTagType.Short)
                                            save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtShort>("id").Value = (short)it.ID;
                                        else
                                            save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtString>("id").Value = it.StringID;
                                        try
                                        {
                                            save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Remove(c.Name);
                                        }
                                        catch { }

                                        if (it.Potion != null)
                                        {
                                            if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag") == null)
                                            {
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Add(new NbtCompound("tag"));
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtString("Potion", it.Potion));
                                            }
                                            else
                                            {
                                                if(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtString>("Potion") == null)
                                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtString("Potion", it.Potion));
                                                else
                                                    save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtString>("Potion").Value = it.Potion;
                                            }
                                            save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Remove("BlockEntityTag");
                                        }

                                        if (it.Barva != -1)
                                        {
                                            if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag") == null)
                                            {
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Add(new NbtCompound("tag"));
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.Barva));
                                            }
                                            else if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") == null)
                                            {
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.Barva));

                                            }
                                            else if(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") == null)
                                            {
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.Barva));
                                            }
                                            else
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value = it.Barva;
                                            save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Remove("Potion");
                                        }

                                         if (bannery.Contains(it.ID) && it.Barva == -1)
                                         {
                                             if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag") == null)
                                             {
                                                 save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Add(new NbtCompound("tag"));
                                                 save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                                 save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.MaxPoskozeni));
                                             }
                                             else if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") == null)
                                             {
                                                 save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                                 save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.MaxPoskozeni));

                                             }
                                             else if(save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") == null)
                                             {
                                                 save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.MaxPoskozeni));
                                             }
                                             else
                                                 save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value = it.MaxPoskozeni;
                                             save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Remove("Potion");
                                         }
                                    }
                                    else
                                    {
                                        save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtByte>("Count").Value = (byte)cislo;
                                        save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtByte>("Slot").Value = (byte)Int16.Parse(((Button)sender).Name.Remove(0, 1));
                                        save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtShort>("Damage").Value = poskozeni;
                                        if(save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get("id").TagType == NbtTagType.Short)
                                            save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtShort>("id").Value = (short)it.ID;
                                        else
                                            save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtString>("id").Value = it.StringID;
                                        try
                                        {
                                            save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Remove(c.Name);
                                        }
                                        catch { }

                                        //tohle překopat aby fungovalo vkládání i kopírování
                                        if (it.Potion != null)
                                        {
                                            if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag") == null)
                                            {
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Add(new NbtCompound("tag"));
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtString("Potion", it.Potion));
                                            }
                                            else
                                            {
                                                if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtString>("Potion") == null)
                                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtString("Potion", it.Potion));
                                                else
                                                    save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtString>("Potion").Value = it.Potion;
                                            }
                                            save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Remove("BlockEntityTag");
                                        }

                                        if (it.Barva != -1)
                                        {
                                            if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag") == null)
                                            {
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Add(new NbtCompound("tag"));
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.Barva));
                                            }
                                            else if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") == null)
                                            {
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.Barva));

                                            }
                                            else if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") == null)
                                            {
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.Barva));
                                            }
                                            else
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value = it.Barva;
                                            save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Remove("Potion");
                                        }

                                        if (bannery.Contains(it.ID) && it.Barva == -1)
                                        {
                                            if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag") == null)
                                            {
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Add(new NbtCompound("tag"));
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.MaxPoskozeni));
                                            }
                                            else if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") == null)
                                            {
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.MaxPoskozeni));

                                            }
                                            else if (save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") == null)
                                            {
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtInt("Base", it.MaxPoskozeni));
                                            }
                                            else
                                                save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value = it.MaxPoskozeni;
                                            save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Remove("Potion");
                                        }
                                    }

                                    VybraneTL = Int16.Parse(((Button)sender).Name.Remove(0, 1));
                                    ((Button)Controls[((Button)sender).Name]).Focus();
                                    ((Button)Controls[((Button)sender).Name]).Image = null;
                                    NactiObrazky(false, cislo.ToString());
                                    InventarVyber();
                                    nalezeno = true;
                                    if (((Button)sender).Name == "i100")
                                        Boty = true;
                                    if (((Button)sender).Name == "i101")
                                        Kalhoty = true;
                                    if (((Button)sender).Name == "i102")
                                        Brneni = true;
                                    if (((Button)sender).Name == "i103")
                                        Helma = true;
                                    if (((Button)sender).Name == "i150")
                                        Stit = true;
                                    break;
                                }
                            }

                        }
                    }
                    catch
                    {
                        if (((Button)sender).Name != e.Data.GetData(typeof(string)))
                        {
                            NeulozenoMetoda();

                            int ix = 0;
                            foreach (NbtCompound c in inventarList)
                            {
                                if (c.Get<NbtByte>("Slot").Value.ToString() == e.Data.GetData(typeof(string)).ToString().Remove(0, 1))
                                {
                                    foreach (NbtCompound cx in inventarList)
                                    {
                                        if (cx.Get<NbtByte>("Slot").Value.ToString() == ((Button)sender).Name.Remove(0, 1))
                                        {
                                            ix = inventarList.IndexOf(cx);
                                            if(varianta != 5)
                                                save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").RemoveAt(ix);
                                            else
                                                save.RootTag.Get<NbtList>("Inventory").RemoveAt(ix);
                                            break;
                                        }
                                    }
                                    ix = inventarList.IndexOf(c);
                                    if(varianta!=5)
                                        save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtByte>("Slot").Value = Convert.ToByte(((Button)sender).Name.Remove(0, 1));
                                    else
                                        save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtByte>("Slot").Value = Convert.ToByte(((Button)sender).Name.Remove(0, 1));
                                    ((Button)Controls[((Button)sender).Name]).Focus();
                                    ((Button)Controls[e.Data.GetData(typeof(string)).ToString()]).Image = null;
                                    ((Button)Controls[((Button)sender).Name]).Image = null;
                                    VybraneTL = Int16.Parse(((Button)sender).Name.Remove(0, 1));
                                    if(varianta != 5)
                                        NactiObrazky(false, save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtByte>("Count").Value.ToString());
                                    else
                                        NactiObrazky(false, save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(ix).Get<NbtByte>("Count").Value.ToString());
                                    InventarVyber();
                                    nalezeno = true;
                                    if (((Button)sender).Name == "i100")
                                        Boty = true;
                                    if (((Button)sender).Name == "i101")
                                        Kalhoty = true;
                                    if (((Button)sender).Name == "i102")
                                        Brneni = true;
                                    if (((Button)sender).Name == "i103")
                                        Helma = true;
                                    if (((Button)sender).Name == "i150")
                                        Stit = true;
                                    break;
                                }
                            }
                        }
                        else
                            break;
                        if (nalezeno)
                            break;
                    }
                }
            }
        }

        private void oProgramu_Click(object sender, EventArgs e)
        {
                AboutBox1 a = new AboutBox1(this);
                a.ShowDialog();
        }

        private void aktualizovatProgram_Click(object sender, EventArgs e)
        {
            if (Neulozeno)
                Ulozit();
            
            backgroundWorker1.RunWorkerAsync();
        }

        private void Vylez(object sender, EventArgs e)
        {
            NaTlacitku = false;
            popisek.Hide((IWin32Window)sender);
            
        }

        private void UkazPopisek(object sender, MouseEventArgs e)
        {
            short i = -1;
            string nezn = "";
            if (!NaTlacitku)
            {
                string textPopisku = "";
                foreach (NbtCompound c in inventarList)
                {

                    if (c.Get<NbtByte>("Slot").Value == (byte)int.Parse(((Button)sender).Name.Remove(0, 1)))
                    {
                        if (c.Get("id").TagType == NbtTagType.Short)
                            i = c.Get<NbtShort>("id").Value;
                        else
                        {
                            verStringId = true;
                            string sid = c.Get<NbtString>("id").Value;
                            foreach(Item ii in itemList)
                            {
                                if(ii.StringID == sid)
                                {
                                    i = (short)ii.ID;
                                    break;
                                }
                            }
                            if (i == -1)
                                nezn = c.Get<NbtString>("id").Value;
                            else if(i != -1 && podleDamage.Contains(i))
                                nezn = c.Get<NbtString>("id").Value + "\nDmg " + Convert.ToString(c.Get<NbtShort>("Damage").Value);
                        }
                        try
                        {
                            if (varianta != 5)
                            {
                                textPopisku = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(inventarList.IndexOf(c)).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtString>("Name").Value;
                            }
                            else
                            {
                                textPopisku = save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(inventarList.IndexOf(c)).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtString>("Name").Value;
                            }
                        }
                        catch
                        {
                            foreach (Item it in itemList)
                            {
                                //else if (i.ID == id && bannery.Contains(i.ID) && c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value == i.Barva && i.Potion == null)
                                if (it.ID == i && !podleDamage.Contains(i) && ((c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtString>("Potion") == null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") == null) || c.Get<NbtCompound>("tag") == null))
                                {
                                    textPopisku = it.Jmeno;
                                    break;
                                }
                                else if (it.ID == i && it.MaxPoskozeni == c.Get<NbtShort>("Damage").Value && ((c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtString>("Potion") == null) || c.Get<NbtCompound>("tag") == null))
                                {
                                    textPopisku = it.Jmeno;
                                    break;
                                }
                                else if (it.ID == i && !podleDamage.Contains(i) && (c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtString>("Potion") != null && c.Get<NbtCompound>("tag").Get<NbtString>("Potion").Value == it.Potion))
                                {
                                    textPopisku = it.Jmeno;
                                    break;
                                }
                                else if (it.ID == i && bannery.Contains(i) && c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value == it.Barva)
                                {
                                    textPopisku = it.Jmeno;
                                    break;
                                }
                                else if (it.ID == i && !podleDamage.Contains(i) && (c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("EntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("EntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("EntityTag").Get<NbtString>("id") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("EntityTag").Get<NbtString>("id").Value == it.Potion))
                                {
                                    textPopisku = it.Jmeno;
                                    break;
                                }
                            }
                        }
                    }

                }
                if (textPopisku == "" && ((Button)sender).Image != null && !obrazkyBrneni.ContainsValue((Bitmap)(((Button)sender).Image)))
                {
                    if (!verStringId)
                        textPopisku = Jazyk.Strings.Neznamy_item + "\nID " + i;
                    else
                        textPopisku = Jazyk.Strings.Neznamy_item + "\n" + nezn;
                }
                popisek.SetToolTip((Control)sender, textPopisku);
                NaTlacitku = true;
            }
        }
         
        private void SeznamAktivuj(object sender, MouseEventArgs e)
        {

            if (!vyhledavani.ContainsFocus || vyhledavani.Text == "")
                seznamBlocku.Focus();
        }

        private void SeznamDeaktivuj(object sender, EventArgs e)
        {

            if (!vyhledavani.ContainsFocus || vyhledavani.Text == "")
                this.ActiveControl = this.Controls["l" + VybraneTL];
        }

        private void nápovědaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string jaz = "EN";
                if (Properties.Settings.Default.jazyk == "CZ")
                    jaz = "";
                try
                {
                    System.Diagnostics.Process.Start(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Návod" + jaz + ".txt");
                }
                catch
                {
                    System.Diagnostics.Process.Start(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Návod" + jaz + ".TXT");
                }
            }
            catch
            {
                MessageBox.Show(Jazyk.Strings.Napoveda_nestazena, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void changelogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string jaz = "EN";
                if (Properties.Settings.Default.jazyk == "CZ")
                    jaz = "";
                try
                {
                    
                    System.Diagnostics.Process.Start(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Changelog" + jaz + ".txt");
                }
                catch
                {
                    System.Diagnostics.Process.Start(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\Changelog" + jaz + ".TXT");
                }
            }
            catch
            {
                MessageBox.Show(Jazyk.Strings.Changelog_nestazen, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!kategorie)
            {
                kategorie = true;
                ktg.StartPosition = FormStartPosition.Manual;
                ktg.Location = new Point(this.Left + this.Width + 10, this.Top + 50);
                ktg.ShowInTaskbar = false;
                ktg.Show();
                kategorieBtn.Text = Jazyk.Strings.Kategorie + " <<";
            }
            else
            {
                ktg.Close();
                kategorie = false;
                ktg = new Kategorie(this);
                kategorieBtn.Text = Jazyk.Strings.Kategorie + " >>";
            }
        }

        private void Pusunuto(object sender, EventArgs e)
        {
            ktg.Left = this.Left + this.Width + 10;
            ktg.Top = this.Top + 50;
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            probihaAktualizace = true;
            backgroundWorker3.RunWorkerAsync();
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            aktualizaceInfo.Text = "    " + Jazyk.Strings.Priprava_k_instalaci;
            webclient.Proxy = new System.Net.WebProxy();

            if (InvokeRequired)
                this.BeginInvoke(new Action(() => updateButton.Visible = false));
            else
                updateButton.Visible = false;
            int i = 0;
            
            while ((!DokoncenoNacitaniBloku || !DokoncenoNacitaniBrneni) && Nacteno)
            {
                if (i == 100)
                {
                    aktualizaceInfo.Text = "    " + Jazyk.Strings.Aktualizace_nemohla_zacit;
                    if (InvokeRequired)
                        this.BeginInvoke(new Action(() => aktualizovatToolStripMenuItem.Enabled = true));
                    else
                        aktualizovatToolStripMenuItem.Enabled = true;
                    backgroundWorker3.CancelAsync();
                }
                System.Threading.Thread.Sleep(100);
                i++;
            }
            int pocet = 1;
            foreach (Aktualizuj akt in aktualizace.GetInvocationList())
            {
                akt();
                pocet++;
            }
            if (restart)
                Restart();
            if (itemy)
                ItemyStazeny();
            if (enchantybool)
                EnchantyStazeny();
            if (!chyba)
            {
                if (InvokeRequired)
                    this.BeginInvoke(new Action(() => RefreshItem()));
                else
                    RefreshItem();
                probihaAktualizace = false;
                aktualizaceInfo.Text = "    " + Jazyk.Strings.Aktualizace_dokoncena;
                if (InvokeRequired)
                    this.BeginInvoke(new Action(() => aktualizovatToolStripMenuItem.Enabled = true));
                else
                    aktualizovatToolStripMenuItem.Enabled = true;
            }

        }

        private void moznostiHry_Click(object sender, EventArgs e)
        {
            MoznostiHry moznosti = new MoznostiHry(this);
            moznosti.ShowDialog();
        }

        private void vlastnosti_Click(object sender, EventArgs e)
        {
            VlastnostiItemu vlastnosti = new VlastnostiItemu(this);
            if (!bannery.Contains(vybranyItemId))
            {
                vlastnosti.bannerPanel.Hide();
            }
            vlastnosti.ShowDialog();
        }

        private void kopirovatBtn_Click(object sender, EventArgs e)
        {
            Kopirovat();
        }

        private void vlozitBtn_Click(object sender, EventArgs e)
        {
            Vlozit();
        }

        private void přidatItemDoSeznamuItemůToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!novyItemOtevreno)
            {
                NovyItem ni = new NovyItem(vybranyItemId, poskozeni.Value);
                ni.Show();
                ni.FormClosed += new FormClosedEventHandler(ni_FormClosed);
                ni.FormClosing += new FormClosingEventHandler(ni_FormClosing);
                ni.BringToFront();
                novyItemOtevreno = true;
            }
            else
                MessageBox.Show(Jazyk.Strings.Novy_item_otevreno, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void češtinaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.jazyk = "CZ";
            Properties.Settings.Default.Save();
            ZmenJazyk();
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.jazyk = "EN";
            Properties.Settings.Default.Save();
            ZmenJazyk();
        }

        private void jazyk_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.jazyk = ((ToolStripItem)sender).Tag.ToString();
            Properties.Settings.Default.Save();
            Jazyk.Strings.Reload();
            ZmenJazyk();
        }

        private void odeslatInfoOChyběnápadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OdeslaniZpravy oz = new OdeslaniZpravy("Hlášení o chybě.", 1);
            oz.ShowDialog();
        }

        private void poslatNápadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OdeslaniZpravy oz = new OdeslaniZpravy("Nový nápad", 2);
            oz.ShowDialog();
        }


        #endregion

        #region Metody

        private void Nacti()
        {

            NacitamSave ns = new NacitamSave();
            try
            {
                otevreno = false;
                //ověření, jestli předchozí práce je uložená
                DialogResult res = new DialogResult();
                if (Neulozeno)
                    res = MessageBox.Show(Jazyk.Strings.Chcete_ulozit_zmeny, "SaveEdit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (res == DialogResult.No)
                {
                    Neulozeno = false;
                    this.Text = "SaveEdit";
                }
                else if (res == DialogResult.Yes)
                    Ulozit();

                Prepnuto = true;

                //vymazání textu z tlačítek
                foreach (Control c in Controls)
                    if (c.GetType().ToString() == "System.Windows.Forms.Button")
                        if (c.Name.StartsWith("i"))
                        {
                            c.Text = "";
                            ((Button)c).Image = null;
                            ((Button)c).ForeColor = Color.Black;
                        }

                //načtení savu

                ns.Show();
                ns.Refresh();

                if (!item.Contains(@".minecraft\saves\"))
                    try
                    {

                        save.LoadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + item + @"\level.dat");
                        varianta = 1;
                        Properties.Settings.Default.cesta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + item;
                    }
                    catch
                    {
                        try
                        {
                            save.LoadFromFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + item);
                            varianta = 2;
                            Properties.Settings.Default.cesta = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + item.Replace("level.dat", "");
                        }
                        catch
                        {
                            save.LoadFromFile(item); varianta = 3;
                            Properties.Settings.Default.cesta = item.Replace("level.dat", "");
                        }
                    }
                else
                {
                    save.LoadFromFile(item);
                    varianta = 4;
                    Properties.Settings.Default.cesta = item.Replace("level.dat", "");
                }

                try
                {
                    if (save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player") == null)
                    {
                        if (varianta == 1 || varianta == 2 || varianta == 3)
                        {
                            otevritDial.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + item + @"\players";
                            if (!otevreno)
                            {
                                otevreno = true;
                                otevrit.DropDown.Hide();
                                otevritDial.ShowDialog();
                                goto konec;
                            }
                        }
                        else if (varianta == 4)
                        {
                            otevritDial.InitialDirectory = item.Replace("\\level.dat", "") + @"\players";
                            if (!otevreno)
                            {
                                otevreno = true;
                                otevrit.DropDown.Hide();
                                otevritDial.ShowDialog();
                                goto konec;
                            }
                        }
                        varianta = 5;
                    }
                }
                catch { varianta = 5; }

                if (varianta != 5)
                    this.Text = "SaveEdit | " + (item.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\", "")).Replace(@"\level.dat", "");
                else
                    this.Text = "SaveEdit | " + (item.Replace(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\", "")).Replace(@"\players\", ": ").Replace(".dat", "");
                if (varianta != 5)
                {
                    xplevel.Text = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtInt>("XpLevel").Value.ToString();
                    inventarList = save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory");
                }
                else
                {
                    xplevel.Text = save.RootTag.Get<NbtInt>("XpLevel").Value.ToString();
                    inventarList = save.RootTag.Get<NbtList>("Inventory");
                }

                //odstranění úvodního hlášení 
                poNacteni.Dispose();

                verStringId = false;

                //přiřazení textu a obrázku k tlačítkám
                foreach (NbtCompound c in inventarList)
                {
                    VybraneTL = c.Get<NbtByte>("Slot").Value;
                    NactiObrazky(false, c.Get<NbtByte>("Count").Value.ToString());

                }

                //aktivace tlačítka 0
                VybraneTL = 0;
                InventarVyber();
                Prepnuto = false;
                vyhledavani.Visible = true;
                Nacteno = true;
                if (DokoncenoNacitaniBloku)
                {
                    seznamBlocku.Visible = true;
                }
                NactiBrneni();
                ulozit.Enabled = true;
                otevreno = false;
            konec:
                i0.Focus();
                if (Properties.Settings.Default.cesta == String.Empty)
                    otevritDial.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves";

                moznostiHry.Enabled = true;
                kopirovatBtn.Enabled = true;
            }
            catch
            {
                MessageBox.Show(Jazyk.Strings.Soubor_nebyl_nacten, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { ns.Close(); }
        }

        //přidání ohraničenýho textu
        private Bitmap AddText(Bitmap bitmapa, string text)
        {
            Bitmap b = new Bitmap(36, 36);
            Graphics g = Graphics.FromImage(b);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawImage(bitmapa, 2, 3);
            float size = 13;

            System.Drawing.Drawing2D.GraphicsPath fontpath = new System.Drawing.Drawing2D.GraphicsPath();
            int x, y;
            if (text.Length == 2)
            {
                x = 15;
                y = 20;
            }
            else if (text.Length == 1)
            {
                x = 24;
                y = 20;
            }
            else if (text.Length == 3)
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
            
            Point p = new Point(x, y);
            fontpath.AddString(text, new FontFamily("Arial Black"), (int)FontStyle.Bold, size, p, StringFormat.GenericDefault);
            g.FillPath(Brushes.White, fontpath);
            g.DrawPath(new Pen(Color.Black, 1), fontpath);
            fontpath.Dispose();
            fontpath = null;
            g.Dispose();
            g = null;
            return b;
        }

        public void NactiObrazky(bool menu, string text = "")
        {
            //načítání obrázků pro listView
            XmlDocument ctiItemy = new XmlDocument();
            ctiItemy.Load(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + @"\itemy.xml");
            try
            {
                if (menu)
                {
                    DokoncenoNacitaniBloku = false;
                    if (InvokeRequired)
                    {
                        this.BeginInvoke(new Action(() => this.label7.Visible = true));
                        this.BeginInvoke(new Action(() => this.Update()));
                    }
                    else
                    {
                        label7.Visible = true;
                        this.Update();
                    }
                    seznamBlocku.BeginUpdate();
                    
                    itemList.Clear();
                    seznamBlocku.Clear();
                    seznamBlocku.Items.Clear();
                    seznamBlocku.SmallImageList.Images.Clear();

                    XmlNodeList neukazovatDamBar = ctiItemy.SelectNodes("Itemy/Nastaveni/NezobrazovatDmgPanel/ID");
                    foreach (XmlNode s in neukazovatDamBar)
                    {
                        neukazovatBar.Add(int.Parse(s.InnerText));
                    }

                    XmlNodeList seznamRozliseniDamage = ctiItemy.SelectNodes("Itemy/Nastaveni/RozlisenoPodleDmg/ID");
                    foreach (XmlNode s in seznamRozliseniDamage)
                    {
                        podleDamage.Add(int.Parse(s.InnerText));
                    }

                    XmlNodeList setstnactkoveSTR = ctiItemy.SelectNodes("Itemy/Nastaveni/StackPo16/ID");
                    foreach (XmlNode s in setstnactkoveSTR)
                    {
                        sestnact.Add(int.Parse(s.InnerText));
                    }

                    XmlNodeList nactiJednaBarvaSTR = ctiItemy.SelectNodes("Itemy/Nastaveni/JednaBarva/ID");
                    foreach (XmlNode s in nactiJednaBarvaSTR)
                    {
                        jednaBarva.Add(int.Parse(s.InnerText));
                    }

                    XmlNodeList nactiViceBarevSTR = ctiItemy.SelectNodes("Itemy/Nastaveni/ViceBarev/ID");
                    foreach (XmlNode s in nactiViceBarevSTR)
                    {
                        viceBarev.Add(int.Parse(s.InnerText));
                    }

                    XmlNodeList nactiExplosionsSTR = ctiItemy.SelectNodes("Itemy/Nastaveni/Exploze/ID");
                    foreach (XmlNode s in nactiExplosionsSTR)
                    {
                        explosions.Add(int.Parse(s.InnerText));
                    }

                    XmlNodeList bannerySeznam = ctiItemy.SelectNodes("Itemy/Nastaveni/Banner/ID");
                    foreach (XmlNode s in bannerySeznam)
                    {
                        bannery.Add(int.Parse(s.InnerText));
                    }

                    //nacteni brneni
                    XmlNodeList povoleneBotyXml = ctiItemy.SelectNodes("Itemy/Nastaveni/PovoleneBrneni/Boty/ID");
                    foreach (XmlNode s in povoleneBotyXml)
                    {
                        povoleneBoty.Add(int.Parse(s.InnerText));
                    }
                    XmlNodeList povoleneKalhotyXml = ctiItemy.SelectNodes("Itemy/Nastaveni/PovoleneBrneni/Kalhoty/ID");
                    foreach (XmlNode s in povoleneKalhotyXml)
                    {
                        povoleneKalhoty.Add(int.Parse(s.InnerText));
                    }
                    XmlNodeList povoleneTeloXml = ctiItemy.SelectNodes("Itemy/Nastaveni/PovoleneBrneni/Telo/ID");
                    foreach (XmlNode s in povoleneTeloXml)
                    {
                        povoleneTelo.Add(int.Parse(s.InnerText));
                    }
                    XmlNodeList povoleneHelmaXml = ctiItemy.SelectNodes("Itemy/Nastaveni/PovoleneBrneni/Helma/ID");
                    foreach (XmlNode s in povoleneHelmaXml)
                    {
                        povoleneHelma.Add(int.Parse(s.InnerText));
                    }

                    bool spatne = false;

                    //načtení všech obrázků ze seznamu herních itemů
                    XmlNodeList itemyHra = ctiItemy.SelectNodes("Itemy/Seznam/Hra/Item");
                    foreach(XmlNode item in itemyHra)
                    {
                        try
                        {
                            string p = null;
                            int barva = -1;
                            try { p = item.SelectSingleNode("Potion").InnerText; }
                            catch {
                                try { p = item.SelectSingleNode("Egg").InnerText; }
                                catch { p = null; }
                            }
                            try { 
                                barva = int.Parse(item.SelectSingleNode("Base").InnerText);
                            }
                            catch { barva = -1; }
                            
                            itemList.Add(new Item(Int32.Parse(item.SelectSingleNode("ID").InnerText), item.SelectSingleNode("StringID").InnerText, item.SelectSingleNode("Jmeno").InnerText, Int32.Parse(item.SelectSingleNode("Dmg").InnerText), item.SelectSingleNode("Soubor").InnerText, Int16.Parse(item.SelectSingleNode("PoziceZleva").InnerText), Int16.Parse(item.SelectSingleNode("PoziceShora").InnerText), Convert.ToBoolean(item.SelectSingleNode("Stackovatelnost").InnerText), short.Parse(item.SelectSingleNode("Kategorie").InnerText), false, p, barva));
                        }
                        catch 
                        {
                            verzeItemu = 0;
                            spatne = true;
                            MessageBox.Show(Jazyk.Strings.Stare_itemy, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        if (spatne)
                            break;
                    }

                    //načtení všech obrázků ze seznamu vlastních itemů
                    if (!spatne)
                    {
                        XmlNodeList itemyVlastni = ctiItemy.SelectNodes("Itemy/Seznam/Vlastni/Item");
                        foreach (XmlNode item in itemyVlastni)
                        {
                            try
                            {
                                string p = null;
                                int barva = -1;
                                try { barva = int.Parse(item.SelectSingleNode("Base").InnerText); }
                                catch{ barva = -1;}
                                try { p = item.SelectSingleNode("Potion").InnerText; }
                                catch { p = null; }
                                itemList.Add(new Item(Int32.Parse(item.SelectSingleNode("ID").InnerText), item.SelectSingleNode("StringID").InnerText, item.SelectSingleNode("Jmeno").InnerText, Int32.Parse(item.SelectSingleNode("Dmg").InnerText), item.SelectSingleNode("Soubor").InnerText, Int16.Parse(item.SelectSingleNode("PoziceZleva").InnerText), Int16.Parse(item.SelectSingleNode("PoziceShora").InnerText), Convert.ToBoolean(item.SelectSingleNode("Stackovatelnost").InnerText), short.Parse(item.SelectSingleNode("Kategorie").InnerText), true, p, barva));
                            }
                            catch
                            {
                                verzeItemu = 0;
                                spatne = true;
                                MessageBox.Show(Jazyk.Strings.Stare_itemy, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            if (spatne)
                                break;
                        }
                    }

                    int count = 0;

                    //tohle to brzdí nejvíc při načítání itemů a nechápu proč, když to jede na jinym vlákně
                    foreach (Item i in itemList)
                    {
                        Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + i.Obrazek);
                        Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle((i.X - 1) * 16, (i.Y - 1) * 16, 16, 16), obrazek.PixelFormat);
                        seznamBlocku.SmallImageList.Images.Add((Image)subObrazek);
                        seznamBlocku.Items.Add(new ListViewItem(i.Jmeno, count));
                        
                        //tohle tpůsobí to, že okno nevytuhne
                        Application.DoEvents();
                        count++;
                    }
                    List<string> list = new List<string>();
                    seznamBlocku.EndUpdate();
                    if(InvokeRequired)
                        this.BeginInvoke(new Action(() => this.label7.Visible = false));
                    else
                        label7.Visible = false;
                    DokoncenoNacitaniBloku = true;

                }

                //načítání obrázků prop inventář
                else if (!menu)
                {
                    
                    //čekání na načtení brnění a jejich obrázků po prvním spuštění
                    sbyte kontrolaBrneni = 0;
                    while (kontrolaBrneni < 40 && !DokoncenoNacitaniBrneni)
                    {
                        System.Threading.Thread.Sleep(100);
                    }

                    //načtení obrázku pro konkrétní slot
                    foreach (NbtCompound c in inventarList)
                    {
                        if (c.Get<NbtByte>("Slot").Value == VybraneTL)
                        {
                            bool je = false;
                            foreach (Item i in itemList)
                            {
                                short id = 0;
                                if (c.Get("id").TagType == NbtTagType.Short)
                                    id = c.Get<NbtShort>("id").Value;
                                else
                                {
                                    string sid = c.Get<NbtString>("id").Value;
                                    foreach (Item ii in itemList)
                                    {
                                        if(ii.StringID == sid)
                                        {
                                            verStringId = true;
                                            id = (short)ii.ID;
                                            break;
                                        }
                                    }
                                }
                                if (i.ID == id && !podleDamage.Contains(i.ID) && i.Potion == null && i.Barva == -1)
                                {
                                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + i.Obrazek);
                                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle((i.X - 1) * 16, (i.Y - 1) * 16, 16, 16), obrazek.PixelFormat);
                                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                                    ((Button)Controls["i" + VybraneTL]).Image = null;
                                    if(!neukazovatBar.Contains(i.ID))
                                        ((Button)Controls["i" + VybraneTL]).Image = DamageBar(AddText(subObrazek, text), i.MaxPoskozeni, (int)c.Get<NbtShort>("Damage").Value);
                                    else
                                        ((Button)Controls["i" + VybraneTL]).Image = AddText(subObrazek, text);
                                    try
                                    {
                                        if (c.Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                                            c.Get<NbtCompound>("tag").Get<NbtList>("ench").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");
                                        else
                                            c.Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");

                                        ((Button)Controls["i" + VybraneTL]).Image = EnchantLabel((Bitmap)((Button)Controls["i" + VybraneTL]).Image);

                                    }
                                    catch
                                    {
                                        
                                    }
                                    je = true;
                                }
                                    //štíty a spol
                                else if (i.ID == id && bannery.Contains(i.ID) && c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value == i.Barva && i.Potion == null)
                                {
                                    /*if (c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value != i.MaxPoskozeni)
                                    {
                                        continue;
                                    }*/
                                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + i.Obrazek);
                                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle((i.X - 1) * 16, (i.Y - 1) * 16, 16, 16), obrazek.PixelFormat);
                                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                                    ((Button)Controls["i" + VybraneTL]).Image = null;
                                    if (!neukazovatBar.Contains(i.ID))
                                        ((Button)Controls["i" + VybraneTL]).Image = DamageBar(AddText(subObrazek, text), i.MaxPoskozeni, (int)c.Get<NbtShort>("Damage").Value);
                                    else
                                        ((Button)Controls["i" + VybraneTL]).Image = AddText(subObrazek, text);
                                    try
                                    {
                                        if (c.Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                                            c.Get<NbtCompound>("tag").Get<NbtList>("ench").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");
                                        else
                                            c.Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");

                                        //((Button)Controls["i" + VybraneTL]).Image = EnchantLabel((Bitmap)((Button)Controls["i" + VybraneTL]).Image);

                                    }
                                    catch
                                    {

                                    }
                                    je = true;
                                }
                                else if (i.ID == id && bannery.Contains(i.ID) && -1 == i.Barva)
                                {
                                    /*if (c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value != i.MaxPoskozeni)
                                    {
                                        continue;
                                    }*/
                                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + i.Obrazek);
                                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle((i.X - 1) * 16, (i.Y - 1) * 16, 16, 16), obrazek.PixelFormat);
                                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                                    ((Button)Controls["i" + VybraneTL]).Image = null;
                                    if (!neukazovatBar.Contains(i.ID))
                                        ((Button)Controls["i" + VybraneTL]).Image = DamageBar(AddText(subObrazek, text), i.MaxPoskozeni, (int)c.Get<NbtShort>("Damage").Value);
                                    else
                                        ((Button)Controls["i" + VybraneTL]).Image = AddText(subObrazek, text);
                                    try
                                    {
                                        if (c.Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                                            c.Get<NbtCompound>("tag").Get<NbtList>("ench").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");
                                        else
                                            c.Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");

                                        //((Button)Controls["i" + VybraneTL]).Image = EnchantLabel((Bitmap)((Button)Controls["i" + VybraneTL]).Image);

                                    }
                                    catch
                                    {

                                    }
                                    je = true;
                                }
                                //načtení obrázku, pokud se jedná o větvičku, dřevo, listí, trávu, nebo vlnu
                                else if (i.ID == id && i.MaxPoskozeni == c.Get<NbtShort>("Damage").Value && i.Potion == null)
                                {
                                    /*if (c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value != i.MaxPoskozeni)
                                    {
                                        continue;
                                    }*/
                                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + i.Obrazek);
                                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle((i.X - 1) * 16, (i.Y - 1) * 16, 16, 16), obrazek.PixelFormat);
                                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                                    ((Button)Controls["i" + VybraneTL]).Image = null;
                                    ((Button)Controls["i" + VybraneTL]).Image = AddText(subObrazek, text);
                                    try
                                    {
                                        if (c.Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                                            c.Get<NbtCompound>("tag").Get<NbtList>("ench").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");
                                        else
                                            c.Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");

                                        //((Button)Controls["i" + VybraneTL]).Image = EnchantLabel((Bitmap)((Button)Controls["i" + VybraneTL]).Image);

                                    }
                                    catch
                                    {
                                        
                                    }
                                    je = true;
                                }
                                //ty nové šípy
                                else if (i.ID == id && c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtString>("Potion") != null && i.Potion == c.Get<NbtCompound>("tag").Get<NbtString>("Potion").Value)
                                {
                                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + i.Obrazek);
                                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle((i.X - 1) * 16, (i.Y - 1) * 16, 16, 16), obrazek.PixelFormat);
                                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                                    ((Button)Controls["i" + VybraneTL]).Image = null;
                                    ((Button)Controls["i" + VybraneTL]).Image = AddText(subObrazek, text);
                                    try
                                    {
                                        if (c.Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                                            c.Get<NbtCompound>("tag").Get<NbtList>("ench").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");
                                        else
                                            c.Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");

                                        //((Button)Controls["i" + VybraneTL]).Image = EnchantLabel((Bitmap)((Button)Controls["i" + VybraneTL]).Image);

                                    }
                                    catch
                                    {

                                    }
                                    je = true;
                                }
                                //ty nové vejce
                                else if (i.ID == id && c.Get<NbtCompound>("tag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("EntityTag") != null && c.Get<NbtCompound>("tag").Get<NbtCompound>("EntityTag").Get<NbtString>("id") != null && i.Potion == c.Get<NbtCompound>("tag").Get<NbtCompound>("EntityTag").Get<NbtString>("id").Value)
                                {
                                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + i.Obrazek);
                                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle((i.X - 1) * 16, (i.Y - 1) * 16, 16, 16), obrazek.PixelFormat);
                                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                                    ((Button)Controls["i" + VybraneTL]).Image = null;
                                    ((Button)Controls["i" + VybraneTL]).Image = AddText(subObrazek, text);
                                    /*try
                                    {
                                        if (c.Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                                            c.Get<NbtCompound>("tag").Get<NbtList>("ench").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");
                                        else
                                            c.Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments").Get<NbtCompound>(Aktivnienchant).Get<NbtShort>("id");

                                        //((Button)Controls["i" + VybraneTL]).Image = EnchantLabel((Bitmap)((Button)Controls["i" + VybraneTL]).Image);

                                    }
                                    catch
                                    {

                                    }*/
                                    je = true;
                                }
                                
                            }
                            if (!je)
                            {
                                Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\items.png");
                                Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle(0, 14 * 16, 16, 16), obrazek.PixelFormat);
                                subObrazek = ResizeBMP(subObrazek, 32, 32);
                                string dodatek;
                                if (text.Length == 1)
                                    dodatek = "     ";
                                else if (text.Length == 2)
                                    dodatek = "   ";
                                else
                                    dodatek = " ";
                                ((Button)Controls["i" + VybraneTL]).Image = null;
                                if (c.Get("id").TagType == NbtTagType.Short)
                                    ((Button)Controls["i" + VybraneTL]).Image = AddText(subObrazek, c.Get<NbtShort>("id").Value.ToString() + "\n" + dodatek + text);
                                else
                                {

                                    verStringId = true;
                                    ((Button)Controls["i" + VybraneTL]).Image = AddText(subObrazek, "\n" + dodatek + text);
                                    break;
                                }
                            }

                            break;
                        }
                    }
                }
            }
            catch 
            {
                Nekompatibilita = true;
                verzeItemu = 0;
                MessageBox.Show(Jazyk.Strings.Stare_itemy, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(!probihaAktualizace)
                NactiBrneni();
        }

        private Bitmap DamageBar(Bitmap bitmapa, int maxPoskozeni, int aktualniPoskozeni)
        {
            if (aktualniPoskozeni < 0)
                aktualniPoskozeni = 0;
            int sirka = 72 - (int)((double)72 / (double)maxPoskozeni * (double)aktualniPoskozeni);
            if (sirka < 0)
                sirka = 0;
            if (maxPoskozeni > 0 && aktualniPoskozeni > 0)
            {
                
                Graphics g = Graphics.FromImage((Image)bitmapa);
                Bitmap bod2 = new Bitmap(1, 1);
                bod2.SetPixel(0, 0, Color.FromArgb(180,180,180));
                bod2 = ResizeBMP(bod2, 72, 5);
                g.DrawImage(bod2, 0, 0);
                if (sirka > 0)
                {
                    Bitmap bod = new Bitmap(1, 1);
                    bod.SetPixel(0, 0, Color.FromArgb((int)((double)255 / (double)maxPoskozeni * (double)aktualniPoskozeni), (int)((double)255 - ((double)255 / (double)maxPoskozeni * (double)aktualniPoskozeni)), 0));
                    bod = ResizeBMP(bod, sirka, 5);
                    g.DrawImage(bod, 0, 0);
                }
                g.Dispose();
                g = null;
            }
            return bitmapa;
        }

        internal Bitmap EnchantLabel(Bitmap bitmapa)
        {
            Graphics g = Graphics.FromImage(bitmapa);
            Bitmap b = new Bitmap(bitmapa);
            Bitmap bod = new Bitmap(1, 1);
            bod.SetPixel(0, 0, Color.FromArgb(211,173,255));
            bod = ResizeBMP(bod, 72, 72);
            g.DrawImage(bod, 0, 0);
            g.DrawImage(b, 0, 0);
            g.Dispose();
            return bitmapa;
        }

        private void NactiBrneni()
        {
            DokoncenoNacitaniBrneni = false;
            if (i103.Image == null)
            {
                if (!obrazkyBrneni.ContainsKey("103"))
                {
                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\items.png");
                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle(15 * 16, 0, 16, 16), obrazek.PixelFormat);
                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                    i103.Image = subObrazek;
                    obrazkyBrneni.Add("103", subObrazek);
                }
                else
                    i103.Image = obrazkyBrneni["103"];
                Helma = false;
            }

            if (i102.Image == null)
            {
                if (!obrazkyBrneni.ContainsKey("102"))
                {
                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\items.png");
                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle(15 * 16, 16, 16, 16), obrazek.PixelFormat);
                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                    i102.Image = subObrazek;
                    obrazkyBrneni.Add("102", subObrazek);
                }
                else
                    i102.Image = obrazkyBrneni["102"];
                Brneni = false;
            }

            if (i101.Image == null)
            {
                if (!obrazkyBrneni.ContainsKey("101"))
                {
                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\items.png");
                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle(15 * 16, 32, 16, 16), obrazek.PixelFormat);
                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                    i101.Image = subObrazek;
                    obrazkyBrneni.Add("101", subObrazek);
                }
                else
                    i101.Image = obrazkyBrneni["101"];
                Kalhoty = false;
            }

            if (i100.Image == null)
            {
                if (!obrazkyBrneni.ContainsKey("100"))
                {
                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\items.png");
                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle(15 * 16, 48, 16, 16), obrazek.PixelFormat);
                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                    i100.Image = subObrazek;
                    obrazkyBrneni.Add("100", subObrazek);
                }
                else
                    i100.Image = obrazkyBrneni["100"];
                Boty = false;
            }

            if (i150.Image == null)
            {
                if (!obrazkyBrneni.ContainsKey("150"))
                {
                    Bitmap obrazek = new Bitmap(Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\items.png");
                    Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle(18 * 16, 0, 16, 16), obrazek.PixelFormat);
                    subObrazek = ResizeBMP(subObrazek, 32, 32);
                    i150.Image = subObrazek;
                    obrazkyBrneni.Add("150", subObrazek);
                }
                else
                    i150.Image = obrazkyBrneni["150"];
                Stit = false;
            }
            DokoncenoNacitaniBrneni = true;

        }

        //změna velikosti bitmapy
        internal Bitmap ResizeBMP(Bitmap bitmapa, int novaSirka, int novaVyska)
        {
            Bitmap result = new Bitmap(novaSirka, novaVyska);
            using (Graphics g = Graphics.FromImage((Image)result))
            {
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.None;
                g.DrawImage(bitmapa, 0, 0, novaSirka, novaVyska);
            }
            return result;
        }

        internal void NeulozenoMetoda(bool ulozeno = false)
        {
            if (!Neulozeno && !ulozeno)
            {
                Neulozeno = true;
                this.Text += " (" + Jazyk.Strings.Neulozeno + ")";
            }
            else if (Neulozeno && ulozeno)
            {
                Neulozeno = false;
                this.Text = this.Text.Replace(" (" + Jazyk.Strings.Neulozeno + ")", "");
            }

        }

        private void InventarVyber()
        {
            Prepnuto = true;
            pocet.Value = 1;
            poskozeni.Minimum = -20000;
            poskozeni.Value = 0;
            enchanty.Clear();
            enchantyButton.Enabled = false;
            vlastnosti.Enabled = false;

            // načtení počtu a poškození, aktivace prvního enchantu
            foreach (NbtCompound c in inventarList)
            {

                if (c.Get<NbtByte>("Slot").Value == VybraneTL)
                {

                    short id = 0;
                    if (c.Get("id").TagType == NbtTagType.Short)
                        id = vybranyItemId = c.Get<NbtShort>("id").Value;
                    else
                    {
                        verStringId = true;
                        string sid = c.Get<NbtString>("id").Value;
                        foreach(Item i in itemList)
                        {
                            if(i.StringID == sid)
                            {
                                id = vybranyItemId = (short)i.ID;
                                break;
                            }
                        }
                    }

                    foreach (Enchant e in enchantyList)
                    {
                        if (e.PovoleneItemy.Contains(id))
                        {
                            enchanty.Add(e.Jmeno);
                        }
                    }

                    if (enchanty.Count > 0)
                        enchantyButton.Enabled = true;
                    else
                        enchantyButton.Enabled = false;

                    pocet.Value = c.Get<NbtByte>("Count").Value;
                    poskozeni.Value = c.Get<NbtShort>("Damage").Value;
                    vlastnosti.Enabled = true;

                    break;
                }
            }
            Prepnuto = false;
        }
        
        private void Ulozit()
        {
            try
            {
                if (varianta != 5)
                {
                    if (!item.Contains(@".minecraft\saves\"))
                    {
                        try
                        {
                            save.SaveToFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + item + @"\level.dat", LibNbt.NbtCompression.GZip);
                        }
                        catch
                        {
                            save.SaveToFile(item, LibNbt.NbtCompression.GZip);
                        }
                    }
                    else
                        save.SaveToFile(item, LibNbt.NbtCompression.GZip);
                }
                else
                {
                    if (!item.Contains(@".minecraft\saves\"))
                    {
                        try
                        {
                            save.SaveToFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + item, LibNbt.NbtCompression.GZip);
                        }
                        catch
                        {
                            save.SaveToFile(item, LibNbt.NbtCompression.GZip);
                        }
                    }
                    else
                        save.SaveToFile(item, LibNbt.NbtCompression.GZip);
                }

                Neulozeno = false;
                this.Text = this.Text.Replace(" (" + Jazyk.Strings.Neulozeno + ")", "");
            }
            catch
            {
                MessageBox.Show(Jazyk.Strings.Bez_mezer, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Kopirovat()
        {
            if (Nacteno)
            {
                foreach (NbtCompound c in inventarList)
                {

                    if (c.Get<NbtByte>("Slot").Value == VybraneTL)
                    {
                        kopirovanyItem = new NbtCompound();

                        NbtByte slot = new NbtByte("Slot", c.Get<NbtByte>("Slot").Value);
                        NbtByte count = new NbtByte("Count", c.Get<NbtByte>("Count").Value);
                        NbtShort damage = new NbtShort("Damage", c.Get<NbtShort>("Damage").Value);
                        NbtTag id = null;
                        if (c.Get("id").TagType == NbtTagType.Short)
                            id = new NbtShort("id", c.Get<NbtShort>("id").Value);
                        else
                        {
                            string sid = c.Get<NbtString>("id").Value;
                            foreach (Item i in itemList)
                            {
                                if (i.StringID == sid)
                                {
                                    //id = new NbtShort("id", (short)i.ID);
                                    id = new NbtString("id", i.StringID);
                                    break;
                                }
                            }
                        }

                        if(id == null)
                            id = new NbtString("id", c.Get<NbtString>("id").Value);

                        kopirovanyItem.Add(slot);
                        kopirovanyItem.Add(count);
                        kopirovanyItem.Add(damage);
                        kopirovanyItem.Add(id);

                        if (c.Get<NbtCompound>("tag") != null)
                        {
                            NbtCompound tag = new NbtCompound("tag");
                            NbtCompound egg;

                            foreach (NbtTag seznam in c.Get<NbtCompound>("tag"))
                            {
                                //pokud reapircost
                                if (seznam.Name == "RepairCost")
                                {
                                    tag.Add(new NbtInt("RepairCost", ((NbtInt)seznam).Value));
                                }

                                //pokud nový šíp
                                if (seznam.Name == "Potion")
                                {
                                    tag.Add(new NbtString("Potion", ((NbtString)seznam).Value));
                                }

                                //pokud spawn egg
                                if (seznam.Name == "EntityTag")
                                {
                                    egg = (NbtCompound)seznam;
                                    if (((NbtCompound)seznam).Get("id") != null)
                                    {
                                        egg.Add(new NbtString("id", ((NbtCompound)seznam).Get<NbtString>("id").Value));
                                    }
                                }

                                //pokud je display
                                else if (seznam.Name == "display")
                                {
                                    NbtCompound display = new NbtCompound("display");

                                    foreach (NbtTag hodnoty in (NbtCompound)seznam)
                                    {
                                        if (hodnoty.Name == "color")
                                            display.Add(new NbtInt("color", ((NbtInt)hodnoty).Value));
                                        else if (hodnoty.Name == "Name")
                                            display.Add(new NbtString("Name", ((NbtString)hodnoty).Value));
                                    }

                                    tag.Add(display);
                                }

                                //pokud je ench
                                else if (seznam.Name == "ench")
                                {
                                    NbtList ench = new NbtList("ench");

                                    foreach (NbtCompound compound in (NbtList)seznam)
                                    {
                                        NbtCompound newCompound = new NbtCompound();
                                        foreach (NbtShort hodnoty in compound)
                                        {
                                            if (hodnoty.Name == "id")
                                                newCompound.Add(new NbtShort("id", hodnoty.Value));
                                            else if (hodnoty.Name == "lvl")
                                                newCompound.Add(new NbtShort("lvl", hodnoty.Value));
                                        }
                                        ench.Add(newCompound);
                                    }

                                    tag.Add(ench);
                                }

                                //pokud je storedench
                                else if (seznam.Name == "StoredEnchantments")
                                {
                                    NbtList ench = new NbtList("StoredEnchantments");

                                    foreach (NbtCompound compound in (NbtList)seznam)
                                    {
                                        NbtCompound newCompound = new NbtCompound();
                                        foreach (NbtShort hodnoty in compound)
                                        {
                                            if (hodnoty.Name == "id")
                                                newCompound.Add(new NbtShort("id", hodnoty.Value));
                                            else if (hodnoty.Name == "lvl")
                                                newCompound.Add(new NbtShort("lvl", hodnoty.Value));
                                        }
                                        ench.Add(newCompound);
                                    }

                                    tag.Add(ench);
                                }

                                //pokud je banner
                                else if (seznam.Name == "BlockEntityTag")
                                {
                                    NbtCompound comp = new NbtCompound("BlockEntityTag");
                                    if (((NbtCompound)seznam).Get<NbtList>("Patterns") != null)
                                    {
                                        comp.Add(new NbtList("Patterns", NbtTagType.Compound));
                                        foreach (NbtCompound hodnoty in ((NbtCompound)seznam).Get<NbtList>("Patterns"))
                                        {
                                            NbtCompound comp2 = new NbtCompound();
                                            comp2.Add(new NbtInt("Color", hodnoty.Get<NbtInt>("Color").Value));
                                            comp2.Add(new NbtString("Pattern", hodnoty.Get<NbtString>("Pattern").Value));
                                            comp.Get<NbtList>("Patterns").Add(comp2);
                                        }
                                    }
                                    if (((NbtCompound)seznam).Get<NbtInt>("Base") != null)
                                    {
                                        comp.Add(new NbtInt("Base", ((NbtCompound)seznam).Get<NbtInt>("Base").Value));
                                    }
                                    tag.Add(comp);
                                }
                                //pokud je štít
                                /*else if (seznam.Name == "BlockEntityTag")
                                {
                                    NbtCompound comp = new NbtCompound("BlockEntityTag");
                                    if (((NbtCompound)seznam).Get<NbtList>("Patterns") != null)
                                    {
                                        comp.Add(new NbtList("Patterns", NbtTagType.Compound));
                                        foreach (NbtCompound hodnoty in ((NbtCompound)seznam).Get<NbtList>("Patterns"))
                                        {
                                            NbtCompound comp2 = new NbtCompound();
                                            comp2.Add(new NbtInt("Color", hodnoty.Get<NbtInt>("Color").Value));
                                            comp2.Add(new NbtString("Pattern", hodnoty.Get<NbtString>("Pattern").Value));
                                            comp.Get<NbtList>("Patterns").Add(comp2);
                                        }
                                    }
                                    if (((NbtCompound)seznam).Get<NbtInt>("Base") != null)
                                    {
                                        comp.Add(new NbtInt("Base", ((NbtCompound)seznam).Get<NbtInt>("Base").Value));
                                    }
                                    tag.Add(comp);
                                }*/

                                //pokud je Explosions
                                else if (seznam.Name == "Explosion")
                                {
                                    NbtCompound exploze = new NbtCompound("Explosion");

                                    foreach (NbtTag hodnoty in (NbtCompound)seznam)
                                    {
                                        if (hodnoty.Name == "Trail")
                                            exploze.Add(new NbtByte("Trail", ((NbtByte)hodnoty).Value));
                                        else if (hodnoty.Name == "Type")
                                            exploze.Add(new NbtByte("Type", ((NbtByte)hodnoty).Value));
                                        else if (hodnoty.Name == "Flicker")
                                            exploze.Add(new NbtByte("Flicker", ((NbtByte)hodnoty).Value));
                                        else if (hodnoty.Name == "Colors")
                                            exploze.Add(new NbtIntArray("Colors", ((NbtIntArray)hodnoty).Value));
                                        else if (hodnoty.Name == "FadeColors")
                                            exploze.Add(new NbtIntArray("FadeColors", ((NbtIntArray)hodnoty).Value));
                                    }

                                    tag.Add(exploze);
                                }

                                //pokud je fireworks TODO
                                else if (seznam.Name == "Fireworks")
                                {
                                    NbtCompound fire = new NbtCompound("Fireworks");

                                    if (((NbtCompound)seznam).Get<NbtByte>("Flight") != null)
                                        fire.Add(new NbtByte("Flight", ((NbtCompound)seznam).Get<NbtByte>("Flight").Value));

                                    if (((NbtCompound)seznam).Get<NbtList>("Explosions") != null)
                                    {
                                        NbtList exploze = new NbtList("Explosions");
                                        foreach (NbtCompound comp in ((NbtCompound)seznam).Get<NbtList>("Explosions"))
                                        {
                                            NbtCompound newComp = new NbtCompound();

                                            foreach (NbtTag hodnoty in comp)
                                            {
                                                if (hodnoty.Name == "Trail")
                                                    newComp.Add(new NbtByte("Trail", ((NbtByte)hodnoty).Value));
                                                else if (hodnoty.Name == "Type")
                                                    newComp.Add(new NbtByte("Type", ((NbtByte)hodnoty).Value));
                                                else if (hodnoty.Name == "Flicker")
                                                    newComp.Add(new NbtByte("Flicker", ((NbtByte)hodnoty).Value));
                                                else if (hodnoty.Name == "Colors")
                                                    newComp.Add(new NbtIntArray("Colors", ((NbtIntArray)hodnoty).Value));
                                                else if (hodnoty.Name == "FadeColors")
                                                    newComp.Add(new NbtIntArray("FadeColors", ((NbtIntArray)hodnoty).Value));
                                            }
                                            exploze.Add(newComp);
                                        }
                                        fire.Add(exploze);
                                    }

                                    tag.Add(fire);
                                }
                            }

                            kopirovanyItem.Add(tag);

                        }
                        break;
                    }
                }
                if(kopirovanyItem != null)
                    vlozitBtn.Enabled = true;
            }
        }

        public void Vlozit()
        {
            if (!Prepnuto)
            {
                if (kopirovanyItem != null)
                {
                    NeulozenoMetoda();

                    //short id = kopirovanyItem.Get<NbtShort>("id").Value;

                    short id = -1;
                    if (kopirovanyItem.Get("id").TagType == NbtTagType.Short)
                        id = kopirovanyItem.Get<NbtShort>("id").Value;
                    else
                    {
                        string sid = kopirovanyItem.Get<NbtString>("id").Value;

                        foreach (Item i in itemList)
                        {
                            if (i.StringID == sid)
                            {
                                id = (short)i.ID;
                                break;
                            }
                        }
                    }
                    if (VybraneTL == 100 && !povoleneBoty.Contains(id))
                    {
                        MessageBox.Show(Jazyk.Strings.Item_nelze_vlozit, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (VybraneTL == 101 && !povoleneKalhoty.Contains(id))
                    {
                        MessageBox.Show(Jazyk.Strings.Item_nelze_vlozit, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (VybraneTL == 102 && !povoleneTelo.Contains(id))
                    {
                        MessageBox.Show(Jazyk.Strings.Item_nelze_vlozit, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (VybraneTL == 103 && !povoleneHelma.Contains(id))
                    {
                        MessageBox.Show(Jazyk.Strings.Item_nelze_vlozit, "SaveEdit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        kopirovanyItem.Get<NbtByte>("Slot").Value = (byte)VybraneTL;
                        int i = 0;

                        foreach (NbtCompound c in save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory"))
                        {
                            if (c.Get<NbtByte>("Slot").Value == VybraneTL)
                            {
                                break;
                            }
                            i++;
                        }
                        try
                        {
                            save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").RemoveAt(i);
                        }
                        catch {  }
                        save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Add(kopirovanyItem);
                        NactiObrazky(false, kopirovanyItem.Get<NbtByte>("Count").Value.ToString());
                        InventarVyber();
                        vlozitBtn.Enabled = false;
                        Kopirovat();
                    }
                }
            }

        }

        #endregion

        #region Vlastnosti

        private bool Nacteno
        {
            get;
            set;
        }

        private bool DokoncenoNacitaniBloku
        {
            get;
            set;
        }

        private bool DokoncenoNacitaniBrneni
        {
            get;
            set;
        }

        internal short VybraneTL
        {
            get;
            set;
        }

        private bool Neulozeno
        {
            get;
            set;
        }

        internal bool Prepnuto
        {
            get;
            set;
        }

        internal int Aktivnienchant
        {
            get;
            set;
        }

        private bool NaTlacitku
        {
            get;
            set;
        }

        private bool HledaniZap
        {
            get;
            set;
        }

        public Verze Verze
        {
            get;
            set;
        }

        private bool Nekompatibilita
        {
            get;
            set;
        }

        private bool Helma
        {
            get;
            set;
        }

        private bool Brneni
        {
            get;
            set;
        }

        private bool Kalhoty
        {
            get;
            set;
        }

        private bool Boty
        {
            get;
            set;
        }

        private bool Stit
        {
            get;
            set;
        }

        #endregion

        #region Klávesové zkratky

        private void KlavesovaZkratka(object sender, KeyEventArgs e)
        {
            e.SuppressKeyPress = false;
            //nastavení verze
            if(e.KeyCode == Keys.V && e.Modifiers == (Keys.Control | Keys.Shift))
            {
                VerzeNast ver = new VerzeNast();
                ver.Show();
            }

            //uložení
            if(e.KeyCode == Keys.S && e.Modifiers == Keys.Control)
            {
                if(Nacteno)
                    Ulozit();
            }

            //otevřít
            if (e.KeyCode == Keys.O && e.Modifiers == Keys.Control)
            {
                otevritDial.ShowDialog();
            }

            //přidat vlastní item
            if (e.KeyCode == Keys.N && e.Modifiers == Keys.Control)
            {
                if (!novyItemOtevreno)
                {
                    novyItemOtevreno = true;
                    NovyItem ni = new NovyItem();
                    ni.Show();
                    ni.FormClosed += new FormClosedEventHandler(ni_FormClosed);
                }
                else
                    MessageBox.Show(Jazyk.Strings.Novy_item_otevreno);
            }

            //refresh
            if (e.KeyCode == Keys.R && e.Modifiers == Keys.Control)
            {
                if (Nacteno && DokoncenoNacitaniBloku)
                {
                    HledaniZap = false;
                    seznamBlocku.Focus();
                    vyhledavani.Text = Jazyk.Strings.Hledej;
                    vyhledavani.ForeColor = Color.Gray;
                    vyhledavani.Font = new Font(vyhledavani.Font, FontStyle.Italic);
                    HledaniZap = true;
                    backgroundWorker4.RunWorkerAsync();
                }
            }

            //kopírovat
            if (e.KeyCode == Keys.C && e.Modifiers == Keys.Control)
            {
                Kopirovat();
            }

            //vložit
            if (e.KeyCode == Keys.V && e.Modifiers == Keys.Control)
            {
                Vlozit();
            }

            //vymazat item
            if (e.KeyCode == Keys.Delete)
                VyhoditItem(VybraneTL);

            //zobrazení tlačítka jazyků (odstraní se s příchodem finální verze jazyků)
            if (e.KeyCode == Keys.J && e.Modifiers == (Keys.Control | Keys.Shift))
            {
                jazykToolStripMenuItem.Visible = true;
            }

            //vytvoření testovacího souboru jazyka
            if (e.KeyCode == Keys.T && e.Modifiers == (Keys.Control | Keys.Shift))
            {
                Jazyk.Serializace s = new Jazyk.Serializace();
                Jazyk.Ostatni o = new Jazyk.Ostatni();
                o.Zacni_otevrenim_ulozene_pozice = "Test načítání jazyka ze souboru";
                o.Hledej = "Hledání test";
                o.VerzeJazyka = "0.0.1";
                o.NazevJazyka = "Testovací čeština";
                s.Ulozit("Test", o);
            }

            //shození programu a otestování chybového hlášení
            if (e.KeyCode == Keys.E && e.Modifiers == (Keys.Control | Keys.Shift))
            {
                throw new Exception("test chyba");
            }

            //test okna na úpravu jazyka
            if (e.KeyCode == Keys.L && e.Modifiers == (Keys.Control | Keys.Shift))
            {
                Jazyk.Preklad p = new Jazyk.Preklad();
                p.Show();
            }
        }

        #endregion

    }
}
