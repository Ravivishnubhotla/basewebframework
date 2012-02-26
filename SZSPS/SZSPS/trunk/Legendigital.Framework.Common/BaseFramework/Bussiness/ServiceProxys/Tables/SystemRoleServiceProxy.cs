// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
    [ServiceContract(Namespace = "http://Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables")]
	public interface ISystemRoleServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemRoleEntity>
    {
        [OperationContract]
        bool DeleteRole(string roleName, bool onPopulatedRole);
        [OperationContract]
        bool RoleExists(string roleName);
        [OperationContract]
        void AddUsersToRoles(string[] usernames, string[] roleNames);
        [OperationContract]
        void RemoveUsersFromRoles(string[] usernames, string[] roleNames);
        [OperationContract]
        string[] GetUsersInRole(string roleName);
        [OperationContract]
        string[] GetAllRoles();
        [OperationContract]
        string[] FindUsersInRole(string roleName, string usernameToMatch);
        [OperationContract]
        void PatchAssignRoleMenusInApplication(SystemRoleEntity roleEntity, SystemApplicationEntity applicationEntity, string[] assignedMenuIDS);
        [OperationContract]
        void PatchAssignRoleApplications(SystemRoleEntity roleEntity, List<string> applicationIDs);
        [OperationContract]
        List<SystemApplicationEntity> GetRoleAssignedApplications(SystemRoleEntity roleEntity);
        [OperationContract]
        List<SystemPrivilegeEntity> GetRoleAssignedPermissions(SystemRoleEntity roleEntity);
        [OperationContract]
        void PatchAssignRolePermissions(SystemRoleEntity roleEntity, List<string> assignedPermissionIDs);
        [OperationContract]
        List<SystemPrivilegeInRolesEntity> GetRoleAssignedPrivilegesInRole(SystemRoleEntity systemRoleEntity);

        SystemRoleEntity GetRoleByName(string roleName);
    }

    public partial class SystemRoleServiceProxy : ISystemRoleServiceProxy
    {
        public bool DeleteRole(string roleName, bool onPopulatedRole)
        {
            SystemRoleEntity role = this.SelfDataObj.GetRoleByName(roleName);
            if (role != null)
            {
                //删除Role的级联数据
                Delete(role);
                return true;
            }
            return false;
        }

        public bool RoleExists(string roleName)
        {
            return (this.SelfDataObj.GetRoleByName(roleName) != null);
        }

        private bool CheckUserRoleRelationIsExist(SystemUserEntity user, SystemRoleEntity role)
        {
            SystemUserRoleRelationEntity systemUserRoleRelation = this.DataObjectsContainerIocID.SystemUserRoleRelationDataObjectInstance.GetUserRoleRelation(user, role);
            return (systemUserRoleRelation != null);
        }

        public void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            for (int i = 0; i < usernames.Length; i++)
            {
                SystemUserEntity user = this.DataObjectsContainerIocID.SystemUserDataObjectInstance.GetUserByLoginID(usernames[i]);
                SystemRoleEntity role = this.SelfDataObj.GetRoleByName(roleNames[i]);
                if (user != null && role != null && !CheckUserRoleRelationIsExist(user, role))
                {
                    var systemUserRoleRelation = new SystemUserRoleRelationEntity
                    {
                        UserID = user,
                        RoleID = role
                    };
                    this.DataObjectsContainerIocID.SystemUserRoleRelationDataObjectInstance.Save(systemUserRoleRelation);
                }
            }
        }

        public void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            for (int i = 0; i < usernames.Length; i++)
            {
                SystemUserEntity user = this.DataObjectsContainerIocID.SystemUserDataObjectInstance.GetUserByLoginID(usernames[i]);
                SystemRoleEntity role = this.SelfDataObj.GetRoleByName(roleNames[i]);
                if (user != null && role != null)
                {
                    var systemUserRoleRelation = this.DataObjectsContainerIocID.SystemUserRoleRelationDataObjectInstance.GetUserRoleRelation(user, role);
                    if (systemUserRoleRelation != null)
                        this.DataObjectsContainerIocID.SystemUserRoleRelationDataObjectInstance.Delete(systemUserRoleRelation);
                }
            }
        }

        public string[] GetUsersInRole(string roleName)
        {
            SystemRoleEntity role = this.SelfDataObj.GetRoleByName(roleName);
            var list = new List<string>();
            if (role == null)
            {
                return list.ToArray();
            }
            List<SystemUserEntity> allUsers = this.DataObjectsContainerIocID.SystemUserRoleRelationDataObjectInstance.GetRoleAssignedUsers(role);
            foreach (var user in allUsers)
            {
                list.Add(user.UserLoginID);
            }
            return list.ToArray();
        }

        public string[] GetAllRoles()
        {
            var list = new List<string>();
            List<SystemRoleEntity> allRoles = this.DataObjectsContainerIocID.SystemRoleDataObjectInstance.FindAll();
            foreach (var role in allRoles)
            {
                list.Add(role.RoleName);
            }
            return list.ToArray();
        }

        public string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 批量保存角色菜单对应关系
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <param name="applicationEntity"></param>
        /// <param name="assignedMenuIDS"></param>
        [Transaction(TransactionPropagation.Required)]
        public virtual void PatchAssignRoleMenusInApplication(SystemRoleEntity roleEntity, SystemApplicationEntity applicationEntity, string[] assignedMenuIDS)
        {
            //生成菜单ID list
            List<string> assignedMenus = new List<string>();
            assignedMenus.AddRange(assignedMenuIDS);

            //获取应用下面的所有菜单
            List<SystemMenuEntity> systemRoleMenuRelations =
                this.DataObjectsContainerIocID.SystemMenuDataObjectInstance.GetMenuByApplication(applicationEntity);

            //保存所有菜单角色对应关系
            foreach (SystemMenuEntity entity in systemRoleMenuRelations)
            {
                //查找菜单角色对应关系
                SystemRoleMenuRelationEntity systemRoleMenuRelation = this.DataObjectsContainerIocID.SystemRoleMenuRelationDataObjectInstance.GetRelationByUserAndMenu(roleEntity, entity);

                if (assignedMenus.Contains(entity.MenuID.ToString()))
                {
                    //不存在对应关系创建一个，存在的话直接保存
                    if (systemRoleMenuRelation == null)
                    {
                        systemRoleMenuRelation = new SystemRoleMenuRelationEntity();
                    }
                    systemRoleMenuRelation.RoleID = roleEntity;
                    systemRoleMenuRelation.MenuID = entity;
                    this.DataObjectsContainerIocID.SystemRoleMenuRelationDataObjectInstance.SaveOrUpdate(systemRoleMenuRelation);
                }
                else
                {
                    //没选中的菜单角色对应关系如果已经存在，查出
                    if (systemRoleMenuRelation != null)
                    {
                        this.DataObjectsContainerIocID.SystemRoleMenuRelationDataObjectInstance.Delete(systemRoleMenuRelation);
                    }
                }
            }

        }

        /// <summary>
        /// 批量保存角色应用对应关系
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <param name="applicationIDs"></param>
        [Transaction(TransactionPropagation.Required)]
        public void PatchAssignRoleApplications(SystemRoleEntity roleEntity, List<string> applicationIDs)
        {
            //获取所有的应用
            List<SystemApplicationEntity> allapplications =
                this.DataObjectsContainerIocID.SystemApplicationDataObjectInstance.FindAll();

            //遍历所有的application
            foreach (SystemApplicationEntity applicationEntity in allapplications)
            {
                //查找是否存在对应关系
                SystemRoleApplicationEntity systemRoleApplicationEntity = this.DataObjectsContainerIocID.SystemRoleApplicationDataObjectInstance.GetRelationByRoleAndApplication(roleEntity, applicationEntity);
                //检查是否需要保存
                if (applicationIDs.Contains(applicationEntity.SystemApplicationID.ToString()))
                {
                    //添加或修改对应关系
                    if (systemRoleApplicationEntity == null)
                    {
                        systemRoleApplicationEntity = new SystemRoleApplicationEntity();
                    }
                    systemRoleApplicationEntity.RoleID = roleEntity;
                    systemRoleApplicationEntity.ApplicationID = applicationEntity;
                    this.DataObjectsContainerIocID.SystemRoleApplicationDataObjectInstance.SaveOrUpdate(systemRoleApplicationEntity);
                }
                else
                {
                    //删除对应Application下面对应的菜单角色对应关系

                    //如果不需要保存则删除已存在的对应关系
                    if (systemRoleApplicationEntity != null)
                    {
                        this.DataObjectsContainerIocID.SystemRoleApplicationDataObjectInstance.Delete(systemRoleApplicationEntity);
                    }


                }
            }
        }

        [Transaction(TransactionPropagation.Required)]
        public void PatchAssignRolePermissions(SystemRoleEntity roleEntity, List<string> assignedPermissionIDs)
        {
            //获取所有的应用
            List<SystemPrivilegeEntity> allPrivileges =
                this.DataObjectsContainerIocID.SystemPrivilegeDataObjectInstance.FindAll();

            //遍历所有的application
            foreach (SystemPrivilegeEntity privilegesEntity in allPrivileges)
            {
                //查找是否存在对应关系
                SystemPrivilegeInRolesEntity systemPrivilegeInRolesEntity = this.DataObjectsContainerIocID.SystemPrivilegeInRolesDataObjectInstance.GetRelationByRoleAndPrivilege(roleEntity, privilegesEntity);
                //检查是否需要保存
                if (assignedPermissionIDs.Contains(privilegesEntity.PrivilegeID.ToString()))
                {
                    //添加或修改对应关系
                    if (systemPrivilegeInRolesEntity == null)
                    {
                        systemPrivilegeInRolesEntity = new SystemPrivilegeInRolesEntity();
                    }
                    systemPrivilegeInRolesEntity.RoleID = roleEntity;
                    systemPrivilegeInRolesEntity.PrivilegeID = privilegesEntity;
                    systemPrivilegeInRolesEntity.CreateTime = System.DateTime.Now;
                    systemPrivilegeInRolesEntity.UpdateTime = System.DateTime.Now;
                    systemPrivilegeInRolesEntity.ExpiryTime = System.DateTime.Now.AddYears(20);
                    systemPrivilegeInRolesEntity.EnableParameter = true;
                    systemPrivilegeInRolesEntity.EnableType = "";
                    systemPrivilegeInRolesEntity.PrivilegeRoleValueType = "string";
                    systemPrivilegeInRolesEntity.PrivilegeRoleValue = null;
                    this.DataObjectsContainerIocID.SystemPrivilegeInRolesDataObjectInstance.SaveOrUpdate(systemPrivilegeInRolesEntity);
                }
                else
                {
                    //删除对应Application下面对应的菜单角色对应关系

                    //如果不需要保存则删除已存在的对应关系
                    if (systemPrivilegeInRolesEntity != null)
                    {
                        this.DataObjectsContainerIocID.SystemPrivilegeInRolesDataObjectInstance.Delete(systemPrivilegeInRolesEntity);
                    }


                }
            }
        }

        public List<SystemPrivilegeInRolesEntity> GetRoleAssignedPrivilegesInRole(SystemRoleEntity systemRoleEntity)
        {
            return
                this.DataObjectsContainerIocID.SystemPrivilegeInRolesDataObjectInstance.GetRoleAssignedPrivilegesInRole(
                    systemRoleEntity);
        }

        public SystemRoleEntity GetRoleByName(string roleName)
        {
            return this.SelfDataObj.GetRoleByName(roleName); 
        }

        public List<SystemApplicationEntity> GetRoleAssignedApplications(SystemRoleEntity roleEntity)
        {
            List<SystemRoleEntity> roles = new List<SystemRoleEntity>();

            roles.Add(roleEntity);
            //获取角色分配的的应用程序.
            return this.DataObjectsContainerIocID.SystemRoleApplicationDataObjectInstance.GetUserAssignedApplications(roles);
        }

        public List<SystemPrivilegeEntity> GetRoleAssignedPermissions(SystemRoleEntity roleEntity)
        {
            return this.DataObjectsContainerIocID.SystemPrivilegeInRolesDataObjectInstance.GetRoleAssignedPermissions(roleEntity);
        }
    }
}
