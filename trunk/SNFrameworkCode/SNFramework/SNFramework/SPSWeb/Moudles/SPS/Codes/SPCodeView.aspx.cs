using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using SPS.Bussiness.Wrappers;
using SPSWeb.AppCode;

namespace SPSWeb.Moudles.SPS.Codes
{
    public partial class SPCodeView : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            SPCodeWrapper obj = CodeID;

            if (obj != null)
            {
                this.lblChannelName.Text = obj.ChannelID_Name;

                this.lblMoCodeCode.Text = obj.MoCode;

                this.lblAssignedClient.Text = obj.AssignedClientName;

                this.lblPrice.Text = obj.Price.ToString();

                this.lblIsDiable.Text = obj.IsDiable.ToString();

                this.lblProvinceLimitInfo.Text = obj.ProvinceLimitInfo.ToString();

                this.lblPhoneLimitInfo.Text = obj.PhoneLimitInfo.ToString();

            }
        }

        public SPCodeWrapper CodeID
        {
            get
            {
                if (this.Request.QueryString["CodeID"] != null)
                {
                    return
                        SPCodeWrapper.FindById(int.Parse(this.Request.QueryString["CodeID"]));
                }
                return null;
            }
        }
    }
}