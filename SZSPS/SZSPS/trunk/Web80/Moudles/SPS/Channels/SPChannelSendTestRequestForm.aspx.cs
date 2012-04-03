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

        public SPClientChannelSettingWrapper ClientChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannleClientID"] != null)
                {
                    return
                        SPClientChannelSettingWrapper.FindById(int.Parse(this.Request.QueryString["ChannleClientID"]));
                }
                return null;
            }
        }

        //public string MO
        //{
        //    get
        //    {
        //        if (CodeID != null)
        //        {
        //            return CodeID.Mo;
        //        }
        //        return "";
        //    }
        //}

        //public string SPCode
        //{
        //    get
        //    {
        //        if (CodeID != null)
        //        {
        //            return CodeID.SPCode;
        //        }
        //        return "";
        //    }
        //}

        public SPChannelWrapper ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannleID"] != null)
                {
                    return
                        SPChannelWrapper.FindById(int.Parse(this.Request.QueryString["ChannleID"]));
                }
                return null;
            }
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;



            this.txtChannelName.Text = ChannelID.Name;

            this.txtChannelSubmitUrl.Text = ChannelID.InterfaceUrl;

            List<SPChannelParamsWrapper> channelParamsWrappers = ChannelID.GetAllEnableParams();

            List<string> dataParams = new List<string>();

            List<string> dataStatusParams = new List<string>();

            foreach (SPChannelParamsWrapper spChannelParamsWrapper in channelParamsWrappers)
            {
                Anchor anchor = new Anchor();
                anchor.Horizontal = "95%";
                TextField txt = new TextField();
                txt.ID = "txt" + spChannelParamsWrapper.Name;
                txt.FieldLabel = spChannelParamsWrapper.Name;

                if (spChannelParamsWrapper.ParamsMappingName=="linkid")
                {
                    txt.Value = "99999" + StringUtil.GetRandNumber(10);

                    hidLinkIDeName.Text = txt.ClientID;

                    dataStatusParams.Add(txt.ClientID);
                }

                if (spChannelParamsWrapper.ParamsMappingName == "mobile")
                {
                    txt.Value = "135" + StringUtil.GetRandNumber(8);

                    hidMobileName.Text = txt.ClientID;
                }

                if (spChannelParamsWrapper.ParamsMappingName == "cpid")
                {
                    if (!string.IsNullOrEmpty(ClientChannelID.ChannelCode))
                        txt.Value = ClientChannelID.ChannelCode;
                }

                if (spChannelParamsWrapper.ParamsMappingName == "ywid")
                {
                    if (!string.IsNullOrEmpty(ClientChannelID.CommandCode))
                        txt.Value = ClientChannelID.CommandCode;
                }

                if (spChannelParamsWrapper.Name != this.ChannelID.StatParamsName)
                {
                    dataParams.Add(txt.ClientID);               
                }
                else
                {
                    dataStatusParams.Add(txt.ClientID);
                }


                anchor.Items.Add(txt);
                this.FormLayout1.Anchors.Add(anchor);


            }

            if (this.ChannelID.RecStatReport.HasValue && this.ChannelID.RecStatReport.Value && !dataStatusParams.Contains("txt" + this.ChannelID.StatParamsName))
            {
                Anchor anchor = new Anchor();
                anchor.Horizontal = "95%";
                TextField statusField = new TextField();
                statusField.ID = "txt" + this.ChannelID.StatParamsName;
                statusField.FieldLabel = this.ChannelID.StatParamsName;
                statusField.Text = this.ChannelID.StatParamsValues;
                anchor.Items.Add(statusField);
                dataStatusParams.Add(statusField.ClientID);
                this.FormLayout1.Anchors.Add(anchor);
                hidStatusName.Text = statusField.ClientID;
                this.FormPanel1.Items.Add(statusField);
            }

            hidDataParam.Text = string.Join(",", dataParams.ToArray());

            hidDataStatusParam.Text = string.Join(",", dataStatusParams.ToArray());

        }








        [AjaxMethod]
        public SPMessage GetTestSPMessage()
        {
            SPMessage spMessage = new SPMessage();
            spMessage.LinkID = "test" + StringUtil.GetRandNumber(10);
            spMessage.Mobile = "135" + StringUtil.GetRandNumber(8);
            spMessage.Mo = "";
            spMessage.SPCode = "";
            return spMessage;
        }

    }
}