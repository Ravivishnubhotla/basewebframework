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
	[WebDataModule("用户用户组对应关系")]
    public class SystemUserGroupUserRelationAddUIPage : BaseDataAddPage<SystemUserGroupUserRelation>
    {
        protected SystemUserGroupUserRelationService systemUserGroupUserRelationServiceInstance;

        public SystemUserGroupUserRelationService SystemUserGroupUserRelationServiceInstance
        {
            set { systemUserGroupUserRelationServiceInstance = value; }
        }
        protected override void SaveData(SystemUserGroupUserRelation obj)
        {
            systemUserGroupUserRelationServiceInstance.Create(obj);
        }
    }
}



