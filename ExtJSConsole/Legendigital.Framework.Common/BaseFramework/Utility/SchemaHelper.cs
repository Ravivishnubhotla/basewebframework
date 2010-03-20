using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;

namespace Legendigital.Framework.Common.BaseFramework.Utility
{
    public static class SchemaHelper
    {
        public static string[] ExportCreateSchema(Dialect dialect)
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            return cfg.GenerateSchemaCreationScript(dialect);
        }
        public static string[] ExportDropeSchema(Dialect dialect)
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            return cfg.GenerateDropSchemaScript(dialect);
        }
        public static string[] ExportUpdateSchema(Dialect dialect, DatabaseMetadata databaseMetadata)
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            return cfg.GenerateSchemaUpdateScript(dialect, databaseMetadata);
        }
    }
}
