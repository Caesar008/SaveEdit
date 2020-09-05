namespace SaveEdit.Jazyk
{
    partial class Preklad
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
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.zkratkaTxt = new System.Windows.Forms.TextBox();
            this.zkratka = new System.Windows.Forms.Label();
            this.info = new System.Windows.Forms.Label();
            this.autorTxt = new System.Windows.Forms.TextBox();
            this.autor = new System.Windows.Forms.Label();
            this.verzeTxt = new System.Windows.Forms.TextBox();
            this.verze = new System.Windows.Forms.Label();
            this.nazevTxt = new System.Windows.Forms.TextBox();
            this.nazev = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pridatVlastniItemTXT = new System.Windows.Forms.TextBox();
            this.pridatVlastniItem = new System.Windows.Forms.Label();
            this.seznamItemuNeniNactenyTxt = new System.Windows.Forms.TextBox();
            this.seznamItemuNeniNacteny = new System.Windows.Forms.Label();
            this.hledejTxt = new System.Windows.Forms.TextBox();
            this.hledej = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(582, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(12, 12);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.zkratkaTxt);
            this.splitContainer1.Panel1.Controls.Add(this.zkratka);
            this.splitContainer1.Panel1.Controls.Add(this.info);
            this.splitContainer1.Panel1.Controls.Add(this.autorTxt);
            this.splitContainer1.Panel1.Controls.Add(this.autor);
            this.splitContainer1.Panel1.Controls.Add(this.verzeTxt);
            this.splitContainer1.Panel1.Controls.Add(this.verze);
            this.splitContainer1.Panel1.Controls.Add(this.nazevTxt);
            this.splitContainer1.Panel1.Controls.Add(this.nazev);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.pridatVlastniItemTXT);
            this.splitContainer1.Panel2.Controls.Add(this.pridatVlastniItem);
            this.splitContainer1.Panel2.Controls.Add(this.seznamItemuNeniNactenyTxt);
            this.splitContainer1.Panel2.Controls.Add(this.seznamItemuNeniNacteny);
            this.splitContainer1.Panel2.Controls.Add(this.hledejTxt);
            this.splitContainer1.Panel2.Controls.Add(this.hledej);
            this.splitContainer1.Size = new System.Drawing.Size(645, 373);
            this.splitContainer1.SplitterDistance = 83;
            this.splitContainer1.TabIndex = 2;
            // 
            // zkratkaTxt
            // 
            this.zkratkaTxt.Location = new System.Drawing.Point(427, 55);
            this.zkratkaTxt.MaxLength = 4;
            this.zkratkaTxt.Name = "zkratkaTxt";
            this.zkratkaTxt.Size = new System.Drawing.Size(58, 20);
            this.zkratkaTxt.TabIndex = 15;
            // 
            // zkratka
            // 
            this.zkratka.AutoSize = true;
            this.zkratka.Location = new System.Drawing.Point(344, 58);
            this.zkratka.Name = "zkratka";
            this.zkratka.Size = new System.Drawing.Size(77, 13);
            this.zkratka.TabIndex = 14;
            this.zkratka.Text = "Zkratka jazyka";
            // 
            // info
            // 
            this.info.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.info.Location = new System.Drawing.Point(4, 6);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(638, 18);
            this.info.TabIndex = 13;
            this.info.Text = "Informace o jazyku";
            this.info.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // autorTxt
            // 
            this.autorTxt.Location = new System.Drawing.Point(382, 29);
            this.autorTxt.Name = "autorTxt";
            this.autorTxt.Size = new System.Drawing.Size(260, 20);
            this.autorTxt.TabIndex = 12;
            // 
            // autor
            // 
            this.autor.AutoSize = true;
            this.autor.Location = new System.Drawing.Point(344, 32);
            this.autor.Name = "autor";
            this.autor.Size = new System.Drawing.Size(32, 13);
            this.autor.TabIndex = 11;
            this.autor.Text = "Autor";
            // 
            // verzeTxt
            // 
            this.verzeTxt.Location = new System.Drawing.Point(139, 55);
            this.verzeTxt.Name = "verzeTxt";
            this.verzeTxt.Size = new System.Drawing.Size(162, 20);
            this.verzeTxt.TabIndex = 10;
            // 
            // verze
            // 
            this.verze.AutoSize = true;
            this.verze.Location = new System.Drawing.Point(3, 58);
            this.verze.Name = "verze";
            this.verze.Size = new System.Drawing.Size(67, 13);
            this.verze.TabIndex = 9;
            this.verze.Text = "Verze jazyka";
            // 
            // nazevTxt
            // 
            this.nazevTxt.Location = new System.Drawing.Point(139, 29);
            this.nazevTxt.Name = "nazevTxt";
            this.nazevTxt.Size = new System.Drawing.Size(162, 20);
            this.nazevTxt.TabIndex = 8;
            // 
            // nazev
            // 
            this.nazev.AutoSize = true;
            this.nazev.Location = new System.Drawing.Point(3, 32);
            this.nazev.Name = "nazev";
            this.nazev.Size = new System.Drawing.Size(71, 13);
            this.nazev.TabIndex = 7;
            this.nazev.Text = "Název jazyka";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(636, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Překlady";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pridatVlastniItemTXT
            // 
            this.pridatVlastniItemTXT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pridatVlastniItemTXT.Location = new System.Drawing.Point(344, 81);
            this.pridatVlastniItemTXT.Name = "pridatVlastniItemTXT";
            this.pridatVlastniItemTXT.Size = new System.Drawing.Size(298, 20);
            this.pridatVlastniItemTXT.TabIndex = 11;
            // 
            // pridatVlastniItem
            // 
            this.pridatVlastniItem.AutoSize = true;
            this.pridatVlastniItem.Location = new System.Drawing.Point(3, 84);
            this.pridatVlastniItem.Name = "pridatVlastniItem";
            this.pridatVlastniItem.Size = new System.Drawing.Size(92, 13);
            this.pridatVlastniItem.TabIndex = 10;
            this.pridatVlastniItem.Text = "Přidat vlastní item";
            // 
            // seznamItemuNeniNactenyTxt
            // 
            this.seznamItemuNeniNactenyTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.seznamItemuNeniNactenyTxt.Location = new System.Drawing.Point(344, 55);
            this.seznamItemuNeniNactenyTxt.Name = "seznamItemuNeniNactenyTxt";
            this.seznamItemuNeniNactenyTxt.Size = new System.Drawing.Size(298, 20);
            this.seznamItemuNeniNactenyTxt.TabIndex = 9;
            // 
            // seznamItemuNeniNacteny
            // 
            this.seznamItemuNeniNacteny.AutoSize = true;
            this.seznamItemuNeniNacteny.Location = new System.Drawing.Point(3, 58);
            this.seznamItemuNeniNacteny.Name = "seznamItemuNeniNacteny";
            this.seznamItemuNeniNacteny.Size = new System.Drawing.Size(239, 13);
            this.seznamItemuNeniNacteny.TabIndex = 8;
            this.seznamItemuNeniNacteny.Text = "Seznam itemů ještě neni načtený! Prosím počkej.";
            // 
            // hledejTxt
            // 
            this.hledejTxt.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hledejTxt.Location = new System.Drawing.Point(344, 29);
            this.hledejTxt.Name = "hledejTxt";
            this.hledejTxt.Size = new System.Drawing.Size(298, 20);
            this.hledejTxt.TabIndex = 7;
            // 
            // hledej
            // 
            this.hledej.AutoSize = true;
            this.hledej.Location = new System.Drawing.Point(3, 32);
            this.hledej.Name = "hledej";
            this.hledej.Size = new System.Drawing.Size(46, 13);
            this.hledej.TabIndex = 6;
            this.hledej.Text = "Hledej...";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Silver;
            this.label2.Location = new System.Drawing.Point(13, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(645, 2);
            this.label2.TabIndex = 3;
            this.label2.Text = "label2";
            // 
            // Preklad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(669, 426);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button1);
            this.Name = "Preklad";
            this.ShowIcon = false;
            this.Text = "Preklad";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox pridatVlastniItemTXT;
        private System.Windows.Forms.Label pridatVlastniItem;
        private System.Windows.Forms.TextBox seznamItemuNeniNactenyTxt;
        private System.Windows.Forms.Label seznamItemuNeniNacteny;
        private System.Windows.Forms.TextBox hledejTxt;
        private System.Windows.Forms.Label hledej;
        private System.Windows.Forms.Label info;
        private System.Windows.Forms.TextBox autorTxt;
        private System.Windows.Forms.Label autor;
        private System.Windows.Forms.TextBox verzeTxt;
        private System.Windows.Forms.Label verze;
        private System.Windows.Forms.TextBox nazevTxt;
        private System.Windows.Forms.Label nazev;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox zkratkaTxt;
        private System.Windows.Forms.Label zkratka;
    }
}