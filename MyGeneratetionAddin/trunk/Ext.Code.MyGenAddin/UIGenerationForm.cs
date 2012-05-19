using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using MyGenerationInputForm;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public abstract partial class UIGenerationForm : Form
    {
        public UIGenerationForm()
        {
            InitializeComponent();    
        }

        private UICodeGenerationConfig uiconfig;

        private const string UIConfigkey = "UI.UIConfig";

        private void AddInputUI(List<InputUIControl> ius, string name, bool canset, bool canread, bool hasitems, string dataType, string controlIDFormat, string controlGetSetValuePrppertyName)
        {
            InputUIControl iu = new InputUIControl();
            iu.Name = name;
            iu.CanSet = canset;
            iu.CanRead = canread;
            iu.HasItems = hasitems;
            iu.DataType = dataType;
            iu.ControlIDFormat = controlIDFormat;
            iu.ControlGetSetValuePrppertyName = controlGetSetValuePrppertyName;
            ius.Add(iu);
        }

        private UICodeGenerationConfig Uiconfig
        {
            get
            {
                if(uiconfig==null)
                {
                    UICodeGenerationConfig ucc = new UICodeGenerationConfig();
                    List<InputUIControl> ius = new List<InputUIControl>();
                    AddInputUI(ius, "HtmlInputText", true, true, false, "string", "txt{$PName}", "Value");
                    AddInputUI(ius, "HtmlInputPassword", true, true, false, "string", "txt{$PName}", "Value");
                    AddInputUI(ius, "HtmlInputHidden", true, true, false, "string", "hid{$PName}", "Value");
                    AddInputUI(ius, "HtmlInputTextArea", true, true, false, "string", "txt{$PName}", "Value");
                    AddInputUI(ius, "TextBox", true, true, false, "string", "txt{$PName}", "Text");
                    AddInputUI(ius, "TextBoxMultiLine", true, true, false, "string", "txt{$PName}", "Text");
                    AddInputUI(ius, "HiddenField", true, true, false, "string", "hdf{$PName}", "Value");
                    AddInputUI(ius, "Label", true, false, false, "string", "lbl{$PName}", "Value");
                    AddInputUI(ius, "CheckBox", true, true, false, "bool", "chk{$PName}", "Checked");
                    AddInputUI(ius, "HtmlInputCheckBox", true, true, true, "bool", "chk{$PName}", "Checked");
                    AddInputUI(ius, "HtmlSelect", true, true, true, "string", "sel{$PName}", "Value");
                    AddInputUI(ius, "DropDownList", true, true, true, "string", "ddl{$PName}", "SelectedValue");
                    AddInputUI(ius, "ListBox", true, true, true, "string", "lbx{$PName}", "SelectedValue");
                    AddInputUI(ius, "CheckBoxList", true, true, true, "string", "cbl{$PName}", "SelectedValue");
                    AddInputUI(ius, "RadioButtonList", true, true, true, "string", "rbl{$PName}", "SelectedValue");
                    ucc.UIControlConfigs = ius.ToArray();
                    uiconfig = SerializableHelper.XmlDeserializeObject<UICodeGenerationConfig>(UIConfigkey, ucc);
                }
                return uiconfig;
            }
        }




        public abstract SortedList<string, string> GetDropDownList();


        private void GetSetting()
        {
            return;
        }

        private void UIGenerationForm_Load(object sender, EventArgs e)
        {
            BindDataBase(this.myMeta.DefaultDatabase, this.cbxtoolStripSelectDataBase.ComboBox, this.cbxtoolStripSelectObejct.ComboBox);
            this.toolStripSelectObjectType.SelectedIndex = 0;
            SortedList<string, string> hb = GetDropDownList();
            for (int i = 0; i < hb.Count; i++)
            {
                ToolStripItem toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
                toolStripMenuItem.Name = "ToolStripMenuItem" + hb.Keys[i];
                toolStripMenuItem.Size = new System.Drawing.Size(194, 22);
                toolStripMenuItem.Text = hb.Values[i];
                sbtntoolStripComandType.DropDownItems.Add(toolStripMenuItem);
            }

            //foreach (KeyValuePair<string, string> pair in hb)
            //{
            //    ToolStripItem toolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            //    toolStripMenuItem.Name = "ToolStripMenuItem" + pair.Key;
            //    toolStripMenuItem.Size = new System.Drawing.Size(194, 22);
            //    toolStripMenuItem.Text = pair.Value;
            //    sbtntoolStripComandType.DropDownItems.Add(toolStripMenuItem);
            //}
        }


        private void BindDataBase(MyMeta.IDatabase selectDatabase, ComboBox cmxdb, ListControl listtb)
        {
            cmxdb.DataSource = this.myMeta.Databases;
            cmxdb.DisplayMember = "Name";

            if (selectDatabase != null)
            {
                cmxdb.SelectedIndex = cmxdb.FindStringExact(selectDatabase.Name);
            }

            BindTable(selectDatabase, listtb);
        }

        private void BindTable(MyMeta.IDatabase selectDatabase, ListControl listtb)
        {
            if (selectDatabase != null)
            {
                listtb.DataSource = selectDatabase.Tables;
                listtb.DisplayMember = "Name";
                listtb.SelectedIndex = 0;
            }
        }




        private void cbxtoolStripSelectDataBase_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyMeta.IDatabase database = this.cbxtoolStripSelectDataBase.ComboBox.SelectedValue as MyMeta.IDatabase;

            if (database != null)
                BindTable(database, this.cbxtoolStripSelectObejct.ComboBox);
        }

        private void cbxtoolStripSelectObejct_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridViewField.AutoGenerateColumns = false;
            MyMeta.ITable tb = this.cbxtoolStripSelectObejct.ComboBox.SelectedValue as MyMeta.ITable;

            List<TableUIGenerationParams> tableUIGenerationParamsList = new List<TableUIGenerationParams>();
            foreach (IColumn column in tb.Columns)
            {
                TableUIGenerationParams tableUIGenerationParams = new TableUIGenerationParams();

                tableUIGenerationParams.IsSelect = true;
                tableUIGenerationParams.FieldName = column.Name.Trim().Replace("_","");

                tableUIGenerationParams.FieldNameCn =
                    TableGenerationHelper.GetNameFromDescription(column.Description.Trim(), column.Name.Trim().Replace("_", "").Trim());

                tableUIGenerationParams.LanguageType = column.LanguageType;
                tableUIGenerationParams.Size = column.CharacterMaxLength;
                tableUIGenerationParams.IsAutoKey = column.IsAutoKey;
                if (column.LanguageType == "bool")
                {
                    tableUIGenerationParams.InputType = "CheckBox";
                }
                else
                {
                    tableUIGenerationParams.InputType = "TextBox";
                }
                tableUIGenerationParams.IsReqiured = !column.IsNullable;
                tableUIGenerationParams.DefaultValue = column.Default;
                tableUIGenerationParams.DbColumnName = column.Name;
                tableUIGenerationParamsList.Add(tableUIGenerationParams);
            }

            TableUIGenerationParams[] tableUIGenerationParamsListArray = new TableUIGenerationParams[tableUIGenerationParamsList.Count];

            tableUIGenerationParamsList.CopyTo(tableUIGenerationParamsListArray);

            this.dataGridViewField.DataSource = tableUIGenerationParamsListArray;
        }


        private void toolStripButtonSelectAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in this.dataGridViewField.Rows)
            {
                row.Cells["colIsSelect"].Value = true;
            }
        }



        private void toolStripButtonSaveConfig_Click(object sender, EventArgs e)
        {
            if ((this.cbxtoolStripSelectDataBase.ComboBox.SelectedIndex >= 0) && (this.cbxtoolStripSelectObejct.ComboBox.SelectedIndex >= 0))
            {
                IDatabase database = this.cbxtoolStripSelectDataBase.ComboBox.SelectedValue as IDatabase;
                ITable selectTable = this.cbxtoolStripSelectObejct.ComboBox.SelectedValue as MyMeta.ITable;

                List<TableUIGenerationParams> tableUIGenerationParamsList = null;
                if(database!=null&&selectTable!=null)
                {
                    tableUIGenerationParamsList = new List<TableUIGenerationParams>();
                    foreach (DataGridViewRow row in this.dataGridViewField.Rows)
                    {
                        TableUIGenerationParams tableUIGenerationParams = new TableUIGenerationParams();
                        tableUIGenerationParams.IsSelect = (bool)row.Cells["colIsSelect"].Value;
                        tableUIGenerationParams.FieldName = (string)row.Cells["colFieldName"].Value;
                        tableUIGenerationParams.FieldNameCn = (string)row.Cells["colFieldNameCn"].Value;
                        tableUIGenerationParams.LanguageType = (string)row.Cells["colLanguageType"].Value;
                        tableUIGenerationParams.Size = (int)row.Cells["colSize"].Value;
                        tableUIGenerationParams.IsAutoKey = (bool)row.Cells["colIsAutoKey"].Value;
                        tableUIGenerationParams.InputType = (string)row.Cells["colInputType"].Value;
                        tableUIGenerationParams.IsReqiured = (bool)row.Cells["colIsReqiured"].Value;
                        tableUIGenerationParams.DefaultValue = (string)row.Cells["colDefaultValue"].Value;
                        tableUIGenerationParams.Items = (string)row.Cells["colSelectItem"].Value;
                        tableUIGenerationParams.DbColumnName = (string)row.Cells["colIndexName"].Value;
                        tableUIGenerationParamsList.Add(tableUIGenerationParams);
                    }
                }

                FormUISetting uis = new FormUISetting();
                uis.TableName = selectTable.Name;
                uis.Items = tableUIGenerationParamsList;


                string pathKey = "Key|KilerCodeGeneration|UI|" + database.Name + "|" + selectTable.Name;

                XmlConfigReader.SetConfig<FormUISetting>(pathKey, uis, this.saveFileDialogInputUIConfig);
            }
        }


        private void dataGridViewField_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if(this.dataGridViewField.Columns[e.ColumnIndex].Name == "colSelectItem")
            {
                DataGridViewCell de = this.dataGridViewField.Rows[e.RowIndex].Cells[e.ColumnIndex];
                string emessage = "";
                if (!TableColumnGenerationHelper.validateSelectItemString((string)de.Value, out emessage))
                {
                    MessageBox.Show(emessage);
                    de.Value = "";
                }
            }
            if (this.dataGridViewField.Columns[e.ColumnIndex].Name == "colInputType")
            {
                DataGridViewCell de = this.dataGridViewField.Rows[e.RowIndex].Cells[e.ColumnIndex];
                DataGridViewCell deitem = this.dataGridViewField.Rows[e.RowIndex].Cells[dataGridViewField.Columns["colSelectItem"].Index];
                InputUIControl iuc = this.Uiconfig.getInputUIControlByName(de.Value.ToString());
                deitem.ReadOnly = !iuc.HasItems;
                if (!iuc.HasItems)
                {
                    deitem.Value = "";
                }
            }


        }

        private void GetSingleInputData(string generateType)
        {
            IDatabase database = this.cbxtoolStripSelectDataBase.ComboBox.SelectedValue as IDatabase;
            ITable selectTable = this.cbxtoolStripSelectObejct.ComboBox.SelectedValue as MyMeta.ITable;
            this.zeusInput["GenerateType"] = generateType;
            this.zeusInput["selectTable"] = selectTable;
            //this.zeusInput["codeGenerationSetting"] = this.Config;



            List<TableUIGenerationParams> tableUIGenerationParamsList = new List<TableUIGenerationParams>();
            foreach (DataGridViewRow row in this.dataGridViewField.Rows)
            {
                TableUIGenerationParams tableUIGenerationParams = new TableUIGenerationParams();
                tableUIGenerationParams.IsSelect = (bool)row.Cells["colIsSelect"].Value;
                tableUIGenerationParams.FieldName = (string)row.Cells["colFieldName"].Value;
                tableUIGenerationParams.FieldNameCn = (string)row.Cells["colFieldNameCn"].Value;
                tableUIGenerationParams.LanguageType = (string)row.Cells["colLanguageType"].Value;
                tableUIGenerationParams.Size = (int)row.Cells["colSize"].Value;
                tableUIGenerationParams.IsAutoKey = (bool)row.Cells["colIsAutoKey"].Value;
                tableUIGenerationParams.InputType = (string)row.Cells["colInputType"].Value;
                tableUIGenerationParams.IsReqiured = (bool)row.Cells["colIsReqiured"].Value;
                tableUIGenerationParams.DefaultValue = (string)row.Cells["colDefaultValue"].Value;
                tableUIGenerationParams.Items = (string)row.Cells["colSelectItem"].Value;
                tableUIGenerationParams.DbColumnName = (string)row.Cells["colIndexName"].Value;
                tableUIGenerationParamsList.Add(tableUIGenerationParams);
            }

            TableUIGenerationParams[] tableUIGenerationParamsListArray = new TableUIGenerationParams[tableUIGenerationParamsList.Count];

            tableUIGenerationParamsList.CopyTo(tableUIGenerationParamsListArray);

            this.zeusInput["TableUIGenerationParamsArray"] = tableUIGenerationParamsListArray;
        }



        private void toolStripButtonLoadConifg_Click(object sender, EventArgs e)
        {
            if ((this.cbxtoolStripSelectDataBase.ComboBox.SelectedIndex >= 0) && (this.cbxtoolStripSelectObejct.ComboBox.SelectedIndex >= 0))
            {
                if (this.openFileDialogInputUIConfig.ShowDialog() == DialogResult.OK)
                {
                    FormUISetting uis = XmlConfigReader.GetConfig<FormUISetting>(this.openFileDialogInputUIConfig.FileName);

                    IDatabase database = this.cbxtoolStripSelectDataBase.ComboBox.SelectedValue as IDatabase;

                    for (int i = 0; i < this.cbxtoolStripSelectObejct.ComboBox.Items.Count; i++)
                    {
                        ITable table = (ITable) this.cbxtoolStripSelectObejct.ComboBox.Items[i];
                        if(table.Name==uis.TableName)
                        {
                            this.cbxtoolStripSelectObejct.ComboBox.SelectedIndex = i;
                            break;
                        }


                    }

                    //foreach (object o in this.cbxtoolStripSelectObejct.ComboBox.Items)
                    //{
                    //    ITable table = (ITable) o;

                    //}

                    //this.cbxtoolStripSelectObejct.ComboBox.SelectedValue = database.Tables[uis.TableName];

                    this.dataGridViewField.DataSource = uis.Items;
                }
            }
        }

        private void sbtntoolStripComandType_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

            GetSingleInputData(e.ClickedItem.Name.Replace("ToolStripMenuItem", ""));
            this.zeusInput["Uiconfig"] = this.Uiconfig;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }



    }
}