
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPSendClientParamsWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPSendClientParamsWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPSendClientParamsWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPSendClientParamsWrapper obj)
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

        public static void Delete(SPSendClientParamsWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPSendClientParamsWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPSendClientParamsWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPSendClientParamsWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPSendClientParamsWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPSendClientParamsEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPSendClientParamsWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPSendClientParamsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPSendClientParamsWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPSendClientParamsWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

        public static List<SPSendClientParamsWrapper> FindAllByOrderByAndClientID(string sortFieldName, bool isDesc, int pageIndex, int limit, int clientId, out int recordCount)
        {
            return
                ConvertToWrapperList(businessProxy.FindAllByOrderByAndClientID(sortFieldName, isDesc, pageIndex, limit,
                                                                               clientId, out recordCount));
        }
    }
}
