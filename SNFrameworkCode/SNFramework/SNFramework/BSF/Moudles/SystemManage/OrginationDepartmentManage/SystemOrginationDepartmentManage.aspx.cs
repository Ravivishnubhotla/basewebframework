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


namespace SNFramework.BSF.Moudles.SystemManage.OrginationDepartmentManage
{
    public partial class SystemOrginationDepartmentManage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void storeSystemPost_Refresh(object sender, StoreRefreshDataEventArgs e)
        {

            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e, this.PagingToolBar1);

            RecordSortor recordSortor = WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e);


            int selectOrgID = 0;

            if (!string.IsNullOrEmpty(e.Parameters["SelectOrgID"]))
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

            storeSystemPost.DataSource = SystemPostWrapper.FindAllByOrderByAndFilterAndOrganizationID(recordSortor.OrderByColumnName, recordSortor.IsDesc, organization, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSystemPost.DataBind();

        }

        [DirectMethod]
        public string GetTreeNodes()
        {
            List<TypedTreeNodeItem<SystemOrganizationWrapper>> nodes = (new SystemOrganizationWrapper()).GetAllTreeItems();

            return WebUIHelper.BuildTree<SystemOrganizationWrapper>(nodes, "All Organizations", Icon.Bricks).ToJson();
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

        [DirectMethod]
        public void DeletePost(int id)
        {
            try
            {
                SystemPostWrapper.DeleteByID(id);

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