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
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem("stavebni");
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem("dekorace");
            System.Windows.Forms.ListViewItem listViewItem18 = new System.Windows.Forms.ListViewItem("redstone");
            System.Windows.Forms.ListViewItem listViewItem19 = new System.Windows.Forms.ListViewItem("doprava");
            System.Windows.Forms.ListViewItem listViewItem20 = new System.Windows.Forms.ListViewItem("ruzne");
            System.Windows.Forms.ListViewItem listViewItem21 = new System.Windows.Forms.ListViewItem("jidlo");
            System.Windows.Forms.ListViewItem listViewItem22 = new System.Windows.Forms.ListViewItem("nastroje");
            System.Windows.Forms.ListViewItem listViewItem23 = new System.Windows.Forms.ListViewItem("bojove");
            System.Windows.Forms.ListViewItem listViewItem24 = new System.Windows.Forms.ListViewItem("lektvary");
            System.Windows.Forms.ListViewItem listViewItem25 = new System.Windows.Forms.ListViewItem("materialy");
            System.Windows.Forms.ListViewItem listViewItem26 = new System.Windows.Forms.ListViewItem("rostliny");
            System.Windows.Forms.ListViewItem listViewItem27 = new System.Windows.Forms.ListViewItem("Helma");
            System.Windows.Forms.ListViewItem listViewItem28 = new System.Windows.Forms.ListViewItem("Tělo");
            System.Windows.Forms.ListViewItem listViewItem29 = new System.Windows.Forms.ListViewItem("Nohy");
            System.Windows.Forms.ListViewItem listViewItem30 = new System.Windows.Forms.ListViewItem("Boty");
            this.seznamBlocku = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ulozit = new System.Windows.Forms.Button();
            this.bridat = new System.Windows.Forms.Button();
            this.imageFile = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.y = new System.Windows.Forms.TextBox();
            this.x = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.preview = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.soubor = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.jmeno = new System.Windows.Forms.TextBox();
            this.lblJmeno = new System.Windows.Forms.Label();
            this.id = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.kategorie = new System.Windows.Forms.ListView();
            this.tag = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.multiID = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.addTag = new System.Windows.Forms.Button();
            this.addId = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.sloty = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.changeColor = new System.Windows.Forms.CheckBox();
            this.bannerBox = new System.Windows.Forms.CheckBox();
            this.fireworkBox = new System.Windows.Forms.CheckBox();
            this.maxDamageUpDown = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.imageFile)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.maxDamageUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // seznamBlocku
            // 
            this.seznamBlocku.AllowDrop = true;
            this.seznamBlocku.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seznamBlocku.AutoArrange = false;
            this.seznamBlocku.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.seznamBlocku.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.seznamBlocku.HideSelection = false;
            this.seznamBlocku.Location = new System.Drawing.Point(848, 12);
            this.seznamBlocku.MultiSelect = false;
            this.seznamBlocku.Name = "seznamBlocku";
            this.seznamBlocku.ShowGroups = false;
            this.seznamBlocku.ShowItemToolTips = true;
            this.seznamBlocku.Size = new System.Drawing.Size(195, 591);
            this.seznamBlocku.TabIndex = 61;
            this.seznamBlocku.TileSize = new System.Drawing.Size(126, 26);
            this.seznamBlocku.UseCompatibleStateImageBehavior = false;
            this.seznamBlocku.View = System.Windows.Forms.View.Details;
            this.seznamBlocku.SelectedIndexChanged += new System.EventHandler(this.seznamBlocku_SelectedIndexChanged);
            this.seznamBlocku.KeyDown += new System.Windows.Forms.KeyEventHandler(this.seznamBlocku_KeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 173;
            // 
            // ulozit
            // 
            this.ulozit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ulozit.Location = new System.Drawing.Point(739, 580);
            this.ulozit.Name = "ulozit";
            this.ulozit.Size = new System.Drawing.Size(103, 23);
            this.ulozit.TabIndex = 62;
            this.ulozit.Text = "Uložit";
            this.ulozit.UseVisualStyleBackColor = true;
            this.ulozit.Click += new System.EventHandler(this.ulozit_Click);
            // 
            // bridat
            // 
            this.bridat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bridat.Location = new System.Drawing.Point(521, 580);
            this.bridat.Name = "bridat";
            this.bridat.Size = new System.Drawing.Size(103, 23);
            this.bridat.TabIndex = 63;
            this.bridat.Text = "Přidat";
            this.bridat.UseVisualStyleBackColor = true;
            this.bridat.Click += new System.EventHandler(this.bridat_Click);
            // 
            // imageFile
            // 
            this.imageFile.Location = new System.Drawing.Point(3, 3);
            this.imageFile.Name = "imageFile";
            this.imageFile.Size = new System.Drawing.Size(491, 489);
            this.imageFile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.imageFile.TabIndex = 64;
            this.imageFile.TabStop = false;
            this.imageFile.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.y);
            this.groupBox1.Controls.Add(this.x);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.preview);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.soubor);
            this.groupBox1.Location = new System.Drawing.Point(12, 93);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 99);
            this.groupBox1.TabIndex = 65;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Obrázek";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Y";
            // 
            // y
            // 
            this.y.Location = new System.Drawing.Point(53, 72);
            this.y.Name = "y";
            this.y.ReadOnly = true;
            this.y.Size = new System.Drawing.Size(196, 20);
            this.y.TabIndex = 5;
            this.y.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // x
            // 
            this.x.Location = new System.Drawing.Point(53, 46);
            this.x.Name = "x";
            this.x.ReadOnly = true;
            this.x.Size = new System.Drawing.Size(196, 20);
            this.x.TabIndex = 4;
            this.x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "X";
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(255, 20);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(68, 68);
            this.preview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.preview.TabIndex = 2;
            this.preview.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Soubor";
            // 
            // soubor
            // 
            this.soubor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.soubor.FormattingEnabled = true;
            this.soubor.Location = new System.Drawing.Point(53, 19);
            this.soubor.Name = "soubor";
            this.soubor.Size = new System.Drawing.Size(196, 21);
            this.soubor.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.imageFile);
            this.panel1.Location = new System.Drawing.Point(345, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 495);
            this.panel1.TabIndex = 66;
            // 
            // jmeno
            // 
            this.jmeno.Location = new System.Drawing.Point(109, 15);
            this.jmeno.Name = "jmeno";
            this.jmeno.Size = new System.Drawing.Size(230, 20);
            this.jmeno.TabIndex = 67;
            // 
            // lblJmeno
            // 
            this.lblJmeno.AutoSize = true;
            this.lblJmeno.Location = new System.Drawing.Point(12, 15);
            this.lblJmeno.Name = "lblJmeno";
            this.lblJmeno.Size = new System.Drawing.Size(38, 13);
            this.lblJmeno.TabIndex = 68;
            this.lblJmeno.Text = "Jméno";
            // 
            // id
            // 
            this.id.Location = new System.Drawing.Point(109, 41);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(230, 20);
            this.id.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 13);
            this.label4.TabIndex = 70;
            this.label4.Text = "ID";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(109, 67);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(230, 20);
            this.numericUpDown1.TabIndex = 71;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 72;
            this.label5.Text = "Stack";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.kategorie);
            this.groupBox2.Location = new System.Drawing.Point(12, 198);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 104);
            this.groupBox2.TabIndex = 73;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Kategorie";
            // 
            // kategorie
            // 
            this.kategorie.CheckBoxes = true;
            this.kategorie.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.kategorie.HideSelection = false;
            listViewItem16.StateImageIndex = 0;
            listViewItem17.StateImageIndex = 0;
            listViewItem18.StateImageIndex = 0;
            listViewItem19.StateImageIndex = 0;
            listViewItem20.StateImageIndex = 0;
            listViewItem21.StateImageIndex = 0;
            listViewItem22.StateImageIndex = 0;
            listViewItem23.StateImageIndex = 0;
            listViewItem24.StateImageIndex = 0;
            listViewItem25.StateImageIndex = 0;
            listViewItem26.StateImageIndex = 0;
            this.kategorie.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem16,
            listViewItem17,
            listViewItem18,
            listViewItem19,
            listViewItem20,
            listViewItem21,
            listViewItem22,
            listViewItem23,
            listViewItem24,
            listViewItem25,
            listViewItem26});
            this.kategorie.Location = new System.Drawing.Point(6, 19);
            this.kategorie.Name = "kategorie";
            this.kategorie.Size = new System.Drawing.Size(315, 78);
            this.kategorie.TabIndex = 83;
            this.kategorie.UseCompatibleStateImageBehavior = false;
            this.kategorie.View = System.Windows.Forms.View.List;
            // 
            // tag
            // 
            this.tag.Location = new System.Drawing.Point(75, 392);
            this.tag.Name = "tag";
            this.tag.Size = new System.Drawing.Size(264, 100);
            this.tag.TabIndex = 74;
            this.tag.Text = "";
            this.tag.WordWrap = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 431);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 75;
            this.label6.Text = "Tag";
            // 
            // multiID
            // 
            this.multiID.Location = new System.Drawing.Point(75, 503);
            this.multiID.Name = "multiID";
            this.multiID.Size = new System.Drawing.Size(264, 100);
            this.multiID.TabIndex = 76;
            this.multiID.Text = "";
            this.multiID.WordWrap = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 562);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 77;
            this.label7.Text = "Multiple ID";
            // 
            // addTag
            // 
            this.addTag.Location = new System.Drawing.Point(12, 447);
            this.addTag.Name = "addTag";
            this.addTag.Size = new System.Drawing.Size(57, 23);
            this.addTag.TabIndex = 78;
            this.addTag.Text = "Add";
            this.addTag.UseVisualStyleBackColor = true;
            this.addTag.Click += new System.EventHandler(this.addTag_Click);
            // 
            // addId
            // 
            this.addId.Location = new System.Drawing.Point(12, 578);
            this.addId.Name = "addId";
            this.addId.Size = new System.Drawing.Size(57, 23);
            this.addId.TabIndex = 79;
            this.addId.Text = "Add";
            this.addId.UseVisualStyleBackColor = true;
            this.addId.Click += new System.EventHandler(this.addId_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.sloty);
            this.groupBox3.Location = new System.Drawing.Point(12, 308);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(327, 78);
            this.groupBox3.TabIndex = 80;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Povolené sloty";
            // 
            // sloty
            // 
            this.sloty.CheckBoxes = true;
            this.sloty.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.sloty.HideSelection = false;
            listViewItem27.StateImageIndex = 0;
            listViewItem28.StateImageIndex = 0;
            listViewItem29.StateImageIndex = 0;
            listViewItem30.StateImageIndex = 0;
            this.sloty.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem27,
            listViewItem28,
            listViewItem29,
            listViewItem30});
            this.sloty.Location = new System.Drawing.Point(6, 19);
            this.sloty.Name = "sloty";
            this.sloty.Size = new System.Drawing.Size(315, 51);
            this.sloty.TabIndex = 0;
            this.sloty.UseCompatibleStateImageBehavior = false;
            this.sloty.View = System.Windows.Forms.View.List;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(630, 580);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 81;
            this.button1.Text = "Změň";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // changeColor
            // 
            this.changeColor.AutoSize = true;
            this.changeColor.Location = new System.Drawing.Point(345, 513);
            this.changeColor.Name = "changeColor";
            this.changeColor.Size = new System.Drawing.Size(110, 17);
            this.changeColor.TabIndex = 82;
            this.changeColor.Text = "Může měnit barvu";
            this.changeColor.UseVisualStyleBackColor = true;
            // 
            // bannerBox
            // 
            this.bannerBox.AutoSize = true;
            this.bannerBox.Location = new System.Drawing.Point(345, 536);
            this.bannerBox.Name = "bannerBox";
            this.bannerBox.Size = new System.Drawing.Size(60, 17);
            this.bannerBox.TabIndex = 83;
            this.bannerBox.Text = "Banner";
            this.bannerBox.UseVisualStyleBackColor = true;
            // 
            // fireworkBox
            // 
            this.fireworkBox.AutoSize = true;
            this.fireworkBox.Location = new System.Drawing.Point(345, 559);
            this.fireworkBox.Name = "fireworkBox";
            this.fireworkBox.Size = new System.Drawing.Size(66, 17);
            this.fireworkBox.TabIndex = 84;
            this.fireworkBox.Text = "Firework";
            this.fireworkBox.UseVisualStyleBackColor = true;
            // 
            // maxDamageUpDown
            // 
            this.maxDamageUpDown.Location = new System.Drawing.Point(609, 513);
            this.maxDamageUpDown.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.maxDamageUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.maxDamageUpDown.Name = "maxDamageUpDown";
            this.maxDamageUpDown.Size = new System.Drawing.Size(230, 20);
            this.maxDamageUpDown.TabIndex = 85;
            this.maxDamageUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(533, 515);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(68, 13);
            this.label8.TabIndex = 86;
            this.label8.Text = "Max damage";
            // 
            // NovyItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1055, 615);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.maxDamageUpDown);
            this.Controls.Add(this.fireworkBox);
            this.Controls.Add(this.bannerBox);
            this.Controls.Add(this.changeColor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.addId);
            this.Controls.Add(this.addTag);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.multiID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tag);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.id);
            this.Controls.Add(this.lblJmeno);
            this.Controls.Add(this.jmeno);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bridat);
            this.Controls.Add(this.ulozit);
            this.Controls.Add(this.seznamBlocku);
            this.Name = "NovyItem";
            this.Text = "Editor Itemů";
            ((System.ComponentModel.ISupportInitialize)(this.imageFile)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.maxDamageUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView seznamBlocku;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Button ulozit;
        private System.Windows.Forms.Button bridat;
        private System.Windows.Forms.PictureBox imageFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox preview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox soubor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox y;
        private System.Windows.Forms.TextBox x;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox jmeno;
        private System.Windows.Forms.Label lblJmeno;
        private System.Windows.Forms.TextBox id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox tag;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox multiID;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button addTag;
        private System.Windows.Forms.Button addId;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox changeColor;
        private System.Windows.Forms.ListView kategorie;
        private System.Windows.Forms.ListView sloty;
        private System.Windows.Forms.CheckBox bannerBox;
        private System.Windows.Forms.CheckBox fireworkBox;
        private System.Windows.Forms.NumericUpDown maxDamageUpDown;
        private System.Windows.Forms.Label label8;
    }
}