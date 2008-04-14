using System;
using System.Collections.Generic;
using System.Data;
using System.Configuration;
using System.Collections;
using System.IO;
using System.Reflection;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Castle.Windsor;
using Castle.Windsor.Configuration.Interpreters;
using log4net;
using Powerasp.Enterprise.Core.BaseManager.Service;
using Powerasp.Enterprise.Core.BaseManager.Web;
using Powerasp.Enterprise.Core.Web.BasePage;
using Powerasp.Enterprise.Core.Web.Security;

namespace BaseWebManager
{
    public class Global : BaseWebGlobalPage

    {
        private ILog logger = LogManager.GetLogger(typeof(BaseWebManager.Global));

        public override void Init()
        {
            this.AuthenticateRequest += new EventHandler(OnAuthenticateRequest);
            this.AuthorizeRequest += new EventHandler(OnAuthorizeRequest);
            this.Error += new EventHandler(OnAuthorizeRequest);
            base.Init();
        }

        protected void OnAuthorizeRequest(object sender, EventArgs e)
        {
        }

        protected void OnAuthenticateRequest(object sender, EventArgs e)
        {
            SystemUserService systemUserService = this.Container.GetService<SystemUserService>();
            systemUserService.AuthenticateRequestUser();
        }


        private void app_Error(object sender, EventArgs e)
        {
            HttpApplication ap = sender as HttpApplication;

            Exception ex = ap.Server.GetLastError();
            if (ex is HttpException)
            {
                HttpException hx = (HttpException)ex;
                if (hx.GetHttpCode() == 404)
                {
                    string page = ap.Request.PhysicalPath;
                    logger.Error(string.Format("文件不存在:{0}", ap.Request.Url.AbsoluteUri));
                    return;
                }
            }
            if (ex.InnerException != null) ex = ex.InnerException;
            logger.Error(ex.Source + " thrown " + ex.GetType().ToString() + "<br />" + ex.Message.Replace("\r", "").Replace("\n", "<br />") + "<br />" + ex.StackTrace.Replace("\r", "").Replace("\n", "<br />"));
            if (!WebManagerSetting.IsDebug)
                ap.Response.Redirect("~/Messages.aspx?CMD=AppError");
            else
                throw ex;


        }

        protected void Application_Start(object sender, EventArgs e)
        {
            try
            {
                log4net.Config.XmlConfigurator.Configure(new FileInfo(Server.MapPath("~/log4net.config")));
                container = new WindsorContainer(new XmlInterpreter());
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw;
            }
        }

        protected void Application_End(object sender, EventArgs e)
        {
            container.Dispose();
        }




    }
}