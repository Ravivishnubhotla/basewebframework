using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ReportDayRange : SPClientGroupViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.IsAjaxRequest)
            {
                dfReportStartDate.DateField.Value = System.DateTime.Now.AddDays(-3);
                dfReportStartDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);
                dfReportEndDate.DateField.Value = System.DateTime.Now.AddDays(-1);
                dfReportEndDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);

                BindData();
            }
        }

        private void BindData()
        {
            List<SPDayReportWrapper> dayReports = SPDayReportWrapper.GetAllClientGroupDayReport((DateTime)dfReportStartDate.DateField.Value, (DateTime)dfReportEndDate.DateField.Value, this.ClientGroupID);

            this.Store1.DataSource = dayReports;
            this.Store1.DataBind();

        }





        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            BindData();
        }
    }
}