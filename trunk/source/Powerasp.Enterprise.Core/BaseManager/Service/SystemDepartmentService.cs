using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.BaseService;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;
using Powerasp.Enterprise.Core.Web.UI.WebControls;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    [Transactional]
    public class SystemDepartmentService : SystemDepartmentBaseService
    {
        public SystemDepartmentService(SystemDepartmentDao selfDao) : base(selfDao)
        {
        }

        public const int SYSTEMDEPARTMENT_MAX_DEPTH = 8;
        public const int SYSTEMDEPARTMENT_MIN_DEPTH = 1;


        public TreeNode GenerateManageWebTreeNodeByParentDepartment(string rootImageUrl,string itemImageUrl,int rootDepartmentID)
        {
            SuperWebTreeNode baseTreeNode = new SuperWebTreeNode(SYSTEMDEPARTMENT_MIN_DEPTH, SYSTEMDEPARTMENT_MAX_DEPTH, 0);
            baseTreeNode.Checked = false;
            baseTreeNode.SelectAction = TreeNodeSelectAction.Select;
            baseTreeNode.Text = "部门管理";
            baseTreeNode.Value = "0";
            baseTreeNode.ImageUrl = rootImageUrl;

            SystemDepartment rootDepartment = null;

            if (rootDepartmentID>0)
                rootDepartment = this.SelfDao.Load(rootDepartmentID);

            List<SystemDepartment> topLevelSystemDepartment =
                this.SelfDao.GetSubDepartmentByParentDepartment(rootDepartment);

            foreach (SystemDepartment topDepartment in topLevelSystemDepartment)
            {
                GenerateSubManageWebTreeNodeByParentDepartment(itemImageUrl, topDepartment, baseTreeNode);
            }

            return baseTreeNode;
        }

        private void GenerateSubManageWebTreeNodeByParentDepartment(string itemImageUrl, SystemDepartment upDepartment,TreeNode upTreeNode)
        {

            SuperWebTreeNode groupTreeNode = new SuperWebTreeNode(SYSTEMDEPARTMENT_MIN_DEPTH, SYSTEMDEPARTMENT_MAX_DEPTH, 0);
            groupTreeNode.Checked = false;
            groupTreeNode.SelectAction = TreeNodeSelectAction.Select;
            groupTreeNode.Text = upDepartment.DepartmentNameCn;
            groupTreeNode.ImageUrl = itemImageUrl;
            groupTreeNode.Value = upDepartment.DepartmentID.ToString();
            upTreeNode.ChildNodes.Add(groupTreeNode);

            List<SystemDepartment> topLevelSystemDepartment =
this.SelfDao.GetSubDepartmentByParentDepartment(upDepartment);

            foreach (SystemDepartment department in topLevelSystemDepartment)
            {
                GenerateSubManageWebTreeNodeByParentDepartment(itemImageUrl, department, groupTreeNode);
            }

        }
    }
}
