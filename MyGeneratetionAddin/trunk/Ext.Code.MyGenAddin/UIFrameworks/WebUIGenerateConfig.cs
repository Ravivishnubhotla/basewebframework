using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using MyMeta;

namespace Legendigital.Code.MyGenAddin.UIFrameworks
{
    [Serializable]
    public class WebUIGenerateConfig
    {
        public enum UIType { AspNet, AspNetWithAjaxToolKit, RadTelerik, Extjs }

        private string _tableRowLableCss;
        private string _tableRowInputCss;
        private string _tableCss;
        private string _listPageNameFormat;
        private string _addPageNameFormat;
        private string _editPageNameFormat;
        private string _viewPageNameFormat;
        private string _idKeyName;
        private string _ajaxControlPrex;
        private string _validGroup;
        private bool _generateKeyLableForm;
        private string _headText;
        private string _formTitle;
        private string _inputTootip;
        private string _validateInfo;
        private string _wrapperClassNameFormat;
        private string _UCControlClassNameFormat;
        private string _defaultDatabaseName;
        private string _gridControlNameFormat;
        private string _HeaderUCTagName;
        private string _toolBarControlNameFormat;


        [Category("[界面元素命名规范]"), ReadOnly(false), Description("[命名规范]-[工具栏控件命名]"), Browsable(true)]
        public string ToolBarControlNameFormat
        {
            get { return _toolBarControlNameFormat; }
            set { _toolBarControlNameFormat = value; }
        }
        [Category("[界面元素命名规范]"), ReadOnly(false), Description("[命名规范]-[表格控件命名]"), Browsable(true)]
        public string GridControlNameFormat
        {
            get { return _gridControlNameFormat; }
            set { _gridControlNameFormat = value; }
        }





        [Category("[录入界面设置]"), ReadOnly(false), Description("[显示信息设置]-[界面HeadText]"), Browsable(true)]
        public string HeadText
        {
            get { return _headText; }
            set { _headText = value; }
        }
        [Category("[录入界面设置]"), ReadOnly(false), Description("[显示信息设置]-[表单标题]"), Browsable(true)]
        public string FormTitle
        {
            get { return _formTitle; }
            set { _formTitle = value; }
        }
        [Category("[录入界面设置]"), ReadOnly(false), Description("[显示信息设置]-[录入表单提示信息]"), Browsable(true)]
        public string InputTootip
        {
            get { return _inputTootip; }
            set { _inputTootip = value; }
        }
        [Category("[录入界面设置]"), ReadOnly(false), Description("[显示信息设置]-[验证控件提示信息]"), Browsable(true)]
        public string ValidateInfo
        {
            get { return _validateInfo; }
            set { _validateInfo = value; }
        }


        [Category("[录入界面设置]"), ReadOnly(false), Description("[界面选项]-【是否为主键生成Label项】"), Browsable(true)]
        public bool GenerateKeyLableForm
        {
            get { return _generateKeyLableForm; }
            set { _generateKeyLableForm = value; }
        }

        [Category("[录入界面设置]"), ReadOnly(false), Description("[界面样式设置]-[录入表单标签项样式]"), Browsable(true)]
        public string TableRowLableCss
        {
            get { return _tableRowLableCss; }
            set { _tableRowLableCss = value; }
        }
        [Category("[录入界面设置]"), ReadOnly(false), Description("[界面样式设置]-[录入表单输入项样式]"), Browsable(true)]
        public string TableRowInputCss
        {
            get { return _tableRowInputCss; }
            set { _tableRowInputCss = value; }
        }
        [Category("[录入界面设置]"), ReadOnly(false), Description("[界面样式设置]-[录入表单样式]"), Browsable(true)]
        public string TableCss
        {
            get { return _tableCss; }
            set { _tableCss = value; }
        }
        [Category("[录入界面设置]"), ReadOnly(false), Description("[命名规范]-[表单验证组名]"), Browsable(true)]
        public string ValidGroup
        {
            get { return _validGroup; }
            set { _validGroup = value; }
        }


