using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;
using NHibernate.Util;

namespace Legendigital.Framework.Common.Data.NHibernate.DynamicQuery
{
    public class NHibernateDynamicQueryGenerator<EntityType>
    {
        private DetachedCriteria query = null;
        private DetachedCriteria queryCount = null;
        //private List<ICriterion> whereClauses = new List<ICriterion>();
        //private SortedList<string, string> aliasList = new SortedList<string, string>();

        

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



        public NHibernateDynamicQueryGenerator<EntityType> AddWhereClause(ICriterion criterion)
        {
            query.Add(criterion);
            queryCount.Add(criterion);
            return this;
        }

        public NHibernateDynamicQueryGenerator<EntityType> AddAlians(string propertyName, string alias)
        {
            query.CreateAlias(propertyName, alias);
            queryCount.CreateAlias(propertyName, alias);
            return this;
        }

        public NHibernateDynamicQueryGenerator<EntityType> AddOrderBy(Order order)
        {
            query.AddOrder(order);
            return this;
        }

        public NHibernateDynamicQueryGenerator<EntityType> SetFirstResult(int firstResult)
        {
            query.SetFirstResult(firstResult);
            return this;
        }

        public NHibernateDynamicQueryGenerator<EntityType> SetMaxResults(int maxResults)
        {
            query.SetMaxResults(maxResults);
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


        internal List<EntityType> FindList(ISession session)
        {
            return FindList(session,false);
        }

        internal List<EntityType> FindDistinctListByPage(ISession session, out int recordCount)
        {
            recordCount = GetCount(session, true);

            return FindList(session, true);
        }

        internal int GetCount(ISession session)
        {
            return GetCount(session, false);
        }

        internal List<EntityType> FindListByPage(ISession session,out int recordCount)
        {
            recordCount = GetCount(session);

            return FindList(session);
        }

        internal EntityType FindSingleEntity(ISession session)
        {
            object results = query.GetExecutableCriteria(session).SetMaxResults(1).UniqueResult();

            if (results == null)
                return default(EntityType);

            return (EntityType)results;
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


    }
}