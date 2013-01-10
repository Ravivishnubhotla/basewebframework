using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{

    public enum UIType { AspNet, AspNetWithEasyUI, ExtNet}

    [Serializable]
    public class UICodeGenerationConfig
    {
        private InputUIControl[] uIConfigs;
        [XmlArrayItem]
        public InputUIControl[] UIControlConfigs
        {
            get { return uIConfigs; }
            set { uIConfigs = value; }
        }
 
        private string _tableRowLableCss;
        private string _tableRowInputCss;
        private string _tableCss;
        private string _listPageNameFormat;
        private string _addPageNameFormat;
        private string _editPageNameFormat;
        private string _viewPageNameFormat;
        private string _idKeyName;
        private string _validGroup;
        private bool _generateKeyLableForm;
        private string _headText;
        private string _formTitle;
        private string _inputTootip;
        private string _validateInfo;
        private string _wrapperClassNameFormat;
        private string _entityClassNameFormat;
        private string _defaultDatabaseName;
        private string _tablePreFix;

        private string _HeaderUCTagName;
        private string _webProjectRootPath;
        private string _webPageNameSpace;

        private string _gridControlNameFormat;
        [Category("[列表界面设置]"), ReadOnly(false), Description("[命名规范]-[表格控件命名]"), Browsable(true)]
        public string GridControlNameFormat
        {
            get { return _gridControlNameFormat; }
            set { _gridControlNameFormat = value; }
        }
        private string _pageControlNameFormat;
        [Category("[列表界面设置]"), ReadOnly(false), Description("[命名规范]-[分页控件命名]"), Browsable(true)]
        public string PageControlNameFormat
        {
            get { return _pageControlNameFormat; }
            set { _pageControlNameFormat = value; }
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
        [Category("[总体代码设置]"), ReadOnly(false), Description("[数据库设置]-[默认数据库名]"), Browsable(true)]
        public string DefaultDatabaseName
        {
            get { return _defaultDatabaseName; }
            set { _defaultDatabaseName = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[命名规范]-[BLL类名]"), Browsable(true)]
        public string WrapperClassNameFormat
        {
            get { return _wrapperClassNameFormat; }
            set { _wrapperClassNameFormat = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[命名规范]-[业务实体类名]"), Browsable(true)]
        public string EntityClassNameFormat
        {
            get { return _entityClassNameFormat; }
            set { _entityClassNameFormat = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[命名规范]-[表名前缀]"), Browsable(true)]
        public string TablePreFix
        {
            get { return _tablePreFix; }
            set { _tablePreFix = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[命名规范]-[Web项目根目录]"), Browsable(true)]
        public string WebProjectRootPath
        {
            get { return _webProjectRootPath; }
            set { _webProjectRootPath = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("[命名规范]-[Web项目名称空间"), Browsable(true)]
        public string WebPageNameSpace
        {
            get { return _webPageNameSpace; }
            set { _webPageNameSpace = value; }
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
            return TableGenerationHelper.GenerateNameByTable(table, "{0}", StringCase.PascalCase, TablePreFix);
        }
        public string GenerateMoudleDisplayName(ITable table)
        {
            if (!string.IsNullOrEmpty(table.Description) && !string.IsNullOrEmpty(table.Description.Trim()))
                return table.Description.Trim();

            return TableGenerationHelper.GenerateNameByTable(table, "{0}", StringCase.PascalCase, TablePreFix);
        }

        public string GenerateWrapperClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.WrapperClassNameFormat, StringCase.PascalCase, TablePreFix);
        }

        public string GenerateEntityClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.EntityClassNameFormat, StringCase.PascalCase, TablePreFix);
        }


        public string GetAddPageUrl(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.AddPageNameFormat + "", StringCase.PascalCase, TablePreFix);
        }
        public string GetEditPageUrl(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.EditPageNameFormat + "", StringCase.PascalCase, TablePreFix);
        }
        public string GetViewrPageUrl(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.ViewPageNameFormat + "", StringCase.PascalCase, TablePreFix);
        }
        public string GetListPageUrl(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.ListPageNameFormat + "", StringCase.PascalCase, TablePreFix);
        }

        public string GetOperatorPageUrl(ITable table, string operatorName)
        {
            return TableGenerationHelper.GenerateNameByTable(table, "{0}" + operatorName + "Page.aspx", StringCase.PascalCase, TablePreFix);
        }

        public string GetOperatorPageClassName(ITable table, string operatorName)
        {
            return TableGenerationHelper.GenerateNameByTable(table, "{0}" + operatorName + "Page", StringCase.PascalCase, TablePreFix);
        }

        public string GetPageControlName(ITable table)
        {
            return string.Format(this.PageControlNameFormat, GenerateMoudleCodeName(table));
        }
        public string GetGridControlName(ITable table)
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

        public List<InputUIControl> GetUIFieldType()
        {
            List<InputUIControl> ius = new List<InputUIControl>();
            switch (UI_Type)
            {
                case UIType.AspNet:
                case UIType.AspNetWithEasyUI:
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
            }
            return ius;
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
                case UIType.AspNetWithEasyUI:
                    if (column.LanguageType == "bool")
                    {
                        tableUIGenerationParams.InputType = "CheckBox";
                    }
                    else
                    {
                        if (column.LanguageType == "string" && column.CharacterMaxLength > 200)
                        {
                            tableUIGenerationParams.InputType = "TextBoxMultiLine";
                        }
                        tableUIGenerationParams.InputType = "TextBox";
                    }
                    break;
            }

        }

 
    }
}