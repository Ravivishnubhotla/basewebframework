using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Common.Web.AppClass;


namespace Legendigital.Common.Web.Moudles.SPS.ClientsView
{
    public partial class ClientParamsDocumentView : SPSClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.gridPanelSPSendClientParams.Reload();
        }

        protected void storeSPSendClientParams_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            storeSPSendClientParams.DataSource = SPSendClientParamsWrapper.FindAllByOrderByAndClientID(sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, this.ClientID, out recordCount);
            e.TotalCount = recordCount;

            storeSPSendClientParams.DataBind();

        }
    }
}
