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



        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            SPClientWrapper spClientWrapper = SPClientWrapper.FindById(this.SPClientID);


            
            this.dfReportStartDate.DateField.Value = System.DateTime.Now.Date;

            this.dfReportStartDate.DateField.MinDate = spClientWrapper.GetDT();

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


            SPClientWrapper spClientWrapper = SPClientWrapper.FindById(this.SPClientID);

            if (startDate < spClientWrapper.GetDT())
            {
                startDate = spClientWrapper.GetDT();
            }

            string province = "";

            if(this.cmbProvince.SelectedItem !=null)
            {
                province = this.cmbProvince.SelectedItem.Value;
            }

            string city = "";

            if (!string.IsNullOrEmpty(this.txtCity.Text.Trim()))
            {
                city = this.txtCity.Text.Trim();
            }

            string phone = "";

            if (!string.IsNullOrEmpty(this.txtMoblie.Text.Trim()))
            {
                phone = this.txtMoblie.Text.Trim();
            }

            List<SPPaymentInfoWrapper> list = SPPaymentInfoWrapper.FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept(ChannelID, this.SPClientID, startDate, Convert.ToDateTime(this.dfReportEndDate.DateField.Value), province, city, phone, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);

            store1.DataSource = list;
            e.TotalCount = recordCount;

            store1.DataBind();
           

        }
    }
}
