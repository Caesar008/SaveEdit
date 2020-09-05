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
    public partial class VlastnostiItemu : Form
    {
        private void efektyView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (efektyView.SelectedItems.Count == 0)
            {
                odebratVybuch.Enabled = false;

                pridatBarvu.Enabled = false;
                pridatPrechod.Enabled = false;
                odebratPrechod.Enabled = false;
                zrusitBarvu.Enabled = false;
                panel.Enabled = false;
                barvyView.Enabled = false;
                prechodyView.Enabled = false;
                barvyView.Items.Clear();
                prechodyView.Items.Clear();
            }
            else
            {
                form.Prepnuto = true;
                odebratVybuch.Enabled = true;
                barvyView.Items.Clear();
                prechodyView.Items.Clear();
                barvy.Clear();
                prechody.Clear();
                flicker.Checked = false;
                trail.Checked = false;
                vybranyVybuch = efektyView.SelectedIndices[0];
                GetBarvyFirework(vybranyVybuch);
                panel.Enabled = true;
                form.Prepnuto = false;
                pridatBarvu.Enabled = true;
                pridatPrechod.Enabled = true;
            }
        }

        private void pridatVybuch_Click(object sender, EventArgs e)
        {
            form.NeulozenoMetoda();
            if(form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
            if(form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks")== null)
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("Fireworks"));
            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions") == null)
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Add(new NbtList("Explosions"));
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Add(new NbtCompound());

            efektyView.Items.Add(new ListViewItem(form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Count.ToString()));
            efektyView.Enabled = true;
            odebratVybuch.Enabled = false;
        }

        private void odebratVybuch_Click(object sender, EventArgs e)
        {
            if (efektyView.SelectedItems.Count > 0)
            {
                form.NeulozenoMetoda();
                efektyView.Items.Clear();
                barvyView.Items.Clear();
                prechodyView.Items.Clear();
                barvyView.Enabled = false;
                prechodyView.Enabled = false;
                pridatBarvu.Enabled = false;
                pridatPrechod.Enabled = false;
                panel.Enabled = false;

                if (form.varianta != 5)
                {
                    form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").RemoveAt(vybranyVybuch);

                    int index = 0;
                    foreach (NbtCompound c in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions"))
                    {
                        efekty.Add(c);
                        efektyView.Items.Add(new ListViewItem((++index).ToString()));
                        efektyView.Enabled = true;
                    }
                }
                else
                {
                    form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").RemoveAt(vybranyVybuch);
                    int index = 0;
                    foreach (NbtCompound c in form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions"))
                    {
                        efekty.Add(c);
                        efektyView.Items.Add(new ListViewItem((++index).ToString()));
                        efektyView.Enabled = true;
                    }
                }
                odebratVybuch.Enabled = false;
            }
            if (efektyView.Items.Count == 0)
            {
                efektyView.Enabled = false;
                odebratVybuch.Enabled = false;
            }
        }
    }
}
