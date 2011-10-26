
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Web.UI;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemDepartmentWrapper : BaseSpringNHibernateWrapper<SystemDepartmentEntity, ISystemDepartmentServiceProxy, SystemDepartmentWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SystemDepartmentWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemDepartmentWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemDepartmentWrapper obj)
        {
            SaveOrUpdate(obj, businessProxy);
        }

        public static void DeleteAll()
        {
            DeleteAll(businessProxy);
        }

        public static void DeleteByID(object id)
        {
            DeleteByID(id, businessProxy);
        }

        public static void PatchDeleteByIDs(object[] ids)
        {

            PatchDeleteByIDs(ids, businessProxy);
        }

        public static void Delete(SystemDepartmentWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemDepartmentWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemDepartmentWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemDepartmentWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemDepartmentWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemDepartmentWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SystemDepartmentWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return ConvertToWrapperList(FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams, businessProxy));
        }


        public static List<SystemDepartmentWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemDepartmentWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion


        public static List<TypedTreeNodeItem<SystemDepartmentWrapper>> GetAllDepartment()
        {
            List<TypedTreeNodeItem<SystemDepartmentWrapper>> nodes = new List<TypedTreeNodeItem<SystemDepartmentWrapper>>();

            List<SystemDepartmentWrapper> departments = SystemDepartmentWrapper.FindAllByOrder();

            List<SystemDepartmentWrapper> topDepartments = departments.FindAll(p => (p.ParentDepartmentID == null));

            foreach (SystemDepartmentWrapper topDepartment in topDepartments)
            {
                TypedTreeNodeItem<SystemDepartmentWrapper> topnode = new TypedTreeNodeItem<SystemDepartmentWrapper>();
                topnode.Id = topDepartment.DepartmentID.ToString();
                topnode.Name = topDepartment.DepartmentNameCn;
                topnode.DataItem = topDepartment;
                topnode.ParentNode = null;

                AddSubDepartment(topnode, topDepartment, departments);

                nodes.Add(topnode);
            }

            return nodes;
        }

        private static List<SystemDepartmentWrapper> FindAllByOrder()
        {
            return ConvertToWrapperList(businessProxy.FindAllByOrder());
        }

        private static void AddSubDepartment(TypedTreeNodeItem<SystemDepartmentWrapper> mnode, SystemDepartmentWrapper topDepartment, List<SystemDepartmentWrapper> departments)
        {
            List<SystemDepartmentWrapper> subdepartments = departments.FindAll(p => (p.ParentDepartmentID != null) && (p.ParentDepartmentID.DepartmentID == topDepartment.DepartmentID));

            foreach (SystemDepartmentWrapper subdepartment in subdepartments)
            {
                TypedTreeNodeItem<SystemDepartmentWrapper> subnode = new TypedTreeNodeItem<SystemDepartmentWrapper>();
                subnode.Id = subdepartment.DepartmentID.ToString();
                subnode.Name = subdepartment.DepartmentNameCn;
                subnode.DataItem = subdepartment;
                subnode.ParentNode = mnode;

                AddSubDepartment(subnode, subdepartment, departments);

                mnode.SubNodes.Add(subnode);
            }

        }

        public static int GetNewMaxOrder(int pid)
        {
            SystemDepartmentEntity pDepartment = null;

            if (pid != 0)
            {
                SystemDepartmentWrapper pDepartmentw = SystemDepartmentWrapper.FindById(pid);

                if(pDepartmentw!=null)
                {
                    pDepartment = pDepartmentw.entity;
                }
            }


            SystemDepartmentWrapper maxOrder = ConvertEntityToWrapper(businessProxy.GetNewMaxOrder(pDepartment));

            if (maxOrder == null)
            {
                return 1;
            }
            else
            {
                if (!maxOrder.DepartmentSortIndex.HasValue)
                {
                    return 1;
                }
                return maxOrder.DepartmentSortIndex.Value + 1;
            }
        }

    }
}
