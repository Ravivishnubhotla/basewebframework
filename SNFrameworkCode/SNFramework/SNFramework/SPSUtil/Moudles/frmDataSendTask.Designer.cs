namespace SPSUtil.Moudles
{
    partial class frmDataSendTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmDataSendTask));
            this.pnlMain = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucChannelParams1 = new SPSUtil.Moudles.UCChannelParams();
            this.gbDataSendType = new System.Windows.Forms.GroupBox();
            this.rbLoadDataSend = new System.Windows.Forms.RadioButton();
            this.rbTestDataSend = new System.Windows.Forms.RadioButton();
            this.cmbChannelList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ucSendParams1 = new SPSUtil.Moudles.UCSendParams();
            this.btnSaveSendText = new System.Windows.Forms.Button();
            this.btnSendData = new System.Windows.Forms.Button();
            this.btnGenerateTestData = new System.Windows.Forms.Button();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.btnLoadExcel = new System.Windows.Forms.ToolStripButton();
            this.btnLoadText = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.opfLoadExcel = new System.Windows.Forms.OpenFileDialog();
            this.sfdSendText = new System.Windows.Forms.SaveFileDialog();
            this.opfLoadText = new System.Windows.Forms.OpenFileDialog();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbDataSendType.SuspendLayout();
            this.tsTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.splitContainer1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(880, 666);
            this.pnlMain.TabIndex = 11;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(880, 666);
            this.splitContainer1.SplitterDistance = 270;
            this.splitContainer1.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(880, 270);
            this.dataGridView1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ucChannelParams1);
            this.panel1.Controls.Add(this.gbDataSendType);
            this.panel1.Controls.Add(this.cmbChannelList);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.ucSendParams1);
            this.panel1.Controls.Add(this.btnSaveSendText);
            this.panel1.Controls.Add(this.btnSendData);
            this.panel1.Controls.Add(this.btnGenerateTestData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(880, 392);
            this.panel1.TabIndex = 0;
            // 
            // ucChannelParams1
            // 
            this.ucChannelParams1.ChannelSetting = ((SPSUtil.AppCode.ChannelSendSettings)(resources.GetObject("ucChannelParams1.ChannelSetting")));
            this.ucChannelParams1.Location = new System.Drawing.Point(12, 49);
            this.ucChannelParams1.Name = "ucChannelParams1";
            this.ucChannelParams1.Size = new System.Drawing.Size(830, 200);
            this.ucChannelParams1.TabIndex = 27;
            // 
            // gbDataSendType
            // 
            this.gbDataSendType.Controls.Add(this.rbLoadDataSend);
            this.gbDataSendType.Controls.Add(this.rbTestDataSend);
            this.gbDataSendType.Location = new System.Drawing.Point(523, 300);
            this.gbDataSendType.Name = "gbDataSendType";
            this.gbDataSendType.Size = new System.Drawing.Size(319, 60);
            this.gbDataSendType.TabIndex = 26;
            this.gbDataSendType.TabStop = false;
            this.gbDataSendType.Text = "发送数据类型";
            // 
            // rbLoadDataSend
            // 
            this.rbLoadDataSend.AutoSize = true;
            this.rbLoadDataSend.Checked = true;
            this.rbLoadDataSend.Location = new System.Drawing.Point(95, 25);
            this.rbLoadDataSend.Name = "rbLoadDataSend";
            this.rbLoadDataSend.Size = new System.Drawing.Size(71, 16);
            this.rbLoadDataSend.TabIndex = 1;
            this.rbLoadDataSend.TabStop = true;
            this.rbLoadDataSend.Text = "加载数据";
            this.rbLoadDataSend.UseVisualStyleBackColor = true;
            // 
            // rbTestDataSend
            // 
            this.rbTestDataSend.AutoSize = true;
            this.rbTestDataSend.Location = new System.Drawing.Point(17, 25);
            this.rbTestDataSend.Name = "rbTestDataSend";
            this.rbTestDataSend.Size = new System.Drawing.Size(71, 16);
            this.rbTestDataSend.TabIndex = 0;
            this.rbTestDataSend.Text = "模拟数据";
            this.rbTestDataSend.UseVisualStyleBackColor = true;
            // 
            // cmbChannelList
            // 
            this.cmbChannelList.DisplayMember = "Name";
            this.cmbChannelList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChannelList.FormattingEnabled = true;
            this.cmbChannelList.Location = new System.Drawing.Point(117, 7);
            this.cmbChannelList.Name = "cmbChannelList";
            this.cmbChannelList.Size = new System.Drawing.Size(751, 20);
            this.cmbChannelList.TabIndex = 25;
            this.cmbChannelList.SelectedIndexChanged += new System.EventHandler(this.cmbChannelList_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 24;
            this.label1.Text = "选择服务器通道：";
            // 
            // ucSendParams1
            // 
            this.ucSendParams1.Location = new System.Drawing.Point(0, 255);
            this.ucSendParams1.Name = "ucSendParams1";
            this.ucSendParams1.Size = new System.Drawing.Size(518, 118);
            this.ucSendParams1.TabIndex = 23;
            // 
            // btnSaveSendText
            // 
            this.btnSaveSendText.Location = new System.Drawing.Point(520, 273);
            this.btnSaveSendText.Name = "btnSaveSendText";
            this.btnSaveSendText.Size = new System.Drawing.Size(104, 21);
            this.btnSaveSendText.TabIndex = 4;
            this.btnSaveSendText.Text = "生成发送链接包";
            this.btnSaveSendText.UseVisualStyleBackColor = true;
            this.btnSaveSendText.Click += new System.EventHandler(this.btnSaveSendText_Click);
            // 
            // btnSendData
            // 
            this.btnSendData.Location = new System.Drawing.Point(740, 273);
            this.btnSendData.Name = "btnSendData";
            this.btnSendData.Size = new System.Drawing.Size(75, 21);
            this.btnSendData.TabIndex = 3;
            this.btnSendData.Text = "发送数据";
            this.btnSendData.UseVisualStyleBackColor = true;
            this.btnSendData.Click += new System.EventHandler(this.btnSendData_Click);
            // 
            // btnGenerateTestData
            // 
            this.btnGenerateTestData.Location = new System.Drawing.Point(630, 273);
            this.btnGenerateTestData.Name = "btnGenerateTestData";
            this.btnGenerateTestData.Size = new System.Drawing.Size(104, 21);
            this.btnGenerateTestData.TabIndex = 2;
            this.btnGenerateTestData.Text = "生成测试链接";
            this.btnGenerateTestData.UseVisualStyleBackColor = true;
            this.btnGenerateTestData.Click += new System.EventHandler(this.btnGenerateTestData_Click);
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnLoadExcel,
            this.btnLoadText,
            this.toolStripButton3});
            this.tsTop.Location = new System.Drawing.Point(0, 0);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(880, 25);
            this.tsTop.TabIndex = 10;
            this.tsTop.Text = "toolStrip1";
            // 
            // btnLoadExcel
            // 
            this.btnLoadExcel.Image = global::SPSUtil.Properties.Resources.page_excel;
            this.btnLoadExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadExcel.Name = "btnLoadExcel";
            this.btnLoadExcel.Size = new System.Drawing.Size(81, 22);
            this.btnLoadExcel.Text = "加载Excel";
            this.btnLoadExcel.Click += new System.EventHandler(this.btnLoadExcel_Click);
            // 
            // btnLoadText
            // 
            this.btnLoadText.Image = global::SPSUtil.Properties.Resources.page_white_text;
            this.btnLoadText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLoadText.Name = "btnLoadText";
            this.btnLoadText.Size = new System.Drawing.Size(76, 22);
            this.btnLoadText.Text = "加载Text";
            this.btnLoadText.Click += new System.EventHandler(this.btnLoadText_Click);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::SPSUtil.Properties.Resources.page_edit;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(100, 22);
            this.toolStripButton3.Text = "数据加载配置";
            // 
            // ssBottom
            // 
            this.ssBottom.Location = new System.Drawing.Point(0, 691);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(880, 22);
            this.ssBottom.TabIndex = 9;
            this.ssBottom.Text = "statusStrip1";
            // 
            // opfLoadExcel
            // 
            this.opfLoadExcel.Filter = "Excel 97-2003 File|*.xls";
            // 
            // sfdSendText
            // 
            this.sfdSendText.Filter = "文本文件|*.txt";
            // 
            // opfLoadText
            // 
            this.opfLoadText.Filter = "CSV 文件|*.csv|文本文件|*.txt";
            // 
            // frmDataSendTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 713);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.ssBottom);
            this.Name = "frmDataSendTask";
            this.Text = "批量发送数据";
            this.Load += new System.EventHandler(this.frmDataSendTask_Load);
            this.Shown += new System.EventHandler(this.frmDataSendTask_Shown);
            this.pnlMain.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbDataSendType.ResumeLayout(false);
            this.gbDataSendType.PerformLayout();
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton btnLoadExcel;
        private System.Windows.Forms.ToolStripButton btnLoadText;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSendData;
        private System.Windows.Forms.Button btnGenerateTestData;
        private System.Windows.Forms.OpenFileDialog opfLoadExcel;
        private System.Windows.Forms.Button btnSaveSendText;
        private System.Windows.Forms.SaveFileDialog sfdSendText;
        private System.Windows.Forms.OpenFileDialog opfLoadText;
        private UCSendParams ucSendParams1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbChannelList;
        private System.Windows.Forms.GroupBox gbDataSendType;
        private System.Windows.Forms.RadioButton rbTestDataSend;
        private System.Windows.Forms.RadioButton rbLoadDataSend;
        private UCChannelParams ucChannelParams1;
    }
}