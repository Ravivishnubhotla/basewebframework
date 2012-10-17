// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;

namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemVersionDataObject
    {
        public SystemVersionEntity GetMaxDataVersionByDataTypeAndDataID(string dataType, int dataId)
        {
            NHibernateDynamicQueryGenerator<SystemVersionEntity> query = this.GetNewQueryBuilder();

            query.AddWhereClause(PROPERTY_PARENTDATATYPE.Eq(dataType));

            query.AddWhereClause(PROPERTY_PARENTDATAID.Eq(dataId));

            query.AddOrderBy(PROPERTY_VERSIONNUMBER.Desc());
            ;
            return this.FindSingleEntityByQueryBuilder(query);
        }
    }
}
