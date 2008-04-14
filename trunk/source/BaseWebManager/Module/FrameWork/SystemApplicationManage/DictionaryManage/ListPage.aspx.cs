using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.MobileControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.Web.BasePage;

namespace BaseWebManager.Module.FrameWork.SystemApplicationManage.DictionaryManage
{
    public partial class ListPage : BaseSecurityPage
    {

        private SystemMenuService systemMenuServiceInstance;

        public SystemMenuService SystemMenuServiceInstance
        {
            set { systemMenuServiceInstance = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }
    }
}
