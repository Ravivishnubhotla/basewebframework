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
    public class SystemPrivilegeService : BaseServices<SystemPrivilege>
    {
        public SystemPrivilegeService(SystemPrivilegeDao selfDao) : base(selfDao)
        {
        }
		
		public SystemPrivilegeDao SelfDao
        {
            get
            {
                return (SystemPrivilegeDao)selfDao;
            }
        }
    }
}
