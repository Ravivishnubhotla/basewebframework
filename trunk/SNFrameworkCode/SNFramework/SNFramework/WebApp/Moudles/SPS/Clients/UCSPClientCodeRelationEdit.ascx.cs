﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {

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
 
                    this.chkSyncData.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.SyncData);
  
                    this.txtSycnRetryTimes.Text = ValueConvertUtil.ConvertStringValue(obj.SycnRetryTimes);
 
                    this.txtSycnDataUrl.Text = ValueConvertUtil.ConvertStringValue(obj.SycnDataUrl);
                    this.txtSycnOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.SycnOkMessage);
                    this.txtSycnFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.SycnFailedMessage);
 
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
                    this.txtSycnNotInterceptCount.Text = obj.SycnNotInterceptCount.ToString();
 



                    hidId.Text = id.ToString();


                    winSPClientCodeRelationEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message  : Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPClientCodeRelation_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPClientCodeRelationWrapper obj = SPClientCodeRelationWrapper.FindById(int.Parse(hidId.Text.Trim()));
 
                obj.Price = Convert.ToDecimal(this.txtPrice.Text.Trim());
                obj.InterceptRate = Convert.ToDecimal(this.txtInterceptRate.Text.Trim());
 
                obj.SyncData = this.chkSyncData.Checked;
 
                obj.SycnRetryTimes = this.txtSycnRetryTimes.Text.Trim();
 
                obj.SycnDataUrl = this.txtSycnDataUrl.Text.Trim();
                obj.SycnOkMessage = this.txtSycnOkMessage.Text.Trim();
                obj.SycnFailedMessage = this.txtSycnFailedMessage.Text.Trim();
 
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.SycnNotInterceptCount = Convert.ToInt32(this.txtSycnNotInterceptCount.Text.Trim());
 


                SPClientCodeRelationWrapper.Update(obj);

                winSPClientCodeRelationEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }

        }
    }


}