
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
    public partial class SystemShortMessageWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemShortMessageWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemShortMessageWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemShortMessageWrapper obj)
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

        public static void Delete(SystemShortMessageWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemShortMessageWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemShortMessageWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemShortMessageWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemShortMessageWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemShortMessageEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemShortMessageWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemShortMessageWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemShortMessageWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams));

            return results;
        }
		

		
		#endregion

    }
}
