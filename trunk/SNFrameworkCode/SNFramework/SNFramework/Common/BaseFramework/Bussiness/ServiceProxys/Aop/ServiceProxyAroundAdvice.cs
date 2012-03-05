using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using AopAlliance.Intercept;
using Common.Logging;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.BaseFramework.Web;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Aop
{
    public class ServiceProxyAroundAdvice : IMethodInterceptor
    {
        private static ILog logger = LogManager.GetLogger(typeof(ServiceProxyAroundAdvice));

        private static Dictionary<Type, RecordAuditorClassAttribute> recordAuditors = new Dictionary<Type, RecordAuditorClassAttribute>();

        public RecordAuditorClassAttribute GetRecordAuditorAttribute(Type type)
        {
            if (recordAuditors.ContainsKey(type))
            {
                return recordAuditors[type];
            }

            var attr = type.GetCustomAttributes(typeof(RecordAuditorClassAttribute), false).FirstOrDefault() as RecordAuditorClassAttribute;

            if (attr != null)
            {
                recordAuditors[type] = attr;
            }
            else
            {
                recordAuditors[type] = new RecordAuditorClassAttribute() { EnableVersion = false };
            }


            return recordAuditors[type];
        }

        public object Invoke(IMethodInvocation invocation)
        {
            RecordAuditorClassAttribute auditorClassAttribute = GetRecordAuditorAttribute(invocation.TargetType);

            logger.Info("开始:  " + invocation.TargetType.Name + "." + invocation.Method.Name);

 
            DateTime operateTime = System.DateTime.Now;

            int operateUserID = SystemUserWrapper.GetCurrentOperateUserID();

            switch (invocation.Method.Name)
            {
                case "Save":
                    SetCreateInfo(invocation.Arguments[0], operateTime, operateUserID, invocation.Method.Name);
                    break;
                case "Update":
                    SetUpdateInfo(invocation.Arguments[0], operateTime, operateUserID, invocation.Method.Name);
                    break;
                case "SaveOrUpdate":
                    break;
            }
     

            object result = invocation.Proceed();

            logger.Info("结束:  " + invocation.TargetType.Name + "." + invocation.Method.Name);
            
            return result;
        }

        private void SetCreateInfo(object saveEntity, DateTime operateTime, int operateUserId, string opName)
        {
            IAuditableEntity iSaveEntity = saveEntity as IAuditableEntity;

            if (iSaveEntity != null)
            {
                iSaveEntity.CreateAt = operateTime;
                iSaveEntity.CreateBy = operateUserId;
                iSaveEntity.LastModifyComment = opName;
            }
        }

        private void SetUpdateInfo(object updateEntity, DateTime operateTime, int operateUserId, string opName)
        {
            IAuditableEntity iUpdateEntity = updateEntity as IAuditableEntity;

            if (iUpdateEntity != null)
            {
                iUpdateEntity.LastModifyAt = operateTime;
                iUpdateEntity.LastModifyBy = operateUserId;
                iUpdateEntity.LastModifyComment = opName;
            }
        }
    }
}
