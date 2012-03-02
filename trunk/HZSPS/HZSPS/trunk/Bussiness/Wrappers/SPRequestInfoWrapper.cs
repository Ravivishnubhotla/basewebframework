
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPRequestInfoWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPRequestInfoWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPRequestInfoWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPRequestInfoWrapper obj)
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

        public static void Delete(SPRequestInfoWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPRequestInfoWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPRequestInfoWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPRequestInfoWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPRequestInfoWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPRequestInfoEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPRequestInfoWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPRequestInfoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPRequestInfoWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPRequestInfoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

    }
}
