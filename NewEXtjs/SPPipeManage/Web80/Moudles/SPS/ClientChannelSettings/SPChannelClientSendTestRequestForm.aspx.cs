using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    public partial class SPChannelClientSendTestRequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            int spClientChannelID = Convert.ToInt32(this.Request.QueryString["ChannleClientID"]);

            SPClientChannelSettingWrapper settingWrapper = SPClientChannelSettingWrapper.FindById(spClientChannelID);

            this.hidChannelClientID.Text = settingWrapper.Id.ToString();

            this.txtChannelName.Text = settingWrapper.Name;

            this.txtChannelSubmitUrl.Text = settingWrapper.ChannelID.InterfaceUrl;

            this.lblChannelCode.Text = settingWrapper.ChannelCode;

            List<SPChannelParamsWrapper> channelParamsWrappers = settingWrapper.ChannelID.GetAllEnableParams();

            foreach (SPChannelParamsWrapper spChannelParamsWrapper in channelParamsWrappers)
            {
                Anchor anchor = new Anchor();
                anchor.Horizontal = "95%";
                TextField txt = new TextField();
                txt.ID = "txt" + spChannelParamsWrapper.Name;
                txt.FieldLabel = spChannelParamsWrapper.Name;

                if (spChannelParamsWrapper.ParamsMappingName == "linkid")
                {
                    txt.Value = "99999" +StringUtil.GetRandNumber(15);

                    hidLinkIDeName.Text = txt.ClientID;
                }

                if (spChannelParamsWrapper.ParamsMappingName == "mobile")
                {
                    txt.Value = "135" + StringUtil.GetRandNumber(8);

                    hidMobileName.Text = txt.ClientID;
                }

                if (spChannelParamsWrapper.ParamsMappingName == "cpid")
                {
                    if (!string.IsNullOrEmpty(settingWrapper.ChannelCode))
                        txt.Value = settingWrapper.ChannelCode;
                }

                if (spChannelParamsWrapper.ParamsMappingName == "ywid")
                {
                    if (!string.IsNullOrEmpty(settingWrapper.CommandCode))
                        txt.Value = settingWrapper.CommandCode;
                }

                anchor.Items.Add(txt);
                this.FormLayout1.Anchors.Add(anchor);
            }
        }




        [AjaxMethod]
        public SPMessage GetTestSPMessage()
        {
            SPMessage spMessage = new SPMessage();
            spMessage.LinkID = "99999" + StringUtil.GetRandNumber(15);
            spMessage.Mobile = "135" + StringUtil.GetRandNumber(8);
            spMessage.Mo = "";
            spMessage.SPCode = "";
            return spMessage;
        }
    }
}