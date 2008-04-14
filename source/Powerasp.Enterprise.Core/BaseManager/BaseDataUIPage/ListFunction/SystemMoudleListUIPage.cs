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
	[WebDataModule("系统数据模块")]
    public class SystemMoudleListUIPage : BaseDataListPage<SystemMoudle>
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

        protected override int GetDomainID(SystemMoudle obj)
        {
            return obj.MoudleID;
        }
    }
}



