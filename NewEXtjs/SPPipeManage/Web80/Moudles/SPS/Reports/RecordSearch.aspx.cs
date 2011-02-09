using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class RecordSearch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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


            store1.DataSource = SPPaymentInfoWrapper.FindAllByOrderBy(sortFieldName,
                                                                      (e.Dir == Coolite.Ext.Web.SortDirection.DESC),
                                                                      pageIndex, limit, out recordCount);
            e.TotalCount = recordCount;

            store1.DataBind();


        }
    }
}