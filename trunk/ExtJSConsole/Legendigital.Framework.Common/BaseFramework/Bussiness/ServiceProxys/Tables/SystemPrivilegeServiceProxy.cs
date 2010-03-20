// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
	public interface ISystemPrivilegeServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemPrivilegeEntity>
    {
        List<SystemPrivilegeEntity> GetAllPrivilegeForListPage(string categoryName);
        List<string> GetAllCategoryNames();
        SystemPrivilegeEntity FindByPermissionCode(string permissionCode);
        List<SystemPrivilegeEntity> GetAllPrivilegeByCategoryByUserID(string categoryName, int userId);
    }

    public partial class SystemPrivilegeServiceProxy : ISystemPrivilegeServiceProxy
    {
        public List<SystemPrivilegeEntity> GetAllPrivilegeForListPage(string categoryName)
        {
            return this.DataObjectsContainerIocID.SystemPrivilegeDataObjectInstance.GetAllPrivilegeForListPage(categoryName);
        }

        public List<string> GetAllCategoryNames()
        {
            return this.DataObjectsContainerIocID.SystemPrivilegeDataObjectInstance.GetAllCategoryNames();
        }

        public SystemPrivilegeEntity FindByPermissionCode(string permissionCode)
        {
            return this.DataObjectsContainerIocID.SystemPrivilegeDataObjectInstance.GetByCode(permissionCode);
        }


        public List<SystemPrivilegeEntity> GetAllPrivilegeByCategoryByUserID(string categoryName, int userId)
        {
            SystemUserEntity userEntity = this.DataObjectsContainerIocID.SystemUserDataObjectInstance.Load(userId);

            //管理员直接具备所有的权限
            if (userEntity != null && userEntity.UserLoginID == SystemUserWrapper.DEV_USER_ID)
                return this.DataObjectsContainerIocID.SystemPrivilegeDataObjectInstance.GetAllPrivilegeForListPage(categoryName);

            return this.DataObjectsContainerIocID.SystemPrivilegeInRolesDataObjectInstance.GetAllPrivilegeByCategoryByUserID(categoryName, userEntity);
        }
    }
}
