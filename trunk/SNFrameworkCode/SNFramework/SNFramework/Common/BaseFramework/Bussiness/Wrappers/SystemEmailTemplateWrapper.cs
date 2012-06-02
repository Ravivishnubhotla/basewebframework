
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
            Save(obj, businessProxy);
        }

        public static void Update(SystemEmailTemplateWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemEmailTemplateWrapper obj)
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

        public static void Delete(SystemEmailTemplateWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemEmailTemplateWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemEmailTemplateWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemEmailTemplateWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemEmailTemplateWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemEmailTemplateWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemEmailTemplateWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemEmailTemplateWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
        }

        #endregion


        public static SystemEmailTemplateWrapper GetTemplateByName(string name)
        {
            return ConvertEntityToWrapper(businessProxy.GetTemplateByName(name));
        }

        public SortedList<string, string> titleParams = new SortedList<string, string>();
        public SortedList<string, string> bodyParams = new SortedList<string, string>();

        public void PutTitle(string key, string value)
        {
            titleParams.Add(key, value);
        }

        public void PutBody(string key, string value)
        {
            bodyParams.Add(key, value);
        }

        protected string PasreTemplate(string template, SortedList<string, string> tparams)
        {
            string outputTemplate = template;

            foreach (KeyValuePair<string, string> tparam in tparams)
            {
                outputTemplate = outputTemplate.Replace(tparam.Key, tparam.Value);
            }

            return outputTemplate;
        }


        public string GetTitle()
        {
            return PasreTemplate(this.TitleTemplate, titleParams);
        }

        public string GetBody()
        {
            return PasreTemplate(this.BodyTemplate, bodyParams);
        }

   
    }
}
