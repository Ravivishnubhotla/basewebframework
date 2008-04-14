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
	[WebDataModule("系统操作")]
    public class SystemOperationEditUIPage : BaseDataEditPage<SystemOperation>
    {
        protected SystemOperationService systemOperationServiceInstance;

        public SystemOperationService SystemOperationServiceInstance
        {
            set { systemOperationServiceInstance = value; }
        }
		 protected override SystemOperation LoadDataByID(int id)
        {
            return systemOperationServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemOperationServiceInstance.DeleteByID(id);
        }

        protected override void UpdateData(SystemOperation obj)
        {
            systemOperationServiceInstance.Update(obj);
        }
    }
}



