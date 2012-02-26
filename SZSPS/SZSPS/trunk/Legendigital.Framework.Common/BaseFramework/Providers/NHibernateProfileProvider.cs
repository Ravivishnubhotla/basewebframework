using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.Profile;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Framework.Common.BaseFramework.Providers
{
    public class NHibernateProfileProvider : ProfileProvider
    {
        public override void Initialize(string name, NameValueCollection config)
        {
            if (null == config)
            {
                throw (new ArgumentNullException("config"));
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "NHibernateProfileProvider";
            }
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NHibernate Profile Provider");
            }

            base.Initialize(name, config);

            application =
                SystemApplicationWrapper.CreateOrLoadApplication(
                    ConfigurationUtil.GetConfigValue(config["applicationName"], HostingEnvironment.ApplicationVirtualPath));
        }

        public override SettingsPropertyValueCollection GetPropertyValues(SettingsContext context, SettingsPropertyCollection collection)
        {
            return SystemUserProfileWrapper.GetPropertyValues(context, collection);
        }



        public override void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection collection)
        {
            SystemUserProfileWrapper.SetPropertyValues(context, collection);
        }

        private SystemApplicationWrapper application = new SystemApplicationWrapper();

        public override string ApplicationName
        {
            get { return application.SystemApplicationName; }
            set { application.SystemApplicationName = value; }
        }

        public override int DeleteProfiles(ProfileInfoCollection profiles)
        {
            return SystemUserProfileWrapper.DeleteProfiles(profiles);
        }

        public override int DeleteProfiles(string[] usernames)
        {
            return SystemUserProfileWrapper.DeleteProfiles(usernames);
        }

        public override int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            return SystemUserProfileWrapper.DeleteInactiveProfiles(authenticationOption, userInactiveSinceDate);
        }

        public override int GetNumberOfInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
        {
            return SystemUserProfileWrapper.GetNumberOfInactiveProfiles(authenticationOption, userInactiveSinceDate);
        }

        public override ProfileInfoCollection GetAllProfiles(ProfileAuthenticationOption authenticationOption, int pageIndex, int pageSize, out int totalRecords)
        {
            ProfileInfoCollection pc = new ProfileInfoCollection();

            totalRecords = 0;

            switch (authenticationOption)
            {
                case ProfileAuthenticationOption.All:
                    {
                        List<SystemUserWrapper> users = SystemUserWrapper.FindAll(((pageIndex - 1) * pageSize), pageSize, out totalRecords);

                        foreach (SystemUserWrapper user in users)
                        {
                            pc.Add(new ProfileInfo(user.UserLoginID, false, user.LastActivityDate, user.LastLoginDate, 0));                 
                        }

                        return pc;
                    };
                case ProfileAuthenticationOption.Anonymous:
                    {
                        return pc;
                    };
                case ProfileAuthenticationOption.Authenticated:
                    {
                        List<SystemUserWrapper> users = SystemUserWrapper.FindAuthenticatedUserAll(((pageIndex - 1) * pageSize), pageSize, out totalRecords);
                        foreach (SystemUserWrapper user in users)
                        {
                            pc.Add(new ProfileInfo(user.UserLoginID, false, user.LastActivityDate, user.LastLoginDate, 0));
                        }
                        return pc;
                    };
                default: return pc; 
            }

        }

        public override ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            return SystemUserProfileWrapper.GetAllInactiveProfiles(authenticationOption, userInactiveSinceDate, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            return SystemUserProfileWrapper.FindProfilesByUserName(authenticationOption, usernameToMatch, pageIndex, pageSize, out totalRecords);
        }

        public override ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption authenticationOption, string usernameToMatch, DateTime userInactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            return SystemUserProfileWrapper.FindInactiveProfilesByUserName(authenticationOption, usernameToMatch, userInactiveSinceDate, pageIndex, pageSize, out totalRecords);
        }
    }
}
