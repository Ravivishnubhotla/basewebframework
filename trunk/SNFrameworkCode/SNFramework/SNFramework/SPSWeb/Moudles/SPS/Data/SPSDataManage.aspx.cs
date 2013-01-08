using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Data
{
    public partial class SPSDataManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;
            this.dfStart.MaxDate = System.DateTime.Now.AddDays(-1).Date;
            this.dfEnd.MaxDate = System.DateTime.Now.AddDays(-1).Date;
        }


        protected void btnGeneReportl_Click(object sender, DirectEventArgs e)
        {
            try
            {
                Server.ScriptTimeout = 300;
                try
                {
                    //SPDayReportWrapper.ArchivesData(this.Server.MapPath("~/DayReport/"), );

                    SPDayReportWrapper.ReGenerateDayReport(Convert.ToDateTime(this.dfStart.Value), Convert.ToDateTime(this.dfEnd.Value));

                    ResourceManager.AjaxSuccess = true;
                }
                catch (Exception ex)
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = "错误信息：" + ex.Message;
                }
                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "Error Message:" + ex.Message;
                return;
            }

        }
    }
}