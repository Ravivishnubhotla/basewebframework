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
	[WebDataModule("用户组")]
    public class SystemUserGroupViewUIPage : BaseDataViewPage<SystemUserGroup>
    {
        protected SystemUserGroupService systemUserGroupServiceInstance;

        public SystemUserGroupService SystemUserGroupServiceInstance
        {
            set { systemUserGroupServiceInstance = value; }
        }
		 protected override SystemUserGroup LoadDataByID(int id)
        {
            return systemUserGroupServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemUserGroupServiceInstance.DeleteByID(id);
        }

    }
}



