using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Securitys.SSO;
using Legendigital.Framework.Common.Utility;
using SNFramework.BSF.images;

namespace SNFramework.BSF.MainPage
{
    public partial class Login : BaseSecurityPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (X.IsAjaxRequest)
                return;

            SystemSettingWrapper settingWrapper = SystemSettingWrapper.GetCurrentSystemSetting();

            extwinLogin.Title = settingWrapper.LocaLocalizationName + " " + settingWrapper.SystemVersion;

            if (!Request.Browser.Cookies)
            {
                this.lblSupportMessage.Text = "您的浏览器设置已被禁用 Cookies，您必须设置浏览器允许使用 Cookies 选项后才能使用本系统。";
                this.btnLogin.Disabled = true;
                this.btnReset.Disabled = true;
                return;
            }
            else
            {
                this.lblSupportMessage.Text = "推荐使用谷歌浏览器(Google Chrome)浏览本系统.";
                this.btnLogin.Disabled = false;
                this.btnReset.Disabled = false;
                return;      
            }
 
        }

 

        protected void BtnLogin_Click(object sender, DirectEventArgs e)
        {

            string loginID = this.txtUserName.Text.Trim();
            string password = this.txtPassWord.Text.Trim();
            string checkCode = this.txtCheckCode.Text.Trim();

            if (checkCode != CheckCode.GetCheckCode())
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = "验证码错误！";
                return;
            }

            SystemUserWrapper userWrapper = SystemUserWrapper.FindByLoginID(loginID);

            if (userWrapper == null)
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString();
                SystemLogWrapper.LogUserLoginFailed(loginID, HttpUtil.GetIP(this.Request), GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString(), System.DateTime.Now);
                return;
            }

            if (userWrapper.IsLockedOut)
            {
                if (SystemUserWrapper.CheckUserIfDeveloperAdminOrSystemAdmin(loginID))
                {
                    SystemUserWrapper.UnlockUser(loginID);
                }
                else
                {
                    ResourceManager.AjaxSuccess = false;
                    ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgLoginFailedUserLockError").ToString();
                    SystemLogWrapper.LogUserLoginFailed(loginID, HttpUtil.GetIP(this.Request), GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString(), System.DateTime.Now);
                    return;
                }
            }


            if (!Membership.ValidateUser(loginID, password))
            {
                ResourceManager.AjaxSuccess = false;
                ResourceManager.AjaxErrorMessage = GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString();
                SystemLogWrapper.LogUserLoginFailed(loginID, HttpUtil.GetIP(this.Request), GetLocalResourceObject("msgLoginFailedUserPasswordError").ToString(), System.DateTime.Now);
                return;
            }

            LoginUser(loginID);
        }


        private void LoginUser(string loginID)
        {
            SystemUserWrapper userWrapper = SystemUserWrapper.GetInitalUserByLoginID(loginID);

            ClearLoginInfo();

            FormsAuthentication.SetAuthCookie(userWrapper.UserLoginID,
                                              false);

            //UserCurrentLoginId = userWrapper.UserLoginID;

            string ssoKey = SSOProvider.GenerateSSOKey(userWrapper.UserLoginID);

            string ipaddress = HttpUtil.GetIP(this.Request);
            DateTime loginDate = System.DateTime.Now;

            SSOTokenInfo ssoTokenInfo = new SSOTokenInfo();

            ssoTokenInfo.LoginUserKey = userWrapper.UserID;
            ssoTokenInfo.LoginUserID = userWrapper.UserLoginID;
            ssoTokenInfo.IPAddress = ipaddress;
            ssoTokenInfo.LoginDate = loginDate;
            ssoTokenInfo.Password = "";
            ssoTokenInfo.UserType = SSOUserType.NormalUser;
            ssoTokenInfo.SSOKey = ssoKey;
            ssoTokenInfo.Email = userWrapper.UserEmail;

            SystemLogWrapper.LogUserLoginSuccessed(userWrapper, ipaddress, loginDate);
 
            string token = SSOProvider.GetSSFToken(ssoTokenInfo, ssoKey);

            Response.Redirect(FormsAuthentication.DefaultUrl + "?" + SSOProvider.QUERY_STRING_NAME_SSFToken + "=" + HttpUtility.UrlEncode(token));
        }

        //protected string UserCurrentLoginId
        //{
        //    get
        //    {
        //        HttpCookie Cookie = Request.Cookies["CurrentLoginId"];

        //        if (Cookie != null)
        //        {
        //            return Cookie.Value;
        //        }
        //        else
        //        {
        //            return string.Empty;
        //        }
        //    }
        //    set
        //    {
        //        if (Response.Cookies["CurrentLoginId"] != null)
        //        {
        //            HttpCookie cookie = Response.Cookies["CurrentLoginId"];
        //            cookie.Value = value;
        //            cookie.Expires = DateTime.Now.AddDays(180);
        //        }
        //        else
        //        {
        //            HttpCookie cookie = new HttpCookie("CurrentLoginId");
        //            cookie.Value = value;
        //            cookie.Expires = DateTime.Now.AddDays(180);

        //        }
        //    }
        //}

    }
}