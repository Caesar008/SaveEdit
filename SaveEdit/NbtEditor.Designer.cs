namespace SaveEdit
{
    partial class NbtEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NbtEditor));
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.ok = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.rename = new System.Windows.Forms.ToolStripButton();
            this.edit = new System.Windows.Forms.ToolStripButton();
            this.delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.addByte = new System.Windows.Forms.ToolStripButton();
            this.addShort = new System.Windows.Forms.ToolStripButton();
            this.addInt = new System.Windows.Forms.ToolStripButton();
            this.addLong = new System.Windows.Forms.ToolStripButton();
            this.addFloat = new System.Windows.Forms.ToolStripButton();
            this.addDouble = new System.Windows.Forms.ToolStripButton();
            this.addByteArray = new System.Windows.Forms.ToolStripButton();
            this.addIntArray = new System.Windows.Forms.ToolStripButton();
            this.addLongArray = new System.Windows.Forms.ToolStripButton();
            this.addString = new System.Windows.Forms.ToolStripButton();
            this.addList = new System.Windows.Forms.ToolStripButton();
            this.addCompound = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(12, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(351, 420);
            this.treeView1.TabIndex = 1;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // ok
            // 
            this.ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.ok.Location = new System.Drawing.Point(288, 453);
            this.ok.Name = "ok";
            this.ok.Size = new System.Drawing.Size(75, 23);
            this.ok.TabIndex = 2;
            this.ok.Text = "OK";
            this.ok.UseVisualStyleBackColor = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rename,
            this.edit,
            this.delete,
            this.toolStripSeparator1,
            this.addByte,
            this.addShort,
            this.addInt,
            this.addLong,
            this.addFloat,
            this.addDouble,
            this.addByteArray,
            this.addIntArray,
            this.addLongArray,
            this.addString,
            this.addList,
            this.addCompound});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(375, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // rename
            // 
            this.rename.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.rename.Image = global::SaveEdit.Properties.Resources.rename;
            this.rename.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.rename.Name = "rename";
            this.rename.Size = new System.Drawing.Size(23, 22);
            this.rename.Text = "Rename tag";
            // 
            // edit
            // 
            this.edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.edit.Image = global::SaveEdit.Properties.Resources.edit;
            this.edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(23, 22);
            this.edit.Text = "Edit value";
            // 
            // delete
            // 
            this.delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.delete.Image = global::SaveEdit.Properties.Resources.krizek1;
            this.delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(23, 22);
            this.delete.Text = "Delete tag";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // addByte
            // 
            this.addByte.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addByte.Image = ((System.Drawing.Image)(resources.GetObject("addByte.Image")));
            this.addByte.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addByte.Name = "addByte";
            this.addByte.Size = new System.Drawing.Size(23, 22);
            this.addByte.Text = "Add Byte tag";
            // 
            // addShort
            // 
            this.addShort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addShort.Image = global::SaveEdit.Properties.Resources._short;
            this.addShort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addShort.Name = "addShort";
            this.addShort.Size = new System.Drawing.Size(23, 22);
            this.addShort.Text = "Add Short tag";
            // 
            // addInt
            // 
            this.addInt.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addInt.Image = global::SaveEdit.Properties.Resources._int;
            this.addInt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addInt.Name = "addInt";
            this.addInt.Size = new System.Drawing.Size(23, 22);
            this.addInt.Text = "Add Int tag";
            // 
            // addLong
            // 
            this.addLong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addLong.Image = global::SaveEdit.Properties.Resources._long;
            this.addLong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addLong.Name = "addLong";
            this.addLong.Size = new System.Drawing.Size(23, 22);
            this.addLong.Text = "Add Long tag";
            // 
            // addFloat
            // 
            this.addFloat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addFloat.Image = global::SaveEdit.Properties.Resources._float;
            this.addFloat.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addFloat.Name = "addFloat";
            this.addFloat.Size = new System.Drawing.Size(23, 22);
            this.addFloat.Text = "Add Float tag";
            // 
            // addDouble
            // 
            this.addDouble.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addDouble.Image = global::SaveEdit.Properties.Resources._double;
            this.addDouble.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addDouble.Name = "addDouble";
            this.addDouble.Size = new System.Drawing.Size(23, 22);
            this.addDouble.Text = "Add Double tag";
            // 
            // addByteArray
            // 
            this.addByteArray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addByteArray.Image = global::SaveEdit.Properties.Resources.byteArray;
            this.addByteArray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addByteArray.Name = "addByteArray";
            this.addByteArray.Size = new System.Drawing.Size(23, 22);
            this.addByteArray.Text = "Add Byte Array tag";
            // 
            // addIntArray
            // 
            this.addIntArray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addIntArray.Image = global::SaveEdit.Properties.Resources.intArray;
            this.addIntArray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addIntArray.Name = "addIntArray";
            this.addIntArray.Size = new System.Drawing.Size(23, 22);
            this.addIntArray.Text = "Add Int Array tag";
            // 
            // addLongArray
            // 
            this.addLongArray.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addLongArray.Image = global::SaveEdit.Properties.Resources.longArray;
            this.addLongArray.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addLongArray.Name = "addLongArray";
            this.addLongArray.Size = new System.Drawing.Size(23, 22);
            this.addLongArray.Text = "Add Long Array tag";
            // 
            // addString
            // 
            this.addString.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addString.Image = global::SaveEdit.Properties.Resources._string;
            this.addString.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addString.Name = "addString";
            this.addString.Size = new System.Drawing.Size(23, 22);
            this.addString.Text = "Add String tag";
            // 
            // addList
            // 
            this.addList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addList.Image = global::SaveEdit.Properties.Resources.list;
            this.addList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addList.Name = "addList";
            this.addList.Size = new System.Drawing.Size(23, 22);
            this.addList.Text = "Add List";
            // 
            // addCompound
            // 
            this.addCompound.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.addCompound.Image = global::SaveEdit.Properties.Resources.compound;
            this.addCompound.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCompound.Name = "addCompound";
            this.addCompound.Size = new System.Drawing.Size(23, 22);
            this.addCompound.Text = "Add Compound";
            // 
            // NbtEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 488);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.ok);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NbtEditor";
            this.Text = "Properties";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton rename;
        private System.Windows.Forms.ToolStripButton edit;
        private System.Windows.Forms.ToolStripButton delete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton addByte;
        private System.Windows.Forms.ToolStripButton addShort;
        private System.Windows.Forms.ToolStripButton addInt;
        private System.Windows.Forms.ToolStripButton addLong;
        private System.Windows.Forms.ToolStripButton addFloat;
        private System.Windows.Forms.ToolStripButton addDouble;
        private System.Windows.Forms.ToolStripButton addByteArray;
        private System.Windows.Forms.ToolStripButton addIntArray;
        private System.Windows.Forms.ToolStripButton addLongArray;
        private System.Windows.Forms.ToolStripButton addString;
        private System.Windows.Forms.ToolStripButton addList;
        private System.Windows.Forms.ToolStripButton addCompound;
    }
}