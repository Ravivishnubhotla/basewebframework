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
	[WebDataModule("系统视图字段")]
    public class SystemViewItemViewUIPage : BaseDataViewPage<SystemViewItem>
    {
        protected SystemViewItemService systemViewItemServiceInstance;

        public SystemViewItemService SystemViewItemServiceInstance
        {
            set { systemViewItemServiceInstance = value; }
        }
		 protected override SystemViewItem LoadDataByID(int id)
        {
            return systemViewItemServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemViewItemServiceInstance.DeleteByID(id);
        }

    }
}



