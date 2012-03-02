using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using Common.Logging;

namespace UrlPatchSender
{
    class Program
    {

        private static ILog logger = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            string fileName = ConfigurationManager.AppSettings["FileName"];

            string fileType = ConfigurationManager.AppSettings["FileType"];

            string[] urls = GetUrls(fileName, fileType); 

            int i = 0;

            foreach (string url in urls)
            {
                i++;

                string sendurl = url;



                logger.Info(sendurl);

                try
                {
                    int retryTimes = 0;

                    bool requestOk = false;

                    do
                    {

                        string errorMessage = string.Empty;

                       requestOk = true;



                         //requestOk = SendRequest(sendurl, 10000, "ok", out errorMessage);

                        if (!requestOk)
                        {
                            logger.Error("请求失败， 错误信息：" + errorMessage + ",line=" + i.ToString() + ",url" + sendurl);

                            Thread.Sleep(300);

                        }

                        retryTimes++;

                        if (retryTimes >= 3)
                            break;

                    } while (!requestOk);

                    logger.Info(string.Format("请求成功，ID:{0}", i.ToString()));
                }
                catch (Exception ex)
                {
                    logger.Error(string.Format("请求失败，ID{0}", i.ToString()), ex);
                }
            }


        }

        private static string[] GetUrls(string fileName, string fileType)
        {
            switch (fileType.ToLower())
            {
                case "url":
                    return File.ReadAllLines(fileName);
                    break;
                case "a":
                    string[] lines = File.ReadAllLines(fileName);

                    for (int i = 0; i < lines.Length; i++)
                    {
                        int start  = lines[i].ToLower().IndexOf("http://");
                        lines[i] = lines[i].Substring(start, lines[i].Length - start);
                    }
                    return lines;
                    break;
                case "b":
                    List<string> lin = new List<string>();
                    DataTable dt = ReadCsv();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string u = dt.Rows[i]["F5"].ToString();

                        if(u.Trim().EndsWith("1"))
                            lin.Add(dt.Rows[i]["F5"].ToString());
                    }
                    return lin.ToArray();
                    break;
            }

            return new string[]{};

        }

        private static DataTable ReadCsv()
        {
            DataSet ds = new DataSet();
            using (OleDbDataAdapter adapter = new OleDbDataAdapter("select * from [cid 19.txt] ", @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=E:\Projects\SPPipeManage\UrlPatchSender\bin\Release;Extended Properties='text;HDR=No;FMT=Delimited'"))
            {
                adapter.Fill(ds);
            }
            return ds.Tables[0];
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
    }
}
