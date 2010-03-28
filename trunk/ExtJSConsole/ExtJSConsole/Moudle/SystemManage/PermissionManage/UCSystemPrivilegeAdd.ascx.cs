using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.PermissionManage
{

    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemPrivilegeAdd")]
    public partial class UCSystemPrivilegeAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSystemPrivilegeAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSystemPrivilege_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemPrivilegeWrapper obj = new SystemPrivilegeWrapper();
                obj.PrivilegeCnName = this.txtPrivilegeCnName.Text.Trim();
                obj.PrivilegeEnName = this.txtPrivilegeEnName.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.PrivilegeCategory = this.txtPrivilegeCategory.Text.Trim();


                SystemPrivilegeWrapper.Save(obj);

                winSystemPrivilegeAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }

}