using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.BaseFramework.Document
{
    public class MSSQLDataBaseSchemaBulider : IDatabaseSchemaBuilder
    {

        public MSSQLDataBaseSchemaBulider()
        {
        }


        public string GetCreateDataTypeSql(string tableName)
        {
            string sqltemplate = @"
CREATE TABLE [dbo].[{0}](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ItemID] [int] NULL
 CONSTRAINT [PK_{0}] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
";
            return string.Format(sqltemplate, tableName);
        }

        public string GetRenameDataTypeSql(string tableName, string newTableName)
        {
            return string.Format("EXEC sp_rename '{0}', '{1}'", tableName, newTableName);
        }

        public string GetDropDataTypeSql(string tableName)
        {
            string sqltemplate = @"
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[{0}]') AND type in (N'U'))
DROP TABLE [dbo].[{0}]
";
            return string.Format(sqltemplate, tableName);
        }

        public string GetCreateDataFieldSql(string tableName, string fieldName, DataFileldType fieldType, bool allowNull, int length, int precision)
        {
            switch (fieldType)
            {
                case DataFileldType.String:
                    return string.Format("ALTER TABLE [{0}] ADD [{1}] nvarchar({2}) {3};", tableName, fieldName, length, BuildNotNull(allowNull));
                case DataFileldType.DateTime:
                    return string.Format("ALTER TABLE [{0}] ADD [{1}] datetime {2};", tableName, fieldName, BuildNotNull(allowNull));
                case DataFileldType.Decimal:
                    return string.Format("ALTER TABLE [{0}] ADD [{1}] decimal({2}, {3}) {4};", tableName, fieldName, length, precision, BuildNotNull(allowNull));
                case DataFileldType.Int:
                    return string.Format("ALTER TABLE [{0}] ADD [{1}] int {2};", tableName, fieldName, BuildNotNull(allowNull));
                case DataFileldType.Bool:
                    return string.Format("ALTER TABLE [{0}] ADD [{1}] bit {2};", tableName, fieldName, BuildNotNull(allowNull));
            }
            return "";
        }

        private string BuildNotNull(bool allowNull)
        {
            if (!allowNull)
                return " NOT NULL ";
            else
                return " NULL ";
        }

        public string GetUpdateDataFieldSql(string tableName, string fieldName, DataFileldType fieldType, bool allowNull, int length, int precision)
        {
            switch (fieldType)
            {
                case DataFileldType.String:
                    return string.Format("ALTER TABLE [{0}] ALTER COLUMN [{1}] nvarchar({2}) {3};", tableName, fieldName, length, BuildNotNull(allowNull));
                case DataFileldType.DateTime:
                    return string.Format("ALTER TABLE [{0}] ALTER COLUMN [{1}] datetime {2};", tableName, fieldName, BuildNotNull(allowNull));
                case DataFileldType.Decimal:
                    return string.Format("ALTER TABLE [{0}] ALTER COLUMN [{1}] decimal({2}, {3}) {4};", tableName, fieldName, length, precision, BuildNotNull(allowNull));
                case DataFileldType.Int:
                    return string.Format("ALTER TABLE [{0}] ALTER COLUMN [{1}] int {2};", tableName, fieldName, BuildNotNull(allowNull));
                case DataFileldType.Bool:
                    return string.Format("ALTER TABLE [{0}] ALTER COLUMN [{1}] bit {2};", tableName, fieldName, BuildNotNull(allowNull));
            }
            return "";
        }

        public string GetDropDataFieldSql(string tableName, string fieldName)
        {
            return string.Format("ALTER TABLE [{0}] DROP COLUMN [{1}];",tableName,fieldName);
        }

        public string GetRenamedateDataFieldSql(string tableName, string fieldName, string newfieldName)
        {
            return string.Format("EXEC sp_rename '{0}.[{1}]', '{2}', 'COLUMN'", tableName, fieldName, newfieldName);
        }
    }
}
