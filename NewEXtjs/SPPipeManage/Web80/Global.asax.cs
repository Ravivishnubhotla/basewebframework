using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Common.Logging;
using Legendigital.Common.Web.Jobs;
using Quartz;

namespace Legendigital.Common.Web
{
    public class Global : System.Web.HttpApplication
    {
        private ILog logger = LogManager.GetLogger(typeof(Global));

        


        protected void Application_Start(object sender, EventArgs e)
        {
            


        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            Exception objErr = Server.GetLastError().GetBaseException();
            logger.Error("Page Error:" + Request.Url, objErr);
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {
        }
    }
}