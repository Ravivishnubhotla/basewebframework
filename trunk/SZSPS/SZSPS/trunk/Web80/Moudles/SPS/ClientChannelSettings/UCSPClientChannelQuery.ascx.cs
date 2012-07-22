using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
 

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelQuery")]
    public partial class UCSPClientChannelQuery : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(id);

                if (obj != null)
                {
                    this.lblChannelClientCode.Text = obj.ChannelClientCode;

                    this.lblChannelName.Text = obj.ChannelName;

                    this.lblClientGroupName.Text = obj.ClientGroupName;

                    this.lblName.Text = obj.Name;

                    this.lblResult.Text = "";
 
                    hidId.Text = id.ToString();

                    winSPClientChannelQuery.Show();

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


        protected void btnSPClientChannelQuery_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(int.Parse(hidId.Text.Trim()));

                int dataCount = obj.QueryDataCount(dfStart.SelectedDate, dfEnd.SelectedDate, chkIncludeSubCode.Checked, chkAfterIntercept.Checked);
                int phoneCount = obj.QueryPhoneCount(dfStart.SelectedDate, dfEnd.SelectedDate, chkIncludeSubCode.Checked, chkAfterIntercept.Checked);

                this.lblResult.Text = string.Format("总数：{0},用户数{1}", dataCount, phoneCount);
 

 
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