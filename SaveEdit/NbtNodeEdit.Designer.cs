namespace SaveEdit
{
    partial class NbtNodeEdit
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
            this.lbl_jmeno = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lbl_hodnota = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_jmeno
            // 
            this.lbl_jmeno.AutoSize = true;
            this.lbl_jmeno.Location = new System.Drawing.Point(12, 15);
            this.lbl_jmeno.Name = "lbl_jmeno";
            this.lbl_jmeno.Size = new System.Drawing.Size(38, 13);
            this.lbl_jmeno.TabIndex = 0;
            this.lbl_jmeno.Text = "Jméno";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(249, 20);
            this.textBox1.TabIndex = 1;
            // 
            // lbl_hodnota
            // 
            this.lbl_hodnota.AutoSize = true;
            this.lbl_hodnota.Location = new System.Drawing.Point(12, 41);
            this.lbl_hodnota.Name = "lbl_hodnota";
            this.lbl_hodnota.Size = new System.Drawing.Size(48, 13);
            this.lbl_hodnota.TabIndex = 2;
            this.lbl_hodnota.Text = "Hodnota";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(81, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(170, 20);
            this.textBox2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(257, 38);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(73, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // NbtNodeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 70);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.lbl_hodnota);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.lbl_jmeno);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(358, 109);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(358, 109);
            this.Name = "NbtNodeEdit";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Edit values";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_jmeno;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lbl_hodnota;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
    }
}