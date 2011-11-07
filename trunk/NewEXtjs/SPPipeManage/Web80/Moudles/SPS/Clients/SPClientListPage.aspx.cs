using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;

namespace Legendigital.Common.Web.Moudles.SPS.Clients
{
    public partial class SPClientListPage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.gridPanelSPClient.Reload();

            this.btnAddToClientGroup.Hidden = (ClientGroupID <= 0);

            if (ClientGroupID > 0)
            {
                this.winSPClientAddToGroup.Title = "添加下家到下家组'" + SPClientGroupWrapper.FindById(ClientGroupID).Name + "'";

                this.winSPClientAddToGroup.AutoLoad.Params.Clear();

                this.winSPClientAddToGroup.AutoLoad.Params.Add(new Parameter("ClientGroupID", ClientGroupID.ToString(),
                                                                             ParameterMode.Value));

                this.txtSreachName.Hide();
            }
        }

        public int ClientGroupID
        {
            get
            {
                if (this.Request.QueryString["ClientGroupID"] == null)
                    return 0;
                return Convert.ToInt32(this.Request.QueryString["ClientGroupID"]);
            }

        }
        

        [AjaxMethod]
        public void LockLoginUser(int id,bool isLock)
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


        [AjaxMethod]
        public void RemoveFromGroup(int id)
        {
            try
            {
                SPClientWrapper clientWrapper = SPClientWrapper.FindById(id);

                clientWrapper.SPClientGroupID = null;

                SPClientWrapper.Update(clientWrapper);

                clientWrapper.UpdateSyncDataSetting();

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
        public void DeleteRecord(int id)
        {
            try
            {
                SPClientWrapper clientWrapper = SPClientWrapper.FindById(id);

                if (clientWrapper.UserID>0)
                    SystemUserWrapper.DeleteByID(clientWrapper.UserID);

                SPClientWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }



        protected void storeSPClient_Refresh(object sender, StoreRefreshDataEventArgs e)
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

            if(!string.IsNullOrEmpty(this.txtSreachName.Text.Trim()))
            {
                clientName = this.txtSreachName.Text.Trim();

                queryFilters.Add(new QueryFilter(SPClientWrapper.PROPERTY_NAME_NAME, clientName, FilterFunction.Contains));
            }



            

            if (ClientGroupID>0)
            {
                storeSPClient.DataSource = SPClientWrapper.FindAllByOrderByAndFilterAndSPClientGroupID(sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, SPClientGroupWrapper.FindById(this.ClientGroupID), out recordCount);
            }
            else
            {
                storeSPClient.DataSource = SPClientWrapper.FindAllByOrderByAndFilter(queryFilters,sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, out recordCount);               
            }


            e.TotalCount = recordCount;

            storeSPClient.DataBind();

        }
    }
}
