using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.Extend;
using NHibernate;
using NHibernate.Criterion;

namespace Legendigital.Framework.Common.Data.Interfaces
{
    public interface IBaseNHibernateViewDataObject<DomainType> : IGenericViewDataObject<DomainType>
    {
        /// <summary>
        /// 将IList装换为类型化的List
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        List<DomainType> ConvertToTypedList(IList<DomainType> list);

        List<DomainType> FindAll(ICriterion[] criterias);
        List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems);
        List<DomainType> FindAllByPage(ICriterion[] criterias, PageQueryParams pageQueryParams);

        List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, PageQueryParams pageQueryParams);

        List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems,
                                                 string filterName, string cacheRegionName, PageQueryParams pageQueryParams);

        List<DomainType> FindAllWithCustomQuery(string queryString);
        List<DomainType> FindAllWithCustomQuery(string queryString, PageQueryParams pageQueryParams);

        List<DomainType> FindAllWithCustomQuery(string queryString,
                                                                NhibernateParameterCollection nhibernateQueryParams);

        List<DomainType> FindAllWithCustomQuery(string queryString,
                                                                NhibernateParameterCollection nhibernateQueryParams,
                                                                PageQueryParams pageQueryParams);

        IList FindIListWithCustomQuery(string queryString);
        IList FindIListWithCustomQuery(string queryString, PageQueryParams pageQueryParams);

        IList FindIListWithCustomQuery(string queryString,
                                                       NhibernateParameterCollection nhibernateQueryParams);

        IList FindIListWithCustomQuery(string queryString,
                                                       NhibernateParameterCollection nhibernateQueryParams,
                                                       PageQueryParams pageQueryParams);

        /// <summary>
        /// HQL标量查询
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        object FindScalarWithCustomQuery(string queryString);

        /// <summary>
        /// 带参数的HQL标量查询
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="nhibernateQueryParams"></param>
        /// <returns></returns>
        object FindScalarWithCustomQuery(string queryString,
                                                         NhibernateParameterCollection nhibernateQueryParams);

        void InitializeLazyProperties(DomainType instance);
        void InitializeLazyProperty(DomainType instance, string propertyName);
        List<DomainType> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria);

        List<DomainType> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria,
                                                                         DetachedCriteria detachedCriteriaCount,
                                                                         PageQueryParams pageQueryParams);

        System.Collections.IList ProjectionQuery(IProjection[] projections, ICriterion[] criterias, Order[] orders);

        object ProjectionSingleLineQuery(IProjection[] projections, ICriterion[] criterias,
                                                         Order[] orders);

        TypeScalar ProjectionScalarQuery<TypeScalar>(IProjection[] projections, ICriterion[] criterias,
                                                                     Order[] orders);

        NHibernateDynamicQueryGenerator<DomainType> GetNewQueryBuilder();
        List<DomainType> FindListByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder);
        List<DomainType> FindListByPageByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder, PageQueryParams pageQueryParams);
        DomainType FindSingleEntityByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder);
        List<DomainType> FindAllByOrderBy(string orderByColumn, bool isDesc, PageQueryParams pageQueryParams);
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc, PageQueryParams pageQueryParams);

        string[] PkPropertyName { get;}
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc);
    }
}