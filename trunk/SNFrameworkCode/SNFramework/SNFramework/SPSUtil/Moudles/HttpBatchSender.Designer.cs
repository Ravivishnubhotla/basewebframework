namespace SPSUtil.Moudles
{
    partial class HttpBatchSender
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
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tsbMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.tsbCancelProgress = new System.Windows.Forms.ToolStripSplitButton();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.tsbUrlSender = new System.Windows.Forms.ToolStripButton();
            this.tsbSendDataUrls = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.rtxtOutput = new System.Windows.Forms.RichTextBox();
            this.bgwSenderUrl = new System.ComponentModel.BackgroundWorker();
            this.ssBottom.SuspendLayout();
            this.tsTop.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ssBottom
            // 
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbMessage,
            this.tsbProgressBar,
            this.tsbCancelProgress});
            this.ssBottom.Location = new System.Drawing.Point(0, 367);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(991, 22);
            this.ssBottom.TabIndex = 0;
            this.ssBottom.Text = "statusStrip1";
            // 
            // tsbMessage
            // 
            this.tsbMessage.Name = "tsbMessage";
            this.tsbMessage.Size = new System.Drawing.Size(0, 17);
            // 
            // tsbProgressBar
            // 
            this.tsbProgressBar.Name = "tsbProgressBar";
            this.tsbProgressBar.Size = new System.Drawing.Size(100, 17);
            this.tsbProgressBar.Visible = false;
            // 
            // tsbCancelProgress
            // 
            this.tsbCancelProgress.Image = global::SPSUtil.Properties.Resources.cancel;
            this.tsbCancelProgress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancelProgress.Name = "tsbCancelProgress";
            this.tsbCancelProgress.Size = new System.Drawing.Size(78, 21);
            this.tsbCancelProgress.Text = "Cancel";
            this.tsbCancelProgress.Visible = false;
            this.tsbCancelProgress.ButtonClick += new System.EventHandler(this.tsbCancelProgress_ButtonClick);
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUrlSender,
            this.tsbSendDataUrls});
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(991, 25);
            this.tsTop.TabIndex = 1;
            this.tsTop.Text = "tsTop";
            this.tsTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsTop_ItemClicked);
            // 
            // tsbUrlSender
            // 
            this.tsbUrlSender.Image = global::SPSUtil.Properties.Resources.link_go;
            this.tsbUrlSender.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUrlSender.Name = "tsbUrlSender";
            this.tsbUrlSender.Size = new System.Drawing.Size(148, 22);
            this.tsbUrlSender.Text = "直接批量发送测试请求";
            // 
            // tsbSendDataUrls
            // 
            this.tsbSendDataUrls.Image = global::SPSUtil.Properties.Resources.brick_link;
            this.tsbSendDataUrls.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSendDataUrls.Name = "tsbSendDataUrls";
            this.tsbSendDataUrls.Size = new System.Drawing.Size(148, 22);
            this.tsbSendDataUrls.Text = "直接批量发送数据请求";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.rtxtOutput);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(991, 342);
            this.pnlMain.TabIndex = 2;
            // 
            // rtxtOutput
            // 
            this.rtxtOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxtOutput.Location = new System.Drawing.Point(0, 0);
            this.rtxtOutput.Name = "rtxtOutput";
            this.rtxtOutput.ReadOnly = true;
            this.rtxtOutput.Size = new System.Drawing.Size(991, 342);
            this.rtxtOutput.TabIndex = 0;
            this.rtxtOutput.Text = "";
            // 
            // bgwSenderUrl
            // 
            this.bgwSenderUrl.WorkerReportsProgress = true;
            this.bgwSenderUrl.WorkerSupportsCancellation = true;
            this.bgwSenderUrl.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwSenderUrl_DoWork);
            this.bgwSenderUrl.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwSenderUrl_ProgressChanged);
            this.bgwSenderUrl.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgwSenderUrl_RunWorkerCompleted);
            // 
            // HttpBatchSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(991, 389);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.ssBottom);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "HttpBatchSender";
            this.Text = "批量发送Http请求";
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStripButton tsbUrlSender;
        private System.Windows.Forms.RichTextBox rtxtOutput;
        private System.Windows.Forms.ToolStripStatusLabel tsbMessage;
        private System.Windows.Forms.ToolStripProgressBar tsbProgressBar;
        private System.ComponentModel.BackgroundWorker bgwSenderUrl;
        private System.Windows.Forms.ToolStripSplitButton tsbCancelProgress;
        private System.Windows.Forms.ToolStripButton tsbSendDataUrls;
    }
}