namespace SPSUtil.Moudles
{
    partial class FrmPhoneDataToNoSQL
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.pnlbottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lblProcessProgress = new System.Windows.Forms.Label();
            this.lblProcessStatus = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblTitleProcessProgress = new System.Windows.Forms.Label();
            this.lblTitleProcessStatus = new System.Windows.Forms.Label();
            this.bgwDataToNoSQL = new System.ComponentModel.BackgroundWorker();
            this.gbLine = new System.Windows.Forms.GroupBox();
            this.pnlTop.SuspendLayout();
            this.pnlbottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(779, 43);
            this.pnlTop.TabIndex = 11;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(12, 12);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(0, 16);
            this.lblTitle.TabIndex = 0;
            // 
            // pnlbottom
            // 
            this.pnlbottom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlbottom.Controls.Add(this.btnCancel);
            this.pnlbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlbottom.Location = new System.Drawing.Point(0, 140);
            this.pnlbottom.Name = "pnlbottom";
            this.pnlbottom.Size = new System.Drawing.Size(779, 38);
            this.pnlbottom.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(692, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblProcessProgress
            // 
            this.lblProcessProgress.AutoSize = true;
            this.lblProcessProgress.Location = new System.Drawing.Point(84, 111);
            this.lblProcessProgress.Name = "lblProcessProgress";
            this.lblProcessProgress.Size = new System.Drawing.Size(0, 12);
            this.lblProcessProgress.TabIndex = 19;
            // 
            // lblProcessStatus
            // 
            this.lblProcessStatus.AutoSize = true;
            this.lblProcessStatus.Location = new System.Drawing.Point(84, 83);
            this.lblProcessStatus.Name = "lblProcessStatus";
            this.lblProcessStatus.Size = new System.Drawing.Size(0, 12);
            this.lblProcessStatus.TabIndex = 18;
            // 
            // lblFilePath
            // 
            this.lblFilePath.AutoSize = true;
            this.lblFilePath.Location = new System.Drawing.Point(84, 57);
            this.lblFilePath.Name = "lblFilePath";
            this.lblFilePath.Size = new System.Drawing.Size(0, 12);
            this.lblFilePath.TabIndex = 17;
            // 
            // pgbProgress
            // 
            this.pgbProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.pgbProgress.Location = new System.Drawing.Point(21, 106);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(746, 23);
            this.pgbProgress.TabIndex = 15;
            // 
            // lblTitleProcessProgress
            // 
            this.lblTitleProcessProgress.AutoSize = true;
            this.lblTitleProcessProgress.Location = new System.Drawing.Point(19, 83);
            this.lblTitleProcessProgress.Name = "lblTitleProcessProgress";
            this.lblTitleProcessProgress.Size = new System.Drawing.Size(65, 12);
            this.lblTitleProcessProgress.TabIndex = 14;
            this.lblTitleProcessProgress.Text = "操作进度：";
            // 
            // lblTitleProcessStatus
            // 
            this.lblTitleProcessStatus.AutoSize = true;
            this.lblTitleProcessStatus.Location = new System.Drawing.Point(19, 57);
            this.lblTitleProcessStatus.Name = "lblTitleProcessStatus";
            this.lblTitleProcessStatus.Size = new System.Drawing.Size(65, 12);
            this.lblTitleProcessStatus.TabIndex = 13;
            this.lblTitleProcessStatus.Text = "操作状态：";
            // 
            // bgwDataToNoSQL
            // 
            this.bgwDataToNoSQL.WorkerReportsProgress = true;
            this.bgwDataToNoSQL.WorkerSupportsCancellation = true;
            this.bgwDataToNoSQL.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgwDataToNoSQL_DoWork);
            this.bgwDataToNoSQL.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgwDataToNoSQL_ProgressChanged);
            // 
            // gbLine
            // 
            this.gbLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbLine.Location = new System.Drawing.Point(0, 178);
            this.gbLine.Name = "gbLine";
            this.gbLine.Size = new System.Drawing.Size(779, 2);
            this.gbLine.TabIndex = 20;
            this.gbLine.TabStop = false;
            // 
            // FrmPhoneDataToNoSQL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 180);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.pnlbottom);
            this.Controls.Add(this.lblProcessProgress);
            this.Controls.Add(this.lblProcessStatus);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.lblTitleProcessProgress);
            this.Controls.Add(this.lblTitleProcessStatus);
            this.Controls.Add(this.gbLine);
            this.Name = "FrmPhoneDataToNoSQL";
            this.Text = "FrmPhoneDataToNoSQL";
            this.Shown += new System.EventHandler(this.FrmPhoneDataToNoSQL_Shown);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlbottom.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlbottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblProcessProgress;
        private System.Windows.Forms.Label lblProcessStatus;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblTitleProcessProgress;
        private System.Windows.Forms.Label lblTitleProcessStatus;
        private System.ComponentModel.BackgroundWorker bgwDataToNoSQL;
        private System.Windows.Forms.GroupBox gbLine;
    }
}