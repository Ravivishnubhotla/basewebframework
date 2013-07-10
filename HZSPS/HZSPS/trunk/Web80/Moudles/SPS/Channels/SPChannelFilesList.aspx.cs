using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    public partial class SPChannelFilesList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;
            this.gridPanelSPChannel.Reload();
        }

        public string ChannleFileType
        {
            get
            {
                if (this.Request.QueryString["ChannleFileType"] == null)
                    return "";
                return this.Request.QueryString["ChannleFileType"];
            }
        }

        public string FileDir
        {
            get
            {
                string filePath = "~/SPSInterface/";

                if (ChannleFileType == "1")
                    filePath = "~/SPSInterface/";
                else if (ChannleFileType == "2")
                    filePath = "~/ConvertRules/";

                return this.Server.MapPath(filePath);
            }
        }

        protected void storeSPChannelFiles_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            List<FileInfo> files = new List<FileInfo>();

            string[] fileNames = Directory.GetFiles(FileDir);

            foreach (string fileName in fileNames)
            {
                files.Add(new FileInfo(fileName));
            }

            if (!string.IsNullOrEmpty(this.txtSreachName.Text.Trim()))
            {
                storeSPChannelFiles.DataSource = files.FindAll(p => (p.Name.Contains(this.txtSreachName.Text.Trim())));
            }
            else
            {
                storeSPChannelFiles.DataSource = files;
            }

            storeSPChannelFiles.DataBind();
        }
    }
}