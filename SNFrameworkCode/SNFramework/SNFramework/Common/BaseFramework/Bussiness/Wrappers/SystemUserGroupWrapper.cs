
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
    public partial class SystemUserGroupWrapper : BaseSpringNHibernateWrapper<SystemUserGroupEntity, ISystemUserGroupServiceProxy, SystemUserGroupWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SystemUserGroupWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemUserGroupWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemUserGroupWrapper obj)
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

        public static void Delete(SystemUserGroupWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemUserGroupWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemUserGroupWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemUserGroupWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemUserGroupWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemUserGroupWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SystemUserGroupWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemUserGroupWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemUserGroupWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion


        public static List<string> GetUserGroupAssignedRoleIDs(SystemUserGroupWrapper userGroupWrapper)
        {
            if (userGroupWrapper == null)
                throw new ArgumentNullException("systemUserGroupWrapper");

            List<SystemRoleEntity> assignedRoles = businessProxy.GetAssignedRoleByUserGroup(userGroupWrapper.entity);

            List<string> roleIDs = new List<string>();

            foreach (SystemRoleEntity role in assignedRoles)
            {
                roleIDs.Add(role.RoleID.ToString());
            }

            return roleIDs;
        }

        public static void PatchAssignUserGroupRoles(SystemUserGroupWrapper userGroupWrapper, List<string> roleids)
        {
            if (userGroupWrapper == null)
                throw new ArgumentNullException("userGroupWrapper");
            if (roleids == null)
                throw new ArgumentNullException("roleids");

            businessProxy.PatchAssignUserGroupRoles(userGroupWrapper.entity, roleids);
        }
    }
}
