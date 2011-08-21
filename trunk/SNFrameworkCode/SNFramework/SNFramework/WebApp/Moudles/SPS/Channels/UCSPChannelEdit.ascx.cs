using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelEdit")]
    public partial class UCSPChannelEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelWrapper obj = SPChannelWrapper.FindById(id);

                if (obj != null)
                {
                    this.txtName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.txtDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.txtCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.chkOtherRecieved.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.OtherRecieved);
                    this.txtOtherRecievedUrl.Text = ValueConvertUtil.ConvertStringValue(obj.OtherRecievedUrl);
                    this.txtRecievedName.Text = ValueConvertUtil.ConvertStringValue(obj.RecievedName);
                    this.chkIsAllowNullLinkID.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsAllowNullLinkID);
                    this.chkIsMonitorRequest.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsMonitorRequest);
                    this.chkIsDisable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsDisable);
                    this.txtDataOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.DataOkMessage);
                    this.txtDataFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.DataFailedMessage);
                    this.txtReportOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.ReportOkMessage);
                    this.txtReportFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.ReportFailedMessage);
                    this.chkStatSendOnce.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.StatSendOnce);
                    this.chkTypeRequest.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.TypeRequest);
                    this.txtDataParamName.Text = ValueConvertUtil.ConvertStringValue(obj.DataParamName);
                    this.txtDataParamValue.Text = ValueConvertUtil.ConvertStringValue(obj.DataParamValue);
                    this.txtReportParamName.Text = ValueConvertUtil.ConvertStringValue(obj.ReportParamName);
                    this.txtReportParamValue.Text = ValueConvertUtil.ConvertStringValue(obj.ReportParamValue);
                    this.chkHasFilters.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.HasFilters);
                    this.txtStatusParamName.Text = ValueConvertUtil.ConvertStringValue(obj.StatusParamName);
                    this.txtStatusParamValue.Text = ValueConvertUtil.ConvertStringValue(obj.StatusParamValue);
                    this.txtPrice.Text = obj.Price.ToString();
                    this.txtDefaultRate.Text = obj.DefaultRate.ToString();
                    this.chkHasStatReport.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.HasStatReport);
                    this.txtChannelDetailInfo.Text = ValueConvertUtil.ConvertStringValue(obj.ChannelDetailInfo);
                    //this.ddlUpperID.SelectedValue = obj.UpperID.ToString();
                    this.chkIsIVR.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsIVR);
                    this.chkIsLogRequest.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsLogRequest);




                    hidId.Text = id.ToString();


                    winSPChannelEdit.Show();

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

        protected void btnSaveSPChannel_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelWrapper obj = SPChannelWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.OtherRecieved = this.chkOtherRecieved.Checked;
                obj.OtherRecievedUrl = this.txtOtherRecievedUrl.Text.Trim();
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
                obj.IsIVR = this.chkIsIVR.Checked;
                obj.IsLogRequest = this.chkIsLogRequest.Checked;


                SPChannelWrapper.Update(obj);

                winSPChannelEdit.Hide();
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