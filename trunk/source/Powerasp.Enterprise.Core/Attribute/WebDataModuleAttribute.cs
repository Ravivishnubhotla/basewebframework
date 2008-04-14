using System;
using System.Collections.Generic;
using System.Text;

namespace Powerasp.Enterprise.Core.Attribute
{
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false,Inherited = true)]
    public class WebDataModuleAttribute : System.Attribute
    {
        private string moduleNameCn;
        private string queryStringIDKeyName;
        private string contextDataitemKeyName;
        private string listPageUrl;
        private string addPageUrl;
        private string editPageUrl;
        private string viewPageUrl;


        public WebDataModuleAttribute(string moduleNameCn)
        {
            this.moduleNameCn = moduleNameCn;
            queryStringIDKeyName = "ID";
            contextDataitemKeyName = "CurrentDataItemID";
            listPageUrl = "ListPage.aspx";
            addPageUrl = "AddPage.aspx";
            editPageUrl = "EditPage.aspx";
            viewPageUrl = "ViewPage.aspx";
        }

        public virtual string ModuleNameCn
        {
            get { return moduleNameCn; }
        }


        public virtual string QueryStringIDKeyName
        {
            get { return queryStringIDKeyName; }
            set { queryStringIDKeyName = value; }
        }

        public virtual string ContextDataitemKeyName
        {
            get { return contextDataitemKeyName; }
            set { contextDataitemKeyName = value; }
        }

        public virtual string ListPageUrl
        {
            get { return listPageUrl; }
            set { listPageUrl = value; }
        }

        public virtual string AddPageUrl
        {
            get { return addPageUrl; }
            set { addPageUrl = value; }
        }

        public virtual string EditPageUrl
        {
            get { return editPageUrl; }
            set { editPageUrl = value; }
        }

        public string ViewPageUrl
        {
            get { return viewPageUrl; }
            set { viewPageUrl = value; }
        }
    }
}
