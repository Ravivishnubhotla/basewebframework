using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Expression;

namespace Powerasp.Enterprise.Core.Data
{
    /// <summary>
    /// Summary description for INHibernateGenericDao.
    /// </summary>
    /// <remarks>
    /// Contributed by Steve Degosserie <steve.degosserie@vn.netika.com>
    /// </remarks>
    public interface INHibernateGenericDao<T> : IGenericDao<T>
    {
        #region 数据操作

        void Refresh(T instance);
        void Evict(T instance);
        void Lock(T instance, LockMode lockMode);
        void SaveOrUpdateCopy(T instance);
        void SaveOrUpdateCopy(T instance, object id);
        void Replicate(object instance, ReplicationMode replicationMode);

        #endregion

        #region 查询方法

        List<T> FindAll(ICriterion[] criterias);

        List<T> FindAll(ICriterion[] criterias, Order[] sortItems);

        List<T> FindAll(ICriterion[] criterias, int firstRow, int maxRows, out int recordCount);

        List<T> FindAll(ICriterion[] criterias, Order[] sortItems, int firstRow, int maxRows, out int recordCount);

        List<T> FindAllWithCustomQuery(string queryString);

        List<T> FindAllWithCustomQuery(string queryString, int firstRow, int maxRows);

        object FindScalarWithCustomQuery(string queryString);

        List<T> FindListWithNamedQuery(string namedQuery);

        List<T> FindListWithNamedQuery(string namedQuery, int firstRow, int maxRows);

        object FindScalarWithNamedQuery(string namedQuery);

        void InitializeLazyProperties(T instance);

        void InitializeLazyProperty(T instance, string propertyName);

        #endregion
    }
}
