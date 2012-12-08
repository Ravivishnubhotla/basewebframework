namespace PatchDownloadUtil.Documents
{
    partial class frmShowText
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
            this.txtShowText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtShowText
            // 
            this.txtShowText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtShowText.Location = new System.Drawing.Point(0, 0);
            this.txtShowText.Multiline = true;
            this.txtShowText.Name = "txtShowText";
            this.txtShowText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtShowText.Size = new System.Drawing.Size(671, 418);
            this.txtShowText.TabIndex = 0;
            // 
            // frmShowText
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 418);
            this.Controls.Add(this.txtShowText);
            this.Name = "frmShowText";
            this.Text = "显示文本";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtShowText;
    }
}