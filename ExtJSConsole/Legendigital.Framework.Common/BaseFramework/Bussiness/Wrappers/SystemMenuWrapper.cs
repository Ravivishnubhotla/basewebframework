
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.UI.WebControls;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemMenuWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemMenuWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemMenuWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemMenuWrapper obj)
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

        public static void Delete(SystemMenuWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemMenuWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemMenuWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemMenuWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemMenuWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SystemMenuEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SystemMenuWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SystemMenuWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SystemMenuWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

            return results;
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
            return businessProxy.GetUserAssignedMenuByLoginID(loginID);
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
                return businessProxy.GetRoleAssignedMenuIDs(role.entity);
            }
            else
            {
                throw new ArgumentNullException("role");
            }
        }


        public static List<NavMenu> GetNavMenuByApplication(SystemApplicationWrapper app)
        {
            List<SystemMenuWrapper> listmenu = ConvertToWrapperList(businessProxy.GetMenuByApplication(app));

            List<NavMenu> menus = new List<NavMenu>();

            foreach (SystemMenuWrapper gmenu in listmenu)
            {
                if (gmenu.ParentMenuID==null || gmenu.ParentMenuID.MenuID==0)
                {
                    NavMenu groupMenu = new NavMenu();
                    groupMenu.Id = gmenu.MenuID.ToString();
                    groupMenu.Name = gmenu.MenuName;
                    groupMenu.NavUrl = gmenu.MenuUrl;
                    groupMenu.IsCategory = gmenu.MenuIsCategory;
                    groupMenu.Icon = gmenu.MenuIconUrl;
                    groupMenu.Tooltip = gmenu.MenuDescription;

                    foreach (SystemMenuWrapper itemMenu in listmenu)
                    {
                        if (gmenu.ParentMenuID != null && itemMenu.ParentMenuID.MenuID == gmenu.MenuID)
                        {
                            NavMenu subMenu = new NavMenu();
                            subMenu.Id = itemMenu.MenuID.ToString();
                            subMenu.Name = itemMenu.MenuName;
                            subMenu.NavUrl = itemMenu.MenuUrl;
                            subMenu.IsCategory = itemMenu.MenuIsCategory;
                            subMenu.Icon = itemMenu.MenuIconUrl;
                            subMenu.Tooltip = itemMenu.MenuDescription;
                            groupMenu.AddSubMenu(subMenu);
                        }
                    }

                    menus.Add(groupMenu);
                }
            }

            return menus;
        }







        public static TreeNode GenerateManageAspNetWebTreeNodeByApplication(SystemApplicationWrapper app, string rootImageUrl, string groupImageUrl, string itemImageUrl)
        {
            TreeNode baseTreeNode = new TreeNode();
            baseTreeNode.Checked = false;
            baseTreeNode.Text = app.SystemApplicationName;
            baseTreeNode.Value = "0";
            baseTreeNode.NavigateUrl = HttpContext.Current.Server.MapPath("#0");
            baseTreeNode.ImageUrl = rootImageUrl;

            List<SystemMenuWrapper> listmenu = ConvertToWrapperList(businessProxy.GetMenuByApplication(app));

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
            SystemMenuWrapper systemMenuWrapper = ConvertEntityToWrapper(businessProxy.GetNewMaxMenuByParentMenuAndApplication(parentMenu, systemApplicationWrapper));

            if (systemMenuWrapper == null)
            {
                return 1;
            }
            else
            {
                return systemMenuWrapper.MenuOrder.Value + 1;
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

        /// <summary>
        /// 批量更新菜单
        /// </summary>
        /// <param name="menus"></param>
        public static void PatchUpdate(List<SystemMenuWrapper> menus)
        {
            businessProxy.PatchUpdate(menus);
        }

    }
}
