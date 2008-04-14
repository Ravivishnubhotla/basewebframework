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
    public class SystemViewItemBaseService : BaseServices<SystemViewItem>
    {
        public SystemViewItemBaseService(SystemViewItemDao selfDao) : base(selfDao)
        {
        }
		
		public SystemViewItemDao SelfDao
        {
            get
            {
                return (SystemViewItemDao)selfDao;
            }
        }
    }
}
