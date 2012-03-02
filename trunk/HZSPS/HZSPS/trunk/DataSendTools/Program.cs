using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Common.Logging;

namespace DataSendTools
{
    class Program
    {
        private static ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {

            //DateTime startdate = Convert.ToDateTime("2011-07-15 10:01:00");
            //DateTime enddate = Convert.ToDateTime("2011-07-15 10:02:02");

            //int feetime = Convert.ToInt32(Math.Ceiling(Convert.ToDouble((enddate - startdate).TotalSeconds) / 60));

            //Console.WriteLine(feetime);

            //Console.WriteLine(startdate.ToString("yyMMddhhmmss"));

            //return;


            DataSet ds = GetData(ConfigurationManager.AppSettings["selectSQL"]);

            string sendUrlTemplate = ConfigurationManager.AppSettings["sendUrl"];

            int rows = ds.Tables[0].Rows.Count;

            int i = 0;

            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                i++;

                string sendurl = sendUrlTemplate;

                sendurl = sendurl.Replace("{" + ConfigurationManager.AppSettings["fieldMO"] + "}",
                                          dr[ConfigurationManager.AppSettings["fieldMO"]].ToString());

                sendurl = sendurl.Replace("{" + ConfigurationManager.AppSettings["fieldLinkID"] + "}",
                                          dr[ConfigurationManager.AppSettings["fieldLinkID"]].ToString());

                sendurl = sendurl.Replace("{" + ConfigurationManager.AppSettings["fieldMobile"] + "}",
                                          dr[ConfigurationManager.AppSettings["fieldMobile"]].ToString());

                sendurl = sendurl.Replace("{" + ConfigurationManager.AppSettings["fieldSPCode"] + "}",
                                          dr[ConfigurationManager.AppSettings["fieldSPCode"]].ToString());

                logger.Info(sendurl);

                try
                {
                    int retryTimes = 0;

                    bool requestOk = false;

                    do
                    {

                        string errorMessage = string.Empty;

                        requestOk = SendRequest(sendurl, 10000, "ok", out errorMessage);

                        if (!requestOk)
                        {
                            logger.Error("请求失败， 错误信息：" + errorMessage + ",dataid=" +
                                         dr[ConfigurationManager.AppSettings["fieldLinkID"]].ToString());

                            Thread.Sleep(300);

                        }

                        retryTimes++;

                        if (retryTimes >= 3)
                            break;

                    } while (!requestOk);

                    logger.Info(string.Format("请求成功，ID:{0}", dr[ConfigurationManager.AppSettings["fieldLinkID"]].ToString()));
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("请求失败，ID{0}", dr[ConfigurationManager.AppSettings["fieldLinkID"]].ToString()), ex);
                }
            }
        
        }

        private static bool SendRequest(string requesturl, int timeOut, string okMessage, out string errorMessage)
        {
            try
            {
                errorMessage = "";

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.Timeout = timeOut;

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);

                    string responseText = sr.ReadToEnd();

                    return responseText.Trim().ToLower().Equals(okMessage);
                }

                return false;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
        }

        private static DataSet GetData(string sql)
        {
            DataSet ds1 = new DataSet();
         
            using (SqlConnection cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["datacnn"].ConnectionString))
            {
                cnn.Open();

                using (SqlDataAdapter dataAdapter = new SqlDataAdapter(sql, cnn))
                {
                    dataAdapter.Fill(ds1);
                }

                cnn.Close();

                return ds1;
            }
        }


    }
}
