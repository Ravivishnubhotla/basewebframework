using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Web;
using Common.Logging;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.Extend;
using Legendigital.Framework.Common.Entity;
using Legendigital.Framework.Common.Utility;
using NHibernate;
using NHibernate.Collection;
using NHibernate.Context;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NHibernate.Metadata;
using NHibernate.Proxy;
using Spring.Data.NHibernate.Generic.Support;

namespace Legendigital.Framework.Common.Data.NHibernate
{
    public abstract class BaseNHibernateViewDataObject<DomainType, EntityKeyType> : HibernateDaoSupport,
                                                                     IBaseNHibernateViewDataObject<DomainType, EntityKeyType> where DomainType : BaseViewEntity<EntityKeyType>
    {
        protected ISession GetCurrentSession()
        {
            if (HttpContext.Current == null)
            {
                if (!CurrentSessionContext.HasBind(SessionFactory))
                {
                    CurrentSessionContext.Bind(SessionFactory.OpenSession());
                }
            }
            return HibernateTemplate.SessionFactory.GetCurrentSession();
        }

        #region 基本操作

        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual DomainType Load(EntityKeyType id)
        {
            try
            {
                //DomainType obj = this.HibernateTemplate.Load<DomainType>(id);

                var obj = GetCurrentSession().Load<DomainType>(id);

                if (obj.Equals(null))
                {
                    return default(DomainType);
                }
                else
                {
                    return obj;
                }
            }
            catch (ObjectNotFoundException oex)
            {
                Logger.Error("Load Object Failed:", oex);
                return default(DomainType);
            }
            catch (Exception ex)
            {
                Logger.Error("Load Object Failed:", ex);
                throw new DataException("Could not perform Load for " + typeof (DomainType).Name, ex);
            }
        }

 


        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="id"></param>
        public virtual void Load(DomainType instance, EntityKeyType id)
        {
            try
            {
                //this.HibernateTemplate.Load(instance, id);
                GetCurrentSession().Load(instance, id);
            }
            catch (Exception ex)
            {
                Logger.Error("Load Object Failed:", ex);
                throw new DataException("Could not perform Load for " + typeof (DomainType).Name, ex);
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
                //this.HibernateTemplate.Refresh(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("Refresh Object Failed:", ex);
                throw new DataException("Could not perform Refresh for " + typeof (DomainType).Name, ex);
            }
        }

        #endregion

        #region 日志对象

        private ILog logger;

        /// <summary>
        /// 日志
        /// </summary>
        public ILog Logger
        {
            get
            {
                if (logger == null)
                    logger = LogManager.GetLogger(GetType());
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
            return FindAllByPage(null);
        }

        public List<DomainType> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return FindAll(null, null, pageQueryParams);
        }

        #endregion

        #region 面向对象的查询方式

        public virtual List<DomainType> FindAll(ICriterion[] criterias)
        {
            return FindAll(criterias, null);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems)
        {
            return FindAll(criterias, sortItems, null);
        }

        public virtual List<DomainType> FindAllByPage(ICriterion[] criterias, PageQueryParams pageQueryParams)
        {
            return FindAll(criterias, null,   "", "", pageQueryParams);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems, PageQueryParams pageQueryParams)
        {
            return FindAll(criterias, sortItems, "", "", pageQueryParams);
        }

        public virtual List<DomainType> FindAll(ICriterion[] criterias, Order[] sortItems,
                                                string filterName, string cacheRegionName, PageQueryParams pageQueryParams)
        {
            try
            {
                int recordCount = 0;

                ISession session = GetCurrentSession();

                //如果有filter打开
                if (!string.IsNullOrEmpty(filterName))
                {
                    session.EnableFilter(filterName);
                }

                //查询l当前页记录的ICriteria
                ICriteria criteria = session.CreateCriteria(typeof (DomainType));
                //查询记录总数的ICriteria
                ICriteria criteriaCount = session.CreateCriteria(typeof (DomainType));


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
                recordCount = criteriaCount.UniqueResult<int>();

                //设置分页查询
                if (pageQueryParams != null)
                {
                    pageQueryParams.RecordCount = recordCount;
                    criteria.SetFirstResult(pageQueryParams.FristRecord);
                    criteria.SetMaxResults(pageQueryParams.MaxRecord);
                }

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
                Logger.Error(ex.Message);
                throw new DataException("Could not perform FindAll for " + typeof (DomainType).Name, ex);
            }
        }

        #endregion

        #region HQL集合查询

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString)
        {
            return FindAllWithCustomQuery(queryString, null, null);
        }

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString, PageQueryParams pageQueryParams)
        {
            return FindAllWithCustomQuery(queryString, null, pageQueryParams);
        }

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString,
                                                               NhibernateParameterCollection nhibernateQueryParams)
        {
            return FindAllWithCustomQuery(queryString, nhibernateQueryParams, null);
        }

        public virtual List<DomainType> FindAllWithCustomQuery(string queryString,
                                                               NhibernateParameterCollection nhibernateQueryParams,
                                                               PageQueryParams pageQueryParams)
        {
            if (string.IsNullOrEmpty(queryString)) throw new ArgumentNullException("queryString");

            try
            {
                ISession session = GetCurrentSession();


                IQuery query = session.CreateQuery(queryString);

                if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
                {
                    foreach (NhibernateParameter param in nhibernateQueryParams)
                    {
                        query.SetParameter(param.ParameterName, param.Value, param.DbType);
                    }
                }


                if (pageQueryParams != null)
                {
                    query.SetFirstResult(pageQueryParams.FristRecord);
                    query.SetMaxResults(pageQueryParams.MaxRecord);
                }

                return ConvertToTypedList(query.List<DomainType>());
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DataException("Could not perform FindAllWithCustomQuery for " + typeof (DomainType).Name, ex);
            }
        }


        public virtual IList FindIListWithCustomQuery(string queryString)
        {
            return FindIListWithCustomQuery(queryString, null, null);
        }

        public virtual IList FindIListWithCustomQuery(string queryString, PageQueryParams pageQueryParams)
        {
            return FindIListWithCustomQuery(queryString, null, pageQueryParams);
        }

        public virtual IList FindIListWithCustomQuery(string queryString,
                                                      NhibernateParameterCollection nhibernateQueryParams)
        {
            return FindIListWithCustomQuery(queryString, nhibernateQueryParams, null);
        }

        public virtual IList FindIListWithCustomQuery(string queryString,
                                                      NhibernateParameterCollection nhibernateQueryParams,
                                                      PageQueryParams pageQueryParams)
        {
            if (string.IsNullOrEmpty(queryString)) throw new ArgumentNullException("queryString");

            IList list = null;

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

                if (pageQueryParams!=null)
                {
                    query.SetFirstResult(pageQueryParams.FristRecord);
                    query.SetMaxResults(pageQueryParams.MaxRecord);
                }



                list = query.List();
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
                throw new DataException("Could not perform FindAllWithCustomQuery for " + typeof (DomainType).Name, ex);
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

                return query.UniqueResult();
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
                                                                                + instance.GetType() + ".");

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
                                                                        PageQueryParams pageQueryParams)
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
                pageQueryParams.RecordCount = criteriaCount.UniqueResult<int>();

                //设置分页查询
                criteria.SetFirstResult(pageQueryParams.FristRecord);
                criteria.SetMaxResults(pageQueryParams.MaxRecord);

                //获取当前页记录数
                IList<DomainType> result = criteria.List<DomainType>();

                if (result.Count > pageQueryParams.RecordCount)
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

        public virtual IList ProjectionQuery(IProjection[] projections, ICriterion[] criterias, Order[] orders)
        {
            ISession session = GetCurrentSession();

            try
            {
                ICriteria criteria = session.CreateCriteria(typeof (DomainType));

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
                throw new DataException("Could not perform ProjectionQuery for " + typeof (DomainType).Name, ex);
            }
        }

        public virtual object ProjectionSingleLineQuery(IProjection[] projections, ICriterion[] criterias,
                                                        Order[] orders)
        {
            ISession session = GetCurrentSession();
            try
            {
                ICriteria criteria = session.CreateCriteria(typeof (DomainType));

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
                throw new DataException("Could not perform ProjectionSingleLineQuery for " + typeof (DomainType).Name,
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
                return (TypeScalar) result;
        }

        #endregion

        #region 动态查询功能

        public NHibernateDynamicQueryGenerator<DomainType> GetNewQueryBuilder()
        {
            return new NHibernateDynamicQueryGenerator<DomainType>();
        }

        public List<DomainType> FindListByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder)
        {
            return queryBuilder.FindList(GetCurrentSession());
        }

        public List<DomainType> FindListByPageByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder,PageQueryParams pageQueryParams)
        {
            return queryBuilder.FindListByPage(GetCurrentSession(), pageQueryParams);
        }

        public DomainType FindSingleEntityByQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder)
        {
            return queryBuilder.FindSingleEntity(GetCurrentSession());
        }

        public List<DomainType> FindAllByOrderBy(string orderByColumn, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumn, isDesc, pageQueryParams);
        }

        public List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc,PageQueryParams pageQueryParams)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<DomainType>();

            //构造Filter查询条件
            AddQueryFiltersToQueryGenerator(filters, queryBuilder);

            AddDefaultOrderByToQueryGenerator(orderByColumn, isDesc, queryBuilder);

            List<DomainType> results = FindListByPageByQueryBuilder(queryBuilder, pageQueryParams);

            return results;
        }


        public List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<DomainType>();

            //构造Filter查询条件
            AddQueryFiltersToQueryGenerator(filters, queryBuilder);

            AddDefaultOrderByToQueryGenerator(orderByColumn, isDesc, queryBuilder);

            List<DomainType> results = FindListByQueryBuilder(queryBuilder);

            return results;
        }

        public abstract string[] PkPropertyName { get; }

        public virtual DomainType FullLoad(EntityKeyType id)
        {
            try
            {
                var obj = GetCurrentSession().Load<DomainType>(id);

                if (!NHibernateUtil.IsInitialized(obj))
                {
                    NHibernateUtil.Initialize(obj);
                }


                if (obj.Equals(null))
                {
                    return default(DomainType);
                }
                else
                {
                    return obj;
                }
            }
            catch (ObjectNotFoundException oex)
            {
                Logger.Info("Load Object No Existed:", oex);
                return default(DomainType);
            }
            catch (Exception ex)
            {
                Logger.Error("Load Object Failed:", ex);
                throw new DataException("Could not perform Load for " + typeof (DomainType).Name, ex);
            }
        }

        public ICriterion Not(ICriterion noCriterion)
        {
            return Restrictions.Not(noCriterion);
        }

        public ICriterion And(params ICriterion[] andCriterions)
        {
            if (andCriterions == null || andCriterions.Length <= 0)
                throw new ArgumentNullException(" andCriterions not allow null!", "andCriterions");
            if (andCriterions.Length == 1)
                return andCriterions[0];

            ICriterion andCriterion = andCriterions[0];

            for (int i = 1; i < andCriterions.Length; i++)
            {
                andCriterion = Restrictions.And(andCriterion, andCriterions[i]);
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
                orCriterion = Restrictions.Or(orCriterion, orCriterions[i]);
            }

            return orCriterion;
        }

        public int CountQueryBuilder(NHibernateDynamicQueryGenerator<DomainType> queryBuilder)
        {
            return queryBuilder.GetCount(GetCurrentSession());
        }

        public List<DomainType> FindDistinctList(NHibernateDynamicQueryGenerator<DomainType> queryBuilder)
        {
            return queryBuilder.FindList(GetCurrentSession(), true);
        }

        public List<DomainType> FindDistinctListByPage(NHibernateDynamicQueryGenerator<DomainType> queryBuilder,PageQueryParams pageQueryParams)
        {
            return queryBuilder.FindDistinctListByPage(GetCurrentSession(), pageQueryParams);
        }

        public abstract Type GetFieldTypeByFieldName(string fieldName);

        public abstract Type GetFieldTypeByFieldName(string fieldName, string tableAliasName);

        protected void AddQueryFiltersToQueryGenerator(List<QueryFilter> filters,
                                                       NHibernateDynamicQueryGenerator<DomainType> queryGenerator)
        {
            //构造Filter查询条件
            foreach (QueryFilter queryFilter in filters)
            {
                if(!queryFilter.FilterFieldName.Contains("."))
                {
                    ICriterion whereClause =
                        queryFilter.GenerateNhibernateCriterion(GetFieldTypeByFieldName(queryFilter.FilterFieldName));
                    if (whereClause != null)
                        queryGenerator.AddWhereClause(whereClause);
                }
                else
                {
                    string tableAliasName = queryFilter.FilterFieldName.Split('.')[0];

                    if (!queryGenerator.HasIncludeTable(tableAliasName))
                    {
                        InClude_Parent_Table(tableAliasName, queryGenerator);
                    }

                    ICriterion whereClause = queryFilter.GenerateNhibernateCriterion(GetFieldTypeByFieldName(queryFilter.FilterFieldName, tableAliasName));
                    
                    if (whereClause != null)
                        queryGenerator.AddWhereClause(whereClause);
                }
            }
        }

        public abstract void InClude_Parent_Table(string parent_alias,
                                                  NHibernateDynamicQueryGenerator<DomainType> queryGenerator);


        protected void AddDefaultOrderByToQueryGenerator(string orderByColumn, bool isDesc,
                                                         NHibernateDynamicQueryGenerator<DomainType> queryGenerator)
        {
            //没有排序字段用主键来排序
            if (orderByColumn == string.Empty)
            {
                queryGenerator.AddOrderBy(Property.ForName(PkPropertyName[0]).Desc());
            }
            else
            {
                if (orderByColumn.Contains("."))
                {
                    string tableAliasName = orderByColumn.Split('.')[0];

                    if (!queryGenerator.HasIncludeTable(tableAliasName))
                    {
                        InClude_Parent_Table(tableAliasName, queryGenerator);
                    }
                }

                if (isDesc)
                    queryGenerator.AddOrderBy(Property.ForName(orderByColumn).Desc());
                else
                    queryGenerator.AddOrderBy(Property.ForName(orderByColumn).Asc());
            }
        }


        public List<CType> FindListByProjection<CType>(NHibernateDynamicQueryGenerator<DomainType> queryBuilder,
                                                       IProjection projection)
        {
            return queryBuilder.FindListByProjection<CType>(GetCurrentSession(), projection);
        }

        public CType FindSingleByProjection<CType>(NHibernateDynamicQueryGenerator<DomainType> queryBuilder,
                                                   IProjection projection)
        {
            return queryBuilder.FindSingleByProjection<CType>(GetCurrentSession(), projection);
        }

        public IProjection GetDistinctProperty(PropertyProjection projection)
        {
            return Projections.Distinct(projection);
        }

        #endregion

        #region 其他功能

        /// <summary>
        /// 获取数据元数据
        /// </summary>
        /// <returns>元数据</returns>
        public virtual IClassMetadata GetClassMetadata()
        {
            try
            {
                return HibernateTemplate.SessionFactory.GetClassMetadata(typeof (DomainType));
            }
            catch (Exception ex)
            {
                Logger.Error("GetClassMetadata Failed:", ex);
                throw new DataException("Could not perform GetClassMetadata for " + typeof (DomainType).Name, ex);
            }
        }

        /// <summary>
        /// 查找用户是否包含属性
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <returns></returns>
        public bool CheckEntityHasProperty(string propertyName)
        {
            IClassMetadata classMetadata = GetClassMetadata();

            return (classMetadata.GetPropertyType(propertyName) != null);
        }

        /// <summary>
        /// 查找用户是否包含属性
        /// </summary>
        /// <param name="propertyName">属性名</param>
        /// <param name="domain">类型</param>
        /// <returns></returns>
        public object GetEntityPropertyValue(string propertyName, DomainType domain)
        {
            IClassMetadata classMetadata = GetClassMetadata();

            return (classMetadata.GetPropertyValue(domain, propertyName, EntityMode.Poco));
        }

        /// <summary>
        /// Linq查询
        /// </summary>
        /// <param name="query">Linq表达式</param>
        /// <returns></returns>
        public virtual List<DomainType> QueryOver(Expression<Func<DomainType>> query)
        {
            ISession session = GetCurrentSession();

            return new List<DomainType>(session.QueryOver(query).List<DomainType>());
        }

        /// <summary>
        /// SQL语句分页查询
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="countsql"></param>
        /// <param name="pageQueryParams"></param>
        /// <returns></returns>
        public virtual List<DomainType> FindAllBySqlAndPage(string sql, string countsql, PageQueryParams pageQueryParams)
        {
            pageQueryParams.RecordCount = GetCurrentSession().CreateSQLQuery(countsql).UniqueResult<int>();

            return ConvertToTypedList(
                GetCurrentSession().CreateSQLQuery(sql).AddEntity(typeof(DomainType)).SetFirstResult(pageQueryParams.FristRecord).SetMaxResults(pageQueryParams.MaxRecord).List<DomainType>());
        }
        /// <summary>
        /// SQL语句直接查询
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public virtual List<DomainType> FindAllBySql(string sql)
        {
            return ConvertToTypedList(
                GetCurrentSession().CreateSQLQuery(sql).AddEntity(typeof(DomainType)).List<DomainType>());
        }


        #endregion



    }
}