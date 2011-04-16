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
    public partial class SystemApplicationDataObject
    {
        /// <summary>
        /// 通过应用名获取应用
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<SystemApplicationEntity> FindedApplicationsByName(string name)
        {
            NHibernateDynamicQueryGenerator<SystemApplicationEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_SYSTEMAPPLICATIONNAME.Eq(name));

            return this.FindListByQueryBuilder(queryGenerator);
        }

        public List<SystemApplicationEntity> FindedApplicationsByCode(string code)
        {
            NHibernateDynamicQueryGenerator<SystemApplicationEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_SYSTEMAPPLICATIONCODE.Eq(code));

            return this.FindListByQueryBuilder(queryGenerator);
        }
    }
}
