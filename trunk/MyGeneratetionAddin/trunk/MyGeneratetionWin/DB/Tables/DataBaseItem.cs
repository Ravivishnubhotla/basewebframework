using System.Collections.Generic;
using Legendigital.Code.MyGenAddin;
using MyMeta;
using SubSonic.SqlGeneration.Schema;

namespace MyGeneratetionWin.DB.Tables
{
    public class DataBaseItem
    {
        [SubSonicPrimaryKey]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Connstring { get; set; }
        public string DefaultDatabaseName { get; set; }

        public DataBaseItem()
        {
            Name = "";
            Description = "";
            Connstring = "";
            DefaultDatabaseName = "";
        }

        public List<ITable> GetAllTables()
        {
            dbRoot db = new dbRoot();

            db.Connect(dbDriver.SQL, this.Connstring);

            List<ITable> tables = new List<ITable>();

            foreach (ITable table in db.DefaultDatabase.Tables)
            {
                tables.Add(table);
            }

            return tables;
        }

        public List<ITable> GetAllExportTablesOrders()
        {
            dbRoot db = new dbRoot();

            db.Connect(dbDriver.SQL, this.Connstring);

            List<ITable> tables = TableGenerationHelper.GetAllExportDataOrderTables(db.DefaultDatabase);

            return tables;        
        }
    }
}
