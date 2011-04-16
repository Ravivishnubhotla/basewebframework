using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework;

namespace Legendigital.Common.WebApp.AppCode
{
    public static class WebUIHelper
    {
        public static TreeNode CreateMainItem(NavMenu menu, Panel leftPanel)
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
            SetIconTreePanel(menu.Icon, true, treePanel);
            treePanel.Listeners.Click.Handler = "e.stopEvent();loadPage(#{MainTabs},node)";
            var rootNode = new TreeNode(menu.Id, menu.Name, Icon.FolderHome);
            rootNode.Expanded = true;
            treePanel.Root.Add(rootNode);
            leftPanel.Items.Add(treePanel);
            return rootNode;
        }

        public static void CreateSubItem(NavMenu menu, TreeNode mainNode,Page page)
        {
            foreach (NavMenu submenu in menu.SubMenus)
            {
                var subNode = new TreeNode(submenu.Id);
                subNode.Text = submenu.Name;
                SetIcon(submenu.Icon, submenu.IsCategory, subNode);
                subNode.Href = page.ResolveUrl(submenu.NavUrl);
                subNode.CustomAttributes.Add(new ConfigItem("isCategory", submenu.IsCategory.ToString(),
                                                            ParameterMode.Value));


                mainNode.Nodes.Add(subNode);
                CreateSubItem(submenu, subNode, page);
            }
        }

        public static Icon GetDefaultIcon(bool iscategoty)
        {
            if (iscategoty)
                return Icon.Folder;
            else
                return Icon.Link;
        }

        public static void SetIconTreePanel(string icon, bool iscategoty, TreePanel pnl)
        {
            //没有图标显示默认图标
            if (string.IsNullOrEmpty(icon) || string.IsNullOrEmpty(icon.Trim()))
            {
                pnl.Icon = GetDefaultIcon(iscategoty);
                return;
            }

            //显示系统图标
            if (icon.StartsWith("[S]"))
            {
                try
                {
                    var sicon = (Icon)Enum.Parse(typeof(Icon), icon.Replace("[S]", ""), true);
                    pnl.Icon = sicon;
                    return;
                }
                catch
                {
                    //转换失败显示默认图标
                    pnl.Icon = GetDefaultIcon(iscategoty);
                    return;
                }
            }
            //显示自定义图标
            if (icon.StartsWith("[C]"))
            {
                pnl.IconCls = icon.Replace("[C]", "");
                return;
            }

            pnl.Icon = GetDefaultIcon(iscategoty);
        }

        public static void SetIcon(string icon, bool iscategoty, TreeNode node)
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
    }
}