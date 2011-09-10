
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPSClientWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPSClientWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPSClientWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPSClientWrapper obj)
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

        public static void Delete(SPSClientWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPSClientWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPSClientWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPSClientWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPSClientWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SPSClientEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPSClientWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc,pageQueryParams);
        }


        public static List<SPSClientWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SPSClientWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,pageQueryParams));

            return results;
        }
		

        public static List<SPSClientWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion


	    public string RelateUserLoginID
	    {
	        get
	        {
                if (this.UserID == null)
                    return "";

	            SystemUserWrapper user = SystemUserWrapper.FindById(this.UserID);

                if(user==null)
                    return "";

	            return user.UserLoginID;
	        }
	    }

	    public static void QuickAdd(SPSClientWrapper spsClientWrapper, string loginId, string password)
	    {
	        businessProxy.QuickAdd(spsClientWrapper.entity, loginId, password);
	    }
    }
}
