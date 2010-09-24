
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPDayReportWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SPDayReportWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SPDayReportWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SPDayReportWrapper obj)
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

        public static void Delete(SPDayReportWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SPDayReportWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SPDayReportWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SPDayReportWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPDayReportWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SPDayReportEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SPDayReportWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SPDayReportWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SPDayReportWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

        public static List<SPDayReportWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc));
        }
			
		#endregion

	    public static void  GenerateDayReport(DateTime date)
        {
            businessProxy.BulidReport(date);
        }

        public static string GetDbSizeString()
        {
            return businessProxy.GetDbSize();
        }

        public static decimal GetDbSize()
        {
            string dbstring = businessProxy.GetDbSize();

            decimal dbsize = decimal.Zero;

            try
            {
                dbsize = Convert.ToDecimal(dbstring.Split(' ')[0]);
            }
            catch 
            {
                try
                {
                    dbsize = Convert.ToDecimal(dbstring.Replace(" ", "").Replace("MB", ""));
                }
                catch
                {
                    
                }
            }

            return dbsize;
        }

        public static void ArchivesData(string archivesPath, DateTime startDate, DateTime endDate)
        {
            businessProxy.ArchivesData(archivesPath, startDate.Date, endDate.Date);
        }


        public static DataTable GetCountReport(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime)
        {
            return businessProxy.GetCountReport(channelId, clientId, startDateTime, enddateTime);
        }


        public static DataTable GetCountReportForMaster(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime)
        {
            return businessProxy.GetCountReportForMaster(channelId, clientId, startDateTime, enddateTime);
        }


        public static DataTable GetCountReportForMaster(int channelId, DateTime startDateTime, DateTime enddateTime)
        {
            return businessProxy.GetCountReportForMaster(channelId, startDateTime, enddateTime);
        }
	    
	    public static DataTable GetDayliyReport(DateTime dateTime)
	    {
	        return businessProxy.GetDayliyReport(dateTime);
	    }

        public static DataTable GetTodayReport(int clientId, int channelId)
	    {
            return businessProxy.GetTodayReport(clientId, channelId);
	    }

	    public static DataTable GetAllTodayReport()
	    {
            return businessProxy.GetAllTodayReport();
	    }

        public static DataTable GetTodayReportByClientGroupID(int clientGroupID)
        {
            return businessProxy.GetTodayReportByClientGroupID(clientGroupID);
        }

        public static DataTable GetTodayReportByClientID(int clientID)
        {
            return businessProxy.GetTodayReportByClientID(clientID);
        }


	    public static DataTable GetCountReportByClientID(int spClientId, DateTime startDate, DateTime enddate)
	    {
            return businessProxy.GetCountReportByClientID(spClientId, startDate, enddate);
	    }

        public static DataTable GetCountReportByClientGroupID(int spClientGroupId, DateTime startDate, DateTime enddate)
	    {
            return businessProxy.GetCountReportByClientGroupID(spClientGroupId, startDate, enddate);
	    }
    }
}
