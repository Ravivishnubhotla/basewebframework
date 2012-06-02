
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
    public partial class SPMonitoringRequestWrapper : BaseSpringNHibernateWrapper<SPMonitoringRequestEntity, ISPMonitoringRequestServiceProxy, SPMonitoringRequestWrapper, int>  
    {
        #region Static Common Data Operation

        public static void Save(SPMonitoringRequestWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPMonitoringRequestWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPMonitoringRequestWrapper obj)
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

        public static void Delete(SPMonitoringRequestWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPMonitoringRequestWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPMonitoringRequestWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPMonitoringRequestWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPMonitoringRequestWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPMonitoringRequestWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SPMonitoringRequestWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SPMonitoringRequestWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SPMonitoringRequestWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
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
