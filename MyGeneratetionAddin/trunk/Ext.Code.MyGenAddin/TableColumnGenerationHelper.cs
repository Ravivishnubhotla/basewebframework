using System;
using System.Collections.Generic;
using System.Threading;
using Dnp.Utils;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public static class TableColumnGenerationHelper
    {
        private static readonly Utils utils = new Utils();
        private static DateTime minSqlDateTime = DateTime.Parse("1800-1-1");


        public static readonly List<string> Csharpkeyword = new List<string>
                                                        {
                                                            "abstract",
                                                            "as",
                                                            "base",
                                                            "bool",
                                                            "break",
                                                            "byte",
                                                            "case",
                                                            "catch",
                                                            "char",
                                                            "checked",
                                                            "class",
                                                            "const",
                                                            "continue",
                                                            "decimal",
                                                            "default",
                                                            "delegate",
                                                            "do",
                                                            "double",
                                                            "else",
                                                            "enum",
                                                            "event",
                                                            "explicit",
                                                            "extern",
                                                            "false",
                                                            "finally",
                                                            "fixed",
                                                            "float",
                                                            "for",
                                                            "foreach",
                                                            "goto",
                                                            "if",
                                                            "implicit",
                                                            "in",
                                                            "int",
                                                            "interface",
                                                            "internal",
                                                            "is",
                                                            "lock",
                                                            "long",
                                                            "namespace",
                                                            "new",
                                                            "null",
                                                            "object",
                                                            "operator",
                                                            "out",
                                                            "override",
                                                            "params",
                                                            "private",
                                                            "protected",
                                                            "public",
                                                            "readonly",
                                                            "ref",
                                                            "return",
                                                            "sbyte",
                                                            "sealed",
                                                            "short",
                                                            "sizeof",
                                                            "stackalloc",
                                                            "static",
                                                            "string",
                                                            "struct",
                                                            "switch",
                                                            "this",
                                                            "throw",
                                                            "true",
                                                            "try",
                                                            "typeof",
                                                            "uint",
                                                            "ulong",
                                                            "unchecked",
                                                            "unsafe",
                                                            "ushort",
                                                            "using",
                                                            "virtual",
                                                            "volatile",
                                                            "void",
                                                            "while"
                                                        };

        #region const

        private const string defaultFilterString = "_ -";

        private const string defaultFormat = "{0}";
        private const StringCase defaultStringCase = StringCase.CamelCase;

        private static readonly string[] notNullableTypes = new[] {"string", "byte[]", "object"};

        #endregion

        #region GenerateNameByTableColumn

        public static string GenerateNameByTableColumn(IColumn column, string format, StringCase stringCase,
                                                       string filterString)
        {
            string generateName = column.Name;
            switch (stringCase)
            {
                case StringCase.CamelCase:
                    generateName = utils.SetCamelCase(generateName);
                    break;
                case StringCase.PascalCase:
                    generateName = utils.SetPascalCase(generateName);
                    break;
            }
            char[] filterChar = filterString.ToCharArray();
            foreach (char c in filterChar)
            {
                generateName = generateName.Replace(c.ToString(), "");
            }
            return string.Format(format, generateName);
        }

        public static string GenerateNameByTableColumn(IColumn column, string format, StringCase stringCase)
        {
            return GenerateNameByTableColumn(column, format, stringCase, defaultFilterString);
        }

        public static string GenerateNameByTableColumn(IColumn column, string format)
        {
            return GenerateNameByTableColumn(column, format, defaultStringCase, defaultFilterString);
        }

        public static string GenerateNameByTableColumn(IColumn column)
        {
            return GenerateNameByTableColumn(column, defaultFormat, defaultStringCase, defaultFilterString);
        }

        #endregion

        public static string GeneratePrivateMembersTypeByTableColumn(IColumn column, bool enableNullType,
                                                                     bool isCreateFKClassRefrence,
                                                                     string tableNameFormat, StringCase stringTableCase,
                                                                     string filterTableString)
        {
            if (isCreateFKClassRefrence && column.IsInForeignKey && !column.IsInPrimaryKey)
            {
                return TableGenerationHelper.GenerateNameByTable(column.ForeignKeys[0].PrimaryTable, tableNameFormat,
                                                                 stringTableCase,
                                                                 filterTableString);
            }
            if (enableNullType)
            {
                foreach (string notNullableType in notNullableTypes)
                {
                    if (column.LanguageType.ToLower() == notNullableType)
                    {
                        return notNullableType;
                    }
                }
                if (column.IsNullable)
                    return column.LanguageType + "?";
                else
                    return column.LanguageType;
            }
            else
            {
                return column.LanguageType;
            }
        }

        public static string GeneratePrivateMembersTypeByTableColumn(IColumn column, string memberPrefix)
        {
            return GenerateNameByTableColumn(column, memberPrefix + "{0}", StringCase.CamelCase, defaultFilterString);
        }

        public static string GetContructInitalValueByTableColumn(IColumn column, bool enableNullType,
                                                                 bool isCreateFKClassRefrence)
        {
            if (column.HasDefault)
                return GenerateFieldDbDefaultValueByTableColumn(column);
            else
                return GenerateFieldSystemDefaultValueByTableColumn(column, enableNullType, isCreateFKClassRefrence);
        }


        public static string GenerateFieldDbDefaultValueByTableColumn(IColumn column)
        {
            if (column.HasDefault)
            {
                string defaultValue = column.Default.Replace("(", "");
                defaultValue = defaultValue.Replace(")", "");
                switch (column.LanguageType)
                {
                    case "string":
                        return "\""+defaultValue.Replace("'","").Replace("\"","")+"\"";
                        break;
                    case "DateTime":
                        if (defaultValue.ToLower().IndexOf("getdate") > 0)
                        {
                            return "System.DateTime.Now";
                        }
                        else
                        {
                            return defaultValue;
                        }
                        break;
                    case "bool":
                        if (defaultValue == "0")
                            return "false";
                        else
                            return "true";
                        break;
                    case "decimal":
                    case "int":
                    case "float":
                    case "byte":
                    case "short":
                    case "double":
                    case "long":
                    case "Guid":
                        return defaultValue;
                        break;
                    case "object":
                    case "byte[]":
                        return "";
                        break;
                }
            }
            else
            {
                return "";
            }
            return "";
        }

        public static string GenerateFieldSystemDefaultValueByTableColumn(IColumn column, bool enableNullType,
                                                                          bool isCreateFKClassRefrence)
        {
            if (isCreateFKClassRefrence && column.IsInForeignKey && !column.IsInPrimaryKey)
            {
                return "null";
            }
            if (enableNullType && column.IsNullable)
            {
                return "null";
            }
            else
            {
                switch (column.LanguageType)
                {
                    case "string":
                        return "String.Empty";
                        break;
                    case "DateTime":
                        return "DateTime.MinValue";
                        break;
                    case "bool":
                        return "false";
                        break;
                    case "decimal":
                    case "int":
                    case "float":
                    case "byte":
                    case "short":
                    case "double":
                    case "long":
                        return "0";
                        break;
                    case "Guid":
                        return "String.Empty";
                        break;
                    case "object":
                        return "new object()";
                    case "byte[]":
                        return "new byte[1]";
                        break;
                }
            }
            return "null";
        }

        public static string GeneratePorpertyTypeByTableColumn(IColumn column, bool enableNullType,
                                                               bool isCreateFKClassRefrence, string tableNameFormat,
                                                               StringCase stringTableCase, string filterTableString)
        {
            return GeneratePrivateMembersTypeByTableColumn(column, enableNullType, isCreateFKClassRefrence,
                                                           tableNameFormat,
                                                           stringTableCase, filterTableString);
        }

        public static string GeneratePorpertyTypeByTableColumn(IColumn column)
        {
            return GeneratePorpertyTypeByTableColumn(column, true
                , false,
                                                           "",
                                                           StringCase.PascalCase, "");
        }

        public static string GenerateNHibernateTypeByTableColumn(IColumn column, bool isCreateFKClassRefrence,
                                                                 string tableNameFormat, StringCase stringTableCase,
                                                                 string filterTableString)
        {
            string nHibernateType = GeneratePrivateMembersTypeByTableColumn(column, false, isCreateFKClassRefrence,
                                                                            tableNameFormat,
                                                                            stringTableCase, filterTableString);
            switch (column.LanguageType)
            {
                case "byte[]":
                    if (column.DataTypeName.ToLower() == "timestamp")
                    {
                        return "Timestamp";
                    }
                    else
                    {
                        return "Byte[]";
                    }
                    ;
                case "bool":
                    return "Boolean";
                case "decimal":
                    return "Decimal";
                default:
                    return nHibernateType;
            }
        }


        public static string GeneratePorpertyNameByTableColumn(IColumn column)
        {
            return GenerateNameByTableColumn(column, "{0}", StringCase.PascalCase, defaultFilterString);
        }

        public static int GenerateColumnSizeByTableColumn(IColumn column)
        {
            if (!(column.LanguageType.ToLower() == "string"))
                return 0;
            if (column.CharacterMaxLength > 8000)
                return 0;
            return column.CharacterMaxLength;
        }

        public static string GenerateFkListPropertyName(IForeignKey fk, string fkListPropertyFormat)
        {
            if (fk.PrimaryColumns != null && fk.ForeignColumns != null && fk.PrimaryColumns.Count > 0 && fk.ForeignColumns.Count > 0)
            {
                string pTableName = TableGenerationHelper.GenerateNameByTable(fk.PrimaryColumns[0].Table, "{0}", StringCase.PascalCase);
                string fTablename = TableGenerationHelper.GenerateNameByTable(fk.ForeignColumns[0].Table, "{0}", StringCase.PascalCase);
                return string.Format(fkListPropertyFormat, pTableName, fTablename, fk.ForeignColumns[0].Name);
            }
            throw new Exception(" PrimaryColumns or ForeignColumns is null or empty");
        }

        public static string GenerateFkListPrivateMembername(IForeignKey fk, string fkListPropertyFormat)
        {
            if (fk.PrimaryColumns != null && fk.ForeignColumns != null && fk.PrimaryColumns.Count > 0 && fk.ForeignColumns.Count > 0)
            {
                string pTableName = TableGenerationHelper.GenerateNameByTable(fk.PrimaryColumns[0].Table, "{0}", StringCase.CamelCase);
                string fTablename = TableGenerationHelper.GenerateNameByTable(fk.ForeignColumns[0].Table, "{0}", StringCase.PascalCase);
                return string.Format(fkListPropertyFormat, pTableName, fTablename, fk.ForeignColumns[0].Name);
            }
            throw new Exception(" PrimaryColumns or ForeignColumns is null or empty");
        }

        //public static List<IColumn> GetRefreneceColumns(IColumn col,List<Table> tables)
        //{
        //    foreach (Table table in tables)
        //    {
        //        foreach (IForeignKey foreignKey in table.ForeignKeys)
        //        {
        //            foreignKey.
        //        }
        //    }
        //}


        public static bool validateSelectItemString(string items,out string errormessage)
        {
            errormessage = "";
            //if(items.Trim() == "")
            //    return true;
            //string[] keyvalue = items.Split('|');
            //string[] keys;
            //string[] values;
            //if (keyvalue.Length < 1 | keyvalue.Length > 2)
            //{
            //    errormessage = "参数错误,|分隔符数量不对！";
            //    return false;
            //}
            //else if (keyvalue.Length == 2)
            //{
            //    ArrayList al = new ArrayList();
            //    values = keyvalue[0].Split('$');
            //    keys = keyvalue[1].Split('$');
            //    if (values.Length != keys.Length)
            //    {
            //        errormessage = "参数错误,key与vakue数量不匹配！";
            //        return false;
            //    }
            //    for (int i = 0; i < keys.Length; i++)
            //    {
            //        if(al.Contains(keys[i]))
            //        {
            //            errormessage = "参数错误,存在重复的key！";
            //            return false;
            //        }
            //        al.Add(keys[i]);
            //    }    
            //}
            return true;
        }
    }
}