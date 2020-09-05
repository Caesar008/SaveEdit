namespace SaveEdit
{
    partial class NovyItem
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.jmeno = new System.Windows.Forms.TextBox();
            this.cesta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.najit = new System.Windows.Forms.Button();
            this.otevritObrazek = new System.Windows.Forms.OpenFileDialog();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.TextBox();
            this.y = new System.Windows.Forms.TextBox();
            this.stackovatelny = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.poskozeni = new System.Windows.Forms.TextBox();
            this.ok = new System.Windows.Forms.Button();
            this.pridanyItemInfo = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.materialy = new System.Windows.Forms.CheckBox();
            this.lektvary = new System.Windows.Forms.CheckBox();
            this.bojove = new System.Windows.Forms.CheckBox();
            this.nastroje = new System.Windows.Forms.CheckBox();
            this.jidlo = new System.Windows.Forms.CheckBox();
            this.ruzne = new System.Windows.Forms.CheckBox();
            this.doprava = new System.Windows.Forms.CheckBox();
            this.redstone = new System.Windows.Forms.CheckBox();
            this.dekorace = new System.Windows.Forms.CheckBox();
            this.stavebni = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.stringID = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = Jazyk.Strings.Jmeno + " *";
            // 
            // jmeno
            // 
            this.jmeno.Location = new System.Drawing.Point(111, 12);
            this.jmeno.Name = "jmeno";
            this.jmeno.Size = new System.Drawing.Size(135, 20);
            this.jmeno.TabIndex = 1;
            // 
            // cesta
            // 
            this.cesta.BackColor = System.Drawing.Color.White;
            this.cesta.Location = new System.Drawing.Point(111, 66);
            this.cesta.Name = "cesta";
            this.cesta.ReadOnly = true;
            this.cesta.Size = new System.Drawing.Size(135, 20);
            this.cesta.TabIndex = 2;
            this.cesta.Click += new System.EventHandler(this.cesta_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = Jazyk.Strings.Soubor_s_obrazkem + " *";
            // 
            // najit
            // 
            this.najit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.najit.Location = new System.Drawing.Point(252, 64);
            this.najit.Name = "najit";
            this.najit.Size = new System.Drawing.Size(75, 23);
            this.najit.TabIndex = 4;
            this.najit.Text = Jazyk.Strings.Najit;
            this.najit.UseVisualStyleBackColor = true;
            this.najit.Click += new System.EventHandler(this.najit_Click);
            // 
            // otevritObrazek
            // 
            this.otevritObrazek.Filter = Jazyk.Strings.Obrazek + " PNG|*.png|" + Jazyk.Strings.Obrazek + " JPG|*.jpg|" + Jazyk.Strings.Bitmapa + "|*.bmp";
            this.otevritObrazek.FileOk += new System.ComponentModel.CancelEventHandler(this.otevritObrazek_FileOk);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(155, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = Jazyk.Strings.Zleva + " *";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = Jazyk.Strings.Poradi_obrazku;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(200, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = Jazyk.Strings.Shora + " *";
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(158, 105);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(31, 20);
            this.x.TabIndex = 8;
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(203, 105);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(31, 20);
            this.y.TabIndex = 9;
            // 
            // stackovatelny
            // 
            this.stackovatelny.AutoSize = true;
            this.stackovatelny.Location = new System.Drawing.Point(10, 126);
            this.stackovatelny.Name = "stackovatelny";
            this.stackovatelny.Size = new System.Drawing.Size(94, 17);
            this.stackovatelny.TabIndex = 10;
            this.stackovatelny.Text = Jazyk.Strings.Stackovatelny;
            this.stackovatelny.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = Jazyk.Strings.Maximalni_poskozeni + " *";
            // 
            // poskozeni
            // 
            this.poskozeni.Location = new System.Drawing.Point(128, 143);
            this.poskozeni.Name = "poskozeni";
            this.poskozeni.Size = new System.Drawing.Size(125, 20);
            this.poskozeni.TabIndex = 12;
            this.poskozeni.Text = "0";
            // 
            // ok
            // 
            this.ok.Location = new System.Drawing.Point(257, 319);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 13;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.ok_Click);
            // 
            // pridanyItemInfo
            // 
            this.pridanyItemInfo.AutoSize = true;
            this.pridanyItemInfo.Location = new System.Drawing.Point(12, 309);
            this.pridanyItemInfo.Name = "pridanyItemInfo";
            this.pridanyItemInfo.Size = new System.Drawing.Size(188, 13);
            this.pridanyItemInfo.TabIndex = 14;
            this.pridanyItemInfo.Text = "upozornění na itemy něco nevyplněno";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(240, 108);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "(" + Jazyk.Strings.Rozmer + " 16 x16 px)";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(25, 13);
            this.label8.TabIndex = 16;
            this.label8.Text = "ID *";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(281, 12);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(51, 20);
            this.id.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.materialy);
            this.groupBox1.Controls.Add(this.lektvary);
            this.groupBox1.Controls.Add(this.bojove);
            this.groupBox1.Controls.Add(this.nastroje);
            this.groupBox1.Controls.Add(this.jidlo);
            this.groupBox1.Controls.Add(this.ruzne);
            this.groupBox1.Controls.Add(this.doprava);
            this.groupBox1.Controls.Add(this.redstone);
            this.groupBox1.Controls.Add(this.dekorace);
            this.groupBox1.Controls.Add(this.stavebni);
            this.groupBox1.Location = new System.Drawing.Point(73, 169);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(185, 137);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = Jazyk.Strings.Kategorie;
            // 
            // materialy
            // 
            this.materialy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.materialy.AutoSize = true;
            this.materialy.Location = new System.Drawing.Point(99, 111);
            this.materialy.Name = "materialy";
            this.materialy.Size = new System.Drawing.Size(68, 17);
            this.materialy.TabIndex = 9;
            this.materialy.Text = Jazyk.Strings.Materialy;
            this.materialy.UseVisualStyleBackColor = true;
            // 
            // lektvary
            // 
            this.lektvary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lektvary.AutoSize = true;
            this.lektvary.Location = new System.Drawing.Point(99, 88);
            this.lektvary.Name = "lektvary";
            this.lektvary.Size = new System.Drawing.Size(67, 17);
            this.lektvary.TabIndex = 8;
            this.lektvary.Text = Jazyk.Strings.Lektvary;
            this.lektvary.UseVisualStyleBackColor = true;
            // 
            // bojove
            // 
            this.bojove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.bojove.AutoSize = true;
            this.bojove.Location = new System.Drawing.Point(99, 65);
            this.bojove.Name = "bojove";
            this.bojove.Size = new System.Drawing.Size(60, 17);
            this.bojove.TabIndex = 7;
            this.bojove.Text = Jazyk.Strings.Zbrane;
            this.bojove.UseVisualStyleBackColor = true;
            // 
            // nastroje
            // 
            this.nastroje.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nastroje.AutoSize = true;
            this.nastroje.Location = new System.Drawing.Point(99, 42);
            this.nastroje.Name = "nastroje";
            this.nastroje.Size = new System.Drawing.Size(65, 17);
            this.nastroje.TabIndex = 6;
            this.nastroje.Text = Jazyk.Strings.Nastroje;
            this.nastroje.UseVisualStyleBackColor = true;
            // 
            // jidlo
            // 
            this.jidlo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.jidlo.AutoSize = true;
            this.jidlo.Location = new System.Drawing.Point(99, 19);
            this.jidlo.Name = "jidlo";
            this.jidlo.Size = new System.Drawing.Size(49, 17);
            this.jidlo.TabIndex = 5;
            this.jidlo.Text = Jazyk.Strings.Jidlo;
            this.jidlo.UseVisualStyleBackColor = true;
            // 
            // ruzne
            // 
            this.ruzne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ruzne.AutoSize = true;
            this.ruzne.Location = new System.Drawing.Point(6, 111);
            this.ruzne.Name = "ruzne";
            this.ruzne.Size = new System.Drawing.Size(57, 17);
            this.ruzne.TabIndex = 4;
            this.ruzne.Text = Jazyk.Strings.Ruzne;
            this.ruzne.UseVisualStyleBackColor = true;
            // 
            // doprava
            // 
            this.doprava.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.doprava.AutoSize = true;
            this.doprava.Location = new System.Drawing.Point(6, 88);
            this.doprava.Name = "doprava";
            this.doprava.Size = new System.Drawing.Size(67, 17);
            this.doprava.TabIndex = 3;
            this.doprava.Text = Jazyk.Strings.Doprava;
            this.doprava.UseVisualStyleBackColor = true;
            // 
            // redstone
            // 
            this.redstone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.redstone.AutoSize = true;
            this.redstone.Location = new System.Drawing.Point(6, 65);
            this.redstone.Name = "redstone";
            this.redstone.Size = new System.Drawing.Size(72, 17);
            this.redstone.TabIndex = 2;
            this.redstone.Text = Jazyk.Strings.Redstone;
            this.redstone.UseVisualStyleBackColor = true;
            // 
            // dekorace
            // 
            this.dekorace.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dekorace.AutoSize = true;
            this.dekorace.Location = new System.Drawing.Point(6, 42);
            this.dekorace.Name = "dekorace";
            this.dekorace.Size = new System.Drawing.Size(82, 17);
            this.dekorace.TabIndex = 1;
            this.dekorace.Text = Jazyk.Strings.Dekorativni;
            this.dekorace.UseVisualStyleBackColor = true;
            // 
            // stavebni
            // 
            this.stavebni.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.stavebni.AutoSize = true;
            this.stavebni.Location = new System.Drawing.Point(6, 19);
            this.stavebni.Name = "stavebni";
            this.stavebni.Size = new System.Drawing.Size(70, 17);
            this.stavebni.TabIndex = 0;
            this.stavebni.Text = Jazyk.Strings.Stavebni;
            this.stavebni.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(92, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "* " + Jazyk.Strings.Povinne_polozky;
            // 
            // stringID
            // 
            this.stringID.Location = new System.Drawing.Point(111, 38);
            this.stringID.Name = "stringID";
            this.stringID.Size = new System.Drawing.Size(135, 20);
            this.stringID.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 41);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(52, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "String ID *";
            // 
            // NovyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 352);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.stringID);
            this.Controls.Add(this.cesta);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.id);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pridanyItemInfo);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.poskozeni);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.stackovatelny);
            this.Controls.Add(this.y);
            this.Controls.Add(this.x);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.najit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.jmeno);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(350, 228);
            this.Name = "NovyItem";
            this.ShowIcon = false;
            this.Text = Jazyk.Strings.Pridat_vlastni_item;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox jmeno;
        private System.Windows.Forms.TextBox cesta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button najit;
        private System.Windows.Forms.OpenFileDialog otevritObrazek;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox x;
        private System.Windows.Forms.TextBox y;
        private System.Windows.Forms.CheckBox stackovatelny;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox poskozeni;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Label pridanyItemInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox materialy;
        private System.Windows.Forms.CheckBox lektvary;
        private System.Windows.Forms.CheckBox bojove;
        private System.Windows.Forms.CheckBox nastroje;
        private System.Windows.Forms.CheckBox jidlo;
        private System.Windows.Forms.CheckBox ruzne;
        private System.Windows.Forms.CheckBox doprava;
        private System.Windows.Forms.CheckBox redstone;
        private System.Windows.Forms.CheckBox dekorace;
        private System.Windows.Forms.CheckBox stavebni;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox stringID;
        private System.Windows.Forms.Label label10;
    }
}