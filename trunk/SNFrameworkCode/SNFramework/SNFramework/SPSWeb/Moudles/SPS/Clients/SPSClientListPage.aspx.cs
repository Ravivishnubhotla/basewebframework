using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Clients
{
    public partial class SPSClientListPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;



            this.gridPanelSPSClient.Reload();
        }


        [DirectMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPSClientWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPSClient_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            string sortFieldName = "";

            if (e.Sort != null)
                sortFieldName = e.Sort;

            if (string.IsNullOrEmpty(sortFieldName))
            {
                sortFieldName = SPSClientWrapper.PROPERTY_NAME_ID;
            }


            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e, this.PagingToolBar1);

            storeSPSClient.DataSource = SPSClientWrapper.FindAllByOrderBy(sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSPSClient.DataBind();

        }
    }
}