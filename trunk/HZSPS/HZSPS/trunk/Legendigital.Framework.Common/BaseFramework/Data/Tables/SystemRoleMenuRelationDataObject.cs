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
    public partial class SystemRoleMenuRelationDataObject
    {
        public List<SystemMenuEntity> GetRoleAssignMenu(List<SystemRoleEntity> entities)
        {
            NHibernateDynamicQueryGenerator<SystemRoleMenuRelationEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_ROLEID.In(entities));

            InClude_MenuID_Query(queryGenerator);

            queryGenerator.AddWhereClause(PROPERTY_MENUID_MENUISENABLE.Eq(true));

            //使用disticnt以后无法排序

            //queryGenerator.AddOrderBy(PROPERTY_MENUID_PARENTMENUID.Asc());

            //queryGenerator.AddOrderBy(PROPERTY_MENUID_MENUORDER.Asc());

            return this.FindListByProjection<SystemMenuEntity>(queryGenerator, GetDistinctProperty(PROPERTY_MENUID));
        }

        public SystemRoleMenuRelationEntity GetRelationByUserAndMenu(SystemRoleEntity roleEntity, SystemMenuEntity menuEntity)
        {
            NHibernateDynamicQueryGenerator<SystemRoleMenuRelationEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(roleEntity));

            queryGenerator.AddWhereClause(PROPERTY_MENUID.Eq(menuEntity));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }
    }
}
