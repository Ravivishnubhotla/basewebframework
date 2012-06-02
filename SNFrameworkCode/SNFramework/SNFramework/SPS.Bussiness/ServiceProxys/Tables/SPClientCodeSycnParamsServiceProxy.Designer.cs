// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPClientCodeSycnParamsServiceProxy.Designer.cs">
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
using SPS.Data.Tables;
using SPS.Entity.Tables;
using SPS.Data.Tables.Container;
using SPS.Data.AdoNet;




namespace SPS.Bussiness.ServiceProxys.Tables
{

    public interface ISPClientCodeSycnParamsServiceProxyDesigner
    {
		List<SPClientCodeSycnParamsEntity> FindAllByOrderByAndFilterAndCodeID(string orderByColumnName, bool isDesc,   SPCodeEntity _codeID, PageQueryParams pageQueryParams);
		List<SPClientCodeSycnParamsEntity> FindAllByCodeID(SPCodeEntity _codeID);
    }

    internal partial class SPClientCodeSycnParamsServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPClientCodeSycnParamsEntity,int>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPClientCodeSycnParamsDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPClientCodeSycnParamsDataObject)selfDataObject;
            }
        }
	
		public List<SPClientCodeSycnParamsEntity> FindAllByOrderByAndFilterAndCodeID(string orderByColumnName, bool isDesc,  SPCodeEntity _codeID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_CodeID_SPCodeEntity(orderByColumnName, isDesc,_codeID, pageQueryParams);
        }
		
		public List<SPClientCodeSycnParamsEntity> FindAllByCodeID(SPCodeEntity _codeID)
        {
			return this.SelfDataObj.GetList_By_CodeID_SPCodeEntity(_codeID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
