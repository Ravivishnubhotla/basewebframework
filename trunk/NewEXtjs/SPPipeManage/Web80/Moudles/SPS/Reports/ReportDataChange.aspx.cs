using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Coolite.Ext.Web;
using LD.SPPipeManage.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;

namespace Legendigital.Common.Web.Moudles.SPS.Reports
{
    public partial class ReportDataChange : System.Web.UI.Page
    {
 


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Ext.IsAjaxRequest)
                return;

            dfReportEndDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);

            dfReportEndDate.DateField.Value = System.DateTime.Now.AddDays(-1);

            dfReportStartDate.DateField.MaxDate = System.DateTime.Now.AddDays(-1);

            dfReportStartDate.DateField.Value = System.DateTime.Now.AddDays(-8);
        }


        protected void btnRefresh_Click(object sender, AjaxEventArgs e)
        {
            if (cmbCode.SelectedItem == null)
                return;

            this.ReportPanel.AutoLoad.Params.Clear();
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("ChannleClientSettingID", cmbCode.SelectedItem.Value.ToString()));
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("StartDate", dfReportStartDate.DateField.SelectedDate.ToShortDateString()));
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("EndDate", dfReportEndDate.DateField.SelectedDate.ToShortDateString()));
            this.ReportPanel.AutoLoad.Url = "SPClientClientCountReportService.aspx";
            this.ReportPanel.LoadContent();
        }

        protected void storeSPChannel_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            List<QueryFilter> filters = new List<QueryFilter>();

            filters.Add(new QueryFilter(SPChannelWrapper.PROPERTY_NAME_ISDISABLE,"false",FilterFunction.EqualTo));

            List<SPChannelWrapper> channels = SPChannelWrapper.FindAllByOrderByAndFilter(filters, SPChannelWrapper.PROPERTY_NAME_ID,true);

            storeSPChannel.DataSource = channels;

            storeSPChannel.DataBind();

        }

        protected void storeSPChannelClientSetting_Refresh(object sender, StoreRefreshDataEventArgs e)
        {
            int channelID = int.Parse(e.Parameters["ChannelID"].ToString());
            
            SPChannelWrapper channelWrapper =  SPChannelWrapper.FindById(channelID);

            storeSPChannelClientSetting.DataSource = channelWrapper.GetAllClientChannelSetting();

            storeSPChannelClientSetting.DataBind();
        }
    }
}