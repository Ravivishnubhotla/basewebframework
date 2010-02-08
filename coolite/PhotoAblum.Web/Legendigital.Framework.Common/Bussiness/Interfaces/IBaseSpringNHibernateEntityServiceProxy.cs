using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.Data.Interfaces;

namespace Legendigital.Framework.Common.Bussiness.Interfaces
{
    public interface IBaseSpringNHibernateEntityServiceProxy<DomainType> : IBaseSpringNHibernateEntityViewServiceProxy<DomainType>
    {
        void Save(DomainType obj);

        void Update(DomainType obj);

        void SaveOrUpdate(DomainType obj);

        void DeleteAll();

        void DeleteByID(object id);

        void PatchDeleteByIDs(object[] ids);

        void Delete(DomainType instance);
    }
}
