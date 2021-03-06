
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using LD.SPPipeManage.Bussiness.Commons;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPFailedRequestWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPFailedRequestWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPFailedRequestWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPFailedRequestWrapper obj)
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

        public static void Delete(SPFailedRequestWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPFailedRequestWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPFailedRequestWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPFailedRequestWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPFailedRequestWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPFailedRequestEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPFailedRequestWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPFailedRequestWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPFailedRequestWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPFailedRequestWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

	    public static void SaveFailedRequest(HttpRequest request, string ip, string getRequestValue,string errormessgae,int channelID,int clientID)
	    {
	        try
	        {
	            SPFailedRequestWrapper spFailedRequestWrapper = new SPFailedRequestWrapper();

                if (channelID<=0)
	                spFailedRequestWrapper.ChannelID = null;
                else
                    spFailedRequestWrapper.ChannelID = channelID;

                if (clientID <= 0)
                    spFailedRequestWrapper.ClientID = null;
                else
                    spFailedRequestWrapper.ClientID = clientID;

	            spFailedRequestWrapper.RecievedSendUrl = request.Url.ToString();

	            spFailedRequestWrapper.RecievedDate = DateTime.Now;

	            spFailedRequestWrapper.RecievedContent = getRequestValue;

	            spFailedRequestWrapper.RecievedIP = ip;

	            spFailedRequestWrapper.FailedMessage = errormessgae;

	            Save(spFailedRequestWrapper);
	        }
	        catch (Exception e)
	        {
                Logger.Error("����ʧ������ʧ�ܣ�", e);
	        }
	    }

        public static void SaveFailedRequest(IHttpRequest httprequest, string errormessgae, int channelID, int clientID)
        {
            try
            {
                SPFailedRequestWrapper spFailedRequestWrapper = new SPFailedRequestWrapper();

                if (channelID <= 0)
                    spFailedRequestWrapper.ChannelID = null;
                else
                    spFailedRequestWrapper.ChannelID = channelID;

                if (clientID <= 0)
                    spFailedRequestWrapper.ClientID = null;
                else
                    spFailedRequestWrapper.ClientID = clientID;

                spFailedRequestWrapper.RecievedSendUrl = httprequest.RequestUrl;

                spFailedRequestWrapper.RecievedDate = DateTime.Now;

                spFailedRequestWrapper.RecievedContent = httprequest.RequestData;

                spFailedRequestWrapper.RecievedIP = httprequest.RequestIp;

                spFailedRequestWrapper.FailedMessage = errormessgae;

                Save(spFailedRequestWrapper);
            }
            catch (Exception e)
            {
                Logger.Error("����ʧ������ʧ�ܣ�", e);
            }
        }
    }
}
