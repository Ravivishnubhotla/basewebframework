
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
    public partial class SystemEmailTemplateWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemEmailTemplateWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemEmailTemplateWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemEmailTemplateWrapper obj)
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

        public static void Delete(SystemEmailTemplateWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemEmailTemplateWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemEmailTemplateWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemEmailTemplateWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemEmailTemplateWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemEmailTemplateEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemEmailTemplateWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc,pageQueryParams);
        }


        public static List<SystemEmailTemplateWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemEmailTemplateWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,pageQueryParams));

            return results;
        }
		

        public static List<SystemEmailTemplateWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

    }
}
