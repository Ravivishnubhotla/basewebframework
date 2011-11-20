using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage
{
    [DirectMethodProxyID(IDMode = DirectMethodProxyIDMode.Alias, Alias = "UCSystemOrganizationAdd")]
    public partial class UCSystemOrganizationAdd : BaseUserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public void Show()
        {
            try
            {
                this.winSystemOrganizationAdd.Show();
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "ErrorMessage:" + ex.Message;
            }
        }

        protected void btnSaveSystemOrganization_Click(object sender, DirectEventArgs e)
        {
            try
            {
                SystemOrganizationWrapper obj = new SystemOrganizationWrapper();

                obj.Name = this.txtName.Text.Trim();
                obj.ShortName = this.txtShortName.Text.Trim();
                obj.Code = this.txtCode.Text.Trim();
                obj.Description = this.txtDescription.Text.Trim();
                obj.LogoUrl = this.txtLogoUrl.Text.Trim();

                obj.MasterName = this.txtMasterName.Text.Trim();
                obj.IsMainOrganization = this.chkIsMainOrganization.Checked;

                obj.TelPhone = this.txtTelPhone.Text.Trim();
                obj.FaxNumber = this.txtFaxNumber.Text.Trim();
                obj.WebSite = this.txtWebSite.Text.Trim();
                obj.Email = this.txtEmail.Text.Trim();

                SystemOrganizationWrapper.Save(obj, this.ParentPage.CurrentLoginUser.UserID);

                winSystemOrganizationAdd.Hide();

            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
            }
        }
    }
}
