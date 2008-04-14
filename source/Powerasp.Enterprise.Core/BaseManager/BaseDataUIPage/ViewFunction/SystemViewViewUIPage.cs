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
	[WebDataModule("系统视图")]
    public class SystemViewViewUIPage : BaseDataViewPage<SystemView>
    {
        protected SystemViewService systemViewServiceInstance;

        public SystemViewService SystemViewServiceInstance
        {
            set { systemViewServiceInstance = value; }
        }
		 protected override SystemView LoadDataByID(int id)
        {
            return systemViewServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemViewServiceInstance.DeleteByID(id);
        }

    }
}



