﻿using System;
using System.Collections.Generic;
using System.Text;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemUserGroupUserRelationDao : SystemUserGroupUserRelationBaseDao
    {
        public SystemUserGroupUserRelationDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemUserGroupUserRelationDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }
    }
}
