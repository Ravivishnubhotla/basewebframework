
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPCustomPhoneAreaWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPCustomPhoneAreaWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPCustomPhoneAreaWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPCustomPhoneAreaWrapper obj)
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

        public static void Delete(SPCustomPhoneAreaWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPCustomPhoneAreaWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPCustomPhoneAreaWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPCustomPhoneAreaWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPCustomPhoneAreaWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPCustomPhoneAreaEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPCustomPhoneAreaWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPCustomPhoneAreaWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPCustomPhoneAreaWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPCustomPhoneAreaWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion


        public static bool FindPhoneInCustomPhoneArea(string customPhoneAreaName,string mobile)
        {
            SPCustomPhoneAreaWrapper customPhoneAreaWrapper = FindByCustomPhoneArea(customPhoneAreaName, mobile);

            if(customPhoneAreaWrapper!=null)
                return true;

            return false;
        }

        private static SPCustomPhoneAreaWrapper FindByCustomPhoneArea(string customPhoneAreaName, string mobile)
	    {
	        return new SPCustomPhoneAreaWrapper(businessProxy.FindByCustomPhoneArea(customPhoneAreaName, mobile));
	    }
    }
}
