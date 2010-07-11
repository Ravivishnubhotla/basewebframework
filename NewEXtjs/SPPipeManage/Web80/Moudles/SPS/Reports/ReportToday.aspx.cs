using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class ReportToday : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Ext.IsAjaxRequest)
                return;

            bindData();
        }

        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            bindData();
        }


        protected void bindData()
        {
            DataTable dt = SPDayReportWrapper.GetAllTodayReport();
            Store1.DataSource = dt;
            Store1.DataBind();
        }
    }
}
