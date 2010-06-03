using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.Interfaces;

namespace Legendigital.Framework.Common.Bussiness.Interfaces
{
    [ServiceContract]
    public interface IBaseSpringNHibernateEntityViewServiceProxy<DomainType>
    {
        [OperationContract]
        DomainType GetNewDomainInstance();
        [OperationContract]
        void Refresh(DomainType instance);
        [OperationContract]
        DomainType FindById(object id);
        [OperationContract]
        DomainType FullFindById(object id);      
        [OperationContract(Name = "FindAll_Default")]
        List<DomainType> FindAll();
        [OperationContract(Name = "FindAll_Page")]
        List<DomainType> FindAll(int firstRow, int maxRows, out int recordCount);
        [OperationContract]
        List<DomainType> FindAllByOrderBy(string orderByColumn,bool isDesc,int firstRow, int maxRows, out int recordCount);
        [OperationContract(Name = "FindAllByOrderByAndFilter_Default")]
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc);
        [OperationContract(Name = "FindAllByOrderByAndFilter_Page")]
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc,
                                                   int firstRow, int maxRows, out int recordCount);

    }
}
