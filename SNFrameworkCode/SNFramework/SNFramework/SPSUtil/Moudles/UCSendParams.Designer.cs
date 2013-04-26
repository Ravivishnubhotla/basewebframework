namespace SPSUtil.Moudles
{
    partial class UCSendParams
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.nudSendCount = new System.Windows.Forms.NumericUpDown();
            this.nudRetryTime = new System.Windows.Forms.NumericUpDown();
            this.nudIntreval = new System.Windows.Forms.NumericUpDown();
            this.nudTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetryTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntreval)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(419, 45);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(63, 21);
            this.numericUpDown1.TabIndex = 32;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 31;
            this.label1.Text = "发送线程数 ： ";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(201, 73);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 12);
            this.label11.TabIndex = 30;
            this.label11.Text = "（单位：毫秒）";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(201, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 12);
            this.label10.TabIndex = 29;
            this.label10.Text = "（单位：毫秒）";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(201, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 12);
            this.label9.TabIndex = 28;
            this.label9.Text = "（单位：毫秒）";
            // 
            // nudSendCount
            // 
            this.nudSendCount.Location = new System.Drawing.Point(419, 20);
            this.nudSendCount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudSendCount.Name = "nudSendCount";
            this.nudSendCount.Size = new System.Drawing.Size(63, 21);
            this.nudSendCount.TabIndex = 27;
            this.nudSendCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudSendCount.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // nudRetryTime
            // 
            this.nudRetryTime.Location = new System.Drawing.Point(123, 71);
            this.nudRetryTime.Name = "nudRetryTime";
            this.nudRetryTime.Size = new System.Drawing.Size(63, 21);
            this.nudRetryTime.TabIndex = 26;
            this.nudRetryTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudRetryTime.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // nudIntreval
            // 
            this.nudIntreval.Location = new System.Drawing.Point(123, 46);
            this.nudIntreval.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudIntreval.Name = "nudIntreval";
            this.nudIntreval.Size = new System.Drawing.Size(63, 21);
            this.nudIntreval.TabIndex = 25;
            this.nudIntreval.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudIntreval.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // nudTimeOut
            // 
            this.nudTimeOut.Location = new System.Drawing.Point(123, 20);
            this.nudTimeOut.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudTimeOut.Name = "nudTimeOut";
            this.nudTimeOut.Size = new System.Drawing.Size(63, 21);
            this.nudTimeOut.TabIndex = 24;
            this.nudTimeOut.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudTimeOut.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 12);
            this.label6.TabIndex = 23;
            this.label6.Text = "模拟数据次数 ： ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 22;
            this.label5.Text = "请求重试次数 ： ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 12);
            this.label4.TabIndex = 21;
            this.label4.Text = "请求间隔时间 ： ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 12);
            this.label3.TabIndex = 20;
            this.label3.Text = "请求超时时间 ： ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.nudTimeOut);
            this.groupBox1.Controls.Add(this.numericUpDown1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.nudIntreval);
            this.groupBox1.Controls.Add(this.nudSendCount);
            this.groupBox1.Controls.Add(this.nudRetryTime);
            this.groupBox1.Location = new System.Drawing.Point(10, 11);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 100);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据发送设置";
            // 
            // UCSendParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Name = "UCSendParams";
            this.Size = new System.Drawing.Size(518, 124);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudSendCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRetryTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudIntreval)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudTimeOut)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudSendCount;
        private System.Windows.Forms.NumericUpDown nudRetryTime;
        private System.Windows.Forms.NumericUpDown nudIntreval;
        private System.Windows.Forms.NumericUpDown nudTimeOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}
