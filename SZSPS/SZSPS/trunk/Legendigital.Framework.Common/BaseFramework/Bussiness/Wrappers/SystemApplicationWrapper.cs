
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;


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

        public static List<SystemApplicationWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SystemApplicationEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SystemApplicationWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SystemApplicationWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SystemApplicationWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
        }
		

		
		#endregion

        public static List<SystemApplicationWrapper> SelectMethod(int start, int limit, string sortFieldName,bool isDesc, out int recordCount)
        {
            if (string.IsNullOrEmpty(sortFieldName))
            {
                return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(new List<QueryFilter>(), SystemApplicationWrapper.PROPERTY_NAME_SYSTEMAPPLICATIONID, true, start, limit, out recordCount));
            }
            return ConvertToWrapperList(businessProxy.FindAllByOrderByAndFilter(new List<QueryFilter>(), sortFieldName, isDesc, start, limit, out recordCount));
        }


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
            if (user.UserLoginID == SystemUserWrapper.DEV_USER_ID)
                return SystemApplicationWrapper.FindAll();

            return ConvertToWrapperList(businessProxy.GetUserAvaiableApplications(user));
        }

    }
}
