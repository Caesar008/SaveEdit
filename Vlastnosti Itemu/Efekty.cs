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
    public partial class VlastnostiItemu
    {
        private void NastavEfektV5(byte efekt)
        {
            int id = -1;
            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get("id").TagType == NbtTagType.Short)
                id = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").Value;
            else
            {
                string sid = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtString>("id").Value;

                foreach (Item i in form.itemList)
                {
                    if (i.StringID == sid)
                    {
                        id = (short)i.ID;
                        break;
                    }
                }
            }

            if (!form.explosions.Contains(id))
            {
                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion") == null)
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Explosion"));
                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Type") == null)
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Add(new NbtByte("Type"));

                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Type").Value = efekt;
            }
            else
            {
                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type") == null)
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Add(new NbtByte("Type"));

                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type").Value = efekt;
            }
        }

        private void NastavEfekt(byte efekt)
        {
            if (!form.explosions.Contains(form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").Value))
            {
                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion") == null)
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Explosion"));
                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Type") == null)
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Add(new NbtByte("Type"));

                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Type").Value = efekt;
            }
            else
            {
                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type") == null)
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Add(new NbtByte("Type"));

                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type").Value = efekt;
            
            }
        }

        private void NastavEfektV5(byte efekt, string nazev)
        {
            int id = -1;
            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get("id").TagType == NbtTagType.Short)
                id = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").Value;
            else
            {
                string sid = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtString>("id").Value;

                foreach (Item i in form.itemList)
                {
                    if (i.StringID == sid)
                    {
                        id = (short)i.ID;
                        break;
                    }
                }
            }

            if (!form.explosions.Contains(id))
            {
                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion") == null)
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Explosion"));
                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>(nazev) == null)
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Add(new NbtByte(nazev));

                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>(nazev).Value = efekt;
            }
            else
            {
                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>(nazev) == null)
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Add(new NbtByte(nazev));

                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>(nazev).Value = efekt;
            
            }
        }

        private void NastavEfekt(byte efekt, string nazev)
        {
            if (!form.explosions.Contains(form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").Value))
            {
                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion") == null)
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Explosion"));
                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>(nazev) == null)
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Add(new NbtByte(nazev));

                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>(nazev).Value = efekt;
            }
            else
            {
                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>(nazev) == null)
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Add(new NbtByte(nazev));

                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>(nazev).Value = efekt;
            
            }
        }

        private void malaKoule_CheckedChanged(object sender, EventArgs e)
        {
            if (!form.Prepnuto)
            {
                form.NeulozenoMetoda();

                if (form.varianta != 5)
                {
                    if (malaKoule.Checked)
                        NastavEfektV5(0);
                }
                else
                {
                    if (malaKoule.Checked)
                        NastavEfekt(0);
                }
            }
        }

        private void velkaKoule_CheckedChanged(object sender, EventArgs e)
        {
            if (!form.Prepnuto)
            {
                form.NeulozenoMetoda();

                if (form.varianta != 5)
                {
                    if (velkaKoule.Checked)
                        NastavEfektV5(1);
                }
                else
                {
                    if (velkaKoule.Checked)
                        NastavEfekt(1);
                }
            }
        }

        private void hvezda_CheckedChanged(object sender, EventArgs e)
        {
            if (!form.Prepnuto)
            {
                form.NeulozenoMetoda();

                if (form.varianta != 5)
                {
                    if (hvezda.Checked)
                        NastavEfektV5(2);
                }
                else
                {
                    if (hvezda.Checked)
                        NastavEfekt(2);
                }
            }
        }

        private void hlavaCreeprera_CheckedChanged(object sender, EventArgs e)
        {
            if (!form.Prepnuto)
            {
                form.NeulozenoMetoda();

                if (form.varianta != 5)
                {
                    if (hlavaCreepera.Checked)
                        NastavEfektV5(3);
                }
                else
                {
                    if (hlavaCreepera.Checked)
                        NastavEfekt(3);
                }
            }
        }

        private void rozprsknuti_CheckedChanged(object sender, EventArgs e)
        {
            if (!form.Prepnuto)
            {
                form.NeulozenoMetoda();

                if (form.varianta != 5)
                {
                    if (rozprsknuti.Checked)
                        NastavEfektV5(4);
                }
                else
                {
                    if (rozprsknuti.Checked)
                        NastavEfekt(4);
                }
            }
        }

        private void trail_CheckedChanged(object sender, EventArgs e)
        {

            if (!form.Prepnuto)
            {
                form.NeulozenoMetoda();

                if (form.varianta != 5)
                {
                    if (trail.Checked)
                        NastavEfektV5(1, "Trail");
                    else
                        NastavEfektV5(0, "Trail");
                }
                else
                {
                    if (trail.Checked)
                        NastavEfekt(1, "Trail");
                    else
                        NastavEfekt(0, "Trail");
                }
            }
        }

        private void flicker_CheckedChanged(object sender, EventArgs e)
        {
            if (!form.Prepnuto)
            {
                form.NeulozenoMetoda();

                if (form.varianta != 5)
                {
                    if (flicker.Checked)
                        NastavEfektV5(1, "Flicker");
                    else
                        NastavEfektV5(0, "Flicker");
                }
                else
                {
                    if (flicker.Checked)
                        NastavEfekt(1, "Flicker");
                    else
                        NastavEfekt(0, "Flicker");
                }
            }
        }

        private void dolet_ValueChanged(object sender, EventArgs e)
        {
            if (!form.Prepnuto)
            {
                form.NeulozenoMetoda();

                if (form.varianta != 5)
                {
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Fireworks"));
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Add(new NbtByte("Flight"));

                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight").Value = (byte)dolet.Value;
                }
                else
                {
                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Fireworks"));
                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Add(new NbtByte("Flight"));

                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight").Value = (byte)dolet.Value;
                
                }
            }
        }
    }
}
