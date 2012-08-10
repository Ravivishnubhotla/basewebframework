using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Securitys.SSO;
using Legendigital.Framework.Common.Web.UI;

namespace Legendigital.Common.WebApp.AppCode
{
    public static class WebUIHelper
    {
        public static TreeNodeCollection BuildTree<T>(List<TypedTreeNodeItem<T>> items, string rootName, Icon treeIcon)
        {
            TreeNodeCollection nodes = new TreeNodeCollection();

            TreeNode root = new TreeNode();
            root.Text = rootName;
            root.Icon = treeIcon;

            nodes.Add(root);

            if (items == null || items.Count == 0)
                return nodes;

            foreach (TypedTreeNodeItem<T> item in items)
            {
                TreeNode mainNode = new TreeNode();
                mainNode.Text = item.Name;
                mainNode.NodeID = item.Id;

                mainNode.Icon = treeIcon;

                mainNode.CustomAttributes.Add(new ConfigItem("ID", item.Id, ParameterMode.Value));
                GenerateSubTreeNode(mainNode, item, treeIcon);
                root.Nodes.Add(mainNode);
            }

            return nodes;
        }

        private static void GenerateSubTreeNode<T>(TreeNode mainNode, TypedTreeNodeItem<T> item, Icon treeIcon)
        {
            foreach (TypedTreeNodeItem<T> sitem in item.SubNodes)
            {
                TreeNode subNode = new TreeNode();

                subNode.Text = sitem.Name;
                subNode.NodeID = sitem.Id;
                subNode.Icon = treeIcon;

                mainNode.CustomAttributes.Add(new ConfigItem("ID", item.Id, ParameterMode.Value));

                GenerateSubTreeNode(subNode, sitem, treeIcon);
                mainNode.Nodes.Add(subNode);
            }
        }

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
                
                if (submenu.IsSystem)
                    subNode.Href = page.ResolveUrl(submenu.NavUrl);
                else
                {
                    string url = CombineWebUrl(submenu.SystemUrl, submenu.NavUrl);

                    if (url.Contains("?"))
                    {
                        url = url + "&" + SSOProvider.QUERY_STRING_NAME_SSFToken +
                              page.Request.QueryString[SSOProvider.QUERY_STRING_NAME_SSFToken];
                    }
                    else
                    {
                        url = url + "?" + SSOProvider.QUERY_STRING_NAME_SSFToken +
                        page.Request.QueryString[SSOProvider.QUERY_STRING_NAME_SSFToken];                  
                    }


                    subNode.Href = url;
                }
                
                subNode.CustomAttributes.Add(new ConfigItem("isCategory", submenu.IsCategory.ToString(),
                                                            ParameterMode.Value));

                mainNode.Nodes.Add(subNode);
                CreateSubItem(submenu, subNode, page);
            }
        }

        private static string CombineWebUrl(string hostUrl,string rootUrl)
        {
            if(!hostUrl.EndsWith("/"))
            {
                hostUrl = hostUrl + "/";
            }

            if (rootUrl.StartsWith("~/"))
            {
                rootUrl = rootUrl.Replace("~/", "/");
            }       

            if (!rootUrl.StartsWith("/"))
            {
                rootUrl = "/" + rootUrl;
            }

            return hostUrl + rootUrl.Substring(1, rootUrl.Length - 1);
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

        public static string GetSelectMutilItems(ComboBoxBaseMulti<ListItem> cmb,string splitChar)
        {
            List<string> selectItems = new List<string>();
            foreach (var selectItem in cmb.SelectedItems)
            {
                if (selectItem.Value!=null)
                    selectItems.Add(selectItem.Value.ToString());
            }
            return string.Join(splitChar, selectItems.ToArray());
        }

        public static void SetSelectMutilItems(ComboBoxBaseMulti<ListItem> cmb, string splitChar,string selectValue)
        {
            List<string> selectItems = new List<string>(selectValue.Split(splitChar.ToCharArray(), StringSplitOptions.None));

            cmb.SelectedItems.Clear();

            foreach (var selectItem in selectItems)
            {
                cmb.SelectedItems.Add(new SelectedListItem(selectItem));          
            }
           
        }

        public static PageQueryParams GetPageQueryParamFromStoreRefreshDataEventArgs(StoreRefreshDataEventArgs e, int pageSize)
        {
            int startIndex = 0;

            if (e.Start > -1)
            {
                startIndex = e.Start;
            }

            int limit = pageSize;

            int pageIndex = 1;

            if ((startIndex % limit) == 0)
                pageIndex = startIndex / limit + 1;
            else
                pageIndex = startIndex / limit;

            PageQueryParams pageQueryParams = new PageQueryParams();
            pageQueryParams.PageSize = limit;
            pageQueryParams.PageIndex = pageIndex;

            return pageQueryParams;
        }

        public static PageQueryParams GetPageQueryParamFromStoreRefreshDataEventArgs(StoreRefreshDataEventArgs e,Ext.Net.PagingToolbar pagingToolbar)
        {
            return GetPageQueryParamFromStoreRefreshDataEventArgs(e, pagingToolbar.PageSize);
        }

        public static RecordSortor GetRecordSortorFromStoreRefreshDataEventArgs(StoreRefreshDataEventArgs e)
        {
            RecordSortor recordSortor = new RecordSortor();

            recordSortor.OrderByColumnName = "";
            if (e.Sort != null)
                recordSortor.OrderByColumnName = e.Sort;

            recordSortor.IsDesc = (e.Dir == Ext.Net.SortDirection.DESC);

            return recordSortor;
        }
    }
}