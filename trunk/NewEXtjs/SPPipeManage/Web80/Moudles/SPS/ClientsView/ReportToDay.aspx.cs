using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ReportToDay : SPClientGroupViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.IsAjaxRequest)
            {
 

                BindData();
            }
        }

        private void BindData()
        {
            List<SPDayReportWrapper> dayReports = SPDayReportWrapper.GetAllClientGroupDayReport(DateTime.Now.Date, DateTime.Now.Date, this.ClientGroupID);

            this.Store1.DataSource = dayReports;
            this.Store1.DataBind();

        }





        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            BindData();
        }
    }
}