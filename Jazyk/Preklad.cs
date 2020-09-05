using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SaveEdit.Jazyk
{
    public partial class Preklad : Form
    {
        public Preklad()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Jazyk.Serializace s = new Jazyk.Serializace();
            Jazyk.Ostatni o = new Jazyk.Ostatni();
            o.Seznam_itemu_neni_nacteny = seznamItemuNeniNactenyTxt.Text;
            o.Pridat_vlastni_item = pridatVlastniItemTXT.Text;
            o.Hledej = hledejTxt.Text;
            o.VerzeJazyka = verzeTxt.Text;
            o.NazevJazyka = nazevTxt.Text;
            s.Ulozit(zkratkaTxt.Text, o);
        }
    }
}
