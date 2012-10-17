// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPParamsConvertRuleServiceProxy.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Data.Tables;
using SPS.Entity.Tables;
using SPS.Data.Tables.Container;
using SPS.Data.AdoNet;




namespace SPS.Bussiness.ServiceProxys.Tables
{

    public interface ISPParamsConvertRuleServiceProxyDesigner
    {
    }

    internal partial class SPParamsConvertRuleServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPParamsConvertRuleEntity,int>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPParamsConvertRuleDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPParamsConvertRuleDataObject)selfDataObject;
            }
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
