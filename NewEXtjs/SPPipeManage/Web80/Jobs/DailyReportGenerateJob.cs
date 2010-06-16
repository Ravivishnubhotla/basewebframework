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

        private string userName;

        /// <summary>
        /// Simple property that can be injected.
        /// </summary>
        public string UserName
        {
            set { userName = value; }
        }

        //public void Execute(JobExecutionContext context)
        //{
        //    //System.Configuration.NameValueSectionHandler
        //    logger.Error("1111111111111111111111111111111111111111s");
        //}

        protected override void ExecuteInternal(JobExecutionContext context)
        {
            logger.Info("Daily Report Generate Job Start");
        }
    }
}
