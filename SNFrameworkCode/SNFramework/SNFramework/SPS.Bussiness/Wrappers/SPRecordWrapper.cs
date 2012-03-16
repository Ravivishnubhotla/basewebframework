
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Bussiness.HttpUtils;
using SPS.Data.AdoNet;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPRecordWrapper : BaseSpringNHibernateWrapper<SPRecordEntity, ISPRecordServiceProxy, SPRecordWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SPRecordWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPRecordWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPRecordWrapper obj)
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

        public static void Delete(SPRecordWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPRecordWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPRecordWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPRecordWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPRecordWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPRecordWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SPRecordWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SPRecordWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SPRecordWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion

	    public static void UpdateUrlSuccessSend(int recordId, string url)
	    {
            businessProxy.UpdateUrlSuccessSend(recordId, url);
	    }

	    public static void UpdateUrlFailedSend(int recordId, string sendUrl, string errorMessage)
	    {
            businessProxy.UpdateUrlFailedSend(recordId, sendUrl, errorMessage);
	    }

	    private bool accessExtendInfo = false;
	    private SPRecordExtendInfoWrapper extendInfo;
	    public SPRecordExtendInfoWrapper ExtendInfo
	    {
	        get
	        {
	            if(!accessExtendInfo)
	            {
	                extendInfo = GetExtendInfo();
	                accessExtendInfo = true;
	            }
	            return extendInfo;
	        }
	    }

	    public string SycnDataUrl
	    {
            get
            {
                if (ExtendInfo != null)
                    return ExtendInfo.SSycnDataUrl;
                return "";
            }
	    }

        public string SycnReturnMessage
        {
            get
            {
                if (ExtendInfo != null)
                    return ExtendInfo.SSycnDataFailedMessage;
                return "";
            }
        }

 

	    private SPRecordExtendInfoWrapper GetExtendInfo()
        {
            List<SPRecordExtendInfoWrapper> spRecordExtends = SPRecordExtendInfoWrapper.FindAllByRecordID(this);

            if (spRecordExtends != null && spRecordExtends.Count>0)
            {
                return spRecordExtends[0];
            }

            return null;
        }

        private UrlSendTask GenerateSendUrl()
        {
            if (this.ClientCodeRelationID == null)
                return null;

            UrlSendTask urlSendTask = new UrlSendTask();
            urlSendTask.RecordID = this.Id;
            urlSendTask.OkMessage = this.ClientCodeRelationID.SycnOkMessage;
            urlSendTask.SendUrl = this.ClientCodeRelationID.GenerateSendUrl(this);

            return urlSendTask;
        }

	    public void SycnToClient()
	    {
            if (this.IsStatOK && this.IsSycnToClient && this.ClientCodeRelationID != null)
            {
                UrlSendTask sendTask = this.GenerateSendUrl();

                if (sendTask != null)
                {
                    sendTask.RecordID = this.Id;
                    ThreadPool.QueueUserWorkItem(UrlSender.SendRequest, sendTask);
                }
            }
	    }

        public static bool InsertPayment(SPRecordWrapper record, SPRecordExtendInfoWrapper spRecordExtendInfo, out RequestErrorType requestError, out string errorMessage)
        {
            return businessProxy.InsertPayment(record.Entity, spRecordExtendInfo.Entity, out requestError, out errorMessage);
        }

	    public static SPRecordWrapper FindByChannelIDAndLinkID(string linkid, SPChannelWrapper spChannelWrapper)
	    {
	        return  ConvertEntityToWrapper(businessProxy.FindByLinkIDAndChannelID(spChannelWrapper.Entity, linkid));
	    }


        public static List<SPRecordWrapper> QueryRecordByPage(SPChannelWrapper channel, SPCodeWrapper code, SPSClientWrapper client, string dataType, DateTime? startDate, DateTime? endDate, List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            SPChannelEntity channelEntity = null;
            if (channel != null)
                channelEntity = channel.Entity;

            SPCodeEntity codeEntity = null;
            if (code != null)
                codeEntity = code.Entity;

            SPSClientEntity clientEntity = null;
            if (client != null)
                clientEntity = client.Entity;


            return ConvertToWrapperList(businessProxy.QueryRecordByPage(channelEntity, codeEntity, clientEntity, dataType, startDate, endDate, filters, orderByColumnName, isDesc, pageQueryParams));
        }

        public static List<SPRecordWrapper> QueryRecord(SPChannelWrapper channel, SPCodeWrapper code, SPSClientWrapper client, string dataType, DateTime? startDate, DateTime? endDate, List<QueryFilter> filters, string orderByColumnName, bool isDesc)
        {
            SPChannelEntity channelEntity = null;
            if (channel != null)
                channelEntity = channel.Entity;

            SPCodeEntity codeEntity = null;
            if (code != null)
                codeEntity = code.Entity;

            SPSClientEntity clientEntity = null;
            if (client != null)
                clientEntity = client.Entity;

            return ConvertToWrapperList(businessProxy.QueryRecord(channelEntity, codeEntity, clientEntity, dataType, startDate, endDate, filters, orderByColumnName, isDesc));
        }

        public static string DayReportType_AllUp
        {
            get { return DayReportType.AllUp.ToString(); }
        }
        public static string DayReportType_AllUpSuccess
        {
            get { return DayReportType.AllUpSuccess.ToString(); }
        }
        public static string DayReportType_Intercept
        {
            get { return DayReportType.Intercept.ToString(); }
        }
        public static string DayReportType_Down
        {
            get { return DayReportType.Down.ToString(); }
        }
        public static string DayReportType_DownNotSycn
        {
            get { return DayReportType.DownNotSycn.ToString(); }
        }
        public static string DayReportType_DownSycnFailed
        {
            get { return DayReportType.DownSycnFailed.ToString(); }
        } 
        public static string DayReportType_DownSycnSuccess
        {
            get { return DayReportType.DownSycnSuccess.ToString(); }
        }

	    public static decimal CaculteActualInterceptRate(SPClientCodeRelationWrapper clientCodeRelation, DateTime date)
	    {
	        return businessProxy.CaculteActualInterceptRate(clientCodeRelation.Entity, date);
	    }

        public static void AutoMatch(int channelId, int codeId, int clientId, DateTime startDate, DateTime endDate)
        {
            SPChannelWrapper channel = SPChannelWrapper.FindById(channelId);

            SPCodeWrapper code = SPCodeWrapper.FindById(codeId);

            SPSClientWrapper client = SPSClientWrapper.FindById(clientId);

            List<SPRecordWrapper> records = SPRecordWrapper.QueryRecord(channel, code, client, SPRecordWrapper.DayReportType_AllUp, startDate, endDate, new List<QueryFilter>(), "", false);

            foreach (SPRecordWrapper record in records)
            {
                record.ReAutoMatch();
            }
        }

	    public void ReAutoMatch()
	    {
            SPCodeWrapper matchCode = this.ChannelID.GetMatchCodeFromRequest(this.ExtendInfo.GetHttpRequestLog(), this.Mo, this.SpNumber, this.Province,
	                                               this.City);

            if (matchCode == null)
            {
                return;
            }

            SPClientCodeRelationWrapper clientCodeRelation = matchCode.GetRelateClientCodeRelation();


            //如果存在指令，但是不存在对应的分配关系，转到默认匹配
            if (clientCodeRelation == null)
            {
                clientCodeRelation = this.ChannelID.GetDefaultClientCodeRelation();

                matchCode = clientCodeRelation.CodeID;
            }

	        this.CodeID = matchCode;
	        this.ClientID = clientCodeRelation.ClientID;
	        this.ClientCodeRelationID = clientCodeRelation;

            Update(this);

	    }
    }
}
