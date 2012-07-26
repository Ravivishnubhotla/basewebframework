using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace SNFramework.BSF.Moudles.SystemManage.LogManage
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
            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e, this.PagingToolBar1);

            RecordSortor recordSortor = WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e);

            List<QueryFilter> filters = new List<QueryFilter>();

            filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_LOGTYPE, LogType, FilterFunction.EqualTo));
            filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_PARENTDATAID, ParentID, FilterFunction.EqualTo));

            if (!string.IsNullOrEmpty(ParentType))
                filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_PARENTDATATYPE, ParentType, FilterFunction.EqualTo));


            if (dfStart.SelectedValue != null)
                filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_LOGDATE, Convert.ToDateTime(dfStart.SelectedDate).ToString("yyyy-MM-dd"), FilterFunction.GreaterThanOrEqualTo));
            if (dfEnd.SelectedValue != null)
                filters.Add(new QueryFilter(SystemLogWrapper.PROPERTY_NAME_LOGDATE, Convert.ToDateTime(dfEnd.SelectedDate).AddDays(1).ToString("yyyy-MM-dd"), FilterFunction.LessThanOrEqualTo));

            storeSystemLog.DataSource = SystemLogWrapper.FindAllByOrderByAndFilter(filters, recordSortor.OrderByColumnName, recordSortor.IsDesc, pageQueryParams);
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