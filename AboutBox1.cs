using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace SaveEdit
{
    partial class AboutBox1 : Form
    {
        public AboutBox1(Form1 form)
        {
            InitializeComponent();
            
            string verzeItemu = form.Verze.GetObjekty["itemy"].ToString();
            verzeItemu = verzeItemu[0] + "." + verzeItemu[1] + "." + verzeItemu[2];
            string verze = form.Verze.GetObjekty["program"].ToString();
            if (verze.Length < 8)
                verze = "0" + verze;
            verze = (verze[0] == '0' ? "" : verze[0].ToString()) + "" + verze[1] + "." + (verze[2] == '0' ? "" : verze[2].ToString()) + "" + verze[3] + "." + (verze[4] == '0' ? "" : verze[4].ToString()) + "" + verze[5] + "." + (verze[6] == '0' ? "" : verze[6].ToString()) + "" + verze[7];
            
            this.Text = String.Format(Jazyk.Strings.O_programu + " {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyProduct;
            this.labelVersion.Text = String.Format(Jazyk.Strings.Verze + " {0}", verze);
            this.labelVerzeItemu.Text = String.Format(Jazyk.Strings.Verze_itemu + " " + verzeItemu + " (" + form.itemInfo +")");
            this.labelCopyright.Text = AssemblyCopyright;
            this.textBoxDescription.Text = Jazyk.Strings.Licence;
            
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
            this.Dispose();
        }

        private void KlikNaOdkaz(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(e.LinkText);
        }
    }
}
