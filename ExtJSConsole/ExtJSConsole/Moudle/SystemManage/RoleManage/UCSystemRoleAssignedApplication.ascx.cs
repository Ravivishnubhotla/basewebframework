using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.RoleManage
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemRoleAssignedApplication")]
    public partial class UCSystemRoleAssignedApplication : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            chkgApplication.Items.Clear();

            List<SystemApplicationWrapper> apps = SystemApplicationWrapper.FindAll();

            for (int i = 0; i < apps.Count; i++)
            {
                chkgApplication.Items.Add(new Checkbox(false, apps[i].SystemApplicationName));
                //chkgApplication.Items.Add(new Checkbox(new Checkbox.Config(){BoxLabel=apps[i].SystemApplicationName,Value=apps[i].SystemApplicationID.ToString(),Checked=false}));
            }
        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                this.winSystemRoleAssignedApplication.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }


        protected void btnSaveSystemRoleAssignedApplication_Click(object sender, DirectEventArgs e)
        {
            try
            {
                winSystemRoleAssignedApplication.Hide();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }
}