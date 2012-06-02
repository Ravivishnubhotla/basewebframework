
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemLogWrapper 
    {
        #region Static Common Data Operation

        public static void Save(SystemLogWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemLogWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemLogWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(int id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(int[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SystemLogWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemLogWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemLogWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemLogWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemLogWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemLogWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemLogWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemLogWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
        }

        #endregion

	    public class SysteLogType
	    {
            public const string LoginLog = "系统安全日志";
            public const string OperationLog = "数据操作日志";
	    }

        public class SysteLogLevel
        {
            public const string Info = "Info";
            public const string Error = "Error";
            public const string Warning = "Warning";
        }

	    public static void LogUserLoginSuccessed(SystemUserWrapper user,string ip, DateTime logindate)
        {
            SystemLogWrapper log = new SystemLogWrapper();
            log.LogDate = logindate;
            log.LogDescrption = string.Format("用户{0}于{1}时间成功登陆系统。登陆IP:{2}.", user.UserLoginID, logindate.ToLongTimeString(), ip);
            log.LogLevel = SysteLogLevel.Info;
            log.LogRelateDateTime = logindate;
            log.LogRelateUserID = user.UserID;
            log.LogRelateUserName = user.UserLoginID;
            log.ParentDataType = typeof (SystemUserWrapper).Name.ToString();
            log.ParentDataID = user.UserID;
            log.LogSource = "System";
            log.LogType = SysteLogType.LoginLog;
            Save(log);
        }


        public static void LogUserLoginOutSuccessed(SystemUserWrapper user, string ip, DateTime logindate)
        {
            SystemLogWrapper log = new SystemLogWrapper();
            log.LogDate = logindate;
            log.LogDescrption = string.Format("用户{0}于{1}时间成功注销系统。登陆IP:{2}.", user.UserLoginID, logindate.ToLongTimeString(), ip);
            log.LogLevel = SysteLogLevel.Info;
            log.LogRelateDateTime = logindate;
            log.LogRelateUserID = user.UserID;
            log.LogRelateUserName = user.UserLoginID;
            log.ParentDataType = typeof(SystemUserWrapper).Name.ToString();
            log.ParentDataID = user.UserID;
            log.LogSource = "System";
            log.LogType = SysteLogType.LoginLog;
            Save(log);
        }

        public static void LogUserAutoLoginOutSuccessed(SystemUserWrapper user, string ip, DateTime logindate)
        {
            SystemLogWrapper log = new SystemLogWrapper();
            log.LogDate = logindate;
            log.LogDescrption = string.Format("用户{0}于{1}时间自动注销系统。登陆IP:{2}.", user.UserLoginID, logindate.ToLongTimeString(), ip);
            log.LogLevel = SysteLogLevel.Info;
            log.LogRelateDateTime = logindate;
            log.LogRelateUserID = user.UserID;
            log.LogRelateUserName = user.UserLoginID;
            log.ParentDataType = typeof(SystemUserWrapper).Name.ToString();
            log.ParentDataID = user.UserID;
            log.LogSource = "System";
            log.LogType = SysteLogType.LoginLog;
            Save(log);
        }


        public static void LogUserLoginFailed(string userLoginID, string ip, string reason, DateTime logindate)
        {
            SystemLogWrapper log = new SystemLogWrapper();
            log.LogDate = logindate;
            log.LogDescrption = string.Format("用户{0}于{1}时间登陆系统失败，错误原因{3}。登陆IP:{2}.", userLoginID, logindate.ToLongTimeString(), ip, reason);
            log.LogLevel = SysteLogLevel.Error;
            log.LogRelateDateTime = logindate;
            log.LogRelateUserID = null;
            log.LogRelateUserName = null;
            log.ParentDataType = "N/A";
            log.ParentDataID = null;
            log.LogSource = "System";
            log.LogType = SysteLogType.LoginLog;
            Save(log);
        }


        public static void LogUserOperationAction(SystemUserWrapper user, string operatioMessage, string ip, DateTime opdate, string dataType, int dataid)
        {
            SystemLogWrapper log = new SystemLogWrapper();

            log.LogDate = opdate;
            log.LogDescrption = string.Format("用户{0}于{1}时间{3}，操作IP:{2}.", user.UserLoginID, ip, opdate.ToLongTimeString(), operatioMessage);
            log.LogLevel = SysteLogLevel.Error;
            log.LogRelateDateTime = opdate;
            log.LogRelateUserID = user.UserID;
            log.LogRelateUserName = user.UserLoginID;
            log.ParentDataType = dataType;
            log.ParentDataID = dataid;
            log.LogSource = "System";
            log.LogType = SysteLogType.OperationLog;
            
            Save(log);
        }


        public static void LogUserOperationAction(string operatioMessage, string ip, DateTime opdate, string dataType, int dataid)
        {
            SystemLogWrapper log = new SystemLogWrapper();

            log.LogDate = opdate;
            log.LogDescrption = string.Format("用户{0}于{1}时间{3}，操作IP:{2}.", "", ip, opdate.ToLongTimeString(), operatioMessage);
            log.LogLevel = SysteLogLevel.Error;
            log.LogRelateDateTime = opdate;
            log.LogRelateUserID = 0;
            log.LogRelateUserName = "";
            log.ParentDataType = dataType;
            log.ParentDataID = dataid;
            log.LogSource = "System";
            log.LogType = SysteLogType.OperationLog;

            Save(log);
        }



    }
}
