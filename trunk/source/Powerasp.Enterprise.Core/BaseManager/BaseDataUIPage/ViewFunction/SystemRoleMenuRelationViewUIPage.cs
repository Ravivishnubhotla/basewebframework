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
	[WebDataModule("系统角色菜单分配")]
    public class SystemRoleMenuRelationViewUIPage : BaseDataViewPage<SystemRoleMenuRelation>
    {
        protected SystemRoleMenuRelationService systemRoleMenuRelationServiceInstance;

        public SystemRoleMenuRelationService SystemRoleMenuRelationServiceInstance
        {
            set { systemRoleMenuRelationServiceInstance = value; }
        }
		 protected override SystemRoleMenuRelation LoadDataByID(int id)
        {
            return systemRoleMenuRelationServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemRoleMenuRelationServiceInstance.DeleteByID(id);
        }

    }
}



