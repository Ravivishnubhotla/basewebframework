using System;
using System.Collections.Generic;
using System.Linq;
 
 
 
using Coolite.Ext.Web;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;

namespace Legendigital.Common.Web.Moudles.SystemManage.UserManage
{
    public partial class SystemUserListPage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.gridPanelSystemUser.Reload();
        }
        [AjaxMethod]
        public void LockUser(int id)
        {
            try
            {
                SystemUserWrapper user = SystemUserWrapper.FindById(id);
                if (user != null)
                {
                    user.IsLockedOut = !user.IsLockedOut;
                    SystemUserWrapper.Update(user);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = "错误信息：" + ex.Message;
            }
        }

        [AjaxMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SystemUserWrapper user = SystemUserWrapper.FindById(id);

                if (user != null)
                {
                    user.IsApproved = false;
                    SystemUserWrapper.Update(user);
                }

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSystemUser_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            List<QueryFilter> filters = new List<QueryFilter>();

            filters.Add(new QueryFilter(SystemUserWrapper.PROPERTY_NAME_ISAPPROVED,"True",FilterFunction.EqualTo));
            filters.Add(new QueryFilter(SystemUserWrapper.PROPERTY_NAME_USERTYPE, "SPCOM", FilterFunction.EqualTo));

            storeSystemUser.DataSource = SystemUserWrapper.FindAllByOrderByAndFilter(filters,sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);
            e.TotalCount = recordCount;

            storeSystemUser.DataBind();

        }
    }
}