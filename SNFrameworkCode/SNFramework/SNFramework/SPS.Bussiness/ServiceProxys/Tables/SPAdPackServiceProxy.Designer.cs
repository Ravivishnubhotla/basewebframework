// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPAdPackServiceProxy.Designer.cs">
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

    public interface ISPAdPackServiceProxyDesigner
    {
		List<SPAdPackEntity> FindAllByOrderByAndFilterAndSPAdID(string orderByColumnName, bool isDesc,   SPAdvertisementEntity _sPAdID, PageQueryParams pageQueryParams);
		List<SPAdPackEntity> FindAllBySPAdID(SPAdvertisementEntity _sPAdID);
    }

    internal partial class SPAdPackServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPAdPackEntity,int>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPAdPackDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPAdPackDataObject)selfDataObject;
            }
        }
	
		public List<SPAdPackEntity> FindAllByOrderByAndFilterAndSPAdID(string orderByColumnName, bool isDesc,  SPAdvertisementEntity _sPAdID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_SPAdID_SPAdvertisementEntity(orderByColumnName, isDesc,_sPAdID, pageQueryParams);
        }
		
		public List<SPAdPackEntity> FindAllBySPAdID(SPAdvertisementEntity _sPAdID)
        {
			return this.SelfDataObj.GetList_By_SPAdID_SPAdvertisementEntity(_sPAdID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
