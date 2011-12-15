using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Commons;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Web.UI;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.OrginationDepartmentManage
{
    public partial class SystemOrginationDepartmentManage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void storeSystemPost_Refresh(object sender, StoreRefreshDataEventArgs e)
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


            int selectOrgID = 0;

            if (e.Parameters["SelectOrgID"] != null)
            {
                selectOrgID = Convert.ToInt32(e.Parameters["SelectOrgID"]);
            }

            if (selectOrgID == 0)
            {
                storeSystemPost.DataSource = new List<SystemPostWrapper>();
                e.Total = 0;
                storeSystemPost.DataBind();

                return;
            }

            SystemOrganizationWrapper organization = SystemOrganizationWrapper.FindById(selectOrgID);

            if (organization == null)
            {
                storeSystemPost.DataSource = new List<SystemPostWrapper>();
                e.Total = 0;
                storeSystemPost.DataBind();

                return;
            }

            PageQueryParams pageQueryParams = new PageQueryParams();
            pageQueryParams.PageSize = limit;
            pageQueryParams.PageIndex = pageIndex;

            storeSystemPost.DataSource = SystemPostWrapper.FindAllByOrderByAndFilterAndOrganizationID(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), organization, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSystemPost.DataBind();

        }

        [DirectMethod]
        public string GetTreeNodes()
        {
            List<TypedTreeNodeItem<ITreeItemWrapper>> nodes = (new SystemOrganizationWrapper()).GetAllTreeItems();

            return WebUIHelper.BuildTree<ITreeItemWrapper>(nodes, "All Organizations", Icon.Bricks).ToJson();
        }


        [DirectMethod]
        public void DeleteData(int id)
        {
            try
            {
                SystemOrganizationWrapper.DeleteByID(id);

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