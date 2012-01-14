namespace SPSUtil
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
            WeifenLuo.WinFormsUI.Docking.DockPanelSkin dockPanelSkin7 = new WeifenLuo.WinFormsUI.Docking.DockPanelSkin();
            WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin autoHideStripSkin7 = new WeifenLuo.WinFormsUI.Docking.AutoHideStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient19 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient43 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin dockPaneStripSkin7 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripSkin();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient dockPaneStripGradient7 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient44 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient20 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient45 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient dockPaneStripToolWindowGradient7 = new WeifenLuo.WinFormsUI.Docking.DockPaneStripToolWindowGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient46 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient47 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.DockPanelGradient dockPanelGradient21 = new WeifenLuo.WinFormsUI.Docking.DockPanelGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient48 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            WeifenLuo.WinFormsUI.Docking.TabGradient tabGradient49 = new WeifenLuo.WinFormsUI.Docking.TabGradient();
            this.msTop = new System.Windows.Forms.MenuStrip();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tsTop = new System.Windows.Forms.ToolStrip();
            this.tsbNewHttpRequest = new System.Windows.Forms.ToolStripButton();
            this.dpnlMain = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.msTop.SuspendLayout();
            this.tsTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // msTop
            // 
            this.msTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msTop.Location = new System.Drawing.Point(0, 0);
            this.msTop.Name = "msTop";
            this.msTop.Size = new System.Drawing.Size(890, 25);
            this.msTop.TabIndex = 0;
            this.msTop.Text = "menuStrip1";
            // 
            // ssBottom
            // 
            this.ssBottom.Location = new System.Drawing.Point(0, 453);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Size = new System.Drawing.Size(890, 22);
            this.ssBottom.TabIndex = 1;
            this.ssBottom.Text = "statusStrip1";
            // 
            // tsTop
            // 
            this.tsTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewHttpRequest});
            this.tsTop.Location = new System.Drawing.Point(0, 25);
            this.tsTop.Name = "tsTop";
            this.tsTop.Size = new System.Drawing.Size(890, 25);
            this.tsTop.TabIndex = 2;
            this.tsTop.Text = "toolStrip1";
            this.tsTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsTop_ItemClicked);
            // 
            // tsbNewHttpRequest
            // 
            this.tsbNewHttpRequest.Image = global::SPSUtil.Properties.Resources.link;
            this.tsbNewHttpRequest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbNewHttpRequest.Name = "tsbNewHttpRequest";
            this.tsbNewHttpRequest.Size = new System.Drawing.Size(100, 22);
            this.tsbNewHttpRequest.Text = "请求测试管理";
            // 
            // dpnlMain
            // 
            this.dpnlMain.ActiveAutoHideContent = null;
            this.dpnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dpnlMain.DockBackColor = System.Drawing.SystemColors.Control;
            this.dpnlMain.Location = new System.Drawing.Point(0, 50);
            this.dpnlMain.Name = "dpnlMain";
            this.dpnlMain.Size = new System.Drawing.Size(890, 403);
            dockPanelGradient19.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient19.StartColor = System.Drawing.SystemColors.ControlLight;
            autoHideStripSkin7.DockStripGradient = dockPanelGradient19;
            tabGradient43.EndColor = System.Drawing.SystemColors.Control;
            tabGradient43.StartColor = System.Drawing.SystemColors.Control;
            tabGradient43.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            autoHideStripSkin7.TabGradient = tabGradient43;
            autoHideStripSkin7.TextFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            dockPanelSkin7.AutoHideStripSkin = autoHideStripSkin7;
            tabGradient44.EndColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient44.StartColor = System.Drawing.SystemColors.ControlLightLight;
            tabGradient44.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient7.ActiveTabGradient = tabGradient44;
            dockPanelGradient20.EndColor = System.Drawing.SystemColors.Control;
            dockPanelGradient20.StartColor = System.Drawing.SystemColors.Control;
            dockPaneStripGradient7.DockStripGradient = dockPanelGradient20;
            tabGradient45.EndColor = System.Drawing.SystemColors.ControlLight;
            tabGradient45.StartColor = System.Drawing.SystemColors.ControlLight;
            tabGradient45.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripGradient7.InactiveTabGradient = tabGradient45;
            dockPaneStripSkin7.DocumentGradient = dockPaneStripGradient7;
            dockPaneStripSkin7.TextFont = new System.Drawing.Font("Microsoft YaHei", 9F);
            tabGradient46.EndColor = System.Drawing.SystemColors.ActiveCaption;
            tabGradient46.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient46.StartColor = System.Drawing.SystemColors.GradientActiveCaption;
            tabGradient46.TextColor = System.Drawing.SystemColors.ActiveCaptionText;
            dockPaneStripToolWindowGradient7.ActiveCaptionGradient = tabGradient46;
            tabGradient47.EndColor = System.Drawing.SystemColors.Control;
            tabGradient47.StartColor = System.Drawing.SystemColors.Control;
            tabGradient47.TextColor = System.Drawing.SystemColors.ControlText;
            dockPaneStripToolWindowGradient7.ActiveTabGradient = tabGradient47;
            dockPanelGradient21.EndColor = System.Drawing.SystemColors.ControlLight;
            dockPanelGradient21.StartColor = System.Drawing.SystemColors.ControlLight;
            dockPaneStripToolWindowGradient7.DockStripGradient = dockPanelGradient21;
            tabGradient48.EndColor = System.Drawing.SystemColors.InactiveCaption;
            tabGradient48.LinearGradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            tabGradient48.StartColor = System.Drawing.SystemColors.GradientInactiveCaption;
            tabGradient48.TextColor = System.Drawing.SystemColors.InactiveCaptionText;
            dockPaneStripToolWindowGradient7.InactiveCaptionGradient = tabGradient48;
            tabGradient49.EndColor = System.Drawing.Color.Transparent;
            tabGradient49.StartColor = System.Drawing.Color.Transparent;
            tabGradient49.TextColor = System.Drawing.SystemColors.ControlDarkDark;
            dockPaneStripToolWindowGradient7.InactiveTabGradient = tabGradient49;
            dockPaneStripSkin7.ToolWindowGradient = dockPaneStripToolWindowGradient7;
            dockPanelSkin7.DockPaneStripSkin = dockPaneStripSkin7;
            this.dpnlMain.Skin = dockPanelSkin7;
            this.dpnlMain.TabIndex = 5;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.fileToolStripMenuItem.Text = "文件";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "退出";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.toolStripMenuItem2});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.helpToolStripMenuItem.Text = "帮助";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewToolStripMenuItem.Text = "查看帮助";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(196, 22);
            this.toolStripMenuItem2.Text = "关于短信平台处理工具";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 475);
            this.Controls.Add(this.dpnlMain);
            this.Controls.Add(this.tsTop);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.msTop);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msTop;
            this.Name = "MainForm";
            this.Text = "短信平台处理工具";
            this.msTop.ResumeLayout(false);
            this.msTop.PerformLayout();
            this.tsTop.ResumeLayout(false);
            this.tsTop.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msTop;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.ToolStrip tsTop;
        private System.Windows.Forms.ToolStripButton tsbNewHttpRequest;
        private WeifenLuo.WinFormsUI.Docking.DockPanel dpnlMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}