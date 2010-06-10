using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.ClientChannelSettings
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSPClientChannelSettingEdit")]
    public partial class UCSPClientChannelSettingEdit : System.Web.UI.UserControl
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
					              	this.txtChannelID.Text = obj.ChannelID.ToString();          	
              	this.txtClinetID.Text = obj.ClinetID.ToString();          	
              	this.txtInterceptRate.Text = obj.InterceptRate.ToString();          	
              	this.txtUpRate.Text = obj.UpRate.ToString();          	
              	this.txtDownRate.Text = obj.DownRate.ToString();          	
              	this.txtCommandType.Text = obj.CommandType.ToString();          	
              	this.txtCommandCode.Text = obj.CommandCode.ToString();          	
 



                    hidId.Text = id.ToString();


                    winSPClientChannelSettingEdit.Show();

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
                //obj.ChannelID = Convert.ToInt32(this.txtChannelID.Text.Trim());
                //obj.ClinetID = Convert.ToInt32(this.txtClinetID.Text.Trim());
                obj.InterceptRate = Convert.ToInt32(this.txtInterceptRate.Text.Trim());
                obj.UpRate = Convert.ToInt32(this.txtUpRate.Text.Trim());
                obj.DownRate = Convert.ToInt32(this.txtDownRate.Text.Trim());
                obj.CommandType = this.txtCommandType.Text.Trim();
                obj.CommandCode = this.txtCommandCode.Text.Trim();


                SPClientChannelSettingWrapper.Update(obj);

                winSPClientChannelSettingEdit.Hide();
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