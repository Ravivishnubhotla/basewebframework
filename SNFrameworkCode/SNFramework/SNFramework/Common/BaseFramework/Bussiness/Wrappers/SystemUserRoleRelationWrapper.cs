
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
    [Serializable]
    public partial class SystemUserRoleRelationWrapper : BaseSpringNHibernateWrapper<SystemUserRoleRelationEntity, ISystemUserRoleRelationServiceProxy, SystemUserRoleRelationWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SystemUserRoleRelationWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemUserRoleRelationWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemUserRoleRelationWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(object id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SystemUserRoleRelationWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemUserRoleRelationWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemUserRoleRelationWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemUserRoleRelationWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemUserRoleRelationWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemUserRoleRelationWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SystemUserRoleRelationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemUserRoleRelationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemUserRoleRelationWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion

        public static List<SystemUserWrapper> GetUserByUserLoginId(string userLoginId)
        {
            SystemUserWrapper systemUser = SystemUserWrapper.GetUserByLoginID(userLoginId);

            SystemRoleWrapper systemRoleWrapper = SystemUserWrapper.GetUserMaxRoleTypeRole(systemUser);

            

            List<SystemUserWrapper> userWrappers = new List<SystemUserWrapper>();



            if (userLoginId == SystemUserWrapper.DEV_USER_ID || userLoginId == SystemUserWrapper.SYS_USER_ID)
            {
                userWrappers = SystemUserWrapper.FindAll();
            }


            else
                if (systemRoleWrapper.RoleType !="5" )
                {

                    userWrappers = SystemUserWrapper.ConvertToWrapperList(businessProxy.GetUserByRole(systemRoleWrapper.Entity));

                }
                else
                {

                    userWrappers.Add(systemUser);

                }


            return userWrappers;
        }

    }
}
