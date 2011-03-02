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
        public void Show(int clientChannleID, int downCount, int downSycnCount)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(clientChannleID);
                this.hidClientChannelID.Text = clientChannleID.ToString(); 
                this.lblChannleName.Text = obj.ChannelName;
                this.lblClientName.Text = obj.ClientName;
                this.lblDownCount.Text = downCount.ToString();
                this.lblSycnCount.Text = downSycnCount.ToString();
                this.lblSycnFailedCount.Text = obj.GetSycnFailedCount(System.DateTime.Now.Date).ToString();
                this.btnResetSycTimes.Disabled = !(obj.SyncData.HasValue && obj.SyncData.Value);
                
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