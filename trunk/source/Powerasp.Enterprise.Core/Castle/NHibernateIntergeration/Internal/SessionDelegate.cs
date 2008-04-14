// Copyright 2004-2006 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.Collections;
using System.Data;
using NHibernate;
using NHibernate.Engine;
using NHibernate.Type;

namespace Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal
{
    /// <summary>
    /// Proxies an ISession so the user cannot close a session which
    /// is controlled by a transaction, or, when this is not the case, 
    /// make sure to remove the session from the storage.
    /// <seealso cref="ISessionStore"/>
    /// <seealso cref="ISessionManager"/>
    /// </summary>
    [Serializable]
    public class SessionDelegate : MarshalByRefObject, ISession
    {
        private readonly ISession inner;
        private readonly ISessionStore sessionStore;
        private readonly bool canClose;
        private bool disposed;
        private object cookie;

        public SessionDelegate(bool canClose, ISession inner, ISessionStore sessionStore)
        {
            this.inner = inner;
            this.sessionStore = sessionStore;
            this.canClose = canClose;
        }

        public ISession InnerSession
        {
            get { return inner; }
        }

        public object SessionStoreCookie
        {
            get { return cookie; }
            set { cookie = value; }
        }

        #region ISession delegation

        public FlushMode FlushMode
        {
            get { return inner.FlushMode; }
            set { inner.FlushMode = value; }
        }
		
        public ISessionFactory SessionFactory
        {
            get { return inner.SessionFactory; }
        }

        public IDbConnection Connection
        {
            get { return inner.Connection; }
        }

        public bool IsOpen
        {
            get { return inner.IsOpen; }
        }

        public bool IsConnected
        {
            get { return inner.IsConnected; }
        }

        public ITransaction Transaction
        {
            get { return inner.Transaction; }
        }
		
        public void CancelQuery()
        {
            inner.CancelQuery();
        }
		
        public bool IsDirty()
        {
            return inner.IsDirty();
        }
		

        public void Flush()
        {
            inner.Flush();
        }

        public IDbConnection Disconnect()
        {
            return inner.Disconnect();
        }

        public void Reconnect()
        {
            inner.Reconnect();
        }

        public void Reconnect(IDbConnection connection)
        {
            inner.Reconnect(connection);
        }

        public object GetIdentifier(object obj)
        {
            return inner.GetIdentifier(obj);
        }

        public bool Contains(object obj)
        {
            return inner.Contains(obj);
        }

        public void Evict(object obj)
        {
            inner.Evict(obj);
        }

        public object Load(Type theType, object id, LockMode lockMode)
        {
            return inner.Load(theType, id, lockMode);
        }

        public object Load(Type theType, object id)
        {
            return inner.Load(theType, id);
        }

        ///<summary>
        ///
        ///            Return the persistent instance of the given entity class with the given identifier,
        ///            obtaining the specified lock mode.
        ///            
        ///</summary>
        ///<typeparam name="T">A persistent class</typeparam>
        ///<param name="id">A valid identifier of an existing persistent instance of the class</param>
        ///<param name="lockMode">The lock level</param>
        ///<returns>
        ///the persistent instance
        ///</returns>
        ///
        public T Load<T>(object id, LockMode lockMode)
        {
            return (T)Load(typeof(T), id, lockMode);
        }

        ///<summary>
        ///
        ///            Return the persistent instance of the given entity class with the given identifier,
        ///            assuming that the instance exists.
        ///            
        ///</summary>
        ///
        ///<remarks>
        ///
        ///            You should not use this method to determine if an instance exists (use a query or
        ///            <see cref="M:NHibernate.ISession.Get``1(System.Object)" /> instead). Use this only to retrieve an instance that you
        ///            assume exists, where non-existence would be an actual error.
        ///            
        ///</remarks>
        ///<typeparam name="T">A persistent class</typeparam>
        ///<param name="id">A valid identifier of an existing persistent instance of the class</param>
        ///<returns>
        ///The persistent instance or proxy
        ///</returns>
        ///
        public T Load<T>(object id)
        {
            return (T)Load(typeof(T), id);
        }

        public void Load(object obj, object id)
        {
            inner.Load(obj, id);
        }

        public object Get(Type clazz, object id)
        {
            return inner.Get(clazz, id);
        }

        public object Get(Type clazz, object id, LockMode lockMode)
        {
            return inner.Get(clazz, id, lockMode);
        }

