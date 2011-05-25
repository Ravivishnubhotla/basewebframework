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

    public interface ISPClientChannelSycnParamsServiceProxyDesigner
    {
		List<SPClientChannelSycnParamsEntity> FindAllByOrderByAndFilterAndClientChannelSettingID(string orderByColumnName, bool isDesc, int pageIndex, int pageSize,    SPClientChannelSettingEntity _clientChannelSettingID, out int recordCount);
		List<SPClientChannelSycnParamsEntity> FindAllByClientChannelSettingID(SPClientChannelSettingEntity _clientChannelSettingID);
    }


    internal partial class SPClientChannelSycnParamsServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPClientChannelSycnParamsEntity> , ISPClientChannelSycnParamsServiceProxyDesigner
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPClientChannelSycnParamsDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPClientChannelSycnParamsDataObject)selfDataObject;
            }
        }
	
		public List<SPClientChannelSycnParamsEntity> FindAllByOrderByAndFilterAndClientChannelSettingID(string orderByColumnName, bool isDesc,int pageIndex, int pageSize,     SPClientChannelSettingEntity _clientChannelSettingID,  out int recordCount)
        {
			return this.SelfDataObj.GetPageList_By_SPClientChannelSettingEntity(orderByColumnName, isDesc,pageIndex, pageSize,_clientChannelSettingID, out recordCount);
        }
		
		public List<SPClientChannelSycnParamsEntity> FindAllByClientChannelSettingID(SPClientChannelSettingEntity _clientChannelSettingID)
        {
			return this.SelfDataObj.GetList_By_SPClientChannelSettingEntity(_clientChannelSettingID);
        }

		
		
        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
