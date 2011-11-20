using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.UserManage
{
    public partial class SystemUserListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            this.gridPanelSystemUser.Reload();
        }
        [DirectMethod]
        public void LockUser(int id)
        {
            try
            {
                SystemUserWrapper user = SystemUserWrapper.FindById(id);
                if (user != null)
                {
                    user.IsLockedOut = !user.IsLockedOut;
                    SystemUserWrapper.Update(user);
                }
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
            }
        }

        [DirectMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SystemUserWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSystemUser_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int recordCount = 0;
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

            PageQueryParams pageQueryParams = new PageQueryParams();
            pageQueryParams.PageSize = limit;
            pageQueryParams.PageIndex = pageIndex;

            List<QueryFilter> queryFilters = new List<QueryFilter>();

            queryFilters.Add(new QueryFilter(SystemUserWrapper.PROPERTY_NAME_USERLOGINID, SystemUserWrapper.DEV_USER_ID,FilterFunction.NotEqualTo));
            
            if(!string.IsNullOrEmpty(this.txtSearchName.Text.Trim()))
                queryFilters.Add(new QueryFilter(SystemUserWrapper.PROPERTY_NAME_USERLOGINID, this.txtSearchName.Text.Trim(), FilterFunction.Contains));




            storeSystemUser.DataSource = SystemUserWrapper.FindAllByOrderByAndFilter(queryFilters,sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), pageQueryParams);
            e.Total = recordCount;

            storeSystemUser.DataBind();

        }
    }

}
