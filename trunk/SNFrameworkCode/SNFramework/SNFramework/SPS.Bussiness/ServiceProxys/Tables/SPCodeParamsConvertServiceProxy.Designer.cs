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

    public interface ISPCodeParamsConvertServiceProxyDesigner
    {
		List<SPCodeParamsConvertEntity> FindAllByOrderByAndFilterAndCodeID(string orderByColumnName, bool isDesc,   SPCodeEntity _codeID, PageQueryParams pageQueryParams);
		List<SPCodeParamsConvertEntity> FindAllByCodeID(SPCodeEntity _codeID);
    }

    internal partial class SPCodeParamsConvertServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPCodeParamsConvertEntity>
    {
		public DataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SPCodeParamsConvertDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SPCodeParamsConvertDataObject)selfDataObject;
            }
        }
	
		public List<SPCodeParamsConvertEntity> FindAllByOrderByAndFilterAndCodeID(string orderByColumnName, bool isDesc,  SPCodeEntity _codeID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_CodeID_SPCodeEntity(orderByColumnName, isDesc,_codeID, pageQueryParams);
        }
		
		public List<SPCodeParamsConvertEntity> FindAllByCodeID(SPCodeEntity _codeID)
        {
			return this.SelfDataObj.GetList_By_CodeID_SPCodeEntity(_codeID);
        }




        public AdoNetDataObject AdoNetDb { set; get; }		

		
    }
}
