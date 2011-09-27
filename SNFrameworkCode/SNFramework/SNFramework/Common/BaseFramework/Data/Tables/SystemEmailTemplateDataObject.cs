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
    public partial class SystemEmailTemplateDataObject
    {
        public SystemEmailTemplateEntity GetTemplateByName(string name)
        {
            NHibernateDynamicQueryGenerator<SystemEmailTemplateEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_NAME.Eq(name));

            queryGenerator.AddWhereClause(PROPERTY_ISENABLE.Eq(true));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }
    }
}