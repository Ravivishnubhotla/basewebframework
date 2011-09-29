
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
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemLogWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemLogWrapper obj)
        {
            businessProxy.SaveOrUpdate(obj.entity);
        }

        public static void DeleteAll()
        {
            businessProxy.DeleteAll();
        }

        public static void DeleteByID(object id)
        {
            businessProxy.DeleteByID(id);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            businessProxy.PatchDeleteByIDs(ids);
        }

        public static void Delete(SystemLogWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemLogWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemLogWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemLogWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemLogWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemLogEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemLogWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemLogWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemLogWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams));

            return results;
        }
		

		
		#endregion


        public static void LogUserLoginSuccessed(SystemUserWrapper user,string ip, DateTime logindate)
        {
            SystemLogWrapper log = new SystemLogWrapper();
            log.LogDate = logindate;
            log.LogDescrption = string.Format("用户{0}于{1}时间成功登陆系统。登陆IP:{2}.", user.UserLoginID, logindate.ToLongTimeString(), ip);
            log.LogLevel = "Info";
            log.LogRelateDateTime = logindate;
            log.LogRelateUserID = user.UserID;
            log.LogRelateUserName = user.UserLoginID;
            log.ParentDataType = typeof (SystemUserWrapper).Name.ToString();
            log.ParentDataID = user.UserID;
            log.LogSource = "System";
            log.LogType = "系统安全日志";
            Save(log);
        }


        public static void LogUserLoginOutSuccessed(SystemUserWrapper user, string ip, DateTime logindate)
        {
            SystemLogWrapper log = new SystemLogWrapper();
            log.LogDate = logindate;
            log.LogDescrption = string.Format("用户{0}于{1}时间成功注销系统。登陆IP:{2}.", user.UserLoginID, logindate.ToLongTimeString(), ip);
            log.LogLevel = "Info";
            log.LogRelateDateTime = logindate;
            log.LogRelateUserID = user.UserID;
            log.LogRelateUserName = user.UserLoginID;
            log.ParentDataType = typeof(SystemUserWrapper).Name.ToString();
            log.ParentDataID = user.UserID;
            log.LogSource = "System";
            log.LogType = "系统安全日志";
            Save(log);
        }

        public static void LogUserAutoLoginOutSuccessed(SystemUserWrapper user, string ip, DateTime logindate)
        {
            SystemLogWrapper log = new SystemLogWrapper();
            log.LogDate = logindate;
            log.LogDescrption = string.Format("用户{0}于{1}时间自动注销系统。登陆IP:{2}.", user.UserLoginID, logindate.ToLongTimeString(), ip);
            log.LogLevel = "Info";
            log.LogRelateDateTime = logindate;
            log.LogRelateUserID = user.UserID;
            log.LogRelateUserName = user.UserLoginID;
            log.ParentDataType = typeof(SystemUserWrapper).Name.ToString();
            log.ParentDataID = user.UserID;
            log.LogSource = "System";
            log.LogType = "系统安全日志";
            Save(log);
        }


        public static void LogUserLoginFailed(string userLoginID, string ip, string reason, DateTime logindate)
        {
            SystemLogWrapper log = new SystemLogWrapper();
            log.LogDate = logindate;
            log.LogDescrption = string.Format("用户{0}于{1}时间登陆系统失败，错误原因{3}。登陆IP:{2}.", userLoginID, logindate.ToLongTimeString(), ip, reason);
            log.LogLevel = "Error";
            log.LogRelateDateTime = logindate;
            log.LogRelateUserID = null;
            log.LogRelateUserName = null;
            log.ParentDataType = "N/A";
            log.ParentDataID = null;
            log.LogSource = "System";
            log.LogType = "系统安全日志";
            Save(log);
        }


        public static void LogUserOperationAction(SystemUserWrapper user, string operatioMessage, string ip, DateTime opdate, string dataType, int dataid)
        {
            SystemLogWrapper log = new SystemLogWrapper();
            log.LogDate = opdate;
            log.LogDescrption = string.Format("用户{0}于{1}时间{3}，操作IP:{2}.", user.UserLoginID, ip, opdate.ToLongTimeString(), operatioMessage);
            log.LogLevel = "Info";
            log.LogRelateDateTime = opdate;
            log.LogRelateUserID = user.UserID;
            log.LogRelateUserName = user.UserLoginID;
            log.ParentDataType = dataType;
            log.ParentDataID = dataid;
            log.LogSource = "System";
            log.LogType = "数据操作日志";
            
            Save(log);
        }



    }
}
