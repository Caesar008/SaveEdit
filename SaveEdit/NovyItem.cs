using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using fNbt;
using System.IO;
using System.Xml;

namespace SaveEdit
{
    public partial class NovyItem : Form
    {
        int minMcVerze = 0;
        int mcVerze = 0;
        string fileVerze = "0";
        string fileText = "";
        bool muze = true;

        public NovyItem()
        {
            InitializeComponent();
            seznamBlocku.SmallImageList = new ImageList { ColorDepth = ColorDepth.Depth24Bit };
            maxDamageUpDown.Maximum = int.MaxValue;
            LoadItemy();
            LoadPng();
        }

        void LoadItemy()
        {
            seznamBlocku.BeginUpdate();
            seznamBlocku.Items.Clear();
            seznamBlocku.SmallImageList.Images.Clear();
            seznamBlocku.Update();
            XmlDocument xmlItemy = new XmlDocument();
            xmlItemy.Load("itemy.xml");
            minMcVerze = int.Parse(xmlItemy.SelectSingleNode("Itemy/Minecraft").Attributes["min"].Value);
            mcVerze = int.Parse(xmlItemy.SelectSingleNode("Itemy/Minecraft").Attributes["mc"].Value);
            fileText = xmlItemy.SelectSingleNode("Itemy/Minecraft").InnerText;
            fileVerze = xmlItemy.SelectSingleNode("Itemy/Verze").InnerText;
            XmlNodeList xmlItemList = xmlItemy.SelectNodes("Itemy/Itemy/Item");

            foreach (XmlNode xmlItem in xmlItemList)
            {
                string id = xmlItem.SelectSingleNode("ID").InnerText;
                string jmeno = xmlItem.SelectSingleNode("Name").InnerText;
                byte stack = byte.Parse(xmlItem.SelectSingleNode("Stack").InnerText);
                string[] kategorie = xmlItem.SelectSingleNode("Kategorie").InnerText.Split(';');
                int maxDamage = -1, damage = -1;
                NbtCompound tag = null;
                byte[] povoleneSloty = null;
                bool canChangeCollor = false;
                bool banner = false;
                bool firework = false;
                bool vlastnostiItemu = false;
                List<string> mandatory = new List<string>();

                if (xmlItem.Attributes.Count > 0 && xmlItem.Attributes["canChangeColor"] != null)
                {
                    canChangeCollor = true;
                    vlastnostiItemu = true;
                }
                if (xmlItem.Attributes.Count > 0 && xmlItem.Attributes["banner"] != null)
                {
                    banner = true;
                    vlastnostiItemu = true;
                }
                if (xmlItem.Attributes.Count > 0 && xmlItem.Attributes["firework"] != null)
                {
                    firework = true;
                    vlastnostiItemu = true;
                }

                if (xmlItem.SelectSingleNode("Damage") != null)
                {
                    maxDamage = int.Parse(xmlItem.SelectSingleNode("Damage").InnerText);
                    damage = 0;
                }


                if (xmlItem.SelectSingleNode("Tag") != null)
                {
                    vlastnostiItemu = true;
                    tag = new NbtCompound("tag");
                    foreach (XmlNode tagValue in xmlItem.SelectNodes("Tag/Value"))
                    {
                        //parametry v tagu itemu
                        switch (tagValue.Attributes["type"].InnerText)
                        {
                            case "string":
                                tag.Add(new NbtString(tagValue.Attributes["name"].InnerText, tagValue.InnerText));
                                break;
                            case "byte":
                                tag.Add(new NbtByte(tagValue.Attributes["name"].InnerText, byte.Parse(tagValue.InnerText)));
                                break;
                            case "int":
                                tag.Add(new NbtInt(tagValue.Attributes["name"].InnerText, int.Parse(tagValue.InnerText)));
                                break;
                            case "list":
                                tag.Add(new NbtList(tagValue.Attributes["name"].InnerText));
                                foreach (XmlNode tagListValue in tagValue.SelectNodes("Value"))
                                {
                                    switch (tagListValue.Attributes["type"].InnerText)
                                    {
                                        case "string":
                                            tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtString(tagListValue.InnerText));
                                            break;
                                        case "byte":
                                            tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtByte(byte.Parse(tagListValue.InnerText)));
                                            break;
                                        case "int":
                                            tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtInt(int.Parse(tagListValue.InnerText)));
                                            break;
                                        case "compound":
                                            tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(RecursiveTagLoad(tagListValue, new NbtCompound(), mandatory));
                                            break;
                                    }
                                }
                                break;
                            case "compound":
                                tag.Add(RecursiveTagLoad(tagValue, new NbtCompound(), mandatory));
                                break;
                        }
                        if (tagValue.Attributes["req"] != null)
                            mandatory.Add(tagValue.Attributes["name"].InnerText + ";" + tagValue.InnerText);
                    }
                }
                if (xmlItem.SelectSingleNode("PovoleneSloty") != null)
                {
                    List<byte> sloty = new List<byte>();

                    foreach (string s in xmlItem.SelectSingleNode("PovoleneSloty").InnerText.Split(';'))
                    {
                        sloty.Add(byte.Parse(s));
                    }

                    povoleneSloty = sloty.ToArray();
                }

