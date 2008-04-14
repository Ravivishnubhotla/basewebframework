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
    public class SystemMoudleFieldService : BaseServices<SystemMoudleField>
    {
        public SystemMoudleFieldService(SystemMoudleFieldDao selfDao) : base(selfDao)
        {
        }
		
		public SystemMoudleFieldDao SelfDao
        {
            get
            {
                return (SystemMoudleFieldDao)selfDao;
            }
        }
    }
}
