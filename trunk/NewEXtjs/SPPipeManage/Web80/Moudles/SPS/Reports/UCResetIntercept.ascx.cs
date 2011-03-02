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
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCResetIntercept")]
    public partial class UCResetIntercept : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int clientChannleID, int totalCount, int interceptCount)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(clientChannleID);
                this.hidClientChannelID.Text = clientChannleID.ToString();
                this.lblChannleName.Text = obj.ChannelName;
                this.lblClientName.Text = obj.ClientName;
                this.lblDownCount.Text = totalCount.ToString();
                this.lblSycnCount.Text = interceptCount.ToString();
                this.btnResetIntercept.Disabled = !(obj.SyncData.HasValue && obj.SyncData.Value);

                this.winResetIntercept.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnResetIntercept_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                int clientChannleID = int.Parse(this.hidClientChannelID.Text.Trim());

                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(clientChannleID);

                obj.ResetIntercept(System.DateTime.Now.Date,int.Parse(this.numMaxCount.Text));

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}