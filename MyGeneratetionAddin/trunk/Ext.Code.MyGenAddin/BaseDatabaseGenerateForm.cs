using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MyMeta;
using Zeus;

namespace Legendigital.Code.MyGenAddin
{
    public abstract class BaseDatabaseGenerateForm<T> : Form
    {
        protected T config;
        protected dbRoot myMeta;
        protected IZeusInput zeusInput;
        protected List<string> selectTables = new List<string>();
        protected List<string> selectViews = new List<string>();
        protected OpenFileDialog openFileDialogConfig;
        protected SaveFileDialog saveFileDialogConfig;
        protected List<string> selectProceduces = new List<string>();


        public abstract T DefaultConfig { get; }
        public abstract string ConfigKey { get; }

        protected abstract List<string> GetDefaultSelectTables();
        protected abstract List<string> GetDefaultSelectViews();
        protected abstract List<string> GetDefaultSelectProceduces();
        protected abstract string GetDefaultDataBaseName();

 


        protected void InitForm(dbRoot myMeta, IZeusInput input)
        {
            this.myMeta = myMeta;
            this.zeusInput = input;
            InitializeComponent();
            this.GetSetting();
        }

        protected void SaveSetting()
        {
            SerializableHelper.BinarySerializeObject<T>(ConfigKey, config);
        }

        protected void GetSetting()
        {
            config = SerializableHelper.BinaryDeserializeObject<T>(ConfigKey, DefaultConfig);
        }

        private string GetCurrentObjectName()
        {
            if (this.tabMain.SelectedIndex == 0)
            {
                return "表";
            }
            if (this.tabMain.SelectedIndex == 1)
            {
                return "视图";
            }
            if (this.tabMain.SelectedIndex == 2)
            {
                return "存储过程";
            }
            return "表";
        }

        private void SelectCustomerTables()
        {
            for (int i = 0; i < this.checkedListBoxSelectTables.Items.Count; i++)
            {
                string itemText = this.checkedListBoxSelectTables.GetItemText(this.checkedListBoxSelectTables.Items[i]).Trim().ToUpper();
                this.checkedListBoxSelectTables.SetItemChecked(i, selectTables.Contains(itemText));
            }
        }

        private void SelectCustomerViews()
        {
            for (int i = 0; i < this.checkedListBoxSelectViews.Items.Count; i++)
            {
                string itemText = this.checkedListBoxSelectViews.GetItemText(this.checkedListBoxSelectViews.Items[i]).Trim().ToUpper();
                this.checkedListBoxSelectViews.SetItemChecked(i, selectViews.Contains(itemText));
            }
        }


        private void SelectCustomerProceduces()
        {
            for (int i = 0; i < this.checkedListBoxSelectProcedures.Items.Count; i++)
            {
                string itemText = this.checkedListBoxSelectProcedures.GetItemText(this.checkedListBoxSelectProcedures.Items[i]).Trim().ToUpper();
                this.checkedListBoxSelectProcedures.SetItemChecked(i, selectProceduces.Contains(itemText));
            }
        }



