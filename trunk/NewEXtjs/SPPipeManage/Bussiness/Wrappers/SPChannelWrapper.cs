using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using LD.SPPipeManage.Bussiness.Commons;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;
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

        public bool ProcessRequest(Hashtable hashtable, string ip, string query, HttpRequest request,
                                   out RequestError error)
        {
            error = new RequestError();
            error.ErrorType = RequestErrorType.NoError;
            error.ErrorMessage = "";
            error.ChannelID = Id;

            Hashtable fieldMappings = GetFieldMappings();

            string cpid = GetMappedParamValueFromRequest(hashtable, "cpid", fieldMappings);
            string mid = GetMappedParamValueFromRequest(hashtable, "mid", fieldMappings);
            string mobile = GetMappedParamValueFromRequest(hashtable, "mobile", fieldMappings);
            string port = GetMappedParamValueFromRequest(hashtable, "port", fieldMappings);
            string ywid = GetMappedParamValueFromRequest(hashtable, "ywid", fieldMappings);
            string msg = GetMappedParamValueFromRequest(hashtable, "msg", fieldMappings);
            string linkid = GetMappedParamValueFromRequest(hashtable, "linkid", fieldMappings);
            string dest = GetMappedParamValueFromRequest(hashtable, "dest", fieldMappings);
            string price = GetMappedParamValueFromRequest(hashtable, "price", fieldMappings);
            string extendfield1 = GetMappedParamValueFromRequest(hashtable, "extendfield1", fieldMappings);
            string extendfield2 = GetMappedParamValueFromRequest(hashtable, "extendfield2", fieldMappings);
            string extendfield3 = GetMappedParamValueFromRequest(hashtable, "extendfield3", fieldMappings);
            string extendfield4 = GetMappedParamValueFromRequest(hashtable, "extendfield4", fieldMappings);
            string extendfield5 = GetMappedParamValueFromRequest(hashtable, "extendfield5", fieldMappings);
            string extendfield6 = GetMappedParamValueFromRequest(hashtable, "extendfield6", fieldMappings);
            string extendfield7 = GetMappedParamValueFromRequest(hashtable, "extendfield7", fieldMappings);
            string extendfield8 = GetMappedParamValueFromRequest(hashtable, "extendfield8", fieldMappings);
            string extendfield9 = GetMappedParamValueFromRequest(hashtable, "extendfield9", fieldMappings);


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

            string content = query;


            Hashtable exparams = GetEXParamsValue(hashtable);

            SPClientChannelSettingWrapper channelSetting = GetClientChannelSettingFromRequestValue(hashtable,
                                                                                                   fieldMappings);

            if (channelSetting == null)
            {
                error.ErrorType = RequestErrorType.NoChannelClientSetting;
                error.ErrorMessage = "请求失败：通道‘" + Name + "’请求未能找到匹配的通道下家设置。";

                //SPFailedRequestWrapper.SaveFailedRequest(request, ip, content, "请求失败：通道‘" + this.Name + "’请求未能找到匹配的通道下家设置。", this.Id, 0);

                return false;
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
            paymentInfo.ExtendField9 = extendfield9;
            paymentInfo.Ip = ip;
            paymentInfo.IsIntercept = channelSetting.CaculteIsIntercept();
            paymentInfo.CreateDate = DateTime.Now;
            paymentInfo.RequestContent = content;


            if (!string.IsNullOrEmpty(mobile) && mobile.Length > 7)
            {
                try
                {
                    PhoneAreaInfo phoneAreaInfo = SPPhoneAreaWrapper.GetPhoneCity(mobile.Substring(0, 7));
                    if (phoneAreaInfo != null)
                    {
                        paymentInfo.Province = phoneAreaInfo.Province;
                        paymentInfo.City = phoneAreaInfo.City;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }

            paymentInfo.IsSycnData = false;

            if (!paymentInfo.IsIntercept.Value)
            {
                if (!string.IsNullOrEmpty(channelSetting.SyncDataUrl))
                {
                    paymentInfo.IsSycnData = true;
                    if (!string.IsNullOrEmpty(channelSetting.SyncType) && channelSetting.SyncType.Equals("2"))
                    {
                        paymentInfo.SucesssToSend = false;
                    }
                    else
                    {
                        paymentInfo.SucesssToSend = channelSetting.SendMsg(paymentInfo);
                    }
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

                var uniqueKeyNames = new List<string>();

                List<SPChannelParamsWrapper> channelParams = GetAllEnableParams();

                foreach (SPChannelParamsWrapper spChannelParamsWrapper in channelParams)
                {
                    if (spChannelParamsWrapper.IsUnique.HasValue && spChannelParamsWrapper.IsUnique.Value)
                        uniqueKeyNames.Add(spChannelParamsWrapper.ParamsMappingName.ToLower());
                }

                if (!uniqueKeyNames.Contains("linkid"))
                {
                    uniqueKeyNames.Add("linkid");
                }

                bool result = paymentInfo.InsertPayment(uniqueKeyNames, out errorType);

                if (!result && errorType == PaymentInfoInsertErrorType.RepeatLinkID)
                {
                    error.ErrorType = RequestErrorType.RepeatLinkID;
                    error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID .";
                    error.ClientID = channelSetting.ClinetID.Id;
                    //SPFailedRequestWrapper.SaveFailedRequest(request, ip, query, " 通道 ‘" + Name + "’ 请求失败：重复的LinkID .",
                    //                                         Id, 0);

                    return false;
                }

                error.ErrorType = RequestErrorType.NoError;
                error.ErrorMessage = "";

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
            return SPClientChannelSettingWrapper.GetSettingByChannel(this);
        }

        private SPClientChannelSettingWrapper GetClientChannelSettingFromRequestValue(Hashtable requestValues,
                                                                                      Hashtable fieldMappings)
        {
            List<SPClientChannelSettingWrapper> clientChannelSettings = GetAllClientChannelSetting();

            SPClientChannelSettingWrapper macthClientChannelSetting = (from cc in clientChannelSettings
                                                                       where (cc.IsMacth(requestValues, fieldMappings))
                                                                       orderby cc.OrderIndex descending
                                                                       select cc).FirstOrDefault();

            return macthClientChannelSetting;
        }

        private SPClientChannelSettingWrapper GetMacthRuleChannelSetting(SPClientChannelSettingWrapper channelSetting,
                                                                         Hashtable requestValues,
                                                                         Hashtable fieldMappings)
        {
            string columnName = "ywid";

            if (!string.IsNullOrEmpty(channelSetting.CommandColumn))
            {
                columnName = channelSetting.CommandColumn;
            }

            string ywid = GetMappedParamValueFromRequest(requestValues, columnName, fieldMappings);

            if (channelSetting.MatchByYWID(ywid))
            {
                return channelSetting;
            }

            return null;
        }

        public static string GetMappedParamValueFromRequest(Hashtable requestValues, string mapName,
                                                            Hashtable fieldMappings)
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

        public string GetOkCode(HttpContext context)
        {
            if (this.OkMessage == null)
                return "";
            return this.OkMessage.Replace("{$linkid}", this.GetRequsetValue(context,"linkid"));
        }


        public DataTable BuildChannelRecordTable()
        {
            var record = new DataTable();

            record.Columns.Add("RecordID", typeof (int));
            record.Columns.Add("CreateDate", typeof (DateTime));
            record.Columns.Add("Province", typeof (string));
            record.Columns.Add("City", typeof (string));
            record.Columns.Add("SendUrl", typeof (string));

            foreach (string field in fields)
            {
                record.Columns.Add(field);
            }

            record.AcceptChanges();

            return record;
        }

        public void SaveStatReport(Hashtable hashtable, string recievdData, string query, string stat)
        {
            Hashtable fieldMappings = GetFieldMappings();

            string linkid = GetMappedParamValueFromRequest(hashtable, "linkid", fieldMappings);

            var statReport = new SPStatReportWrapper();
            statReport.ChannelID = Id;
            statReport.LinkID = linkid;
            statReport.CreateDate = DateTime.Now;
            statReport.QueryString = query;
            statReport.RequestContent = recievdData;
            statReport.Stat = stat;

            SPStatReportWrapper.Save(statReport);
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

        public bool ProcessStateRequest(Hashtable hashtable, string ip, string recievdData, HttpRequest httpRequest, out RequestError error)
        {
            error = new RequestError();
            error.ErrorType = RequestErrorType.NoError;
            error.ErrorMessage = "";
            error.ChannelID = Id;

            Hashtable fieldMappings = GetFieldMappings();

            string cpid = GetMappedParamValueFromRequest(hashtable, "cpid", fieldMappings);
            string mid = GetMappedParamValueFromRequest(hashtable, "mid", fieldMappings);
            string mobile = GetMappedParamValueFromRequest(hashtable, "mobile", fieldMappings);
            string port = GetMappedParamValueFromRequest(hashtable, "port", fieldMappings);
            string ywid = GetMappedParamValueFromRequest(hashtable, "ywid", fieldMappings);
            string msg = GetMappedParamValueFromRequest(hashtable, "msg", fieldMappings);
            string linkid = GetMappedParamValueFromRequest(hashtable, "linkid", fieldMappings);
            string dest = GetMappedParamValueFromRequest(hashtable, "dest", fieldMappings);
            string price = GetMappedParamValueFromRequest(hashtable, "price", fieldMappings);
            string extendfield1 = GetMappedParamValueFromRequest(hashtable, "extendfield1", fieldMappings);
            string extendfield2 = GetMappedParamValueFromRequest(hashtable, "extendfield2", fieldMappings);
            string extendfield3 = GetMappedParamValueFromRequest(hashtable, "extendfield3", fieldMappings);
            string extendfield4 = GetMappedParamValueFromRequest(hashtable, "extendfield4", fieldMappings);
            string extendfield5 = GetMappedParamValueFromRequest(hashtable, "extendfield5", fieldMappings);
            string extendfield6 = GetMappedParamValueFromRequest(hashtable, "extendfield6", fieldMappings);
            string extendfield7 = GetMappedParamValueFromRequest(hashtable, "extendfield7", fieldMappings);
            string extendfield8 = GetMappedParamValueFromRequest(hashtable, "extendfield8", fieldMappings);
            string extendfield9 = GetMappedParamValueFromRequest(hashtable, "extendfield9", fieldMappings);


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

            string content = recievdData;


            Hashtable exparams = GetEXParamsValue(hashtable);

            SPClientChannelSettingWrapper channelSetting = GetClientChannelSettingFromRequestValue(hashtable,
                                                                                                   fieldMappings);

            if (channelSetting == null)
            {
                error.ErrorType = RequestErrorType.NoChannelClientSetting;
                error.ErrorMessage = "请求失败：通道‘" + Name + "’请求未能找到匹配的通道下家设置。";

                return false;
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
            paymentInfo.ExtendField9 = extendfield9;
            paymentInfo.Ip = ip;
            paymentInfo.IsIntercept = false;
            paymentInfo.CreateDate = DateTime.Now;
            paymentInfo.RequestContent = content;


            if (!string.IsNullOrEmpty(mobile) && mobile.Length > 7)
            {
                try
                {
                    PhoneAreaInfo phoneAreaInfo = SPPhoneAreaWrapper.GetPhoneCity(mobile.Substring(0, 7));
                    if (phoneAreaInfo != null)
                    {
                        paymentInfo.Province = phoneAreaInfo.Province;
                        paymentInfo.City = phoneAreaInfo.City;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }

            paymentInfo.IsSycnData = false;

           
            try
            {
                PaymentInfoInsertErrorType errorType = PaymentInfoInsertErrorType.NoError;

                var uniqueKeyNames = new List<string>();

                List<SPChannelParamsWrapper> channelParams = GetAllEnableParams();

                foreach (SPChannelParamsWrapper spChannelParamsWrapper in channelParams)
                {
                    if (spChannelParamsWrapper.IsUnique.HasValue && spChannelParamsWrapper.IsUnique.Value)
                        uniqueKeyNames.Add(spChannelParamsWrapper.ParamsMappingName.ToLower());
                }

                if (!uniqueKeyNames.Contains("linkid"))
                {
                    uniqueKeyNames.Add("linkid");
                }

                bool result = paymentInfo.InsertPayment(uniqueKeyNames, out errorType);

                if (!result && errorType == PaymentInfoInsertErrorType.RepeatLinkID)
                {
                    error.ErrorType = RequestErrorType.RepeatLinkID;
                    error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID .";
                    error.ClientID = channelSetting.ClinetID.Id;

                    return false;
                }

                error.ErrorType = RequestErrorType.NoError;
                error.ErrorMessage = "";

                return true;
            }
            catch (Exception ex)
            {
                error.ErrorType = RequestErrorType.DataSaveError;
                error.ErrorMessage = "请求失败：插入数据失败，错误信息：" + ex.Message;
                return false;
            }
        }

        public bool RecState(Hashtable hashtable, string recievdData, string query, string stat, out RequestError error)
        {
            Hashtable fieldMappings = GetFieldMappings();

            string linkid = GetMappedParamValueFromRequest(hashtable, "linkid", fieldMappings);

            var statReport = new SPStatReportWrapper();
            statReport.ChannelID = Id;
            statReport.LinkID = linkid;
            statReport.CreateDate = DateTime.Now;
            statReport.QueryString = query;
            statReport.RequestContent = recievdData;
            statReport.Stat = stat;

            SPStatReportWrapper.Save(statReport);

            SPSStatePaymentInfoWrapper statepaymentInfo = SPSStatePaymentInfoWrapper.FindByChannelIDAndLinkID(Id, linkid);

            error = new RequestError();
            error.ErrorType = RequestErrorType.NoError;
            error.ErrorMessage = "";
            error.ChannelID = Id;


            if (statepaymentInfo==null)
            {
                error.ErrorType = RequestErrorType.NoReportData;
                error.ErrorMessage = "没有linkid为“" + linkid + "”找到状态报告数据";
                return false;
            }



            SPClientChannelSettingWrapper channelSetting =
                SPClientChannelSettingWrapper.FindById(statepaymentInfo.ChannleClientID);

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
            paymentInfo.ExtendField9 = statepaymentInfo.ExtendField9;
            paymentInfo.Ip = statepaymentInfo.Ip;
            paymentInfo.IsIntercept = channelSetting.CaculteIsIntercept();
            paymentInfo.CreateDate = DateTime.Now;
            paymentInfo.RequestContent = recievdData;


            paymentInfo.SetPaymentProviceAndCity();

            paymentInfo.IsSycnData = false;

            paymentInfo.SycnDataToClient();

            try
            {
                PaymentInfoInsertErrorType errorType = PaymentInfoInsertErrorType.NoError;

                var uniqueKeyNames = new List<string>();

                List<SPChannelParamsWrapper> channelParams = GetAllEnableParams();

                foreach (SPChannelParamsWrapper spChannelParamsWrapper in channelParams)
                {
                    if (spChannelParamsWrapper.IsUnique.HasValue && spChannelParamsWrapper.IsUnique.Value)
                        uniqueKeyNames.Add(spChannelParamsWrapper.ParamsMappingName.ToLower());
                }

                if (!uniqueKeyNames.Contains("linkid"))
                {
                    uniqueKeyNames.Add("linkid");
                }

                bool result = paymentInfo.InsertPayment(uniqueKeyNames, out errorType);

                if (!result && errorType == PaymentInfoInsertErrorType.RepeatLinkID)
                {
                    error.ErrorType = RequestErrorType.RepeatLinkID;
                    error.ErrorMessage = " 通道 ‘" + Name + "’ 请求失败：重复的LinkID .";
                    error.ClientID = channelSetting.ClinetID.Id;

                    return false;
                }

                error.ErrorType = RequestErrorType.NoError;
                error.ErrorMessage = "";

                return true;
            }
            catch (Exception ex)
            {
                error.ErrorType = RequestErrorType.DataSaveError;
                error.ErrorMessage = "请求失败：插入数据失败，错误信息：" + ex.Message;
                return false;
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


        public string GetFailedCode()
        {
            if(string.IsNullOrEmpty(this.FailedMessage))
                return "";
            return this.FailedMessage.Trim().ToLower();
        }
    }
}