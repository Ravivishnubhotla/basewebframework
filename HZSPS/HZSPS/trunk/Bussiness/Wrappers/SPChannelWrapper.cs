using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using LD.SPPipeManage.Bussiness.Commons;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;
using LD.SPPipeManage.Bussiness.UrlSender;
using LD.SPPipeManage.Entity.Tables;
using Legendigital.Framework.Common.Bussiness.NHibernate;

namespace LD.SPPipeManage.Bussiness.Wrappers
{
    public enum RequestErrorType
    {
        NoError,
        NoLinkID,
        RepeatLinkID,
        NoChannelClientSetting,
        DataSaveError,
        NoReportData
    }

    public class RequestError
    {
        public RequestErrorType ErrorType { get; set; }
        public string ErrorMessage { get; set; }
        public int ChannelID { get; set; }
        public int ClientID { get; set; }
    }


    [Serializable]
    public partial class SPChannelWrapper
    {
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

        public static List<SPChannelWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPChannelEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }

        public static List<SPChannelWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex,
                                                              int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters,
                                                                       string orderByColumnName, bool isDesc,
                                                                       int pageIndex, int pageSize, out int recordCount)
        {
            List<SPChannelWrapper> results = null;

            results = ConvertToWrapperList(
                businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                        (pageIndex - 1)*pageSize, pageSize, out recordCount));

            return results;
        }


        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters,
                                                                       string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }

        #endregion

        public static string[] fields = new[]
                                            {
                                                "cpid", "mid", "mobile", "port", "ywid", "msg", "linkid", "dest", "price",
                                                "extendfield1", "extendfield2", "extendfield3", "extendfield4",
                                                "extendfield5", "extendfield6", "extendfield7", "extendfield8",
                                                "extendfield9"
                                            };

        public ChannelStatus CStatus
        {
            get
            {
                switch (Status)
                {
                    case 0:
                        return ChannelStatus.Run;
                    case 1:
                        return ChannelStatus.Stop;
                    case 2:
                        return ChannelStatus.Disable;
                    default:
                        return ChannelStatus.Disable;
                }
            }
        }



 

        public string UperName
        {
            get
            {
                if (this.UperID == null)
                    return "";
                return this.UperID.Name;
            }
        }

        public string CStatusString
        {
            get
            {
                switch (CStatus)
                {
                    case ChannelStatus.Run:
                        return "运行";
                    case ChannelStatus.Stop:
                        return "暂停";
                    case ChannelStatus.Disable:
                        return "禁用";
                    default:
                        return "禁用";
                }
            }
        }

        public bool DataSendOnce
        {
            get
            {
                if (!(this.RecStatReport.HasValue && this.RecStatReport.Value))
                    return true;
                if (this.StatSendOnce.HasValue && this.StatSendOnce.Value)
                    return true;
                return false;
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
                    return string.Format("{0}://{1}/SPSInterface/{2}Recieved.ashx", context.Request.Url.Scheme,
                                         context.Request.Url.Host, FuzzyCommand);

                return string.Format("{0}://{1}:{2}/SPSInterface/{3}Recieved.ashx", context.Request.Url.Scheme,
                                     context.Request.Url.Host,
                                     context.Request.Url.Port, FuzzyCommand);
            }
        }

        public string RequestReportTypeValue
        {
            get
            {
                if (string.IsNullOrEmpty(this.RequestTypeValues))
                    return "";

                string[] values = this.RequestTypeValues.Split('|');

                if(values.Length>0)
                    return values[0];

                return "";
            }
        }

        public string RequestDataTypeValue
        {
            get
            {
                if (string.IsNullOrEmpty(this.RequestTypeValues))
                    return "";

                string[] values = this.RequestTypeValues.Split('|');

                if (values.Length > 1)
                    return values[1];

                return "";
            }
        }

        public string CodeList
        {
            get
            {
                List<SPClientChannelSettingWrapper> clientChannelSettings = GetAllClientChannelSetting();

                var sb = new StringBuilder();

                List<SPClientChannelSettingWrapper> sortedList = (from cc in clientChannelSettings
                                                                  orderby cc.OrderIndex descending
                                                                  select cc).ToList();

                foreach (SPClientChannelSettingWrapper channelSetting in sortedList)
                {
                    string interceptRate = "<font color='red'>0</font>";

                    string syncDataUrl = "";

                    if (!string.IsNullOrEmpty(channelSetting.SyncDataUrl))
                    {
                        syncDataUrl = " ,<font color='blue'>下家同步地址：" + channelSetting.SyncDataUrl + "</font>";
                    }

                    if (channelSetting.InterceptRate.HasValue && channelSetting.InterceptRate.Value > 0)
                    {
                        interceptRate = channelSetting.InterceptRate.Value.ToString();
                    }

                    string line = string.Format(
                        "名称 ‘{0}’ , 下家 ‘{2}’, 登陆ID ‘{6}’, 指令 '{7}' , 指令规则 '{1}', 扣率  {3},优先级  {5}, {4}<br/>", channelSetting.Name,
                        channelSetting.ChannelClientRuleMatch, channelSetting.ClientName,
                        interceptRate, syncDataUrl, channelSetting.OrderIndex, channelSetting.ClinetID.UserLoginID, channelSetting.ChannelClientCode);


                    sb.Append(line);
                }

                return sb.ToString();
            }
        }

        public string ParamsList
        {
            get
            {
                List<SPChannelParamsWrapper> clientChannelParams = GetAllEnableParams();

                var sb = new StringBuilder();

                foreach (SPChannelParamsWrapper paramsWrapper in clientChannelParams)
                {
                    sb.AppendFormat("参数 {0} - {2}：{1} ,<br/>", paramsWrapper.Name, paramsWrapper.Description,
                                    paramsWrapper.ParamsMappingName);
                }

                return sb.ToString();
            }
        }

        public static SPChannelWrapper GetChannelByPath(string fileName)
        {
            int id = 0;

            int.TryParse(fileName, out id);

            SPChannelWrapper channel = null;

            if (id != 0)
            {
                channel = FindById(id);
            }

            if (channel != null)
            {
                return channel;
            }

            return ConvertEntityToWrapper(businessProxy.FindByAlias(fileName));
        }

        public static SPChannelWrapper FindByAlias(string alias)
        {
            return ConvertEntityToWrapper(businessProxy.FindByAlias(alias));
        }

        public static Hashtable GetRequestValue(HttpContext requestContext)
        {
            Hashtable hb = new Hashtable();

            foreach (string key in requestContext.Request.Params.Keys)
            {
                hb.Add(key.ToLower(), requestContext.Request.Params[key.ToLower()]);
            }

            return hb;
        }

        public string GetRequsetValue(HttpContext requestContext, string fieldName)
        {
            return GetMappedParamValueFromRequest(GetRequestValue(requestContext), fieldName, GetFieldMappings());
        }

        public bool ProcessRequest(IHttpRequest httpGetPostRequest,
                           out RequestError error)
        {
            error = new RequestError();
            error.ErrorType = RequestErrorType.NoError;
            error.ErrorMessage = "";
            error.ChannelID = Id;

            Hashtable fieldMappings = GetFieldMappings();

            string cpid = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "cpid", fieldMappings);
            string mid = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "mid", fieldMappings);
            string mobile = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "mobile", fieldMappings);
            string port = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "port", fieldMappings);
            string ywid = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "ywid", fieldMappings);
            string msg = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "msg", fieldMappings);
            string linkid = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "linkid", fieldMappings);
            string dest = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "dest", fieldMappings);
            string price = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "price", fieldMappings);
            string extendfield1 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield1", fieldMappings);
            string extendfield2 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield2", fieldMappings);
            string extendfield3 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield3", fieldMappings);
            string extendfield4 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield4", fieldMappings);
            string extendfield5 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield5", fieldMappings);
            string extendfield6 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield6", fieldMappings);
            string extendfield7 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield7", fieldMappings);
            string extendfield8 = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "extendfield8", fieldMappings);



            if (string.IsNullOrEmpty(linkid) && IsAllowNullLinkID.HasValue && IsAllowNullLinkID.Value)
            {
                linkid = Guid.NewGuid().ToString();
            }

            try
            {
                if (string.IsNullOrEmpty(linkid))
                {
                    error.ErrorType = RequestErrorType.NoLinkID;
                    error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：没有LinkID .";

                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }

            if(LinkIDQueryCache.CheckLinkIDIsExisted(linkid,this.Id))
            {
                error.ErrorType = RequestErrorType.RepeatLinkID;
                error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID (缓存检查) .";
                return false;
            }

            Hashtable exparams = GetEXParamsValue(httpGetPostRequest.RequestParams);

            PhoneAreaInfo phoneAreaInfo = null;

#if DEBUG 
            if (!string.IsNullOrEmpty(mobile) && mobile.Length > 7)
            {
                try
                {
 
                        phoneAreaInfo = SPPhoneAreaWrapper.GetPhoneCity(mobile.Substring(0, 7));
 
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
#else
            if (!string.IsNullOrEmpty(mobile) && mobile.Length > 7)
            {
                try
                {
                    try
                    {
                        phoneAreaInfo = PhoneCache.GetPhoneAreaByPhoneNumber(mobile);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("号段读取错误：" + ex.Message);
                        phoneAreaInfo = SPPhoneAreaWrapper.GetPhoneCity(mobile.Substring(0, 7));
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error("号段读取错误：" + ex.Message);
                }
            }
            //else
            //{
            //    if (string.IsNullOrEmpty(mobile))
            //    {
            //        Logger.Error("空号错误");
            //    }
            //    else
            //    {
            //        Logger.Error("号码错误：" + mobile);               
            //    }
            //}
#endif




            SPClientChannelSettingWrapper channelSetting = GetClientChannelSettingFromRequestValue(httpGetPostRequest.RequestParams,
                                                                                                   fieldMappings,phoneAreaInfo);

            if (channelSetting == null || !channelSetting.IsEnable)
            {
                List<SPClientChannelSettingWrapper> clientChannelSettings = GetAllClientChannelSetting();

                channelSetting = clientChannelSettings.Find(p => (p.CommandType == "7" && p.Name.Contains("默认下家")));
            }


            SPPaymentInfoWrapper paymentInfo = new SPPaymentInfoWrapper();

            paymentInfo.ChannelID = this;
            paymentInfo.ClientID = channelSetting.ClinetID;
            paymentInfo.ChannleClientID = channelSetting.Id;
            paymentInfo.Cpid = cpid;
            paymentInfo.Mid = mid;
            paymentInfo.MobileNumber = mobile;
            paymentInfo.Port = port;
            paymentInfo.Ywid = ywid;
            paymentInfo.Message = msg;
            paymentInfo.Linkid = linkid;
            paymentInfo.Dest = dest;
            paymentInfo.Price = price;
            paymentInfo.ExtendField1 = extendfield1;
            paymentInfo.ExtendField2 = extendfield2;
            paymentInfo.ExtendField3 = extendfield3;
            paymentInfo.ExtendField4 = extendfield4;
            paymentInfo.ExtendField5 = extendfield5;
            paymentInfo.ExtendField6 = extendfield6;
            paymentInfo.ExtendField7 = extendfield7;
            paymentInfo.ExtendField8 = extendfield8;

            try
            {
                if (channelSetting.ClinetID != null && channelSetting.ClinetID.SPClientGroupID != null)
                {
                    paymentInfo.ClientGroupID = channelSetting.ClinetID.SPClientGroupID.Id;
                }
            }
            catch (Exception ex)
            {
                logger.Error("ClientGroup ID Error", ex);
            }


            paymentInfo.Ip = httpGetPostRequest.RequestIp;
            paymentInfo.CreateDate = DateTime.Now;
            paymentInfo.RequestContent = httpGetPostRequest.RequestData;

            if (phoneAreaInfo != null)
            {
                paymentInfo.Province = phoneAreaInfo.Province;
                paymentInfo.City = phoneAreaInfo.City;
                paymentInfo.MobileOperators = phoneAreaInfo.MobileOperators;
            }

            paymentInfo.IsIntercept = channelSetting.CaculteIsIntercept(paymentInfo);




            paymentInfo.IsSycnData = false;

            UrlSendTask sendTask = null;

            if (!paymentInfo.IsIntercept.Value)
            {
                if (!string.IsNullOrEmpty(channelSetting.SyncDataUrl))
                {
                    paymentInfo.IsSycnData = true;
                    //if (!string.IsNullOrEmpty(channelSetting.SyncType) && channelSetting.SyncType.Equals("2"))
                    //{
                    //    paymentInfo.SucesssToSend = false;
                    //}
                    //else
                    //{
                    paymentInfo.SucesssToSend = false;

                    sendTask = new UrlSendTask();

                    sendTask.SendUrl = channelSetting.BulidUrl(paymentInfo);
                    sendTask.OkMessage = channelSetting.OkMessage;
                    //}
                }
                else
                {
                    paymentInfo.IsSycnData = false;
                    paymentInfo.SucesssToSend = false;
                }

            }
            else
            {
                paymentInfo.IsSycnData = false;
                paymentInfo.SucesssToSend = false;
            }

            try
            {
                PaymentInfoInsertErrorType errorType = PaymentInfoInsertErrorType.NoError;

 

                bool result = paymentInfo.InsertPayment(out errorType);

                if (!result && errorType == PaymentInfoInsertErrorType.RepeatLinkID)
                {
                    error.ErrorType = RequestErrorType.RepeatLinkID;
                    error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID（查询排重 异常排重） .";
                    error.ClientID = channelSetting.ClinetID.Id;
                    //SPFailedRequestWrapper.SaveFailedRequest(request, ip, query, " 通道 ‘" + Name + "’ 请求失败：重复的LinkID .",
                    //                                         Id, 0);

                    return false;
                }

                error.ErrorType = RequestErrorType.NoError;
                error.ErrorMessage = "";
                try
                {
                    LinkIDQueryCache.AddLinkIDs(linkid, this.Id);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }

                if (sendTask!=null)
                {
                    sendTask.PaymentID = paymentInfo.Id;
                    ThreadPool.QueueUserWorkItem(UrlSender.UrlSender.SendRequest, sendTask);
                }

                return true;
            }
            catch (Exception ex)
            {
                error.ErrorType = RequestErrorType.DataSaveError;
                error.ErrorMessage = "请求失败：插入数据失败，错误信息：" + ex.Message;
                return false;
            }
        }


        public List<SPChannelParamsWrapper> GetAllShowParams()
        {
            return SPChannelParamsWrapper.ConvertToWrapperList(businessProxy.GetAllShowParams(entity));
        }

        public List<SPChannelParamsWrapper> GetAllEnableParams()
        {
            return SPChannelParamsWrapper.ConvertToWrapperList(businessProxy.GetAllEnableParams(entity));
        }

        public Hashtable GetFieldMappings()
        {
            var mappingFields = new Hashtable();

            List<SPChannelParamsWrapper> spChannelParamsWrappers =
                SPChannelParamsWrapper.ConvertToWrapperList(businessProxy.GetAllEnableParams(entity));

            foreach (string field in fields)
            {
                string findFeild = field.ToLower();

                SPChannelParamsWrapper channelParamsWrapper =
                    spChannelParamsWrappers.Find(p => (p.ParamsMappingName.Equals(findFeild.ToLower())));

                if (channelParamsWrapper == null)
                {
                    //mappingFields.Add(findFeild.ToLower(), findFeild.ToLower());
                }
                else
                {
                    mappingFields.Add(findFeild.ToLower(), channelParamsWrapper.Name.ToLower());
                }
            }

            return mappingFields;
        }

        private Hashtable GetEXParamsValue(Hashtable hashtable)
        {
            return new Hashtable();
        }

 

        public List<SPClientChannelSettingWrapper> GetAllClientChannelSetting()
        {
            //return SPClientChannelSettingWrapper.GetSettingByChannel(this);
            List<SPClientChannelSettingWrapper> clientChannelSettingWrappers =
                SPClientChannelSettingWrapper.GetSettingByChannel(this);
            return clientChannelSettingWrappers.FindAll(p => (p.IsEnable));
        }

        private SPClientChannelSettingWrapper FindDefaultClientChannelSetting(List<SPClientChannelSettingWrapper> clientChannelSettings)
        {
            return (from cc in clientChannelSettings
                    where (string.IsNullOrEmpty(cc.CommandCode) && cc.CommandType == "7" && cc.OrderIndex == 0)
                    select cc).FirstOrDefault();
        }

        private bool CheckClientChannelSettingHasFilters(List<SPClientChannelSettingWrapper> allEnableClientChannelSettings)
        {
            SPClientChannelSettingWrapper clientChannelSettingWrapper =
                allEnableClientChannelSettings.Find(p => ((p.CommandType == "1" || p.CommandType == "3") && p.AllowFilter.HasValue && p.AllowFilter.Value));

            return (clientChannelSettingWrapper != null);
        }

        private List<SPClientChannelSettingWrapper> FindMatchedClientChannelSettingHasFilters(List<SPClientChannelSettingWrapper> allEnableClientChannelSettings,string ywid,string cpid)
        {
            List<SPClientChannelSettingWrapper> findMatchedClientChannelSettingHasFilters =
                allEnableClientChannelSettings.FindAll(p => ((p.CommandType == "1" || p.CommandType == "3") && p.AllowFilter.HasValue && p.AllowFilter.Value) && p.IsMacthByYWID(ywid) && p.IsMacthSPCode(cpid));

            return findMatchedClientChannelSettingHasFilters;
        }

        private SPClientChannelSettingWrapper GetClientChannelSettingFromRequestValue(Hashtable requestValues,
                                                                                      Hashtable fieldMappings, 
                                                                                      PhoneAreaInfo phoneAreaInfo)
        {
            //获取所有的指令
            List<SPClientChannelSettingWrapper> allEnableClientChannelSettings = GetAllClientChannelSetting();
            //或者默认指令
            SPClientChannelSettingWrapper defaultClientChannelSetting = FindDefaultClientChannelSetting(allEnableClientChannelSettings);
            //如果有分省份指令
            if(CheckClientChannelSettingHasFilters(allEnableClientChannelSettings))
            {
                //获取SPcode和mo
                string cpid = GetMappedParamValueFromRequest(requestValues, "cpid", fieldMappings);
                string ywid = GetMappedParamValueFromRequest(requestValues, "ywid", fieldMappings);
                //string mobile = GetMappedParamValueFromRequest(requestValues, "mobile", fieldMappings);

                List<SPClientChannelSettingWrapper> findMatchedClientChannelSettingHasFilters = FindMatchedClientChannelSettingHasFilters(allEnableClientChannelSettings, ywid, cpid);

                if (findMatchedClientChannelSettingHasFilters != null && findMatchedClientChannelSettingHasFilters.Count>0)
                {
                    SPClientChannelSettingWrapper macthedYWIDAndProvinceClientChannelSettingWrapper = null;

                    if(phoneAreaInfo!=null)
                        macthedYWIDAndProvinceClientChannelSettingWrapper = findMatchedClientChannelSettingHasFilters.Find(p => (p.InArea(phoneAreaInfo) && p.IsEnable));

                    if (macthedYWIDAndProvinceClientChannelSettingWrapper != null)
                        return macthedYWIDAndProvinceClientChannelSettingWrapper;

                    foreach (SPClientChannelSettingWrapper findMatchedClientChannelSettingHasFilter in findMatchedClientChannelSettingHasFilters)
                    {
                        if(findMatchedClientChannelSettingHasFilter.Filters!=null && findMatchedClientChannelSettingHasFilter.Filters.Count>0)
                        {
                            allEnableClientChannelSettings.Remove(findMatchedClientChannelSettingHasFilter);
                        }
                    }

                }
            }

            //List<SPClientChannelSettingWrapper> spcodes = (from cc in allEnableClientChannelSettings
            //                                               where (cc.IsMacth(requestValues, fieldMappings))
            //                                               orderby cc.OrderIndex descending
            //                                               select cc).ToList();

            SPClientChannelSettingWrapper macthClientChannelSetting = (from cc in allEnableClientChannelSettings
                                                                       where (cc.IsMacth(requestValues, fieldMappings))
                                                                       orderby cc.OrderIndex descending
                                                                       select cc).FirstOrDefault();

            if (macthClientChannelSetting == null)
                return defaultClientChannelSetting;

            int orderIndex = macthClientChannelSetting.OrderIndex.HasValue?macthClientChannelSetting.OrderIndex.Value:0;

            List<SPClientChannelSettingWrapper> allmacthClientChannelSettings = (from cc in allEnableClientChannelSettings
                                                                                 where (cc.IsMacth(requestValues, fieldMappings) && cc.OrderIndex == orderIndex)
                                                                                 select cc).ToList();

            if (allmacthClientChannelSettings.Count <= 0)
            {
                return defaultClientChannelSetting;
            }
            else if (allmacthClientChannelSettings.Count<=1)
            {
                return allmacthClientChannelSettings[0];
            }
            else
            {
                return allmacthClientChannelSettings.Find(p => (p.IsMacthSPCode(requestValues, fieldMappings,"cpid")));
            }
        }

        public static string GetMappedParamValueFromRequest(Hashtable requestValues, string mapName,
                                                            Hashtable fieldMappings)
        {
            if (requestValues==null)
                throw new ArgumentNullException("requestValues");
            if (fieldMappings == null)
                throw new ArgumentNullException("fieldMappings");

            try
            {
                string queryKey = mapName.ToLower();

                if (fieldMappings.ContainsKey(mapName))
                {
                    queryKey = (string) fieldMappings[mapName];
                }
                else
                {
                    queryKey = "";
                }

                if (!requestValues.ContainsKey(queryKey))
                    return "";

                return requestValues[queryKey].ToString();
            }
            catch (Exception ex)
            {
                Logger.Error(mapName+":Error",ex);
                throw;
            }
        }




        public DataTable BuildChannelRecordTable()
        {
            var record = new DataTable();

            record.Columns.Add("RecordID", typeof (int));
            record.Columns.Add("CreateDate", typeof (DateTime));
            record.Columns.Add("Province", typeof (string));
            record.Columns.Add("City", typeof (string));
            record.Columns.Add("IsSycnData", typeof(string));
            record.Columns.Add("SucesssToSend", typeof(string));
            record.Columns.Add("SycnRetryTimes", typeof(string));
            record.Columns.Add("SendUrl", typeof (string));

            foreach (string field in fields)
            {
                record.Columns.Add(field);
            }

            record.AcceptChanges();

            return record;
        }
 
        public List<SPChannelDefaultClientSycnParamsWrapper> GetAllEnableDefaultSendParams()
        {
            return
                SPChannelDefaultClientSycnParamsWrapper.ConvertToWrapperList(
                    businessProxy.GetAllEnableDefaultSendParams(entity));
        }

        public static void QuickAdd(SPChannelWrapper spChannelWrapper, string linkPName, string mobilePName,
                                    string spCodePName, string moPName, int userID)
        {
            businessProxy.QuickAdd(spChannelWrapper.entity, linkPName, mobilePName, spCodePName, moPName, userID);
        }

        public static void QuickAddIVR(SPChannelWrapper spChannelWrapper, string linkPName, string mobilePName,
                            string spCodePName, string startTimePName, string endTimePName, string feetimePName, int userID)
        {
            businessProxy.QuickAddIVR(spChannelWrapper.entity, linkPName, mobilePName, spCodePName, startTimePName, endTimePName, feetimePName, userID);
        }


        public bool ProcessStateRequest(IHttpRequest httpGetPostReques, out RequestError error)
        {
            error = new RequestError();
            error.ErrorType = RequestErrorType.NoError;
            error.ErrorMessage = "";
            error.ChannelID = Id;

            Hashtable fieldMappings = GetFieldMappings();

            string cpid = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "cpid", fieldMappings);
            string mid = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "mid", fieldMappings);
            string mobile = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "mobile", fieldMappings);
            string port = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "port", fieldMappings);
            string ywid = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "ywid", fieldMappings);
            string msg = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "msg", fieldMappings);
            string linkid = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "linkid", fieldMappings);
            string dest = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "dest", fieldMappings);
            string price = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "price", fieldMappings);
            string extendfield1 = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "extendfield1", fieldMappings);
            string extendfield2 = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "extendfield2", fieldMappings);
            string extendfield3 = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "extendfield3", fieldMappings);
            string extendfield4 = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "extendfield4", fieldMappings);
            string extendfield5 = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "extendfield5", fieldMappings);
            string extendfield6 = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "extendfield6", fieldMappings);
            string extendfield7 = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "extendfield7", fieldMappings);
            string extendfield8 = GetMappedParamValueFromRequest(httpGetPostReques.RequestParams, "extendfield8", fieldMappings);



            if (string.IsNullOrEmpty(linkid) && IsAllowNullLinkID.HasValue && IsAllowNullLinkID.Value)
            {
                linkid = Guid.NewGuid().ToString();
            }

            if (string.IsNullOrEmpty(linkid))
            {
                error.ErrorType = RequestErrorType.NoLinkID;
                error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：没有LinkID .";

                return false;
            }

            if (LinkIDQueryCache.CheckLinkIDIsExisted(linkid, this.Id))
            {
                error.ErrorType = RequestErrorType.RepeatLinkID;
                error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID (缓存检查) .";
                return false;
            }

 

            Hashtable exparams = GetEXParamsValue(httpGetPostReques.RequestParams);

            PhoneAreaInfo phoneAreaInfo = null;

            if (!string.IsNullOrEmpty(mobile) && mobile.Length > 7)
            {
                try
                {
                    
                    try
                    {
                        phoneAreaInfo = PhoneCache.GetPhoneAreaByPhoneNumber(mobile);
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("号段读取错误："+ex.Message);
                        phoneAreaInfo = SPPhoneAreaWrapper.GetPhoneCity(mobile.Substring(0, 7));
                    }

                }
                catch (Exception ex)
                {
                    Logger.Error("号段读取错误：" + ex.Message);
                }
            }
 

            SPClientChannelSettingWrapper channelSetting = GetClientChannelSettingFromRequestValue(httpGetPostReques.RequestParams,
                                                                                                   fieldMappings, phoneAreaInfo);

            if (channelSetting == null || !channelSetting.IsEnable)
            {
                List<SPClientChannelSettingWrapper> clientChannelSettings = GetAllClientChannelSetting();

                channelSetting = clientChannelSettings.Find(p=>(p.CommandType=="7" && p.Name.Contains("默认下家")));
            }


            SPSStatePaymentInfoWrapper paymentInfo = new SPSStatePaymentInfoWrapper();

            paymentInfo.ChannelID = this.Id;
            paymentInfo.ClientID = channelSetting.ClinetID.Id;
            paymentInfo.ChannleClientID = channelSetting.Id;
            paymentInfo.Cpid = cpid;
            paymentInfo.Mid = mid;
            paymentInfo.MobileNumber = mobile;
            paymentInfo.Port = port;
            paymentInfo.Ywid = ywid;
            paymentInfo.Message = msg;
            paymentInfo.Linkid = linkid;
            paymentInfo.Dest = dest;
            paymentInfo.Price = price;
            paymentInfo.ExtendField1 = extendfield1;
            paymentInfo.ExtendField2 = extendfield2;
            paymentInfo.ExtendField3 = extendfield3;
            paymentInfo.ExtendField4 = extendfield4;
            paymentInfo.ExtendField5 = extendfield5;
            paymentInfo.ExtendField6 = extendfield6;
            paymentInfo.ExtendField7 = extendfield7;
            paymentInfo.ExtendField8 = extendfield8;

            try
            {
                if (channelSetting.ClinetID != null && channelSetting.ClinetID.SPClientGroupID != null)
                {
                    paymentInfo.ClientGroupID = channelSetting.ClinetID.SPClientGroupID.Id;
                }
                else
                {
                    paymentInfo.ClientGroupID = 0;
                }
            }
            catch (Exception ex)
            {
                logger.Error("SPClientGroupID Error", ex);
            }
            paymentInfo.Ip = httpGetPostReques.RequestIp;
            paymentInfo.IsIntercept = false;
            paymentInfo.CreateDate = DateTime.Now;
            //paymentInfo.RequestContent = httpGetPostReques.RequestData;

            if (phoneAreaInfo != null)
            {
                paymentInfo.Province = phoneAreaInfo.Province;
                paymentInfo.City = phoneAreaInfo.City;
                paymentInfo.MobileOperators = phoneAreaInfo.MobileOperators;
            }



            paymentInfo.IsSycnData = false;


            try
            {
                PaymentInfoInsertErrorType errorType = PaymentInfoInsertErrorType.NoError;

 

                bool result = paymentInfo.InsertPayment(  out errorType);

                if (!result && errorType == PaymentInfoInsertErrorType.RepeatLinkID)
                {
                    error.ErrorType = RequestErrorType.RepeatLinkID;
                    error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID .";
                    error.ClientID = channelSetting.ClinetID.Id;

                    return false;
                }

                error.ErrorType = RequestErrorType.NoError;
                error.ErrorMessage = "";
 
                SPStatReportWrapper spStatReportWrapper =
                    SPStatReportWrapper.FindByChannelIDAndLinkIDAndReportOk(this.Id, linkid);

                bool findOkReport = (spStatReportWrapper!=null);

                if (findOkReport)
                {
                    return ProcessStatPayment(error, httpGetPostReques, linkid, paymentInfo);
                }
                else
                {
                    return true;
                }


            }
            catch (Exception ex)
            {
                error.ErrorType = RequestErrorType.DataSaveError;
                error.ErrorMessage = "请求失败：插入数据失败，错误信息：" + ex.Message;
                return false;
            }
        }



        public bool RecState(IHttpRequest httpGetPostRequest, string stat, out RequestError error)
        {
            error = new RequestError();
            error.ErrorType = RequestErrorType.NoError;
            error.ErrorMessage = "";
            error.ChannelID = Id;


            Hashtable fieldMappings = GetFieldMappings();

            string linkid = "";

            linkid = GetMappedParamValueFromRequest(httpGetPostRequest.RequestParams, "linkid", fieldMappings);

            if (LinkIDQueryCache.CheckLinkIDIsExisted(linkid, this.Id))
            {
                error.ErrorType = RequestErrorType.RepeatLinkID;
                error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID (缓存检查) .";
                return false;
            }


            //保存状态报告
            SPStatReportWrapper statReport = new SPStatReportWrapper();

            statReport.ChannelID = Id;
            statReport.LinkID = linkid;
            statReport.IsPayOk = this.CheckReportIsOk(stat);
            statReport.CreateDate = DateTime.Now;
            statReport.QueryString = httpGetPostRequest.RequestQueryString;
            statReport.RequestContent = httpGetPostRequest.RequestData;
            statReport.Stat = stat;

            SPStatReportWrapper.Save(statReport);

            //如果状态报告OK，检查是否存在记录，存在记录立即报告
            if (!(statReport.IsPayOk.HasValue && statReport.IsPayOk.Value))
            {
                return true;
            }

            SPSStatePaymentInfoWrapper statepaymentInfo = SPSStatePaymentInfoWrapper.FindByChannelIDAndLinkID(Id, linkid);

           
            if (statepaymentInfo == null)
            {
                return true;
            }

            //存在数据的话立即报告

            return ProcessStatPayment(error, httpGetPostRequest, linkid, statepaymentInfo);
        }

        private bool ProcessStatPayment(RequestError error, IHttpRequest httpGetPostRequest, string linkid, SPSStatePaymentInfoWrapper statepaymentInfo)
        {
            SPClientChannelSettingWrapper channelSetting = SPClientChannelSettingWrapper.FindById(statepaymentInfo.ChannleClientID);

            SPPaymentInfoWrapper paymentInfo = new SPPaymentInfoWrapper();

            paymentInfo.ChannelID = this;
            paymentInfo.ClientID = SPClientWrapper.FindById(statepaymentInfo.ClientID);
            paymentInfo.ChannleClientID = statepaymentInfo.ChannleClientID;
            paymentInfo.Cpid = statepaymentInfo.Cpid;
            paymentInfo.Mid = statepaymentInfo.Mid;
            paymentInfo.MobileNumber = statepaymentInfo.MobileNumber;
            paymentInfo.Port = statepaymentInfo.Port;
            paymentInfo.Ywid = statepaymentInfo.Ywid;
            paymentInfo.Message = statepaymentInfo.Message;
            paymentInfo.Linkid = linkid;
            paymentInfo.Dest = statepaymentInfo.Dest;
            paymentInfo.Price = statepaymentInfo.Price;
            paymentInfo.ExtendField1 = statepaymentInfo.ExtendField1;
            paymentInfo.ExtendField2 = statepaymentInfo.ExtendField2;
            paymentInfo.ExtendField3 = statepaymentInfo.ExtendField3;
            paymentInfo.ExtendField4 = statepaymentInfo.ExtendField4;
            paymentInfo.ExtendField5 = statepaymentInfo.ExtendField5;
            paymentInfo.ExtendField6 = statepaymentInfo.ExtendField6;
            paymentInfo.ExtendField7 = statepaymentInfo.ExtendField7;
            paymentInfo.ExtendField8 = statepaymentInfo.ExtendField8;
            paymentInfo.ClientGroupID = statepaymentInfo.ClientGroupID;
            paymentInfo.MobileOperators = statepaymentInfo.MobileOperators;
            paymentInfo.Ip = statepaymentInfo.Ip;
            paymentInfo.CreateDate = DateTime.Now;
            paymentInfo.RequestContent = httpGetPostRequest.RequestData;

            paymentInfo.SetPaymentProviceAndCity();

            paymentInfo.IsIntercept = channelSetting.CaculteIsIntercept(paymentInfo);

            paymentInfo.IsSycnData = false;

            UrlSendTask sendTask = null;

            if (!paymentInfo.IsIntercept.Value)
            {
                if (!string.IsNullOrEmpty(channelSetting.SyncDataUrl))
                {
                    paymentInfo.IsSycnData = true;
                    //if (!string.IsNullOrEmpty(channelSetting.SyncType) && channelSetting.SyncType.Equals("2"))
                    //{
                    //    paymentInfo.SucesssToSend = false;
                    //}
                    //else
                    //{
                    paymentInfo.SucesssToSend = false;

                    sendTask = new UrlSendTask();

                    sendTask.SendUrl = channelSetting.BulidUrl(paymentInfo);
                    sendTask.OkMessage = channelSetting.OkMessage;

                    //}
                }
                else
                    paymentInfo.SucesssToSend = false;
            }
            else
            {
                paymentInfo.SucesssToSend = false;
            }

            try
            {
                PaymentInfoInsertErrorType errorType = PaymentInfoInsertErrorType.NoError;

                bool result = paymentInfo.InsertPayment(out errorType);

                if (!result && errorType == PaymentInfoInsertErrorType.RepeatLinkID)
                {
                    error.ErrorType = RequestErrorType.RepeatLinkID;
                    error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID .";
                    error.ClientID = channelSetting.ClinetID.Id;

                    return false;
                }

                error.ErrorType = RequestErrorType.NoError;
                error.ErrorMessage = "";

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
                    sendTask.PaymentID = paymentInfo.Id;
                    ThreadPool.QueueUserWorkItem(UrlSender.UrlSender.SendRequest, sendTask);
                }

                return true;
            }
            catch (Exception ex)
            {
                error.ErrorType = RequestErrorType.DataSaveError;
                error.ErrorMessage = "请求失败：插入数据失败，错误信息：" + ex.Message;
                return false;
            }
        }

        public bool IsReportChannel
        {
            get { return (this.RecStatReport.HasValue && this.RecStatReport.Value); }
        }

        public bool IsTypeReuquestReportChannel
        {
            get { return (this.HasRequestTypeParams.HasValue && this.HasRequestTypeParams.Value); }
        }

        private bool CheckReportIsOk(string stat)
        {
            //如果状态报告通道
            if (IsReportChannel)
            {
                return stat.ToLower().Trim().Equals(this.StatParamsValues.ToLower().Trim());
            }
            else
            {
                return true;
            }
        }


        public void RefreshChannelInfo()
        {
            this.ChannelInfo = this.CodeList;
            Save(this);
        }

        public static void RefreshAllChannelInfo()
        {
            List<SPChannelWrapper> allchannels = SPChannelWrapper.FindAll();
            foreach (SPChannelWrapper spChannelWrapper in allchannels)
            {
                spChannelWrapper.RefreshChannelInfo();
            }
        }

        public static Hashtable PraseHttpGetPostRequestValue(HttpContext requestContext)
        {
            Hashtable hb = new Hashtable();

            foreach (string key in requestContext.Request.Params.Keys)
            {
                hb.Add(key.ToLower(), requestContext.Request.Params[key.ToLower()]);
            }

            return hb;
        }

        public string GetFailedCode(IHttpRequest httpRequest)
        {
            if(string.IsNullOrEmpty(this.FailedMessage))
                return "";

            if (!FailedMessage.Contains("{$"))
                return this.FailedMessage.Trim().ToLower();

            Regex regex = new Regex(@"(?<={\$).*?(?=})");

            MatchCollection mc = regex.Matches(OkMessage);

            string rmessage = FailedMessage;

            foreach (Match match in mc)
            {
                if (!httpRequest.RequestParams.ContainsKey(match.Value))
                    rmessage = rmessage.Replace("{$" + match.Value + "}", "");
                else
                    rmessage = rmessage.Replace("{$" + match.Value + "}", httpRequest.RequestParams[match.Value].ToString());
            }

            return rmessage;
        }

        
        public bool LogFailedRequestToDb
        {
            get
            {
                return false;      
            }
        }

        public string GetOkCode(IHttpRequest httpRequest)
        {
            if (string.IsNullOrEmpty(OkMessage))
                return "";

            if (!OkMessage.Contains("{$"))
                return OkMessage;

            Regex regex = new Regex(@"(?<={\$).*?(?=})");

            MatchCollection mc = regex.Matches(OkMessage);

            string okmessage = OkMessage;

            foreach (Match match in mc)
            {
                if(!httpRequest.RequestParams.ContainsKey(match.Value))
                    okmessage = okmessage.Replace("{$" + match.Value + "}", "");
                else
                    okmessage = okmessage.Replace("{$" + match.Value + "}", httpRequest.RequestParams[match.Value].ToString());
            }

            return okmessage;
        }
    }
}