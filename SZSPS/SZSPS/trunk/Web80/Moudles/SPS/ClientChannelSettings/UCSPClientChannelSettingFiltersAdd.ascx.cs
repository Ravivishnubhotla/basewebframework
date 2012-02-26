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
  [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingFiltersAdd")]
    public partial class UCSPClientChannelSettingFiltersAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public int ChannleClientID
        {
            get
            {
                if (this.Request.QueryString["ChannleClientID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleClientID"]);
            }

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSPClientChannelSettingFiltersAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSPClientChannelSettingFilters_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientChannelSettingFiltersWrapper obj = new SPClientChannelSettingFiltersWrapper();
          obj.ParamsName = "province";
          obj.FilterType = "eq";        	
          obj.FilterValue = this.cmbFilterProvince.SelectedItem.Text.Trim();        	
          obj.IsEnable = true;
                obj.ClientChannelSettingID = SPClientChannelSettingWrapper.FindById(ChannleClientID);        	





                SPClientChannelSettingFiltersWrapper.Save(obj);

                winSPClientChannelSettingFiltersAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

  }
}

 

 