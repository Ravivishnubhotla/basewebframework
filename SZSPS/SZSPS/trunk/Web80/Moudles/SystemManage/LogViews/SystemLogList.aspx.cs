using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SystemManage.LogViews
{
    public partial class SystemLogList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
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

 

            List<QueryFilter> filters = new List<QueryFilter>();

            filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_LOGTYPE, LogType, FilterFunction.EqualTo));
            filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_LOGRELATEMOUDLEDATAID, ParentID, FilterFunction.EqualTo));

            if (!string.IsNullOrEmpty(ParentType))
                filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_LOGRELATEMOUDLEID, ParentType, FilterFunction.EqualTo));


            if (dfStart.SelectedValue != null)
                filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_LOGDATE, Convert.ToDateTime(dfStart.SelectedDate).ToString("yyyy-MM-dd"), FilterFunction.GreaterThanOrEqualTo));
            if (dfEnd.SelectedValue != null)
                filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_LOGDATE, Convert.ToDateTime(dfEnd.SelectedDate).AddDays(1).ToString("yyyy-MM-dd"), FilterFunction.LessThanOrEqualTo));

            int recordCount = 0;

            storeSystemLog.DataSource = SystemLogWrapper.FindAllByOrderByAndFilter(filters, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);
            e.TotalCount = recordCount;

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