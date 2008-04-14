using System;
using System.Collections.Generic;
using System.Text;
using Powerasp.Enterprise.Core.Business;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseService
{
    [Transactional]
    public class SystemUserGroupRoleRelationBaseService : BaseServices<SystemUserGroupRoleRelation>
    {
        public SystemUserGroupRoleRelationBaseService(SystemUserGroupRoleRelationDao selfDao) : base(selfDao)
        {
        }
		
		public SystemUserGroupRoleRelationDao SelfDao
        {
            get
            {
                return (SystemUserGroupRoleRelationDao)selfDao;
            }
        }
    }
}
