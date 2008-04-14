using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Business;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    [Transactional]
    public class SystemApplicationService : BaseServices<SystemApplication>
    {
        public SystemApplicationService(SystemApplicationDao selfDao) : base(selfDao)
        {
        }
		
		public SystemApplicationDao SelfDao
        {
            get
            {
                return (SystemApplicationDao)selfDao;
            }
        }



        public List<SystemApplication> GetAll(int firstRow, int maxRows, out int recordCount)
        {
            List<Order> orders = new List<Order>();
            orders.Add(SystemApplicationDao.PROPERTY_SYSTEMAPPLICATIONID.Desc());
            List<ICriterion> criterions = new List<ICriterion>();
            return this.FindAll(criterions.ToArray(), orders.ToArray(), firstRow, maxRows, out recordCount);
        }
    }
}
