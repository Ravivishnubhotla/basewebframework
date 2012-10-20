using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Xml;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Framework.Common.Securitys.SSO
{
    /// <summary>
    /// 登陆类型（指常规登陆还是key登陆，手机登陆）
    /// </summary>
    public enum LoginType
    {
        /// <summary>
        /// 普通登陆
        /// </summary>
        Normal = 1,
        /// <summary>
        /// 通过Key登陆
        /// </summary>
        UseKey = 2
    }
    /// <summary>
    /// 子页面验证方式
    /// </summary>
    public enum SecurityMode
    {
        /// <summary>
        /// 需要验证
        /// </summary>
        Authentication = 1,
        /// <summary>
        /// 不需要验证
        /// </summary>
        None = 2
    }

    public enum SSOUserType
    {
        NormalUser,
        SystemUser,
        SuperUser
    }

    public enum LoginError
    {
        NoPermissionForPage = 0,
        HasLoginInOtherPlace = 1,
        TokenExpired = 2,
        TokenWrong = 3
    }

    public class SSOProvider
    {
        public const string QUERY_STRING_NAME_SSFToken = "_SSFToken";
        public const string Session_Key_LoginUser = "CurrentLoginUser";
        /// <summary>
        /// Token的有效期，单位小时
        /// </summary>
        public static int SSFTokenValidationPeriod = 24;


        /// <summary>
        /// 密码加密密钥
        /// </summary>
        internal static string m_PasswordEncyptKey = "eKqebkPS";


        /// <summary>
        /// AES 256bit加密，密钥需要32位
        /// </summary>
        private static string m_EncyptKey = "PCpJwIBGsHrbTCwqWgGGrYdBpiFVqjcA";
        /// <summary>
        /// AES 256bit加密，密钥需要32位
        /// </summary>
        private static string m_SSFTokenKey = "PCpJwIBGsHrbTCwqWgGGrYdBpiFVqjcA";

        public static string GetSSFToken(SSOTokenInfo ssoTokenInfo)
        {
            return CryptographyUtil.EncryptDES(SerializeUtil.ToJson(ssoTokenInfo), m_SSFTokenKey);
        }

        /// <summary>
        /// 返回从Token中出来的用户名和密码
        /// </summary>
        /// <param name="SSFToken"></param>
        /// <returns></returns>
        internal static SSOTokenInfo GetInfoFromSSFToken(string ssfToken)
        {
            return SerializeUtil.JsonDeserialize<SSOTokenInfo>(CryptographyUtil.DecryptDES(ssfToken, m_SSFTokenKey));
        }

        public static object GetSessionValue(string sessionName)
        {
            return HttpContext.Current.Session[sessionName];
        }

        public static void SetSessionValue(string sessionKeyLoginUser, SSOTokenInfo tokenInfo)
        {
            HttpContext.Current.Session[sessionKeyLoginUser] = tokenInfo;
        }


        /// <summary>
        /// 生成登录的SSOKey，只在登录时调用一次
        /// </summary>
        /// <returns></returns>
        public static string GenerateSSOKey(string userLoginID)
        {
            return SystemUserWrapper.GenerateSSOKey(userLoginID);
        }

        public static string GetSSOKeyFromPage(Page page)
        {
            if (HttpContext.Current.User == null)
                return "";

            if (HttpContext.Current.User.Identity == null)
                return "";

            if (string.IsNullOrEmpty(HttpContext.Current.User.Identity.Name))
                return "";

            if (HttpContext.Current.Session["SSOKey"] != null)
                return (string)HttpContext.Current.Session["SSOKey"];

            string ssf_Token_QueryString = page.Request.QueryString[QUERY_STRING_NAME_SSFToken];

            object ssf_Token_Session =GetSessionValue(Session_Key_LoginUser);

            string string_Token = "";///看优先选用哪一个token

            if (string.IsNullOrEmpty(ssf_Token_QueryString))
            {
                string_Token = ssf_Token_Session.ToString();
            }
            else
            {
                string_Token = ssf_Token_QueryString;
            }

            HttpContext.Current.Session["SSOKey"] = string_Token;

            return string_Token;
        }


        public static void RedirectToBSFDefaultUrl(Page page)
        {
            string redirectDefaultUrl = UrlUtil.CombineWebUrl(SSOConfig.BSFWebRoot,
                                                              AddSSFTokenToUrl(
                                                                  page.ResolveUrl(FormsAuthentication.DefaultUrl), GetSSOKeyFromPage(page)));
            page.Response.Redirect(redirectDefaultUrl);
        }

        public static void RedirectToBSFLoginUrl(Page page)
        {
            string redirectDefaultUrl = UrlUtil.CombineWebUrl(SSOConfig.BSFWebRoot,
                                                  AddSSFTokenToUrl(
                                                      page.ResolveUrl(FormsAuthentication.LoginUrl), GetSSOKeyFromPage(page)));
            page.Response.Redirect(redirectDefaultUrl);
        }

        public static string AddSSFTokenToUrl(string url, string ssoKey)
        {
            if (url.Contains("?"))
            {
                url = url + "&" + SSOProvider.QUERY_STRING_NAME_SSFToken + "=" + HttpUtility.UrlEncode(ssoKey);
            }
            else
            {
                url = url + "?" + SSOProvider.QUERY_STRING_NAME_SSFToken + "=" + HttpUtility.UrlEncode(ssoKey);
            }
            return url;
        }
    }
}
