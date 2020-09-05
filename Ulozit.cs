using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SaveEdit
{
    public partial class Form1
    {
        private void Ulozit()
        {
            if (!item.Contains(@".minecraft\saves\"))
                save.SaveFile(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\.minecraft\saves\" + item + @"\level.dat");
            else
                save.SaveFile(item);
            Neulozeno = false;
            this.Text = "SaveEdit";
            GetEnchant(Aktivnienchant + 1);
        }
    }
}
