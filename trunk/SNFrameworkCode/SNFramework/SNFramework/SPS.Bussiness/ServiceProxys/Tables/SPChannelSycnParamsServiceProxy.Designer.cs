// Generated by MyGeneration Version # (1.3.0.9)
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
using LD.SPPipeManage.Data.AdoNet;




namespace SPS.Bussiness.ServiceProxys.Tables
{

    public interface ISPChannelSycnParamsServiceProxyDesigner
    {
		List<SPChannelSycnParamsEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc, int pageIndex, int pageSize,    SPChannelEntity _channelID, out int recordCount);
		List<SPChannelSycnParamsEntity> FindAllByChannelID(SPChannelEntity _channelID);
    }


    internal partial class SPChannelSycnParamsServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPChannelSycnParamsEntity> , ISPChannelSycnParamsServiceProxyDesigner
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPChannelSycnParamsDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPChannelSycnParamsDataObject)selfDataObject;
            }
        }
	
		public List<SPChannelSycnParamsEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,int pageIndex, int pageSize,     SPChannelEntity _channelID,  out int recordCount)
        {
			return this.SelfDataObj.GetPageList_By_SPChannelEntity(orderByColumnName, isDesc,pageIndex, pageSize,_channelID, out recordCount);
        }
		
		public List<SPChannelSycnParamsEntity> FindAllByChannelID(SPChannelEntity _channelID)
        {
			return this.SelfDataObj.GetList_By_SPChannelEntity(_channelID);
        }

		
		
        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
