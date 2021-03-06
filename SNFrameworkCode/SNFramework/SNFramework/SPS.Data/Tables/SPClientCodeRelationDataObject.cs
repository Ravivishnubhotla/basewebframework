// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using SPS.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;

namespace SPS.Data.Tables
{
    public partial class SPClientCodeRelationDataObject
    {
        public static ICriterion Query_ClientAssignedCode(SPSClientEntity client, Property codeProperty)
        {
            DetachedCriteria subQuery = DetachedCriteria.For(typeof(SPClientCodeRelationEntity));

            subQuery.CreateAlias(SPClientCodeRelationEntity.PROPERTY_NAME_CODEID, PROPERTY_CODEID_ALIAS_NAME);

            subQuery.SetProjection(PROPERTY_CODEID_ID.CriterionProperty);
 
            subQuery.Add(PROPERTY_CLIENTID.Eq(client));

            return Subqueries.PropertyIn(codeProperty.PropertyName, subQuery);
        }


    }
}
