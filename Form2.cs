using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using LibNbt;
using LibNbt.Tags;
using LibNbt.Queries;

namespace SaveEdit
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            Nacti();
        }

        private void Nacti()
        {
            NbtFile nbt = new NbtFile();
            NbtCompound xpLevel;
            nbt.LoadFile(@"C:\Users\Pavel\AppData\Roaming\.minecraft\saves\Testovací2\level.dat");
            xpLevel = nbt.Query<NbtCompound>("/").Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(0);
            richTextBox1.Text += xpLevel.ToString();
        }
    }
}
