
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.Threading;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemConfigWrapper : BaseSpringNHibernateWrapper<SystemConfigEntity, ISystemConfigServiceProxy, SystemConfigWrapper, int>
    {
        #region Static Common Data Operation
		
		public static void Save(SystemConfigWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemConfigWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemConfigWrapper obj)
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

        public static void Delete(SystemConfigWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemConfigWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemConfigWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemConfigWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemConfigWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemConfigWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemConfigWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }
		

        public static List<SystemConfigWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));  
        }
			
		#endregion

 


        public static bool CheckIfExistedConfigByKey(string key)
        {
            return (SystemConfigWrapper.GetConfigByKey(key)!=null);
        }

        public static SystemConfigWrapper GetConfigByKey(string key)
        {
            return ConvertEntityToWrapper(businessProxy.GetConfigByKey(key));
        }


        public static string GetValueByConfigKey(string key, string defaultValue)
        {
            SystemConfigWrapper config = SystemConfigWrapper.GetConfigByKey(key);

            if (config == null)
            {
                return defaultValue;
            }
            else
            {
                return config.ConfigValue;
            }
        }

        [NhibernateQueryPropertyAttribute(MappingColumnName = "ConfigGroupID_SystemConfigEntity_Alias.Name")]
        public string GroupName
        {
            get
            {
                if (this.ConfigGroupID == null)
                    return "";
                return ConfigGroupID.Name;
            }
        }


        public string ConfigDataTypeName
        {
            get
            {
                if (string.IsNullOrEmpty(this.ConfigDataType))
                    return "";
                return SystemDictionaryWrapper.ParseDictionaryValueByGroupCodeAndKey("System_DataType", this.ConfigDataType);
            }
        }

        public string LocaLocalizationName
        {
            get
            {
                return SystemTerminologyWrapper.GetLocalizationName(this.ConfigValue, Thread.CurrentThread.CurrentUICulture.ToString().ToLower());
            }
        }


    }
}
