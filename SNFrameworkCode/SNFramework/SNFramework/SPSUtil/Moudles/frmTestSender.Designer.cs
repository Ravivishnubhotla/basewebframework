namespace SPSUtil.Moudles
{
    partial class frmTestSender
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
            this.btnSend = new System.Windows.Forms.Button();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.chkHasPostData = new System.Windows.Forms.CheckBox();
            this.txtRequestMessage = new System.Windows.Forms.TextBox();
            this.txtResponseMessge = new System.Windows.Forms.TextBox();
            this.tblRequestMessage = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tblResponseMessge = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tblRequestMessage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tblResponseMessge.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Location = new System.Drawing.Point(544, 12);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(12, 14);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(526, 21);
            this.txtUrl.TabIndex = 1;
            // 
            // chkHasPostData
            // 
            this.chkHasPostData.AutoSize = true;
            this.chkHasPostData.Location = new System.Drawing.Point(12, 55);
            this.chkHasPostData.Name = "chkHasPostData";
            this.chkHasPostData.Size = new System.Drawing.Size(120, 16);
            this.chkHasPostData.TabIndex = 2;
            this.chkHasPostData.Text = "包含本地请求数据";
            this.chkHasPostData.UseVisualStyleBackColor = true;
            this.chkHasPostData.CheckedChanged += new System.EventHandler(this.chkHasPostData_CheckedChanged);
            // 
            // txtRequestMessage
            // 
            this.txtRequestMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRequestMessage.Location = new System.Drawing.Point(3, 3);
            this.txtRequestMessage.Multiline = true;
            this.txtRequestMessage.Name = "txtRequestMessage";
            this.txtRequestMessage.Size = new System.Drawing.Size(271, 131);
            this.txtRequestMessage.TabIndex = 3;
            // 
            // txtResponseMessge
            // 
            this.txtResponseMessge.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtResponseMessge.Location = new System.Drawing.Point(3, 3);
            this.txtResponseMessge.Multiline = true;
            this.txtResponseMessge.Name = "txtResponseMessge";
            this.txtResponseMessge.Size = new System.Drawing.Size(297, 131);
            this.txtResponseMessge.TabIndex = 4;
            // 
            // tblRequestMessage
            // 
            this.tblRequestMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tblRequestMessage.Controls.Add(this.tabPage1);
            this.tblRequestMessage.Location = new System.Drawing.Point(12, 87);
            this.tblRequestMessage.Name = "tblRequestMessage";
            this.tblRequestMessage.SelectedIndex = 0;
            this.tblRequestMessage.Size = new System.Drawing.Size(285, 163);
            this.tblRequestMessage.TabIndex = 5;
            this.tblRequestMessage.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRequestMessage);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(277, 137);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "发送信息";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tblResponseMessge
            // 
            this.tblResponseMessge.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblResponseMessge.Controls.Add(this.tabPage2);
            this.tblResponseMessge.Location = new System.Drawing.Point(308, 87);
            this.tblResponseMessge.Name = "tblResponseMessge";
            this.tblResponseMessge.SelectedIndex = 0;
            this.tblResponseMessge.Size = new System.Drawing.Size(311, 163);
            this.tblResponseMessge.TabIndex = 6;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtResponseMessge);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(303, 137);
            this.tabPage2.TabIndex = 0;
            this.tabPage2.Text = "响应信息";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmTestSender
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 262);
            this.Controls.Add(this.tblResponseMessge);
            this.Controls.Add(this.tblRequestMessage);
            this.Controls.Add(this.chkHasPostData);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.btnSend);
            this.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "frmTestSender";
            this.Text = "Http请求测试器";
            this.tblRequestMessage.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tblResponseMessge.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.CheckBox chkHasPostData;
        private System.Windows.Forms.TextBox txtRequestMessage;
        private System.Windows.Forms.TextBox txtResponseMessge;
        private System.Windows.Forms.TabControl tblRequestMessage;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabControl tblResponseMessge;
        private System.Windows.Forms.TabPage tabPage2;
    }
}