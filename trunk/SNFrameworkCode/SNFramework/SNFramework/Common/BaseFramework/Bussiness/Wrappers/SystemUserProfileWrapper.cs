
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
    public partial class SystemUserProfileWrapper : BaseSpringNHibernateWrapper<SystemUserProfileEntity, ISystemUserProfileServiceProxy, SystemUserProfileWrapper, int>
    {
 
            #region Static Common Data Operation

            public static void Save(SystemUserProfileWrapper obj)
            {
                Save(obj, businessProxy);
            }

            public static void Update(SystemUserProfileWrapper obj)
            {
                Update(obj, businessProxy);
            }

            public static void SaveOrUpdate(SystemUserProfileWrapper obj)
            {
                SaveOrUpdate(obj, businessProxy);
            }

            public static void DeleteAll()
            {
                DeleteAll(businessProxy);
            }

            public static void DeleteByID(int id)
            {
                DeleteByID(id, businessProxy);
            }

            public static void PatchDeleteByIDs(int[] ids)
            {

                PatchDeleteByIDs(ids, businessProxy);
            }

            public static void Delete(SystemUserProfileWrapper instance)
            {
                Delete(instance, businessProxy);
            }

            public static void Refresh(SystemUserProfileWrapper instance)
            {
                Refresh(instance, businessProxy);
            }

            public static SystemUserProfileWrapper FindById(int id)
            {
                return ConvertEntityToWrapper(FindById(id, businessProxy));
            }

            public static List<SystemUserProfileWrapper> FindAll()
            {
                return ConvertToWrapperList(FindAll(businessProxy));
            }

            public static List<SystemUserProfileWrapper> FindAllByPage(PageQueryParams pageQueryParams)
            {
                return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
            }

            public static List<SystemUserProfileWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc,
                                                                          PageQueryParams pageQueryParams)
            {
                orderByColumnName = ProcessColumnName(orderByColumnName);

                return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
            }


            public static List<SystemUserProfileWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters,
                                                                                   string orderByColumnName, bool isDesc,
                                                                                   PageQueryParams pageQueryParams)
            {
                orderByColumnName = ProcessColumnName(orderByColumnName);

                ProcessQueryFilters(filters);

                return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));              
            }


            public static List<SystemUserProfileWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters,
                                                                                   string orderByFieldName, bool isDesc)
            {
                orderByFieldName = ProcessColumnName(orderByFieldName);

                ProcessQueryFilters(filters);

                return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
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

            public static int DeleteInactiveProfiles(ProfileAuthenticationOption authenticationOption,
                                                     DateTime userInactiveSinceDate)
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

            public static ProfileInfoCollection GetAllInactiveProfiles(
                ProfileAuthenticationOption profileAuthenticationOption, DateTime inactiveSinceDate, int pageIndex,
                int pageSize, out int totalRecords)
            {
                ProfileInfoCollection infos = new ProfileInfoCollection();
                List<SystemUserProfileEntity> profiles =
                    businessProxy.GetAllInactiveProfiles(profileAuthenticationOption, inactiveSinceDate, pageIndex,
                                                         pageSize, out totalRecords);
                foreach (SystemUserProfileEntity prof in profiles)
                {
                    SystemUserWrapper user = SystemUserWrapper.FindById(prof.UserID.UserID);

                    infos.Add(new ProfileInfo(user.UserLoginID, false, user.LastActivityDate,
                                              prof.LastUpdatedDate, 2000));
                }
                return infos;
            }

            public static ProfileInfoCollection FindProfilesByUserName(
                ProfileAuthenticationOption profileAuthenticationOption, string usernameToMatch, int pageIndex,
                int pageSize, out int totalRecords)
            {
                return businessProxy.FindProfilesByUserName(profileAuthenticationOption, usernameToMatch, pageIndex,
                                                            pageSize, out totalRecords);
            }

            public static ProfileInfoCollection FindInactiveProfilesByUserName(
                ProfileAuthenticationOption profileAuthenticationOption, string usernameToMatch,
                DateTime inactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
            {
                return businessProxy.FindInactiveProfilesByUserName(profileAuthenticationOption, usernameToMatch,
                                                                    inactiveSinceDate, pageIndex, pageSize,
                                                                    out totalRecords);
            }

            public static int GetNumberOfInactiveProfiles(ProfileAuthenticationOption profileAuthenticationOption,
                                                          DateTime inactiveSinceDate)
            {
                return businessProxy.GetNumberOfInactiveProfiles(profileAuthenticationOption, inactiveSinceDate);
            }

            public static SettingsPropertyValueCollection GetPropertyValues(SettingsContext settingsContext,
                                                                            SettingsPropertyCollection
                                                                                settingsPropertyCollection)
            {
                return businessProxy.GetPropertyValues(settingsContext, settingsPropertyCollection);
            }

            public static void SetPropertyValues(SettingsContext context,
                                                 SettingsPropertyValueCollection settingsPropertyValueCollection)
            {
                businessProxy.SetPropertyValues(context, settingsPropertyValueCollection);
            }
        }
 
}
