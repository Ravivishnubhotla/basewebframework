
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using LD.SPPipeManage.Bussiness.Commons;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Utility;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
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

        public static List<SPChannelWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPChannelWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }


        public static List<SPChannelWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }

        #endregion

        public static string[] fields = new string[] { "cpid", "mid", "mobile", "port", "ywid", "msg", "linkid", "dest", "price", "extendfield1", "extendfield2", "extendfield3", "extendfield4", "extendfield5", "extendfield6", "extendfield7", "extendfield8", "extendfield9" };

        public static SPChannelWrapper GetChannelByPath(string fileName)
        {
            int id = 0;

            int.TryParse(fileName, out id);

            SPChannelWrapper channel = null;

            if (id != 0)
            {
                channel = SPChannelWrapper.FindById(id);
            }

            if (channel != null)
            {
                return channel;
            }

            return ConvertEntityToWrapper(businessProxy.FindByAlias(fileName));
        }

        public bool ProcessRequest(Hashtable hashtable, string ip, string query, HttpRequest request)
        {
            Hashtable fieldMappings = this.GetFieldMappings();

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


            if (string.IsNullOrEmpty(linkid) && this.IsAllowNullLinkID.HasValue && this.IsAllowNullLinkID.Value)
            {
                linkid = Guid.NewGuid().ToString();
            }

            if (string.IsNullOrEmpty(linkid))
            {
                Logger.Error("not link id  " + this.Name + " channel setting.");

                SPFailedRequestWrapper.SaveFailedRequest(request, ip, query, "not link id  " + this.Name + " channel setting.", this.Id, 0);

                return false;
            }


            string content = query;


            Hashtable exparams = GetEXParamsValue(hashtable);

            //SPClientChannelSettingWrapper channelSetting = GetClientChannelSettingFromYWID(ywid);

            SPClientChannelSettingWrapper channelSetting = GetClientChannelSettingFromRequestValue(hashtable, fieldMappings);

            if (channelSetting != null)
            {

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
                paymentInfo.CreateDate = System.DateTime.Now;
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

                try
                {
                    SPInterceptRateWrapper.InsertRate(channelSetting.ChannelID, channelSetting.ClinetID, paymentInfo.IsIntercept.Value);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }



                //SPInterceptRateWrapper.InsertRecord(paymentInfo);

                if (!paymentInfo.IsIntercept.Value)
                {
                    if (!string.IsNullOrEmpty(channelSetting.SyncDataUrl))
                        paymentInfo.SucesssToSend = channelSetting.SendMsg(paymentInfo);
                    //paymentInfo.SucesssToSend = channelSetting.ClinetID.SendMsg(cpid, mid, mobile, port, ywid, msg, linkid, dest, price, exparams);
                    else
                        paymentInfo.SucesssToSend = false;
                }
                else
                {
                    paymentInfo.SucesssToSend = false;
                }

                try
                {
                    SPPaymentInfoWrapper.Save(paymentInfo);
                    return true;
                }
                catch (Exception ex)
                {
                    Exception innerException = ex;

                    while (innerException.InnerException != null)
                    {
                        innerException = innerException.InnerException;
                    }

                    SqlException sqlException = innerException as SqlException;

                    if (sqlException != null && sqlException.Number == 2627)
                    {
                        Logger.Error("Process Request Error:linkid repeater");
                        throw new Exception("Process Request Error:linkid repeater");
                    }

                    Logger.Error("Process Request Error:Isert date failed  " + ex.Message);
                    throw new Exception("Process Request Error:Isert date failed  " + ex.Message);
                }


            }
            else
            {
                Logger.Error("Process Request Error:Can't find match Client  " + this.Name + " client setting.");

                SPFailedRequestWrapper.SaveFailedRequest(request, ip, content, "Process Request Error:Can't find match Client  " + this.Name + " client setting.", this.Id, 0);

                return false;
            }


        }

        public List<SPChannelParamsWrapper> GetAllShowParams()
        {
            return SPChannelParamsWrapper.ConvertToWrapperList(businessProxy.GetAllShowParams(this.entity));
        }

        public List<SPChannelParamsWrapper> GetAllEnableParams()
        {
            return SPChannelParamsWrapper.ConvertToWrapperList(businessProxy.GetAllEnableParams(this.entity));
        }

        public Hashtable GetFieldMappings()
        {
            Hashtable mappingFields = new Hashtable();

            List<SPChannelParamsWrapper> spChannelParamsWrappers = SPChannelParamsWrapper.ConvertToWrapperList(businessProxy.GetAllEnableParams(this.entity));

            foreach (string field in fields)
            {
                string findFeild = field.ToLower();

                SPChannelParamsWrapper channelParamsWrapper =
                    spChannelParamsWrappers.Find(p => (p.ParamsMappingName.Equals(findFeild.ToLower())));

                if (channelParamsWrapper == null)
                {
                    mappingFields.Add(findFeild.ToLower(), findFeild.ToLower());
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

        //private SPClientChannelSettingWrapper GetClientChannelSettingFromYWID(string ywid)
        //{
        //    List<SPClientChannelSettingWrapper> clientChannelSettings = SPClientChannelSettingWrapper.GetSettingByChannel(this);

        //    SPClientChannelSettingWrapper macthClientChannelSetting = (from cc in clientChannelSettings where (cc.MatchByYWID(ywid)) orderby cc.OrderIndex descending select cc).FirstOrDefault();
            
        //    return macthClientChannelSetting;
        //}

        public List<SPClientChannelSettingWrapper> GetAllClientChannelSetting()
        {
            return SPClientChannelSettingWrapper.GetSettingByChannel(this);
        }

        private SPClientChannelSettingWrapper GetClientChannelSettingFromRequestValue(Hashtable requestValues, Hashtable fieldMappings)
        {
            List<SPClientChannelSettingWrapper> clientChannelSettings = GetAllClientChannelSetting();

            SPClientChannelSettingWrapper macthClientChannelSetting = (from cc in clientChannelSettings where (cc.IsMacth(requestValues, fieldMappings)) orderby cc.OrderIndex descending select cc).FirstOrDefault();

            return macthClientChannelSetting;
        }

        private SPClientChannelSettingWrapper GetMacthRuleChannelSetting(SPClientChannelSettingWrapper channelSetting, Hashtable requestValues, Hashtable fieldMappings)
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

        public static string GetMappedParamValueFromRequest(Hashtable requestValues, string mapName, Hashtable fieldMappings)
        {
            string queryKey = mapName.ToLower();

            if (fieldMappings.ContainsKey(mapName))
            {
                queryKey = (string)fieldMappings[mapName];
            }

            if (!requestValues.ContainsKey(queryKey))
                return "";

            return requestValues[queryKey].ToString();
        }

        public ChannelStatus CStatus
        {
            get
            {
                switch (this.Status)
                {
                    case 0:
                        return ChannelStatus.Run;
                        break;
                    case 1:
                        return ChannelStatus.Stop;
                        break;
                    case 2:
                        return ChannelStatus.Disable;
                        break;
                    default:
                        return ChannelStatus.Disable;
                        break;
                }
            }
        }

        public string CStatusString
        {
            get
            {
                switch (this.CStatus)
                {
                    case ChannelStatus.Run:
                        return "运行";
                        break;
                    case ChannelStatus.Stop:
                        return "暂停";
                        break;
                    case ChannelStatus.Disable:
                        return "禁用";
                        break;
                    default:
                        return "禁用";
                        break;
                }
            }
        }

        public string GetOkCode()
        {
            return "ok";
        }

        public string InterfaceUrl
        {
            get
            {
                HttpContext context = HttpContext.Current;

                if (context == null)
                    return "";

                if (context.Request.Url.Port == 80)
                    return string.Format("{0}://{1}/SPSInterface/{2}Recieved.ashx", context.Request.Url.Scheme, context.Request.Url.Host, this.FuzzyCommand);

                return string.Format("{0}://{1}:{2}/SPSInterface/{3}Recieved.ashx", context.Request.Url.Scheme, context.Request.Url.Host,
                                     context.Request.Url.Port, this.FuzzyCommand);

            }
        }

        public string CodeList
        {
            get
            {
                List<SPClientChannelSettingWrapper> clientChannelSettings = GetAllClientChannelSetting();

                StringBuilder sb = new StringBuilder();

                foreach (SPClientChannelSettingWrapper channelSetting in clientChannelSettings)
                {
                    string interceptRate = "<font color='red'>0</font>";

                    string syncDataUrl = "";

                    if (!string.IsNullOrEmpty(channelSetting.SyncDataUrl))
                    {
                        syncDataUrl = " ,<font color='blue'>下家同步地址：" + channelSetting.SyncDataUrl + "</font>";
                    }

                    if (channelSetting.InterceptRate.HasValue && channelSetting.InterceptRate.Value>0)
                    {
                        interceptRate = channelSetting.InterceptRate.Value.ToString();
                    }

                    string line = string.Format("名称 ‘{0}’ , 下家 ‘{2}’ , 指令 '{1}', 扣率  {3} , {4}<br/>", channelSetting.Name,
                                                channelSetting.ChannelClientRuleMatch, channelSetting.ClientName,
                                                interceptRate, syncDataUrl);

 
                    sb.Append(line);
                }

                return sb.ToString();

            }
        }

        public string ParamsList
        {
            get
            {
                List<SPChannelParamsWrapper> clientChannelParams = this.GetAllEnableParams();

                StringBuilder sb = new StringBuilder();

                foreach (SPChannelParamsWrapper paramsWrapper in clientChannelParams)
                {
                    sb.AppendFormat("参数 {0} - {2}：{1} ,<br/>", paramsWrapper.Name, paramsWrapper.Description, paramsWrapper.ParamsMappingName);
                }

                return sb.ToString();

            }
        }

        public DataTable BuildChannelRecordTable()
        {
            DataTable record = new DataTable();

            record.Columns.Add("RecordID", typeof(int));
            record.Columns.Add("CreateDate", typeof(DateTime));
            record.Columns.Add("Province", typeof(string));
            record.Columns.Add("City", typeof(string));

            foreach (string field in fields)
            {
                record.Columns.Add(field);
            }

            record.AcceptChanges();

            return record;
        }

        public void SaveStatReport(Hashtable hashtable, string recievdData,string query,string stat)
        {
            Hashtable fieldMappings = this.GetFieldMappings();

            string linkid = GetMappedParamValueFromRequest(hashtable, "linkid", fieldMappings);

            SPStatReportWrapper statReport = new SPStatReportWrapper();
            statReport.ChannelID = this.Id;
            statReport.LinkID = linkid;
            statReport.CreateDate = System.DateTime.Now;
            statReport.QueryString = query;
            statReport.RequestContent = recievdData;
            statReport.Stat = stat;

            SPStatReportWrapper.Save(statReport);
        }
    }
}
