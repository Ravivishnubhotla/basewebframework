using System;
using System.Collections.Generic;
using System.Web.Security;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.MainPage
{
    public partial class Default : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ExtNet.IsAjaxRequest)
                return;


            Session["Ext.Net.Theme"] = Ext.Net.Theme.Default;
            cbTheme.SelectedItem.Value = ResourceManagerProxy1.Theme.ToString();
            lblUser.Text = string.Format("<b>{0}</b>", Context.User.Identity.Name);
            lblToday.Text = string.Format("当前日期：{0:D}", DateTime.Now);

            SystemSettingWrapper settingWrapper = SystemSettingWrapper.GetCurrentSystemSetting();

            locSystemName.Text = settingWrapper.SystemName + " " + settingWrapper.SystemVersion;
            locCopyRight.Text = settingWrapper.SystemLisence;

            InitLeftMenu();
        }


        [DirectMethod]
        public string GetThemeUrl(string theme)
        {
            var temp = (Theme) Enum.Parse(typeof (Theme), theme);

            Session["Ext.Net.Theme"] = temp;
            return (temp == Ext.Net.Theme.Default) ? "Default" : ExtNet.ResourceManager.GetThemeUrl(temp);
        }

        private void InitLeftMenu()
        {
            List<NavMenu> navMenus = SystemMenuWrapper.GetUserAssignedNavMenuByUserLoginID(CurrentLoginUser.UserLoginID);

            foreach (NavMenu m in navMenus)
            {
                TreeNode topnode = CreateMainItem(m, LeftPanel);

                CreateSubItem(m, topnode);
            }
        }

        private TreeNode CreateMainItem(NavMenu menu, Panel leftPanel)
        {
            var treePanel = new TreePanel();
            treePanel.ID = "tp" + menu.Id;
            treePanel.AutoScroll = true;
            treePanel.Collapsed = false;
            treePanel.CollapseFirst = true;
            treePanel.HideParent = false;
            treePanel.RootVisible = false;
            treePanel.Title = menu.Name;
            treePanel.Icon = Icon.ApplicationHome;
            treePanel.Listeners.Click.Handler = "e.stopEvent();loadPage(#{MainTabs},node)";
            var rootNode = new TreeNode(menu.Id, menu.Name, Icon.FolderHome);
            rootNode.Expanded = true;
            treePanel.Root.Add(rootNode);
            leftPanel.Items.Add(treePanel);
            return rootNode;
        }

        private void CreateSubItem(NavMenu menu, TreeNode mainNode)
        {
            foreach (NavMenu submenu in menu.SubMenus)
            {
                var subNode = new TreeNode(submenu.Id);
                subNode.Text = submenu.Name;
                SetIcon(submenu.Icon, submenu.IsCategory, subNode);
                subNode.Href = ResolveUrl(submenu.NavUrl);
                subNode.CustomAttributes.Add(new ConfigItem("isCategory", submenu.IsCategory.ToString(),
                                                            ParameterMode.Value));
                mainNode.Nodes.Add(subNode);
                CreateSubItem(submenu, subNode);
            }
        }

        private Icon GetDefaultIcon(bool iscategoty)
        {
            if (iscategoty)
                return Icon.Folder;
            else
                return Icon.Link;
        }

        private void SetIcon(string icon, bool iscategoty, TreeNode node)
        {
            //没有图标显示默认图标
            if (string.IsNullOrEmpty(icon) || string.IsNullOrEmpty(icon.Trim()))
            {
                node.Icon = GetDefaultIcon(iscategoty);
                return;
            }

            //显示系统图标
            if (icon.StartsWith("[S]"))
            {
                try
                {
                    var sicon = (Icon) Enum.Parse(typeof (Icon), icon.Replace("[S]", ""), true);
                    node.Icon = sicon;
                    return;
                }
                catch
                {
                    //转换失败显示默认图标
                    node.Icon = GetDefaultIcon(iscategoty);
                    return;
                }
            }
            //显示自定义图标
            if (icon.StartsWith("[C]"))
            {
                node.IconCls = icon.Replace("[C]", "");
                return;
            }

            node.Icon = GetDefaultIcon(iscategoty);
        }

        protected void btnExit_Click(object sender, DirectEventArgs e)
        {
            FormsAuthentication.SignOut();
        }
    }
}