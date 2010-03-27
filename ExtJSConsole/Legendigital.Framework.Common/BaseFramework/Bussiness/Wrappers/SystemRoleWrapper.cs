
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemRoleWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemRoleWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemRoleWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemRoleWrapper obj)
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

        public static void Delete(SystemRoleWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemRoleWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemRoleWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemRoleWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemRoleWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SystemRoleEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SystemRoleWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SystemRoleWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SystemRoleWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

		
		#endregion

        public static bool DeleteRole(string roleName, bool onPopulatedRole)
        {
            return businessProxy.DeleteRole(roleName, onPopulatedRole);
        }

        public static void CreateRole(string roleName)
        {
            var role = new SystemRoleWrapper { RoleName = roleName, RoleDescription = "", RoleIsSystemRole = false };
            SaveOrUpdate(role);
        }

        public static bool RoleExists(string roleName)
        {
            return businessProxy.RoleExists(roleName);
        }

        public static void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            businessProxy.AddUsersToRoles(usernames, roleNames);
        }

        public static void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            businessProxy.RemoveUsersFromRoles(usernames, roleNames);
        }

        public static string[] GetUsersInRole(string roleName)
        {
            return businessProxy.GetUsersInRole(roleName);
        }

        public static string[] GetAllRoles()
        {
            return businessProxy.GetAllRoles();
        }

        public static string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            return businessProxy.FindUsersInRole(roleName, usernameToMatch);
        }

        public static void PatchAssignRoleMenusInApplication(SystemRoleWrapper role, int applicationID, string[] assignedMenuIDS)
        {
            SystemApplicationWrapper applicationWrapper = SystemApplicationWrapper.FindById(applicationID);

            if (role != null && applicationWrapper != null)
            {
                businessProxy.PatchAssignRoleMenusInApplication(role.entity, applicationWrapper.entity, assignedMenuIDS);
            }
        }

        public static void PatchAssignRoleApplications(SystemRoleWrapper role, List<string> applicationIDs)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            if (applicationIDs == null)
                throw new ArgumentNullException("applicationIDs");

            businessProxy.PatchAssignRoleApplications(role.entity, applicationIDs);
        }

        public static void PatchAssignRolePermissions(SystemRoleWrapper role, List<string> assignedPermissionIDs)
        {
            if (role == null)
                throw new ArgumentNullException("role");
            if (assignedPermissionIDs == null)
                throw new ArgumentNullException("assignedPermissionIDs");

            businessProxy.PatchAssignRolePermissions(role.entity, assignedPermissionIDs);
        }

        public static List<string> GetRoleAssignedApplicationIDs(SystemRoleWrapper role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            List<string> assignedApplicationIDs = new List<string>();

            List<SystemApplicationEntity> list = businessProxy.GetRoleAssignedApplications(role.entity);

            foreach (SystemApplicationEntity applicationEntity in list)
            {
                assignedApplicationIDs.Add(applicationEntity.SystemApplicationID.ToString());
            }

            return assignedApplicationIDs;
        }

        public static List<SystemPrivilegeWrapper> GetRoleAssignedPrivileges(SystemRoleWrapper role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            return SystemPrivilegeWrapper.ConvertToWrapperList(businessProxy.GetRoleAssignedPermissions(role.entity));
        }

        public static List<SystemPrivilegeInRolesWrapper> GetRoleAssignedPrivilegesInRole(SystemRoleWrapper role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            return SystemPrivilegeInRolesWrapper.ConvertToWrapperList(businessProxy.GetRoleAssignedPrivilegesInRole(role.entity));
        }

        public static List<SystemApplicationWrapper> GetRoleAssignedApplications(SystemRoleWrapper role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            return SystemApplicationWrapper.ConvertToWrapperList(businessProxy.GetRoleAssignedApplications(role.entity));
        }

        public static List<string> GetRoleAssignedPermissions(SystemRoleWrapper role)
        {
            if (role == null)
                throw new ArgumentNullException("role");

            List<string> assignedPermissions = new List<string>();

            List<SystemPrivilegeEntity> list = businessProxy.GetRoleAssignedPermissions(role.entity);

            foreach (SystemPrivilegeEntity systemPrivilegeEntity in list)
            {
                assignedPermissions.Add(systemPrivilegeEntity.PrivilegeID.ToString());
            }

            return assignedPermissions;
        }




    }
}
