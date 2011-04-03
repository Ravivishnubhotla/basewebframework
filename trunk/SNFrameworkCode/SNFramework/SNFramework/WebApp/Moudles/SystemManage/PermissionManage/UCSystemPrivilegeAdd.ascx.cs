using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemPrivilegeAdd")]
    public partial class UCSystemPrivilegeAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemPrivilegeAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
            }
        }

        protected void btnSaveSystemPrivilege_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemPrivilegeWrapper obj = new SystemPrivilegeWrapper();
                obj.OperationID = null;
                obj.ResourcesID = null;
                obj.PrivilegeCnName = this.txtPrivilegeCnName.Text.Trim();
                obj.PrivilegeEnName = this.txtPrivilegeEnName.Text.Trim();
                obj.DefaultValue = this.txtDefaultValue.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.PrivilegeOrder = Convert.ToInt32(this.txtPrivilegeOrder.Text.Trim());
                obj.PrivilegeCategory = this.txtPrivilegeCategory.Text.Trim();
                obj.PrivilegeType = this.txtPrivilegeType.Text.Trim();





                SystemPrivilegeWrapper.Save(obj);

                winSystemPrivilegeAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
            }
        }
    }


}