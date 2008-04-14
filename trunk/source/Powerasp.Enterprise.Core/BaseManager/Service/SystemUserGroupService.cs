using System;
using System.Collections.Generic;
using System.Text;
using Castle.Services.Transaction;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.BaseManager.BaseService;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    [Transactional]
    public class SystemUserGroupService : SystemUserGroupBaseService
    {
        public SystemUserGroupService(SystemUserGroupDao selfDao) : base(selfDao)
        {
        }

        private SystemUserGroupRoleRelationDao systemUserGroupRoleRelationDaoInstance;

        public SystemUserGroupRoleRelationDao SystemUserGroupRoleRelationDaoInstance
        {
            set { systemUserGroupRoleRelationDaoInstance = value; }
        }

        private SystemRoleDao systemRoleDaoInstance;

        public SystemRoleDao SystemRoleDaoInstance
        {
            set { systemRoleDaoInstance = value; }
        }

        public List<SystemUserGroup> GetAll(int firstRow, int maxRows, out int recordCount)
        {
            List<Order> orders = new List<Order>();
            orders.Add(SystemUserGroupDao.PROPERTY_GROUPID.Desc());
            List<ICriterion> criterions = new List<ICriterion>();
            return this.FindAll(criterions.ToArray(), orders.ToArray(), firstRow, maxRows, out recordCount);
        }

        public List<int> GetUserGroupAssignedroleIDList(SystemUserGroup userGroup)
        {
            List<SystemRole> list = systemUserGroupRoleRelationDaoInstance.GetUserGroupAssignedRole(userGroup);
            List<int> roleList = new List<int>();
            foreach (SystemRole role in list)
            {
                roleList.Add(role.RoleID);
            }
            return roleList;
        }
        [Transaction(TransactionMode.Requires)]
        public virtual void SaveUserGroupAssignedRoleIDList(List<int> roleIDList, SystemUserGroup userGroup)
        {
            List<SystemUserGroupRoleRelation> systemUserGroupRoleRelation =
                systemUserGroupRoleRelationDaoInstance.GetSystemUserGroupRoleRelationByUserGroup(userGroup);
            foreach (SystemUserGroupRoleRelation userGroupRoleRelation in systemUserGroupRoleRelation)
            {
                systemUserGroupRoleRelationDaoInstance.Delete(userGroupRoleRelation);
            }
            foreach (int id in roleIDList)
            {
                SystemRole assignedRole = systemRoleDaoInstance.Load(id);
                SystemUserGroupRoleRelation userGroupRoleRelation = new SystemUserGroupRoleRelation();
                userGroupRoleRelation.RoleID = assignedRole;
                userGroupRoleRelation.UserGroupID = userGroup;
                systemUserGroupRoleRelationDaoInstance.Save(userGroupRoleRelation);
            }
        }


    }


}
