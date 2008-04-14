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
	[WebDataModule("系统权限")]
    public class SystemPrivilegeEditUIPage : BaseDataEditPage<SystemPrivilege>
    {
        protected SystemPrivilegeService systemPrivilegeServiceInstance;

        public SystemPrivilegeService SystemPrivilegeServiceInstance
        {
            set { systemPrivilegeServiceInstance = value; }
        }
		 protected override SystemPrivilege LoadDataByID(int id)
        {
            return systemPrivilegeServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemPrivilegeServiceInstance.DeleteByID(id);
        }

        protected override void UpdateData(SystemPrivilege obj)
        {
            systemPrivilegeServiceInstance.Update(obj);
        }
    }
}



