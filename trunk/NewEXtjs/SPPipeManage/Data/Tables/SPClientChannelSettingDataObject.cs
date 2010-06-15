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
    public partial class SPClientChannelSettingDataObject
    {
        public List<SPClientChannelSettingEntity> GetSettingByChannel(SPChannelEntity spChannelEntity)
        {
            NHibernateDynamicQueryGenerator<SPClientChannelSettingEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_CHANNELID.Eq(spChannelEntity));

            return this.FindListByQueryBuilder(queryGenerator);
        }
    }
}
