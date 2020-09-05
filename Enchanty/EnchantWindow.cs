using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibNbt;

namespace SaveEdit
{
    public partial class EnchantWindow : Form
    {
        Form1 form;
        List<short> pridane = new List<short>();
        public EnchantWindow(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            GetEnchant();
        }

        void GetEnchant()
        {
            int i = 0;
            foreach (NbtCompound c in form.inventarList)
            {
                if (c.Get<NbtByte>("Slot").Value == form.VybraneTL)
                {
                    i = form.inventarList.IndexOf(c);
                    break;
                }
            }

            pridane.Clear();
            enchanty.Items.Clear();
            enchantView.Items.Clear();

            try
            {
                if (form.varianta != 5)
                {
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                        foreach (NbtCompound s in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench"))
                        {
                            ListViewItem lvi = new ListViewItem(new string[] { Enchanty.GetEnchant(s.Get<NbtShort>("id").Value, form.enchantyList).Jmeno, s.Get<NbtShort>("lvl").Value.ToString() });
                            enchantView.Items.Add(lvi);
                            pridane.Add(s.Get<NbtShort>("id").Value);
                        }
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments") != null)
                        foreach (NbtCompound s in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments"))
                        {
                            ListViewItem lvi = new ListViewItem(new string[] { Enchanty.GetEnchant(s.Get<NbtShort>("id").Value, form.enchantyList).Jmeno, s.Get<NbtShort>("lvl").Value.ToString() });
                            enchantView.Items.Add(lvi);
                            pridane.Add(s.Get<NbtShort>("id").Value);
                        }
                }
                else
                {
                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                        foreach (NbtCompound s in form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench"))
                        {
                            ListViewItem lvi = new ListViewItem(new string[] { Enchanty.GetEnchant(s.Get<NbtShort>("id").Value, form.enchantyList).Jmeno, s.Get<NbtShort>("lvl").Value.ToString() });
                            enchantView.Items.Add(lvi);
                            pridane.Add(s.Get<NbtShort>("id").Value);
                        }
                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments") != null)
                        foreach (NbtCompound s in form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("StoredEnchantments"))
                        {
                            ListViewItem lvi = new ListViewItem(new string[] { Enchanty.GetEnchant(s.Get<NbtShort>("id").Value, form.enchantyList).Jmeno, s.Get<NbtShort>("lvl").Value.ToString() });
                            enchantView.Items.Add(lvi);
                            pridane.Add(s.Get<NbtShort>("id").Value);
                        }
                }
            }
            catch{ }

            //přidat jen ty, co nejsou přidané
            foreach (string s in form.enchanty)
            {
                form.Prepnuto = true;

                if (!pridane.Contains(Enchanty.GetId(s, form.enchantyList)))
                    enchanty.Items.Add(s);

                form.Prepnuto = false;
            }
            if(enchanty.Items.Count > 0)
                enchanty.SelectedIndex = 0;

            if (enchantView.Items.Count != 0 && enchantView.SelectedIndices.Count != 0)
                enchLevel.Enabled = true;
            else
                enchLevel.Enabled = false;

            if (enchanty.Items.Count == 0)
                enchanty.Text = "";
        }

        private void pridat_Click(object sender, EventArgs e)
        {
            form.Prepnuto = true;
            foreach (NbtCompound c in form.inventarList)
            {
                if (c.Get<NbtByte>("Slot").Value == form.VybraneTL)
                {
                    
                    int i = form.inventarList.IndexOf(c);
                    short selectedItem = (short)Enchanty.GetId((string)enchanty.SelectedItem, form.enchantyList);
                    string enchTag = "ench";

                    if (selectedItem != -1)
                    {
                        form.NeulozenoMetoda();
                        //přidání enchantu
                        try
                        {
                            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench") == null)
                                enchTag = "StoredEnchantments";

                            if (form.varianta != 5)
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).ListType != NbtTagType.Compound)
                                {
                                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Remove(enchTag);
                                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtList(enchTag, NbtTagType.Compound));

                                }
                                int aktivniEnchant = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Count;

                                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Add(new NbtCompound(""));
                                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(aktivniEnchant).Add(new NbtShort("id", 0));
                                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(aktivniEnchant).Add(new NbtShort("lvl", 1));
                                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(aktivniEnchant).Get<NbtShort>("id").Value = (short)Enchanty.GetId((string)enchanty.SelectedItem, form.enchantyList);
                            }
                            else
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).ListType != NbtTagType.Compound)
                                {
                                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Remove(enchTag);
                                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(new NbtList(enchTag, NbtTagType.Compound));
                                }
                                int aktivniEnchant = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Count;

                                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Add(new NbtCompound(""));
                                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(aktivniEnchant).Add(new NbtShort("id", 0));
                                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(aktivniEnchant).Add(new NbtShort("lvl", 1));
                                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(aktivniEnchant).Get<NbtShort>("id").Value = (short)Enchanty.GetId((string)enchanty.SelectedItem, form.enchantyList);
                            }

                            if (c.Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(0).Get<NbtShort>("id") != null)

                                ((Button)form.Controls["i" + form.VybraneTL]).Image = form.EnchantLabel((Bitmap)((Button)form.Controls["i" + form.VybraneTL]).Image);
                            form.Controls["i" + form.VybraneTL].Refresh();
                        }
                        catch
                        {
                            //přidání enchantu, když tam žádnej neni
                            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get("id").TagType == NbtTagType.Short)
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtShort>("id").Value == 403)
                                    enchTag = "StoredEnchantments";
                            }
                            else
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtString>("id").Value == "minecraft:enchanted_book")
                                    enchTag = "StoredEnchantments";

                            NbtCompound comp = new NbtCompound("");
                            NbtCompound tag = new NbtCompound("tag");
                            NbtList ench = new NbtList(enchTag, NbtTagType.Compound);
                            NbtShort id = new NbtShort("id", 0);
                            NbtShort lvl = new NbtShort("lvl", 1);
                            comp.Add(id);
                            comp.Add(lvl);
                            ench.Add(comp);
                            

                            if (form.varianta != 5)
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag") != null)
                                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(ench);
                                else
                                {
                                    tag.Add(ench);
                                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Add(tag);
                                }

                                int aktivniEnchant = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Count - 1;

                                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(aktivniEnchant).Get<NbtShort>("id").Value = (short)Enchanty.GetId((string)enchanty.SelectedItem, form.enchantyList);
                            }
                            else
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag") != null)
                                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Add(ench);
                                else
                                {
                                    tag.Add(ench);
                                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Add(tag);
                                }

                                int aktivniEnchant = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Count - 1;

                                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(aktivniEnchant).Get<NbtShort>("id").Value = (short)Enchanty.GetId((string)enchanty.SelectedItem, form.enchantyList);
                            }

                            if (c.Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(0).Get<NbtShort>("id") != null)

                                ((Button)form.Controls["i" + form.VybraneTL]).Image = form.EnchantLabel((Bitmap)((Button)form.Controls["i" + form.VybraneTL]).Image);
                            form.Controls["i" + form.VybraneTL].Refresh();

                        }
                        enchLevel.Minimum = 1;
                        enchLevel.Value = 1;
                        GetEnchant();
                        break;
                    }
                }
            }
            form.Prepnuto = false;
        }

        private void smazat_Click(object sender, EventArgs e)
        {
            foreach (NbtCompound c in form.inventarList)
            {
                if (c.Get<NbtByte>("Slot").Value == form.VybraneTL)
                {
                    form.NeulozenoMetoda();
                    //odstranění enchantu
                    int i = form.inventarList.IndexOf(c);
                    int selected = 0;
                    string enchTag = "ench";

                    if (enchantView.SelectedIndices.Count > 0)
                        selected = enchantView.SelectedIndices[0];

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                    {
                        if (selected > form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench").Count - 1)
                        {
                            selected -= form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench").Count;
                            enchTag = "StoredEnchantments";
                        }
                    }
                    else
                        enchTag = "StoredEnchantments";
                    if (form.varianta != 5)
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).RemoveAt(selected);
                    }
                    else
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).RemoveAt(selected);
                    GetEnchant();


                    if (c.Get<NbtCompound>("tag").Get<NbtList>("ench") != null && c.Get<NbtCompound>("tag").Get<NbtList>("ench").Count == 0)
                    {
                        form.NactiObrazky(false, c.Get<NbtByte>("Count").Value.ToString());
                        form.Controls["i" + form.VybraneTL].Refresh();
                    }
                    break;
                }
            }
            smazat.Enabled = false;
        }

        private void enchLevel_ValueChanged(object sender, EventArgs e)
        {
            ZmenHodnotu();
        }

        private void ZmenHodnotu(bool select = true, int subitem = -1)
        {
            if (!form.Prepnuto)
            {
                int selected = 0;
                string enchTag = "ench";

                if (enchantView.SelectedIndices.Count > 0)
                    selected = enchantView.SelectedIndices[0];
                if (subitem >= 0)
                    selected = subitem;

                foreach (NbtCompound c in form.inventarList)
                {
                    form.NeulozenoMetoda();
                    if (c.Get<NbtByte>("Slot").Value == form.VybraneTL)
                    {
                        int i = form.inventarList.IndexOf(c);

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench") != null)
                        {
                            if (selected > form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench").Count - 1)
                            {
                                selected -= form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>("ench").Count;
                                enchTag = "StoredEnchantments";
                            }
                        }
                        else
                            enchTag = "StoredEnchantments";
                        
                        if (form.varianta != 5)
                        {

                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(selected).Get<NbtShort>("lvl").Value = (short)enchLevel.Value;
                        }
                        else
                        {
                            form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(i).Get<NbtCompound>("tag").Get<NbtList>(enchTag).Get<NbtCompound>(selected).Get<NbtShort>("lvl").Value = (short)enchLevel.Value;
                        }
                        break;
                    }
                }
                GetEnchant();
                if (select)
                {
                    enchantView.Select();
                    enchantView.Items[selected].Selected = true;
                }
            }
        }

        private void enchantView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!form.Prepnuto)
            {
                form.Prepnuto = true;
                bool zmeneno = false;

                int selected = 0;

                if (enchantView.SelectedIndices.Count > 0)
                {
                    selected = enchantView.SelectedIndices[0];
                    smazat.Enabled = true;
                }
                else
                    smazat.Enabled = false;

                //nastavení maximálního levelu podle zaškrtávátka
                if (limiter.Checked)
                {
                    enchLevel.Maximum = short.MaxValue;
                }
                else
                {
                    int lvl = Enchanty.GetEnchant(Enchanty.GetId(enchantView.Items[selected].SubItems[0].Text, form.enchantyList), form.enchantyList).MaxLevel;
                    
                    if (int.Parse(enchantView.Items[selected].SubItems[1].Text) > lvl)
                    {
                        if (enchLevel.Maximum < lvl)
                            enchLevel.Maximum = lvl;
                        form.Prepnuto = false;
                        enchLevel.Value = lvl;
                        ZmenHodnotu(false);
                        zmeneno = true;
                        form.Prepnuto = true;
                        enchantView.Focus();
                        this.Focus();
                        enchantView.Items[selected].Selected = true;
                        enchantView.Select();
                    }
                    enchLevel.Maximum = lvl;
                }

                //nastavení levelu v měňátku
                if (!zmeneno)
                    enchLevel.Value = decimal.Parse(enchantView.Items[selected].SubItems[1].Text);

                if (enchantView.SelectedIndices.Count != 0)
                    enchLevel.Enabled = true;
                else
                    enchLevel.Enabled = false;

                form.Prepnuto = false;
            }
        }

        private void limiter_CheckedChanged(object sender, EventArgs e)
        {
            int selectedIndex = 0;
            if (enchantView.SelectedIndices.Count > 0)
            {
                selectedIndex = enchantView.SelectedIndices[0];
            }
            if (limiter.Checked)
            {
                enchLevel.Maximum = short.MaxValue;
            }
            else
            {
                int id = 0;
                foreach (ListViewItem sub in enchantView.Items)
                {
                    int lvl = Enchanty.GetEnchant(Enchanty.GetId(sub.SubItems[0].Text, form.enchantyList), form.enchantyList).MaxLevel;
                    if (short.Parse(sub.SubItems[1].Text) > lvl)
                    {
                        sub.SubItems[1].Text = lvl.ToString();
                        form.Prepnuto = true;
                        enchLevel.Value = lvl;
                        form.Prepnuto = false;
                        ZmenHodnotu(false, id);
                    }
                    id++;
                }

                if (enchantView.SelectedItems.Count > 0)
                {
                    int lvl2 = Enchanty.GetEnchant(Enchanty.GetId(enchantView.Items[selectedIndex].SubItems[0].Text, form.enchantyList), form.enchantyList).MaxLevel;
                    if (enchLevel.Value > lvl2)
                    {
                        enchLevel.Value = lvl2;
                    }
                }
            }
        }
    }
}
