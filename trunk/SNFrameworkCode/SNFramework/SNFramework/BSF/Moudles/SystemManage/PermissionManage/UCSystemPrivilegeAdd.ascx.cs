using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace SNFramework.BSF.Moudles.SystemManage.PermissionManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemPrivilegeAdd")]
    public partial class UCSystemPrivilegeAdd : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show(int rid)
        {
            try
            {
                this.lblResourcesName.Text = SystemResourcesWrapper.FindById(rid).ResourcesNameCn;

                this.hidResourcesID.Value = rid;

                this.winSystemPrivilegeAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message ：" + ex.Message;
            }
        }

        protected void btnSaveSystemPrivilege_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemPrivilegeWrapper obj = new SystemPrivilegeWrapper();
                obj.OperationID = SystemOperationWrapper.FindById(Convert.ToInt32(this.cmbOperationID.SelectedItem.Value));
                obj.ResourcesID = SystemResourcesWrapper.FindById(Convert.ToInt32(this.hidResourcesID.Value));
                obj.PrivilegeCnName = this.txtPrivilegeCnName.Text.Trim();
                obj.PrivilegeEnName = this.txtPrivilegeEnName.Text.Trim();

                obj.Description = this.txtDescription.Text.Trim();
                obj.PrivilegeOrder = Convert.ToInt32(this.txtPrivilegeOrder.Text.Trim());
                //obj.PrivilegeCategory = this.txtPrivilegeCategory.Text.Trim();






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