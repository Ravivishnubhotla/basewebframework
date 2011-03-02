using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ScriptManager = Coolite.Ext.Web.ScriptManager;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class ReportDayTotal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Ext.IsAjaxRequest)
            {
                dfReportDate.DateField.Value = System.DateTime.Now.AddDays(-1);
                dfReportDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);
                BindData();
            }
        }


        [AjaxMethod]
        public void ChangeInterceptCount(string dateTime, int clientID, string newIntercept)
        {
            try
            {
                SPClientWrapper clientWrapper = SPClientWrapper.FindById(clientID);

                int newInterceptCount = Convert.ToInt32(newIntercept);

                DateTime date = Convert.ToDateTime(dateTime);

                DayliyReport dayReport = clientWrapper.GetDayReport(date);

                if (newInterceptCount < 0)
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "扣量不得小于0";
                    return;
                }

                if (newInterceptCount > dayReport.TotalCount)
                {
                    ScriptManager.AjaxSuccess = false;
                    ScriptManager.AjaxErrorMessage = "扣量不得大于当日总量：" + dayReport.TotalCount.ToString();
                    return;
                }


                //ScriptManager.AjaxSuccess = false;
                //ScriptManager.AjaxErrorMessage = string.Format("日期{0} 总量：{1} 点播 {2} 扣量 {3} 同步 {4}", dateTime, dayReport.TotalCount, dayReport.DownCount, dayReport.InterceptCount, dayReport.SycnCount);
                //return;

 

                SPPaymentInfoWrapper.UpdateRecordAndReport(dayReport, clientWrapper, newInterceptCount);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }


        protected void Store1_RefreshData(object sender, StoreRefreshDataEventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            //DataTable dt = SPDayReportWrapper.GetDayliyReport(Convert.ToDateTime(dfReportDate.DateField.Value));

            DataTable dt = SPDayReportWrapper.GetDayCountReportForMaster((DateTime)dfReportDate.DateField.Value, (DateTime)dfReportDate.DateField.Value);

            if (dt.Columns["SPClientGroupName"] == null)
            {
                dt.Columns.Add("SPClientGroupName");
            }

            foreach (DataRow dataRow in dt.Rows)
            {
                if (dataRow["ClientID"] == System.DBNull.Value || dataRow["ClientID"].Equals(0))
                {
                    dataRow["SPClientGroupName"] = "";
                }
                else
                {
                    SPClientWrapper clientWrapper = SPClientWrapper.FindById((int)dataRow["ClientID"]);

                    if (clientWrapper != null)
                    {
                        dataRow["SPClientGroupName"] = clientWrapper.ClientGroupName;
                    }
                    else
                    {
                        dataRow["SPClientGroupName"] = "";
                    }
                }
            }


            this.Store1.DataSource = dt;
            this.Store1.DataBind();


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
    }
}
