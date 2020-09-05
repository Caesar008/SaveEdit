namespace SaveEdit
{
    partial class NacitamSave
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
            this.nacitamSaveLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // nacitamSaveLbl
            // 
            this.nacitamSaveLbl.AutoSize = true;
            this.nacitamSaveLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nacitamSaveLbl.Location = new System.Drawing.Point(12, 9);
            this.nacitamSaveLbl.Name = "nacitamSaveLbl";
            this.nacitamSaveLbl.Size = new System.Drawing.Size(0, 24);
            this.nacitamSaveLbl.TabIndex = 0;
            this.nacitamSaveLbl.Text = Jazyk.Strings.Nacitam_Save;
            // 
            // NacitamSave
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 43);
            this.Controls.Add(this.nacitamSaveLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(352, 82);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(352, 82);
            this.Name = "NacitamSave";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nacitamSaveLbl;
    }
}