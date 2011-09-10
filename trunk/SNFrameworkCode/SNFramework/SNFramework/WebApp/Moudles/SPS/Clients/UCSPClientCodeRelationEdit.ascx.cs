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
                    this.txtCodeID.Text = obj.CodeID.ToString();
                    this.txtClientID.Text = obj.ClientID.ToString();
                    this.txtPrice.Text = obj.Price.ToString();
                    this.txtInterceptRate.Text = obj.InterceptRate.ToString();
                    this.chkUseClientDefaultSycnSetting.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.UseClientDefaultSycnSetting);
                    this.chkSyncData.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.SyncData);
 
                    this.txtSycnRetryTimes.Text = ValueConvertUtil.ConvertStringValue(obj.SycnRetryTimes);
                    this.txtSyncType.Text = ValueConvertUtil.ConvertStringValue(obj.SyncType);
                    this.txtSycnDataUrl.Text = ValueConvertUtil.ConvertStringValue(obj.SycnDataUrl);
                    this.txtSycnOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.SycnOkMessage);
                    this.txtSycnFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.SycnFailedMessage);
                    this.txtStartDate.Text = obj.StartDate.ToString();
                    this.txtEndDate.Text = obj.EndDate.ToString();
                    this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);
                    this.txtSycnNotInterceptCount.Text = obj.SycnNotInterceptCount.ToString();
                    this.txtCreateBy.Text = obj.CreateBy.ToString();
                    this.txtCreateAt.Text = obj.CreateAt.ToString();
                    this.txtLastModifyBy.Text = obj.LastModifyBy.ToString();
                    this.txtLastModifyAt.Text = obj.LastModifyAt.ToString();




                    hidId.Text = id.ToString();


                    winSPClientCodeRelationEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage:Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
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
                obj.UseClientDefaultSycnSetting = this.chkUseClientDefaultSycnSetting.Checked;
                obj.SyncData = this.chkSyncData.Checked;
 
                obj.SycnRetryTimes = this.txtSycnRetryTimes.Text.Trim();
                obj.SyncType = this.txtSyncType.Text.Trim();
                obj.SycnDataUrl = this.txtSycnDataUrl.Text.Trim();
                obj.SycnOkMessage = this.txtSycnOkMessage.Text.Trim();
                obj.SycnFailedMessage = this.txtSycnFailedMessage.Text.Trim();
                obj.StartDate = UIHelper.SaftGetDateTime(this.txtStartDate.Text.Trim());
                obj.EndDate = UIHelper.SaftGetDateTime(this.txtEndDate.Text.Trim());
                obj.IsEnable = this.chkIsEnable.Checked;
                obj.SycnNotInterceptCount = Convert.ToInt32(this.txtSycnNotInterceptCount.Text.Trim());
                obj.CreateBy = Convert.ToInt32(this.txtCreateBy.Text.Trim());
                obj.CreateAt = UIHelper.SaftGetDateTime(this.txtCreateAt.Text.Trim());
                obj.LastModifyBy = Convert.ToInt32(this.txtLastModifyBy.Text.Trim());
                obj.LastModifyAt = UIHelper.SaftGetDateTime(this.txtLastModifyAt.Text.Trim());


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