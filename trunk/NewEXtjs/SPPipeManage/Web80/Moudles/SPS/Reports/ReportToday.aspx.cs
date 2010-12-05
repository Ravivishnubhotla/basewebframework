using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Xsl;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using ScriptManager = Coolite.Ext.Web.ScriptManager;

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

        //,int channelID,int clinetID,int newintercept,int oldIntercept,int totalcont
        [AjaxMethod]
        public void ChangeInterceptCount(string dateTime)
        {
            try
            {

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }


        protected void bindData()
        {
            DataTable dt = SPDayReportWrapper.GetAllTodayReport(this.chkFilterNoCount.Checked);
            Store1.DataSource = dt;
            Store1.DataBind();

            this.txtTotalCount.Text = string.Format("总点播数(条)：{0}", GetSumField(dt, "TotalCount"));
            this.txtInterceptCount.Text = string.Format("总扣量数(条)：{0}", GetSumField(dt, "InterceptCount"));
            this.txtDownCount.Text = string.Format("总转发下家数(条)：{0}", GetSumField(dt, "DownCount"));
            this.txtDownSycnCount.Text = string.Format("总同步下家数(条)：{0}", GetSumField(dt, "DownSycnCount"));
        }

        private int GetSumField(DataTable dt,string field)
        {
            object result = dt.Compute("SUM(" + field + ")", "");

            if (result == System.DBNull.Value)
                return 0;

            return Convert.ToInt32(result);
        }
    }
}
