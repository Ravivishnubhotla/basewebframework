using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.Extend;
using Legendigital.Framework.Common.Utility;
using NHibernate;
using NHibernate.Collection;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NHibernate.Proxy;
using NHibernate.Util;
using Spring.Data.NHibernate.Generic.Support;
using IList=System.Collections.IList;

namespace Legendigital.Framework.Common.Data.NHibernate
{
    public abstract class BaseNHibernateViewDataObject<DomainType> : HibernateDaoSupport, IBaseNHibernateViewDataObject<DomainType>
    {
        protected ISession GetCurrentSession()
        {
            return this.HibernateTemplate.SessionFactory.GetCurrentSession();
        }


        #region 基本操作

       
        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual DomainType Load(object id)
        {
            try
            {
                DomainType obj = GetCurrentSession().Load<DomainType>(id);

                if(obj.Equals(null))
                {
                    return default(DomainType);
                }
                else
                {
                    return obj;
                }
            }
            catch(ObjectNotFoundException oex)
            {
                return default(DomainType);
            }
            catch (Exception ex)
            {
                Logger.Error("Load Object Failed:", ex);
                throw new DataException("Could not perform Load for " + typeof(DomainType).Name, ex);
            }
        }


        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="id"></param>
        public virtual void Load(DomainType instance, object id)
        {
            try
            {
                GetCurrentSession().Load(instance, id);
            }
            catch (Exception ex)
            {
                Logger.Error("Load Object Failed:", ex);
                throw new DataException("Could not perform Load for " + typeof(DomainType).Name, ex);
            }
        }


        /// <summary>
        /// 刷新对象
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Refresh(DomainType instance)
        {
            try
            {
                GetCurrentSession().Refresh(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("Refresh Object Failed:", ex);
                throw new DataException("Could not perform Refresh for " + typeof(DomainType).Name, ex);
            }
        }

        #endregion

        #region 日志对象

        private ILog logger = null;

        /// <summary>
        /// 日志
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

        #endregion

        #region 受保护的方法

        /// <summary>
        /// 将IList装换为类型化的List
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public virtual List<DomainType> ConvertToTypedList(IList<DomainType> list)
        {
            if (list == null) return null;
            var typedList = new List<DomainType>();
            foreach (DomainType o in list)
            {
                typedList.Add(o);
            }
            return typedList;
        }


        #endregion

        #region 查找所有的数据

        public List<DomainType> FindAll()
        {
            return FindAll(int.MinValue, int.MinValue);
        }

        public List<DomainType> FindAll(int firstRow, int maxRows)
        {
            int recordCount = 0;
            return FindAll(null, null, firstRow, maxRows, out recordCount);
        }

        #endregion

        #region 面向对象的查询方式

        public virtual List<DomainType> FindAll(ICriterion[] criterias)
        {
            return FindAll(criterias, null);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems)
        {
            int recordCount = 0;
            return FindAll(criterias, sortItems, int.MinValue, int.MinValue, out recordCount);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, int firstRow, int maxRows, out int recordCount)
        {
            return FindAll(criterias, null, firstRow, maxRows, "", "", out recordCount);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows,
                                                out int recordCount)
        {
            return FindAll(criterias, sortItems, firstRow, maxRows, "", "", out recordCount);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows,
                                                string filterName, string cacheRegionName, out int recordCount)
        {
            ISession session = GetCurrentSession();

            try
            {

                //如果有filter打开
                if (!string.IsNullOrEmpty(filterName))
                {
                    session.EnableFilter(filterName);
                }

                //查询l当前页记录的ICriteria
                ICriteria criteria = session.CreateCriteria(typeof(DomainType));
                //查询记录总数的ICriteria
                ICriteria criteriaCount = session.CreateCriteria(typeof(DomainType));


                //加载查询条件
                if (criterias != null)
                {
                    foreach (ICriterion cond in criterias)
                    {
                        criteria.Add(cond);
                        criteriaCount.Add(cond);
                    }
                }

                //加载排序条件
                if (sortItems != null)
                {
                    foreach (Order order in sortItems)
                    {
                        //查询记录总数的ICriteria不需要加载排序条件
                        criteria.AddOrder(order);
                    }
                }

                //打开缓存
                if (!string.IsNullOrEmpty(cacheRegionName))
                {
                    criteria.SetCacheable(true);
                    criteria.SetCacheRegion(cacheRegionName);
                }

                //投影查询获取记录总数
                criteriaCount.SetProjection(Projections.RowCount());
                recordCount = criteriaCount.SetMaxResults(1).UniqueResult<int>();

                //设置分页查询
                if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);

                //获取当前页记录数
                IList<DomainType> result = criteria.List<DomainType>();

                if (result.Count > recordCount)
                {
                    throw new Exception("Query Count Error!");
                }

                //关闭缓存
                if (!string.IsNullOrEmpty(cacheRegionName))
                {
                    criteria.SetCacheable(false);
                }

                //如果有filter关闭
                if (!string.IsNullOrEmpty(filterName))
                {
                    session.DisableFilter(filterName);
                }

                return ConvertToTypedList(result);

            }
            catch (Exception ex)
            {
                this.Logger.Error(ex.Message);
                throw new DataException("Could not perform FindAll for " + typeof(DomainType).Name, ex);
            }
        }

