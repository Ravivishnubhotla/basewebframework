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
    public partial class SystemTerminologyDataObject
    {
        public SystemTerminologyEntity GetLocalizationNameByTypeAndCode(string localizationType, string localizationCode)
        {
            NHibernateDynamicQueryGenerator<SystemTerminologyEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_CODE.Eq(localizationCode));

            queryGenerator.AddWhereClause(PROPERTY_LANGUAGETYPE.Eq(localizationType));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }
    }
}
