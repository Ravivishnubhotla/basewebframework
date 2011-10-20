﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Entity;
using Spring.Context.Support;

namespace Legendigital.Framework.Common.Bussiness.NHibernate
{
    public abstract class BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType>
        where DomainType : BaseTableEntity
        where ServiceProxyType : IBaseSpringNHibernateEntityServiceProxy<DomainType>
        where WrapperType : BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType>
    {
        #region Member

        protected DomainType entity;

        private static ILog _logger = null;

        public static ILog Logger
        {
            get
            {
                if (_logger == null)
                    _logger = LogManager.GetLogger(typeof(DomainType));
                return Logger;
            }
        }

        #endregion

        #region Construtor

        protected BaseSpringNHibernateWrapper(DomainType entityObj)
        {
            entity = entityObj;
        }

        #endregion

        #region Equals 和 HashCode 方法覆盖
        public override bool Equals(object obj)
        {
            if (obj == null && entity != null)
            {
                if (entity.DataKeyIsEmpty)
                    return true;

                return false;
            }
            return entity.Equals(obj);
        }

        public override int GetHashCode()
        {
            return entity.GetHashCode();
        }
        #endregion

        #region Static Common Data Operation

        protected static void Save(WrapperType obj, ServiceProxyType serviceProxy)
        {
            serviceProxy.Save(obj.entity);
        }

        protected static void Update(WrapperType obj, ServiceProxyType serviceProxy)
        {
            serviceProxy.Update(obj.entity);
        }

        protected static void SaveOrUpdate(WrapperType obj, ServiceProxyType serviceProxy)
        {
            serviceProxy.SaveOrUpdate(obj.entity);
        }

        protected static void DeleteAll(ServiceProxyType serviceProxy)
        {
            serviceProxy.DeleteAll();
        }

        protected static void DeleteByID(object id, ServiceProxyType serviceProxy)
        {
            serviceProxy.DeleteByID(id);
        }

        protected static void PatchDeleteByIDs(object[] ids, ServiceProxyType serviceProxy)
        {
            serviceProxy.PatchDeleteByIDs(ids);
        }

        protected static void Delete(WrapperType instance, ServiceProxyType serviceProxy)
        {
            serviceProxy.Delete(instance.entity);
        }

        protected static void Refresh(WrapperType instance, ServiceProxyType serviceProxy)
        {
            serviceProxy.Refresh(instance.entity);
        }

        protected static DomainType FindById(object id, ServiceProxyType serviceProxy)
        {
            return serviceProxy.FindById(id);
        }

        protected static List<DomainType> FindAll(ServiceProxyType serviceProxy)
        {
            return serviceProxy.FindAll();
        }

        public static List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc,  ServiceProxyType businessProxy)
        {
            return businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc );
        }

        protected static List<DomainType> FindAllByPage(PageQueryParams pageQueryParams,ServiceProxyType serviceProxy)
        {
            return serviceProxy.FindAllByPage(pageQueryParams);
        }

        public static List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams,ServiceProxyType businessProxy)
        {
            return  businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                  pageQueryParams);
        }


        #endregion

    }
}