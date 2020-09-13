using System;
using System.Windows.Forms;

namespace SaveEdit
{
    partial class Form1
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
            this.Visible = false;
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.novy = new System.Windows.Forms.ToolStripButton();
            this.otevrit = new System.Windows.Forms.ToolStripSplitButton();
            this.ulozit = new System.Windows.Forms.ToolStripButton();
            this.splitter = new System.Windows.Forms.ToolStripSeparator();
            this.kopirovatBtn = new System.Windows.Forms.ToolStripButton();
            this.vlozitBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSeparator();
            this.moznostiHry = new System.Windows.Forms.ToolStripButton();
            this.OProgramu = new System.Windows.Forms.ToolStripDropDownButton();
            this.oProgramuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aktualizovatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jazykToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.češtinaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.poslatNápadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nahlásitChybuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nápovědaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changelogToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateButton = new System.Windows.Forms.ToolStripButton();
            this.aktualizaceInfo = new System.Windows.Forms.ToolStripLabel();
            this.kategorieBtn = new System.Windows.Forms.ToolStripButton();
            this.i103 = new System.Windows.Forms.Button();
            this.i102 = new System.Windows.Forms.Button();
            this.i101 = new System.Windows.Forms.Button();
            this.i100 = new System.Windows.Forms.Button();
            this.i9 = new System.Windows.Forms.Button();
            this.i0 = new System.Windows.Forms.Button();
            this.i1 = new System.Windows.Forms.Button();
            this.i2 = new System.Windows.Forms.Button();
            this.i3 = new System.Windows.Forms.Button();
            this.i4 = new System.Windows.Forms.Button();
            this.i5 = new System.Windows.Forms.Button();
            this.i6 = new System.Windows.Forms.Button();
            this.i7 = new System.Windows.Forms.Button();
            this.i8 = new System.Windows.Forms.Button();
            this.i10 = new System.Windows.Forms.Button();
            this.i11 = new System.Windows.Forms.Button();
            this.i12 = new System.Windows.Forms.Button();
            this.i13 = new System.Windows.Forms.Button();
            this.i14 = new System.Windows.Forms.Button();
            this.i15 = new System.Windows.Forms.Button();
            this.i16 = new System.Windows.Forms.Button();
            this.i17 = new System.Windows.Forms.Button();
            this.i26 = new System.Windows.Forms.Button();
            this.i25 = new System.Windows.Forms.Button();
            this.i24 = new System.Windows.Forms.Button();
            this.i23 = new System.Windows.Forms.Button();
            this.i22 = new System.Windows.Forms.Button();
            this.i21 = new System.Windows.Forms.Button();
            this.i20 = new System.Windows.Forms.Button();
            this.i19 = new System.Windows.Forms.Button();
            this.i18 = new System.Windows.Forms.Button();
            this.i35 = new System.Windows.Forms.Button();
            this.i34 = new System.Windows.Forms.Button();
            this.i33 = new System.Windows.Forms.Button();
            this.i32 = new System.Windows.Forms.Button();
            this.i31 = new System.Windows.Forms.Button();
            this.i30 = new System.Windows.Forms.Button();
            this.i29 = new System.Windows.Forms.Button();
            this.i28 = new System.Windows.Forms.Button();
            this.i27 = new System.Windows.Forms.Button();
            this.lbl_pocet = new System.Windows.Forms.Label();
            this.lbl_poskozeni = new System.Windows.Forms.Label();
            this.poskozeni = new System.Windows.Forms.NumericUpDown();
            this.pocet = new System.Windows.Forms.NumericUpDown();
            this.vyhledavani = new System.Windows.Forms.TextBox();
            this.otevritDial = new System.Windows.Forms.OpenFileDialog();
            this.lbl_xpLevel = new System.Windows.Forms.Label();
            this.xplevel = new System.Windows.Forms.TextBox();
            this.poNacteni = new System.Windows.Forms.Panel();
            this.lbl_zacit = new System.Windows.Forms.Label();
            this.seznamBlocku = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.seznamBlockuSearch = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.popisek = new System.Windows.Forms.ToolTip(this.components);
            this.vlastnosti = new System.Windows.Forms.Button();
            this.enchantyButton = new System.Windows.Forms.Button();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.lbl_nacitaniItemu = new System.Windows.Forms.Label();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker4 = new System.ComponentModel.BackgroundWorker();
            this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.přidatItemDoSeznamuItemůToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.i150 = new System.Windows.Forms.Button();
            this.kos = new System.Windows.Forms.Button();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poskozeni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pocet)).BeginInit();
            this.poNacteni.SuspendLayout();
            this.contextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.novy,
            this.otevrit,
            this.ulozit,
            this.splitter,
            this.kopirovatBtn,
            this.vlozitBtn,
            this.toolStripButton1,
            this.moznostiHry,
            this.OProgramu,
            this.updateButton,
            this.aktualizaceInfo,
            this.kategorieBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(769, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // novy
            // 
            this.novy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.novy.Image = global::SaveEdit.Properties.Resources.new1;
            this.novy.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.novy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.novy.Name = "novy";
            this.novy.Size = new System.Drawing.Size(23, 22);
            this.novy.Text = "Přidat vlastní item";
            this.novy.Click += new System.EventHandler(this.novy_Click);
            // 
            // otevrit
            // 
            this.otevrit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.otevrit.Image = global::SaveEdit.Properties.Resources.OpenButton1;
            this.otevrit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.otevrit.Name = "otevrit";
            this.otevrit.Size = new System.Drawing.Size(32, 22);
            this.otevrit.Text = "Otevřít";
            this.otevrit.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.otevrit_DropDownItemClicked);
            this.otevrit.Click += new System.EventHandler(this.otevrit_Click);
            // 
            // ulozit
            // 
            this.ulozit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ulozit.Enabled = false;
            this.ulozit.Image = global::SaveEdit.Properties.Resources.SaveButton1;
            this.ulozit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ulozit.Name = "ulozit";
            this.ulozit.Size = new System.Drawing.Size(23, 22);
            this.ulozit.Text = "Uložit";
            this.ulozit.Click += new System.EventHandler(this.ulozit_Click);
            // 
            // splitter
            // 
            this.splitter.Name = "splitter";
            this.splitter.Size = new System.Drawing.Size(6, 25);
            // 
            // kopirovatBtn
            // 
            this.kopirovatBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.kopirovatBtn.Image = global::SaveEdit.Properties.Resources.copy_32;
            this.kopirovatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kopirovatBtn.Name = "kopirovatBtn";
            this.kopirovatBtn.Size = new System.Drawing.Size(23, 22);
            this.kopirovatBtn.Text = "Kopírovat";
            this.kopirovatBtn.Click += new System.EventHandler(this.kopirovatBtn_Click);
            // 
            // vlozitBtn
            // 
            this.vlozitBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.vlozitBtn.Image = global::SaveEdit.Properties.Resources.page_paste;
            this.vlozitBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.vlozitBtn.Name = "vlozitBtn";
            this.vlozitBtn.Size = new System.Drawing.Size(23, 22);
            this.vlozitBtn.Text = "Vložit";
            this.vlozitBtn.Click += new System.EventHandler(this.vlozitBtn_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(6, 25);
            // 
            // moznostiHry
            // 
            this.moznostiHry.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.moznostiHry.Enabled = false;
            this.moznostiHry.Image = global::SaveEdit.Properties.Resources.settings;
            this.moznostiHry.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.moznostiHry.Name = "moznostiHry";
            this.moznostiHry.Size = new System.Drawing.Size(23, 22);
            this.moznostiHry.Text = "Možnosti hry";
            this.moznostiHry.Click += new System.EventHandler(this.moznostiHry_Click);
            // 
            // OProgramu
            // 
            this.OProgramu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.OProgramu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.oProgramuToolStripMenuItem,
            this.aktualizovatToolStripMenuItem,
            this.jazykToolStripMenuItem,
            this.poslatNápadToolStripMenuItem,
            this.nahlásitChybuToolStripMenuItem,
            this.nápovědaToolStripMenuItem,
            this.changelogToolStripMenuItem});
            this.OProgramu.Image = global::SaveEdit.Properties.Resources.OProgramu;
            this.OProgramu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.OProgramu.Name = "OProgramu";
            this.OProgramu.Size = new System.Drawing.Size(29, 22);
            this.OProgramu.Text = "O programu";
            this.OProgramu.ToolTipText = "O programu";
            // 
            // oProgramuToolStripMenuItem
            // 
            this.oProgramuToolStripMenuItem.Name = "oProgramuToolStripMenuItem";
            this.oProgramuToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.oProgramuToolStripMenuItem.Text = "O programu";
            this.oProgramuToolStripMenuItem.Click += new System.EventHandler(this.oProgramu_Click);
            // 
            // aktualizovatToolStripMenuItem
            // 
            this.aktualizovatToolStripMenuItem.Name = "aktualizovatToolStripMenuItem";
            this.aktualizovatToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.aktualizovatToolStripMenuItem.Text = "Vyhledat aktualizace";
            this.aktualizovatToolStripMenuItem.Click += new System.EventHandler(this.aktualizovatProgram_Click);
            // 
            // jazykToolStripMenuItem
            // 
            this.jazykToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.češtinaToolStripMenuItem,
            this.englishToolStripMenuItem});
            this.jazykToolStripMenuItem.Name = "jazykToolStripMenuItem";
            this.jazykToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.jazykToolStripMenuItem.Text = "Jazyk";
            this.jazykToolStripMenuItem.Visible = false;
            // 
            // češtinaToolStripMenuItem
            // 
            this.češtinaToolStripMenuItem.Name = "češtinaToolStripMenuItem";
            this.češtinaToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.češtinaToolStripMenuItem.Text = "Čeština";
            this.češtinaToolStripMenuItem.Click += new System.EventHandler(this.češtinaToolStripMenuItem_Click);
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.englishToolStripMenuItem.Text = "English";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.englishToolStripMenuItem_Click);
            // 
            // poslatNápadToolStripMenuItem
            // 
            this.poslatNápadToolStripMenuItem.Name = "poslatNápadToolStripMenuItem";
            this.poslatNápadToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.poslatNápadToolStripMenuItem.Text = "Poslat nápad";
            this.poslatNápadToolStripMenuItem.Click += new System.EventHandler(this.poslatNápadToolStripMenuItem_Click);
            // 
            // nahlásitChybuToolStripMenuItem
            // 
            this.nahlásitChybuToolStripMenuItem.Name = "nahlásitChybuToolStripMenuItem";
            this.nahlásitChybuToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.nahlásitChybuToolStripMenuItem.Text = "Nahlásit chybu";
            this.nahlásitChybuToolStripMenuItem.Click += new System.EventHandler(this.odeslatInfoOChyběnápadToolStripMenuItem_Click);
            // 
            // nápovědaToolStripMenuItem
            // 
            this.nápovědaToolStripMenuItem.Name = "nápovědaToolStripMenuItem";
            this.nápovědaToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.nápovědaToolStripMenuItem.Text = "Nápověda";
            this.nápovědaToolStripMenuItem.Click += new System.EventHandler(this.nápovědaToolStripMenuItem_Click);
            // 
            // changelogToolStripMenuItem
            // 
            this.changelogToolStripMenuItem.Name = "changelogToolStripMenuItem";
            this.changelogToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.changelogToolStripMenuItem.Text = "Changelog";
            this.changelogToolStripMenuItem.Click += new System.EventHandler(this.changelogToolStripMenuItem_Click);
            // 
            // updateButton
            // 
            this.updateButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.updateButton.Image = global::SaveEdit.Properties.Resources.arr;
            this.updateButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(23, 22);
            this.updateButton.Text = "Aktualizovat";
            this.updateButton.ToolTipText = "Aktualizovat";
            this.updateButton.Visible = false;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // aktualizaceInfo
            // 
            this.aktualizaceInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.aktualizaceInfo.Enabled = false;
            this.aktualizaceInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.aktualizaceInfo.Name = "aktualizaceInfo";
            this.aktualizaceInfo.Size = new System.Drawing.Size(0, 22);
            // 
            // kategorieBtn
            // 
            this.kategorieBtn.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.kategorieBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.kategorieBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.kategorieBtn.Name = "kategorieBtn";
            this.kategorieBtn.Size = new System.Drawing.Size(80, 22);
            this.kategorieBtn.Text = "Kategorie >>";
            this.kategorieBtn.ToolTipText = "Seznam kategorií";
            this.kategorieBtn.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // i103
            // 
            this.i103.AllowDrop = true;
            this.i103.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i103.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i103.Location = new System.Drawing.Point(12, 39);
            this.i103.Name = "i103";
            this.i103.Size = new System.Drawing.Size(48, 48);
            this.i103.TabIndex = 1;
            this.i103.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i103.UseVisualStyleBackColor = true;
            this.i103.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i103.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i103.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i103.MouseLeave += new System.EventHandler(this.Vylez);
            this.i103.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i102
            // 
            this.i102.AllowDrop = true;
            this.i102.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i102.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i102.Location = new System.Drawing.Point(12, 93);
            this.i102.Name = "i102";
            this.i102.Size = new System.Drawing.Size(48, 48);
            this.i102.TabIndex = 2;
            this.i102.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i102.UseVisualStyleBackColor = true;
            this.i102.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i102.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i102.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i102.MouseLeave += new System.EventHandler(this.Vylez);
            this.i102.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i101
            // 
            this.i101.AllowDrop = true;
            this.i101.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i101.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i101.Location = new System.Drawing.Point(12, 147);
            this.i101.Name = "i101";
            this.i101.Size = new System.Drawing.Size(48, 48);
            this.i101.TabIndex = 3;
            this.i101.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i101.UseVisualStyleBackColor = true;
            this.i101.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i101.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i101.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i101.MouseLeave += new System.EventHandler(this.Vylez);
            this.i101.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i100
            // 
            this.i100.AllowDrop = true;
            this.i100.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i100.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i100.Location = new System.Drawing.Point(12, 201);
            this.i100.Name = "i100";
            this.i100.Size = new System.Drawing.Size(48, 48);
            this.i100.TabIndex = 4;
            this.i100.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i100.UseVisualStyleBackColor = true;
            this.i100.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i100.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i100.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i100.MouseLeave += new System.EventHandler(this.Vylez);
            this.i100.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i9
            // 
            this.i9.AllowDrop = true;
            this.i9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i9.Location = new System.Drawing.Point(94, 82);
            this.i9.Name = "i9";
            this.i9.Size = new System.Drawing.Size(48, 48);
            this.i9.TabIndex = 5;
            this.i9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i9.UseVisualStyleBackColor = true;
            this.i9.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i9.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i9.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i9.MouseLeave += new System.EventHandler(this.Vylez);
            this.i9.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i0
            // 
            this.i0.AllowDrop = true;
            this.i0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i0.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i0.Location = new System.Drawing.Point(94, 272);
            this.i0.Name = "i0";
            this.i0.Size = new System.Drawing.Size(48, 48);
            this.i0.TabIndex = 6;
            this.i0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i0.UseVisualStyleBackColor = true;
            this.i0.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i0.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i0.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i0.MouseLeave += new System.EventHandler(this.Vylez);
            this.i0.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i1
            // 
            this.i1.AllowDrop = true;
            this.i1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i1.Location = new System.Drawing.Point(148, 272);
            this.i1.Name = "i1";
            this.i1.Size = new System.Drawing.Size(48, 48);
            this.i1.TabIndex = 7;
            this.i1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i1.UseVisualStyleBackColor = true;
            this.i1.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i1.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i1.MouseLeave += new System.EventHandler(this.Vylez);
            this.i1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i2
            // 
            this.i2.AllowDrop = true;
            this.i2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i2.Location = new System.Drawing.Point(202, 272);
            this.i2.Name = "i2";
            this.i2.Size = new System.Drawing.Size(48, 48);
            this.i2.TabIndex = 8;
            this.i2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i2.UseVisualStyleBackColor = true;
            this.i2.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i2.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i2.MouseLeave += new System.EventHandler(this.Vylez);
            this.i2.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i3
            // 
            this.i3.AllowDrop = true;
            this.i3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i3.Location = new System.Drawing.Point(256, 272);
            this.i3.Name = "i3";
            this.i3.Size = new System.Drawing.Size(48, 48);
            this.i3.TabIndex = 9;
            this.i3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i3.UseVisualStyleBackColor = true;
            this.i3.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i3.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i3.MouseLeave += new System.EventHandler(this.Vylez);
            this.i3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i4
            // 
            this.i4.AllowDrop = true;
            this.i4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i4.Location = new System.Drawing.Point(310, 272);
            this.i4.Name = "i4";
            this.i4.Size = new System.Drawing.Size(48, 48);
            this.i4.TabIndex = 10;
            this.i4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i4.UseVisualStyleBackColor = true;
            this.i4.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i4.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i4.MouseLeave += new System.EventHandler(this.Vylez);
            this.i4.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i5
            // 
            this.i5.AllowDrop = true;
            this.i5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i5.Location = new System.Drawing.Point(364, 272);
            this.i5.Name = "i5";
            this.i5.Size = new System.Drawing.Size(48, 48);
            this.i5.TabIndex = 11;
            this.i5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i5.UseVisualStyleBackColor = true;
            this.i5.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i5.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i5.MouseLeave += new System.EventHandler(this.Vylez);
            this.i5.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i6
            // 
            this.i6.AllowDrop = true;
            this.i6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i6.Location = new System.Drawing.Point(418, 272);
            this.i6.Name = "i6";
            this.i6.Size = new System.Drawing.Size(48, 48);
            this.i6.TabIndex = 12;
            this.i6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i6.UseVisualStyleBackColor = true;
            this.i6.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i6.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i6.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i6.MouseLeave += new System.EventHandler(this.Vylez);
            this.i6.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i7
            // 
            this.i7.AllowDrop = true;
            this.i7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i7.Location = new System.Drawing.Point(472, 272);
            this.i7.Name = "i7";
            this.i7.Size = new System.Drawing.Size(48, 48);
            this.i7.TabIndex = 13;
            this.i7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i7.UseVisualStyleBackColor = true;
            this.i7.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i7.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i7.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i7.MouseLeave += new System.EventHandler(this.Vylez);
            this.i7.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i8
            // 
            this.i8.AllowDrop = true;
            this.i8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i8.Location = new System.Drawing.Point(526, 272);
            this.i8.Name = "i8";
            this.i8.Size = new System.Drawing.Size(48, 48);
            this.i8.TabIndex = 14;
            this.i8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i8.UseVisualStyleBackColor = true;
            this.i8.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i8.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i8.MouseLeave += new System.EventHandler(this.Vylez);
            this.i8.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i10
            // 
            this.i10.AllowDrop = true;
            this.i10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i10.Location = new System.Drawing.Point(148, 82);
            this.i10.Name = "i10";
            this.i10.Size = new System.Drawing.Size(48, 48);
            this.i10.TabIndex = 15;
            this.i10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i10.UseVisualStyleBackColor = true;
            this.i10.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i10.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i10.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i10.MouseLeave += new System.EventHandler(this.Vylez);
            this.i10.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i11
            // 
            this.i11.AllowDrop = true;
            this.i11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i11.Location = new System.Drawing.Point(202, 82);
            this.i11.Name = "i11";
            this.i11.Size = new System.Drawing.Size(48, 48);
            this.i11.TabIndex = 16;
            this.i11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i11.UseVisualStyleBackColor = true;
            this.i11.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i11.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i11.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i11.MouseLeave += new System.EventHandler(this.Vylez);
            this.i11.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i12
            // 
            this.i12.AllowDrop = true;
            this.i12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i12.Location = new System.Drawing.Point(256, 82);
            this.i12.Name = "i12";
            this.i12.Size = new System.Drawing.Size(48, 48);
            this.i12.TabIndex = 17;
            this.i12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i12.UseVisualStyleBackColor = true;
            this.i12.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i12.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i12.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i12.MouseLeave += new System.EventHandler(this.Vylez);
            this.i12.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i13
            // 
            this.i13.AllowDrop = true;
            this.i13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i13.Location = new System.Drawing.Point(310, 82);
            this.i13.Name = "i13";
            this.i13.Size = new System.Drawing.Size(48, 48);
            this.i13.TabIndex = 18;
            this.i13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i13.UseVisualStyleBackColor = true;
            this.i13.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i13.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i13.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i13.MouseLeave += new System.EventHandler(this.Vylez);
            this.i13.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i14
            // 
            this.i14.AllowDrop = true;
            this.i14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i14.Location = new System.Drawing.Point(364, 82);
            this.i14.Name = "i14";
            this.i14.Size = new System.Drawing.Size(48, 48);
            this.i14.TabIndex = 19;
            this.i14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i14.UseVisualStyleBackColor = true;
            this.i14.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i14.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i14.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i14.MouseLeave += new System.EventHandler(this.Vylez);
            this.i14.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i15
            // 
            this.i15.AllowDrop = true;
            this.i15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i15.Location = new System.Drawing.Point(418, 82);
            this.i15.Name = "i15";
            this.i15.Size = new System.Drawing.Size(48, 48);
            this.i15.TabIndex = 20;
            this.i15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i15.UseVisualStyleBackColor = true;
            this.i15.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i15.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i15.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i15.MouseLeave += new System.EventHandler(this.Vylez);
            this.i15.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i16
            // 
            this.i16.AllowDrop = true;
            this.i16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i16.Location = new System.Drawing.Point(472, 82);
            this.i16.Name = "i16";
            this.i16.Size = new System.Drawing.Size(48, 48);
            this.i16.TabIndex = 21;
            this.i16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i16.UseVisualStyleBackColor = true;
            this.i16.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i16.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i16.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i16.MouseLeave += new System.EventHandler(this.Vylez);
            this.i16.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i17
            // 
            this.i17.AllowDrop = true;
            this.i17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i17.Location = new System.Drawing.Point(526, 82);
            this.i17.Name = "i17";
            this.i17.Size = new System.Drawing.Size(48, 48);
            this.i17.TabIndex = 22;
            this.i17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i17.UseVisualStyleBackColor = true;
            this.i17.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i17.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i17.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i17.MouseLeave += new System.EventHandler(this.Vylez);
            this.i17.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i26
            // 
            this.i26.AllowDrop = true;
            this.i26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i26.Location = new System.Drawing.Point(526, 136);
            this.i26.Name = "i26";
            this.i26.Size = new System.Drawing.Size(48, 48);
            this.i26.TabIndex = 31;
            this.i26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i26.UseVisualStyleBackColor = true;
            this.i26.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i26.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i26.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i26.MouseLeave += new System.EventHandler(this.Vylez);
            this.i26.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i25
            // 
            this.i25.AllowDrop = true;
            this.i25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i25.Location = new System.Drawing.Point(472, 136);
            this.i25.Name = "i25";
            this.i25.Size = new System.Drawing.Size(48, 48);
            this.i25.TabIndex = 30;
            this.i25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i25.UseVisualStyleBackColor = true;
            this.i25.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i25.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i25.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i25.MouseLeave += new System.EventHandler(this.Vylez);
            this.i25.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i24
            // 
            this.i24.AllowDrop = true;
            this.i24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i24.Location = new System.Drawing.Point(418, 136);
            this.i24.Name = "i24";
            this.i24.Size = new System.Drawing.Size(48, 48);
            this.i24.TabIndex = 29;
            this.i24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i24.UseVisualStyleBackColor = true;
            this.i24.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i24.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i24.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i24.MouseLeave += new System.EventHandler(this.Vylez);
            this.i24.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i23
            // 
            this.i23.AllowDrop = true;
            this.i23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i23.Location = new System.Drawing.Point(364, 136);
            this.i23.Name = "i23";
            this.i23.Size = new System.Drawing.Size(48, 48);
            this.i23.TabIndex = 28;
            this.i23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i23.UseVisualStyleBackColor = true;
            this.i23.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i23.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i23.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i23.MouseLeave += new System.EventHandler(this.Vylez);
            this.i23.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i22
            // 
            this.i22.AllowDrop = true;
            this.i22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i22.Location = new System.Drawing.Point(310, 136);
            this.i22.Name = "i22";
            this.i22.Size = new System.Drawing.Size(48, 48);
            this.i22.TabIndex = 27;
            this.i22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i22.UseVisualStyleBackColor = true;
            this.i22.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i22.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i22.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i22.MouseLeave += new System.EventHandler(this.Vylez);
            this.i22.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i21
            // 
            this.i21.AllowDrop = true;
            this.i21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i21.Location = new System.Drawing.Point(256, 136);
            this.i21.Name = "i21";
            this.i21.Size = new System.Drawing.Size(48, 48);
            this.i21.TabIndex = 26;
            this.i21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i21.UseVisualStyleBackColor = true;
            this.i21.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i21.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i21.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i21.MouseLeave += new System.EventHandler(this.Vylez);
            this.i21.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i20
            // 
            this.i20.AllowDrop = true;
            this.i20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i20.Location = new System.Drawing.Point(202, 136);
            this.i20.Name = "i20";
            this.i20.Size = new System.Drawing.Size(48, 48);
            this.i20.TabIndex = 25;
            this.i20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i20.UseVisualStyleBackColor = true;
            this.i20.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i20.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i20.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i20.MouseLeave += new System.EventHandler(this.Vylez);
            this.i20.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i19
            // 
            this.i19.AllowDrop = true;
            this.i19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i19.Location = new System.Drawing.Point(148, 136);
            this.i19.Name = "i19";
            this.i19.Size = new System.Drawing.Size(48, 48);
            this.i19.TabIndex = 24;
            this.i19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i19.UseVisualStyleBackColor = true;
            this.i19.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i19.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i19.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i19.MouseLeave += new System.EventHandler(this.Vylez);
            this.i19.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i18
            // 
            this.i18.AllowDrop = true;
            this.i18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i18.Location = new System.Drawing.Point(94, 136);
            this.i18.Name = "i18";
            this.i18.Size = new System.Drawing.Size(48, 48);
            this.i18.TabIndex = 23;
            this.i18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i18.UseVisualStyleBackColor = true;
            this.i18.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i18.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i18.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i18.MouseLeave += new System.EventHandler(this.Vylez);
            this.i18.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i35
            // 
            this.i35.AllowDrop = true;
            this.i35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i35.Location = new System.Drawing.Point(526, 190);
            this.i35.Name = "i35";
            this.i35.Size = new System.Drawing.Size(48, 48);
            this.i35.TabIndex = 40;
            this.i35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i35.UseVisualStyleBackColor = true;
            this.i35.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i35.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i35.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i35.MouseLeave += new System.EventHandler(this.Vylez);
            this.i35.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i34
            // 
            this.i34.AllowDrop = true;
            this.i34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i34.Location = new System.Drawing.Point(472, 190);
            this.i34.Name = "i34";
            this.i34.Size = new System.Drawing.Size(48, 48);
            this.i34.TabIndex = 39;
            this.i34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i34.UseVisualStyleBackColor = true;
            this.i34.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i34.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i34.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i34.MouseLeave += new System.EventHandler(this.Vylez);
            this.i34.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i33
            // 
            this.i33.AllowDrop = true;
            this.i33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i33.Location = new System.Drawing.Point(418, 190);
            this.i33.Name = "i33";
            this.i33.Size = new System.Drawing.Size(48, 48);
            this.i33.TabIndex = 38;
            this.i33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i33.UseVisualStyleBackColor = true;
            this.i33.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i33.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i33.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i33.MouseLeave += new System.EventHandler(this.Vylez);
            this.i33.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i32
            // 
            this.i32.AllowDrop = true;
            this.i32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i32.Location = new System.Drawing.Point(364, 190);
            this.i32.Name = "i32";
            this.i32.Size = new System.Drawing.Size(48, 48);
            this.i32.TabIndex = 37;
            this.i32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i32.UseVisualStyleBackColor = true;
            this.i32.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i32.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i32.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i32.MouseLeave += new System.EventHandler(this.Vylez);
            this.i32.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i31
            // 
            this.i31.AllowDrop = true;
            this.i31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i31.Location = new System.Drawing.Point(310, 190);
            this.i31.Name = "i31";
            this.i31.Size = new System.Drawing.Size(48, 48);
            this.i31.TabIndex = 36;
            this.i31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i31.UseVisualStyleBackColor = true;
            this.i31.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i31.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i31.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i31.MouseLeave += new System.EventHandler(this.Vylez);
            this.i31.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i30
            // 
            this.i30.AllowDrop = true;
            this.i30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i30.Location = new System.Drawing.Point(256, 190);
            this.i30.Name = "i30";
            this.i30.Size = new System.Drawing.Size(48, 48);
            this.i30.TabIndex = 35;
            this.i30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i30.UseVisualStyleBackColor = true;
            this.i30.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i30.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i30.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i30.MouseLeave += new System.EventHandler(this.Vylez);
            this.i30.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i29
            // 
            this.i29.AllowDrop = true;
            this.i29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i29.Location = new System.Drawing.Point(202, 190);
            this.i29.Name = "i29";
            this.i29.Size = new System.Drawing.Size(48, 48);
            this.i29.TabIndex = 34;
            this.i29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i29.UseVisualStyleBackColor = true;
            this.i29.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i29.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i29.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i29.MouseLeave += new System.EventHandler(this.Vylez);
            this.i29.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i28
            // 
            this.i28.AllowDrop = true;
            this.i28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i28.Location = new System.Drawing.Point(148, 190);
            this.i28.Name = "i28";
            this.i28.Size = new System.Drawing.Size(48, 48);
            this.i28.TabIndex = 33;
            this.i28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i28.UseVisualStyleBackColor = true;
            this.i28.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i28.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i28.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i28.MouseLeave += new System.EventHandler(this.Vylez);
            this.i28.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // i27
            // 
            this.i27.AllowDrop = true;
            this.i27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i27.Location = new System.Drawing.Point(94, 190);
            this.i27.Name = "i27";
            this.i27.Size = new System.Drawing.Size(48, 48);
            this.i27.TabIndex = 32;
            this.i27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i27.UseVisualStyleBackColor = true;
            this.i27.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i27.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i27.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i27.MouseLeave += new System.EventHandler(this.Vylez);
            this.i27.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // lbl_pocet
            // 
            this.lbl_pocet.AutoSize = true;
            this.lbl_pocet.Location = new System.Drawing.Point(86, 31);
            this.lbl_pocet.Name = "lbl_pocet";
            this.lbl_pocet.Size = new System.Drawing.Size(35, 13);
            this.lbl_pocet.TabIndex = 41;
            this.lbl_pocet.Text = "Počet";
            // 
            // lbl_poskozeni
            // 
            this.lbl_poskozeni.AutoSize = true;
            this.lbl_poskozeni.Location = new System.Drawing.Point(85, 58);
            this.lbl_poskozeni.Name = "lbl_poskozeni";
            this.lbl_poskozeni.Size = new System.Drawing.Size(58, 13);
            this.lbl_poskozeni.TabIndex = 42;
            this.lbl_poskozeni.Text = "Poškození";
            // 
            // poskozeni
            // 
            this.poskozeni.Location = new System.Drawing.Point(149, 55);
            this.poskozeni.Maximum = new decimal(new int[] {
            32767,
            0,
            0,
            0});
            this.poskozeni.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            -2147483648});
            this.poskozeni.Name = "poskozeni";
            this.poskozeni.Size = new System.Drawing.Size(65, 20);
            this.poskozeni.TabIndex = 43;
            this.poskozeni.ValueChanged += new System.EventHandler(this.poskozeni_ValueChanged);
            // 
            // pocet
            // 
            this.pocet.Location = new System.Drawing.Point(149, 29);
            this.pocet.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.pocet.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pocet.Name = "pocet";
            this.pocet.Size = new System.Drawing.Size(65, 20);
            this.pocet.TabIndex = 44;
            this.pocet.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.pocet.ValueChanged += new System.EventHandler(this.pocet_ValueChanged);
            // 
            // vyhledavani
            // 
            this.vyhledavani.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vyhledavani.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic);
            this.vyhledavani.ForeColor = System.Drawing.Color.Gray;
            this.vyhledavani.Location = new System.Drawing.Point(594, 29);
            this.vyhledavani.Name = "vyhledavani";
            this.vyhledavani.Size = new System.Drawing.Size(173, 20);
            this.vyhledavani.TabIndex = 0;
            this.vyhledavani.Text = "Hledej...";
            this.vyhledavani.TextChanged += new System.EventHandler(this.vyhledavani_TextChanged);
            this.vyhledavani.Enter += new System.EventHandler(this.vyhledavani_Enter);
            this.vyhledavani.Leave += new System.EventHandler(this.vyhledavani_Leave);
            // 
            // otevritDial
            // 
            this.otevritDial.DefaultExt = "dat";
            this.otevritDial.FileName = "level.dat";
            this.otevritDial.Filter = "Uložený svět|*.dat";
            this.otevritDial.FileOk += new System.ComponentModel.CancelEventHandler(this.otevritDial_FileOk);
            // 
            // lbl_xpLevel
            // 
            this.lbl_xpLevel.AutoSize = true;
            this.lbl_xpLevel.Location = new System.Drawing.Point(430, 31);
            this.lbl_xpLevel.Name = "lbl_xpLevel";
            this.lbl_xpLevel.Size = new System.Drawing.Size(46, 13);
            this.lbl_xpLevel.TabIndex = 51;
            this.lbl_xpLevel.Text = "XP level";
            // 
            // xplevel
            // 
            this.xplevel.Location = new System.Drawing.Point(482, 28);
            this.xplevel.Name = "xplevel";
            this.xplevel.Size = new System.Drawing.Size(100, 20);
            this.xplevel.TabIndex = 59;
            this.xplevel.TextChanged += new System.EventHandler(this.xplevel_TextChanged);
            // 
            // poNacteni
            // 
            this.poNacteni.Controls.Add(this.lbl_zacit);
            this.poNacteni.Location = new System.Drawing.Point(12, 28);
            this.poNacteni.Name = "poNacteni";
            this.poNacteni.Size = new System.Drawing.Size(755, 292);
            this.poNacteni.TabIndex = 60;
            // 
            // lbl_zacit
            // 
            this.lbl_zacit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbl_zacit.AutoSize = true;
            this.lbl_zacit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbl_zacit.Location = new System.Drawing.Point(165, 124);
            this.lbl_zacit.Name = "lbl_zacit";
            this.lbl_zacit.Size = new System.Drawing.Size(395, 31);
            this.lbl_zacit.TabIndex = 0;
            this.lbl_zacit.Text = "Zační otevřením uložené pozice";
            // 
            // seznamBlocku
            // 
            this.seznamBlocku.AllowDrop = true;
            this.seznamBlocku.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seznamBlocku.AutoArrange = false;
            this.seznamBlocku.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.seznamBlocku.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.seznamBlocku.HideSelection = false;
            this.seznamBlocku.Location = new System.Drawing.Point(594, 54);
            this.seznamBlocku.MultiSelect = false;
            this.seznamBlocku.Name = "seznamBlocku";
            this.seznamBlocku.ShowGroups = false;
            this.seznamBlocku.ShowItemToolTips = true;
            this.seznamBlocku.Size = new System.Drawing.Size(173, 264);
            this.seznamBlocku.TabIndex = 61;
            this.seznamBlocku.TileSize = new System.Drawing.Size(126, 26);
            this.seznamBlocku.UseCompatibleStateImageBehavior = false;
            this.seznamBlocku.View = System.Windows.Forms.View.Details;
            this.seznamBlocku.Visible = false;
            this.seznamBlocku.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.seznam_ItemDrag);
            this.seznamBlocku.DragDrop += new System.Windows.Forms.DragEventHandler(this.VhoditItem);
            this.seznamBlocku.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunuSeznam);
            this.seznamBlocku.MouseLeave += new System.EventHandler(this.SeznamDeaktivuj);
            this.seznamBlocku.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SeznamAktivuj);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 173;
            // 
            // seznamBlockuSearch
            // 
            this.seznamBlockuSearch.AllowDrop = true;
            this.seznamBlockuSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seznamBlockuSearch.AutoArrange = false;
            this.seznamBlockuSearch.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2});
            this.seznamBlockuSearch.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.seznamBlockuSearch.HideSelection = false;
            this.seznamBlockuSearch.Location = new System.Drawing.Point(594, 54);
            this.seznamBlockuSearch.MultiSelect = false;
            this.seznamBlockuSearch.Name = "seznamBlockuSearch";
            this.seznamBlockuSearch.ShowGroups = false;
            this.seznamBlockuSearch.ShowItemToolTips = true;
            this.seznamBlockuSearch.Size = new System.Drawing.Size(173, 264);
            this.seznamBlockuSearch.TabIndex = 61;
            this.seznamBlockuSearch.TileSize = new System.Drawing.Size(126, 26);
            this.seznamBlockuSearch.UseCompatibleStateImageBehavior = false;
            this.seznamBlockuSearch.View = System.Windows.Forms.View.Details;
            this.seznamBlockuSearch.Visible = false;
            this.seznamBlockuSearch.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.seznam_ItemDrag);
            this.seznamBlockuSearch.DragDrop += new System.Windows.Forms.DragEventHandler(this.VhoditItem);
            this.seznamBlockuSearch.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunuSeznam);
            this.seznamBlockuSearch.MouseLeave += new System.EventHandler(this.SeznamDeaktivuj);
            this.seznamBlockuSearch.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SeznamAktivuj);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 173;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // popisek
            // 
            this.popisek.AutoPopDelay = 5000;
            this.popisek.InitialDelay = 500;
            this.popisek.ReshowDelay = 100;
            // 
            // vlastnosti
            // 
            this.vlastnosti.Image = global::SaveEdit.Properties.Resources.PropertiesButton;
            this.vlastnosti.Location = new System.Drawing.Point(302, 29);
            this.vlastnosti.Name = "vlastnosti";
            this.vlastnosti.Size = new System.Drawing.Size(48, 48);
            this.vlastnosti.TabIndex = 64;
            this.popisek.SetToolTip(this.vlastnosti, "Vlastnosti itemu");
            this.vlastnosti.UseVisualStyleBackColor = true;
            this.vlastnosti.Click += new System.EventHandler(this.vlastnosti_Click);
            // 
            // enchantyButton
            // 
            this.enchantyButton.Enabled = false;
            this.enchantyButton.Image = global::SaveEdit.Properties.Resources.Enchantment_Table;
            this.enchantyButton.Location = new System.Drawing.Point(229, 29);
            this.enchantyButton.Name = "enchantyButton";
            this.enchantyButton.Size = new System.Drawing.Size(48, 48);
            this.enchantyButton.TabIndex = 63;
            this.popisek.SetToolTip(this.enchantyButton, "Enchanty");
            this.enchantyButton.UseVisualStyleBackColor = true;
            this.enchantyButton.Click += new System.EventHandler(this.enchantyButton_Click);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_Complete);
            // 
            // lbl_nacitaniItemu
            // 
            this.lbl_nacitaniItemu.AutoSize = true;
            this.lbl_nacitaniItemu.Location = new System.Drawing.Point(601, 165);
            this.lbl_nacitaniItemu.Name = "lbl_nacitaniItemu";
            this.lbl_nacitaniItemu.Size = new System.Drawing.Size(134, 26);
            this.lbl_nacitaniItemu.TabIndex = 62;
            this.lbl_nacitaniItemu.Text = "Probíhá načítání seznamu\r\nitemů. Prosím, čekejte.";
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // backgroundWorker4
            // 
            this.backgroundWorker4.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker4_DoWork);
            // 
            // contextMenu
            // 
            this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.přidatItemDoSeznamuItemůToolStripMenuItem});
            this.contextMenu.Name = "contextMenu";
            this.contextMenu.Size = new System.Drawing.Size(234, 26);
            // 
            // přidatItemDoSeznamuItemůToolStripMenuItem
            // 
            this.přidatItemDoSeznamuItemůToolStripMenuItem.Name = "přidatItemDoSeznamuItemůToolStripMenuItem";
            this.přidatItemDoSeznamuItemůToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.přidatItemDoSeznamuItemůToolStripMenuItem.Text = "Přidat item do seznamu itemů";
            this.přidatItemDoSeznamuItemůToolStripMenuItem.Click += new System.EventHandler(this.přidatItemDoSeznamuItemůToolStripMenuItem_Click);
            // 
            // i150
            // 
            this.i150.AllowDrop = true;
            this.i150.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.i150.ForeColor = System.Drawing.SystemColors.ControlText;
            this.i150.Location = new System.Drawing.Point(12, 255);
            this.i150.Name = "i150";
            this.i150.Size = new System.Drawing.Size(48, 48);
            this.i150.TabIndex = 66;
            this.i150.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.i150.UseVisualStyleBackColor = true;
            this.i150.DragDrop += new System.Windows.Forms.DragEventHandler(this.Presun);
            this.i150.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunu);
            this.i150.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VyjmoutZTlacitka);
            this.i150.MouseLeave += new System.EventHandler(this.Vylez);
            this.i150.MouseMove += new System.Windows.Forms.MouseEventHandler(this.UkazPopisek);
            // 
            // kos
            // 
            this.kos.AllowDrop = true;
            this.kos.BackColor = System.Drawing.Color.LightGray;
            this.kos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.kos.FlatAppearance.BorderSize = 0;
            this.kos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightGray;
            this.kos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightGray;
            this.kos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.kos.Image = global::SaveEdit.Properties.Resources.icon_40357_640;
            this.kos.Location = new System.Drawing.Point(375, 29);
            this.kos.Name = "kos";
            this.kos.Size = new System.Drawing.Size(48, 48);
            this.kos.TabIndex = 65;
            this.kos.UseVisualStyleBackColor = false;
            this.kos.DragDrop += new System.Windows.Forms.DragEventHandler(this.VhoditItem);
            this.kos.DragEnter += new System.Windows.Forms.DragEventHandler(this.VstupPresunuSeznam);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 331);
            this.Controls.Add(this.lbl_pocet);
            this.Controls.Add(this.kos);
            this.Controls.Add(this.vlastnosti);
            this.Controls.Add(this.enchantyButton);
            this.Controls.Add(this.lbl_nacitaniItemu);
            this.Controls.Add(this.seznamBlocku);
            this.Controls.Add(this.seznamBlockuSearch);
            this.Controls.Add(this.xplevel);
            this.Controls.Add(this.lbl_xpLevel);
            this.Controls.Add(this.vyhledavani);
            this.Controls.Add(this.pocet);
            this.Controls.Add(this.poskozeni);
            this.Controls.Add(this.lbl_poskozeni);
            this.Controls.Add(this.i35);
            this.Controls.Add(this.i34);
            this.Controls.Add(this.i33);
            this.Controls.Add(this.i32);
            this.Controls.Add(this.i31);
            this.Controls.Add(this.i30);
            this.Controls.Add(this.i29);
            this.Controls.Add(this.i28);
            this.Controls.Add(this.i27);
            this.Controls.Add(this.i26);
            this.Controls.Add(this.i25);
            this.Controls.Add(this.i24);
            this.Controls.Add(this.i23);
            this.Controls.Add(this.i22);
            this.Controls.Add(this.i21);
            this.Controls.Add(this.i20);
            this.Controls.Add(this.i19);
            this.Controls.Add(this.i18);
            this.Controls.Add(this.i17);
            this.Controls.Add(this.i16);
            this.Controls.Add(this.i15);
            this.Controls.Add(this.i14);
            this.Controls.Add(this.i13);
            this.Controls.Add(this.i12);
            this.Controls.Add(this.i11);
            this.Controls.Add(this.i10);
            this.Controls.Add(this.i8);
            this.Controls.Add(this.i7);
            this.Controls.Add(this.i6);
            this.Controls.Add(this.i5);
            this.Controls.Add(this.i4);
            this.Controls.Add(this.i3);
            this.Controls.Add(this.i2);
            this.Controls.Add(this.i1);
            this.Controls.Add(this.i0);
            this.Controls.Add(this.i9);
            this.Controls.Add(this.i100);
            this.Controls.Add(this.i101);
            this.Controls.Add(this.i102);
            this.Controls.Add(this.i103);
            this.Controls.Add(this.i150);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.poNacteni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1000, 370);
            this.MinimumSize = new System.Drawing.Size(785, 370);
            this.Name = "Form1";
            this.Text = "SaveEdit";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.LocationChanged += new System.EventHandler(this.Pusunuto);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KlavesovaZkratka);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.poskozeni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pocet)).EndInit();
            this.poNacteni.ResumeLayout(false);
            this.poNacteni.PerformLayout();
            this.contextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Presun(object sender, DragEventArgs e)
        {
            throw new NotImplementedException();
        }



        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton novy;
        private System.Windows.Forms.ToolStripButton ulozit;
        private System.Windows.Forms.Button i103;
        private System.Windows.Forms.Button i102;
        private System.Windows.Forms.Button i101;
        private System.Windows.Forms.Button i100;
        private System.Windows.Forms.Button i9;
        private System.Windows.Forms.Button i0;
        private System.Windows.Forms.Button i1;
        private System.Windows.Forms.Button i2;
        private System.Windows.Forms.Button i3;
        private System.Windows.Forms.Button i4;
        private System.Windows.Forms.Button i5;
        private System.Windows.Forms.Button i6;
        private System.Windows.Forms.Button i7;
        private System.Windows.Forms.Button i8;
        private System.Windows.Forms.Button i10;
        private System.Windows.Forms.Button i11;
        private System.Windows.Forms.Button i12;
        private System.Windows.Forms.Button i13;
        private System.Windows.Forms.Button i14;
        private System.Windows.Forms.Button i15;
        private System.Windows.Forms.Button i16;
        private System.Windows.Forms.Button i17;
        private System.Windows.Forms.Button i26;
        private System.Windows.Forms.Button i25;
        private System.Windows.Forms.Button i24;
        private System.Windows.Forms.Button i23;
        private System.Windows.Forms.Button i22;
        private System.Windows.Forms.Button i21;
        private System.Windows.Forms.Button i20;
        private System.Windows.Forms.Button i19;
        private System.Windows.Forms.Button i18;
        private System.Windows.Forms.Button i35;
        private System.Windows.Forms.Button i34;
        private System.Windows.Forms.Button i33;
        private System.Windows.Forms.Button i32;
        private System.Windows.Forms.Button i31;
        private System.Windows.Forms.Button i30;
        private System.Windows.Forms.Button i29;
        private System.Windows.Forms.Button i28;
        private System.Windows.Forms.Button i27;
        private System.Windows.Forms.Label lbl_pocet;
        private System.Windows.Forms.Label lbl_poskozeni;
        private System.Windows.Forms.NumericUpDown poskozeni;
        private System.Windows.Forms.NumericUpDown pocet;
        private System.Windows.Forms.TextBox vyhledavani;
        private System.Windows.Forms.OpenFileDialog otevritDial;
        private System.Windows.Forms.Label lbl_xpLevel;
        private System.Windows.Forms.ToolStripSplitButton otevrit;
        private System.Windows.Forms.TextBox xplevel;
        private System.Windows.Forms.Panel poNacteni;
        private System.Windows.Forms.Label lbl_zacit;
        internal System.Windows.Forms.ListView seznamBlocku;
        internal System.Windows.Forms.ListView seznamBlockuSearch;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ToolStripSeparator splitter;
        private System.Windows.Forms.ToolStripDropDownButton OProgramu;
        private System.Windows.Forms.ToolStripMenuItem oProgramuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aktualizovatToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel aktualizaceInfo;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolTip popisek;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.Windows.Forms.Label lbl_nacitaniItemu;
        private System.Windows.Forms.ToolStripMenuItem nápovědaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changelogToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton kategorieBtn;
        private System.Windows.Forms.ToolStripButton updateButton;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private System.Windows.Forms.ToolStripButton moznostiHry;
        private System.Windows.Forms.Button enchantyButton;
        private System.Windows.Forms.Button vlastnosti;
        private System.Windows.Forms.Button kos;
        private System.Windows.Forms.ToolStripButton kopirovatBtn;
        private System.Windows.Forms.ToolStripButton vlozitBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripButton1;
        private System.ComponentModel.BackgroundWorker backgroundWorker4;
        private System.Windows.Forms.ContextMenuStrip contextMenu;
        private System.Windows.Forms.ToolStripMenuItem přidatItemDoSeznamuItemůToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem jazykToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem češtinaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem poslatNápadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nahlásitChybuToolStripMenuItem;
        private System.Windows.Forms.Button i150;
    }
}

