using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Expression;
using Powerasp.Enterprise.Core.Business;
using Castle.Services.Transaction;
using Powerasp.Enterprise.Core.BaseManager.Dao;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.Service
{
    [Transactional]
    public class SystemRoleService : BaseServices<SystemRole>
    {
        public SystemRoleService(SystemRoleDao selfDao) : base(selfDao)
        {
        }
		
		public SystemRoleDao SelfDao
        {
            get
            {
                return (SystemRoleDao)selfDao;
            }
        }


        private SystemRoleApplicationDao systemRoleApplicationDaoInstance;

        public SystemRoleApplicationDao SystemRoleApplicationDaoInstance
        {
            set { systemRoleApplicationDaoInstance = value; }
        }

        private SystemApplicationDao systemApplicationDaoInstance;

        public SystemApplicationDao SystemApplicationDaoInstance
        {
            set { systemApplicationDaoInstance = value; }
        }

        private SystemRoleDao systemRoleDaoInstance;

        public SystemRoleDao SystemRoleDaoInstance
        {
            set { systemRoleDaoInstance = value; }
        }


        private SystemRoleMenuRelationDao systemRoleMenuRelationDaoInstance;

        public SystemRoleMenuRelationDao SystemRoleMenuRelationDaoInstance
        {
            set { systemRoleMenuRelationDaoInstance = value; }
        }

        private SystemMenuDao systemMenuDaoInstance;

        public SystemMenuDao SystemMenuDaoInstance
        {
            set { systemMenuDaoInstance = value; }
        }


        public List<SystemRole> GetAll(int firstRow, int maxRows, out int recordCount)
        {
            List<Order> orders = new List<Order>();
            orders.Add(SystemRoleDao.PROPERTY_ROLEID.Desc());
            List<ICriterion> criterions = new List<ICriterion>();
            return this.FindAll(criterions.ToArray(), orders.ToArray(), firstRow, maxRows, out recordCount);
        }


        public List<int> GetRoleAssignedApplicatonIDList(SystemRole role)
        {
            List<SystemApplication> list = systemRoleApplicationDaoInstance.GetRoleAssignedApplicaton(role);
            List<int> applicatonIDList = new List<int>();
            foreach (SystemApplication application in list)
            {
                applicatonIDList.Add(application.SystemApplicationID);
            }
            return applicatonIDList;
        }

        [Transaction(TransactionMode.Requires)]
        public virtual void SaveRoleAssignedApplicatonIDList(List<int> applicatonIDList, SystemRole role)
        {
            List<SystemRoleApplication> systemRoleApplications =
                systemRoleApplicationDaoInstance.GetRoleApplicationRelationAssignedApplicaton(role);
            foreach (SystemRoleApplication roleApplication in systemRoleApplications)
            {
                systemRoleApplicationDaoInstance.Delete(roleApplication);
            }
            foreach (int applicatonID in applicatonIDList)
            {
                SystemApplication assignedApplication = systemApplicationDaoInstance.Load(applicatonID);
                SystemRoleApplication systemRoleApplication = new SystemRoleApplication();
                systemRoleApplication.RoleID = role;
                systemRoleApplication.ApplicationID = assignedApplication;
                systemRoleApplicationDaoInstance.Save(systemRoleApplication);
            }
        }


        [Transaction(TransactionMode.Requires)]
        public virtual void SaveRoleAssignedMenuIDList(List<int> menuIDList, SystemRole role)
        {
            List<SystemRoleMenuRelation> systemRoleMenuRelations =
                systemRoleMenuRelationDaoInstance.GetRoleMenuRelationAssignedApplicaton(role);
            foreach (SystemRoleMenuRelation roleMenuRelation in systemRoleMenuRelations)
            {
                systemRoleMenuRelationDaoInstance.Delete(roleMenuRelation);
            }
            foreach (int menuID in menuIDList)
            {
                SystemMenu assignedMenu = systemMenuDaoInstance.Load(menuID);
                SystemRoleMenuRelation systemRoleMenuRelation = new SystemRoleMenuRelation();
                systemRoleMenuRelation.RoleID = role;
                systemRoleMenuRelation.MenuID = assignedMenu;
                systemRoleMenuRelationDaoInstance.Save(systemRoleMenuRelation);
            }
        }


        public virtual List<string> GetRoleAssigedMenuIDs(SystemRole role)
        {
            List<string> list = new List<string>();
            List<SystemRoleMenuRelation> systemRoleMenuRelations =
    systemRoleMenuRelationDaoInstance.GetRoleMenuRelationAssignedApplicaton(role);
            foreach (SystemRoleMenuRelation roleMenuRelation in systemRoleMenuRelations)
            {
                list.Add(roleMenuRelation.MenuID.MenuID.ToString());
            }
            return list;
        }
    }
}
