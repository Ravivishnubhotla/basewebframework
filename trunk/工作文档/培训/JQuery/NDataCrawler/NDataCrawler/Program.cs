using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Common.Logging;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;


namespace NDataCrawler
{
    class Program
    {
        private static ILog log = LogManager.GetLogger(typeof (Program));


        static void Main(string[] args)
        {
            log.Info("开始获取京东类别树页面......");

            //string html = SendRequest("http://www.360buy.com/allSort.aspx",5000);
            string html = SendRequest("http://www.youku.com/playlist_show/id_18474474.html", 5000);

            log.Info("获取京东类别树成功页面......");

            log.Info("开始解析页面......");

            var htmlDocument = new HtmlDocument();

            htmlDocument.LoadHtml(html);

            var htmlDom = htmlDocument.DocumentNode;

            log.Info("解析页面成功......");

            //var topCategorys = htmlDom.CssSelect("div#allsort div.fl div.m div.mt h2 a");
            var topCategorys = htmlDom.CssSelect("ul.v li.v_link a");

            log.Info("开始读取顶级分类......");

 

            foreach (var topCategory in topCategorys)
            {
                log.Info(topCategory.Attributes["href"].Value);

                Process.Start("IExplore.exe", @"iku://|video|http://v.youku.com/v_show/id_XNDc1MDkwMzc2.html|quality=flv|");

                Console.ReadKey();
            }

            log.Info("读取顶级分类结束......");
            //var divs = htmlDom.CssSelect("div.postBody");

            //foreach (var htmlNode in divs)
            //{
            //    Console.WriteLine(htmlNode.InnerHtml);
            //}

            //divs = htmlDom.CssSelect("#cnblogs_post_body");
            //foreach (var htmlNode in divs)
            //{
            //    Console.WriteLine(htmlNode.InnerHtml);
            //} 



            log.Info("操作完成。");

            Console.ReadKey();
        }

        private static string SendRequest(string requesturl, int timeOut)
        {
            try
            {
 

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.Timeout = timeOut;

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(),Encoding.UTF8);

                    string responseText = sr.ReadToEnd();

                    return responseText.Trim();
                }

                return "";
            }
            catch (Exception e)
            {
                return "";
            }
        }
        //private static string SendRequest(string requesturl)
        //{
        //    try
        //    {
        //        var uri = new Uri(requesturl);
        //        var browser1 = new ScrapingBrowser();
        //        return  browser1.DownloadString(uri);
        //    }
        //    catch (Exception ex)
        //    {
        //        return "";
        //    }
        //}
    }
}
