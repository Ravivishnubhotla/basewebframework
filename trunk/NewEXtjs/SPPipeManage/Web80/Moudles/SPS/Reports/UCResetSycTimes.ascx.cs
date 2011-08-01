using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCResetSycTimes")]
    public partial class UCResetSycTimes : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int clientChannleID)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(clientChannleID);
                this.hidClientChannelID.Text = clientChannleID.ToString(); 
                this.lblChannleName.Text = obj.ChannelName;
                this.lblClientName.Text = obj.ClientName;


                int downCount = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(System.DateTime.Now.Date,
                                                                System.DateTime.Now.Date,
                                                                clientChannleID,
                                                                DataType.Down.ToString());

                int downSycnCount = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(System.DateTime.Now.Date,
                                                                System.DateTime.Now.Date,
                                                                clientChannleID,
                                                                DataType.Intercept.ToString());


                int downNotSycn = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(System.DateTime.Now.Date,
                                                System.DateTime.Now.Date,
                                                clientChannleID,
                                                DataType.DownNotSycn.ToString());

                int sycnFailed = SPPaymentInfoWrapper.FindAllPaymentCountByDateAndType(System.DateTime.Now.Date,
                                System.DateTime.Now.Date,
                                clientChannleID,
                                DataType.SycnFailed.ToString());
 


                this.lblDownCount.Text = downCount.ToString();
                this.lblSycnCount.Text = downSycnCount.ToString();
                this.lblDownNotSycnCount.Text = downNotSycn.ToString();
                this.lblSycnFailedCount.Text = sycnFailed.ToString();

                this.btnReSendDown.Disabled = (downCount <=0);
                this.btnReSendSycn.Disabled = (downSycnCount <= 0);
                this.btnReSendDownNotSycn.Disabled = (downNotSycn <= 0);
                this.btnReSendSycnFailed.Disabled = (sycnFailed <= 0);

                this.winResetSycTimes.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnResetSycTimes_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                int clientChannleID = int.Parse(this.hidClientChannelID.Text.Trim());

                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(clientChannleID);

                obj.ResetAllSycnCount(  System.DateTime.Now.Date);

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}