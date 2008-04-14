using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using System.Web.UI.WebControls;
using Castle.Services.Transaction;
using log4net;
using NHibernate.Expression;
using NHibernate.Metadata;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Components;
using Powerasp.Enterprise.Core.Data;

namespace Powerasp.Enterprise.Core.Business
{

    //public delegate DomainType LoadDataEventHandler<DomainType>(int dataID);
    //public delegate void DeleteDataEventHandler(int dataID);



    /// <summary>
    /// 业务处理基类
    /// </summary>
    [Transactional]
    public abstract class BaseServices<T> : MarshalByRefObject
    {
        protected BaseCastleNhibernateDao<T> selfDao;

        private ILog logger = null;

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

        public BaseServices(BaseCastleNhibernateDao<T> selfDao)
        {
            this.selfDao = selfDao;
        }

        public virtual T GetNewDomainInstance()
        {
            return Activator.CreateInstance<T>();
        }

        [Transaction(TransactionMode.Requires)]
        public virtual void Create(T obj)
        {
            selfDao.Save(obj);
        }


        [Transaction(TransactionMode.Requires)]
        public virtual void Update(T obj)
        {
            selfDao.Update(obj);
        }

        [Transaction(TransactionMode.Requires)]
        public virtual void DeleteAll()
        {
            selfDao.DeleteAll();
        }

        [Transaction(TransactionMode.Requires)]
        public virtual void DeleteByID(object id)
        {
            selfDao.DeleteByID(id);
        }

        [Transaction(TransactionMode.Requires)]
        public virtual void Delete(T instance)
        {
            selfDao.Delete(instance);
        }

        [Transaction(TransactionMode.Requires)]
        public virtual void Refresh(T instance)
        {
            selfDao.Refresh(instance);
        }

        public virtual T FindById(object id)
        {
            return selfDao.Load(id);
        }

        public virtual List<T> FindAll()
        {
            return selfDao.FindAll();
        }

        protected virtual List<T> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            return selfDao.FindAll(null, null, firstRow, maxRows, out recordCount);
        }

        protected virtual List<T> FindAll(Order[] sortItems, int firstRow, int maxRows, out int recordCount)
        {
            return selfDao.FindAll(null, null, firstRow, maxRows, out recordCount);
        }

        protected virtual void InitializeLazyProperties(T instance)
        {
            selfDao.InitializeLazyProperties(instance);
        }

        protected virtual void InitializeLazyProperty(T instance, string propertyName)
        {
            selfDao.InitializeLazyProperty(instance, propertyName);
        }

        protected virtual List<T> FindAll(ICriterion[] criterias, NHibernate.Expression.Order[] sortItems)
        {
            return selfDao.FindAll(criterias, sortItems);
        }

        protected virtual List<T> FindAll(ICriterion[] criterias, NHibernate.Expression.Order[] sortItems, int firstRow, int maxRows, out int recordCount)
        {
            return selfDao.FindAll(criterias, sortItems, firstRow, maxRows, out recordCount);
        }

        public List<T> GetAll(string orderFieldName,bool isAsc,int firstRow, int maxRows, out int recordCount)
        {
            List<Order> orders = new List<Order>();
            orders.Add(new Order(orderFieldName, isAsc));
            List<ICriterion> criterions = new List<ICriterion>();
            return this.FindAll(criterions.ToArray(), orders.ToArray(), firstRow, maxRows, out recordCount);
        }

        //public virtual T[] FindByProperty(string propertyName, object propertyValue)
        //{
        //    return selfDao.FindByProperty(propertyName, propertyValue);
        //}

        //public virtual T[] FindByProperty(string[] propertyNames, object[] propertyValues)
        //{
        //    return selfDao.FindByProperty(propertyNames, propertyValues);
        //}

        //public virtual bool CheckIfExistByProperty(string propertyName, object propertyValue)
        //{
        //    T[] array = selfDao.FindByProperty(propertyName, propertyValue);
        //    return (array.Length > 0);
        //}

