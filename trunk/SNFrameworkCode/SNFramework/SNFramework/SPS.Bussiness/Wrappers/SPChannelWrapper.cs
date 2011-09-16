
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPChannelWrapper
    {
        #region Static Common Data Operation
		
		protected static void Save(SPChannelWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        protected static void Update(SPChannelWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        protected static void SaveOrUpdate(SPChannelWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        protected static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }

        protected static void DeleteByID(object id)
        {
            businessProxy.DeleteByID(id);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            businessProxy.PatchDeleteByIDs(ids);
        }

        protected static void Delete(SPChannelWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPChannelWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPChannelWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPChannelWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPChannelWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SPChannelEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPChannelWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc,pageQueryParams);
        }


        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SPChannelWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,pageQueryParams));

            return results;
        }
		

        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

 

 

	    public void QuickAddSPChannel(string pLinkId, string pMo, string pMobile, string pSpCode, string pCreateDate, string pProvince, string pCity, string pExtend1, string pExtend2, string pExtend3, string pExtend4, string pExtend5, string pExtend6, string pExtend7, string pExtend8, string pExtend9, string pExtend10)
	    {
            businessProxy.QuickAddSPChannel(this.entity, pLinkId, pMo, pMobile, pSpCode, pCreateDate, pProvince, pCity,
	                                        pExtend1, pExtend2, pExtend3, pExtend4, pExtend5, pExtend6, pExtend7, pExtend8,
	                                        pExtend9, pExtend10);

	    }

	    public void QuickAddIVRChannel(string pIvrLinkId, string pIvrFeetime, string pIvrMobile, string pIvrspCode, string pIvrStartTime, string pIvrEndTime, 
                                        string pIvrProvince, string pIvrCity, string pIvrExtend1, string pIvrExtend2, string pIvrExtend3, string pIvrExtend4, 
                                        string pIvrExtend5, string pIvrExtend6, string pIvrExtend7, string pIvrExtend8, string pIvrExtend9, string pIvrExtend10)
	    {
            businessProxy.QuickAddIVRChannel(this.entity, pIvrLinkId, pIvrFeetime, pIvrMobile, pIvrspCode, pIvrStartTime,
                                             pIvrEndTime, pIvrProvince, pIvrCity, pIvrExtend1, pIvrExtend2, pIvrExtend3,
                                             pIvrExtend4, pIvrExtend5, pIvrExtend6, pIvrExtend7, pIvrExtend8, pIvrExtend9,
                                             pIvrExtend10);
	    }

	    public static SPChannelWrapper GetChannelByDataAdaptorUrl(string dataAdaptorUrl)
	    {
            return ConvertEntityToWrapper(businessProxy.GetChannelByDataAdaptorUrl(dataAdaptorUrl));
	    }

	    public static void UpdateRecord(SPChannelWrapper spChannelWrapper, int userId, DateTime dateTime, string comment)
	    {
	        throw new NotImplementedException();
	    }
    }
}
