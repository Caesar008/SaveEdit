namespace SaveEdit
{
    partial class VlastnostiItemu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VlastnostiItemu));
            this.label1 = new System.Windows.Forms.Label();
            this.jmeno = new System.Windows.Forms.TextBox();
            this.barvyView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pridatBarvu = new System.Windows.Forms.Button();
            this.zrusitBarvu = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.prechodyView = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pridatPrechod = new System.Windows.Forms.Button();
            this.odebratPrechod = new System.Windows.Forms.Button();
            this.efektyView = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pridatVybuch = new System.Windows.Forms.Button();
            this.odebratVybuch = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.GroupBox();
            this.trail = new System.Windows.Forms.CheckBox();
            this.flicker = new System.Windows.Forms.CheckBox();
            this.rozprsknuti = new System.Windows.Forms.RadioButton();
            this.hlavaCreepera = new System.Windows.Forms.RadioButton();
            this.hvezda = new System.Windows.Forms.RadioButton();
            this.velkaKoule = new System.Windows.Forms.RadioButton();
            this.malaKoule = new System.Windows.Forms.RadioButton();
            this.dolet = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bannerPanel = new System.Windows.Forms.Panel();
            this.smazat = new System.Windows.Forms.Button();
            this.vlnRam = new System.Windows.Forms.RadioButton();
            this.gradientH = new System.Windows.Forms.RadioButton();
            this.gradientDolu = new System.Windows.Forms.RadioButton();
            this.ldPulka = new System.Windows.Forms.RadioButton();
            this.pdPulka = new System.Windows.Forms.RadioButton();
            this.phPulka = new System.Windows.Forms.RadioButton();
            this.lhPulka = new System.Windows.Forms.RadioButton();
            this.pPulka = new System.Windows.Forms.RadioButton();
            this.lPulka = new System.Windows.Forms.RadioButton();
            this.pPruh = new System.Windows.Forms.RadioButton();
            this.lPruh = new System.Windows.Forms.RadioButton();
            this.pruhy = new System.Windows.Forms.RadioButton();
            this.dPulka = new System.Windows.Forms.RadioButton();
            this.dPruh = new System.Windows.Forms.RadioButton();
            this.hPulka = new System.Windows.Forms.RadioButton();
            this.hPruh = new System.Windows.Forms.RadioButton();
            this.kosoc = new System.Windows.Forms.RadioButton();
            this.svPruh = new System.Windows.Forms.RadioButton();
            this.shPruh = new System.Windows.Forms.RadioButton();
            this.zubyD = new System.Windows.Forms.RadioButton();
            this.zubyH = new System.Windows.Forms.RadioButton();
            this.kriz = new System.Windows.Forms.RadioButton();
            this.pruhPD = new System.Windows.Forms.RadioButton();
            this.pruhLD = new System.Windows.Forms.RadioButton();
            this.trojD = new System.Windows.Forms.RadioButton();
            this.trojH = new System.Windows.Forms.RadioButton();
            this.ctverecPD = new System.Windows.Forms.RadioButton();
            this.ctverecLD = new System.Windows.Forms.RadioButton();
            this.ctverecLH = new System.Windows.Forms.RadioButton();
            this.ctverecPH = new System.Windows.Forms.RadioButton();
            this.kruh = new System.Windows.Forms.RadioButton();
            this.cihly = new System.Windows.Forms.RadioButton();
            this.kvetina = new System.Windows.Forms.RadioButton();
            this.lebka = new System.Windows.Forms.RadioButton();
            this.creeper = new System.Windows.Forms.RadioButton();
            this.ramecek = new System.Windows.Forms.RadioButton();
            this.zmenitBarvu = new System.Windows.Forms.Button();
            this.pridatPatternu = new System.Windows.Forms.Button();
            this.dolu = new System.Windows.Forms.Button();
            this.nahoru = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.patternyView = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.bannerNahled = new System.Windows.Forms.PictureBox();
            this.rovKriz = new System.Windows.Forms.RadioButton();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dolet)).BeginInit();
            this.bannerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerNahled)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = Jazyk.Strings.Jmeno_itemu;
            // 
            // jmeno
            // 
            this.jmeno.Location = new System.Drawing.Point(84, 12);
            this.jmeno.Name = "jmeno";
            this.jmeno.Size = new System.Drawing.Size(180, 20);
            this.jmeno.TabIndex = 1;
            this.jmeno.TextChanged += new System.EventHandler(this.jmeno_TextChanged);
            // 
            // barvyView
            // 
            this.barvyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.barvyView.Enabled = false;
            this.barvyView.FullRowSelect = true;
            this.barvyView.GridLines = true;
            this.barvyView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.barvyView.HideSelection = false;
            this.barvyView.Location = new System.Drawing.Point(12, 57);
            this.barvyView.MultiSelect = false;
            this.barvyView.Name = "barvyView";
            this.barvyView.Size = new System.Drawing.Size(114, 182);
            this.barvyView.TabIndex = 2;
            this.barvyView.UseCompatibleStateImageBehavior = false;
            this.barvyView.View = System.Windows.Forms.View.Details;
            this.barvyView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.barvyView_ItemSelectionChanged);
            this.barvyView.DoubleClick += new System.EventHandler(this.barvyView_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 110;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = Jazyk.Strings.Barvy;
            // 
            // pridatBarvu
            // 
            this.pridatBarvu.Enabled = false;
            this.pridatBarvu.Location = new System.Drawing.Point(132, 106);
            this.pridatBarvu.Name = "pridatBarvu";
            this.pridatBarvu.Size = new System.Drawing.Size(75, 35);
            this.pridatBarvu.TabIndex = 4;
            this.pridatBarvu.Text = Jazyk.Strings.Pridat_barvu;
            this.pridatBarvu.UseVisualStyleBackColor = true;
            this.pridatBarvu.Click += new System.EventHandler(this.pridatBarvu_Click);
            // 
            // zrusitBarvu
            // 
            this.zrusitBarvu.Enabled = false;
            this.zrusitBarvu.Location = new System.Drawing.Point(132, 147);
            this.zrusitBarvu.Name = "zrusitBarvu";
            this.zrusitBarvu.Size = new System.Drawing.Size(75, 35);
            this.zrusitBarvu.TabIndex = 5;
            this.zrusitBarvu.Text = Jazyk.Strings.Odebrat_barvu;
            this.zrusitBarvu.UseVisualStyleBackColor = true;
            this.zrusitBarvu.Click += new System.EventHandler(this.zrusitBarvu_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(210, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = Jazyk.Strings.Prechody;
            // 
            // prechodyView
            // 
            this.prechodyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.prechodyView.Enabled = false;
            this.prechodyView.FullRowSelect = true;
            this.prechodyView.GridLines = true;
            this.prechodyView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.prechodyView.HideSelection = false;
            this.prechodyView.Location = new System.Drawing.Point(213, 57);
            this.prechodyView.MultiSelect = false;
            this.prechodyView.Name = "prechodyView";
            this.prechodyView.Size = new System.Drawing.Size(114, 182);
            this.prechodyView.TabIndex = 7;
            this.prechodyView.UseCompatibleStateImageBehavior = false;
            this.prechodyView.View = System.Windows.Forms.View.Details;
            this.prechodyView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.prechodyView_ItemSelectionChanged);
            this.prechodyView.DoubleClick += new System.EventHandler(this.prechodyView_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 110;
            // 
            // pridatPrechod
            // 
            this.pridatPrechod.Enabled = false;
            this.pridatPrechod.Location = new System.Drawing.Point(333, 106);
            this.pridatPrechod.Name = "pridatPrechod";
            this.pridatPrechod.Size = new System.Drawing.Size(75, 35);
            this.pridatPrechod.TabIndex = 8;
            this.pridatPrechod.Text = Jazyk.Strings.Pridat_prechod;
            this.pridatPrechod.UseVisualStyleBackColor = true;
            this.pridatPrechod.Click += new System.EventHandler(this.pridatPrechod_Click);
            // 
            // odebratPrechod
            // 
            this.odebratPrechod.Enabled = false;
            this.odebratPrechod.Location = new System.Drawing.Point(333, 147);
            this.odebratPrechod.Name = "odebratPrechod";
            this.odebratPrechod.Size = new System.Drawing.Size(75, 35);
            this.odebratPrechod.TabIndex = 9;
            this.odebratPrechod.Text = Jazyk.Strings.Odebrat_prechod;
            this.odebratPrechod.UseVisualStyleBackColor = true;
            this.odebratPrechod.Click += new System.EventHandler(this.odstranPrechod_Click);
            // 
            // efektyView
            // 
            this.efektyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3});
            this.efektyView.Enabled = false;
            this.efektyView.FullRowSelect = true;
            this.efektyView.GridLines = true;
            this.efektyView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.efektyView.HideSelection = false;
            this.efektyView.Location = new System.Drawing.Point(414, 57);
            this.efektyView.MultiSelect = false;
            this.efektyView.Name = "efektyView";
            this.efektyView.Size = new System.Drawing.Size(54, 182);
            this.efektyView.TabIndex = 10;
            this.efektyView.UseCompatibleStateImageBehavior = false;
            this.efektyView.View = System.Windows.Forms.View.Details;
            this.efektyView.SelectedIndexChanged += new System.EventHandler(this.efektyView_SelectedIndexChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 50;
            // 
            // pridatVybuch
            // 
            this.pridatVybuch.Enabled = false;
            this.pridatVybuch.Location = new System.Drawing.Point(474, 106);
            this.pridatVybuch.Name = "pridatVybuch";
            this.pridatVybuch.Size = new System.Drawing.Size(75, 35);
            this.pridatVybuch.TabIndex = 11;
            this.pridatVybuch.Text = Jazyk.Strings.Pridat_vybuch;
            this.pridatVybuch.UseVisualStyleBackColor = true;
            this.pridatVybuch.Click += new System.EventHandler(this.pridatVybuch_Click);
            // 
            // odebratVybuch
            // 
            this.odebratVybuch.Enabled = false;
            this.odebratVybuch.Location = new System.Drawing.Point(474, 147);
            this.odebratVybuch.Name = "odebratVybuch";
            this.odebratVybuch.Size = new System.Drawing.Size(75, 35);
            this.odebratVybuch.TabIndex = 12;
            this.odebratVybuch.Text = Jazyk.Strings.Odebrat_vybuch;
            this.odebratVybuch.UseVisualStyleBackColor = true;
            this.odebratVybuch.Click += new System.EventHandler(this.odebratVybuch_Click);
            // 
            // panel
            // 
            this.panel.Controls.Add(this.trail);
            this.panel.Controls.Add(this.flicker);
            this.panel.Controls.Add(this.rozprsknuti);
            this.panel.Controls.Add(this.hlavaCreepera);
            this.panel.Controls.Add(this.hvezda);
            this.panel.Controls.Add(this.velkaKoule);
            this.panel.Controls.Add(this.malaKoule);
            this.panel.Enabled = false;
            this.panel.Location = new System.Drawing.Point(12, 245);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(390, 67);
            this.panel.TabIndex = 13;
            this.panel.TabStop = false;
            this.panel.Text = Jazyk.Strings.Efekty;
            // 
            // trail
            // 
            this.trail.AutoSize = true;
            this.trail.Location = new System.Drawing.Point(286, 20);
            this.trail.Name = "trail";
            this.trail.Size = new System.Drawing.Size(46, 17);
            this.trail.TabIndex = 6;
            this.trail.Text = Jazyk.Strings.Trail;
            this.trail.UseVisualStyleBackColor = true;
            this.trail.CheckedChanged += new System.EventHandler(this.trail_CheckedChanged);
            // 
            // flicker
            // 
            this.flicker.AutoSize = true;
            this.flicker.Location = new System.Drawing.Point(286, 43);
            this.flicker.Name = "flicker";
            this.flicker.Size = new System.Drawing.Size(63, 17);
            this.flicker.TabIndex = 5;
            this.flicker.Text = Jazyk.Strings.Twinkle;
            this.flicker.UseVisualStyleBackColor = true;
            this.flicker.CheckedChanged += new System.EventHandler(this.flicker_CheckedChanged);
            // 
            // rozprsknuti
            // 
            this.rozprsknuti.AutoSize = true;
            this.rozprsknuti.Location = new System.Drawing.Point(197, 19);
            this.rozprsknuti.Name = "rozprsknuti";
            this.rozprsknuti.Size = new System.Drawing.Size(85, 17);
            this.rozprsknuti.TabIndex = 4;
            this.rozprsknuti.TabStop = true;
            this.rozprsknuti.Text = Jazyk.Strings.Rozprsknuti;
            this.rozprsknuti.UseVisualStyleBackColor = true;
            this.rozprsknuti.CheckedChanged += new System.EventHandler(this.rozprsknuti_CheckedChanged);
            // 
            // hlavaCreepera
            // 
            this.hlavaCreepera.AutoSize = true;
            this.hlavaCreepera.Location = new System.Drawing.Point(93, 42);
            this.hlavaCreepera.Name = "hlavaCreepera";
            this.hlavaCreepera.Size = new System.Drawing.Size(94, 17);
            this.hlavaCreepera.TabIndex = 3;
            this.hlavaCreepera.TabStop = true;
            this.hlavaCreepera.Text = Jazyk.Strings.Hlava_creepera;
            this.hlavaCreepera.UseVisualStyleBackColor = true;
            this.hlavaCreepera.CheckedChanged += new System.EventHandler(this.hlavaCreeprera_CheckedChanged);
            // 
            // hvezda
            // 
            this.hvezda.AutoSize = true;
            this.hvezda.Location = new System.Drawing.Point(93, 19);
            this.hvezda.Name = "hvezda";
            this.hvezda.Size = new System.Drawing.Size(76, 17);
            this.hvezda.TabIndex = 2;
            this.hvezda.TabStop = true;
            this.hvezda.Text = Jazyk.Strings.Hvezda;
            this.hvezda.UseVisualStyleBackColor = true;
            this.hvezda.CheckedChanged += new System.EventHandler(this.hvezda_CheckedChanged);
            // 
            // velkaKoule
            // 
            this.velkaKoule.AutoSize = true;
            this.velkaKoule.Location = new System.Drawing.Point(6, 42);
            this.velkaKoule.Name = "velkaKoule";
            this.velkaKoule.Size = new System.Drawing.Size(59, 17);
            this.velkaKoule.TabIndex = 1;
            this.velkaKoule.TabStop = true;
            this.velkaKoule.Text = Jazyk.Strings.Velka_koule;
            this.velkaKoule.UseVisualStyleBackColor = true;
            this.velkaKoule.CheckedChanged += new System.EventHandler(this.velkaKoule_CheckedChanged);
            // 
            // malaKoule
            // 
            this.malaKoule.AutoSize = true;
            this.malaKoule.Location = new System.Drawing.Point(6, 19);
            this.malaKoule.Name = "malaKoule";
            this.malaKoule.Size = new System.Drawing.Size(69, 17);
            this.malaKoule.TabIndex = 0;
            this.malaKoule.TabStop = true;
            this.malaKoule.Text = Jazyk.Strings.Mala_koule;
            this.malaKoule.UseVisualStyleBackColor = true;
            this.malaKoule.CheckedChanged += new System.EventHandler(this.malaKoule_CheckedChanged);
            // 
            // dolet
            // 
            this.dolet.Enabled = false;
            this.dolet.Location = new System.Drawing.Point(408, 287);
            this.dolet.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.dolet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dolet.Name = "dolet";
            this.dolet.Size = new System.Drawing.Size(65, 20);
            this.dolet.TabIndex = 8;
            this.dolet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dolet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.dolet.ValueChanged += new System.EventHandler(this.dolet_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(405, 267);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = Jazyk.Strings.Vyska_doletu;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(411, 41);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = Jazyk.Strings.Vybuchy;
            // 
            // bannerPanel
            // 
            this.bannerPanel.Controls.Add(this.rovKriz);
            this.bannerPanel.Controls.Add(this.smazat);
            this.bannerPanel.Controls.Add(this.vlnRam);
            this.bannerPanel.Controls.Add(this.gradientH);
            this.bannerPanel.Controls.Add(this.gradientDolu);
            this.bannerPanel.Controls.Add(this.ldPulka);
            this.bannerPanel.Controls.Add(this.pdPulka);
            this.bannerPanel.Controls.Add(this.phPulka);
            this.bannerPanel.Controls.Add(this.lhPulka);
            this.bannerPanel.Controls.Add(this.pPulka);
            this.bannerPanel.Controls.Add(this.lPulka);
            this.bannerPanel.Controls.Add(this.pPruh);
            this.bannerPanel.Controls.Add(this.lPruh);
            this.bannerPanel.Controls.Add(this.pruhy);
            this.bannerPanel.Controls.Add(this.dPulka);
            this.bannerPanel.Controls.Add(this.dPruh);
            this.bannerPanel.Controls.Add(this.hPulka);
            this.bannerPanel.Controls.Add(this.hPruh);
            this.bannerPanel.Controls.Add(this.kosoc);
            this.bannerPanel.Controls.Add(this.svPruh);
            this.bannerPanel.Controls.Add(this.shPruh);
            this.bannerPanel.Controls.Add(this.zubyD);
            this.bannerPanel.Controls.Add(this.zubyH);
            this.bannerPanel.Controls.Add(this.kriz);
            this.bannerPanel.Controls.Add(this.pruhPD);
            this.bannerPanel.Controls.Add(this.pruhLD);
            this.bannerPanel.Controls.Add(this.trojD);
            this.bannerPanel.Controls.Add(this.trojH);
            this.bannerPanel.Controls.Add(this.ctverecPD);
            this.bannerPanel.Controls.Add(this.ctverecLD);
            this.bannerPanel.Controls.Add(this.ctverecLH);
            this.bannerPanel.Controls.Add(this.ctverecPH);
            this.bannerPanel.Controls.Add(this.kruh);
            this.bannerPanel.Controls.Add(this.cihly);
            this.bannerPanel.Controls.Add(this.kvetina);
            this.bannerPanel.Controls.Add(this.lebka);
            this.bannerPanel.Controls.Add(this.creeper);
            this.bannerPanel.Controls.Add(this.ramecek);
            this.bannerPanel.Controls.Add(this.zmenitBarvu);
            this.bannerPanel.Controls.Add(this.pridatPatternu);
            this.bannerPanel.Controls.Add(this.dolu);
            this.bannerPanel.Controls.Add(this.nahoru);
            this.bannerPanel.Controls.Add(this.label7);
            this.bannerPanel.Controls.Add(this.patternyView);
            this.bannerPanel.Controls.Add(this.label6);
            this.bannerPanel.Controls.Add(this.bannerNahled);
            this.bannerPanel.Location = new System.Drawing.Point(12, 38);
            this.bannerPanel.Name = "bannerPanel";
            this.bannerPanel.Size = new System.Drawing.Size(536, 274);
            this.bannerPanel.TabIndex = 15;
            // 
            // smazat
            // 
            this.smazat.Enabled = false;
            this.smazat.Location = new System.Drawing.Point(246, 181);
            this.smazat.Name = "smazat";
            this.smazat.Size = new System.Drawing.Size(55, 39);
            this.smazat.TabIndex = 66;
            this.smazat.Text = Jazyk.Strings.Smazat_patternu;
            this.smazat.UseVisualStyleBackColor = true;
            this.smazat.Click += new System.EventHandler(this.smazat_Click);
            // 
            // vlnRam
            // 
            this.vlnRam.AutoSize = true;
            this.vlnRam.Location = new System.Drawing.Point(466, 233);
            this.vlnRam.Name = "vlnRam";
            this.vlnRam.Size = new System.Drawing.Size(72, 17);
            this.vlnRam.TabIndex = 65;
            this.vlnRam.TabStop = true;
            this.vlnRam.Text = Jazyk.Strings.Vlnity_ram;
            this.vlnRam.UseVisualStyleBackColor = true;
            // 
            // gradientH
            // 
            this.gradientH.AutoSize = true;
            this.gradientH.Location = new System.Drawing.Point(384, 233);
            this.gradientH.Name = "gradientH";
            this.gradientH.Size = new System.Drawing.Size(80, 17);
            this.gradientH.TabIndex = 64;
            this.gradientH.TabStop = true;
            this.gradientH.Text = Jazyk.Strings.Gradient_nahoru;
            this.gradientH.UseVisualStyleBackColor = true;
            // 
            // gradientDolu
            // 
            this.gradientDolu.AutoSize = true;
            this.gradientDolu.Location = new System.Drawing.Point(307, 233);
            this.gradientDolu.Name = "gradientDolu";
            this.gradientDolu.Size = new System.Drawing.Size(80, 17);
            this.gradientDolu.TabIndex = 63;
            this.gradientDolu.TabStop = true;
            this.gradientDolu.Text = Jazyk.Strings.Gradient_dolu;
            this.gradientDolu.UseVisualStyleBackColor = true;
            // 
            // ldPulka
            // 
            this.ldPulka.AutoSize = true;
            this.ldPulka.Location = new System.Drawing.Point(466, 212);
            this.ldPulka.Name = "ldPulka";
            this.ldPulka.Size = new System.Drawing.Size(57, 17);
            this.ldPulka.TabIndex = 62;
            this.ldPulka.TabStop = true;
            this.ldPulka.Text = Jazyk.Strings.Leva_dolni_pulka;
            this.ldPulka.UseVisualStyleBackColor = true;
            // 
            // pdPulka
            // 
            this.pdPulka.AutoSize = true;
            this.pdPulka.Location = new System.Drawing.Point(384, 212);
            this.pdPulka.Name = "pdPulka";
            this.pdPulka.Size = new System.Drawing.Size(59, 17);
            this.pdPulka.TabIndex = 61;
            this.pdPulka.TabStop = true;
            this.pdPulka.Text = Jazyk.Strings.Prava_dolni_pulka;
            this.pdPulka.UseVisualStyleBackColor = true;
            // 
            // phPulka
            // 
            this.phPulka.AutoSize = true;
            this.phPulka.Location = new System.Drawing.Point(466, 192);
            this.phPulka.Name = "phPulka";
            this.phPulka.Size = new System.Drawing.Size(61, 17);
            this.phPulka.TabIndex = 60;
            this.phPulka.TabStop = true;
            this.phPulka.Text = Jazyk.Strings.Prava_horni_pulka;
            this.phPulka.UseVisualStyleBackColor = true;
            // 
            // lhPulka
            // 
            this.lhPulka.AutoSize = true;
            this.lhPulka.Location = new System.Drawing.Point(307, 212);
            this.lhPulka.Name = "lhPulka";
            this.lhPulka.Size = new System.Drawing.Size(59, 17);
            this.lhPulka.TabIndex = 59;
            this.lhPulka.TabStop = true;
            this.lhPulka.Text = Jazyk.Strings.Leva_horni_pulka;
            this.lhPulka.UseVisualStyleBackColor = true;
            // 
            // pPulka
            // 
            this.pPulka.AutoSize = true;
            this.pPulka.Location = new System.Drawing.Point(384, 171);
            this.pPulka.Name = "pPulka";
            this.pPulka.Size = new System.Drawing.Size(70, 17);
            this.pPulka.TabIndex = 58;
            this.pPulka.TabStop = true;
            this.pPulka.Text = Jazyk.Strings.Prava_pulka;
            this.pPulka.UseVisualStyleBackColor = true;
            // 
            // lPulka
            // 
            this.lPulka.AutoSize = true;
            this.lPulka.Location = new System.Drawing.Point(307, 171);
            this.lPulka.Name = "lPulka";
            this.lPulka.Size = new System.Drawing.Size(63, 17);
            this.lPulka.TabIndex = 57;
            this.lPulka.TabStop = true;
            this.lPulka.Text = Jazyk.Strings.Leva_pulka;
            this.lPulka.UseVisualStyleBackColor = true;
            // 
            // pPruh
            // 
            this.pPruh.AutoSize = true;
            this.pPruh.Location = new System.Drawing.Point(466, 150);
            this.pPruh.Name = "pPruh";
            this.pPruh.Size = new System.Drawing.Size(61, 17);
            this.pPruh.TabIndex = 56;
            this.pPruh.TabStop = true;
            this.pPruh.Text = Jazyk.Strings.Pravy_pruh;
            this.pPruh.UseVisualStyleBackColor = true;
            // 
            // lPruh
            // 
            this.lPruh.AutoSize = true;
            this.lPruh.Location = new System.Drawing.Point(384, 150);
            this.lPruh.Name = "lPruh";
            this.lPruh.Size = new System.Drawing.Size(71, 17);
            this.lPruh.TabIndex = 55;
            this.lPruh.TabStop = true;
            this.lPruh.Text = Jazyk.Strings.Levy_pruh;
            this.lPruh.UseVisualStyleBackColor = true;
            // 
            // pruhy
            // 
            this.pruhy.AutoSize = true;
            this.pruhy.Location = new System.Drawing.Point(307, 150);
            this.pruhy.Name = "pruhy";
            this.pruhy.Size = new System.Drawing.Size(57, 17);
            this.pruhy.TabIndex = 54;
            this.pruhy.TabStop = true;
            this.pruhy.Text = Jazyk.Strings.Pruhy;
            this.pruhy.UseVisualStyleBackColor = true;
            // 
            // dPulka
            // 
            this.dPulka.AutoSize = true;
            this.dPulka.Location = new System.Drawing.Point(384, 129);
            this.dPulka.Name = "dPulka";
            this.dPulka.Size = new System.Drawing.Size(74, 17);
            this.dPulka.TabIndex = 53;
            this.dPulka.TabStop = true;
            this.dPulka.Text = Jazyk.Strings.Dolni_pulka;
            this.dPulka.UseVisualStyleBackColor = true;
            // 
            // dPruh
            // 
            this.dPruh.AutoSize = true;
            this.dPruh.Location = new System.Drawing.Point(466, 129);
            this.dPruh.Name = "dPruh";
            this.dPruh.Size = new System.Drawing.Size(76, 17);
            this.dPruh.TabIndex = 52;
            this.dPruh.TabStop = true;
            this.dPruh.Text = Jazyk.Strings.Dolni_pruh;
            this.dPruh.UseVisualStyleBackColor = true;
            // 
            // hPulka
            // 
            this.hPulka.AutoSize = true;
            this.hPulka.Location = new System.Drawing.Point(307, 129);
            this.hPulka.Name = "hPulka";
            this.hPulka.Size = new System.Drawing.Size(74, 17);
            this.hPulka.TabIndex = 51;
            this.hPulka.TabStop = true;
            this.hPulka.Text = Jazyk.Strings.Horni_pulka;
            this.hPulka.UseVisualStyleBackColor = true;
            // 
            // hPruh
            // 
            this.hPruh.AutoSize = true;
            this.hPruh.Location = new System.Drawing.Point(466, 108);
            this.hPruh.Name = "hPruh";
            this.hPruh.Size = new System.Drawing.Size(76, 17);
            this.hPruh.TabIndex = 50;
            this.hPruh.TabStop = true;
            this.hPruh.Text = Jazyk.Strings.Horni_pruh;
            this.hPruh.UseVisualStyleBackColor = true;
            // 
            // kosoc
            // 
            this.kosoc.AutoSize = true;
            this.kosoc.Location = new System.Drawing.Point(384, 192);
            this.kosoc.Name = "kosoc";
            this.kosoc.Size = new System.Drawing.Size(70, 17);
            this.kosoc.TabIndex = 49;
            this.kosoc.TabStop = true;
            this.kosoc.Text = Jazyk.Strings.Kosoctverec;
            this.kosoc.UseVisualStyleBackColor = true;
            // 
            // svPruh
            // 
            this.svPruh.AutoSize = true;
            this.svPruh.Location = new System.Drawing.Point(384, 108);
            this.svPruh.Name = "svPruh";
            this.svPruh.Size = new System.Drawing.Size(58, 17);
            this.svPruh.TabIndex = 48;
            this.svPruh.TabStop = true;
            this.svPruh.Text = Jazyk.Strings.Svisly_pruh;
            this.svPruh.UseVisualStyleBackColor = true;
            // 
            // shPruh
            // 
            this.shPruh.AutoSize = true;
            this.shPruh.Location = new System.Drawing.Point(307, 108);
            this.shPruh.Name = "shPruh";
            this.shPruh.Size = new System.Drawing.Size(59, 17);
            this.shPruh.TabIndex = 47;
            this.shPruh.TabStop = true;
            this.shPruh.Text = Jazyk.Strings.Vodorovny_pruh;
            this.shPruh.UseVisualStyleBackColor = true;
            // 
            // zubyD
            // 
            this.zubyD.AutoSize = true;
            this.zubyD.Location = new System.Drawing.Point(466, 87);
            this.zubyD.Name = "zubyD";
            this.zubyD.Size = new System.Drawing.Size(75, 17);
            this.zubyD.TabIndex = 46;
            this.zubyD.TabStop = true;
            this.zubyD.Text = Jazyk.Strings.Dolni_zuby;
            this.zubyD.UseVisualStyleBackColor = true;
            // 
            // zubyH
            // 
            this.zubyH.AutoSize = true;
            this.zubyH.Location = new System.Drawing.Point(384, 87);
            this.zubyH.Name = "zubyH";
            this.zubyH.Size = new System.Drawing.Size(77, 17);
            this.zubyH.TabIndex = 45;
            this.zubyH.TabStop = true;
            this.zubyH.Text = Jazyk.Strings.Horni_zuby;
            this.zubyH.UseVisualStyleBackColor = true;
            // 
            // kriz
            // 
            this.kriz.AutoSize = true;
            this.kriz.Location = new System.Drawing.Point(307, 87);
            this.kriz.Name = "kriz";
            this.kriz.Size = new System.Drawing.Size(64, 17);
            this.kriz.TabIndex = 44;
            this.kriz.TabStop = true;
            this.kriz.Text = Jazyk.Strings.Kriz;
            this.kriz.UseVisualStyleBackColor = true;
            // 
            // pruhPD
            // 
            this.pruhPD.AutoSize = true;
            this.pruhPD.Location = new System.Drawing.Point(466, 66);
            this.pruhPD.Name = "pruhPD";
            this.pruhPD.Size = new System.Drawing.Size(69, 17);
            this.pruhPD.TabIndex = 43;
            this.pruhPD.TabStop = true;
            this.pruhPD.Text = Jazyk.Strings.Pruh_doprava_dolu;
            this.pruhPD.UseVisualStyleBackColor = true;
            // 
            // pruhLD
            // 
            this.pruhLD.AutoSize = true;
            this.pruhLD.Location = new System.Drawing.Point(466, 45);
            this.pruhLD.Name = "pruhLD";
            this.pruhLD.Size = new System.Drawing.Size(67, 17);
            this.pruhLD.TabIndex = 42;
            this.pruhLD.TabStop = true;
            this.pruhLD.Text = Jazyk.Strings.Pruh_doleva_dolu;
            this.pruhLD.UseVisualStyleBackColor = true;
            // 
            // trojD
            // 
            this.trojD.AutoSize = true;
            this.trojD.Location = new System.Drawing.Point(466, 171);
            this.trojD.Name = "trojD";
            this.trojD.Size = new System.Drawing.Size(73, 17);
            this.trojD.TabIndex = 41;
            this.trojD.TabStop = true;
            this.trojD.Text = Jazyk.Strings.Trojuhelnik_dole;
            this.trojD.UseVisualStyleBackColor = true;
            // 
            // trojH
            // 
            this.trojH.AutoSize = true;
            this.trojH.Location = new System.Drawing.Point(307, 191);
            this.trojH.Name = "trojH";
            this.trojH.Size = new System.Drawing.Size(73, 17);
            this.trojH.TabIndex = 40;
            this.trojH.TabStop = true;
            this.trojH.Text = Jazyk.Strings.Trojuhelnik_nahore;
            this.trojH.UseVisualStyleBackColor = true;
            // 
            // ctverecPD
            // 
            this.ctverecPD.AutoSize = true;
            this.ctverecPD.Location = new System.Drawing.Point(384, 66);
            this.ctverecPD.Name = "ctverecPD";
            this.ctverecPD.Size = new System.Drawing.Size(76, 17);
            this.ctverecPD.TabIndex = 39;
            this.ctverecPD.TabStop = true;
            this.ctverecPD.Text = Jazyk.Strings.Ctverec_vpravo_dole;
            this.ctverecPD.UseVisualStyleBackColor = true;
            // 
            // ctverecLD
            // 
            this.ctverecLD.AutoSize = true;
            this.ctverecLD.Location = new System.Drawing.Point(307, 66);
            this.ctverecLD.Name = "ctverecLD";
            this.ctverecLD.Size = new System.Drawing.Size(74, 17);
            this.ctverecLD.TabIndex = 38;
            this.ctverecLD.TabStop = true;
            this.ctverecLD.Text = Jazyk.Strings.Ctverec_vlevo_dole;
            this.ctverecLD.UseVisualStyleBackColor = true;
            // 
            // ctverecLH
            // 
            this.ctverecLH.AutoSize = true;
            this.ctverecLH.Location = new System.Drawing.Point(384, 45);
            this.ctverecLH.Name = "ctverecLH";
            this.ctverecLH.Size = new System.Drawing.Size(76, 17);
            this.ctverecLH.TabIndex = 37;
            this.ctverecLH.TabStop = true;
            this.ctverecLH.Text = Jazyk.Strings.Ctverec_vlevo_nahore;
            this.ctverecLH.UseVisualStyleBackColor = true;
            // 
            // ctverecPH
            // 
            this.ctverecPH.AutoSize = true;
            this.ctverecPH.Location = new System.Drawing.Point(307, 45);
            this.ctverecPH.Name = "ctverecPH";
            this.ctverecPH.Size = new System.Drawing.Size(78, 17);
            this.ctverecPH.TabIndex = 36;
            this.ctverecPH.TabStop = true;
            this.ctverecPH.Text = Jazyk.Strings.Ctverec_vpravo_nahore;
            this.ctverecPH.UseVisualStyleBackColor = true;
            // 
            // kruh
            // 
            this.kruh.AutoSize = true;
            this.kruh.Location = new System.Drawing.Point(466, 24);
            this.kruh.Name = "kruh";
            this.kruh.Size = new System.Drawing.Size(51, 17);
            this.kruh.TabIndex = 35;
            this.kruh.TabStop = true;
            this.kruh.Text = Jazyk.Strings.Kruh;
            this.kruh.UseVisualStyleBackColor = true;
            // 
            // cihly
            // 
            this.cihly.AutoSize = true;
            this.cihly.Location = new System.Drawing.Point(384, 24);
            this.cihly.Name = "cihly";
            this.cihly.Size = new System.Drawing.Size(54, 17);
            this.cihly.TabIndex = 34;
            this.cihly.TabStop = true;
            this.cihly.Text = Jazyk.Strings.Cihly;
            this.cihly.UseVisualStyleBackColor = true;
            // 
            // kvetina
            // 
            this.kvetina.AutoSize = true;
            this.kvetina.Location = new System.Drawing.Point(307, 24);
            this.kvetina.Name = "kvetina";
            this.kvetina.Size = new System.Drawing.Size(56, 17);
            this.kvetina.TabIndex = 33;
            this.kvetina.TabStop = true;
            this.kvetina.Text = Jazyk.Strings.Kvetina;
            this.kvetina.UseVisualStyleBackColor = true;
            // 
            // lebka
            // 
            this.lebka.AutoSize = true;
            this.lebka.Location = new System.Drawing.Point(466, 3);
            this.lebka.Name = "lebka";
            this.lebka.Size = new System.Drawing.Size(48, 17);
            this.lebka.TabIndex = 32;
            this.lebka.TabStop = true;
            this.lebka.Text = Jazyk.Strings.Lebka;
            this.lebka.UseVisualStyleBackColor = true;
            // 
            // creeper
            // 
            this.creeper.AutoSize = true;
            this.creeper.Location = new System.Drawing.Point(384, 3);
            this.creeper.Name = "creeper";
            this.creeper.Size = new System.Drawing.Size(62, 17);
            this.creeper.TabIndex = 31;
            this.creeper.TabStop = true;
            this.creeper.Text = Jazyk.Strings.Creeper;
            this.creeper.UseVisualStyleBackColor = true;
            // 
            // ramecek
            // 
            this.ramecek.AutoSize = true;
            this.ramecek.Checked = true;
            this.ramecek.Location = new System.Drawing.Point(307, 3);
            this.ramecek.Name = "ramecek";
            this.ramecek.Size = new System.Drawing.Size(56, 17);
            this.ramecek.TabIndex = 30;
            this.ramecek.TabStop = true;
            this.ramecek.Text = Jazyk.Strings.Ramecek;
            this.ramecek.UseVisualStyleBackColor = true;
            // 
            // zmenitBarvu
            // 
            this.zmenitBarvu.Enabled = false;
            this.zmenitBarvu.Location = new System.Drawing.Point(246, 136);
            this.zmenitBarvu.Name = "zmenitBarvu";
            this.zmenitBarvu.Size = new System.Drawing.Size(55, 39);
            this.zmenitBarvu.TabIndex = 7;
            this.zmenitBarvu.Text = Jazyk.Strings.Zmenit_barvu;
            this.zmenitBarvu.UseVisualStyleBackColor = true;
            this.zmenitBarvu.Click += new System.EventHandler(this.zmenitBarvu_Click);
            // 
            // pridatPatternu
            // 
            this.pridatPatternu.Location = new System.Drawing.Point(246, 91);
            this.pridatPatternu.Name = "pridatPatternu";
            this.pridatPatternu.Size = new System.Drawing.Size(55, 39);
            this.pridatPatternu.TabIndex = 5;
            this.pridatPatternu.Text = Jazyk.Strings.Pridat_patternu;
            this.pridatPatternu.UseVisualStyleBackColor = true;
            this.pridatPatternu.Click += new System.EventHandler(this.pridatPatternu_Click);
            // 
            // dolu
            // 
            this.dolu.Enabled = false;
            this.dolu.Image = ((System.Drawing.Image)(resources.GetObject("dolu.Image")));
            this.dolu.Location = new System.Drawing.Point(246, 55);
            this.dolu.Name = "dolu";
            this.dolu.Size = new System.Drawing.Size(30, 30);
            this.dolu.TabIndex = 4;
            this.dolu.UseVisualStyleBackColor = true;
            this.dolu.Click += new System.EventHandler(this.dolu_Click);
            // 
            // nahoru
            // 
            this.nahoru.Enabled = false;
            this.nahoru.Image = ((System.Drawing.Image)(resources.GetObject("nahoru.Image")));
            this.nahoru.Location = new System.Drawing.Point(246, 19);
            this.nahoru.Name = "nahoru";
            this.nahoru.Size = new System.Drawing.Size(30, 30);
            this.nahoru.TabIndex = 4;
            this.nahoru.UseVisualStyleBackColor = true;
            this.nahoru.Click += new System.EventHandler(this.nahoru_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(117, 3);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = Jazyk.Strings.Seznam_pattern;
            // 
            // patternyView
            // 
            this.patternyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4});
            this.patternyView.FullRowSelect = true;
            this.patternyView.GridLines = true;
            this.patternyView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.patternyView.HideSelection = false;
            this.patternyView.Location = new System.Drawing.Point(120, 19);
            this.patternyView.MultiSelect = false;
            this.patternyView.Name = "patternyView";
            this.patternyView.Size = new System.Drawing.Size(120, 252);
            this.patternyView.TabIndex = 2;
            this.patternyView.UseCompatibleStateImageBehavior = false;
            this.patternyView.View = System.Windows.Forms.View.Details;
            this.patternyView.SelectedIndexChanged += new System.EventHandler(this.patternyView_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Width = 116;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 3);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = Jazyk.Strings.Nahled_banneru;
            // 
            // bannerNahled
            // 
            this.bannerNahled.Location = new System.Drawing.Point(3, 19);
            this.bannerNahled.Name = "bannerNahled";
            this.bannerNahled.Size = new System.Drawing.Size(100, 200);
            this.bannerNahled.TabIndex = 0;
            this.bannerNahled.TabStop = false;
            // 
            // rovKriz
            // 
            this.rovKriz.AutoSize = true;
            this.rovKriz.Location = new System.Drawing.Point(307, 254);
            this.rovKriz.Name = "rovKriz";
            this.rovKriz.Size = new System.Drawing.Size(71, 17);
            this.rovKriz.TabIndex = 67;
            this.rovKriz.TabStop = true;
            this.rovKriz.Text = Jazyk.Strings.Rovny_kriz;
            this.rovKriz.UseVisualStyleBackColor = true;
            // 
            // VlastnostiItemu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 324);
            this.Controls.Add(this.bannerPanel);
            this.Controls.Add(this.dolet);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.odebratVybuch);
            this.Controls.Add(this.pridatVybuch);
            this.Controls.Add(this.efektyView);
            this.Controls.Add(this.odebratPrechod);
            this.Controls.Add(this.pridatPrechod);
            this.Controls.Add(this.prechodyView);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.zrusitBarvu);
            this.Controls.Add(this.pridatBarvu);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.barvyView);
            this.Controls.Add(this.jmeno);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "VlastnostiItemu";
            this.ShowIcon = false;
            this.Text = Jazyk.Strings.Vlastnosti_itemu;
            this.panel.ResumeLayout(false);
            this.panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dolet)).EndInit();
            this.bannerPanel.ResumeLayout(false);
            this.bannerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bannerNahled)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox jmeno;
        private System.Windows.Forms.ListView barvyView;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button pridatBarvu;
        private System.Windows.Forms.Button zrusitBarvu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView prechodyView;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button pridatPrechod;
        private System.Windows.Forms.Button odebratPrechod;
        private System.Windows.Forms.ListView efektyView;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button pridatVybuch;
        private System.Windows.Forms.Button odebratVybuch;
        private System.Windows.Forms.GroupBox panel;
        private System.Windows.Forms.RadioButton rozprsknuti;
        private System.Windows.Forms.RadioButton hlavaCreepera;
        private System.Windows.Forms.RadioButton hvezda;
        private System.Windows.Forms.RadioButton velkaKoule;
        private System.Windows.Forms.RadioButton malaKoule;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown dolet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox trail;
        private System.Windows.Forms.CheckBox flicker;
        internal System.Windows.Forms.Panel bannerPanel;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.PictureBox bannerNahled;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Button dolu;
        private System.Windows.Forms.Button nahoru;
        private System.Windows.Forms.Button pridatPatternu;
        private System.Windows.Forms.Button zmenitBarvu;
        internal System.Windows.Forms.ListView patternyView;
        private System.Windows.Forms.RadioButton lhPulka;
        private System.Windows.Forms.RadioButton pPulka;
        private System.Windows.Forms.RadioButton lPulka;
        private System.Windows.Forms.RadioButton pPruh;
        private System.Windows.Forms.RadioButton lPruh;
        private System.Windows.Forms.RadioButton pruhy;
        private System.Windows.Forms.RadioButton dPulka;
        private System.Windows.Forms.RadioButton dPruh;
        private System.Windows.Forms.RadioButton hPulka;
        private System.Windows.Forms.RadioButton hPruh;
        private System.Windows.Forms.RadioButton kosoc;
        private System.Windows.Forms.RadioButton svPruh;
        private System.Windows.Forms.RadioButton shPruh;
        private System.Windows.Forms.RadioButton zubyD;
        private System.Windows.Forms.RadioButton zubyH;
        private System.Windows.Forms.RadioButton kriz;
        private System.Windows.Forms.RadioButton pruhPD;
        private System.Windows.Forms.RadioButton pruhLD;
        private System.Windows.Forms.RadioButton trojD;
        private System.Windows.Forms.RadioButton trojH;
        private System.Windows.Forms.RadioButton ctverecPD;
        private System.Windows.Forms.RadioButton ctverecLD;
        private System.Windows.Forms.RadioButton ctverecLH;
        private System.Windows.Forms.RadioButton ctverecPH;
        private System.Windows.Forms.RadioButton kruh;
        private System.Windows.Forms.RadioButton cihly;
        private System.Windows.Forms.RadioButton kvetina;
        private System.Windows.Forms.RadioButton lebka;
        private System.Windows.Forms.RadioButton creeper;
        private System.Windows.Forms.RadioButton ramecek;
        private System.Windows.Forms.RadioButton phPulka;
        private System.Windows.Forms.RadioButton pdPulka;
        private System.Windows.Forms.RadioButton ldPulka;
        private System.Windows.Forms.RadioButton gradientDolu;
        private System.Windows.Forms.RadioButton gradientH;
        private System.Windows.Forms.RadioButton vlnRam;
        private System.Windows.Forms.Button smazat;
        private System.Windows.Forms.RadioButton rovKriz;
    }
}