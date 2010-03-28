using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.UserGroupManage
{
    [AjaxMethodProxyID(IDMode = AjaxMethodProxyIDMode.Alias, Alias = "UCSystemUserGroupAdd")]
    public partial class UCSystemUserGroupAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [AjaxMethod]
        public void Show()
        {
            try
            {
                this.winSystemUserGroupAdd.Show();
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void btnSaveSystemUserGroup_Click(object sender, AjaxEventArgs e)
        {
            try
            {
                SystemUserGroupWrapper obj = new SystemUserGroupWrapper();
                obj.GroupNameCn = this.txtGroupNameCn.Text.Trim();
                obj.GroupNameEn = this.txtGroupNameEn.Text.Trim();
                obj.GroupDescription = this.txtGroupDescription.Text.Trim();


                SystemUserGroupWrapper.Save(obj);

                winSystemUserGroupAdd.Hide();

            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }
    }

}