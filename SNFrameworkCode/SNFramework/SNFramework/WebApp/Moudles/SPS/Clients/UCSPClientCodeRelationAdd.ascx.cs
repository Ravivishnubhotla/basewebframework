using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SPS.Bussiness.Wrappers;
using Ext.Net;
using Legendigital.Framework.Common.Web.ControlHelper;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPClientCodeRelationAdd")]
    public partial class UCSPClientCodeRelationAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPClientCodeRelationAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPClientCodeRelation_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPClientCodeRelationWrapper obj = new SPClientCodeRelationWrapper();
 
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





                SPClientCodeRelationWrapper.Save(obj);

                winSPClientCodeRelationAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }


}