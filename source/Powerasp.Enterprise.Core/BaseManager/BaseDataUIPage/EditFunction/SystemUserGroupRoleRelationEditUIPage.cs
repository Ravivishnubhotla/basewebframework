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
	[WebDataModule("部门角色关系")]
    public class SystemUserGroupRoleRelationEditUIPage : BaseDataEditPage<SystemUserGroupRoleRelation>
    {
        protected SystemUserGroupRoleRelationService systemUserGroupRoleRelationServiceInstance;

        public SystemUserGroupRoleRelationService SystemUserGroupRoleRelationServiceInstance
        {
            set { systemUserGroupRoleRelationServiceInstance = value; }
        }
		 protected override SystemUserGroupRoleRelation LoadDataByID(int id)
        {
            return systemUserGroupRoleRelationServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemUserGroupRoleRelationServiceInstance.DeleteByID(id);
        }

        protected override void UpdateData(SystemUserGroupRoleRelation obj)
        {
            systemUserGroupRoleRelationServiceInstance.Update(obj);
        }
    }
}



