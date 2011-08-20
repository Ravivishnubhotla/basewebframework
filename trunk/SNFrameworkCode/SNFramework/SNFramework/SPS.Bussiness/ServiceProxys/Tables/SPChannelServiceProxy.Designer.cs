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

    public interface ISPChannelServiceProxyDesigner
    {
		List<SPChannelEntity> FindAllByOrderByAndFilterAndUpperID(string orderByColumnName, bool isDesc,   SPUpperEntity _upperID, PageQueryParams pageQueryParams);
		List<SPChannelEntity> FindAllByUpperID(SPUpperEntity _upperID);
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
	
		public List<SPChannelEntity> FindAllByOrderByAndFilterAndUpperID(string orderByColumnName, bool isDesc,  SPUpperEntity _upperID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_UpperID_SPUpperEntity(orderByColumnName, isDesc,_upperID, pageQueryParams);
        }
		
		public List<SPChannelEntity> FindAllByUpperID(SPUpperEntity _upperID)
        {
			return this.SelfDataObj.GetList_By_UpperID_SPUpperEntity(_upperID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
