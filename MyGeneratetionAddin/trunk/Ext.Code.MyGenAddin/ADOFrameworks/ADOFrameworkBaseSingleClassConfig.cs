using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms.Design;
using Legendigital.Code.MyGenAddin.Win;
using MyMeta;

namespace Legendigital.Code.MyGenAddin.ADOFrameworks
{
    [Serializable]
    public class ADOFrameworkBaseSingleClassConfig
    {
        #region [代码设置]
       
        
        private string _CodeAssembleName;
        private string _CodeNameSpace;
        private string _CodeClassNameFormat;
        private string _SelectCodeClassFilePath;
        private string _CodePropertyMemberPrefix;
        private bool _IsUseNullAbleType;
        private bool _IsCreateFKeyCodeClassRefence = false;
        private string _DbPrefix;
        private string _CodeImportNameSpace;
        private string _ProcNamePrefix;
        private string _DbSchemaName;
        private string _DBConfigurationPropertyName;
        

        [Category("[代码设置]"), ReadOnly(false), Description("代码应用程序集"), Browsable(true)]
        public string CodeAssembleName
        {
            get { return _CodeAssembleName; }
            set { _CodeAssembleName = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("代码名称空间"), Browsable(true)]
        public string CodeNameSpace
        {
            get { return _CodeNameSpace; }
            set { _CodeNameSpace = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("代码类命名规则"), Browsable(true)]
        public string CodeClassNameFormat
        {
            get { return _CodeClassNameFormat; }
            set { _CodeClassNameFormat = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("代码生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SelectCodeClassFilePath
        {
            get { return _SelectCodeClassFilePath; }
            set { _SelectCodeClassFilePath = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("代码成员变量前缀"), Browsable(true)]
        public string CodePropertyMemberPrefix
        {
            get { return _CodePropertyMemberPrefix; }
            set { _CodePropertyMemberPrefix = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("代码属性类型是否支持可空类型"), Browsable(true)]
        public bool IsUseNullAbleType
        {
            get { return _IsUseNullAbleType; }
            set { _IsUseNullAbleType = value; }
        }
        [Category("[代码设置]"),  ReadOnly(false), Description("是否支持外键类"), Browsable(false)]
        public bool IsCreateFKeyCodeClassRefence
        {
            get { return _IsCreateFKeyCodeClassRefence; }
            set { _IsCreateFKeyCodeClassRefence = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("数据库表名过滤前缀"), Browsable(true)]
        public string DbPrefix
        {
            get { return _DbPrefix; }
            set { _DbPrefix = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("生成类预加载名称空间"), Browsable(true)]
        [Editor(typeof(MultilineTextEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string CodeImportNameSpace
        {
            get { return _CodeImportNameSpace; }
            set { _CodeImportNameSpace = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("存储过程前缀"), Browsable(true)]
        public string ProcNamePrefix
        {
            get { return _ProcNamePrefix; }
            set { _ProcNamePrefix = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("数据库Schema名"), Browsable(true)]
        public string DbSchemaName
        {
            get { return _DbSchemaName; }
            set { _DbSchemaName = value; }
        }
        [Category("[代码设置]"), ReadOnly(false), Description("数据库连接字符串属性名"), Browsable(true)]
        public string DBConfigurationPropertyName
        {
            get { return _DBConfigurationPropertyName; }
            set { _DBConfigurationPropertyName = value; }
        }
        #endregion

 

        public string GenerateCodeClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.CodeClassNameFormat, StringCase.PascalCase,
                                                            "");
        }

        public string GenerateProceduceCodeClassName(IProcedure procedure)
        {
            return ProceduceGenerationHelper.GenerateNameByProceduce(procedure, this.CodeClassNameFormat, StringCase.PascalCase,
                                                              "");
        }

        public string GenerateProceduceCodeClassDesignerClassPath(IProcedure procedure)
        {
            return Path.Combine(this.SelectCodeClassFilePath, GenerateProceduceCodeClassName(procedure) + ".cs");
        }

        public string GenerateProceduceCodeClassClassPath(IProcedure procedure)
        {
            return Path.Combine(this.SelectCodeClassFilePath, GenerateProceduceCodeClassName(procedure) + ".cs");
        }

        public string GenerateCodeClassPath(ITable table)
        {
            return Path.Combine(this.SelectCodeClassFilePath, GenerateCodeClassName(table) + ".cs");
        }

        public string GenerateCodeClassDesignerClassPath(ITable table)
        {
            return Path.Combine(this.SelectCodeClassFilePath, GenerateCodeClassName(table) + ".Designer.cs");
        }

        public string GenerateCodeClassDescription(ITable table)
        {
            return table.Description;
        }

        public string GenerateCodePropertyMemberName(IColumn column)
        {
            return TableColumnGenerationHelper.GenerateNameByTableColumn(column, this.CodePropertyMemberPrefix + "{0}", StringCase.CamelCase);
        }

        public string GenerateCodePropertyMemberType(IColumn column)
        {
            return TableColumnGenerationHelper.GeneratePrivateMembersTypeByTableColumn(column, this.IsUseNullAbleType, IsCreateFKeyCodeClassRefence, this.CodeClassNameFormat, StringCase.PascalCase, this.DbPrefix);
        }

        public string GenerateCodePropertyParamsName(IColumn column)
        {
            string entityParamsName = TableColumnGenerationHelper.GenerateNameByTableColumn(column, "{0}", StringCase.CamelCase);
            if (TableColumnGenerationHelper.Csharpkeyword.Contains(entityParamsName))
            {
                return entityParamsName + "p";
            }
            return entityParamsName;
        }

        public string GenerateCodePropertyType(IColumn column)
        {
            return TableColumnGenerationHelper.GeneratePorpertyTypeByTableColumn(column, this.IsUseNullAbleType, IsCreateFKeyCodeClassRefence, this.CodeClassNameFormat, StringCase.PascalCase, this.DbPrefix);
        }

        public string GenerateCodePropertyType(IColumn column, bool isGenerateClassType)
        {
            return TableColumnGenerationHelper.GeneratePorpertyTypeByTableColumn(column, this.IsUseNullAbleType, isGenerateClassType, this.CodeClassNameFormat, StringCase.CamelCase, this._DbPrefix);
        }

        public string GenerateCodePropertyName(IColumn column)
        {
            return TableColumnGenerationHelper.GenerateNameByTableColumn(column, "{0}", StringCase.PascalCase);
        }

        public int GenerateColumnSize(IColumn column)
        {
            return TableColumnGenerationHelper.GenerateColumnSizeByTableColumn(column);
        }

        public string GenerateColumnDbType(IColumn column)
        {
            return column.DbTargetType;
        }

        public string GenerateParameterDirection(IParameter parameter)
        {
            return ProceduceParameterGenerationHelper.GenerateParameterDirection(parameter);
        }

        public string GenerateProceduceParamterName(IParameter parameter)
        {
            return ProceduceParameterGenerationHelper.GenerateNameByParameter(parameter, "{0}", StringCase.PascalCase);
        }

        public int GenerateParameterSize(IParameter parameter)
        {
            return ProceduceParameterGenerationHelper.GenerateParameterSize(parameter);
        }

        public string GenerateParameterDbType(IParameter parameter)
        {
            return parameter.DbTargetType;
        }



        public List<IColumn> GetAllPkColumn(ITable table)
        {
            int primaryKeysCount = table.PrimaryKeys.Count;

            List<IColumn> pks = new List<IColumn>();

            if (primaryKeysCount > 0)
            {
                foreach (IColumn column in table.PrimaryKeys)
                {
                    pks.Add(column);
                }
            }

            return pks;
        }

        public List<IColumn> GetAllNotPkColumn(ITable table)
        {
            List<IColumn> pks = GetAllPkColumn(table);

            List<IColumn> npks = new List<IColumn>();

            foreach (IColumn column in table.Columns)
            {
                if (!pks.Contains(column))
                {
                    npks.Add(column);
                }
            }

            return npks;
        }


    }
}
