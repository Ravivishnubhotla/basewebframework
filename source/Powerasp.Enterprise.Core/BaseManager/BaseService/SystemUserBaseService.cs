using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.Business;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseService
{
    [Transactional]
    public class SystemUserBaseService : BaseServices<SystemUser>
    {
        public SystemUserBaseService(SystemUserDao selfDao) : base(selfDao)
        {
        }
		
		public SystemUserDao SelfDao
        {
            get
            {
                return (SystemUserDao)selfDao;
            }
        }


    }
}
