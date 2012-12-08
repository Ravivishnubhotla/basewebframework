using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PatchDownloadUtil.Properties;
using WeifenLuo.WinFormsUI.Docking;

namespace PatchDownloadUtil.Documents
{
    public partial class frmDownloadYouku : DockContent 
    {
        public frmDownloadYouku()
        {
            InitializeComponent();

            this.Icon = Resources.youku1;
        }

        private void BtnAnalysisUrl_Click(object sender, EventArgs e)
        {
            string html = Program.SendRequest("http://www.youku.com/playlist_show/id_18474474.html",Encoding.UTF8, 5000);


            var htmlDocument = new HtmlAgilityPack.HtmlDocument();

            htmlDocument.LoadHtml(html);

            var htmlDom = htmlDocument.DocumentNode;
 

            //var topCategorys = htmlDom.CssSelect("div#allsort div.fl div.m div.mt h2 a");
            var topCategorys = htmlDom.CssSelect("ul.v li.v_link a");



        }


    }
}
