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
            logger.Info("Daily Report Generate Job Start");

            try
            {
                SPDayReportWrapper.GenerateDayReport(DateTime.Now.AddDays(-1));


                logger.Info("Daily Report Generate Job End");
            }
            catch (Exception ex)
            {
                logger.Info("Daily Report Generate Job Failed:"+ex.Message);
            }
        }
    }
}
