
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Bussiness.HttpUtils;
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


        public SPRecordExtendInfoWrapper GetExtendInfo()
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
            if (this.IsSycnToClient && this.ClientCodeRelationID != null)
            {
                UrlSendTask sendTask = this.GenerateSendUrl();

                if (sendTask != null)
                {
                    sendTask.RecordID = this.Id;
                    ThreadPool.QueueUserWorkItem(UrlSender.SendRequest, sendTask);
                }
            }

	    }
    }
}
