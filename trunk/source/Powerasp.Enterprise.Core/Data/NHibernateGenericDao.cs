using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using log4net;
using NHibernate;
using NHibernate.Collection;
using NHibernate.Expression;
using NHibernate.Metadata;
using NHibernate.Proxy;
using NHibernate.Type;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.Utility;

namespace Powerasp.Enterprise.Core.Data
{

    #region 委托的定义

    /// <summary>
    /// 数据变更事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataChangedEventHandler(object sender, EventArgs e);
    /// <summary>
    /// 数据创建委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataCreatedEventHandler(object sender, EventArgs e);
    /// <summary>
    /// 数据更新委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataUpdatedEventHandler(object sender, EventArgs e);
    /// <summary>
    /// 数据删除委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataDeletedEventHandler(object sender, EventArgs e);

    #endregion

    /// <summary>
    /// Nhibernate数据层访问类基类.
    /// </summary>
    public class NHibernateGenericDao<T> : INHibernateGenericDao<T>
    {
        #region 私有成员变量

        private readonly ISessionManager sessionManager;
        private string sessionFactoryAlias = null;
        private IClassMetadata currentClassMetaData = null;

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

        #region 事件委托

        public event DataChangedEventHandler DataChanged;
        public event DataCreatedEventHandler DataCreated;
        public event DataUpdatedEventHandler DataUpdated;
        public event DataDeletedEventHandler DataDeleted;

        protected virtual void OnDataChanged(EventArgs e)
        {
            if (DataChanged != null)
            {
                DataChanged(this, e);
            }
        }
        protected virtual void OnDataCreated(EventArgs e)
        {
            if (DataCreated != null)
            {
                DataCreated(this, e);
            }
        }
        protected virtual void OnDataUpdated(EventArgs e)
        {
            if (DataUpdated != null)
            {
                DataUpdated(this, e);
            }
        }
        protected virtual void OnDataDeleted(EventArgs e)
        {
            if (DataDeleted != null)
            {
                DataDeleted(this, e);
            }
        }

        #endregion

        #region 构造器

        public NHibernateGenericDao(ISessionManager sessionManager)
        {
            this.sessionManager = sessionManager;
        }

        public NHibernateGenericDao(ISessionManager sessionManager, string sessionFactoryAlias)
            : this(sessionManager)
        {
            this.sessionFactoryAlias = sessionFactoryAlias;
        }

        #endregion

        #region 属性

        protected ISessionManager SessionManager
        {
            get { return sessionManager; }
        }

        public string SessionFactoryAlias
        {
            get { return sessionFactoryAlias; }
            set { sessionFactoryAlias = value; }
        }

        #endregion

        #region 受保护的方法

        /// <summary>
        /// 获取session
        /// </summary>
        /// <returns></returns>
        protected ISession GetSession()
        {
            if (sessionFactoryAlias == null || sessionFactoryAlias.Length == 0)
            {
                return sessionManager.OpenSession();
            }
            else
            {
                return sessionManager.OpenSession(sessionFactoryAlias);
            }
        }

        /// <summary>
        /// 将IList装换为类型化的List
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        protected virtual List<T> ConvertToTypedList(IList list)
        {
            if (list == null) return null;
            List<T> typedList = new List<T>();
            foreach (object o in list)
            {
                typedList.Add((T)o);
            }
            return typedList;
        }

        #endregion

