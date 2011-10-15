
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemConfigWrapper : BaseSpringNHibernateWrapper<SystemConfigEntity, ISystemConfigServiceProxy, SystemConfigWrapper>
    {
        #region Static Common Data Operation
		
		public static void Save(SystemConfigWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemConfigWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemConfigWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }

        public static void DeleteByID(object id)
        {
            businessProxy.DeleteByID(id);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            businessProxy.PatchDeleteByIDs(ids);
        }

        public static void Delete(SystemConfigWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemConfigWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemConfigWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemConfigWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemConfigWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemConfigEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemConfigWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            Type entityType = typeof(SystemConfigWrapper);

            PropertyInfo[] ps = entityType.GetProperties();

            foreach (PropertyInfo propertyInfo in ps)
            {
                if (!propertyInfo.CanWrite && propertyInfo.CanRead && propertyInfo.Name == orderByColumnName)
                {
                    object[] npas = propertyInfo.GetCustomAttributes(typeof(NhibernateQueryPropertyAttribute), false);

                    foreach (object npa in npas)
                    {
                        if (npa is NhibernateQueryPropertyAttribute)
                        {
                            orderByColumnName = ((NhibernateQueryPropertyAttribute)npa).MappingColumnName;
                            break;
                        }
                    }
                }
            }


            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemConfigWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemConfigWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams));

            return results;
        }
		

        public static List<SystemConfigWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
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

    }
}
