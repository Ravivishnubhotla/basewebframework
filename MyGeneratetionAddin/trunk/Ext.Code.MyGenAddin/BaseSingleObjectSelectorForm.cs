using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Legendigital.Code.MyGenAddin.NHibernateFramework;
using MyGenerationInputForm;
using MyMeta;
using Zeus;

namespace Legendigital.Code.MyGenAddin
{
    public abstract class BaseSingleObjectSelectorForm<T> : Form where T : NHibernateFrameworkWebUIGenerateConfig
    {
        private Button btnSaveSetting;
        private ToolStripComboBox cbxtoolStripSelectDataBase;
        private ToolStripComboBox cbxtoolStripSelectObejct;
        private DataGridViewTextBoxColumn colDefaultValue;
        private DataGridViewTextBoxColumn colFieldName;
        private DataGridViewTextBoxColumn colFieldNameCn;
        private DataGridViewTextBoxColumn colIndexName;
        private DataGridViewComboBoxColumn colInputType;
        private DataGridViewCheckBoxColumn colIsAutoKey;
        private DataGridViewCheckBoxColumn colIsReqiured;
        private DataGridViewCheckBoxColumn colIsSelect;
        private DataGridViewTextBoxColumn colLanguageType;
        private DataGridViewTextBoxColumn colSelectItem;
        private DataGridViewTextBoxColumn colSize;
        protected T config;
        private DataGridView dataGridViewField;
        private ToolStripLabel lbltoolStriplblSelectTable;
        private ToolStripLabel lblToolStripSelectDataBase;
        protected dbRoot myMeta;
        protected OpenFileDialog openFileDialogConfig;
        private OpenFileDialog openFileDialogInputUIConfig;
        private Panel panelMain;
        private Panel panelTop;
        private PropertyGrid propertyGridSetting;
        protected SaveFileDialog saveFileDialogConfig;
        private SaveFileDialog saveFileDialogInputUIConfig;
        private ToolStripSplitButton sbtntoolStripComandType;
        private ToolStripLabel SelectObjectType;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanelFieldList;
        private TabPage tabPageSetting;
        private TabPage tabPageSingleCode;
        private TabControl tbcMain;
        protected ToolStripButton toolStripButtonConfigMygeneration;
        protected ToolStripButton toolStripButtonLoadConfig;
        private ToolStripButton toolStripButtonLoadConifg;
        protected ToolStripButton toolStripButtonSaveAs;
        protected ToolStripButton toolStripButtonSaveCodeGenerateConifg;
        private ToolStripButton toolStripButtonSaveConfig;
        private ToolStripButton toolStripButtonSelectAll;
        private ToolStripComboBox toolStripSelectObjectType;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStrip toolStripSingleCodeCommandList;
        private ToolStrip toolStripTop;
 
        protected IZeusInput zeusInput;

        public abstract T DefaultConfig { get; }
        public abstract string ConfigKey { get; }


        public NHibernateFrameworkWebUIGenerateConfig webuiconfig
        {
            get
            {
                return (NHibernateFrameworkWebUIGenerateConfig)config;
            }
        }

 

        protected abstract string GetDefaultDataBaseName();

        protected void InitForm(dbRoot myMeta, IZeusInput input)
        {
            try
            {
                this.myMeta = myMeta;

                zeusInput = input;

                InitializeComponent();


                GetSetting();

                InitInputType();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void InitInputType()
        {
            colInputType.Items.Clear();

            foreach (InputUIControl inputUIControl in webuiconfig.GetUIFieldType())
            {
                colInputType.Items.Add(inputUIControl.Name);
            }
        }

        protected void SaveSetting()
        {
            SerializableHelper.BinarySerializeObject<T>(ConfigKey, config);
        }

        protected void GetSetting()
        {
            config = SerializableHelper.BinaryDeserializeObject<T>(ConfigKey, DefaultConfig);
        }

        public abstract SortedList<string, string> GetDropDownList();


        protected void btnGenarateCode_Click(object sender, EventArgs e)
        {
        }

        private void toolStripButtonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridViewField.Rows)
            {
                row.Cells["colIsSelect"].Value = true;
            }
        }

