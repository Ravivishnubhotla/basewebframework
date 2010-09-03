using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    public partial class SPChannelSendTestRequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            int channelID = Convert.ToInt32(this.Request.QueryString["ChannleID"]);

            SPChannelWrapper channelWrapper = SPChannelWrapper.FindById(channelID);

            this.hidChannelID.Text = channelWrapper.Id.ToString();

            this.txtChannelName.Text = channelWrapper.Name;

            this.txtChannelSubmitUrl.Text = channelWrapper.InterfaceUrl;

            List<SPChannelParamsWrapper> channelParamsWrappers = channelWrapper.GetAllEnableParams();

            foreach (SPChannelParamsWrapper spChannelParamsWrapper in channelParamsWrappers)
            {
                Anchor anchor = new Anchor();
                anchor.Horizontal = "95%";
                TextField txt = new TextField();
                txt.ID = "txt" + spChannelParamsWrapper.Name;
                txt.FieldLabel = spChannelParamsWrapper.Name;

                if (spChannelParamsWrapper.ParamsMappingName=="linkid")
                {
                    txt.Value = "test" + Guid.NewGuid().ToString();
                }

                if (spChannelParamsWrapper.ParamsMappingName == "mobile")
                {
                    txt.Value = "135" + StringUtil.GetRandNumber(8);
                }

                anchor.Items.Add(txt);
                this.FormLayout1.Anchors.Add(anchor);
            }

        }
    }
}