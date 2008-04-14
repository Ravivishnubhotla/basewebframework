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
	[WebDataModule("系统数据模块字段")]
    public class SystemMoudleFieldEditUIPage : BaseDataEditPage<SystemMoudleField>
    {
        protected SystemMoudleFieldService systemMoudleFieldServiceInstance;

        public SystemMoudleFieldService SystemMoudleFieldServiceInstance
        {
            set { systemMoudleFieldServiceInstance = value; }
        }
		 protected override SystemMoudleField LoadDataByID(int id)
        {
            return systemMoudleFieldServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemMoudleFieldServiceInstance.DeleteByID(id);
        }

        protected override void UpdateData(SystemMoudleField obj)
        {
            systemMoudleFieldServiceInstance.Update(obj);
        }
    }
}



