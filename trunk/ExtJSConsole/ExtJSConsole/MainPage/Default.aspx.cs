using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace ExtJSConsole.MainPage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;


            this.Session["Coolite.Theme"] = Coolite.Ext.Web.Theme.Default;

            this.cbTheme.SelectedItem.Value = this.ScriptManagerProxy1.Theme.ToString();

            this.lblUser.Text = string.Format("<b>{0}</b>", this.Context.User.Identity.Name.ToString());

            this.lblToday.Text = string.Format("今天是{0:D}", System.DateTime.Now);

            InitLeftMenu();
        }


        [AjaxMethod]
        public string GetThemeUrl(string theme)
        {
            Theme temp = (Theme)Enum.Parse(typeof(Theme), theme);

            this.Session["Coolite.Theme"] = temp;

            return (temp == Coolite.Ext.Web.Theme.Default) ? "Default" : this.ScriptManagerProxy1.GetThemeUrl(temp);
        }

        private void InitLeftMenu()
        {
            //List<SystemMenuWrapper> usermenus = SystemMenuWrapper.GetUserAssignedMenuByUserLoginID(this.Context.User.Identity.Name.ToString());

            //List<SystemMenuWrapper> topMenus = usermenus.FindAll(p => p.ParentMenuID == null || p.ParentMenuID.MenuID == 0);



            //foreach (SystemMenuWrapper menu in topMenus)
            //{
            //    TreeNode rootNode = CreateMainItem(menu, leftAccordion);

            //    int menuID = menu.MenuID;

            //    List<SystemMenuWrapper> subMenus = usermenus.FindAll(p => p.ParentMenuID != null && p.ParentMenuID.MenuID == menuID);

            //    foreach (SystemMenuWrapper subMenu in subMenus)
            //    {
            //        CreateSubItem(subMenu.MenuID.ToString(), subMenu.MenuName, Icon.FolderLink, this.Page.ResolveUrl(subMenu.MenuUrl), rootNode);
            //    }

            //}

            NavMenu rootMenu = new NavMenu();

            NavMenu abMenu1 = new NavMenu();

            abMenu1.Name = "系统管理";
            abMenu1.Id = "M11";

            abMenu1.AddSubMenu("M111", "应用管理", "~/Moudle/SystemManage/ApplicationManage/SystemApplicationListPage.aspx", "");
            abMenu1.AddSubMenu("M112", "菜单管理", "~/Moudle/SystemManage/MenuManage/SystemMenuListPage.aspx", "");
            abMenu1.AddSubMenu("M113", "部门管理", "~/Moudle/SystemManage/DepartmentManage/SystemDepartmentListPage.aspx", "");
            abMenu1.AddSubMenu("M114", "角色管理", "~/Moudle/SystemManage/RoleManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M115", "用户管理", "~/Moudle/SystemManage/UserManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M115", "用户组管理", "~/Moudle/SystemManage/UserGroupManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M116", "权限管理", "~/Moudle/SystemManage/PermissionManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M119", "模块管理", "~/Moudle/SystemManage/MoudleManage/SystemMoudleListPage.aspx", "");

            
            abMenu1.AddSubMenu("M117", "字典管理", "~/Moudle/SystemManage/DictionaryManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M118", "日志查询", "~/Moudle/SystemManage/MoudleManage/SystemMoudleListPage.aspx", "");

            rootMenu.AddSubMenu(abMenu1);



            foreach (NavMenu menu in rootMenu.SubMenus)
            {
                TreeNode rootNode = CreateMainItem(menu.Id, menu.Name, leftAccordion);

                foreach (NavMenu subMenu in menu.SubMenus)
                {
                    CreateSubItem(subMenu.Id, subMenu.Name, Icon.FolderLink, this.Page.ResolveUrl(subMenu.NavUrl), rootNode);
                }

            }


        }

        private TreeNode CreateMainItem(string id, string name, Accordion accordion)
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
            accordion.Items.Add(treePanel);
            return rootNode;
        }


        private TreeNode CreateMainItem(SystemMenuWrapper menu, Accordion accordion)
        {
            TreePanel treePanel = new TreePanel();
            treePanel.ID = "tp" + menu.MenuID.ToString();
            treePanel.AutoScroll = true;
            treePanel.Collapsed = false;
            treePanel.CollapseFirst = true;
            treePanel.HideParent = false;
            treePanel.RootVisible = false;
            treePanel.Title = menu.MenuName;
            treePanel.Icon = Icon.ApplicationHome;
            treePanel.Listeners.Click.Handler = "e.stopEvent();loadPage(MainTabs,node);";
            TreeNode rootNode = new TreeNode(menu.MenuID.ToString(), menu.MenuName, Icon.FolderHome);
            rootNode.Expanded = true;
            treePanel.Root.Add(rootNode);
            accordion.Items.Add(treePanel);
            return rootNode;
        }

        private TreeNode CreateSubItem(string id, string name, Icon icon, string url, TreeNode mainNode)
        {
            TreeNode subNode = new TreeNode(id, name, icon);
            subNode.Href = url;
            mainNode.Nodes.Add(subNode);
            return subNode;
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}