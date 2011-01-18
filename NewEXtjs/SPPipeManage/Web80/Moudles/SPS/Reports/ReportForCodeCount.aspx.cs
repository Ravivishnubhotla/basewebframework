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
    public partial class ReportForCodeCount : System.Web.UI.Page
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
            int channleID = 0;

 

            DataTable dt = SPDayReportWrapper.GetDayCountReportForMaster((DateTime)dfReportStartDate.DateField.Value, (DateTime)dfReportEndDate.DateField.Value);

            this.Store1.DataSource = dt;
            this.Store1.DataBind();
 
        }


 


        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            BindData();
        }
    }
}