                Bitmap obrazek = new Bitmap(xmlItem.SelectSingleNode("Image/File").InnerText);
                Bitmap subObrazek = (Bitmap)obrazek.Clone(new Rectangle((int.Parse(xmlItem.SelectSingleNode("Image/X").InnerText) - 1) * 16, (int.Parse(xmlItem.SelectSingleNode("Image/Y").InnerText) - 1) * 16, 16, 16), obrazek.PixelFormat);

                string imageInfo = xmlItem.SelectSingleNode("Image/File").InnerText + ";" + int.Parse(xmlItem.SelectSingleNode("Image/X").InnerText) + ";" + int.Parse(xmlItem.SelectSingleNode("Image/Y").InnerText);

                Item i = new Item(jmeno, id, damage, maxDamage, stack, stack, 0, tag, kategorie, povoleneSloty, subObrazek, null, canChangeCollor, banner, firework, vlastnostiItemu, mandatory, imageInfo);

                //různé ID bude v xml samostatný uzel s verzováním pro daný item

                if (xmlItem.SelectSingleNode("MultipleID") != null)
                {
                    foreach (XmlNode multID in xmlItem.SelectNodes("MultipleID/ID"))
                    {
                        int minVerze = minMcVerze;
                        int maxVerze = int.MaxValue;

                        if (multID.Attributes["minVerze"] != null)
                        {
                            minVerze = int.Parse(multID.Attributes["minVerze"].Value);
                        }

                        if (multID.Attributes["maxVerze"] != null)
                        {
                            maxVerze = int.Parse(multID.Attributes["maxVerze"].Value);
                        }

                        i.AddVerze(minVerze, maxVerze, multID.InnerText);
                    }
                }
                seznamBlocku.SmallImageList.Images.Add(i.Image);
                ListViewItem lvi = new ListViewItem(i.Name, seznamBlocku.SmallImageList.Images.Count - 1);
                lvi.Tag = new Tag(i);
                seznamBlocku.Items.Add(lvi);
            }
        }
        private NbtCompound RecursiveTagLoad(XmlNode xmlItemTag, NbtCompound tag, List<string> mandatory)
        {
            foreach (XmlNode tagValue in xmlItemTag.SelectNodes("Value"))
            {
                //parametry v tagu itemu
                switch (tagValue.Attributes["type"].InnerText)
                {
                    case "string":
                        tag.Add(new NbtString(tagValue.Attributes["name"].InnerText, tagValue.InnerText));
                        break;
                    case "byte":
                        tag.Add(new NbtByte(tagValue.Attributes["name"].InnerText, byte.Parse(tagValue.InnerText)));
                        break;
                    case "int":
                        tag.Add(new NbtInt(tagValue.Attributes["name"].InnerText, int.Parse(tagValue.InnerText)));
                        break;
                    case "list":
                        tag.Add(new NbtList(tagValue.Attributes["name"].InnerText));
                        foreach (XmlNode tagListValue in tagValue.SelectNodes("Value"))
                        {
                            switch (tagListValue.Attributes["type"].InnerText)
                            {
                                case "string":
                                    tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtString(tagListValue.InnerText));
                                    break;
                                case "byte":
                                    tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtByte(byte.Parse(tagListValue.InnerText)));
                                    break;
                                case "int":
                                    tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtInt(int.Parse(tagListValue.InnerText)));
                                    break;
                                case "compound":
                                    tag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(RecursiveTagLoad(tagListValue, new NbtCompound(), mandatory));
                                    break;
                            }
                        }
                        break;
                    case "compound":
                        tag.Add(RecursiveTagLoad(tagValue, new NbtCompound(tagValue.Attributes["name"].InnerText), mandatory));
                        break;
                }
                if (tagValue.Attributes["req"] != null)
                    mandatory.Add(tagValue.Attributes["name"].InnerText + ";" + tagValue.InnerText);
            }
            return tag;
        }
        void LoadPng()
        {
            soubor.Items.AddRange(Directory.GetFiles(".\\", "*.png", SearchOption.TopDirectoryOnly));
            soubor.SelectedIndexChanged += Soubor_SelectedIndexChanged;
            soubor.SelectedIndex = 0;
        }

        private void Soubor_SelectedIndexChanged(object sender, EventArgs e)
        {
            imageFile.Image = Image.FromFile(soubor.SelectedItem.ToString());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseArgs = (MouseEventArgs)e;
            x.Text = ((mouseArgs.X / 16) + 1).ToString();
            y.Text = ((mouseArgs.Y / 16) + 1).ToString();

            preview.Image = Rozsirujici.Grafika.Obrazek.ResizeBMP(((Bitmap)(imageFile.Image)).Clone(new Rectangle((int.Parse(x.Text) - 1) * 16, (int.Parse(y.Text) - 1) * 16, 16, 16), imageFile.Image.PixelFormat), 64, 64, Rozsirujici.Grafika.Obrazek.PomerStran.Originální, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
        }

        private void seznamBlocku_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (muze)
            {
                if (((ListView)sender).SelectedItems.Count > 0)
                {
                    jmeno.Text = ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.Name;
                    id.Text = ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.ID;
                    numericUpDown1.Value = ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.Stack;
                    maxDamageUpDown.Value = ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.MaxDamage;
                    soubor.SelectedItem = ".\\" + ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.ImageInfo.Split(';')[0];
                    x.Text = ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.ImageInfo.Split(';')[1];
                    y.Text = ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.ImageInfo.Split(';')[2];
                    preview.Image = Rozsirujici.Grafika.Obrazek.ResizeBMP(((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.Image, 64, 64, Rozsirujici.Grafika.Obrazek.PomerStran.Originální, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);
                    changeColor.Checked = ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.ZmenaBarev;
                    for (int i = 0; i < kategorie.Items.Count; i++)
                    {
                        kategorie.Items[i].Checked = false;
                    }
                    foreach (string s in ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.Kategorie)
                    {
                        for (int i = 0; i < kategorie.Items.Count; i++)
                        {
                            if (kategorie.Items[i].Text == s)
                                kategorie.Items[i].Checked = true;
                        }
                    }
                    for (int i = 0; i < sloty.Items.Count; i++)
                    {
                        sloty.Items[i].Checked = false;
                    }
                    if (((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.PovoleneSloty != null)
                    {
                        foreach (byte b in ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.PovoleneSloty)
                        {
                            string s = "";
                            for (int i = 0; i < sloty.Items.Count; i++)
                            {
                                switch (b)
                                {
                                    case 103:
                                        s = "Helma";
                                        break;
                                    case 102:
                                        s = "Tělo";
                                        break;
                                    case 101:
                                        s = "Nohy";
                                        break;
                                    case 100:
                                        s = "Boty";
                                        break;
                                }
                                if (sloty.Items[i].Text == s)
                                    sloty.Items[i].Checked = true;
                            }
                        }
                    }
                    tag.Text = "";
                    if (((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.Tag != null)
                    {
                        string tmpTag = "<Tag>\r\n";
                        tmpTag += "<Value ";
                        foreach (NbtTag ntag in ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.Tag)
                        {
                            switch (ntag.TagType)
                            {
                                case NbtTagType.String:
                                    tmpTag += "type=\"string\" ";
                                    break;
                                case NbtTagType.Byte:
                                    tmpTag += "type=\"byte\" ";
                                    break;
                                case NbtTagType.Int:
                                    tmpTag += "type=\"int\" ";
                                    break;
                                case NbtTagType.List:
                                    tmpTag += "type=\"list\" ";
                                    break;
                                case NbtTagType.Compound:
                                    tmpTag += "type=\"compound\" ";
                                    //rekurzivně pak generovat
                                    break;
                            }

                            tmpTag += "name=\"" + ntag.Name + "\"";
                            foreach (string man in ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.Mandatory)
                            {
                                if (man.Split(';')[0] == ntag.Name)
                                {
                                    tmpTag += " req=\"1\"";
                                    break;
                                }
                            }
                            switch (ntag.TagType)
                            {
                                case NbtTagType.String:
                                    tmpTag += ">" + ntag.StringValue + "</Value>\r\n";
                                    break;
                                case NbtTagType.Byte:
                                    tmpTag += ">" + ntag.ByteValue.ToString() + "</Value>\r\n";
                                    break;
                                case NbtTagType.Int:
                                    tmpTag += ">" + ntag.IntValue.ToString() + "</Value>\r\n";
                                    break;
                                case NbtTagType.List:
                                    tmpTag += ">\r\n";
                                    foreach(NbtTag tmpNtag in ((NbtList)ntag))
                                    {
                                        switch(tmpNtag.TagType)
                                        {
                                            case NbtTagType.Byte:
                                                tmpTag += "<Value type=\"byte\">" + tmpNtag.ByteValue + "</Value>\r\n";
                                                break;
                                            case NbtTagType.Int:
                                                tmpTag += "<Value type=\"int\">" + tmpNtag.IntValue + "</Value>\r\n";
                                                break;
                                            case NbtTagType.String:
                                                tmpTag += "<Value type=\"string\">" + tmpNtag.StringValue + "</Value>\r\n";
                                                break;
                                            case NbtTagType.Compound:
                                                tmpTag += "<Value type=\"compound\">" + "</Value>\r\n";
                                                //rekurzivně pak generovat
                                                break;
                                        }
                                    }
                                    tmpTag += "</Value>\r\n";
                                    break;
                                case NbtTagType.Compound:
                                    tmpTag += ">\r\n" + "</Value>\r\n";
                                    //rekurzivně pak generovat
                                    break;
                            }

                        }
                        tmpTag += "</Tag>";
                        tag.Text = tmpTag;
                    }


                    multiID.Text = "";
                    if (((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.Verze != null)
                    {
                        string tmpMultiId = "<MultipleID>\r\n";
                        foreach (VerzeID vid in ((Tag)(((ListView)sender).SelectedItems[0].Tag)).Item.Verze)
                        {
                            tmpMultiId += "<ID";
                            if (vid.MinVerze > minMcVerze)
                                tmpMultiId += " minVerze=\"" + vid.MinVerze.ToString() + "\"";
                            if (vid.MaxVerze < int.MaxValue)
                                tmpMultiId += " maxVerze=\"" + vid.MaxVerze.ToString() + "\"";
                            tmpMultiId += ">" + vid.ID + "</ID>\r\n";
                        }
                        tmpMultiId += "</MultipleID>";
                        multiID.Text = tmpMultiId;
                    }
                }
            }
        }

        private void ulozit_Click(object sender, EventArgs e)
        {
            if (File.Exists("itemy-old.xml"))
                File.Delete("itemy-old.xml");
            if (File.Exists("itemy.xml"))
                File.Move("itemy.xml", "itemy-old.xml");
            XmlDocument novyDokument = new XmlDocument();
            novyDokument.LoadXml("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<Itemy>\r\n</Itemy>");
            XmlNode verze = novyDokument.CreateElement("Verze");
            verze.InnerText = fileVerze;

            XmlNode minecraft = novyDokument.CreateElement("Minecraft");
            minecraft.Attributes.Append(novyDokument.CreateAttribute("mc"));
            minecraft.Attributes["mc"].Value = mcVerze.ToString(); 
            minecraft.Attributes.Append(novyDokument.CreateAttribute("min"));
            minecraft.Attributes["min"].Value = minMcVerze.ToString();
            minecraft.InnerText = fileText;

            XmlNode itemy = novyDokument.CreateElement("Itemy");
            itemy.Attributes.Append(novyDokument.CreateAttribute("total"));
            itemy.Attributes["total"].Value = seznamBlocku.Items.Count.ToString();

            foreach (ListViewItem lvi in seznamBlocku.Items)
            {
                XmlNode item = novyDokument.CreateElement("Item");
                if(((Tag)lvi.Tag).Item.ZmenaBarev)
                {
                    XmlAttribute attChangeCol = novyDokument.CreateAttribute("canChangeColor");
                    attChangeCol.Value = "1";
                    item.Attributes.Append(attChangeCol);
                }
                if (((Tag)lvi.Tag).Item.Banner)
                {
                    XmlAttribute attBanner = novyDokument.CreateAttribute("banner");
                    attBanner.Value = "1";
                    item.Attributes.Append(attBanner);
                }
                if (((Tag)lvi.Tag).Item.Firework)
                {
                    XmlAttribute attFirework = novyDokument.CreateAttribute("firework");
                    attFirework.Value = "1";
                    item.Attributes.Append(attFirework);
                }
                XmlNode itemID = novyDokument.CreateElement("ID");
                itemID.InnerText = ((Tag)lvi.Tag).Item.ID;
                item.AppendChild(itemID);

                if (((Tag)lvi.Tag).Item.Verze != null)
                {
                    XmlNode itemMultiID = novyDokument.CreateElement("MultipleID");
                    foreach (VerzeID vid in ((Tag)lvi.Tag).Item.Verze)
                    {
                        XmlNode itemMultiIDID = novyDokument.CreateElement("ID");
                        if (vid.MinVerze > minMcVerze)
                        {
                            XmlAttribute attMinVer = novyDokument.CreateAttribute("minVerze");
                            attMinVer.Value = vid.MinVerze.ToString();
                            itemMultiIDID.Attributes.Append(attMinVer);
                        }
                        if (vid.MaxVerze < int.MaxValue)
                        {
                            XmlAttribute attMaxVer = novyDokument.CreateAttribute("maxVerze");
                            attMaxVer.Value = vid.MaxVerze.ToString();
                            itemMultiIDID.Attributes.Append(attMaxVer);
                        }
                        itemMultiIDID.InnerText = vid.ID;
                        itemMultiID.AppendChild(itemMultiIDID);
                    }
                    item.AppendChild(itemMultiID);
                }

                XmlNode itemName = novyDokument.CreateElement("Name");
                itemName.InnerText = ((Tag)lvi.Tag).Item.Name;
                item.AppendChild(itemName);
                XmlNode itemStack = novyDokument.CreateElement("Stack");
                itemStack.InnerText = ((Tag)lvi.Tag).Item.Stack.ToString();
                item.AppendChild(itemStack);

                if (((Tag)lvi.Tag).Item.PovoleneSloty != null)
                {
                    XmlNode itemSloty = novyDokument.CreateElement("PovoleneSloty");
                    if (((Tag)lvi.Tag).Item.PovoleneSloty.Count() == 1)
                    {
                        itemSloty.InnerText = ((Tag)lvi.Tag).Item.PovoleneSloty[0].ToString();
                        item.AppendChild(itemSloty);
                    }
                    else if (((Tag)lvi.Tag).Item.PovoleneSloty.Count() > 1)
                    {
                        itemSloty.InnerText = ((Tag)lvi.Tag).Item.PovoleneSloty[0].ToString();
                        for (int i = 1; i < ((Tag)lvi.Tag).Item.PovoleneSloty.Count(); i++)
                            itemSloty.InnerText += ";" + ((Tag)lvi.Tag).Item.PovoleneSloty[i];
                        item.AppendChild(itemSloty);
                    }
                }

                if(((Tag)lvi.Tag).Item.MaxDamage != -1)
                {
                    XmlNode itemDamage = novyDokument.CreateElement("Damage");
                    itemDamage.InnerText = ((Tag)lvi.Tag).Item.MaxDamage.ToString();
                    item.AppendChild(itemDamage);
                }

                if(((Tag)lvi.Tag).Item.Tag != null)
                {
                    XmlNode itemTag = novyDokument.CreateElement("Tag");
                    foreach(NbtTag ntag in ((Tag)lvi.Tag).Item.Tag)
                    {
                        XmlNode itemTagValue = novyDokument.CreateElement("Value"); 
                        XmlAttribute att = novyDokument.CreateAttribute("type");
                        switch (ntag.TagType)
                        {                                
                            case NbtTagType.String:
                                att.Value = "string";
                                itemTagValue.Attributes.Append(att);
                                break;
                            case NbtTagType.Byte:
                                att.Value = "byte";
                                itemTagValue.Attributes.Append(att);
                                break;
                            case NbtTagType.Int:
                                att.Value = "int";
                                itemTagValue.Attributes.Append(att);
                                break;
                            case NbtTagType.List:
                                att.Value = "list";
                                itemTagValue.Attributes.Append(att);
                                break;
                            case NbtTagType.Compound:
                                att.Value = "compound";
                                itemTagValue.Attributes.Append(att);
                                break;
                        }

                        XmlAttribute attName = novyDokument.CreateAttribute("name");
                        attName.Value = ntag.Name;
                        itemTagValue.Attributes.Append(attName);

                        foreach (string man in ((Tag)lvi.Tag).Item.Mandatory)
                        {
                            if (man.Split(';')[0] == ntag.Name)
                            {
                                XmlAttribute attReq = novyDokument.CreateAttribute("req");
                                attReq.Value = "1";
                                itemTagValue.Attributes.Append(attReq);
                                break;
                            }
                        }

                        switch (ntag.TagType)
                        {
                            case NbtTagType.String:
                                itemTagValue.InnerText = ntag.StringValue;
                                break;
                            case NbtTagType.Byte:
                                itemTagValue.InnerText = ntag.ByteValue.ToString();
                                break;
                            case NbtTagType.Int:
                                itemTagValue.InnerText = ntag.IntValue.ToString();
                                break;
                            case NbtTagType.List:
                                foreach (NbtTag tmpNtag in ((NbtList)ntag))
                                {
                                    XmlNode itemListTagValue = novyDokument.CreateElement("Value");
                                    XmlAttribute listAtt = novyDokument.CreateAttribute("type");
                                    switch (tmpNtag.TagType)
                                    {
                                        case NbtTagType.Byte:
                                            itemListTagValue.Attributes.Append(listAtt);
                                            itemListTagValue.Attributes["type"].Value = "byte";
                                            itemListTagValue.InnerText = tmpNtag.ByteValue.ToString();
                                            break;
                                        case NbtTagType.Int:
                                            itemListTagValue.Attributes.Append(listAtt);
                                            itemListTagValue.Attributes["type"].Value = "int";
                                            itemListTagValue.InnerText = tmpNtag.IntValue.ToString();
                                            break;
                                        case NbtTagType.String:
                                            itemListTagValue.Attributes.Append(listAtt);
                                            itemListTagValue.Attributes["type"].Value = "string";
                                            itemListTagValue.InnerText = tmpNtag.StringValue;
                                            break;
                                        case NbtTagType.Compound:
                                            itemListTagValue.Attributes.Append(listAtt);
                                            itemListTagValue.Attributes["type"].Value = "compound";
                                            //rekurzivně generovat
                                            break;
                                    }
                                    itemTagValue.AppendChild(itemListTagValue);
                                }
                                break;
                            case NbtTagType.Compound:
                                //rekurzivně generovat
                                break;
                        }
                        itemTag.AppendChild(itemTagValue);
                    }
                    item.AppendChild(itemTag);
                }

                XmlNode itemImage = novyDokument.CreateElement("Image");
                XmlNode itemImageX = novyDokument.CreateElement("X");
                itemImageX.InnerText = ((Tag)lvi.Tag).Item.ImageInfo.Split(';')[1];
                itemImage.AppendChild(itemImageX);
                XmlNode itemImageY = novyDokument.CreateElement("Y");
                itemImageY.InnerText = ((Tag)lvi.Tag).Item.ImageInfo.Split(';')[2];
                itemImage.AppendChild(itemImageY);
                XmlNode itemImagePath = novyDokument.CreateElement("File");
                itemImagePath.InnerText = ((Tag)lvi.Tag).Item.ImageInfo.Split(';')[0];
                itemImage.AppendChild(itemImagePath);
                item.AppendChild(itemImage);
                XmlNode itemKategorie = novyDokument.CreateElement("Kategorie");
                if (((Tag)lvi.Tag).Item.Kategorie.Count() == 1)
                {
                    itemKategorie.InnerText = ((Tag)lvi.Tag).Item.Kategorie[0];
                    item.AppendChild(itemKategorie);
                }
                else if (((Tag)lvi.Tag).Item.Kategorie.Count() > 1)
                {
                    itemKategorie.InnerText = ((Tag)lvi.Tag).Item.Kategorie[0];
                    for(int i = 1; i< ((Tag)lvi.Tag).Item.Kategorie.Count(); i++)
                        itemKategorie.InnerText += ";" + ((Tag)lvi.Tag).Item.Kategorie[i];
                    item.AppendChild(itemKategorie);
                }
                itemy.AppendChild(item);
            }

            novyDokument.SelectSingleNode("Itemy").AppendChild(verze);
            novyDokument.SelectSingleNode("Itemy").AppendChild(minecraft);
            novyDokument.SelectSingleNode("Itemy").AppendChild(itemy);

            novyDokument.Save("itemy.xml");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(seznamBlocku.SelectedItems.Count > 0)
            {
                int maxDamage = (int)maxDamageUpDown.Value;
                string[] cat = new string[kategorie.CheckedItems.Count];

                for(int i = 0; i < kategorie.CheckedItems.Count; i++)
                {
                    cat[i] = kategorie.CheckedItems[i].Text;
                }
                byte[] povSloty = new byte[sloty.CheckedItems.Count];

                for (int i = 0; i < sloty.CheckedItems.Count; i++)
                {
                    switch(sloty.CheckedItems[i].Text)
                    {
                        case "Helma":
                            povSloty[i] = 103;
                            break;
                        case "Tělo":
                            povSloty[i] = 102;
                            break;
                        case "Nohy":
                            povSloty[i] = 101;
                            break;
                        case "Boty":
                            povSloty[i] = 100;
                            break;
                    }
                    
                }

                NbtCompound nbtTag = null;
                bool vlastnostiItemu = false;
                List<string> mandatory = null;

                if (tag.Text != "")
                {
                    mandatory = new List<string>();
                    XmlDocument xmlItem = new XmlDocument();
                    xmlItem.LoadXml(tag.Text);

                    vlastnostiItemu = true;
                    nbtTag = new NbtCompound("tag");
                    foreach (XmlNode tagValue in xmlItem.SelectNodes("Tag/Value"))
                    {
                        //parametry v tagu itemu
                        switch (tagValue.Attributes["type"].InnerText)
                        {
                            case "string":
                                nbtTag.Add(new NbtString(tagValue.Attributes["name"].InnerText, tagValue.InnerText));
                                break;
                            case "byte":
                                nbtTag.Add(new NbtByte(tagValue.Attributes["name"].InnerText, byte.Parse(tagValue.InnerText)));
                                break;
                            case "int":
                                nbtTag.Add(new NbtInt(tagValue.Attributes["name"].InnerText, int.Parse(tagValue.InnerText)));
                                break;
                            case "list":
                                nbtTag.Add(new NbtList(tagValue.Attributes["name"].InnerText));
                                foreach (XmlNode tagListValue in tagValue.SelectNodes("Value"))
                                {
                                    switch (tagListValue.Attributes["type"].InnerText)
                                    {
                                        case "string":
                                            nbtTag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtString(tagListValue.InnerText));
                                            break;
                                        case "byte":
                                            nbtTag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtByte(byte.Parse(tagListValue.InnerText)));
                                            break;
                                        case "int":
                                            nbtTag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtInt(int.Parse(tagListValue.InnerText)));
                                            break;
                                        case "compound":
                                            nbtTag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(RecursiveTagLoad(tagListValue, new NbtCompound(), mandatory));
                                            break;
                                    }
                                }
                                break;
                            case "compound":
                                nbtTag.Add(RecursiveTagLoad(tagValue, new NbtCompound(tagValue.Attributes["name"].InnerText), mandatory));
                                break;
                        }
                        if (tagValue.Attributes["req"] != null)
                            mandatory.Add(tagValue.Attributes["name"].InnerText + ";" + tagValue.InnerText);
                    }
                }

                List<VerzeID> multiVerzeList = null;

                if(multiID.Text != "")
                {
                    multiVerzeList = new List<VerzeID>();
                    XmlDocument xmlItem = new XmlDocument();
                    xmlItem.LoadXml(multiID.Text);

                    foreach (XmlNode multID in xmlItem.SelectNodes("MultipleID/ID"))
                    {
                        int minVerze = 0;
                        int maxVerze = int.MaxValue;

                        if (multID.Attributes["minVerze"] != null)
                        {
                            minVerze = int.Parse(multID.Attributes["minVerze"].Value);
                        }

                        if (multID.Attributes["maxVerze"] != null)
                        {
                            maxVerze = int.Parse(multID.Attributes["maxVerze"].Value);
                        }

                        multiVerzeList.Add(new VerzeID(minVerze, maxVerze, multID.InnerText));
                    }
                }
                seznamBlocku.SelectedItems[0].Text = jmeno.Text;

                Bitmap imagePrev = Rozsirujici.Grafika.Obrazek.ResizeBMP((Bitmap)preview.Image, 16, 16, Rozsirujici.Grafika.Obrazek.PomerStran.Originální, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);

                seznamBlocku.SmallImageList.Images.Add(imagePrev);
                seznamBlocku.SelectedItems[0].ImageIndex = seznamBlocku.SmallImageList.Images.Count - 1;

                ((Tag)(seznamBlocku.SelectedItems[0].Tag)).Item.ChangeItemEditor(jmeno.Text, id.Text, maxDamage, 
                    (byte)numericUpDown1.Value, soubor.SelectedItem.ToString().Replace(".\\", "") + ";" + x.Text + ";" + y.Text, cat, povSloty, 
                    changeColor.Checked, nbtTag, mandatory, vlastnostiItemu, imagePrev, multiVerzeList);
            }
        }

        private void addTag_Click(object sender, EventArgs e)
        {
            tag.Text = "<Tag>\r\n<Value type=\"typ\" name=\"Jméno\" req=\"1\">minecraft:id_itemu</Value>\r\n</Tag>";
        }

        private void addId_Click(object sender, EventArgs e)
        {
            multiID.Text = "<MultipleID>\r\n<ID maxVerze=\"200\">minecraft:nejstarsi_id</ID>\r\n<ID minVerze=\"200\" maxVerze=\"1901\">minecraft:stare_id</ID>\r\n<ID minVerze=\"1901\">minecraft:nove_id</ID>\r\n</MultipleID>";
        }

        private void bridat_Click(object sender, EventArgs e)
        {
            int maxDamage = (int)maxDamageUpDown.Value;
            string[] cat = new string[kategorie.CheckedItems.Count];

            for (int ii = 0; ii < kategorie.CheckedItems.Count; ii++)
            {
                cat[ii] = kategorie.CheckedItems[ii].Text;
            }
            byte[] povSloty = new byte[sloty.CheckedItems.Count];

            for (int ii = 0; ii < sloty.CheckedItems.Count; ii++)
            {
                switch (sloty.CheckedItems[ii].Text)
                {
                    case "Helma":
                        povSloty[ii] = 103;
                        break;
                    case "Tělo":
                        povSloty[ii] = 102;
                        break;
                    case "Nohy":
                        povSloty[ii] = 101;
                        break;
                    case "Boty":
                        povSloty[ii] = 100;
                        break;
                }

            }

            NbtCompound nbtTag = null;
            bool vlastnostiItemu = false;
            List<string> mandatory = null;

            if (tag.Text != "")
            {
                mandatory = new List<string>();
                XmlDocument xmlItem = new XmlDocument();
                xmlItem.LoadXml(tag.Text);

                vlastnostiItemu = true;
                nbtTag = new NbtCompound("tag");
                foreach (XmlNode tagValue in xmlItem.SelectNodes("Tag/Value"))
                {
                    //parametry v tagu itemu
                    switch (tagValue.Attributes["type"].InnerText)
                    {
                        case "string":
                            nbtTag.Add(new NbtString(tagValue.Attributes["name"].InnerText, tagValue.InnerText));
                            break;
                        case "byte":
                            nbtTag.Add(new NbtByte(tagValue.Attributes["name"].InnerText, byte.Parse(tagValue.InnerText)));
                            break;
                        case "int":
                            nbtTag.Add(new NbtInt(tagValue.Attributes["name"].InnerText, int.Parse(tagValue.InnerText)));
                            break;
                        case "list":
                            nbtTag.Add(new NbtList(tagValue.Attributes["name"].InnerText));
                            foreach (XmlNode tagListValue in tagValue.SelectNodes("Value"))
                            {
                                switch (tagListValue.Attributes["type"].InnerText)
                                {
                                    case "string":
                                        nbtTag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtString(tagListValue.InnerText));
                                        break;
                                    case "byte":
                                        nbtTag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtByte(byte.Parse(tagListValue.InnerText)));
                                        break;
                                    case "int":
                                        nbtTag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(new NbtInt(int.Parse(tagListValue.InnerText)));
                                        break;
                                    case "compound":
                                        nbtTag.Get<NbtList>(tagValue.Attributes["name"].InnerText).Add(RecursiveTagLoad(tagListValue, new NbtCompound(), mandatory));
                                        break;
                                }
                            }
                            break;
                        case "compound":
                            nbtTag.Add(RecursiveTagLoad(tagValue, new NbtCompound(tagValue.Attributes["name"].InnerText), mandatory));
                            break;
                    }
                    if (tagValue.Attributes["req"] != null)
                        mandatory.Add(tagValue.Attributes["name"].InnerText + ";" + tagValue.InnerText);
                }
            }

            List<VerzeID> multiVerzeList = null;

            if (multiID.Text != "")
            {
                multiVerzeList = new List<VerzeID>();
                XmlDocument xmlItem = new XmlDocument();
                xmlItem.LoadXml(multiID.Text);

                foreach (XmlNode multID in xmlItem.SelectNodes("MultipleID/ID"))
                {
                    int minVerze = 0;
                    int maxVerze = int.MaxValue;

                    if (multID.Attributes["minVerze"] != null)
                    {
                        minVerze = int.Parse(multID.Attributes["minVerze"].Value);
                    }

                    if (multID.Attributes["maxVerze"] != null)
                    {
                        maxVerze = int.Parse(multID.Attributes["maxVerze"].Value);
                    }

                    multiVerzeList.Add(new VerzeID(minVerze, maxVerze, multID.InnerText));
                }
            }

            Bitmap imagePrev = Rozsirujici.Grafika.Obrazek.ResizeBMP((Bitmap)preview.Image, 16, 16, Rozsirujici.Grafika.Obrazek.PomerStran.Originální, System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor);

            seznamBlocku.SmallImageList.Images.Add(imagePrev);
            Item i = new Item(jmeno.Text, id.Text, 0, maxDamage, (byte)numericUpDown1.Value, (byte)numericUpDown1.Value, 0, nbtTag, cat, povSloty, imagePrev, null, changeColor.Checked, bannerBox.Checked, fireworkBox.Checked, vlastnostiItemu, mandatory, soubor.SelectedItem.ToString().Replace(".\\", "") + ";" + x.Text + ";" + y.Text);

            ListViewItem lvi = new ListViewItem(i.Name, seznamBlocku.SmallImageList.Images.Count - 1);
            lvi.Tag = new Tag(i);
            seznamBlocku.Items.Add(lvi);

            ((Tag)(seznamBlocku.Items[seznamBlocku.Items.Count-1].Tag)).Item.ChangeItemEditor(jmeno.Text, id.Text, maxDamage,
                (byte)numericUpDown1.Value, soubor.SelectedItem.ToString().Replace(".\\", "") + ";" + x.Text + ";" + y.Text, cat, povSloty,
                changeColor.Checked, nbtTag, mandatory, vlastnostiItemu, imagePrev, multiVerzeList);
            muze = false;
            seznamBlocku.Items[seznamBlocku.Items.Count - 1].Focused = true;
            seznamBlocku.Items[seznamBlocku.Items.Count - 1].Selected = true;
            seznamBlocku.Items[seznamBlocku.Items.Count - 1].EnsureVisible();
            muze = true;
        }

        private enum MoveDirection { Up = -1, Down = 1 };

        private static void MoveListViewItems(ListView sender, MoveDirection direction)
        {
            int dir = (int)direction;
            int opp = dir * -1;

            bool valid = sender.SelectedItems.Count > 0 &&
                            ((direction == MoveDirection.Down && (sender.SelectedItems[sender.SelectedItems.Count - 1].Index < sender.Items.Count - 1))
                        || (direction == MoveDirection.Up && (sender.SelectedItems[0].Index > 0)));

            if (valid)
            {
                foreach (ListViewItem item in sender.SelectedItems)
                {
                    int index = item.Index + dir;
                    sender.Items.RemoveAt(item.Index);
                    sender.Items.Insert(index, item);
                    sender.Items[index-dir].Focused = true;
                    sender.Items[index-dir].Selected = true;
                    //sender.Items[index + opp].SubItems[1].Text = (index + opp).ToString();
                    //item.SubItems[1].Text = (index).ToString();
                }
            }
        }
        private void seznamBlocku_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Up && e.Modifiers == Keys.Control)
            {
                muze = false;
                MoveListViewItems((ListView)sender, MoveDirection.Up);
                muze = true;
            }
            else if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Control)
            {
                muze = false;
                MoveListViewItems((ListView)sender, MoveDirection.Down);
                muze = true;
            }
        }
    }
}
