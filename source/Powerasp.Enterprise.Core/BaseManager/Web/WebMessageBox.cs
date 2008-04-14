using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Powerasp.Enterprise.Core.Utility;

namespace Powerasp.Enterprise.Core.BaseManager.Web
{
    public static class WebMessageBox
    {
        private const string CookiesWebMessageKeyName = "TransMessageBoxValue";

        private static readonly string WebMessageUrl = "~/MainPage/MessageBoxs.aspx";

        static WebMessageBox()
        {
        }


        public static WebMessage CurrentWebMessage
        {
            get
            {
                if (HttpContext.Current.Request.Cookies[CookiesWebMessageKeyName] != null)
                {
                    string MessageValue = HttpContext.Current.Request.Cookies[CookiesWebMessageKeyName].Value.ToString();

                    if (MessageValue != "")
                        return SerializableUtil.ConvertZipedBase64StringToObject<WebMessage>(MessageValue);
                    else
                        return null;
                }
                else
                    return null;
            }
            set
            {
                HttpContext.Current.Response.Cookies[CookiesWebMessageKeyName].Value = SerializableUtil.ConvertObjectToZipedBase64String<WebMessage>(value);
            }
        }

        /// <summary>
        /// 信息提示
        /// </summary>
        /// <param name="message">信息提示类</param>
        public static void ShowWebMessage(WebMessage message)
        {
            if (message.M_ButtonList.Count > 0)
            {
                WebMessageBox.CurrentWebMessage = message;
                HttpContext.Current.Response.Redirect(WebMessageUrl);
            }
        }


        /// <summary>
        /// 信息提示
        /// </summary>
        public static void ShowOperationOkMessage(string title,string message,string returnUrl)
        {
            WebMessage webMessage = new WebMessage();
            webMessage.M_Type = 1;
            webMessage.M_IconType = Icon_Type.OK;
            webMessage.M_Title = title;
            webMessage.M_Body = message;
            List<WebNavigationUrl> M_ButtonList = new List<WebNavigationUrl>();
            M_ButtonList.Add(new WebNavigationUrl("确定", returnUrl, "", UrlType.Href, true));
            webMessage.M_ButtonList = M_ButtonList;
            ShowWebMessage(webMessage);
        }

        public static void ShowOperationFailedMessage(string title, string message, string returnUrl)
        {
            WebMessage webMessage = new WebMessage();
            webMessage.M_Type = 1;
            webMessage.M_IconType = Icon_Type.Error;
            webMessage.M_Title = title;
            webMessage.M_Body = message;
            List<WebNavigationUrl> M_ButtonList = new List<WebNavigationUrl>();
            M_ButtonList.Add(new WebNavigationUrl("确定", returnUrl, "", UrlType.Href, true));
            webMessage.M_ButtonList = M_ButtonList;
            ShowWebMessage(webMessage);
        }

        public static void ShowOperationFailedMessageAndHistoryBack(string title, string message)
        {
            WebMessage webMessage = new WebMessage();
            webMessage.M_Type = 1;
            webMessage.M_IconType = Icon_Type.Error;
            webMessage.M_Title = title;
            webMessage.M_Body = message;
            List<WebNavigationUrl> M_ButtonList = new List<WebNavigationUrl>();
            M_ButtonList.Add(new WebNavigationUrl("确定", "window.history.back();", "", UrlType.JavaScript, true));
            webMessage.M_ButtonList = M_ButtonList;
            ShowWebMessage(webMessage);
        }
    }
}
