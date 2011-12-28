using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Code;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{
    public partial class SPChannelSendTestRequestForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

 

            SPChannelWrapper channelWrapper = ChannelID;

            this.hidChannelID.Text = channelWrapper.Id.ToString();

            this.txtChannelName.Text = channelWrapper.Name;

            this.txtChannelSubmitUrl.Text = channelWrapper.InterfaceUrl;


            SPChannelParamsCollection channelParamsWrappers = channelWrapper.ChannelParams;

            foreach (SPChannelParamsWrapper spChannelParamsWrapper in channelParamsWrappers.Items)
            {
 
                TextField txt = new TextField();
                txt.ID = "txt" + spChannelParamsWrapper.Name;
                txt.FieldLabel = spChannelParamsWrapper.Name;

                if (spChannelParamsWrapper.ParamsMappingName == DictionaryConst.Dictionary_SPField_LinkID_Key)
                {
                    txt.Value = "test" + StringUtil.GetRandNumber(10);

                    hidLinkIDeName.Text = txt.ClientID;
                }

                if (spChannelParamsWrapper.ParamsMappingName == DictionaryConst.Dictionary_SPField_Mobile_Key)
                {
                    txt.Value = "135" + StringUtil.GetRandNumber(8);

                    hidMobileName.Text = txt.ClientID;
                }

                if (spChannelParamsWrapper.ParamsMappingName == DictionaryConst.Dictionary_SPField_MO_Key)
                {
                    txt.Value = this.MO;
                }

                if (spChannelParamsWrapper.ParamsMappingName == DictionaryConst.Dictionary_SPField_SpNumber_Key)
                {
                    txt.Value = this.SPCode;
                }

                txt.AnchorHorizontal = "95%";
                this.FormPanel1.Items.Add(txt);
            }

        }

        public SPCodeWrapper CodeID
        {
            get
            {
                if (this.Request.QueryString["CodeID"] != null)
                {
                    return
                        SPCodeWrapper.FindById(int.Parse(this.Request.QueryString["CodeID"]));
                }
                return null;           
            }
        }

        public string MO
        {
            get
            {
                if (CodeID != null)
                {
                    return  CodeID.Mo;
                }
                return "";
            }
        }

        public string SPCode
        {
            get
            {
                if (CodeID != null)
                {
                    return CodeID.SPCode;
                }
                return "";
            }
        }

        public SPChannelWrapper ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannelID"] != null)
                {
                    return
                        SPChannelWrapper.FindById(int.Parse(this.Request.QueryString["ChannelID"]));
                }
                return null;
            }
        }




        [DirectMethod]
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