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
        //public static DataTable ReadFile(string filePath)
        //{
        //    string csvConnString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"text;HDR=No;FMT=Delimited\";", Path.GetDirectoryName(filePath));

        //    DataSet ds = new DataSet();

        //    using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(string.Format("Select F1 As ID,F2 As OrderNumber,F3 As ID,F4 As ID,F5 As ID from [{0}]", Path.GetFileName(filePath)), csvConnString))
        //    {
        //        dataAdapter.Fill(ds);
        //    }

        //    return ds.Tables[0];
        //}


        public static DataTable ReadKeyIndexFile(string filePath)
        {
            string csvConnString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"text;HDR=No;IMEX=1;FMT=Delimited\";", Path.GetDirectoryName(filePath));

            DataSet ds = new DataSet();

            string sql =
                string.Format(
                    "Select F1 As OrderNumber,F2 As ShipDate,F3 As PONumber,F4 As CustomerName from [{0}]",
                    Path.GetFileName(filePath));

            using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sql, csvConnString))
            {
                dataAdapter.Fill(ds);
            }

            return ds.Tables[0];
        }

        public static DataTable ReadPodsKeyIndexFile(string filePath)
        {
            string csvConnString = string.Format("Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=\"text;HDR=No;IMEX=1;FMT=Delimited\";", Path.GetDirectoryName(filePath));

            DataSet ds = new DataSet();

            string sql =
                string.Format(
                    "Select F1 As ShipToNumber,F2 As OrderNumber,F3 As ShipDate,F4 As PONumber,F5 As CustomerName from [{0}]",
                    Path.GetFileName(filePath));

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
