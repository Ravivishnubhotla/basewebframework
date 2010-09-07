using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Dialect;


namespace DataBaseSchemaExport
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration cfg = new Configuration();
            cfg.Configure();
            string[] sqls = cfg.GenerateSchemaCreationScript(new MySQL5Dialect());

            File.WriteAllLines("1.sql", sqls);

            Console.WriteLine("OK");
        }
    }
}
