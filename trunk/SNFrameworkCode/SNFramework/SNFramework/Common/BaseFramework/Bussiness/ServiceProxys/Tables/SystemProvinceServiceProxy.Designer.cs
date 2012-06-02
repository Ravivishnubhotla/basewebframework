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

    public interface ISystemProvinceServiceProxyDesigner
    {
		List<SystemProvinceEntity> FindAllByOrderByAndFilterAndCountryID(string orderByColumnName, bool isDesc,   SystemCountryEntity _countryID, PageQueryParams pageQueryParams);
		List<SystemProvinceEntity> FindAllByCountryID(SystemCountryEntity _countryID);
    }

    public partial class SystemProvinceServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemProvinceEntity,int>
    {
		public BaseFrameworkDataObjectContainers DataObjectsContainerIocID { set; get; }
	
        public SystemProvinceDataObject SelfDataObj
        {
            set
            {
                selfDataObject = value;
            }
			get
            {
                return (SystemProvinceDataObject)selfDataObject;
            }
        }
	
		public List<SystemProvinceEntity> FindAllByOrderByAndFilterAndCountryID(string orderByColumnName, bool isDesc,  SystemCountryEntity _countryID, PageQueryParams pageQueryParams)
        {
			return this.SelfDataObj.GetPageList_By_CountryID_SystemCountryEntity(orderByColumnName, isDesc,_countryID, pageQueryParams);
        }
		
		public List<SystemProvinceEntity> FindAllByCountryID(SystemCountryEntity _countryID)
        {
			return this.SelfDataObj.GetList_By_CountryID_SystemCountryEntity(_countryID);
        }





		
    }
}
