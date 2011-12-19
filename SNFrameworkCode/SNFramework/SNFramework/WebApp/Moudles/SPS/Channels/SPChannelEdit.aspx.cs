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
    public partial class SPChannelEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            
            SPChannelWrapper channelWrapper = ChannelID;

            if(channelWrapper!=null)
            {
                txtName.Text = channelWrapper.Name;
                txtCode.Text = channelWrapper.Code;
                txtDescription.Text = channelWrapper.Description;
                txtDataOkMessage.Text = channelWrapper.DataOkMessage;
                txtDataFailedMessage.Text = channelWrapper.DataFailedMessage;

                lblDataAdapterType.Text = DictionaryConst.ParseChannelDataAdapterTypeDictionaryKey(channelWrapper.DataAdapterType);
                lblChannelType.Text = DictionaryConst.ParseChannelTypeDictionaryKey(channelWrapper.ChannelType);

                if(channelWrapper.ChannelType==DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
                {
                    cmbIVRType.Hidden = false;
                    txtIVRTimeFormat.Hidden = false;
                    cmbIVRType.Value = channelWrapper.IVRFeeTimeType;
                    txtIVRTimeFormat.Text = channelWrapper.IVRTimeFormat;
                }

                if(channelWrapper.IsStateReport)
                {
                    //this.fsIsStateReport.CheckboxToggle = true;
                    this.fsIsStateReport.Collapsed = false;

                    this.rdgStateReportType.SetValue(channelWrapper.StateReportType);

                    this.txtStateReportParamName.Text = channelWrapper.StateReportParamName;
                    this.txtStateReportParamValue.Text = channelWrapper.StateReportParamValue;

                    this.txtReportOkMessage.Text = channelWrapper.ReportOkMessage;
                    this.txtReportFailedMessage.Text = channelWrapper.ReportFailedMessage;

                    if(channelWrapper.StateReportType==DictionaryConst.Dictionary_ChannelStateReportType_SendTwiceTypeRequest_Key)
                    {
                        this.txtRequestTypeParamName.Hidden = false;
                        this.txtRequestTypeParamName.Text = channelWrapper.RequestTypeParamName;

                        this.txtRequestTypeParamDataReportValue.Hidden = false;
                        this.txtRequestTypeParamDataReportValue.Text = channelWrapper.RequestTypeParamDataReportValue;

                        this.txtRequestTypeParamStateReportValue.Hidden = false;
                        this.txtRequestTypeParamStateReportValue.Text = channelWrapper.RequestTypeParamStateReportValue;
                    }



                }

                this.chkHasFilters.Checked = channelWrapper.HasFilters;
                this.chkIsLogRequest.Checked = channelWrapper.IsLogRequest;
                this.chkIsMonitorRequest.Checked = channelWrapper.IsMonitorRequest;
                this.chkIsParamsConvert.Checked = channelWrapper.IsParamsConvert;
                this.chkIsAutoLinkID.Checked = channelWrapper.IsAutoLinkID;

                if(channelWrapper.IsAutoLinkID)
                {
                    this.txtAutoLinkIDFields.Hidden = false;
                    this.txtAutoLinkIDFields.Text = channelWrapper.AutoLinkIDFields;
                }

            }

        }

        protected void btnEdit_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SPChannelWrapper channelWrapper = ChannelID;

                channelWrapper.Name = this.txtName.Text.Trim();
                channelWrapper.Code = this.txtCode.Text.Trim();
                channelWrapper.Description = this.txtDescription.Text.Trim();
                channelWrapper.DataOkMessage = this.txtDataOkMessage.Text.Trim();
                channelWrapper.DataFailedMessage = this.txtDataFailedMessage.Text.Trim();
 

                if (channelWrapper.ChannelType == DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
                {
                    channelWrapper.IVRFeeTimeType = cmbIVRType.SelectedItem.Value;
                    channelWrapper.IVRTimeFormat = this.txtIVRTimeFormat.Text.Trim();
                }

                channelWrapper.IsStateReport = !fsIsStateReport.Collapsed;

                if (channelWrapper.IsStateReport)
                {
                    channelWrapper.StateReportType = ((CheckboxBase)(rdgStateReportType.CheckedItems[0])).InputValue;

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

                if (channelWrapper.IsAutoLinkID)
                {
                    channelWrapper.AutoLinkIDFields = this.txtAutoLinkIDFields.Text.Trim();
                }

                channelWrapper.IsDisable = false;
                channelWrapper.IsLogRequest = this.chkIsLogRequest.Checked;
                channelWrapper.IsMonitorRequest = this.chkIsMonitorRequest.Checked;
                channelWrapper.IsParamsConvert = this.chkIsParamsConvert.Checked;
                channelWrapper.HasFilters = this.chkHasFilters.Checked;

                SPChannelWrapper.Update(channelWrapper);
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息:" + ex.Message;
                return;
            }

        }

        public SPChannelWrapper ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannelID"] != null)
                {
                    return
                        SPChannelWrapper.FindById(int.Parse(this.Request.QueryString["ChannelID"]));
                }
                return null;
            }
        }
    }
}