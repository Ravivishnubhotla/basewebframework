// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using Legendigital.Framework.Common.BaseFramework.Bussiness.Wrappers;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;

namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemUserDataObject
    {
        /// <summary>
        /// 通过用户ID获取用户
        /// </summary>
        /// <param name="loginID"></param>
        /// <returns></returns>
        public SystemUserEntity GetUserByLoginID(string loginID)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_USERLOGINID.Eq(loginID));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }

        /// <summary>
        /// 通过Email获取用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public SystemUserEntity GetUserByEmail(string email)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_USEREMAIL.Eq(email));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }

        /// <summary>
        /// 通过用户名密码获取用户
        /// </summary>
        /// <param name="loginID"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SystemUserEntity GetUserByLoginIDAndPassword(string loginID, string password)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_USERLOGINID.Eq(loginID));

            queryGenerator.AddWhereClause(PROPERTY_USERPASSWORD.Eq(password));

            return this.FindSingleEntityByQueryBuilder(queryGenerator);
        }
        /// <summary>
        /// 通过Email分页查找用户
        /// </summary>
        /// <param name="emailToMatch"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public List<SystemUserEntity> FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_USEREMAIL.Like(emailToMatch));

            PageQueryParams pageQueryParams = new PageQueryParams();

            pageQueryParams.PageIndex = pageIndex;

            pageQueryParams.PageSize = pageSize;

            List<SystemUserEntity> result = this.FindListByPageByQueryBuilder(queryGenerator,pageQueryParams);

            totalRecords = pageQueryParams.RecordCount;

            return result;
        }


        /// <summary>
        /// 通过用户名分页查找用户
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public List<SystemUserEntity> FindUsersByName(string userName, int pageIndex, int pageSize, out int totalRecords)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_USERLOGINID.Like(userName));

            PageQueryParams pageQueryParams = new PageQueryParams();

            pageQueryParams.PageIndex = pageIndex;

            pageQueryParams.PageSize = pageSize;

            List<SystemUserEntity> result = this.FindListByPageByQueryBuilder(queryGenerator, pageQueryParams);

            totalRecords = pageQueryParams.RecordCount;

            return result;
        }

        /// <summary>
        /// 分页查找所拥护
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="totalRecords"></param>
        /// <returns></returns>
        public List<SystemUserEntity> FindAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddOrderBy(PROPERTY_USERID.Desc());

            PageQueryParams pageQueryParams = new PageQueryParams();

            pageQueryParams.PageIndex = pageIndex;

            pageQueryParams.PageSize = pageSize;

            List<SystemUserEntity> result = this.FindListByPageByQueryBuilder(queryGenerator, pageQueryParams);

            totalRecords = pageQueryParams.RecordCount;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="checkDate"></param>
        /// <returns></returns>
        public int FindOnlineUsersCount(DateTime checkDate)
        {
            var criterions = new List<ICriterion> { PROPERTY_LASTACTIVITYDATE.Gt(checkDate) };
            var pjs = new List<IProjection> { Projections.RowCount() };
            return ProjectionScalarQuery<int>(pjs.ToArray(), criterions.ToArray(), null);
        }

        public List<SystemUserEntity> FindUsersByNames(string[] usernames)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_USERLOGINID.In(usernames));

            return this.FindListByQueryBuilder(queryGenerator);
        }

        public List<SystemUserEntity> FindAuthenticatedUserAll(int pageIndex, int pageSize, out int totalRecords)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_ISAPPROVED.Eq(true));

            queryGenerator.AddWhereClause(PROPERTY_ISLOCKEDOUT.Eq(false));

            PageQueryParams pageQueryParams = new PageQueryParams();

            pageQueryParams.PageIndex = pageIndex;

            pageQueryParams.PageSize = pageSize;

            List<SystemUserEntity> result = this.FindListByPageByQueryBuilder(queryGenerator, pageQueryParams);

            totalRecords = pageQueryParams.RecordCount;

            return result;
        }

        public List<SystemUserEntity> FindAllInactiveProfiles(DateTime inactiveSinceDate)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_LASTACTIVITYDATE.Lt(inactiveSinceDate));

            return this.FindListByQueryBuilder(queryGenerator);
        }

        public List<SystemUserEntity> FindAllInactiveAuthenticatedProfiles(DateTime inactiveSinceDate)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_LASTACTIVITYDATE.Lt(inactiveSinceDate));

            queryGenerator.AddWhereClause(PROPERTY_ISAPPROVED.Eq(true));

            queryGenerator.AddWhereClause(PROPERTY_ISLOCKEDOUT.Eq(false));

            return this.FindListByQueryBuilder(queryGenerator);
        }

        internal List<SystemUserEntity> FindAllInactiveProfiles(DateTime inactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_LASTACTIVITYDATE.Lt(inactiveSinceDate));

            PageQueryParams pageQueryParams = new PageQueryParams();

            pageQueryParams.PageIndex = pageIndex;

            pageQueryParams.PageSize = pageSize;

            List<SystemUserEntity> result = this.FindListByPageByQueryBuilder(queryGenerator, pageQueryParams);

            totalRecords = pageQueryParams.RecordCount;

            return result;
        }

        public List<SystemUserEntity> FindAllInactiveAuthenticatedProfiles(DateTime inactiveSinceDate, int pageIndex, int pageSize, out int totalRecords)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            queryGenerator.AddWhereClause(PROPERTY_LASTACTIVITYDATE.Lt(inactiveSinceDate));

            queryGenerator.AddWhereClause(PROPERTY_ISAPPROVED.Eq(true));

            queryGenerator.AddWhereClause(PROPERTY_ISLOCKEDOUT.Eq(false));

            PageQueryParams pageQueryParams = new PageQueryParams();

            pageQueryParams.PageIndex = pageIndex;

            pageQueryParams.PageSize = pageSize;

            List<SystemUserEntity> result = this.FindListByPageByQueryBuilder(queryGenerator,pageQueryParams);

            totalRecords = pageQueryParams.RecordCount;

            return result;
        }


        public List<SystemUserEntity> FindAllByOrderByExpcept(string sortFieldName, bool isDesc, List<string> expceptUserLoginId, List<string> expceptRoleName, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator = this.GetNewQueryBuilder();

            AddDefaultOrderByToQueryGenerator(sortFieldName, isDesc, queryGenerator);

            queryGenerator.AddWhereClause(Not(PROPERTY_USERLOGINID.In(expceptUserLoginId)));

            //queryGenerator.AddWhereClause(Not(PROPERTY_USERLOGINID.In(expceptUserLoginId)));

            return this.FindListByPageByQueryBuilder(queryGenerator, pageQueryParams);


        }
    }
}
