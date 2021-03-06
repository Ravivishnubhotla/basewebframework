﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Entity;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Bussiness.NHibernate
{
    /// <summary>
    /// NHibernate架构可查询服务层对象基类
    /// </summary>
    /// <typeparam name="DomainType"></typeparam>
    public class BaseSpringNHibernateEntityViewServiceProxy<DomainType, EntityKeyType> : IBaseSpringNHibernateEntityViewServiceProxy<DomainType, EntityKeyType> where DomainType : BaseViewEntity<EntityKeyType>
    {

        protected IBaseNHibernateViewDataObject<DomainType, EntityKeyType> selfDataObject;

        /// <summary>
        /// 可查询数据对象
        /// </summary>
        public IBaseNHibernateViewDataObject<DomainType, EntityKeyType> SelfDataObject
        {
            set
            {
             
                selfDataObject = value;
            }
        }

        private ILog logger = null;

        /// <summary>
        /// 日志对象
        /// </summary>
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

        public BaseSpringNHibernateEntityViewServiceProxy()
        {
        }

        /// <summary>
        /// 创建新的实例对象
        /// </summary>
        /// <returns></returns>
        public virtual DomainType GetNewDomainInstance()
        {
            return Activator.CreateInstance<DomainType>();
        }
        /// <summary>
        /// 刷新对象（重新加载）
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Refresh(DomainType instance)
        {
            selfDataObject.Refresh(instance);
        }
        /// <summary>
        /// 通过ID查找对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual DomainType FindById(EntityKeyType id)
        {
            return selfDataObject.Load(id);
        }

        public virtual DomainType FullFindById(EntityKeyType id)
        {
            return selfDataObject.FullLoad(id);
        }
        /// <summary>
        /// 查出所有的对象
        /// </summary>
        /// <returns></returns>
        public virtual List<DomainType> FindAll()
        {
            return selfDataObject.FindAll();
        }
        /// <summary>
        /// 分页查出所有的对象
        /// </summary>
        /// <param name="firstRow"></param>
        /// <param name="maxRows"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
        public virtual List<DomainType> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return selfDataObject.FindAll(null, null, pageQueryParams);
        }
        /// <summary>
        /// 分页查出所有的对象（带单字段排序条件）
        /// </summary>
        /// <param name="orderByColumn"></param>
        /// <param name="isDesc"></param>
        /// <param name="firstRow"></param>
        /// <param name="maxRows"></param>
        /// <param name="recordCount"></param>
        /// <returns></returns>
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


        public virtual bool CheckEntityHasProperty(string propertyName)
        {
            return selfDataObject.CheckEntityHasProperty(propertyName);
        }

        public virtual object GetEntityPropertyValue(string propertyName, DomainType domain)
        {
            return selfDataObject.GetEntityPropertyValue(propertyName, domain);
        }
    }
}
