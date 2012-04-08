
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;
using Spring.Transaction.Interceptor;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
    [Serializable]
    public partial class SPClientChannelSettingWrapper
    {
        #region Static Common Data Operation

        public static void Save(SPClientChannelSettingWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPClientChannelSettingWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPClientChannelSettingWrapper obj)
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

        public static void Delete(SPClientChannelSettingWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPClientChannelSettingWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPClientChannelSettingWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPClientChannelSettingWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPClientChannelSettingWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPClientChannelSettingEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }

        public static List<SPClientChannelSettingWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPClientChannelSettingWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPClientChannelSettingWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }


        public static List<SPClientChannelSettingWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }

        #endregion


        //public static List<SPClientChannelSettingWrapper> Get

        public string ClientName
        {
            get
            {
                if (this.ClinetID != null)
                {
                    return this.ClinetID.Name;
                }
                return "";
            }
        }

        public string DayLimitAndMonthLimit
        {
            get
            {
                if (!this.DayLimitCount.HasValue)
                    this.DayLimitCount = 0;

                if (!this.MonthLimitCount.HasValue)
                    this.MonthLimitCount = 0;

                if (this.HasDayMonthLimit.HasValue && this.HasDayMonthLimit.Value)
                {
                    return string.Format("日{0}/月{1}", this.DayLimitCount.Value, this.MonthLimitCount.Value);
                }
                return "无";
            }
        }

        public string DayTotalLimitInfo
        {
            get
            {
                if (!this.DayTotalLimit.HasValue)
                    this.DayTotalLimit = 0;

                if (this.HasDayTotalLimit.HasValue && this.HasDayTotalLimit.Value)
                {
                    return string.Format("{0}", this.DayTotalLimit.Value);
                }
                return "无";
            }
        }

        public string ClientGroupName
        {
            get
            {
                if (this.ClinetID != null && this.ClinetID.SPClientGroupID!=null)
                {
                    return this.ClinetID.ClientGroupName;
                }
                return "";
            }
        }

        public string ChannelName
        {
            get
            {
                if (this.ChannelID != null)
                {
                    return this.ChannelID.Name;
                }
                return "";
            }
        }

        public int ChannelID_ID
        {
            get
            {
                if (this.ChannelID != null)
                {
                    return this.ChannelID.Id;
                }
                return 0;
            }
        }

        public bool IsEnable
        {
            get
            {
                if (!Disable.HasValue)
                {
                    return true;
                }
                return !Disable.Value;
            }
        }

        public string ChannelClientRuleMatch
        {
            get
            {
                string columnName = "ywid";

                if (!string.IsNullOrEmpty(this.CommandColumn))
                    columnName = this.CommandColumn;

                if (this.CommandType == "7")
                    return this.CommandTypeName;

                return columnName + " " + this.CommandTypeName + " " + this.CommandCode;
            }
        }


        public string ChannelClientCode
        {
            get
            {
                string columnName = "ywid";

                if (!string.IsNullOrEmpty(this.CommandColumn))
                    columnName = this.CommandColumn;

                if (!columnName.Equals("ywid"))
                    return "";

                if (string.IsNullOrEmpty(this.CommandCode))
                    return "";

                string spcode = "<font color='Red'>空缺</font>";

                if(!string.IsNullOrEmpty(this.ChannelCode))
                    spcode = this.ChannelCode;

                string provinceLimit = "";

                if (this.CommandType == "1" && this.AllowFilter.HasValue && this.AllowFilter.Value && this.Filters != null && this.Filters.Count > 0)
                {
                    provinceLimit = " (";

                    int i = 0;

                    foreach (SPClientChannelSettingFiltersWrapper settingFilter in this.Filters)
                    {
                        provinceLimit += settingFilter.FilterValue;

                        if (i < this.Filters.Count - 1)
                        {
                            provinceLimit += ",";
                        }

                        i++;
                    }

                    provinceLimit += ")";
                }


                if (this.CommandType == "1")
                    return this.CommandCode + " (精准) 到 " + spcode + provinceLimit;

                if (this.CommandType == "2")
                    return "包含" + this.CommandCode + " (模糊) 到 " + spcode + provinceLimit;

                if (this.CommandType == "3")
                    return this.CommandCode + " (模糊) 到 " + spcode + provinceLimit;

                if (this.CommandType == "4")
                    return "结尾" + this.CommandCode + " (模糊) 到 " + spcode + provinceLimit;

                if (this.CommandType == "5")
                    return "正则" + this.CommandCode + " (模糊) 到 " + spcode + provinceLimit;

                if (this.CommandType == "6")
                    return "自定义" + this.CommandCode + " (模糊) 到 " + spcode + provinceLimit;
 
                return columnName + " " + this.CommandTypeName + " " + this.CommandCode;
            }
        }

        public string MoCode
        {
            get
            {
                if (string.IsNullOrEmpty(this.CommandCode))
                    return "";

                string spcode = "空缺";

                if (!string.IsNullOrEmpty(this.ChannelCode))
                    spcode = this.ChannelCode;

                if (this.CommandType == "1")
                    return this.CommandCode + " (精准) 到 " + spcode;

                if (this.CommandType == "2")
                    return "包含" + this.CommandCode + " (模糊) 到 " + spcode;

                if (this.CommandType == "3")
                    return this.CommandCode + " (模糊) 到 " + spcode;

                if (this.CommandType == "4")
                    return "结尾" + this.CommandCode + " (模糊) 到 " + spcode;

                if (this.CommandType == "5")
                    return "正则" + this.CommandCode + " (模糊) 到 " + spcode;

                if (this.CommandType == "6")
                    return "自定义" + this.CommandCode + " (模糊) 到 " + spcode;

                return this.CommandTypeName + " " + this.CommandCode;
            }
        }

        public static List<SPClientChannelSettingWrapper> GetSettingByChannel(SPChannelWrapper spChannelWrapper)
        {
            return SPClientChannelSettingWrapper.ConvertToWrapperList(businessProxy.GetSettingByChannel(spChannelWrapper.entity));
        }


        public static List<SPChannelWrapper> GetChannelByClient(SPClientWrapper spClientWrapper)
        {
            return SPChannelWrapper.ConvertToWrapperList(businessProxy.GetChannelByClient(spClientWrapper.entity));
        }

        public static List<SystemUserWrapper> GetAvailableUser()
        {
            List<SystemUserWrapper> users = SystemUserWrapper.GetAllUserByRoleName("SPDownUser");

            return users;
        }


        public bool IsMacth(Hashtable requestValues, Hashtable fieldMappings)
        {
            string columnName = "ywid";

            if (!string.IsNullOrEmpty(this.CommandColumn))
            {
                columnName = this.CommandColumn;
            }

            string ywid = SPChannelWrapper.GetMappedParamValueFromRequest(requestValues, columnName, fieldMappings);

            return this.MatchByYWID(ywid);
        }

        public bool IsMacthSPCode(Hashtable requestValues, Hashtable fieldMappings,string cpid)
        {
            string columnName = "cpid";

            if (!string.IsNullOrEmpty(cpid))
            {
                columnName = cpid;
            }

            string spcode = SPChannelWrapper.GetMappedParamValueFromRequest(requestValues, columnName, fieldMappings);

            return spcode.Trim().ToLower().Equals(this.ChannelCode);
        }



        public bool IsMacthByYWID(string ywid)
        {
            return this.MatchByYWID(ywid);
        }

        public bool IsMacthSPCode(string cpid)
        {
            return cpid.Trim().ToLower().Equals(this.ChannelCode);
        }
        public bool MatchByYWID(string ywid)
        {
            switch (this.CommandType)
            {
                case "1":
                    return ywid.ToLower().Equals(this.CommandCode.ToLower());
                case "2":
                    return ywid.ToLower().Contains(this.CommandCode.ToLower());
                case "3":
                    return ywid.ToLower().StartsWith(this.CommandCode.ToLower());
                case "4":
                    return ywid.ToLower().EndsWith(this.CommandCode.ToLower());
                case "5":
                    return Regex.IsMatch(ywid.ToLower(), this.CommandCode.ToLower());
                case "6":
                    string newRegCommandCode = this.CommandCode.ToLower().Replace("*", "[S]*").Replace("?", "[S]{1}");
                    return Regex.IsMatch(ywid.ToLower(), newRegCommandCode,RegexOptions.IgnoreCase);
                case "7":
                    return true;
            }
            return false;
        }

        public string CommandTypeName
        {
            get
            {
                switch (this.CommandType)
                {
                    case "1":
                        return "完全匹配";
                    case "2":
                        return "包含";
                    case "3":
                        return "以开头";
                    case "4":
                        return "以结尾";
                    case "5":
                        return "正则表达式";
                    case "6":
                        return "自定义解析";
                    case "7":
                        return "无条件匹配";
                }
                return "未知类型";
            }
        }


        private bool CaculteRandom(int rate)
        {
            Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            int result = random.Next(0, 100);

            return (result <= rate);
        }

        public const int AddRate = 30;
        public const int MaxInterceptRate = 75;

        public bool CaculteIsIntercept(SPPaymentInfoWrapper paymentInfo)
        {
            int interceptRate = 0;

            if(this.DefaultNoInterceptCount<0)
            {
                this.DefaultNoInterceptCount = 0;
            }

            if (this.DefaultNoInterceptCount>0)
            {
                this.DefaultNoInterceptCount = this.DefaultNoInterceptCount - 1;

                Update(this);

                return false;
            }

            if(this.InterceptRate.HasValue)
            {
                interceptRate = this.InterceptRate.Value;
            }

            bool isIntercept = CaculteRandom(interceptRate);

            //如果没有扣除，如果该通道日总量有限制，超过了日总量，必须改成扣除
            if (!isIntercept && this.HasDayTotalLimit.HasValue && this.HasDayTotalLimit.Value)
            {
                if (this.DayTotalLimit.HasValue && this.DayTotalLimit.Value > 0)
                {
                    int todayPaymentCount = CacultePaymentCount(System.DateTime.Now.Date, this.Id);

                    if(todayPaymentCount>=this.DayTotalLimit.Value)
                        isIntercept = true;
                }
            }

            //如果是扣除的，如果该通道有号码日限制月限制，超过日限月限制的，先检查月限制，超过月限制乘以扣率，则放行（直接返回不检查日限制）
            //没有超过，在检查日限制，超过日限制乘以扣率，则放行

            if (isIntercept)
            {
                if (this.HasDayMonthLimit.HasValue && this.HasDayMonthLimit.Value && this.MonthLimitCount.HasValue && this.MonthLimitCount.Value>0)
                {
                    int todayMonthPhoneCount = CaculteMonthPhoneCount(System.DateTime.Now.Date, this.Id,paymentInfo.MobileNumber);

                    //int maxMonthPhoneCount = Convert.ToInt32(Math.Floor((double) this.MonthLimitCount.Value*(double) interceptRate/100d));

                    //if (maxMonthPhoneCount < 1)
                    //    maxMonthPhoneCount = 1;

                    int maxMonthPhoneCount = this.MonthLimitCount.Value;

                    if (todayMonthPhoneCount + 1 > maxMonthPhoneCount)
                    {
                        isIntercept = false;
                        return isIntercept;
                    }
                }
                if (this.HasDayMonthLimit.HasValue && this.HasDayMonthLimit.Value && this.DayLimitCount.HasValue && this.DayLimitCount.Value > 0)
                {
                    int todayDayPhoneCount = CaculteDayPhoneCount(System.DateTime.Now.Date, this.Id, paymentInfo.MobileNumber);

                    //int maxDayPhoneCount = Convert.ToInt32(Math.Floor((double) this.DayLimitCount.Value*(double) interceptRate/100d));

                    //if (maxDayPhoneCount < 1)
                    //    maxDayPhoneCount = 1;

                    int maxDayPhoneCount = this.DayLimitCount.Value;

                    if (todayDayPhoneCount + 1 > maxDayPhoneCount)
                    {
                        isIntercept = false;
                        return isIntercept;
                    }
                }
            }

            //this.HasDayMonthLimit.HasValue && this.HasDayMonthLimit.Value
                //if (this.DayLimitCount.HasValue && this.DayLimitCount.Value > 0)
                //    isIntercept = CaculteDayPhoneIntercept(paymentInfo);

                //if (!isIntercept)
                //    return isIntercept;

                //if (this.DayLimitCount.HasValue && this.DayLimitCount.Value > 0)
                //    isIntercept = CaculteMonthPhoneIntercept(paymentInfo);

                //if (!isIntercept)
                //    return isIntercept;
            //if ()
            //{

            //        isIntercept = CaculteDayTotalPhoneIntercept();

            //    if (!isIntercept)
            //        return isIntercept;
            //}

            return isIntercept;

            //if(interceptRate==0)
            //    return false;

            //decimal rate = GetToDayRate(this.ClinetID.Id, this.ChannelID.Id);

            //if (rate < Convert.ToDecimal(interceptRate))
            //{
            //    return CaculteRandom(Math.Min(interceptRate + AddRate, MaxInterceptRate));
            //}
            //else
            //{
            //    return false;
            //}
        }

        private int CaculteDayPhoneCount(DateTime dateTime, int clientChannelID, string mobileNumber)
        {
            return businessProxy.CaculteDayPhoneCount(dateTime, clientChannelID, mobileNumber);
        }

        private int CaculteMonthPhoneCount(DateTime dateTime, int clientChannelID, string mobileNumber)
        {
            return businessProxy.CaculteMonthPhoneCount(dateTime, clientChannelID, mobileNumber);
        }

        private int CacultePaymentCount(DateTime dateTime, int clientChannelID)
        {
            return businessProxy.CacultePaymentCount(dateTime, clientChannelID);
        }

 

 

        public SPClientChannelSettingWrapper ParentClientChannelSetting
        {
            get
            {
                if (this.CommandType == "2" || this.CommandType == "3" || this.CommandType == "4")
                {
                    List<SPClientChannelSettingWrapper> clientChannelSettings = FindAllByChannelID(this.ChannelID);

                    SPClientChannelSettingWrapper parentClientChannelSetting = (from rap in clientChannelSettings
                                                                                where
                                                                                    (rap.ChannelID.Id == this.ChannelID.Id && rap.ChannelCode == this.ChannelCode &&
                                                                                     !this.CommandCode.Equals(rap.CommandCode) && this.CommandCode.Contains(rap.CommandCode))
                                                                                orderby rap.CommandCode.Length
                                                                                select rap).FirstOrDefault();

                    if (parentClientChannelSetting == null)
                        return this;

                    return parentClientChannelSetting;
                }
                else
                {
                   return this;                 
                }
            }
        }

        public bool SendMsg(SPPaymentInfoWrapper spPaymentInfo)
        {
            string requesturl = "";

            //if (spPaymentInfo.IsSycnData.HasValue && spPaymentInfo.IsSycnData.Value && string.IsNullOrEmpty(spPaymentInfo.SSycnDataUrl))
            //{
            //    requesturl = spPaymentInfo.SSycnDataUrl;
            //}
            //else
            //{
           requesturl = BulidUrl(spPaymentInfo);
            //}

            spPaymentInfo.IsSycnData = true;

            spPaymentInfo.SSycnDataUrl = requesturl;

            string errorMessage = string.Empty;

            bool sendOk = SendRequest(requesturl, 10000, "ok", out errorMessage);

            return sendOk;
        }

        public string BulidUrl(SPPaymentInfoWrapper spPaymentInfo)
        {
            NameValueCollection queryString = HttpUtility.ParseQueryString(string.Empty);

            List<SPClientChannelSycnParamsWrapper> clientFieldMappings = this.GetFieldMappings();

            if (clientFieldMappings.Count > 0)
            {
                foreach (SPClientChannelSycnParamsWrapper clientFieldMapping in clientFieldMappings)
                {
                    switch (clientFieldMapping.MappingParams)
                    {
                        case "mid":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Mid);
                            break;
                        case "mobile":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.MobileNumber);
                            break;
                        case "port":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Port);
                            break;
                        case "ywid":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Ywid);
                            break;
                        case "msg":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Message);
                            break;
                        case "cpid":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Cpid);
                            break;
                        case "linkid":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Linkid);
                            break;
                        case "dest":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.Dest);
                            break;
                        case "extendfield1":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField1);
                            break;
                        case "extendfield2":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField2);
                            break;
                        case "extendfield3":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField3);
                            break;
                        case "extendfield4":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField4);
                            break;
                        case "extendfield5":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField5);
                            break;
                        case "extendfield6":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField6);
                            break;
                        case "extendfield7":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField7);
                            break;
                        case "extendfield8":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField8);
                            break;
                    }
                }
            }
            else
            {
                List<SPChannelDefaultClientSycnParamsWrapper> channelFieldMappings = this.ChannelID.GetAllEnableDefaultSendParams();


                foreach (SPChannelDefaultClientSycnParamsWrapper channelDefaultClientSycnParam in channelFieldMappings)
                {
                    switch (channelDefaultClientSycnParam.MappingParams)
                    {
                        case "mid":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.Mid);
                            break;
                        case "mobile":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.MobileNumber);
                            break;
                        case "port":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.Port);
                            break;
                        case "ywid":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.Ywid);
                            break;
                        case "msg":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.Message);
                            break;
                        case "cpid":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.Cpid);
                            break;
                        case "linkid":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.Linkid);
                            break;
                        case "dest":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.Dest);
                            break;
                        case "extendfield1":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.ExtendField1);
                            break;
                        case "extendfield2":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.ExtendField2);
                            break;
                        case "extendfield3":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.ExtendField3);
                            break;
                        case "extendfield4":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.ExtendField4);
                            break;
                        case "extendfield5":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.ExtendField5);
                            break;
                        case "extendfield6":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.ExtendField6);
                            break;
                        case "extendfield7":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.ExtendField7);
                            break;
                        case "extendfield8":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.ExtendField8);
                            break;
                    }
                }
            }

            Uri uri = new Uri(this.SyncDataUrl);

            if (string.IsNullOrEmpty(queryString.ToString()))
            {
                return this.SyncDataUrl;
            }

            if (!string.IsNullOrEmpty(uri.Query.Trim()))
                return string.Format("{0}&{1}", this.SyncDataUrl, queryString.ToString()); 

            return string.Format("{0}?{1}", this.SyncDataUrl, queryString.ToString());
        }



        public List<SPClientChannelSycnParamsWrapper> GetFieldMappings()
        {
            return SPClientChannelSycnParamsWrapper.ConvertToWrapperList(businessProxy.GetAllEnableParams(this.entity));
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

                    return responseText.Trim().ToLower().Equals(okMessage);
                }

                return false;
            }
            catch (Exception e)
            {
                errorMessage = e.Message;
                return false;
            }
        }

        private void BulidParams(NameValueCollection queryString, string key, string value)
        {
            queryString.Add(key,value);
        }


        public NameValueCollection GetAllSendParams()
        {
            NameValueCollection sendParams = new NameValueCollection();

            List<SPClientChannelSycnParamsWrapper> clientFieldMappings = this.GetFieldMappings();

            if (clientFieldMappings.Count > 0)
            {
                foreach (SPClientChannelSycnParamsWrapper clientFieldMapping in clientFieldMappings)
                {
                    sendParams.Add(clientFieldMapping.Name, clientFieldMapping.MappingParams);
                }
            }
            else
            {
                List<SPChannelDefaultClientSycnParamsWrapper> channelFieldMappings = this.ChannelID.GetAllEnableDefaultSendParams();

                foreach (SPChannelDefaultClientSycnParamsWrapper channelDefaultClientSycnParam in channelFieldMappings)
                {
                    sendParams.Add(channelDefaultClientSycnParam.Name, channelDefaultClientSycnParam.MappingParams);
                }
            }

            return sendParams;
        }



        public bool SendMsg(SPPaymentInfoWrapper spPaymentInfo, out string errorMessage)
        {
            string requesturl = BulidUrl(spPaymentInfo);

            bool sendOk = SendRequest(requesturl, 10000, "ok", out errorMessage);

            return sendOk;
        }



        public bool SendMsgAndUpdate(SPPaymentInfoWrapper spPaymentInfoWrapper, out string errorMessage)
        {
            spPaymentInfoWrapper.SucesssToSend = SendMsg(spPaymentInfoWrapper, out errorMessage);

            SPPaymentInfoWrapper.Update(spPaymentInfoWrapper);

            return spPaymentInfoWrapper.SucesssToSend.Value;
        }

        public static List<SPClientChannelSettingWrapper> GetAllNeedRendSetting()
        {
            return ConvertToWrapperList(businessProxy.GetAllNeedRendSetting());
        }

 

        public static List<SPClientChannelSettingWrapper> GetSettingByClient(SPClientWrapper spClientWrapper)
        {
            return ConvertToWrapperList(businessProxy.GetSettingByClient(spClientWrapper.entity));
        }

        public void ChangeClientUser(string clientName, string clientAlias, string userLoginId, int userID)
        {
            businessProxy.ChangeClientUser(this.entity, clientName, clientAlias, userLoginId, userID);
        }

        public void ResetAllSycnCount(DateTime date)
        {
            businessProxy.ResetAllSycnCount(this.entity, date);
        }

        public int GetSycnFailedCount(DateTime date)
        {
            return businessProxy.GetSycnFailedCount(this.entity, date);
        }

        public void ResetIntercept(DateTime date, int dataCount)
        {
            businessProxy.ResetIntercept(this.entity, date, dataCount);
        }

        public static List<SPClientChannelSettingWrapper> FindAllByOrderByAndFilterAndChannelIDAndCodeAndPort(string sortFieldName, bool isDesc, int channleId, string mo, string port, int pageIndex, int pageSize, out int recordCount)
        {
            return SPClientChannelSettingWrapper.ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilterAndChannelIDAndCodeAndPort(sortFieldName, isDesc, channleId, mo, port, pageIndex, pageSize, out   recordCount));
        }


        private List<SPClientChannelSettingFiltersWrapper> filters;

        public List<SPClientChannelSettingFiltersWrapper> Filters
        {
            get
            {
                if (filters == null)
                    filters = SPClientChannelSettingFiltersWrapper.FindAllByClientChannelSettingID(this);
                return filters;
            }
        }


        public bool InArea(PhoneAreaInfo phoneAreaInfo)
        {
            if (Filters == null || Filters.Count <= 0)
                return false;

            List<SPClientChannelSettingFiltersWrapper> filters =
                SPClientChannelSettingFiltersWrapper.FindAllByClientChannelSettingID(this);

            return filters.Exists(p => p.ParamsName.Trim().ToLower() == "province" && p.FilterValue == phoneAreaInfo.Province);
        }
    }
}
