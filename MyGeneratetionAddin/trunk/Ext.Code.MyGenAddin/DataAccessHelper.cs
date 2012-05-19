using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Legendigital.Code.MyGenAddin
{
    public static class DataAccessHelper
    {
        public static DataSet GetDataSetBySql(string sql)
        {
            DefaultSettings settings = new DefaultSettings();

            using (OleDbConnection cnn = new OleDbConnection(settings.ConnectionString))
            {
                DataSet ds = new DataSet();
                cnn.Open();
                OleDbCommand cmd = cnn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = sql;
                OleDbDataAdapter dpt = new OleDbDataAdapter();
                dpt.SelectCommand = cmd;
                dpt.Fill(ds);
                cnn.Close();
                return ds;
            }
        }
    }
}
