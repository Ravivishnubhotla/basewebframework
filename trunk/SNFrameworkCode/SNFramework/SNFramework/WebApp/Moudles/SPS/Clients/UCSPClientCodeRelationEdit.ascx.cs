using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPS.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.ControlHelper;
using Ext.Net;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPClientCodeRelationEdit")]
    public partial class UCSPClientCodeRelationEdit : System.Web.UI.UserControl
    {
        public bool ShowForClient
        {
            get
            {
                if (this.ViewState["ShowForClient"]==null)
                    this.ViewState["ShowForClient"] = false;
                return (bool) this.ViewState["ShowForClient"];
            }
            set { this.ViewState["ShowForClient"] = value; }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            txtChannelID.Hidden = ShowForClient;
            txtCodeID.Hidden = ShowForClient;
            txtPrice.Hidden = ShowForClient;
            txtInterceptRate.Hidden = ShowForClient;
            txtSycnNotInterceptCount.Hidden = ShowForClient;
         
        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPClientCodeRelationWrapper obj = SPClientCodeRelationWrapper.FindById(id);

                if (obj != null)
                {

                    this.txtChannelID.Text = obj.CodeID_ChannelID.Name;
                    this.txtCodeID.Text = obj.CodeID.MoCode;
                    this.txtPrice.Text = obj.Price.ToString();
                    this.txtInterceptRate.Text = obj.InterceptRate.ToString();
                    this.txtSycnNotInterceptCount.Text = obj.SycnNotInterceptCount.ToString();

                    this.chkSyncData.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.SyncData);
  
                    this.txtSycnRetryTimes.Text = ValueConvertUtil.ConvertStringValue(obj.SycnRetryTimes);

                    if(obj.SyncDataSetting!=null)
                    {
                        this.txtSycnDataUrl.Text = ValueConvertUtil.ConvertStringValue(obj.SyncDataSetting.SycnMOUrl);
                        this.txtSycnOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.SyncDataSetting.SycnMOOkMessage);
                        this.txtSycnFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.SyncDataSetting.SycnMOFailedMessage);
                    }
                    else
                    {
                        this.txtSycnDataUrl.Text = "";
                        this.txtSycnOkMessage.Text = "";
                        this.txtSycnFailedMessage.Text = "";
                    }


 
 

 



                    hidId.Text = id.ToString();


                    winSPClientCodeRelationEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：数据不存在！";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPClientCodeRelation_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPClientCodeRelationWrapper obj = SPClientCodeRelationWrapper.FindById(int.Parse(hidId.Text.Trim()));

                if (!ShowForClient)
                {
                    obj.Price = Convert.ToDecimal(this.txtPrice.Text.Trim());
                    obj.InterceptRate = Convert.ToDecimal(this.txtInterceptRate.Text.Trim());
                    obj.SyncData = this.chkSyncData.Checked;
                    obj.SycnRetryTimes = this.txtSycnRetryTimes.Text.Trim();
                    obj.SycnNotInterceptCount = Convert.ToInt32(this.txtSycnNotInterceptCount.Text.Trim());
                }

                if (obj.SyncDataSetting == null)
                {
                    obj.SyncDataSetting = new SPSDataSycnSettingWrapper();

                    SPSDataSycnSettingWrapper.Save(obj.SyncDataSetting);
                }

 
                obj.SyncDataSetting.SycnMOUrl = this.txtSycnDataUrl.Text.Trim();
                obj.SyncDataSetting.SycnMOOkMessage = this.txtSycnOkMessage.Text.Trim();
                obj.SyncDataSetting.SycnMOFailedMessage = this.txtSycnFailedMessage.Text.Trim();
 
 



                SPClientCodeRelationWrapper.Update(obj);

                winSPClientCodeRelationEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }


}