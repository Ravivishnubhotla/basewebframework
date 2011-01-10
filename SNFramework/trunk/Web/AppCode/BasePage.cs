using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.AppCode
{
    public class BasePage : System.Web.UI.Page
    {
        public const string Session_Key_UserLogin = "Session_Key_UserLogin";
        public const string Session_Key_ValidateString = "Session_Key_ValidateString";

        public LoginMemberShip LoginUser
        {
            get
            {
                if (this.Session[Session_Key_UserLogin] == null)
                    return null;
                return this.Session[Session_Key_UserLogin] as LoginMemberShip;
            }
        }

        public bool IsLogin
        {
            get{
                return (LoginUser != null);
            }
        }

        public bool CheckVerifyCode(string verifyCoded)
        {
            if (Session[Session_Key_ValidateString] == null)
                return false;

            return Session[Session_Key_ValidateString].ToString().ToLower().Equals(verifyCoded.ToLower());
        }


        public bool CheckUserLogin(string loginID, string password)
        {
            AuthorizeLoginUser(loginID);
            return true;
        }

        public LoginMemberShip GetUserMemberShipByLoginID(string loginID)
        {
            LoginMemberShip loginUser = new LoginMemberShip();
            loginUser.DataId = 1;
            loginUser.IsVip = false;
            loginUser.LoginId = loginID;
            return loginUser;
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