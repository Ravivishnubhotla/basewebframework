using System;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Castle.NHibernateIntergeration.Internal;
using Powerasp.Enterprise.Core.BaseManager.BaseDao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Dao
{
    public class SystemMenuDao : SystemMenuBaseDao
    {
        public SystemMenuDao(ISessionManager sessionManager) : base(sessionManager)
        {
        }
        public SystemMenuDao(ISessionManager sessionManager, string sessionFactoryAlias) : base(sessionManager, sessionFactoryAlias)
        {
        }


        /// <summary>
        /// 获取指定应用程序下指定菜单的子菜单最大序号
        /// </summary>
        /// <param name="app">应用程序</param>
        /// <param name="parentMenu">父菜单</param>
        /// <returns>子菜单最大序号</returns>
        public int GetMaxOrderByApplicationAndParentMenu(SystemApplication app,SystemMenu parentMenu)
        {
            DetachedCriteria menuCriteria = DetachedCriteria.For(typeof(SystemMenu));
            if (app==null)
                menuCriteria.Add(SystemMenuDao.PROPERTY_APPLICATIONID.IsNull());
            else
                menuCriteria.Add(SystemMenuDao.PROPERTY_APPLICATIONID.Eq(app));

            if (parentMenu == null)
                menuCriteria.Add(SystemMenuDao.PROPERTY_PARENTMENUID.IsNull());
            else
                menuCriteria.Add(SystemMenuDao.PROPERTY_PARENTMENUID.Eq(parentMenu));
            menuCriteria.SetProjection(SystemMenuDao.PROPERTY_MENUORDER.Max());

            using(ISession session = this.GetSession())
            {
                object result = menuCriteria.GetExecutableCriteria(session).SetMaxResults(1).UniqueResult();

                if (result == null)
                    return 0;
                else
                    return (int)result;
            }
        }

        /// <summary>
        /// 获取指定系统应用下的Menu
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public List<SystemMenu> GetMenuByApplication(SystemApplication app)
        {
            //创建游离对象
            DetachedCriteria menuQuery = DetachedCriteria.For(typeof(SystemMenu));
            //指定查询条件
            menuQuery.Add(SystemMenuDao.PROPERTY_APPLICATIONID.Eq(app));
            //指定排序规则
            menuQuery.AddOrder(SystemMenuDao.PROPERTY_MENUORDER.Asc());
            menuQuery.AddOrder(SystemMenuDao.PROPERTY_MENUID.Desc());

            return this.FindListByDetachedCriteriaQuery(menuQuery);
        }

        /// <summary>
        /// 获取制定菜单下的子菜单
        /// </summary>
        /// <param name="parentMenu">父菜单</param>
        /// <returns>子菜单</returns>
        public List<SystemMenu> GetSubMenu(SystemMenu parentMenu)
        {
            DetachedCriteria menuCriteria = DetachedCriteria.For(typeof(SystemMenu));
            if (parentMenu == null)
                menuCriteria.Add(SystemMenuDao.PROPERTY_PARENTMENUID.IsNull());
            else
                menuCriteria.Add(SystemMenuDao.PROPERTY_PARENTMENUID.Eq(parentMenu));
            menuCriteria.AddOrder(SystemMenuDao.PROPERTY_MENUORDER.Asc());
            return this.FindListByDetachedCriteriaQuery(menuCriteria);
        }



        public SystemMenu FindPreMenu(SystemMenu systemMenu)
        {
            if(systemMenu==null)
                throw new ArgumentNullException("systemMenu", "systemMenu not allow null.");

            DetachedCriteria menuCriteria = DetachedCriteria.For(typeof(SystemMenu));
            //同一子菜单下
            if (systemMenu.ParentMenuID == null)
                menuCriteria.Add(SystemMenuDao.PROPERTY_PARENTMENUID.IsNull());
            else
                menuCriteria.Add(SystemMenuDao.PROPERTY_PARENTMENUID.Eq(systemMenu.ParentMenuID));
            //Order小于当前菜单
            menuCriteria.Add(SystemMenuDao.PROPERTY_MENUORDER.Lt(systemMenu.MenuOrder));
            //最大序号的菜单
            menuCriteria.AddOrder(SystemMenuDao.PROPERTY_MENUORDER.Desc());

            List<SystemMenu> listMenu = this.FindListByDetachedCriteriaQuery(menuCriteria);

            if (listMenu.Count <= 0)
                return null;
            else
                return listMenu[0];
        }

        public SystemMenu FindNextMenu(SystemMenu systemMenu)
        {
            if (systemMenu == null)
                throw new ArgumentNullException("systemMenu", "systemMenu not allow null.");

            DetachedCriteria menuCriteria = DetachedCriteria.For(typeof(SystemMenu));
            //同一子菜单下
            if (systemMenu.ParentMenuID == null)
                menuCriteria.Add(SystemMenuDao.PROPERTY_PARENTMENUID.IsNull());
            else
                menuCriteria.Add(SystemMenuDao.PROPERTY_PARENTMENUID.Eq(systemMenu.ParentMenuID));
            //Order大于当前菜单
            menuCriteria.Add(SystemMenuDao.PROPERTY_MENUORDER.Gt(systemMenu.MenuOrder));
            //最小序号的菜单
            menuCriteria.AddOrder(SystemMenuDao.PROPERTY_MENUORDER.Asc());

            List<SystemMenu> listMenu = this.FindListByDetachedCriteriaQuery(menuCriteria);

            if (listMenu.Count <= 0)
                return null;
            else
                return listMenu[0];

        }



    }
}
