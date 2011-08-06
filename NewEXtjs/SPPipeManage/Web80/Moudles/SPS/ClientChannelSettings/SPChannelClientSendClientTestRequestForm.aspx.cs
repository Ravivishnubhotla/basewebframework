using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;
using Legendigital.Framework.Common.Web.Request;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    public partial class SPChannelClientSendClientTestRequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            int spClientChannelID = Convert.ToInt32(this.Request.QueryString["ChannleClientID"]);

            SPClientChannelSettingWrapper settingWrapper = SPClientChannelSettingWrapper.FindById(spClientChannelID);

            this.hidChannelClientID.Text = settingWrapper.Id.ToString();

            this.lblChannelName.Text = settingWrapper.ChannelName;

            this.txtClientSycnUrl.Text = settingWrapper.SyncDataUrl;

            this.lblCode.Text = settingWrapper.ChannelClientCode;

            this.lblOkMessage.Text = settingWrapper.OkMessage;

            this.lblClientName.Text = settingWrapper.ClientName;

            this.lblClientGroupName.Text = settingWrapper.ClientGroupName;

            NameValueCollection sendParams = settingWrapper.GetAllSendParams();

            foreach (string sendParamKey in sendParams.AllKeys)
            {
                Anchor anchor = new Anchor();
                anchor.Horizontal = "95%";
                TextField txt = new TextField();
                txt.ID = "txt" + sendParamKey;
                txt.FieldLabel = sendParamKey;

                if (sendParams[sendParamKey] == "linkid" || sendParamKey == "linkid")
                {
                    txt.Value = "99999" + StringUtil.GetRandNumber(15);

                    hidLinkIDeName.Text = txt.ClientID;
                }

                if (sendParams[sendParamKey] == "mobile" || sendParamKey == "mobile")
                {
                    txt.Value = "135" + StringUtil.GetRandNumber(8);

                    hidMobileName.Text = txt.ClientID;
                }

                if (sendParams[sendParamKey] == "cpid" || sendParamKey == "spCode")
                {
                    if (!string.IsNullOrEmpty(settingWrapper.ChannelCode))
                        txt.Value = settingWrapper.ChannelCode;
                }

                if (sendParams[sendParamKey] == "ywid" || sendParamKey == "mo")
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


        [AjaxMethod]
        public string SubmitUrl(string url)
        {
            WebRequestResult result = WebRequestHelper.SendRequest(url, 10000);

            if(result.IsSuccess)
            {
                return result.ResponseText;
            }
            else
            {
                return result.ErrorMessage;            
            }
        }
    }
}