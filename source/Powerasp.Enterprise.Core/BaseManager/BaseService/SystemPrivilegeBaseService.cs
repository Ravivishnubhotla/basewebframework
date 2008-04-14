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
    public class SystemPrivilegeBaseService : BaseServices<SystemPrivilege>
    {
        public SystemPrivilegeBaseService(SystemPrivilegeDao selfDao) : base(selfDao)
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
