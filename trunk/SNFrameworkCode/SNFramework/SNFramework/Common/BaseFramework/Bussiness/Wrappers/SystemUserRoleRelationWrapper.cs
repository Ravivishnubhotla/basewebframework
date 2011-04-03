
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
    public partial class SystemUserRoleRelationWrapper
    {
        #region Static Common Data Operation

        public static void Save(SystemUserRoleRelationWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemUserRoleRelationWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemUserRoleRelationWrapper obj)
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

        public static void Delete(SystemUserRoleRelationWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemUserRoleRelationWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemUserRoleRelationWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemUserRoleRelationWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemUserRoleRelationWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemUserRoleRelationEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemUserRoleRelationWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemUserRoleRelationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemUserRoleRelationWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams));

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

                    userWrappers = SystemUserWrapper.ConvertToWrapperList(businessProxy.GetUserByRole(systemRoleWrapper.entity));

                }
                else
                {

                    userWrappers.Add(systemUser);

                }


            return userWrappers;
        }

    }
}
