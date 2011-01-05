using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Models
{
    public class LoginFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string findName = filterContext.HttpContext.User.Identity.Name;
            bool isGuest = false;

            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
                findName = filterContext.HttpContext.User.Identity.Name;
            else
            {
                findName = filterContext.HttpContext.Session.SessionID.ToUpper();
                isGuest = true;
            }

            //LoginUserMemberShip userModel = 

            //if (userModel == null)
            //{
            //    userModel = new Models.OnlineUser();
            //    userModel.UserName = findName;
            //    userModel.LoginTime = DateTime.Now;
            //    userModel.LastTime = DateTime.Now;
            //    userModel.LoginIp = filterContext.HttpContext.Request.UserHostAddress;
            //    userModel.LastActionUrl = filterContext.HttpContext.Request.Url.PathAndQuery;
            //    userModel.SessionID = filterContext.HttpContext.Session.SessionID.ToUpper();
            //    userModel.IsGuest = isGuest;
            //    UserOnlineModule.OnlineList.Add(userModel);

            //}
            //else
            //{
            //    userModel.LastTime = DateTime.Now;
            //    userModel.LastActionUrl = filterContext.HttpContext.Request.Url.PathAndQuery;

            //}
        }
    }
}