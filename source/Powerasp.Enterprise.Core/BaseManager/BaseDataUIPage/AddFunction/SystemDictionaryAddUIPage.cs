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
	[WebDataModule("系统字典表")]
    public class SystemDictionaryAddUIPage : BaseDataAddPage<SystemDictionary>
    {
        protected SystemDictionaryService systemDictionaryServiceInstance;

        public SystemDictionaryService SystemDictionaryServiceInstance
        {
            set { systemDictionaryServiceInstance = value; }
        }
        protected override void SaveData(SystemDictionary obj)
        {
            systemDictionaryServiceInstance.Create(obj);
        }
    }
}



