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

namespace SPSWeb.Moudles.SPS.Channels
{
    public partial class SPChannelListPage : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            this.gridPanelSPChannel.Reload();
        }


        [DirectMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPChannelWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            string sortFieldName = "";
            if (e.Sort != null)
                sortFieldName = e.Sort;

            if (sortFieldName == "ChannelTypeName")
                sortFieldName = "ChannelType";

            bool isDesc = (e.Dir == Ext.Net.SortDirection.DESC);

            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e, this.PagingToolBar1.PageSize);

            if (string.IsNullOrEmpty(sortFieldName))
            {
                sortFieldName = "Id";
                isDesc = true;
            }

            storeSPChannel.DataSource = SPChannelWrapper.FindAllByOrderBy(sortFieldName,isDesc, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSPChannel.DataBind();

        }
    }
}