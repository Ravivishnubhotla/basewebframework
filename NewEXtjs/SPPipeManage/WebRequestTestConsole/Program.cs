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

            for (int i = 0; i < 10; i++)
            {
                int retryTimes = 0;

                bool requestOk = false;

                do
                {
                    try
                    {
                        requestOk = SendRequest(i, requesturl);
                    }
                    catch
                    {
                        requestOk = false;
                    }

                    retryTimes++;

                    if(retryTimes>=3)
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








                Thread.Sleep(200);

            }

            Console.WriteLine("Error Count:" + j.ToString());

            Console.ReadKey();

        }

        private static bool SendRequest(int i, string requesturl)
        {
            HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(BulidUrl(i, requesturl));

            webRequest.Timeout = 15000;

            HttpWebResponse webResponse = null;

            webResponse = (HttpWebResponse)webRequest.GetResponse();

            return (webResponse.StatusCode == HttpStatusCode.OK);
        }


        private static string BulidUrl(int i, string requesturl)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            BulidParams(queryString, "cpid", "1");
            BulidParams(queryString, "mid", "2");
            BulidParams(queryString, "mobile", "13521" + i.ToString("D5"));
            BulidParams(queryString, "port", "21");
            BulidParams(queryString, "ywid", "10000903");
            BulidParams(queryString, "msg", "msg" + i.ToString("D5"));

            return string.Format("{0}?{1}", requesturl, queryString.ToString());
        }

        private static void BulidParams(NameValueCollection queryString, string key, string value)
        {
            queryString.Add(key, HttpUtility.UrlEncode(value));
        }
    }
}
