using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.ApplicationManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemApplicationAdd")]
    public partial class UCSystemApplicationAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSystemApplicationAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSystemApplication_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemApplicationWrapper systemApplication = new SystemApplicationWrapper();
                systemApplication.SystemApplicationName = txtSystemApplicationName.Text.Trim();
                systemApplication.SystemApplicationDescription = txtSystemApplicationDescription.Text.Trim();
                systemApplication.SystemApplicationUrl = txtSystemApplicationUrl.Text.Trim();
                systemApplication.SystemApplicationIsSystemApplication = chkSystemApplicationIsSystemApplication.Checked;

                SystemApplicationWrapper.Save(systemApplication);

                winSystemApplicationAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}