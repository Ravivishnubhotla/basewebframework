using System;
using System.Collections.Generic;
using System.Web.Security;
using Ext.Net;
using System.Linq;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace Legendigital.Common.WebApp.MainPage
{
    public partial class Default : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;


            this.Session["Ext.Net.Theme"] = Ext.Net.Theme.Default;
            this.cbTheme.SelectedItem.Value = this.ResourceManagerProxy1.Theme.ToString();
            this.lblUser.Text = string.Format("<b>{0}</b>", this.Context.User.Identity.Name.ToString());
            this.lblToday.Text = string.Format("当前日期：{0:D}", System.DateTime.Now);

            SystemSettingWrapper settingWrapper = SystemSettingWrapper.GetCurrentSystemSetting();

            this.locSystemName.Text = settingWrapper.SystemName + " " + settingWrapper.SystemVersion;
            this.locCopyRight.Text = settingWrapper.SystemLisence;

            InitLeftMenu(null, null, 0,true);
        }


        [DirectMethod]
        public string GetThemeUrl(string theme)
        {
            Theme temp = (Theme)Enum.Parse(typeof(Theme), theme);

            this.Session["Ext.Net.Theme"] = temp;
            return (temp == Ext.Net.Theme.Default) ? "Default" : X.ResourceManager.GetThemeUrl(temp);
        }

        private void InitLeftMenu(List<SystemMenuWrapper> list, Ext.Net.TreeNode tnd, int mid, bool flag)
        {
            #region
            //NavMenu rootMenu = new NavMenu();
            //NavMenu abMenu1 = new NavMenu();
            //abMenu1.Name = "SystemManage";
            //abMenu1.Id = "M11";

            //abMenu1.AddSubMenu("M111", "Application Manage", "~/Moudles/SystemManage/ApplicationManage/SystemApplicationListPage.aspx", "");
            //abMenu1.AddSubMenu("M112", "Menu Manage", "~/Moudles/SystemManage/MenuManage/SystemMenuListPage.aspx", "");
            //abMenu1.AddSubMenu("M113", "Department Manage", "~/Moudles/SystemManage/DepartmentManage/SystemDepartmentListPage.aspx", "");
            //abMenu1.AddSubMenu("M114", "Role Manage", "~/Moudles/SystemManage/RoleManage/SystemRoleListPage.aspx", "");
            //abMenu1.AddSubMenu("M115", "User Manage", "~/Moudles/SystemManage/UserManage/SystemUserListPage.aspx", "");
            //abMenu1.AddSubMenu("M116", "User Group Manage", "~/Moudles/SystemManage/UserGroupManage/SystemUserGroupListPage.aspx", "");
            //abMenu1.AddSubMenu("M117", "Permission Manage", "~/Moudles/SystemManage/PermissionManage/SystemPrivilegeListPage.aspx", "");
            //abMenu1.AddSubMenu("M118", "Moudle Manage", "~/Moudles/SystemManage/MoudleManage/SystemMoudleListPage.aspx", "");
            //abMenu1.AddSubMenu("M119", "Dictionary Manage", "~/Moudles/SystemManage/DictionaryManage/SystemDictionaryListPage.aspx", "");
            //abMenu1.AddSubMenu("M120", "Log Manage", "~/Moudles/SystemManage/LogManage/SystemLogListPage.aspx", "");
            //abMenu1.AddSubMenu("M121", "Config Manage", "~/Moudles/SystemManage/ConfigManage/SystemConfigListPage.aspx", "");
            //rootMenu.AddSubMenu(abMenu1);

            //foreach (NavMenu menu in rootMenu.SubMenus)
            //{
            //    TreeNode rootNode = CreateMainItem(menu.Id, menu.Name, LeftPanel);
            //    foreach (NavMenu subMenu in menu.SubMenus)
            //    {
            //        CreateSubItem(subMenu.Id, subMenu.Name, Icon.FolderLink, this.Page.ResolveUrl(subMenu.NavUrl), rootNode);
            //    }
            //}
            #endregion

            List<SystemMenuWrapper> list2 = null;
            if (list == null)
            {
                list = SystemMenuWrapper.GetUserAssignedMenuByUserLoginID(this.CurrentLoginUser.UserLoginID);
            }
            if (mid == 0)
            {
                list2 = list.FindAll(m => m.ParentMenuID == null);
            }
            else
            {
                list2 = list.FindAll(menu => menu.ParentMenuID == null ? false : menu.ParentMenuID.MenuID == mid ? true : false);

            }
            TreeNode tn = null;
            foreach (SystemMenuWrapper m in list2)
            {
                if (flag)
                {
                    tn = CreateMainItem(m.MenuID.ToString(), m.MenuName, LeftPanel);
                }
                else
                {
                    tn = CreateSubItem(m.MenuID.ToString(), m.MenuName, m.MenuIsCategory ? Icon.Folder : Icon.Link, this.Page.ResolveUrl(m.MenuUrl), tnd, m.MenuIsCategory);
                }
                if (list.Exists(menu => menu.ParentMenuID == null ? false : (menu.ParentMenuID.MenuID == m.MenuID) ? true : false))
                {
                    InitLeftMenu(list, tn, m.MenuID, false);
                }
            }
        }

        private TreeNode CreateMainItem(string id, string name, Panel leftPanel)
        {
            TreePanel treePanel = new TreePanel();
            treePanel.ID = "tp" + id;
            treePanel.AutoScroll = true;
            treePanel.Collapsed = false;
            treePanel.CollapseFirst = true;
            treePanel.HideParent = false;
            treePanel.RootVisible = false;
            treePanel.Title = name;
            treePanel.Icon = Icon.ApplicationHome;
            treePanel.Listeners.Click.Handler = "e.stopEvent();loadPage(#{MainTabs},node)";
            TreeNode rootNode = new TreeNode(id, name, Icon.FolderHome);
            rootNode.Expanded = true;
            treePanel.Root.Add(rootNode);
            leftPanel.Items.Add(treePanel);
            return rootNode;
        }

        private TreeNode CreateSubItem(string id, string name, Icon icon, string url, TreeNode mainNode, bool isCategory)
        {
            TreeNode subNode = new TreeNode(id, name, icon);
            subNode.Href = url;
            subNode.CustomAttributes.Add(new ConfigItem("isCategory", isCategory.ToString(), ParameterMode.Value));
            mainNode.Nodes.Add(subNode);
            return subNode;
        }

        protected void btnExit_Click(object sender, DirectEventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}
