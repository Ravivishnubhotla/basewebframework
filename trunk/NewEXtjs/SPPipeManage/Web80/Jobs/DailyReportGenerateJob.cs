using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Logging;
using Quartz;
using Spring.Scheduling.Quartz;

namespace Legendigital.Common.Web.Jobs
{
    public class DailyReportGenerateJob : QuartzJobObject
    {
        private ILog logger = LogManager.GetLogger(typeof (DailyReportGenerateJob));


        protected override void ExecuteInternal(JobExecutionContext context)
        {
            logger.Error("1111111111111111111111111111111111111111s");
        }
    }
}
