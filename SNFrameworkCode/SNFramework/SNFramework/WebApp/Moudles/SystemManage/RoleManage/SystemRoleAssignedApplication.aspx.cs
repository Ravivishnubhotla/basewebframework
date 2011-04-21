using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage
{
    public partial class SystemRoleAssignedApplication : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            GridPanel1.Reload();
            GridPanel2.Reload();
        }

        [DirectMethod]
        public void Save_RoleApplication(string json)
        {
            try
            {
                List<SystemApplicationWrapper> applications = JSON.Deserialize<List<SystemApplicationWrapper>>(json);

                List<String> list = new List<string>();

                foreach (SystemApplicationWrapper systemApplicationWrapper in applications)
                {
                    list.Add(systemApplicationWrapper.SystemApplicationID.ToString());
                }

                SystemRoleWrapper.PatchAssignRoleApplications(SystemRoleWrapper.FindById(RoleID), list);
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }


        public int RoleID
        {
            get
            {
                if (this.Request.QueryString["RoleID"] == null)
                {
                    return 0;
                }
                return Convert.ToInt32(this.Request.QueryString["RoleID"]);
            }
        }

        protected void storeNotAssigned_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            storeNotAssigned.DataSource = SystemApplicationWrapper.GetUserAvaiableApplicationsNotAssigned(this.CurrentLoginUser, RoleID);
            storeNotAssigned.DataBind();
        }

        protected void storeAssigned_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            SystemRoleWrapper systemRoleWrapper = SystemRoleWrapper.FindById(RoleID);
            List<SystemApplicationWrapper> assignedRoles = SystemRoleWrapper.GetRoleAssignedApplications(systemRoleWrapper);
            storeAssigned.DataSource = assignedRoles;
            storeAssigned.DataBind();
        }
    }
}
