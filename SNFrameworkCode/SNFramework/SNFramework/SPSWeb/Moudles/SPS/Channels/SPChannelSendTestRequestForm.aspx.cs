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
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Channels
{
    public partial class SPChannelSendTestRequestForm : BasePage
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

            TextField statusField = null;

            List<string> dataParams = new List<string>();

            List<string> dataStatusParams = new List<string>();

            foreach (SPChannelParamsWrapper spChannelParamsWrapper in channelParamsWrappers.Items)
            {



                TextField txt = new TextField();
                txt.ID = "txt" + spChannelParamsWrapper.Name;
                txt.FieldLabel = spChannelParamsWrapper.Name;

                if (!this.ChannelID.IsAutoLinkID && spChannelParamsWrapper.ParamsMappingName == DictionaryConst.Dictionary_SPField_LinkID_Key)
                {
                    txt.Value = "test" + StringUtil.GetRandNumber(10);

                    hidLinkIDName.Text = txt.ClientID;

                    dataStatusParams.Add(txt.ClientID);
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

                if (this.ChannelID.ChannelType == DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
                {
                    if ((this.ChannelID.IVRFeeTimeType == "0") && spChannelParamsWrapper.ParamsMappingName == DictionaryConst.Dictionary_SPField_FeeTime_Key)
                    {
                        txt.Value = "2";
                    }

                    Random random = new Random(Guid.NewGuid().GetHashCode());

                    DateTime teststartdt =
                        System.DateTime.Now.AddDays(-1 * random.Next(1, 3)).AddHours(random.Next(-12, 12)).AddMinutes(
                            random.Next(-30, 30)).AddSeconds(random.Next(-30, 30));

                    DateTime testenddt = teststartdt.AddSeconds(50);

                    if (spChannelParamsWrapper.ParamsMappingName == DictionaryConst.Dictionary_SPField_StartTime_Key)
                    {
                        if (this.ChannelID.IVRFeeTimeType == "1")
                            txt.Value = teststartdt.ToString(this.ChannelID.IVRTimeFormat);
                        else
                            txt.Value = teststartdt.ToString("yyyy-MM-dd hh:mm:ss");
                    }

                    if (spChannelParamsWrapper.ParamsMappingName == DictionaryConst.Dictionary_SPField_EndTime_Key)
                    {
                        if (this.ChannelID.IVRFeeTimeType == "1")
                            txt.Value = testenddt.ToString(this.ChannelID.IVRTimeFormat);
                        else
                            txt.Value = testenddt.ToString("yyyy-MM-dd hh:mm:ss");
                    }
                }

                if (spChannelParamsWrapper.ParamsMappingName == DictionaryConst.Dictionary_SPField_State_Key)
                {
                    TextField tf = this.FormPanel1.Items.Find(p => p.ID == txt.ClientID) as TextField;

                    if (tf != null)
                    {
                        statusField = tf;

                        hidStatusName.Text = tf.ClientID;

                        continue;
                    }
                    else
                    {
                        statusField = txt;

                        hidStatusName.Text = txt.ClientID;
                    }
                }

                if (spChannelParamsWrapper.ParamsMappingName != DictionaryConst.Dictionary_SPField_State_Key)
                    dataParams.Add(txt.ClientID);

                txt.AnchorHorizontal = "95%";
                this.FormPanel1.Items.Add(txt);
            }

            if (this.ChannelID.IsStateReport && statusField == null && !this.FormPanel1.Items.Exists(p => p.ID == "txt" + this.ChannelID.StateReportParamName))
            {
                statusField = new TextField();
                statusField.ID = "txt" + this.ChannelID.StateReportParamName;
                statusField.FieldLabel = this.ChannelID.StateReportParamName;
                statusField.AnchorHorizontal = "95%";
                hidStatusName.Text = statusField.ClientID;
                this.FormPanel1.Items.Add(statusField);
            }

            if (statusField != null)
            {
                dataStatusParams.Add(statusField.ClientID);
            }

            if (this.ChannelID.IsStateReport && statusField != null && this.ChannelID.StateReportType != DictionaryConst.Dictionary_ChannelStateReportType_SendTwiceTypeRequest_Key)
            {
                statusField.Value = this.ChannelID.StateReportParamValue;
            }

            hidDataParam.Text = string.Join(",", dataParams.ToArray());

            hidDataStatusParam.Text = string.Join(",", dataStatusParams.ToArray());



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
                    return CodeID.Mo;
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