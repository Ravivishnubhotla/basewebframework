using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using PhotoAblum.Web.Codes;
using TreeNode=Coolite.Ext.Web.TreeNode;

namespace PhotoAblum.Web.Admin.MainPage
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.lblUser.Text = string.Format("<b>{0}</b>", this.Context.User.Identity.Name.ToString());

            this.lblToday.Text = string.Format("今天是{0:D}", System.DateTime.Now);

            InitLeftMenu();
        }

        private TreeNode CreateMainItem(string id,string name, Accordion accordion)
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

        private TreeNode CreateSubItem(string id, string name, Icon icon, string url, TreeNode mainNode)
        {
            TreeNode subNode = new TreeNode(id, name, icon);
            subNode.Href = url;
            mainNode.Nodes.Add(subNode);
            return subNode;

            
        }


        private void InitLeftMenu()
        {
            NavMenu rootMenu = new NavMenu();


            NavMenu abMenu = new NavMenu();

            abMenu.Name = "相册网站维护";
            abMenu.Id = "M1";

            abMenu.AddSubMenu("M2", "相册管理", "~/Admin/Moudles/Ablums/AblumListPage.aspx", "");

            rootMenu.AddSubMenu(abMenu);

            NavMenu abMenu1 = new NavMenu();

            abMenu1.Name = "系统管理";
            abMenu1.Id = "M11";

            abMenu1.AddSubMenu("M111", "应用管理", "~/Admin/Moudles/SystemManage/ApplicationManage/SystemApplicationListPage.aspx", "");
            abMenu1.AddSubMenu("M112", "菜单管理", "~/Admin/Moudles/SystemManage/MenuManage/SystemMenuListPage.aspx", "");
            abMenu1.AddSubMenu("M113", "部门管理", "~/Admin/Moudles/SystemManage/DepartmentManage/SystemDepartmentListPage.aspx", "");
            abMenu1.AddSubMenu("M114", "角色管理", "~/Admin/Moudles/SystemManage/RoleManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M115", "用户管理", "~/Admin/Moudles/SystemManage/UserManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M115", "用户组管理", "~/Admin/Moudles/SystemManage/UserGroupManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M116", "权限管理", "~/Admin/Moudles/SystemManage/PermissionManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M117", "字典管理", "~/Admin/Moudles/SystemManage/DictionaryManage/AblumListPage.aspx", "");
            abMenu1.AddSubMenu("M118", "日志查询", "~/Admin/Moudles/SystemManage/LogManage/AblumListPage.aspx", "");

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


        protected void btnExit_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}
