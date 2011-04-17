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
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using TreeNode = Ext.Net.TreeNode;
using TreeNodeCollection = Ext.Net.TreeNodeCollection;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.SystemApplicationAndMenus
{
    public partial class SystemApplicationAndMenusManage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            this.GridPanel1.Reload();
        }


        [DirectMethod]
        public void DeleteMenu(string smenuID)
        {

            try
            {
                int menuID = int.Parse(smenuID);

                SystemMenuWrapper.DeleteByID(menuID);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception e)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(e.Message);
                return;
            }

        }

        [DirectMethod]
        public void AutoMaticSortSubItems(string appid, string pmenuID)
        {
            try
            {
                int menuID = int.Parse(pmenuID);

                int iappID = int.Parse(appid);

                SystemMenuWrapper.AutoMaticSortSubItems(iappID, menuID);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception e)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(e.Message);
                return;
            }

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

            foreach (var menu in menus)
            {
                TreeNode mainNode = new TreeNode();
                mainNode.Text = menu.Name;
                mainNode.NodeID = menu.Id;
                WebUIHelper.SetIcon(menu.Icon, menu.IsCategory, mainNode);
                mainNode.CustomAttributes.Add(new ConfigItem("IsGroup", "1", ParameterMode.Value));
                mainNode.CustomAttributes.Add(new ConfigItem("MenuID", menu.Id, ParameterMode.Value));
                GenerateSubTreeNode(mainNode, menu);
                root.Nodes.Add(mainNode);
            }

            return nodes;
        }

        private void GenerateSubTreeNode(TreeNode mainNode, NavMenu menu)
        {
            foreach (var sMenu in menu.SubMenus)
            {
                TreeNode subNode = new TreeNode();
                subNode.Text = sMenu.Name;
                subNode.NodeID = sMenu.Id;
                WebUIHelper.SetIcon(menu.Icon, menu.IsCategory, mainNode);
                subNode.CustomAttributes.Add(new ConfigItem("IsGroup", (sMenu.IsCategory ? "1" : "0"), ParameterMode.Value));
                subNode.CustomAttributes.Add(new ConfigItem("MenuID", menu.Id, ParameterMode.Value));
                GenerateSubTreeNode(subNode, sMenu);
                mainNode.Nodes.Add(subNode);
            }
        }

        protected void storeSystemApplication_Refresh(object sender, StoreRefreshDataEventArgs e)
        {

            string sortFieldName = "";
            if (e.Sort != null)
                sortFieldName = e.Sort;

            int startIndex = 0;

            if (e.Start > -1)
            {
                startIndex = e.Start;
            }

            int limit = 10;

            int pageIndex = 1;

            if ((startIndex % limit) == 0)
                pageIndex = startIndex / limit + 1;
            else
                pageIndex = startIndex / limit;

            PageQueryParams pageQueryParams = new PageQueryParams();
            pageQueryParams.PageSize = limit;
            pageQueryParams.PageIndex = pageIndex;

            storeSystemApplication.DataSource = SystemApplicationWrapper.FindAllByOrderBy(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSystemApplication.DataBind();

        }
 

        [DirectMethod()]
        public void DeleteRecord(int id)
        {
            try
            {
                //throw new Exception("11111");
                SystemApplicationWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        //protected void storeSystemApplication_Refresh(object sender, StoreRefreshDataEventArgs e)
        //{

        //    string sortFieldName = "";
        //    if (e.Sort != null)
        //        sortFieldName = e.Sort;

        //    int startIndex = 0;

        //    if (e.Start > -1)
        //    {
        //        startIndex = e.Start;
        //    }

        //    int limit = this.PagingToolBar1.PageSize;

        //    int pageIndex = 1;

        //    if ((startIndex % limit) == 0)
        //        pageIndex = startIndex / limit + 1;
        //    else
        //        pageIndex = startIndex / limit;

        //    PageQueryParams pageQueryParams = new PageQueryParams();
        //    pageQueryParams.PageSize = limit;
        //    pageQueryParams.PageIndex = pageIndex;

        //    storeSystemApplication.DataSource = SystemApplicationWrapper.FindAllByOrderBy(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), pageQueryParams);
        //    e.Total = pageQueryParams.RecordCount;

        //    storeSystemApplication.DataBind();

        //}

    }
}