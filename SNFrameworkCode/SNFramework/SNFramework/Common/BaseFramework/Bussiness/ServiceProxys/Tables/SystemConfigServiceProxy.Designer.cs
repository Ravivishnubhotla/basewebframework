// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemConfigServiceProxy.Designer.cs">
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

    public interface ISystemConfigServiceProxyDesigner
    {
		List<SystemConfigEntity> FindAllByOrderByAndFilterAndConfigGroupID(string orderByColumnName, bool isDesc,   SystemConfigGroupEntity _configGroupID, PageQueryParams pageQueryParams);
		List<SystemConfigEntity> FindAllByConfigGroupID(SystemConfigGroupEntity _configGroupID);
    }

    public partial class SystemConfigServiceProxy //: BaseSpringNHibernateEntityServiceProxy<SystemConfigEntity,int>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemConfigDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemConfigDataObject)selfDataObject;
            }
        }
	
		public List<SystemConfigEntity> FindAllByOrderByAndFilterAndConfigGroupID(string orderByColumnName, bool isDesc,  SystemConfigGroupEntity _configGroupID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_ConfigGroupID_SystemConfigGroupEntity(orderByColumnName, isDesc,_configGroupID, pageQueryParams);
        }
		
		public List<SystemConfigEntity> FindAllByConfigGroupID(SystemConfigGroupEntity _configGroupID)
        {
			return this.SelfDataObj.GetList_By_ConfigGroupID_SystemConfigGroupEntity(_configGroupID);
        }





		
    }
}
