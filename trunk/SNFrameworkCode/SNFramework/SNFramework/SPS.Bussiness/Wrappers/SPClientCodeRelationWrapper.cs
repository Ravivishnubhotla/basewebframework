
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPClientCodeRelationWrapper : BaseSpringNHibernateWrapper<SPClientCodeRelationEntity, ISPClientCodeRelationServiceProxy, SPClientCodeRelationWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SPClientCodeRelationWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPClientCodeRelationWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPClientCodeRelationWrapper obj)
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

        public static void Delete(SPClientCodeRelationWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPClientCodeRelationWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPClientCodeRelationWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPClientCodeRelationWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPClientCodeRelationWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPClientCodeRelationWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SPClientCodeRelationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SPClientCodeRelationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SPClientCodeRelationWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion


        public string CodeID_MoCode
        {
            get
            {
                if (this.CodeID == null)
                    return "";
                return CodeID.MoCode;
            }
        }

        public string ChannelName
        {
            get
            {
                if (this.CodeID == null)
                    return "";
                return this.CodeID.ChannelID_Name;
            }
        }

        public string DataRange
        {
            get
            {
                string startDate = "Î´¿ªÊ¼";

                if(this.StartDate.HasValue)
                {
                    startDate = this.StartDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }

                string endDate = "Î´½áÊø";

                if (this.EndDate.HasValue)
                {
                    endDate = this.EndDate.Value.ToString("yyyy-MM-dd HH:mm:ss");
                }


                return startDate + "<br/>" + endDate;
            }
        }

        public static List<SPCodeWrapper> GetAllCodeByClient(SPSClientWrapper client)
        {
            List<SPClientCodeRelationWrapper> spClientCodeRelations = FindAllByClientID(client);

            List<SPCodeWrapper> spCodes = new List<SPCodeWrapper>();

            foreach (SPClientCodeRelationWrapper spClientCodeRelationWrapper in spClientCodeRelations)
            {
                if(!spCodes.Exists(p=>(p.Id==spClientCodeRelationWrapper.ClientID.Id)))
                    spCodes.Add(spClientCodeRelationWrapper.CodeID);
            }

            return spCodes;
        }


	    public string GenerateSendUrl(SPRecordWrapper record)
        {
            SPRecordExtendInfoWrapper spRecordExtendInfo = record.ExtendInfo;

            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);


            List<SPChannelSycnParamsWrapper> channelSycnParams = record.ChannelID.GetAllSycnParams();

            foreach (SPChannelSycnParamsWrapper channelSycnParam in channelSycnParams)
            {
                switch (channelSycnParam.MappingParams)
                {
                    case DictionaryConst.Dictionary_SPField_LinkID_Key:
                        BulidParams(queryString, channelSycnParam.Name, record.LinkID);
                        break;
                    case DictionaryConst.Dictionary_SPField_MO_Key:
                        BulidParams(queryString, channelSycnParam.Name, record.Mo);
                        break;
                    case DictionaryConst.Dictionary_SPField_Mobile_Key:
                        BulidParams(queryString, channelSycnParam.Name, record.Mobile);
                        break;
                    case DictionaryConst.Dictionary_SPField_SpNumber_Key:
                        BulidParams(queryString, channelSycnParam.Name, record.SpNumber);
                        break;
                    case DictionaryConst.Dictionary_SPField_CreateDate_Key:
                        BulidParams(queryString, channelSycnParam.Name, record.CreateDate.ToString("yyyyMMddhhmmss"));
                        break;
                    case DictionaryConst.Dictionary_SPField_City_Key:
                        BulidParams(queryString, channelSycnParam.Name, record.City);
                        break;
                    case DictionaryConst.Dictionary_SPField_Province_Key:
                        BulidParams(queryString, channelSycnParam.Name, record.Province);
                        break;
                    case DictionaryConst.Dictionary_SPField_FeeTime_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.FeeTime);
                        break;
                    case DictionaryConst.Dictionary_SPField_StartTime_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.StartTime);
                        break;
                    case DictionaryConst.Dictionary_SPField_EndTime_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.EndTime);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField1_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField1);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField2_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField2);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField3_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField3);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField4_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField4);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField5_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField5);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField6_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField6);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField7_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField7);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField8_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField8);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField9_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField9);
                        break;
                    case DictionaryConst.Dictionary_SPField_ExtendField10_Key:
                        BulidParams(queryString, channelSycnParam.Name, spRecordExtendInfo.ExtendField10);
                        break;
                }
            }


            Uri uri = new Uri(this.SycnDataUrl);

            if (string.IsNullOrEmpty(queryString.ToString()))
            {
                return this.SycnDataUrl;
            }

            if (!string.IsNullOrEmpty(uri.Query.Trim()))
                return string.Format("{0}&{1}", this.SycnDataUrl, queryString.ToString());

            return string.Format("{0}?{1}", this.SycnDataUrl, queryString.ToString());
        }



        private void BulidParams(NameValueCollection queryString, string key, string value)
        {
            queryString.Add(key, value);
        }
    }
}
