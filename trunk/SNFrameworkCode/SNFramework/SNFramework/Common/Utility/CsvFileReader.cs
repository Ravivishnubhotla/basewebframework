using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Text;

namespace Legendigital.Framework.Common.Utility
{
    public class CsvFileReader
    {
        public static DataTable LoadTextFile(string filePath, string sql, bool firstRowAsHeader,string splitColumnChar)
        {
            string hdr = "HDR=";

            if (firstRowAsHeader)
            {
                hdr += "Yes";
            }
            else
            {
                hdr += "No";
            }

            string csvConnString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"text;" + hdr + ";IMEX=1;FMT=Delimited\"" , Path.GetDirectoryName(filePath));

            csvConnString.Substring(0, 49);

            DataSet ds = new DataSet();

            sql = sql.Replace("[$FileName]", "["+Path.GetFileName(filePath)+"]");

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, csvConnString))
            {
                dataAdapter.Fill(ds);
            }

            return ds.Tables[0];
        }

 

        //public static DataTable ReadFile(string filePath, string sWhere)
        //{
        //    string csvConnString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"text;HDR=Yes;FMT=Delimited\";", Path.GetDirectoryName(filePath));

        //    DataSet ds = new DataSet();

        //    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(string.Format("Select F1 As ID,F2 As OrderNumber,F3 As ShipDate,F4 As PONumber,F5 As CustomerName from [{0}] {1}", Path.GetFileName(filePath), sWhere), csvConnString))
        //    {
        //        dataAdapter.Fill(ds);
        //    }

        //    return ds.Tables[0];
        //}
    }
}
