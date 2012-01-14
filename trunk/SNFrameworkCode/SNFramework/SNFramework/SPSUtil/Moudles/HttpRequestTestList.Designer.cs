namespace SPSUtil.Moudles
{
    partial class HttpRequestTestList
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.tsbAdd = new System.Windows.Forms.ToolStripButton();
            this.bsList = new System.Windows.Forms.BindingSource(this.components);
            this.tsTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).BeginInit();
            this.SuspendLayout();
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAdd});
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(812, 25);
            this.tsTop.TabIndex = 4;
            this.tsTop.Text = "toolStrip1";
            this.tsTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsTop_ItemClicked);
            // 
            // ssBottom
            // 
            this.ssBottom.Location = new System.Drawing.Point(0, 345);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(812, 22);
            this.ssBottom.TabIndex = 3;
            this.ssBottom.Text = "statusStrip1";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvList);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(812, 320);
            this.pnlMain.TabIndex = 5;
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AutoGenerateColumns = false;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.DataSource = this.bsList;
            this.dgvList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvList.Enabled = false;
            this.dgvList.Location = new System.Drawing.Point(0, 0);
            this.dgvList.MultiSelect = false;
            this.dgvList.Name = "dgvList";
            this.dgvList.RowTemplate.Height = 23;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(812, 320);
            this.dgvList.TabIndex = 0;
            // 
            // tsbAdd
            // 
            this.tsbAdd.Image = global::SPSUtil.Properties.Resources.link_add;
            this.tsbAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAdd.Name = "tsbAdd";
            this.tsbAdd.Size = new System.Drawing.Size(52, 22);
            this.tsbAdd.Text = "添加";
            // 
            // HttpRequestTestList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 367);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.ssBottom);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "HttpRequestTestList";
            this.Text = "请求测试管理";
            this.Shown += new System.EventHandler(this.HttpRequestTestList_Shown);
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.BindingSource bsList;
        private System.Windows.Forms.ToolStripButton tsbAdd;
    }
}