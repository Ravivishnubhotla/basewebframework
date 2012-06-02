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

    public interface ISystemDepartmentServiceProxyDesigner
    {
		List<SystemDepartmentEntity> FindAllByOrderByAndFilterAndOrganizationID(string orderByColumnName, bool isDesc,   SystemOrganizationEntity _organizationID, PageQueryParams pageQueryParams);
		List<SystemDepartmentEntity> FindAllByOrganizationID(SystemOrganizationEntity _organizationID);
    }

    public partial class SystemDepartmentServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemDepartmentEntity,int>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemDepartmentDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemDepartmentDataObject)selfDataObject;
            }
        }
	
		public List<SystemDepartmentEntity> FindAllByOrderByAndFilterAndOrganizationID(string orderByColumnName, bool isDesc,  SystemOrganizationEntity _organizationID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_OrganizationID_SystemOrganizationEntity(orderByColumnName, isDesc,_organizationID, pageQueryParams);
        }
		
		public List<SystemDepartmentEntity> FindAllByOrganizationID(SystemOrganizationEntity _organizationID)
        {
			return this.SelfDataObj.GetList_By_OrganizationID_SystemOrganizationEntity(_organizationID);
        }





		
    }
}
