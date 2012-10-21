
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Entity;
using Legendigital.Framework.Common.Utility;
using Newtonsoft.Json;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemVersionWrapper : BaseSpringNHibernateWrapper<SystemVersionEntity, ISystemVersionServiceProxy, SystemVersionWrapper, int>
    {
        #region Static Common Data Operation
		
		public static void Save(SystemVersionWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemVersionWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemVersionWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(int id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(int[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SystemVersionWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemVersionWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemVersionWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemVersionWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemVersionWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }
		
		public static List<SystemVersionWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemVersionWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));     
        }
		

        public static List<SystemVersionWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
        }
			
		#endregion
 
        public void GetChangeField(SystemVersionWrapper currentDataVersion)
        {
            this.NewChangeFileld = "";
            this.OldChangeFileld = "";

            PropertyChangeInfo propertyChangeInfo = new PropertyChangeInfo
            (
                JsonConvert.DeserializeObject<Dictionary<string, string>>(currentDataVersion.VauleField),
                JsonConvert.DeserializeObject<Dictionary<string, string>>(this.VauleField)
            );

            if (!string.IsNullOrEmpty(currentDataVersion.VauleField))
            {
                propertyChangeInfo.GetChangeFields();
                this.NewChangeFileld = JsonConvert.SerializeObject(propertyChangeInfo.NewChangedPropertys);
                this.OldChangeFileld = JsonConvert.SerializeObject(propertyChangeInfo.OldChangedPropertys);
            }
        }

        public static SystemVersionWrapper GetCurrentVersionByDataTypeAndDataID(string dataType, int dataId)
        {
            return ConvertEntityToWrapper(businessProxy.GetMaxDataVersionByDataTypeAndDataID(dataType, dataId));
        }

    }
}

 