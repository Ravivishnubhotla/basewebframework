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
        public static DataTable ReadExcelSheet(string sheetName, string excelPath)
        {
            OleDbConnection conn = new OleDbConnection();

            conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelPath + "; Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
 
            conn.Open();

            string sql = string.Format("select * from [Sheet1$]", sheetName);
 
            OleDbCommand olecommand = new OleDbCommand(sql, conn);

            DataSet ds = new DataSet();

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(olecommand);

            dataAdapter.Fill(ds);
 
            conn.Close();

            return ds.Tables[0];
        }
    }
}
