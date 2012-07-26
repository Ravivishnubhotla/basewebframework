using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;

namespace SNFramework.BSF.Moudles.SystemManage.LogManage
{
    public partial class SystemLogListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;



            this.gridPanelSystemLog.Reload();
        }


        [DirectMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SystemLogWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(this.GetGlobalResourceObject("GlobalResource", "msgServerErrorMsg").ToString(), ex.Message);
                return;
            }
        }

        protected void storeSystemLog_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            PageQueryParams pageQueryParams = WebUIHelper.GetPageQueryParamFromStoreRefreshDataEventArgs(e, this.PagingToolBar1);

            RecordSortor recordSortor = WebUIHelper.GetRecordSortorFromStoreRefreshDataEventArgs(e);

            storeSystemLog.DataSource = SystemLogWrapper.FindAllByOrderBy(recordSortor.OrderByColumnName, recordSortor.IsDesc, pageQueryParams);
            e.Total = pageQueryParams.RecordCount;

            storeSystemLog.DataBind();

        }
    }
}