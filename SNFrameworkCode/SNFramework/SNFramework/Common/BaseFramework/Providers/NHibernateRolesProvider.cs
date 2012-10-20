using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.Security;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Exceptions;
using Legendigital.Framework.Common.Utility;
using Spring.Context.Support;

namespace Legendigital.Framework.Common.BaseFramework.Providers
{
    public class NHibernateRolesProvider : RoleProvider
    {
        private SystemApplicationWrapper application = new SystemApplicationWrapper();

        public override bool IsUserInRole(string username, string roleName)
        {   
            try
            {
                return SystemUserWrapper.IsUserInRole(username, roleName);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToFindUserInRole, exception);
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                return SystemUserWrapper.GetRolesForUser(username);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToGetRolesForUser, exception);
            }
        }

        public override void CreateRole(string roleName)
        {
            if (this.RoleExists(roleName))
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_AlreadyExists);
            }
            try
            {
                SystemRoleWrapper.CreateRole(roleName);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToCreate, exception);
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            if (throwOnPopulatedRole && (0 < this.GetUsersInRole(roleName).Length))
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, "role is not empty.");
            }
            try
            {
                return SystemRoleWrapper.DeleteRole(roleName, throwOnPopulatedRole);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToDelete, exception);
            }
        }

        public override bool RoleExists(string roleName)
        {
            try
            {
                return SystemRoleWrapper.RoleExists(roleName);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToCheckIfExists, exception);
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            int length = usernames.Length;
            if (length != roleNames.Length)
            {
                throw new ArgumentOutOfRangeException(NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this, NHibernateProviderSR.Role_UserRoleParamsNotSameLength));
            }
            try
            {
                SystemRoleWrapper.AddUsersToRoles(usernames, roleNames);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToAddUsersToRoles, exception);
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            int length = usernames.Length;
            if (length != roleNames.Length)
            {
                throw new ArgumentOutOfRangeException(NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this, NHibernateProviderSR.Role_UserRoleParamsNotSameLength));
            }
            try
            {
                SystemRoleWrapper.RemoveUsersFromRoles(usernames, roleNames);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToAddUsersToRoles, exception);
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            try
            {
                return SystemRoleWrapper.GetUsersInRole(roleName);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToGetUsersInRole, exception);
            }
        }

        public override string[] GetAllRoles()
        {
            try
            {
                return SystemRoleWrapper.GetAllRoles();
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToGetAllRoles, exception);
            }

        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            try
            {
                return SystemRoleWrapper.FindUsersInRole(roleName, usernameToMatch);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, NHibernateProviderSR.Role_UnableToFindUsersInRole, exception);
            }
        }


        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "NHibernateRoleProvider";
            }
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NHibernate Role Provider");
            }
            base.Initialize(name, config);
            application =
                SystemApplicationWrapper.CreateOrLoadApplication(SystemApplicationWrapper.BaseSystemApplicationName);
        }

        public override string ApplicationName
        {
            get { return application.SystemApplicationName; }
            set { application.SystemApplicationName = value; }
        }
    }
}