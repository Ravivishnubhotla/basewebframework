 

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Reports
{
 
    public partial class SPAdReportListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;



            this.gridPanelSPAdReport.Reload();
        }


        [DirectMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPAdReportWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPAdReport_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e, this.PagingToolBar1);

            RecordSortor recordSortor = WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e);

            storeSPAdReport.DataSource = SPAdReportWrapper.FindAllByOrderBy(recordSortor.OrderByColumnName, recordSortor.IsDesc, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSPAdReport.DataBind();

        }
    }



}

			
