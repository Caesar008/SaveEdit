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

        public void ReportProgress(int progress, int item, int celkem)
        {
            if (progress >= 0)
            {
                label1.Text = form.jazyk.ReturnPreklad("Messages/LoadingItems", form.en).Replace("{0}", item.ToString()).Replace("{1}", celkem.ToString());
                if (progressBar1.Style == ProgressBarStyle.Marquee)
                    progressBar1.Style = ProgressBarStyle.Blocks;
                if (progress != 100)
                {
                    if (progressBar1.Maximum != 101)
                        progressBar1.Maximum = 101;
                    progressBar1.Value = progress + 1;
                }
                else
                {
                    progressBar1.Value = progress + 1;
                    progressBar1.Maximum = 100;
                }
                progressBar1.Value = progress;
            }
            else
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                label1.Text = "";
            }
        }
    }
}
