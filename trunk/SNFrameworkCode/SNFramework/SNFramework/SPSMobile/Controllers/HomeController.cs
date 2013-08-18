using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SPSMobile.Models;

namespace SPSMobile.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult Index()
        {
            //FormsAuthentication.SignOut();
            //if (this.HttpContext.User == null)
            //    return RedirectToAction("Login", "Home");
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUserModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (model.ValidateUser())
                {
                    FormsAuthentication.SetAuthCookie(model.LoginID, model.SaveLoginStatus);
                    if (Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }


 

    }
}
