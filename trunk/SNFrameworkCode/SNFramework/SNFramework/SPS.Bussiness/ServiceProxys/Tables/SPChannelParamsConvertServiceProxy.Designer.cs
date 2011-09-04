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




namespace SPS.Bussiness.ServiceProxys.Tables
{

    public interface ISPChannelParamsConvertServiceProxyDesigner
    {
		List<SPChannelParamsConvertEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,   SPChannelEntity _channelID, PageQueryParams pageQueryParams);
		List<SPChannelParamsConvertEntity> FindAllByChannelID(SPChannelEntity _channelID);
    }

    internal partial class SPChannelParamsConvertServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPChannelParamsConvertEntity>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPChannelParamsConvertDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPChannelParamsConvertDataObject)selfDataObject;
            }
        }
	
		public List<SPChannelParamsConvertEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,  SPChannelEntity _channelID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_ChannelID_SPChannelEntity(orderByColumnName, isDesc,_channelID, pageQueryParams);
        }
		
		public List<SPChannelParamsConvertEntity> FindAllByChannelID(SPChannelEntity _channelID)
        {
			return this.SelfDataObj.GetList_By_ChannelID_SPChannelEntity(_channelID);
        }





		
    }
}
