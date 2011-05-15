using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using TreeNode = Ext.Net.TreeNode;
using TreeNodeCollection = Ext.Net.TreeNodeCollection;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.RoleManage
{
    public partial class SystemRoleAssignedApplication : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
 
        }


        [DirectMethod]
        public string GetTreeNodes(string selectNodeID)
        {
            int applicationid = int.Parse(selectNodeID);

            SystemApplicationWrapper applicationWrapper = SystemApplicationWrapper.FindById(applicationid);

            if (applicationWrapper != null)
            {
                List<NavMenu> menus = SystemMenuWrapper.GetNavMenuByApplication(applicationWrapper);

                return BuildTree(menus, applicationWrapper.SystemApplicationName).ToJson();
            }

            return "";
        }

        private TreeNodeCollection BuildTree(List<NavMenu> menus, string rootName)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            TreeNode root = new TreeNode();
            root.Text = rootName;
            root.Icon = Icon.Folder;

            nodes.Add(root);

            if (menus == null || menus.Count == 0)
                return nodes;

            List<string> roleAssignedmenuIDs = SystemMenuWrapper.GetRoleAssignedMenuIDs(SystemRoleWrapper.FindById(RoleID));

            foreach (var menu in menus)
            {
                TreeNode mainNode = new TreeNode();
                mainNode.Text = menu.Name;
                mainNode.NodeID = menu.Id;
                WebUIHelper.SetIcon(menu.Icon, menu.IsCategory, mainNode);
                mainNode.CustomAttributes.Add(new ConfigItem("IsGroup", "1", ParameterMode.Value));
                mainNode.CustomAttributes.Add(new ConfigItem("MenuID", menu.Id, ParameterMode.Value));

                if (roleAssignedmenuIDs.Contains(menu.Id.ToString()))
                    mainNode.Checked = ThreeStateBool.True;
                else
                    mainNode.Checked = ThreeStateBool.False;
                GenerateSubTreeNode(mainNode, menu, roleAssignedmenuIDs);
                root.Nodes.Add(mainNode);
            }

            

            //foreach (TreeNodeBase treeNodeBase in nodes)
            //{
            //    treeNodeBase.Checked = ThreeStateBool.False;
            //}



            return nodes;
        }


        [DirectMethod]
        public void SaveApplicationAssignedMenus(int app_id, string menu_ids)
        {
            try
            {
                int role_id = RoleID;
                SystemRoleWrapper obj = SystemRoleWrapper.FindById(role_id);
                SystemRoleWrapper.PatchAssignRoleMenusInApplication(obj, app_id, menu_ids.Split(','));
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }

        private void GenerateSubTreeNode(TreeNode mainNode, NavMenu menu, List<string> roleAssignedmenuIDs)
        {
            foreach (var sMenu in menu.SubMenus)
            {
                TreeNode subNode = new TreeNode();
                subNode.Text = sMenu.Name;
                subNode.NodeID = sMenu.Id;
                WebUIHelper.SetIcon(menu.Icon, menu.IsCategory, mainNode);
                subNode.CustomAttributes.Add(new ConfigItem("IsGroup", (sMenu.IsCategory ? "1" : "0"), ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("MenuID", menu.Id, ParameterMode.Value));
                if (roleAssignedmenuIDs.Contains(menu.Id.ToString()))
                    subNode.Checked = ThreeStateBool.True;
                else
                    subNode.Checked = ThreeStateBool.False;
                //subNode.Leaf = sMenu.IsCategory;
                //mainNode.Leaf = sMenu.IsCategory;
                GenerateSubTreeNode(subNode, sMenu, roleAssignedmenuIDs);
                mainNode.Nodes.Add(subNode);
            }
        }

        protected void btnAdd_Click(object sender, DirectEventArgs e)
        {

            try
            {
                string json = e.ExtraParams["addItem"];
                List<SystemApplicationWrapper> companies = JSON.Deserialize<List<SystemApplicationWrapper>>(json);

                List<int> assignedAppIDs = new List<int>();

                foreach (SystemApplicationWrapper systemApplicationWrapper in companies)
                {
                    assignedAppIDs.Add(systemApplicationWrapper.SystemApplicationID);
                }

                SystemRoleWrapper systemRoleWrapper = SystemRoleWrapper.FindById(RoleID);

                SystemRoleWrapper.PatchAssignRoleApplications(systemRoleWrapper, assignedAppIDs);
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }

        protected void btnRemove_Click(object sender, DirectEventArgs e)
        {

            try
            {
                string json = e.ExtraParams["removeItem"];
                List<SystemApplicationWrapper> companies = JSON.Deserialize<List<SystemApplicationWrapper>>(json);

                List<int> assignedAppIDs = new List<int>();

                foreach (SystemApplicationWrapper systemApplicationWrapper in companies)
                {
                    assignedAppIDs.Add(systemApplicationWrapper.SystemApplicationID);
                }

                SystemRoleWrapper systemRoleWrapper = SystemRoleWrapper.FindById(RoleID);

                SystemRoleWrapper.PatchRemoveRoleApplications(systemRoleWrapper, assignedAppIDs);
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
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

                SystemRoleWrapper.PatchSetRoleApplications(SystemRoleWrapper.FindById(RoleID), list);
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
