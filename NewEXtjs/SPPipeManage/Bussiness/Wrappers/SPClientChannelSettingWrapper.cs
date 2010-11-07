
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
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

                if (this.CommandType == "1")
                    return this.CommandCode + " (精准) 到 " + spcode;

                if (this.CommandType == "3")
                    return this.CommandCode + " (模糊) 到 " + spcode;
 
                return columnName + " " + this.CommandTypeName + " " + this.CommandCode;
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
                    return false;
                case "6":
                    return false;
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

        public bool CaculteIsIntercept()
        {
            decimal rate = GetToDayRate(this.ClinetID.Id, this.ChannelID.Id);

            if (rate < Convert.ToDecimal(this.InterceptRate))
                return true;
            else
                return false;


            //Random random = new Random(unchecked((int)DateTime.Now.Ticks));

            //int result = random.Next(0, 100);

            //return (result <= this.InterceptRate);
        }

        private decimal GetToDayRate(int clinetID, int channelID)
        {
            return businessProxy.GetToDayRate(clinetID, channelID);
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
                        case "extendfield9":
                            BulidParams(queryString, clientFieldMapping.Name, spPaymentInfo.ExtendField9);
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
                        case "extendfield9":
                            BulidParams(queryString, channelDefaultClientSycnParam.Name, spPaymentInfo.ExtendField9);
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
            queryString.Add(key, HttpUtility.UrlEncode(value));
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
    }
}
