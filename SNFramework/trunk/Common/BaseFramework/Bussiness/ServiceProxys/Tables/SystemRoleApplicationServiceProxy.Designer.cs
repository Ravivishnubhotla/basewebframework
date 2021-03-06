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

    public interface ISystemRoleApplicationServiceProxyDesigner
    {
		List<SystemRoleApplicationEntity> FindAllByOrderByAndFilterAndRoleID(string orderByColumnName, bool isDesc,   SystemRoleEntity _roleID, PageQueryParams pageQueryParams);
		List<SystemRoleApplicationEntity> FindAllByRoleID(SystemRoleEntity _roleID);
		List<SystemRoleApplicationEntity> FindAllByOrderByAndFilterAndApplicationID(string orderByColumnName, bool isDesc,   SystemApplicationEntity _applicationID, PageQueryParams pageQueryParams);
		List<SystemRoleApplicationEntity> FindAllByApplicationID(SystemApplicationEntity _applicationID);
    }

    public partial class SystemRoleApplicationServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemRoleApplicationEntity>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemRoleApplicationDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemRoleApplicationDataObject)selfDataObject;
            }
        }
	
		public List<SystemRoleApplicationEntity> FindAllByOrderByAndFilterAndRoleID(string orderByColumnName, bool isDesc,  SystemRoleEntity _roleID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_RoleID_SystemRoleEntity(orderByColumnName, isDesc,_roleID, pageQueryParams);
        }
		
		public List<SystemRoleApplicationEntity> FindAllByRoleID(SystemRoleEntity _roleID)
        {
			return this.SelfDataObj.GetList_By_RoleID_SystemRoleEntity(_roleID);
        }
	
		public List<SystemRoleApplicationEntity> FindAllByOrderByAndFilterAndApplicationID(string orderByColumnName, bool isDesc,  SystemApplicationEntity _applicationID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_ApplicationID_SystemApplicationEntity(orderByColumnName, isDesc,_applicationID, pageQueryParams);
        }
		
		public List<SystemRoleApplicationEntity> FindAllByApplicationID(SystemApplicationEntity _applicationID)
        {
			return this.SelfDataObj.GetList_By_ApplicationID_SystemApplicationEntity(_applicationID);
        }





		
    }
}
