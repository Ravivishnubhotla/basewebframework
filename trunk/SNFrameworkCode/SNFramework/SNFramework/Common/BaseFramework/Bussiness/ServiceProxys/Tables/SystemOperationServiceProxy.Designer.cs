// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Data.Tables.Container;




namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{

    public interface ISystemOperationServiceProxyDesigner
    {
		List<SystemOperationEntity> FindAllByOrderByAndFilterAndResourceID(string orderByColumnName, bool isDesc,   SystemResourcesEntity _resourceID, PageQueryParams pageQueryParams);
		List<SystemOperationEntity> FindAllByResourceID(SystemResourcesEntity _resourceID);
    }

    public partial class SystemOperationServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemOperationEntity>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemOperationDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemOperationDataObject)selfDataObject;
            }
        }
	
		public List<SystemOperationEntity> FindAllByOrderByAndFilterAndResourceID(string orderByColumnName, bool isDesc,  SystemResourcesEntity _resourceID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_ResourceID_SystemResourcesEntity(orderByColumnName, isDesc,_resourceID, pageQueryParams);
        }
		
		public List<SystemOperationEntity> FindAllByResourceID(SystemResourcesEntity _resourceID)
        {
			return this.SelfDataObj.GetList_By_ResourceID_SystemResourcesEntity(_resourceID);
        }





		
    }
}
