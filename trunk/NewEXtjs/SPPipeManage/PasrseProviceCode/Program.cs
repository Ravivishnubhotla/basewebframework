using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace PasrseProviceCode
{
    public class Program
    {
        static void Main(string[] args)
        {
            string connstring = "Initial Catalog=SPSManage;server=ATOM\\SQLEXPRESS;uid=SPSManage;pwd=SPSManage;";

            using (SqlConnection cnn = new SqlConnection(connstring))
            {
                cnn.Open();


                DataSet ds1 = GetDs(cnn,"[s1]");


                DataSet ds2 = GetDs(cnn, "[s2]");


                SortedList<string,HashSet<string>> nameCodes = new SortedList<string, HashSet<string>>();

                List<string> names = new List<string>();

                GetData(ds1, nameCodes, names);

                GetData(ds2, nameCodes, names);

                StringBuilder sb = new StringBuilder();



                foreach (var name in names)
                {
                    string province = "";
                    string city = "";

                    if (name.Contains("-"))
                    {
                        province = name.Split('-')[0].Trim();
                        city = name.Split('-')[1].Trim();
                    }
                    else
                    {
                        province = name.Trim();
                        city = "";
                    }


                    foreach (string mobileN in nameCodes[name])
                    {

                        string phonePrefix = mobileN;


                        Console.WriteLine(province + ":" + city + ":" + phonePrefix);


                        using (SqlCommand cmd = new SqlCommand("INSERT INTO [SPPhoneArea] ([Province],[City],[PhonePrefix]) VALUES (@Province, @City,@PhonePrefix)", cnn))
                        {
                            cmd.Parameters.Add("@Province", SqlDbType.NVarChar).Value = province;
                            cmd.Parameters.Add("@City", SqlDbType.NVarChar).Value = city;
                            cmd.Parameters.Add("@PhonePrefix", SqlDbType.NVarChar).Value = phonePrefix;

                            cmd.ExecuteNonQuery();
                        }


                    }
                }

                //Console.WriteLine(sb.ToString());



                cnn.Close();


                Console.ReadKey();
            }



            Console.ReadKey();

        }

        private static void GetData(DataSet ds1, SortedList<string, HashSet<string>> nameCodes, List<string> names)
        {
            string ckey = "";


            foreach (DataRow row in ds1.Tables[0].Rows)
            {

                if(row["FF1"]==System.DBNull.Value)
                {
                    //Console.WriteLine("NA");
                }
                else
                {
                    string svalue = row["FF1"].ToString();

                    if (svalue.Contains("计算"))
                    {
                        continue;
                    }
                    if (svalue.Contains("号段"))
                    {
                        continue;
                    }

                    
                    if (!svalue.Trim().StartsWith("1"))
                    {
                        if (!nameCodes.ContainsKey(svalue))
                            nameCodes.Add(svalue, new HashSet<string>());
                        names.Add(svalue);

                        ckey = svalue;
                    }
                    else
                    {
                        nameCodes[ckey].Add(svalue);
                    }
                }
            }
        }

        private static DataSet GetDs(SqlConnection cnn, string tbName)
        {
            DataSet ds1 = new DataSet();

            using (SqlDataAdapter dataAdapter = new SqlDataAdapter("Select * from " + tbName, cnn))
            {
                dataAdapter.Fill(ds1);
            }
            return ds1;
        }
    }
}
