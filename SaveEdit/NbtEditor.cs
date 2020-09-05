using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using fNbt;

namespace SaveEdit
{
    public partial class NbtEditor : Form
    {
        Form1 form1;
        internal NbtEditor(Form1 form)
        {
            form1 = form;
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(form.Location.X + (form.Width/2) - (this.Width/2), form.Location.Y + (form.Height / 2) - (this.Height / 2));
            this.Text = form.jazyk.ReturnPreklad("NbtEditor/Caption", form.en);
            treeView1.ImageList = new ImageList();
            treeView1.ImageList.Images.Add("byte", Properties.Resources._byte);
            treeView1.ImageList.Images.Add("short", Properties.Resources._short);
            treeView1.ImageList.Images.Add("int", Properties.Resources._int);
            treeView1.ImageList.Images.Add("long", Properties.Resources._long);
            treeView1.ImageList.Images.Add("float", Properties.Resources._float);
            treeView1.ImageList.Images.Add("double", Properties.Resources._double);
            treeView1.ImageList.Images.Add("string", Properties.Resources._string);
            treeView1.ImageList.Images.Add("byteArray", Properties.Resources.byteArray);
            treeView1.ImageList.Images.Add("intArray", Properties.Resources.intArray);
            treeView1.ImageList.Images.Add("longArray", Properties.Resources.longArray);
            treeView1.ImageList.Images.Add("compound", Properties.Resources.compound);
            treeView1.ImageList.Images.Add("list", Properties.Resources.list);

            //create strom
            TreeNode rootNode = new TreeNode();
            
            treeView1.Nodes.Add(AddNode(rootNode, form.itemToEdit.NbtItem, form.itemToEdit.Name));
            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.TopNode;
            edit.Enabled = false;
        }