        ///<summary>
        ///
        ///            Strongly-typed version of <see cref="M:NHibernate.ISession.Get(System.Type,System.Object)" />
        ///</summary>
        ///
        public T Get<T>(object id)
        {
            return (T)Get(typeof(T), id);
        }

        ///<summary>
        ///
        ///            Strongly-typed version of <see cref="M:NHibernate.ISession.Get(System.Type,System.Object,NHibernate.LockMode)" />
        ///</summary>
        ///
        public T Get<T>(object id, LockMode lockMode)
        {
            return (T)Get(typeof(T), id, lockMode);
        }

        ///<summary>
        ///
        ///            Enable the named filter for this current session.
        ///            
        ///</summary>
        ///
        ///<param name="filterName">The name of the filter to be enabled.</param>
        ///<returns>
        ///The Filter instance representing the enabled fiter.
        ///</returns>
        ///
        public IFilter EnableFilter(string filterName)
        {
            return inner.EnableFilter(filterName);
        }

        ///<summary>
        ///
        ///            Retrieve a currently enabled filter by name.
        ///            
        ///</summary>
        ///
        ///<param name="filterName">The name of the filter to be retrieved.</param>
        ///<returns>
        ///The Filter instance representing the enabled fiter.
        ///</returns>
        ///
        public IFilter GetEnabledFilter(string filterName)
        {
            return inner.GetEnabledFilter(filterName);
        }

        ///<summary>
        ///
        ///            Disable the named filter for the current session.
        ///            
        ///</summary>
        ///
        ///<param name="filterName">The name of the filter to be disabled.</param>
        public void DisableFilter(string filterName)
        {
            inner.DisableFilter(filterName);
        }

        public IMultiQuery CreateMultiQuery()
        {
            return inner.CreateMultiQuery();
        }

        public ISessionImplementor GetSessionImplementation()
        {
            return inner.GetSessionImplementation();
        }

        public void Replicate(object obj, ReplicationMode replicationMode)
        {
            inner.Replicate(obj, replicationMode);
        }

        public object Save(object obj)
        {
            return inner.Save(obj);
        }

        public void Save(object obj, object id)
        {
            inner.Save(obj, id);
        }

        public void SaveOrUpdate(object obj)
        {
            inner.SaveOrUpdate(obj);
        }

        public void Update(object obj)
        {
            inner.Update(obj);
        }

        public void Update(object obj, object id)
        {
            inner.Update(obj, id);
        }

        public object SaveOrUpdateCopy(object obj)
        {
            return inner.SaveOrUpdateCopy(obj);
        }

        public object SaveOrUpdateCopy(object obj, object id)
        {
            return inner.SaveOrUpdateCopy(obj, id);
        }

        public void Delete(object obj)
        {
            inner.Delete(obj);
        }

        public IList Find(string query)
        {
            return inner.CreateQuery(query).List();
        }

        public IList Find(string query, object value, IType type)
        {
            return inner.CreateQuery(query).SetParameter(0, value, type).List();
        }

        public IList Find(string query, object[] values, IType[] types)
        {
            IQuery iquery = inner.CreateQuery(query);
            for (int i = 0; i < values.Length; i++)
            {
                iquery.SetParameter(i, values[i], types[i]);
            }
            return iquery.List();
        }

        public IEnumerable Enumerable(string query)
        {
            return inner.CreateQuery(query).Enumerable();
        }

        public IEnumerable Enumerable(string query, object value, IType type)
        {
            return inner.CreateQuery(query).SetParameter(0, value, type).Enumerable();
        }

        public IEnumerable Enumerable(string query, object[] values, IType[] types)
        {
            IQuery iquery = inner.CreateQuery(query);
            for (int i = 0; i < values.Length; i++)
            {
                iquery.SetParameter(i, values[i], types[i]);
            }
            return iquery.Enumerable();
        }

        public ICollection Filter(object collection, string filter)
        {
            return inner.CreateFilter(collection, filter).List();
        }

        public ICollection Filter(object collection, string filter, object value, IType type)
        {
            return inner.CreateFilter(collection, filter).SetParameter(0, value, type).List();
        }

        public ICollection Filter(object collection, string filter, object[] values, IType[] types)
        {
            IQuery iquery = inner.CreateFilter(collection, filter);
            for (int i = 0; i < values.Length; i++)
            {
                iquery.SetParameter(i, values[i], types[i]);
            }
            return iquery.List();
        }

