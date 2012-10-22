// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPAdAssignedHistortyServiceProxy.Designer.cs">
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

    public interface ISPAdAssignedHistortyServiceProxyDesigner
    {
		List<SPAdAssignedHistortyEntity> FindAllByOrderByAndFilterAndSPAdID(string orderByColumnName, bool isDesc,   SPAdvertisementEntity _sPAdID, PageQueryParams pageQueryParams);
		List<SPAdAssignedHistortyEntity> FindAllBySPAdID(SPAdvertisementEntity _sPAdID);
		List<SPAdAssignedHistortyEntity> FindAllByOrderByAndFilterAndSPClientID(string orderByColumnName, bool isDesc,   SPSClientEntity _sPClientID, PageQueryParams pageQueryParams);
		List<SPAdAssignedHistortyEntity> FindAllBySPClientID(SPSClientEntity _sPClientID);
    }

    internal partial class SPAdAssignedHistortyServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPAdAssignedHistortyEntity,int>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPAdAssignedHistortyDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPAdAssignedHistortyDataObject)selfDataObject;
            }
        }
	
		public List<SPAdAssignedHistortyEntity> FindAllByOrderByAndFilterAndSPAdID(string orderByColumnName, bool isDesc,  SPAdvertisementEntity _sPAdID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_SPAdID_SPAdvertisementEntity(orderByColumnName, isDesc,_sPAdID, pageQueryParams);
        }
		
		public List<SPAdAssignedHistortyEntity> FindAllBySPAdID(SPAdvertisementEntity _sPAdID)
        {
			return this.SelfDataObj.GetList_By_SPAdID_SPAdvertisementEntity(_sPAdID);
        }
	
		public List<SPAdAssignedHistortyEntity> FindAllByOrderByAndFilterAndSPClientID(string orderByColumnName, bool isDesc,  SPSClientEntity _sPClientID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_SPClientID_SPSClientEntity(orderByColumnName, isDesc,_sPClientID, pageQueryParams);
        }
		
		public List<SPAdAssignedHistortyEntity> FindAllBySPClientID(SPSClientEntity _sPClientID)
        {
			return this.SelfDataObj.GetList_By_SPClientID_SPSClientEntity(_sPClientID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
