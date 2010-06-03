// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;

namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemPrivilegeInRolesDataObject
    {
        /// <summary>
        /// 获取角色分配的权限
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        public List<SystemPrivilegeEntity> GetRoleAssignedPermissions(SystemRoleEntity role)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(role));

            return FindListByProjection<SystemPrivilegeEntity>(dynamicQueryGenerator, PROPERTY_PRIVILEGEID);
        }


        public List<SystemPrivilegeInRolesEntity> GetAllPrivilegeByCategoryByUserID(SystemUserEntity userEntity)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.In(QueryObjects.GetUserAssignedRoles(userEntity)));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
            
 

        }


        public List<SystemPrivilegeEntity> GetAllPrivilegeByCategoryByUserID(string categoryName, SystemUserEntity userEntity)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.In(QueryObjects.GetUserAssignedRoles(userEntity)));

            if(!string.IsNullOrEmpty(categoryName))
            {
                InClude_PrivilegeID_Query(dynamicQueryGenerator);
                dynamicQueryGenerator.AddWhereClause(PROPERTY_PRIVILEGEID_PRIVILEGECATEGORY.Eq(categoryName));
            }

            return this.FindListByProjection<SystemPrivilegeEntity>(dynamicQueryGenerator, GetDistinctProperty(PROPERTY_PRIVILEGEID));

            //string hql = string.Format("select rp.PrivilegeID from {1} rp where rp.RoleID in (select ur.RoleID from {0} ur where ur.UserID = :userID)", SystemUserRoleRelationEntity.CLASS_FULL_NAME, SystemPrivilegeInRolesEntity.CLASS_FULL_NAME);

            //if (!string.IsNullOrEmpty(categoryName))
            //{
            //    hql += " and (rp.PrivilegeID.PrivilegeCategory = :categoryName)";
            //}


            //var parameters = new NhibernateParameterCollection();

            //parameters.AddParameter("userID", userEntity, NHibernateUtil.Entity(typeof(SystemUserEntity)));

            //if (!string.IsNullOrEmpty(categoryName))
            //{
            //    parameters.AddParameter("categoryName", categoryName, NHibernateUtil.Entity(typeof(string)));
            //}

            //return this.FindAllWithCustomQuery(hql, parameters);
        }

        /// <summary>
        /// 获取角色权限对应关系
        /// </summary>
        /// <param name="roleEntity"></param>
        /// <param name="privilegEntity"></param>
        /// <returns></returns>
        public SystemPrivilegeInRolesEntity GetRelationByRoleAndPrivilege(SystemRoleEntity roleEntity, SystemPrivilegeEntity privilegEntity)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(roleEntity));

            dynamicQueryGenerator.AddWhereClause(PROPERTY_PRIVILEGEID.Eq(privilegEntity));

            return FindSingleEntityByQueryBuilder(dynamicQueryGenerator);
        }

        public bool RolesHasPermission(List<SystemRoleEntity> roleEntities, SystemPrivilegeEntity permission)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.In(roleEntities));

            dynamicQueryGenerator.AddWhereClause(PROPERTY_PRIVILEGEID.Eq(permission));

            List<SystemPrivilegeInRolesEntity> list = FindListByQueryBuilder(dynamicQueryGenerator);

            return (list != null && list.Count > 0);
        }

        public List<SystemPrivilegeInRolesEntity> GetRoleAssignedPrivilegesInRole(SystemRoleEntity systemRoleEntity)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(systemRoleEntity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
        }
    }
}
