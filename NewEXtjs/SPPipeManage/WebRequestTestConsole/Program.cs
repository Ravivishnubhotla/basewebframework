﻿using System;
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

            for (int i = 0; i < 1000; i++)
            {



                try
                {

                    HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(BulidUrl(i, requesturl));
                    webRequest.Timeout = 60000;
                    HttpWebResponse webResponse = null;

                    webResponse = (HttpWebResponse)webRequest.GetResponse();

                    //判断HTTP响应状态 
                    if (webResponse.StatusCode != HttpStatusCode.OK)
                    {
                        j++;
                        Console.WriteLine(string.Format("line {0} failed", i));
                        return;
                    }



                }

                catch
                {
                    j++;
                    Console.WriteLine(string.Format("line {0} failed",i));
                    continue;
                }


                Console.WriteLine(string.Format("line {0} ok", i));

                Thread.Sleep(100);

            }

            Console.WriteLine("Error Count:"+j.ToString());

            Console.ReadKey();

        }


        private static string BulidUrl(int i, string requesturl)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            BulidParams(queryString, "cpid", "1");
            BulidParams(queryString, "mid", "2");
            BulidParams(queryString, "mobile", "13521"+i.ToString("D5"));
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