        #region code generate
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
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.groupBoxCodeGeneration = new System.Windows.Forms.GroupBox();
            this.lblFilterDbObjectName = new System.Windows.Forms.Label();
            this.txtFilterDbObjectName = new System.Windows.Forms.TextBox();
            this.lblSelectDbObject = new System.Windows.Forms.Label();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.grpObjectSelector = new System.Windows.Forms.GroupBox();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabPageTables = new System.Windows.Forms.TabPage();
            this.checkedListBoxSelectTables = new System.Windows.Forms.CheckedListBox();
            this.tabPageViews = new System.Windows.Forms.TabPage();
            this.checkedListBoxSelectViews = new System.Windows.Forms.CheckedListBox();
            this.tabPageProcedures = new System.Windows.Forms.TabPage();
            this.checkedListBoxSelectProcedures = new System.Windows.Forms.CheckedListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnGenarateCode = new System.Windows.Forms.Button();
            this.lblSelectDataBase = new System.Windows.Forms.Label();
            this.cmbSelectDataBase = new System.Windows.Forms.ComboBox();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSaveCodeGenerateConifg = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoadConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonConfigMygeneration = new System.Windows.Forms.ToolStripButton();
            this.propertyGridSetting = new System.Windows.Forms.PropertyGrid();
            this.lblConfigDescription = new System.Windows.Forms.Label();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialogConfig = new System.Windows.Forms.SaveFileDialog();
            this.tbcMain.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.groupBoxCodeGeneration.SuspendLayout();
            this.grpObjectSelector.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabPageTables.SuspendLayout();
            this.tabPageViews.SuspendLayout();
            this.tabPageProcedures.SuspendLayout();
            this.tabPageConfig.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStripTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabPageData);
            this.tbcMain.Controls.Add(this.tabPageConfig);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(901, 587);
            this.tbcMain.TabIndex = 5;
            this.tbcMain.TabStop = false;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.groupBoxCodeGeneration);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(893, 561);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "批量代码生成";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // groupBoxCodeGeneration
            // 
            this.groupBoxCodeGeneration.Controls.Add(this.lblFilterDbObjectName);
            this.groupBoxCodeGeneration.Controls.Add(this.txtFilterDbObjectName);
            this.groupBoxCodeGeneration.Controls.Add(this.lblSelectDbObject);
            this.groupBoxCodeGeneration.Controls.Add(this.chkSelectAll);
            this.groupBoxCodeGeneration.Controls.Add(this.grpObjectSelector);
            this.groupBoxCodeGeneration.Controls.Add(this.btnRefresh);
            this.groupBoxCodeGeneration.Controls.Add(this.btnGenarateCode);
            this.groupBoxCodeGeneration.Controls.Add(this.lblSelectDataBase);
            this.groupBoxCodeGeneration.Controls.Add(this.cmbSelectDataBase);
            this.groupBoxCodeGeneration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCodeGeneration.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCodeGeneration.Name = "groupBoxCodeGeneration";
            this.groupBoxCodeGeneration.Size = new System.Drawing.Size(887, 555);
            this.groupBoxCodeGeneration.TabIndex = 6;
            this.groupBoxCodeGeneration.TabStop = false;
            this.groupBoxCodeGeneration.Text = "代码生成";
            // 
            // lblFilterDbObjectName
            // 
            this.lblFilterDbObjectName.AutoSize = true;
            this.lblFilterDbObjectName.Location = new System.Drawing.Point(95, 72);
            this.lblFilterDbObjectName.Name = "lblFilterDbObjectName";
            this.lblFilterDbObjectName.Size = new System.Drawing.Size(147, 13);
            this.lblFilterDbObjectName.TabIndex = 15;
            this.lblFilterDbObjectName.Text = "过滤指定前缀的{$DbObj}：";
            // 
            // txtFilterDbObjectName
            // 
            this.txtFilterDbObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterDbObjectName.Location = new System.Drawing.Point(266, 69);
            this.txtFilterDbObjectName.Name = "txtFilterDbObjectName";
            this.txtFilterDbObjectName.Size = new System.Drawing.Size(604, 20);
            this.txtFilterDbObjectName.TabIndex = 14;
            this.txtFilterDbObjectName.Text = "sys|aspnet_";
            // 
            // lblSelectDbObject
            // 
            this.lblSelectDbObject.AutoSize = true;
            this.lblSelectDbObject.Location = new System.Drawing.Point(15, 72);
            this.lblSelectDbObject.Name = "lblSelectDbObject";
            this.lblSelectDbObject.Size = new System.Drawing.Size(87, 13);
            this.lblSelectDbObject.TabIndex = 13;
            this.lblSelectDbObject.Text = "选择{$DbObj}：";
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(21, 527);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(130, 17);
            this.chkSelectAll.TabIndex = 12;
            this.chkSelectAll.Text = "选中所有的{$DbObj}";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // grpObjectSelector
            // 
            this.grpObjectSelector.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpObjectSelector.Controls.Add(this.tabMain);
            this.grpObjectSelector.Location = new System.Drawing.Point(18, 95);
            this.grpObjectSelector.Name = "grpObjectSelector";
            this.grpObjectSelector.Size = new System.Drawing.Size(852, 421);
            this.grpObjectSelector.TabIndex = 11;
            this.grpObjectSelector.TabStop = false;
            this.grpObjectSelector.Text = "数据库对象选择";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabPageTables);
            this.tabMain.Controls.Add(this.tabPageViews);
            this.tabMain.Controls.Add(this.tabPageProcedures);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(3, 16);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(846, 402);
            this.tabMain.TabIndex = 0;
            this.tabMain.SelectedIndexChanged += new System.EventHandler(this.tabMain_SelectedIndexChanged);
            this.tabMain.TabIndexChanged += new System.EventHandler(this.tabMain_TabIndexChanged);
            // 
            // tabPageTables
            // 
            this.tabPageTables.Controls.Add(this.checkedListBoxSelectTables);
            this.tabPageTables.Location = new System.Drawing.Point(4, 22);
            this.tabPageTables.Name = "tabPageTables";
            this.tabPageTables.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTables.Size = new System.Drawing.Size(838, 376);
            this.tabPageTables.TabIndex = 0;
            this.tabPageTables.Text = "表";
            this.tabPageTables.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxSelectTables
            // 
            this.checkedListBoxSelectTables.CheckOnClick = true;
            this.checkedListBoxSelectTables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxSelectTables.FormattingEnabled = true;
            this.checkedListBoxSelectTables.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxSelectTables.Name = "checkedListBoxSelectTables";
            this.checkedListBoxSelectTables.Size = new System.Drawing.Size(832, 370);
            this.checkedListBoxSelectTables.TabIndex = 9;
            // 
            // tabPageViews
            // 
            this.tabPageViews.Controls.Add(this.checkedListBoxSelectViews);
            this.tabPageViews.Location = new System.Drawing.Point(4, 22);
            this.tabPageViews.Name = "tabPageViews";
            this.tabPageViews.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageViews.Size = new System.Drawing.Size(838, 376);
            this.tabPageViews.TabIndex = 1;
            this.tabPageViews.Text = "视图";
            this.tabPageViews.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxSelectViews
            // 
            this.checkedListBoxSelectViews.CheckOnClick = true;
            this.checkedListBoxSelectViews.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxSelectViews.FormattingEnabled = true;
            this.checkedListBoxSelectViews.Location = new System.Drawing.Point(3, 3);
            this.checkedListBoxSelectViews.Name = "checkedListBoxSelectViews";
            this.checkedListBoxSelectViews.Size = new System.Drawing.Size(832, 370);
            this.checkedListBoxSelectViews.TabIndex = 10;
            // 
            // tabPageProcedures
            // 
            this.tabPageProcedures.Controls.Add(this.checkedListBoxSelectProcedures);
            this.tabPageProcedures.Location = new System.Drawing.Point(4, 22);
            this.tabPageProcedures.Name = "tabPageProcedures";
            this.tabPageProcedures.Size = new System.Drawing.Size(838, 376);
            this.tabPageProcedures.TabIndex = 2;
            this.tabPageProcedures.Text = "存储过程";
            this.tabPageProcedures.UseVisualStyleBackColor = true;
            // 
            // checkedListBoxSelectProcedures
            // 
            this.checkedListBoxSelectProcedures.CheckOnClick = true;
            this.checkedListBoxSelectProcedures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkedListBoxSelectProcedures.FormattingEnabled = true;
            this.checkedListBoxSelectProcedures.Location = new System.Drawing.Point(0, 0);
            this.checkedListBoxSelectProcedures.Name = "checkedListBoxSelectProcedures";
            this.checkedListBoxSelectProcedures.Size = new System.Drawing.Size(838, 376);
            this.checkedListBoxSelectProcedures.TabIndex = 10;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(809, 33);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 25);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnGenarateCode
            // 
            this.btnGenarateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenarateCode.Location = new System.Drawing.Point(776, 522);
            this.btnGenarateCode.Name = "btnGenarateCode";
            this.btnGenarateCode.Size = new System.Drawing.Size(94, 25);
            this.btnGenarateCode.TabIndex = 6;
            this.btnGenarateCode.Text = "代码生成";
            this.btnGenarateCode.UseVisualStyleBackColor = true;
            this.btnGenarateCode.Click += new System.EventHandler(this.btnGenarateCode_Click);
            // 
            // lblSelectDataBase
            // 
            this.lblSelectDataBase.AutoSize = true;
            this.lblSelectDataBase.Location = new System.Drawing.Point(15, 36);
            this.lblSelectDataBase.Name = "lblSelectDataBase";
            this.lblSelectDataBase.Size = new System.Drawing.Size(79, 13);
            this.lblSelectDataBase.TabIndex = 0;
            this.lblSelectDataBase.Text = "选择数据库：";
            // 
            // cmbSelectDataBase
            // 
            this.cmbSelectDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelectDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectDataBase.FormattingEnabled = true;
            this.cmbSelectDataBase.Location = new System.Drawing.Point(98, 33);
            this.cmbSelectDataBase.Name = "cmbSelectDataBase";
            this.cmbSelectDataBase.Size = new System.Drawing.Size(696, 21);
            this.cmbSelectDataBase.TabIndex = 1;
            this.cmbSelectDataBase.SelectedIndexChanged += new System.EventHandler(this.cmbSelectDataBase_SelectedIndexChanged);
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.tableLayoutPanel1);
            this.tabPageConfig.Controls.Add(this.lblConfigDescription);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(893, 561);
            this.tabPageConfig.TabIndex = 1;
            this.tabPageConfig.Text = "配置管理";
            this.tabPageConfig.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.toolStripTop, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyGridSetting, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(887, 555);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // toolStripTop
            // 
            this.toolStripTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSaveCodeGenerateConifg,
            this.toolStripButtonSaveAs,
            this.toolStripButtonLoadConfig,
            this.toolStripButtonConfigMygeneration});
            this.toolStripTop.Location = new System.Drawing.Point(0, 0);
            this.toolStripTop.Name = "toolStripTop";
            this.toolStripTop.Size = new System.Drawing.Size(887, 27);
            this.toolStripTop.TabIndex = 4;
            this.toolStripTop.Text = "toolStrip1";
            this.toolStripTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripTop_ItemClicked);
            // 
            // toolStripButtonSaveCodeGenerateConifg
            // 
            this.toolStripButtonSaveCodeGenerateConifg.Image = global::Legendigital.Code.MyGenAddin.WinResource.Save;
            this.toolStripButtonSaveCodeGenerateConifg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveCodeGenerateConifg.Name = "toolStripButtonSaveCodeGenerateConifg";
            this.toolStripButtonSaveCodeGenerateConifg.Size = new System.Drawing.Size(111, 24);
            this.toolStripButtonSaveCodeGenerateConifg.Text = "保存为默认配置";
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.Image = global::Legendigital.Code.MyGenAddin.WinResource.Save;
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(87, 24);
            this.toolStripButtonSaveAs.Text = "配置另存为";
            // 
            // toolStripButtonLoadConfig
            // 
            this.toolStripButtonLoadConfig.Image = global::Legendigital.Code.MyGenAddin.WinResource.open;
            this.toolStripButtonLoadConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadConfig.Name = "toolStripButtonLoadConfig";
            this.toolStripButtonLoadConfig.Size = new System.Drawing.Size(75, 24);
            this.toolStripButtonLoadConfig.Text = "加载配置";
            // 
            // toolStripButtonConfigMygeneration
            // 
            this.toolStripButtonConfigMygeneration.Image = global::Legendigital.Code.MyGenAddin.WinResource.setting;
            this.toolStripButtonConfigMygeneration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConfigMygeneration.Name = "toolStripButtonConfigMygeneration";
            this.toolStripButtonConfigMygeneration.Size = new System.Drawing.Size(118, 24);
            this.toolStripButtonConfigMygeneration.Text = "配置MyGeneration";
            // 
            // propertyGridSetting
            // 
            this.propertyGridSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridSetting.Location = new System.Drawing.Point(3, 30);
            this.propertyGridSetting.Name = "propertyGridSetting";
            this.propertyGridSetting.Size = new System.Drawing.Size(881, 522);
            this.propertyGridSetting.TabIndex = 1;
            // 
            // lblConfigDescription
            // 
            this.lblConfigDescription.AutoSize = true;
            this.lblConfigDescription.Location = new System.Drawing.Point(8, 367);
            this.lblConfigDescription.Name = "lblConfigDescription";
            this.lblConfigDescription.Size = new System.Drawing.Size(0, 13);
            this.lblConfigDescription.TabIndex = 3;
            // 
            // openFileDialogConfig
            // 
            this.openFileDialogConfig.DefaultExt = "dat";
            this.openFileDialogConfig.Filter = "代码生成配置文件 (*.dat)|*.dat";
            // 
            // saveFileDialogConfig
            // 
            this.saveFileDialogConfig.DefaultExt = "dat";
            this.saveFileDialogConfig.Filter = "代码生成配置文件 (*.dat)|*.dat";
            // 
            // BaseDatabaseGenerateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(901, 587);
            this.Controls.Add(this.tbcMain);
            this.Name = "BaseDatabaseGenerateForm";
            this.Text = "BaseDatabaseGenerateForm";
            this.Load += new System.EventHandler(this.BaseDatabaseGenerateForm_Load);
            this.tbcMain.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.groupBoxCodeGeneration.ResumeLayout(false);
            this.groupBoxCodeGeneration.PerformLayout();
            this.grpObjectSelector.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabPageTables.ResumeLayout(false);
            this.tabPageViews.ResumeLayout(false);
            this.tabPageProcedures.ResumeLayout(false);
            this.tabPageConfig.ResumeLayout(false);
            this.tabPageConfig.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStripTop.ResumeLayout(false);
            this.toolStripTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.TabControl tbcMain;
        protected System.Windows.Forms.TabPage tabPageData;
        protected System.Windows.Forms.GroupBox groupBoxCodeGeneration;
        protected System.Windows.Forms.Button btnRefresh;
        protected System.Windows.Forms.Button btnGenarateCode;
        protected System.Windows.Forms.Label lblSelectDataBase;
        protected System.Windows.Forms.ComboBox cmbSelectDataBase;
        protected System.Windows.Forms.TabPage tabPageConfig;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.ToolStrip toolStripTop;
        protected System.Windows.Forms.ToolStripButton toolStripButtonSaveCodeGenerateConifg;
        protected System.Windows.Forms.ToolStripButton toolStripButtonSaveAs;
        protected System.Windows.Forms.ToolStripButton toolStripButtonLoadConfig;
        protected System.Windows.Forms.ToolStripButton toolStripButtonConfigMygeneration;
        protected System.Windows.Forms.PropertyGrid propertyGridSetting;
        protected System.Windows.Forms.Label lblConfigDescription;
        private System.Windows.Forms.GroupBox grpObjectSelector;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabPageTables;
        private System.Windows.Forms.TabPage tabPageViews;
        private System.Windows.Forms.TabPage tabPageProcedures;
        protected System.Windows.Forms.CheckBox chkSelectAll;
        protected System.Windows.Forms.Label lblFilterDbObjectName;
        protected System.Windows.Forms.TextBox txtFilterDbObjectName;
        protected System.Windows.Forms.Label lblSelectDbObject;
        protected System.Windows.Forms.CheckedListBox checkedListBoxSelectTables;
        protected System.Windows.Forms.CheckedListBox checkedListBoxSelectViews;
        protected System.Windows.Forms.CheckedListBox checkedListBoxSelectProcedures;
        #endregion

        private void cmbSelectDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDatabase database = this.cmbSelectDataBase.SelectedValue as IDatabase;

            List<ITable> tables = CodeGenerateUIHelper.GetFilterObjectFormDataBase<ITable>(database,
                                                                                  this.txtFilterDbObjectName.Text.Trim());
            if (tables != null)
            {
                this.checkedListBoxSelectTables.DataSource = tables;
                this.checkedListBoxSelectTables.DisplayMember = "Name";
            }

            List<IView> views = CodeGenerateUIHelper.GetFilterObjectFormDataBase<IView>(database,
                                                                      this.txtFilterDbObjectName.Text.Trim());
            if (views != null)
            {
                this.checkedListBoxSelectViews.DataSource = views;
                this.checkedListBoxSelectViews.DisplayMember = "Name";
            }


            List<IProcedure> procedures = CodeGenerateUIHelper.GetFilterObjectFormDataBase<IProcedure>(database,
                                                                      this.txtFilterDbObjectName.Text.Trim());
            if (procedures != null)
            {
                this.checkedListBoxSelectProcedures.DataSource = procedures;
                this.checkedListBoxSelectProcedures.DisplayMember = "Name";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            DefaultSettings defaultSettings = new DefaultSettings();
            this.myMeta.Connect(defaultSettings.DbDriver, defaultSettings.ConnectionString);

            GetSetting();

            this.propertyGridSetting.SelectedObject = config;

            CodeGenerateUIHelper.BindDataBaseToComboBox(this.myMeta, this.cmbSelectDataBase);
        }

        private void FormatLableDbObjectName()
        {
            CodeGenerateUIHelper.FormatLableDbObjectName(this.lblFilterDbObjectName, GetCurrentObjectName());
            CodeGenerateUIHelper.FormatLableDbObjectName(this.chkSelectAll, GetCurrentObjectName());
            CodeGenerateUIHelper.FormatLableDbObjectName(this.lblSelectDbObject, GetCurrentObjectName());
        }

        private void BaseDatabaseGenerateForm_Load(object sender, EventArgs e)
        {
            config = this.DefaultConfig;

            GetSetting();

            this.propertyGridSetting.SelectedObject = config;

            CodeGenerateUIHelper.BindDataBaseToComboBox(this.myMeta, this.cmbSelectDataBase);

            if (!string.IsNullOrEmpty(this.GetDefaultDataBaseName()))
            {
                cmbSelectDataBase.SelectedIndex =
                    cmbSelectDataBase.FindStringExact(this.GetDefaultDataBaseName());
            }

            //MessageBox.Show(GetDefaultSelectObject().Count.ToString());
            if (GetDefaultSelectTables() != null && GetDefaultSelectTables().Count > 0)
            {
                selectTables = GetDefaultSelectTables();
                SelectCustomerTables();
            }

            if (GetDefaultSelectViews() != null && GetDefaultSelectViews().Count > 0)
            {
                selectViews = GetDefaultSelectViews();
                SelectCustomerViews();
            }

            if (GetDefaultSelectProceduces() != null && GetDefaultSelectProceduces().Count > 0)
            {
                selectProceduces = GetDefaultSelectProceduces();
                SelectCustomerProceduces();
            }
        }

        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FormatLableDbObjectName();
        }

        private void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            if (this.tabMain.SelectedIndex == 0)
            {
                for (int i = 0; i < this.checkedListBoxSelectTables.Items.Count; i++)
                {
                    this.checkedListBoxSelectTables.SetItemChecked(i, chkSelectAll.Checked);
                }
            }
            if (this.tabMain.SelectedIndex == 1)
            {
                for (int i = 0; i < this.checkedListBoxSelectViews.Items.Count; i++)
                {
                    this.checkedListBoxSelectViews.SetItemChecked(i, chkSelectAll.Checked);
                }
            }
            if (this.tabMain.SelectedIndex == 2)
            {
                for (int i = 0; i < this.checkedListBoxSelectProcedures.Items.Count; i++)
                {
                    this.checkedListBoxSelectProcedures.SetItemChecked(i, chkSelectAll.Checked);
                }
            }

        }

        private void toolStripTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "toolStripButtonSaveCodeGenerateConifg")
            {
                try
                {
                    SaveSetting();
                    MessageBox.Show("设置保存成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("设置保存失败：" + ex.Message);
                }
            }
            else if (e.ClickedItem.Name == "toolStripButtonConfigMygeneration")
            {
                DefaultProperties defaultProperties = new DefaultProperties();
                defaultProperties.ShowDialog();
            }
            else if (e.ClickedItem.Name == "toolStripButtonSaveAs")
            {
                if (this.saveFileDialogConfig.ShowDialog() == DialogResult.OK)
                {
                    SerializableHelper.BinarySerializeObjectByPath<T>(this.saveFileDialogConfig.FileName,
                                                                      this.config);
                }
            }
            else if (e.ClickedItem.Name == "toolStripButtonLoadConfig")
            {
                if (this.openFileDialogConfig.ShowDialog() == DialogResult.OK)
                {
                    this.config = SerializableHelper.BinaryDeserializeObjectByPath(this.openFileDialogConfig.FileName,
                                                                                   this.DefaultConfig);
                    this.propertyGridSetting.SelectedObject = config;
                }
            }
        }

        private void btnGenarateCode_Click(object sender, EventArgs e)
        {
            if ((cmbSelectDataBase.SelectedIndex >= 0) && (this.checkedListBoxSelectTables.SelectedIndex >= 0 || this.checkedListBoxSelectViews.SelectedIndex >= 0 || this.checkedListBoxSelectProcedures.SelectedIndex >= 0))
            {
                IDatabase database = this.cmbSelectDataBase.SelectedValue as IDatabase;
                List<ITable> selectTables = CodeGenerateUIHelper.GetAllSelectTable<ITable>(this.checkedListBoxSelectTables);
                List<IView> selectViews = CodeGenerateUIHelper.GetAllSelectTable<IView>(this.checkedListBoxSelectViews);
                List<IProcedure> selectProcedures = CodeGenerateUIHelper.GetAllSelectTable<IProcedure>(this.checkedListBoxSelectProcedures);

                this.zeusInput["databaseName"] = database.Name;

                this.zeusInput["selectTables"] = selectTables.ToArray();
                this.zeusInput["selectViews"] = selectViews.ToArray();
                this.zeusInput["selectProcedures"] = selectProcedures.ToArray();
                this.zeusInput["codeGenerationSetting"] = config;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择一个表、视图或者存储过程");
            }
        }

        private void tabMain_TabIndexChanged(object sender, EventArgs e)
        {
            FormatLableDbObjectName();
        }
    }
}
