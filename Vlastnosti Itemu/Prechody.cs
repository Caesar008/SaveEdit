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
        private void prechodyView_DoubleClick(object sender, EventArgs e)
        {
            colorDialog1.Color = prechodyView.Items[prechodyView.SelectedIndices[0]].BackColor;
            DialogResult diag = colorDialog1.ShowDialog();
            if (diag == DialogResult.OK)
            {
                form.NeulozenoMetoda();

                prechodyView.Items[prechodyView.SelectedIndices[0]].BackColor = colorDialog1.Color;

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

                if (form.varianta != 5 && form.viceBarev.Contains(id))
                {
                    prechody[prechodyView.SelectedIndices[0]] = colorDialog1.Color.ToArgb();
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors").IntArrayValue.SetValue(colorDialog1.Color.ToArgb(), prechodyView.SelectedIndices[0]);
                }
                else if (form.viceBarev.Contains(form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").IntValue))
                {
                    prechody[prechodyView.SelectedIndices[0]] = colorDialog1.Color.ToArgb();
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors").IntArrayValue.SetValue(colorDialog1.Color.ToArgb(), prechodyView.SelectedIndices[0]);
                }
            }
        }

        private void prechodyView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (prechodyView.SelectedItems.Count == 0)
                odebratPrechod.Enabled = false;
            else
            {
                odebratPrechod.Enabled = true;
                if (barvyView.SelectedItems.Count > 0)
                    barvyView.SelectedItems[0].Selected = false;
            }
        }

        private void pridatPrechod_Click(object sender, EventArgs e)
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

                //firework star
                if (form.varianta != 5 && !form.explosions.Contains(id))
                {
                    prechody.Add(colorDialog1.Color.ToArgb());

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Explosion"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("FadeColors") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Add(new NbtIntArray("FadeColors"));

                    prechodyView.Items.Clear();
                    int[] array = new int[prechody.Count];
                    for (int i = 0; i < prechody.Count; i++)
                    {
                        array[i] = prechody[i];

                        prechodyView.Items.Add(new ListViewItem(""));
                        prechodyView.Items[i].BackColor = Color.FromArgb(prechody[i]);
                    }

                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("FadeColors").Value = array;
                    prechodyView.Enabled = true;
                }

                    //firework
                else if (form.varianta != 5)
                {
                    prechody.Add(colorDialog1.Color.ToArgb());

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Fireworks"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Add(new NbtList("Explosions"));

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch) == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Add(new NbtCompound());

                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Add(new NbtIntArray("FadeColors"));

                    prechodyView.Items.Clear();
                    int[] array = new int[prechody.Count];
                    for (int i = 0; i < prechody.Count; i++)
                    {
                        array[i] = prechody[i];

                        prechodyView.Items.Add(new ListViewItem(""));
                        prechodyView.Items[i].BackColor = Color.FromArgb(prechody[i]);
                    }

                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors").Value = array;
                    prechodyView.Enabled = true;
                }
                //firework star
                else if (!form.explosions.Contains(form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").IntValue))
                {
                    prechody.Add(colorDialog1.Color.ToArgb());

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Explosion"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("FadeColors") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Add(new NbtIntArray("FadeColors"));

                    prechodyView.Items.Clear();
                    int[] array = new int[prechody.Count];
                    for (int i = 0; i < prechody.Count; i++)
                    {
                        array[i] = prechody[i];

                        prechodyView.Items.Add(new ListViewItem(""));
                        prechodyView.Items[i].BackColor = Color.FromArgb(prechody[i]);
                    }

                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("FadeColors").Value = array;
                    prechodyView.Enabled = true;
                }
                //forework
                else
                {
                    prechody.Add(colorDialog1.Color.ToArgb());

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Fireworks"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Add(new NbtList("Explosions"));

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch) == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Add(new NbtCompound());

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Add(new NbtIntArray("FadeColors"));

                    prechodyView.Items.Clear();
                    int[] array = new int[prechody.Count];
                    for (int i = 0; i < prechody.Count; i++)
                    {
                        array[i] = prechody[i];

                        prechodyView.Items.Add(new ListViewItem(""));
                        prechodyView.Items[i].BackColor = Color.FromArgb(prechody[i]);
                    }

                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors").Value = array;
                    prechodyView.Enabled = true;
                }
            }
        }

        private void odstranPrechod_Click(object sender, EventArgs e)
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

            if (form.varianta != 5 && form.viceBarev.Contains(id))
            {
                prechody.RemoveAt(prechodyView.SelectedIndices[0]);
                int[] array = new int[prechody.Count];
                prechodyView.Items.Clear();

                for (int i = 0; i < prechody.Count; i++)
                {
                    array[i] = prechody[i];

                    prechodyView.Items.Add(new ListViewItem(""));
                    prechodyView.Items[i].BackColor = Color.FromArgb(array[i]);
                }


                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors").Value = array;
                if (prechodyView.Items.Count == 0 || prechodyView.SelectedIndices.Count == 0)
                    odebratPrechod.Enabled = false;
            }
            else if (form.viceBarev.Contains(form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").IntValue))
            {
                prechody.RemoveAt(prechodyView.SelectedIndices[0]);
                int[] array = new int[prechody.Count];
                prechodyView.Items.Clear();

                for (int i = 0; i < prechody.Count; i++)
                {
                    array[i] = prechody[i];

                    prechodyView.Items.Add(new ListViewItem(""));
                    prechodyView.Items[i].BackColor = Color.FromArgb(array[i]);
                }

                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors").Value = array;
                if (prechodyView.Items.Count == 0 || prechodyView.SelectedIndices.Count == 0)
                    odebratPrechod.Enabled = false;
            }
            if (prechodyView.Items.Count == 0)
            {
                prechodyView.Enabled = false;
                odebratPrechod.Enabled = false;
            }
        }
    }
}
