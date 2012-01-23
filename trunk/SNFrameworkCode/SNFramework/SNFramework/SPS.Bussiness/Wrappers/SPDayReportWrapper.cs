
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using SPS.Entity.Tables;
using SPS.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace SPS.Bussiness.Wrappers
{
	[Serializable]
    public partial class SPDayReportWrapper : BaseSpringNHibernateWrapper<SPDayReportEntity, ISPDayReportServiceProxy, SPDayReportWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SPDayReportWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SPDayReportWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SPDayReportWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(object id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SPDayReportWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SPDayReportWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SPDayReportWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SPDayReportWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SPDayReportWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SPDayReportWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SPDayReportWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SPDayReportWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SPDayReportWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion


        public static List<SPDayReportWrapper> CaculateReport(DateTime reportDate)
        {
            return ConvertNoDbDataToWrapperList(businessProxy.CaculateReport(reportDate.Date));
        }

        public static List<SPDayReportWrapper> CaculateReport(DateTime reportDate,SPSClientWrapper clientWrapper)
        {
            return ConvertNoDbDataToWrapperList(businessProxy.CaculateReport(reportDate.Date, clientWrapper.Entity));
        }

	    public string CodeID_MoCode
	    {
	        get
	        {
                if (CodeID == null)
                    return "";
	            return CodeID.MoCode;
	        }
	    }


	    internal static List<SPDayReportWrapper> ConvertNoDbDataToWrapperList(List<SPDayReportEntity> entitys)
        {
            List<SPDayReportWrapper> list = new List<SPDayReportWrapper>();
            foreach (SPDayReportEntity reportEntity in entitys)
            {
                list.Add(new SPDayReportWrapper(reportEntity));
            }
            int i = 1;
            foreach (SPDayReportWrapper report  in list)
            {
                report.Id = i;
                i++;
            }
            return list;
        }

        public static void ReGenerateDayReport(DateTime date)
        {
            businessProxy.ReBulidReport(date);
        }

        public static List<SPDayReportWrapper> QueryReport(DateTime startDate, DateTime endDate)
        {
           return  ConvertToWrapperList(businessProxy.QueryReport(startDate, endDate));
        }

	    public static void ReGenerateDayReport(DateTime startDate, DateTime endDate)
	    {
            for (DateTime i = startDate; i < endDate.AddDays(1); i = i.AddDays(1))
            {
                try
                {
                    ReGenerateDayReport(i);
                }
                catch (Exception ex)
                {
                    Logger.Error("���ɱ�������" + ex.Message);
                }
            }
	    }

        public static List<SPDayReportWrapper> QueryReport(DateTime startDate, DateTime endDate, SPSClientWrapper client)
	    {
            return ConvertToWrapperList(businessProxy.QueryReport(startDate, endDate, client.Entity));
	    }
    }
}
