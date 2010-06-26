using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.DataArchives
{
    public partial class DataArchive : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            string dbsizestring = SPDayReportWrapper.GetDbSizeString();

            decimal space = SPDayReportWrapper.GetDbSize();

            decimal total = 100.00m;

            prgData.Text = string.Format("占用数据库空间{0},空间使用率{1}%", dbsizestring, (space / total * 100m).ToString("N2"));
        }


        protected void StartLongAction(object sender, AjaxEventArgs e)
        {
            Server.ScriptTimeout = 300;
            try
            {
                SPDayReportWrapper.ArchivesData(this.Server.MapPath("~/DayReport/"), Convert.ToDateTime(this.dfStart.Value), Convert.ToDateTime(this.dfEnd.Value));

                string dbsizestring = SPDayReportWrapper.GetDbSizeString();

                decimal space = SPDayReportWrapper.GetDbSize();

                decimal total = 100.00m;

                prgData.Text = string.Format("占用数据库空间{0},空间使用率{1}%", dbsizestring, (space / total * 100m).ToString("N2"));
                
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        //private void LongAction(object state)
        //{
        //    for (int i = 0; i < 10; i++)
        //    {
        //        Thread.Sleep(1000);
        //        this.Session["LongActionProgress"] = i + 1;
        //    }
        //    this.Session.Remove("LongActionProgress");
        //}

        //protected void RefreshProgress(object sender, AjaxEventArgs e)
        //{
        //    object progress = this.Session["LongActionProgress"];
        //    if (progress != null)
        //    {
        //        Progress1.UpdateProgress(((int)progress) / 10f, string.Format("Step {0} of {1}...", progress.ToString(), 10));
        //    }
        //    else
        //    {
        //        ScriptManager1.AddScript("{0}.stopTask('longactionprogress');", TaskManager1.ClientID);
        //        Progress1.UpdateProgress(1, "All finished!");
        //    }
        //}

    }
}
