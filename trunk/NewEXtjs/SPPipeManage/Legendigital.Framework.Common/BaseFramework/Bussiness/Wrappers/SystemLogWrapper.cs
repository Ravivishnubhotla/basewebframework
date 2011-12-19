
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;


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

        public static List<SystemLogWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SystemLogEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SystemLogWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SystemLogWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SystemLogWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

		
		#endregion


        public enum SecurityLogType
        {
            LoginSuccessful,
            LoginFailed,
            Logout,
            ChangePasswordSuccessful,
            ChangePasswordFailed
        }

        public enum SystemLogLevel
        {
            Warning,
            Error,
            Info,
            Debug
        }

        public enum MoudleType
        {
            User = 0,
            Channel = 1,
            Client = 2,
            ClientGroup = 3,
            ChannelClientSetting =4,
            Report = 5
        }

        public static void AddSecurityLog(string loginID,DateTime date,string reason,string ip,string ipLocation,SecurityLogType logType)
        {
            try
            {
                SystemUserWrapper user = SystemUserWrapper.GetUserByLoginID(loginID);

                if (user == null)
                    return;

                SystemLogWrapper securityLog = new SystemLogWrapper();
                securityLog.LogDate = date;
                securityLog.LogType = "安全日志";
                securityLog.LogRelateDateTime = date;
                securityLog.LogRelateUserID = user.UserID;
                securityLog.LogRelateMoudleDataID = user.UserID;
                securityLog.LogRelateMoudleID = (int)MoudleType.User;
                securityLog.LogSource = "系统日志";
                securityLog.LogUser = user.UserLoginID;
           

                switch (logType)
                {
                    case SecurityLogType.LoginFailed:
                        securityLog.LogLevel = SystemLogLevel.Warning.ToString();
                        securityLog.LogDescrption = string.Format("用户“{0}”于“{1}”时间登陆系统失败，失败原因：{4}，登陆IP:{2}({3})", user.UserLoginID, date.ToString("yyyy-MM-dd HH:mm:ss"), ip, ipLocation, reason);
                        break;
                    case SecurityLogType.LoginSuccessful:
                        securityLog.LogLevel = SystemLogLevel.Info.ToString();
                        securityLog.LogDescrption = string.Format("用户“{0}”于“{1}”时间登陆系统成功，登陆IP:{2}({3})", user.UserLoginID, date.ToString("yyyy-MM-dd HH:mm:ss"), ip, ipLocation);
                        break;
                    case SecurityLogType.Logout:
                        securityLog.LogLevel = SystemLogLevel.Info.ToString();
                        securityLog.LogDescrption = string.Format("用户“{0}”于“{1}”时间注销登陆，登陆IP:{2}({3})", user.UserLoginID, date.ToString("yyyy-MM-dd HH:mm:ss"), ip, ipLocation);
                        break;
                    case SecurityLogType.ChangePasswordSuccessful:
                        securityLog.LogLevel = SystemLogLevel.Info.ToString();
                        securityLog.LogDescrption = string.Format("用户“{0}”于“{1}”时间更改密码成功，登陆IP:{2}({3})", user.UserLoginID, date.ToString("yyyy-MM-dd HH:mm:ss"), ip, ipLocation);
                        break;
                    case SecurityLogType.ChangePasswordFailed:
                        securityLog.LogLevel = SystemLogLevel.Warning.ToString();
                        securityLog.LogDescrption = string.Format("用户“{0}”于“{1}”时间更改密码失败，登陆IP:{2}({3})", user.UserLoginID, date.ToString("yyyy-MM-dd HH:mm:ss"), ip, ipLocation);
                        break;
                }

                SystemLogWrapper.Save(securityLog);
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }

 
    }
}
