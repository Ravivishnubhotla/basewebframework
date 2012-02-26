using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;
 

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
   [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingFiltersEdit")]
    public partial class UCSPClientChannelSettingFiltersEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [AjaxMethod]
        public void Show(int id)
        {
            try
            {
                SPClientChannelSettingFiltersWrapper obj = SPClientChannelSettingFiltersWrapper.FindById(id);

                if (obj != null)
                {
                    if (string.IsNullOrEmpty(obj.FilterValue))
                        this.cmbFilterProvince.SetValue(obj.FilterValue); ;          	
                    //this.chkIsEnable.Checked = ValueConvertUtil.ConvertNullableValue<bool>(obj.IsEnable);          	
                    //this.txtClientChannelSettingID.Text = obj.ClientChannelSettingID.ToString();          	
                    hidId.Text = id.ToString();


                    winSPClientChannelSettingFiltersEdit.Show();

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

        protected void btnSaveSPClientChannelSettingFilters_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SPClientChannelSettingFiltersWrapper obj =
                    SPClientChannelSettingFiltersWrapper.FindById(int.Parse(hidId.Text.Trim()));


                obj.FilterValue = cmbFilterProvince.SelectedItem.Value;
  
                //obj.IsEnable = this.chkIsEnable.Checked;
                //obj.ClientChannelSettingID = this.txtClientChannelSettingID.Text;


                SPClientChannelSettingFiltersWrapper.Update(obj);

                winSPClientChannelSettingFiltersEdit.Hide();
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