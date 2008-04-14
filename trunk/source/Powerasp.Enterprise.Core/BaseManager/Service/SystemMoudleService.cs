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
    public class SystemMoudleService : BaseServices<SystemMoudle>
    {
        public SystemMoudleService(SystemMoudleDao selfDao) : base(selfDao)
        {
        }
		
		public SystemMoudleDao SelfDao
        {
            get
            {
                return (SystemMoudleDao)selfDao;
            }
        }
    }
}
