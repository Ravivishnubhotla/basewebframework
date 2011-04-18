
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
    public partial class SystemMenuWrapper
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

        public static List<SystemMenuWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            List<SystemMenuEntity> list = businessProxy.FindAllByPage(pageQueryParams);
            return ConvertToWrapperList(list);
        }

        public static List<SystemMenuWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemMenuWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            List<SystemMenuWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                  pageQueryParams));

            return results;
        }
		

		
		#endregion

        public const int SYSTEMMENU_MAX_DEPTH = 2;
        public const int SYSTEMMENU_MIN_DEPTH = 1;

        /// <summary>
        /// ��ȡ�û���������в˵��������developmentAdminֱ�ӻ�ȡ���еĲ˵���
        /// </summary>
        /// <param name="loginID">�û���½ID</param>
        /// <returns></returns>
        public static List<SystemMenuWrapper> GetUserAssignedMenuByUserLoginID(string loginID)
        {
            return SystemMenuWrapper.ConvertToWrapperList(businessProxy.GetUserAssignedMenuByLoginID(loginID));
        }

        /// <summary>
        /// ��ȡ��ɫ��������в˵�
        /// </summary>
        /// <param name="role">��ɫ����</param>
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

        /// <summary>
        /// ��ȡ�û���������в˵��������developmentAdminֱ�ӻ�ȡ���еĲ˵���
        /// </summary>
        /// <param name="loginID">�û���½ID</param>
        /// <returns></returns>
        public static List<NavMenu> GetUserAssignedNavMenuByUserLoginID(string loginID)
        {
            List<SystemMenuWrapper> listmenu = SystemMenuWrapper.ConvertToWrapperList(businessProxy.GetUserAssignedMenuByLoginID(loginID));

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

            List<SystemMenuWrapper> listmenu = ConvertToWrapperList(businessProxy.GetMenuByApplication(app.entity));

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

            //��ȡ��ǰӦ����ָ���ĸ��˵�����������ŵĲ˵�
            SystemMenuWrapper systemMenuWrapper = null;

            if(parentMenu==null)
                systemMenuWrapper = ConvertEntityToWrapper(businessProxy.GetNewMaxMenuByParentMenuAndApplication(null, systemApplicationWrapper.entity));
            else
                systemMenuWrapper = ConvertEntityToWrapper(businessProxy.GetNewMaxMenuByParentMenuAndApplication(parentMenu.entity, systemApplicationWrapper.entity));

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
        /// ��ȡָ���˵�������Ӳ˵�
        /// </summary>
        /// <param name="parentMenuId">���˵�ID</param>
        /// <returns></returns>
        public static List<SystemMenuWrapper> GetMenuByParentID(int parentMenuId)
        {
            return ConvertToWrapperList(businessProxy.GetMenuByParentID(parentMenuId));
        }

        /// <summary>
        /// �Զ�����ָ���˵�������Ӳ˵�
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
        /// �������²˵�
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
                    groupMenu.AddSubMenu(subMenu);
                    AddSubMenus(listmenu, itemMenu, subMenu);
                }
            }
        }

    }
}