
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;



namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemSettingWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemSettingWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemSettingWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemSettingWrapper obj)
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

        public static void Delete(SystemSettingWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemSettingWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemSettingWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemSettingWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemSettingWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemSettingEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemSettingWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemSettingWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemSettingWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams));

            return results;
        }
		

		
		#endregion

        public static SystemSettingWrapper GetCurrentSystemSetting()
        {
            return businessProxy.GetCurrentSystemSetting();
        }

        public string LocaLocalizationName
        {
            get
            {
                return SystemTerminologyWrapper.GetLocalizationName(this.SystemName, Thread.CurrentThread.CurrentUICulture.ToString().ToLower());
            }
        }


        public string LocaLocalizationLisence
        {
            get
            {
                return SystemTerminologyWrapper.GetLocalizationName(this.SystemLisence, Thread.CurrentThread.CurrentUICulture.ToString().ToLower());
            }
        }
    }
}
