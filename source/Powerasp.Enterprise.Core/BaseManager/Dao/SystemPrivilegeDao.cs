using System;
using System.Collections.Generic;
using System.Text;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemPrivilegeDao : SystemPrivilegeBaseDao
    {
        public SystemPrivilegeDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemPrivilegeDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
