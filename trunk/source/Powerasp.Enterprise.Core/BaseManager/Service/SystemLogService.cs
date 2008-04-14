using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Powerasp.Enterprise.Core.Business;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    public enum SecurityVisitOperation{LoginOk,LoginFailed,LogOut,LoginTimeOut,HasNoPermissionToVisit}
    public enum LogLevel { Info,Warning,Debug,Error }
    public enum LogType { SecurityVisit, Authorization,BussnessOperation }


    [Transactional]
    public class SystemLogService : BaseServices<SystemLog>
    {
        public SystemLogService(SystemLogDao selfDao) : base(selfDao)
        {
        }
		
        public string GenerateOperationOKInfo(string userName,string operationInfo)
        {
            return string.Format("�û�{0}��{1}ʱ�����{2}�����ɹ���", userName, System.DateTime.Now, operationInfo);
        }
        public string GenerateOperationFailedInfo(string userName, string operationInfo,string errorInfo)
        {
            return string.Format("�û�{0}��{1}ʱ�����{2}����ʧ�ܣ�������Ϣ��{3}��", userName, System.DateTime.Now, operationInfo,errorInfo);
        }

        public override void Create(SystemLog obj)
        {
            base.Create(obj);
            this.Logger.Info(obj.LogDescrption);
        }


        //public void RecordWebSecurityVisitInfo(HttpContext context, SecurityVisitOperation securityOperation, SecurityVisitOperation securityVisitOperation)
        //{

        //}

        //public void RecordSecurityVisitInfo(HttpContext context, SecurityVisitOperation securityOperation)
        //{

        //}

        //public void RecordSecurityVisitInfo(HttpContext context, SecurityVisitOperation securityOperation)
        //{

        //}

    }
}
