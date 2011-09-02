using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemConfigAdd")]
    public partial class UCSystemConfigAdd : System.Web.UI.UserControl
    {

        protected void storeSystemConfigGroup_Refresh(object sender, StoreRefreshDataEventArgs e)
        {


            storeSystemConfigGroup.DataSource = SystemConfigGroupWrapper.FindAll();
 

            storeSystemConfigGroup.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemConfigAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message：" + ex.Message;
            }
        }

        protected void btnSaveSystemConfig_Click(object sender, DirectEventArgs e)
        {
            try
            {
                if(SystemConfigWrapper.CheckIfExistedConfigByKey(this.txtConfigKey.Text.Trim()))
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "Error Message : config '" + this.txtConfigKey.Text.Trim() + "' is existed  ,Please change key name.";
                    return;
                }


                SystemConfigWrapper obj = new SystemConfigWrapper();
                obj.ConfigKey = this.txtConfigKey.Text.Trim();
                obj.ConfigValue = this.txtConfigValue.Text.Trim();
                obj.ConfigDescription = this.txtConfigDescription.Text.Trim();
                obj.SortIndex = Convert.ToInt32(this.numSortIndex.Text.Trim());





                SystemConfigWrapper.Save(obj);

                winSystemConfigAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message ：" + ex.Message;
            }
        }
    }
}