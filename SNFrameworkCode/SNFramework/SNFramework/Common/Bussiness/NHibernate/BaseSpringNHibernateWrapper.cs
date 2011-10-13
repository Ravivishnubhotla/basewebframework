using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Entity;
using Spring.Context.Support;

namespace Legendigital.Framework.Common.Bussiness.NHibernate
{
    public class BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType>
        where DomainType : BaseTableEntity
        where ServiceProxyType : BaseSpringNHibernateEntityServiceProxy<DomainType>
        where WrapperType : BaseSpringNHibernateWrapper<DomainType, ServiceProxyType, WrapperType>
    {
        #region Member

        internal DomainType entity;

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

#endregion


        //internal BaseSpringNHibernateWrapper(DomainType entityObj)
        //{
        //    entity = entityObj;
        //}

        //#endregion

        //#region Equals 和 HashCode 方法覆盖
        //public override bool Equals(object obj)
        //{
        //    if (obj == null && entity != null)
        //    {
        //        //if (entity.SystemApplicationID == 0)
        //        //    return true;

        //        return false;
        //    }
        //    return entity.Equals(obj);
        //}

        //public override int GetHashCode()
        //{
        //    return entity.GetHashCode();
        //}
        //#endregion

        //#region Static Common Data Operation

        //private void Save(WrapperType obj, ServiceProxyType serviceProxy)
        //{
        //    serviceProxy.Save(obj.entity);
        //}

        //private void Update(WrapperType obj, ServiceProxyType serviceProxy)
        //{
        //    serviceProxy.Update(obj.entity);
        //}

        //private void SaveOrUpdate(WrapperType obj, ServiceProxyType serviceProxy)
        //{
        //    serviceProxy.SaveOrUpdate(obj.entity);
        //}

        //private void DeleteAll(ServiceProxyType serviceProxy)
        //{
        //    serviceProxy.DeleteAll();
        //}

        //private void DeleteByID(object id, ServiceProxyType serviceProxy)
        //{
        //    serviceProxy.DeleteByID(id);
        //}

        //private void PatchDeleteByIDs(object[] ids, ServiceProxyType serviceProxy)
        //{

        //    serviceProxy.PatchDeleteByIDs(ids);
        //}

        //private void Delete(WrapperType instance, ServiceProxyType serviceProxy)
        //{
        //    serviceProxy.Delete(instance.entity);
        //}

        //private void Refresh(WrapperType instance, ServiceProxyType serviceProxy)
        //{
        //    serviceProxy.Refresh(instance.entity);
        //}

        //private WrapperType FindById(object id, ServiceProxyType serviceProxy)
        //{
        //    return ConvertEntityToWrapper(serviceProxy.FindById(id));
        //}

        //private List<WrapperType> FindAll(ServiceProxyType serviceProxy)
        //{
        //    return ConvertToWrapperList(serviceProxy.FindAll());
        //}

        //private List<WrapperType> FindAllByPage(PageQueryParams pageQueryParams, ServiceProxyType serviceProxy)
        //{
        //    List<DomainType> list = serviceProxy.FindAllByPage(pageQueryParams);
        //    return ConvertToWrapperList(list);
        //}

        ////private List<WrapperType> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams, ServiceProxyType serviceProxy)
        ////{
        ////    if (string.IsNullOrEmpty(orderByColumnName))
        ////    {
        ////        orderByColumnName = WrapperType.PROPERTY_NAME_SYSTEMAPPLICATIONID;
        ////        isDesc = false;
        ////    }
        ////    return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams,serviceProxy);
        ////}

        //private List<WrapperType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams, ServiceProxyType serviceProxy)
        //{
        //    List<WrapperType> results = null;

        //    results = ConvertToWrapperList(
        //            serviceProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
        //                                          pageQueryParams));

        //    return results;
        //}

        //internal List<WrapperType> ConvertToWrapperList(List<DomainType> entitylist)
        //{
        //    List<WrapperType> list = new List<WrapperType>();
        //    foreach (DomainType lentity in entitylist)
        //    {
        //        list.Add(ConvertEntityToWrapper(lentity));
        //    }
        //    return list;
        //}

        //internal List<WrapperType> ConvertToWrapperList(IList<DomainType> entitylist)
        //{
        //    List<WrapperType> list = new List<WrapperType>();
        //    foreach (DomainType lentity in entitylist)
        //    {
        //        list.Add(ConvertEntityToWrapper(lentity));
        //    }
        //    return list;
        //}

        //internal List<DomainType> ConvertToEntityList(List<WrapperType> wrapperlist)
        //{
        //    List<DomainType> list = new List<DomainType>();
        //    foreach (WrapperType wrapper in wrapperlist)
        //    {
        //        list.Add(wrapper.entity);
        //    }
        //    return list;
        //}

        //internal static WrapperType ConvertEntityToWrapper(DomainType entity)
        //{
        //    if (entity == null)
        //        return null;

        //    if (entity.GetDataEntityKey() is int && (int)entity.GetDataEntityKey() == 0)
        //        return null;

        //    return new WrapperType(entity);
        //}

        //private static WrapperType GetNewWrapperTypeByEntity(DomainType entity)
        //{
        //    return new WrapperType(entity);
        //}







        //#endregion

    }
}
