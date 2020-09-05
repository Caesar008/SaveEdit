namespace SaveEdit
{
    partial class EnchantWindow
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
            this.enchantView = new System.Windows.Forms.ListView();
            this.enchant = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.level = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.enchanty = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.enchLevel = new System.Windows.Forms.NumericUpDown();
            this.pridat = new System.Windows.Forms.Button();
            this.smazat = new System.Windows.Forms.Button();
            this.limiter = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.enchLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // enchantView
            // 
            this.enchantView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.enchant,
            this.level});
            this.enchantView.FullRowSelect = true;
            this.enchantView.GridLines = true;
            this.enchantView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.enchantView.HideSelection = false;
            this.enchantView.Location = new System.Drawing.Point(12, 12);
            this.enchantView.MultiSelect = false;
            this.enchantView.Name = "enchantView";
            this.enchantView.Size = new System.Drawing.Size(297, 201);
            this.enchantView.TabIndex = 0;
            this.enchantView.UseCompatibleStateImageBehavior = false;
            this.enchantView.View = System.Windows.Forms.View.Details;
            this.enchantView.SelectedIndexChanged += new System.EventHandler(this.enchantView_SelectedIndexChanged);
            // 
            // enchant
            // 
            this.enchant.Text = Jazyk.Strings.Enchant;
            this.enchant.Width = 215;
            // 
            // level
            // 
            this.level.Text = Jazyk.Strings.Level;
            this.level.Width = 55;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 234);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = Jazyk.Strings.Enchant;
            // 
            // enchanty
            // 
            this.enchanty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enchanty.FormattingEnabled = true;
            this.enchanty.Location = new System.Drawing.Point(65, 231);
            this.enchanty.Name = "enchanty";
            this.enchanty.Size = new System.Drawing.Size(146, 21);
            this.enchanty.Sorted = true;
            this.enchanty.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(217, 234);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = Jazyk.Strings.Level;
            // 
            // enchLevel
            // 
            this.enchLevel.Location = new System.Drawing.Point(256, 231);
            this.enchLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.enchLevel.Name = "enchLevel";
            this.enchLevel.Size = new System.Drawing.Size(54, 20);
            this.enchLevel.TabIndex = 4;
            this.enchLevel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.enchLevel.ValueChanged += new System.EventHandler(this.enchLevel_ValueChanged);
            // 
            // pridat
            // 
            this.pridat.Location = new System.Drawing.Point(60, 258);
            this.pridat.Name = "pridat";
            this.pridat.Size = new System.Drawing.Size(75, 23);
            this.pridat.TabIndex = 5;
            this.pridat.Text = Jazyk.Strings.Pridat;
            this.pridat.UseVisualStyleBackColor = true;
            this.pridat.Click += new System.EventHandler(this.pridat_Click);
            // 
            // smazat
            // 
            this.smazat.Enabled = false;
            this.smazat.Image = global::SaveEdit.Properties.Resources.krizek;
            this.smazat.Location = new System.Drawing.Point(141, 258);
            this.smazat.Name = "smazat";
            this.smazat.Size = new System.Drawing.Size(23, 23);
            this.smazat.TabIndex = 6;
            this.smazat.UseVisualStyleBackColor = true;
            this.smazat.Click += new System.EventHandler(this.smazat_Click);
            // 
            // limiter
            // 
            this.limiter.AutoSize = true;
            this.limiter.Location = new System.Drawing.Point(194, 262);
            this.limiter.Name = "limiter";
            this.limiter.Size = new System.Drawing.Size(116, 17);
            this.limiter.TabIndex = 7;
            this.limiter.Text = Jazyk.Strings.Vypnout_limit;
            this.limiter.UseVisualStyleBackColor = true;
            this.limiter.CheckedChanged += new System.EventHandler(this.limiter_CheckedChanged);
            // 
            // EnchantWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 294);
            this.Controls.Add(this.limiter);
            this.Controls.Add(this.smazat);
            this.Controls.Add(this.pridat);
            this.Controls.Add(this.enchLevel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.enchanty);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.enchantView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EnchantWindow";
            this.ShowIcon = false;
            this.Text = Jazyk.Strings.Enchanty;
            ((System.ComponentModel.ISupportInitialize)(this.enchLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView enchantView;
        private System.Windows.Forms.ColumnHeader enchant;
        private System.Windows.Forms.ColumnHeader level;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox enchanty;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown enchLevel;
        private System.Windows.Forms.Button pridat;
        private System.Windows.Forms.Button smazat;
        private System.Windows.Forms.CheckBox limiter;

    }
}