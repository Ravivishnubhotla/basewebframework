using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public partial class ReportSearchList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPChannel.DataSource = SPChannelWrapper.FindAll();

            this.storeSPChannel.DataBind();
        }


        protected void storeData_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
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


            //PageQueryParams pageQueryParams = new PageQueryParams();
            //pageQueryParams.PageSize = limit;
            //pageQueryParams.PageIndex = pageIndex;

            storeData.DataSource = new List<SPRecordWrapper>();
            storeData.DataBind();

        }

        protected void storeSPClient_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPClient.DataSource = SPSClientWrapper.FindAll();

            this.storeSPClient.DataBind();
        }
    }
}