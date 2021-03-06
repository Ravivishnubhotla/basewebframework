// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using LD.SPPipeManage.Bussiness.Wrappers;
using LD.SPPipeManage.Data.AdoNet;
using LD.SPPipeManage.Data.Tables.Container;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using LD.SPPipeManage.Data.Tables;
using LD.SPPipeManage.Entity.Tables;
using Legendigital.Framework.Common.Utility;
using Spring.Transaction.Interceptor;


namespace LD.SPPipeManage.Bussiness.ServiceProxys.Tables
{
    public interface ISPDayReportServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SPDayReportEntity>, ISPDayReportServiceProxyDesigner
    {
        void ReBulidReport(DateTime date);
        //void BulidReport(DateTime date);
	    string GetDbSize();
        //void ArchivesData(string archivesPath, DateTime startDate, DateTime endDate);
	    DataTable GetDayliyReport(DateTime dateTime);
        DataTable GetTodayReport(int clientId, int channelId);
        DataTable GetCountReport(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime);
	    DataTable GetCountReportForMaster(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime);
	    DataTable GetCountReportForMaster(int channelId, DateTime startDateTime, DateTime enddateTime);
	    DataTable GetAllTodayReport(bool filterZeroCountChannel);
        DataTable GetTodayReportByClientGroupID(int clientGroupId);
        DataTable GetTodayReportByClientID(int clientId);
        DataTable GetCountReportByClientID(int spClientId, DateTime startDate, DateTime enddate);
        DataTable GetCountReportByClientGroupID(int spClientGroupId, DateTime startDate, DateTime enddate);
        void ReGenerateDayReport(DateTime startDateTime, DateTime endDateTime);
        DataTable GetProvinceCountReport(int channleId, int clientId, DateTime startDate, DateTime endDate, DataType dType);
        DayliyReport GetDayReport(DateTime dateTime, SPClientChannelSettingEntity spClientChannelSettingEntity);
        DataTable GetClientGroupPriceReport(int clientGroupId, DateTime startDate, DateTime endDate);
        DataTable GetDayCountReportForMaster(DateTime startDate, DateTime endDate);
        DataTable GetReportDataChange(int reportClientChannleId, DateTime startDate, DateTime endDate);
        DataTable GetALlClientGroupPriceReport(DateTime startDate, DateTime endDate);
        DataTable GetProvinceReport(DateTime startDate, DateTime endDate, int channelId, int channleClientID, bool? isIntercept);
        DataTable GetOperatorReport(DateTime startDate, DateTime endDate, int channleId, int clientChannleId, bool? isInterceptstring ,string mprovince,  string moperator);
        DataTable GetDayReport(DateTime startDate, DateTime enddate, string dateType);
        DataTable GetClientGroupDayReport(DateTime startDate, DateTime endDate , int clientGroupId);
        DataTable GetClientGroupTotalReport(DateTime startDate, DateTime endDate);
        List<SPDayReportEntity> GetAllClientGroupDayReport(DateTime startDate, DateTime endDate, int clientGroupId);
        DataTable GetALlChannelReport(DateTime startDate, DateTime endDate);
    }

    internal partial class SPDayReportServiceProxy :  ISPDayReportServiceProxy
    {

        public const string DataType_All = "All";
        public const string DataType_Intercept = "Intercept";
        public const string DataType_Down = "Down";
        public const string DataType_DownSycn = "DownSycn";
        public const string DataType_DownNotSycn = "DownNotSycn";
        public const string DataType_SycnFailed = "SycnFailed";

        //[Transaction(ReadOnly=false)]
        //public void BulidReport(DateTime date)
        //{
        //    //Get all need to generate report's channle nad client ID.
        //    DataSet dsAllClientChannel = this.AdoNetDb.GetAllClientChannel();

        //    DataTable dsDayTotalCount = this.AdoNetDb.GetDayTotalCount(date);
        //    DataTable dsDayDownCount = this.AdoNetDb.GetDayDownCount(date);
        //    DataTable dsDayInterceptCount = this.AdoNetDb.GetDayInterceptCount(date);
        //    DataTable dsDayDownSycnCount = this.AdoNetDb.GetDayDownSycnCount(date);    

        //    foreach (DataRow dataRow in dsAllClientChannel.Tables[0].Rows)
        //    {
        //        int channelID = (int)dataRow["ChannelID"];
        //        int clientID = (int)dataRow["ClientID"];


        //        string filterSql = string.Format(" ClientID = {0} and ChannelID = {1} ", clientID, channelID);

