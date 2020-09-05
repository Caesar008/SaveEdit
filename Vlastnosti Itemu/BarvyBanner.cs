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
    public partial class BarvyBanner : Form
    {
        VlastnostiItemu vl;
        Form1 form;
        public BarvyBanner(Form1 form, VlastnostiItemu vl)
        {
            InitializeComponent();
            this.form = form;
            this.vl = vl;
        }

        private void zrusit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ok_Click(object sender, EventArgs e)
        {
            form.NeulozenoMetoda();
            if(cerna.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(25, 22, 22);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 0;
            }
            else if (cervena.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(150, 52, 48);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 1;
            }
            else if (zelena.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(53, 70, 27);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 2;
            }
            else if (hneda.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(79, 50, 31);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 3;
            }
            else if (modra.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(46, 56, 141);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 4;
            }

            else if (fialova.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(126, 61, 181);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 5;
            }
            else if (cyan.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(46, 110, 137);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 6;
            }
            else if (sseda.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(154, 161, 161);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 7;
            }
            else if (seda.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(64, 64, 64);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 8;
            }
            else if (ruzova.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(208, 132, 153);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 9;
            }
            else if (lime.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(65, 174, 56);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 10;
            }
            else if (zluta.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(177, 166, 39);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 11;
            }
            else if (smodra.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(107, 138, 201);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 12;
            }
            else if (magenta.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(179, 80, 188);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 13;
            }
            else if (oranzova.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(219, 125, 62);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 14;
            }
            else if (bila.Checked)
            {
                vl.patternyView.Items[vl.index2].BackColor = Color.FromArgb(221, 221, 221);
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(vl.item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(vl.index2).Get<NbtInt>("Color").Value = 15;
            }
            vl.bannerNahled.Image = vl.NovyBanner();
            vl.patternyView.Items[vl.index2].Selected = true;
            vl.patternyView.Select();
            this.Close();
        }
    }
}
