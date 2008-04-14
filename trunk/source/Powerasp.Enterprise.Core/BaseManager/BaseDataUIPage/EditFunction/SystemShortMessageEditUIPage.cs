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
	[WebDataModule("系统短消息")]
    public class SystemShortMessageEditUIPage : BaseDataEditPage<SystemShortMessage>
    {
        protected SystemShortMessageService systemShortMessageServiceInstance;

        public SystemShortMessageService SystemShortMessageServiceInstance
        {
            set { systemShortMessageServiceInstance = value; }
        }
		 protected override SystemShortMessage LoadDataByID(int id)
        {
            return systemShortMessageServiceInstance.FindById(id);
        }

        protected override void DeleteDataByID(int id)
        {
            systemShortMessageServiceInstance.DeleteByID(id);
        }

        protected override void UpdateData(SystemShortMessage obj)
        {
            systemShortMessageServiceInstance.Update(obj);
        }
    }
}



