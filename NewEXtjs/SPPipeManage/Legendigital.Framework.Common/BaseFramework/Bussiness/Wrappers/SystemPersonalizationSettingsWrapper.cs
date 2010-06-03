
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemPersonalizationSettingsWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemPersonalizationSettingsWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemPersonalizationSettingsWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemPersonalizationSettingsWrapper obj)
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

        public static void Delete(SystemPersonalizationSettingsWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemPersonalizationSettingsWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemPersonalizationSettingsWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemPersonalizationSettingsWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemPersonalizationSettingsWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SystemPersonalizationSettingsEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SystemPersonalizationSettingsWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SystemPersonalizationSettingsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SystemPersonalizationSettingsWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
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
