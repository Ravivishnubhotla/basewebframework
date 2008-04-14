using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;

namespace Powerasp.Enterprise.Core.Web.Security
{
    public class WebLoginPermissionModule : IHttpModule
    {

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="app"></param>
        public void Init(HttpApplication app)
        {
            app.AuthenticateRequest += new EventHandler(app_AuthMethod);
            app.AuthorizeRequest += new EventHandler(app_Auth);
        }

        /// <summary>
        /// 设置方法属性权限检测数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void app_AuthMethod(object sender, EventArgs e)
        {

            //检测方法权限设置
            HttpApplication App = (HttpApplication)sender;
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = App.Context.Request.Cookies[cookieName];

            if (null == authCookie)
            {
                // 沒有驗證 Cookie。
                return;
            }

            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            if (null == authTicket)
            {
                // Cookie 無法解密。
                return;
            }

            // 建立 Identity 物件
            FormsIdentity id = new FormsIdentity(authTicket);

            List<string> listRole = new List<string>();
            listRole.Add("文章管理员");
            listRole.Add("图片管理员");
            App.Context.User = new LoginPermissionPrincipal(id, listRole);

        }

        /// <summary>
        /// 处理认证成功事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void app_Auth(object sender, EventArgs e)
        {

            ////判断
            //if (Common.GetScriptNameExt.ToLower() == "aspx" && Common.Get_UserID != 0)
            //{
            //    //判断在线用户

            //    if (UserOnlineList.CheckMemberOnline(UserData.Get_sys_UserTable(Common.Get_UserID).U_LoginName.ToLower(), Common.CookiesGuid))
            //    {
            //        UserOnlineList.Access(Common.CookiesGuid, Common.GetScriptUrl);
            //    }
            //    else
            //    {
            //        if (Common.OnlineMinute != 0)
            //        {
            //            FrameWorkLogin.UserOut();
            //            MessageBox MBx = new MessageBox();
            //            MBx.M_Type = 2;
            //            MBx.M_Title = "没有登陆!";
            //            MBx.M_IconType = Icon_Type.Error;
            //            MBx.M_Body = "您已经被系统强制退出！";
            //            MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "~/default.aspx", "", UrlType.Href, true));
            //            EventMessage.MessageBox(MBx);
            //        }
            //    }

            //    //检测权限
            //    if (!Check_Permission)
            //    {
            //        MessageBox MBx = new MessageBox();
            //        MBx.M_Type = 2;
            //        MBx.M_Title = "权限出错";
            //        MBx.M_IconType = Icon_Type.Error;
            //        MBx.M_Body = "无权访问当前页面！";
            //        MBx.M_ButtonList.Add(new sys_NavigationUrl("返回", "history.back();", "", UrlType.JavaScript, true));
            //        EventMessage.MessageBox(MBx);
            //    }

            //    //更新当前用户最后访问记录
            //    BusinessFacade.Update_Table_Fileds("sys_User", string.Format("U_LastIP='{0}',U_LastDateTime='{1}'", Common.GetIPAddress(), DateTime.Now), string.Format("UserID={0}", Common.Get_UserID));

            //    //写访问日志
            //    if (FrameSystemInfo.GetSystemInfoTable.S_SystemConfigData.C_RequestLog)
            //        EventMessage.EventWriteDB(3, "访问网页");
            //}
        }



        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {

        }
    }
}
