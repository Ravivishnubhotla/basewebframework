using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemUserRoleRelationDao : SystemUserRoleRelationBaseDao
    {
        public SystemUserRoleRelationDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserRoleRelationDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }

        public List<SystemRole> GetUserAssignRole(SystemUser user)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemUserRoleRelationBaseDao.PROPERTY_USERID.Eq(user));
            List<SystemUserRoleRelation> listSystemUserRoleRelation = this.FindAll(criterions.ToArray());
            List<SystemRole> assignRoles = new List<SystemRole>();
            foreach (SystemUserRoleRelation relation in listSystemUserRoleRelation)
            {
                this.InitializeLazyProperties(relation);
                assignRoles.Add(relation.RoleID);
            }
            return assignRoles;
        }
    }
}
