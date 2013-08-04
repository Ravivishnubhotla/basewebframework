using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ScriptManager = Coolite.Ext.Web.ScriptManager;

namespace Legendigital.Common.Web.Moudles.SPS.Channels
{
   [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPChannelEdit")]
    public partial class UCSPChannelEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPChannelWrapper obj = SPChannelWrapper.FindById(id);

                if (obj != null)
                {
				    this.txtName.Text = obj.Name.ToString();          	
              	    this.txtDescription.Text = obj.Description.ToString();          	
              	    this.txtArea.Text = obj.Area.ToString();

                    if (!string.IsNullOrEmpty(obj.ChannelCodeParamsName))
                        this.cmbChannelCodeParamsName.SetValue(obj.ChannelCodeParamsName);
                    else
                        this.cmbChannelCodeParamsName.SetValue("");

                    if (obj.IsAllowNullLinkID.HasValue)
                        chkIsAllowNullLinkID.Checked = obj.IsAllowNullLinkID.Value;
                    else
                        chkIsAllowNullLinkID.Checked = false;

              	    this.txtChannelCode.Text = obj.ChannelCode.ToString();

              	    this.txtFuzzyCommand.Text = obj.FuzzyCommand.ToString();
                    this.txtPort.Text = obj.Port.ToString();          	
              	    this.txtChannelType.Text = obj.ChannelType.ToString();
                    this.txtRate.Text = obj.Rate.ToString();
                    this.txtOkMessage.Text = obj.OkMessage;
                    this.txtFailedMessage.Text = obj.FailedMessage;

                    if (obj.RecStatReport.HasValue)
                        chkRecStatReport.Checked = obj.RecStatReport.Value;
                    else
                        chkRecStatReport.Checked = false;

                    if (!string.IsNullOrEmpty(obj.StatParamsName))
                        this.txtStatParamName.Text = obj.StatParamsName.ToString();
                    else
                        this.txtStatParamName.Text = "";

                    if (!string.IsNullOrEmpty(obj.StatParamsValues))
                        this.txtStatValues.Text = obj.StatParamsValues.ToString();
                    else
                        this.txtStatValues.Text = "";


                    if (obj.HasRequestTypeParams.HasValue)
                        chkHasRequestTypeParams.Checked = obj.HasRequestTypeParams.Value;
                    else
                        chkHasRequestTypeParams.Checked = false;

                    if (!string.IsNullOrEmpty(obj.RequestTypeParamName))
                        this.txtRequestTypeParamName.Text = obj.RequestTypeParamName.ToString();
                    else
                        this.txtRequestTypeParamName.Text = "";


                    if (obj.Price.HasValue)
                        txtPrice.Text = obj.Price.Value.ToString("N2");
                    else
                        txtPrice.Text = "0.00";

                    if (!string.IsNullOrEmpty(obj.RequestTypeValues))
                        this.txtRequestTypeValues.Text = obj.RequestTypeValues.ToString();
                    else
                        this.txtRequestTypeValues.Text = "";


                    if (obj.StatSendOnce.HasValue)
                        chkStatSendOnce.Checked = obj.StatSendOnce.Value;
                    else
                        chkStatSendOnce.Checked = false;


                    if (obj.HasConvertRule.HasValue)
                        chkHasConvertRule.Checked = obj.HasConvertRule.Value;
                    else
                        chkHasConvertRule.Checked = false;



                    if (obj.IsMonitoringRequest.HasValue)
                        chkIsMonitoringRequest.Checked = obj.IsMonitoringRequest.Value;
                    else
                        chkIsMonitoringRequest.Checked = false;



                    hidId.Text = id.ToString();

                    winSPChannelEdit.Show();

                }
                else
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "错误信息：数据不存在";
                    return;
                }
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSPChannel_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPChannelWrapper obj = SPChannelWrapper.FindById(int.Parse(hidId.Text.Trim()));
                obj.Name = this.txtName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.Area = this.txtArea.Text.Trim();

                obj.ChannelCode = this.txtChannelCode.Text.Trim();

                if (this.cmbChannelCodeParamsName.SelectedItem != null)
                    obj.ChannelCodeParamsName = this.cmbChannelCodeParamsName.SelectedItem.Value;
                else
                    obj.ChannelCodeParamsName = "";

                obj.IsAllowNullLinkID = chkIsAllowNullLinkID.Checked;

                obj.FuzzyCommand = this.txtFuzzyCommand.Text.Trim();
                obj.Port = this.txtPort.Value.ToString();
                obj.ChannelType = this.txtChannelType.Text.Trim();

                obj.Rate = Convert.ToInt32(this.txtRate.Value);
                obj.Status = 0;
                obj.Price = Convert.ToDecimal(this.txtPrice.Value);
                obj.OkMessage = txtOkMessage.Text.Trim();
                obj.FailedMessage = txtFailedMessage.Text.Trim();
                obj.RecStatReport = chkRecStatReport.Checked;
                obj.StatParamsName = txtStatParamName.Text.Trim();
                obj.StatParamsValues = txtStatValues.Text.Trim();

                obj.HasRequestTypeParams = chkHasRequestTypeParams.Checked;
                obj.RequestTypeParamName = txtRequestTypeParamName.Text.Trim();
                obj.RequestTypeValues = txtRequestTypeValues.Text.Trim();

 
                obj.HasConvertRule = chkHasConvertRule.Checked;
                obj.StatSendOnce = chkStatSendOnce.Checked;
                obj.IsMonitoringRequest = chkIsMonitoringRequest.Checked;

                SPChannelWrapper.Update(obj);

                obj.RefreshChannelInfo();

                winSPChannelEdit.Hide();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                return;
            }

        }
    }

}