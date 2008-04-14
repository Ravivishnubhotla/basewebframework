using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemUserGroupRoleRelationDao : SystemUserGroupRoleRelationBaseDao
    {
        public SystemUserGroupRoleRelationDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserGroupRoleRelationDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }

        public List<SystemRole> GetUserGroupAssignedRole(SystemUserGroup systemUserGroup)
        {
            List<SystemUserGroupRoleRelation> listSystemUserGroupRoleRelation =
                GetSystemUserGroupRoleRelationByUserGroup(systemUserGroup);

            List<SystemRole> assignRoles = new List<SystemRole>();
            foreach (SystemUserGroupRoleRelation relation in listSystemUserGroupRoleRelation)
            {
                assignRoles.Add(relation.RoleID);
            }

            return assignRoles;
        }

        public List<SystemUserGroupRoleRelation> GetSystemUserGroupRoleRelationByUserGroup(SystemUserGroup systemUserGroup)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemUserGroupRoleRelationDao.PROPERTY_USERGROUPID.Eq(systemUserGroup));

            return this.FindAll(criterions.ToArray());
        }
    }
}
