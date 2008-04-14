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
	[WebDataModule("系统数据模块")]
    public class SystemMoudleEditUIPage : BaseDataEditPage<SystemMoudle>
    {
        protected SystemMoudleService systemMoudleServiceInstance;

        public SystemMoudleService SystemMoudleServiceInstance
        {
            set { systemMoudleServiceInstance = value; }
        }
		 protected override SystemMoudle LoadDataByID(int id)
        {
            return systemMoudleServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemMoudleServiceInstance.DeleteByID(id);
        }

        protected override void UpdateData(SystemMoudle obj)
        {
            systemMoudleServiceInstance.Update(obj);
        }
    }
}



