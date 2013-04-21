using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.Utility;
using SPS.Bussiness.Wrappers;

namespace SPSWeb.Moudles.SPS.Clients
{
    public partial class SPClientView : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;


            SPSClientWrapper obj = SPSClientID;

            if (obj != null)
            {



                this.lblName.Text = ValueConvertUtil.ConvertStringValue(obj.Name);
                this.lblDescription.Text = ValueConvertUtil.ConvertStringValue(obj.Description);
 
                this.lblUserID.Text = obj.UserID.ToString();
 
 
                this.lblInterceptRate.Text = obj.InterceptRate.ToString();
                this.lblDefaultPrice.Text = obj.DefaultPrice.ToString();
                this.lblDefaultShowRecordDays.Text = obj.DefaultShowRecordDays.ToString();
                this.lblSycnNotInterceptCount.Text = obj.SycnNotInterceptCount.ToString();

                this.lblSycnDataInfo.Text = obj.SycnDataInfo;

            }
        }


        public SPSClientWrapper SPSClientID
        {
            get
            {
                if (this.Request.QueryString["SPSClientID"] != null)
                {
                    return
                        SPSClientWrapper.FindById(int.Parse(this.Request.QueryString["SPSClientID"]));
                }
                return null;
            }
        }
    }
}