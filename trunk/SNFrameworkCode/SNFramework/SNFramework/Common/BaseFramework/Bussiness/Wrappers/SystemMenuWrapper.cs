
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using System.Web;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemMenuWrapper : BaseSpringNHibernateWrapper<SystemMenuEntity, ISystemMenuServiceProxy, SystemMenuWrapper, int>
    {
        public string LocaLocalizationName
        {
            get
            {
                return SystemTerminologyWrapper.GetLocalizationName(this.MenuName, Thread.CurrentThread.CurrentUICulture.ToString().ToLower());
            }
        }


        #region Static Common Data Operation

        public static void Save(SystemMenuWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemMenuWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemMenuWrapper obj)
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

        public static void Delete(SystemMenuWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemMenuWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemMenuWrapper FindById(int id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemMenuWrapper> FindAll()
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemMenuWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }

        public static List<SystemMenuWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemMenuWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemMenuWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            orderByFieldName = ProcessColumnName(orderByFieldName);

            ProcessQueryFilters(filters);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy)); 
        }

        #endregion


        public const int SYSTEMMENU_MAX_DEPTH = 2;
        public const int SYSTEMMENU_MIN_DEPTH = 1;

        /// <summary>
        /// 获取用户分配的所有菜单，如果是developmentAdmin直接获取所有的菜单。
        /// </summary>
        /// <param name="loginID">用户登陆ID</param>
        /// <returns></returns>
        public static List<SystemMenuWrapper> GetUserAssignedMenuByUserLoginID(string loginID)
        {
            List<SystemApplicationWrapper> applications = SystemApplicationWrapper.GetUserAvaiableApplications(SystemUserWrapper.FindByLoginID(loginID));

            List<SystemMenuWrapper> assignedMenus = new List<SystemMenuWrapper>();

            List<SystemMenuEntity> menus = businessProxy.GetUserAssignedMenuByLoginID(loginID);

            if (menus==null)
                return assignedMenus;

            foreach (SystemMenuEntity systemMenuWrapper in menus)
            {
                if(applications.Exists(p=>(p.SystemApplicationID==systemMenuWrapper.ApplicationID.SystemApplicationID)))
                {
                    assignedMenus.Add(ConvertEntityToWrapper(systemMenuWrapper));
                }
            }

            return assignedMenus;
        }

	    /// <summary>
	    /// 获取用户分配的所有菜单，如果是developmentAdmin直接获取所有的菜单（指定到某一个特定的应用下面，测试模式使用）。
	    /// </summary>
	    /// <param name="loginID">用户登陆ID</param>
	    /// <param name="applicationCode">限定应用</param>
	    /// <returns></returns>
	    public static List<SystemMenuWrapper> GetUserAssignedMenuByUserLoginID(string loginID,string applicationCode)
        {
            List<SystemApplicationWrapper> applications = new List<SystemApplicationWrapper>() { SystemApplicationWrapper.FindByCode(applicationCode) };

            List<SystemMenuWrapper> assignedMenus = new List<SystemMenuWrapper>();

            List<SystemMenuEntity> menus = businessProxy.GetUserAssignedMenuByLoginID(loginID);

            foreach (SystemMenuEntity systemMenuWrapper in menus)
            {
                if (applications.Exists(p => (p.SystemApplicationID == systemMenuWrapper.ApplicationID.SystemApplicationID)))
                {
                    assignedMenus.Add(ConvertEntityToWrapper(systemMenuWrapper));
                }
            }

            return assignedMenus;
        }

        /// <summary>
        /// 获取角色分配的所有菜单
        /// </summary>
        /// <param name="role">角色对象</param>
        /// <returns></returns>
        public static List<string> GetRoleAssignedMenuIDs(SystemRoleWrapper role)
        {
            if (role != null)
            {
                return businessProxy.GetRoleAssignedMenuIDs(role.Entity);
            }
            else
            {
                throw new ArgumentNullException("role");
            }
        }

        /// <summary>
        /// 获取用户分配的所有菜单，如果是developmentAdmin直接获取所有的菜单。
        /// </summary>
        /// <param name="loginID">用户登陆ID</param>
        /// <returns></returns>
        public static List<NavMenu> GetUserAssignedNavMenuByUserLoginID(string loginID)
        {
            List<SystemMenuWrapper> listmenu = GetUserAssignedMenuByUserLoginID(loginID);

            return GetNavMenusFromSystemMenus(listmenu);
        }

        /// 获取用户分配的所有菜单，如果是developmentAdmin直接获取所有的菜单。
        /// </summary>
        /// <param name="loginID">用户登陆ID</param>
        /// <returns></returns>
        public static List<NavMenu> GetUserAssignedNavMenuByUserLoginID(string loginID,string applicationCode)
        {
            List<SystemMenuWrapper> listmenu = GetUserAssignedMenuByUserLoginID(loginID, applicationCode);

            return GetNavMenusFromSystemMenus(listmenu);
        }

        private static List<NavMenu> GetNavMenusFromSystemMenus(List<SystemMenuWrapper> listmenu)
        {
            List<NavMenu> menus = new List<NavMenu>();

            foreach (SystemMenuWrapper gmenu in listmenu)
            {
                if (gmenu.ParentMenuID == null || gmenu.ParentMenuID.MenuID == 0)
                {
                    NavMenu groupMenu = new NavMenu();
                    groupMenu.Id = gmenu.MenuID.ToString();
                    groupMenu.Name = gmenu.LocaLocalizationName;
                    groupMenu.NavUrl = gmenu.MenuUrl;
                    groupMenu.IsCategory = gmenu.MenuIsCategory;
                    groupMenu.Icon = gmenu.MenuIconUrl;
                    groupMenu.Tooltip = gmenu.MenuDescription;

                    AddSubMenus(listmenu, gmenu, groupMenu);

                    menus.Add(groupMenu);
                }
            }
            return menus;
        }


        public static List<NavMenu> GetNavMenuByApplication(SystemApplicationWrapper app)
        {
            List<SystemMenuWrapper> listmenu = ConvertToWrapperList(businessProxy.GetMenuByApplication(app));

            return GetNavMenusFromSystemMenus(listmenu);
        }

        public static TreeNode GenerateManageAspNetWebTreeNodeByApplication(SystemApplicationWrapper app, string rootImageUrl, string groupImageUrl, string itemImageUrl)
        {
            TreeNode baseTreeNode = new TreeNode();
            baseTreeNode.Checked = false;
            baseTreeNode.Text = app.SystemApplicationName;
            baseTreeNode.Value = "0";
            baseTreeNode.NavigateUrl = HttpContext.Current.Server.MapPath("#0");
            baseTreeNode.ImageUrl = rootImageUrl;

            List<SystemMenuWrapper> listmenu = ConvertToWrapperList(businessProxy.GetMenuByApplication(app.Entity));

            foreach (SystemMenuWrapper groupMenu in listmenu)
            {
                if (groupMenu.MenuIsCategory)
                {
                    TreeNode groupTreeNode = new TreeNode();
                    groupTreeNode.Checked = false;
                    groupTreeNode.Text = groupMenu.MenuName;
                    groupTreeNode.ImageUrl = groupImageUrl;
                    groupTreeNode.Value = groupMenu.MenuID.ToString();
                    groupTreeNode.ToolTip = string.Format("{0}:[{1}]", groupMenu.MenuOrder, groupMenu.MenuName);
                    groupTreeNode.NavigateUrl = HttpContext.Current.Server.MapPath("#") + groupMenu.MenuID.ToString();
                    baseTreeNode.ChildNodes.Add(groupTreeNode);
                    foreach (SystemMenuWrapper itemMenu in listmenu)
                    {
                        if (!itemMenu.MenuIsCategory && itemMenu.ParentMenuID.MenuID == groupMenu.MenuID)
                        {
                            TreeNode itemTreeNode = new TreeNode();
                            itemTreeNode.Checked = false;
                            itemTreeNode.Text = itemMenu.MenuName;
                            itemTreeNode.ToolTip = string.Format("{0}:[{1}]", itemMenu.MenuOrder, itemMenu.MenuName);
                            itemTreeNode.ImageUrl = itemImageUrl;
                            itemTreeNode.NavigateUrl = HttpContext.Current.Server.MapPath("#") + itemMenu.MenuID.ToString();
                            itemTreeNode.Value = itemMenu.MenuID.ToString(); ;
                            groupTreeNode.ChildNodes.Add(itemTreeNode);
                        }
                    }
                }
            }

            return baseTreeNode;
        }



 
        public static int GetNewMaxMenuOrder(int parentMenuId, int applicationId)
        {
            SystemMenuWrapper parentMenu = null;

            if (parentMenuId != 0)
                parentMenu = SystemMenuWrapper.FindById(parentMenuId);

            SystemApplicationWrapper systemApplicationWrapper = SystemApplicationWrapper.FindById(applicationId);

            //获取当前应用下指定的父菜单下面的最大序号的菜单
            SystemMenuWrapper systemMenuWrapper = null;

            if(parentMenu==null)
                systemMenuWrapper = ConvertEntityToWrapper(businessProxy.GetNewMaxMenuByParentMenuAndApplication(null, systemApplicationWrapper.Entity));
            else
                systemMenuWrapper = ConvertEntityToWrapper(businessProxy.GetNewMaxMenuByParentMenuAndApplication(parentMenu.entity, systemApplicationWrapper.Entity));

            if (systemMenuWrapper == null)
            {
                return 1;
            }
            else
            {
                if (systemMenuWrapper.MenuOrder.HasValue)
                    return systemMenuWrapper.MenuOrder.Value + 1;
                else
                    return 1;
            }
        }

        /// <summary>
        /// 获取指定菜单下面的子菜单
        /// </summary>
        /// <param name="parentMenuId">父菜单ID</param>
        /// <returns></returns>
        public static List<SystemMenuWrapper> GetMenuByParentID(int parentMenuId)
        {
            return ConvertToWrapperList(businessProxy.GetMenuByParentID(parentMenuId));
        }

        /// <summary>
        /// 自动排序指定菜单下面的子菜单
        /// </summary>
        /// <param name="parentMenuId"></param>
        public static void AutoMaticSortSubItems(int parentMenuId)
        {
            List<SystemMenuWrapper> menus = GetMenuByParentID(parentMenuId);
            for (int i = 0; i < menus.Count; i++)
            {
                menus[i].MenuOrder = i + 1;
            }
            PatchUpdate(menus);
        }



        public static void AutoMaticSortSubItems(int appID, int parentMenuId)
        {
            businessProxy.AutoUpdateOrder(appID, parentMenuId);
        }




        /// <summary>
        /// 批量更新菜单
        /// </summary>
        /// <param name="menus"></param>
        public static void PatchUpdate(List<SystemMenuWrapper> menus)
        {
            businessProxy.PatchUpdate(SystemMenuWrapper.ConvertToEntityList(menus));
        }


        public static List<SystemMenuWrapper> GetTopMenuByAppID(int appID)
        {
            return ConvertToWrapperList(businessProxy.GetTopMenuByAppID(appID));
        }

        public static void UpdateOrder(List<int> ids)
        {
            businessProxy.UpdateOrder(ids);
        }


  


        public static List<SystemMenuWrapper> GetSystemMenusByApplication(int appID)
        {
            return ConvertToWrapperList(businessProxy.GetMenuByApplication(SystemApplicationWrapper.FindById(appID)));
        }


        private static void AddSubMenus(List<SystemMenuWrapper> listmenu, SystemMenuWrapper gmenu, NavMenu groupMenu)
        {
            foreach (SystemMenuWrapper itemMenu in listmenu)
            {
                if (itemMenu.ParentMenuID != null && itemMenu.ParentMenuID.MenuID == gmenu.MenuID)
                {
                    NavMenu subMenu = new NavMenu();
                    subMenu.Id = itemMenu.MenuID.ToString();
                    subMenu.Name = itemMenu.LocaLocalizationName;
                    subMenu.NavUrl = itemMenu.MenuUrl;
                    subMenu.IsCategory = itemMenu.MenuIsCategory;
                    subMenu.Icon = itemMenu.MenuIconUrl;
                    subMenu.Tooltip = itemMenu.MenuDescription;
                    subMenu.IsSystem = itemMenu.ApplicationID.SystemApplicationIsSystemApplication.HasValue && itemMenu.ApplicationID.SystemApplicationIsSystemApplication.Value;
                    if (!subMenu.IsSystem)
                    {
                        subMenu.SystemUrl = itemMenu.ApplicationID.SystemApplicationUrl;
                    }
                    else
                    {
                        subMenu.SystemUrl = "";
                    }
                    groupMenu.AddSubMenu(subMenu);
                    AddSubMenus(listmenu, itemMenu, subMenu);
                }
            }
        }

    }
}
