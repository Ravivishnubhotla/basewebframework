using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.BaseFramework.Document
{
    public interface IDatabaseSchemaBuilder
    {
        string GetCreateDataTypeSql(string tableName);

        string GetRenameDataTypeSql(string tableName, string newTableName);

        string GetDropDataTypeSql(string tableName);

        string GetCreateDataFieldSql(string tableName, string fieldName, DataFileldType fieldType, bool allowNull, int length, int precision);

        string GetUpdateDataFieldSql(string tableName, string fieldName, DataFileldType fieldType, bool allowNull, int length, int precision);

        string GetDropDataFieldSql(string tableName, string fieldName);

        string GetRenamedateDataFieldSql(string tableName, string fieldName, string newfieldName);
    }
}
