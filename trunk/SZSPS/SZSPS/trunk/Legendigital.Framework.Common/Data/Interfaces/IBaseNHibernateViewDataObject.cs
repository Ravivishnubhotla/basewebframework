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
        List<DomainType> FindAll(ICriterion[] criterias, int firstRow, int maxRows, out int recordCount);

        List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows,
                                                 out int recordCount);

        List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows,
                                                 string filterName, string cacheRegionName, out int recordCount);

        List<DomainType> FindAllWithCustomQuery(string queryString);
        List<DomainType> FindAllWithCustomQuery(string queryString, int firstRow, int maxRows);

        List<DomainType> FindAllWithCustomQuery(string queryString,
                                                                NhibernateParameterCollection nhibernateQueryParams);

        List<DomainType> FindAllWithCustomQuery(string queryString,
                                                                NhibernateParameterCollection nhibernateQueryParams,
                                                                int firstRow, int maxRows);

        IList FindIListWithCustomQuery(string queryString);
        IList FindIListWithCustomQuery(string queryString, int firstRow, int maxRows);

        IList FindIListWithCustomQuery(string queryString,
                                                       NhibernateParameterCollection nhibernateQueryParams);

        IList FindIListWithCustomQuery(string queryString,
                                                       NhibernateParameterCollection nhibernateQueryParams,
                                                       int firstRow, int maxRows);

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
                                                                         int firstRow, int maxRows, out int recordCount);

        System.Collections.IList ProjectionQuery(IProjection[] projections, ICriterion[] criterias, Order[] orders);

        object ProjectionSingleLineQuery(IProjection[] projections, ICriterion[] criterias,
                                                         Order[] orders);

        TypeScalar ProjectionScalarQuery<TypeScalar>(IProjection[] projections, ICriterion[] criterias,
                                                                     Order[] orders);

        NHibernateDynamicQueryGenerator<DomainType> GetNewQueryBuilder();
        List<DomainType> FindListByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder);
        List<DomainType> FindListByPageByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder, out int recordCount);
        DomainType FindSingleEntityByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder);
        List<DomainType> FindAllByOrderBy(string orderByColumn, bool isDesc, int firstRow, int maxRows, out int recordCount);
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc, int firstRow, int maxRows, out int recordCount);

        string[] PkPropertyName { get;}
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc);
    }
}