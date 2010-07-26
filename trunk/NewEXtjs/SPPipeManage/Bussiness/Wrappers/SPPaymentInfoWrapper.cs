
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Utility;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
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


        public static DataTable FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime, string sortFieldName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return businessProxy.FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(channelId, clientId,
                                                                                                  startDateTime,
                                                                                                  enddateTime,
                                                                                                  sortFieldName, isDesc,
                                                                                                  pageIndex, pageSize,
                                                                                                  out recordCount);


        }

	    private string values;

	    public string Values
	    {
	        get
	        {
	            return values;
	        }
            set
            {
                values = value;
            }
	    }

        public void SetHBValues(Hashtable hashtable)
        {
            values = SerializeUtil.ToJson(hashtable);
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


	    public bool SendToClient()
	    {
	        if(this.IsIntercept.HasValue && this.IsIntercept.Value)
	            return false;

            if (this.SucesssToSend.HasValue && this.SucesssToSend.Value)
                return false;

	        SPClientWrapper clientWrapper = SPClientWrapper.FindById(this.ClientID);

	        clientWrapper.SendMsg();


	    }
    }
}
