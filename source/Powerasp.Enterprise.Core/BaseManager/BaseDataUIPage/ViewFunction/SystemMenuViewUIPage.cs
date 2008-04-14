using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.Web.BasePage;
using Powerasp.Enterprise.Core.Attribute;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.ViewFunction
{
	[WebDataModule("系统导航菜单")]
    public class SystemMenuViewUIPage : BaseDataViewPage<SystemMenu>
    {
        protected SystemMenuService systemMenuServiceInstance;

        public SystemMenuService SystemMenuServiceInstance
        {
            set { systemMenuServiceInstance = value; }
        }
		 protected override SystemMenu LoadDataByID(int id)
        {
            return systemMenuServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemMenuServiceInstance.DeleteByID(id);
        }

    }
}



