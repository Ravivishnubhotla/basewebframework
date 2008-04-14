using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Business;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.Web.UI.WebControls;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    [Transactional]
    public class SystemMenuService : BaseServices<SystemMenu>
    {
        public const int SYSTEMMENU_MAX_DEPTH = 2;
        public const int SYSTEMMENU_MIN_DEPTH = 1;


        public SystemMenuService(SystemMenuDao selfDao) : base(selfDao)
        {
        }

        public SystemMenuDao SelfDao
        {
            get
            {
                return (SystemMenuDao)selfDao;
            }
        }


        /// <summary>
        /// 获取指定系统应用下的Menu
        /// </summary>
        /// <param name="app"></param>
        /// <param name="rootImageUrl"></param>
        /// <param name="groupImageUrl"></param>
        /// <param name="itemImageUrl"></param>
        /// <returns></returns>
        public TreeNode GenerateManageWebTreeNodeByApplication(SystemApplication app, string rootImageUrl, string groupImageUrl, string itemImageUrl)
        {
            SuperWebTreeNode baseTreeNode = new SuperWebTreeNode(SYSTEMMENU_MIN_DEPTH, SYSTEMMENU_MAX_DEPTH, 0);
            baseTreeNode.Checked = false;
            baseTreeNode.SelectAction = TreeNodeSelectAction.Select;
            baseTreeNode.Text = app.SystemApplicationName;
            baseTreeNode.Value = "0";
            baseTreeNode.ImageUrl = rootImageUrl;


            List<SystemMenu> listmenu =
            this.SelfDao.GetMenuByApplication(app);

            foreach (SystemMenu groupMenu in listmenu)
            {
                if(groupMenu.MenuIsEnable && groupMenu.MenuIsCategory)
                {
                    SuperWebTreeNode groupTreeNode = new SuperWebTreeNode(SYSTEMMENU_MIN_DEPTH, SYSTEMMENU_MAX_DEPTH, 0);
                    groupTreeNode.Checked = false;
                    groupTreeNode.SelectAction = TreeNodeSelectAction.Select;
                    groupTreeNode.Text = groupMenu.MenuName;
                    groupTreeNode.ImageUrl = groupImageUrl;
                    groupTreeNode.Value = groupMenu.MenuID.ToString();
                    baseTreeNode.ChildNodes.Add(groupTreeNode);
                    foreach (SystemMenu itemMenu in listmenu)
                    {
                        if(itemMenu.MenuIsEnable && !itemMenu.MenuIsCategory && itemMenu.ParentMenuID == groupMenu)
                        {
                            SuperWebTreeNode itemTreeNode = new SuperWebTreeNode(SYSTEMMENU_MIN_DEPTH, SYSTEMMENU_MAX_DEPTH, 0);
                            itemTreeNode.Checked = false;
                            itemTreeNode.SelectAction = TreeNodeSelectAction.Select;
                            itemTreeNode.Text = itemMenu.MenuName;
                            itemTreeNode.ImageUrl = itemImageUrl;
                            itemTreeNode.Value = itemMenu.MenuID.ToString();
                            groupTreeNode.ChildNodes.Add(itemTreeNode);
                        }
                    }
                }
            }

            return baseTreeNode;
        }



        public TreeNode GenerateSelectAssignedWebTreeNodeByApplication(SystemApplication app, string rootImageUrl, string groupImageUrl, string itemImageUrl)
        {
            SuperWebTreeNode baseTreeNode = new SuperWebTreeNode(SYSTEMMENU_MIN_DEPTH, SYSTEMMENU_MAX_DEPTH, 0);
            baseTreeNode.ShowCheckBox = false;
            baseTreeNode.SelectAction = TreeNodeSelectAction.None;
            baseTreeNode.Text = app.SystemApplicationName;
            baseTreeNode.Value = "0";
            baseTreeNode.ImageUrl = rootImageUrl;


            List<SystemMenu> listmenu =
            this.SelfDao.GetMenuByApplication(app);

            foreach (SystemMenu groupMenu in listmenu)
            {
                if (groupMenu.MenuIsEnable && groupMenu.MenuIsCategory)
                {
                    SuperWebTreeNode groupTreeNode = new SuperWebTreeNode(SYSTEMMENU_MIN_DEPTH, SYSTEMMENU_MAX_DEPTH, 0);
                    groupTreeNode.Checked = false;
                    groupTreeNode.SelectAction = TreeNodeSelectAction.None;
                    groupTreeNode.Text = groupMenu.MenuName;
                    groupTreeNode.ImageUrl = groupImageUrl;
                    groupTreeNode.Value = groupMenu.MenuID.ToString();
                    baseTreeNode.ChildNodes.Add(groupTreeNode);
                    foreach (SystemMenu itemMenu in listmenu)
                    {
                        if (itemMenu.MenuIsEnable && !itemMenu.MenuIsCategory && itemMenu.ParentMenuID == groupMenu)
                        {
                            SuperWebTreeNode itemTreeNode = new SuperWebTreeNode(SYSTEMMENU_MIN_DEPTH, SYSTEMMENU_MAX_DEPTH, 0);
                            itemTreeNode.Checked = false;
                            itemTreeNode.SelectAction = TreeNodeSelectAction.None;
                            itemTreeNode.Text = itemMenu.MenuName;
                            itemTreeNode.ImageUrl = itemImageUrl;
                            itemTreeNode.Value = itemMenu.MenuID.ToString();
                            groupTreeNode.ChildNodes.Add(itemTreeNode);
                        }
                    }
                }
            }

            return baseTreeNode;
        }




        [Transaction(TransactionMode.Requires)]
        public override void Create(SystemMenu obj)
        {
            //顶级菜单默认为菜单组
            if (obj.ParentMenuID == null)
            {
                obj.MenuUrl = "";
                obj.MenuIsCategory = true;
            }
            else
            {
                obj.MenuIsCategory = false;
            }
            //获取一个最大序号
            obj.MenuOrder = SelfDao.GetMaxOrderByApplicationAndParentMenu(obj.ApplicationID, obj.ParentMenuID)+1;
            base.Create(obj);
        }

        [Transaction(TransactionMode.Requires)]
        public override void Delete(SystemMenu instance)
        {
            if (instance==null)
                return;
            //递归循环删除所有的子菜单。
            DeleteSubMenu(instance);
        }

        private void DeleteSubMenu(SystemMenu parentMenu)
        {
            List<SystemMenu> subMenus = SelfDao.GetSubMenu(parentMenu);
            foreach (SystemMenu menu in subMenus)
            {
                DeleteSubMenu(menu);
            }
            SelfDao.Delete(parentMenu);
        }

        [Transaction(TransactionMode.Requires)]
        public virtual void ReSortedSubmenu(SystemMenu parentMenu)
        {
            List<SystemMenu> allSubSystemMenus = SelfDao.GetSubMenu(parentMenu);

            for (int i = 0; i < allSubSystemMenus.Count; i++)
            {
                allSubSystemMenus[i].MenuOrder = i + 1;
                SelfDao.Update(allSubSystemMenus[i]);
            }

            return;
        }


        [Transaction(TransactionMode.Requires)]
        public virtual void MovePostion(SystemMenu systemMenu, int movePostion)
        {
            int currentOrder = 0;

            switch (movePostion)
            {
                case 0:
                    return;
                case 1:
                    SystemMenu preSystemMenu = SelfDao.FindPreMenu(systemMenu);
                    if (preSystemMenu == null)
                        return;
                    currentOrder = systemMenu.MenuOrder;
                    systemMenu.MenuOrder = preSystemMenu.MenuOrder;
                    preSystemMenu.MenuOrder = currentOrder;
                    SelfDao.Update(systemMenu);
                    SelfDao.Update(preSystemMenu);
                    break;
                case -1:
                    SystemMenu nextSystemMenu = SelfDao.FindNextMenu(systemMenu);
                    if (nextSystemMenu == null)
                        return;
                    currentOrder = systemMenu.MenuOrder;
                    systemMenu.MenuOrder = nextSystemMenu.MenuOrder;
                    nextSystemMenu.MenuOrder = currentOrder;
                    SelfDao.Update(systemMenu);
                    SelfDao.Update(nextSystemMenu);
                    break;
                default:
                    throw new NotImplementedException(" movePostion must be 1 or -1 now");
            }

            return;
        }
    }
}
