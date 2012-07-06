// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemUserProfilePropertysServiceProxy.Designer.cs">
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

    public interface ISystemUserProfilePropertysServiceProxyDesigner
    {
    }

    public partial class SystemUserProfilePropertysServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemUserProfilePropertysEntity,int>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemUserProfilePropertysDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemUserProfilePropertysDataObject)selfDataObject;
            }
        }





		
    }
}
