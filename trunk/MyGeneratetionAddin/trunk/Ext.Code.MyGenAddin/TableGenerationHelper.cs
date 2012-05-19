using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Dnp.Utils;
using MyMeta;

namespace Legendigital.Code.MyGenAddin
{
    public enum StringCase { CamelCase, PascalCase }

    public static class TableGenerationHelper
    {
        private static Utils utils = new Utils();

        #region const

        private const string defaultFilterString = "_ -";

        private const StringCase defaultStringCase = StringCase.CamelCase;

        private const string defaultFormat = "{0}";

        #endregion

        #region GenerateNameByTableColumn

        public static string GenerateNameByTable(ITable table, string format, StringCase stringCase, string filterString)
        {
            string generateName = table.Name;
            if(!string.IsNullOrEmpty(filterString))
            {
                string[] filterStrings = filterString.Split((",").ToCharArray());
                foreach (string s in filterStrings)
                {
                    if(generateName.ToUpper().StartsWith(s.ToUpper()))
                    {
                        generateName = generateName.Substring(s.Length, generateName.Length - s.Length);
                    }
                }
            }
            switch (stringCase)
            {
                case StringCase.CamelCase:
                    generateName = utils.SetCamelCase(generateName);
                    break;
                case StringCase.PascalCase:
                    generateName = utils.SetPascalCase(generateName);
                    break;
            }
            return string.Format(format, generateName);
        }


        public static string GenerateNameByTable(ITable table, string format, StringCase stringCase)
        {
            return GenerateNameByTable(table, format, stringCase, defaultFilterString);
        }

        public static string GenerateNameByTable(ITable table, string format)
        {
            return GenerateNameByTable(table, format, defaultStringCase, defaultFilterString);
        }

        public static string GenerateNameByTable(ITable table)
        {
            return GenerateNameByTable(table, defaultFormat, defaultStringCase, defaultFilterString);
        }

        #endregion


        public static List<ITable> GetAllExportDataOrderTables(IDatabase database)
        {
            List<ITable> tables = new List<ITable>();

            foreach (ITable table in database.Tables)
            {
                tables.Add(table);
            }

            List<ITable> alltables = new List<ITable>();

            foreach (ITable table in database.Tables)
            {
                if (table.ForeignKeys.Count<=0)
                {
                    alltables.Add(table);
                    tables.Remove(table);
                }
                else
                {
                    if (CheckAllForeignKeysIsSelf(table))
                    {
                        alltables.Add(table);
                        tables.Remove(table);
                    }
                }
            }

            while (tables.Count>0)
            {
                List<ITable> tmptables = new List<ITable>();

                foreach (ITable table in tables)
                {
                    tmptables.Add(table);
                }

                foreach (ITable table in tmptables)
                {
                    if (CheckTablehasDept(table, alltables))
                    {
                        alltables.Add(table);
                        tables.Remove(table);
                    }
                }   
            }

            return alltables;
        }

        private static bool CheckAllForeignKeysIsSelf(ITable table)
        {
            foreach (IForeignKey foreignKey in table.ForeignKeys)
            {
                if (table.Name == foreignKey.PrimaryTable.Name)
                    continue;
                if (foreignKey.ForeignTable.Name != foreignKey.PrimaryTable.Name)
                    return false;
            }
            return true;
        }

        private static bool CheckTablehasDept(ITable table, List<ITable> tables)
        {
            StringBuilder sbTables = new StringBuilder();

            foreach (ITable tb in tables)
            {
                sbTables.AppendLine(tb.Name);
            }

            var tblist = sbTables.ToString();


            foreach (IForeignKey foreignKey in table.ForeignKeys)
            {
                if (table.Name != foreignKey.PrimaryTable.Name)
                    continue;
                if(foreignKey.ForeignTable.Name != foreignKey.PrimaryTable.Name    &&  tables.Find(p=>p.Name==foreignKey.ForeignTable.Name)==null)
                    return false;
            }
            return true;
        }

        public static List<IColumn> GetAllNonePKColumn(ITable table)
        {
            List<IColumn> columns = new List<IColumn>();
            foreach (IColumn column in table.Columns)
            {
                if(!column.IsInPrimaryKey)
                {
                    columns.Add(column); 
                }
            }
            return columns;
        }

        public static IColumn GetSinglePKColumn(ITable table)
        {
            List<IColumn> columns = GetAllPKColumn(table);
            if (columns.Count>0)
                return columns[0];
            else
                return null;
        }

        public static bool CheckIsSinglePKColumn(ITable table)
        {
            List<IColumn> columns = GetAllPKColumn(table);
            if (columns.Count == 1)
                return true;
            else
                return false;
        }

        public static bool CheckIsSingleAutoPKColumn(ITable table)
        {
            List<IColumn> columns = GetAllPKColumn(table);
            if (columns.Count == 1)
                return columns[0].IsAutoKey;
            else
                return false;
        }

        public static List<IColumn> GetAllPKColumn(ITable table)
        {
            List<IColumn> columns = new List<IColumn>();
            foreach (IColumn column in table.Columns)
            {
                if (column.IsInPrimaryKey)
                {
                    columns.Add(column);
                }
            }
            return columns;
        }

        public static string GetNameFromDescription(string description,string alterName)
        {
            string displayName = description;

            Match match = Regex.Match(description, @"(?<=\{\$" + "DisplayName:\").*?(?=\"" + @"\})",RegexOptions.IgnoreCase);

            if (match != null && !string.IsNullOrEmpty(match.Value))
                displayName = match.Value;

            if (!string.IsNullOrEmpty(displayName))
                return displayName;
            else
                return alterName;
        }

        public static TableUIGenerationParams[] FilterAutoKeyField(TableUIGenerationParams[] tui)
        {
            var ltui = new List<TableUIGenerationParams>();
            foreach (TableUIGenerationParams tableUiGenerationParam in tui)
            {
                if(!tableUiGenerationParam.IsAutoKey)
                    ltui.Add(tableUiGenerationParam);
            }
            return ltui.ToArray();
        }
    }
}
