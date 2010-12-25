using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.PermissionManage
{

    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemPrivilegeEdit")]
    public partial class UCSystemPrivilegeEdit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        [DirectMethod]
        public void Show(int id)
        {
            try
            {
                SystemPrivilegeWrapper obj = SystemPrivilegeWrapper.FindById(id);

                if (obj != null)
                {
                    this.radnumOperationID.Value = obj.OperationID.ToString();
                    this.radnumResourcesID.Value = obj.ResourcesID.ToString();
                    this.txtPrivilegeCnName.Text = obj.PrivilegeCnName.ToString();
                    this.txtPrivilegeEnName.Text = obj.PrivilegeEnName.ToString();
                    this.txtDefaultValue.Text = obj.DefaultValue.ToString();
                    this.txtDescription.Text = obj.Description.ToString();
                    this.txtPrivilegeOrder.Text = obj.PrivilegeOrder.ToString();
                    this.txtPrivilegeCategory.Text = obj.PrivilegeCategory.ToString();
                    this.txtPrivilegeType.Text = obj.PrivilegeType.ToString();




                    hidPrivilegeID.Text = id.ToString();


                    winSystemPrivilegeEdit.Show();

                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "ErrorMessage：Data does not exist";
                    return;
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
                return;
            }
        }

        protected void btnSaveSystemPrivilege_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemPrivilegeWrapper obj = SystemPrivilegeWrapper.FindById(int.Parse(hidPrivilegeID.Text.Trim()));
                obj.OperationID = null;
                obj.ResourcesID = null;
                obj.PrivilegeCnName = this.txtPrivilegeCnName.Text.Trim();
                obj.PrivilegeEnName = this.txtPrivilegeEnName.Text.Trim();
                obj.DefaultValue = this.txtDefaultValue.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.PrivilegeOrder = Convert.ToInt32(this.txtPrivilegeOrder.Text.Trim());
                obj.PrivilegeCategory = this.txtPrivilegeCategory.Text.Trim();
                obj.PrivilegeType = this.txtPrivilegeType.Text.Trim();


                SystemPrivilegeWrapper.Update(obj);

                winSystemPrivilegeEdit.Hide();
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage：" + ex.Message;
                return;
            }

        }
    }
}