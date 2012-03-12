
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
    public partial class SPSClientWrapper : BaseSpringNHibernateWrapper<SPSClientEntity, ISPSClientServiceProxy, SPSClientWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SPSClientWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPSClientWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPSClientWrapper obj)
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

        public static void Delete(SPSClientWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPSClientWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPSClientWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPSClientWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPSClientWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPSClientWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SPSClientWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SPSClientWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SPSClientWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
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

        public static SPSClientWrapper GetClientByUserID(int userId)
	    {
            return ConvertEntityToWrapper(businessProxy.GetClientByUserID(userId));
	    }

        public List<SPCodeWrapper> GetAllAssignedCode()
	    {
	        return new List<SPCodeWrapper>();
	    }
    }
}
