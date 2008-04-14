using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.BaseDomain;
using Powerasp.Enterprise.Core.BaseManager.BaseService;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.CustomException;
using Powerasp.Enterprise.Core.Utility;
using Powerasp.Enterprise.Core.Web.Security;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    [Transactional]
    public class SystemUserService : SystemUserBaseService
    {

        protected const string DEV_USER_ID = "DeveloperAdministrator";
        protected const string SYS_USER_ID = "SystemAdministrator";
        private SystemRoleDao systemRoleDaoInstance;
        private SystemUserRoleRelationDao systemUserRoleRelationDaoInstance;

        public SystemUserService(SystemUserDao selfDao)
            : base(selfDao)
        {
        }

        public void AuthenticateRequestUser()
        {
            FormsAuthenticationTicket authTicket = this.GetTicket(HttpContext.Current);
            if (null != authTicket)
            {
                FormsIdentity id = new FormsIdentity(authTicket);
                Pair userData = this.GetUserData(HttpContext.Current);
                List<SystemRole> roles = null;
                SystemUser systemUser = null;
                if (userData != null)
                {
                    roles = (List<SystemRole>)userData.Second;
                    systemUser = (SystemUser)userData.First;
                }
                else
                {
                    roles = new List<SystemRole>();
                    systemUser = null;
                }
                HttpContext.Current.Items["Context_Key_LoginUser"] = systemUser;
                HttpContext.Current.Items["Context_Key_LoginUserAssignRole"] = roles;
                List<string> listRoleName = new List<string>();
                foreach (SystemRole role in roles)
                {
                    listRoleName.Add(role.RoleName);
                }
                HttpContext.Current.User = new LoginPermissionPrincipal(id, listRoleName);
            }
        }

        public override void Create(SystemUser obj)
        {
            if (obj.UserLoginID.Equals("DeveloperAdministrator"))
            {
                throw new DataValidationException(" Login ID ¡±DeveloperAdministrator¡° has exist¡£");
            }
            if (obj.UserLoginID.Equals("SystemAdministrator"))
            {
                throw new DataValidationException(" Login ID ¡±SystemAdministrator¡° has exist¡£");
            }
            if (base.SelfDao.GetUserByLoginID(obj.UserLoginID) != null)
            {
                throw new DataValidationException(" Login ID ¡±" + obj.UserLoginID + "¡° has exist¡£");
            }
            base.Create(obj);
        }

        public SystemUser GetCurrentLoginUser()
        {
            if (HttpContext.Current.Items["Context_Key_LoginUser"] == null)
            {
                return null;
            }
            return (SystemUser)HttpContext.Current.Items["Context_Key_LoginUser"];
        }

        public List<SystemRole> GetCurrentLoginUserAssignedRole()
        {
            if (HttpContext.Current.Items["Context_Key_LoginUserAssignRole"] == null)
            {
                return new List<SystemRole>();
            }
            return (List<SystemRole>)HttpContext.Current.Items["Context_Key_LoginUserAssignRole"];
        }

        private FormsAuthenticationTicket GetTicket(HttpContext context)
        {
            string cookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = context.Request.Cookies[cookieName];
            if (null == authCookie)
            {
                return null;
            }
            FormsAuthenticationTicket authTicket = null;
            try
            {
                authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            }
            catch (Exception ex)
            {
                base.Logger.Error(ex.Message);
                return null;
            }
            return authTicket;
        }

        public List<SystemRole> GetUserAssignedRoleByUserLoginID(string loginID)
        {
            SystemUser user = base.SelfDao.GetUserByLoginID(loginID);
            List<SystemRole> list = this.systemUserRoleRelationDaoInstance.GetUserAssignRole(user);
            foreach (SystemRole role in list)
            {
                this.systemRoleDaoInstance.InitializeLazyProperty(role, SystemRole.PROPERTY_NAME_ROLEID);
                this.systemRoleDaoInstance.InitializeLazyProperty(role, SystemRole.PROPERTY_NAME_ROLENAME);
                this.systemRoleDaoInstance.InitializeLazyProperty(role, SystemRole.PROPERTY_NAME_ROLEDESCRIPTION);
                this.systemRoleDaoInstance.InitializeLazyProperty(role, SystemRole.PROPERTY_NAME_ROLEISSYSTEMROLE);
            }
            return list;
        }

        public SystemUser GetUserByLoginIDAndPassword(string loginID, string password)
        {
            SystemUser findUser = base.SelfDao.GetUserByLoginIDAndPassword(loginID, password);
            if ((findUser != null) && findUser.UserPassword.Equals(password))
            {
                return findUser;
            }
            return null;
        }

        private Pair GetUserData(HttpContext context)
        {
            if (context.Request.Cookies[FormsAuthentication.FormsCookieName + "UserInfo"] == null)
            {
                return null;
            }
            return SerializableUtil.ConvertZipedBase64StringToObject<Pair>(context.Request.Cookies[FormsAuthentication.FormsCookieName + "UserInfo"].Value);
        }

        public string WebUserLoginIn(SystemUser systemUser, bool persistentUser, HttpContext context)
        {
            List<SystemRole> listRole = this.systemUserRoleRelationDaoInstance.GetUserAssignRole(systemUser);
            Pair pair = new Pair(systemUser, listRole);
            string userInfo = SerializableUtil.ConvertObjectToZipedBase64String<Pair>(pair);
            HttpCookie userC = new HttpCookie(FormsAuthentication.FormsCookieName + "UserInfo", userInfo);
            context.Response.Cookies.Add(userC);
            FormsAuthenticationTicket tk = new FormsAuthenticationTicket(1, systemUser.UserLoginID.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30.0), persistentUser, "", FormsAuthentication.FormsCookiePath);
            string key = FormsAuthentication.Encrypt(tk);
            HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, key);
            context.Response.Cookies.Add(ck);
            return FormsAuthentication.GetRedirectUrl(systemUser.UserLoginID.ToString(), persistentUser);
        }

        public void WebUserLoginOut(HttpContext context)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        public SystemRoleDao SystemRoleDaoInstance
        {
            set
            {
                this.systemRoleDaoInstance = value;
            }
        }

        public SystemUserRoleRelationDao SystemUserRoleRelationDaoInstance
        {
            set
            {
                this.systemUserRoleRelationDaoInstance = value;
            }
        }
    }
}