        //        int totalCount = this.AdoNetDb.ExecuteScalarFormDataTable("TotalCount", filterSql, dsDayTotalCount);
        //        int downCount = this.AdoNetDb.ExecuteScalarFormDataTable("DownCount", filterSql, dsDayDownCount);
        //        int interceptCount = this.AdoNetDb.ExecuteScalarFormDataTable("InterceptCount", filterSql, dsDayInterceptCount);
        //        int downSycnCount = this.AdoNetDb.ExecuteScalarFormDataTable("DownSycnCount", filterSql, dsDayDownSycnCount);

        //        SPDayReportEntity dayReportEntity = this.SelfDataObj.FindReportByChannelIDChannelIDAndDate(channelID, clientID, date);

        //        bool hasReport = false;


        //        if (dayReportEntity==null)
        //        {
        //            dayReportEntity = new SPDayReportEntity();
        //        }
        //        else
        //        {
        //            hasReport = true;
        //        }

        //        dayReportEntity.ChannelID = channelID;
        //        dayReportEntity.ClientID = clientID;
        //        if (hasReport)
        //        {
        //            dayReportEntity.UpTotalCount += totalCount;
        //            dayReportEntity.UpSuccess += 0;
        //            dayReportEntity.InterceptTotalCount += interceptCount;
        //            dayReportEntity.InterceptSuccess += 0;
        //            dayReportEntity.DownTotalCount += downCount;
        //            dayReportEntity.DownSuccess += downSycnCount;
        //        }
        //        else
        //        {
        //            dayReportEntity.UpTotalCount = totalCount;
        //            dayReportEntity.UpSuccess = 0;
        //            dayReportEntity.InterceptTotalCount = interceptCount;
        //            dayReportEntity.InterceptSuccess = 0;
        //            dayReportEntity.DownTotalCount = downCount;
        //            dayReportEntity.DownSuccess = downSycnCount;
        //        }        
                
        //        dayReportEntity.ReportDate = new DateTime(date.Year, date.Month, date.Day);

        //        this.SelfDataObj.SaveOrUpdate(dayReportEntity);



        //    }




        //    this.AdoNetDb.ClearAllReportedData(date);     
        //}




