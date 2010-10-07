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
    public partial class SPClientDataObject
    {
        public SPClientEntity GetClientByUserID(int userId)
        {
            NHibernateDynamicQueryGenerator<SPClientEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_USERID.Eq(userId));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }

        public List<SPClientEntity> GetAllDefaultClient()
        {
            NHibernateDynamicQueryGenerator<SPClientEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_ISDEFAULTCLIENT.Eq(true));

            return this.FindListByQueryBuilder(queryGenerator);
        }
    }
}
