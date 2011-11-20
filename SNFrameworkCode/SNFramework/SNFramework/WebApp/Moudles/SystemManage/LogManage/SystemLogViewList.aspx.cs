using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace Legendigital.Common.WebApp.Moudles.SystemManage.LogManage
{
    public partial class SystemLogViewList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            this.gridPanelSystemLog.Reload();
        }

        protected void storeSystemLog_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            List<QueryFilter> filters = new List<QueryFilter>();

            filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_LOGTYPE, LogType, FilterFunction.EqualTo));
            filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_PARENTDATAID, ParentID, FilterFunction.EqualTo));
            filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_PARENTDATATYPE, ParentType, FilterFunction.EqualTo));

            storeSystemLog.DataSource = SystemLogWrapper.FindAllByOrderByAndFilter(filters, sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSystemLog.DataBind();

        }

        protected string LogType
        {
            get { return this.Request.QueryString["LogType"]; }
        }
        protected string ParentID
        {
            get { return this.Request.QueryString["ParentID"]; }
        }
        protected string ParentType
        {
            get { return this.Request.QueryString["ParentType"]; }
        }
    }
}