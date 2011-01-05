using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace WebSite.Models
{
    public class BaseMVCControler : Controller
    {
        public const string Session_Key_UserLogin = "Session_Key_UserLogin";
        public const string Session_Key_ValidateString = "Session_Key_ValidateString";

 

        public bool IsLogin()
        {
            if(this.Session[Session_Key_UserLogin]==null)
                return false;

            return false;
        }


        private LoginResult CheckUserLogin(string loginID, string password)
        {
            return null;
        }

        private LoginUserMemberShip GetUserMemberShipByLoginID(string loginID)
        {
            return null;
        }

        private void AuthorizeLoginUser(string loginID)
        {
            this.Session[Session_Key_UserLogin] = GetUserMemberShipByLoginID(loginID);
 
        }

        private void SignOutnUser(string loginID)
        {
            this.Session.Remove(Session_Key_UserLogin);
        }






 

    }
}