        public int Delete(string query)
        {
            return inner.Delete(query);
        }

        public int Delete(string query, object value, IType type)
        {
            return inner.Delete(query, value, type);
        }

        public int Delete(string query, object[] values, IType[] types)
        {
            return inner.Delete(query, values, types);
        }

        public void Lock(object obj, LockMode lockMode)
        {
            inner.Lock(obj, lockMode);
        }

        public void Refresh(object obj)
        {
            inner.Refresh(obj);
        }
		
        public void Refresh(object obj, LockMode lockMode)
        {
            inner.Refresh(obj, lockMode);
        }

        public LockMode GetCurrentLockMode(object obj)
        {
            return inner.GetCurrentLockMode(obj);
        }

        public ITransaction BeginTransaction()
        {
            return inner.BeginTransaction();
        }

        public ITransaction BeginTransaction(IsolationLevel isolationLevel)
        {
            return inner.BeginTransaction(isolationLevel);
        }

        public ICriteria CreateCriteria(Type persistentClass)
        {
            return inner.CreateCriteria(persistentClass);
        }

        ///<summary>
        ///
        ///            Creates a new 
        ///<c>Criteria</c> for the entity class with a specific alias
        ///            
        ///</summary>
        ///
        ///<param name="persistentClass">The class to Query</param>
        ///<param name="alias">The alias of the entity</param>
        ///<returns>
        ///An ICriteria object
        ///</returns>
        ///
        public ICriteria CreateCriteria(Type persistentClass, string alias)
        {
            return inner.CreateCriteria(persistentClass, alias);
        }

        public IQuery CreateQuery(string queryString)
        {
            return inner.CreateQuery(queryString);
        }

        public IQuery CreateFilter(object collection, string queryString)
        {
            return inner.CreateFilter(collection, queryString);
        }

        public IQuery GetNamedQuery(string queryName)
        {
            return inner.GetNamedQuery(queryName);
        }

        public IQuery CreateSQLQuery(string sql, string returnAlias, Type returnClass)
        {
            return inner.CreateSQLQuery(sql).AddEntity(returnAlias, returnClass);
        }


        ///<summary>
        ///
        ///            Create a new instance of <see cref="T:NHibernate.ISQLQuery" /> for the given SQL query string.
        ///            
        ///</summary>
        ///
        ///<param name="queryString"></param>
        ///<returns>
        ///
        ///</returns>
        ///
        public ISQLQuery CreateSQLQuery(string queryString)
        {
            return inner.CreateSQLQuery(queryString);
        }

        public void Clear()
        {
            inner.Clear();
        }

        public IDbConnection Close()
        {
            return DoClose(true);
        }


        #endregion

        #region Dispose delegation

        public void Dispose()
        {
            DoClose(false);
        }

        #endregion

        protected IDbConnection DoClose(bool closing)
        {
            if (disposed) return null;

            if (canClose)
            {
                return InternalClose(closing);
            }

            return null;
        }

        internal IDbConnection InternalClose(bool closing)
        {
            IDbConnection conn = null;
	
            sessionStore.Remove(this);

            if (closing)
            {
                conn = inner.Close();
            }

            inner.Dispose();
	
            disposed = true;
	
            return conn;
        }

        public static bool AreEqual(ISession left, ISession right)
        {
            SessionDelegate sdLeft = left as SessionDelegate;
            SessionDelegate sdRight = right as SessionDelegate;

            if (sdLeft != null && sdRight != null)
            {
                return Object.ReferenceEquals( sdLeft.inner, sdRight.inner );
            }
            else
            {
                throw new NotSupportedException("AreEqual: left is " + 
                                                left.GetType().Name + " and right is " + right.GetType().Name);
            }
        }

        IQuery ISession.CreateSQLQuery(string sql, string[] returnAliases, Type[] returnClasses)
        {
            if(returnAliases.Length != returnClasses.Length)
                throw new ArgumentException(" returnAliases's length not equal returnClasses's length");

            ISQLQuery query = inner.CreateSQLQuery(sql);
            for (int i = 0; i < returnClasses.Length; i++)
            {
                query.AddEntity(returnAliases[i], returnClasses[i]);          
            }
            return query;
        }
    }
}