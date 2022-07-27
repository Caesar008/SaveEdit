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
                if (!InvokeRequired)
                    label1.Text = form.jazyk.ReturnPreklad("Messages/LoadingItems", form.en).Replace("{0}", item.ToString()).Replace("{1}", celkem.ToString());
                else
                    this.BeginInvoke(new Action(() => label1.Text = form.jazyk.ReturnPreklad("Messages/LoadingItems", form.en).Replace("{0}", item.ToString()).Replace("{1}", celkem.ToString())));
                if (progressBar1.Style == ProgressBarStyle.Marquee)
                { 
                    if (!InvokeRequired)
                        progressBar1.Style = ProgressBarStyle.Blocks;
                    else
                        this.BeginInvoke(new Action(() => progressBar1.Style = ProgressBarStyle.Blocks));
                }

                if (progress != 100)
                {
                    if (progressBar1.Maximum != 101)
                    {
                        if(!InvokeRequired)
                            progressBar1.Maximum = 101;
                        else
                            this.BeginInvoke(new Action(() => progressBar1.Maximum = 101));
                    }
                    if(!InvokeRequired)
                        progressBar1.Value = progress + 1;
                    else
                        this.BeginInvoke(new Action(() => progressBar1.Value = progress + 1));
                }
                else
                {
                    if (!InvokeRequired)
                    {
                        this.BeginInvoke(new Action(() => progressBar1.Value = progress + 1));
                        this.BeginInvoke(new Action(() => progressBar1.Maximum = 100));
                    }
                    else
                    {
                        this.BeginInvoke(new Action(() => progressBar1.Value = progress + 1));
                        this.BeginInvoke(new Action(() => progressBar1.Maximum = 100));
                    }
                }
                if (!InvokeRequired)
                    progressBar1.Value = progress;
                else
                    this.BeginInvoke(new Action(() => progressBar1.Value = progress));
            }
            else
            {
                progressBar1.Style = ProgressBarStyle.Marquee;
                if (!InvokeRequired)
                    label1.Text = "";
                else
                    this.BeginInvoke(new Action(() => label1.Text = ""));
            }
        }
    }
}
