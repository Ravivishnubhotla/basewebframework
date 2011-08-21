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
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSPChannelView")]
    public partial class UCSPChannelView : System.Web.UI.UserControl
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



                    this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                    this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
                    this.lblCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);
                    this.lblOtherRecieved.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.OtherRecieved).ToString();
                    this.lblOtherRecievedUrl.Text = ValueConvertUtil.ConvertStringValue(obj.OtherRecievedUrl);
                    this.lblRecievedName.Text = ValueConvertUtil.ConvertStringValue(obj.RecievedName);
                    this.lblIsAllowNullLinkID.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsAllowNullLinkID).ToString();
                    this.lblIsMonitorRequest.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsMonitorRequest).ToString();
                    this.lblIsDisable.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsDisable).ToString();
                    this.lblDataOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.DataOkMessage);
                    this.lblDataFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.DataFailedMessage);
                    this.lblReportOkMessage.Text = ValueConvertUtil.ConvertStringValue(obj.ReportOkMessage);
                    this.lblReportFailedMessage.Text = ValueConvertUtil.ConvertStringValue(obj.ReportFailedMessage);
                    this.lblStatSendOnce.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.StatSendOnce).ToString();
                    this.lblTypeRequest.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.TypeRequest).ToString();
                    this.lblDataParamName.Text = ValueConvertUtil.ConvertStringValue(obj.DataParamName);
                    this.lblDataParamValue.Text = ValueConvertUtil.ConvertStringValue(obj.DataParamValue);
                    this.lblReportParamName.Text = ValueConvertUtil.ConvertStringValue(obj.ReportParamName);
                    this.lblReportParamValue.Text = ValueConvertUtil.ConvertStringValue(obj.ReportParamValue);
                    this.lblHasFilters.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.HasFilters).ToString();
                    this.lblStatusParamName.Text = ValueConvertUtil.ConvertStringValue(obj.StatusParamName);
                    this.lblStatusParamValue.Text = ValueConvertUtil.ConvertStringValue(obj.StatusParamValue);
                    this.lblPrice.Text = obj.Price.ToString();
                    this.lblDefaultRate.Text = obj.DefaultRate.ToString();
                    this.lblHasStatReport.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.HasStatReport).ToString();
                    this.lblChannelDetailInfo.Text = ValueConvertUtil.ConvertStringValue(obj.ChannelDetailInfo);
                    this.lblUpperID.Text = obj.UpperID.ToString();
                    this.lblIsIVR.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsIVR).ToString();
                    this.lblIsLogRequest.Text = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsLogRequest).ToString();         	
 





                    //hidLogID.Text = id.ToString();


                    winSPChannelView.Show();

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


    }


}