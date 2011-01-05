using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSite.Models;

namespace WebSite.Controllers
{
    public class AccountController : BaseMVCControler
    {
        
        //
        // GET: /Account/

        public ActionResult ChangePersonalSeting()
        {
            if(!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }

        public ActionResult MyMessage()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }

        public ActionResult NeedLoginPage()
        {
            return View();
        }


        public ActionResult MyFriend()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }
        
        public ActionResult SouTou()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }

        public ActionResult GetMyAddress()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }



        public ActionResult Boy()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }


        public ActionResult BoyGril()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }



        public ActionResult Gril()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }



        public ActionResult ViewVideo()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }


        public ActionResult SearchF()
        {


            return View();
        }

        public ActionResult SearchResult()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }


        public ActionResult Suggest()
        {
            if (!this.IsLogin())
                return RedirectToAction("NeedLoginPage", "Account");

            return View();
        }

        



            

        

    }
}
