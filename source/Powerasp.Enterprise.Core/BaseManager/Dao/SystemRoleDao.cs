using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemRoleDao : SystemRoleBaseDao
    {
        public SystemRoleDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemRoleDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }


        public List<SystemRole> GetUserAssignRole(SystemUser user)
        {
            using (ISession session = GetSession())
            {
                DetachedCriteria userAssignedRoleRelation = DetachedCriteria.For(typeof(SystemUserRoleRelation));
                userAssignedRoleRelation.Add(SystemUserRoleRelationDao.PROPERTY_USERID.Eq(user));

                DetachedCriteria userAssignedRole = DetachedCriteria.For(typeof(SystemRole));
                userAssignedRole.Add(
                    Subqueries.PropertyIn(SystemUserRoleRelation.PROPERTY_NAME_ROLEID, userAssignedRoleRelation));
                return this.ConvertToTypedList(userAssignedRole.GetExecutableCriteria(session).List());
            }

        }





    }
}
