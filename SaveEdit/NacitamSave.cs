using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveEdit
{
    public partial class NacitamSave : Form
    {
        Form1 form;
        //int runtime = 0;

        public NacitamSave(Form1 form, bool items = false)
        {
            this.form = form;
            InitializeComponent();
            progressBar1.MarqueeAnimationSpeed = 25;
            if(!items)
                nacitamSaveLbl.Text = form.jazyk.ReturnPreklad("Messages/LoadingSave", form.en);
            else
                nacitamSaveLbl.Text = form.jazyk.ReturnPreklad("Messages/LoadingSaveEdit", form.en);
        }
    }
}
