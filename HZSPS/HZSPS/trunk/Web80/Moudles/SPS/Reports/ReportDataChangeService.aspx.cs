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
    public partial class ReportDataChangeService : System.Web.UI.Page
    {
        public int ReportClientChannleID
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
            DataTable tb = SPDayReportWrapper.GetReportDataChange(ReportClientChannleID, StartDate, EndDate);

            


            ReportDataSource rds = new ReportDataSource("DayReport", tb);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(rds);


            SPClientChannelSettingWrapper channelSettingWrapper = SPClientChannelSettingWrapper.FindById(ReportClientChannleID);


            ReportParameter rpClientChannleID = new ReportParameter();
            rpClientChannleID.Name = "ReportClientChannleID";
            rpClientChannleID.Values.Add(ReportClientChannleID.ToString());

            ReportParameter rpStartDate = new ReportParameter();
            rpStartDate.Name = "StartDate";
            rpStartDate.Values.Add(StartDate.ToShortDateString());

            ReportParameter rpEndDate = new ReportParameter();
            rpEndDate.Name = "EndDate";
            rpEndDate.Values.Add(EndDate.ToShortDateString());

            ReportParameter rpChannelName = new ReportParameter();
            rpChannelName.Name = "ReportChannelName";
            rpChannelName.Values.Add(channelSettingWrapper.ChannelName);

            ReportParameter rpCodeName = new ReportParameter();
            rpCodeName.Name = "ReportCodeName";
            rpCodeName.Values.Add(string.Format("下家[{0} 指令 [{1}]", channelSettingWrapper.ClientName, channelSettingWrapper.ChannelClientCode));


            ReportViewer1.LocalReport.SetParameters(
             new ReportParameter[] { rpClientChannleID, rpStartDate, rpEndDate, rpChannelName, rpCodeName });


            ReportViewer1.LocalReport.Refresh();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;

            ReportViewer1.LocalReport.ReportPath = this.Server.MapPath("ReportDataChange.rdl");
            BindData();
        }

        protected void ReportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            BindData();
        }
    }
}