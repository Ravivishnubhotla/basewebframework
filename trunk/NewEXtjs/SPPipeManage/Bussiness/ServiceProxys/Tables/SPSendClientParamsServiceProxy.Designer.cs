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
using   LD.SPPipeManage.Data.Tables.Container;




namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{

    public interface ISPSendClientParamsServiceProxyDesigner
    {
		List<SPSendClientParamsEntity> FindAllByOrderByAndFilterAndClientID(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, SPClientEntity _clientID, out int recordCount);
		List<SPSendClientParamsEntity> FindAllByClientID(SPClientEntity _clientID);
    }

    internal partial class SPSendClientParamsServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPSendClientParamsEntity>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPSendClientParamsDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPSendClientParamsDataObject)selfDataObject;
            }
        }
	
		public List<SPSendClientParamsEntity> FindAllByOrderByAndFilterAndClientID(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, SPClientEntity _clientID, out int recordCount)
        {
			return this.SelfDataObj.GetPageList_By_SPClientEntity(orderByColumnName, isDesc, pageIndex, pageSize,_clientID, out recordCount);
        }
		
		public List<SPSendClientParamsEntity> FindAllByClientID(SPClientEntity _clientID)
        {
			return this.SelfDataObj.GetList_By_SPClientEntity(_clientID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}