        #endregion

        #region HQL集合查询

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString)
        {
            return FindAllWithCustomQuery(queryString, null, int.MinValue, int.MinValue);
        }

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString, int firstRow, int maxRows)
        {
            return FindAllWithCustomQuery(queryString, null, firstRow, maxRows);
        }

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString,
                                                               NhibernateParameterCollection nhibernateQueryParams)
        {
            return FindAllWithCustomQuery(queryString, nhibernateQueryParams, int.MinValue, int.MinValue);
        }

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString,
                                                               NhibernateParameterCollection nhibernateQueryParams,
                                                               int firstRow, int maxRows)
        {
            if (string.IsNullOrEmpty(queryString)) throw new ArgumentNullException("queryString");

            ISession session = GetCurrentSession();

            try
            {
                IQuery query = session.CreateQuery(queryString);

                if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
                {
                    foreach (NhibernateParameter param in nhibernateQueryParams)
                    {
                        query.SetParameter(param.ParameterName, param.Value, param.DbType);
                    }
                }

                if (firstRow != int.MinValue) query.SetFirstResult(firstRow);

                if (maxRows != int.MinValue) query.SetMaxResults(maxRows);

                return ConvertToTypedList(query.List<DomainType>());
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DataException("Could not perform FindAllWithCustomQuery for " + typeof(DomainType).Name, ex);
            }

        }


        public virtual IList FindIListWithCustomQuery(string queryString)
        {
            return FindIListWithCustomQuery(queryString, null, int.MinValue, int.MinValue);
        }

        public virtual IList FindIListWithCustomQuery(string queryString, int firstRow, int maxRows)
        {
            return FindIListWithCustomQuery(queryString, null, firstRow, maxRows);
        }

        public virtual IList FindIListWithCustomQuery(string queryString,
                                                      NhibernateParameterCollection nhibernateQueryParams)
        {
            return FindIListWithCustomQuery(queryString, nhibernateQueryParams, int.MinValue, int.MinValue);
        }

        public virtual IList FindIListWithCustomQuery(string queryString,
                                                      NhibernateParameterCollection nhibernateQueryParams,
                                                      int firstRow, int maxRows)
        {
            if (string.IsNullOrEmpty(queryString)) throw new ArgumentNullException("queryString");

            IList list = null;

            ISession session = GetCurrentSession();

            try
            {
                //list = HibernateTemplate.ExecuteFind(
                //    delegate(ISession session)
                //        {
                IQuery query = session.CreateQuery(queryString);

                if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
                {
                    foreach (NhibernateParameter param in nhibernateQueryParams)
                    {
                        query.SetParameter(param.ParameterName, param.Value, param.DbType);
                    }
                }

                if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) query.SetMaxResults(maxRows);

                list = query.List();
                //});
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DataException("Could not perform FindAllWithCustomQuery for " + typeof(DomainType).Name, ex);
            }

            return list;
        }

        #endregion

        #region HQL标量查询

        /// <summary>
        /// HQL标量查询
        /// </summary>
        /// <param name="queryString"></param>
        /// <returns></returns>
        public virtual object FindScalarWithCustomQuery(string queryString)
        {
            return FindScalarWithCustomQuery(queryString, null);
        }

        /// <summary>
        /// 带参数的HQL标量查询
        /// </summary>
        /// <param name="queryString"></param>
        /// <param name="nhibernateQueryParams"></param>
        /// <returns></returns>
        public virtual object FindScalarWithCustomQuery(string queryString,
                                                        NhibernateParameterCollection nhibernateQueryParams)
        {
            ISession session = GetCurrentSession();

            try
            {
                IQuery query = session.CreateQuery(queryString);

                if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
                {
                    foreach (NhibernateParameter param in nhibernateQueryParams)
                    {
                        query.SetParameter(param.ParameterName, param.Value, param.DbType);
                    }
                }

                return query.SetMaxResults(1).UniqueResult();
            }
            catch (Exception ex)
            {
                throw new DataException("Could not perform FindScalar for custom query : " + queryString, ex);
            }
        }

        #endregion

        #region 初始化实体

        public virtual void InitializeLazyProperties(DomainType instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");

            ISession session = GetCurrentSession();

            foreach (object val in ReflectionUtil.GetPropertiesDictionary(instance).Values)
            {
                if (val is INHibernateProxy || val is IPersistentCollection)
                {
                    if (!NHibernateUtil.IsInitialized(val))
                    {
                        session.Lock(instance, LockMode.None);
                        NHibernateUtil.Initialize(val);
                    }
                }
            }
        }

        public virtual void InitializeLazyProperty(DomainType instance, string propertyName)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException("collectionPropertyName");

            IDictionary properties = ReflectionUtil.GetPropertiesDictionary(instance);
            if (!properties.Contains(propertyName))
                throw new ArgumentOutOfRangeException("collectionPropertyName", "Property "
                                                                                + propertyName +
                                                                                " doest not exist for type "
                                                                                + instance.GetType().ToString() + ".");

            ISession session = GetCurrentSession();

            object val = properties[propertyName];

            if (val is INHibernateProxy || val is IPersistentCollection)
            {
                if (!NHibernateUtil.IsInitialized(val))
                {
                    session.Lock(instance, LockMode.None);
                    NHibernateUtil.Initialize(val);
                }
            }
        }

        #endregion

        #region 游离条件查询

        public virtual List<DomainType> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria)
        {
            if (detachedCriteria == null) throw new ArgumentNullException("detachedCriteria");

            ISession session = GetCurrentSession();

            try
            {
                IList<DomainType> result = detachedCriteria.GetExecutableCriteria(session).List<DomainType>();
                return ConvertToTypedList(result);
            }
            catch (Exception ex)
            {
                Logger.Error("Could not perform Find List By DetachedCriteriaQuery : " + ex.Message);
                throw new DataException("Could not perform Find List By DetachedCriteriaQuery : ", ex);
            }
        }

        public virtual List<DomainType> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria,
                                                                        DetachedCriteria detachedCriteriaCount,
                                                                        int firstRow, int maxRows, out int recordCount)
        {
            if (detachedCriteria == null) throw new ArgumentNullException("detachedCriteria");

            ISession session = GetCurrentSession();

            try
            {
                //查询l当前页记录的ICriteria
                ICriteria criteria = detachedCriteria.GetExecutableCriteria(session);
                //查询记录总数的ICriteria
                ICriteria criteriaCount = detachedCriteriaCount.GetExecutableCriteria(session);
                //投影查询获取记录总数
                criteriaCount.SetProjection(Projections.RowCount());
                recordCount = criteriaCount.SetMaxResults(1).UniqueResult<int>();

                //设置分页查询
                if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
                if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);

                //获取当前页记录数
                IList<DomainType> result = criteria.List<DomainType>();

                if (result.Count > recordCount)
                {
                    throw new Exception("Query Count Error!");
                }
                return ConvertToTypedList(result);
            }
            catch (Exception ex)
            {
                Logger.Error("Could not perform Find List By DetachedCriteriaQuery : " + ex.Message);
                throw new DataException("Could not perform Find List By DetachedCriteriaQuery : ", ex);
            }
        }

        #endregion

        #region 投影查询

        public virtual System.Collections.IList ProjectionQuery(IProjection[] projections, ICriterion[] criterias, Order[] orders)
        {
            ISession session = GetCurrentSession();

            try
            {
                ICriteria criteria = session.CreateCriteria(typeof(DomainType));

                if (criterias != null)
                {
                    foreach (ICriterion cond in criterias)
                    {
                        criteria.Add(cond);
                    }
                }

                if (orders != null)
                {
                    foreach (Order order in orders)
                    {
                        criteria.AddOrder(order);
                    }
                }

                if (projections != null)
                {
                    foreach (IProjection projection in projections)
                    {
                        criteria.SetProjection(projection);
                    }
                }

                return criteria.List();
            }
            catch (Exception ex)
            {
                throw new DataException("Could not perform ProjectionQuery for " + typeof(DomainType).Name, ex);
            }
        }

        public virtual object ProjectionSingleLineQuery(IProjection[] projections, ICriterion[] criterias,
                                                        Order[] orders)
        {
            ISession session = GetCurrentSession();
            try
            {
                ICriteria criteria = session.CreateCriteria(typeof(DomainType));

                if (criterias != null)
                {
                    foreach (ICriterion cond in criterias)
                    {
                        criteria.Add(cond);
                    }
                }

                criteria.SetMaxResults(1);

                if (orders != null)
                {
                    foreach (Order order in orders)
                    {
                        criteria.AddOrder(order);
                    }
                }

                if (projections != null)
                {
                    foreach (IProjection projection in projections)
                    {
                        criteria.SetProjection(projection);
                    }
                }

                IList result = criteria.List();

                if (result == null)
                    return null;
                else
                    return result[0];
            }
            catch (Exception ex)
            {
                throw new DataException("Could not perform ProjectionSingleLineQuery for " + typeof(DomainType).Name,
                                        ex);
            }
        }

        public virtual TypeScalar ProjectionScalarQuery<TypeScalar>(IProjection[] projections, ICriterion[] criterias,
                                                                    Order[] orders)
        {
            object result = ProjectionSingleLineQuery(projections, criterias, orders);

            if (result == null)
                return default(TypeScalar);
            else
                return (TypeScalar)result;
        }


        #endregion

        #region 动态查询功能

        public ICriterion Not(ICriterion noCriterion)
        {
            return Expression.Not(noCriterion);
        }

        public ICriterion And(params ICriterion[] andCriterions)
        {
            if (andCriterions == null || andCriterions.Length<=0)
                throw new ArgumentNullException(" andCriterions not allow null!", "andCriterions");
            if (andCriterions.Length == 1)
                return andCriterions[0];

            ICriterion andCriterion = andCriterions[0];

            for (int i = 1; i < andCriterions.Length; i++)
            {
                andCriterion = Expression.And(andCriterion, andCriterions[i]);
            }

            return andCriterion;
        }

        public ICriterion Or(params ICriterion[] orCriterions)
        {
            if (orCriterions == null || orCriterions.Length <= 0)
                throw new ArgumentNullException(" orCriterions not allow null!", "orCriterions");
            if (orCriterions.Length == 1)
                return orCriterions[0];

            ICriterion orCriterion = orCriterions[0];

            for (int i = 1; i < orCriterions.Length; i++)
            {
                orCriterion = Expression.Or(orCriterion, orCriterions[i]);
            }

            return orCriterion;
        }


        public NHibernateDynamicQueryGenerator<DomainType> GetNewQueryBuilder()
        {
            return new NHibernateDynamicQueryGenerator<DomainType>();
        }

        public List<DomainType> FindListByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder)
        {
            return queryBuilder.FindList(GetCurrentSession());
        }

        public int CountQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder)
        {
            return queryBuilder.GetCount(GetCurrentSession());
        }


        public List<DomainType> FindListByPageByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder, int pageIndex, int pageSize, out int recordCount)
        {
            queryBuilder.SetFirstResult((pageIndex - 1)*pageSize);

            queryBuilder.SetMaxResults(pageSize);

            return queryBuilder.FindListByPage(GetCurrentSession(), out recordCount);
        }


        public List<DomainType> FindDistinctList(NHibernateDynamicQueryGenerator<DomainType> queryBuilder)
        {
            return queryBuilder.FindList(GetCurrentSession(),true);
        }

        public List<DomainType> FindDistinctListByPage(NHibernateDynamicQueryGenerator<DomainType> queryBuilder, out int recordCount)
        {
            return queryBuilder.FindDistinctListByPage(GetCurrentSession(), out recordCount);
        }

        public List<DomainType> FindListByPageByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder, out int recordCount)
        {
            return queryBuilder.FindListByPage(GetCurrentSession(), out recordCount);
        }

        public DomainType FindSingleEntityByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder)
        {
            return queryBuilder.FindSingleEntity(GetCurrentSession());
        }

        public List<DomainType> FindAllByOrderBy(string orderByColumn, bool isDesc, int firstRow, int maxRows, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumn, isDesc, firstRow, maxRows, out recordCount);
        }

        public abstract Type GetFieldTypeByFieldName(string fieldName);

        protected void AddQueryFiltersToQueryGenerator(List<QueryFilter> filters, NHibernateDynamicQueryGenerator<DomainType> queryGenerator)
        {
            //构造Filter查询条件
            foreach (QueryFilter queryFilter in filters)
            {
                ICriterion whereClause = queryFilter.GenerateNhibernateCriterion(GetFieldTypeByFieldName(queryFilter.FilterFieldName));
                if (whereClause != null)
                    queryGenerator.AddWhereClause(whereClause);
            }
        }

        protected void AddDefaultOrderByToQueryGenerator(string orderByColumn, bool isDesc, NHibernateDynamicQueryGenerator<DomainType> queryGenerator)
        {
            //没有排序字段用主键来排序
            if (orderByColumn == string.Empty)
            {
                queryGenerator.AddOrderBy(Property.ForName(this.PkPropertyName[0]).Desc());
            }
            else
            {
                if (isDesc)
                    queryGenerator.AddOrderBy(Property.ForName(orderByColumn).Desc());
                else
                    queryGenerator.AddOrderBy(Property.ForName(orderByColumn).Asc());
            }
        }


        public List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc, int firstRow, int maxRows, out int recordCount)
        {
            NHibernateDynamicQueryGenerator<DomainType> queryBuilder = new NHibernateDynamicQueryGenerator<DomainType>();

            //构造Filter查询条件
            AddQueryFiltersToQueryGenerator(filters, queryBuilder);

            AddDefaultOrderByToQueryGenerator(orderByColumn, isDesc, queryBuilder);

            queryBuilder.SetFirstResult(firstRow);

            queryBuilder.SetMaxResults(maxRows);

            List<DomainType> results = FindListByPageByQueryBuilder(queryBuilder, out recordCount);

            return results;
        }


        public List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc)
        {
            NHibernateDynamicQueryGenerator<DomainType> queryBuilder = new NHibernateDynamicQueryGenerator<DomainType>();

            //构造Filter查询条件
            foreach (QueryFilter queryFilter in filters)
            {
                ICriterion whereClause = queryFilter.GenerateNhibernateCriterion(GetFieldTypeByFieldName(queryFilter.FilterFieldName));
                if (whereClause != null)
                    queryBuilder.AddWhereClause(whereClause);
            }

            //没有排序字段用主键来排序
            if (orderByColumn == string.Empty)
            {
                queryBuilder.AddOrderBy(Property.ForName(this.PkPropertyName[0]).Desc());
            }
            else
            {
                if (isDesc)
                    queryBuilder.AddOrderBy(Property.ForName(orderByColumn).Desc());
                else
                    queryBuilder.AddOrderBy(Property.ForName(orderByColumn).Asc());
            }

            List<DomainType> results = FindListByQueryBuilder(queryBuilder);

            return results;
        }

        public abstract string[] PkPropertyName { get; }

        public List<CType> FindListByProjection<CType>(NHibernateDynamicQueryGenerator<DomainType> queryBuilder, IProjection projection)
        {
            return queryBuilder.FindListByProjection<CType>(GetCurrentSession(),projection);
        }

        public CType FindSingleByProjection<CType>(NHibernateDynamicQueryGenerator<DomainType> queryBuilder, IProjection projection)
        {
            return queryBuilder.FindSingleByProjection<CType>(GetCurrentSession(),projection);
        }

        public IProjection GetDistinctProperty(PropertyProjection projection)
        {
            return Projections.Distinct(projection);
        }

        #endregion
    }
}