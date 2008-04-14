using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemRoleMenuRelationDao : SystemRoleMenuRelationBaseDao
    {
        public SystemRoleMenuRelationDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemRoleMenuRelationDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }


        public List<SystemRoleMenuRelation> GetRoleMenuRelationAssignedApplicaton(SystemRole role)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemRoleMenuRelationDao.PROPERTY_ROLEID.Eq(role));
            return this.FindAll(criterions.ToArray());
        }
    }
}
