
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


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


        public void ProcessRequest(Hashtable hashtable,string ip)
        {
            string cpid = GetParamsValue(hashtable,"cpid");
            string mid = GetParamsValue(hashtable, "mid");
            string mobile = GetParamsValue(hashtable, "mobile");
            string port = GetParamsValue(hashtable, "port");
            string ywid = GetParamsValue(hashtable, "ywid");
            string msg = GetParamsValue(hashtable, "msg");

            if(string.IsNullOrEmpty(mobile))
                return;
            if (string.IsNullOrEmpty(msg))
                return;
            if (string.IsNullOrEmpty(ywid))
                return;


            Hashtable exparams = GetEXParamsValue(hashtable);

            SPClientChannelSettingWrapper channelSetting = GetClientChannelSettingFromYWID(ywid);



            if (channelSetting != null)
            {

                SPPaymentInfoWrapper paymentInfo = new SPPaymentInfoWrapper();

                paymentInfo.ChannelID = this;
                paymentInfo.ClientID = channelSetting.ClinetID;
                paymentInfo.Cpid = cpid;
                paymentInfo.Mid = mid;
                paymentInfo.MobileNumber = mobile;
                paymentInfo.Port = port;
                paymentInfo.Ywid = ywid;
                paymentInfo.Message = msg;
                paymentInfo.Ip = ip;
                paymentInfo.IsIntercept = channelSetting.CaculteIsIntercept();
                paymentInfo.SucesssToSend = channelSetting.ClinetID.SendMsg(cpid, mid, mobile, port, ywid, msg, exparams);

                SPPaymentInfoWrapper.Save(paymentInfo);
            }

            
        }

	    private Hashtable GetEXParamsValue(Hashtable hashtable)
	    {
	        return new Hashtable();
	    }

        private SPClientChannelSettingWrapper GetClientChannelSettingFromYWID(string ywid)
	    {
	        List<SPClientChannelSettingWrapper> clientChannelSettings = SPClientChannelSettingWrapper.GetSettingByChannel(this);

	        foreach (SPClientChannelSettingWrapper channelSetting in clientChannelSettings)
	        {
	            if(channelSetting.MatchByYWID(ywid))
	            {
	                return channelSetting;
	            }
	        }

	        return null;
	    }

	    private string GetParamsValue(Hashtable hashtable,string key)
        {
            if (!hashtable.ContainsKey(key))
                return "";
            return hashtable[key].ToString();
        }
    }
}
