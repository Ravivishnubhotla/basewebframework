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

    public interface ISPChannelServiceProxyDesigner
    {
		List<SPChannelEntity> FindAllByOrderByAndFilterAndUperID(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, SPUperEntity _uperID, out int recordCount);
		List<SPChannelEntity> FindAllByUperID(SPUperEntity _uperID);
    }

    internal partial class SPChannelServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPChannelEntity>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPChannelDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPChannelDataObject)selfDataObject;
            }
        }
	
		public List<SPChannelEntity> FindAllByOrderByAndFilterAndUperID(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, SPUperEntity _uperID, out int recordCount)
        {
			return this.SelfDataObj.GetPageList_By_SPUperEntity(orderByColumnName, isDesc, pageIndex, pageSize,_uperID, out recordCount);
        }
		
		public List<SPChannelEntity> FindAllByUperID(SPUperEntity _uperID)
        {
			return this.SelfDataObj.GetList_By_SPUperEntity(_uperID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
