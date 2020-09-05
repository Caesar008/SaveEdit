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
    public partial class VerzeNast : Form
    {
        public VerzeNast()
        {
            InitializeComponent();
            souborTB.Text = "SaveEdit";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\" + souborTB.Text))
            {
                Serializace s = new Serializace();
                Verze verze = s.Nacist(System.IO.Path.GetDirectoryName(Environment.GetCommandLineArgs()[0]) + "\\"+souborTB.Text);
                try
                {
                    verze.GetObjekty.Add(objektTB.Text, Int32.Parse(verzeTB.Text));
                }
                catch { verze.GetObjekty[objektTB.Text] = Int32.Parse(verzeTB.Text); }
                s.Ulozit(souborTB.Text, verze);
            }
            else
            {
                Serializace s = new Serializace();
                s.Ulozit(souborTB.Text, new Verze(Int32.Parse(verzeTB.Text), objektTB.Text));
            }
        }
    }
}
