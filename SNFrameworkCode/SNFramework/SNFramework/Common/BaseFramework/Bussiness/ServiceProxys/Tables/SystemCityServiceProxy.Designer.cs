// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Data.Tables.Container;




namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{

    public interface ISystemCityServiceProxyDesigner
    {
		List<SystemCityEntity> FindAllByOrderByAndFilterAndProvinceID(string orderByColumnName, bool isDesc,   SystemProvinceEntity _provinceID, PageQueryParams pageQueryParams);
		List<SystemCityEntity> FindAllByProvinceID(SystemProvinceEntity _provinceID);
    }

    public partial class SystemCityServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemCityEntity>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemCityDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemCityDataObject)selfDataObject;
            }
        }
	
		public List<SystemCityEntity> FindAllByOrderByAndFilterAndProvinceID(string orderByColumnName, bool isDesc,  SystemProvinceEntity _provinceID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_ProvinceID_SystemProvinceEntity(orderByColumnName, isDesc,_provinceID, pageQueryParams);
        }
		
		public List<SystemCityEntity> FindAllByProvinceID(SystemProvinceEntity _provinceID)
        {
			return this.SelfDataObj.GetList_By_ProvinceID_SystemProvinceEntity(_provinceID);
        }





		
    }
}