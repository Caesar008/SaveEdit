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
        Form1 form;
        int barva = -1;
        List<int> barvy = new List<int>();
        List<int> prechody = new List<int>();
        List<NbtCompound> efekty = new List<NbtCompound>();
        string puvodniJmeno = string.Empty;
        internal int item = 0;
        int vybranyVybuch = -1;

        public VlastnostiItemu(Form1 form)
        {
            InitializeComponent();
            this.form = form;
            form.Prepnuto = true;
            GetVlastnost();
            form.Prepnuto = false;
        }

        void GetVlastnost()
        {
            foreach (NbtCompound c in form.inventarList)
            {
                if (c.Get<NbtByte>("Slot").Value == form.VybraneTL)
                {
                    item = form.inventarList.IndexOf(c);
                    break;
                }
            }

            puvodniJmeno = jmeno.Text = string.Empty;
            barvy.Clear();
            prechody.Clear();
            barva = -1;
            barvyView.Enabled = false;
            efekty.Clear();

            try
            {
                short id = 0;
                if (form.varianta != 5)
                {
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display") == null)
                        form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("display"));

                    NbtCompound vlastnosti = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display");

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
                        if (vlastnosti.Get<NbtInt>("color") != null)
                        {
                            barva = vlastnosti.Get<NbtInt>("color").Value;
                            barvyView.Items.Add(new ListViewItem(""));
                            barvyView.Items[0].BackColor = Color.FromArgb(barva);
                            barvyView.Enabled = true;
                            pridatBarvu.Enabled = false;
                        }
                        else
                        {
                            barva = -1;
                            pridatBarvu.Enabled = true;
                        }
                    }
                    else if (form.viceBarev.Contains(id))
                    {
                        //star
                        if (!form.explosions.Contains(id))
                        {
                            pridatBarvu.Enabled = true;
                            pridatPrechod.Enabled = true;
                            panel.Enabled = true;
                            malaKoule.Checked = true;

                            try
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors") != null)
                                {
                                    NbtIntArray colors = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors");

                                    int index = 0;
                                    foreach (int c in colors.Value)
                                    {
                                        barvy.Add(c);
                                        barvyView.Items.Add(new ListViewItem(""));
                                        barvyView.Items[index++].BackColor = Color.FromArgb(c);
                                        barvyView.Enabled = true;
                                    }
                                }
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("FadeColors") != null)
                                {
                                    NbtIntArray fade = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("FadeColors");

                                    int index = 0;
                                    foreach (int c in fade.Value)
                                    {
                                        prechody.Add(c);
                                        prechodyView.Items.Add(new ListViewItem(""));
                                        prechodyView.Items[index++].BackColor = Color.FromArgb(c);
                                        prechodyView.Enabled = true;
                                    }
                                }
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Type") != null)
                                {
                                    switch (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Type").Value)
                                    {
                                        case 0: malaKoule.Checked = true;
                                            break;
                                        case 1: velkaKoule.Checked = true;
                                            break;
                                        case 2: hvezda.Checked = true;
                                            break;
                                        case 3: hlavaCreepera.Checked = true;
                                            break;
                                        case 4: rozprsknuti.Checked = true;
                                            break;
                                        default: malaKoule.Checked = true;
                                            break;
                                    }
                                }
                                else
                                    malaKoule.Checked = true;
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Flicker") != null)
                                {
                                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Flicker").Value == 1)
                                        flicker.Checked = true;
                                }
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Trail") != null)
                                {
                                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Trail").Value == 1)
                                        trail.Checked = true;
                                }
                            }
                            catch { }
                        }
                        //firework
                        else
                        {
                            pridatVybuch.Enabled = true;
                            dolet.Enabled = true;

                            int index = 0;
                            foreach (NbtCompound c in form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions"))
                            {
                                efekty.Add(c);
                                efektyView.Items.Add(new ListViewItem((++index).ToString()));
                                efektyView.Enabled = true;
                            }
                            try
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight") != null)
                                    dolet.Value = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight").Value;
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type") != null)
                                {
                                    switch (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type").Value)
                                    {
                                        case 0: malaKoule.Checked = true;
                                            break;
                                        case 1: velkaKoule.Checked = true;
                                            break;
                                        case 2: hvezda.Checked = true;
                                            break;
                                        case 3: hlavaCreepera.Checked = true;
                                            break;
                                        case 4: rozprsknuti.Checked = true;
                                            break;
                                        default: malaKoule.Checked = true;
                                            break;
                                    }
                                }
                                else
                                    malaKoule.Checked = true;
                            }
                            catch
                            {
                            }
                            try
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Flicker") != null)
                                {
                                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Flicker").Value == 1)
                                        flicker.Checked = true;
                                }
                            }
                            catch { }
                            try
                            {
                                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Trail") != null)
                                {
                                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Trail").Value == 1)
                                        trail.Checked = true;
                                }
                            }
                            catch { }
                        }
                    }
                    else if(form.bannery.Contains(id))
                    {
                        bannerNahled.Image = NovyBanner();
                    }

                    if (vlastnosti.Get<NbtString>("Name") != null)
                    {
                        puvodniJmeno = jmeno.Text = vlastnosti.Get<NbtString>("Name").Value;
                    }
                    else
                        puvodniJmeno = jmeno.Text = string.Empty;
                }
                else
                {
                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display") == null)
                        form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("display"));

                    NbtCompound vlastnosti = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display");

                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get("id").TagType == NbtTagType.Short)
                        id = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("id").Value;
                    else
                    {
                        string sid = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtString>("id").Value;

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
                        if (vlastnosti.Get<NbtInt>("color") != null)
                        {
                            barva = vlastnosti.Get<NbtInt>("color").Value;
                            barvyView.Items.Add(new ListViewItem(""));
                            barvyView.Items[0].BackColor = Color.FromArgb(barva);
                            barvyView.Enabled = true;
                            pridatBarvu.Enabled = false;
                        }
                        else
                        {
                            barva = -1;
                            pridatBarvu.Enabled = false;
                        }
                    }
                    else if (form.viceBarev.Contains(id))
                    {
                        //star
                        if (!form.explosions.Contains(id))
                        {
                            pridatBarvu.Enabled = true;
                            pridatPrechod.Enabled = true;
                            panel.Enabled = true;
                            malaKoule.Checked = true;

                            try
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors") != null)
                                {
                                    NbtIntArray colors = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("Colors");

                                    int index = 0;
                                    foreach (int c in colors.Value)
                                    {
                                        barvy.Add(c);
                                        barvyView.Items.Add(new ListViewItem(""));
                                        barvyView.Items[index++].BackColor = Color.FromArgb(c);
                                        barvyView.Enabled = true;
                                    }
                                }
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("FadeColors") != null)
                                {
                                    NbtIntArray fade = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtIntArray>("FadeColors");
                                    int index = 0;
                                    foreach (int c in fade.Value)
                                    {
                                        prechody.Add(c);
                                        prechodyView.Items.Add(new ListViewItem(""));
                                        prechodyView.Items[index++].BackColor = Color.FromArgb(c);
                                        prechodyView.Enabled = true;
                                    }
                                }
                            }
                            catch { }
                            try
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Type") != null)
                                {
                                    switch (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Type").Value)
                                    {
                                        case 0: malaKoule.Checked = true;
                                            break;
                                        case 1: velkaKoule.Checked = true;
                                            break;
                                        case 2: hvezda.Checked = true;
                                            break;
                                        case 3: hlavaCreepera.Checked = true;
                                            break;
                                        case 4: rozprsknuti.Checked = true;
                                            break;
                                        default: malaKoule.Checked = true;
                                            break;
                                    }
                                }
                                else
                                    malaKoule.Checked = true;
                            }
                            catch { }
                            try
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Flicker") != null)
                                {
                                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Flicker").Value == 1)
                                        flicker.Checked = true;
                                }
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Trail") != null)
                                {
                                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Explosion").Get<NbtByte>("Trail").Value == 1)
                                        trail.Checked = true;
                                }

                            //firework
                                else
                                {
                                    pridatVybuch.Enabled = true;
                                    dolet.Enabled = true;

                                    int index = 0;
                                    foreach (NbtCompound c in form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions"))
                                    {
                                        efekty.Add(c);
                                        efektyView.Items.Add(new ListViewItem((++index).ToString()));
                                        efektyView.Enabled = true;
                                    }

                                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight") != null)
                                        dolet.Value = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight").Value;
                                }
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type") != null)
                                {
                                    switch (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type").Value)
                                    {
                                        case 0: malaKoule.Checked = true;
                                            break;
                                        case 1: velkaKoule.Checked = true;
                                            break;
                                        case 2: hvezda.Checked = true;
                                            break;
                                        case 3: hlavaCreepera.Checked = true;
                                            break;
                                        case 4: rozprsknuti.Checked = true;
                                            break;
                                        default: malaKoule.Checked = true;
                                            break;
                                    }
                                }
                                else
                                    malaKoule.Checked = true;
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Flicker") != null)
                                {
                                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Flicker").Value == 1)
                                        flicker.Checked = true;
                                }
                            }
                            catch { }

                            try
                            {
                                if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Trail") != null)
                                {
                                    if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Trail").Value == 1)
                                        trail.Checked = true;
                                }
                            }
                            catch { }
                        }
                    }

                    if (vlastnosti.Get<NbtString>("Name") != null)
                    {
                        puvodniJmeno = jmeno.Text = vlastnosti.Get<NbtString>("Name").Value;
                    }
                    else
                        puvodniJmeno = jmeno.Text = string.Empty;
                }
                
            }
            catch { }

        }

                    
        

        private void GetBarvyFirework(int id)
        {
                if (form.varianta != 5)
                {
                    try
                    {
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors") != null)
                        {
                            NbtIntArray colors = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors");

                            int index = 0;
                            foreach (int c in colors.Value)
                            {
                                barvy.Add(c);
                                barvyView.Items.Add(new ListViewItem(""));
                                barvyView.Items[index++].BackColor = Color.FromArgb(c);
                                barvyView.Enabled = true;
                            }
                        }
                    }
                    catch
                    {

                    }

                    try
                    {
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors") != null)
                        {
                            NbtIntArray fade = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors");
                            
                            int index = 0;
                            foreach (int c in fade.Value)
                            {
                                prechody.Add(c);
                                prechodyView.Items.Add(new ListViewItem(""));
                                prechodyView.Items[index++].BackColor = Color.FromArgb(c);
                                prechodyView.Enabled = true;
                            }
                        }
                    }catch{}

                    try
                    {
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight") != null)
                            dolet.Value = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtByte>("Flight").Value;

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type") != null)
                        {
                            switch (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Type").Value)
                            {
                                case 0: malaKoule.Checked = true;
                                    break;
                                case 1: velkaKoule.Checked = true;
                                    break;
                                case 2: hvezda.Checked = true;
                                    break;
                                case 3: hlavaCreepera.Checked = true;
                                    break;
                                case 4: rozprsknuti.Checked = true;
                                    break;
                                default: malaKoule.Checked = true;
                                    break;
                            }
                        }
                        else
                        {
                            malaKoule.Checked = true;
                        }

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Flicker") != null)
                        {
                            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Flicker").Value == 1)
                                flicker.Checked = true;
                        }

                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Trail") != null)
                        {
                            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtByte>("Trail").Value == 1)
                                trail.Checked = true;
                        }
                    }
                    catch
                    { }
                }
                else
                {
                    try
                    {
                        if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors") != null)
                        {
                            NbtIntArray colors = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("Colors");

                            int index = 0;
                            foreach (int c in colors.Value)
                            {
                                barvy.Add(c);
                                barvyView.Items.Add(new ListViewItem(""));
                                barvyView.Items[index++].BackColor = Color.FromArgb(c);
                                barvyView.Enabled = true;
                            }
                        }
                    }
                    catch { }
                    try
                    {
                        if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors") != null)
                        {
                            NbtIntArray fade = form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("Fireworks").Get<NbtList>("Explosions").Get<NbtCompound>(vybranyVybuch).Get<NbtIntArray>("FadeColors");

                            int index = 0;
                            foreach (int c in fade.Value)
                            {
                                prechody.Add(c);
                                prechodyView.Items.Add(new ListViewItem(""));
                                prechodyView.Items[index++].BackColor = Color.FromArgb(c);
                                prechodyView.Enabled = true;
                            }
                        }
                    }
                    catch { }
                }
        }

        private void jmeno_TextChanged(object sender, EventArgs e)
        {
            if (!form.Prepnuto)
            {
                if (jmeno.Text != puvodniJmeno)
                {
                    form.NeulozenoMetoda();

                    if (form.varianta != 5)
                    {
                        if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        {
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("display"));
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Add(new NbtString("Name", string.Empty));
                        }
                        else if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display") == null)
                        {
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("display"));
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Add(new NbtString("Name", string.Empty));
                        }
                        else if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtString>("Name") == null)
                        {
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Add(new NbtString("Name", string.Empty));
                        }

                        if(jmeno.Text != string.Empty)
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtString>("Name").Value = jmeno.Text;
                        else
                            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Remove("Name");
                    }
                    else
                    {
                        if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                        {
                            form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
                            form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("display"));
                            form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Add(new NbtString("Name", string.Empty));
                        }
                        else if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display") == null)
                        {
                            form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("display"));
                            form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Add(new NbtString("Name", string.Empty));
                        }
                        else if (form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtString>("Name") == null)
                        {
                            form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Add(new NbtString("Name", string.Empty));
                        }

                        if (jmeno.Text != string.Empty)
                            form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtString>("Name").Value = jmeno.Text;
                        else
                            form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Remove("Name");
                    }

                }
                else
                {
                    form.NeulozenoMetoda(true);

                    if (form.varianta != 5)
                    {
                        try
                        {
                            if (jmeno.Text != string.Empty)
                                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtString>("Name").Value = jmeno.Text;
                            else
                                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Remove("Name");
                        }
                        catch
                        {

                        }
                    }
                    else
                    {
                        try
                        {
                            if (jmeno.Text != string.Empty)
                                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Get<NbtString>("Name").Value = jmeno.Text;
                            else
                                form.save.RootTag.Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("display").Remove("Name");
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
    }
}
