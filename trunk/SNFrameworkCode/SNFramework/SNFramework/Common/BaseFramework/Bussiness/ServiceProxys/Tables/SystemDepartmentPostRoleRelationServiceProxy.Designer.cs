// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemDepartmentPostRoleRelationServiceProxy.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
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

    public interface ISystemDepartmentPostRoleRelationServiceProxyDesigner
    {
		List<SystemDepartmentPostRoleRelationEntity> FindAllByOrderByAndFilterAndDepartmentID(string orderByColumnName, bool isDesc,   SystemDepartmentEntity _departmentID, PageQueryParams pageQueryParams);
		List<SystemDepartmentPostRoleRelationEntity> FindAllByDepartmentID(SystemDepartmentEntity _departmentID);
		List<SystemDepartmentPostRoleRelationEntity> FindAllByOrderByAndFilterAndPostID(string orderByColumnName, bool isDesc,   SystemPostEntity _postID, PageQueryParams pageQueryParams);
		List<SystemDepartmentPostRoleRelationEntity> FindAllByPostID(SystemPostEntity _postID);
		List<SystemDepartmentPostRoleRelationEntity> FindAllByOrderByAndFilterAndRoleID(string orderByColumnName, bool isDesc,   SystemRoleEntity _roleID, PageQueryParams pageQueryParams);
		List<SystemDepartmentPostRoleRelationEntity> FindAllByRoleID(SystemRoleEntity _roleID);
    }

    public partial class SystemDepartmentPostRoleRelationServiceProxy //: BaseSpringNHibernateEntityServiceProxy<SystemDepartmentPostRoleRelationEntity,int>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemDepartmentPostRoleRelationDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemDepartmentPostRoleRelationDataObject)selfDataObject;
            }
        }
	
		public List<SystemDepartmentPostRoleRelationEntity> FindAllByOrderByAndFilterAndDepartmentID(string orderByColumnName, bool isDesc,  SystemDepartmentEntity _departmentID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_DepartmentID_SystemDepartmentEntity(orderByColumnName, isDesc,_departmentID, pageQueryParams);
        }
		
		public List<SystemDepartmentPostRoleRelationEntity> FindAllByDepartmentID(SystemDepartmentEntity _departmentID)
        {
			return this.SelfDataObj.GetList_By_DepartmentID_SystemDepartmentEntity(_departmentID);
        }
	
		public List<SystemDepartmentPostRoleRelationEntity> FindAllByOrderByAndFilterAndPostID(string orderByColumnName, bool isDesc,  SystemPostEntity _postID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_PostID_SystemPostEntity(orderByColumnName, isDesc,_postID, pageQueryParams);
        }
		
		public List<SystemDepartmentPostRoleRelationEntity> FindAllByPostID(SystemPostEntity _postID)
        {
			return this.SelfDataObj.GetList_By_PostID_SystemPostEntity(_postID);
        }
	
		public List<SystemDepartmentPostRoleRelationEntity> FindAllByOrderByAndFilterAndRoleID(string orderByColumnName, bool isDesc,  SystemRoleEntity _roleID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_RoleID_SystemRoleEntity(orderByColumnName, isDesc,_roleID, pageQueryParams);
        }
		
		public List<SystemDepartmentPostRoleRelationEntity> FindAllByRoleID(SystemRoleEntity _roleID)
        {
			return this.SelfDataObj.GetList_By_RoleID_SystemRoleEntity(_roleID);
        }





		
    }
}
