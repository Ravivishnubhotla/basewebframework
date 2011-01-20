using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LD.SPPipeManage.Bussiness.Wrappers;
using Microsoft.Reporting.WebForms;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class SPClientClientCountReportService : System.Web.UI.Page
    {
        public int ChannleClientSettingID
        {
            get
            {
                if (this.Request.QueryString["ChannleClientSettingID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ChannleClientSettingID"]);
            }
        }

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

        private void BindData()
        {
            //DataTable tb = SPDayReportWrapper.GetDataCountReport(ChannleClientSettingID, StartDate.Date, EndDate.Date);


            //ReportDataSource rds = new ReportDataSource("DataSet1", tb);
            //ReportViewer1.LocalReport.DataSources.Clear();
            //ReportViewer1.LocalReport.DataSources.Add(rds);
            //ReportViewer1.LocalReport.Refresh();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;

            ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("Report2.rdl");
            BindData();
        }

        protected void ReportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindData();
        }
    }
}