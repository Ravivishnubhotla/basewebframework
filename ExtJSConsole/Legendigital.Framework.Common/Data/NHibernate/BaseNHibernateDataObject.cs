﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.Extend;
using NHibernate;
using NHibernate.Collection;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using NHibernate.Metadata;
using NHibernate.Proxy;
using IDictionary=System.Collections.IDictionary;

namespace Legendigital.Framework.Common.Data.NHibernate
{
    public abstract class BaseNHibernateDataObject<DomainType> : BaseNHibernateViewDataObject<DomainType>, IBaseNHibernateDataObject<DomainType>
    {
        #region 基本操作

        /// <summary>
        /// 保存数据
        /// </summary>
        /// <param name="instance">持久化类</param>
        public virtual void Save(DomainType instance)
        {
            try
            { 
                DoGetSession(false).Save(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("Save Object Failed:", ex);
                throw new DataException("Could not perform Save for " + typeof(DomainType).Name, ex);
            }
        }

        ///// <summary>
        ///// 更新数据
        ///// </summary>
        ///// <param name="instance">持久化类</param>
        public virtual void Update(DomainType instance)
        {
            try
            {
                DoGetSession(false).Update(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("Update Object Failed:", ex);
                throw new DataException("Could not perform Update for " + typeof(DomainType).Name, ex);
            }
        }

        /// <summary>
        /// 保存或者更新数据
        /// </summary>
        /// <param name="instance">持久化类</param>
        public virtual void SaveOrUpdate(DomainType instance)
        {
            try
            {
                DoGetSession(false).SaveOrUpdate(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("SaveOrUpdate Object Failed:", ex);
                throw new DataException("Could not perform SaveOrUpdate for " + typeof(DomainType).Name, ex);
            }
        }

        /// <summary>
        /// 添加更新拷贝
        /// </summary>
        /// <param name="instance"></param>
        public virtual void SaveOrUpdateCopy(DomainType instance)
        {
            try
            {
                DoGetSession(false).SaveOrUpdateCopy(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("SaveOrUpdateCopy Object Failed:", ex);
                throw new DataException("Could not perform SaveOrUpdateCopy for " + typeof(DomainType).Name, ex);
            }
        }

        /// <summary>
        /// 部分字段更新
        /// </summary>
        /// <param name="instance">更新的值</param>
        /// <param name="id">id</param>
        /// <param name="updatePropertyNames">需要更新的属性名</param>
        public virtual void PartUpdate(DomainType instance, object id, string[] updatePropertyNames)
        {
            try
            {
                DomainType lastInstance = Load(id);
                Type t = typeof(DomainType);
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
                throw new DataException("Could not perform PartUpdate for " + typeof(DomainType).Name, ex);
            }
        }

        ///// <summary>
        ///// 删除数据
        ///// </summary>
        ///// <param name="instance">需要删除的业务实体</param>
        public virtual void Delete(DomainType instance)
        {
            try
            {
                DoGetSession(false).Delete(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("Delete Object Failed:", ex);
                throw new DataException("Could not perform Delete for " + typeof(DomainType).Name, ex);
            }
        }

        ///// <summary>
        ///// 通过ID删除数据
        ///// </summary>
        ///// <param name="id"></param>
        public virtual void DeleteByID(object id)
        {
            DomainType obj = Load(id);
            if (obj != null)
                Delete(obj);
        }

        ///// <summary>
        ///// 删除所有的数据
        ///// </summary>
        public virtual void DeleteAll()
        {
            try
            {
                DoGetSession(false).Delete(String.Format("from {0}", typeof (DomainType).Name));
            }
            catch (Exception ex)
            {
                throw new DataException("Could not perform DeleteAll for " + typeof(DomainType).Name, ex);
            }
        }

        /// <summary>
        /// 从session中移除对象
        /// </summary>
        ///// <param name="instance"></param>
        public virtual void Evict(DomainType instance)
        {
            try
            {
                DoGetSession(false).Evict(instance);
            }
            catch (Exception ex)
            {
                Logger.Error("Evict Object Failed:", ex);
                throw new DataException("Could not perform Evict for " + typeof(DomainType).Name, ex);
            }
        }

        ///// <summary>
        ///// 锁定对象
        ///// </summary>
        ///// <param name="instance">需要锁定的对象</param>
        ///// <param name="lockMode"></param>
        public virtual void Lock(DomainType instance, LockMode lockMode)
        {
            try
            {
                DoGetSession(false).Lock(instance, lockMode);
            }
            catch (Exception ex)
            {
                Logger.Error("Lock Object Failed:", ex);
                throw new DataException("Could not perform Lock for " + typeof(DomainType).Name, ex);
            }
        }

        #endregion
    }
}