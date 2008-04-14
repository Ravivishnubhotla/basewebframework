using System;
using System.Collections.Generic;
using System.Text;
using Castle.Windsor;

namespace Powerasp.Enterprise.Core.Web.BasePage
{
    public class BaseWebGlobalPage : System.Web.HttpApplication, IContainerAccessor
    {
        protected static WindsorContainer container;

        #region IContainerAccessor Members

        public IWindsorContainer Container
        {
            get { return container; }
        }

        #endregion

        public static IWindsorContainer GetWebContainer()
        {
            return container;
        }
    }
}
