using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using ScriptManager=Coolite.Ext.Web.ScriptManager;

namespace ExtJSConsole.Moudle.SystemManage.ApplicationManage
{
    public partial class SystemApplicationListPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

           

            this.GridPanel1.Reload();
        }


        [AjaxMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                //throw new Exception("11111");
                SystemApplicationWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;

                //Ext.Msg.Alert("操作成功", "成功删除系统应用", new JFunction { Fn = "RefreshData" }).Show();
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
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

            storeSystemApplication.DataSource = SystemApplicationWrapper.SelectMethod(startIndex, limit, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), out recordCount);
            e.TotalCount = recordCount;

            storeSystemApplication.DataBind();

        }
    }
}