        TreeNode AddNode(TreeNode node, NbtTag tag, string name = "")
        {
            switch (tag.TagType)
            {
                case NbtTagType.Byte:
                    TreeNode tnb = new TreeNode(tag.Name + " : " + tag.ByteValue, treeView1.ImageList.Images.IndexOfKey("byte"), treeView1.ImageList.Images.IndexOfKey("byte"));
                    tnb.Tag = "byte";
                    if (tag.Name.ToLower() == "slot")
                    {
                        tnb.ForeColor = SystemColors.GrayText;
                        tnb.BackColor = Color.LightGray;
                        tnb.Tag = "disable";
                    }
                    node.Nodes.Add(tnb);
                    break;
                case NbtTagType.ByteArray:
                    TreeNode tnba = new TreeNode(tag.Name + " : " + tag.ByteArrayValue.Length, treeView1.ImageList.Images.IndexOfKey("byteArray"), treeView1.ImageList.Images.IndexOfKey("byteArray"));
                    tnba.Tag = "byteArray";
                    foreach (byte byteTag in tag.ByteArrayValue)
                        tnba.Nodes.Add(new TreeNode(byteTag.ToString(), treeView1.ImageList.Images.IndexOfKey("byte"), treeView1.ImageList.Images.IndexOfKey("byte")));
                    node.Nodes.Add(tnba);
                    break;
                case NbtTagType.Compound:
                    if (name == "")
                    {
                        TreeNode tnc = new TreeNode(tag.Name + " : " + ((NbtCompound)tag).Tags.Count(), treeView1.ImageList.Images.IndexOfKey("compound"), treeView1.ImageList.Images.IndexOfKey("compound"));
                        tnc.Tag = "compound";
                        foreach (NbtTag comTag in ((NbtCompound)tag).Tags)
                            AddNode(tnc, comTag);
                        node.Nodes.Add(tnc);
                    }
                    else
                    {
                        node = new TreeNode(name, treeView1.ImageList.Images.IndexOfKey("compound"), treeView1.ImageList.Images.IndexOfKey("compound"));
                        node.Tag = "compound";
                        foreach (NbtTag comTag in ((NbtCompound)tag).Tags)
                            AddNode(node, comTag);
                    }
                    break;
                case NbtTagType.Double:
                    TreeNode tnd = new TreeNode(tag.Name + " : " + tag.DoubleValue, treeView1.ImageList.Images.IndexOfKey("double"), treeView1.ImageList.Images.IndexOfKey("double"));
                    tnd.Tag = "double";
                    node.Nodes.Add(tnd);
                    break;
                case NbtTagType.Float:
                    TreeNode tnf = new TreeNode(tag.Name + " : " + tag.FloatValue, treeView1.ImageList.Images.IndexOfKey("float"), treeView1.ImageList.Images.IndexOfKey("float"));
                    tnf.Tag = "float";
                    node.Nodes.Add(tnf);
                    break;
                case NbtTagType.Int:
                    TreeNode tni = new TreeNode(tag.Name + " : " + tag.IntValue, treeView1.ImageList.Images.IndexOfKey("int"), treeView1.ImageList.Images.IndexOfKey("int"));
                    tni.Tag = "int";
                    node.Nodes.Add(tni);
                    break;
                case NbtTagType.IntArray:
                    TreeNode tnia = new TreeNode(tag.Name + " : " + tag.IntArrayValue.Length, treeView1.ImageList.Images.IndexOfKey("intArray"), treeView1.ImageList.Images.IndexOfKey("intArray"));
                    tnia.Tag = "intArray";
                    foreach (int intTag in tag.IntArrayValue)
                        tnia.Nodes.Add(new TreeNode(intTag.ToString(), treeView1.ImageList.Images.IndexOfKey("intArray"), treeView1.ImageList.Images.IndexOfKey("intArray")));
                    node.Nodes.Add(tnia);
                    break;
                case NbtTagType.List:
                    TreeNode tnl = new TreeNode(tag.Name + " : " + ((NbtList)tag).Count, treeView1.ImageList.Images.IndexOfKey("list"), treeView1.ImageList.Images.IndexOfKey("list"));
                    tnl.Tag = "list" + "|" + ((NbtList)tag).ListType.ToString();
                    foreach(NbtTag listTag in (NbtList)tag)
                        AddNode(tnl, listTag);
                    node.Nodes.Add(tnl);
                    break;
                case NbtTagType.Long:
                    TreeNode tnlo = new TreeNode(tag.Name + " : " + tag.LongValue, treeView1.ImageList.Images.IndexOfKey("long"), treeView1.ImageList.Images.IndexOfKey("long"));
                    tnlo.Tag = "long";
                    node.Nodes.Add(tnlo);
                    break;
                case NbtTagType.LongArray:
                    TreeNode tnla = new TreeNode(tag.Name + " : " + tag.LongArrayValue.Length, treeView1.ImageList.Images.IndexOfKey("intArray"), treeView1.ImageList.Images.IndexOfKey("intArray"));
                    tnla.Tag = "longArray";
                    foreach (long longTag in tag.LongArrayValue)
                        tnla.Nodes.Add(new TreeNode(longTag.ToString(), treeView1.ImageList.Images.IndexOfKey("intArray"), treeView1.ImageList.Images.IndexOfKey("intArray")));
                    node.Nodes.Add(tnla);
                    break;
                case NbtTagType.Short:
                    TreeNode tns = new TreeNode(tag.Name + " : " + tag.ShortValue, treeView1.ImageList.Images.IndexOfKey("short"), treeView1.ImageList.Images.IndexOfKey("short"));
                    tns.Tag = "short";
                    node.Nodes.Add(tns);
                    break;
                case NbtTagType.String:
                    TreeNode tnst = new TreeNode(tag.Name + " : " + tag.StringValue, treeView1.ImageList.Images.IndexOfKey("string"), treeView1.ImageList.Images.IndexOfKey("string"));
                    tnst.Tag = "string";
                    node.Nodes.Add(tnst);
                    break;
            }
            return node;
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            rename.Enabled = false;
            edit.Enabled = false;
            delete.Enabled = false;
            addByte.Enabled = false;
            addByteArray.Enabled = false;
            addCompound.Enabled = false;
            addDouble.Enabled = false;
            addFloat.Enabled = false;
            addInt.Enabled = false;
            addIntArray.Enabled = false;
            addList.Enabled = false;
            addLong.Enabled = false;
            addLongArray.Enabled = false;
            addShort.Enabled = false;
            addString.Enabled = false;

            //index uzlu
            List<string> path = new List<string>();
            TreeNode testIndex = e.Node;
            do
            {
                path.Add(testIndex.Name + "|" + testIndex.Index);
                testIndex = testIndex.Parent;
            }
            while (testIndex != null);
            /*string ind = "";
            for (int i = path.Count - 1; i >= 0; i--)
                ind += path[i].ToString() + ".";
            if (ind.EndsWith("."))
                ind = ind.Remove(ind.Length - 1);
            MessageBox.Show(ind);*/
            //konec indexu uzlu

            switch (((string)e.Node.Tag).Split('|')[0])
            {
                case "byte":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    break;
                case "byteArray":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    addByte.Enabled = true;
                    break;
                case "compound":
                    rename.Enabled = true;
                    delete.Enabled = true;
                    addByte.Enabled = true;
                    addByteArray.Enabled = true;
                    addCompound.Enabled = true;
                    addDouble.Enabled = true;
                    addFloat.Enabled = true;
                    addInt.Enabled = true;
                    addIntArray.Enabled = true;
                    addList.Enabled = true;
                    addLong.Enabled = true;
                    addLongArray.Enabled = true;
                    addShort.Enabled = true;
                    addString.Enabled = true;
                    break;
                case "double":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    break;
                case "float":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    break;
                case "int":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    break;
                case "intArray":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    addInt.Enabled = true;
                    break;
                case "long":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    break;
                case "short":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    break;
                case "string":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    break;
                case "longArray":
                    rename.Enabled = true;
                    edit.Enabled = true;
                    delete.Enabled = true;
                    addLong.Enabled = true;
                    break;
                case "list":
                    rename.Enabled = true;
                    delete.Enabled = true;


                    switch (((string)e.Node.Tag).Split('|')[1])
                    {
                        case "Byte":
                            addByte.Enabled = true;
                            break;
                        case "ByteArray":
                            addByteArray.Enabled = true;
                            break;
                        case "Compound":
                            addCompound.Enabled = true;
                            break;
                        case "Double":
                            addDouble.Enabled = true;
                            break;
                        case "Float":
                            addFloat.Enabled = true;
                            break;
                        case "Int":
                            addInt.Enabled = true;
                            break;
                        case "IntArray":
                            addIntArray.Enabled = true;
                            break;
                        case "List":
                            addList.Enabled = true;
                            break;
                        case "Long":
                            addLong.Enabled = true;
                            break;
                        case "LongArray":
                            addLongArray.Enabled = true;
                            break;
                        case "Short":
                            addShort.Enabled = true;
                            break;
                        case "String":
                            addString.Enabled = true;
                            break;
                        case "Unknown":
                            addByte.Enabled = true;
                            addByteArray.Enabled = true;
                            addCompound.Enabled = true;
                            addDouble.Enabled = true;
                            addFloat.Enabled = true;
                            addInt.Enabled = true;
                            addIntArray.Enabled = true;
                            addList.Enabled = true;
                            addLong.Enabled = true;
                            addLongArray.Enabled = true;
                            addShort.Enabled = true;
                            addString.Enabled = true;
                            break;
                    }
                        break;
            }
        }
    }
}
