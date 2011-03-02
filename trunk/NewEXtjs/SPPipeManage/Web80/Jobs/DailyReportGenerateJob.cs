using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Logging;
using LD.SPPipeManage.Bussiness.Wrappers;
using Quartz;
using Spring.Scheduling.Quartz;

namespace Legendigital.Common.Web.Jobs
{
    public class DailyReportGenerateJob : QuartzJobObject
    {
        private ILog logger = LogManager.GetLogger(typeof (DailyReportGenerateJob));

        private string reportOutPutPath;

        /// <summary>
        /// Simple property that can be injected.
        /// </summary>
        public string ReportOutPutPath
        {
            set { reportOutPutPath = value; }
        }

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
