using System;
using System.Collections.Generic;
using System.Data;
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

            //dfStart.Value = System.DateTime.Now.AddDays(-2);

            dfEnd.MaxDate = System.DateTime.Now.AddDays(-1);

            dfEnd.Value = System.DateTime.Now.AddDays(-1);

            DateField1.MaxDate = System.DateTime.Now.AddDays(-1);

            DateField2.Value = System.DateTime.Now.AddDays(-1);


            //string dbsizestring = SPDayReportWrapper.GetDbSizeString();

            //decimal space = SPDayReportWrapper.GetDbSize();

            //decimal total = 500.00m;

            //prgData.Text = string.Format("占用数据库空间{0},空间使用率{1}%", dbsizestring, (space / total * 100m).ToString("N2"));

            //prgData.UpdateProgress(float.Parse((space / total).ToString()));
        }


        protected void StartLongAction(object sender, AjaxEventArgs e)
        {
            Server.ScriptTimeout = 300;
            try
            {
                SPDayReportWrapper.ArchivesData(this.Server.MapPath("~/DayReport/"), Convert.ToDateTime(this.dfStart.Value), Convert.ToDateTime(this.dfEnd.Value));

                //string dbsizestring = SPDayReportWrapper.GetDbSizeString();

                //decimal space = SPDayReportWrapper.GetDbSize();

                //decimal total = 500.00m;

                //prgData.Text = string.Format("占用数据库空间{0},空间使用率{1}%", dbsizestring, (space / total * 100m).ToString("N2"));

                //prgData.UpdateProgress(float.Parse((space / total).ToString()));
                
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        protected void StartLongAction2(object sender, AjaxEventArgs e)
        {
            Server.ScriptTimeout = 3000;

            try
            {
                int channelID = Convert.ToInt32(cmbChannelID.SelectedItem.Value);

                int clientID = Convert.ToInt32(cmbClientID.SelectedItem.Value);

                List<SPPaymentInfoWrapper> paymentInfos = SPPaymentInfoWrapper.FindAllNotSendData(channelID, clientID, Convert.ToDateTime(this.DateField1.Value), Convert.ToDateTime(this.DateField2.Value));

                foreach (SPPaymentInfoWrapper spPaymentInfoWrapper in paymentInfos)
                {
                    spPaymentInfoWrapper.ReSend();
                }

                //Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                //Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + paymentInfos.Count.ToString();
                //return;


                Coolite.Ext.Web.ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                Coolite.Ext.Web.ScriptManager.AjaxSuccess = false;
                Coolite.Ext.Web.ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }


 



    }
}
