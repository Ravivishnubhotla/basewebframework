using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace RequestSendTools
{
    class Program
    {
        public static string ConnString = ConfigurationManager.ConnectionStrings["sqldb"].ConnectionString;

        static void Main(string[] args)
        {

        }

        public static DataSet QueryData(string sql)
        {
            DataSet ds = new DataSet();
            using(SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, ConnString))
            {
                sqlDataAdapter.Fill(ds);
            }
            return ds;
        }
    }
}
