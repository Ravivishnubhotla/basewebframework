
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Threading;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemApplicationWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemApplicationWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemApplicationWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemApplicationWrapper obj)
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

        public static void Delete(SystemApplicationWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemApplicationWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemApplicationWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemApplicationWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemApplicationWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemApplicationEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemApplicationWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemApplicationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemApplicationWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                  pageQueryParams));

            return results;
        }


		

		
		#endregion

 


	    /// <summary>
        /// 通过配置文件加载系统应用（如果不存在，则创建。MemberShip使用）
        /// </summary>
        /// <param name="configValue"></param>
        /// <returns></returns>
        public static SystemApplicationWrapper CreateOrLoadApplication(string configValue)
        {
            return businessProxy.CreateOrLoadApplication(configValue);
        }

        /// <summary>
        /// 获取用户分配的所有系统应用
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static List<SystemApplicationWrapper> GetUserAvaiableApplications(SystemUserWrapper user)
        {
            //如果是系统管理员，获取所有的系统应用
            if (SystemUserWrapper.CheckUserIfDeveloperAdminOrSystemAdmin(user.UserLoginID))
                return FindAll();

            return ConvertToWrapperList(businessProxy.GetUserAvaiableApplications(user));
        }

        public static List<SystemApplicationWrapper> GetUserAvaiableApplicationsNotAssigned(SystemUserWrapper currentLoginUser, int roleID)
        {
            List<SystemApplicationWrapper> allAplications = GetUserAvaiableApplications(currentLoginUser);

            SystemRoleWrapper systemRoleWrapper = SystemRoleWrapper.FindById(roleID);

            List<SystemApplicationWrapper> assignedApplications = SystemRoleWrapper.GetRoleAssignedApplications(systemRoleWrapper);

            foreach (SystemApplicationWrapper assignedApplication in assignedApplications)
            {
                int appID = assignedApplication.SystemApplicationID;

                allAplications.RemoveAll(p => (p.SystemApplicationID == appID));
            }

            return allAplications;
        }


	    public string LocaLocalizationName
	    {
	        get
	        {
                return SystemTerminologyWrapper.GetLocalizationName(this.SystemApplicationName, Thread.CurrentThread.CurrentUICulture.ToString().ToLower());
	        }
	    }

    }
}
