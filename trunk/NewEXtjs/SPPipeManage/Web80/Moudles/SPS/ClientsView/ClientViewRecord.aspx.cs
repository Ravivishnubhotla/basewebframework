using System;
using System.Collections;
using System.Collections.Generic;
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
    public partial class ClientViewRecord : SPSClientViewPage
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
            
            this.dfReportStartDate.DateField.Value = System.DateTime.Now.Date;

            this.dfReportStartDate.DateField.MinDate = GetDT();

            this.dfReportEndDate.DateField.Value = System.DateTime.Now.Date;

            this.hidId.Text = this.SPClientID.ToString();



            this.gridPanelSPClientChannelSetting.Reload();
        }

        public int ChannelID
        {
            get
            {
                int channelID = 0;

                return channelID;
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

            DateTime startDate = Convert.ToDateTime(this.dfReportStartDate.DateField.Value);

            if(startDate<GetDT())
            {
                startDate = GetDT();
            }

            string province = "";

            if(this.cmbProvince.SelectedItem !=null)
            {
                province = this.cmbProvince.SelectedItem.Value;
            }


            List<SPPaymentInfoWrapper> list = SPPaymentInfoWrapper.FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept(ChannelID, this.SPClientID, startDate, Convert.ToDateTime(this.dfReportEndDate.DateField.Value), province, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);

            if (list.Count > 0)
            {
                foreach (SPPaymentInfoWrapper spPaymentInfoWrapper in list)
                {
                    spPaymentInfoWrapper.Values = JsonConvert.SerializeObject(
                        spPaymentInfoWrapper.GetValues(
                            JsonConvert.DeserializeObject<Hashtable>(spPaymentInfoWrapper.RequestContent)));
                }
            }

            store1.DataSource = list;
            e.TotalCount = recordCount;

            store1.DataBind();
           

        }
    }
}
