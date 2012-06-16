using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Common.Logging;

namespace Legendigital.Common.WebApp
{
    public class Global : System.Web.HttpApplication
    {
        private static ILog logger = LogManager.GetLogger(typeof(Global));

        protected DateTime pageStartDateTime;
 
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            //HttpApplication application = sender as HttpApplication;
            //if (application != null && application.Context != null)
            //{
            //    Stopwatch timer = new Stopwatch();
            //    application.Context.Items["Timer"] = timer;
            //    timer.Start();
            //}
        }

        protected void Application_EndRequest(object sender, EventArgs e)
        {
            //HttpContext httpContext = ((HttpApplication)sender).Context;
            //HttpResponse response = httpContext.Response;
            //Stopwatch timer = (Stopwatch)httpContext.Items["Timer"];
            //timer.Stop();

            //if (response.ContentType == "text/html")
            //{
            //    double seconds = (double)timer.ElapsedTicks / Stopwatch.Frequency;
            //    string result_time = string.Format("{0:F4} sec ", seconds);
            //    RenderQueriesToResponse(response, result_time);
            //}
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