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
    public abstract class BaseObjectSelectorForm<T,ObjectType> : Form
    {

        protected T config;
        protected dbRoot myMeta;
        protected IZeusInput zeusInput;
        private Label lblCheckObjectNamePrefix;
        private TextBox txtCheckObjectNamePrefix;
        private Label lblCodeType;
        private ComboBox cmbCodeType;
        protected List<string> selectObject = new List<string>();


        public abstract T DefaultConfig { get; }
        public abstract string ConfigKey { get; }

        protected abstract List<string> GetDefaultSelectObject();
        protected abstract string GetDefaultDataBaseName();
        protected abstract string GetItemName(ObjectType obj);

        protected void InitForm(dbRoot myMeta, IZeusInput input)
        {
            this.myMeta = myMeta;
            this.zeusInput = input;
            InitializeComponent();
            this.GetSetting();
        }

        public void ShowCustomList(Dictionary<string,string> dictionarys,string codeTypeText)
        {
            //Dictionary<string,string> dictionarys1 = new Dictionary<string, string>();

            //dictionarys1.Add("1","ExecuteNoQuery");
            //dictionarys1.Add("2", "ExecuteDataSet");
            //dictionarys1.Add("3", "ExecuteScalar");

            //string codeType = "选择存储过程方法代码类型：";

            this.lblCodeType.Visible = true;
            this.cmbCodeType.Visible = true;

            this.lblCodeType.Text = "";
            this.lblCodeType.Text = codeTypeText;

            this.cmbCodeType.Items.Clear();

            foreach (KeyValuePair<string,string> dictionary in dictionarys)
            {
                this.cmbCodeType.Items.Add(dictionary.Value);
            }

            cmbCodeType.SelectedIndex = 0;


        }

        protected void SaveSetting()
        {
            SerializableHelper.BinarySerializeObject<T>(ConfigKey, config);
        }

        protected void GetSetting()
        {
            config = SerializableHelper.BinaryDeserializeObject<T>(ConfigKey, DefaultConfig);
        }

        private void SelectCustomerObject()
        {
            for (int i = 0; i < this.checkedListBoxSelectDbObject.Items.Count; i++)
            {
                string itemText = this.checkedListBoxSelectDbObject.GetItemText(this.checkedListBoxSelectDbObject.Items[i]).Trim().ToUpper();
                this.checkedListBoxSelectDbObject.SetItemChecked(i, selectObject.Contains(itemText));
            }
        }

        protected void cmbSelectDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            IDatabase database = this.cmbSelectDataBase.SelectedValue as IDatabase;

            List<ObjectType> tables = CodeGenerateUIHelper.GetFilterObjectFormDataBase<ObjectType>(database,
                                                                                  this.txtFilterDbObjectName.Text.Trim());
            if (tables != null)
            {
                this.checkedListBoxSelectDbObject.DataSource = tables;
                this.checkedListBoxSelectDbObject.DisplayMember = "Name";
            }
        }

        protected void chkSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.checkedListBoxSelectDbObject.Items.Count; i++)
            {
                if (chkSelectAll.Checked && !string.IsNullOrEmpty(this.txtCheckObjectNamePrefix.Text.Trim()))
                {
                     if(GetItemName((ObjectType)this.checkedListBoxSelectDbObject.Items[i]).ToLower().StartsWith(this.txtCheckObjectNamePrefix.Text.Trim().ToLower()))
                     {
                         this.checkedListBoxSelectDbObject.SetItemChecked(i, chkSelectAll.Checked);
                     }
                }
                else
                {
                    this.checkedListBoxSelectDbObject.SetItemChecked(i, chkSelectAll.Checked);                  
                }
            }
        }


        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            DefaultSettings defaultSettings = new DefaultSettings();
            this.myMeta.Connect(defaultSettings.DbDriver, defaultSettings.ConnectionString);

            GetSetting();

            this.propertyGridSetting.SelectedObject = config;

            CodeGenerateUIHelper.BindDataBaseToComboBox(this.myMeta, this.cmbSelectDataBase);
        }

        protected void BaseDbObjectSelectorForm_Load(object sender, EventArgs e)
        {
            CodeGenerateUIHelper.FormatLableDbObjectName(this.lblFilterDbObjectName, GetObjectName());
            CodeGenerateUIHelper.FormatLableDbObjectName(this.chkSelectAll, GetObjectName());
            CodeGenerateUIHelper.FormatLableDbObjectName(this.lblSelectDbObject, GetObjectName());

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
            if (GetDefaultSelectObject() != null && GetDefaultSelectObject().Count > 0)
            {
                selectObject = GetDefaultSelectObject();
                SelectCustomerObject();
            }


        }

        private string GetObjectName()
        {
            if (typeof(ObjectType) == typeof(ITable))
            {
                return "表";
            }
            if (typeof(ObjectType) == typeof(IView))
            {
                return "视图";
            }
            if (typeof(ObjectType) == typeof(IProcedure))
            {
                return "存储过程";
            }
            return "表";
        }


        protected void btnGenarateCode_Click(object sender, EventArgs e)
        {
            if ((cmbSelectDataBase.SelectedIndex >= 0) && (this.checkedListBoxSelectDbObject.SelectedIndex >= 0))
            {
                IDatabase database = this.cmbSelectDataBase.SelectedValue as IDatabase;
                List<ObjectType> selectTables = CodeGenerateUIHelper.GetAllSelectTable<ObjectType>(this.checkedListBoxSelectDbObject);

                this.zeusInput["databaseName"] = database.Name;
                this.zeusInput["database"] = database;
                //MessageBox.Show((selectTables==null).ToString());
                this.zeusInput["selectObjects"] = selectTables.ToArray();
                this.zeusInput["codeGenerationSetting"] = config;
                if (cmbCodeType.SelectedItem!=null)
                    this.zeusInput["codeType"] = cmbCodeType.SelectedItem.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("请选择一个表、视图或者存储过程");
            }
        }


        protected void toolStripTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
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
        protected void InitializeComponent()
        {
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabPageData = new System.Windows.Forms.TabPage();
            this.groupBoxCodeGeneration = new System.Windows.Forms.GroupBox();
            this.lblCheckObjectNamePrefix = new System.Windows.Forms.Label();
            this.txtCheckObjectNamePrefix = new System.Windows.Forms.TextBox();
            this.lblFilterDbObjectName = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.chkSelectAll = new System.Windows.Forms.CheckBox();
            this.checkedListBoxSelectDbObject = new System.Windows.Forms.CheckedListBox();
            this.txtFilterDbObjectName = new System.Windows.Forms.TextBox();
            this.btnGenarateCode = new System.Windows.Forms.Button();
            this.lblSelectDataBase = new System.Windows.Forms.Label();
            this.cmbSelectDataBase = new System.Windows.Forms.ComboBox();
            this.lblSelectDbObject = new System.Windows.Forms.Label();
            this.tabPageConfig = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStripTop = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSaveCodeGenerateConifg = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSaveAs = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoadConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonConfigMygeneration = new System.Windows.Forms.ToolStripButton();
            this.propertyGridSetting = new System.Windows.Forms.PropertyGrid();
            this.lblConfigDescription = new System.Windows.Forms.Label();
            this.saveFileDialogConfig = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.lblCodeType = new System.Windows.Forms.Label();
            this.cmbCodeType = new System.Windows.Forms.ComboBox();
            this.tbcMain.SuspendLayout();
            this.tabPageData.SuspendLayout();
            this.groupBoxCodeGeneration.SuspendLayout();
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
            this.tbcMain.Size = new System.Drawing.Size(589, 446);
            this.tbcMain.TabIndex = 4;
            this.tbcMain.TabStop = false;
            // 
            // tabPageData
            // 
            this.tabPageData.Controls.Add(this.groupBoxCodeGeneration);
            this.tabPageData.Location = new System.Drawing.Point(4, 22);
            this.tabPageData.Name = "tabPageData";
            this.tabPageData.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageData.Size = new System.Drawing.Size(581, 420);
            this.tabPageData.TabIndex = 0;
            this.tabPageData.Text = "批量代码生成";
            this.tabPageData.UseVisualStyleBackColor = true;
            // 
            // groupBoxCodeGeneration
            // 
            this.groupBoxCodeGeneration.Controls.Add(this.cmbCodeType);
            this.groupBoxCodeGeneration.Controls.Add(this.lblCodeType);
            this.groupBoxCodeGeneration.Controls.Add(this.lblCheckObjectNamePrefix);
            this.groupBoxCodeGeneration.Controls.Add(this.txtCheckObjectNamePrefix);
            this.groupBoxCodeGeneration.Controls.Add(this.lblFilterDbObjectName);
            this.groupBoxCodeGeneration.Controls.Add(this.btnRefresh);
            this.groupBoxCodeGeneration.Controls.Add(this.chkSelectAll);
            this.groupBoxCodeGeneration.Controls.Add(this.checkedListBoxSelectDbObject);
            this.groupBoxCodeGeneration.Controls.Add(this.txtFilterDbObjectName);
            this.groupBoxCodeGeneration.Controls.Add(this.btnGenarateCode);
            this.groupBoxCodeGeneration.Controls.Add(this.lblSelectDataBase);
            this.groupBoxCodeGeneration.Controls.Add(this.cmbSelectDataBase);
            this.groupBoxCodeGeneration.Controls.Add(this.lblSelectDbObject);
            this.groupBoxCodeGeneration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxCodeGeneration.Location = new System.Drawing.Point(3, 3);
            this.groupBoxCodeGeneration.Name = "groupBoxCodeGeneration";
            this.groupBoxCodeGeneration.Size = new System.Drawing.Size(575, 414);
            this.groupBoxCodeGeneration.TabIndex = 6;
            this.groupBoxCodeGeneration.TabStop = false;
            this.groupBoxCodeGeneration.Text = "代码生成";
            // 
            // lblCheckObjectNamePrefix
            // 
            this.lblCheckObjectNamePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblCheckObjectNamePrefix.AutoSize = true;
            this.lblCheckObjectNamePrefix.Location = new System.Drawing.Point(164, 361);
            this.lblCheckObjectNamePrefix.Name = "lblCheckObjectNamePrefix";
            this.lblCheckObjectNamePrefix.Size = new System.Drawing.Size(113, 12);
            this.lblCheckObjectNamePrefix.TabIndex = 13;
            this.lblCheckObjectNamePrefix.Text = "选中过滤对象前缀：";
            // 
            // txtCheckObjectNamePrefix
            // 
            this.txtCheckObjectNamePrefix.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtCheckObjectNamePrefix.Location = new System.Drawing.Point(283, 357);
            this.txtCheckObjectNamePrefix.Name = "txtCheckObjectNamePrefix";
            this.txtCheckObjectNamePrefix.Size = new System.Drawing.Size(112, 21);
            this.txtCheckObjectNamePrefix.TabIndex = 12;
            // 
            // lblFilterDbObjectName
            // 
            this.lblFilterDbObjectName.AutoSize = true;
            this.lblFilterDbObjectName.Location = new System.Drawing.Point(103, 68);
            this.lblFilterDbObjectName.Name = "lblFilterDbObjectName";
            this.lblFilterDbObjectName.Size = new System.Drawing.Size(149, 12);
            this.lblFilterDbObjectName.TabIndex = 11;
            this.lblFilterDbObjectName.Text = "过滤指定前缀的{$DbObj}：";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.Location = new System.Drawing.Point(497, 30);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(61, 23);
            this.btnRefresh.TabIndex = 10;
            this.btnRefresh.Text = "刷新";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // chkSelectAll
            // 
            this.chkSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSelectAll.AutoSize = true;
            this.chkSelectAll.Location = new System.Drawing.Point(18, 360);
            this.chkSelectAll.Name = "chkSelectAll";
            this.chkSelectAll.Size = new System.Drawing.Size(132, 16);
            this.chkSelectAll.TabIndex = 9;
            this.chkSelectAll.Text = "选中所有的{$DbObj}";
            this.chkSelectAll.UseVisualStyleBackColor = true;
            this.chkSelectAll.CheckedChanged += new System.EventHandler(this.chkSelectAll_CheckedChanged);
            // 
            // checkedListBoxSelectDbObject
            // 
            this.checkedListBoxSelectDbObject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxSelectDbObject.CheckOnClick = true;
            this.checkedListBoxSelectDbObject.FormattingEnabled = true;
            this.checkedListBoxSelectDbObject.Location = new System.Drawing.Point(17, 101);
            this.checkedListBoxSelectDbObject.Name = "checkedListBoxSelectDbObject";
            this.checkedListBoxSelectDbObject.Size = new System.Drawing.Size(541, 244);
            this.checkedListBoxSelectDbObject.TabIndex = 8;
            // 
            // txtFilterDbObjectName
            // 
            this.txtFilterDbObjectName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilterDbObjectName.Location = new System.Drawing.Point(256, 66);
            this.txtFilterDbObjectName.Name = "txtFilterDbObjectName";
            this.txtFilterDbObjectName.Size = new System.Drawing.Size(302, 21);
            this.txtFilterDbObjectName.TabIndex = 7;
            this.txtFilterDbObjectName.Text = "sys|aspnet_";
            // 
            // btnGenarateCode
            // 
            this.btnGenarateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenarateCode.Location = new System.Drawing.Point(464, 385);
            this.btnGenarateCode.Name = "btnGenarateCode";
            this.btnGenarateCode.Size = new System.Drawing.Size(94, 23);
            this.btnGenarateCode.TabIndex = 6;
            this.btnGenarateCode.Text = "代码生成";
            this.btnGenarateCode.UseVisualStyleBackColor = true;
            this.btnGenarateCode.Click += new System.EventHandler(this.btnGenarateCode_Click);
            // 
            // lblSelectDataBase
            // 
            this.lblSelectDataBase.AutoSize = true;
            this.lblSelectDataBase.Location = new System.Drawing.Point(15, 33);
            this.lblSelectDataBase.Name = "lblSelectDataBase";
            this.lblSelectDataBase.Size = new System.Drawing.Size(77, 12);
            this.lblSelectDataBase.TabIndex = 0;
            this.lblSelectDataBase.Text = "选择数据库：";
            // 
            // cmbSelectDataBase
            // 
            this.cmbSelectDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSelectDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSelectDataBase.FormattingEnabled = true;
            this.cmbSelectDataBase.Location = new System.Drawing.Point(98, 30);
            this.cmbSelectDataBase.Name = "cmbSelectDataBase";
            this.cmbSelectDataBase.Size = new System.Drawing.Size(384, 20);
            this.cmbSelectDataBase.TabIndex = 1;
            this.cmbSelectDataBase.SelectedIndexChanged += new System.EventHandler(this.cmbSelectDataBase_SelectedIndexChanged);
            // 
            // lblSelectDbObject
            // 
            this.lblSelectDbObject.AutoSize = true;
            this.lblSelectDbObject.Location = new System.Drawing.Point(15, 68);
            this.lblSelectDbObject.Name = "lblSelectDbObject";
            this.lblSelectDbObject.Size = new System.Drawing.Size(89, 12);
            this.lblSelectDbObject.TabIndex = 2;
            this.lblSelectDbObject.Text = "选择{$DbObj}：";
            // 
            // tabPageConfig
            // 
            this.tabPageConfig.Controls.Add(this.tableLayoutPanel1);
            this.tabPageConfig.Controls.Add(this.lblConfigDescription);
            this.tabPageConfig.Location = new System.Drawing.Point(4, 22);
            this.tabPageConfig.Name = "tabPageConfig";
            this.tabPageConfig.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageConfig.Size = new System.Drawing.Size(596, 414);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(590, 408);
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
            this.toolStripTop.Size = new System.Drawing.Size(590, 25);
            this.toolStripTop.TabIndex = 4;
            this.toolStripTop.Text = "toolStrip1";
            this.toolStripTop.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStripTop_ItemClicked);
            // 
            // toolStripButtonSaveCodeGenerateConifg
            // 
            this.toolStripButtonSaveCodeGenerateConifg.Image = global::Legendigital.Code.MyGenAddin.WinResource.Save;
            this.toolStripButtonSaveCodeGenerateConifg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveCodeGenerateConifg.Name = "toolStripButtonSaveCodeGenerateConifg";
            this.toolStripButtonSaveCodeGenerateConifg.Size = new System.Drawing.Size(112, 22);
            this.toolStripButtonSaveCodeGenerateConifg.Text = "保存为默认配置";
            // 
            // toolStripButtonSaveAs
            // 
            this.toolStripButtonSaveAs.Image = global::Legendigital.Code.MyGenAddin.WinResource.Save;
            this.toolStripButtonSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            this.toolStripButtonSaveAs.Size = new System.Drawing.Size(88, 22);
            this.toolStripButtonSaveAs.Text = "配置另存为";
            // 
            // toolStripButtonLoadConfig
            // 
            this.toolStripButtonLoadConfig.Image = global::Legendigital.Code.MyGenAddin.WinResource.open;
            this.toolStripButtonLoadConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadConfig.Name = "toolStripButtonLoadConfig";
            this.toolStripButtonLoadConfig.Size = new System.Drawing.Size(76, 22);
            this.toolStripButtonLoadConfig.Text = "加载配置";
            // 
            // toolStripButtonConfigMygeneration
            // 
            this.toolStripButtonConfigMygeneration.Image = global::Legendigital.Code.MyGenAddin.WinResource.setting;
            this.toolStripButtonConfigMygeneration.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonConfigMygeneration.Name = "toolStripButtonConfigMygeneration";
            this.toolStripButtonConfigMygeneration.Size = new System.Drawing.Size(134, 22);
            this.toolStripButtonConfigMygeneration.Text = "配置MyGeneration";
            // 
            // propertyGridSetting
            // 
            this.propertyGridSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridSetting.Location = new System.Drawing.Point(3, 28);
            this.propertyGridSetting.Name = "propertyGridSetting";
            this.propertyGridSetting.Size = new System.Drawing.Size(584, 377);
            this.propertyGridSetting.TabIndex = 1;
            // 
            // lblConfigDescription
            // 
            this.lblConfigDescription.AutoSize = true;
            this.lblConfigDescription.Location = new System.Drawing.Point(8, 339);
            this.lblConfigDescription.Name = "lblConfigDescription";
            this.lblConfigDescription.Size = new System.Drawing.Size(0, 12);
            this.lblConfigDescription.TabIndex = 3;
            // 
            // saveFileDialogConfig
            // 
            this.saveFileDialogConfig.DefaultExt = "dat";
            this.saveFileDialogConfig.Filter = "代码生成配置文件 (*.dat)|*.dat";
            // 
            // openFileDialogConfig
            // 
            this.openFileDialogConfig.DefaultExt = "dat";
            this.openFileDialogConfig.Filter = "代码生成配置文件 (*.dat)|*.dat";
            // 
            // lblCodeType
            // 
            this.lblCodeType.AutoSize = true;
            this.lblCodeType.Location = new System.Drawing.Point(16, 389);
            this.lblCodeType.Name = "lblCodeType";
            this.lblCodeType.Size = new System.Drawing.Size(125, 12);
            this.lblCodeType.TabIndex = 14;
            this.lblCodeType.Text = "代码生成自定义选项：";
            this.lblCodeType.Visible = false;
            // 
            // cmbCodeType
            // 
            this.cmbCodeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCodeType.FormattingEnabled = true;
            this.cmbCodeType.Location = new System.Drawing.Point(185, 386);
            this.cmbCodeType.Name = "cmbCodeType";
            this.cmbCodeType.Size = new System.Drawing.Size(210, 20);
            this.cmbCodeType.TabIndex = 15;
            this.cmbCodeType.Visible = false;
            // 
            // BaseObjectSelectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 446);
            this.Controls.Add(this.tbcMain);
            this.Name = "BaseObjectSelectorForm";
            this.ShowInTaskbar = false;
            this.Text = "BaseDbObjectSelectorForm";
            this.Load += new System.EventHandler(this.BaseDbObjectSelectorForm_Load);
            this.tbcMain.ResumeLayout(false);
            this.tabPageData.ResumeLayout(false);
            this.groupBoxCodeGeneration.ResumeLayout(false);
            this.groupBoxCodeGeneration.PerformLayout();
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
        protected System.Windows.Forms.Label lblFilterDbObjectName;
        protected System.Windows.Forms.Button btnRefresh;
        protected System.Windows.Forms.CheckBox chkSelectAll;
        protected System.Windows.Forms.CheckedListBox checkedListBoxSelectDbObject;
        protected System.Windows.Forms.TextBox txtFilterDbObjectName;
        protected System.Windows.Forms.Button btnGenarateCode;
        protected System.Windows.Forms.Label lblSelectDataBase;
        protected System.Windows.Forms.ComboBox cmbSelectDataBase;
        protected System.Windows.Forms.Label lblSelectDbObject;
        protected System.Windows.Forms.TabPage tabPageConfig;
        protected System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        protected System.Windows.Forms.ToolStrip toolStripTop;
        protected System.Windows.Forms.ToolStripButton toolStripButtonSaveCodeGenerateConifg;
        protected System.Windows.Forms.ToolStripButton toolStripButtonSaveAs;
        protected System.Windows.Forms.ToolStripButton toolStripButtonLoadConfig;
        protected System.Windows.Forms.ToolStripButton toolStripButtonConfigMygeneration;
        protected System.Windows.Forms.PropertyGrid propertyGridSetting;
        protected System.Windows.Forms.Label lblConfigDescription;
        protected System.Windows.Forms.SaveFileDialog saveFileDialogConfig;
        protected System.Windows.Forms.OpenFileDialog openFileDialogConfig;





    }
}
