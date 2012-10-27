// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using LD.SPPipeManage.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;

namespace LD.SPPipeManage.Data.Tables
{
    public partial class SPClientPriceDataObject
    {
        public SPClientPriceEntity GetClientPriceByClientID(int clientid)
        {
            NHibernateDynamicQueryGenerator<SPClientPriceEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_SPCLIENTID.Eq(clientid));

            queryGenerator.AddWhereClause(Or(PROPERTY_SPCLIENTGROUPID.Eq(0), PROPERTY_SPCLIENTGROUPID.IsNull()));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }

        public SPClientPriceEntity GetClientPriceByClientID(int clientid, int clientGroupid)
        {
            NHibernateDynamicQueryGenerator<SPClientPriceEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_SPCLIENTID.Eq(clientid));

            queryGenerator.AddWhereClause(PROPERTY_SPCLIENTGROUPID.Eq(clientGroupid));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }
    }
}