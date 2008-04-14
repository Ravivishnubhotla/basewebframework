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

namespace Powerasp.Enterprise.Core.BaseManager.BaseDataUIPage.ListFunction
{
	[WebDataModule("系统用户角色分配")]
    public class SystemUserRoleRelationListUIPage : BaseDataListPage<SystemUserRoleRelation>
    {
        protected SystemUserRoleRelationService systemUserRoleRelationServiceInstance;

        public SystemUserRoleRelationService SystemUserRoleRelationServiceInstance
        {
            set { systemUserRoleRelationServiceInstance = value; }
        }

        protected override SystemUserRoleRelation LoadDataByID(int id)
        {
            return systemUserRoleRelationServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemUserRoleRelationServiceInstance.DeleteByID(id);
        }

        protected override int GetDomainID(SystemUserRoleRelation obj)
        {
            return obj.UserRoleID;
        }
    }
}



