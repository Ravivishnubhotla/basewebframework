using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Web;

namespace WebRequestTestConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            string requesturl = ConfigurationManager.AppSettings["RequestUrl"];

            int j = 0;

            int testDataCount = int.Parse(ConfigurationManager.AppSettings["testDataCount"]);

            int reTryCount = int.Parse(ConfigurationManager.AppSettings["reTryCount"]);

            int sleepTime = int.Parse(ConfigurationManager.AppSettings["sleepTime"]);

            string mobileformat = ConfigurationManager.AppSettings["mobileformat"];

            string msg =  ConfigurationManager.AppSettings["msg"];

            string ywid =  ConfigurationManager.AppSettings["ywid"];

            for (int i = 0; i < testDataCount; i++)
            {
                int retryTimes = 0;

                bool requestOk = false;

                do
                {
                    try
                    {
                        requestOk = SendRequest(i, requesturl, mobileformat, msg, ywid);
                    }
                    catch
                    {
                        requestOk = false;
                    }

                    retryTimes++;

                    if (retryTimes >= reTryCount)
                        break;

                } while (!requestOk);


                if (!requestOk)
                {
                    j++;
                    Console.WriteLine(string.Format("line {0} failed", i));
                }
                else
                {
                    Console.WriteLine(string.Format("line {0} ok", i));               
                }

                Thread.Sleep(sleepTime);

            }

            Console.WriteLine("Error Count:" + j.ToString());

            Console.ReadKey();

        }

        private static bool SendRequest(int i, string requesturl, string mobileformat, string msg, string ywid)
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(BulidUrl(i, requesturl, mobileformat, msg, ywid));

            webRequest.Timeout = 15000;

            HttpWebResponse webResponse = null;

            webResponse = (HttpWebResponse)webRequest.GetResponse();

            return (webResponse.StatusCode == HttpStatusCode.OK);
        }

        //private static bool SendRequest(int i, string requesturl)
        //{

        //}


        private static string BulidUrl(int i, string requesturl, string mobileformat, string msg, string ywid)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            BulidParams(queryString, "cpid", "1");
            BulidParams(queryString, "mid", "2");
            BulidParams(queryString, "mobile",string.Format(mobileformat,i.ToString("D5")));
            BulidParams(queryString, "port", "21");
            BulidParams(queryString, "ywid", ywid);
            BulidParams(queryString, "msg", string.Format(msg,i.ToString("D5")));

            return string.Format("{0}?{1}", requesturl, queryString.ToString());
        }

        private static void BulidParams(NameValueCollection queryString, string key, string value)
        {
            queryString.Add(key, HttpUtility.UrlEncode(value));
        }
    }
}