        private void dataGridViewField_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridViewField.Columns[e.ColumnIndex].Name == "colSelectItem")
            {
                DataGridViewCell de = dataGridViewField.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string emessage = "";
                if (!TableColumnGenerationHelper.validateSelectItemString((string) de.Value, out emessage))
                {
                    MessageBox.Show(emessage);
                    de.Value = "";
                }
            }
            if (dataGridViewField.Columns[e.ColumnIndex].Name == "colInputType")
            {
                DataGridViewCell de = dataGridViewField.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewCell deitem =
                    dataGridViewField.Rows[e.RowIndex].Cells[dataGridViewField.Columns["colSelectItem"].Index];
                InputUIControl iuc = webuiconfig.getInputUIControlByName(de.Value.ToString());
                deitem.ReadOnly = !iuc.HasItems;
                if (!iuc.HasItems)
                {
                    deitem.Value = "";
                }
            }
        }


        private void toolStripButtonSaveConfig_Click(object sender, EventArgs e)
        {
            if ((cbxtoolStripSelectDataBase.ComboBox.SelectedIndex >= 0) &&
                (cbxtoolStripSelectObejct.ComboBox.SelectedIndex >= 0))
            {
                var database = cbxtoolStripSelectDataBase.ComboBox.SelectedValue as IDatabase;
                var selectTable = cbxtoolStripSelectObejct.ComboBox.SelectedValue as ITable;

                FormUISetting uis = GetFormUIConfig(database, selectTable);

                string pathKey = "Key|KilerCodeGeneration|UI|" + database.Name + "|" + selectTable.Name;

                XmlConfigReader.SetConfig<FormUISetting>(pathKey, uis, saveFileDialogInputUIConfig);
            }
        }

        private FormUISetting GetFormUIConfig(IDatabase database, ITable selectTable)
        {
            List<TableUIGenerationParams> tableUIGenerationParamsList = null;
            if (database != null && selectTable != null)
            {
                tableUIGenerationParamsList = new List<TableUIGenerationParams>();
                foreach (DataGridViewRow row in dataGridViewField.Rows)
                {
                    if ((bool) row.Cells["colIsSelect"].Value)
                    {
                        var tableUIGenerationParams = new TableUIGenerationParams();
                        tableUIGenerationParams.IsSelect = (bool) row.Cells["colIsSelect"].Value;
                        tableUIGenerationParams.FieldName = (string) row.Cells["colFieldName"].Value;
                        tableUIGenerationParams.FieldNameCn = (string) row.Cells["colFieldNameCn"].Value;
                        tableUIGenerationParams.LanguageType = (string) row.Cells["colLanguageType"].Value;
                        tableUIGenerationParams.Size = (int) row.Cells["colSize"].Value;
                        tableUIGenerationParams.IsAutoKey = (bool) row.Cells["colIsAutoKey"].Value;
                        tableUIGenerationParams.InputType = (string) row.Cells["colInputType"].Value;
                        tableUIGenerationParams.IsReqiured = (bool) row.Cells["colIsReqiured"].Value;
                        tableUIGenerationParams.DefaultValue = (string) row.Cells["colDefaultValue"].Value;
                        tableUIGenerationParams.Items = (string) row.Cells["colSelectItem"].Value;
                        tableUIGenerationParams.DbColumnName = (string) row.Cells["colIndexName"].Value;
                        tableUIGenerationParamsList.Add(tableUIGenerationParams);
                    }
                }
            }

            var uis = new FormUISetting();
            uis.TableName = selectTable.Name;
            uis.Items = tableUIGenerationParamsList;
            return uis;
        }


        private void GetSingleInputData(string generateType)
        {
            var database = cbxtoolStripSelectDataBase.ComboBox.SelectedValue as IDatabase;
            var selectTable = cbxtoolStripSelectObejct.ComboBox.SelectedValue as ITable;

            GenerateMoudlePages generateMoudle = new GenerateMoudlePages();

            if (!(generateMoudle.ShowSelect(this.config.WebProjectRootPath) == DialogResult.OK))
            {
                return;
            }

            if (string.IsNullOrEmpty(generateMoudle.SelectPath))
                return;

            zeusInput["PagePath"] = generateMoudle.SelectPath;
            zeusInput["PageNameSpace"] = generateMoudle.PageNameSpace;
            zeusInput["GenerateType"] = generateType;
            zeusInput["selectDataBase"] = database;
            zeusInput["selectTable"] = selectTable;
            this.zeusInput["codeGenerationSetting"] = this.config;

            TableUIGenerationParams[] tableUIGenerationParamsListArray = GetTableUiGenerationParamsListArray();

            zeusInput["TableUIGenerationParamsArray"] = tableUIGenerationParamsListArray;
        }

        private TableUIGenerationParams[] GetTableUiGenerationParamsListArray()
        {
            List<TableUIGenerationParams> tableUIGenerationParamsList = new List<TableUIGenerationParams>();
            foreach (DataGridViewRow row in dataGridViewField.Rows)
            {
                var tableUIGenerationParams = new TableUIGenerationParams();
                tableUIGenerationParams.IsSelect = (bool) row.Cells["colIsSelect"].Value;
                tableUIGenerationParams.FieldName = (string) row.Cells["colFieldName"].Value;
                tableUIGenerationParams.FieldNameCn = (string) row.Cells["colFieldNameCn"].Value;
                tableUIGenerationParams.LanguageType = (string) row.Cells["colLanguageType"].Value;
                tableUIGenerationParams.Size = (int) row.Cells["colSize"].Value;
                tableUIGenerationParams.IsAutoKey = (bool) row.Cells["colIsAutoKey"].Value;
                tableUIGenerationParams.InputType = (string) row.Cells["colInputType"].Value;
                tableUIGenerationParams.IsReqiured = (bool) row.Cells["colIsReqiured"].Value;
                tableUIGenerationParams.DefaultValue = (string) row.Cells["colDefaultValue"].Value;
                tableUIGenerationParams.Items = (string) row.Cells["colSelectItem"].Value;
                tableUIGenerationParams.DbColumnName = (string) row.Cells["colIndexName"].Value;
                tableUIGenerationParams.InputUIControlType =
                    webuiconfig.getInputUIControlByName(tableUIGenerationParams.InputType);
                tableUIGenerationParamsList.Add(tableUIGenerationParams);
            }
            return tableUIGenerationParamsList.ToArray();
        }


        private void toolStripButtonLoadConifg_Click(object sender, EventArgs e)
        {
            if ((cbxtoolStripSelectDataBase.ComboBox.SelectedIndex >= 0) &&
                (cbxtoolStripSelectObejct.ComboBox.SelectedIndex >= 0))
            {
                if (openFileDialogInputUIConfig.ShowDialog() == DialogResult.OK)
                {
                    var uis = XmlConfigReader.GetConfig<FormUISetting>(openFileDialogInputUIConfig.FileName);

                    var database = cbxtoolStripSelectDataBase.ComboBox.SelectedValue as IDatabase;

                    for (int i = 0; i < cbxtoolStripSelectObejct.ComboBox.Items.Count; i++)
                    {
                        var table = (ITable) cbxtoolStripSelectObejct.ComboBox.Items[i];
                        if (table.Name == uis.TableName)
                        {
                            cbxtoolStripSelectObejct.ComboBox.SelectedIndex = i;
                            break;
                        }
                    }

                    dataGridViewField.DataSource = uis.Items;
                }
            }
        }

        private void sbtntoolStripComandType_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            GetSingleInputData(e.ClickedItem.Name.Replace("ToolStripMenuItem", ""));
            zeusInput["Uiconfig"] = webuiconfig;
            zeusInput["codeGenerationSetting"] = config;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void InitializeComponent()
        {
            tbcMain = new TabControl();
            tabPageSingleCode = new TabPage();
            tableLayoutPanelFieldList = new TableLayoutPanel();
            panelMain = new Panel();
            dataGridViewField = new DataGridView();
            colIsSelect = new DataGridViewCheckBoxColumn();
            colFieldName = new DataGridViewTextBoxColumn();
            colFieldNameCn = new DataGridViewTextBoxColumn();
            colLanguageType = new DataGridViewTextBoxColumn();
            colSize = new DataGridViewTextBoxColumn();
            colIsAutoKey = new DataGridViewCheckBoxColumn();
            colInputType = new DataGridViewComboBoxColumn();
            colDefaultValue = new DataGridViewTextBoxColumn();
            colIsReqiured = new DataGridViewCheckBoxColumn();
            colSelectItem = new DataGridViewTextBoxColumn();
            colIndexName = new DataGridViewTextBoxColumn();
            panelTop = new Panel();
            toolStripSingleCodeCommandList = new ToolStrip();
            lblToolStripSelectDataBase = new ToolStripLabel();
            cbxtoolStripSelectDataBase = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            SelectObjectType = new ToolStripLabel();
            toolStripSelectObjectType = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            lbltoolStriplblSelectTable = new ToolStripLabel();
            cbxtoolStripSelectObejct = new ToolStripComboBox();
            toolStripSeparator3 = new ToolStripSeparator();
            sbtntoolStripComandType = new ToolStripSplitButton();
            toolStripButtonSelectAll = new ToolStripButton();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripButtonSaveConfig = new ToolStripButton();
            toolStripButtonLoadConifg = new ToolStripButton();
            tabPageSetting = new TabPage();
            tableLayoutPanel1 = new TableLayoutPanel();
            propertyGridSetting = new PropertyGrid();
            toolStripTop = new ToolStrip();
            toolStripButtonSaveCodeGenerateConifg = new ToolStripButton();
            toolStripButtonSaveAs = new ToolStripButton();
            toolStripButtonLoadConfig = new ToolStripButton();
            toolStripButtonConfigMygeneration = new ToolStripButton();
            btnSaveSetting = new Button();
            saveFileDialogInputUIConfig = new SaveFileDialog();
            openFileDialogInputUIConfig = new OpenFileDialog();
            openFileDialogConfig = new OpenFileDialog();
            saveFileDialogConfig = new SaveFileDialog();
            tbcMain.SuspendLayout();
            tabPageSingleCode.SuspendLayout();
            tableLayoutPanelFieldList.SuspendLayout();
            panelMain.SuspendLayout();
            ((ISupportInitialize) (dataGridViewField)).BeginInit();
            panelTop.SuspendLayout();
            toolStripSingleCodeCommandList.SuspendLayout();
            tabPageSetting.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            toolStripTop.SuspendLayout();
            SuspendLayout();
            // 
            // tbcMain
            // 
            tbcMain.Controls.Add(tabPageSingleCode);
            tbcMain.Controls.Add(tabPageSetting);
            tbcMain.Dock = DockStyle.Fill;
            tbcMain.ImeMode = ImeMode.NoControl;
            tbcMain.Location = new Point(0, 0);
            tbcMain.Name = "tbcMain";
            tbcMain.SelectedIndex = 0;
            tbcMain.Size = new Size(1050, 558);
            tbcMain.TabIndex = 3;
            tbcMain.TabStop = false;
            // 
            // tabPageSingleCode
            // 
            tabPageSingleCode.Controls.Add(tableLayoutPanelFieldList);
            tabPageSingleCode.Location = new Point(4, 22);
            tabPageSingleCode.Name = "tabPageSingleCode";
            tabPageSingleCode.Size = new Size(1042, 532);
            tabPageSingleCode.TabIndex = 2;
            tabPageSingleCode.Text = "片段代码生成";
            tabPageSingleCode.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanelFieldList
            // 
            tableLayoutPanelFieldList.ColumnCount = 1;
            tableLayoutPanelFieldList.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanelFieldList.Controls.Add(panelMain, 0, 1);
            tableLayoutPanelFieldList.Controls.Add(panelTop, 0, 0);
            tableLayoutPanelFieldList.Dock = DockStyle.Fill;
            tableLayoutPanelFieldList.Location = new Point(0, 0);
            tableLayoutPanelFieldList.Name = "tableLayoutPanelFieldList";
            tableLayoutPanelFieldList.RowCount = 2;
            tableLayoutPanelFieldList.RowStyles.Add(new RowStyle(SizeType.Absolute, 32F));
            tableLayoutPanelFieldList.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanelFieldList.Size = new Size(1042, 532);
            tableLayoutPanelFieldList.TabIndex = 3;
            // 
            // panelMain
            // 
            panelMain.Controls.Add(dataGridViewField);
            panelMain.Dock = DockStyle.Fill;
            panelMain.Location = new Point(3, 35);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1036, 494);
            panelMain.TabIndex = 0;
            // 
            // dataGridViewField
            // 
            dataGridViewField.AllowUserToAddRows = false;
            dataGridViewField.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewField.Columns.AddRange(new DataGridViewColumn[]
                                                   {
                                                       colIsSelect,
                                                       colFieldName,
                                                       colFieldNameCn,
                                                       colLanguageType,
                                                       colSize,
                                                       colIsAutoKey,
                                                       colInputType,
                                                       colDefaultValue,
                                                       colIsReqiured,
                                                       colSelectItem,
                                                       colIndexName
                                                   });
            dataGridViewField.Dock = DockStyle.Fill;
            dataGridViewField.Location = new Point(0, 0);
            dataGridViewField.Name = "dataGridViewField";
            dataGridViewField.RowTemplate.Height = 23;
            dataGridViewField.Size = new Size(1036, 494);
            dataGridViewField.TabIndex = 4;
            dataGridViewField.CellValueChanged += new DataGridViewCellEventHandler(dataGridViewField_CellValueChanged);
            dataGridViewField.DataError +=new DataGridViewDataErrorEventHandler(dataGridViewField_DataError);
            // 
            // colIsSelect
            // 
            colIsSelect.DataPropertyName = "IsSelect";
            colIsSelect.FillWeight = 50F;
            colIsSelect.HeaderText = "选择";
            colIsSelect.Name = "colIsSelect";
            colIsSelect.Width = 50;
            // 
            // colFieldName
            // 
            colFieldName.DataPropertyName = "FieldName";
            colFieldName.HeaderText = "列名";
            colFieldName.Name = "colFieldName";
            colFieldName.ReadOnly = true;
            // 
            // colFieldNameCn
            // 
            colFieldNameCn.DataPropertyName = "FieldNameCn";
            colFieldNameCn.HeaderText = "显示名";
            colFieldNameCn.Name = "colFieldNameCn";
            // 
            // colLanguageType
            // 
            colLanguageType.DataPropertyName = "LanguageType";
            colLanguageType.FillWeight = 80F;
            colLanguageType.HeaderText = "数据类型";
            colLanguageType.Name = "colLanguageType";
            colLanguageType.ReadOnly = true;
            colLanguageType.Width = 80;
            // 
            // colSize
            // 
            colSize.DataPropertyName = "Size";
            colSize.FillWeight = 60F;
            colSize.HeaderText = "大小";
            colSize.Name = "colSize";
            colSize.ReadOnly = true;
            colSize.Width = 60;
            // 
            // colIsAutoKey
            // 
            colIsAutoKey.DataPropertyName = "IsAutoKey";
            colIsAutoKey.FillWeight = 60F;
            colIsAutoKey.HeaderText = "主键";
            colIsAutoKey.Name = "colIsAutoKey";
            colIsAutoKey.ReadOnly = true;
            colIsAutoKey.Resizable = DataGridViewTriState.True;
            colIsAutoKey.SortMode = DataGridViewColumnSortMode.Automatic;
            colIsAutoKey.Width = 60;
            // 
            // colInputType
            // 
            colInputType.DataPropertyName = "InputType";
            colInputType.FillWeight = 120F;
            colInputType.HeaderText = "输入控件类型";
            colInputType.Name = "colInputType";
            colInputType.Width = 120;
            // 
            // colDefaultValue
            // 
            colDefaultValue.DataPropertyName = "DefaultValue";
            colDefaultValue.HeaderText = "默认值";
            colDefaultValue.Name = "colDefaultValue";
            // 
            // colIsReqiured
            // 
            colIsReqiured.DataPropertyName = "IsReqiured";
            colIsReqiured.FillWeight = 40F;
            colIsReqiured.HeaderText = "必填";
            colIsReqiured.Name = "colIsReqiured";
            colIsReqiured.Width = 40;
            // 
            // colSelectItem
            // 
            colSelectItem.DataPropertyName = "Items";
            colSelectItem.FillWeight = 290F;
            colSelectItem.HeaderText = "选项";
            colSelectItem.Name = "colSelectItem";
            colSelectItem.Width = 290;
            // 
            // colIndexName
            // 
            colIndexName.DataPropertyName = "DbColumnName";
            colIndexName.HeaderText = "数据列名";
            colIndexName.Name = "colIndexName";
            colIndexName.ReadOnly = true;
            colIndexName.Visible = false;
            // 
            // panelTop
            // 
            panelTop.Controls.Add(toolStripSingleCodeCommandList);
            panelTop.Dock = DockStyle.Fill;
            panelTop.Location = new Point(3, 3);
            panelTop.Name = "panelTop";
            panelTop.Size = new Size(1036, 26);
            panelTop.TabIndex = 1;
            // 
            // toolStripSingleCodeCommandList
            // 
            toolStripSingleCodeCommandList.Items.AddRange(new ToolStripItem[]
                                                              {
                                                                  lblToolStripSelectDataBase,
                                                                  cbxtoolStripSelectDataBase,
                                                                  toolStripSeparator1,
                                                                  SelectObjectType,
                                                                  toolStripSelectObjectType,
                                                                  toolStripSeparator2,
                                                                  lbltoolStriplblSelectTable,
                                                                  cbxtoolStripSelectObejct,
                                                                  toolStripSeparator3,
                                                                  sbtntoolStripComandType,
                                                                  toolStripButtonSelectAll,
                                                                  toolStripSeparator4,
                                                                  toolStripButtonSaveConfig,
                                                                  toolStripButtonLoadConifg
                                                              });
            toolStripSingleCodeCommandList.Location = new Point(0, 0);
            toolStripSingleCodeCommandList.Name = "toolStripSingleCodeCommandList";
            toolStripSingleCodeCommandList.Size = new Size(1036, 25);
            toolStripSingleCodeCommandList.TabIndex = 1;
            toolStripSingleCodeCommandList.Text = "toolStrip1";
            // 
            // lblToolStripSelectDataBase
            // 
            lblToolStripSelectDataBase.Name = "lblToolStripSelectDataBase";
            lblToolStripSelectDataBase.Size = new Size(55, 22);
            lblToolStripSelectDataBase.Text = "数据库：";
            // 
            // cbxtoolStripSelectDataBase
            // 
            cbxtoolStripSelectDataBase.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxtoolStripSelectDataBase.Name = "cbxtoolStripSelectDataBase";
            cbxtoolStripSelectDataBase.Size = new Size(200, 25);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // SelectObjectType
            // 
            SelectObjectType.Name = "SelectObjectType";
            SelectObjectType.Size = new Size(70, 22);
            SelectObjectType.Text = " 对象类型：";
            // 
            // toolStripSelectObjectType
            // 
            toolStripSelectObjectType.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripSelectObjectType.Items.AddRange(new object[]
                                                         {
                                                             "表",
                                                             "视图"
                                                         });
            toolStripSelectObjectType.Name = "toolStripSelectObjectType";
            toolStripSelectObjectType.Size = new Size(60, 25);
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // lbltoolStriplblSelectTable
            // 
            lbltoolStriplblSelectTable.Name = "lbltoolStriplblSelectTable";
            lbltoolStriplblSelectTable.Size = new Size(43, 22);
            lbltoolStriplblSelectTable.Text = "对象：";
            // 
            // cbxtoolStripSelectObejct
            // 
            cbxtoolStripSelectObejct.DropDownStyle = ComboBoxStyle.DropDownList;
            cbxtoolStripSelectObejct.DropDownWidth = 150;
            cbxtoolStripSelectObejct.Name = "cbxtoolStripSelectObejct";
            cbxtoolStripSelectObejct.Size = new Size(200, 25);
            cbxtoolStripSelectObejct.SelectedIndexChanged +=
                new EventHandler(cbxtoolStripSelectObejct_SelectedIndexChanged);
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // sbtntoolStripComandType
            // 
            sbtntoolStripComandType.DisplayStyle = ToolStripItemDisplayStyle.Text;
            sbtntoolStripComandType.ImageTransparentColor = Color.Magenta;
            sbtntoolStripComandType.Name = "sbtntoolStripComandType";
            sbtntoolStripComandType.Size = new Size(71, 22);
            sbtntoolStripComandType.Text = "选择操作";
            sbtntoolStripComandType.DropDownItemClicked +=
                new ToolStripItemClickedEventHandler(sbtntoolStripComandType_DropDownItemClicked);
            // 
            // toolStripButtonSelectAll
            // 
            toolStripButtonSelectAll.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonSelectAll.ImageTransparentColor = Color.Magenta;
            toolStripButtonSelectAll.Name = "toolStripButtonSelectAll";
            toolStripButtonSelectAll.Size = new Size(35, 22);
            toolStripButtonSelectAll.Text = "全选";
            toolStripButtonSelectAll.Click += new EventHandler(toolStripButtonSelectAll_Click);
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // toolStripButtonSaveConfig
            // 
            toolStripButtonSaveConfig.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonSaveConfig.ImageTransparentColor = Color.Magenta;
            toolStripButtonSaveConfig.Name = "toolStripButtonSaveConfig";
            toolStripButtonSaveConfig.Size = new Size(59, 22);
            toolStripButtonSaveConfig.Text = "保存配置";
            toolStripButtonSaveConfig.Click += new EventHandler(toolStripButtonSaveConfig_Click);
            // 
            // toolStripButtonLoadConifg
            // 
            toolStripButtonLoadConifg.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonLoadConifg.ImageTransparentColor = Color.Magenta;
            toolStripButtonLoadConifg.Name = "toolStripButtonLoadConifg";
            toolStripButtonLoadConifg.Size = new Size(59, 22);
            toolStripButtonLoadConifg.Text = "载入配置";
            toolStripButtonLoadConifg.Click += new EventHandler(toolStripButtonLoadConifg_Click);
            // 
            // tabPageSetting
            // 
            tabPageSetting.Controls.Add(tableLayoutPanel1);
            tabPageSetting.Controls.Add(btnSaveSetting);
            tabPageSetting.Location = new Point(4, 22);
            tabPageSetting.Name = "tabPageSetting";
            tabPageSetting.Padding = new Padding(3);
            tabPageSetting.Size = new Size(1042, 532);
            tabPageSetting.TabIndex = 1;
            tabPageSetting.Text = "配置设置";
            tabPageSetting.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(propertyGridSetting, 0, 1);
            tableLayoutPanel1.Controls.Add(toolStripTop, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 27F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1036, 526);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // propertyGridSetting
            // 
            propertyGridSetting.Dock = DockStyle.Fill;
            propertyGridSetting.Location = new Point(3, 30);
            propertyGridSetting.Name = "propertyGridSetting";
            propertyGridSetting.Size = new Size(1030, 493);
            propertyGridSetting.TabIndex = 1;
            // 
            // toolStripTop
            // 
            toolStripTop.Items.AddRange(new ToolStripItem[]
                                            {
                                                toolStripButtonSaveCodeGenerateConifg,
                                                toolStripButtonSaveAs,
                                                toolStripButtonLoadConfig,
                                                toolStripButtonConfigMygeneration
                                            });
            toolStripTop.Location = new Point(0, 0);
            toolStripTop.Name = "toolStripTop";
            toolStripTop.Size = new Size(1036, 25);
            toolStripTop.TabIndex = 2;
            toolStripTop.Text = "toolStrip1";
            toolStripTop.ItemClicked += new ToolStripItemClickedEventHandler(toolStripTop_ItemClicked);
            // 
            // toolStripButtonSaveCodeGenerateConifg
            // 
            toolStripButtonSaveCodeGenerateConifg.Image = WinResource.Save;
            toolStripButtonSaveCodeGenerateConifg.ImageTransparentColor = Color.Magenta;
            toolStripButtonSaveCodeGenerateConifg.Name = "toolStripButtonSaveCodeGenerateConifg";
            toolStripButtonSaveCodeGenerateConifg.Size = new Size(111, 22);
            toolStripButtonSaveCodeGenerateConifg.Text = "保存为默认配置";
            // 
            // toolStripButtonSaveAs
            // 
            toolStripButtonSaveAs.Image = WinResource.Save;
            toolStripButtonSaveAs.ImageTransparentColor = Color.Magenta;
            toolStripButtonSaveAs.Name = "toolStripButtonSaveAs";
            toolStripButtonSaveAs.Size = new Size(87, 22);
            toolStripButtonSaveAs.Text = "配置另存为";
            // 
            // toolStripButtonLoadConfig
            // 
            toolStripButtonLoadConfig.Image = WinResource.open;
            toolStripButtonLoadConfig.ImageTransparentColor = Color.Magenta;
            toolStripButtonLoadConfig.Name = "toolStripButtonLoadConfig";
            toolStripButtonLoadConfig.Size = new Size(75, 22);
            toolStripButtonLoadConfig.Text = "加载配置";
            // 
            // toolStripButtonConfigMygeneration
            // 
            toolStripButtonConfigMygeneration.Image = WinResource.setting;
            toolStripButtonConfigMygeneration.ImageTransparentColor = Color.Magenta;
            toolStripButtonConfigMygeneration.Name = "toolStripButtonConfigMygeneration";
            toolStripButtonConfigMygeneration.Size = new Size(118, 22);
            toolStripButtonConfigMygeneration.Text = "配置MyGeneration";
            // 
            // btnSaveSetting
            // 
            btnSaveSetting.Location = new Point(851, 483);
            btnSaveSetting.Name = "btnSaveSetting";
            btnSaveSetting.Size = new Size(75, 25);
            btnSaveSetting.TabIndex = 4;
            btnSaveSetting.Text = "保存设置";
            btnSaveSetting.UseVisualStyleBackColor = true;
            // 
            // openFileDialogInputUIConfig
            // 
            openFileDialogInputUIConfig.FileName = "openFileDialog1";
            // 
            // openFileDialogConfig
            // 
            openFileDialogConfig.DefaultExt = "dat";
            openFileDialogConfig.Filter = "代码生成配置文件 (*.dat)|*.dat";
            // 
            // saveFileDialogConfig
            // 
            saveFileDialogConfig.DefaultExt = "dat";
            saveFileDialogConfig.Filter = "代码生成配置文件 (*.dat)|*.dat";
            // 
            // BaseSingleObjectSelectorForm
            // 
            ClientSize = new Size(1050, 558);
            Controls.Add(tbcMain);
            Name = "BaseSingleObjectSelectorForm";
            Load += new EventHandler(BaseSingleObjectSelectorForm_Load);
            tbcMain.ResumeLayout(false);
            tabPageSingleCode.ResumeLayout(false);
            tableLayoutPanelFieldList.ResumeLayout(false);
            panelMain.ResumeLayout(false);
            ((ISupportInitialize) (dataGridViewField)).EndInit();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            toolStripSingleCodeCommandList.ResumeLayout(false);
            toolStripSingleCodeCommandList.PerformLayout();
            tabPageSetting.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            toolStripTop.ResumeLayout(false);
            toolStripTop.PerformLayout();
            ResumeLayout(false);
        }

        private void dataGridViewField_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
 
        }


        private void BaseSingleObjectSelectorForm_Load(object sender, EventArgs e)
        {
            BindDataBase(myMeta.DefaultDatabase, cbxtoolStripSelectDataBase.ComboBox, cbxtoolStripSelectObejct.ComboBox);

            toolStripSelectObjectType.SelectedIndex = 0;

            SortedList<string, string> hb = GetDropDownList();

            for (int i = 0; i < hb.Count; i++)
            {
                ToolStripItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = "ToolStripMenuItem" + hb.Keys[i];
                toolStripMenuItem.Size = new Size(194, 22);
                toolStripMenuItem.Text = hb.Values[i];
                sbtntoolStripComandType.DropDownItems.Add(toolStripMenuItem);
            }

            config = DefaultConfig;

            GetSetting();

            propertyGridSetting.SelectedObject = config;
        }

        private void BindDataBase(IDatabase selectDatabase, ComboBox cmxdb, ListControl listtb)
        {
            cmxdb.DataSource = myMeta.Databases;
            cmxdb.DisplayMember = "Name";

            if (selectDatabase != null)
            {
                cmxdb.SelectedIndex = cmxdb.FindStringExact(selectDatabase.Name);
            }

            BindTable(selectDatabase, listtb);
        }

        private void BindTable(IDatabase selectDatabase, ListControl listtb)
        {
            if (selectDatabase != null)
            {
                listtb.DataSource = selectDatabase.Tables;
                listtb.DisplayMember = "Name";
                listtb.SelectedIndex = 0;
            }
        }

        private void cbxtoolStripSelectObejct_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridViewField.AutoGenerateColumns = false;
            var tb = cbxtoolStripSelectObejct.ComboBox.SelectedValue as ITable;

            TableUIGenerationParams[] tableUIGenerationParamsListArray = BuildDefaultTableUiGenerationParams(tb);

            dataGridViewField.DataSource = tableUIGenerationParamsListArray;
        }

        private TableUIGenerationParams[] BuildDefaultTableUiGenerationParams(ITable tb)
        {
            List<TableUIGenerationParams> tableUIGenerationParamsList = new List<TableUIGenerationParams>();

            foreach (IColumn column in tb.Columns)
            {
                var tableUIGenerationParams = new TableUIGenerationParams();

                tableUIGenerationParams.IsSelect = true;
                tableUIGenerationParams.FieldName = column.Name.Trim().Replace("_", "");

                tableUIGenerationParams.FieldNameCn =
                    TableGenerationHelper.GetNameFromDescription(column.Description.Trim(),
                                                                 column.Name.Trim().Replace("_", "").Trim());

                tableUIGenerationParams.LanguageType = column.LanguageType;
                tableUIGenerationParams.Size = column.CharacterMaxLength;
                tableUIGenerationParams.IsAutoKey = column.IsAutoKey;

                if (config is NHibernateFrameworkWebUIGenerateConfig)
                {
                    NHibernateFrameworkWebUIGenerateConfig nconfig = config as NHibernateFrameworkWebUIGenerateConfig;
                    nconfig.SetColumnParams(column, tableUIGenerationParams);
                }


                tableUIGenerationParams.IsReqiured = !column.IsNullable;
                tableUIGenerationParams.DefaultValue = column.Default;
                tableUIGenerationParams.DbColumnName = column.Name;
                tableUIGenerationParamsList.Add(tableUIGenerationParams);
            }

            return tableUIGenerationParamsList.ToArray();
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
                var defaultProperties = new DefaultProperties();
                defaultProperties.ShowDialog();
            }
            else if (e.ClickedItem.Name == "toolStripButtonSaveAs")
            {
                if (saveFileDialogConfig.ShowDialog() == DialogResult.OK)
                {
                    SerializableHelper.BinarySerializeObjectByPath<T>(saveFileDialogConfig.FileName,
                                                                      config);
                }
            }
            else if (e.ClickedItem.Name == "toolStripButtonLoadConfig")
            {
                if (openFileDialogConfig.ShowDialog() == DialogResult.OK)
                {
                    config = SerializableHelper.BinaryDeserializeObjectByPath(openFileDialogConfig.FileName,
                                                                              DefaultConfig);
                    propertyGridSetting.SelectedObject = config;
                }
            }
        }
    }
}