        [Transaction(ReadOnly = false,Timeout = 300)]
        public void ReBulidReport(DateTime date)
        {
            this.AdoNetDb.ResetAllReportedData(date);

            //Get all need to generate report's channle nad client ID.
            DataSet dsAllClientChannel = this.AdoNetDb.GetAllClientChannel(date);

            DataTable dsDayTotalCount = this.AdoNetDb.GetDayTotalCount(date);
            DataTable dsDayDownCount = this.AdoNetDb.GetDayDownCount(date);
            DataTable dsDayInterceptCount = this.AdoNetDb.GetDayInterceptCount(date);
            DataTable dsDayDownSycnCount = this.AdoNetDb.GetDayDownSycnCount(date);

            foreach (DataRow dataRow in dsAllClientChannel.Tables[0].Rows)
            {
                int channelID = (int)dataRow["ChannelID"];
                int clientID = (int)dataRow["ClientID"];


                string filterSql = string.Format(" ClientID = {0} and ChannelID = {1} ", clientID, channelID);

                int totalCount = this.AdoNetDb.ExecuteScalarFormDataTable("TotalCount", filterSql, dsDayTotalCount);
                int downCount = this.AdoNetDb.ExecuteScalarFormDataTable("DownCount", filterSql, dsDayDownCount);
                int interceptCount = this.AdoNetDb.ExecuteScalarFormDataTable("InterceptCount", filterSql, dsDayInterceptCount);
                int downSycnCount = this.AdoNetDb.ExecuteScalarFormDataTable("DownSycnCount", filterSql, dsDayDownSycnCount);

                SPDayReportEntity dayReportEntity = this.SelfDataObj.FindReportByChannelIDChannelIDAndDate(channelID, clientID, date);

                bool hasReport = false;


                if (dayReportEntity == null)
                {
                    dayReportEntity = new SPDayReportEntity();
                    dayReportEntity.ChannelID = channelID;
                    dayReportEntity .ClientID = clientID;

                    try
                    {
                        if(clientID>0)
                        {
                            SPClientEntity spClient =
                                this.DataObjectsContainerIocID.SPClientDataObjectInstance.Load(clientID);

                            if(spClient!=null)
                            {
                                //if(spClient.SPClientGroupID!=null)
                                //{
                                //    dayReportEntity.ClientGroupID = spClient.SPClientGroupID.Id;
                                //}

                                SPClientWrapper clientWrapper = new SPClientWrapper(spClient);

                                if(clientWrapper.DefaultClientChannelSetting!=null)
                                {
                                    dayReportEntity.ChannelClientID = clientWrapper.DefaultClientChannelSetting.Id;
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Logger.Error("��������SPClientGroupID ChannelClientID����"+ex.Message);
                    }
                }
 
                dayReportEntity.UpTotalCount = totalCount;
                dayReportEntity.UpSuccess = 0;
                dayReportEntity.InterceptTotalCount = interceptCount;
                dayReportEntity.InterceptSuccess = 0;
                dayReportEntity.DownTotalCount = downCount;
                dayReportEntity.DownSuccess = downSycnCount;
 

                dayReportEntity.ReportDate = new DateTime(date.Year, date.Month, date.Day);

                this.SelfDataObj.SaveOrUpdate(dayReportEntity);



            }

            this.AdoNetDb.ClearAllReportedData(date);
        }

        [Transaction(ReadOnly = false)]
        public void ReGenerateDayReport(DateTime startDateTime, DateTime endDateTime)
        {
            for (DateTime i = startDateTime; i < endDateTime.AddDays(1); i = i.AddDays(1))
            {
                ReBulidReport(i);
            }
        }

        public DataTable GetProvinceCountReport(int channleId, int clientId, DateTime startDate, DateTime endDate, DataType dType)
        {
            return this.AdoNetDb.CountDataByProvince(channleId, clientId, startDate, endDate, dType.ToString());
        }

        public DayliyReport GetDayReport(DateTime dateTime, SPClientChannelSettingEntity spClientChannelSettingEntity)
        {
            return this.AdoNetDb.GetDayReport(spClientChannelSettingEntity.ChannelID.Id, spClientChannelSettingEntity.ClinetID.Id, dateTime);
        }

        public DataTable GetClientGroupPriceReport(int clientChannelSettingEntitys, DateTime startDate, DateTime endDate)
        {


            return this.AdoNetDb.GetClientGroupPriceReport(clientChannelSettingEntitys, startDate, endDate);
        }

        [Transaction(IsolationLevel.ReadUncommitted)]
        public DataTable GetDayCountReportForMaster(DateTime startDate, DateTime endDate)
        {
            return this.AdoNetDb.GetDayCountReportForMaster(startDate, endDate);
        }

        public DataTable GetReportDataChange(int reportClientChannleId, DateTime startDate, DateTime endDate)
        {
            return this.AdoNetDb.GetReportDataChange(reportClientChannleId, startDate, endDate);
        }

        public DataTable GetALlClientGroupPriceReport(DateTime startDate, DateTime endDate)
        {
            return this.AdoNetDb.GetALlClientGroupPriceReport( startDate, endDate);
        }

        public DataTable GetProvinceReport(DateTime startDate, DateTime endDate, int channelId, int channleClientID, bool? isIntercept)
        {
            return this.AdoNetDb.GetProvinceReport(startDate, endDate, channelId, channleClientID, isIntercept);
        }

        public DataTable GetOperatorReport(DateTime startDate, DateTime endDate, int channleId, int clientChannleId, bool? isIntercept, string mprovince, string moperator)
        {
            return this.AdoNetDb.GetOperatorReport(startDate, endDate, channleId, clientChannleId, isIntercept,mprovince,   moperator);
        }

        public string GetDbSize()
        {
            return this.AdoNetDb.GetDbSize();
        }

        //[Transaction(ReadOnly = false)]
        //public void ArchivesData(string archivesPath, DateTime startDate, DateTime endDate)
        //{
        //    for (DateTime i = startDate; i < endDate.AddDays(1); i=i.AddDays(1))
        //    {
        //        ArchivesData(archivesPath, i);
        //    }
        //}

        public DataTable GetDayliyReport(DateTime dateTime)
        {
            return this.AdoNetDb.GetDayliyReport(dateTime);
        }

        public DataTable GetTodayReport(int clientId, int channelId)
        {
            return this.AdoNetDb.GetTodayReport(clientId, channelId);
        }

        public DataTable GetCountReport(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime)
        {
            return this.AdoNetDb.GetDayliyReport(channelId, clientId, startDateTime, enddateTime);
        }

        public DataTable GetCountReportForMaster(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime)
        {
            return this.AdoNetDb.GetCountReportForMaster(channelId, clientId, startDateTime, enddateTime);
        }

        public DataTable GetCountReportForMaster(int channelId, DateTime startDateTime, DateTime enddateTime)
        {
            return this.AdoNetDb.GetCountReportForMaster(channelId, startDateTime, enddateTime);
        }

        [Transaction(IsolationLevel.ReadUncommitted)]
        public DataTable GetAllTodayReport(bool filterZeroCountChannel)
        {
            return this.AdoNetDb.GetAllTodayReport(filterZeroCountChannel);
        }

        public DataTable GetTodayReportByClientGroupID(int clientGroupId)
        {
            return this.AdoNetDb.GetTodayReportByClientGroupID(clientGroupId);
        }

        public DataTable GetTodayReportByClientID(int clientId)
        {
            return this.AdoNetDb.GetTodayReportByClientID(clientId);
        }

        public DataTable GetCountReportByClientID(int spClientId, DateTime startDate, DateTime enddate)
        {
            return this.AdoNetDb.GetCountReportByClientID(spClientId,startDate, enddate);
        }

        public DataTable GetCountReportByClientGroupID(int spClientGroupId, DateTime startDate, DateTime enddate)
        {
            return this.AdoNetDb.GetCountReportByClientGroupID(spClientGroupId,  startDate, enddate);
        }




        //[Transaction(ReadOnly = false)]
        //private void ArchivesData(string archivesPath, DateTime dateTime)
        //{
        //    BulidReport(dateTime);

        //    DataSet ds = this.AdoNetDb.GetAllReportData(dateTime);

        //    if(ds.Tables[0].Rows.Count ==0)
        //        return;

        //    string fileName = GetFileName(archivesPath, dateTime);

        //    WriteDataSetToXml(archivesPath, Path.GetFileNameWithoutExtension(fileName)+".jpg", ds);

        //    WriteDataSetToXml(archivesPath, Path.GetFileNameWithoutExtension(fileName) + ".zip", ds);

        //    //this.AdoNetDb.DeleteAllReportData(dateTime);
        //}

        private string GetFileName(string reportOutPutPath, DateTime date)
        {
            int i = 1;

            bool existFileName = false;

            string fileName = "";

            do
            {
                existFileName =
                    File.Exists(Path.Combine(reportOutPutPath, date.ToString("yyyyMMdd") + i.ToString("D3") + ".zip"));

                fileName = Path.Combine(reportOutPutPath, date.ToString("yyyyMMdd") + i.ToString("D3") + ".zip");

                i++;


            } while (existFileName);

            return fileName;
        }

        private void WriteDataSetToXml(string reportOutPutPath, string fileName, DataSet dsReportDate)
        {
            string filePath = Path.Combine(reportOutPutPath, fileName);

            if (File.Exists(filePath))
                File.Delete(filePath);

            MemoryStream ms = new MemoryStream();

            dsReportDate.WriteXml(ms);

            File.WriteAllBytes(filePath, CompressionUtil.CompressZipFile(ms.ToArray(), Path.GetFileNameWithoutExtension(fileName)+".xml"));
        }

        public DataTable GetDayReport( DateTime startDate, DateTime enddate,string dateType)
        {
            return this.AdoNetDb.GetDayReport(startDate, enddate, dateType);
        }

        public DataTable GetClientGroupDayReport(DateTime startDate, DateTime endDate , int clientGroupId)
        {
            return this.AdoNetDb.GetClientGroupDayReport(startDate, endDate, clientGroupId);
        }

        public DataTable GetClientGroupTotalReport(DateTime startDate, DateTime endDate)
        {
            return this.AdoNetDb.GetClientGroupTotalReport(startDate, endDate);
        }

        public List<SPDayReportEntity> GetAllClientGroupDayReport(DateTime startDate, DateTime endDate, int clientGroupId)
        {
            List<SPDayReportEntity> spDayReports = new List<SPDayReportEntity>();

            for(DateTime st = startDate.Date;st<endDate.Date.AddDays(1);st=st.AddDays(1))
            {
                spDayReports.AddRange(GetAllClientGroupDayReport(st, clientGroupId));
            }

            int i = 1;

            foreach (SPDayReportEntity spDayReportEntity in spDayReports)
            {
                spDayReportEntity.ReportID = i;
                i++;
            }

            return spDayReports;
        }

        public DataTable GetALlChannelReport(DateTime startDate, DateTime endDate)
        {
            return this.AdoNetDb.GetALlChannelReport(startDate, endDate);
        }

        private List<SPDayReportEntity> GetAllClientGroupDayReport(DateTime reportDate, int clientGroupId)
        {
            //List<SPClientEntity> clients =
            //    this.DataObjectsContainerIocID.SPClientDataObjectInstance.GetList_By_SPClientGroupEntity(
            //        this.DataObjectsContainerIocID.SPClientGroupDataObjectInstance.Load(clientGroupId));

            return this.AdoNetDb.GetAllClientGroupDayReport(reportDate, clientGroupId);
        }
    }
}
