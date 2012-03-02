
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Utility;
using Spring.Data.NHibernate.Support;
using LD.SPPipeManage.Bussiness.UrlSender;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
    public enum DataType
    {
        All,
        Intercept,
        Down,
        DownSycn,
        DownNotSycn,
        SycnFailed
    }


	[Serializable]
    public partial class SPPaymentInfoWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPPaymentInfoWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPPaymentInfoWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPPaymentInfoWrapper obj)
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

        public static void Delete(SPPaymentInfoWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPPaymentInfoWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPPaymentInfoWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPPaymentInfoWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPPaymentInfoWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPPaymentInfoEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPPaymentInfoWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPPaymentInfoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPPaymentInfoWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPPaymentInfoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

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

        public string ClientName
        {
            get
            {
                if (this.ClientID != null)
                {
                    return this.ClientID.Name;
                }
                return "";
            }
        }

        public string ClientAlias
        {
            get
            {
                if (this.ClientID != null)
                {
                    return this.ClientID.Alias;
                }
                return "";
            }
        }

        public string ClientGroupName
        {
            get
            {
                if (this.ClientID != null)
                {
                    if (this.ClientID.SPClientGroupID!=null)
                        return this.ClientID.SPClientGroupID.Name;
                }
                return "";
            }
        }

        public string Code
        {
            get
            {
                if (this.ClientID != null)
                {
                    if(this.ClientID.DefaultClientChannelSetting!=null)
                        return this.ClientID.DefaultClientChannelSetting.ChannelClientCode;
                }
                return "";
            }
        }


	    public static List<SPPaymentInfoWrapper> FindAllByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime, string sortFieldName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
	    {
	        return
                ConvertToWrapperList(businessProxy.FindAllByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(channelId, clientId,
	                                                                                              startDateTime,
	                                                                                              enddateTime,
	                                                                                              sortFieldName, isDesc,
	                                                                                              pageIndex, pageSize,
	                                                                                              out recordCount));

	    }

        public static int FindAllPaymentCountByDateAndType(DateTime startDate, DateTime endDate, int channleClientID, string dataType)
        {
            return businessProxy.FindAllPaymentCountByDateAndType(startDate, endDate, channleClientID, dataType);
        }

	    public static DataSet FindAllPaymentIDByDateAndType(DateTime startDate, DateTime endDate, int channleClientID, string dataType, int limit)
        {
            return businessProxy.FindAllPaymentIDByDateAndType(startDate,   endDate,   channleClientID,   dataType,   limit);
        }


	    public static DataTable FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime, string sortFieldName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            if(channelId==0)
                throw new ArgumentException(" channelId not allow 0.");

            SPChannelWrapper channelWrapper = SPChannelWrapper.FindById(channelId);

            List<SPPaymentInfoWrapper> spPaymentInfoWrappers = ConvertToWrapperList(businessProxy.FindAllByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(channelId, clientId,
                                                                                                  startDateTime,
                                                                                                  enddateTime,
                                                                                                  sortFieldName, isDesc,
                                                                                                  pageIndex, pageSize,
                                                                                                  out recordCount));

            DataTable channelRecordTable = channelWrapper.BuildChannelRecordTable();

            for (int i = 0; i < spPaymentInfoWrappers.Count; i++)
            {
                DataRow dr = channelRecordTable.NewRow();

                dr.BeginEdit();

                dr["RecordID"] = spPaymentInfoWrappers[i].Id;
                dr["CreateDate"] = spPaymentInfoWrappers[i].CreateDate;

                foreach (string field in SPChannelWrapper.fields)
                {
                    dr[field] = spPaymentInfoWrappers[i].GetMappingValue(field);
                }

                dr.EndEdit();

                channelRecordTable.Rows.Add(dr);


            }

            channelRecordTable.AcceptChanges();

            return channelRecordTable;

        }



        public static List<SPPaymentInfoWrapper> FindAllByOrderByAndCleintIDAndChanneLIDAndDate
    (int channelId, int clientId, DateTime startDateTime, DateTime enddateTime, DataType dataType, string sortFieldName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            if (channelId == 0)
                throw new ArgumentException(" channelId not allow 0.");

            SPChannelWrapper channelWrapper = SPChannelWrapper.FindById(channelId);

            return ConvertToWrapperList(businessProxy.FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDate(channelId, clientId,
                                                                                                  startDateTime,
                                                                                                  enddateTime, dataType,
                                                                                                  sortFieldName, isDesc,
                                                                                                  pageIndex, pageSize,
                                                                                                  out recordCount));

 

        }
 
	    public static DataTable FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDate
            (int channelId, int clientId, DateTime startDateTime, DateTime enddateTime, DataType dataType, string sortFieldName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            if (channelId == 0)
                throw new ArgumentException(" channelId not allow 0.");

            SPChannelWrapper channelWrapper = SPChannelWrapper.FindById(channelId);

            List<SPPaymentInfoWrapper> spPaymentInfoWrappers = ConvertToWrapperList(businessProxy.FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDate(channelId, clientId,
                                                                                                  startDateTime,
                                                                                                  enddateTime,dataType,
                                                                                                  sortFieldName, isDesc,
                                                                                                  pageIndex, pageSize,
                                                                                                  out recordCount));

            DataTable channelRecordTable = channelWrapper.BuildChannelRecordTable();

            for (int i = 0; i < spPaymentInfoWrappers.Count; i++)
            {
                DataRow dr = channelRecordTable.NewRow();

                dr.BeginEdit();

                dr["RecordID"] = spPaymentInfoWrappers[i].Id;
                dr["CreateDate"] = spPaymentInfoWrappers[i].CreateDate;
                dr["Province"] = spPaymentInfoWrappers[i].Province;
                dr["City"] = spPaymentInfoWrappers[i].City;
                dr["SycnRetryTimes"] = spPaymentInfoWrappers[i].SycnRetryTimes;
                dr["IsSycnData"] = spPaymentInfoWrappers[i].IsSycnData;
                dr["SucesssToSend"] = spPaymentInfoWrappers[i].SucesssToSend;
                dr["SendUrl"] = spPaymentInfoWrappers[i].SSycnDataUrl;

                foreach (string field in SPChannelWrapper.fields)
                {
                    dr[field] = spPaymentInfoWrappers[i].GetMappingValue(field);
                }

                dr.EndEdit();

                channelRecordTable.Rows.Add(dr);


            }

            channelRecordTable.AcceptChanges();

            return channelRecordTable;

        }



	    public string Values
	    {
	        get
	        {
                if (string.IsNullOrEmpty(this.RequestContent))
                    return "";

	            string values;

                if (this.RequestContent.Trim().StartsWith("["))
                {
                    values =
                        SerializeUtil.ToJson(GetValues(SerializeUtil.JsonDeserialize2<Hashtable>(this.RequestContent)));
                }
                else
                {
                    values =
                  SerializeUtil.ToJson(GetValues(SerializeUtil.JsonDeserialize<Hashtable>(this.RequestContent)));              
                }
	            return values;
	        }

	    }

 

	    public Hashtable GetValues(Hashtable hashtable)
	    {
	        Hashtable hb = this.ChannelID.GetFieldMappings();

            Hashtable nhb = new Hashtable();

            foreach (DictionaryEntry entry in hb)
	        {
	            if(hashtable.ContainsKey(entry.Value))
	            {
                    if (!nhb.ContainsKey(entry.Value))
                        nhb.Add(entry.Value, hashtable[entry.Value]);
	            }
	        }

	        return nhb;
	    }


 


        public string GetMappingValue(string mappingName)
        {
            switch (mappingName)
            {
                case "cpid":
                    return this.Cpid;
                case "mid":
                    return this.Mid;
                case "mobile":
                    return this.MobileNumber;
                case "port":
                    return this.Port;
                case "ywid":
                    return this.Ywid;
                case "msg":
                    return this.Message;
                case "linkid":
                    return this.Linkid;
                case "dest":
                    return this.Dest;
                case "price":
                    return this.Price;
                case "extendfield1":
                    return this.ExtendField1;
                case "extendfield2":
                    return this.ExtendField2;
                case "extendfield3":
                    return this.ExtendField3;
                case "extendfield4":
                    return this.ExtendField4;
                case "extendfield5":
                    return this.ExtendField5;
                case "extendfield6":
                    return this.ExtendField6;
                case "extendfield7":
                    return this.ExtendField7;
                case "extendfield8":
                    return this.ExtendField8;
                default:
                    return "";
            }
        }

        public void SetMappingValue(string mappingName, string sValue)
        {
            switch (mappingName)
            {
                case "cpid":
                    this.Cpid = sValue;
                    break;
                case "mid":
                    this.Mid = sValue;
                    break;
                case "mobile":
                    this.MobileNumber = sValue;
                    break;
                case "port":
                    this.Port = sValue;
                    break;
                case "ywid":
                    this.Ywid = sValue;
                    break;
                case "msg":
                    this.Message = sValue;
                    break;
                case "linkid":
                    this.Linkid = sValue;
                    break;
                case "dest":
                    this.Dest = sValue;
                    break;
                case "price":
                    this.Price = sValue;
                    break;
                case "extendfield1":
                    this.ExtendField1 = sValue;
                    break;
                case "extendfield2":
                    this.ExtendField2 = sValue;
                    break;
                case "extendfield3":
                    this.ExtendField3 = sValue;
                    break;
                case "extendfield4":
                    this.ExtendField4 = sValue;
                    break;
                case "extendfield5":
                    this.ExtendField5 = sValue;
                    break;
                case "extendfield6":
                    this.ExtendField6 = sValue;
                    break;
                case "extendfield7":
                    this.ExtendField7 = sValue;
                    break;
                case "extendfield8":
                    this.ExtendField8 = sValue;
                    break;
            }
        }

        public static List<SPPaymentInfoWrapper> FindAllNotSendData(int channelId, int clientId, DateTime startdate, DateTime endDate,int maxDataCount)
	    {
            return ConvertToWrapperList(businessProxy.FindAllNotSendData(channelId, clientId, startdate, endDate, maxDataCount));
	    }

        public static DataTable FindAllNotSendChannelClient()
        {
            return businessProxy.FindAllNotSendChannelClient();
        }

	    public void ReSend()
	    {
	        SPClientChannelSettingWrapper spClientChannelSettingWrapper = GetChannleClientSetting();

            this.SucesssToSend = spClientChannelSettingWrapper.SendMsg(this);

            Update(this);
	    }

        public SPClientChannelSettingWrapper GetChannleClientSetting()
        {
            if (this.ChannleClientID.HasValue && this.ChannleClientID.Value > 0)
            {
                return SPClientChannelSettingWrapper.FindById(this.ChannleClientID.Value);
            }

            List<SPClientChannelSettingWrapper> clientChannelSettings = this.ChannelID.GetAllClientChannelSetting();

            SPClientChannelSettingWrapper macthClientChannelSetting = (from cc in clientChannelSettings where (cc.ChannelID.Id == this.ChannelID.Id && cc.ClinetID.Id == this.ClientID.Id) orderby cc.OrderIndex descending select cc).FirstOrDefault();

            return macthClientChannelSetting;
        }

        public UrlSendTask BulidSendTask()
        {
            UrlSendTask sendTask = new UrlSendTask();

            sendTask.SendUrl = this.ClientID.DefaultClientChannelSetting.BulidUrl(this);
            sendTask.OkMessage = this.ClientID.DefaultClientChannelSetting.OkMessage;
            sendTask.PaymentID = this.Id;

            return sendTask;
        }



	    internal bool InsertPayment(out PaymentInfoInsertErrorType errorType)
        {
            errorType = PaymentInfoInsertErrorType.NoError;

            if (this.CheckHasLinkIDAndChannelID())
            {
                errorType = PaymentInfoInsertErrorType.RepeatLinkID;

                return false;
            }

            try
            {
                businessProxy.Save(this.entity);
                return true;
            }
            catch (Exception ex)
            {
                Exception innerEx = ex;

                while (innerEx.InnerException !=null)
                {
                    innerEx = innerEx.InnerException;
                }

                if (innerEx is SqlException && ((SqlException)innerEx).Number==2601)
                {
                    errorType = PaymentInfoInsertErrorType.RepeatLinkID;
                    return false;
                }

                throw ex;
            }
        }



        public static List<SPPaymentInfoWrapper> FindAllByOrderByAndSPClientGroupIDAndDateNoIntercept(int spClientGroupID, DateTime startDate, DateTime endDate, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
	    {

            return
                ConvertToWrapperList(businessProxy.FindAllByOrderByAndSPClientGroupIDAndDateNoIntercept(spClientGroupID,
                                                                                                  startDate,
                                                                                                  endDate,
                                                                                                  sortFieldName, isdesc,
                                                                                                  pageIndex, limit,
                                                                                                  out recordCount));

	    }

	    public static void RendAllData(DateTime resendDay)
	    {
            //using (new SessionScope())
            //{
                Logger.Info("开始重新发送失败同步数据");

                List<SPClientChannelSettingWrapper> allNeedResendChannleClientSetting = SPClientChannelSettingWrapper.GetAllNeedRendSetting();

                //Logger.Info(string.Format("读取设置成功，共{0}个配置需要重新发送", allNeedResendChannleClientSetting.Count));

                //foreach (SPClientChannelSettingWrapper channelSetting in allNeedResendChannleClientSetting)
                //{
                //    Logger.Info(string.Format("开始重新发送设置{0}-{1}请求", channelSetting.ChannelID.Name, channelSetting.ClinetID.Name));

                //    List<SPPaymentInfoWrapper> spReSendPaymentInfos = FindAllNotSendData(channelSetting.ChannelID.Id,
                //                                                                         channelSetting.ClinetID.Id, resendDay,
                //                                                                         resendDay);

                //    Logger.Info(string.Format("设置{0}-{1}开始，发送请求，共{2}条记录。", channelSetting.ChannelID.Name, channelSetting.ClinetID.Name, spReSendPaymentInfos.Count));

                //    int failedCount = 0;

                //    foreach (SPPaymentInfoWrapper reSendPaymentInfo in spReSendPaymentInfos)
                //    {
                //        int retryTimes = 0;

                //        bool requestOk = false;

                //        do
                //        {
                //            try
                //            {
                //                reSendPaymentInfo.ReSend();
                //                requestOk = true;
                //            }
                //            catch (Exception ex)
                //            {
                //                requestOk = false;
                //                Thread.Sleep(1000);
                //            }

                //            retryTimes++;

                //            if (retryTimes >= 3)
                //                break;

                //        } while (!requestOk);

                //        if (!requestOk)
                //            failedCount++;

                //    }

                //    Logger.Info(string.Format("设置{0}-{1}结束，失败{2}条记录。", channelSetting.ChannelID.Name, channelSetting.ClinetID.Name, failedCount));

                //}

                Logger.Info("重新发送失败同步数据结束");
            }
        //}

        public string ReBuildUrl()
        {
            return GetChannleClientSetting().BulidUrl(this);
        }

	    public static List<SPPaymentInfoWrapper> FindAllByOrderByAndClientIDAndDate(int clientId, DateTime startDate, DateTime endDate, string sortFieldName, bool isDesc, int pageIndex, int limit, out int recordCount)
	    {
	        return
	            ConvertToWrapperList(businessProxy.FindAllByOrderByAndClientIDAndDate(clientId, startDate, endDate,
	                                                                                  sortFieldName, isDesc, pageIndex,
	                                                                                  limit, out recordCount));


	    }

        public static List<SPPaymentInfoWrapper> FindAllDefaultClientPaymentByOrderByDate(DateTime startDate, DateTime endDate, string sortFieldName, bool isDesc, int pageIndex, int limit, out int recordCount)
	    {
            return
            ConvertToWrapperList(businessProxy.FindAllDefaultClientPaymentByOrderByDate(startDate, endDate,
                                                                                  sortFieldName, isDesc, pageIndex,
                                                                                  limit, out recordCount));        

	    }


        public void SetPaymentProviceAndCity()
        {
            if (!string.IsNullOrEmpty(this.MobileNumber) && this.MobileNumber.Length > 7)
            {
                try
                {
                    PhoneAreaInfo phoneAreaInfo = SPPhoneAreaWrapper.GetPhoneCity(this.MobileNumber.Substring(0, 7));
                    if (phoneAreaInfo != null)
                    {
                        this.Province = phoneAreaInfo.Province;
                        this.City = phoneAreaInfo.City;
                        this.MobileOperators = phoneAreaInfo.MobileOperators;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Error(ex.Message);
                }
            }
        }

        public void SycnDataToClient()
        {
            SPClientChannelSettingWrapper channelSetting = this.GetChannleClientSetting();

            if (!this.IsIntercept.Value)
            {
                if (!string.IsNullOrEmpty(channelSetting.SyncDataUrl))
                {
                    this.IsSycnData = true;
                    if (!string.IsNullOrEmpty(channelSetting.SyncType) && channelSetting.SyncType.Equals("2"))
                    {
                        this.SucesssToSend = false;
                    }
                    else
                    {
                        this.SucesssToSend = channelSetting.SendMsg(this);
                    }
                }
                else
                    this.SucesssToSend = false;
            }
            else
            {
                this.SucesssToSend = false;
            }
        }
        public static List<SPPaymentInfoWrapper> FindAllByOrderByAndClientIDAndDateNoIntercept(int spClientID, DateTime startDate, DateTime endDate, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
        {
            return
                ConvertToWrapperList(businessProxy.FindAllByOrderByAndClientIDAndDateNoIntercept(spClientID,
                                                                                                  startDate,
                                                                                                  endDate,
                                                                                                  sortFieldName, isdesc,
                                                                                                  pageIndex, limit,
                                                                                                  out recordCount));

        }

        public static List<SPPaymentInfoWrapper> FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept(
                                                                                                                        int channleID, 
                                                                                                                        int spClientId, 
                                                                                                                        DateTime startDate, 
                                                                                                                        DateTime endDate, 
                                                                                                                        string province, 
                                                                                                                        string city, 
                                                                                                                        string phone, 
                                                                                                                        string sortFieldName, 
                                                                                                                        bool isdesc, 
                                                                                                                        int pageIndex, 
                                                                                                                        int limit, 
                                                                                                                        out int recordCount
                                                                                                                     )
	    {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept(
                                                                                                                            spClientId,
                                                                                                                            startDate,
                                                                                                                            endDate, 
                                                                                                                            province, 
                                                                                                                            city,
                                                                                                                            phone,
                                                                                                                            sortFieldName, 
                                                                                                                            isdesc,
                                                                                                                            pageIndex, 
                                                                                                                            limit,
                                                                                                                            out recordCount)
                                                                                                                          ); 



	    }

        public static List<SPPaymentInfoWrapper> FindAllByOrderByAndSPClientGroupIDAndDateAndProviceNoIntercept(int spClientGroupID, DateTime startDate, DateTime endDate, string province,string city, string phone, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
	    {
            return
                ConvertToWrapperList(businessProxy.FindAllByOrderByAndSPClientGroupIDAndDateAndProviceNoIntercept(spClientGroupID,
                                                                                                  startDate,
                                                                                                  endDate, province, city, phone,
                                                                                                  sortFieldName, isdesc,
                                                                                                  pageIndex, limit,
                                                                                                  out recordCount));	        

	    }

        public static List<SPPaymentInfoWrapper> FindAllNotSendData(int clientChannelId, DateTime starDate, DateTime endDate, int maxRetryCount)
	    {
            return
                ConvertToWrapperList(businessProxy.FindAllNotSendData(clientChannelId, starDate, endDate, maxRetryCount));	
	    }

	    public static int[] GetGetAllClientChannelIDNeed(DateTime startDate, DateTime endDate)
	    {
            return businessProxy.GetGetAllClientChannelIDNeed(startDate, endDate);
	    }

	    public static void UpdateRecordAndReport(DayliyReport dayReport,SPClientWrapper spClientWrapper, int newIntercept)
	    {
            businessProxy.UpdateRecordAndReport(dayReport, spClientWrapper.DefaultClientChannelSetting.entity, newIntercept);


	    }


        public static void UpdateUrlSuccessSend(int id,string url)
        {
            businessProxy.UpdateUrlSuccessSend(id, url);
        }

        public static List<SPPaymentInfoWrapper> FindAllByChannelIDAndClientChannelIDAndPhoneListByOrderBy(int channelId, int clientChannelId, List<string> phones, string sortFieldName, bool isDesc, int pageIndex, int limit, out int recordCount)
        {
            return
                ConvertToWrapperList(businessProxy.FindAllByChannelIDAndClientChannelIDAndPhoneListByOrderBy(channelId, clientChannelId, phones, sortFieldName, isDesc, pageIndex, limit, out recordCount));	
        }

        public static List<SPPaymentInfoWrapper> FindAllByChannelIDAndClientChannelIDAndPhoneList(int channelId, int clientChannelId, List<string> phones)
        {
            return ConvertToWrapperList(businessProxy.FindAllByChannelIDAndClientChannelIDAndPhoneList(channelId, clientChannelId, phones));	
        }


	    public bool CheckHasLinkIDAndChannelID()
	    {
	        return businessProxy.CheckHasLinkIDAndChannelID(this.entity);
	    }

	    public static DataTable GetClientMobileCount(int spClientId, DateTime startDate, DateTime endDate)
	    {
            return businessProxy.GetClientMobileCount(spClientId, startDate, endDate);        
	    }

        public static List<SPPaymentInfoWrapper> FindAllByOrderByAndSPClientGroupIDAndDateAndProviceNoIntercept1(int spClientGroupID, DateTime startDate, DateTime endDate, string province, string city, string phone, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
	    {
            return
                ConvertToWrapperList(businessProxy.FindAllByOrderByAndSPClientGroupIDAndDateAndProviceNoIntercept1(spClientGroupID,
                                                                                                  startDate,
                                                                                                  endDate, province, city, phone,
                                                                                                  sortFieldName, isdesc,
                                                                                                  pageIndex, limit,
                                                                                                  out recordCount));	  
	    }

        public static List<SPPaymentInfoWrapper> FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept1(
                                                                                                                        int channleID,
                                                                                                                        int spClientId,
                                                                                                                        int spClientGroupID,
                                                                                                                        DateTime startDate,
                                                                                                                        DateTime endDate,
                                                                                                                        string province,
                                                                                                                        string city,
                                                                                                                        string phone,
                                                                                                                        string sortFieldName,
                                                                                                                        bool isdesc,
                                                                                                                        int pageIndex,
                                                                                                                        int limit,
                                                                                                                        out int recordCount
                                                                                                                     )
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept1(
                                                                                                                            spClientId,
                                                                                                                            spClientGroupID,
                                                                                                                            channleID,
                                                                                                                            startDate,
                                                                                                                            endDate,
                                                                                                                            province,
                                                                                                                            city,
                                                                                                                            phone,
                                                                                                                            sortFieldName,
                                                                                                                            isdesc,
                                                                                                                            pageIndex,
                                                                                                                            limit,
                                                                                                                            out recordCount)
                                                                                                                          );



        }
    }
}
