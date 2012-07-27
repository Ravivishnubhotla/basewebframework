using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SNFramework.BSF.Moudles.SystemManage.UserGroupManage
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemUserGroupAdd")]
    public partial class UCSystemUserGroupAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemUserGroupAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
            }
        }

        protected void btnSaveSystemUserGroup_Click(object sender, DirectEventArgs e)
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
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
            }
        }
    }
}