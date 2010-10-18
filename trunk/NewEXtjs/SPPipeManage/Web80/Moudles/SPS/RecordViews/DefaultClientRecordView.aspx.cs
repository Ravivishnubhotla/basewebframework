using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Newtonsoft.Json;

namespace Legendigital.Common.Web.Moudles.SPS.RecordViews
{
    public partial class DefaultClientRecordView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

 
        }


        public int SPClientID
        {
            get
            {
                if (this.cmbClientID.SelectedItem == null)
                    return 0;
                if (this.cmbClientID.SelectedItem.Value == "")
                    return 0;
                return Convert.ToInt32(this.cmbClientID.SelectedItem.Value);
            }
        }

 
        protected void store1_Refresh(object sender, StoreRefreshDataEventArgs e)
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


            List<SPPaymentInfoWrapper> list = null;


                            DateTime startDate = DateTime.MinValue;

                if(this.dfStartDate.DateField.Value!=null)
                {
                    startDate = Convert.ToDateTime(this.dfStartDate.DateField.Value);
                }

                DateTime endDate = DateTime.MinValue;

                if(this.dfEndDate.DateField.Value!=null)
                {
                    endDate = Convert.ToDateTime(this.dfEndDate.DateField.Value);
                }

            if (SPClientID > 0)
            {


                list = SPPaymentInfoWrapper.FindAllByOrderByAndClientIDAndDate(SPClientID, startDate, endDate, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);
            }
            else
            {
                list = SPPaymentInfoWrapper.FindAllDefaultClientPaymentByOrderByDate(startDate, endDate, sortFieldName, (e.Dir == Coolite.Ext.Web.SortDirection.DESC), pageIndex, limit, out recordCount);
            }


            if (list.Count > 0)
            {
                foreach (SPPaymentInfoWrapper spPaymentInfoWrapper in list)
                {
                    spPaymentInfoWrapper.Values = JsonConvert.SerializeObject(
                        spPaymentInfoWrapper.GetValues(
                            JsonConvert.DeserializeObject<Hashtable>(spPaymentInfoWrapper.RequestContent)));
                }
            }

            store1.DataSource = list;
            e.TotalCount = recordCount;

            store1.DataBind();


        }

        protected void storeSPClient_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeSPClient.DataSource = SPClientWrapper.GetAllDefaultClient();

            storeSPClient.DataBind();

        }
    }
}