
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Newtonsoft.Json;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SPSClientWrapper : BaseSpringNHibernateWrapper<SPSClientEntity, ISPSClientServiceProxy, SPSClientWrapper, int>  
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

        public static void DeleteByID(int id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(int[] ids)
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

        public static SPSClientWrapper FindById(int id)
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
            List<SPClientCodeRelationWrapper> spClientCodeRelations = SPClientCodeRelationWrapper.FindAllByClientID(this);

            List<SPCodeWrapper> spCodes = new List<SPCodeWrapper>();

            foreach (SPClientCodeRelationWrapper spClientCodeRelationWrapper in spClientCodeRelations)
            {
                if (!spCodes.Exists(p => (p.Id == spClientCodeRelationWrapper.ClientID.Id)&&(!p.IsDiable)))
                    spCodes.Add(spClientCodeRelationWrapper.CodeID);
            }

            return spCodes;
	    }
    }
}
