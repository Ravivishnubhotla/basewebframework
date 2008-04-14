using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemUserDao : SystemUserBaseDao
    {
        public SystemUserDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }

        public SystemUser GetUserByLoginID(string loginID)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemUserDao.PROPERTY_USERLOGINID.Eq(loginID));
            List<SystemUser> users = this.FindAll(criterions.ToArray());
            if (users.Count >= 1)
            {
                return users[0];
            }
            return null;
        }

        public SystemUser GetUserByLoginIDAndPassword(string loginID, string password)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemUserDao.PROPERTY_USERLOGINID.Eq(loginID));
            criterions.Add(SystemUserDao.PROPERTY_USERPASSWORD.Eq(password));
            List<SystemUser> users = this.FindAll(criterions.ToArray());
            if ((users.Count >= 1) && users[0].UserPassword.Equals(password))
            {
                return users[0];
            }
            return null;
        }
    }
}
