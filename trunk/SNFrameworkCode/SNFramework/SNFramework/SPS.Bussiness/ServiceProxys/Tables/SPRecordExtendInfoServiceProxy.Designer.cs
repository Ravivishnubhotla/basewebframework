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

    public interface ISPRecordExtendInfoServiceProxyDesigner
    {
		List<SPRecordExtendInfoEntity> FindAllByOrderByAndFilterAndRecordID(string orderByColumnName, bool isDesc,   SPRecordEntity _recordID, PageQueryParams pageQueryParams);
		List<SPRecordExtendInfoEntity> FindAllByRecordID(SPRecordEntity _recordID);
    }

    internal partial class SPRecordExtendInfoServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPRecordExtendInfoEntity>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPRecordExtendInfoDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPRecordExtendInfoDataObject)selfDataObject;
            }
        }
	
		public List<SPRecordExtendInfoEntity> FindAllByOrderByAndFilterAndRecordID(string orderByColumnName, bool isDesc,  SPRecordEntity _recordID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_RecordID_SPRecordEntity(orderByColumnName, isDesc,_recordID, pageQueryParams);
        }
		
		public List<SPRecordExtendInfoEntity> FindAllByRecordID(SPRecordEntity _recordID)
        {
			return this.SelfDataObj.GetList_By_RecordID_SPRecordEntity(_recordID);
        }





		
    }
}
