
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPClientChannelSettingWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPClientChannelSettingWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPClientChannelSettingWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPClientChannelSettingWrapper obj)
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

        public static void Delete(SPClientChannelSettingWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPClientChannelSettingWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPClientChannelSettingWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPClientChannelSettingWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPClientChannelSettingWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPClientChannelSettingEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPClientChannelSettingWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPClientChannelSettingWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPClientChannelSettingWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPClientChannelSettingWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion


        //public static List<SPClientChannelSettingWrapper> Get

	    public string ClientName
	    {
	        get
	        {
	            if(this.ClinetID!=null)
	            {
	                return this.ClinetID.Name;
	            }
	            return "";
	        }
	    }

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

	    public static List<SPClientChannelSettingWrapper> GetSettingByChannel(SPChannelWrapper spChannelWrapper)
	    {
            return SPClientChannelSettingWrapper.ConvertToWrapperList(businessProxy.GetSettingByChannel(spChannelWrapper.entity));
	    }


	    public bool MatchByYWID(string ywid)
	    {
	        switch(this.CommandType)
	        {
                case "1":
                    return ywid.Equals(this.CommandCode);
                case "2":
                    return ywid.Contains(this.CommandCode);
                case "3":
                    return ywid.StartsWith(this.CommandCode);
                case "4":
                    return ywid.EndsWith(this.CommandCode);
                case "5":
                    return false;
                case "6":
	                return false;
                    break;
	        }
            return false;
	    }

	    public bool CaculteIsIntercept()
	    {
            Random random = new Random(DateTime.Now.Millisecond);

	        int result = random.Next(0, 100);

	        return (result > this.InterceptRate);
	    }
    }
}
