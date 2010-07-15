// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Data;
using LD.SPPipeManage.Entity.CustomTyoe;
using Spring.Data.Common;

namespace LD.SPPipeManage.Data.AdoNet
{











    public partial class AdoNetDataObject
    {
        #region Common

        private T GetScalarFromDataSet<T>(DataTable dt, int columnIndex)
        {
            DataRow dr = GetFristDataRowFromDataTable(dt);

            if (dr != null && dr.Table.Columns.Count >= columnIndex + 1)
                return (T) dr[columnIndex];
            return default(T);
        }

        private T GetScalarFromDataSet<T>(DataSet ds, int columnIndex)
        {
            return GetScalarFromDataSet<T>(GetDataTableFromDataSet(ds), columnIndex);
        }

        private DataRow GetFristDataRowFromDataSet(DataSet ds)
        {
            return GetFristDataRowFromDataTable(GetDataTableFromDataSet(ds));
        }

        private DataRow GetFristDataRowFromDataTable(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
                return dt.Rows[0];
            return null;
        }

        private DataTable GetDataTableFromDataSet(DataSet ds)
        {
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        #endregion

        public DataSet GetAllNOReportData(int year, int month, int day)
        {
            string sql = "Select * from wiew_NoPayReport where CYear = @year and  CMonth =  @month and  CDay=@day";
 
            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("year", year.ToString());

            dbParameters.AddWithValue("month", month.ToString());

            dbParameters.AddWithValue("day", day.ToString());

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters);
        }

        public void ClearAllReportedData(DateTime date)
        {
            string sql = "update SPPaymentInfo set  IsReport = 1  where Year(CreateDate) = @year and  Month(CreateDate) =  @month and  Day(CreateDate)=@day and  IsReport = 0";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("year", date.Year.ToString());

            dbParameters.AddWithValue("month", date.Month.ToString());

            dbParameters.AddWithValue("day", date.Day.ToString());

            this.ExecuteNoQuery(sql, CommandType.Text, dbParameters);
        }

        public DataSet GetAllClientChannel()
        {
            string sql = "Select * from view_ClientChannel";

            DbParameters dbParameters = this.CreateNewDbParameters();

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters);
        }


        public string GetDbSize()
        {
            string sql = "exec sp_spaceused";

            DbParameters dbParameters = this.CreateNewDbParameters();

            DataSet ds = this.ExecuteDataSet(sql, CommandType.Text, dbParameters);

            return ds.Tables[0].Rows[0]["database_size"].ToString();
        }


        public void DeleteAllReportData(DateTime date)
        {
            string sql = "delete from SPPaymentInfo where Year(CreateDate) = @year and  Month(CreateDate) =  @month and  Day(CreateDate)=@day and IsReport = 1";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("year", date.Year.ToString());

            dbParameters.AddWithValue("month", date.Month.ToString());

            dbParameters.AddWithValue("day", date.Day.ToString());

            this.ExecuteNoQuery(sql, CommandType.Text, dbParameters);
        }


