
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
    public partial class SystemSettingWrapper : BaseSpringNHibernateWrapper<SystemSettingEntity, ISystemSettingServiceProxy, SystemSettingWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SystemSettingWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemSettingWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemSettingWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(object id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SystemSettingWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemSettingWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemSettingWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemSettingWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemSettingWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemSettingWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SystemSettingWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemSettingWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemSettingWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

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
