namespace SaveEdit
{
    partial class MoznostiHry
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
            this.label2 = new System.Windows.Forms.Label();
            this.survival = new System.Windows.Forms.RadioButton();
            this.creative = new System.Windows.Forms.RadioButton();
            this.adventure = new System.Windows.Forms.RadioButton();
            this.hardcore = new System.Windows.Forms.RadioButton();
            this.seed = new System.Windows.Forms.TextBox();
            this.cheaty = new System.Windows.Forms.CheckBox();
            this.kopirovatSeed = new System.Windows.Forms.Button();
            this.nesmrtelnost = new System.Windows.Forms.CheckBox();
            this.ztrataItemu = new System.Windows.Forms.CheckBox();
            this.denNoc = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.hodiny = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.minuty = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.zivot = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.maxZivot = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.utok = new System.Windows.Forms.NumericUpDown();
            this.odrazeni = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.spectator = new System.Windows.Forms.RadioButton();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.x = new System.Windows.Forms.TextBox();
            this.y = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.z = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.zamceniObtiznosti = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.hodiny)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.zivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxZivot)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.utok)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.odrazeni)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = Jazyk.Strings.Seed_mapy + ":";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = Jazyk.Strings.Typ_hry + ":";
            // 
            // survival
            // 
            this.survival.AutoSize = true;
            this.survival.Location = new System.Drawing.Point(12, 50);
            this.survival.Name = "survival";
            this.survival.Size = new System.Drawing.Size(63, 17);
            this.survival.TabIndex = 3;
            this.survival.TabStop = true;
            this.survival.Text = Jazyk.Strings.Survival;
            this.survival.UseVisualStyleBackColor = true;
            this.survival.CheckedChanged += new System.EventHandler(this.survival_CheckedChanged);
            // 
            // creative
            // 
            this.creative.AutoSize = true;
            this.creative.Location = new System.Drawing.Point(81, 50);
            this.creative.Name = "creative";
            this.creative.Size = new System.Drawing.Size(64, 17);
            this.creative.TabIndex = 4;
            this.creative.TabStop = true;
            this.creative.Text = Jazyk.Strings.Creative;
            this.creative.UseVisualStyleBackColor = true;
            this.creative.CheckedChanged += new System.EventHandler(this.creative_CheckedChanged);
            // 
            // adventure
            // 
            this.adventure.AutoSize = true;
            this.adventure.Location = new System.Drawing.Point(151, 50);
            this.adventure.Name = "adventure";
            this.adventure.Size = new System.Drawing.Size(74, 17);
            this.adventure.TabIndex = 5;
            this.adventure.TabStop = true;
            this.adventure.Text = Jazyk.Strings.Adventure;
            this.adventure.UseVisualStyleBackColor = true;
            this.adventure.CheckedChanged += new System.EventHandler(this.adventure_CheckedChanged);
            // 
            // hardcore
            // 
            this.hardcore.AutoSize = true;
            this.hardcore.Location = new System.Drawing.Point(231, 50);
            this.hardcore.Name = "hardcore";
            this.hardcore.Size = new System.Drawing.Size(69, 17);
            this.hardcore.TabIndex = 6;
            this.hardcore.TabStop = true;
            this.hardcore.Text = Jazyk.Strings.Hardcore;
            this.hardcore.UseVisualStyleBackColor = true;
            this.hardcore.CheckedChanged += new System.EventHandler(this.hardcore_CheckedChanged);
            // 
            // seed
            // 
            this.seed.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.seed.Location = new System.Drawing.Point(81, 9);
            this.seed.Name = "seed";
            this.seed.ReadOnly = true;
            this.seed.Size = new System.Drawing.Size(144, 13);
            this.seed.TabIndex = 7;
            // 
            // cheaty
            // 
            this.cheaty.AutoSize = true;
            this.cheaty.Location = new System.Drawing.Point(12, 144);
            this.cheaty.Name = "cheaty";
            this.cheaty.Size = new System.Drawing.Size(134, 17);
            this.cheaty.TabIndex = 8;
            this.cheaty.Text = Jazyk.Strings.Povolit_prikazy;
            this.cheaty.UseVisualStyleBackColor = true;
            this.cheaty.CheckedChanged += new System.EventHandler(this.cheaty_CheckedChanged);
            // 
            // kopirovatSeed
            // 
            this.kopirovatSeed.Location = new System.Drawing.Point(251, 4);
            this.kopirovatSeed.Name = "kopirovatSeed";
            this.kopirovatSeed.Size = new System.Drawing.Size(69, 23);
            this.kopirovatSeed.TabIndex = 9;
            this.kopirovatSeed.Text = Jazyk.Strings.Kopirovat;
            this.kopirovatSeed.UseVisualStyleBackColor = true;
            this.kopirovatSeed.Click += new System.EventHandler(this.kopirovatSeed_Click);
            // 
            // nesmrtelnost
            // 
            this.nesmrtelnost.AutoSize = true;
            this.nesmrtelnost.Location = new System.Drawing.Point(12, 167);
            this.nesmrtelnost.Name = "nesmrtelnost";
            this.nesmrtelnost.Size = new System.Drawing.Size(87, 17);
            this.nesmrtelnost.TabIndex = 10;
            this.nesmrtelnost.Text = Jazyk.Strings.Nesmrtelnost;
            this.nesmrtelnost.UseVisualStyleBackColor = true;
            this.nesmrtelnost.CheckedChanged += new System.EventHandler(this.nesmrtelnost_CheckedChanged);
            // 
            // ztrataItemu
            // 
            this.ztrataItemu.AutoSize = true;
            this.ztrataItemu.Location = new System.Drawing.Point(12, 190);
            this.ztrataItemu.Name = "ztrataItemu";
            this.ztrataItemu.Size = new System.Drawing.Size(154, 17);
            this.ztrataItemu.TabIndex = 11;
            this.ztrataItemu.Text = Jazyk.Strings.Hrac_neztrati;
            this.ztrataItemu.UseVisualStyleBackColor = true;
            this.ztrataItemu.CheckedChanged += new System.EventHandler(this.ztrataItemu_CheckedChanged);
            // 
            // denNoc
            // 
            this.denNoc.AutoSize = true;
            this.denNoc.Location = new System.Drawing.Point(12, 213);
            this.denNoc.Name = "denNoc";
            this.denNoc.Size = new System.Drawing.Size(119, 17);
            this.denNoc.TabIndex = 12;
            this.denNoc.Text = Jazyk.Strings.Stridani_dne;
            this.denNoc.UseVisualStyleBackColor = true;
            this.denNoc.CheckedChanged += new System.EventHandler(this.denNoc_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 233);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = Jazyk.Strings.Denni_cas;
            // 
            // hodiny
            // 
            this.hodiny.Location = new System.Drawing.Point(12, 249);
            this.hodiny.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hodiny.Name = "hodiny";
            this.hodiny.Size = new System.Drawing.Size(40, 20);
            this.hodiny.TabIndex = 14;
            this.hodiny.ValueChanged += new System.EventHandler(this.hodiny_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = Jazyk.Strings.Hodin;
            // 
            // minuty
            // 
            this.minuty.Location = new System.Drawing.Point(97, 249);
            this.minuty.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minuty.Name = "minuty";
            this.minuty.Size = new System.Drawing.Size(40, 20);
            this.minuty.TabIndex = 16;
            this.minuty.ValueChanged += new System.EventHandler(this.hodiny_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(143, 251);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = Jazyk.Strings.Minut;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 277);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 13);
            this.label6.TabIndex = 18;
            this.label6.Text = Jazyk.Strings.Zivot;
            // 
            // zivot
            // 
            this.zivot.Location = new System.Drawing.Point(50, 275);
            this.zivot.Name = "zivot";
            this.zivot.Size = new System.Drawing.Size(60, 20);
            this.zivot.TabIndex = 19;
            this.zivot.ValueChanged += new System.EventHandler(this.zivot_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(116, 277);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 20;
            this.label7.Text = Jazyk.Strings.Max_zivot;
            // 
            // maxZivot
            // 
            this.maxZivot.Location = new System.Drawing.Point(177, 275);
            this.maxZivot.Name = "maxZivot";
            this.maxZivot.Size = new System.Drawing.Size(60, 20);
            this.maxZivot.TabIndex = 21;
            this.maxZivot.ValueChanged += new System.EventHandler(this.maxZivot_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 306);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = Jazyk.Strings.Zakladni_utok;
            // 
            // utok
            // 
            this.utok.Location = new System.Drawing.Point(89, 304);
            this.utok.Name = "utok";
            this.utok.Size = new System.Drawing.Size(80, 20);
            this.utok.TabIndex = 23;
            this.utok.ValueChanged += new System.EventHandler(this.utok_ValueChanged);
            // 
            // odrazeni
            // 
            this.odrazeni.Location = new System.Drawing.Point(132, 330);
            this.odrazeni.Name = "odrazeni";
            this.odrazeni.Size = new System.Drawing.Size(80, 20);
            this.odrazeni.TabIndex = 24;
            this.odrazeni.ValueChanged += new System.EventHandler(this.odrazeni_ValueChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 332);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(117, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = Jazyk.Strings.Odolnost;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(245, 272);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 26;
            this.button1.Text = Jazyk.Strings.Zakladni;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 299);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 27;
            this.button2.Text = Jazyk.Strings.Zakladni;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(245, 327);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 28;
            this.button3.Text = Jazyk.Strings.Zakladni;
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // spectator
            // 
            this.spectator.AutoSize = true;
            this.spectator.Location = new System.Drawing.Point(12, 73);
            this.spectator.Name = "spectator";
            this.spectator.Size = new System.Drawing.Size(71, 17);
            this.spectator.TabIndex = 29;
            this.spectator.TabStop = true;
            this.spectator.Text = Jazyk.Strings.Spectator;
            this.spectator.UseVisualStyleBackColor = true;
            this.spectator.CheckedChanged += new System.EventHandler(this.spectator_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(243, 13);
            this.label10.TabIndex = 30;
            this.label10.Text = Jazyk.Strings.Souradnice_spawnu;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(12, 121);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(12, 13);
            this.label11.TabIndex = 31;
            this.label11.Text = "x";
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(30, 118);
            this.x.Name = "x";
            this.x.Size = new System.Drawing.Size(70, 20);
            this.x.TabIndex = 32;
            this.x.TextChanged += new System.EventHandler(this.x_TextChanged);
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(124, 118);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(70, 20);
            this.y.TabIndex = 34;
            this.y.TextChanged += new System.EventHandler(this.y_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(106, 121);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(12, 13);
            this.label12.TabIndex = 33;
            this.label12.Text = "y";
            // 
            // z
            // 
            this.z.Location = new System.Drawing.Point(218, 118);
            this.z.Name = "z";
            this.z.Size = new System.Drawing.Size(70, 20);
            this.z.TabIndex = 36;
            this.z.TextChanged += new System.EventHandler(this.z_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(200, 121);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(12, 13);
            this.label13.TabIndex = 35;
            this.label13.Text = "z";
            // 
            // zamceniObtiznosti
            // 
            this.zamceniObtiznosti.AutoSize = true;
            this.zamceniObtiznosti.Location = new System.Drawing.Point(175, 144);
            this.zamceniObtiznosti.Name = "zamceniObtiznosti";
            this.zamceniObtiznosti.Size = new System.Drawing.Size(124, 17);
            this.zamceniObtiznosti.TabIndex = 37;
            this.zamceniObtiznosti.Text = Jazyk.Strings.Uzamceni_obtiznosti;
            this.zamceniObtiznosti.UseVisualStyleBackColor = true;
            this.zamceniObtiznosti.CheckedChanged += new System.EventHandler(this.zamceniObtiznosti_CheckedChanged);
            // 
            // MoznostiHry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(332, 362);
            this.Controls.Add(this.zamceniObtiznosti);
            this.Controls.Add(this.z);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.y);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.x);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.spectator);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.odrazeni);
            this.Controls.Add(this.utok);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.maxZivot);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.zivot);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.minuty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.hodiny);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.denNoc);
            this.Controls.Add(this.ztrataItemu);
            this.Controls.Add(this.nesmrtelnost);
            this.Controls.Add(this.kopirovatSeed);
            this.Controls.Add(this.cheaty);
            this.Controls.Add(this.seed);
            this.Controls.Add(this.hardcore);
            this.Controls.Add(this.adventure);
            this.Controls.Add(this.creative);
            this.Controls.Add(this.survival);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MoznostiHry";
            this.ShowIcon = false;
            this.Text = Jazyk.Strings.Moznosti_hry;
            this.Load += new System.EventHandler(this.MoznostiHry_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hodiny)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minuty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.zivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxZivot)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.utok)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.odrazeni)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton survival;
        private System.Windows.Forms.RadioButton creative;
        private System.Windows.Forms.RadioButton adventure;
        private System.Windows.Forms.RadioButton hardcore;
        private System.Windows.Forms.TextBox seed;
        private System.Windows.Forms.CheckBox cheaty;
        private System.Windows.Forms.Button kopirovatSeed;
        private System.Windows.Forms.CheckBox nesmrtelnost;
        private System.Windows.Forms.CheckBox ztrataItemu;
        private System.Windows.Forms.CheckBox denNoc;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown hodiny;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown minuty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown zivot;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown maxZivot;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown utok;
        private System.Windows.Forms.NumericUpDown odrazeni;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton spectator;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox x;
        private System.Windows.Forms.TextBox y;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox z;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox zamceniObtiznosti;
    }
}