using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.UI.WebControls.WebParts;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Utility;

namespace Legendigital.Framework.Common.BaseFramework.Providers
{
    public class NhibernatePersonalizationProvider : PersonalizationProvider 
    {
        private SystemApplicationWrapper application = new SystemApplicationWrapper();

        public override PersonalizationStateInfoCollection FindState(PersonalizationScope scope, PersonalizationStateQuery query, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new System.NotImplementedException();
        }

        public override int GetCountOfState(PersonalizationScope scope, PersonalizationStateQuery query)
        {
            throw new System.NotImplementedException();
        }

        protected override void LoadPersonalizationBlobs(WebPartManager webPartManager, string path, string userName, ref byte[] sharedDataBlob, ref byte[] userDataBlob)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");

            SystemPersonalizationSettingsWrapper.LoadPersonalizationBlobs(path, userName, ref userDataBlob);
        }

        protected override void ResetPersonalizationBlob(WebPartManager webPartManager, string path, string userName)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");

            SystemPersonalizationSettingsWrapper.ResetPersonalizationBlob(path, userName);
        }

        public override int ResetState(PersonalizationScope scope, string[] paths, string[] usernames)
        {
            throw new System.NotImplementedException();
        }

        public override int ResetUserState(string path, DateTime userInactiveSinceDate)
        {
            throw new System.NotImplementedException();
        }

        protected override void SavePersonalizationBlob(WebPartManager webPartManager, string path, string userName, byte[] dataBlob)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentNullException("path");

            if (string.IsNullOrEmpty(userName))
                throw new ArgumentNullException("userName");

            SystemPersonalizationSettingsWrapper.SavePersonalizationBlob(path, userName, ref dataBlob);
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "NhibernatePersonalizationProvider";
            }
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NHibernate Personalization Provider");
            }
            base.Initialize(name, config);
            application =
                SystemApplicationWrapper.CreateOrLoadApplication(
                    ConfigurationUtil.GetConfigValue(config["applicationName"],
                                                     HostingEnvironment.ApplicationVirtualPath));
        }

        public override string ApplicationName
        {
            get { return application.SystemApplicationName; }
            set { application.SystemApplicationName = value; }
        }
    }
}