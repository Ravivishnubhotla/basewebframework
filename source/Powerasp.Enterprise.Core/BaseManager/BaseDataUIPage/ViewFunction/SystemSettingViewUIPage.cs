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
	[WebDataModule("系统设置")]
    public class SystemSettingViewUIPage : BaseDataViewPage<SystemSetting>
    {
        protected SystemSettingService systemSettingServiceInstance;

        public SystemSettingService SystemSettingServiceInstance
        {
            set { systemSettingServiceInstance = value; }
        }
		 protected override SystemSetting LoadDataByID(int id)
        {
            return systemSettingServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemSettingServiceInstance.DeleteByID(id);
        }

    }
}



