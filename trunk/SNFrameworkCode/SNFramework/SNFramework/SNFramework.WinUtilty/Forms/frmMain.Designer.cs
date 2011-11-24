namespace SNFramework.WinUtilty.Forms
{
    partial class frmMain
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin4 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin4 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient10 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient22 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin4 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient4 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient23 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient11 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient24 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient4 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient25 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient26 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient12 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient27 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient28 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.msTop = new System.Windows.Forms.MenuStrip();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tvLeft = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dockPanel1 = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.tsTop.SuspendLayout();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // msTop
            // 
            this.msTop.Location = new System.Drawing.Point(0, 0);
            this.msTop.Name = "msTop";
            this.msTop.Size = new System.Drawing.Size(1051, 24);
            this.msTop.TabIndex = 0;
            this.msTop.Text = "menuStrip1";
            // 
            // ssBottom
            // 
            this.ssBottom.Location = new System.Drawing.Point(0, 429);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(1051, 22);
            this.ssBottom.TabIndex = 1;
            this.ssBottom.Text = "statusStrip1";
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1});
            this.tsTop.Location = new System.Drawing.Point(0, 24);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(1051, 25);
            this.tsTop.TabIndex = 2;
            this.tsTop.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::SNFramework.WinUtilty.Properties.Resources.telephone_go;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(124, 22);
            this.toolStripButton1.Text = "导入电话号码区段";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.Location = new System.Drawing.Point(0, 49);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.Controls.Add(this.panel1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.panel2);
            this.scMain.Size = new System.Drawing.Size(1051, 380);
            this.scMain.SplitterDistance = 220;
            this.scMain.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.toolStrip2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(220, 380);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.tvLeft);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 25);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(220, 355);
            this.panel3.TabIndex = 1;
            // 
            // tvLeft
            // 
            this.tvLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvLeft.Location = new System.Drawing.Point(0, 0);
            this.tvLeft.Name = "tvLeft";
            this.tvLeft.Size = new System.Drawing.Size(220, 355);
            this.tvLeft.TabIndex = 0;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(220, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dockPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(827, 380);
            this.panel2.TabIndex = 0;
            // 
            // dockPanel1
            // 
            this.dockPanel1.ActiveAutoHideContent = null;
            this.dockPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dockPanel1.DockBackColor = System.Drawing.SystemColors.Control;
            this.dockPanel1.Location = new System.Drawing.Point(0, 0);
            this.dockPanel1.Name = "dockPanel1";
            this.dockPanel1.Size = new System.Drawing.Size(827, 380);
            dockPanelGradient10.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient10.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin4.DockStripGradient = dockPanelGradient10;
            tabGradient22.EndColor = System.Drawing.SystemColors.Control;
            tabGradient22.StartColor = System.Drawing.SystemColors.Control;
            tabGradient22.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin4.TabGradient = tabGradient22;
            autoHideStripSkin4.TextFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            dockPanelSkin4.AutoHideStripSkin = autoHideStripSkin4;
            tabGradient23.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient23.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient23.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient4.ActiveTabGradient = tabGradient23;
            dockPanelGradient11.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient11.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient4.DockStripGradient = dockPanelGradient11;
            tabGradient24.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient24.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient24.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient4.InactiveTabGradient = tabGradient24;
            dockPaneStripSkin4.DocumentGradient = dockPaneStripGradient4;
            dockPaneStripSkin4.TextFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            tabGradient25.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient25.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient25.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient25.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient4.ActiveCaptionGradient = tabGradient25;
            tabGradient26.EndColor = System.Drawing.SystemColors.Control;
            tabGradient26.StartColor = System.Drawing.SystemColors.Control;
            tabGradient26.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient4.ActiveTabGradient = tabGradient26;
            dockPanelGradient12.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient12.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient4.DockStripGradient = dockPanelGradient12;
            tabGradient27.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient27.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient27.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient27.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient4.InactiveCaptionGradient = tabGradient27;
            tabGradient28.EndColor = System.Drawing.Color.Transparent;
            tabGradient28.StartColor = System.Drawing.Color.Transparent;
            tabGradient28.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient4.InactiveTabGradient = tabGradient28;
            dockPaneStripSkin4.ToolWindowGradient = dockPaneStripToolWindowGradient4;
            dockPanelSkin4.DockPaneStripSkin = dockPaneStripSkin4;
            this.dockPanel1.Skin = dockPanelSkin4;
            this.dockPanel1.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 451);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.msTop);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msTop;
            this.Name = "frmMain";
            this.Text = "Main form";
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            this.scMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msTop;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TreeView tvLeft;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.Panel panel2;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dockPanel1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}