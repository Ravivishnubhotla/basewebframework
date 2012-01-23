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
    public partial class SPDayReportDataObject
    {
        public List<SPDayReportEntity> FindByDate(DateTime date)
        {
            NHibernateDynamicQueryGenerator<SPDayReportEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            //指定查询条件
            dynamicQueryGenerator.AddWhereClause(PROPERTY_REPORTDATE.Eq(date.Date));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
        }

        public List<SPDayReportEntity> QueryReport(DateTime startDate, DateTime endDate)
        {
            NHibernateDynamicQueryGenerator<SPDayReportEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            //指定查询条件
            dynamicQueryGenerator.AddWhereClause(PROPERTY_REPORTDATE.Ge(startDate.Date));

            dynamicQueryGenerator.AddWhereClause(PROPERTY_REPORTDATE.Lt(endDate.AddDays(1).Date));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
        }
    }
}
