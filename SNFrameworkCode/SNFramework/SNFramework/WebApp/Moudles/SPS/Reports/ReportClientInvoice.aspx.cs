using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;

namespace Legendigital.Common.WebApp.Moudles.SPS.Reports
{
    public partial class ReportClientInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void storeSPClient_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPClient.DataSource = SPSClientWrapper.FindAll();

            this.storeSPClient.DataBind();
        }

        protected void storeSPCode_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPSClientWrapper client = null;

            if (this.cmbClient.SelectedItem != null)
            {
                client = SPSClientWrapper.FindById(Convert.ToInt32(this.cmbClient.SelectedItem.Value));
            }

            if (client != null)
            {
                this.storeSPCode.DataSource = client.GetAllAssignedCode();
            }
            else
            {
                this.storeSPCode.DataSource = new List<SPCodeWrapper>();
            }

            this.storeSPCode.DataBind();

        }
    }
}