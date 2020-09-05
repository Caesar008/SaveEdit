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
        private void barvyView_DoubleClick(object sender, EventArgs e)
        {
            colorDialog1.Color = barvyView.Items[barvyView.SelectedIndices[0]].BackColor;
            DialogResult diag = colorDialog1.ShowDialog();
            if (diag == DialogResult.OK)
            {
                form.NeulozenoMetoda();

                barvyView.Items[barvyView.SelectedIndices[0]].BackColor = colorDialog1.Color;

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

                if (form.varianta != 5 && form.jednaBarva.Contains(id))
                {
                    barva = colorDialog1.Color.ToArgb();
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtInt>("color").Value = barva;
                }
                else if (form.jednaBarva.Contains(id))
                {
                    barva = colorDialog1.Color.ToArgb();
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtInt>("color").Value = barva;
                }
                else if (form.varianta != 5)
                {
                    barvy[barvyView.SelectedIndices[0]] = colorDialog1.Color.ToArgb();
                    if(!form.explosions.Contains(id))
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors").IntArrayValue.SetValue(colorDialog1.Color.ToArgb(), barvyView.SelectedIndices[0]);
                    else
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors").IntArrayValue.SetValue(colorDialog1.Color.ToArgb(), barvyView.SelectedIndices[0]);
                }
                else
                {
                    barvy[barvyView.SelectedIndices[0]] = colorDialog1.Color.ToArgb();
                    if (!form.explosions.Contains(id))
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors").IntArrayValue.SetValue(colorDialog1.Color.ToArgb(), barvyView.SelectedIndices[0]);
                    else
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors").IntArrayValue.SetValue(colorDialog1.Color.ToArgb(), barvyView.SelectedIndices[0]);
                }
            }
        }

        private void barvyView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (barvyView.SelectedItems.Count == 0)
                zrusitBarvu.Enabled = false;
            else
            {
                zrusitBarvu.Enabled = true;
                if(prechodyView.SelectedItems.Count > 0)
                    prechodyView.SelectedItems[0].Selected = false;
            }
        }

        private void pridatBarvu_Click(object sender, EventArgs e)
        {
            DialogResult diag = colorDialog1.ShowDialog();
            if (diag == DialogResult.OK)
            {
                form.NeulozenoMetoda();

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

                if (form.varianta != 5 && form.jednaBarva.Contains(id))
                {
                    barva = colorDialog1.Color.ToArgb();
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("display"));
                    if(form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtInt>("color")== null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Add(new NbtInt("color", barva));

                    else
                    {
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtInt>("color").Value = barva;
                    }
                    barvyView.Items.Add(new ListViewItem(""));
                    barvyView.Items[0].BackColor = Color.FromArgb(barva);
                    barvyView.Enabled = true;
                    pridatBarvu.Enabled = false;
                }
                else if (form.jednaBarva.Contains(id))
                {
                    barva = colorDialog1.Color.ToArgb();

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("display"));
                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtInt>("color") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Add(new NbtInt("color", barva));

                    else
                    {
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtInt>("color").Value = barva;
                    }

                    barvyView.Items.Add(new ListViewItem(""));
                    barvyView.Items[0].BackColor = Color.FromArgb(barva);
                    barvyView.Enabled = true;
                    pridatBarvu.Enabled = false;
                }
                //firework star
                else if (form.varianta != 5 && !form.explosions.Contains(id))
                {
                    barvy.Add(colorDialog1.Color.ToArgb());

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Explosion"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Add(new NbtIntArray("Colors"));

                    barvyView.Items.Clear();
                    int[] array = new int[barvy.Count];
                    for (int i = 0; i < barvy.Count; i++)
                    {
                        array[i] = barvy[i];

                        barvyView.Items.Add(new ListViewItem(""));
                        barvyView.Items[i].BackColor = Color.FromArgb(barvy[i]);
                    }

                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors").Value = array;
                    barvyView.Enabled = true;
                }

                    //firework
                else if (form.varianta != 5)
                {
                    barvy.Add(colorDialog1.Color.ToArgb());

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Fireworks"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Add(new NbtList("Explosions"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch) == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Add(new NbtCompound());

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Add(new NbtIntArray("Colors"));

                    barvyView.Items.Clear();
                    int[] array = new int[barvy.Count];
                    for (int i = 0; i < barvy.Count; i++)
                    {
                        array[i] = barvy[i];

                        barvyView.Items.Add(new ListViewItem(""));
                        barvyView.Items[i].BackColor = Color.FromArgb(barvy[i]);
                    }

                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors").Value = array;
                    barvyView.Enabled = true;
                }
                //firework star
                else if (!form.explosions.Contains(form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").IntValue))
                {
                    barvy.Add(colorDialog1.Color.ToArgb());

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Explosion"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Add(new NbtIntArray("Colors"));

                    barvyView.Items.Clear();
                    int[] array = new int[barvy.Count];
                    for (int i = 0; i < barvy.Count; i++)
                    {
                        array[i] = barvy[i];

                        barvyView.Items.Add(new ListViewItem(""));
                        barvyView.Items[i].BackColor = Color.FromArgb(barvy[i]);
                    }

                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors").Value = array;
                    barvyView.Enabled = true;
                }
                //forework
                else
                {
                    barvy.Add(colorDialog1.Color.ToArgb());

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Fireworks"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Add(new NbtList("Explosions"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch) == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Add(new NbtCompound());

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Add(new NbtIntArray("Colors"));

                    barvyView.Items.Clear();
                    int[] array = new int[barvy.Count];
                    for (int i = 0; i < barvy.Count; i++)
                    {
                        array[i] = barvy[i];

                        barvyView.Items.Add(new ListViewItem(""));
                        barvyView.Items[i].BackColor = Color.FromArgb(barvy[i]);
                    }

                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors").Value = array;
                    barvyView.Enabled = true;
                }
            }
        }

        private void zrusitBarvu_Click(object sender, EventArgs e)
        {
            form.NeulozenoMetoda();

            if (form.varianta != 5)
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

                if (form.jednaBarva.Contains(id))
                {
                    barva = -1;
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Remove("color");
                    barvyView.Items.Clear();
                    barvyView.Enabled = false;
                    zrusitBarvu.Enabled = false;

                    if(form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtString>("Name") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Remove("display");
                }
                else if (!form.explosions.Contains(id))
                {
                    barvy.RemoveAt(barvyView.SelectedIndices[0]);
                    int[] array = new int[barvy.Count];
                    barvyView.Items.Clear();

                    for (int i = 0; i < barvy.Count; i++)
                    {
                        array[i] = barvy[i];

                        barvyView.Items.Add(new ListViewItem(""));
                        barvyView.Items[i].BackColor = Color.FromArgb(array[i]);
                    }

                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors").Value = array;
                    if (barvyView.Items.Count == 0 || barvyView.SelectedIndices.Count == 0)
                    zrusitBarvu.Enabled = false;
                
                }
                else
                {
                    barvy.RemoveAt(barvyView.SelectedIndices[0]);
                    int[] array = new int[barvy.Count];
                    barvyView.Items.Clear();

                    for (int i = 0; i < barvy.Count; i++)
                    {
                        array[i] = barvy[i];

                        barvyView.Items.Add(new ListViewItem(""));
                        barvyView.Items[i].BackColor = Color.FromArgb(array[i]);
                    }

                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors").Value = array;
                    if (barvyView.Items.Count == 0 || barvyView.SelectedIndices.Count == 0)
                        zrusitBarvu.Enabled = false;
                }
            }
            else
            {
                if (form.jednaBarva.Contains(form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").IntValue))
                {
                    barva = -1;
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Remove("color");
                    barvyView.Items.Clear();
                    zrusitBarvu.Enabled = false;
                }
                else if (!form.explosions.Contains(form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").IntValue))
                {
                    barvy.RemoveAt(barvyView.SelectedIndices[0]);
                    int[] array = new int[barvy.Count];
                    barvyView.Items.Clear();

                    for (int i = 0; i < barvy.Count; i++)
                    {
                        array[i] = barvy[i];

                        barvyView.Items.Add(new ListViewItem(""));
                        barvyView.Items[i].BackColor = Color.FromArgb(array[i]);
                    }

                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors").Value = array;
                    if (barvyView.Items.Count == 0 || barvyView.SelectedIndices.Count == 0)
                        zrusitBarvu.Enabled = false;
                }
                else
                {
                    barvy.RemoveAt(barvyView.SelectedIndices[0]);
                    int[] array = new int[barvy.Count];
                    barvyView.Items.Clear();

                    for (int i = 0; i < barvy.Count; i++)
                    {
                        array[i] = barvy[i];

                        barvyView.Items.Add(new ListViewItem(""));
                        barvyView.Items[i].BackColor = Color.FromArgb(array[i]);
                    }

                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors").Value = array;
                    if (barvyView.Items.Count == 0 || barvyView.SelectedIndices.Count == 0)
                        zrusitBarvu.Enabled = false;
                }
            }
            if (barvyView.Items.Count == 0)
            {
                barvyView.Enabled = false;
                zrusitBarvu.Enabled = false;
            }
        }
    }
}
