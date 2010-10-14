using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.ControlHelper;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPChannelAdd")]
    public partial class UCSPChannelAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSPChannelAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPChannel_Click(object sender, AjaxEventArgs e)
        {

            if (SPChannelWrapper.GetChannelByPath(this.txtFuzzyCommand.Text.Trim()) != null)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：提交别名已存在！";
                return;
            }

            try
            {
                SPChannelWrapper obj = new SPChannelWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.Area = this.txtArea.Text.Trim();
                obj.ChannelCode = this.txtChannelCode.Text.Trim();
                obj.FuzzyCommand = this.txtFuzzyCommand.Text.Trim();
                obj.Port = this.txtPort.Value.ToString();
                obj.ChannelType = this.txtChannelType.Text.Trim();
                obj.Price = Convert.ToDecimal(this.txtPrice.Value);
                obj.Rate = Convert.ToInt32(this.txtRate.Value);
                if (this.cmbChannelCodeParamsName.SelectedItem != null)
                    obj.ChannelCodeParamsName = this.cmbChannelCodeParamsName.SelectedItem.Value;
                else
                    obj.ChannelCodeParamsName = "";
                obj.IsAllowNullLinkID = chkIsAllowNullLinkID.Checked;
                obj.Status = 0;
                obj.CreateTime = System.DateTime.Now;
                obj.CreateBy = this.ParentPage.CurrentLoginUser.UserID;
                obj.OkMessage = txtOkMessage.Text.Trim();
                obj.FailedMessage = txtFailedMessage.Text.Trim();
                obj.RecStatReport = chkRecStatReport.Checked;
                obj.StatParamsName = txtStatParamName.Text.Trim();
                obj.StatParamsValues = txtStatValues.Text.Trim();

                obj.HasRequestTypeParams = chkHasRequestTypeParams.Checked;
                obj.RequestTypeParamName = txtRequestTypeParamName.Text.Trim();
                obj.RequestTypeValues = txtRequestTypeValues.Text.Trim();


                obj.HasFilters = chkHasFilters.Checked;
                obj.StatSendOnce = chkStatSendOnce.Checked;
                obj.IsMonitoringRequest = chkIsMonitoringRequest.Checked;

                SPChannelWrapper.Save(obj);

                obj.RefreshChannelInfo();

                winSPChannelAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }


    }

}