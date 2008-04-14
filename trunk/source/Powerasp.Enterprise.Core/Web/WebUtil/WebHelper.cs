using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Castle.Windsor;

namespace Powerasp.Enterprise.Core.Web.WebUtil
{
    public static class WebHelper
    {
        /// <summary>   
        /// Obtain the Cuyahoga container.   
        /// </summary>   
        /// <returns></returns>   
        public static IWindsorContainer GetContainer()
        {
            IContainerAccessor containerAccessor = HttpContext.Current.ApplicationInstance as IContainerAccessor;

            if (containerAccessor == null)
            {
                throw new Exception("You must extend the HttpApplication in your web project " +
                    "and implement the IContainerAccessor to properly expose your container instance");
            }

            IWindsorContainer container = containerAccessor.Container;

            if (container == null)
            {
                throw new Exception("The container seems to be unavailable in " +
                    "your HttpApplication subclass");
            }

            return container;
        }

        public static T GetService<T>()
        {
            IWindsorContainer container = GetContainer();
            return (T)container[typeof(T)];
        }

        public static int GetSaftIntValueFormQueryString(string keyName,int defaultVaule)
        {
            if (!string.IsNullOrEmpty(HttpContext.Current.Request.QueryString[keyName]))
            {
                int returnVaule = 0;
                if (int.TryParse(HttpContext.Current.Request.QueryString[keyName],out returnVaule))
                    return returnVaule;
                else
                    return defaultVaule;
            }
            else
            {
                return defaultVaule;
            }
        }

        /// <summary>
        /// 获取用户IP地址
        /// </summary>
        /// <returns></returns>
        public static string GetIPAddress()
        {

            string user_IP;
            if (HttpContext.Current.Request.ServerVariables["HTTP_VIA"] != null)
            {
                if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                {
                    user_IP = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
                else
                {
                    user_IP = HttpContext.Current.Request.UserHostAddress;
                }
            }
            else
            {
                user_IP = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"].ToString();
            }
            return user_IP;
        }
  
        
    }
}
