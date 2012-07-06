// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemMoudleFieldServiceProxy.Designer.cs">
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

    public interface ISystemMoudleFieldServiceProxyDesigner
    {
		List<SystemMoudleFieldEntity> FindAllByOrderByAndFilterAndSystemMoudleID(string orderByColumnName, bool isDesc,   SystemMoudleEntity _systemMoudleID, PageQueryParams pageQueryParams);
		List<SystemMoudleFieldEntity> FindAllBySystemMoudleID(SystemMoudleEntity _systemMoudleID);
    }

    public partial class SystemMoudleFieldServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemMoudleFieldEntity,int>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemMoudleFieldDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemMoudleFieldDataObject)selfDataObject;
            }
        }
	
		public List<SystemMoudleFieldEntity> FindAllByOrderByAndFilterAndSystemMoudleID(string orderByColumnName, bool isDesc,  SystemMoudleEntity _systemMoudleID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_SystemMoudleID_SystemMoudleEntity(orderByColumnName, isDesc,_systemMoudleID, pageQueryParams);
        }
		
		public List<SystemMoudleFieldEntity> FindAllBySystemMoudleID(SystemMoudleEntity _systemMoudleID)
        {
			return this.SelfDataObj.GetList_By_SystemMoudleID_SystemMoudleEntity(_systemMoudleID);
        }





		
    }
}
