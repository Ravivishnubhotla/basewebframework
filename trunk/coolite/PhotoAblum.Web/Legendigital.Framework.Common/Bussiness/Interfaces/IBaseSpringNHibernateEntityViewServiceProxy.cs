using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.Interfaces;

namespace Legendigital.Framework.Common.Bussiness.Interfaces
{
    public interface IBaseSpringNHibernateEntityViewServiceProxy<DomainType>
    {
        DomainType GetNewDomainInstance();
        void Refresh(DomainType instance);
        DomainType FindById(object id);
        List<DomainType> FindAll();
        List<DomainType> FindAll(int firstRow, int maxRows, out int recordCount);
        List<DomainType> FindAllByOrderBy(string orderByColumn,bool isDesc,int firstRow, int maxRows, out int recordCount);
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc,
                                                   int firstRow, int maxRows, out int recordCount);
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc);
    }
}
