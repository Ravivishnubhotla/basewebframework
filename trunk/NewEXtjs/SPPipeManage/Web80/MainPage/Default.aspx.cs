using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Common.Logging;
using Coolite.Ext.Web;
using Coolite.Utilities;
using Legendigital.Common.Web.Jobs;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using TreeNode=Coolite.Ext.Web.TreeNode;
using Panel = Coolite.Ext.Web.Panel;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Common.Web.MainPage
{
    public partial class Default : BaseSecurityPage
    {
        private ILog logger = LogManager.GetLogger(typeof(BaseSecurityPage));


        protected void Page_Load(object sender, EventArgs e)
        {
            //foreach (Portlet portlet in ControlUtils.FindControls<Portlet>(this.Page))
            //{
            //    portlet.AjaxEvents.Hide.Event += Portlet_Hide;
            //    portlet.AjaxEvents.Hide.EventMask.ShowMask = true;
            //    portlet.AjaxEvents.Hide.EventMask.Msg = "Saving...";
            //    portlet.AjaxEvents.Hide.EventMask.MinDelay = 500;

            //    portlet.AjaxEvents.Hide.ExtraParams.Add(new Coolite.Ext.Web.Parameter("ID", portlet.ClientID));
            //}


            if (Ext.IsAjaxRequest)
                return;

            //logger.Error("1111");


            Session["Ext.Net.Theme"] = Coolite.Ext.Web.Theme.Default;
            cbTheme.SelectedItem.Value = ScriptManagerProxy1.Theme.ToString();
            lblUser.Text = string.Format("<b>{0}</b>", Context.User.Identity.Name);
            lblToday.Text = string.Format("当前日期：{0:D}", DateTime.Now);

            SystemSettingWrapper settingWrapper = SystemSettingWrapper.GetCurrentSystemSetting();

            locSystemName.Text = settingWrapper.SystemName + " " + settingWrapper.SystemVersion;
            locCopyRight.Text = settingWrapper.SystemLisence;

            InitLeftMenu();
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

        private TreeNode CreateMainItem(NavMenu menu, Accordion accordion)
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
            accordion.Items.Add(treePanel);
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

        protected void Portlet_Hide(object sender, AjaxEventArgs e)
        {
            string id = e.ExtraParams["ID"];
            this.ScriptManagerProxy1.AddScript("Ext.Msg.alert('Status','" + id + " Hidden');");
        }

        private Icon GetDefaultIcon(bool iscategoty)
        {
            if (iscategoty)
                return Icon.Folder;
            else
                return Icon.Link;
        }

        private void SetIcon(string icon, bool iscategoty, Coolite.Ext.Web.TreeNode node)
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
                    var sicon = (Icon)Enum.Parse(typeof(Icon), icon.Replace("[S]", ""), true);
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


        protected void btnExit_Click(object sender, AjaxEventArgs e)
        {
            SystemUserWrapper userWrapper = this.CurrentLoginUser;

            if(userWrapper!=null)
            {
                string ip = HttpUtil.GetIP(Request);

                SystemLogWrapper.AddSecurityLog(userWrapper.UserLoginID, System.DateTime.Now, "", ip, HttpUtil.ParseLocation(ip), SystemLogWrapper.SecurityLogType.Logout);

            }

            FormsAuthentication.SignOut();
        }
    }
}
