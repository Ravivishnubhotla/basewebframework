using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Web.UI;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage
{
    public partial class SystemRoleAssignedPrivilege : System.Web.UI.Page
    {
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

        [DirectMethod]
        public string GetTreeNodes()
        {
            List<TypedTreeNodeItem<SystemResourcesWrapper>> nodes = SystemResourcesWrapper.GetAllTreeNodesItems();

            return WebUIHelper.BuildTree<SystemResourcesWrapper>(nodes, "All Resources", Icon.Bricks).ToJson();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            //GridPanel1.Reload();
            //GridPanel2.Reload();
        }

        protected void Store1_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            int selectResourceID = 0;

            if (e.Parameters["SelectResourceID"] != null)
            {
                selectResourceID = Convert.ToInt32(e.Parameters["SelectResourceID"]);
            }

            if(selectResourceID==0)
            {
                Store1.DataSource = new List<SystemPrivilegeWrapper>();
                Store1.DataBind();
                return;
            }

            SystemResourcesWrapper resourcesWrapper = SystemResourcesWrapper.FindById(selectResourceID);

            SystemRoleWrapper systemRoleWrapper = SystemRoleWrapper.FindById(RoleID);
            List<SystemPrivilegeWrapper> list1 = SystemPrivilegeWrapper.FindAllByResourcesID(resourcesWrapper);
            List<string> list2 = SystemRoleWrapper.GetRoleAssignedPermissionsByResources(systemRoleWrapper, resourcesWrapper);
            List<SystemPrivilegeWrapper> list3 = list1.FindAll(p => !list2.Contains(p.PrivilegeID.ToString()));
            Store1.DataSource = list3;
            Store1.DataBind();
        }

        protected void Store2_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            int selectResourceID = 0;

            if (e.Parameters["SelectResourceID"] != null)
            {
                selectResourceID = Convert.ToInt32(e.Parameters["SelectResourceID"]);
            }

            if (selectResourceID == 0)
            {
                Store2.DataSource = new List<SystemPrivilegeWrapper>();
                Store2.DataBind();
                return;
            }

            SystemResourcesWrapper resourcesWrapper = SystemResourcesWrapper.FindById(selectResourceID);

            SystemRoleWrapper systemRoleWrapper = SystemRoleWrapper.FindById(RoleID);
            List<string> list2 = SystemRoleWrapper.GetRoleAssignedPermissionsByResources(systemRoleWrapper, resourcesWrapper);
            List<SystemPrivilegeWrapper> list3 = new List<SystemPrivilegeWrapper>();
            foreach (string s in list2)
            {
                list3.Add(SystemPrivilegeWrapper.FindById(Int32.Parse(s)));
            }
            Store2.DataSource = list3;
            Store2.DataBind();
        }

  

        [DirectMethod]
        public void Save_RolePermission(string json, int selectResourceID)
        {
            try
            {
                List<SystemPrivilegeWrapper> selectIDs = JSON.Deserialize<List<SystemPrivilegeWrapper>>(json);
                List<String> list = new List<string>();
                foreach (SystemPrivilegeWrapper row in selectIDs)
                {
                    list.Add(row.PrivilegeID.ToString());
                }
                SystemRoleWrapper.PatchAssignRolePermissionsByResourcse(SystemRoleWrapper.FindById(RoleID), list, selectResourceID);
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }

 

    
    }
}
