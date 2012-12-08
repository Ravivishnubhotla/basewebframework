using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScrapySharp.Extensions;

namespace PatchDownloadUtil.AppCode
{
    public class XunleiKuaiChuanDownloadLinkParse : IDownloadLinkParse
    {
        public string Name
        {
            get { return "迅雷快传下载地址分析"; }
        }

        public List<DownloadLink> Parse(string parseUrl)
        {
            string html = Program.SendRequest(parseUrl, Encoding.UTF8, 5000);

            var htmlDocument = new HtmlAgilityPack.HtmlDocument();

            htmlDocument.LoadHtml(html);

            var htmlDom = htmlDocument.DocumentNode;
 
            //var topCategorys = htmlDom.CssSelect("div#allsort div.fl div.m div.mt h2 a");
            var topCategorys = htmlDom.CssSelect("div.file_tr span.c_1 input");

            List<DownloadLink> downloadLinks = new List<DownloadLink>();

            foreach (var topCategory in topCategorys)
            {
                DownloadLink downloadLink = new DownloadLink();
                downloadLink.Text = topCategory.Attributes["file_name"].Value;
                downloadLink.Link = topCategory.Attributes["file_url"].Value;
                downloadLinks.Add(downloadLink);
            }

            return downloadLinks;
        }

        public void PatchDownloadByClient(List<DownloadLink> allDownloadLinks)
        {
 
        }

        public bool CanPatchDownloadByClient
        {
            get { return true; }
        }
    }
}
