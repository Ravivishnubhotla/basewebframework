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
            Console.WriteLine(Encoding.ASCII.GetString(ConvertHexToBytes("3833363137343136343123235550532323534843452323363232353634313030312323303036342323")));
            Console.ReadLine();
        }







        public static byte[] ConvertHexToBytes(string value)
        {
            int len = value.Length / 2;
            byte[] ret = new byte[len];
            for (int i = 0; i < len; i++)
                ret[i] = (byte)(Convert.ToInt32(value.Substring(i * 2, 2), 16));
            return ret;
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
