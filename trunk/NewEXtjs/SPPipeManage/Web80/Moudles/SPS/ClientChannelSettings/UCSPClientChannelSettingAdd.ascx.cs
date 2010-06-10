using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingAdd")]
    public partial class UCSPClientChannelSettingAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //protected void storeSPChannelAdd_Refresh(object sender, StoreRefreshDataEventArgs e)
        //{
        //    storeSPChannelAdd.DataSource = SPChannelWrapper.FindAll();
        //    storeSPChannelAdd.DataBind();
        //}

        protected void storeSPClientAdd_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeSPClientAdd.DataSource = SPClientWrapper.FindAll();
            storeSPClientAdd.DataBind();
        }


        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSPClientChannelSettingAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPClientChannelSetting_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientChannelSettingWrapper obj = new SPClientChannelSettingWrapper();



                obj.ChannelID = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannelID.Value.ToString()));
                obj.ClinetID = SPClientWrapper.FindById(Convert.ToInt32(this.cmbClinetID.Value.ToString()));        	
                obj.InterceptRate = Convert.ToInt32(this.txtInterceptRate.Text.Trim());
                obj.UpRate = 0;
                obj.DownRate = 0;
                obj.CommandType = this.cmbCommandType.Value.ToString();
                obj.CommandCode = this.txtCommandCode.Text.Trim();

                SPClientChannelSettingWrapper.Save(obj);

                winSPClientChannelSettingAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }



    }

}