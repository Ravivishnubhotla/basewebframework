using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.ConfigManage
{

    public partial class SystemConfigListPage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            this.gridPanelSystemConfig.Reload();
        }

        [DirectMethod]
        public void DeleteGroupRecord(int id)
        {
            try
            {
                SystemConfigGroupWrapper.DeleteByID(id);

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
        public void DeleteRecord(int id)
        {

            if (!this.CurrentLoginUserIsDevelopeAdmin())
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = " only developer admin can delete config.";
                return;
            }


            try
            {
                SystemConfigWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSystemConfigGroup_Refresh(object sender, StoreRefreshDataEventArgs e)
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


            PageQueryParams pageQueryParams = new PageQueryParams();
            pageQueryParams.PageSize = limit;
            pageQueryParams.PageIndex = pageIndex;

            storeSystemConfigGroup.DataSource = SystemConfigGroupWrapper.FindAllByOrderBy(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSystemConfigGroup.DataBind();

        }

        protected void storeSystemConfig_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            if (sortFieldName == "GroupName")
                sortFieldName = "ConfigGroupID_SystemConfigEntity_Alias.Name";


            storeSystemConfig.DataSource = SystemConfigWrapper.FindAllByOrderBy(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), pageQueryParams);
            e.Total = recordCount;

            storeSystemConfig.DataBind();

        }
    }

}
