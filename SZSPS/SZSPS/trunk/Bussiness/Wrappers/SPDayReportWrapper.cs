
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Entity.Tables;
using LD.SPPipeManage.Bussiness.ServiceProxys.Tables;


namespace LD.SPPipeManage.Bussiness.Wrappers
{
    public class ReportDataProvinceItem
    {
        public int ChannelID { get; set; }
        public string ChannelName { get; set; }
        public string CodeName { get; set; }
        public int CodeID { get; set; }
        public string Mo { get; set; }
        public string SPCode { get; set; }
        public string MoType { get; set; }
        public string Province { get; set; }
        public int RecordCount { get; set; }
        public int MoLength { get; set; }


        public ReportDataProvinceItem Copy()
        {
            ReportDataProvinceItem item = new ReportDataProvinceItem();
            item.ChannelName = this.ChannelName;
            item.CodeName = this.CodeName;
            item.Mo = this.Mo;
            item.SPCode = this.SPCode;
            item.MoType = this.MoType;
            item.Province = this.Province;
            item.RecordCount = this.RecordCount;
            item.MoLength = this.MoLength;
            return item;
        }

    }

    public class ReportDataOperatorItem
    {
        public string ChannelName { get; set; }
        public string CodeName { get; set; }
        public string Mo { get; set; }
        public string SPCode { get; set; }
        public string MoType { get; set; }
        public string Province { get; set; }
        public string OperatorType { get; set; }
        public int RecordCount { get; set; }
        public int MoLength { get; set; }


        public ReportDataOperatorItem Copy()
        {
            ReportDataOperatorItem item = new ReportDataOperatorItem();
            item.ChannelName = this.ChannelName;
            item.CodeName = this.CodeName;
            item.Mo = this.Mo;
            item.SPCode = this.SPCode;
            item.MoType = this.MoType;
            item.Province = this.Province;
            item.RecordCount = this.RecordCount;
            item.MoLength = this.MoLength;
            item.OperatorType = this.OperatorType;
            return item;
        }

    }

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

        //public static void GenerateDayReport(DateTime date)
        //{
        //    businessProxy.BulidReport(date);
        //}

