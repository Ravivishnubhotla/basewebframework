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

namespace Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.EditFunction
{
	[WebDataModule("系统用户")]
    public class SystemUserEditUIPage : BaseDataEditPage<SystemUser>
    {
        protected SystemUserService systemUserServiceInstance;

        public SystemUserService SystemUserServiceInstance
        {
            set { systemUserServiceInstance = value; }
        }
		 protected override SystemUser LoadDataByID(int id)
        {
            return systemUserServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemUserServiceInstance.DeleteByID(id);
        }

        protected override void UpdateData(SystemUser obj)
        {
            systemUserServiceInstance.Update(obj);
        }
    }
}



