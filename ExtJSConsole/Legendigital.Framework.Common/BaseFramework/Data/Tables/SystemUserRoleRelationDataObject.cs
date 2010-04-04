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
    public partial class SystemUserRoleRelationDataObject
    {
        /// <summary>
        /// ��ȡ�û�����Ľ�ɫ
        /// </summary>
        /// <param name="user">�û�</param>
        /// <returns></returns>
        public List<SystemRoleEntity> GetUserAssignedRoles(SystemUserEntity user)
        {
            NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_USERID.Eq(user));

            return this.FindListByProjection<SystemRoleEntity>(queryGenerator, SystemUserRoleRelationDataObject.PROPERTY_ROLEID);
        }

        /// <summary>
        /// ��ȡ��ɫ�����������û�
        /// </summary>
        /// <param name="role">��ɫ</param>
        /// <returns></returns>
        public List<SystemUserEntity> GetRoleAssignedUsers(SystemRoleEntity role)
        {
            NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(SystemUserRoleRelationDataObject.PROPERTY_ROLEID.Eq(role));

            return
                this.FindListByProjection<SystemUserEntity>(queryGenerator, SystemUserRoleRelationDataObject.PROPERTY_USERID);
        }

        /// <summary>
        /// ��ȡ�û���ɫ��ϵ�Ƿ����
        /// </summary>
        /// <param name="user">�û�</param>
        /// <param name="role">��ɫ</param>
        /// <returns></returns>
        public SystemUserRoleRelationEntity GetUserRoleRelation(SystemUserEntity user, SystemRoleEntity role)
        {
            NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_USERID.Eq(user));

            queryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(role));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }






    }
}