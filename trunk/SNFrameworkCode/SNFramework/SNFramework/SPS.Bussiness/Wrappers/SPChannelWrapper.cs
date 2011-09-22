
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Bussiness.Code;
using SPS.Bussiness.HttpUtils;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPChannelWrapper
    {
	    public bool NeedInitParams
	    {
	        get { return false; }
	    }

	    #region Static Common Data Operation

        public static void Save(SPChannelWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPChannelWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPChannelWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        protected static void DeleteAll()
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

        public static void Delete(SPChannelWrapper instance)
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

	    public string GetFailedCode(HttpRequestLog httpRequestLog)
	    {
	        return this.DataFailedMessage;
	    }

	    public bool CheckRequestIsFilters(HttpRequestLog httpRequestLog)
	    {
	        return false;
	    }

	    public void ParamsConvert(HttpRequestLog httpRequestLog)
	    {
	        return;
	    }

	    public void InitParams(HttpRequestLog httpRequestLog)
	    {
            return;
	    }

	    public bool ProcessRequest(HttpRequestLog httpRequestLog, out RequestErrorType requestError, out string errorMessage)
	    {
            requestError = RequestErrorType.NoError;
            errorMessage = "";

	        string linkid = GetLinkID(httpRequestLog);

            if (string.IsNullOrEmpty(linkid))
            {
                requestError = RequestErrorType.NoLinkID;
                errorMessage = " 通道 ‘" + Name + "’ 请求失败：没有LinkID .";
                return false;
            }
 
            if (this.CheckLinkIDIsExisted(linkid))
            {
                requestError = RequestErrorType.RepeatLinkID;
                errorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID (缓存检查) .";
                return false;
            }

	        string mo = this.ChannelParams.GetRequsetValueByKey(httpRequestLog, DictionaryConst.Dictionary_SPField_MO_Key);
            string spnumber = this.ChannelParams.GetRequsetValueByKey(httpRequestLog, DictionaryConst.Dictionary_SPField_SpNumber_Key);
            string mobile = this.ChannelParams.GetRequsetValueByKey(httpRequestLog, DictionaryConst.Dictionary_SPField_Mobile_Key);

	        string province = "";
	        string city = "";

	        this.GetProvinceAndCity(mobile, ref province, ref city);

            SPCodeWrapper matchCode = GetMatchCodeFromRequest(httpRequestLog, province, city);

            if (matchCode == null)
            {
                requestError = RequestErrorType.NoChannelClientSetting;
                errorMessage = "请求失败：通道‘" + Name + "’请求未能找到匹配的代码设置。";
                return false;
            }

	        SPSClientWrapper client = matchCode.GetRelateClient();

            if (client == null)
            {
                requestError = RequestErrorType.NoChannelClientSetting;
                errorMessage = "请求失败：代码‘" + matchCode.Name + "’请求未能找到对应客户。";
                return false;
            }

            //string cpid = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "cpid", fieldMappings);
            //string mid = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "mid", fieldMappings);
            //string mobile = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "mobile", fieldMappings);
            //string port = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "port", fieldMappings);
            //string ywid = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "ywid", fieldMappings);
            //string msg = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "msg", fieldMappings);
            //string linkid = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "linkid", fieldMappings);
            //string dest = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "dest", fieldMappings);
            //string price = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "price", fieldMappings);
            //string extendfield1 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield1", fieldMappings);
            //string extendfield2 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield2", fieldMappings);
            //string extendfield3 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield3", fieldMappings);
            //string extendfield4 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield4", fieldMappings);
            //string extendfield5 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield5", fieldMappings);
            //string extendfield6 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield6", fieldMappings);
            //string extendfield7 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield7", fieldMappings);
            //string extendfield8 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield8", fieldMappings);
            //string extendfield9 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield9", fieldMappings);


            SPRecordWrapper record = new SPRecordWrapper();

            record.ChannelID = this;
            record.CodeID = matchCode;
	        record.ClientID = client;
            //paymentInfo.Cpid = cpid;
            //paymentInfo.Mid = mid;
            //paymentInfo.MobileNumber = mobile;
            //paymentInfo.Port = port;
            //paymentInfo.Ywid = ywid;
            //paymentInfo.Message = msg;
            //paymentInfo.Linkid = linkid;
            //paymentInfo.Dest = dest;
            //paymentInfo.Price = price;
            //paymentInfo.ExtendField1 = extendfield1;
            //paymentInfo.ExtendField2 = extendfield2;
            //paymentInfo.ExtendField3 = extendfield3;
            //paymentInfo.ExtendField4 = extendfield4;
            //paymentInfo.ExtendField5 = extendfield5;
            //paymentInfo.ExtendField6 = extendfield6;
            //paymentInfo.ExtendField7 = extendfield7;
            //paymentInfo.ExtendField8 = extendfield8;
            //paymentInfo.ExtendField9 = extendfield9;
            //paymentInfo.Ip = httpGetPostRequest.RequestIp;
            //paymentInfo.IsIntercept = channelSetting.CaculteIsIntercept();
            //paymentInfo.CreateDate = DateTime.Now;
            //paymentInfo.RequestContent = httpGetPostRequest.RequestData;

            //if (phoneAreaInfo != null)
            //{
            //    paymentInfo.Province = phoneAreaInfo.Province;
            //    paymentInfo.City = phoneAreaInfo.City;
            //}
	        record.IsSycnSuccessed = false;
	        record.IsIntercept = this.CaculteIsIntercept(matchCode, client);
            //record.IsSycnToClient = this.CaculteIsSycnToClient(matchCode, client, record);


 



 





 





 

            
 

            //try
            //{
            //    PaymentInfoInsertErrorType errorType = PaymentInfoInsertErrorType.NoError;



            //    bool result = paymentInfo.InsertPayment(out errorType);

            //    if (!result && errorType == PaymentInfoInsertErrorType.RepeatLinkID)
            //    {
            //        error.ErrorType = RequestErrorType.RepeatLinkID;
            //        error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID（查询排重 异常排重） .";
            //        error.ClientID = channelSetting.ClinetID.Id;
            //        //SPFailedRequestWrapper.SaveFailedRequest(request, ip, query, " 通道 ‘" + Name + "’ 请求失败：重复的LinkID .",
            //        //                                         Id, 0);

            //        return false;
            //    }

            //    error.ErrorType = RequestErrorType.NoError;
            //    error.ErrorMessage = "";
            //    try
            //    {
            //        LinkIDQueryCache.AddLinkIDs(linkid, this.Id);
            //    }
            //    catch (Exception ex)
            //    {
            //        Logger.Error(ex.Message);
            //    }

            //    if (sendTask != null)
            //    {
            //        sendTask.PaymentID = paymentInfo.Id;
            //        ThreadPool.QueueUserWorkItem(UrlSender.UrlSender.SendRequest, sendTask);
            //    }

            //    return true;
            //}
            //catch (Exception ex)
            //{
            //    error.ErrorType = RequestErrorType.DataSaveError;
            //    error.ErrorMessage = "请求失败：插入数据失败，错误信息：" + ex.Message;
            //    return false;
            //}


	        return false;
	    }

        private void CaculteIsSycnToClient(SPCodeWrapper matchCode, SPSClientWrapper client, SPRecordWrapper record)
	    {
            if (record.IsIntercept.Value)
            {
                record.IsSycnToClient = false;
                return;
            }


            record.IsSycnToClient = false;
            return;
	    }

	    private bool CaculteIsIntercept(SPCodeWrapper matchCode, SPSClientWrapper client)
	    {
	        return false;
	    }

	    private SPCodeWrapper GetMatchCodeFromRequest(HttpRequestLog httpRequestLog, string province, string city)
	    {
	        return null;
	    }

	    private void GetProvinceAndCity(string mobile, ref string province, ref string city)
	    {

//            PhoneAreaInfo phoneAreaInfo = null;

//#if DEBUG
//            if (!string.IsNullOrEmpty(mobile) && mobile.Length > 7)
//            {
//                try
//                {

//                    phoneAreaInfo = SPPhoneAreaWrapper.GetPhoneCity(mobile.Substring(0, 7));

//                }
//                catch (Exception ex)
//                {
//                    Logger.Error(ex.Message);
//                }
//            }
//#else
//            if (!string.IsNullOrEmpty(mobile) && mobile.Length > 7)
//            {
//                try
//                {
//                    try
//                    {
//                        phoneAreaInfo = PhoneCache.GetPhoneAreaByPhoneNumber(mobile);
//                    }
//                    catch (Exception)
//                    {
//                        phoneAreaInfo = SPPhoneAreaWrapper.GetPhoneCity(mobile.Substring(0, 7));
//                    }
//                }
//                catch (Exception ex)
//                {
//                    Logger.Error(ex.Message);
//                }
//            }
//#endif


	    }

	    private bool CheckLinkIDIsExisted(string linkid)
	    {
	        return false;
	    }

	    private const int linkIDMaxLength = 20;

	    private string GetLinkID(HttpRequestLog httpRequestLog)
	    {
	        if(this.IsAutoLinkID.HasValue && this.IsAutoLinkID.Value)
	        {
                if(string.IsNullOrEmpty(this.AutoLinkIDFields.Trim()))
                {
                    Guid newID = Guid.NewGuid();

                    return newID.GetHashCode().ToString("D" + (linkIDMaxLength-1).ToString()).Replace("-","1");
                }
                else
                {
                    string[] fields = this.AutoLinkIDFields.Split(',');

                    string totalIDString = "";

                    foreach (string field in fields)
                    {
                        totalIDString += httpRequestLog.RequestParams[field.ToLower()];
                    }

                    return totalIDString.GetHashCode().ToString("D" + (linkIDMaxLength-1).ToString()).Replace("-","1");
                }
	        }
	        else
	        {
	            return this.ChannelParams.GetRequsetValueByKey(httpRequestLog,
	                                                           DictionaryConst.Dictionary_SPField_LinkID_Key);
	        }
	    }

	    private SPChannelParamsCollection channelParams = null;

        public SPChannelParamsCollection ChannelParams
	    {
            get
            {
                if (channelParams == null)
                {
                    channelParams = new SPChannelParamsCollection(SPChannelParamsWrapper.FindAllByChannelID(this));
                }
                return channelParams;
            }
	    }



        //获取请求类型，当前状态报告还是数据报告
	    public RequestType GetRequestType(HttpRequestLog httpRequestLog)
	    {
            if(!(this.IsStateReport.HasValue && this.IsStateReport.Value))
            {
                return RequestType.DataReport;
            }
            if(this.StateReportType==DictionaryConst.Dictionary_ChannelStateReportType_SendOnce_Key)
            {
                return RequestType.DataStatusReport;
            }
            else if (this.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendTwice_Key) 
            {
                 if (httpRequestLog.RequestParams.ContainsKey(this.StateReportParamName.ToLower()))
                 {
                     return RequestType.StatusReport;
                 }
                 else
                 {
                     return RequestType.DataReport;
                 }
            }
            else if (this.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendTwiceTypeRequest_Key)
            {
                string requestType = httpRequestLog.RequestParams[this.RequestTypeParamName.ToLower()].ToString().ToLower();

                if (requestType.Equals(this.RequestTypeParamDataReportValue.ToLower()))
                {
                    return RequestType.DataReport; 
                }
                else if (requestType.Equals(this.RequestTypeParamStateReportValue.ToLower()))
                {
                    return RequestType.StatusReport;
                }
                else
                {
                    return RequestType.UnKnow;
                }
            }
            return RequestType.UnKnow;
	    }

        public bool ProcessStatusReport(HttpRequestLog httpRequestLog, out RequestErrorType requestError, out string errorMessage)
	    {

            requestError = RequestErrorType.NoError;
            errorMessage = "";
            return false;
	    }

        public bool ProcessDataStatusReport(HttpRequestLog httpRequestLog, out RequestErrorType requestError, out string errorMessage)
	    {

            requestError = RequestErrorType.NoError;
            errorMessage = "";
            return false;
	    }

        public string GetOkCode(HttpRequestLog httpRequestLog)
        {
            return this.DataOkMessage;
        }
    }
}
