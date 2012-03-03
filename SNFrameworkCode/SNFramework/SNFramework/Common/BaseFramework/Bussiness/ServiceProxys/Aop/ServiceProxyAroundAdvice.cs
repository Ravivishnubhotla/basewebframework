using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AopAlliance.Intercept;
using Common.Logging;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Aop
{
    public class ServiceProxyAroundAdvice : IMethodInterceptor
    {
        private static ILog logger = LogManager.GetLogger(typeof(ServiceProxyAroundAdvice));

        public object Invoke(IMethodInvocation invocation)
        {
            bool needAuditor = false;

            var attr = invocation.Method.GetCustomAttributes(typeof(RecordAuditorLogAttribute), false).FirstOrDefault() as RecordAuditorLogAttribute;

            needAuditor = (attr != null);

            logger.Info("开始:  " + invocation.TargetType.Name + "." + invocation.Method.Name);
            
            object result = invocation.Proceed();

            if (needAuditor)
            {

            }

            logger.Info("结束:  " + invocation.TargetType.Name + "." + invocation.Method.Name);
            
            return result;
        }
    }
}
