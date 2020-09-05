using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaveEdit
{
    public partial class Kategorie : Form
    {
        Form1 form;
        public Kategorie(Form1 form)
        {
            this.form = form;
            InitializeComponent();
        }

        //kategorie
        private void button1_Click(object sender, EventArgs e)
        {
            short modulo = 1;

            if (((Button)sender).Name == "stavebni")
                modulo = form.vybranaKategorie = 11;
            else if (((Button)sender).Name == "dekorace")
                modulo = form.vybranaKategorie = 13;
            else if (((Button)sender).Name == "redstone")
                modulo = form.vybranaKategorie = 17;
            else if (((Button)sender).Name == "doprava")
                modulo = form.vybranaKategorie = 19;
            else if (((Button)sender).Name == "ruzne")
                modulo = form.vybranaKategorie = 23;
            else if (((Button)sender).Name == "jidlo")
                modulo = form.vybranaKategorie = 29;
            else if (((Button)sender).Name == "nastroje")
                modulo = form.vybranaKategorie = 31;
            else if (((Button)sender).Name == "bojove")
                modulo = form.vybranaKategorie = 37;
            else if (((Button)sender).Name == "lektvary")
                modulo = form.vybranaKategorie = 41;
            else if (((Button)sender).Name == "materialy")
                modulo = form.vybranaKategorie = 43;
            else
                modulo = form.vybranaKategorie = 1;

            ListView lv2 = new ListView();
            foreach (ListViewItem lvi in form.seznamBlocku.Items)
                lv2.Items.Add((ListViewItem)lvi.Clone());
            form.seznamBlocku.BeginUpdate();
            form.seznamBlocku.Items.Clear();
            int count = 0;
            foreach (Item i in form.itemList)
            {
                if (i.Kategorie % modulo == 0)
                {
                    ListViewItem novyItem = new ListViewItem(i.Jmeno, lv2.Items.IndexOfKey(i.Jmeno));
                    form.seznamBlocku.Items.Add(new ListViewItem(i.Jmeno, count));
                }
                count++;
            }
            form.seznamBlocku.EndUpdate();
        }

        //vše
        private void button2_Click(object sender, EventArgs e)
        {
            form.vybranaKategorie = 1;
            ListView lv2 = new ListView();
            foreach (ListViewItem lvi in form.seznamBlocku.Items)
                lv2.Items.Add((ListViewItem)lvi.Clone());
            form.seznamBlocku.BeginUpdate();
            form.seznamBlocku.Items.Clear();
            int count = 0;
            foreach (Item i in form.itemList)
            {
                ListViewItem novyItem = new ListViewItem(i.Jmeno, lv2.Items.IndexOfKey(i.Jmeno));
                form.seznamBlocku.Items.Add(new ListViewItem(i.Jmeno, count));

                count++;
            }
            form.seznamBlocku.EndUpdate();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ListView lv2 = new ListView();
            foreach (ListViewItem lvi in form.seznamBlocku.Items)
                lv2.Items.Add((ListViewItem)lvi.Clone());
            form.seznamBlocku.BeginUpdate();
            form.seznamBlocku.Items.Clear();
            int count = 0;
            form.vybranaKategorie = 9929;
            foreach (Item i in form.itemList)
            {
                if (i.Kategorie == 9929 || i.Vlastni)
                {
                    ListViewItem novyItem = new ListViewItem(i.Jmeno, lv2.Items.IndexOfKey(i.Jmeno));
                    form.seznamBlocku.Items.Add(new ListViewItem(i.Jmeno, count));
                }
                count++;
            }
            form.seznamBlocku.EndUpdate();
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCLBUTTONDOWN = 161;
            const int WM_SYSCOMMAND = 274;
            const int HTCAPTION = 2;
            const int SC_MOVE = 61456;

            if ((m.Msg == WM_SYSCOMMAND) && (m.WParam.ToInt32() == SC_MOVE))
            {
                return;
            }

            if ((m.Msg == WM_NCLBUTTONDOWN) && (m.WParam.ToInt32() == HTCAPTION))
            {
                return;
            }

            base.WndProc(ref m);
        }
    }
}
