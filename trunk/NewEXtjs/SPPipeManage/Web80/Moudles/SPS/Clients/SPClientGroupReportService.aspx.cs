using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Data;
using System.Data.SqlClient;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    public partial class SPClientGroupReportService : System.Web.UI.Page
    {
        public int ClientGroupID
        {
            get
            {
                if (this.Request.QueryString["ClientGroupID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ClientGroupID"]);
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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;

            ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("Report2.rdl");
            BindData();
        }

        private void BindData()
        {
            DataTable tb = SPDayReportWrapper.GetClientGroupPriceReport(ClientGroupID, StartDate.Date, EndDate.Date);


            ReportDataSource rds = new ReportDataSource("DataSet1", tb);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);
            ReportViewer1.LocalReport.Refresh();
        }

        private DataSet GetData()
        { 
            DataSet ds = new DataSet();

            using (SqlDataAdapter dap = new SqlDataAdapter(@"SELECT ReportID, ReportDate, UpTotalCount, InterceptTotalCount, DownTotalCount, DownSuccess, ClientID, ChannelID, SPClientGroupID, Price, Amount, ClientName,ClientAliasName FROM vw_ClientGroupAmountReport", @"Initial Catalog=SPSManage;server=ATOM\SQLEXPRESS;uid=SPSManage;pwd=SPSManage;"))
            {
                dap.Fill(ds);
            }

            return ds;
        }

        protected void ReportViewer1_ReportRefresh(object sender, System.ComponentModel.CancelEventArgs e)
        {
            BindData();
        }
    }
}