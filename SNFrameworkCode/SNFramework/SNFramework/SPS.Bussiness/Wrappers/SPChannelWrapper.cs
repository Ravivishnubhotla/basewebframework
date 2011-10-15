
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
 
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Bussiness.Code;
using SPS.Bussiness.ConstClass;
using SPS.Bussiness.HttpUtils;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPChannelWrapper : BaseSpringNHibernateWrapper<SPChannelEntity, ISPChannelServiceProxy, SPChannelWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SPChannelWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPChannelWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPChannelWrapper obj)
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

        public static void Delete(SPChannelWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPChannelWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPChannelWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPChannelWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPChannelWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPChannelWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SPChannelWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
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

	        string mo = this.ChannelParams.MoFromRequset(httpRequestLog);
            string spcode = this.ChannelParams.SPCodeFromRequset(httpRequestLog);
            string mobile = this.ChannelParams.MobileFromRequset(httpRequestLog);

	        string province = "";
	        string city = "";

	        this.GetProvinceAndCity(mobile, ref province, ref city);

            SPCodeWrapper matchCode = this.GetMatchCodeFromRequest(httpRequestLog, mo, spcode, province, city);

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

            SPRecordWrapper record = new SPRecordWrapper();

            record.ChannelID = this;
            record.CodeID = matchCode;
	        record.ClientID = client;
	        record.Mo = mo;
	        record.Mobile = mobile;
	        record.LinkID = linkid;
	        record.SpNumber = spcode;
	        record.Province = province;
	        record.City = city;
            record.CreateDate = GetRecordTime(httpRequestLog);

	        record.IsReport = false;




	        record.IsIntercept = this.CaculteIsIntercept(matchCode, client);

            record.IsSycnSuccessed = false;

	        record.IsStatOK = (!IsStateReport);
	        record.SycnRetryTimes = 0;
	        record.Price = matchCode.Price;
	        record.Count = GetRecordCount(httpRequestLog);

            SPRecordExtendInfoWrapper spRecordExtendInfo = new SPRecordExtendInfoWrapper();

            spRecordExtendInfo.StartTime = this.ChannelParams.StartTimeFromRequset(httpRequestLog);
            spRecordExtendInfo.EndTime = this.ChannelParams.EndTimeFromRequset(httpRequestLog);
            spRecordExtendInfo.FeeTime = this.ChannelParams.FeeTimeFromRequset(httpRequestLog);
            spRecordExtendInfo.State = this.ChannelParams.StateFromRequset(httpRequestLog);
	        spRecordExtendInfo.Ip = httpRequestLog.RequestIp;
	        spRecordExtendInfo.RequestContent = httpRequestLog.RequestData;
            spRecordExtendInfo.ExtendField1 = this.ChannelParams.ExtendField1FromRequset(httpRequestLog);
            spRecordExtendInfo.ExtendField2 = this.ChannelParams.ExtendField2FromRequset(httpRequestLog);
            spRecordExtendInfo.ExtendField3 = this.ChannelParams.ExtendField3FromRequset(httpRequestLog);
            spRecordExtendInfo.ExtendField4 = this.ChannelParams.ExtendField4FromRequset(httpRequestLog);
            spRecordExtendInfo.ExtendField5 = this.ChannelParams.ExtendField5FromRequset(httpRequestLog);
            spRecordExtendInfo.ExtendField6 = this.ChannelParams.ExtendField6FromRequset(httpRequestLog);
            spRecordExtendInfo.ExtendField7 = this.ChannelParams.ExtendField7FromRequset(httpRequestLog);
            spRecordExtendInfo.ExtendField8 = this.ChannelParams.ExtendField8FromRequset(httpRequestLog);
            spRecordExtendInfo.ExtendField9 = this.ChannelParams.ExtendField9FromRequset(httpRequestLog);
            spRecordExtendInfo.ExtendField10 = this.ChannelParams.ExtendField10FromRequset(httpRequestLog);

            UrlSendTask sendTask = this.GenerateSendUrl(record, spRecordExtendInfo);


            try
            {

                bool result = InsertPayment(record, spRecordExtendInfo, out requestError, out errorMessage);

                if (!result && requestError == RequestErrorType.RepeatLinkID)
                {
                    requestError = RequestErrorType.RepeatLinkID;

                    errorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID（查询排重 异常排重） .";
 
                    return false;
                }

                requestError = RequestErrorType.NoError;
                errorMessage = "";
                try
                {
                    LinkIDQueryCache.AddLinkIDs(linkid, this.Id);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }

                if (sendTask != null)
                {
                    sendTask.PaymentID = record.Id;
                    ThreadPool.QueueUserWorkItem(SendRequest, sendTask);
                }

                return true;
            }
            catch (Exception ex)
            {
                requestError = RequestErrorType.DataSaveError;
                errorMessage = "请求失败：插入数据失败，错误信息：" + ex.Message;
                return false;
            }


	        return false;
	    }

	    private UrlSendTask GenerateSendUrl(SPRecordWrapper record, SPRecordExtendInfoWrapper spRecordExtendInfo)
	    {
	        return null;
	    }

	    private bool InsertPayment(SPRecordWrapper record, SPRecordExtendInfoWrapper spRecordExtendInfo, out RequestErrorType requestError, out string errorMessage)
	    {
            return businessProxy.InsertPayment(record.Entity, spRecordExtendInfo.Entity, out requestError, out errorMessage);
	    }

	    private int GetRecordCount(HttpRequestLog httpRequestLog)
	    {
            if(this.ChannelType == DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
            {
                if (this.ChannelParams.FeeTimeFromRequset(httpRequestLog) != null)
                {
                    return Convert.ToInt32(this.ChannelParams.FeeTimeFromRequset(httpRequestLog));
                }

                DateTime startTime = ParseTime(this.ChannelParams.StartTimeFromRequset(httpRequestLog));
                DateTime endTime = ParseTime(this.ChannelParams.EndTimeFromRequset(httpRequestLog));

                return Convert.ToInt32((endTime - startTime).TotalMinutes);
            }
	        return 1;
	    }

	    private DateTime ParseTime(string feeTime)
	    {
	        if(!string.IsNullOrEmpty(this.IVRTimeFormat))
	        {
	            return Convert.ToDateTime(feeTime);
	        }
	        else
	        {
                DateTimeFormatInfo   dtfi = new CultureInfo("zh-CN", false).DateTimeFormat;
                DateTime output;
                DateTime.TryParseExact(feeTime, this.IVRTimeFormat, dtfi, DateTimeStyles.None, out output);

	            return output;
	        }
	    }

	    private DateTime GetRecordTime(HttpRequestLog httpRequestLog)
	    {
            //if (this.ChannelParams.HasKey(DictionaryConst.Dictionary_SPField_CreateDate_Key)&&this.ca)
	        return DateTime.Now;
	    }

	    private void CaculteIsSycnToClient(SPCodeWrapper matchCode, SPSClientWrapper client, SPRecordWrapper record)
	    {
            if (record.IsIntercept)
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

        private SPCodeWrapper GetMatchCodeFromRequest(HttpRequestLog httpRequestLog, string mo, string spcode, string province, string city)
        {
            return Codes.Find(p => p.CheckIsMatchCode(mo, spcode));
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
            return LinkIDQueryCache.CheckLinkIDAndChannelIDIsExisted(linkid,this.Id);
	    }

	    private const int linkIDMaxLength = 20;

	    private string GetLinkID(HttpRequestLog httpRequestLog)
	    {
	        if(this.IsAutoLinkID)
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
	            return this.ChannelParams.LinkIDFromRequset(httpRequestLog);
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

        private List<SPCodeWrapper> codes = null;

        public List<SPCodeWrapper> Codes
        {
            get
            {
                if (codes == null)
                {
                    codes = SPCodeWrapper.FindAllByChannelID(this).FindAll(p=>(!p.IsDiable));
                }
                return codes;
            }
        }



        //获取请求类型，当前状态报告还是数据报告
	    public RequestType GetRequestType(HttpRequestLog httpRequestLog)
	    {
            if(!(this.IsStateReport))
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

        public static void SendRequest(object request)
        {
            UrlSendTask sendTask = request as UrlSendTask;

            if (sendTask == null)
                throw new AbandonedMutexException(" sendTask is null ");


            try
            {
                bool requestOk = false;

                string errorMessage = string.Empty;

                requestOk = SendRequest(sendTask.SendUrl, 3000, sendTask.OkMessage, out errorMessage);

                if (requestOk)
                {
                    UpdatePaymentSendSuccessAndUrl(sendTask.SendUrl, sendTask.PaymentID);
                }
                else
                {
                    Console.WriteLine(errorMessage);
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void UpdatePaymentSendSuccessAndUrl(string url, int paymentID)
        {
            return; 
            //SPPaymentInfoWrapper.UpdateUrlSuccessSend(paymentID, url);
        }

        private static bool SendRequest(string requesturl, int timeOut, string okMessage, out string errorMessage)
        {
            try
            {
                errorMessage = "";

                HttpWebRequest webRequest = (HttpWebRequest)HttpWebRequest.Create(requesturl);

                webRequest.Timeout = timeOut;

                HttpWebResponse webResponse = null;

                webResponse = (HttpWebResponse)webRequest.GetResponse();


                if (webResponse.StatusCode == HttpStatusCode.OK)
                {
                    StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Default);

                    string responseText = sr.ReadToEnd();

                    bool result = responseText.Trim().ToLower().Equals(okMessage);

                    if (!result)
                    {
                        errorMessage = responseText;
                    }

                    return result;
                }

                errorMessage = "web error Status:" + webResponse.StatusCode.ToString();

                return false;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
        }
    }
}
