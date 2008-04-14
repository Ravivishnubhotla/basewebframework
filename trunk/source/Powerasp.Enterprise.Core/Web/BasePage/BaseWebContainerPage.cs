using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Castle.Windsor;
using Powerasp.Enterprise.Core.Web.WebUtil;

namespace Powerasp.Enterprise.Core.Web.BasePage
{
    public abstract class BaseWebContainerPage : System.Web.UI.Page
    {
        public BindingFlags BINDING_FLAGS_SET
    = BindingFlags.Public
    | BindingFlags.SetProperty
    | BindingFlags.Instance
    | BindingFlags.SetField
    ;

        protected BaseWebContainerPage()
        {
            IWindsorContainer container = ObtainContainer();
        }

        protected override void OnInit(EventArgs e)
        {
            IWindsorContainer container = ObtainContainer();

            Type type = this.GetType();

            PropertyInfo[] properties = type.GetProperties(BINDING_FLAGS_SET);

            foreach (PropertyInfo propertie in properties)
            {
                string pname = propertie.Name;

                if (container.Kernel.HasComponent(pname))
                {
                    propertie.SetValue(this, container[pname], null);
                }
            }

            base.OnInit(e);
        }

        public IWindsorContainer ObtainContainer()
        {
            return WebHelper.GetContainer();
        }
    }
}