        [Category("[总体代码设置]"), ReadOnly(false), Description("[用户控件命名]-[用户控件前缀]"), Browsable(true)]
        public string UcControlClassNameFormat
        {
            get { return _UCControlClassNameFormat; }
            set { _UCControlClassNameFormat = value; }
        }

        [Category("[总体代码设置]"), ReadOnly(false), Description("[页面命名]-列表页面命名规范]"), Browsable(true)]
        public string ListPageNameFormat
        {
            get { return _listPageNameFormat; }
            set { _listPageNameFormat = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[页面命名]-添加页面命名规范]"), Browsable(true)]
        public string AddPageNameFormat
        {
            get { return _addPageNameFormat; }
            set { _addPageNameFormat = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[页面命名]-编辑页面命名规范]"), Browsable(true)]
        public string EditPageNameFormat
        {
            get { return _editPageNameFormat; }
            set { _editPageNameFormat = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[页面命名]-查看页面命名规范]"), Browsable(true)]
        public string ViewPageNameFormat
        {
            get { return _viewPageNameFormat; }
            set { _viewPageNameFormat = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[命名规范]-[主键Key命名规范]"), Browsable(true)]
        public string IdKeyName
        {
            get { return _idKeyName; }
            set { _idKeyName = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[命名规范]-[AjaxControl注册前缀]"), Browsable(true)]
        public string AjaxControlPrex
        {
            get { return _ajaxControlPrex; }
            set { _ajaxControlPrex = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[数据库设置]-[默认数据库名]"), Browsable(true)]
        public string DefaultDatabaseName
        {
            get { return _defaultDatabaseName; }
            set { _defaultDatabaseName = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[命名规范]-[业务包装类名]"), Browsable(true)]
        public string WrapperClassNameFormat
        {
            get { return _wrapperClassNameFormat; }
            set { _wrapperClassNameFormat = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[命名规范]-[Header用户控件注册标签名]"), Browsable(true)]
        public string HeaderUcTagName
        {
            get { return _HeaderUCTagName; }
            set { _HeaderUCTagName = value; }
        }

        private UIType _UIType = UIType.AspNet;

        [Category("[总体代码设置]"), ReadOnly(false), Description("[控件设置]-[控件类型]"), Browsable(true)]
        public UIType UI_Type
        {
            get { return _UIType; }
            set { _UIType = value; }
        }



        public const string AspBeginTaget = "<%";
        public const string AspEndTaget = "%>";

        public string GenerateMoudleValidateGroupName(ITable table)
        {
            return string.Format(this.ValidGroup, GenerateMoudleCodeName(table));
        }
        public string GenerateMoudleHeadText(ITable table, string operatorName)
        {
            return string.Format(this.HeadText, GenerateMoudleDisplayName(table), operatorName);
        }

        public string GenerateMoudleFormTitle(ITable table)
        {
            return string.Format(this.FormTitle, GenerateMoudleDisplayName(table));
        }

        public string GetFieldInputUIID(TableUIGenerationParams column)
        {
            return column.InputUIControlType.ControlIDFormat.Replace("{$PName}", column.FieldName );
        }

        public string GenerateFieldInputTooltip(TableUIGenerationParams column)
        {
            return string.Format(this.InputTootip, column.FieldNameCn);
        }

        public string GenerateFieldValidateInfo(TableUIGenerationParams column)
        {
            return string.Format(this.ValidateInfo, column.FieldNameCn);
        }

        public string GenerateMoudleCodeName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, "{0}", StringCase.PascalCase, "");
        }
        public string GenerateMoudleDisplayName(ITable table)
        {
            if (!string.IsNullOrEmpty(table.Description) && !string.IsNullOrEmpty(table.Description.Trim()))
                return table.Description.Trim();

            return TableGenerationHelper.GenerateNameByTable(table, "{0}", StringCase.PascalCase, "");
        }

        public string GenerateWrapperClassMame(ITable table, string fiterNames)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.WrapperClassNameFormat, StringCase.PascalCase, fiterNames);
        }

        public string GetOperatorPageUrl(ITable table, string operatorName)
        {
            return TableGenerationHelper.GenerateNameByTable(table, "{0}" + operatorName + "Page.aspx", StringCase.PascalCase, "");
        }

        public string GetOperatorPageClassName(ITable table, string operatorName)
        {
            return TableGenerationHelper.GenerateNameByTable(table, "{0}" + operatorName + "Page", StringCase.PascalCase, "");
        }

        public string GetOperatorUCControlClassName(ITable table, string operatorName)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.UcControlClassNameFormat + operatorName, StringCase.PascalCase, "");
        }

        public string GetRadGridControlName(ITable table)
        {
            return string.Format(this.GridControlNameFormat, GenerateMoudleCodeName(table));
        }

        public string GetPkProprtyName(ITable table)
        {
            return TableColumnGenerationHelper.GeneratePorpertyNameByTableColumn(table.PrimaryKeys[0]);
        }

        public string GetPkQueryString(ITable table)
        {
            return GetPkQueryKey(table) + "={0}";
        }

        public string GetPkQueryKey(ITable table)
        {
            return string.Format(this.IdKeyName, TableColumnGenerationHelper.GeneratePorpertyNameByTableColumn(table.PrimaryKeys[0]));
        }




        public List<InputUIControl> GetUIFieldType()
        {
            List<InputUIControl> ius = new List<InputUIControl>();
            switch (UI_Type)
            {
                case UIType.AspNet:
                case UIType.AspNetWithAjaxToolKit:
                    AddInputUI(ius, "TextBox", true, true, false, "string", "txt{$PName}", "Text");
                    AddInputUI(ius, "TextBoxMultiLine", true, true, false, "string", "txt{$PName}", "Text");
                    AddInputUI(ius, "HiddenField", true, true, false, "string", "hdf{$PName}", "Value");
                    AddInputUI(ius, "Label", true, false, false, "string", "lbl{$PName}", "Value");
                    AddInputUI(ius, "CheckBox", true, true, false, "bool", "chk{$PName}", "Checked");
                    AddInputUI(ius, "DropDownList", true, true, true, "string", "ddl{$PName}", "SelectedValue");
                    AddInputUI(ius, "ListBox", true, true, true, "string", "lbx{$PName}", "SelectedValue");
                    AddInputUI(ius, "CheckBoxList", true, true, true, "string", "cbl{$PName}", "SelectedValue");
                    AddInputUI(ius, "RadioButtonList", true, true, true, "string", "rbl{$PName}", "SelectedValue");
                    AddInputUI(ius, "HtmlInputText", true, true, false, "string", "txt{$PName}", "Value");
                    AddInputUI(ius, "HtmlInputTextArea", true, true, false, "string", "txt{$PName}", "Value");
                    AddInputUI(ius, "HtmlInputPassword", true, true, false, "string", "txt{$PName}", "Value");
                    AddInputUI(ius, "HtmlInputHidden", true, true, false, "string", "hid{$PName}", "Value");
                    AddInputUI(ius, "HtmlInputCheckBox", true, true, true, "bool", "chk{$PName}", "Checked");
                    AddInputUI(ius, "HtmlSelect", true, true, true, "string", "sel{$PName}", "Value");
                    break;
                case UIType.RadTelerik:
                    AddInputUI(ius, "RadTextBox", true, true, false, "string", "radtxt{$PName}", "Text");
                    AddInputUI(ius, "RadTextBoxMutilLine", true, true, false, "string", "radtxt{$PName}", "Text");
                    AddInputUI(ius, "RadComboBox", true, true, false, "string", "radcmb{$PName}", "SelectedValue");
                    AddInputUI(ius, "RadNumericTextBox", true, true, false, "int", "radnum{$PName}", "Value");
                    AddInputUI(ius, "RadDateInput", true, true, false, "DateTime", "raddateinput{$PName}", "SelectedDate");
                    AddInputUI(ius, "RadDatePicker", true, true, false, "DateTime", "raddatepick{$PName}", "SelectedDate");
                    AddInputUI(ius, "RadEditor", true, true, false, "string", "radedit{$PName}", "Content");
                    AddInputUI(ius, "RadMaskedTextBox", true, true, false, "string", "txt{$PName}", "Text");
                    AddInputUI(ius, "HiddenField", true, true, false, "string", "hdf{$PName}", "Value");
                    AddInputUI(ius, "CheckBox", true, true, false, "bool", "chk{$PName}", "Checked");
                    AddInputUI(ius, "Label", true, false, false, "string", "lbl{$PName}", "Value");
                    break;
                case UIType.Extjs:
                    AddInputUI(ius, "TextField ", true, true, false, "string", "txt{$PName}", "Text");
                    AddInputUI(ius, "TextArea ", true, true, false, "string", "txt{$PName}", "Text");
                    AddInputUI(ius, "NumberField ", true, true, false, "int", "num{$PName}", "Value");
                    AddInputUI(ius, "NumberDecimalField", true, true, false, "decimal", "num{$PName}", "Value");
                    AddInputUI(ius, "DateField", true, true, false, "DateTime", "date{$PName}", "Value");
                    AddInputUI(ius, "Checkbox", true, true, false, "bool", "chk{$PName}", "Checked");
                    break;
            }
            return ius;
        }


        public InputUIControl getInputUIControlByName(string name)
        {
            foreach (InputUIControl iuc in this.GetUIFieldType())
            {
                if (iuc.Name.Trim().ToUpper() == name.Trim().ToUpper())
                {
                    return iuc;
                }
            }
            return null;
        }


        private void AddInputUI(List<InputUIControl> ius, string name, bool canset, bool canread, bool hasitems,
                                string dataType, string controlIDFormat, string controlGetSetValuePrppertyName)
        {


            

            var iu = new InputUIControl();
            iu.Name = name;
            iu.CanSet = canset;
            iu.CanRead = canread;
            iu.HasItems = hasitems;
            iu.DataType = dataType;
            iu.ControlIDFormat = controlIDFormat;
            iu.ControlGetSetValuePrppertyName = controlGetSetValuePrppertyName;
            ius.Add(iu);
        }


        public void SetColumnParams(IColumn column, TableUIGenerationParams tableUIGenerationParams)
        {
            switch (UI_Type)
            {
                case UIType.AspNet:
                case UIType.AspNetWithAjaxToolKit:
                    if (column.LanguageType == "bool")
                    {
                        tableUIGenerationParams.InputType = "CheckBox";
                    }
                    else
                    {
                        tableUIGenerationParams.InputType = "TextBox";
                    }
                    break;
                case UIType.RadTelerik:
                    if (column.LanguageType == "string")
                    {
                        if (column.CharacterMaxLength < 2000)
                            tableUIGenerationParams.InputType = "RadTextBox";
                        else
                            tableUIGenerationParams.InputType = "RadEditor";
                    }
                    else if (column.LanguageType == "bool")
                    {
                        tableUIGenerationParams.InputType = "CheckBox";
                    }
                    else if (column.LanguageType == "DateTime")
                    {
                        tableUIGenerationParams.InputType = "RadDatePicker";
                    }
                    else if (column.LanguageType == "int")
                    {
                        tableUIGenerationParams.InputType = "RadNumericTextBox";
                    }
                    else if (column.LanguageType == "long")
                    {
                        tableUIGenerationParams.InputType = "RadNumericTextBox";
                    }
                    else if (column.LanguageType == "float")
                    {
                        tableUIGenerationParams.InputType = "RadNumericTextBox";
                    }
                    else if (column.LanguageType == "double")
                    {
                        tableUIGenerationParams.InputType = "RadNumericTextBox";
                    }
                    else if (column.LanguageType == "decimal")
                    {
                        tableUIGenerationParams.InputType = "RadNumericTextBox";
                    }
                    else
                    {
                        tableUIGenerationParams.InputType = "RadTextBox";
                    }
                    break;
                case UIType.Extjs:

                    break;
            }

        }

    }

}
