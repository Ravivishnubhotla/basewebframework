using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Data.NHibernate.Extend;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.SqlCommand;
using NHibernate.Transform;
using NHibernate.Type;
using NHibernate.Util;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery
{
    /// <summary>
    /// Nhibernate 动态查询构建器
    /// </summary>
    /// <typeparam name="EntityType">查询实体类型</typeparam>
    public class NHibernateDynamicQueryGenerator<EntityType>
    {
        /// <summary>
        /// 离线查询条件（查数据）
        /// </summary>
        private DetachedCriteria query = null;
        /// <summary>
        /// 离线查询条件（查记录数）
        /// </summary>
        private DetachedCriteria queryCount = null;
        /// <summary>
        /// 别名组
        /// </summary>
        private List<string> allAlias = new List<string>();

     
        /// <summary>
        /// 默认构造器，初始化查询条件
        /// </summary>
        public NHibernateDynamicQueryGenerator()
        {
            query = DetachedCriteria.For(typeof(EntityType));
            queryCount = DetachedCriteria.For(typeof(EntityType));
        }

        public NHibernateDynamicQueryGenerator(string alias)
        {
            query = DetachedCriteria.For(typeof(EntityType),alias);
            queryCount = DetachedCriteria.For(typeof(EntityType), alias);
        }

        public NHibernateDynamicQueryGenerator<EntityType> ToAlians(string alias)
        {
            query = query.GetCriteriaByAlias(alias);
            queryCount = queryCount.GetCriteriaByAlias(alias);
            return this;
        }

        /// <summary>
        /// 添加动态Where条件
        /// </summary>
        /// <param name="criterion">Where条件</param>
        /// <returns></returns>
        public NHibernateDynamicQueryGenerator<EntityType> AddWhereClause(ICriterion criterion)
        {
            query.Add(criterion);
            queryCount.Add(criterion);
            return this;
        }
        /// <summary>
        /// 添加SQL Where 条件支持Sql语句条件
        /// </summary>
        /// <param name="sqlwhere">Sql语句</param>
        /// <returns></returns>
        public NHibernateDynamicQueryGenerator<EntityType> AddSQLWhereClause(string sqlwhere)
        {
            AddSQLWhereClause(sqlwhere, new NhibernateParameterCollection());
            return this;
        }
        /// <summary>
        /// 添加SQL Where 条件支持Sql语句条件(支持参数)
        /// </summary>
        /// <param name="sqlwhere">Sql语句</param>
        /// <param name="parameterCollection">Sql参数</param>
        /// <returns></returns>
        public NHibernateDynamicQueryGenerator<EntityType> AddSQLWhereClause(string sqlwhere,NhibernateParameterCollection parameterCollection)
        {
            query.Add(new SQLCriterion(new SqlString(sqlwhere), parameterCollection.GetAllValues(), parameterCollection.GetAllTypes()));
            queryCount.Add(new SQLCriterion(new SqlString(sqlwhere), parameterCollection.GetAllValues(), parameterCollection.GetAllTypes()));
            return this;
        }
        /// <summary>
        /// 添加排序条件
        /// </summary>
        /// <param name="order">排序字段</param>
        /// <returns></returns>
        public NHibernateDynamicQueryGenerator<EntityType> AddOrderBy(Order order)
        {
            query.AddOrder(order);
            return this;
        }

        public NHibernateDynamicQueryGenerator<EntityType> AddAlians(string propertyName, string alias)
        {
            query.CreateAlias(propertyName, alias);
            queryCount.CreateAlias(propertyName, alias);
            allAlias.Add(alias);
            return this;
        }



        internal List<EntityType> FindList(ISession session,bool isDistinctResult)
        {
            IList<EntityType> results;

            if (isDistinctResult)
                results = query.SetResultTransformer(new DistinctRootEntityResultTransformer()).GetExecutableCriteria(session).List<EntityType>();
            else
                results = query.GetExecutableCriteria(session).List<EntityType>();

            if (results == null)
                return null;

            return new List<EntityType>(results);
        }

        /// <summary>
        /// 查找集合数据
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        internal List<EntityType> FindList(ISession session)
        {
            return FindList(session, false);
        }
        /// <summary>
        /// 查找单个数据
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        internal EntityType FindSingleEntity(ISession session)
        {
            object results = query.GetExecutableCriteria(session).SetMaxResults(1).UniqueResult();

            if (results == null)
                return default(EntityType);

            return (EntityType)results;
        }
        /// <summary>
        /// 查总数
        /// </summary>
        /// <param name="session"></param>
        /// <param name="isDistinctResult"></param>
        /// <returns></returns>
        internal int GetCount(ISession session, bool isDistinctResult)
        {
            if (isDistinctResult)
            {
                return queryCount.SetResultTransformer(new DistinctRootEntityResultTransformer()).GetExecutableCriteria(session).SetProjection(Projections.RowCount()).SetMaxResults(1).UniqueResult<int>();
            }
            else
            {
                return queryCount.GetExecutableCriteria(session).SetProjection(Projections.RowCount()).SetMaxResults(1).UniqueResult<int>();              
            }

        }

        /// <summary>
        /// 查总数
        /// </summary>
        /// <param name="session"></param>
        /// <returns></returns>
        internal int GetCount(ISession session)
        {
            return GetCount(session, false);
        }
        /// <summary>
        /// 查找分页数据
        /// </summary>
        /// <param name="session"></param>
        /// <param name="pageQueryParams"></param>
        /// <returns></returns>
        internal List<EntityType> FindListByPage(ISession session, PageQueryParams pageQueryParams)
        {

            this.query.SetFirstResult(pageQueryParams.FristRecord);

            this.query.SetMaxResults(pageQueryParams.MaxRecord);

            pageQueryParams.RecordCount = GetCount(session);

            return FindList(session);
        }


        internal List<EntityType> FindDistinctListByPage(ISession session, PageQueryParams pageQueryParams)
        {
            this.query.SetFirstResult(pageQueryParams.FristRecord);

            this.query.SetMaxResults(pageQueryParams.MaxRecord);

            pageQueryParams.RecordCount = GetCount(session, true);

            return FindList(session, true);
        }

 
        internal IList FindSingleEntity<T>(ISession session, List<PropertyProjection> propertyProjection)
        {
            ICriteria criteria = query.GetExecutableCriteria(session);

            foreach (PropertyProjection projection in propertyProjection)
            {
                criteria.SetProjection(projection);
            }

            return criteria.List();
        }

        internal List<T> FindListByProjection<T>(ISession session, IProjection propertyProjection)
        {
            IList list = query.GetExecutableCriteria(session).SetProjection(propertyProjection).List();

            List<T> result = new List<T>();

            foreach (var item in list)
            {
                result.Add((T)item);
            }

            return result;
        }

        internal T FindSingleByProjection<T>(ISession session, IProjection propertyProjection)
        {
            return query.GetExecutableCriteria(session).SetProjection(propertyProjection).UniqueResult<T>();
        }


        public bool HasIncludeTable(string tableAliasName)
        {
            return allAlias.Contains(tableAliasName);
        }
    }
}