        public static void ReGenerateDayReport(DateTime date)
        {
            businessProxy.ReBulidReport(date);
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

        //public static void ArchivesData(string archivesPath, DateTime startDate, DateTime endDate)
        //{
        //    businessProxy.ArchivesData(archivesPath, startDate.Date, endDate.Date);
        //}


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

	    public static DataTable GetAllTodayReport(bool filterZeroCountChannel)
	    {
            if (filterZeroCountChannel)
                return businessProxy.GetAllTodayReport(filterZeroCountChannel);
            return businessProxy.GetAllTodayReport(filterZeroCountChannel);
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

        public static void ReGenerateDayReport(DateTime startDateTime, DateTime endDateTime)
	    {
            businessProxy.ReGenerateDayReport(startDateTime, endDateTime);
	    }

	    public static DataTable GetTodayReportByProvince(int clientID, int channelID, string province)
	    {
            return businessProxy.GetTodayReport(clientID, channelID);
	    }

	    public static DataTable GetProvinceCountReport(int channleId, int clientId, DateTime startDate, DateTime endDate, DataType dType)
	    {
            return businessProxy.GetProvinceCountReport(channleId, clientId, startDate, endDate, dType);
	    }

        public static DayliyReport GetDayReport(DateTime dateTime, SPClientWrapper clientWrapper)
        {
            return businessProxy.GetDayReport(dateTime, clientWrapper.DefaultClientChannelSetting.entity);
        }

	    public static DataTable GetClientGroupPriceReport(int clientGroupId, DateTime startDate, DateTime endDate)
	    {
            return businessProxy.GetClientGroupPriceReport(clientGroupId, startDate, endDate);
	    }

	    public static DataTable GetDayCountReportForMaster(DateTime startDate, DateTime endDate)
	    {
            return businessProxy.GetDayCountReportForMaster( startDate, endDate);
	    }

	    public static DataTable GetReportDataChange(int reportClientChannleId, DateTime startDate, DateTime endDate)
	    {
            return businessProxy.GetReportDataChange(reportClientChannleId,startDate, endDate);
	    }

        public static DataTable GetALlClientGroupPriceReport(DateTime startDate, DateTime endDate)
	    {
            return businessProxy.GetALlClientGroupPriceReport( startDate, endDate);
	    }


        public static DataTable GetClientGroupDayReport(DateTime startDate, DateTime endDate, int clientGroupId)
        {
            return businessProxy.GetClientGroupDayReport(startDate, endDate, clientGroupId);
        }



        public static List<SPDayReportWrapper> GetAllClientGroupDayReport(DateTime startDate, DateTime endDate, int clientGroupId)
        {
            return ConvertToWrapperList(businessProxy.GetAllClientGroupDayReport(startDate, endDate, clientGroupId));
        }




        public static DataTable GetProvinceReport(DateTime startDate, DateTime endDate, int channelID, int channleClientID)
        {
            DataTable dt = new DataTable("DS");
            dt.Columns.Add("ChannelName");
            dt.Columns.Add("ChannelID");
            dt.Columns.Add("CodeName");
            dt.Columns.Add("ChannelClentID");
            dt.Columns.Add("Province");
            dt.Columns.Add("RecordCount",typeof(int));

            dt.AcceptChanges();

            DataTable dtReportQuery = businessProxy.GetProvinceReport(startDate, endDate, channelID, channleClientID,null);

            List<ReportDataProvinceItem> reportDataProvinceItems = new List<ReportDataProvinceItem>();

            foreach (DataRow dr in dtReportQuery.Rows)
            {
                SPChannelWrapper channel = SPChannelWrapper.FindById((int) dr["ChannelID"]);
                SPClientChannelSettingWrapper channelSettingWrapper = SPClientChannelSettingWrapper.FindById((int)dr["ChannleClientID"]);

                string channelName = channel.Name;
                string moCode = channelSettingWrapper.ParentClientChannelSetting.MoCode;
                string province = dr["Province"].ToString();

                int recordCount = (int)dr["RecordCount"];

                ReportDataProvinceItem reportDataProvinceItem = new ReportDataProvinceItem();
                reportDataProvinceItem.ChannelID = (int)dr["ChannelID"];
                reportDataProvinceItem.ChannelName = channelName;
                reportDataProvinceItem.CodeID = (int)dr["ChannleClientID"];
                reportDataProvinceItem.CodeName = moCode.ToLower();
                if (string.IsNullOrEmpty(province))
                {
                    reportDataProvinceItem.Province = "未知省份";   
                }
                else
                {
                    if (string.IsNullOrEmpty(province.Trim()))
                    {
                        reportDataProvinceItem.Province = "未知省份";  
                    }
                    else
                    {
                        reportDataProvinceItem.Province = province.ToLower();              
                    }
                }

                reportDataProvinceItem.RecordCount = recordCount;
                reportDataProvinceItem.Mo = channelSettingWrapper.CommandCode.ToLower();
                if (channelSettingWrapper.ChannelCode==null)
                {
                    reportDataProvinceItem.SPCode = "";
                }
                else
                {
                    reportDataProvinceItem.SPCode = channelSettingWrapper.ChannelCode.ToLower();          
                }


                if (channelSettingWrapper.CommandType == "1")
                    reportDataProvinceItem.MoType = "1";
                else if (channelSettingWrapper.CommandType == "2" || channelSettingWrapper.CommandType == "3" || channelSettingWrapper.CommandType == "4")
                    reportDataProvinceItem.MoType = "2";
                else
                {
                    reportDataProvinceItem.MoType = "0";
                }

                reportDataProvinceItem.MoLength = reportDataProvinceItem.Mo.Length;

                reportDataProvinceItems.Add(reportDataProvinceItem);
            }

 

            foreach (ReportDataProvinceItem groupItem in reportDataProvinceItems)
            {
                AddNewProvinceReportRow(dt, groupItem.ChannelName, groupItem.CodeName, groupItem.Province, groupItem.RecordCount, groupItem.ChannelID, groupItem.CodeID);
            }
 
            return dt;
 
        }

        public static DataTable GetProvinceReportForClientGroup(DateTime startDate, DateTime endDate, int clientGroupID, int channleClientID)
        {
            DataTable dt = new DataTable("DS");
            dt.Columns.Add("ClientGroupName");
            dt.Columns.Add("ChannelID");
            dt.Columns.Add("CodeName");
            dt.Columns.Add("ChannelClentID");
            dt.Columns.Add("Province");
            dt.Columns.Add("RecordCount", typeof(int));
            dt.AcceptChanges();

            DataTable dtReportQuery = businessProxy.GetProvinceReportForClientGroup(startDate, endDate, clientGroupID, channleClientID, false);

            List<ReportDataProvinceItem> reportDataProvinceItems = new List<ReportDataProvinceItem>();

            foreach (DataRow dr in dtReportQuery.Rows)
            {
                SPClientGroupWrapper clientGroup = SPClientGroupWrapper.FindById((int)dr["ClientGroupID"]);
                SPClientChannelSettingWrapper channelSettingWrapper = SPClientChannelSettingWrapper.FindById((int)dr["ChannleClientID"]);

                string channelName = clientGroup.Name;
                string moCode = channelSettingWrapper.ParentClientChannelSetting.MoCode;
                string province = dr["Province"].ToString();
                int recordCount = (int)dr["RecordCount"];

                ReportDataProvinceItem reportDataProvinceItem = new ReportDataProvinceItem();
                reportDataProvinceItem.ChannelName = channelName.ToLower();
                reportDataProvinceItem.ChannelID = clientGroup.Id;
                reportDataProvinceItem.CodeID = channelSettingWrapper.Id;
                reportDataProvinceItem.CodeName = moCode.ToLower();
                if (string.IsNullOrEmpty(province))
                {
                    reportDataProvinceItem.Province = "未知省份";
                }
                else
                {
                    if (string.IsNullOrEmpty(province.Trim()))
                    {
                        reportDataProvinceItem.Province = "未知省份";
                    }
                    else
                    {
                        reportDataProvinceItem.Province = province.ToLower();
                    }
                }

                reportDataProvinceItem.RecordCount = recordCount;
                reportDataProvinceItem.Mo = channelSettingWrapper.CommandCode.ToLower();
                if (channelSettingWrapper.ChannelCode == null)
                {
                    reportDataProvinceItem.SPCode = "";
                }
                else
                {
                    reportDataProvinceItem.SPCode = channelSettingWrapper.ChannelCode.ToLower();
                }


                if (channelSettingWrapper.CommandType == "1")
                    reportDataProvinceItem.MoType = "1";
                else if (channelSettingWrapper.CommandType == "2" || channelSettingWrapper.CommandType == "3" || channelSettingWrapper.CommandType == "4")
                    reportDataProvinceItem.MoType = "2";
                else
                {
                    reportDataProvinceItem.MoType = "0";
                }

                reportDataProvinceItem.MoLength = reportDataProvinceItem.Mo.Length;

                reportDataProvinceItems.Add(reportDataProvinceItem);
            }


 

            foreach (ReportDataProvinceItem groupItem in reportDataProvinceItems)
            {
                AddNewProvinceReportRow1(dt, groupItem.ChannelName, groupItem.CodeName, groupItem.Province, groupItem.RecordCount, groupItem.ChannelID, groupItem.CodeID);
            }

            return dt;

        }


        private static void AddNewProvinceReportRow1(DataTable dt, string channelName, string codeName, string province, int recordCount, int cid, int codeID)
        {
            DataRow dr = dt.NewRow();
            dr["ClientGroupName"] = channelName;
            dr["ChannelID"] = cid;
            dr["CodeName"] = codeName;
            dr["ChannelClentID"] = codeID;
            dr["Province"] = province;
            dr["RecordCount"] = recordCount;
            dt.Rows.Add(dr);
            dt.AcceptChanges();
        }


        private static void AddNewProvinceReportRow(DataTable dt,string channelName,string codeName,string province,int recordCount,int cid,int codeID)
        {
            DataRow dr = dt.NewRow();
            dr["ChannelName"] = channelName;
            dr["ChannelID"] = cid;
            dr["CodeName"] = codeName;
            dr["ChannelClentID"] = codeID;
            dr["Province"] = province;
            dr["RecordCount"] = recordCount;
            dt.Rows.Add(dr);
            dt.AcceptChanges();
        }

        public static DataTable GetOperatorReport(DateTime startDate, DateTime endDate, int channleId, int clientChannleId,string  mprovince,  string moperator)
        {
            DataTable dt = new DataTable("DS");
            dt.Columns.Add("Operator");
            dt.Columns.Add("Province");
            dt.Columns.Add("Channel");
            dt.Columns.Add("Mo");
            dt.Columns.Add("RecordCount",typeof(int));
            dt.AcceptChanges();

            DataTable dtReportQuery = businessProxy.GetOperatorReport(startDate, endDate, channleId, clientChannleId,null, mprovince , moperator);

            List<ReportDataOperatorItem> reportDataProvinceItems = new List<ReportDataOperatorItem>();

            foreach (DataRow dr in dtReportQuery.Rows)
            {
                SPChannelWrapper channel = SPChannelWrapper.FindById((int) dr["ChannelID"]);
                SPClientChannelSettingWrapper channelSettingWrapper = SPClientChannelSettingWrapper.FindById((int)dr["ChannleClientID"]);

                string channelName = channel.Name;
                string moCode = channelSettingWrapper.MoCode;
                int recordCount = (int)dr["RecordCount"];
                string province = dr["Province"].ToString();

                ReportDataOperatorItem reportDataProvinceItem = new ReportDataOperatorItem();
                reportDataProvinceItem.ChannelName = channelName.ToLower();
                reportDataProvinceItem.CodeName = moCode.ToLower();
                if (string.IsNullOrEmpty(province))
                {
                    reportDataProvinceItem.Province = "未知省份";
                }
                else
                {
                    if (string.IsNullOrEmpty(province.Trim()))
                    {
                        reportDataProvinceItem.Province = "未知省份";
                    }
                    else
                    {
                        reportDataProvinceItem.Province = province.ToLower();
                    }
                }

                reportDataProvinceItem.RecordCount = recordCount;
                reportDataProvinceItem.Mo = channelSettingWrapper.CommandCode.ToLower();
                if (channelSettingWrapper.ChannelCode == null)
                {
                    reportDataProvinceItem.SPCode = "";
                }
                else
                {
                    reportDataProvinceItem.SPCode = channelSettingWrapper.ChannelCode.ToLower();
                }


                if (channelSettingWrapper.CommandType == "1")
                    reportDataProvinceItem.MoType = "1";
                else if (channelSettingWrapper.CommandType == "2" || channelSettingWrapper.CommandType == "3" || channelSettingWrapper.CommandType == "4")
                    reportDataProvinceItem.MoType = "2";
                else
                {
                    reportDataProvinceItem.MoType = "0";
                }

                reportDataProvinceItem.MoLength = reportDataProvinceItem.Mo.Length;
                reportDataProvinceItem.OperatorType = dr["Operator"].ToString();
                reportDataProvinceItems.Add(reportDataProvinceItem);
            }



            List<ReportDataOperatorItem> orderedItems = (from rap in reportDataProvinceItems
                                                         orderby rap.OperatorType, rap.Province, rap.ChannelName, rap.MoType, rap.Mo, rap.SPCode, rap.MoLength
                                                         select rap).ToList();

            List<ReportDataOperatorItem> groupItems = new List<ReportDataOperatorItem>();

            foreach (ReportDataOperatorItem oItem in orderedItems)
            {
                ReportDataOperatorItem item =
                    groupItems.Find(
                        p =>
                        (p.OperatorType == oItem.OperatorType && p.ChannelName == oItem.ChannelName &&
                         p.Province == oItem.Province && p.CodeName == oItem.CodeName));

                if (item != null)
                {
                    item.RecordCount = oItem.RecordCount + item.RecordCount;
                }
                else
                {
                    if (oItem.MoType == "2")
                    {
                        ReportDataOperatorItem mitem = (from rap in groupItems
                                                        where
                                                            (rap.OperatorType == oItem.OperatorType && rap.ChannelName == oItem.ChannelName &&
                         rap.Province == oItem.Province && rap.SPCode == oItem.SPCode &&
                                                             !oItem.Mo.Equals(rap.Mo) && oItem.Mo.Contains(rap.Mo))
                                                        orderby rap.MoLength
                                                        select rap).FirstOrDefault();

                        bool hasMain = (mitem != null);

                        if (hasMain)
                        {
                            mitem.RecordCount = oItem.RecordCount + mitem.RecordCount;

                            continue;
                        }
                    }

                    var addItem = oItem.Copy();

                    groupItems.Add(addItem);
 
                }

            }

            foreach (ReportDataOperatorItem groupItem in groupItems)
            {
                dt.Rows.Add(groupItem.OperatorType, groupItem.Province, groupItem.ChannelName, groupItem.CodeName,
                            groupItem.RecordCount);
            }



            dt.AcceptChanges();

            return dt;


        }

        public string ClientChannelName
        {
            get
            {
                if (this.ClientID <= 0)
                    return "";

                SPClientWrapper client = SPClientWrapper.FindById(this.ClientID);

                if (client == null)
                    return "";

                if (string.IsNullOrEmpty(client.Alias))
                    return client.Name;

                return client.Alias;

            }
        }

        public string MoCode
        {
            get
            {
                if (this.ClientID <= 0)
                    return "";

                SPClientWrapper client = SPClientWrapper.FindById(this.ClientID);

                if (client == null)
                    return "";

                SPClientChannelSettingWrapper spClientChannelSetting = client.DefaultClientChannelSetting;

                if (spClientChannelSetting == null)
                    return "";

                return spClientChannelSetting.MoCode;
 

            }
        }

        public static DataTable GetClientGroupTotalReport(DateTime startDate, DateTime endDate)
        {
            return businessProxy.GetClientGroupTotalReport(startDate, endDate);
        }

        public static DataTable GetProvinceCityReport(DateTime startDate, DateTime endDate, int reportId, int reportClientChannleId, string province)
        {
            return businessProxy.GetProvinceCityReport(startDate, endDate, reportId, reportClientChannleId, province);
        }

        public static DataTable GetProvinceCityReportForClientGroup(DateTime startDate, DateTime endDate, int reportId, int reportClientChannleId, string province)
        {
            return businessProxy.GetProvinceCityReportForClientGroup(startDate, endDate, reportId, reportClientChannleId, province);
        }

        public static DataTable GetDataChangeReport(DateTime startDate, DateTime endDate, int reportChannleId, int reportClientChannleId, int timeIntercept)
        {
            return businessProxy.GetDataChangeReport(startDate, endDate, reportChannleId, reportClientChannleId, timeIntercept);
        }
    }
}
