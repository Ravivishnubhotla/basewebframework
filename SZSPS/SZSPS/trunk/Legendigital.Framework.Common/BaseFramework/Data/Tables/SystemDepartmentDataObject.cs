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
    public partial class SystemDepartmentDataObject
    {
        public List<SystemDepartmentEntity> FindAllByOrder()
        {
            NHibernateDynamicQueryGenerator<SystemDepartmentEntity> dynamicQueryGenerator =
                this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddOrderBy(PROPERTY_DEPARTMENTSORTINDEX.Asc());

            dynamicQueryGenerator.AddOrderBy(PROPERTY_PARENTDEPARTMENTID.Asc());

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
        }

        public SystemDepartmentEntity GetNewMaxOrderDepartment(SystemDepartmentEntity pEntity)
        {
            NHibernateDynamicQueryGenerator<SystemDepartmentEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            if (pEntity != null)
                dynamicQueryGenerator.AddWhereClause(SystemDepartmentDataObject.PROPERTY_PARENTDEPARTMENTID.Eq(pEntity));
            else
                dynamicQueryGenerator.AddWhereClause(SystemDepartmentDataObject.PROPERTY_PARENTDEPARTMENTID.IsNull());
            //ָ���������
            dynamicQueryGenerator.AddOrderBy(SystemDepartmentDataObject.PROPERTY_DEPARTMENTSORTINDEX.Desc());

            return this.FindSingleEntityByQueryBuilder(dynamicQueryGenerator);
        }
    }
}
