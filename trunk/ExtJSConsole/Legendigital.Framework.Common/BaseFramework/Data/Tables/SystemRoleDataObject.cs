// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.Data.NHibernate.Extend;
using NHibernate;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;

namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemRoleDataObject
    {
        /// <summary>
        /// 获取用户分配的角色
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>分配的角色</returns>
        public List<SystemRoleEntity> GetUserAssignRole(SystemUserEntity user)
        {
            string hql = string.Format("select ur.RoleID from {0} ur where ur.UserID = :userID ", SystemUserRoleRelationEntity.CLASS_FULL_NAME);

            var parameters = new NhibernateParameterCollection();

            parameters.AddParameter("userID", user, NHibernateUtil.Entity(typeof(SystemUserEntity)));

            return this.FindAllWithCustomQuery(hql, parameters);
        }



        /// <summary>
        /// 通过角色名获取角色
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <returns>角色</returns>
        public SystemRoleEntity GetRoleByName(string roleName)
        {
            NHibernateDynamicQueryGenerator<SystemRoleEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_ROLENAME.Eq(roleName));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }
    }
}
