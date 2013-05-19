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

            dfReportEndDate.DateField.MaxDate = System.DateTime.Now.Date;

            dfReportEndDate.DateField.Value = System.DateTime.Now.Date;

            dfReportStartDate.DateField.MaxDate = System.DateTime.Now.Date;

            dfReportStartDate.DateField.Value = System.DateTime.Now.Date;
        }


        protected void btnRefresh_Click(object sender, AjaxEventArgs e)
        {
            if (cmbCode.SelectedItem == null)
                return;

            this.ReportPanel.AutoLoad.Params.Clear();
            if (cmbChannelID.SelectedItem != null)
                this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("ChannleID", cmbChannelID.SelectedItem.Value.ToString()));
            else
                this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("ChannleID", "0"));

            if (cmbCode.SelectedItem != null)
                this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("ChannleClientSettingID", cmbCode.SelectedItem.Value.ToString()));
            else
                this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("ChannleClientSettingID", "0"));

            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("StartDate", dfReportStartDate.DateField.SelectedDate.ToShortDateString()));
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("EndDate", dfReportEndDate.DateField.SelectedDate.ToShortDateString()));
            this.ReportPanel.AutoLoad.Params.Add(new Coolite.Ext.Web.Parameter("TimeIntercept", cmbCommandType.SelectedItem.Value.ToString()));
            this.ReportPanel.AutoLoad.Url = "ReportDataChangeService.aspx";
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
            if (!string.IsNullOrEmpty(e.Parameters["ChannelID"]))
            {
                int channelID = int.Parse(e.Parameters["ChannelID"].ToString());

                SPChannelWrapper channelWrapper = SPChannelWrapper.FindById(channelID);

                storeSPChannelClientSetting.DataSource = SPClientChannelSettingWrapper.GetSettingByChannel(channelWrapper);

                storeSPChannelClientSetting.DataBind();
            }
            else
            {
                storeSPChannelClientSetting.DataSource = new List<SPClientChannelSettingWrapper>();

                storeSPChannelClientSetting.DataBind();
            }
        }
    }
}