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
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSystemConfig_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemConfigWrapper obj = new SystemConfigWrapper();
                obj.ConfigKey = this.txtConfigKey.Text.Trim();
                obj.ConfigValue = this.txtConfigValue.Text.Trim();
                obj.ConfigDescription = this.txtConfigDescription.Text.Trim();
                obj.SortIndex = Convert.ToInt32(this.txtSortIndex.Text.Trim());





                SystemConfigWrapper.Save(obj);

                winSystemConfigAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}