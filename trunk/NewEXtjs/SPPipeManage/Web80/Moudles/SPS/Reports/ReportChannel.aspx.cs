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
    public partial class ReportChannel : System.Web.UI.Page
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

            if (this.cmbChannelID.SelectedItem!=null)
            {
                if (!string.IsNullOrEmpty(this.cmbChannelID.SelectedItem.Value))
                    channleID = int.Parse(this.cmbChannelID.SelectedItem.Value);
                else
                    channleID = 0;
            }

            DataTable dt = SPDayReportWrapper.GetCountReportForMaster(channleID, (DateTime)dfReportStartDate.DateField.Value, (DateTime)dfReportEndDate.DateField.Value);

            this.Store1.DataSource = dt;
            this.Store1.DataBind();
            this.txtTotalCount.Text = string.Format("总点播数(条)：{0}", GetSumField(dt, "TotalCount"));
            this.txtInterceptCount.Text = string.Format("总扣量数(条)：{0}", GetSumField(dt, "InterceptCount"));
            this.txtDownCount.Text = string.Format("总转发下家数(条)：{0}", GetSumField(dt, "DownCount"));
            this.txtDownSycnCount.Text = string.Format("总同步下家数(条)：{0}", GetSumField(dt, "DownSycnCount"));
        }


        private int GetSumField(DataTable dt, string field)
        {
            object result = dt.Compute("SUM(" + field + ")", "");

            if (result == System.DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }


        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            BindData();
        }
    }
}
