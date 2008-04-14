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
    public class SystemViewService : BaseServices<SystemView>
    {
        public SystemViewService(SystemViewDao selfDao) : base(selfDao)
        {
        }
		
		public SystemViewDao SelfDao
        {
            get
            {
                return (SystemViewDao)selfDao;
            }
        }
    }
}
