
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Bussiness.HttpUtils;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPMonitoringRequestWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPMonitoringRequestWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPMonitoringRequestWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPMonitoringRequestWrapper obj)
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

        public static void Delete(SPMonitoringRequestWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPMonitoringRequestWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPMonitoringRequestWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPMonitoringRequestWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPMonitoringRequestWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SPMonitoringRequestEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPMonitoringRequestWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc,pageQueryParams);
        }


        public static List<SPMonitoringRequestWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SPMonitoringRequestWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,pageQueryParams));

            return results;
        }
		

        public static List<SPMonitoringRequestWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

	    public static void SaveRequest(HttpRequestLog httpRequestLog, SPChannelWrapper channelID)
	    {
            try
            {
                SPMonitoringRequestWrapper spFailedRequestWrapper = new SPMonitoringRequestWrapper();

                if (channelID == null)
                    spFailedRequestWrapper.ChannelID = null;
                else
                    spFailedRequestWrapper.ChannelID = channelID;



                spFailedRequestWrapper.RecievedSendUrl = httpRequestLog.RequestUrl;

                spFailedRequestWrapper.RecievedDate = DateTime.Now;

                spFailedRequestWrapper.RecievedContent = httpRequestLog.RequestData;

                spFailedRequestWrapper.RecievedIP = httpRequestLog.RequestIp;

                Save(spFailedRequestWrapper);
            }
            catch (Exception e)
            {
                Logger.Error("±£¥Ê ß∞‹«Î«Û ß∞‹£∫", e);
            }
	    }
    }
}
