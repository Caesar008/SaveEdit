namespace SaveEdit
{
    partial class OdeslaniZpravy
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
            this.zrusit = new System.Windows.Forms.Button();
            this.odeslat = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pouzity = new System.Windows.Forms.RadioButton();
            this.novy = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pripojit = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // zrusit
            // 
            this.zrusit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.zrusit.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.zrusit.Location = new System.Drawing.Point(449, 275);
            this.zrusit.Name = "zrusit";
            this.zrusit.Size = new System.Drawing.Size(75, 23);
            this.zrusit.TabIndex = 0;
            this.zrusit.Text = Jazyk.Strings.Zrusit;
            this.zrusit.UseVisualStyleBackColor = true;
            // 
            // odeslat
            // 
            this.odeslat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.odeslat.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.odeslat.Location = new System.Drawing.Point(368, 275);
            this.odeslat.Name = "odeslat";
            this.odeslat.Size = new System.Drawing.Size(75, 23);
            this.odeslat.TabIndex = 1;
            this.odeslat.Text = Jazyk.Strings.Odeslat;
            this.odeslat.UseVisualStyleBackColor = true;
            this.odeslat.Click += new System.EventHandler(this.odeslat_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(512, 257);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.pripojit);
            this.tabPage1.Controls.Add(this.pouzity);
            this.tabPage1.Controls.Add(this.novy);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(504, 231);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = Jazyk.Strings.Dodatecne_info;
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // pouzity
            // 
            this.pouzity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pouzity.AutoSize = true;
            this.pouzity.Location = new System.Drawing.Point(6, 208);
            this.pouzity.Name = "pouzity";
            this.pouzity.Size = new System.Drawing.Size(156, 17);
            this.pouzity.TabIndex = 4;
            this.pouzity.Text = Jazyk.Strings.Save_s_pouzitym;
            this.pouzity.UseVisualStyleBackColor = true;
            // 
            // novy
            // 
            this.novy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.novy.AutoSize = true;
            this.novy.Checked = true;
            this.novy.Location = new System.Drawing.Point(6, 185);
            this.novy.Name = "novy";
            this.novy.Size = new System.Drawing.Size(101, 17);
            this.novy.TabIndex = 3;
            this.novy.TabStop = true;
            this.novy.Text = Jazyk.Strings.Cisty_save;
            this.novy.UseVisualStyleBackColor = true;
            this.novy.CheckedChanged += new System.EventHandler(this.novy_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = Jazyk.Strings.Jednalo_se_o;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(492, 147);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.TextChanged += new System.EventHandler(this.richTextBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = Jazyk.Strings.Co_jste;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.richTextBox2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(504, 231);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = Jazyk.Strings.Obsah_zpravy;
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox2.Location = new System.Drawing.Point(6, 6);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.ReadOnly = true;
            this.richTextBox2.Size = new System.Drawing.Size(492, 219);
            this.richTextBox2.TabIndex = 0;
            this.richTextBox2.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "dat";
            this.openFileDialog1.FileName = "level.dat";
            this.openFileDialog1.Filter = Jazyk.Strings.Ulozeny_svet + "|*.dat";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // pripojit
            // 
            this.pripojit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pripojit.Location = new System.Drawing.Point(168, 185);
            this.pripojit.Name = "pripojit";
            this.pripojit.Size = new System.Drawing.Size(75, 40);
            this.pripojit.TabIndex = 3;
            this.pripojit.Text = Jazyk.Strings.Pripojit_prilohu;
            this.pripojit.UseVisualStyleBackColor = true;
            this.pripojit.Click += new System.EventHandler(this.pripojit_Click);
            // 
            // OdeslaniZpravy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 310);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.odeslat);
            this.Controls.Add(this.zrusit);
            this.MinimizeBox = false;
            this.Name = "OdeslaniZpravy";
            this.ShowIcon = false;
            this.Text = Jazyk.Strings.Odeslani_informace;
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button zrusit;
        private System.Windows.Forms.Button odeslat;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.RadioButton pouzity;
        private System.Windows.Forms.RadioButton novy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Button pripojit;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}