using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using SPS.Bussiness.Wrappers;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Web;

namespace Legendigital.Common.WebApp.Moudles.SPS.Clients
{
    public partial class SPClientCodeRelationListPage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;



            this.gridPanelSPClientCodeRelation.Reload();
        }

 

        protected void storeSPClientCodeRelation_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
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


            PageQueryParams pageQueryParams = new PageQueryParams();
            pageQueryParams.PageSize = limit;
            pageQueryParams.PageIndex = pageIndex;

            storeSPClientCodeRelation.DataSource = SPClientCodeRelationWrapper.FindAllByOrderByAndFilterAndClientID(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), SPSClientID, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSPClientCodeRelation.DataBind();

        }


        public SPSClientWrapper SPSClientID
        {
            get
            {
                if (this.Request.QueryString["SPSClientID"] != null)
                {
                    return
                        SPSClientWrapper.FindById(int.Parse(this.Request.QueryString["SPSClientID"]));
                }
                return null;
            }
        }
    }




}