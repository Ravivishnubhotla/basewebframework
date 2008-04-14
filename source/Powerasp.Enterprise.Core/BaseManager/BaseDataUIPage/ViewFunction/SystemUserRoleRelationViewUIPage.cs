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
	[WebDataModule("系统用户角色分配")]
    public class SystemUserRoleRelationViewUIPage : BaseDataViewPage<SystemUserRoleRelation>
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

    }
}



