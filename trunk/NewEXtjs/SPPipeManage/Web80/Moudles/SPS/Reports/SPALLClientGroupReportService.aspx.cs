using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LD.SPPipeManage.Bussiness.Wrappers;
using Microsoft.Reporting.WebForms;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class SPALLClientGroupReportService : System.Web.UI.Page
    {
        public DateTime StartDate
        {
            get
            {
                if (this.Request.QueryString["StartDate"] == null)
                    return DateTime.Now;
                return Convert.ToDateTime(this.Request.QueryString["StartDate"]);
            }
        }

        public DateTime EndDate
        {
            get
            {
                if (this.Request.QueryString["EndDate"] == null)
                    return DateTime.Now;
                return Convert.ToDateTime(this.Request.QueryString["EndDate"]);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;

            ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("SPSALLClientGroupAmount.rdl");
            BindData();
        }

        private void BindData()
        {
            DataTable tb = SPDayReportWrapper.GetALlClientGroupPriceReport(StartDate.Date, EndDate.Date);


            ReportDataSource rds = new ReportDataSource("DataSet2", tb);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
 

            ReportParameter rpStartDate = new ReportParameter();
            rpStartDate.Name = "StartDate";
            rpStartDate.Values.Add(StartDate.ToShortDateString());

            ReportParameter rpEndDate = new ReportParameter();
            rpEndDate.Name = "EndDate";
            rpEndDate.Values.Add(EndDate.ToShortDateString());


            ReportViewer1.LocalReport.SetParameters(
             new ReportParameter[] {  rpStartDate, rpEndDate });



            ReportViewer1.LocalReport.Refresh();
        }


        protected void ReportViewer1_ReportRefresh(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BindData();
        }
    }
}