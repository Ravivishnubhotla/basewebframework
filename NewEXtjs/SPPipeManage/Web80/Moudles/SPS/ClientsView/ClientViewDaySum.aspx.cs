using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientViewDaySum : SPSClientViewPage
    {

        protected DateTime GetDT()
        {
            switch (System.DateTime.Now.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return System.DateTime.Now.AddDays(-7);
                    break;
                case DayOfWeek.Tuesday:
                    return System.DateTime.Now.AddDays(-8);
                    break;
                case DayOfWeek.Wednesday:
                    return System.DateTime.Now.AddDays(-9);
                    break;
                case DayOfWeek.Thursday:
                    return System.DateTime.Now.AddDays(-10);
                    break;
                case DayOfWeek.Friday:
                    return System.DateTime.Now.AddDays(-11);
                    break;
                case DayOfWeek.Saturday:
                    return System.DateTime.Now.AddDays(-12);
                    break;
                case DayOfWeek.Sunday:
                    return System.DateTime.Now.AddDays(-13);
                    break;

            }

            return DateTime.Now;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.dfReportStartDate.DateField.Value = System.DateTime.Now.AddDays(-7).Date;

            this.dfReportStartDate.DateField.MinDate = GetDT();

            this.dfReportStartDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1).Date;

            this.dfReportStartDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1).Date;

            this.dfReportEndDate.DateField.Value = System.DateTime.Now.AddDays(-1).Date;

            this.dfReportEndDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1).Date;

            this.hidId.Text = this.ClientID.ToString();

            this.storeSPChannel.BaseParams.Add(new Coolite.Ext.Web.Parameter("ClinetID", this.ClientID.ToString()));

            this.gridPanelSPClientChannelSetting.Reload();
        }



        protected void store1_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            //int recordCount = 0;
            //string sortFieldName = "";
            //if (e.Sort != null)
            //    sortFieldName = e.Sort;

            //int startIndex = 0;

            //if (e.Start > -1)
            //{
            //    startIndex = e.Start;
            //}

            //int limit = this.PagingToolBar1.PageSize;

            //int pageIndex = 1;

            //if ((startIndex % limit) == 0)
            //    pageIndex = startIndex / limit + 1;
            //else
            //    pageIndex = startIndex / limit;


            int channelID = 0;

            if (this.cmbChannelID.SelectedItem != null && !string.IsNullOrEmpty(this.cmbChannelID.SelectedItem.Value))
            {
                channelID = int.Parse(this.cmbChannelID.SelectedItem.Value);
            }


            DateTime startDate = Convert.ToDateTime(this.dfReportStartDate.DateField.Value);

            if (startDate < GetDT())
            {
                startDate = GetDT();
            }

            DataTable tb = SPDayReportWrapper.GetCountReport(channelID, this.ClientID, startDate, Convert.ToDateTime(this.dfReportEndDate.DateField.Value));

            store1.DataSource = tb;
            store1.DataBind();


        }
    }
}
