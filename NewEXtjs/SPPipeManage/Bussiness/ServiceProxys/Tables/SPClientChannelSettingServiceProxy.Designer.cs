// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Data.Tables;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Data.Tables.Container;
using LD.SPPipeManage.Data.AdoNet;




namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{

    public interface ISPClientChannelSettingServiceProxyDesigner
    {
		List<SPClientChannelSettingEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc, int pageIndex, int pageSize,    SPChannelEntity _channelID, out int recordCount);
		List<SPClientChannelSettingEntity> FindAllByChannelID(SPChannelEntity _channelID);
		List<SPClientChannelSettingEntity> FindAllByOrderByAndFilterAndClinetID(string orderByColumnName, bool isDesc, int pageIndex, int pageSize,    SPClientEntity _clinetID, out int recordCount);
		List<SPClientChannelSettingEntity> FindAllByClinetID(SPClientEntity _clinetID);
    }


    internal partial class SPClientChannelSettingServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPClientChannelSettingEntity> , ISPClientChannelSettingServiceProxyDesigner
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPClientChannelSettingDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPClientChannelSettingDataObject)selfDataObject;
            }
        }
	
		public List<SPClientChannelSettingEntity> FindAllByOrderByAndFilterAndChannelID(string orderByColumnName, bool isDesc,int pageIndex, int pageSize,     SPChannelEntity _channelID,  out int recordCount)
        {
			return this.SelfDataObj.GetPageList_By_SPChannelEntity(orderByColumnName, isDesc,pageIndex, pageSize,_channelID, out recordCount);
        }
		
		public List<SPClientChannelSettingEntity> FindAllByChannelID(SPChannelEntity _channelID)
        {
			return this.SelfDataObj.GetList_By_SPChannelEntity(_channelID);
        }
	
		public List<SPClientChannelSettingEntity> FindAllByOrderByAndFilterAndClinetID(string orderByColumnName, bool isDesc,int pageIndex, int pageSize,     SPClientEntity _clinetID,  out int recordCount)
        {
			return this.SelfDataObj.GetPageList_By_SPClientEntity(orderByColumnName, isDesc,pageIndex, pageSize,_clinetID, out recordCount);
        }
		
		public List<SPClientChannelSettingEntity> FindAllByClinetID(SPClientEntity _clinetID)
        {
			return this.SelfDataObj.GetList_By_SPClientEntity(_clinetID);
        }

		
		
        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
