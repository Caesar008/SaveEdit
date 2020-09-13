using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fNbt;
using System.Drawing;

namespace SaveEdit
{
    class Item
    {
        Form1 form;
        string _id;

        public Item(string name, string id, int damage, int maxDamage, byte stack, byte count, byte slot, NbtCompound tag, string[] kategorie, byte[] povoleneSloty, Bitmap image, Form1 form, bool canChangeColor, bool banner, bool firework, bool vlastnosti, List<string> mandatory, string imageInfo = null)
        {
            Name = name;
            ID = id;
            Damage = damage;
            Stack = stack;
            Count = count;
            Slot = slot;
            Tag = tag;
            this.form = form;
            ZmenaBarev = canChangeColor;
            Banner = banner;
            Firework = firework;

            NbtCompound item = new NbtCompound();
            item.Add(new NbtString("id", id));
            item.Add(new NbtByte("Count", count));
            item.Add(new NbtByte("Slot", slot));
            if (tag != null)
                item.Add(new NbtCompound(tag));
            if (damage != -1)
            {
                if (item.Get<NbtCompound>("tag") == null)
                    item.Add(new NbtCompound("tag"));
                if (item.Get<NbtCompound>("tag").Get<NbtInt>("Damage") == null)
                    item.Get<NbtCompound>("tag").Add(new NbtInt("Damage", damage));
                else
                    item.Get<NbtCompound>("tag").Get<NbtInt>("Damage").Value = damage;

            }

            NbtItem = item;
            Kategorie = kategorie;
            Image = image;
            PovoleneSloty = povoleneSloty;
            MaxDamage = maxDamage;
            Vlastnosti = vlastnosti;
            Mandatory = mandatory;
            ImageInfo = imageInfo;
        }

        public Item(NbtCompound item, Form1 form)
        {
            NbtItem = item;
            this.form = form;
            if (item.Get<NbtCompound>("tag") != null)
            {
                Tag = item.Get<NbtCompound>("tag");
                if (item.Get<NbtCompound>("tag").Get<NbtInt>("Damage") != null)
                    Damage = item.Get<NbtCompound>("tag").Get<NbtInt>("Damage").Value;

            }
            Slot = item.Get<NbtByte>("Slot").Value;
            ID = item.Get<NbtString>("id").Value;
            Count = item.Get<NbtByte>("Count").Value;

            Item tmp = GetItemProperties(item, form);
            if (tmp != null)
            {
                Image = tmp.Image;
                MaxDamage = tmp.MaxDamage;
                Stack = tmp.Stack;
                Kategorie = tmp.Kategorie;
                PovoleneSloty = tmp.PovoleneSloty;
                Image = tmp.Image;
                Name = tmp.Name;
                ZmenaBarev = tmp.ZmenaBarev;
                Vlastnosti = tmp.Vlastnosti;
                Mandatory = tmp.Mandatory;
                ImageInfo = tmp.ImageInfo;
                Banner = tmp.Banner;
                Firework = tmp.Firework;
            }
            else
            {
                Log.Write("Next item is unknown", Log.Verbosity.Info);
                Image = Properties.Resources.unknown;
                Unknown = true;
            }
        }

        private Item GetItemProperties(NbtCompound item, Form1 form)
        {
            foreach (System.Windows.Forms.ListViewItem lvi in form.seznamBlocku.Items)
            {
                if (((Tag)lvi.Tag).Item.ID == item.Get<NbtString>("id").Value && (((Tag)lvi.Tag).Item.Mandatory == null || ((Tag)lvi.Tag).Item.Mandatory.Count == 0))
                {
                    int damage = -1;
                    NbtCompound tag = null;
                    if (item.Get<NbtCompound>("tag") != null)
                    {
                        tag = item.Get<NbtCompound>("tag");
                        if (item.Get<NbtCompound>("tag").Get<NbtInt>("Damage") != null)
                            damage = item.Get<NbtCompound>("tag").Get<NbtInt>("Damage").Value;
                    }
                    return new Item(((Tag)lvi.Tag).Item.Name, ((Tag)lvi.Tag).Item.ID, damage, ((Tag)lvi.Tag).Item.MaxDamage, ((Tag)lvi.Tag).Item.Stack, item.Get<NbtByte>("Count").Value, item.Get<NbtByte>("Slot").Value, tag, ((Tag)lvi.Tag).Item.Kategorie, ((Tag)lvi.Tag).Item.PovoleneSloty, ((Tag)lvi.Tag).Item.Image, form, ((Tag)lvi.Tag).Item.ZmenaBarev, ((Tag)lvi.Tag).Item.Banner, ((Tag)lvi.Tag).Item.Firework, ((Tag)lvi.Tag).Item.Vlastnosti, ((Tag)lvi.Tag).Item.Mandatory);
                }
                else if (((Tag)lvi.Tag).Item.ID == item.Get<NbtString>("id").Value)
                {
                    foreach(string s in ((Tag)lvi.Tag).Item.Mandatory)
                    {
                        if (item.Get<NbtCompound>("tag") != null && item.Get<NbtCompound>("tag").Get<NbtString>(s.Split(';')[0]) != null && item.Get<NbtCompound>("tag").Get<NbtString>(s.Split(';')[0]).Value == s.Split(';')[1])
                        {
                            int damage = -1;
                            NbtCompound tag = null;
                            if (item.Get<NbtCompound>("tag") != null)
                            {
                                tag = item.Get<NbtCompound>("tag");
                                if (item.Get<NbtCompound>("tag").Get<NbtInt>("Damage") != null)
                                    damage = item.Get<NbtCompound>("tag").Get<NbtInt>("Damage").Value;
                            }
                            return new Item(((Tag)lvi.Tag).Item.Name, ((Tag)lvi.Tag).Item.ID, damage, ((Tag)lvi.Tag).Item.MaxDamage, ((Tag)lvi.Tag).Item.Stack, item.Get<NbtByte>("Count").Value, item.Get<NbtByte>("Slot").Value, tag, ((Tag)lvi.Tag).Item.Kategorie, ((Tag)lvi.Tag).Item.PovoleneSloty, ((Tag)lvi.Tag).Item.Image, form, ((Tag)lvi.Tag).Item.ZmenaBarev, ((Tag)lvi.Tag).Item.Banner, ((Tag)lvi.Tag).Item.Firework, ((Tag)lvi.Tag).Item.Vlastnosti, ((Tag)lvi.Tag).Item.Mandatory);
                        }
                        /*else
                            return null;*/
                    }
                }
            }
            return null;
        }


