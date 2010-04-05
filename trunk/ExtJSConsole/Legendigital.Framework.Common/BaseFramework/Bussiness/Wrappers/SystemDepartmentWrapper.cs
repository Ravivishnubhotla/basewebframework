
using System;
using System.Collections.Generic;
using System.Configuration;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Web.UI;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemDepartmentWrapper
    {
        #region Static Common Data Operation
		
		public static void Save(SystemDepartmentWrapper obj)
        {
            businessProxy.Save(obj.entity);
        }

        public static void Update(SystemDepartmentWrapper obj)
        {
            businessProxy.Update(obj.entity);
        }

        public static void SaveOrUpdate(SystemDepartmentWrapper obj)
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

        public static void Delete(SystemDepartmentWrapper instance)
        {
            businessProxy.Delete(instance.entity);
        }

        public static void Refresh(SystemDepartmentWrapper instance)
        {
            businessProxy.Refresh(instance.entity);
        }

        public static SystemDepartmentWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(businessProxy.FindById(id));
        }

        public static List<SystemDepartmentWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemDepartmentWrapper> FindAll(int firstRow, int maxRows, out int recordCount)
        {
            List<SystemDepartmentEntity> list = businessProxy.FindAll(firstRow, maxRows, out recordCount);
            return ConvertToWrapperList(list);
        }
		
		public static List<SystemDepartmentWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageIndex, pageSize,
                                             out recordCount);
        }


        public static List<SystemDepartmentWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            List<SystemDepartmentWrapper> results = null;

            results = ConvertToWrapperList(
                    businessProxy.FindAllByOrderByAndFilter(filters, orderByColumnName, isDesc,
                                                   (pageIndex - 1) * pageSize, pageSize, out recordCount));

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
                pDepartment = SystemDepartmentWrapper.FindById(pid).entity;

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
