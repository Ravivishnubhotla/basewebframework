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

    public interface ISystemUserGroupUserRelationServiceProxyDesigner
    {
		List<SystemUserGroupUserRelationEntity> FindAllByOrderByAndFilterAndUserID(string orderByColumnName, bool isDesc,   SystemUserEntity _userID, PageQueryParams pageQueryParams);
		List<SystemUserGroupUserRelationEntity> FindAllByUserID(SystemUserEntity _userID);
		List<SystemUserGroupUserRelationEntity> FindAllByOrderByAndFilterAndUserGroupID(string orderByColumnName, bool isDesc,   SystemUserGroupEntity _userGroupID, PageQueryParams pageQueryParams);
		List<SystemUserGroupUserRelationEntity> FindAllByUserGroupID(SystemUserGroupEntity _userGroupID);
    }

    public partial class SystemUserGroupUserRelationServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemUserGroupUserRelationEntity>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemUserGroupUserRelationDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemUserGroupUserRelationDataObject)selfDataObject;
            }
        }
	
		public List<SystemUserGroupUserRelationEntity> FindAllByOrderByAndFilterAndUserID(string orderByColumnName, bool isDesc,  SystemUserEntity _userID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_UserID_SystemUserEntity(orderByColumnName, isDesc,_userID, pageQueryParams);
        }
		
		public List<SystemUserGroupUserRelationEntity> FindAllByUserID(SystemUserEntity _userID)
        {
			return this.SelfDataObj.GetList_By_UserID_SystemUserEntity(_userID);
        }
	
		public List<SystemUserGroupUserRelationEntity> FindAllByOrderByAndFilterAndUserGroupID(string orderByColumnName, bool isDesc,  SystemUserGroupEntity _userGroupID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_UserGroupID_SystemUserGroupEntity(orderByColumnName, isDesc,_userGroupID, pageQueryParams);
        }
		
		public List<SystemUserGroupUserRelationEntity> FindAllByUserGroupID(SystemUserGroupEntity _userGroupID)
        {
			return this.SelfDataObj.GetList_By_UserGroupID_SystemUserGroupEntity(_userGroupID);
        }





		
    }
}
