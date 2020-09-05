using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaveEdit
{
    public partial class Form1
    {
        internal void ZmenJazyk()
        {
            this.novy.Text = Jazyk.Strings.Pridat_vlastni_item;
            this.otevrit.Text = Jazyk.Strings.Otevrit;
            this.ulozit.Text = Jazyk.Strings.Ulozit;
            this.kopirovatBtn.Text = Jazyk.Strings.Kopirovat;
            this.vlozitBtn.Text = Jazyk.Strings.Vlozit;
            this.moznostiHry.Text = Jazyk.Strings.Moznosti_hry;
            this.OProgramu.Text = Jazyk.Strings.O_programu;
            this.OProgramu.ToolTipText = Jazyk.Strings.O_programu;
            this.oProgramuToolStripMenuItem.Text = Jazyk.Strings.O_programu;
            this.aktualizovatToolStripMenuItem.Text = Jazyk.Strings.Vyhledat_aktualizace;
            this.nápovědaToolStripMenuItem.Text = Jazyk.Strings.Napoveda;
            this.changelogToolStripMenuItem.Text = Jazyk.Strings.Changelog;
            this.jazykToolStripMenuItem.Text = Jazyk.Strings.Jazyk;
            this.updateButton.Text = Jazyk.Strings.Aktualizovat;
            this.updateButton.ToolTipText = Jazyk.Strings.Aktualizovat;
            this.kategorieBtn.Text = Jazyk.Strings.Kategorie + " >>";
            this.kategorieBtn.ToolTipText = Jazyk.Strings.Seznam_kategorii;
            this.label1.Text = Jazyk.Strings.Pocet;
            this.label2.Text = Jazyk.Strings.Poskozeni;
            this.vyhledavani.Text = Jazyk.Strings.Hledej;
            this.otevritDial.Filter = Jazyk.Strings.Ulozeny_svet + "|*.dat";
            this.label5.Text = Jazyk.Strings.XP_level;
            this.label6.Text = Jazyk.Strings.Zacni_otevrenim_ulozene_pozice;
            this.popisek.SetToolTip(this.enchantyButton, Jazyk.Strings.Enchanty);
            this.popisek.SetToolTip(this.vlastnosti, Jazyk.Strings.Vlastnosti_itemu);
            this.label7.Text = Jazyk.Strings.Probiha_nacitani_itemu;
            this.ktg.stavebni.Text = Jazyk.Strings.Stavebni_material;
            this.ktg.button2.Text = Jazyk.Strings.Vse;
            this.ktg.dekorace.Text = Jazyk.Strings.Dekorativni_material;
            this.ktg.redstone.Text = Jazyk.Strings.Redstone;
            this.ktg.doprava.Text = Jazyk.Strings.Doprava;
            this.ktg.ruzne.Text = Jazyk.Strings.Ruzne;
            this.ktg.jidlo.Text = Jazyk.Strings.Jidlo;
            this.ktg.nastroje.Text = Jazyk.Strings.Nastroje;
            this.ktg.bojove.Text = Jazyk.Strings.Zbrane;
            this.ktg.lektvary.Text = Jazyk.Strings.Lektvary;
            this.ktg.materialy.Text = Jazyk.Strings.Materialy;
            this.ktg.button1.Text = Jazyk.Strings.Vlastni;
            this.ktg.Text = Jazyk.Strings.Kategorie;
            this.poslatNápadToolStripMenuItem.Text = Jazyk.Strings.Poslat_napad;
            this.nahlásitChybuToolStripMenuItem.Text = Jazyk.Strings.Nahlasit_chybu;
        }
    }
}
