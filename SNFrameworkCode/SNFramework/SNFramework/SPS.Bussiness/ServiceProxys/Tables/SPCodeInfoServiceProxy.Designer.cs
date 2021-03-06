// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPCodeInfoServiceProxy.Designer.cs">
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

    public interface ISPCodeInfoServiceProxyDesigner
    {
		List<SPCodeInfoEntity> FindAllByOrderByAndFilterAndSPCodeID(string orderByColumnName, bool isDesc,   SPCodeEntity _sPCodeID, PageQueryParams pageQueryParams);
		List<SPCodeInfoEntity> FindAllBySPCodeID(SPCodeEntity _sPCodeID);
    }

    internal partial class SPCodeInfoServiceProxy //: BaseSpringNHibernateEntityServiceProxy<SPCodeInfoEntity,int>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPCodeInfoDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPCodeInfoDataObject)selfDataObject;
            }
        }
	
		public List<SPCodeInfoEntity> FindAllByOrderByAndFilterAndSPCodeID(string orderByColumnName, bool isDesc,  SPCodeEntity _sPCodeID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_SPCodeID_SPCodeEntity(orderByColumnName, isDesc,_sPCodeID, pageQueryParams);
        }
		
		public List<SPCodeInfoEntity> FindAllBySPCodeID(SPCodeEntity _sPCodeID)
        {
			return this.SelfDataObj.GetList_By_SPCodeID_SPCodeEntity(_sPCodeID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
