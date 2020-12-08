using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SaveEdit
{
    public partial class NbtNodeEdit : Form
    {
        TreeNode node;
        Form1 form;
        public NbtNodeEdit(Form1 form, TreeNode node, string typ)
        {
            this.form = form;
            this.node = node;
            InitializeComponent();
            this.Text = form.jazyk.ReturnPreklad("NbtEditor/EditValues", form.en);
            if (typ == "double")
            {
                Log.Write("Opening NbtTagNode editor in \"Double\" mode", Log.Verbosity.Info);
                if (((NbtEditNodeTag)node.Tag).NbtTagData.Name != "")
                    this.textBox1.Text = ((NbtEditNodeTag)node.Tag).NbtTagData.Name;
                else
                    this.textBox1.Enabled = false;

                switch (((NbtEditNodeTag)node.Tag).NbtTagData.TagType)
                {
                    case fNbt.NbtTagType.Byte:
                        break;
                    case fNbt.NbtTagType.ByteArray:
                        break;
                    case fNbt.NbtTagType.Compound:
                        this.textBox2.Enabled = false;
                        break;
                    case fNbt.NbtTagType.Double:
                        break;
                    case fNbt.NbtTagType.Float:
                        break;
                    case fNbt.NbtTagType.Int:
                        break;
                    case fNbt.NbtTagType.IntArray:
                        break;
                    case fNbt.NbtTagType.List:
                        this.textBox2.Enabled = false;
                        break;
                    case fNbt.NbtTagType.Long:
                        break;
                    case fNbt.NbtTagType.LongArray:
                        break;
                    case fNbt.NbtTagType.Short:
                        break;
                    case fNbt.NbtTagType.String:
                        this.textBox2.Text = ((NbtEditNodeTag)node.Tag).NbtTagData.StringValue;

                        break;
                }
            }
            else if (typ == "name")
            {
                Log.Write("Opening NbtTagNode editor in \"Name\" mode", Log.Verbosity.Info);
            }
            else if (typ == "value")
            {
                Log.Write("Opening NbtTagNode editor in \"Value\" mode", Log.Verbosity.Info);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Enabled)
                ((NbtEditNodeTag)node.Tag).NbtTagData.Name = textBox1.Text;
            if(textBox2.Enabled)
                ((fNbt.NbtString)((NbtEditNodeTag)node.Tag).NbtTagData).Value = textBox2.Text;

        }
    }
}
