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
    public enum CodeGenerateType
    {
        Inherit,
        Partial
    }


    [Serializable]
    public class ADOFrameworkBaseSingleClassConfig
    {
        #region [代码设置]
       
        
        private string _entityCodeAssembleName;
        private string _entityCodeNameSpace;
        private string _entityBaseCodeNameSpace;
        private string _entityCodeClassNameFormat;
        private string _entityBaseCodeNameFormat;
        private string _entityCodeClassFilePath;
        private string _entityBaseCodeClassFilePath;
        private string _entityCodePropertyMemberPrefix;
        private string _entityCodeImportNameSpace;
        private string _dataCodeAssembleName;
        private string _dataCodeNameSpace;
        private string _dataBaseCodeNameSpace;
        private string _dataCodeClassNameFormat;
        private string _dataBaseCodeNameFormat;
        private string _dataCodeClassFilePath;
        private string _dataBaseCodeClassFilePath;
        private string _dataCodePropertyMemberPrefix;
        private string _dataCodeImportNameSpace;
        private string _bussinessCodeAssembleName;
        private string _bussinessCodeNameSpace;
        private string _bussinessBaseCodeNameSpace;
        private string _bussinessCodeClassNameFormat;
        private string _bussinessBaseCodeNameFormat;
        private string _bussinessCodeClassFilePath;
        private string _bussinessBaseCodeClassFilePath;
        private string _bussinessCodePropertyMemberPrefix;
        private string _bussinessCodeImportNameSpace;

        private bool _entityIsUseNullAbleType;
        private string _DbPrefix;
        private string _DbSchemaName;









        //private string _DBConfigurationPropertyName;
        #region 业务逻辑代码设置
        [Category("[业务逻辑代码设置]"), ReadOnly(false), Description("预加载名称空间"), Browsable(true)]
        [Editor(typeof(MultilineTextEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string BussinessCodeImportNameSpace
        {
            get { return _bussinessCodeImportNameSpace; }
            set { _bussinessCodeImportNameSpace = value; }
        }
        [Category("[业务逻辑代码设置]"), ReadOnly(false), Description("设计类生成地址"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string BussinessBaseCodeClassFilePath
        {
            get { return _bussinessBaseCodeClassFilePath; }
            set { _bussinessBaseCodeClassFilePath = value; }
        }
        [Category("[业务逻辑代码设置]"), ReadOnly(false), Description("类生成地址"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string BussinessCodeClassFilePath
        {
            get { return _bussinessCodeClassFilePath; }
            set { _bussinessCodeClassFilePath = value; }
        }
        [Category("[业务逻辑代码设置]"), ReadOnly(false), Description("成员变量前缀"), Browsable(true)]
        public string BussinessCodePropertyMemberPrefix
        {
            get { return _bussinessCodePropertyMemberPrefix; }
            set { _bussinessCodePropertyMemberPrefix = value; }
        }
        [Category("[业务逻辑代码设置]"), ReadOnly(false), Description("设计类命名格式"), Browsable(true)]
        public string BussinessBaseCodeNameFormat
        {
            get { return _bussinessBaseCodeNameFormat; }
            set { _bussinessBaseCodeNameFormat = value; }
        }
        [Category("[业务逻辑代码设置]"), ReadOnly(false), Description("类命名格式"), Browsable(true)]
        public string BussinessCodeClassNameFormat
        {
            get { return _bussinessCodeClassNameFormat; }
            set { _bussinessCodeClassNameFormat = value; }
        }
        [Category("[业务逻辑代码设置]"), ReadOnly(false), Description("设计类名称空间"), Browsable(true)]
        public string BussinessBaseCodeNameSpace
        {
            get { return _bussinessBaseCodeNameSpace; }
            set { _bussinessBaseCodeNameSpace = value; }
        }
        [Category("[业务逻辑代码设置]"), ReadOnly(false), Description("类名称空间"), Browsable(true)]
        public string BussinessCodeNameSpace
        {
            get { return _bussinessCodeNameSpace; }
            set { _bussinessCodeNameSpace = value; }
        }
        [Category("[业务逻辑代码设置]"), ReadOnly(false), Description("应用程序集"), Browsable(true)]
        public string BussinessCodeAssembleName
        {
            get { return _bussinessCodeAssembleName; }
            set { _bussinessCodeAssembleName = value; }
        }
        #endregion

        #region 数据层代码设置
        [Category("[数据层代码设置]"), ReadOnly(false), Description("预加载名称空间"), Browsable(true)]
        [Editor(typeof(MultilineTextEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataCodeImportNameSpace
        {
            get { return _dataCodeImportNameSpace; }
            set { _dataCodeImportNameSpace = value; }
        }
        [Category("[数据层代码设置]"), ReadOnly(false), Description("成员变量前缀"), Browsable(true)]
        public string DataCodePropertyMemberPrefix
        {
            get { return _dataCodePropertyMemberPrefix; }
            set { _dataCodePropertyMemberPrefix = value; }
        }
        [Category("[数据层代码设置]"), ReadOnly(false), Description("类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataCodeClassFilePath
        {
            get { return _dataCodeClassFilePath; }
            set { _dataCodeClassFilePath = value; }
        }
        [Category("[数据层代码设置]"), ReadOnly(false), Description("设计类命名规则"), Browsable(true)]
        public string DataBaseCodeNameFormat
        {
            get { return _dataBaseCodeNameFormat; }
            set { _dataBaseCodeNameFormat = value; }
        }
        [Category("[数据层代码设置]"), ReadOnly(false), Description("类命名规则"), Browsable(true)]
        public string DataCodeClassNameFormat
        {
            get { return _dataCodeClassNameFormat; }
            set { _dataCodeClassNameFormat = value; }
        }
        [Category("[数据层代码设置]"), ReadOnly(false), Description("设计类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string DataBaseCodeClassFilePath
        {
            get { return _dataBaseCodeClassFilePath; }
            set { _dataBaseCodeClassFilePath = value; }
        }
        [Category("[数据层代码设置]"), ReadOnly(false), Description("类名称空间"), Browsable(true)]
        public string DataCodeNameSpace
        {
            get { return _dataCodeNameSpace; }
            set { _dataCodeNameSpace = value; }
        }
        [Category("[数据层代码设置]"), ReadOnly(false), Description("设计类名称空间"), Browsable(true)]
        public string DataBaseCodeNameSpace
        {
            get { return _dataBaseCodeNameSpace; }
            set { _dataBaseCodeNameSpace = value; }
        }
        [Category("[数据层代码设置]"), ReadOnly(false), Description("应用程序集"), Browsable(true)]
        public string DataCodeAssembleName
        {
            get { return _dataCodeAssembleName; }
            set { _dataCodeAssembleName = value; }
        }
        #endregion

        #region 业务实体代码设置
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("应用程序集"), Browsable(true)]
        public string EntityCodeAssembleName
        {
            get { return _entityCodeAssembleName; }
            set { _entityCodeAssembleName = value; }
        }
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("类名称空间"), Browsable(true)]
        public string EntityCodeNameSpace
        {
            get { return _entityCodeNameSpace; }
            set { _entityCodeNameSpace = value; }
        }
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("类命名规则"), Browsable(true)]
        public string EntityCodeClassNameFormat
        {
            get { return _entityCodeClassNameFormat; }
            set { _entityCodeClassNameFormat = value; }
        }
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string EntityCodeClassFilePath
        {
            get { return _entityCodeClassFilePath; }
            set { _entityCodeClassFilePath = value; }
        }
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("成员变量前缀"), Browsable(true)]
        public string EntityCodePropertyMemberPrefix
        {
            get { return _entityCodePropertyMemberPrefix; }
            set { _entityCodePropertyMemberPrefix = value; }
        }
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("属性类型是否支持可空类型"), Browsable(true)]
        public bool EntityIsUseNullAbleType
        {
            get { return _entityIsUseNullAbleType; }
            set { _entityIsUseNullAbleType = value; }
        }
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("预加载名称空间"), Browsable(true)]
        [Editor(typeof(MultilineTextEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string EntityCodeImportNameSpace
        {
            get { return _entityCodeImportNameSpace; }
            set { _entityCodeImportNameSpace = value; }
        }
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("设计类名格式"), Browsable(true)]
        public string EntityBaseCodeNameFormat
        {
            get { return _entityBaseCodeNameFormat; }
            set { _entityBaseCodeNameFormat = value; }
        }
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("设计类名称空间"), Browsable(true)]
        public string EntityBaseCodeNameSpace
        {
            get { return _entityBaseCodeNameSpace; }
            set { _entityBaseCodeNameSpace = value; }
        }
        [Category("[业务实体代码设置]"), ReadOnly(false), Description("设计类生成路径"), Browsable(true)]
        [Editor(typeof(FolderNameEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string EntityBaseCodeClassFilePath
        {
            get { return _entityBaseCodeClassFilePath; }
            set { _entityBaseCodeClassFilePath = value; }
        }
        #endregion

        #region 总体代码设置
        [Category("[总体代码设置]"), ReadOnly(false), Description("数据库Schema名"), Browsable(true)]
        public string DbSchemaName
        {
            get { return _DbSchemaName; }
            set { _DbSchemaName = value; }
        }
        [Category("[总体代码设置]"), ReadOnly(false), Description("数据库表名过滤前缀"), Browsable(true)]
        public string DbPrefix
        {
            get { return _DbPrefix; }
            set { _DbPrefix = value; }
        }
        #endregion

 
        //[Category("[代码设置]"), ReadOnly(false), Description("数据库连接字符串属性名"), Browsable(true)]
        //public string DBConfigurationPropertyName
        //{
        //    get { return _DBConfigurationPropertyName; }
        //    set { _DBConfigurationPropertyName = value; }
        //}
        //[Category("[代码设置]"), ReadOnly(false), Description("存储过程前缀"), Browsable(true)]
        //public string ProcNamePrefix
        //{
        //    get { return _ProcNamePrefix; }
        //    set { _ProcNamePrefix = value; }
        //}
        #endregion

 

        public string GenerateCodeClassName(ITable table)
        {
            return TableGenerationHelper.GenerateNameByTable(table, this.EntityCodeClassNameFormat, StringCase.PascalCase,
                                                            this.DbPrefix);
        }

        public string GenerateBaseCodeClassName(ITable table)
        {
            return string.Format(this.EntityBaseCodeNameFormat,TableGenerationHelper.GenerateNameByTable(table, this.EntityCodeClassNameFormat, StringCase.PascalCase,
                                                            this.DbPrefix));
        }

        public string GenerateProceduceCodeClassName(IProcedure procedure)
        {
            return ProceduceGenerationHelper.GenerateNameByProceduce(procedure, this.EntityCodeClassNameFormat, StringCase.PascalCase,
                                                              "");
        }

        public string GenerateProceduceCodeClassDesignerClassPath(IProcedure procedure)
        {
            return Path.Combine(this.EntityCodeClassFilePath, GenerateProceduceCodeClassName(procedure) + ".cs");
        }

        public string GenerateProceduceCodeClassClassPath(IProcedure procedure)
        {
            return Path.Combine(this.EntityCodeClassFilePath, GenerateProceduceCodeClassName(procedure) + ".cs");
        }

        public string GenerateCodeClassPath(ITable table)
        {
            return Path.Combine(this.EntityCodeClassFilePath, GenerateCodeClassName(table) + ".cs");
        }

        public string GenerateCodeClassDesignerClassPath(ITable table)
        {
            return Path.Combine(this.EntityBaseCodeClassFilePath,  GenerateBaseCodeClassName(table) + ".cs");
        }

        public string GenerateCodeClassDescription(ITable table)
        {
            return table.Description;
        }

        public string GenerateCodePropertyMemberName(IColumn column)
        {
            return TableColumnGenerationHelper.GenerateNameByTableColumn(column, this.EntityCodePropertyMemberPrefix + "{0}", StringCase.CamelCase);
        }

        public string GenerateCodePropertyMemberType(IColumn column)
        {
            return TableColumnGenerationHelper.GeneratePrivateMembersTypeByTableColumn(column, this.EntityIsUseNullAbleType, false, this.EntityCodeClassNameFormat, StringCase.PascalCase, this.DbPrefix);
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
            return TableColumnGenerationHelper.GeneratePorpertyTypeByTableColumn(column, this.EntityIsUseNullAbleType, false, this.EntityCodeClassNameFormat, StringCase.PascalCase, this.DbPrefix);
        }

        public string GenerateCodePropertyType(IColumn column, bool isGenerateClassType)
        {
            return TableColumnGenerationHelper.GeneratePorpertyTypeByTableColumn(column, this.EntityIsUseNullAbleType, isGenerateClassType, this.EntityCodeClassNameFormat, StringCase.CamelCase, this._DbPrefix);
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
