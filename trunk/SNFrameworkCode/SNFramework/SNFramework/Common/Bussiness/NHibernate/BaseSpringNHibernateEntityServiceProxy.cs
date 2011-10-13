using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Entity;
using NHibernate.Criterion;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Legendigital.Framework.Common.Bussiness.NHibernate
{


    public class BaseSpringNHibernateEntityServiceProxy<DomainType> : IBaseSpringNHibernateEntityServiceProxy<DomainType> where DomainType : BaseTableEntity
    {
        protected IBaseNHibernateDataObject<DomainType> selfDataObject;

        public IBaseNHibernateDataObject<DomainType> SelfDataObject
        {
            set
            {
                selfDataObject = value;
            }
        }

        private ILog logger = null;

        public ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(this.GetType());
                return logger;
            }
            set { logger = value; }
        }

        public BaseSpringNHibernateEntityServiceProxy()
        {
        }

        public virtual DomainType GetNewDomainInstance()
        {
            return Activator.CreateInstance<DomainType>();
        }

        [Transaction(TransactionPropagation.Required,ReadOnly=false)]
        public virtual void Save(DomainType obj)
        {
            selfDataObject.Save(obj);
        }


        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void Update(DomainType obj)
        {
            selfDataObject.Update(obj);
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void SaveOrUpdate(DomainType obj)
        {
            selfDataObject.SaveOrUpdate(obj);
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void DeleteAll()
        {
            selfDataObject.DeleteAll();
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void DeleteByID(object id)
        {
            selfDataObject.DeleteByID(id);
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void PatchDeleteByIDs(object[] ids)
        {
            foreach (var id in ids)
            {
                selfDataObject.DeleteByID(id);                
            }
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public virtual void Delete(DomainType instance)
        {
            selfDataObject.Delete(instance);
        }


        public virtual void Refresh(DomainType instance)
        {
            selfDataObject.Refresh(instance);
        }

        public virtual DomainType FindById(object id)
        {
            return selfDataObject.Load(id);
        }

        public virtual DomainType FullFindById(object id)
        {
            return selfDataObject.FullLoad(id);
        }

        public virtual List<DomainType> FindAll()
        {
            return selfDataObject.FindAll();
        }

        public virtual List<DomainType> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return selfDataObject.FindAll(null, null,  pageQueryParams);
        }

        public List<DomainType> FindAllByOrderBy(string orderByColumn, bool isDesc, PageQueryParams pageQueryParams)
        {
            return selfDataObject.FindAllByOrderBy(orderByColumn, isDesc, pageQueryParams);
        }

        public List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc, PageQueryParams pageQueryParams)
        {
            return selfDataObject.FindAllByOrderByAndFilter(filters, orderByColumn, isDesc, pageQueryParams);           
        }

        public List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc)
        {
            return selfDataObject.FindAllByOrderByAndFilter(filters, orderByColumn, isDesc);  
        }

        protected virtual List<DomainType> FindAll(Order[] sortItems, PageQueryParams pageQueryParams)
        {
            return selfDataObject.FindAll(null, null, pageQueryParams);
        }

        protected virtual void InitializeLazyProperties(DomainType instance)
        {
            selfDataObject.InitializeLazyProperties(instance);
        }

        protected virtual void InitializeLazyProperty(DomainType instance, string propertyName)
        {
            selfDataObject.InitializeLazyProperty(instance, propertyName);
        }

        protected virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems)
        {
            return selfDataObject.FindAll(criterias, sortItems);
        }

        protected virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, PageQueryParams pageQueryParams)
        {
            return selfDataObject.FindAll(criterias, sortItems, pageQueryParams);
        }
 
    }
}