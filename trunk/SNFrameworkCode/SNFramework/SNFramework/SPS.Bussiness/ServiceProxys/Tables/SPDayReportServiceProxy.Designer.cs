// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPDayReportServiceProxy.Designer.cs">
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

    public interface ISPDayReportServiceProxyDesigner
    {
		List<SPDayReportEntity> FindAllByOrderByAndFilterAndClientID(string orderByColumnName, bool isDesc,   SPSClientEntity _clientID, PageQueryParams pageQueryParams);
		List<SPDayReportEntity> FindAllByClientID(SPSClientEntity _clientID);
		List<SPDayReportEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,   SPChannelEntity _channelID, PageQueryParams pageQueryParams);
		List<SPDayReportEntity> FindAllByChannelID(SPChannelEntity _channelID);
		List<SPDayReportEntity> FindAllByOrderByAndFilterAndCodeID(string orderByColumnName, bool isDesc,   SPCodeEntity _codeID, PageQueryParams pageQueryParams);
		List<SPDayReportEntity> FindAllByCodeID(SPCodeEntity _codeID);
		List<SPDayReportEntity> FindAllByOrderByAndFilterAndUperID(string orderByColumnName, bool isDesc,   SPUpperEntity _uperID, PageQueryParams pageQueryParams);
		List<SPDayReportEntity> FindAllByUperID(SPUpperEntity _uperID);
    }

    internal partial class SPDayReportServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPDayReportEntity,int>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPDayReportDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPDayReportDataObject)selfDataObject;
            }
        }
	
		public List<SPDayReportEntity> FindAllByOrderByAndFilterAndClientID(string orderByColumnName, bool isDesc,  SPSClientEntity _clientID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_ClientID_SPSClientEntity(orderByColumnName, isDesc,_clientID, pageQueryParams);
        }
		
		public List<SPDayReportEntity> FindAllByClientID(SPSClientEntity _clientID)
        {
			return this.SelfDataObj.GetList_By_ClientID_SPSClientEntity(_clientID);
        }
	
		public List<SPDayReportEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,  SPChannelEntity _channelID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_ChannelID_SPChannelEntity(orderByColumnName, isDesc,_channelID, pageQueryParams);
        }
		
		public List<SPDayReportEntity> FindAllByChannelID(SPChannelEntity _channelID)
        {
			return this.SelfDataObj.GetList_By_ChannelID_SPChannelEntity(_channelID);
        }
	
		public List<SPDayReportEntity> FindAllByOrderByAndFilterAndCodeID(string orderByColumnName, bool isDesc,  SPCodeEntity _codeID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_CodeID_SPCodeEntity(orderByColumnName, isDesc,_codeID, pageQueryParams);
        }
		
		public List<SPDayReportEntity> FindAllByCodeID(SPCodeEntity _codeID)
        {
			return this.SelfDataObj.GetList_By_CodeID_SPCodeEntity(_codeID);
        }
	
		public List<SPDayReportEntity> FindAllByOrderByAndFilterAndUperID(string orderByColumnName, bool isDesc,  SPUpperEntity _uperID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_UperID_SPUpperEntity(orderByColumnName, isDesc,_uperID, pageQueryParams);
        }
		
		public List<SPDayReportEntity> FindAllByUperID(SPUpperEntity _uperID)
        {
			return this.SelfDataObj.GetList_By_UperID_SPUpperEntity(_uperID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