        public void ChangeItemEditor(string name, string id, int maxDamage, byte stack, string imageInfo, string[] kategorie, byte[] povoleneSloty, bool canChangeColor, bool banner, bool firework, NbtCompound tag, List<string> mandatory, bool vlastnosti, Bitmap image, List<VerzeID> verzeID)
        {
            Name = name;
            ID = id;
            MaxDamage = maxDamage;
            Stack = stack;
            ImageInfo = imageInfo;
            Kategorie = kategorie;
            PovoleneSloty = povoleneSloty;
            ZmenaBarev = canChangeColor;
            Banner = banner;
            Firework = firework;
            Tag = tag;
            Mandatory = mandatory;
            Vlastnosti = vlastnosti;
            Image = image;
            Verze = verzeID;
        }

        public void ChangeSlot(byte newSlot)
        {
            Slot = newSlot;
            NbtItem.Get<NbtByte>("Slot").Value = newSlot;
        }

        public void ChangeDamage(short newDmg)
        {
            Damage = newDmg;
            if (NbtItem.Get<NbtCompound>("tag") == null)
                NbtItem.Add(new NbtCompound("tag"));
            if (NbtItem.Get<NbtCompound>("tag").Get<NbtShort>("Damage") == null)
                NbtItem.Get<NbtCompound>("tag").Add(new NbtInt("Damage", 0));
            NbtItem.Get<NbtCompound>("tag").Get<NbtInt>("Damage").Value = newDmg;
        }

        public void ChangeCount(byte newCount)
        {
            Count = newCount;
            NbtItem.Get<NbtByte>("Count").Value = newCount;
        }

        public string Name
        {
            get;
            private set;
        }

        public string ID
        {
            get
            {
                try
                {
                    if (form.saveVerze >= form.mcVerze)
                        return _id;
                    else
                    {
                        if (Verze != null)
                        {
                            foreach (VerzeID vid in Verze)
                            {
                                if (vid.JeMezi(form.saveVerze))
                                {
                                    return vid.ID;
                                }
                            }
                        }
                        return _id;
                    }
                }
                catch
                {
                    return _id;
                }
            }
            private set { _id = value; }
        }

        public int Damage
        {
            get;
            private set;
        }

        public int MaxDamage
        {
            get;
            private set;
        }

        public byte Stack
        {
            get;
            private set;
        }

        public byte Count
        {
            get;
            private set;
        }

        public byte Slot
        {
            get;
            private set;
        }

        public NbtCompound Tag
        {
            get;
            private set;
        }

        public NbtCompound NbtItem
        {
            get;
            private set;
        }

        public string[] Kategorie
        {
            get;
            private set;
        }

        public byte[] PovoleneSloty
        {
            get;
            private set;
        }

        public Bitmap Image
        {
            get;
            private set;
        }

        public bool ZmenaBarev
        {
            get;
            private set;
        }

        public bool Banner
        {
            get;
            private set;
        }

        public bool Firework
        {
            get;
            private set;
        }

        public List<VerzeID> Verze
        {
            get;
            private set;
        }

        public bool Vlastnosti
        {
            get;
            private set;
        }

        public List<string> Mandatory
        {
            get;
            private set;
        }

        public bool Unknown
        {
            get;
            private set;
        }

        public string ImageInfo
        {
            get;
            private set;
        }

        public void AddVerze(int minVerze, int maxVerze, string id)
        {
            if (Verze == null)
                Verze = new List<VerzeID>{new VerzeID(minVerze, maxVerze, id)};
            else
                Verze.Add(new VerzeID(minVerze, maxVerze, id));

        }

    }

    class VerzeID
    {
        public VerzeID(int minVerze, int maxVerze, string id)
        {
            MinVerze = minVerze;
            MaxVerze = maxVerze;
            ID = id;
        }

        public int MinVerze { get;  private set; }
        public int MaxVerze { get;  private set; }
        public string ID { get; private set; }

        public bool JeMezi(int verze)
        {
            if (verze >= MinVerze && verze < MaxVerze)
                return true;
            return false;
        }
    }
}
