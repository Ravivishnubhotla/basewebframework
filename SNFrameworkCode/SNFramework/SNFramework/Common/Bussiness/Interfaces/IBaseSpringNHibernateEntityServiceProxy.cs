using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.Bussiness.Interfaces
{
    [ServiceContract]
    public interface IBaseSpringNHibernateEntityServiceProxy<DomainType, EntityKeyType> : IBaseSpringNHibernateEntityViewServiceProxy<DomainType, EntityKeyType> where DomainType : BaseTableEntity<EntityKeyType>
    {
        [OperationContract]
        void Save(DomainType obj);

        [OperationContract]
        void Update(DomainType obj);

        [OperationContract]
        void SaveOrUpdate(DomainType obj);

        [OperationContract]
        void DeleteAll();

        [OperationContract]
        void DeleteByID(EntityKeyType id);

        [OperationContract]
        void PatchDeleteByIDs(EntityKeyType[] ids);

        [OperationContract]
        void Delete(DomainType instance);
    }
}
