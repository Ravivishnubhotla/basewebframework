using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
 
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingInfoEdit")]
    public partial class UCSPClientChannelSettingInfoEdit : System.Web.UI.UserControl
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

                    this.lblChannelName.Text = obj.ChannelName;

                    this.lblClientName.Text = obj.ClientName;

                    this.lblClientName.Text = obj.ClientGroupName;

                    this.lblName.Text = obj.Name;

                    this.lblChannelClientCode.Text = obj.ChannelClientCode;

                    chkHasDayTotalLimit.Checked = obj.HasDayTotalLimit.HasValue && obj.HasDayTotalLimit.Value;



                    if (this.chkHasDayTotalLimit.Checked)
                    {
                        if (obj.DayTotalLimit.HasValue)
                            this.txtDayTotalLimit.Text = obj.DayTotalLimit.Value.ToString();
                        else
                            this.txtDayTotalLimit.Text = "0";
                    }
                    else
                    {
                        this.txtDayTotalLimit.Text = "0";
                    }


                    this.txtDayTotalLimit.Hidden = !chkHasDayTotalLimit.Checked;



                    hidId.Text = id.ToString();

                    winSPClientChannelSettingInfoEdit.Show();

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

        protected void btnSaveSPClientChannelSetting_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientChannelSettingWrapper obj = SPClientChannelSettingWrapper.FindById(int.Parse(hidId.Text.Trim()));


                obj.HasDayTotalLimit = this.chkHasDayTotalLimit.Checked;
                obj.DayTotalLimit = Convert.ToInt32(this.txtDayTotalLimit.Value);


                SPClientChannelSettingWrapper.Update(obj);

                obj.ChannelID.RefreshChannelInfo();

                winSPClientChannelSettingInfoEdit.Hide();
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