using System;
using System.Collections.Generic;
using System.Text;
using Powerasp.Enterprise.Core.Attribute;

namespace Powerasp.Enterprise.Core.Web.BasePage
{
    public class BaseDataManagePage : BaseSecurityPage
    {
        protected static SortedList<string, WebDataModuleAttribute> webDataModuleCache =
    new SortedList<string, WebDataModuleAttribute>();

        protected override void OnInit(EventArgs e)
        {
            Type pageType = this.GetType();
            string pageTypeName = pageType.FullName;
            if (!webDataModuleCache.ContainsKey(pageTypeName))
            {
                object[] webDataModuleAttributes =
                    pageType.GetCustomAttributes(typeof(WebDataModuleAttribute), true);
                if (webDataModuleAttributes.Length > 0)
                    webDataModuleCache[pageTypeName] = (WebDataModuleAttribute)webDataModuleAttributes[0];
                else
                    webDataModuleCache[pageTypeName] = new WebDataModuleAttribute("");
            }
            base.OnInit(e);
        }

        protected WebDataModuleAttribute CurrentWebDataModuleAttribute()
        {
            return webDataModuleCache[this.GetType().FullName];
        }

        protected string GetIDQueryStringKey()
        {
            return CurrentWebDataModuleAttribute().QueryStringIDKeyName;
        }

        protected string GetDataItemContextKey()
        {
            return CurrentWebDataModuleAttribute().ContextDataitemKeyName;
        }

        protected string GetListPageUrl()
        {
            return CurrentWebDataModuleAttribute().ListPageUrl;
        }

        protected string GetAddPageUrl()
        {
            return CurrentWebDataModuleAttribute().AddPageUrl;
        }

        protected string GetViewPageUrl()
        {
            return CurrentWebDataModuleAttribute().ViewPageUrl;
        }

        protected string GetEditPageUrl()
        {
            return CurrentWebDataModuleAttribute().EditPageUrl;
        }

        protected string GetModuleNameCn()
        {
            string moduleNameCn = CurrentWebDataModuleAttribute().ModuleNameCn;
            if (moduleNameCn == "")
                return "";
            else
                return CurrentWebDataModuleAttribute().ModuleNameCn;
        }
    }
}
