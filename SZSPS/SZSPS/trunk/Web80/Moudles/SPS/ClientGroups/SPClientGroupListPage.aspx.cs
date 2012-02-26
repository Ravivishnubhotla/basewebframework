using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;


namespace Legendigital.Common.Web.Moudles.SPS.ClientGroups
{
    public partial class SPClientGroupListPage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.gridPanelSPClientGroup.Reload();
        }


        [AjaxMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPClientGroupWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }


        [AjaxMethod]
        public void LockLoginUser(int id, bool isLock)
        {
            try
            {
                SPClientWrapper clientWrapper = SPClientWrapper.FindById(id);

                SystemUserWrapper user = SystemUserWrapper.FindById(clientWrapper.UserID);

                if (user != null)
                {
                    user.IsLockedOut = !user.IsLockedOut;
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

        protected void storeSPClientGroup_Refresh(object sender, StoreRefreshDataEventArgs e)
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


            List<QueryFilter> queryFilters = new List<QueryFilter>();

            string clientName = "";

            if (!string.IsNullOrEmpty(this.txtSreachName.Text.Trim()))
            {
                clientName = this.txtSreachName.Text.Trim();

                queryFilters.Add(new QueryFilter(SPClientGroupWrapper.PROPERTY_NAME_NAME, clientName, FilterFunction.Contains));
            }

            storeSPClientGroup.DataSource = SPClientGroupWrapper.FindAllByOrderByAndFilter(queryFilters,sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, out recordCount);
            e.TotalCount = recordCount;

            storeSPClientGroup.DataBind();

        }
    }

}