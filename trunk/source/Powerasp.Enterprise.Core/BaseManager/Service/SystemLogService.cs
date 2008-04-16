using System;
using System.Text;
using System.Web;
using System.Collections.Generic;

using Powerasp.Enterprise.Core.Business;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

using NHibernate.Expression;
using Castle.Services.Transaction;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    public enum SecurityVisitOperation{LoginOk,LoginFailed,LogOut,LoginTimeOut,HasNoPermissionToVisit}
    public enum LogLevel { Info,Warning,Debug,Error }
    public enum LogType { SecurityVisit, Authorization,BussnessOperation }


    [Transactional]
    public class SystemLogService : BaseServices<SystemLog>
    {
        #region 私有变量

        private string _operationOKInfoExp = "用户{0}于{1}时间进行{2}操作成功。";
        private string _operationFailedInfoExp = "用户{0}于{1}时间进行{2}操作失败，错误信息：{3}。";
        
        #endregion

        #region 构造函数

        public SystemLogService(SystemLogDao selfDao) : base(selfDao)
        {

        }

        #endregion
		
        #region 公共方法

        public string GenerateOperationOKInfo(string userName,string operationInfo)
        {
            return string.Format(_operationOKInfoExp, userName, System.DateTime.Now, operationInfo);
        }

        public string GenerateOperationFailedInfo(string userName, string operationInfo,string errorInfo)
        {
            return string.Format(_operationFailedInfoExp, userName, System.DateTime.Now, operationInfo,errorInfo);
        }

        public List<SystemLog> GetAll(int firstRow, int maxRows, out int recordCount)
        {
            List<Order> orders = new List<Order>();
            orders.Add(SystemLogDao.PROPERTY_LOGDATE.Desc());
            List<ICriterion> criterions = new List<ICriterion>();
            return this.FindAll(criterions.ToArray(), orders.ToArray(), firstRow, maxRows, out recordCount);
        }


        #endregion

        #region 重写方法

        public override void Create(SystemLog obj)
        {
            base.Create(obj);
            this.Logger.Info(obj.LogDescrption);
        }

        #endregion

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
