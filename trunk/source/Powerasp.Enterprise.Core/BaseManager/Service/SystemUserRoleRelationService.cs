using System;
using System.Collections.Generic;
using System.Text;
using Powerasp.Enterprise.Core.Business;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    [Transactional]
    public class SystemUserRoleRelationService : BaseServices<SystemUserRoleRelation>
    {
        public SystemUserRoleRelationService(SystemUserRoleRelationDao selfDao) : base(selfDao)
        {
        }
		
		public SystemUserRoleRelationDao SelfDao
        {
            get
            {
                return (SystemUserRoleRelationDao)selfDao;
            }
        }
    }
}
