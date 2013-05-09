using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SPSMobile.Models;

namespace SPSMobile.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            if (Session["LoginUser"] == null)
                Response.Redirect("Home/Login");
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }


        //public ActionResult Dialog()
        //{
        //    return View();
        //}
        

        public bool CheckUser(LoginUserInfo loginUserInfo)
        {
            return false;
        }

    }
}