        //public virtual bool CheckIfExistByProperty(string[] propertyNames, object[] propertyValues)
        //{
        //    T[] array = selfDao.FindByProperty(propertyNames, propertyValues);
        //    return (array.Length > 0);
        //}

        //public virtual void BindAllDataToGridView(GridView gridView)
        //{
        //    UIhelper.BindIListToGridView<T>(FindAll(), gridView, GetNewDomainInstance());
        //}
        //public virtual void BindAllDataToGridViewAndAspNetPager(GridView gridView, AspNetPager aspNetPager)
        //{
        //    int recordCount = 0;
        //    Array array =
        //        selfDao.FindAll((aspNetPager.CurrentPageIndex - 1) * aspNetPager.PageSize, aspNetPager.PageSize,
        //                        out recordCount);
        //    UIhelper.BindIListToGridViewAndAspNetPager<T>(array, recordCount, gridView, aspNetPager, GetNewDomainInstance());
        //}
        //public virtual void BindAllDataToGridView(QueryCondition queryCondition, GridView gridView)
        //{
        //    UIhelper.BindIListToGridView<T>(this.FindAll(queryCondition.Criterions.ToArray(), queryCondition.Orders.ToArray()), gridView, GetNewDomainInstance());
        //}
        //public virtual void BindAllDataToGridViewAndAspNetPager(QueryCondition queryCondition, GridView gridView, AspNetPager aspNetPager)
        //{
        //    int recordCount = 0;
        //    Array array =
        //        selfDao.FindAll(queryCondition.Criterions.ToArray(), queryCondition.Orders.ToArray(), (aspNetPager.CurrentPageIndex - 1) * aspNetPager.PageSize, aspNetPager.PageSize,
        //                        out recordCount);
        //    UIhelper.BindIListToGridViewAndAspNetPager<T>(array, recordCount, gridView, aspNetPager, GetNewDomainInstance());
        //}


        //[Transaction(TransactionMode.Requires)]
        //public virtual void ImportData(DataSet ds, string tableName)
        //{
        //    List<PropertyInfo> list = new List<PropertyInfo>();
        //    Type type = typeof(T);
        //    foreach (PropertyInfo info in type.GetProperties())
        //    {
        //        if (info.CanWrite && ds.Tables[tableName].Columns.Contains(info.Name))
        //        {
        //            list.Add(info);
        //        }
        //    }
        //    foreach (DataRow row in ds.Tables[tableName].Rows)
        //    {
        //        T newDomainInstance = this.GetNewDomainInstance();
        //        foreach (PropertyInfo info2 in list)
        //        {
        //            info2.SetValue(newDomainInstance, row[info2.Name], null);
        //        }
        //        this.selfDao.Create(newDomainInstance);
        //    }
        //}

        //[Transaction(TransactionMode.Requires)]
        //public virtual void ImportData(DataSet ds, string tableName, DataRowToEntityHandler<T> dataRowToEntityHandler)
        //{
        //    foreach (DataRow row in ds.Tables[tableName].Rows)
        //    {
        //        T newDomainInstance = this.GetNewDomainInstance();


        //        dataRowToEntityHandler(row, newDomainInstance);


        //        this.selfDao.Create(newDomainInstance);
        //    }
        //}

        public string OutPutDomain(T objInstance)
        {
            string outPutDomain = "";
            IClassMetadata currentClassMetaData = selfDao.CurrentClassMetaData;
            Type domainType = typeof(T);
            foreach (string fieldName in currentClassMetaData.PropertyNames)
            {
                PropertyInfo propertyInfo = domainType.GetProperty(fieldName);
                outPutDomain += fieldName + ":" + propertyInfo.GetValue(objInstance, null).ToString() + "\t";
            }
            return outPutDomain;
        }


    }
}
