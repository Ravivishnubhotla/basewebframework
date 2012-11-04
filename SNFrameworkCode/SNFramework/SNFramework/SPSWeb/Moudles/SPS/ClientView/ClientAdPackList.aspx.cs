using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Common.WebApp.AppCode;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.ClientView
{
    public partial class ClientAdPackList : SPClientViewPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;



            this.gridPanelSPAdPack.Reload();
        }


 

        protected void storeSPAdPack_Refresh(object sender, StoreRefreshDataEventArgs e)
        {


            storeSPAdPack.DataSource = SPAdAssignedHistortyWrapper.FindAllCLientAssignedAdPack(this.Client);
            storeSPAdPack.DataBind();

        }
    }
}