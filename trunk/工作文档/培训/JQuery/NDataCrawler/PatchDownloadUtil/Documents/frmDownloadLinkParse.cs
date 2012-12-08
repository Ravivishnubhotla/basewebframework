using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PatchDownloadUtil.AppCode;
using WeifenLuo.WinFormsUI.Docking;

namespace PatchDownloadUtil.Documents
{
    public partial class frmDownloadLinkParse : DockContent
    {
        private IDownloadLinkParse downloadLinkParser;

        public frmDownloadLinkParse(IDownloadLinkParse _downloadLinkParser)
        {
            InitializeComponent();
            downloadLinkParser   = _downloadLinkParser;
            this.Text = _downloadLinkParser.Name + "工具";
        }

        private void tsTop_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "tsbCopyLink":
                    List<DownloadLink> downloadLinks = bsResult.DataSource as List<DownloadLink>;

                    frmShowText frmText = new frmShowText(DownloadLink.GetAllLinksText(downloadLinks));

                    frmText.Show();

                    break;
                case "tsbPatchDownload":
                    List<DownloadLink> allDownloadLinks = bsResult.DataSource as List<DownloadLink>;

                    downloadLinkParser.PatchDownloadByClient(allDownloadLinks);

                    break;
            }
        }

        private void BtnAnalysisUrl_Click(object sender, EventArgs e)
        {
            bsResult.DataSource = downloadLinkParser.Parse(this.TxtUrl.Text.Trim());
        }
    }
}
