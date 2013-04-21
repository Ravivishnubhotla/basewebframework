using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Channels
{
    public partial class SPChannelView : System.Web.UI.Page
    {
        public SPChannelWrapper ChannelID
        {
            get
            {
                if (this.Request.QueryString["ChannelID"] != null)
                {
                    return
                        SPChannelWrapper.FindById(int.Parse(this.Request.QueryString["ChannelID"]));
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            SPChannelWrapper obj = ChannelID;

            if (obj != null)
            {
                obj.UpdateChannelDetailInfo();

                this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);

                this.lblCode.Text = ValueConvertUtil.ConvertStringValue(obj.Code);

                this.lblChannelType.Text = obj.ChannelTypeName;

                this.lblStateReportType.Text = obj.StatusReportType;

                this.lblIsMonitorRequest.Text = obj.IsMonitorRequest.ToString();

                this.lblIsLogRequest.Text = obj.IsLogRequest.ToString();

                this.lblHasFilters.Text = obj.HasFilters.ToString();

                this.lblIsDisable.Text = obj.IsDisable.ToString();

                this.lblDefaultRate.Text = obj.DefaultRate.ToString();

                this.lblPrice.Text = obj.Price.ToString();

                this.lblChannelStatus.Text = obj.ChannelStatusName;

                this.lblUpper.Text = obj.UpperID_Name;

                this.lblChannelDetailInfo.Text = obj.ChannelDetailInfo;
            }
 
 
        }

 
    }
}