using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemUserGroupDao : SystemUserGroupBaseDao
    {
        public SystemUserGroupDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserGroupDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }




    }
}
