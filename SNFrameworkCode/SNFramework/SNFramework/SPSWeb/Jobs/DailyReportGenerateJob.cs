using System;
using Common.Logging;
using Quartz;
using SPS.Bussiness.Wrappers;
using Spring.Scheduling.Quartz;

namespace SPSWeb.Jobs
{
    public class DailyReportGenerateJob : QuartzJobObject
    {
        private ILog logger = LogManager.GetLogger(typeof(DailyReportGenerateJob));

        protected override void ExecuteInternal(JobExecutionContext context)
        {
            logger.Info("日报表任务开始。。。");

            try
            {
                SPDayReportWrapper.ReGenerateDayReport(DateTime.Now.AddDays(-1));

                logger.Info("日报表任务成功。。。");
            }
            catch (Exception ex)
            {
                logger.Error("日报表任务失败:" + ex.Message);
            }
        }
    }
}