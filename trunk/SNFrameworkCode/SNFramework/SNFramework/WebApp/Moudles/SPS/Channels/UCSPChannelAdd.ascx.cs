using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelAdd")]
    public partial class UCSPChannelAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSPChannelAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSPChannel_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelWrapper obj = new SPChannelWrapper();
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.RecievedName = this.txtRecievedName.Text.Trim();
                obj.IsAllowNullLinkID = this.chkIsAllowNullLinkID.Checked;
                obj.IsMonitorRequest = this.chkIsMonitorRequest.Checked;
                obj.IsDisable = this.chkIsDisable.Checked;
                obj.DataOkMessage = this.txtDataOkMessage.Text.Trim();
                obj.DataFailedMessage = this.txtDataFailedMessage.Text.Trim();
                obj.ReportOkMessage = this.txtReportOkMessage.Text.Trim();
                obj.ReportFailedMessage = this.txtReportFailedMessage.Text.Trim();
                obj.StatSendOnce = this.chkStatSendOnce.Checked;
                obj.TypeRequest = this.chkTypeRequest.Checked;
                obj.DataParamName = this.txtDataParamName.Text.Trim();
                obj.DataParamValue = this.txtDataParamValue.Text.Trim();
                obj.ReportParamName = this.txtReportParamName.Text.Trim();
                obj.ReportParamValue = this.txtReportParamValue.Text.Trim();
                obj.HasFilters = this.chkHasFilters.Checked;
                obj.StatusParamName = this.txtStatusParamName.Text.Trim();
                obj.StatusParamValue = this.txtStatusParamValue.Text.Trim();
                obj.Price = Convert.ToDecimal(this.txtPrice.Text.Trim());
                obj.DefaultRate = Convert.ToDecimal(this.txtDefaultRate.Text.Trim());
                obj.HasStatReport = this.chkHasStatReport.Checked;
                obj.ChannelDetailInfo = this.txtChannelDetailInfo.Text.Trim();
                //obj.UpperID = Convert.ToInt32(this.ddlUpperID.SelectedValue.Trim());
                obj.IsLogRequest = this.chkIsLogRequest.Checked;





                SPChannelWrapper.Save(obj);

                winSPChannelAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }

}