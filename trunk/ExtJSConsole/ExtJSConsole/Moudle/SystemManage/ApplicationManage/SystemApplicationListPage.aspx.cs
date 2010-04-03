using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;

namespace ExtJSConsole.Moudle.SystemManage.ApplicationManage
{
    public partial class SystemApplicationListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

           

            this.GridPanel1.Reload();
        }


        [DirectMethod()]
        public void DeleteRecord(int id)
        {
            try
            {
                //throw new Exception("11111");
                SystemApplicationWrapper.DeleteByID(id);

                ResourceManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSystemApplication_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int recordCount = 0;
            string sortFieldName = "";
            if (e.Sort != null)
                sortFieldName = e.Sort;

            int startIndex = 0;

            if(e.Start > -1)
            {
                startIndex = e.Start;
            }

            int limit = this.PagingToolBar1.PageSize;

            if (e.Limit>-1)
            {
                limit = e.Limit;
            }

            storeSystemApplication.DataSource = SystemApplicationWrapper.SelectMethod(startIndex, limit, sortFieldName, (e.Dir == Ext.Net.SortDirection.DESC), out recordCount);
            e.Total= recordCount;

            storeSystemApplication.DataBind();

        }
    }
}
