using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Commons;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Web.UI;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace SNFramework.BSF.Moudles.SystemManage.PermissionManage
{
    public partial class SystemResourcesAndPriviliege : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [DirectMethod]
        public string GetTreeNodes()
        {
            List<TypedTreeNodeItem<SystemResourcesWrapper>> nodes = (new SystemResourcesWrapper()).GetAllTreeItems();

            return WebUIHelper.BuildTree<SystemResourcesWrapper>(nodes, "All Resources", Icon.Bricks).ToJson();
        }


        [DirectMethod]
        public void DeleteSystemPrivilegeRecord(int id)
        {
            try
            {
                SystemPrivilegeWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSystemPrivilege_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e, this.PagingToolBar1);

            RecordSortor recordSortor = WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e);

            int selectResourceID = 0;

            if (e.Parameters["SelectResourceID"] != null)
            {
                selectResourceID = Convert.ToInt32(e.Parameters["SelectResourceID"]);
            }

            if (selectResourceID == 0)
            {
                storeSystemPrivilege.DataSource = new List<SystemPrivilegeWrapper>();
                e.Total = 0;
                storeSystemPrivilege.DataBind();

                return;
            }

            SystemResourcesWrapper resourcesWrapper = SystemResourcesWrapper.FindById(selectResourceID);

            if (resourcesWrapper == null)
            {
                storeSystemPrivilege.DataSource = new List<SystemPrivilegeWrapper>();
                e.Total = 0;
                storeSystemPrivilege.DataBind();

                return;
            }

            storeSystemPrivilege.DataSource = SystemPrivilegeWrapper.FindAllByOrderByAndFilterAndResourcesID(recordSortor.OrderByColumnName, recordSortor.IsDesc, resourcesWrapper, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSystemPrivilege.DataBind();

        }



        [DirectMethod]
        public void DeleteSystemOperationRecord(int id)
        {
            try
            {
                SystemOperationWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        [DirectMethod]
        public void QuickPatchAddOperation(int resourceid)
        {
            try
            {
                SystemOperationWrapper.QuickPatchAddOperation(resourceid);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        [DirectMethod]
        public void QuickGeneratePrivilege(int resourceid)
        {
            try
            {
                SystemPrivilegeWrapper.QuickGeneratePrivilege(resourceid);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }




        protected void storeSystemOperation_Refresh(object sender, StoreRefreshDataEventArgs e)
        {



            string sortFieldName = "";
            if (e.Sort != null)
                sortFieldName = e.Sort;

            int startIndex = 0;

            if (e.Start > -1)
            {
                startIndex = e.Start;
            }

            int limit = this.PagingToolBar1.PageSize;

            int pageIndex = 1;

            if ((startIndex % limit) == 0)
                pageIndex = startIndex / limit + 1;
            else
                pageIndex = startIndex / limit;

            int selectResourceID = 0;

            if (e.Parameters["SelectResourceID"] != null)
            {
                selectResourceID = Convert.ToInt32(e.Parameters["SelectResourceID"]);
            }

            if (selectResourceID == 0)
            {
                storeSystemOperation.DataSource = new List<SystemOperationWrapper>();
                e.Total = 0;
                storeSystemOperation.DataBind();

                return;
            }

            SystemResourcesWrapper resourcesWrapper = SystemResourcesWrapper.FindById(selectResourceID);

            if (resourcesWrapper == null)
            {
                storeSystemOperation.DataSource = new List<SystemOperationWrapper>();
                e.Total = 0;
                storeSystemOperation.DataBind();

                return;
            }


            PageQueryParams pageQueryParams = new PageQueryParams();
            pageQueryParams.PageSize = limit;
            pageQueryParams.PageIndex = pageIndex;

            storeSystemOperation.DataSource = SystemOperationWrapper.FindAllByOrderByAndFilterAndResourceID(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), resourcesWrapper, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSystemOperation.DataBind();

        }


        [DirectMethod]
        public void DeleteData(int id)
        {
            try
            {
                SystemResourcesWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception e)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = e.Message;
                return;
            }

        }

    }
}