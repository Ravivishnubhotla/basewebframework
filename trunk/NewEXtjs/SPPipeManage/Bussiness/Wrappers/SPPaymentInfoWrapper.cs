
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
    public enum DataType
    {
        All,
        Intercept,
        Down,
        DownSycn
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


        //public bool SendToClient(out string error)
        //{
        //    error = "";

        //    if(this.IsIntercept.HasValue && this.IsIntercept.Value)
        //    {
        //        error = "Is Intercept";
        //        return false;
        //    }


        //    if (this.SucesssToSend.HasValue && this.SucesssToSend.Value)
        //    {
        //        error = "Is Sucesss To Send";
        //        return false;
        //    }

        //    error = "Is Sucesss To Send";

        //    return this.c.SendMsgAndUpdate(this, out error);


        //}


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
                case "extendfield9":
                    return this.ExtendField9;
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
                case "extendfield9":
                    this.ExtendField9 = sValue;
                    break;
            }
        }
    }
}
