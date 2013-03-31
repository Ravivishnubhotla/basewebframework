using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Code;

namespace SPSWeb.Moudles.SPS.Codes
{
    public partial class SPCodeLimitSetting : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void storeAreaCountList_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            storeAreaCountList.DataSource = new List<PhoneLimitAreaAssigned>();

            storeAreaCountList.DataBind();
        }
    }
}