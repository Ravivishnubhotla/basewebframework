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


namespace Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.AddFunction
{
	[WebDataModule("用户组")]
    public class SystemUserGroupAddUIPage : BaseDataAddPage<SystemUserGroup>
    {
        protected SystemUserGroupService systemUserGroupServiceInstance;

        public SystemUserGroupService SystemUserGroupServiceInstance
        {
            set { systemUserGroupServiceInstance = value; }
        }
        protected override void SaveData(SystemUserGroup obj)
        {
            systemUserGroupServiceInstance.Create(obj);
        }
    }
}



