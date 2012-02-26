using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;


namespace Legendigital.Common.Web.Moudles.SPS.FailedRequests
{
    public partial class SPFailedRequestListPage : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            this.gridPanelSPFailedRequest.Reload();
        }


        [AjaxMethod]
        public void DeleteRecord(int id)
        {
            try
            {
                SPFailedRequestWrapper.DeleteByID(id);

                ScriptManager.AjaxSuccess = true;
            }
            catch (Exception ex)
            {
                ScriptManager.AjaxSuccess = false;
                ScriptManager.AjaxErrorMessage = string.Format(ex.Message);
                return;
            }
        }

        protected void storeSPFailedRequest_Refresh(object sender, StoreRefreshDataEventArgs e)
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


            List<QueryFilter> queryFilters = GetQueryFilters();

            storeSPFailedRequest.DataSource = SPFailedRequestWrapper.FindAllByOrderByAndFilter(queryFilters, sortFieldName, (e.Dir == SortDirection.DESC), pageIndex, limit, out recordCount);
            e.TotalCount = recordCount;

            storeSPFailedRequest.DataBind();

        }

        protected void btnProcessAll_Click(object sender, AjaxEventArgs e)
        {
            string json = e.ExtraParams["Values"];

            if (string.IsNullOrEmpty(json))
            {
                return;
            }


            Dictionary<string, string>[] datas = JSON.Deserialize<Dictionary<string, string>[]>(json);

            foreach (Dictionary<string, string> row in datas)
            {
                int id = Convert.ToInt32(row["Id"].ToString());

                SPFailedRequestWrapper spFailedRequestWrapper = SPFailedRequestWrapper.FindById(id);

                spFailedRequestWrapper.IsProcessed = true;

                SPFailedRequestWrapper.Update(spFailedRequestWrapper);
            }
        }


        private List<QueryFilter> GetQueryFilters()
        {
            string proccessType = "0";

            if (this.cmbProcessType.SelectedItem != null)
            {
                proccessType = this.cmbProcessType.SelectedItem.Value.ToString();
            }

            DateTime startDate = DateTime.MinValue;

            if(this.dfStartDate.DateField.Value !=null)
            {
                startDate = (DateTime)this.dfStartDate.DateField.Value;
            }

            DateTime endDate = DateTime.MinValue;


            if (this.dfEndDate.DateField.Value != null)
            {
                endDate = (DateTime)this.dfEndDate.DateField.Value;
            }

            string urlLike = this.txtUrl.Text.Trim();


            List<QueryFilter> queryFilters = new List<QueryFilter>();

            if(proccessType=="1")
            {
                queryFilters.Add(new QueryFilter(SPFailedRequestWrapper.PROPERTY_NAME_ISPROCESSED,bool.TrueString,FilterFunction.EqualTo));
            }
            if(proccessType=="2")
            {
                queryFilters.Add(new QueryFilter(SPFailedRequestWrapper.PROPERTY_NAME_ISPROCESSED,bool.TrueString, FilterFunction.NotEqualTo));
            }


            if (startDate != DateTime.MinValue)
            {
                queryFilters.Add(new QueryFilter(SPFailedRequestWrapper.PROPERTY_NAME_RECIEVEDDATE, startDate.Date.ToShortDateString(), FilterFunction.GreaterThanOrEqualTo));
            }
            if (endDate != DateTime.MinValue)
            {
                queryFilters.Add(new QueryFilter(SPFailedRequestWrapper.PROPERTY_NAME_RECIEVEDDATE, endDate.AddDays(1).Date.ToShortDateString(), FilterFunction.LessThan));
            }

 

            if(!string.IsNullOrEmpty(urlLike))
            {
                queryFilters.Add(new QueryFilter(SPFailedRequestWrapper.PROPERTY_NAME_RECIEVEDSENDURL, urlLike, FilterFunction.Contains));
            }



            return queryFilters;
        }
    }
}