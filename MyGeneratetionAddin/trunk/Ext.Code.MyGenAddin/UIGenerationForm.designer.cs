using System.Collections;
using System.Windows.Forms;
using MyMeta;
using Zeus;

namespace Legendigital.Code.MyGenAddin
{
    partial class UIGenerationForm
    {
        private dbRoot myMeta;
        private IZeusInput zeusInput;

        public UIGenerationForm(dbRoot myMeta, IZeusInput zeusInput)
        {
            this.myMeta    = myMeta;
            this.zeusInput = zeusInput;
		
            InitializeComponent();
            UICodeGenerationConfig cg = this.Uiconfig;
            ArrayList al = new ArrayList();
            foreach (InputUIControl inputUIControl in cg.UIControlConfigs)
            {
                al.Add(inputUIControl.Name);
            }
            this.colInputType.Items.AddRange(al.ToArray());

            this.GetSetting();
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIGenerationForm));
            this.saveFileDialogInputUIConfig = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogInputUIConfig = new System.Windows.Forms.OpenFileDialog();
            this.tabPageSetting = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tsConfigOperation = new System.Windows.Forms.ToolStrip();
            this.tsbSaveConifgToDefault = new System.Windows.Forms.ToolStripButton();
            this.tsbSaveConfigToFile = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenConfigFromFile = new System.Windows.Forms.ToolStripButton();
            this.propertyGridSetting = new System.Windows.Forms.PropertyGrid();
            this.btnSaveSetting = new System.Windows.Forms.Button();
            this.tabPageSingleCode = new System.Windows.Forms.TabPage();
            this.dataGridViewField = new System.Windows.Forms.DataGridView();
            this.colIsSelect = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFieldNameCn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colLanguageType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsAutoKey = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colInputType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.colDefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsReqiured = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colSelectItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIndexName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStripSingleCodeCommandList = new System.Windows.Forms.ToolStrip();
            this.lblToolStripSelectDataBase = new System.Windows.Forms.ToolStripLabel();
            this.cbxtoolStripSelectDataBase = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.SelectObjectType = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSelectObjectType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.lbltoolStriplblSelectTable = new System.Windows.Forms.ToolStripLabel();
            this.cbxtoolStripSelectObejct = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.sbtntoolStripComandType = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripButtonSelectAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonSaveConfig = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonLoadConifg = new System.Windows.Forms.ToolStripButton();
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.saveFileDialogConfig = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.tabPageSetting.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tsConfigOperation.SuspendLayout();
            this.tabPageSingleCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewField)).BeginInit();
            this.toolStripSingleCodeCommandList.SuspendLayout();
            this.tbcMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialogInputUIConfig
            // 
            this.openFileDialogInputUIConfig.FileName = "openFileDialog1";
            // 
            // tabPageSetting
            // 
            this.tabPageSetting.Controls.Add(this.tableLayoutPanel1);
            this.tabPageSetting.Controls.Add(this.btnSaveSetting);
            this.tabPageSetting.Location = new System.Drawing.Point(4, 22);
            this.tabPageSetting.Name = "tabPageSetting";
            this.tabPageSetting.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSetting.Size = new System.Drawing.Size(1042, 489);
            this.tabPageSetting.TabIndex = 1;
            this.tabPageSetting.Text = "配置设置";
            this.tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tsConfigOperation, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.propertyGridSetting, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1036, 483);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // tsConfigOperation
            // 
            this.tsConfigOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tsConfigOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSaveConifgToDefault,
            this.tsbSaveConfigToFile,
            this.tsbOpenConfigFromFile});
            this.tsConfigOperation.Location = new System.Drawing.Point(0, 0);
            this.tsConfigOperation.Name = "tsConfigOperation";
            this.tsConfigOperation.Size = new System.Drawing.Size(1036, 25);
            this.tsConfigOperation.TabIndex = 4;
            this.tsConfigOperation.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsConfigOperation_ItemClicked);
            // 
            // tsbSaveConifgToDefault
            // 
            this.tsbSaveConifgToDefault.Image = global::Legendigital.Code.MyGenAddin.WinResource.Save;
            this.tsbSaveConifgToDefault.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveConifgToDefault.Name = "tsbSaveConifgToDefault";
            this.tsbSaveConifgToDefault.Size = new System.Drawing.Size(112, 22);
            this.tsbSaveConifgToDefault.Text = "保存为默认配置";
            // 
            // tsbSaveConfigToFile
            // 
            this.tsbSaveConfigToFile.Image = global::Legendigital.Code.MyGenAddin.WinResource.Save;
            this.tsbSaveConfigToFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveConfigToFile.Name = "tsbSaveConfigToFile";
            this.tsbSaveConfigToFile.Size = new System.Drawing.Size(76, 22);
            this.tsbSaveConfigToFile.Text = "保存配置";
            // 
            // tsbOpenConfigFromFile
            // 
            this.tsbOpenConfigFromFile.Image = global::Legendigital.Code.MyGenAddin.WinResource.open;
            this.tsbOpenConfigFromFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOpenConfigFromFile.Name = "tsbOpenConfigFromFile";
            this.tsbOpenConfigFromFile.Size = new System.Drawing.Size(76, 22);
            this.tsbOpenConfigFromFile.Text = "保存配置";
            // 
            // propertyGridSetting
            // 
            this.propertyGridSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridSetting.Location = new System.Drawing.Point(3, 28);
            this.propertyGridSetting.Name = "propertyGridSetting";
            this.propertyGridSetting.Size = new System.Drawing.Size(1030, 452);
            this.propertyGridSetting.TabIndex = 1;
            // 
            // btnSaveSetting
            // 
            this.btnSaveSetting.Location = new System.Drawing.Point(851, 446);
            this.btnSaveSetting.Name = "btnSaveSetting";
            this.btnSaveSetting.Size = new System.Drawing.Size(75, 23);
            this.btnSaveSetting.TabIndex = 4;
            this.btnSaveSetting.Text = "保存设置";
            this.btnSaveSetting.UseVisualStyleBackColor = true;
            // 
            // tabPageSingleCode
            // 
            this.tabPageSingleCode.Controls.Add(this.dataGridViewField);
            this.tabPageSingleCode.Controls.Add(this.toolStripSingleCodeCommandList);
            this.tabPageSingleCode.Location = new System.Drawing.Point(4, 22);
            this.tabPageSingleCode.Name = "tabPageSingleCode";
            this.tabPageSingleCode.Size = new System.Drawing.Size(1042, 489);
            this.tabPageSingleCode.TabIndex = 2;
            this.tabPageSingleCode.Text = "片段代码生成";
            this.tabPageSingleCode.UseVisualStyleBackColor = true;
            // 
            // dataGridViewField
            // 
            this.dataGridViewField.AllowUserToAddRows = false;
            this.dataGridViewField.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewField.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIsSelect,
            this.colFieldName,
            this.colFieldNameCn,
            this.colLanguageType,
            this.colSize,
            this.colIsAutoKey,
            this.colInputType,
            this.colDefaultValue,
            this.colIsReqiured,
            this.colSelectItem,
            this.colIndexName});
            this.dataGridViewField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewField.Location = new System.Drawing.Point(0, 25);
            this.dataGridViewField.Name = "dataGridViewField";
            this.dataGridViewField.RowTemplate.Height = 23;
            this.dataGridViewField.Size = new System.Drawing.Size(1042, 464);
            this.dataGridViewField.TabIndex = 1;
            this.dataGridViewField.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewField_CellValueChanged);
            // 
            // colIsSelect
            // 
            this.colIsSelect.DataPropertyName = "IsSelect";
            this.colIsSelect.FillWeight = 50F;
            this.colIsSelect.HeaderText = "选择";
            this.colIsSelect.Name = "colIsSelect";
            this.colIsSelect.Width = 50;
            // 
            // colFieldName
            // 
            this.colFieldName.DataPropertyName = "FieldName";
            this.colFieldName.HeaderText = "列名";
            this.colFieldName.Name = "colFieldName";
            this.colFieldName.ReadOnly = true;
            // 
            // colFieldNameCn
            // 
            this.colFieldNameCn.DataPropertyName = "FieldNameCn";
            this.colFieldNameCn.HeaderText = "中文字段";
            this.colFieldNameCn.Name = "colFieldNameCn";
            // 
            // colLanguageType
            // 
            this.colLanguageType.DataPropertyName = "LanguageType";
            this.colLanguageType.FillWeight = 80F;
            this.colLanguageType.HeaderText = "数据类型";
            this.colLanguageType.Name = "colLanguageType";
            this.colLanguageType.ReadOnly = true;
            this.colLanguageType.Width = 80;
            // 
            // colSize
            // 
            this.colSize.DataPropertyName = "Size";
            this.colSize.FillWeight = 60F;
            this.colSize.HeaderText = "大小";
            this.colSize.Name = "colSize";
            this.colSize.ReadOnly = true;
            this.colSize.Width = 60;
            // 
            // colIsAutoKey
            // 
            this.colIsAutoKey.DataPropertyName = "IsAutoKey";
            this.colIsAutoKey.FillWeight = 60F;
            this.colIsAutoKey.HeaderText = "主键";
            this.colIsAutoKey.Name = "colIsAutoKey";
            this.colIsAutoKey.ReadOnly = true;
            this.colIsAutoKey.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colIsAutoKey.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colIsAutoKey.Width = 60;
            // 
            // colInputType
            // 
            this.colInputType.DataPropertyName = "InputType";
            this.colInputType.FillWeight = 120F;
            this.colInputType.HeaderText = "输入控件类型";
            this.colInputType.Name = "colInputType";
            this.colInputType.Width = 120;
            // 
            // colDefaultValue
            // 
            this.colDefaultValue.DataPropertyName = "DefaultValue";
            this.colDefaultValue.HeaderText = "默认值";
            this.colDefaultValue.Name = "colDefaultValue";
            // 
            // colIsReqiured
            // 
            this.colIsReqiured.DataPropertyName = "IsReqiured";
            this.colIsReqiured.FillWeight = 40F;
            this.colIsReqiured.HeaderText = "必填";
            this.colIsReqiured.Name = "colIsReqiured";
            this.colIsReqiured.Width = 40;
            // 
            // colSelectItem
            // 
            this.colSelectItem.DataPropertyName = "Items";
            this.colSelectItem.FillWeight = 290F;
            this.colSelectItem.HeaderText = "选项";
            this.colSelectItem.Name = "colSelectItem";
            this.colSelectItem.Width = 290;
            // 
            // colIndexName
            // 
            this.colIndexName.DataPropertyName = "DbColumnName";
            this.colIndexName.HeaderText = "数据列名";
            this.colIndexName.Name = "colIndexName";
            this.colIndexName.ReadOnly = true;
            this.colIndexName.Visible = false;
            // 
            // toolStripSingleCodeCommandList
            // 
            this.toolStripSingleCodeCommandList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblToolStripSelectDataBase,
            this.cbxtoolStripSelectDataBase,
            this.toolStripSeparator1,
            this.SelectObjectType,
            this.toolStripSelectObjectType,
            this.toolStripSeparator2,
            this.lbltoolStriplblSelectTable,
            this.cbxtoolStripSelectObejct,
            this.toolStripSeparator3,
            this.sbtntoolStripComandType,
            this.toolStripButtonSelectAll,
            this.toolStripSeparator4,
            this.toolStripButtonSaveConfig,
            this.toolStripButtonLoadConifg});
            this.toolStripSingleCodeCommandList.Location = new System.Drawing.Point(0, 0);
            this.toolStripSingleCodeCommandList.Name = "toolStripSingleCodeCommandList";
            this.toolStripSingleCodeCommandList.Size = new System.Drawing.Size(1042, 25);
            this.toolStripSingleCodeCommandList.TabIndex = 0;
            this.toolStripSingleCodeCommandList.Text = "toolStrip1";
            // 
            // lblToolStripSelectDataBase
            // 
            this.lblToolStripSelectDataBase.Name = "lblToolStripSelectDataBase";
            this.lblToolStripSelectDataBase.Size = new System.Drawing.Size(56, 22);
            this.lblToolStripSelectDataBase.Text = "数据库：";
            // 
            // cbxtoolStripSelectDataBase
            // 
            this.cbxtoolStripSelectDataBase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxtoolStripSelectDataBase.Name = "cbxtoolStripSelectDataBase";
            this.cbxtoolStripSelectDataBase.Size = new System.Drawing.Size(150, 25);
            this.cbxtoolStripSelectDataBase.SelectedIndexChanged += new System.EventHandler(this.cbxtoolStripSelectDataBase_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // SelectObjectType
            // 
            this.SelectObjectType.Name = "SelectObjectType";
            this.SelectObjectType.Size = new System.Drawing.Size(72, 22);
            this.SelectObjectType.Text = " 对象类型：";
            // 
            // toolStripSelectObjectType
            // 
            this.toolStripSelectObjectType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripSelectObjectType.Items.AddRange(new object[] {
            "表",
            "视图"});
            this.toolStripSelectObjectType.Name = "toolStripSelectObjectType";
            this.toolStripSelectObjectType.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // lbltoolStriplblSelectTable
            // 
            this.lbltoolStriplblSelectTable.Name = "lbltoolStriplblSelectTable";
            this.lbltoolStriplblSelectTable.Size = new System.Drawing.Size(44, 22);
            this.lbltoolStriplblSelectTable.Text = "对象：";
            // 
            // cbxtoolStripSelectObejct
            // 
            this.cbxtoolStripSelectObejct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxtoolStripSelectObejct.DropDownWidth = 180;
            this.cbxtoolStripSelectObejct.Name = "cbxtoolStripSelectObejct";
            this.cbxtoolStripSelectObejct.Size = new System.Drawing.Size(180, 25);
            this.cbxtoolStripSelectObejct.SelectedIndexChanged += new System.EventHandler(this.cbxtoolStripSelectObejct_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // sbtntoolStripComandType
            // 
            this.sbtntoolStripComandType.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.sbtntoolStripComandType.Image = ((System.Drawing.Image)(resources.GetObject("sbtntoolStripComandType.Image")));
            this.sbtntoolStripComandType.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sbtntoolStripComandType.Name = "sbtntoolStripComandType";
            this.sbtntoolStripComandType.Size = new System.Drawing.Size(72, 22);
            this.sbtntoolStripComandType.Text = "选择操作";
            this.sbtntoolStripComandType.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.sbtntoolStripComandType_DropDownItemClicked);
            // 
            // toolStripButtonSelectAll
            // 
            this.toolStripButtonSelectAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSelectAll.Image")));
            this.toolStripButtonSelectAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSelectAll.Name = "toolStripButtonSelectAll";
            this.toolStripButtonSelectAll.Size = new System.Drawing.Size(36, 22);
            this.toolStripButtonSelectAll.Text = "全选";
            this.toolStripButtonSelectAll.Click += new System.EventHandler(this.toolStripButtonSelectAll_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonSaveConfig
            // 
            this.toolStripButtonSaveConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonSaveConfig.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSaveConfig.Image")));
            this.toolStripButtonSaveConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSaveConfig.Name = "toolStripButtonSaveConfig";
            this.toolStripButtonSaveConfig.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonSaveConfig.Text = "保存配置";
            this.toolStripButtonSaveConfig.Click += new System.EventHandler(this.toolStripButtonSaveConfig_Click);
            // 
            // toolStripButtonLoadConifg
            // 
            this.toolStripButtonLoadConifg.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLoadConifg.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadConifg.Image")));
            this.toolStripButtonLoadConifg.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadConifg.Name = "toolStripButtonLoadConifg";
            this.toolStripButtonLoadConifg.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonLoadConifg.Text = "载入配置";
            this.toolStripButtonLoadConifg.Click += new System.EventHandler(this.toolStripButtonLoadConifg_Click);
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabPageSingleCode);
            this.tbcMain.Controls.Add(this.tabPageSetting);
            this.tbcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcMain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tbcMain.Location = new System.Drawing.Point(0, 0);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(1050, 515);
            this.tbcMain.TabIndex = 2;
            this.tbcMain.TabStop = false;
            // 
            // saveFileDialogConfig
            // 
            this.saveFileDialogConfig.Filter = "代码生成配置文件|*.cgf";
            // 
            // openFileDialogConfig
            // 
            this.openFileDialogConfig.Filter = "代码生成配置文件|*.cgf";
            // 
            // UIGenerationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 515);
            this.Controls.Add(this.tbcMain);
            this.Name = "UIGenerationForm";
            this.Text = "表现层代码生成工具";
            this.Load += new System.EventHandler(this.UIGenerationForm_Load);
            this.tabPageSetting.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tsConfigOperation.ResumeLayout(false);
            this.tsConfigOperation.PerformLayout();
            this.tabPageSingleCode.ResumeLayout(false);
            this.tabPageSingleCode.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewField)).EndInit();
            this.toolStripSingleCodeCommandList.ResumeLayout(false);
            this.toolStripSingleCodeCommandList.PerformLayout();
            this.tbcMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialogInputUIConfig;
        private System.Windows.Forms.OpenFileDialog openFileDialogInputUIConfig;
        private System.Windows.Forms.TabPage tabPageSetting;
        private System.Windows.Forms.Button btnSaveSetting;
        private System.Windows.Forms.TabPage tabPageSingleCode;
        private System.Windows.Forms.DataGridView dataGridViewField;
        private System.Windows.Forms.ToolStrip toolStripSingleCodeCommandList;
        private System.Windows.Forms.ToolStripLabel lblToolStripSelectDataBase;
        private System.Windows.Forms.ToolStripComboBox cbxtoolStripSelectDataBase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel SelectObjectType;
        private System.Windows.Forms.ToolStripComboBox toolStripSelectObjectType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel lbltoolStriplblSelectTable;
        private System.Windows.Forms.ToolStripComboBox cbxtoolStripSelectObejct;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSplitButton sbtntoolStripComandType;
        private System.Windows.Forms.ToolStripButton toolStripButtonSelectAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonSaveConfig;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadConifg;
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip tsConfigOperation;
        private System.Windows.Forms.ToolStripButton tsbSaveConifgToDefault;
        private System.Windows.Forms.PropertyGrid propertyGridSetting;
        private DataGridViewCheckBoxColumn colIsSelect;
        private DataGridViewTextBoxColumn colFieldName;
        private DataGridViewTextBoxColumn colFieldNameCn;
        private DataGridViewTextBoxColumn colLanguageType;
        private DataGridViewTextBoxColumn colSize;
        private DataGridViewCheckBoxColumn colIsAutoKey;
        private DataGridViewComboBoxColumn colInputType;
        private DataGridViewTextBoxColumn colDefaultValue;
        private DataGridViewCheckBoxColumn colIsReqiured;
        private DataGridViewTextBoxColumn colSelectItem;
        private DataGridViewTextBoxColumn colIndexName;
        private ToolStripButton tsbSaveConfigToFile;
        private ToolStripButton tsbOpenConfigFromFile;
        private SaveFileDialog saveFileDialogConfig;
        private OpenFileDialog openFileDialogConfig;
    }
}