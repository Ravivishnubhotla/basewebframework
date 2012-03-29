
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPCodeInfoWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPCodeInfoWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPCodeInfoWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPCodeInfoWrapper obj)
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

        public static void Delete(SPCodeInfoWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPCodeInfoWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPCodeInfoWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPCodeInfoWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPCodeInfoWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPCodeInfoEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPCodeInfoWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPCodeInfoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPCodeInfoWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPCodeInfoWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }



			
		#endregion


        public static List<SPCodeInfoWrapper> FindAllByOrderByAndFilterAndChannelID(int channelID,List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPCodeInfoWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilterAndChannelID(channelID,filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }


	    public string ChannelName
	    {
	        get
	        {
                if (this.ChannelID == null)
                    return "";
	            return ChannelID.Name;
	        }
	    }


        public string MoCode
        {
            get
            {
                return string.Format("{0} ({1}) {2}",Mo,CodeType,SPCode);
            }
        }


        public static List<SPCodeInfoWrapper> FindAllByOrderByAndChannelID(int channelID, List<QueryFilter> queryFilters, string orderByColumnName, bool isDesc)
        {
            List<SPCodeInfoWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndChannelID(channelID, queryFilters, orderByColumnName, isDesc));

            return results;
        }
    }
}
