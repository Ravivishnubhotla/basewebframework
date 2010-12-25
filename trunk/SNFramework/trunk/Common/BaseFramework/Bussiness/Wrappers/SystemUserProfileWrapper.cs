
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Web.Profile;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Spring.Context.Support;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemUserProfileWrapper
    {
        #region Static Common Data Operation

        internal static readonly ISystemUserServiceProxy userBusinessProxy = ((Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)(ContextRegistry.GetContext().GetObject("BaseFrameworkServiceProxyContainerIocID", typeof(Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables.Container.BaseFrameworkServiceProxyContainer)))).SystemUserServiceProxyInstance;
		
		public static void Save(SystemUserProfileWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemUserProfileWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemUserProfileWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }

        public static void DeleteByID(object id)
        {
            businessProxy.DeleteByID(id);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            businessProxy.PatchDeleteByIDs(ids);
        }

        public static void Delete(SystemUserProfileWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemUserProfileWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemUserProfileWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemUserProfileWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemUserProfileWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemUserProfileEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemUserProfileWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemUserProfileWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemUserProfileWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   pageQueryParams));

            return results;
        }
		

		
		#endregion

	    public static int DeleteProfiles(string[] usernames)
	    {
	        try
	        {
	            businessProxy.DeleteProfiles(usernames);
                return 1;

	        }
	        catch (Exception ex)
	        {
                Logger.Error(ex);
                return 0;    
	        }
	    }



        internal static int DeleteProfiles(System.Web.Profile.ProfileInfoCollection profiles)
        {
            List<string> listUserName = new List<string>();

            listUserName.Add(profiles["UserName"].ToString());
            
            try
            {
                businessProxy.DeleteProfiles(listUserName.ToArray());
                return 1;

            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
        }

        public static int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption, DateTime userInactiveSinceDate)
	    {
            try
            {
                businessProxy.DeleteInactiveProfiles(authenticationOption, userInactiveSinceDate);
                return 1;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                return 0;
            }
	    }

	    public static ProfileInfoCollection GetAllInactiveProfiles(ProfileAuthenticationOption profileAuthenticationOption, DateTime inactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
	    {
            ProfileInfoCollection infos = new ProfileInfoCollection();
            List<SystemUserProfileEntity> profiles = businessProxy.GetAllInactiveProfiles(profileAuthenticationOption, inactiveSinceDate, pageIndex, pageSize,out totalRecords);
            foreach (SystemUserProfileEntity prof in profiles)
            {
                SystemUserEntity userEntity = userBusinessProxy.FindById(prof.UserID);

                infos.Add(new ProfileInfo(userEntity.UserLoginID, false, userEntity.LastActivityDate, prof.LastUpdatedDate, 2000));
            }
            return infos;
	    }

	    public static ProfileInfoCollection FindProfilesByUserName(ProfileAuthenticationOption profileAuthenticationOption, string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
	    {
            return businessProxy.FindProfilesByUserName(profileAuthenticationOption, usernameToMatch, pageIndex, pageSize, out totalRecords);
	    }

	    public static ProfileInfoCollection FindInactiveProfilesByUserName(ProfileAuthenticationOption profileAuthenticationOption, string usernameToMatch, DateTime inactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
	    {
            return businessProxy.FindInactiveProfilesByUserName(profileAuthenticationOption, usernameToMatch, inactiveSinceDate, pageIndex, pageSize, out totalRecords);
	    }

        public static int GetNumberOfInactiveProfiles(ProfileAuthenticationOption profileAuthenticationOption, DateTime inactiveSinceDate)
	    {
            return businessProxy.GetNumberOfInactiveProfiles(profileAuthenticationOption, inactiveSinceDate);
	    }

	    public static SettingsPropertyValueCollection GetPropertyValues(SettingsContext settingsContext, SettingsPropertyCollection settingsPropertyCollection)
	    {
	        return businessProxy.GetPropertyValues(settingsContext, settingsPropertyCollection);
	    }

	    public static void SetPropertyValues(SettingsContext context, SettingsPropertyValueCollection settingsPropertyValueCollection)
	    {
	        businessProxy.SetPropertyValues(context, settingsPropertyValueCollection);
	    }
    }
}
