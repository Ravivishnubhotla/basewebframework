using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.Bussiness.Interfaces
{
    [ServiceContract]
    public interface IBaseSpringNHibernateEntityViewServiceProxy<DomainType> where DomainType : BaseViewEntity
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
        List<DomainType> FindAllByPage(PageQueryParams pageQueryParams);
        [OperationContract]
        List<DomainType> FindAllByOrderBy(string orderByColumn, bool isDesc, PageQueryParams pageQueryParams);
        [OperationContract(Name = "FindAllByOrderByAndFilter_Default")]
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc);
        [OperationContract(Name = "FindAllByOrderByAndFilter_Page")]
        List<DomainType> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumn, bool isDesc,
                                                   PageQueryParams pageQueryParams);

        [OperationContract]
        bool CheckEntityHasProperty(string propertyName);
        [OperationContract]
        object GetEntityPropertyValue(string propertyName,DomainType domain);
    }
}
