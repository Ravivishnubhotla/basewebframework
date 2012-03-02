namespace SendDataWinTools
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtSendText = new System.Windows.Forms.TextBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.btnSender = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrl.Location = new System.Drawing.Point(12, 12);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(630, 21);
            this.txtUrl.TabIndex = 0;
            // 
            // txtSendText
            // 
            this.txtSendText.Location = new System.Drawing.Point(12, 39);
            this.txtSendText.Multiline = true;
            this.txtSendText.Name = "txtSendText";
            this.txtSendText.Size = new System.Drawing.Size(255, 211);
            this.txtSendText.TabIndex = 1;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(370, 39);
            this.txtResult.Multiline = true;
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(272, 211);
            this.txtResult.TabIndex = 2;
            // 
            // btnSender
            // 
            this.btnSender.Location = new System.Drawing.Point(280, 45);
            this.btnSender.Name = "btnSender";
            this.btnSender.Size = new System.Drawing.Size(75, 23);
            this.btnSender.TabIndex = 3;
            this.btnSender.Text = "Send";
            this.btnSender.UseVisualStyleBackColor = true;
            this.btnSender.Click += new System.EventHandler(this.btnSender_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 262);
            this.Controls.Add(this.btnSender);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.txtSendText);
            this.Controls.Add(this.txtUrl);
            this.Name = "MainForm";
            this.Text = "Xml Post Test";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtSendText;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.Button btnSender;
    }
}