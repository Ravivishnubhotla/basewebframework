// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using SPS.Bussiness.HttpUtils;
using SPS.Bussiness.Wrappers;
using SPS.Data.Tables;
using SPS.Entity.Tables;
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace SPS.Bussiness.ServiceProxys.Tables
{
    public interface ISPRecordServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SPRecordEntity, int>, ISPRecordServiceProxyDesigner
    {
	    void UpdateUrlSuccessSend(int recordId, string url);
	    void UpdateUrlFailedSend(int recordId, string sendUrl, string errorMessage);
        bool InsertPayment(SPRecordEntity record, SPRecordExtendInfoEntity spRecordExtendInfo, out RequestErrorType requestError, out string errorMessage);
	    SPRecordEntity FindByLinkIDAndChannelID(SPChannelEntity channelID, string linkId);
        List<SPRecordEntity> QueryRecordByPage(SPChannelEntity channel, SPCodeEntity code, SPSClientEntity client, string dataType, DateTime? startDate, DateTime? endDate, List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams);
        List<SPRecordEntity> QueryRecord(SPChannelEntity channel, SPCodeEntity code, SPSClientEntity client, string dataType, DateTime? startDate, DateTime? endDate, List<QueryFilter> filters, string orderByColumnName, bool isDesc);
        decimal CaculteActualInterceptRate(SPClientCodeRelationEntity clientCodeRelation, DateTime date);
        //void AutoMatch(int channelId, int codeId, int clientId, DateTime startDate, DateTime endDate);
        List<SPRecordEntity> FindAllSendRecordByClientAndCodeAndDateRange(SPSClientEntity client, SPCodeEntity code, DateTime startDate, DateTime endDate);
    }

    internal partial class SPRecordServiceProxy : BaseSpringNHibernateEntityServiceProxy<SPRecordEntity,int>, ISPRecordServiceProxy
    {
        public void UpdateUrlSuccessSend(int recordId, string url)
        {
            this.AdoNetDb.UpdateUrlSuccessSend(recordId, url);
        }

        public void UpdateUrlFailedSend(int recordId, string sendUrl, string errorMessage)
        {
            this.AdoNetDb.UpdateUrlFailedSend(recordId, sendUrl, errorMessage);
        }

        public bool InsertPayment(SPRecordEntity record, SPRecordExtendInfoEntity spRecordExtendInfo, out RequestErrorType requestError, out string errorMessage)
        {
            requestError = RequestErrorType.NoError;

            if (this.CheckHasLinkIDAndChannelID(record.ChannelID, record.LinkID))
            {
                requestError = RequestErrorType.RepeatLinkID;

                errorMessage = "";

                return false;
            }

            try
            {
                this.DataObjectsContainerIocID.SPRecordDataObjectInstance.Save(record);
                spRecordExtendInfo.RecordID = record;
                this.DataObjectsContainerIocID.SPRecordExtendInfoDataObjectInstance.Save(spRecordExtendInfo);
                errorMessage = "";
                return true;
            }
            catch (Exception ex)
            {
                Exception innerEx = ex;

                while (innerEx.InnerException != null)
                {
                    innerEx = innerEx.InnerException;
                }

                if (innerEx is SqlException && ((SqlException)innerEx).Number == 2601)
                {
                    requestError = RequestErrorType.RepeatLinkID;
                    errorMessage = "";
                    return false;
                }

                throw ex;
            }
        }

        private bool CheckHasLinkIDAndChannelID(SPChannelEntity channelID, string linkId)
        {
            SPRecordEntity spPaymentInfoEntity = FindByLinkIDAndChannelID(channelID, linkId);

            return (spPaymentInfoEntity != null);
        }

        public SPRecordEntity FindByLinkIDAndChannelID(SPChannelEntity channelID, string linkId)
        {
            return this.DataObjectsContainerIocID.SPRecordDataObjectInstance.FindByLinkIDAndChannelID(channelID, linkId);
        }

        public List<SPRecordEntity> QueryRecordByPage(SPChannelEntity channel, SPCodeEntity code, SPSClientEntity client, string dataType, DateTime? startDate, DateTime? endDate, List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return this.SelfDataObj.QueryRecordByPage(channel, code, client, dataType, startDate, endDate, filters,
                                                      orderByColumnName, isDesc, pageQueryParams);
        }

        public List<SPRecordEntity> QueryRecord(SPChannelEntity channel, SPCodeEntity code, SPSClientEntity client, string dataType, DateTime? startDate, DateTime? endDate, List<QueryFilter> filters, string orderByColumnName, bool isDesc)
        {
            return this.SelfDataObj.QueryRecordByPage(channel, code, client, dataType, startDate, endDate, filters,
                                                      orderByColumnName, isDesc);
        }

        public decimal CaculteActualInterceptRate(SPClientCodeRelationEntity clientCodeRelation, DateTime date)
        {
            return this.AdoNetDb.CaculteActualInterceptRate(clientCodeRelation, date);
        }

        public List<SPRecordEntity> FindAllSendRecordByClientAndCodeAndDateRange(SPSClientEntity client, SPCodeEntity code, DateTime startDate, DateTime endDate)
        {
            return this.SelfDataObj.QueryRecordByPage(null, code, client, "DownNotSycn", startDate, endDate, new List<QueryFilter>(),
                                                     SPRecordWrapper.PROPERTY_NAME_CREATEDATE, false);
        }
    }
}
