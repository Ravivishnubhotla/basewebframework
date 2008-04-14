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
	[WebDataModule("用户用户组对应关系")]
    public class SystemUserGroupUserRelationListUIPage : BaseDataListPage<SystemUserGroupUserRelation>
    {
        protected SystemUserGroupUserRelationService systemUserGroupUserRelationServiceInstance;

        public SystemUserGroupUserRelationService SystemUserGroupUserRelationServiceInstance
        {
            set { systemUserGroupUserRelationServiceInstance = value; }
        }

        protected override SystemUserGroupUserRelation LoadDataByID(int id)
        {
            return systemUserGroupUserRelationServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemUserGroupUserRelationServiceInstance.DeleteByID(id);
        }

        protected override int GetDomainID(SystemUserGroupUserRelation obj)
        {
            return obj.UserGroupUserID;
        }
    }
}



