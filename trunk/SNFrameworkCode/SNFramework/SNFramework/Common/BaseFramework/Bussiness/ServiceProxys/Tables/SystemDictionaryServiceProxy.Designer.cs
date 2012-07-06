// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemDictionaryServiceProxy.Designer.cs">
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

    public interface ISystemDictionaryServiceProxyDesigner
    {
		List<SystemDictionaryEntity> FindAllByOrderByAndFilterAndSystemDictionaryGroupID(string orderByColumnName, bool isDesc,   SystemDictionaryGroupEntity _systemDictionaryGroupID, PageQueryParams pageQueryParams);
		List<SystemDictionaryEntity> FindAllBySystemDictionaryGroupID(SystemDictionaryGroupEntity _systemDictionaryGroupID);
    }

    public partial class SystemDictionaryServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemDictionaryEntity,int>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemDictionaryDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemDictionaryDataObject)selfDataObject;
            }
        }
	
		public List<SystemDictionaryEntity> FindAllByOrderByAndFilterAndSystemDictionaryGroupID(string orderByColumnName, bool isDesc,  SystemDictionaryGroupEntity _systemDictionaryGroupID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_SystemDictionaryGroupID_SystemDictionaryGroupEntity(orderByColumnName, isDesc,_systemDictionaryGroupID, pageQueryParams);
        }
		
		public List<SystemDictionaryEntity> FindAllBySystemDictionaryGroupID(SystemDictionaryGroupEntity _systemDictionaryGroupID)
        {
			return this.SelfDataObj.GetList_By_SystemDictionaryGroupID_SystemDictionaryGroupEntity(_systemDictionaryGroupID);
        }





		
    }
}
