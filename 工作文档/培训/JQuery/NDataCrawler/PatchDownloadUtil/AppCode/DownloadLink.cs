using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScrapySharp.Extensions;

namespace PatchDownloadUtil.AppCode
{
    [Serializable]
    public class DownloadLink
    {
        private string text;
        private string link;

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public static string GetAllLinksText(List<DownloadLink> downloadLinks)
        {
            StringBuilder sbLinks = new StringBuilder();

            for (int i = 0; i < downloadLinks.Count; i++)
            {
                sbLinks.AppendLine(downloadLinks[i].Link);
            }

            return sbLinks.ToString();
        }


        public static List<DownloadLink> GetYouKuLinks(string url)
        {
            string html = Program.SendRequest(url, Encoding.UTF8, 5000);

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
    }
}
