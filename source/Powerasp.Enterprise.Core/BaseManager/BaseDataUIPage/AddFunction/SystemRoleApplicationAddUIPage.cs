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
	[WebDataModule("角色应用分配表")]
    public class SystemRoleApplicationAddUIPage : BaseDataAddPage<SystemRoleApplication>
    {
        protected SystemRoleApplicationService systemRoleApplicationServiceInstance;

        public SystemRoleApplicationService SystemRoleApplicationServiceInstance
        {
            set { systemRoleApplicationServiceInstance = value; }
        }
        protected override void SaveData(SystemRoleApplication obj)
        {
            systemRoleApplicationServiceInstance.Create(obj);
        }
    }
}



