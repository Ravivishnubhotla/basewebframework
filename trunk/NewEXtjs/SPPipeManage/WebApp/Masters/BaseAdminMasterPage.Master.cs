using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.BaseFramework.Web;
using Ext.Net;

namespace Legendigital.Common.WebApp.Masters
{
    public partial class BaseAdminMasterPage : System.Web.UI.MasterPage
    {
        public BaseSecurityPage CurrentSecurityPage
        {
            get
            {
                BaseSecurityPage page = this.Page as BaseSecurityPage;

                return page;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            this.lblUser.Text = string.Format("<b>{0}</b>,Today is {1:D}", this.CurrentSecurityPage.CurrentLoginUser.UserLoginID, System.DateTime.Now);
        }

        protected void btnExit_Click(object sender, DirectEventArgs e)
        {
            CurrentSecurityPage.ClearLoginInfo();
        }
    }
}
