using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.Extend;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Metadata;

namespace Legendigital.Framework.Common.Data.Interfaces
{
    public interface IBaseNHibernateDataObject<DomainType> : IGenericDataObject<DomainType>, IBaseNHibernateViewDataObject<DomainType>
    {
        /// <summary>
        /// 添加更新拷贝
        /// </summary>
        /// <param name="instance"></param>
        void SaveOrUpdateCopy(DomainType instance);

        /// <summary>
        /// 从session中移除对象
        /// </summary>
        ///// <param name="instance"></param>
        void Evict(DomainType instance);

        void Lock(DomainType instance, LockMode lockMode);


       
    }
}