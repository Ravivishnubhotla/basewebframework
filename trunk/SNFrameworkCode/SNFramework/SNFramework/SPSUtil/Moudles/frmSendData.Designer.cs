namespace SPSUtil.Moudles
{
    partial class frmSendData
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
            this.pnlbottom = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProcessProgress = new System.Windows.Forms.Label();
            this.lblProcessStatus = new System.Windows.Forms.Label();
            this.lblFilePath = new System.Windows.Forms.Label();
            this.pgbProgress = new System.Windows.Forms.ProgressBar();
            this.lblTitleProcessProgress = new System.Windows.Forms.Label();
            this.lblTitleProcessStatus = new System.Windows.Forms.Label();
            this.bgwLoadPhoneData = new System.ComponentModel.BackgroundWorker();
            this.gbLine = new System.Windows.Forms.GroupBox();
            this.rtxtOutput = new System.Windows.Forms.RichTextBox();
            this.pnlbottom.SuspendLayout();
            this.pnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlbottom
            // 
            this.pnlbottom.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlbottom.Controls.Add(this.btnCancel);
            this.pnlbottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlbottom.Location = new System.Drawing.Point(0, 406);
            this.pnlbottom.Name = "pnlbottom";
            this.pnlbottom.Size = new System.Drawing.Size(862, 38);
            this.pnlbottom.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(775, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 22);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(862, 43);
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
            // lblProcessProgress
            // 
            this.lblProcessProgress.AutoSize = true;
            this.lblProcessProgress.Location = new System.Drawing.Point(90, 85);
            this.lblProcessProgress.Name = "lblProcessProgress";
            this.lblProcessProgress.Size = new System.Drawing.Size(0, 12);
            this.lblProcessProgress.TabIndex = 19;
            // 
            // lblProcessStatus
            // 
            this.lblProcessStatus.AutoSize = true;
            this.lblProcessStatus.Location = new System.Drawing.Point(90, 57);
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
            this.pgbProgress.Location = new System.Drawing.Point(15, 114);
            this.pgbProgress.Name = "pgbProgress";
            this.pgbProgress.Size = new System.Drawing.Size(835, 23);
            this.pgbProgress.TabIndex = 15;
            // 
            // lblTitleProcessProgress
            // 
            this.lblTitleProcessProgress.AutoSize = true;
            this.lblTitleProcessProgress.Location = new System.Drawing.Point(19, 85);
            this.lblTitleProcessProgress.Name = "lblTitleProcessProgress";
            this.lblTitleProcessProgress.Size = new System.Drawing.Size(65, 12);
            this.lblTitleProcessProgress.TabIndex = 14;
            this.lblTitleProcessProgress.Text = "导入进度：";
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
            // bgwLoadPhoneData
            // 
            this.bgwLoadPhoneData.WorkerReportsProgress = true;
            this.bgwLoadPhoneData.WorkerSupportsCancellation = true;
            // 
            // gbLine
            // 
            this.gbLine.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.gbLine.Location = new System.Drawing.Point(0, 444);
            this.gbLine.Name = "gbLine";
            this.gbLine.Size = new System.Drawing.Size(862, 2);
            this.gbLine.TabIndex = 20;
            this.gbLine.TabStop = false;
            // 
            // rtxtOutput
            // 
            this.rtxtOutput.Location = new System.Drawing.Point(15, 154);
            this.rtxtOutput.Name = "rtxtOutput";
            this.rtxtOutput.ReadOnly = true;
            this.rtxtOutput.Size = new System.Drawing.Size(835, 233);
            this.rtxtOutput.TabIndex = 21;
            this.rtxtOutput.Text = "";
            // 
            // frmSendData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 446);
            this.Controls.Add(this.rtxtOutput);
            this.Controls.Add(this.pnlbottom);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.lblProcessProgress);
            this.Controls.Add(this.lblProcessStatus);
            this.Controls.Add(this.lblFilePath);
            this.Controls.Add(this.pgbProgress);
            this.Controls.Add(this.lblTitleProcessProgress);
            this.Controls.Add(this.lblTitleProcessStatus);
            this.Controls.Add(this.gbLine);
            this.Name = "frmSendData";
            this.Text = "frmSendData";
            this.pnlbottom.ResumeLayout(false);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlbottom;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblProcessProgress;
        private System.Windows.Forms.Label lblProcessStatus;
        private System.Windows.Forms.Label lblFilePath;
        private System.Windows.Forms.ProgressBar pgbProgress;
        private System.Windows.Forms.Label lblTitleProcessProgress;
        private System.Windows.Forms.Label lblTitleProcessStatus;
        private System.ComponentModel.BackgroundWorker bgwLoadPhoneData;
        private System.Windows.Forms.GroupBox gbLine;
        private System.Windows.Forms.RichTextBox rtxtOutput;
    }
}