namespace SPSUtil.Moudles
{
    partial class frmTestSendTask
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtOkMessage = new System.Windows.Forms.TextBox();
            this.nudTimeOut = new System.Windows.Forms.NumericUpDown();
            this.nudIntreval = new System.Windows.Forms.NumericUpDown();
            this.nudRetryTime = new System.Windows.Forms.NumericUpDown();
            this.nudSendCount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.btnStartTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.ucChannelParams1 = new SPSUtil.Moudles.UCChannelParams();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntreval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetryTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "成功响应信息 ： ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "请求超时时间 ： ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 269);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "请求间隔时间 ： ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 294);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "请求重试次数 ： ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 320);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "模拟数据次数 ： ";
            // 
            // txtOkMessage
            // 
            this.txtOkMessage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOkMessage.Location = new System.Drawing.Point(126, 215);
            this.txtOkMessage.Name = "txtOkMessage";
            this.txtOkMessage.Size = new System.Drawing.Size(684, 21);
            this.txtOkMessage.TabIndex = 7;
            this.txtOkMessage.Text = "ok";
            // 
            // nudTimeOut
            // 
            this.nudTimeOut.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudTimeOut.Location = new System.Drawing.Point(126, 241);
            this.nudTimeOut.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTimeOut.Name = "nudTimeOut";
            this.nudTimeOut.Size = new System.Drawing.Size(684, 21);
            this.nudTimeOut.TabIndex = 8;
            this.nudTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTimeOut.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // nudIntreval
            // 
            this.nudIntreval.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudIntreval.Location = new System.Drawing.Point(126, 267);
            this.nudIntreval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudIntreval.Name = "nudIntreval";
            this.nudIntreval.Size = new System.Drawing.Size(684, 21);
            this.nudIntreval.TabIndex = 9;
            this.nudIntreval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudIntreval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudRetryTime
            // 
            this.nudRetryTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudRetryTime.Location = new System.Drawing.Point(126, 292);
            this.nudRetryTime.Name = "nudRetryTime";
            this.nudRetryTime.Size = new System.Drawing.Size(684, 21);
            this.nudRetryTime.TabIndex = 10;
            this.nudRetryTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRetryTime.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudSendCount
            // 
            this.nudSendCount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nudSendCount.Location = new System.Drawing.Point(126, 318);
            this.nudSendCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSendCount.Name = "nudSendCount";
            this.nudSendCount.Size = new System.Drawing.Size(684, 21);
            this.nudSendCount.TabIndex = 11;
            this.nudSendCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSendCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(816, 218);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 12);
            this.label8.TabIndex = 13;
            this.label8.Text = "（例：ok）";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(816, 243);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 14;
            this.label9.Text = "（单位：毫秒）";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(816, 269);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 15;
            this.label10.Text = "（单位：毫秒）";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(816, 294);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 16;
            this.label11.Text = "（单位：毫秒）";
            // 
            // btnStartTest
            // 
            this.btnStartTest.Location = new System.Drawing.Point(371, 371);
            this.btnStartTest.Name = "btnStartTest";
            this.btnStartTest.Size = new System.Drawing.Size(75, 23);
            this.btnStartTest.TabIndex = 17;
            this.btnStartTest.Text = "开始测试";
            this.btnStartTest.UseVisualStyleBackColor = true;
            this.btnStartTest.Click += new System.EventHandler(this.btnStartTest_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 345);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "模拟线程次数 ： ";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(126, 343);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(684, 21);
            this.numericUpDown1.TabIndex = 19;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(452, 371);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 23);
            this.button1.TabIndex = 20;
            this.button1.Text = "保存测试设置";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ucChannelParams1
            // 
            this.ucChannelParams1.Location = new System.Drawing.Point(17, 16);
            this.ucChannelParams1.Name = "ucChannelParams1";
            this.ucChannelParams1.Size = new System.Drawing.Size(873, 190);
            this.ucChannelParams1.TabIndex = 21;
            // 
            // frmTestSendTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 402);
            this.Controls.Add(this.ucChannelParams1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnStartTest);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudSendCount);
            this.Controls.Add(this.nudRetryTime);
            this.Controls.Add(this.nudIntreval);
            this.Controls.Add(this.nudTimeOut);
            this.Controls.Add(this.txtOkMessage);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Name = "frmTestSendTask";
            this.Text = "模拟请求测试任务";
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntreval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetryTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtOkMessage;
        private System.Windows.Forms.NumericUpDown nudTimeOut;
        private System.Windows.Forms.NumericUpDown nudIntreval;
        private System.Windows.Forms.NumericUpDown nudRetryTime;
        private System.Windows.Forms.NumericUpDown nudSendCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btnStartTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button1;
        private UCChannelParams ucChannelParams1;
    }
}