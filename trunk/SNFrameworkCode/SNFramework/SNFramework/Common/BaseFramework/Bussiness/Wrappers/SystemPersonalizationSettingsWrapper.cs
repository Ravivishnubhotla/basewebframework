
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemPersonalizationSettingsWrapper  
    {
        #region Static Common Data Operation

        public static void Save(SystemPersonalizationSettingsWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemPersonalizationSettingsWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemPersonalizationSettingsWrapper obj)
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

        public static void Delete(SystemPersonalizationSettingsWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemPersonalizationSettingsWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemPersonalizationSettingsWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemPersonalizationSettingsWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemPersonalizationSettingsWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemPersonalizationSettingsWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemPersonalizationSettingsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }



        #endregion

        public static void LoadPersonalizationBlobs(string path, string userName, ref byte[] userDataBlob)
        {
            businessProxy.LoadPersonalizationBlobs(path, userName, ref userDataBlob);
        }

        public static void ResetPersonalizationBlob(string path, string userName)
        {
            businessProxy.ResetPersonalizationBlob(path, userName);
        }

        public static void SavePersonalizationBlob(string path, string userName, ref byte[] dataBlob)
        {
            businessProxy.SavePersonalizationBlob(path, userName, dataBlob);
        }
    }
}
