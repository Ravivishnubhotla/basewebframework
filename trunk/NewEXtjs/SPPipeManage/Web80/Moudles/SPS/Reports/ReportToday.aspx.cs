﻿using System;
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
        public void ChangeInterceptCount(string dateTime,int clientID,string newIntercept)
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