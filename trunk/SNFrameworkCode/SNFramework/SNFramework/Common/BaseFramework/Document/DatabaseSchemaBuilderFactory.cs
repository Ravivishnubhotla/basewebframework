using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.BaseFramework.Document
{
    public static class DatabaseSchemaBuilderFactory
    {
        private static readonly MSSQLDataBaseSchemaBulider _mssqlDataBaseSchemaBulider = new MSSQLDataBaseSchemaBulider();


        public static IDatabaseSchemaBuilder GetDatabaseSchemaBuilder(DatabaseType databaseType)
        {
            switch (databaseType)
            {
                case DatabaseType.MSSQL:
                    return _mssqlDataBaseSchemaBulider;
                case DatabaseType.MYSQL:
                    break;
                case DatabaseType.ORACLE:
                    break;
            }
            return null;
        }
    }
}
