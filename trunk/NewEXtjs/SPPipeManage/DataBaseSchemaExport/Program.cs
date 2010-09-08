﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;


namespace DataBaseSchemaExport
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration cfg = new Configuration();
            
            cfg.Configure();
            
            string[] sqls = cfg.GenerateSchemaCreationScript(new MySQL5Dialect());

            File.WriteAllLines("MySQL5.sql", sqls);

            Console.WriteLine("OK");
        }
    }
}
