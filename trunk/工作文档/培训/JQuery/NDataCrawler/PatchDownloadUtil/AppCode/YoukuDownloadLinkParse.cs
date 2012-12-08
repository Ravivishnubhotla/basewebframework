using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using ScrapySharp.Extensions;

namespace PatchDownloadUtil.AppCode
{
    public class YoukuDownloadLinkParse : IDownloadLinkParse
    {
        public string Name 
        {
            get { return "优酷专题下载地址分析"; }
        }

        public List<DownloadLink> Parse(string parseUrl)
        {
            string html = Program.SendRequest(parseUrl, Encoding.UTF8, 5000);

            var htmlDocument = new HtmlAgilityPack.HtmlDocument();

            htmlDocument.LoadHtml(html);

            var htmlDom = htmlDocument.DocumentNode;

            //var topCategorys = htmlDom.CssSelect("div#allsort div.fl div.m div.mt h2 a");
            var topCategorys = htmlDom.CssSelect("ul.v li.v_link a");

            List<DownloadLink> downloadLinks = new List<DownloadLink>();

            foreach (var topCategory in topCategorys)
            {
                DownloadLink downloadLink = new DownloadLink();
                downloadLink.Text = topCategory.Attributes["title"].Value;
                downloadLink.Link = topCategory.Attributes["href"].Value;
                downloadLinks.Add(downloadLink);
            }

            return downloadLinks;
        }

        public void PatchDownloadByClient(List<DownloadLink> allDownloadLinks)
        {
            if (CanPatchDownloadByClient)
            {
                foreach (var allDownloadLink in allDownloadLinks)
                {
                    Process pdl =
                        Process.Start(@"iku://|video|" + allDownloadLink.Link + @"|quality=flv|");

                    if (pdl!=null)
                        pdl.WaitForInputIdle();

                    //Thread.Sleep(500);
                }
            }
        }

        public bool CanPatchDownloadByClient {
            get { return true; }
        }
    }
}
