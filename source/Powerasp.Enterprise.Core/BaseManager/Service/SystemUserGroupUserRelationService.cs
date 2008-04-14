using System;
using System.Collections.Generic;
using System.Text;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.BaseService;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    [Transactional]
    public class SystemUserGroupUserRelationService : SystemUserGroupUserRelationBaseService
    {
        public SystemUserGroupUserRelationService(SystemUserGroupUserRelationDao selfDao) : base(selfDao)
        {
        }
    }
}
