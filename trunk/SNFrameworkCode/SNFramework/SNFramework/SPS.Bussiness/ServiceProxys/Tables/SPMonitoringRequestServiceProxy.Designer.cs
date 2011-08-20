// Generated by MyGeneration Version # (1.3.0.9)
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
using   SPS.Data.Tables.Container;




namespace SPS.Bussiness.ServiceProxys.Tables
{

    public interface ISPMonitoringRequestServiceProxyDesigner
    {
		List<SPMonitoringRequestEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,   SPChannelEntity _channelID, PageQueryParams pageQueryParams);
		List<SPMonitoringRequestEntity> FindAllByChannelID(SPChannelEntity _channelID);
    }

    internal partial class SPMonitoringRequestServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPMonitoringRequestEntity>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPMonitoringRequestDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPMonitoringRequestDataObject)selfDataObject;
            }
        }
	
		public List<SPMonitoringRequestEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,  SPChannelEntity _channelID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_ChannelID_SPChannelEntity(orderByColumnName, isDesc,_channelID, pageQueryParams);
        }
		
		public List<SPMonitoringRequestEntity> FindAllByChannelID(SPChannelEntity _channelID)
        {
			return this.SelfDataObj.GetList_By_ChannelID_SPChannelEntity(_channelID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
