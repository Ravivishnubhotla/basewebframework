using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Channels
{
    public partial class SPChannelQuickAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnAdd_Click(object sender, DirectEventArgs e)
        {
            try
            {
                //SPChannelFiltersWrapper obj = new SPChannelFiltersWrapper();

                SPChannelWrapper channelWrapper = new SPChannelWrapper();

                channelWrapper.Name = this.txtName.Text.Trim();
                channelWrapper.Code = this.txtCode.Text.Trim();
                channelWrapper.Description = this.txtDescription.Text.Trim();
                channelWrapper.DataOkMessage = this.txtDataOkMessage.Text.Trim();
                channelWrapper.DataFailedMessage = this.txtDataFailedMessage.Text.Trim();

                channelWrapper.DataAdapterType = ((Ext.Net.CheckboxBase)(rdgSelectDataAdapter.CheckedItems[0])).InputValue;
                channelWrapper.DataAdapterUrl = this.txtAdapterHandleName.Text.Trim();

                channelWrapper.ChannelType = cmbChannelType.SelectedItem.Value;

                if (channelWrapper.ChannelType==DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
                {
                    channelWrapper.IVRFeeTimeType = cmbIVRType.SelectedItem.Value;
                    channelWrapper.IVRTimeFormat = this.txtIVRTimeFormat.Text.Trim();
                }

                channelWrapper.IsStateReport = fsIsStateReport.CheckboxToggle;

                if(channelWrapper.IsStateReport.Value)
                {
                    channelWrapper.StateReportType = ((Ext.Net.CheckboxBase)(rdgStateReportType.CheckedItems[0])).InputValue;

                    channelWrapper.StateReportParamName = this.txtStateReportParamName.Text.Trim();
                    channelWrapper.StateReportParamValue = this.txtStateReportParamValue.Text.Trim();

                    channelWrapper.ReportOkMessage = this.txtReportOkMessage.Text.Trim();
                    channelWrapper.ReportFailedMessage = this.txtReportFailedMessage.Text.Trim();

                    if (channelWrapper.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendTwiceTypeRequest_Key)
                    {
                        channelWrapper.RequestTypeParamName = this.txtRequestTypeParamName.Text.Trim();
                        channelWrapper.RequestTypeParamDataReportValue = this.txtRequestTypeParamDataReportValue.Text.Trim();
                        channelWrapper.RequestTypeParamStateReportValue = this.txtRequestTypeParamStateReportValue.Text.Trim();
                    }
                }

                channelWrapper.IsAutoLinkID = this.chkIsAutoLinkID.Checked;

                if (channelWrapper.IsAutoLinkID.Value)
                {
                    channelWrapper.AutoLinkIDFields = this.txtAutoLinkIDFields.Text.Trim();
                }

                channelWrapper.IsDisable = false;
                channelWrapper.IsLogRequest = this.chkIsLogRequest.Checked;
                channelWrapper.IsMonitorRequest = this.chkIsMonitorRequest.Checked;
                channelWrapper.IsParamsConvert = this.chkIsParamsConvert.Checked;
                channelWrapper.HasFilters = this.chkHasFilters.Checked;


                if (channelWrapper.ChannelType == DictionaryConst.Dictionary_ChannelType_SPChannel_Key)
                {
                    string pLinkID = this.txtLinkParamsName.Text.Trim();
                    string pMo = this.txtMoParamsName.Text.Trim();
                    string pMobile = this.txtMobileParamsName.Text.Trim();
                    string pSPCode = this.txtSPcodeParamsName.Text.Trim();
                    string pCreateDate = this.txtCreateDate.Text.Trim();
                    string pProvince = this.txtProvince.Text.Trim();
                    string pCity = this.txtCity.Text.Trim();
                    string pExtend1 = this.txtExtend1.Text.Trim();
                    string pExtend2 = this.txtExtend2.Text.Trim();
                    string pExtend3 = this.txtExtend3.Text.Trim();
                    string pExtend4 = this.txtExtend4.Text.Trim();
                    string pExtend5 = this.txtExtend5.Text.Trim();
                    string pExtend6 = this.txtExtend6.Text.Trim();
                    string pExtend7 = this.txtExtend7.Text.Trim();
                    string pExtend8 = this.txtExtend8.Text.Trim();
                    string pExtend9 = this.txtExtend9.Text.Trim();
                    string pExtend10 = this.txtExtend10.Text.Trim();
                    channelWrapper.QuickAddSPChannel(pLinkID, pMo, pMobile, pSPCode, pCreateDate, pProvince, pCity, pExtend1, pExtend2, pExtend3, pExtend4, pExtend5, pExtend6, pExtend7, pExtend8, pExtend9,pExtend10);
                }
                else if (channelWrapper.ChannelType == DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
                {
                    string pIVRLinkID = this.txtIVRLinkID.Text.Trim();
                    string pIVRMobile = this.txtIVRMobile.Text.Trim();
                    string pIVRSPCode = this.txtIVRSPCode.Text.Trim();
                    string pIVRFeetime = this.txtIVRFeetime.Text.Trim();
                    string pIVRStartTime = this.txtIVRStartTime.Text.Trim();
                    string pIVREndTime = this.txtIVREndTime.Text.Trim();
                    string pIVRProvince = this.txtIVRProvince.Text.Trim();
                    string pIVRCity = this.txtIVRCity.Text.Trim();
                    string pIVRExtend1 = this.txtIVRExtend1.Text.Trim();
                    string pIVRExtend2 = this.txtIVRExtend2.Text.Trim();
                    string pIVRExtend3 = this.txtIVRExtend3.Text.Trim();
                    string pIVRExtend4 = this.txtIVRExtend4.Text.Trim();
                    string pIVRExtend5 = this.txtIVRExtend5.Text.Trim();
                    string pIVRExtend6 = this.txtIVRExtend6.Text.Trim();
                    string pIVRExtend7 = this.txtIVRExtend7.Text.Trim();
                    string pIVRExtend8 = this.txtIVRExtend8.Text.Trim();
                    string pIVRExtend9 = this.txtIVRExtend9.Text.Trim();
                    string pIVRExtend10 = this.txtIVRExtend10.Text.Trim();
                    channelWrapper.QuickAddIVRChannel(pIVRLinkID, pIVRFeetime, pIVRMobile, pIVRSPCode, pIVRStartTime, pIVREndTime, pIVRProvince, pIVRCity, pIVRExtend1, pIVRExtend2, pIVRExtend3, pIVRExtend4, pIVRExtend5, pIVRExtend6, pIVRExtend7, pIVRExtend8, pIVRExtend9, pIVRExtend10);
                }




                //SPChannelFiltersWrapper.Save(obj);

                //winSPChannelFiltersAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }
}