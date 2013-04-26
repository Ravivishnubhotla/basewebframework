using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Utility
{
    public static class ExcelFileReader
    {

        public static string GetFirstTableName(OleDbConnection conn)
        {
            DataTable dt = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            string tableName = dt.Rows[0][2].ToString().Trim();
            return tableName;
        }


        public static DataTable ReadExcelSheet(string excelPath,bool firstRowAsHeader)
        {
            OleDbConnection conn = new OleDbConnection();

            string hdr = "HDR=";

            if (firstRowAsHeader)
            {
                hdr += "Yes";
            }
            else
            {
                hdr += "No";
            }

            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + "; Extended Properties='Excel 8.0;" + hdr + ";IMEX=1'";
 
            conn.Open();

            string sheetName = GetFirstTableName(conn);

            string sql = string.Format("select * from [{0}$]", sheetName);
 
            OleDbCommand olecommand = new OleDbCommand(sql, conn);

            DataSet ds = new DataSet();

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(olecommand);

            dataAdapter.Fill(ds);
 
            conn.Close();

            return ds.Tables[0];
        }
    }
}
