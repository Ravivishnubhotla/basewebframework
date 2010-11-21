using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientGroupViewRecord : SPClientGroupViewPage
    {
        protected DateTime GetDT()
        {
            switch (System.DateTime.Now.Date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                    return System.DateTime.Now.Date.AddDays(-7);
                case DayOfWeek.Tuesday:
                    return System.DateTime.Now.Date.AddDays(-8);
                case DayOfWeek.Wednesday:
                    return System.DateTime.Now.Date.AddDays(-9);
                case DayOfWeek.Thursday:
                    return System.DateTime.Now.Date.AddDays(-10);
                case DayOfWeek.Friday:
                    return System.DateTime.Now.Date.AddDays(-11);
                case DayOfWeek.Saturday:
                    return System.DateTime.Now.Date.AddDays(-12);
                case DayOfWeek.Sunday:
                    return System.DateTime.Now.Date.AddDays(-13);

            }

            return DateTime.Now.Date;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            int id = this.ClientGroupID;

            this.dfReportEndDate.DateField.Value = System.DateTime.Now.Date;

            this.dfReportStartDate.DateField.Value = System.DateTime.Now.Date.AddDays(-7);

            this.dfReportStartDate.DateField.MinDate = GetDT();

            storeSPClient.BaseParams.Add(new Parameter("ClientGroupID", id.ToString(), ParameterMode.Value));

            this.hidId.Text = id.ToString();
        }

        protected void storeSPClient_OnRefresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPClientGroupWrapper clientGroup = SPClientGroupWrapper.FindById(this.ClientGroupID);

            storeSPClient.DataSource = SPClientWrapper.FindAllBySPClientGroupID(clientGroup);
            storeSPClient.DataBind();
        }


        public int SPClientID
        {
            get
            {
                if (this.cmbClientID.SelectedItem == null)
                    return 0;
                if (this.cmbClientID.SelectedItem.Value == "")
                    return 0;
                return Convert.ToInt32(this.cmbClientID.SelectedItem.Value);
            }
        }

        public int SPClientGroupID
        {
            get
            {
                if (this.hidId.Text=="")
                {
                    this.hidId.Text = this.ClientGroupID.ToString();
                }
                return Convert.ToInt32(this.hidId.Text);
            }
        }


        private Column NewColumn(string id, string header, string dataIndex, string renderHandler)
        {
            Column col1 = new Column();
            col1.ColumnID = id;
            col1.Header = header;
            col1.Sortable = false;
            col1.DataIndex = dataIndex;
            if (!string.IsNullOrEmpty(renderHandler))
            {
                if (col1.Renderer == null)
                    col1.Renderer = new Renderer();
                col1.Renderer.Handler = renderHandler;
            }
            return col1;
        }

        public int ChannelID
        {
            get
            {
                int channelID = 0;

                return channelID;
            }
        }


        protected void store1_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int recordCount = 0;
            string sortFieldName = "";
            if (e.Sort != null)
                sortFieldName = e.Sort;

            int startIndex = 0;

            if (e.Start > -1)
            {
                startIndex = e.Start;
            }

            int limit = this.PagingToolBar1.PageSize;

            int pageIndex = 1;

            if ((startIndex % limit) == 0)
                pageIndex = startIndex / limit + 1;
            else
                pageIndex = startIndex / limit;


            List<SPPaymentInfoWrapper> list = null;

            DateTime startDate = Convert.ToDateTime(this.dfReportStartDate.DateField.Value);

            if (startDate < GetDT())
            {
                startDate = GetDT();
            }

            string province = "";

            if (this.cmbProvince.SelectedItem != null)
            {
                province = this.cmbProvince.SelectedItem.Value;
            }

            if (SPClientID > 0)
            {
                list = SPPaymentInfoWrapper.FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept(ChannelID,SPClientID, startDate, Convert.ToDateTime(this.dfReportEndDate.DateField.Value), province, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);
            }
            else
            {
                list = SPPaymentInfoWrapper.FindAllByOrderByAndSPClientGroupIDAndDateAndProviceNoIntercept(SPClientGroupID, startDate, Convert.ToDateTime(this.dfReportEndDate.DateField.Value), province, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);
            }
                   
            store1.DataSource = list;
            e.TotalCount = recordCount;

            store1.DataBind();


        }
    }
}