        #region 基本操作

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="instance">持久化类</param>
        public virtual void Save(T instance)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.Save(instance);
                    OnDataCreated(EventArgs.Empty);
                    OnDataChanged(EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    Logger.Error("Save Object Failed:", ex);
                    throw new DataException("Could not perform Save for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="instance">持久化类</param>
        public virtual void Update(T instance)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.Update(instance);
                    OnDataUpdated(EventArgs.Empty);
                    OnDataChanged(EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    Logger.Error("Update Object Failed:", ex);
                    throw new DataException("Could not perform Update for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 保存或者更新数据
        /// </summary>
        /// <param name="instance">持久化类</param>
        public virtual void SaveOrUpdate(T instance)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.SaveOrUpdate(instance);
                    OnDataChanged(EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    Logger.Error("SaveOrUpdate Object Failed:", ex);
                    throw new DataException("Could not perform SaveOrUpdate for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        public virtual void SaveOrUpdateCopy(T instance)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.SaveOrUpdateCopy(instance);
                    OnDataChanged(EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    Logger.Error("SaveOrUpdateCopy Object Failed:", ex);
                    throw new DataException("Could not perform SaveOrUpdateCopy for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="id"></param>
        public virtual void SaveOrUpdateCopy(T instance, object id)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.SaveOrUpdateCopy(instance, id);
                    OnDataChanged(EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    Logger.Error("SaveOrUpdateCopy Object Failed:", ex);
                    throw new DataException("Could not perform SaveOrUpdateCopy for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 部分更新
        /// </summary>
        /// <param name="instance">更新的值</param>
        /// <param name="id">id</param>
        /// <param name="updatePropertyNames">需要更新的属性名</param>
        public virtual void PartUpdate(T instance, object id, string[] updatePropertyNames)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    T lastInstance = Load(id);
                    Type t = typeof(T);
                    foreach (string propertyName in updatePropertyNames)
                    {
                        PropertyInfo setPropertyInfo = t.GetProperty(propertyName);
                        setPropertyInfo.SetValue(lastInstance, setPropertyInfo.GetValue(instance, null), null);
                    }
                    Update(instance);
                }
                catch (Exception ex)
                {
                    Logger.Error("PartUpdate Object Failed:", ex);
                    throw new DataException("Could not perform PartUpdate for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="instance">需要删除的业务实体</param>
        public virtual void Delete(T instance)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.Delete(instance);
                    OnDataDeleted(EventArgs.Empty);
                    OnDataChanged(EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    Logger.Error("Delete Object Failed:", ex);
                    throw new DataException("Could not perform Delete for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 通过ID删除数据
        /// </summary>
        /// <param name="id"></param>
        public virtual void DeleteByID(object id)
        {
            T obj = Load(id);
            if (obj!=null)
                Delete(obj);
        }

        /// <summary>
        /// 删除所有的数据
        /// </summary>
        public virtual void DeleteAll()
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.Delete(String.Format("from {0}", typeof(T).Name));
                    OnDataDeleted(EventArgs.Empty);
                    OnDataChanged(EventArgs.Empty);
                }
                catch (Exception ex)
                {
                    throw new DataException("Could not perform DeleteAll for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Load(object id)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    return session.Load<T>(id);
                }
                catch (Exception ex)
                {
                    Logger.Error("Load Object Failed:", ex);
                    throw new DataException("Could not perform Load for " + typeof(T).Name, ex);
                }
            }
        }
        
        /// <summary>
        /// 加载对象
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="id"></param>
        public virtual void Load(T instance, object id)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.Load(instance,id);
                }
                catch (Exception ex)
                {
                    Logger.Error("Load Object Failed:", ex);
                    throw new DataException("Could not perform Load for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 刷新对象
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Refresh(T instance)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.Refresh(instance);
                }
                catch (Exception ex)
                {
                    Logger.Error("Refresh Object Failed:", ex);
                    throw new DataException("Could not perform Refresh for " + typeof(T).Name, ex);
                }
            }
        }


        /// <summary>
        /// 从session中移除对象
        /// </summary>
        /// <param name="instance"></param>
        public virtual void Evict(T instance)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.Evict(instance);
                }
                catch (Exception ex)
                {
                    Logger.Error("Evict Object Failed:", ex);
                    throw new DataException("Could not perform Evict for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 锁定对象
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="lockMode"></param>
        public virtual void Lock(T instance, LockMode lockMode)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.Lock(instance, lockMode);
                }
                catch (Exception ex)
                {
                    Logger.Error("Lock Object Failed:", ex);
                    throw new DataException("Could not perform Lock for " + typeof(T).Name, ex);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="instance"></param>
        /// <param name="replicationMode"></param>
        public virtual void Replicate(object instance, ReplicationMode replicationMode)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    session.Replicate(instance, replicationMode);
                }
                catch (Exception ex)
                {
                    Logger.Error("Replicate Object Failed:", ex);
                    throw new DataException("Could not perform Replicate for " + typeof(T).Name, ex);
                }
            }
        }

        #endregion

        #region 查找所有的数据

        public List<T> FindAll()
        {
            return FindAll(int.MinValue, int.MinValue);
        }

        public List<T> FindAll(int firstRow, int maxRows)
        {
            int recordCount = 0;
            return FindAll(null, null, firstRow, maxRows, out recordCount);
        }

        #endregion

        #region 面向对象的查询方式

        public virtual List<T> FindAll(ICriterion[] criterias)
        {
            return FindAll(criterias, null);
        }

        public virtual List<T> FindAll(ICriterion[] criterias, Order[] sortItems)
        {
            int recordCount = 0;
            return FindAll(criterias, sortItems, int.MinValue, int.MinValue, out recordCount);
        }

        public virtual List<T> FindAll(ICriterion[] criterias, int firstRow, int maxRows, out int recordCount)
        {
            return FindAll(criterias, null, firstRow, maxRows, "", "", out recordCount);
        }

        public virtual List<T> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows, out int recordCount)
        {
            return FindAll(criterias, sortItems, firstRow, maxRows, "", "", out recordCount);
        }

        public virtual List<T> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows, string filterName, string cacheRegionName, out int recordCount)
        {
            //获取session
            using (ISession session = GetSession())
            {
                try
                {
                    //如果有filter打开
                    if (!string.IsNullOrEmpty(filterName))
                    {
                        session.EnableFilter(filterName);
                    }

                    //查询l当前页记录的ICriteria
                    ICriteria criteria = session.CreateCriteria(typeof(T));
                    //查询记录总数的ICriteria
                    ICriteria criteriaCount = session.CreateCriteria(typeof(T));


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
                    IList result = criteria.List();

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

                    //类型转换
                    return ConvertToTypedList(result);
                }
                catch (Exception ex)
                {
                    logger.Error(ex.Message);
                    throw new DataException("Could not perform FindAll for " + typeof(T).Name, ex);
                }
            }
        }

        #endregion

        #region HQL集合查询

        public virtual List<T> FindAllWithCustomQuery(string queryString)
        {
            return FindAllWithCustomQuery(queryString, null, int.MinValue, int.MinValue);
        }

        public virtual List<T> FindAllWithCustomQuery(string queryString, int firstRow, int maxRows)
        {
            return FindAllWithCustomQuery(queryString, null, firstRow, maxRows);
        }

        public virtual List<T> FindAllWithCustomQuery(string queryString, NhibernateParameterCollection nhibernateQueryParams)
        {
            return FindAllWithCustomQuery(queryString, nhibernateQueryParams, int.MinValue, int.MinValue);
        }

        public virtual List<T> FindAllWithCustomQuery(string queryString, NhibernateParameterCollection nhibernateQueryParams, int firstRow, int maxRows)
        {
            if (queryString == null || queryString.Length == 0) throw new ArgumentNullException("queryString");

            using (ISession session = GetSession())
            {
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

                    return ConvertToTypedList(query.List());
                }
                catch (Exception ex)
                {
                    throw new DataException("Could not perform Find for custom query : " + queryString, ex);
                }
            }
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
        public virtual object FindScalarWithCustomQuery(string queryString, NhibernateParameterCollection nhibernateQueryParams)
        {
            if (queryString == null || queryString.Length == 0) throw new ArgumentNullException("queryString");

            using (ISession session = GetSession())
            {
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
        }

        #endregion

        #region 命名集合查询

        public virtual List<T> FindListWithNamedQuery(string namedQuery)
        {
            return FindListWithNamedQuery(namedQuery, null, int.MinValue, int.MinValue);
        }

        public virtual List<T> FindListWithNamedQuery(string namedQuery, int firstRow, int maxRows)
        {
            return FindListWithNamedQuery(namedQuery, null, firstRow, maxRows);
        }

        public virtual List<T> FindListWithNamedQuery(string namedQuery, NhibernateParameterCollection nhibernateQueryParams)
        {
            return FindListWithNamedQuery(namedQuery, nhibernateQueryParams, int.MinValue, int.MinValue);
        }

        public virtual List<T> FindListWithNamedQuery(string namedQuery, NhibernateParameterCollection nhibernateQueryParams, int firstRow, int maxRows)
        {
            if (namedQuery == null || namedQuery.Length == 0) throw new ArgumentNullException("namedQuery");

            using (ISession session = GetSession())
            {
                try
                {
                    IQuery query = session.GetNamedQuery(namedQuery);
                    if (query == null) throw new ArgumentException("Cannot find named query", "namedQuery");

                    if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
                    {
                        foreach (NhibernateParameter param in nhibernateQueryParams)
                        {
                            query.SetParameter(param.ParameterName, param.Value, param.DbType);
                        }
                    }

                    if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
                    if (maxRows != int.MinValue) query.SetMaxResults(maxRows);

                    return ConvertToTypedList(query.List());
                }
                catch (Exception ex)
                {
                    throw new DataException("Could not perform Find List for named query : " + namedQuery, ex);
                }
            }
        }

        #endregion

        #region 命名标量查询

        public virtual object FindScalarWithNamedQuery(string namedQuery)
        {
            return FindScalarWithNamedQuery(namedQuery, null);
        }

        public virtual object FindScalarWithNamedQuery(string namedQuery, NhibernateParameterCollection nhibernateQueryParams)
        {
            if (namedQuery == null || namedQuery.Length == 0) throw new ArgumentNullException("namedQuery");

            using (ISession session = GetSession())
            {
                try
                {
                    IQuery query = session.GetNamedQuery(namedQuery);

                    if (query == null) throw new ArgumentException("Cannot find named query", "namedQuery");

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
                    throw new DataException("Could not perform Find Scalar for named query : " + namedQuery, ex);
                }
            }
        }

        #endregion

        #region 初始化实体

        public virtual void InitializeLazyProperties(T instance)
        {
            if (instance == null) throw new ArgumentNullException("instance");

            using (ISession session = GetSession())
            {
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
        }

        public virtual void InitializeLazyProperty(T instance, string propertyName)
        {
            if (instance == null) throw new ArgumentNullException("instance");
            if (propertyName == null || propertyName.Length == 0) throw new ArgumentNullException("collectionPropertyName");

            IDictionary properties = ReflectionUtil.GetPropertiesDictionary(instance);
            if (!properties.Contains(propertyName))
                throw new ArgumentOutOfRangeException("collectionPropertyName", "Property "
                                                                                + propertyName + " doest not exist for type "
                                                                                + instance.GetType().ToString() + ".");

            using (ISession session = GetSession())
            {
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
        }

        #endregion

        #region 游离条件查询

        public virtual List<T> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria)
        {
            if (detachedCriteria == null) throw new ArgumentNullException("detachedCriteria");

            using (ISession session = GetSession())
            {
                try
                {
                    IList result = detachedCriteria.GetExecutableCriteria(session).List();
                    return ConvertToTypedList(result);
                }
                catch (Exception ex)
                {
                    logger.Error("Could not perform Find List By DetachedCriteriaQuery : " + ex.Message);
                    throw new DataException("Could not perform Find List By DetachedCriteriaQuery : ", ex);
                }
            }
        }

        public virtual List<T> FindListByDetachedCriteriaQuery(DetachedCriteria detachedCriteria, DetachedCriteria detachedCriteriaCount, int firstRow, int maxRows, out int recordCount)
        {
            if (detachedCriteria == null) throw new ArgumentNullException("detachedCriteria");

            using (ISession session = GetSession())
            {
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
                    IList result = criteria.List();

                    if (result.Count > recordCount)
                    {
                        throw new Exception("Query Count Error!");
                    }
                    return ConvertToTypedList(result);
                }
                catch (Exception ex)
                {
                    logger.Error("Could not perform Find List By DetachedCriteriaQuery : " + ex.Message);
                    throw new DataException("Could not perform Find List By DetachedCriteriaQuery : ", ex);
                }
            }
        }

        #endregion

        #region 投影查询

        public virtual IList ProjectionQuery(IProjection[] projections, ICriterion[] criterias,Order[] orders)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    ICriteria criteria = session.CreateCriteria(typeof(T));

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
                    throw new DataException("Could not perform FindAll for " + typeof(T).Name, ex);
                }
            }
        }

        public virtual object ProjectionSingleLineQuery(IProjection[] projections, ICriterion[] criterias, Order[] orders)
        {
            using (ISession session = GetSession())
            {
                try
                {
                    ICriteria criteria = session.CreateCriteria(typeof(T));

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

                    if(result==null)
                        return null;
                    else
                        return result[0];
                }
                catch (Exception ex)
                {
                    throw new DataException("Could not perform ProjectionSingleLineQuery for " + typeof(T).Name, ex);
                }
            }
        }

        public virtual TypeScalar ProjectionScalarQuery<TypeScalar>(IProjection[] projections, ICriterion[] criterias, Order[] orders)
        {
            object result = ProjectionSingleLineQuery(projections, criterias, orders);

            if (result == null)
                return default(TypeScalar);
            else
                return (TypeScalar)result;
        }

        #endregion

        #region 获取实体类元数据

        public virtual IClassMetadata CurrentClassMetaData
        {
            get
            {
                if (currentClassMetaData == null)
                {
                    currentClassMetaData = GetSession().SessionFactory.GetClassMetadata(typeof(T));
                }
                return currentClassMetaData;
            }
        }

        #endregion

        //public virtual DataSet QueryDataSet(string sql)
        //{
        //    using (ISession session = GetSession())
        //    {

        //    }
        //}






























        //#region IGenericDAO Members

        //#region 数据查询方法

        //public virtual T[] FindAll()
        //{
        //    return FindAll(int.MinValue, int.MinValue);
        //}

        //public virtual T[] FindAll(int firstRow, int maxRows)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            ICriteria criteria = session.CreateCriteria(typeof(T));

        //            if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
        //            if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);

        //            return ConvertToArray(criteria.List());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindAll for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual T[] FindAll(int firstRow, int maxRows, out int recordCount)
        //{
        //    return FindAll(null, firstRow, maxRows, out recordCount);
        //}

        //public virtual T FindById(object id)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            return (T)session.Load(typeof(T), id);
        //        }
        //        catch (ObjectNotFoundException)
        //        {
        //            throw;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindByPrimaryKey for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //#endregion

        //#region 数据操作方法

        ///// <summary>
        ///// 新增数据
        ///// </summary>
        ///// <param name="instance"></param>
        ///// <returns></returns>
        //public virtual void Save(T instance)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            session.Save(instance);
        //            OnDataChanged(EventArgs.Empty);
        //            return instance;
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.Error("Create Object Failed:", ex);
        //            throw new DataException("Could not perform Create for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual void SaveOrUpdate(T instance)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            session.
        //            session.SaveOrUpdate(instance);
        //            OnDataChanged(EventArgs.Empty);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform Save for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual void Delete(T instance)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            session.Delete(instance);
        //            OnDataChanged(EventArgs.Empty);
        //        }
        //        catch (Exception ex)
        //        {
        //            Logger.Error("Delete Object Failed:", ex);
        //            throw new DataException("Could not perform Delete for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual void Refresh(T instance)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            session.Evict<T>(instance);
        //            session.Refresh(instance);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform Save for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public void DeleteByID(object id)
        //{
        //    Delete(this.FindById(id));
        //}

        //public virtual void Update(T instance)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            session.Update(instance);
        //            OnDataChanged(EventArgs.Empty);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform Update for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual void DeleteAll()
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            session.Delete(String.Format("from {0}", typeof(T).Name));
        //            OnDataChanged(EventArgs.Empty);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform DeleteAll for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual void DeleteByHQL(string hql)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            session.Delete(hql);
        //            OnDataChanged(EventArgs.Empty);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform DeleteAll for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual void DeleteByHQL(string hql, NhibernateParameterCollection nhibernateQueryParams)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
        //            {
        //                IType[] types = new IType[nhibernateQueryParams.Count];
        //                object[] values = new object[nhibernateQueryParams.Count];
        //                for (int i = 0; i < nhibernateQueryParams.Count; i++)
        //                {
        //                    types[i] = nhibernateQueryParams[i].DbType;
        //                    values[i] = nhibernateQueryParams[i].Value;
        //                }
        //                session.Delete(hql, values, types);
        //            }
        //            else
        //            {
        //                session.Delete(hql);
        //            }
        //            OnDataChanged(EventArgs.Empty);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform DeleteAll for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual void DeleteByHQL(string hql, object svalue, IType hbType)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            session.Delete(hql, svalue, hbType);
        //            OnDataChanged(EventArgs.Empty);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform DeleteAll for " + typeof(T).Name, ex);
        //        }
        //    }
        //}






        //#endregion

        //#endregion

        //#region INHibernateGenericDAO Members

        //#region 标准查询

        //public virtual T[] FindAll(ICriterion[] criterias)
        //{
        //    return FindAll(criterias, null);
        //}

        //public virtual T[] FindAll(ICriterion[] criterias, Order[] sortItems)
        //{
        //    int recordCount = 0;
        //    return FindAll(criterias, sortItems, int.MinValue, int.MinValue, out recordCount);
        //}

        //public virtual T[] FindAll(ICriterion[] criterias, int firstRow, int maxRows, out int recordCount)
        //{
        //    return FindAll(criterias, null, int.MinValue, int.MinValue, out recordCount);
        //}

        //public virtual T[] FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows, out int recordCount)
        //{
        //    return FindAll(criterias, sortItems, int.MinValue, int.MinValue, "", out recordCount);
        //}

        //public virtual T[] FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows, string filterName, out int recordCount)
        //{
        //    return FindAll(criterias, sortItems, int.MinValue, int.MinValue, "", "", out recordCount);
        //}

        //public virtual T[] FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows, string filterName, string cacheRegionName, out int recordCount)
        //{
        //    //获取session
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            //如果有filter打开
        //            if (!string.IsNullOrEmpty(filterName))
        //            {
        //                session.EnableFilter(filterName);
        //            }

        //            //查询l当前页记录的ICriteria
        //            ICriteria criteria = session.CreateCriteria(typeof(T));
        //            //查询记录总数的ICriteria
        //            ICriteria criteriaCount = session.CreateCriteria(typeof(T));


        //            //加载查询条件
        //            if (criterias != null)
        //            {
        //                foreach (ICriterion cond in criterias)
        //                {
        //                    criteria.Add(cond);
        //                    criteriaCount.Add(cond);
        //                }
        //            }

        //            //加载排序条件
        //            if (sortItems != null)
        //            {
        //                foreach (Order order in sortItems)
        //                {
        //                    //查询记录总数的ICriteria不需要加载排序条件
        //                    criteria.AddOrder(order);
        //                }
        //            }

        //            //打开缓存
        //            if (!string.IsNullOrEmpty(cacheRegionName))
        //            {
        //                criteria.SetCacheable(true);
        //                criteria.SetCacheRegion(cacheRegionName);
        //            }

        //            //投影查询获取记录总数
        //            criteriaCount.SetProjection(Projections.RowCount());
        //            recordCount = criteriaCount.SetMaxResults(1).UniqueResult<int>();


        //            //object count = criteriaCount.SetMaxResults(1).UniqueResult();

        //            //if (count == null)
        //            //{
        //            //    recordCount = 0;
        //            //}
        //            //else
        //            //{
        //            //    recordCount = (int)count;
        //            //}


        //            //设置分页查询
        //            if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
        //            if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);

        //            //获取当前页记录数
        //            IList result = criteria.List();

        //            if (result.Count > recordCount)
        //            {
        //                throw new Exception("Query count error!");
        //            }

        //            //关闭缓存
        //            if (!string.IsNullOrEmpty(cacheRegionName))
        //            {
        //                criteria.SetCacheable(false);
        //            }

        //            //如果有filter关闭
        //            if (!string.IsNullOrEmpty(filterName))
        //            {
        //                session.DisableFilter(filterName);
        //            }

        //            //类型转换
        //            return ConvertToArray(result);
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindAll for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual IList FindList(ICriterion[] criterias)
        //{
        //    return FindList(criterias, null);
        //}

        //public virtual IList FindList(ICriterion[] criterias, Order[] sortItems)
        //{
        //    int recordCount = 0;
        //    return FindList(criterias, sortItems, int.MinValue, int.MinValue, out recordCount);
        //}

        //public virtual IList FindList(ICriterion[] criterias, int firstRow, int maxRows, out int recordCount)
        //{
        //    return FindList(criterias, null, int.MinValue, int.MinValue, out recordCount);
        //}

        //public virtual IList FindList(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows, out int recordCount)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            ICriteria criteria = session.CreateCriteria(typeof(T));
        //            ICriteria criteriaCount = session.CreateCriteria(typeof(T));

        //            if (criterias != null)
        //            {
        //                foreach (ICriterion cond in criterias)
        //                {
        //                    criteria.Add(cond);
        //                    criteriaCount.Add(cond);
        //                }
        //            }

        //            if (sortItems != null)
        //            {
        //                foreach (Order order in sortItems)
        //                {
        //                    criteria.AddOrder(order);
        //                }
        //            }

        //            criteriaCount.SetProjection(Projections.RowCount());

        //            recordCount = (int)criteriaCount.SetMaxResults(1).UniqueResult();

        //            if (firstRow != int.MinValue) criteria.SetFirstResult(firstRow);
        //            if (maxRows != int.MinValue) criteria.SetMaxResults(maxRows);

        //            return criteria.List();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindAll for List", ex);
        //        }
        //    }
        //}

        //#endregion

        //#region HQL查询

        //public virtual T[] FindAllWithCustomQuery(string queryString)
        //{
        //    return FindAllWithCustomQuery(queryString, null, int.MinValue, int.MinValue);
        //}

        //public virtual T[] FindAllWithCustomQuery(string queryString, int firstRow, int maxRows)
        //{
        //    return FindAllWithCustomQuery(queryString, null, firstRow, maxRows);
        //}

        //public virtual T[] FindAllWithCustomQuery(string queryString, NhibernateParameterCollection nhibernateQueryParams)
        //{
        //    return FindAllWithCustomQuery(queryString, nhibernateQueryParams, int.MinValue, int.MinValue);
        //}

        //public virtual T[] FindAllWithCustomQuery(string queryString, NhibernateParameterCollection nhibernateQueryParams, int firstRow, int maxRows)
        //{
        //    if (queryString == null || queryString.Length == 0) throw new ArgumentNullException("queryString");

        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            IQuery query = session.CreateQuery(queryString);

        //            if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
        //            {
        //                foreach (NhibernateParameter param in nhibernateQueryParams)
        //                {
        //                    query.SetParameter(param.ParameterName, param.Value, param.DbType);
        //                }
        //            }

        //            if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
        //            if (maxRows != int.MinValue) query.SetMaxResults(maxRows);

        //            return ConvertToArray(query.List());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform Find for custom query : " + queryString, ex);
        //        }
        //    }
        //}

        //public virtual IList FindListWithCustomQuery(string queryString)
        //{
        //    return FindListWithCustomQuery(queryString, null, int.MinValue, int.MinValue);
        //}

        //public virtual IList FindListWithCustomQuery(string queryString, int firstRow, int maxRows)
        //{
        //    return FindAllWithCustomQuery(queryString, null, firstRow, maxRows);
        //}

        //public virtual IList FindListWithCustomQuery(string queryString, NhibernateParameterCollection nhibernateQueryParams)
        //{
        //    return FindListWithCustomQuery(queryString, nhibernateQueryParams, int.MinValue, int.MinValue);
        //}

        //public virtual IList FindListWithCustomQuery(string queryString, NhibernateParameterCollection nhibernateQueryParams, int firstRow, int maxRows)
        //{
        //    if (queryString == null || queryString.Length == 0) throw new ArgumentNullException("queryString");

        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            IQuery query = session.CreateQuery(queryString);

        //            if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
        //            {
        //                foreach (NhibernateParameter param in nhibernateQueryParams)
        //                {
        //                    query.SetParameter(param.ParameterName, param.Value, param.DbType);
        //                }
        //            }

        //            if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
        //            if (maxRows != int.MinValue) query.SetMaxResults(maxRows);

        //            return query.List();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform Find for custom query : " + queryString, ex);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 查找单个数值
        ///// </summary>
        ///// <param name="queryString"></param>
        ///// <returns></returns>
        //public virtual object FindScalarWithCustomQuery(string queryString)
        //{
        //    return FindScalarWithCustomQuery(queryString, null);
        //}

        ///// <summary>
        ///// 查找单个数值
        ///// </summary>
        ///// <param name="queryString"></param>
        ///// <param name="nhibernateQueryParams"></param>
        ///// <returns></returns>
        //public virtual object FindScalarWithCustomQuery(string queryString, NhibernateParameterCollection nhibernateQueryParams)
        //{
        //    if (queryString == null || queryString.Length == 0) throw new ArgumentNullException("queryString");

        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            IQuery query = session.CreateQuery(queryString);

        //            if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
        //            {
        //                foreach (NhibernateParameter param in nhibernateQueryParams)
        //                {
        //                    query.SetParameter(param.ParameterName, param.Value, param.DbType);
        //                }
        //            }

        //            return query.SetMaxResults(1).UniqueResult();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform Find for custom query : " + queryString, ex);
        //        }
        //    }
        //}

        //#endregion

        //#region NamedQuery

        //public virtual T[] FindAllWithNamedQuery(string namedQuery)
        //{
        //    return FindAllWithNamedQuery(namedQuery, null, int.MinValue, int.MinValue);
        //}

        //public virtual T[] FindAllWithNamedQuery(string namedQuery, int firstRow, int maxRows)
        //{
        //    return FindAllWithCustomQuery(namedQuery, null, firstRow, maxRows);
        //}

        //public virtual T[] FindAllWithNamedQuery(string namedQuery, NhibernateParameterCollection nhibernateQueryParams)
        //{
        //    return FindAllWithCustomQuery(namedQuery, nhibernateQueryParams, int.MinValue, int.MinValue);
        //}

        //public virtual T[] FindAllWithNamedQuery(string namedQuery, NhibernateParameterCollection nhibernateQueryParams, int firstRow, int maxRows)
        //{
        //    if (namedQuery == null || namedQuery.Length == 0) throw new ArgumentNullException("queryString");

        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            IQuery query = session.GetNamedQuery(namedQuery);
        //            if (query == null) throw new ArgumentException("Cannot find named query", "namedQuery");

        //            if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
        //            {
        //                foreach (NhibernateParameter param in nhibernateQueryParams)
        //                {
        //                    query.SetParameter(param.ParameterName, param.Value, param.DbType);
        //                }
        //            }

        //            if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
        //            if (maxRows != int.MinValue) query.SetMaxResults(maxRows);

        //            return ConvertToArray(query.List());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform Find for named query : " + namedQuery, ex);
        //        }
        //    }
        //}

        //public virtual IList FindListWithNamedQuery(string namedQuery)
        //{
        //    return FindListWithNamedQuery(namedQuery, null, int.MinValue, int.MinValue);
        //}

        //public virtual IList FindListWithNamedQuery(string namedQuery, int firstRow, int maxRows)
        //{
        //    return FindListWithNamedQuery(namedQuery, null, firstRow, maxRows);
        //}

        //public virtual IList FindListWithNamedQuery(string namedQuery, NhibernateParameterCollection nhibernateQueryParams)
        //{
        //    return FindListWithNamedQuery(namedQuery, nhibernateQueryParams, int.MinValue, int.MinValue);
        //}

        //public virtual IList FindListWithNamedQuery(string namedQuery, NhibernateParameterCollection nhibernateQueryParams, int firstRow, int maxRows)
        //{
        //    if (namedQuery == null || namedQuery.Length == 0) throw new ArgumentNullException("queryString");

        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            IQuery query = session.GetNamedQuery(namedQuery);
        //            if (query == null) throw new ArgumentException("Cannot find named query", "namedQuery");

        //            if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
        //            {
        //                foreach (NhibernateParameter param in nhibernateQueryParams)
        //                {
        //                    query.SetParameter(param.ParameterName, param.Value, param.DbType);
        //                }
        //            }

        //            if (firstRow != int.MinValue) query.SetFirstResult(firstRow);
        //            if (maxRows != int.MinValue) query.SetMaxResults(maxRows);

        //            return ConvertToArray(query.List());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform Find for named query : " + namedQuery, ex);
        //        }
        //    }
        //}

        //public virtual object FindScalarWithNamedQuery(string namedQuery)
        //{
        //    return FindScalarWithNamedQuery(namedQuery, null);
        //}

        //public virtual object FindScalarWithNamedQuery(string namedQuery, NhibernateParameterCollection nhibernateQueryParams)
        //{
        //    if (namedQuery == null || namedQuery.Length == 0) throw new ArgumentNullException("queryString");

        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            IQuery query = session.GetNamedQuery(namedQuery);

        //            if (query == null) throw new ArgumentException("Cannot find named query", "namedQuery");

        //            if (nhibernateQueryParams != null && nhibernateQueryParams.Count > 0)
        //            {
        //                foreach (NhibernateParameter param in nhibernateQueryParams)
        //                {
        //                    query.SetParameter(param.ParameterName, param.Value, param.DbType);
        //                }
        //            }

        //            return query.SetMaxResults(1).UniqueResult();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform Find for named query : " + namedQuery, ex);
        //        }
        //    }
        //}

        //#endregion

        //#region 初始化属性

        ///// <summary>
        ///// 读取所有属性，组织lazyLoad
        ///// </summary>
        ///// <param name="instance"></param>
        //public virtual void InitializeLazyProperties(T instance)
        //{
        //    if (instance == null) throw new ArgumentNullException("instance");

        //    using (ISession session = GetSession())
        //    {
        //        foreach (object val in ReflectionUtil.GetPropertiesDictionary(instance).Values)
        //        {
        //            if (val is INHibernateProxy || val is IPersistentCollection)
        //            {
        //                if (!NHibernateUtil.IsInitialized(val))
        //                {
        //                    session.Lock(instance, LockMode.None);
        //                    NHibernateUtil.Initialize(val);
        //                }
        //            }
        //        }
        //    }
        //}

        ///// <summary>
        ///// 读取指定属性
        ///// </summary>
        ///// <param name="instance"></param>
        ///// <param name="propertyName"></param>
        //public virtual void InitializeLazyProperty(T instance, string propertyName)
        //{
        //    if (instance == null) throw new ArgumentNullException("instance");
        //    if (propertyName == null || propertyName.Length == 0)
        //        throw new ArgumentNullException("collectionPropertyName");

        //    IDictionary properties = ReflectionUtil.GetPropertiesDictionary(instance);
        //    if (!properties.Contains(propertyName))
        //        throw new ArgumentOutOfRangeException("collectionPropertyName", "Property "
        //                                                                        + propertyName +
        //                                                                        " doest not exist for type "
        //                                                                        + instance.GetType().ToString() + ".");

        //    using (ISession session = GetSession())
        //    {
        //        object val = properties[propertyName];

        //        if (val is INHibernateProxy || val is IPersistentCollection)
        //        {
        //            if (!NHibernateUtil.IsInitialized(val))
        //            {
        //                session.Lock(instance, LockMode.None);
        //                NHibernateUtil.Initialize(val);
        //            }
        //        }
        //    }
        //}

        //public virtual IClassMetadata CurrentClassMetaData
        //{
        //    get
        //    {
        //        if (currentClassMetaData == null)
        //        {
        //            currentClassMetaData = GetSession().SessionFactory.GetClassMetadata(typeof(T));
        //        }
        //        return currentClassMetaData;
        //    }
        //}

        //#endregion

        //#endregion

        //#region Custom Query Method

        ///// <summary>
        ///// 利用属性值查找
        ///// </summary>
        ///// <param name="propertyName"></param>
        ///// <param name="propertyValue"></param>
        ///// <returns></returns>
        //public virtual T[] FindByProperty(string propertyName, object propertyValue)
        //{
        //    return FindByProperty(new string[] { propertyName }, new object[] { propertyValue });
        //}


        ///// <summary>
        ///// 利用属性值查找
        ///// </summary>
        ///// <param name="propertyNames"></param>
        ///// <param name="propertyValues"></param>
        ///// <returns></returns>
        //public virtual T[] FindByProperty(string[] propertyNames, object[] propertyValues)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            ICriteria criteria = session.CreateCriteria(typeof(T));

        //            if (propertyNames == null || propertyNames.Length == 0)
        //                throw new ArgumentNullException("propertyNames");

        //            if (propertyValues == null || propertyValues.Length == 0)
        //                throw new ArgumentNullException("propertyValues");

        //            if (propertyNames.Length != propertyValues.Length)
        //                throw new ArgumentException("propertyNames length not eq propertyValues length.");

        //            for (int i = 0; i < propertyNames.Length; i++)
        //            {
        //                ICriterion queryCondition = NHibernate.Expression.Expression.Eq(propertyNames[i], propertyValues[i]);

        //                criteria.Add(queryCondition);
        //            }

        //            return ConvertToArray(criteria.List());
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindByProperty for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="propertyName"></param>
        ///// <param name="propertyValue"></param>
        ///// <returns></returns>
        //public virtual int FindCountByProperty(string propertyName, object propertyValue)
        //{
        //    return FindCountByProperty(new string[] { propertyName }, new object[] { propertyValue });
        //}

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="propertyNames"></param>
        ///// <param name="propertyValues"></param>
        ///// <returns></returns>
        //public virtual int FindCountByProperty(string[] propertyNames, object[] propertyValues)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            ICriteria criteria = session.CreateCriteria(typeof(T));

        //            if (propertyNames == null || propertyNames.Length == 0)
        //                throw new ArgumentNullException("propertyNames");

        //            if (propertyValues == null || propertyValues.Length == 0)
        //                throw new ArgumentNullException("propertyValues");

        //            if (propertyNames.Length != propertyValues.Length)
        //                throw new ArgumentException("propertyNames length not eq propertyValues length.");

        //            for (int i = 0; i < propertyNames.Length; i++)
        //            {
        //                ICriterion queryCondition = NHibernate.Expression.Expression.Eq(propertyNames[i], propertyValues[i]);

        //                criteria.Add(queryCondition);
        //            }

        //            criteria.SetProjection(Projections.RowCount());

        //            return (int)criteria.SetMaxResults(1).UniqueResult();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindCountByProperty for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual int CalculateByProperty(CalculateType calculateType, string calculatePropertyName)
        //{
        //    return
        //        CalculateByProperty(calculateType, calculatePropertyName, new string[] { },
        //                            new object[] { });
        //}

        //public virtual int CalculateByProperty(CalculateType calculateType, string calculatePropertyName, string propertyName, object propertyValue)
        //{
        //    return
        //        CalculateByProperty(calculateType, calculatePropertyName, new string[] { propertyName },
        //                            new object[] { propertyValue });
        //}

        ///// <summary>
        ///// 统计查询
        ///// </summary>
        ///// <param name="calculateType">统计类型</param>
        ///// <param name="calculatePropertyName">统计字段</param>
        ///// <param name="propertyNames">条件属性名</param>
        ///// <param name="propertyValues">条件属性值</param>
        ///// <returns></returns>
        //public virtual int CalculateByProperty(CalculateType calculateType, string calculatePropertyName, string[] propertyNames, object[] propertyValues)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            ICriteria criteria = session.CreateCriteria(typeof(T));

        //            if (propertyNames == null)
        //                throw new ArgumentNullException("propertyNames");

        //            if (propertyValues == null)
        //                throw new ArgumentNullException("propertyValues");

        //            if (propertyNames.Length != propertyValues.Length)
        //                throw new ArgumentException("propertyNames length not eq propertyValues length.");

        //            for (int i = 0; i < propertyNames.Length; i++)
        //            {
        //                ICriterion queryCondition = NHibernate.Expression.Expression.Eq(propertyNames[i], propertyValues[i]);

        //                criteria.Add(queryCondition);
        //            }

        //            switch (calculateType)
        //            {
        //                case CalculateType.Avg:
        //                    criteria.SetProjection(Projections.Avg(calculatePropertyName));
        //                    break;
        //                case CalculateType.Sum:
        //                    criteria.SetProjection(Projections.Sum(calculatePropertyName));
        //                    break;
        //                case CalculateType.Min:
        //                    criteria.SetProjection(Projections.Min(calculatePropertyName));
        //                    break;
        //                case CalculateType.Max:
        //                    criteria.SetProjection(Projections.Max(calculatePropertyName));
        //                    break;
        //                case CalculateType.CountDistinct:
        //                    criteria.SetProjection(Projections.CountDistinct(calculatePropertyName));

        //                    break;
        //                default:
        //                    break;
        //            }

        //            Object result = criteria.SetMaxResults(1).UniqueResult();

        //            if (result == null)
        //                return int.MinValue;
        //            else
        //                return (int)result;
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindCountByProperty for " + typeof(T).Name, ex);
        //        }
        //    }
        //}


        //public virtual IList GetDistinctProperty(Property property)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            ICriteria criteria = session.CreateCriteria(typeof(T));

        //            criteria.SetProjection(Projections.Distinct(property));

        //            return criteria.List();

        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindCountByProperty for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual IList GetDistinctProperty(Property property, ICriterion[] criterias)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            ICriteria criteria = session.CreateCriteria(typeof(T));

        //            if (criterias != null)
        //            {
        //                foreach (ICriterion cond in criterias)
        //                {
        //                    criteria.Add(cond);
        //                }
        //            }

        //            criteria.SetProjection(Projections.Distinct(property));

        //            return criteria.List();

        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindCountByProperty for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual IList GetDistinctProperty(Property property, ICriterion[] criterias, Order[] orders)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            ICriteria criteria = session.CreateCriteria(typeof(T));

        //            if (criterias != null)
        //            {
        //                foreach (ICriterion cond in criterias)
        //                {
        //                    criteria.Add(cond);
        //                }
        //            }

        //            if (orders != null)
        //            {
        //                foreach (Order order in orders)
        //                {
        //                    criteria.AddOrder(order);
        //                }
        //            }

        //            criteria.SetProjection(Projections.Distinct(property));

        //            return criteria.List();

        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindCountByProperty for " + typeof(T).Name, ex);
        //        }
        //    }
        //}


        ///// <summary>
        ///// 投影查询
        ///// </summary>
        ///// <param name="projections">投影</param>
        ///// <param name="criterias">过滤条件</param>
        ///// <returns></returns>
        //public virtual IList ProjectionQuery(IProjection[] projections, ICriterion[] criterias)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        try
        //        {
        //            ICriteria criteria = session.CreateCriteria(typeof(T));
        //            ICriteria criteriaCount = session.CreateCriteria(typeof(T));

        //            if (criterias != null)
        //            {
        //                foreach (ICriterion cond in criterias)
        //                {
        //                    criteria.Add(cond);
        //                    criteriaCount.Add(cond);
        //                }
        //            }

        //            if (projections != null)
        //            {
        //                foreach (IProjection projection in projections)
        //                {
        //                    criteria.SetProjection(projection);
        //                    criteriaCount.SetProjection(projection);
        //                }
        //            }

        //            criteriaCount.SetProjection(Projections.RowCount());

        //            return criteria.List();
        //        }
        //        catch (Exception ex)
        //        {
        //            throw new DataException("Could not perform FindAll for " + typeof(T).Name, ex);
        //        }
        //    }
        //}

        //public virtual IList ProjectionQuery(IProjection projection, ICriterion[] criterias)
        //{
        //    return ProjectionQuery(new IProjection[] { projection }, criterias);
        //}

        //public virtual IDbDataAdapter GetIDbDataAdapter()
        //{
        //    using (ISession session = GetSession())
        //    {
        //        if (session.SessionFactory.Dialect is NHibernate.Dialect.MsSql2000Dialect)
        //        {
        //            return new SqlDataAdapter();
        //        }
        //        else if (session.SessionFactory.Dialect is NHibernate.Dialect.MsSql2005Dialect)
        //        {
        //            return new SqlDataAdapter();
        //        }
        //        else if (session.SessionFactory.Dialect is NHibernate.JetDriver.JetDialect)
        //        {
        //            return new OleDbDataAdapter();
        //        }
        //        throw new System.Data.DataException("this database is not supported.");
        //    }
        //}

        //public void DeleteByIntIDs(int[] ids, string className, string idField)
        //{
        //    if (ids.Length > 0)
        //    {
        //        string[] strArray = new string[ids.Length];
        //        for (int i = 0; i < ids.Length; i++)
        //        {
        //            strArray[i] = ids[i].ToString();
        //        }
        //        string str = string.Join(" ,", strArray);
        //        string hql = string.Format(" from {2} as t wheret.{0} in ({1}) ", idField, str, className);
        //        this.DeleteByHQL(hql);
        //    }
        //}

        //public virtual IList GetDistinctPropertys(Property[] propertys, ICriterion[] criterias, Order[] sortItems)
        //{
        //    IList list2;
        //    ISession session = this.GetSession();
        //    try
        //    {
        //        ICriteria criteria = session.CreateCriteria(typeof(T));
        //        if (criterias != null)
        //        {
        //            foreach (ICriterion criterion in criterias)
        //            {
        //                criteria.Add(criterion);
        //            }
        //        }
        //        ProjectionList list = Projections.ProjectionList();
        //        foreach (Property property in propertys)
        //        {
        //            list.Add(property);
        //        }
        //        criteria.SetProjection(Projections.Distinct(list));
        //        if (sortItems != null)
        //        {
        //            foreach (Order order in sortItems)
        //            {
        //                criteria.AddOrder(order);
        //            }
        //        }
        //        list2 = criteria.List();
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new DataException("Could not perform FindCountByProperty for " + typeof(T).Name, exception);
        //    }
        //    finally
        //    {
        //        if (session != null)
        //        {
        //            session.Dispose();
        //        }
        //    }
        //    return list2;
        //}

        //public virtual DataSet QueryDataSet(string sql)
        //{
        //    using (ISession session = GetSession())
        //    {
        //        IDbCommand cmd = session.Connection.CreateCommand();
        //        cmd.CommandText = sql;
        //        cmd.CommandType = CommandType.Text;
        //        IDbDataAdapter adapter = GetIDbDataAdapter();
        //        adapter.SelectCommand = cmd;
        //        DataSet ds = new DataSet();
        //        adapter.Fill(ds);
        //        return ds;
        //    }
        //}

        //#endregion

        //#region Protected methods

        //protected ISession GetSession()
        //{

        //    if (sessionFactoryAlias == null || sessionFactoryAlias.Length == 0)
        //    {
        //        return sessionManager.OpenSession();
        //    }
        //    else
        //    {
        //        return sessionManager.OpenSession(sessionFactoryAlias);
        //    }
        //}

        //protected virtual T[] ConvertToArray(IList list)
        //{
        //    return ConvertToArray<T>(list);
        //}

        //protected virtual EntityType[] ConvertToArray<EntityType>(IList list)
        //{
        //    if (list == null) return null;

        //    EntityType[] array = new EntityType[list.Count];

        //    list.CopyTo(array, 0);

        //    return array;
        //}



        //#endregion



    }
}
