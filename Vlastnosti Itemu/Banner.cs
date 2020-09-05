using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using LibNbt;

namespace SaveEdit
{
    public partial class VlastnostiItemu
    {
        internal int index2;
        private Color KontrastniBarva(Color color)
        {
            int d = 0;

            // Counting the perceptive luminance - human eye favors green color... 
            double a = 1 - (0.299 * color.R + 0.587 * color.G + 0.114 * color.B) / 255;

            if (a < 0.5)
                d = 0; // bright colors - black font
            else
                d = 255; // dark colors - white font

            return Color.FromArgb(d, d, d);
        }

        internal Bitmap NovyBanner()
        {
            patternyView.Items.Clear();
            Bitmap banner = new Bitmap(20,40);
            int barvaB = 0;
            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base") != null)
            {
                barvaB = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtInt>("Base").Value;
            }
            else
                barvaB = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtShort>("Damage").Value;
            switch (barvaB)
            {
                case 0:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(25, 22, 22));
                        }
                    break;
                case 1:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(150, 52, 48));
                        }
                    
                    break;
                case 2:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(53, 70, 27));
                        }
                    
                    break;
                case 3:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(79, 50, 31));
                        }
                    
                    break;
                case 4:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(46, 56, 141));
                        }
                    
                    break;
                case 5:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(126, 61, 181));
                        }
                    
                    break;
                case 6:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(46, 110, 137));
                        }
                    
                    break;
                case 7:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(154, 161, 161));
                        }
                   
                    break;
                case 8:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(64, 64, 64));
                        }
                    
                    break;
                case 9:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(208, 132, 153));
                        }
                    
                    break;
                case 10:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(65, 174, 56));
                        }
                    
                    break;
                case 11:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(177, 166, 39));
                        }
                    
                    break;
                case 12:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(107, 138, 201));
                        }
                    
                    break;
                case 13:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(179, 80, 188));
                        }
                    
                    break;
                case 14:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(219, 125, 62));
                        }
                    
                    break;
                case 15:
                    for (int x = 0; x < banner.Width; x++)
                        for (int y = 0; y < banner.Height; y++)
                        {
                            banner.SetPixel(x, y, Color.FromArgb(221, 221, 221));
                        }
                    
                    break;
            }

            banner = form.ResizeBMP(banner, 100, 200);

            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") != null)
            {
                if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") != null)
                {
                    if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns") != null)
                    {
                        NbtList patterny = form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns");

                        foreach (NbtCompound c in patterny)
                        {
                            Color barva;
                            switch (c.Get<NbtInt>("Color").Value)
                            {
                                case 0:
                                    barva = Color.FromArgb(25, 22, 22);
                                    break;
                                case 1:
                                    barva = Color.FromArgb(150, 52, 48);
                                    break;
                                case 2:
                                    barva = Color.FromArgb(53, 70, 27);
                                    break;
                                case 3:
                                    barva = Color.FromArgb(79, 50, 31);
                                    break;
                                case 4:
                                    barva = Color.FromArgb(46, 56, 141);
                                    break;
                                case 5:
                                    barva = Color.FromArgb(126, 61, 181);
                                    break;
                                case 6:
                                    barva = Color.FromArgb(46, 110, 137);
                                    break;
                                case 7:
                                    barva = Color.FromArgb(154, 161, 161);
                                    break;
                                case 8:
                                    barva = Color.FromArgb(64, 64, 64);
                                    break;
                                case 9:
                                    barva = Color.FromArgb(208, 132, 153);
                                    break;
                                case 10:
                                    barva = Color.FromArgb(65, 174, 56);
                                    break;
                                case 11:
                                    barva = Color.FromArgb(177, 166, 39);
                                    break;
                                case 12:
                                    barva = Color.FromArgb(107, 138, 201);
                                    break;
                                case 13:
                                    barva = Color.FromArgb(179, 80, 188);
                                    break;
                                case 14:
                                    barva = Color.FromArgb(219, 125, 62);
                                    break;
                                case 15:
                                    barva = Color.FromArgb(221, 221, 221);
                                    break;
                                default:
                                    barva = Color.FromArgb(25, 22, 22);
                                    break;
                            }

                            switch (c.Get<NbtString>("Pattern").Value)
                            {
                                case "gra":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.gradient);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Gradient_dolu_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "gru":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.gradient_up);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Gradient_nahoru_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "tt":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.triangle_top);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Trojuhelnik_nahore_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "cre":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.creeper);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Creeper));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "sku":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.skull);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Lebka));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "flo":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.flower);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Kvetina));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "bri":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.bricks);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Cihly));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "mc":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.circle);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Kruh));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "tr":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.square_top_right);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Ctverec_vpravo_nahore_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "tl":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.square_top_left);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Ctverec_vlevo_nahore_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "bl":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.square_bottom_left);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Ctverec_vlevo_dole_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "br":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.square_bottom_right);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Ctverec_vpravo_dole));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "bt":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.triangle_bottom);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Trojuhelnik_dole_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "dls":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.stripe_downleft);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Pruh_doleva_dolu_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "drs":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.stripe_downright);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Pruh_doprava_dolu_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "cr":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.cross);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Kriz));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "tts":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.triangles_top);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Horni_zuby_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "bts":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.triangles_bottom);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Dolni_zuby_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "ms":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.stripe_middle);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Vodorovny_pruh_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "cs":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.stripe_center);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Svisly_pruh_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "mr":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.rhombus);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Kosoctverec_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "ts":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.stripe_top);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Horni_pruh_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "bs":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.stripe_bottom);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Dolni_pruh_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "hh":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.half_horizontal);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Horni_pulka_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "hhb":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.half_horizontal_bottom);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Dolni_pulka_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "ss":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.small_stripes);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Pruhy_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "ls":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.stripe_left);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Levy_pruh_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "rs":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.stripe_right);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Pravy_pruh_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "vh":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.half_vertical);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Leva_pulka_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "vhr":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.half_vertical_right);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Prava_pulka_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "lud":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.diagonal_left);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Leva_horni_pulka_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "rud":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.diagonal_right);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Prava_horni_pulka_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "ld":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.diagonal_up_left);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Leva_dolni_pulka_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "rd":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.diagonal_up_right);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Prava_dolni_pulka_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "bo":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.border);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Ramecek_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "cbo":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.curly_border);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Vlnity_ram_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                                case "sc":
                                    banner = PridejPatternu(banner, barva, Properties.Resources.straight_cross);
                                    patternyView.Items.Add(new ListViewItem(Jazyk.Strings.Rovny_kriz_d));
                                    patternyView.Items[patternyView.Items.Count - 1].BackColor = barva;
                                    patternyView.Items[patternyView.Items.Count - 1].ForeColor = KontrastniBarva(barva);
                                    break;
                            }
                        }
                    }
                }
            }

            return banner;
        }
        private Bitmap PridejPatternu(Bitmap bitmapa, Color barva, Bitmap patterna)
        {
            Graphics g = Graphics.FromImage((Image)bitmapa);

            for (int x = 0; x < patterna.Width; x++)
                for (int y = 0; y < patterna.Height; y++)
                {
                    patterna.SetPixel(x, y, Color.FromArgb(patterna.GetPixel(x, y).A, barva.R, barva.G, barva.B));
                }

            patterna = form.ResizeBMP(patterna, 100, 200);

            g.DrawImage(patterna, 0, 0);
            g.Dispose();
            g = null;
            return bitmapa;
        }

        private void patternyView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(patternyView.SelectedIndices.Count != 0)
            {
                int index = index2 = patternyView.Items.IndexOf(patternyView.SelectedItems[0]);
                zmenitBarvu.Enabled = true;
                smazat.Enabled = true;
                if (patternyView.SelectedIndices[0] == 0)
                {
                    nahoru.Enabled = false;
                    if (patternyView.Items.Count != 1)
                        dolu.Enabled = true;
                    else
                        dolu.Enabled = false;
                }
                else if (patternyView.SelectedIndices[0] == (patternyView.Items.Count - 1))
                {
                    nahoru.Enabled = true;
                    dolu.Enabled = false;
                }
                else
                {
                    dolu.Enabled = true;
                    nahoru.Enabled = true;
                }
            }
            else
            {
                dolu.Enabled = false;
                nahoru.Enabled = false;
                zmenitBarvu.Enabled = false;
                smazat.Enabled = false;
            }
        }

        private void nahoru_Click(object sender, EventArgs e)
        {
            form.NeulozenoMetoda();
            int index = index2 = patternyView.Items.IndexOf(patternyView.SelectedItems[0]);
            ListViewItem i = patternyView.Items[index - 1];
            patternyView.Items[index - 1] = new ListViewItem();
            NbtCompound c = new NbtCompound();
            c.Add(new NbtInt("Color", form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(index - 1).Get<NbtInt>("Color").Value));
            c.Add(new NbtString("Pattern", form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(index - 1).Get<NbtString>("Pattern").Value));
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns")[index - 1] = new NbtCompound();
            ListViewItem ii = patternyView.Items[index];
            patternyView.Items[index] = new ListViewItem();
            NbtCompound cc = new NbtCompound();
            cc.Add(new NbtInt("Color", form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(index).Get<NbtInt>("Color").Value));
            cc.Add(new NbtString("Pattern", form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(index).Get<NbtString>("Pattern").Value));
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns")[index] = new NbtCompound(); ;
            patternyView.Items[index - 1] = ii;
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns")[index - 1] = cc;
            patternyView.Items[index] = i;
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns")[index] = c;
            bannerNahled.Image = NovyBanner();
            patternyView.Items[index - 1].Selected = true;
            patternyView.Select();
        }

        private void dolu_Click(object sender, EventArgs e)
        {
            form.NeulozenoMetoda();
            int index = index2 = patternyView.Items.IndexOf(patternyView.SelectedItems[0]);
            ListViewItem i = patternyView.Items[index + 1];
            patternyView.Items[index + 1] = new ListViewItem();
            NbtCompound c = new NbtCompound();
            c.Add(new NbtInt("Color", form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(index + 1).Get<NbtInt>("Color").Value));
            c.Add(new NbtString("Pattern", form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(index + 1).Get<NbtString>("Pattern").Value));
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns")[index + 1] = new NbtCompound();
            ListViewItem ii = patternyView.Items[index];
            patternyView.Items[index] = new ListViewItem();
            NbtCompound cc = new NbtCompound();
            cc.Add(new NbtInt("Color", form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(index).Get<NbtInt>("Color").Value));
            cc.Add(new NbtString("Pattern", form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Get<NbtCompound>(index).Get<NbtString>("Pattern").Value));
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns")[index] = new NbtCompound(); ;
            patternyView.Items[index + 1] = ii;
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns")[index + 1] = cc;
            patternyView.Items[index] = i;
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns")[index] = c;
            bannerNahled.Image = NovyBanner();
            patternyView.Items[index + 1].Selected = true;
            patternyView.Select();
        }

        private void pridatPatternu_Click(object sender, EventArgs e)
        {
            form.NeulozenoMetoda();
            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag") == null)
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Add(new NbtCompound("tag"));
            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag") == null)
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Add(new NbtCompound("BlockEntityTag"));
            if (form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns") == null)
                form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Add(new NbtList("Patterns", NbtTagType.Compound));

            if (ramecek.Checked)
            {
                AddPattern("bo");
            }
            else if (creeper.Checked)
            {
                AddPattern("cre");
            }
            else if (lebka.Checked)
                AddPattern("sku");
            else if (kvetina.Checked)
                AddPattern("flo");
            else if (cihly.Checked)
                AddPattern("bri");
            else if (kruh.Checked)
                AddPattern("mc");
            else if (ctverecPH.Checked)
                AddPattern("tr");
            else if (ctverecLH.Checked)
                AddPattern("tl");
            else if (ctverecLD.Checked)
                AddPattern("bl");
            else if (ctverecPD.Checked)
                AddPattern("br");
            else if (trojH.Checked)
                AddPattern("tt");
            else if (trojD.Checked)
                AddPattern("bt");
            else if (pruhLD.Checked)
                AddPattern("dls");
            else if (pruhPD.Checked)
                AddPattern("drs");
            else if (kriz.Checked)
                AddPattern("cr");
            else if (zubyH.Checked)
                AddPattern("tts");
            else if (zubyD.Checked)
                AddPattern("bts");
            else if (shPruh.Checked)
                AddPattern("ms");
            else if (svPruh.Checked)
                AddPattern("cs");
            else if (kosoc.Checked)
                AddPattern("mr");
            else if (hPruh.Checked)
                AddPattern("ts");
            else if (hPulka.Checked)
                AddPattern("hh");
            else if (dPruh.Checked)
                AddPattern("bs");
            else if (dPulka.Checked)
                AddPattern("hhb");
            else if (pruhy.Checked)
                AddPattern("ss");
            else if (lPruh.Checked)
                AddPattern("ls");
            else if (pPruh.Checked)
                AddPattern("rs");
            else if (lPulka.Checked)
                AddPattern("vh");
            else if (pPulka.Checked)
                AddPattern("vhr");
            else if (lhPulka.Checked)
                AddPattern("lud");
            else if (phPulka.Checked)
                AddPattern("rud");
            else if (pdPulka.Checked)
                AddPattern("rd");
            else if (ldPulka.Checked)
                AddPattern("ld");
            else if (gradientDolu.Checked)
                AddPattern("gra");
            else if (gradientH.Checked)
                AddPattern("gru");
            else if (vlnRam.Checked)
                AddPattern("cbo");
            else if (rovKriz.Checked)
                AddPattern("sc");
            patternyView.Items[patternyView.Items.Count - 1].Selected = true;
            patternyView.Select();
        }

        private void zmenitBarvu_Click(object sender, EventArgs e)
        {
            BarvyBanner barvy = new BarvyBanner(form, this);
            DialogResult di = barvy.ShowDialog();
            patternyView.Items[index2].Selected = true;
            patternyView.Select();
        }

        private void AddPattern(string patt)
        {
            NbtCompound c = new NbtCompound();
            c.Add(new NbtInt("Color", 0));
            c.Add(new NbtString("Pattern", patt));
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").Add(c);
            bannerNahled.Image = NovyBanner();
            patternyView.Items[patternyView.Items.Count - 1].Selected = true;
            patternyView.Select();
        }

        private void smazat_Click(object sender, EventArgs e)
        {
            form.NeulozenoMetoda();
            int index = index2 = patternyView.Items.IndexOf(patternyView.SelectedItems[0]);
            form.save.RootTag.Get<NbtCompound>("Data").Get<NbtCompound>("Player").Get<NbtList>("Inventory").Get<NbtCompound>(item).Get<NbtCompound>("tag").Get<NbtCompound>("BlockEntityTag").Get<NbtList>("Patterns").RemoveAt(index);
            bannerNahled.Image = NovyBanner();
            if (patternyView.Items.Count > 0)
            {
                if (patternyView.Items.Count > index)
                    patternyView.Items[index].Selected = true;
                else if (patternyView.Items.Count > 1)
                    patternyView.Items[index - 1].Selected = true;
                else
                    patternyView.Items[0].Selected = true;
                patternyView.Select();
            }
            else
            {
                smazat.Enabled = false;
                zmenitBarvu.Enabled = false;
            }
        }
    }
}
