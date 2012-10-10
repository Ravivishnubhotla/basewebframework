using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Clients
{
    public partial class SPSClientCodeSycnTestForm : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            int clientCodeRelationID = Convert.ToInt32(this.Request.QueryString["ClientCodeRelationID"]);

            SPClientCodeRelationWrapper clientCodeRelation = SPClientCodeRelationWrapper.FindById(clientCodeRelationID);

            if (clientCodeRelation != null)
            {
                this.lblChannelName.Text = clientCodeRelation.CodeID_ChannelID.Name;



                this.lblCode.Text = clientCodeRelation.CodeID.MoCode;

                if (clientCodeRelation.SyncData && clientCodeRelation.SyncDataSetting != null)
                {
                    this.txtClientSycnUrl.Text = clientCodeRelation.SyncDataSetting.SycnMOUrl;

                    this.lblOkMessage.Text = clientCodeRelation.SyncDataSetting.SycnMOOkMessage;
                }



                this.lblClientName.Text = clientCodeRelation.ClientID_Name;

                NameValueCollection sendParams = clientCodeRelation.GetAllSycnParams();

                foreach (string sendParamKey in sendParams.AllKeys)
                {
                    TextField txt = new TextField();
                    txt.ID = "txt" + sendParamKey;
                    txt.FieldLabel = sendParamKey;
                    txt.AnchorHorizontal = "95%";

                    if (sendParams[sendParamKey] == DictionaryConst.Dictionary_SPField_LinkID_Key.ToLower() || sendParamKey == DictionaryConst.Dictionary_SPField_LinkID_Key.ToLower())
                    {
                        txt.Value = "99999" + StringUtil.GetRandNumber(15);
                        txt.DataIndex = "linkid";
                        hidLinkIDName.Text = txt.ClientID;
                    }

                    if (sendParams[sendParamKey] == DictionaryConst.Dictionary_SPField_Mobile_Key.ToLower() || sendParamKey == DictionaryConst.Dictionary_SPField_Mobile_Key.ToLower())
                    {
                        txt.Value = "135" + StringUtil.GetRandNumber(8);
                        txt.DataIndex = "mobile";
                        hidMobileName.Text = txt.ClientID;
                    }

                    if (sendParams[sendParamKey] == DictionaryConst.Dictionary_SPField_SpNumber_Key.ToLower() || sendParamKey == DictionaryConst.Dictionary_SPField_SpNumber_Key.ToLower())
                    {
                        if (!string.IsNullOrEmpty(clientCodeRelation.CodeID.SPCode))
                            txt.Value = clientCodeRelation.CodeID.SPCode;
                    }

                    if (sendParams[sendParamKey] == DictionaryConst.Dictionary_SPField_MO_Key.ToLower() || sendParamKey == DictionaryConst.Dictionary_SPField_MO_Key.ToLower())
                    {
                        if (!string.IsNullOrEmpty(clientCodeRelation.CodeID.Mo))
                            txt.Value = clientCodeRelation.CodeID.Mo; ;
                    }

                    this.FormPanel1.Items.Add(txt);

                }
            }


        }




        [DirectMethod]
        public object GetTestSPSData()
        {
            return new { LinkID = "99999" + StringUtil.GetRandNumber(15), Mobile = "135" + StringUtil.GetRandNumber(8) };
        }


        //[DirectMethod]
        //public string SubmitUrl(string url)
        //{
        //    WebRequestResult result = WebRequestHelper.SendRequest(url, 10000);

        //    if (result.IsSuccess)
        //    {
        //        return result.ResponseText;
        //    }
        //    else
        //    {
        //        return result.ErrorMessage;
        //    }
        //}
    }
}