        public DataSet GetAllReportData(DateTime date)
        {
            string sql = "Select * from SPPaymentInfo where Year(CreateDate) = @year and  Month(CreateDate) =  @month and  Day(CreateDate)=@day and IsReport = 1";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("year", date.Year.ToString());

            dbParameters.AddWithValue("month", date.Month.ToString());

            dbParameters.AddWithValue("day", date.Day.ToString());

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters);
        }

        public DataTable GetDayliyReport(DateTime date)
        {
            DataTable reportDt = new DataTable();


            DataColumn dc = new DataColumn("ReportID", typeof(int));
            reportDt.Columns.Add(dc);
            reportDt.PrimaryKey = new DataColumn[] { dc };

            reportDt.Columns.Add(new DataColumn("ChannelName", typeof(string)));
            reportDt.Columns.Add(new DataColumn("ClientName", typeof(string)));
            reportDt.Columns.Add(new DataColumn("TotalCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("DownCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("InterceptCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("DownSycnCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("InterceptRate", typeof(decimal)));

            reportDt.AcceptChanges();

            DataTable dtChannelClient = GetAllEnableChannelClient();

            int j = 0;

            DataTable dsDaySumReport = GetDaySumReport(date.Date);

            foreach (DataRow rowChannelClient in dtChannelClient.Rows)
            {
                j++;

                ReportResult reportResult = GetTodayReportResult((int)rowChannelClient["ClientID"], (int)rowChannelClient["ChannelID"], dsDaySumReport);

                reportDt.Rows.Add(j,
                                  rowChannelClient["ChannelName"],
                                  rowChannelClient["ClientName"],
                                  reportResult.TotalCount,
                                  reportResult.DownCount,
                                  reportResult.InterceptCount,
                                  reportResult.DownSycnCount,
                                  reportResult.InterceptRate);
            }

            return reportDt;
        }

        private ReportResult GetTodayReportResult(int clientId, int channelId, DataTable dsDaySumReport)
        {
            ReportResult reportResult = new ReportResult();

            reportResult.ReportDate = DateTime.Now;

            string filterSql = string.Format(" ClientID = {0} and ChannelID = {1} ", clientId, channelId);

            DataRow[] drs = dsDaySumReport.Select(filterSql);

            reportResult.TotalCount = ExecuteScalarFormDataRowArray("UpTotalCount", drs);
            reportResult.DownCount = ExecuteScalarFormDataRowArray("DownTotalCount", drs);
            reportResult.InterceptCount = ExecuteScalarFormDataRowArray("InterceptTotalCount", drs);
            reportResult.DownSycnCount = ExecuteScalarFormDataRowArray("DownSuccess", drs);

            if (reportResult.TotalCount == 0)
                reportResult.InterceptRate = 0;
            else
                reportResult.InterceptRate = (decimal)(reportResult.InterceptCount * 100) / (decimal)(reportResult.TotalCount);


            return reportResult;
        }

        public int ExecuteScalarFormDataRowArray(string field, DataRow[] drs)
        {
            if (drs.Length <= 0)
                return 0;

            if (drs[0][field]==System.DBNull.Value)
                return 0;

            return (int) drs[0][field];
        }

        private DataTable GetDaySumReport(DateTime date)
        {
            string sql = "SELECT * from [view_PaymentReportSum] where Year = @year and  Month =  @month and  Day=@day";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("year", date.Year);

            dbParameters.AddWithValue("month", date.Month);

            dbParameters.AddWithValue("day", date.Day);

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }

        public DataTable GetTodayReport(int clientId, int channelId)
        {
            string sql = "";

            if(channelId!=0)
            {
                sql = "SELECT ClientID, ChannelID, CHour, COUNT(*) AS Total FROM ClientToDayPaymentRecord Where (ChannelID = @ChannelID) AND (ClientID = @ClientID) GROUP BY ClientID, ChannelID, CHour  ";
            }
            else
            {
                sql = "SELECT ClientID, CHour, COUNT(*) AS Total FROM ClientToDayPaymentRecord where ClientID =  @ClientID GROUP BY ClientID, ChannelID, CHour   ";              
            }

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("ClientID", clientId);

            if (channelId != 0)
            {
                dbParameters.AddWithValue("ChannelID", channelId);
            }

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }



        public DataTable GetDayliyReport(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime)
        {

            DataTable reportDt = new DataTable();


            DataColumn dc = new DataColumn("RID",typeof(int));
            reportDt.Columns.Add(dc);
            reportDt.PrimaryKey = new DataColumn[]{dc};

            reportDt.Columns.Add(new DataColumn("ReportDate", typeof(DateTime)));
            reportDt.Columns.Add(new DataColumn("DataCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("Price", typeof(decimal)));

            reportDt.AcceptChanges();

            int j = 0;

            for (DateTime i = startDateTime; i < enddateTime.AddDays(1); i = i.AddDays(1))
            {
                string sql = "";

                if (channelId != 0)
                {
                    sql = "SELECT  ClientID,ChannelID,Sum(UpTotalCount) as TotalCount,Sum(InterceptSuccess) as InterceptCount,Sum(DownSuccess) as DownTotal FROM [dbo].[view_ReportDayTotal] where Year = @year and  Month =  @month and  Day=@day and ClientID = @ClientID and ChannelID=@ChannelID group by  ClientID,ChannelID";
                }
                else
                {
                    sql = "SELECT  ClientID,Sum(UpTotalCount) as TotalCount,Sum(InterceptSuccess) as InterceptCount,Sum(DownSuccess) as DownTotal FROM [dbo].[view_ReportDayTotal] where Year = @year and  Month =  @month and  Day=@day and ClientID = @ClientID group by  ClientID";
                }

                DbParameters dbParameters = this.CreateNewDbParameters();

                dbParameters.AddWithValue("year", i.Year);

                dbParameters.AddWithValue("month", i.Month);

                dbParameters.AddWithValue("day", i.Day);

                dbParameters.AddWithValue("ClientID", clientId);

                if (channelId != 0)
                {
                    dbParameters.AddWithValue("ChannelID", channelId);
                }

                DataTable dt = this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];

                j++;

                if(dt==null|| dt.Rows.Count==0)
                {
                    reportDt.Rows.Add(j,i, 0, 0);
                }
                else
                {
                    reportDt.Rows.Add(j, i, dt.Rows[0]["DownTotal"], 0);      
                }
            }

            return reportDt;
        }

        public ReportResult GetDayReportResult(int clientID, int channelID, DataTable dsDayTotalCount, DataTable dsDayDownCount, DataTable dsDayInterceptCount, DataTable dsDayDownSycnCount)
        {
            ReportResult reportResult = new ReportResult();

            reportResult.ReportDate = DateTime.Now;

            string filterSql = string.Format(" ClientID = {0} and ChannelID = {1} ", clientID, channelID);

            reportResult.TotalCount = ExecuteScalarFormDataTable("TotalCount", filterSql, dsDayTotalCount);
            reportResult.DownCount = ExecuteScalarFormDataTable("DownCount", filterSql, dsDayDownCount);
            reportResult.InterceptCount = ExecuteScalarFormDataTable("InterceptCount", filterSql, dsDayInterceptCount);
            reportResult.DownSycnCount = ExecuteScalarFormDataTable("DownSycnCount", filterSql, dsDayDownSycnCount);

            if (reportResult.TotalCount == 0)
                reportResult.InterceptRate = 0;
            else
                reportResult.InterceptRate = (decimal)(reportResult.InterceptCount * 100) / (decimal)(reportResult.TotalCount);


            return reportResult;
        }


        public DataTable GetDayTotalCount(DateTime date)
        {
            string sql = "SELECT * from view_PaymentReportAllTotalCount where CYear = @year and  CMonth =  @month and  CDay=@day ";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("year", date.Year);

            dbParameters.AddWithValue("month", date.Month);

            dbParameters.AddWithValue("day", date.Day);

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }

        public DataTable GetDayDownCount(DateTime date)
        {
            string sql = "SELECT * from view_PaymentReportAllDownCount where CYear = @year and  CMonth =  @month and  CDay=@day ";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("year", date.Year);

            dbParameters.AddWithValue("month", date.Month);

            dbParameters.AddWithValue("day", date.Day);

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }

        public DataTable GetDayInterceptCount(DateTime date)
        {
            string sql = "SELECT * from view_PaymentReportAllInterceptCount where CYear = @year and  CMonth =  @month and  CDay=@day ";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("year", date.Year);

            dbParameters.AddWithValue("month", date.Month);

            dbParameters.AddWithValue("day", date.Day);

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }

        public DataTable GetDayDownSycnCount(DateTime date)
        {
            string sql = "SELECT * from view_PaymentReportAllDownSycnCount where CYear = @year and  CMonth =  @month and  CDay=@day ";

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("year", date.Year);

            dbParameters.AddWithValue("month", date.Month);

            dbParameters.AddWithValue("day", date.Day);

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }





        #region TodayReport

        public DataTable GetAllTodayReport()
        {
            DataTable reportDt = new DataTable();


            DataColumn dc = new DataColumn("ReportID", typeof(int));
            reportDt.Columns.Add(dc);
            reportDt.PrimaryKey = new DataColumn[] { dc };

            reportDt.Columns.Add(new DataColumn("ChannelName", typeof(string)));
            reportDt.Columns.Add(new DataColumn("ClientName", typeof(string)));
            reportDt.Columns.Add(new DataColumn("TotalCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("DownCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("InterceptCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("DownSycnCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("InterceptRate", typeof(decimal)));

            reportDt.AcceptChanges();

            DataTable dtChannelClient = GetAllChannelClient();

            int j = 0;

            DataTable dsTodayTotalCount = GetTodayTotalCount();
            DataTable dsTodayDownCount = GetTodayDownCount();
            DataTable dsTodayInterceptCount = GetTodayInterceptCount();
            DataTable dsTodayDownSycnCount = GetTodayDownSycnCount();    



            foreach (DataRow rowChannelClient in dtChannelClient.Rows)
            {
                j++;

                ReportResult reportResult = GetTodayReportResult((int)rowChannelClient["ClientID"], (int)rowChannelClient["ChannelID"], dsTodayTotalCount, dsTodayDownCount, dsTodayInterceptCount, dsTodayDownSycnCount);

                reportDt.Rows.Add(j, 
                                  rowChannelClient["ChannelName"], 
                                  rowChannelClient["ClientName"],
                                  reportResult.TotalCount, 
                                  reportResult.DownCount, 
                                  reportResult.InterceptCount,
                                  reportResult.DownSycnCount,
                                  reportResult.InterceptRate);
            }

            return reportDt;
        }

        private ReportResult GetTodayReportResult(int clientID, int channelID, DataTable dsTodayTotalCount, DataTable dsTodayDownCount, DataTable dsTodayInterceptCount, DataTable dsTodayDownSycnCount)
        {
            ReportResult reportResult = new ReportResult();

            reportResult.ReportDate = DateTime.Now;

            string filterSql = string.Format(" ClientID = {0} and ChannelID = {1} ", clientID, channelID);

            reportResult.TotalCount = ExecuteScalarFormDataTable("TotalCount", filterSql, dsTodayTotalCount);
            reportResult.DownCount = ExecuteScalarFormDataTable("DownCount", filterSql, dsTodayDownCount);
            reportResult.InterceptCount = ExecuteScalarFormDataTable("InterceptCount", filterSql, dsTodayInterceptCount);
            reportResult.DownSycnCount = ExecuteScalarFormDataTable("DownSycnCount", filterSql, dsTodayDownSycnCount);

            if (reportResult.TotalCount==0)
                reportResult.InterceptRate = 0;
            else
                reportResult.InterceptRate = (decimal)(reportResult.InterceptCount*100) / (decimal)(reportResult.TotalCount);


            return reportResult;
        }

        private DataTable GetTodayTotalCount()
        {
            string sql = "SELECT * from view_PaymentReportTodayTotalCount ";

            DbParameters dbParameters = this.CreateNewDbParameters();

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }

        private DataTable GetTodayDownCount()
        {
            string sql = "SELECT * from view_PaymentReportTodayDownCount ";

            DbParameters dbParameters = this.CreateNewDbParameters();

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }

        private DataTable GetTodayInterceptCount()
        {
            string sql = "SELECT * from view_PaymentReportTodayInterceptCount ";

            DbParameters dbParameters = this.CreateNewDbParameters();

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }

        private DataTable GetTodayDownSycnCount()
        {
            string sql = "SELECT * from view_PaymentReportTodayDownSycnCount ";

            DbParameters dbParameters = this.CreateNewDbParameters();

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }

        #endregion



        public DataTable GetAllChannelClient()
        {
            string sql = "SELECT * FROM [view_AllClientChannel]";

            DbParameters dbParameters = this.CreateNewDbParameters();

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }

        public DataTable GetAllEnableChannelClient()
        {
            string sql = "SELECT * FROM [view_PaymentReportClientChannel]";

            DbParameters dbParameters = this.CreateNewDbParameters();

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }


        public int ExecuteScalarFormDataTable(string scalarField, string filterExpress, DataTable dt)
        {
            DataRow[] selectDrs = dt.Select(filterExpress);

            if (selectDrs.Length > 0)
            {
                object result = selectDrs[0][scalarField];

                if (result == System.DBNull.Value)
                {
                    return 0;
                }
                else
                {
                    return (int)result;
                }
            }

            return 0;
        }


        public DataTable GetCountReportForMaster(int channelId, int clientId, DateTime startDateTime, DateTime enddateTime)
        {
            DataTable reportDt = new DataTable();


            DataColumn dc = new DataColumn("ReportID", typeof(int));
            reportDt.Columns.Add(dc);
            reportDt.PrimaryKey = new DataColumn[] { dc };

            reportDt.Columns.Add(new DataColumn("ChannelName", typeof(string)));
            reportDt.Columns.Add(new DataColumn("ClientName", typeof(string)));
            reportDt.Columns.Add(new DataColumn("TotalCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("DownCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("InterceptCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("DownSycnCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("InterceptRate", typeof(decimal)));
            reportDt.Columns.Add(new DataColumn("ReportDate", typeof(DateTime)));

            reportDt.AcceptChanges();

            DataTable dtChannelClient = GetAllEnableChannelClient();

            int j = 0;

            DataTable dCountReportForMaster = QueryReportForMaster(channelId, clientId, startDateTime.Date, enddateTime.Date);

            foreach (DataRow rowChannelClient in dtChannelClient.Rows)
            {
                if (channelId > 0)
                {
                    if ((int)rowChannelClient["ChannelID"] != channelId)
                        continue;
                }
                if (clientId > 0)
                {
                    if ((int)rowChannelClient["ClientID"] != clientId)
                        continue;
                }

                for (DateTime i = startDateTime; i < enddateTime.AddDays(1); i = i.AddDays(1))
                {
                    j++;

                    ReportResult reportResult = GetReportResult((int)rowChannelClient["ClientID"], (int)rowChannelClient["ChannelID"], i, dCountReportForMaster);

                    reportDt.Rows.Add(j,
                                      rowChannelClient["ChannelName"],
                                      rowChannelClient["ClientName"],
                                      reportResult.TotalCount,
                                      reportResult.DownCount,
                                      reportResult.InterceptCount,
                                      reportResult.DownSycnCount,
                                      reportResult.InterceptRate, i.Date);
                }
            }

            return reportDt;
        }

        public DataTable GetCountReportForMaster(int channelId, DateTime startDateTime, DateTime enddateTime)
        {
            DataTable reportDt = new DataTable();


            DataColumn dc = new DataColumn("ReportID", typeof(int));
            reportDt.Columns.Add(dc);
            reportDt.PrimaryKey = new DataColumn[] { dc };

            reportDt.Columns.Add(new DataColumn("ChannelName", typeof(string)));
            reportDt.Columns.Add(new DataColumn("ClientName", typeof(string)));
            reportDt.Columns.Add(new DataColumn("TotalCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("DownCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("InterceptCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("DownSycnCount", typeof(int)));
            reportDt.Columns.Add(new DataColumn("InterceptRate", typeof(decimal)));
            reportDt.Columns.Add(new DataColumn("ReportDate", typeof(DateTime)));

            reportDt.AcceptChanges();

            DataTable dtChannelClient = GetAllEnableChannelClient();

            int j = 0;

            DataTable dCountReportForMaster = QueryReportForMaster(channelId, 0, startDateTime.Date, enddateTime.Date);

            foreach (DataRow rowChannelClient in dtChannelClient.Rows)
            {
                if (channelId>0)
                {
                    if ((int)rowChannelClient["ChannelID"] != channelId)
                        continue;
                }


                for (DateTime i = startDateTime; i < enddateTime.AddDays(1); i = i.AddDays(1))
                {
                    j++;

                    ReportResult reportResult = GetReportResult((int)rowChannelClient["ClientID"], (int)rowChannelClient["ChannelID"], i, dCountReportForMaster);

                    reportDt.Rows.Add(j,
                                      rowChannelClient["ChannelName"],
                                      rowChannelClient["ClientName"],
                                      reportResult.TotalCount,
                                      reportResult.DownCount,
                                      reportResult.InterceptCount,
                                      reportResult.DownSycnCount,
                                      reportResult.InterceptRate,i.Date);
                }
            }

            return reportDt;
        }

        private ReportResult GetReportResult(int clientID, int channelID,DateTime dateTime, DataTable dCountReportForMaster)
        {
            ReportResult reportResult = new ReportResult();

            reportResult.ReportDate = DateTime.Now;

            string filterSql = string.Format(" ReportDate='{0}' ", dateTime);
            
            if(channelID>0)
            {
                filterSql += string.Format(" And  channelId = {0} ",channelID);
            }

            if (clientID > 0)
            {
                filterSql += string.Format(" And  clientID = {0} ",clientID);
            }

            reportResult.TotalCount = ExecuteSumFormDataTable("UpTotalCount", filterSql, dCountReportForMaster);
            reportResult.DownCount = ExecuteSumFormDataTable("DownTotalCount", filterSql, dCountReportForMaster);
            reportResult.InterceptCount = ExecuteSumFormDataTable("InterceptTotalCount", filterSql, dCountReportForMaster);
            reportResult.DownSycnCount = ExecuteSumFormDataTable("DownSuccess", filterSql, dCountReportForMaster);

            if (reportResult.TotalCount == 0)
                reportResult.InterceptRate = 0;
            else
                reportResult.InterceptRate = (decimal)(reportResult.InterceptCount * 100) / (decimal)(reportResult.TotalCount);


            return reportResult;
        }

        private int ExecuteSumFormDataTable(string field, string filterSql, DataTable dCountReportForMaster)
        {
            object result = dCountReportForMaster.Compute(string.Format(" SUM({0}) ", field), filterSql);

            if (result == System.DBNull.Value)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(result);
            }

            return 0;
        }

        private DataTable QueryReportForMaster(int channelId, int clientID, DateTime startDateTime, DateTime enddateTime)
        {
            string sql = "SELECT * from [view_PaymentReportSum] where ReportDate>@startDate and ReportDate<@enddate ";

            if(channelId>0)
            {
                sql += " And  channelId = @channelId ";
            }

            if (clientID > 0)
            {
                sql += " And  clientID = @clientID ";
            }

            DbParameters dbParameters = this.CreateNewDbParameters();

            dbParameters.AddWithValue("startDate", startDateTime.Date);

            dbParameters.AddWithValue("enddate", enddateTime.AddDays(1).Date);

            if (channelId > 0)
            {
                dbParameters.AddWithValue("channelId", channelId);
            }

            if (clientID > 0)
            {
                dbParameters.AddWithValue("clientID", clientID);
            }

            return this.ExecuteDataSet(sql, CommandType.Text, dbParameters).Tables[0];
        }
    }
}