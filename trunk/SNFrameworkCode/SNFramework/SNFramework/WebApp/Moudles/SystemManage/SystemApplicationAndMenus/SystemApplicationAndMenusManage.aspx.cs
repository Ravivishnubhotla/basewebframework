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


        protected void RowSelect(object sender, DirectEventArgs e)
        {
            int recordID = Convert.ToInt32(e.ExtraParams["RecordID"]);

            SystemApplicationWrapper applicationWrapper = SystemApplicationWrapper.FindById(recordID);

            if (applicationWrapper != null)
            {
                this.TreePanel1.Title = applicationWrapper.LocaLocalizationName + " - 子菜单管理";

                List<NavMenu> menus = SystemMenuWrapper.GetNavMenuByApplication(applicationWrapper);

     

                Ext.Net.TreeNode root = new TreeNode();
                root.Text = applicationWrapper.LocaLocalizationName;
                root.Icon = Icon.Folder;
                this.TreePanel1.Root.
                                this.TreePanel1.SetRootNode(root);

                if (!(menus == null || menus.Count == 0))
                {
                    foreach (var menu in menus)
                    {
                        TreeNode mainNode = new TreeNode();
                        mainNode.Text = menu.Name;
                        mainNode.NodeID = menu.Id;
                        WebUIHelper.SetIcon(menu.Icon, menu.IsCategory, mainNode);
                        //if (menu.IsCategory)
                        //    mainNode.Icon = Icon.Folder;
                        //else
                        //    mainNode.Icon = Icon.ApplicationForm;
                        mainNode.CustomAttributes.Add(new ConfigItem("IsGroup", "1", ParameterMode.Value));
                        mainNode.CustomAttributes.Add(new ConfigItem("MenuID", menu.Id, ParameterMode.Value));
                        GenerateSubTreeNode(mainNode, menu);
                        root.Nodes.lo
                    }

                }


 
            }


        }

        private void GenerateSubTreeNode(TreeNode mainNode, NavMenu menu)
        {
            foreach (var sMenu in menu.SubMenus)
            {
                TreeNode subNode = new TreeNode();
                subNode.Text = sMenu.Name;
                subNode.NodeID = sMenu.Id;
                WebUIHelper.SetIcon(menu.Icon, menu.IsCategory, mainNode);
                //if (sMenu.IsCategory)
                //    subNode.Icon = Icon.Folder;
                //else
                //    subNode.Icon = Icon.ApplicationForm;
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