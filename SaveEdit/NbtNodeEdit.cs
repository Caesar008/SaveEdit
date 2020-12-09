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
        NumericUpDown numUpDown;
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
                        textBox2.Visible = false;
                        numUpDown = new NumericUpDown();
                        numUpDown.Location = textBox2.Location;
                        numUpDown.Name = "numUpDown";
                        numUpDown.Size = textBox2.Size;
                        numUpDown.TabIndex = 1;
                        numUpDown.Minimum = 0;
                        numUpDown.Maximum = byte.MaxValue;
                        numUpDown.Value = ((NbtEditNodeTag)node.Tag).NbtTagData.ByteValue;
                        numUpDown.Tag = "byte";
                        Controls.Add(numUpDown);
                        break;
                    case fNbt.NbtTagType.ByteArray:
                        break;
                    case fNbt.NbtTagType.Compound:
                        this.textBox2.Enabled = false;
                        break;
                    case fNbt.NbtTagType.Double:
                        this.textBox2.Text = ((NbtEditNodeTag)node.Tag).NbtTagData.DoubleValue.ToString();
                        textBox2.Tag = "double";
                        break;
                    case fNbt.NbtTagType.Float:
                        this.textBox2.Text = ((NbtEditNodeTag)node.Tag).NbtTagData.FloatValue.ToString();
                        textBox2.Tag = "float";
                        break;
                    case fNbt.NbtTagType.Int:
                        textBox2.Visible = false;
                        numUpDown = new NumericUpDown();
                        numUpDown.Location = textBox2.Location;
                        numUpDown.Name = "numUpDown";
                        numUpDown.Size = textBox2.Size;
                        numUpDown.TabIndex = 1;
                        numUpDown.Minimum = 0;
                        numUpDown.Maximum = int.MaxValue;
                        numUpDown.Value = ((NbtEditNodeTag)node.Tag).NbtTagData.IntValue;
                        numUpDown.Tag = "int";
                        Controls.Add(numUpDown);
                        break;
                    case fNbt.NbtTagType.IntArray:
                        break;
                    case fNbt.NbtTagType.List:
                        this.textBox2.Enabled = false;
                        break;
                    case fNbt.NbtTagType.Long:
                        textBox2.Visible = false;
                        numUpDown = new NumericUpDown();
                        numUpDown.Location = textBox2.Location;
                        numUpDown.Name = "numUpDown";
                        numUpDown.Size = textBox2.Size;
                        numUpDown.TabIndex = 1;
                        numUpDown.Minimum = 0;
                        numUpDown.Maximum = long.MaxValue;
                        numUpDown.Value = ((NbtEditNodeTag)node.Tag).NbtTagData.LongValue;
                        numUpDown.Tag = "long";
                        Controls.Add(numUpDown);
                        break;
                    case fNbt.NbtTagType.LongArray:
                        break;
                    case fNbt.NbtTagType.Short:
                        textBox2.Visible = false;
                        numUpDown = new NumericUpDown();
                        numUpDown.Location = textBox2.Location;
                        numUpDown.Name = "numUpDown";
                        numUpDown.Size = textBox2.Size;
                        numUpDown.TabIndex = 1;
                        numUpDown.Minimum = 0;
                        numUpDown.Maximum = short.MaxValue;
                        numUpDown.Value = ((NbtEditNodeTag)node.Tag).NbtTagData.ShortValue;
                        numUpDown.Tag = "short";
                        Controls.Add(numUpDown);
                        break;
                    case fNbt.NbtTagType.String:
                        this.textBox2.Text = ((NbtEditNodeTag)node.Tag).NbtTagData.StringValue;
                        textBox2.Tag = "string";

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
            if (textBox2.Enabled && textBox2.Visible)
            {
                switch ((string)textBox2.Tag)
                {
                    case "string":
                        ((fNbt.NbtString)((NbtEditNodeTag)node.Tag).NbtTagData).Value = textBox2.Text;
                        break;
                    case "double":
                        double testDouble;
                        if(double.TryParse(textBox2.Text, out testDouble))
                            ((fNbt.NbtDouble)((NbtEditNodeTag)node.Tag).NbtTagData).Value = double.Parse(textBox2.Text);
                        break;
                    case "float":
                        float testFloat;
                        if (float.TryParse(textBox2.Text, out testFloat))
                            ((fNbt.NbtFloat)((NbtEditNodeTag)node.Tag).NbtTagData).Value = float.Parse(textBox2.Text);
                        break;
                }
            }
            else if (numUpDown != null)
            {
                switch ((string)numUpDown.Tag)
                {
                    case "byte":
                        ((fNbt.NbtByte)((NbtEditNodeTag)node.Tag).NbtTagData).Value = (byte)numUpDown.Value;
                        break;
                    case "int":
                        ((fNbt.NbtInt)((NbtEditNodeTag)node.Tag).NbtTagData).Value = (int)numUpDown.Value;
                        break;
                    case "long":
                        ((fNbt.NbtLong)((NbtEditNodeTag)node.Tag).NbtTagData).Value = (long)numUpDown.Value;
                        break;
                    case "short":
                        ((fNbt.NbtShort)((NbtEditNodeTag)node.Tag).NbtTagData).Value = (short)numUpDown.Value;
                        break;
                }
            }
        }
    }
}
