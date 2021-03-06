// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using Legendigital.Framework.Common.Bussiness.Interfaces;
using Legendigital.Framework.Common.Data.Interfaces;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Data.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables
{
    [ServiceContract(Namespace = "http://Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables")]
    public interface ISystemMenuServiceProxy : IBaseSpringNHibernateEntityServiceProxy<SystemMenuEntity, int>, ISystemMenuServiceProxyDesigner
    {
        [OperationContract]
        List<SystemMenuEntity> GetUserAssignedMenuByLoginID(string loginID);
        [OperationContract]
        List<SystemMenuEntity> GetMenuByApplication(SystemApplicationEntity entity);
        [OperationContract]
        SystemMenuEntity GetNewMaxMenuByParentMenuAndApplication(SystemMenuEntity menuWrapper, SystemApplicationEntity applicationWrapper);
        [OperationContract]
        List<SystemMenuEntity> GetMenuByParentID(int parentMenuId);
        [OperationContract]
        void PatchUpdate(List<SystemMenuEntity> menus);
        [OperationContract]
        List<string> GetRoleAssignedMenuIDs(SystemRoleEntity role);
        List<SystemMenuEntity> GetTopMenuByAppID(int appId);
        List<SystemMenuEntity> GetMenuByApplication(SystemApplicationWrapper app, SystemUserEntity userEntity);
        void UpdateOrder(List<int> ids);
        void AutoUpdateOrder(int appID, int parentID);
        List<SystemMenuEntity> GetMenuByApplication(SystemApplicationWrapper app);
    }

    public partial class SystemMenuServiceProxy : BaseSpringNHibernateEntityServiceProxy<SystemMenuEntity,int>,ISystemMenuServiceProxy
    {
        public List<SystemMenuEntity> GetUserAssignedMenuByLoginID(string loginID)
        {
            //检查用户是否存在
            SystemUserEntity userEntity =
                this.DataObjectsContainerIocID.SystemUserDataObjectInstance.GetUserByLoginID(loginID);

            if (userEntity != null)
            {
                //开发用户直接返回所有的可用的菜单
                if(loginID==SystemUserWrapper.DEV_USER_ID)
                    return this.DataObjectsContainerIocID.SystemMenuDataObjectInstance.GetAllAviableMenu();

                //获取用户分配的角色
                List<SystemRoleEntity> userAssignedRole =
                    this.DataObjectsContainerIocID.SystemUserRoleRelationDataObjectInstance.GetUserAssignedRoles(userEntity);

                if (userAssignedRole != null && userAssignedRole.Count > 0)
                {
                    //查找角色下面分配的所有的菜单,(未排序)
                    List<SystemMenuEntity> listMenu =
                        this.DataObjectsContainerIocID.SystemRoleMenuRelationDataObjectInstance.GetRoleAssignMenu(userAssignedRole);

                    List<int> menuIDs = new List<int>();

                    foreach (SystemMenuEntity menuEntity in listMenu)
                    {
                        menuIDs.Add(menuEntity.MenuID);
                    }

                    //获取重新排序的Menu
                    return this.DataObjectsContainerIocID.SystemMenuDataObjectInstance.SortMenu(menuIDs);
                }
            }

            return null;

        }

        public List<SystemMenuEntity> GetMenuByApplication(SystemApplicationEntity entity)
        {
            return this.SelfDataObj.GetMenuByApplication(entity);
        }


        public List<SystemMenuEntity> GetMenuByApplication(SystemApplicationWrapper app,SystemUserEntity userEntity)
        {
            return this.SelfDataObj.GetMenuByApplication(app.Entity);
        }

        public SystemMenuEntity GetNewMaxMenuByParentMenuAndApplication(SystemMenuEntity menuWrapper, SystemApplicationEntity applicationWrapper)
        {
            if (menuWrapper == null)
                return this.SelfDataObj.GetNewMaxMenuByParentMenuAndApplication(null, applicationWrapper);

            return this.SelfDataObj.GetNewMaxMenuByParentMenuAndApplication(menuWrapper, applicationWrapper);
        }

        public List<SystemMenuEntity> GetMenuByParentID(int parentMenuId)
        {
            if (parentMenuId == 0)
                return this.SelfDataObj.GetMenuByParentID(null);

            return this.SelfDataObj.GetMenuByParentID(this.FindById(parentMenuId));
        }
        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public void PatchUpdate(List<SystemMenuEntity> menus)
        {
            foreach (SystemMenuEntity menu in menus)
            {
                this.Update(menu);
            }
        }

        public List<string> GetRoleAssignedMenuIDs(SystemRoleEntity role)
        {
            List<SystemRoleEntity> roles = new List<SystemRoleEntity>();
            roles.Add(role);
            List<SystemMenuEntity> list =
                this.DataObjectsContainerIocID.SystemRoleMenuRelationDataObjectInstance.GetRoleAssignMenu(roles);
            List<string> menuIDs = new List<string>();
            foreach (SystemMenuEntity entity in list)
            {
                menuIDs.Add(entity.MenuID.ToString());
            }
            return menuIDs;
        }

        public List<SystemMenuEntity> GetTopMenuByAppID(int appId)
        {
            return
                this.SelfDataObj.GetTopMenuByAppID(
                    this.DataObjectsContainerIocID.SystemApplicationDataObjectInstance.Load(appId));
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public void UpdateOrder(List<int> ids)
        {
            int i = 1;

            foreach (int id in ids)
            {
                SystemMenuEntity systemMenuEntity = this.SelfDataObj.Load(id);
                systemMenuEntity.MenuOrder = i;

                this.SelfDataObj.Update(systemMenuEntity);

                i++;
            }
        }

        [Transaction(TransactionPropagation.Required, ReadOnly = false)]
        public void AutoUpdateOrder(int appID, int parentID)
        {
            SystemApplicationEntity applicationEntity =
                this.DataObjectsContainerIocID.SystemApplicationDataObjectInstance.Load(appID);

            List<SystemMenuEntity> menus;

            if (parentID == 0)
            {
                menus = this.SelfDataObj.GetMenuByParentIDAndApp(null, applicationEntity);
            }
            else
            {
                SystemMenuEntity topMenu = this.DataObjectsContainerIocID.SystemMenuDataObjectInstance.Load(parentID);

                menus = this.SelfDataObj.GetMenuByParentIDAndApp(topMenu, applicationEntity);
            }


            int i = 1;

            foreach (SystemMenuEntity menu in menus)
            {
                menu.MenuOrder = i;

                this.SelfDataObj.Update(menu);

                i++;
            }
        }

        public List<SystemMenuEntity> GetMenuByApplication(SystemApplicationWrapper app)
        {
            return this.SelfDataObj.GetMenuByApplication(app.Entity);
        }
    }
}
