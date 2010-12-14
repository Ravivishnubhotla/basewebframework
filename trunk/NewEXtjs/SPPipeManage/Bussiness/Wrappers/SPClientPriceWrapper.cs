
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPClientPriceWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPClientPriceWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPClientPriceWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPClientPriceWrapper obj)
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

        public static void Delete(SPClientPriceWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPClientPriceWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPClientPriceWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPClientPriceWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPClientPriceWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPClientPriceEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPClientPriceWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPClientPriceWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPClientPriceWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPClientPriceWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

	    public static decimal GetClientPrice(int clientid)
	    {
	        return businessProxy.GetClientPrice(clientid);
	    }



        public static decimal GetClientGroupPrice(int clientid, int clientGroupid)
	    {
            return businessProxy.GetClientGroupPrice(clientid, clientGroupid);
	    }

        public static void SetClientPrice(int clientid, decimal price)
	    {
            businessProxy.SetClientPrice(clientid, price); ;
	    }

        public static void SetClientGroupPrice(int clientid, int clientGroupid, decimal price)
	    {
            businessProxy.SetClientGroupPrice(clientid, clientGroupid, price);
	    }
    }
}
