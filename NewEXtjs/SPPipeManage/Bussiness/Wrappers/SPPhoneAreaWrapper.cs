
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPPhoneAreaWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPPhoneAreaWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPPhoneAreaWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPPhoneAreaWrapper obj)
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

        public static void Delete(SPPhoneAreaWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPPhoneAreaWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPPhoneAreaWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPPhoneAreaWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPPhoneAreaWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPPhoneAreaEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPPhoneAreaWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPPhoneAreaWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPPhoneAreaWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPPhoneAreaWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion


        public static PhoneAreaInfo GetPhoneCity(string phone)
        {
            List<SPPhoneAreaWrapper> spPhoneAreaWrappers = ConvertToWrapperList(businessProxy.GetPhoneCity(phone));

            if (spPhoneAreaWrappers.Count<=0)
                return null;

            PhoneAreaInfo phoneAreaInfo = new PhoneAreaInfo();

            phoneAreaInfo.City = "";

            foreach (SPPhoneAreaWrapper phoneAreaWrapper in spPhoneAreaWrappers)
            {
                phoneAreaInfo.Province = phoneAreaWrapper.Province;

                phoneAreaInfo.City += phoneAreaWrapper.City;
            }

            return phoneAreaInfo;
        }

        public static SortedList<string, PhoneAreaInfo> GetAllPhoneInfos_Key()
        {
            //List<SPPhoneAreaWrapper> spPhoneAreaWrappers = FindAll();

            DataTable dt = SPPhoneAreaWrapper.GetAllPhoneAreaData();

            SortedList<string, PhoneAreaInfo> phoneinfos = new SortedList<string, PhoneAreaInfo>();

            foreach (DataRow item in dt.Rows)
	        {
                if (!phoneinfos.ContainsKey(item["PhonePrefix"].ToString()))
                { 
                    PhoneAreaInfo phonearea = new PhoneAreaInfo();
                    phonearea.City = item["City"].ToString();
                    phonearea.Province = item["Province"].ToString();
                    phoneinfos.Add(item["PhonePrefix"].ToString(), phonearea);
                }
	        }

            return phoneinfos;
        }

        private static DataTable GetAllPhoneAreaData()
	    {
            return businessProxy.GetAllPhoneAreaData();
	    }
    }
}
