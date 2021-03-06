
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using LD.SPPipeManage.Bussiness.Commons;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
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

        public static List<SPMonitoringRequestWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPMonitoringRequestEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPMonitoringRequestWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPMonitoringRequestWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPMonitoringRequestWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPMonitoringRequestWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

        public static void SaveRequest(HttpRequest httpRequest, string ip, string recievdData, int channelID)
	    {
            try
            {
                SPMonitoringRequestWrapper spFailedRequestWrapper = new SPMonitoringRequestWrapper();

                if (channelID <= 0)
                    spFailedRequestWrapper.ChannelID = null;
                else
                    spFailedRequestWrapper.ChannelID = channelID;



                spFailedRequestWrapper.RecievedSendUrl = httpRequest.Url.ToString();

                spFailedRequestWrapper.RecievedDate = DateTime.Now;

                spFailedRequestWrapper.RecievedContent = recievdData;

                spFailedRequestWrapper.RecievedIP = ip;

                Save(spFailedRequestWrapper);
            }
            catch (Exception e)
            {
                Logger.Error("����ʧ������ʧ�ܣ�", e);
            }
	    }

        public static void SaveRequest(IHttpRequest httpRequest, int channelID)
        {
            try
            {
                SPMonitoringRequestWrapper spFailedRequestWrapper = new SPMonitoringRequestWrapper();

                if (channelID <= 0)
                    spFailedRequestWrapper.ChannelID = null;
                else
                    spFailedRequestWrapper.ChannelID = channelID;



                spFailedRequestWrapper.RecievedSendUrl = httpRequest.RequestUrl;

                spFailedRequestWrapper.RecievedDate = DateTime.Now;

                spFailedRequestWrapper.RecievedContent = httpRequest.RequestData;

                spFailedRequestWrapper.RecievedIP = httpRequest.RequestIp;

                Save(spFailedRequestWrapper);
            }
            catch (Exception e)
            {
                Logger.Error("����ʧ������ʧ�ܣ�", e);
            }
        }
    }
}
