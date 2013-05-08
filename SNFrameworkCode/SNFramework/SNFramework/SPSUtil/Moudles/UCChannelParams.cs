using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SPSUtil.AppCode;

namespace SPSUtil.Moudles
{
    public partial class UCChannelParams : UserControl
    {
        public UCChannelParams()
        {
            InitializeComponent();
        }

        public bool Valid 
        {
            get { return false; }
        }


        public ChannelSendSettings ChannelSetting
        {
            get
            {
                ChannelSendSettings sendSetting = new ChannelSendSettings();

                sendSetting.SubmitSendUrl = this.txtSubmitUrl.Text.Trim();
                sendSetting.ParamsLinkidName = this.txtParamsLinkidName.Text.Trim();
                sendSetting.ParamsLinkidValue = this.txtParamsLinkidValue.Text.Trim();
                sendSetting.ParamsMoName = this.txtParamsMoName.Text.Trim();
                sendSetting.ParamsMoValue = this.txtParamsMoValue.Text.Trim();
                sendSetting.ParamsSPCodeName = this.txtParamsSPCodeName.Text.Trim();
                sendSetting.ParamsSPCodeValue = this.txtParamsSPCodeValue.Text.Trim();
                sendSetting.ParamsMobileName = this.txtParamsMobileName.Text.Trim();
                sendSetting.ParamsMobileValue = this.txtParamsMobileValue.Text.Trim();
                sendSetting.IsStatusReport = this.chkIsStatusReport.Checked;
                sendSetting.ParamsStatusName = this.txtParamsStatusName.Text.Trim();
                sendSetting.ParamsStatusValue = this.txtParamsStatusValue.Text.Trim();
                sendSetting.ParamsRequestTypeName = this.txtParamsRequestTypeName.Text.Trim();
                sendSetting.ParamsRequestTypeDataValue = this.txtParamsRequestTypeDataValue.Text.Trim();
                sendSetting.ParamsRequestTypeReportValue = this.txtParamsRequestTypeReportValue.Text.Trim();
                sendSetting.RequestType = this.cmbRequestType.SelectedIndex;
                sendSetting.ReportOkMesage = this.txtReportOkMessage.Text.Trim();
                sendSetting.DataOkMessage = this.txtDataOkMessage.Text.Trim();

                return sendSetting;
            }
            set
            {
                if (value == null)
                    return;

                this.txtSubmitUrl.Text = value.SubmitSendUrl;

                this.cmbRequestType.SelectedIndex = value.RequestType;

                this.chkIsStatusReport.Checked = value.IsStatusReport;

                this.txtParamsStatusName.Text = value.ParamsStatusName;

                this.txtParamsStatusValue.Text = value.ParamsStatusValue;

                this.txtParamsRequestTypeName.Text = value.ParamsRequestTypeName;

                this.txtParamsRequestTypeDataValue.Text = value.ParamsRequestTypeDataValue;

                this.txtParamsRequestTypeReportValue.Text = value.ParamsRequestTypeReportValue;

                this.txtParamsLinkidName.Text = value.ParamsLinkidName;

                this.txtParamsMoName.Text = value.ParamsMoName;

                this.txtParamsMobileName.Text = value.ParamsMobileName;

                this.txtParamsSPCodeName.Text = value.ParamsSPCodeName;

                this.txtReportOkMessage.Text = value.ReportOkMesage;

                this.txtDataOkMessage.Text = value.DataOkMessage;
            }
        }

        private void chkIsStatusReport_CheckedChanged(object sender, EventArgs e)
        {
            bool statusReported = this.chkIsStatusReport.Checked;

            cmbRequestType.Enabled = statusReported;
            txtParamsStatusName.Enabled = statusReported;
            txtParamsStatusValue.Enabled = statusReported;
            txtParamsRequestTypeName.Enabled = statusReported;
            txtParamsRequestTypeDataValue.Enabled = statusReported;
            txtParamsRequestTypeReportValue.Enabled = statusReported;

            if(!statusReported)
            {
                txtParamsStatusName.Text = "status";
                txtParamsStatusValue.Text = "DELIVRD";
                txtParamsRequestTypeName.Text = "";
                txtParamsRequestTypeDataValue.Text = "";
                txtParamsRequestTypeReportValue.Text = "";
            }

        }
    }
}
