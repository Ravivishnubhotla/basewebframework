namespace PatchDownloadUtil.Tools
{
    partial class frmTemplateExplorer
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
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.tvExplorer = new System.Windows.Forms.TreeView();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsTop
            // 
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(284, 25);
            this.tsTop.TabIndex = 0;
            this.tsTop.Text = "tsTop";
            // 
            // ssBottom
            // 
            this.ssBottom.Location = new System.Drawing.Point(0, 462);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(284, 22);
            this.ssBottom.TabIndex = 1;
            this.ssBottom.Text = "statusStrip1";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.tvExplorer);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(284, 437);
            this.pnlMain.TabIndex = 2;
            // 
            // tvExplorer
            // 
            this.tvExplorer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvExplorer.Location = new System.Drawing.Point(0, 0);
            this.tvExplorer.Name = "tvExplorer";
            this.tvExplorer.Size = new System.Drawing.Size(284, 437);
            this.tvExplorer.TabIndex = 0;
            // 
            // frmTemplateExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 484);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.tsTop);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmTemplateExplorer";
            this.Text = "下载模版";
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.TreeView tvExplorer;
    }
}