using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.Web.BasePage;

namespace BaseWebManager.MainPage
{
    public partial class Right : BaseSecurityPage
    {
        private SystemUserService systemUserServiceInstance;

        public SystemUserService SystemUserServiceInstance
        {
            set { systemUserServiceInstance = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}
