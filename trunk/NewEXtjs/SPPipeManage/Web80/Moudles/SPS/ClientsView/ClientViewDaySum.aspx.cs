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
                case DayOfWeek.Tuesday:
                    return System.DateTime.Now.AddDays(-8);
                case DayOfWeek.Wednesday:
                    return System.DateTime.Now.AddDays(-9);
                case DayOfWeek.Thursday:
                    return System.DateTime.Now.AddDays(-10);
                case DayOfWeek.Friday:
                    return System.DateTime.Now.AddDays(-11);
                case DayOfWeek.Saturday:
                    return System.DateTime.Now.AddDays(-12);
                case DayOfWeek.Sunday:
                    return System.DateTime.Now.AddDays(-13);

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

            this.hidId.Text = this.SPClientID.ToString();

            this.hidChannelID.Text =
                SPClientWrapper.FindById(this.SPClientID).DefaultClientChannelSetting.ChannelID.Id.ToString();

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




            DateTime startDate = Convert.ToDateTime(this.dfReportStartDate.DateField.Value);

            if (startDate < GetDT())
            {
                startDate = GetDT();
            }

            DataTable tb = SPDayReportWrapper.GetCountReport(channelID, this.SPClientID, startDate.Date, Convert.ToDateTime(this.dfReportEndDate.DateField.Value).Date);

            store1.DataSource = tb;
            store1.DataBind();


        }
    }
}
