﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Channels
{
    public partial class SPChannelParamsListPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;



            this.gridPanelSPChannelParams.Reload();
        }


        [DirectMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPChannelParamsWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPChannelParams_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            storeSPChannelParams.DataSource = SPChannelParamsWrapper.FindAllByOrderByAndFilterAndChannelID(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), ChannelID, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSPChannelParams.DataBind();

        }


        public SPChannelWrapper ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannelID"] != null)
                {
                    return
                        SPChannelWrapper.FindById(int.Parse(this.Request.QueryString["ChannelID"]));
                }
                return null;
            }
        }
    }
}