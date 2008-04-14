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
    public class SystemRoleMenuRelationService : BaseServices<SystemRoleMenuRelation>
    {
        public SystemRoleMenuRelationService(SystemRoleMenuRelationDao selfDao) : base(selfDao)
        {
        }
		
		public SystemRoleMenuRelationDao SelfDao
        {
            get
            {
                return (SystemRoleMenuRelationDao)selfDao;
            }
        }
    }
}
