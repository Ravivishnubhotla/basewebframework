namespace MyGeneratetionWin
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tvwObjects = new System.Windows.Forms.TreeView();
            this.tsDbTreeTop = new System.Windows.Forms.ToolStrip();
            this.tsbAddDataBase = new System.Windows.Forms.ToolStripButton();
            this.cmsDbTree = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmstsmigenerateAlExportDataSQL = new System.Windows.Forms.ToolStripMenuItem();
            this.imglDbTreeView = new System.Windows.Forms.ImageList(this.components);
            this.msTop = new System.Windows.Forms.MenuStrip();
            this.panel1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tsDbTreeTop.SuspendLayout();
            this.cmsDbTree.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTop
            // 
            this.tsTop.Location = new System.Drawing.Point(0, 24);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(1098, 25);
            this.tsTop.TabIndex = 0;
            this.tsTop.Text = "toolStrip1";
            // 
            // ssBottom
            // 
            this.ssBottom.Location = new System.Drawing.Point(0, 521);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(1098, 22);
            this.ssBottom.TabIndex = 1;
            this.ssBottom.Text = "statusStrip1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 49);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1098, 472);
            this.panel1.TabIndex = 2;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel2);
            this.splitContainer1.Panel1.Controls.Add(this.tsDbTreeTop);
            this.splitContainer1.Size = new System.Drawing.Size(1098, 472);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tvwObjects);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 447);
            this.panel2.TabIndex = 1;
            // 
            // tvwObjects
            // 
            this.tvwObjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwObjects.Location = new System.Drawing.Point(0, 0);
            this.tvwObjects.Name = "tvwObjects";
            this.tvwObjects.Size = new System.Drawing.Size(228, 447);
            this.tvwObjects.TabIndex = 0;
            // 
            // tsDbTreeTop
            // 
            this.tsDbTreeTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddDataBase});
            this.tsDbTreeTop.Location = new System.Drawing.Point(0, 0);
            this.tsDbTreeTop.Name = "tsDbTreeTop";
            this.tsDbTreeTop.Size = new System.Drawing.Size(228, 25);
            this.tsDbTreeTop.TabIndex = 0;
            this.tsDbTreeTop.Text = "tsDbTreeTop";
            // 
            // tsbAddDataBase
            // 
            this.tsbAddDataBase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbAddDataBase.Image = global::MyGeneratetionWin.Properties.Resources.database_add;
            this.tsbAddDataBase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddDataBase.Name = "tsbAddDataBase";
            this.tsbAddDataBase.Size = new System.Drawing.Size(23, 22);
            this.tsbAddDataBase.Text = "tsbAddDataBase";
            this.tsbAddDataBase.Click += new System.EventHandler(this.tsbAddDataBase_Click);
            // 
            // cmsDbTree
            // 
            this.cmsDbTree.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmstsmigenerateAlExportDataSQL});
            this.cmsDbTree.Name = "cmsDbTree";
            this.cmsDbTree.Size = new System.Drawing.Size(229, 48);
            this.cmsDbTree.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsDbTree_ItemClicked);
            // 
            // cmstsmigenerateAlExportDataSQL
            // 
            this.cmstsmigenerateAlExportDataSQL.Name = "cmstsmigenerateAlExportDataSQL";
            this.cmstsmigenerateAlExportDataSQL.Size = new System.Drawing.Size(228, 22);
            this.cmstsmigenerateAlExportDataSQL.Text = "Generate AlL Export Data SQL";
            // 
            // imglDbTreeView
            // 
            this.imglDbTreeView.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imglDbTreeView.ImageSize = new System.Drawing.Size(16, 16);
            this.imglDbTreeView.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // msTop
            // 
            this.msTop.Location = new System.Drawing.Point(0, 0);
            this.msTop.Name = "msTop";
            this.msTop.Size = new System.Drawing.Size(1098, 24);
            this.msTop.TabIndex = 3;
            this.msTop.Text = "menuStrip1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1098, 543);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.msTop);
            this.MainMenuStrip = this.msTop;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tsDbTreeTop.ResumeLayout(false);
            this.tsDbTreeTop.PerformLayout();
            this.cmsDbTree.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TreeView tvwObjects;
        private System.Windows.Forms.ToolStrip tsDbTreeTop;
        private System.Windows.Forms.ToolStripButton tsbAddDataBase;
        private System.Windows.Forms.ImageList imglDbTreeView;
        private System.Windows.Forms.MenuStrip msTop;
        private System.Windows.Forms.ContextMenuStrip cmsDbTree;
        private System.Windows.Forms.ToolStripMenuItem cmstsmigenerateAlExportDataSQL;
    }
}