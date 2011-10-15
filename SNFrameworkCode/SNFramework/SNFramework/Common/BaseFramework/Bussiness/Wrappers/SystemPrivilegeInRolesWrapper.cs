
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using Legendigital.Framework.Common.Bussiness.NHibernate;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Bussiness.ServiceProxys.Tables;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;


namespace Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers
{
	[Serializable]
    public partial class SystemPrivilegeInRolesWrapper : BaseSpringNHibernateWrapper<SystemPrivilegeInRolesEntity, ISystemPrivilegeInRolesServiceProxy, SystemPrivilegeInRolesWrapper>
    {
        #region Static Common Data Operation

        public static void Save(SystemPrivilegeInRolesWrapper obj)
        {
            Save(obj, businessProxy);
        }

        public static void Update(SystemPrivilegeInRolesWrapper obj)
        {
            Update(obj, businessProxy);
        }

        public static void SaveOrUpdate(SystemPrivilegeInRolesWrapper obj)
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

        public static void Delete(SystemPrivilegeInRolesWrapper instance)
        {
            Delete(instance, businessProxy);
        }

        public static void Refresh(SystemPrivilegeInRolesWrapper instance)
        {
            Refresh(instance, businessProxy);
        }

        public static SystemPrivilegeInRolesWrapper FindById(object id)
        {
            return ConvertEntityToWrapper(FindById(id, businessProxy));
        }

        public static List<SystemPrivilegeInRolesWrapper> FindAll()
        {
            return ConvertToWrapperList(businessProxy.FindAll());
        }

        public static List<SystemPrivilegeInRolesWrapper> FindAllByPage(PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAll(businessProxy));
        }

        public static List<SystemPrivilegeInRolesWrapper> FindAllByOrderBy(string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            return ConvertToWrapperList(FindAllByPage(pageQueryParams, businessProxy));
        }


        public static List<SystemPrivilegeInRolesWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByColumnName, bool isDesc, PageQueryParams pageQueryParams)
        {
            orderByColumnName = ProcessColumnName(orderByColumnName);

            return FindAllByOrderByAndFilter(new List<QueryFilter>(), orderByColumnName, isDesc, pageQueryParams);
        }


        public static List<SystemPrivilegeInRolesWrapper> FindAllByOrderByAndFilter(List<QueryFilter> filters, string orderByFieldName, bool isDesc)
        {
            List<SystemPrivilegeInRolesWrapper> results = null;

            ProcessQueryFilters(filters);

            results = ConvertToWrapperList(
                    FindAllByOrderByAndFilter(filters, orderByFieldName, isDesc, businessProxy));

            return results;
        }

        #endregion

        public object PrivilegeRoleParseValue
        {
            get
            {
                return DeserializeObject(PrivilegeRoleValue); 
            }
            set
            {
                PrivilegeRoleValue = SerializeObject(value);
            }
        }


        public byte[] SerializeObject(object obj)
        {
            if (obj == null)
                return null;
            System.IO.MemoryStream _memory = new System.IO.MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(_memory, obj);
            _memory.Position = 0;
            byte[] read = new byte[_memory.Length];
            _memory.Read(read, 0, read.Length);
            _memory.Close();
            return read;
        }


        public object DeserializeObject(byte[] pBytes)
        {
            object _newOjb = null;
            if (pBytes == null)
                return _newOjb;
            System.IO.MemoryStream _memory = new System.IO.MemoryStream(pBytes);
            _memory.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            _newOjb = formatter.Deserialize(_memory);
            _memory.Close();
            return _newOjb;
        }


        public byte[] SerializeObject<T>(T obj)
        {
            if (obj == null)
                return null;
            System.IO.MemoryStream _memory = new System.IO.MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(_memory, obj);
            _memory.Position = 0;
            byte[] read = new byte[_memory.Length];
            _memory.Read(read, 0, read.Length);
            _memory.Close();
            return read;
        }

        public T DeserializeObject<T>(byte[] pBytes)
        {
            T _newOjb = default(T);
            if (pBytes == null)
                return _newOjb;
            System.IO.MemoryStream _memory = new System.IO.MemoryStream(pBytes);
            _memory.Position = 0;
            BinaryFormatter formatter = new BinaryFormatter();
            _newOjb = (T)formatter.Deserialize(_memory);
            _memory.Close();
            return _newOjb;
        }


	    public static void PatchUpdatePermissionsParam(List<SystemPrivilegeInRolesWrapper> privilegeInRolesWrapper)
	    {
	        businessProxy.PatchUpdatePermissionsParam(ConvertToEntityList(privilegeInRolesWrapper));
	    }

        public static  List<SystemPrivilegeInRolesWrapper>  GetAllPrivilegeByCategoryByUserID(SystemUserWrapper wrapper)
	    {
            return ConvertToWrapperList(businessProxy.GetAllPrivilegeByCategoryByUserID(wrapper.Entity));
	    }

        public static SystemPrivilegeInRolesWrapper GetRelationByRoleAndPrivilege(SystemRoleWrapper systemRoleWrapper, SystemPrivilegeWrapper systemPrivilegeWrapper)
        {
            return ConvertEntityToWrapper(businessProxy.GetRelationByRoleAndPrivilege(systemRoleWrapper.Entity, systemPrivilegeWrapper.Entity));
        }
    }
}
