using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemRoleApplicationDao : SystemRoleApplicationBaseDao
    {
        public SystemRoleApplicationDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemRoleApplicationDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }

        /// <summary>
        /// 获取应用程序
        /// </summary>
        /// <param name="application"></param>
        /// <returns></returns>
        public List<SystemRole> GetApplicationAssignRole(SystemApplication application)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemRoleApplicationDao.PROPERTY_APPLICATIONID.Eq(application));

            List<SystemRoleApplication> listSystemRoleApplication = this.FindAll(criterions.ToArray());

            List<SystemRole> assignRoles = new List<SystemRole>();
            foreach (SystemRoleApplication relation in listSystemRoleApplication)
            {
                assignRoles.Add(relation.RoleID);
            }

            return assignRoles;
        }


        public List<SystemApplication> GetRoleAssignedApplicaton(SystemRole role)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemRoleApplicationDao.PROPERTY_ROLEID.Eq(role));

            List<SystemRoleApplication> listSystemRoleApplication = this.FindAll(criterions.ToArray());

            List<SystemApplication> assignRoles = new List<SystemApplication>();
            foreach (SystemRoleApplication relation in listSystemRoleApplication)
            {
                assignRoles.Add(relation.ApplicationID);
            }

            return assignRoles;
        }

        public List<SystemRoleApplication> GetRoleApplicationRelationAssignedApplicaton(SystemRole role)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemRoleApplicationDao.PROPERTY_ROLEID.Eq(role));
            return this.FindAll(criterions.ToArray());
        }


        public bool RoleAndApplicationHasRelation(SystemRole role, SystemApplication application)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemRoleApplicationDao.PROPERTY_ROLEID.Eq(role));
            criterions.Add(SystemRoleApplicationDao.PROPERTY_APPLICATIONID.Eq(application));
            return (this.FindAll(criterions.ToArray()).Count > 0);
        }
    }
}
