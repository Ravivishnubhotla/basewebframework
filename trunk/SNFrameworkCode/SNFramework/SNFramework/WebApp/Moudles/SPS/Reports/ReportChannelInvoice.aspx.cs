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
    public partial class ReportChannelInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            this.storeSPChannel.DataSource = SPChannelWrapper.FindAll();

            this.storeSPChannel.DataBind();
        }

        protected void storeSPCode_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            SPChannelWrapper channel = null;

            if (this.cmbChannel.SelectedItem != null)
            {
                channel = SPChannelWrapper.FindById(Convert.ToInt32(this.cmbChannel.SelectedItem.Value));
            }

            if (channel != null)
            {
                this.storeSPCode.DataSource = SPCodeWrapper.FindAllByChannelID(channel);
            }
            else
            {
                this.storeSPCode.DataSource = new List<SPCodeWrapper>();
            }

            this.storeSPCode.DataBind();
        }
    }
}