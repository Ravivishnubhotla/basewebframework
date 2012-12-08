namespace PatchDownloadUtil.Documents
{
    partial class frmDownloadYouku
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
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.BtnAnalysisUrl = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvResult = new System.Windows.Forms.DataGridView();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.bsResult = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResult)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtUrl
            // 
            this.TxtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtUrl.Location = new System.Drawing.Point(12, 12);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(664, 21);
            this.TxtUrl.TabIndex = 0;
            // 
            // BtnAnalysisUrl
            // 
            this.BtnAnalysisUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnAnalysisUrl.Location = new System.Drawing.Point(682, 10);
            this.BtnAnalysisUrl.Name = "BtnAnalysisUrl";
            this.BtnAnalysisUrl.Size = new System.Drawing.Size(75, 23);
            this.BtnAnalysisUrl.TabIndex = 2;
            this.BtnAnalysisUrl.Text = "分析链接";
            this.BtnAnalysisUrl.UseVisualStyleBackColor = true;
            this.BtnAnalysisUrl.Click += new System.EventHandler(this.BtnAnalysisUrl_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.tsTop);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(745, 411);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "分析结果";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvResult);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 366);
            this.panel1.TabIndex = 1;
            // 
            // dgvResult
            // 
            this.dgvResult.AllowUserToAddRows = false;
            this.dgvResult.AllowUserToDeleteRows = false;
            this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvResult.Location = new System.Drawing.Point(0, 0);
            this.dgvResult.Name = "dgvResult";
            this.dgvResult.RowTemplate.Height = 23;
            this.dgvResult.Size = new System.Drawing.Size(739, 366);
            this.dgvResult.TabIndex = 0;
            // 
            // tsTop
            // 
            this.tsTop.Location = new System.Drawing.Point(3, 17);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(739, 25);
            this.tsTop.TabIndex = 0;
            this.tsTop.Text = "toolStrip1";
            // 
            // frmDownloadYouku
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 462);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnAnalysisUrl);
            this.Controls.Add(this.TxtUrl);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmDownloadYouku";
            this.Text = "优酷下载地址分析工具";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsResult)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtUrl;
        private System.Windows.Forms.Button BtnAnalysisUrl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.DataGridView dgvResult;
        private System.Windows.Forms.BindingSource bsResult;
    }
}