
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Newtonsoft.Json;
using SPS.Bussiness.Code;
using SPS.Bussiness.ConstClass;
using SPS.Bussiness.DataAdapter;
using SPS.Bussiness.HttpUtils;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Bussiness.SystemConst;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    [DataContract]
    [JsonObject(MemberSerialization.OptIn)]
    public partial class SPChannelWrapper : BaseSpringNHibernateWrapper<SPChannelEntity, ISPChannelServiceProxy, SPChannelWrapper, int>  
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

        public static void DeleteByID(int id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(int[] ids)
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

        public static SPChannelWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPChannelWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPChannelWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SPChannelWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams,businessProxy));
        }


        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams,businessProxy));
        }


        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));
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

        public string GetFailedCode(IDataAdapter httpRequestLog)
	    {
	        return this.DataFailedMessage;
	    }

        public bool CheckRequestIsFilters(IDataAdapter httpRequestLog)
	    {
	        return false;
	    }

        public void ParamsConvert(IDataAdapter httpRequestLog)
	    {
	        return;
	    }

        public void InitParams(IDataAdapter httpRequestLog)
	    {
            return;
	    }

	    public const string ChannelType_SPS = "SPSCS";
        public const string ChannelType_IVRCS = "IVRCS";
        public const string ChannelType_CustomCS = "CustomCS";

        public string ChannelTypeString
	    {
            get
            {
                if (this.ChannelType == DictionaryConst.Dictionary_ChannelType_SPChannel_Key)
                    return ChannelType_SPS;
                else if (this.ChannelType == DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
                    return ChannelType_IVRCS;
                else
                    return ChannelType_CustomCS;
            }
	    }

        public string ChannelTypeName
	    {
            get
            {
                return DictionaryConst.ParseChannelTypeDictionaryKey(this.ChannelType);
            }
	    }
        
	    public string InterfaceUrl
        {
            get
            {
                HttpContext context = HttpContext.Current;

                if (context == null)
                    return "";

                if (context.Request.Url.Port == 80)
                    return string.Format("{0}://{1}/{4}/{2}{4}{3}", context.Request.Url.Scheme,
                                         context.Request.Url.Host, this.Code, this.DataAdapterUrl, this.ChannelTypeString);

                return string.Format("{0}://{1}:{2}/{5}/{3}{5}{4}", context.Request.Url.Scheme,
                                     context.Request.Url.Host,
                                     context.Request.Url.Port, this.Code, this.DataAdapterUrl, this.ChannelTypeString);
            }
        }

        public bool ProcessRequest(IDataAdapter httpRequestLog, bool statusOk, out RequestErrorType requestError, out string errorMessage)
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

            if (this.ChannelType == DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
            {
                mo = "ivr";
            }

            string spcode = this.ChannelParams.SPCodeFromRequset(httpRequestLog);
            string mobile = this.ChannelParams.MobileFromRequset(httpRequestLog);

	        string province = "";
	        string city = "";
            string mobileOperator    = "";        

            PhoneAreaInfo phoneArea = this.GetProvinceAndCity(mobile);

            if(phoneArea!=null)
            {
                if (!string.IsNullOrEmpty(phoneArea.Province))
                    province = phoneArea.Province;
                else
                    province = "";
                if (!string.IsNullOrEmpty(phoneArea.City))
                    city = phoneArea.City;
                else
                    city = "";
                if (!string.IsNullOrEmpty(phoneArea.MobileOperators))
                    mobileOperator = phoneArea.MobileOperators;
                else
                    mobileOperator = "";
            }

            SPCodeWrapper matchCode = null;

            if(this.ChannelType==DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
            {
                matchCode = this.GetMatchCodeFromIVRRequest(httpRequestLog, spcode, province, city);
            }
            else
            {
                matchCode = this.GetMatchCodeFromRequest(httpRequestLog, mo, spcode, province, city);        
            }


            if (matchCode == null)
            {
                requestError = RequestErrorType.NoChannelClientSetting;
                errorMessage = "请求失败：通道‘" + Name + "’请求未能找到匹配的代码设置。";
                return false;
            }

            SPClientCodeRelationWrapper clientCodeRelation = matchCode.GetRelateClientCodeRelation();
 
            //如果存在指令，但是不存在对应的分配关系，转到默认匹配
            if (clientCodeRelation == null)
            {
                clientCodeRelation = this.GetDefaultClientCodeRelation();

                matchCode = clientCodeRelation.CodeID;
            }

            SPRecordWrapper record = new SPRecordWrapper();

            record.ChannelID = this;
            record.CodeID = matchCode;
            record.ClientID = clientCodeRelation.ClientID;
	        record.ClientCodeRelationID = clientCodeRelation;
	        record.Mo = mo;
	        record.Mobile = mobile;
	        record.LinkID = linkid;
	        record.SpNumber = spcode;
	        record.Province = province;
	        record.City = city;
	        record.OperatorType = mobileOperator;
            record.CreateDate = GetRecordTime(httpRequestLog);

	        record.IsReport = false;


            record.IsStatOK = statusOk;

            record.IsIntercept = this.CaculteIsIntercept(matchCode, clientCodeRelation);

            if (record.IsIntercept)
            {
                record.IsSycnToClient = false;
                record.IsSycnSuccessed = false;
                record.SycnRetryTimes = 0;
            }
            else
            {
                if(!clientCodeRelation.SyncData)
                {
                    record.IsSycnToClient = false;
                    record.IsSycnSuccessed = false;
                    record.SycnRetryTimes = 0;
                }
                else
                {
                    record.IsSycnToClient = true;
                    record.IsSycnSuccessed = false;
                    record.SycnRetryTimes = 0;      
                }
            }
 
            record.Price = clientCodeRelation.Price;
 

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
 
            try
            {

                bool result = SPRecordWrapper.InsertPayment(record, spRecordExtendInfo, out requestError, out errorMessage);

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

                record.SycnToClient();

                return true;
            }
            catch (Exception ex)
            {
                requestError = RequestErrorType.DataSaveError;
                errorMessage = "请求失败：插入数据失败，错误信息：" + ex.Message;
                return false;
            }
	    }

	    public SPCodeWrapper GetMatchCodeFromIVRRequest(IDataAdapter httpRequestLog, string spcode, string province, string city)
	    {
            var findCode = (from cc in Codes
                            where (cc.CheckIsMatchCode("IVR",spcode,province,city) && (cc.MOType != DictionaryConst.Dictionary_CodeType_CodeDefault_Key))
                            orderby cc.Priority ascending, cc.Mo.Length descending
                            select cc).FirstOrDefault();

            if (findCode != null)
                return findCode;

            var defaultCode = Codes.Find(p => p.MOType == DictionaryConst.Dictionary_CodeType_CodeDefault_Key);

            return defaultCode;
	    }

	    public SPClientCodeRelationWrapper GetDefaultClientCodeRelation()
	    {
	        var defaultCode = Codes.Find(p => p.MOType == DictionaryConst.Dictionary_CodeType_CodeDefault_Key);

	        return defaultCode.GetRelateClientCodeRelation();
	    }

	    public List<SPChannelSycnParamsWrapper> GetAllSycnParams()
	    {
	        return SPChannelSycnParamsWrapper.FindAllByChannelID(this);
	    }



        private int GetRecordCount(IDataAdapter httpRequestLog)
	    {
            //if(this.ChannelType == DictionaryConst.Dictionary_ChannelType_IVRChannel_Key)
            //{
            //    if (this.ChannelParams.FeeTimeFromRequset(httpRequestLog) != null)
            //    {
            //        return Convert.ToInt32(this.ChannelParams.FeeTimeFromRequset(httpRequestLog));
            //    }

            //    DateTime startTime = ParseTime(this.ChannelParams.StartTimeFromRequset(httpRequestLog));
            //    DateTime endTime = ParseTime(this.ChannelParams.EndTimeFromRequset(httpRequestLog));

            //    return Convert.ToInt32((endTime - startTime).TotalMinutes);
            //}
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

        private DateTime GetRecordTime(IDataAdapter httpRequestLog)
	    {
            //if (this.ChannelParams.HasKey(DictionaryConst.Dictionary_SPField_CreateDate_Key)&&this.ca)
	        return DateTime.Now;
	    }

        private bool CaculteRandom(int rate)
        {
            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            int result = random.Next(0, 100);

            return (result <= rate);
        }

        private bool CaculteIsIntercept(SPCodeWrapper matchCode, SPClientCodeRelationWrapper clientCodeRelation)
	    {
            if(clientCodeRelation==null)
                return false;

            int addRate = 50;

            int maxInterceptRate = 80;

            if(clientCodeRelation.SycnNotInterceptCount>0)
            {
                clientCodeRelation.SycnNotInterceptCount = clientCodeRelation.SycnNotInterceptCount - 1;

                SPClientCodeRelationWrapper.Update(clientCodeRelation);

                return false;
            }

            int interceptRate = 0;
 
            interceptRate = Convert.ToInt32(clientCodeRelation.InterceptRate);

            //return CaculteRandom(interceptRate);

            if (interceptRate == 0)
                return false;

            decimal rate = SPRecordWrapper.CaculteActualInterceptRate(clientCodeRelation,System.DateTime.Now.Date);

            if (rate < Convert.ToDecimal(interceptRate))
            {
                return CaculteRandom(Math.Min(interceptRate + addRate, maxInterceptRate));
            }
            else
            {
                return false;
            }
	    }

        public SPCodeWrapper GetMatchCodeFromRequest(IDataAdapter httpRequestLog, string mo, string spcode, string province, string city)
        {
            var findCode = (from cc in Codes
                            where (cc.CheckIsMatchSPCode(spcode) && cc.CheckIsMatchCode(mo, spcode, province, city) && (cc.MOType != DictionaryConst.Dictionary_CodeType_CodeDefault_Key))
                            orderby cc.Priority ascending , cc.Mo.Length descending 
                                 select cc).FirstOrDefault();

            if (findCode != null)
                return findCode;

            var defaultCode = Codes.Find(p => p.MOType == DictionaryConst.Dictionary_CodeType_CodeDefault_Key);

            return defaultCode;
        }

        private PhoneAreaInfo GetProvinceAndCity(string mobile)
	    {

            PhoneAreaInfo phoneAreaInfo = null;

//#if DEBUG
            if (!string.IsNullOrEmpty(mobile) && mobile.Length > 7)
            {
                try
                {
                    SystemPhoneAreaWrapper phoneArea = SystemPhoneAreaWrapper.GetPhoneAreaByMobilePrefix(mobile.Substring(0, 7));

                    if (phoneArea == null)
                        return null;

                    phoneAreaInfo = new PhoneAreaInfo();
                    phoneAreaInfo.MobileOperators = phoneArea.OperatorType;
                    phoneAreaInfo.Province = phoneArea.Province;
                    phoneArea.City = phoneArea.City;

                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }

            return phoneAreaInfo;
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
            //return LinkIDQueryCache.CheckLinkIDAndChannelIDIsExisted(linkid,this.Id);
	    }

	    private const int linkIDMaxLength = 20;

        public string GetLinkID(IDataAdapter httpRequestLog)
	    {
	        if(this.IsAutoLinkID)
	        {
                if(string.IsNullOrEmpty(this.AutoLinkIDFields.Trim()))
                {
                    Guid newID = Guid.NewGuid();

                    return newID.GetHashCode().ToString("D" + (linkIDMaxLength-1).ToString()).Replace("-","1");
                }

                string[] fields = this.AutoLinkIDFields.Split(',');

                string totalIDString = "";

                foreach (string field in fields)
                {
                    totalIDString += httpRequestLog.RequestParams[field.ToLower()];
                }

                return totalIDString;//.GetHashCode().ToString("D" + (linkIDMaxLength-1).ToString()).Replace("-","1");

	        }

	        return this.ChannelParams.LinkIDFromRequset(httpRequestLog);
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

	    public string StatusReportType
	    {
	        get
	        {
	            if(!this.IsStateReport)
	            {
	                return "只同步成功";
	            }

                if (this.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendOnce_Key)
                {
                    return "单次请求";
                }
                else if (this.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendTwice_Key)
                {
                    return "双次请求";
                }
                else if (this.StateReportType == DictionaryConst.Dictionary_ChannelStateReportType_SendTwiceTypeRequest_Key)
                {
                    return "双次请求(分类型)";
                }
                
	            return "未知类型";
	        }
	    }

	    //获取请求类型，当前状态报告还是数据报告
        public RequestType GetRequestType(IDataAdapter httpRequestLog)
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

                 return RequestType.DataReport;

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

                return RequestType.UnKnow;
            }
            return RequestType.UnKnow;
	    }

        public bool ProcessStatusReport(IDataAdapter httpRequestLog, bool statusOk, out RequestErrorType requestError, out string errorMessage)
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

            if(!statusOk)
            {
                return true;
            }

            SPRecordWrapper record = SPRecordWrapper.FindByChannelIDAndLinkID(linkid, this);

            if (!record.IsStatOK)
            {
                record.IsStatOK = statusOk;

                SPRecordWrapper.Update(record);

                record.SycnToClient();

                return true;
            }

            return false;

	    }



        public string GetOkCode(IDataAdapter httpRequestLog)
        {
            return this.DataOkMessage;
        }



        public bool GetStatus(IDataAdapter httpRequestLog)
        {
            return (httpRequestLog.RequestParams[this.StateReportParamName.ToLower()].ToString().ToLower().Equals(this.StateReportParamValue.ToLower()));
        }

        public void UpdateChannelDetailInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("通道参数列表:<br/>");

            sb.AppendLine(ParamsList + "<br/>");


            sb.AppendLine("通道指令列表:<br/>");

            sb.AppendLine(CodeList + "<br/>");

            this.ChannelDetailInfo = sb.ToString();

            Update(this);
        }


        public string CodeList
        {
            get
            {
                StringBuilder sb = new StringBuilder();

                List<SPCodeWrapper> sortedList = (from cc in Codes
                                                                  orderby cc.OrderIndex descending
                                                                  select cc).ToList();

                foreach (SPCodeWrapper code in sortedList)
                {
                    if(code.MOType==DictionaryConst.Dictionary_CodeType_CodeDefault_Key)
                        continue;
                    sb.AppendLine(code.MoCode);
                    sb.Append("&nbsp;&nbsp;分配状态：" + code.AssignedClientName + "<br/>");
                }

                return sb.ToString();
            }
        }

        public string ParamsList
        {
            get
            {
                SPChannelParamsCollection clientChannelParams = this.ChannelParams;

                var sb = new StringBuilder();

                foreach (SPChannelParamsWrapper paramsWrapper in clientChannelParams.Items)
                {
                    sb.AppendFormat("参数 {0} - {2}：{1} <br/>", paramsWrapper.Name, paramsWrapper.Description,
                                    paramsWrapper.ParamsMappingName);
                }

                return sb.ToString();
            }
        }

	    public int GetFeetime(IDataAdapter httpRequestLog)
	    {
            if (this.IVRFeeTimeType == null || this.IVRFeeTimeType =="0")
	            return Convert.ToInt32(this.ChannelParams.FeeTimeFromRequset(httpRequestLog));

            DateTimeFormatInfo dtfi = new CultureInfo("zh-CN", false).DateTimeFormat;
            DateTime startTime = DateTime.MinValue;
            DateTime.TryParseExact(this.ChannelParams.StartTimeFromRequset(httpRequestLog), this.IVRTimeFormat, dtfi, DateTimeStyles.None, out startTime);

            if(startTime==DateTime.MinValue)
                throw new ArgumentNullException("startTime");

            DateTime endTime = DateTime.MinValue;
            DateTime.TryParseExact(this.ChannelParams.EndTimeFromRequset(httpRequestLog), this.IVRTimeFormat, dtfi, DateTimeStyles.None, out startTime);

            if (endTime == DateTime.MinValue)
                throw new ArgumentNullException("endTime");

            return Convert.ToInt32(Math.Ceiling(Convert.ToDouble((endTime - startTime).TotalSeconds) / 60));

	    }
    }
}
