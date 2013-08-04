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
    public partial class SPPaymentInfoDataObject
    {
        public List<SPPaymentInfoEntity> FindAllByOrderByAndCleintIDAndChanneLIDAndDateNoIntercept(SPChannelEntity channelId, SPClientEntity clientId, DateTime startDateTime, DateTime enddateTime, string sortFieldName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {

            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            if (channelId != null)
                queryBuilder.AddWhereClause(PROPERTY_CHANNELID.Eq(channelId));

            if (clientId != null)
                queryBuilder.AddWhereClause(PROPERTY_CLIENTID.Eq(clientId));


            if (startDateTime==DateTime.MinValue)
                startDateTime = DateTime.Now;


            if (enddateTime == DateTime.MinValue)
                enddateTime = DateTime.Now;

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDateTime.Date));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(enddateTime.AddDays(1).Date));

            queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));

            AddDefaultOrderByToQueryGenerator(sortFieldName, isDesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * pageSize);

            queryBuilder.SetMaxResults(pageSize);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);

        }

        public List<SPPaymentInfoEntity> FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDate(SPChannelEntity channelId, SPClientEntity clientId, DateTime startDateTime, DateTime enddateTime, string dataType, string sortFieldName, bool isDesc, int pageIndex, int pageSize, out int recordCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            if (channelId != null)
                queryBuilder.AddWhereClause(PROPERTY_CHANNELID.Eq(channelId));

            if (clientId != null)
                queryBuilder.AddWhereClause(PROPERTY_CLIENTID.Eq(clientId));


            if (startDateTime == DateTime.MinValue)
                startDateTime = DateTime.Now;


            if (enddateTime == DateTime.MinValue)
                enddateTime = DateTime.Now;

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDateTime.Date));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(enddateTime.AddDays(1).Date));

            switch (dataType)
            {
                case "All":
                    break;
                case "Intercept":
                    queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(true));
                    break;
                case "Down":
                    queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));
                    break;
                case "DownSycn":
                    queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));
                    queryBuilder.AddWhereClause(PROPERTY_SUCESSSTOSEND.Eq(true));
                    break;
            }

            AddDefaultOrderByToQueryGenerator(sortFieldName, isDesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * pageSize);

            queryBuilder.SetMaxResults(pageSize);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);        


        }

        public List<SPPaymentInfoEntity> FindAllDataTableByOrderByAndCleintIDAndChanneLIDAndDate(SPChannelEntity channelId, SPClientEntity clientId, DateTime startDateTime, DateTime enddateTime, string dataType, string sortFieldName, bool isDesc)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            if (channelId != null)
                queryBuilder.AddWhereClause(PROPERTY_CHANNELID.Eq(channelId));

            if (clientId != null)
                queryBuilder.AddWhereClause(PROPERTY_CLIENTID.Eq(clientId));


            if (startDateTime == DateTime.MinValue)
                startDateTime = DateTime.Now;


            if (enddateTime == DateTime.MinValue)
                enddateTime = DateTime.Now;

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDateTime.Date));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(enddateTime.AddDays(1).Date));

            switch (dataType)
            {
                case "All":
                    break;
                case "Intercept":
                    queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(true));
                    break;
                case "Down":
                    queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));
                    break;
                case "DownSycn":
                    queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));
                    queryBuilder.AddWhereClause(PROPERTY_SUCESSSTOSEND.Eq(true));
                    break;
            }

            AddDefaultOrderByToQueryGenerator(sortFieldName, isDesc, queryBuilder);


            return FindListByQueryBuilder(queryBuilder);


        }


        public List<SPPaymentInfoEntity> FindAllNotSendData(SPChannelEntity channelId, SPClientEntity clientId, DateTime startdate, DateTime endDate, int maxDataCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();


            if (channelId != null)
                queryBuilder.AddWhereClause(PROPERTY_CHANNELID.Eq(channelId));

            if (clientId != null)
                queryBuilder.AddWhereClause(PROPERTY_CLIENTID.Eq(clientId));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startdate.Date));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));

            queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));
            queryBuilder.AddWhereClause(PROPERTY_SUCESSSTOSEND.Eq(false));

            queryBuilder.SetMaxResults(maxDataCount);

            return this.FindListByQueryBuilder(queryBuilder);
        }

        public SPPaymentInfoEntity CheckChannleLinkIDIsExist(SPChannelEntity spChannelEntity, SPPaymentInfoEntity paymentInfo)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CHANNELID.Eq(spChannelEntity));

            queryBuilder.AddWhereClause(PROPERTY_LINKID.Eq(paymentInfo.Linkid));

            return this.FindSingleEntityByQueryBuilder(queryBuilder);
        }

 

        public SPPaymentInfoEntity CheckChannleLinkIDIsExist(SPChannelEntity spChannelEntity, SPPaymentInfoEntity paymentInfo, List<string> uniqueKeyNames)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CHANNELID.Eq(spChannelEntity));

            queryBuilder.AddWhereClause(PROPERTY_LINKID.Eq(paymentInfo.Linkid));

            if (uniqueKeyNames.Contains("mobile"))
                queryBuilder.AddWhereClause(PROPERTY_MOBILENUMBER.Eq(paymentInfo.MobileNumber));

            return this.FindSingleEntityByQueryBuilder(queryBuilder);
        }

        public List<SPPaymentInfoEntity> FindAllByOrderByAndClientIDAndDateNoIntercept(SPClientEntity clientEntity, DateTime startDate, DateTime endDate, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CLIENTID.Eq(clientEntity));


            if (startDate == DateTime.MinValue)
                startDate = DateTime.Now;


            if (endDate == DateTime.MinValue)
                endDate = DateTime.Now;

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDate.Date));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));

            queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));

            AddDefaultOrderByToQueryGenerator(sortFieldName, isdesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * limit);

            queryBuilder.SetMaxResults(limit);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);
        }

        public List<SPPaymentInfoEntity> FindAllByOrderByAndSPClientIDsAndDateNoIntercept(List<SPClientEntity> spClientEntities, DateTime startDate, DateTime endDate, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CLIENTID.In(spClientEntities));


            if (startDate == DateTime.MinValue)
                startDate = DateTime.Now;


            if (endDate == DateTime.MinValue)
                endDate = DateTime.Now;

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDate.Date));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));

            queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));

            AddDefaultOrderByToQueryGenerator(sortFieldName, isdesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * limit);

            queryBuilder.SetMaxResults(limit);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);
        }

        public List<SPPaymentInfoEntity> FindAllByOrderByAndClientIDAndDate(SPClientEntity clientEntity, DateTime startDate, DateTime endDate, string sortFieldName, bool isDesc, int pageIndex, int limit, out int recordCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CLIENTID.Eq(clientEntity));


            if (startDate != DateTime.MinValue)
            {
                queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDate.Date));
            }


            if (endDate != DateTime.MinValue)
            {
                queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));
            }

            AddDefaultOrderByToQueryGenerator(sortFieldName, isDesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * limit);

            queryBuilder.SetMaxResults(limit);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);


        }

        public List<SPPaymentInfoEntity> FindAllDefaultClientPaymentByOrderByDate(List<SPClientEntity> spClientEntities, DateTime startDate, DateTime endDate, string sortFieldName, bool isDesc, int pageIndex, int limit, out int recordCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CLIENTID.In(spClientEntities));


            if (startDate != DateTime.MinValue)
            {
                queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDate.Date));
            }


            if (endDate != DateTime.MinValue)
            {
                queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));
            }

            AddDefaultOrderByToQueryGenerator(sortFieldName, isDesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * limit);

            queryBuilder.SetMaxResults(limit);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);
        }

        public List<SPPaymentInfoEntity> FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept(SPClientEntity clientEntity, DateTime startDate, DateTime endDate, string province, string city, string phone, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
        {

            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CLIENTID.Eq(clientEntity));


            if (startDate != DateTime.MinValue)
            {
                queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDate.Date));
            }


            if (endDate != DateTime.MinValue)
            {
                queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));
            }

            if (!string.IsNullOrEmpty(province))
            {
                if (province.Equals("NULL"))
                {
                    queryBuilder.AddWhereClause(PROPERTY_PROVINCE.Eq(""));
                }
                else
                {
                    queryBuilder.AddWhereClause(PROPERTY_PROVINCE.Eq(province));
                }
            }

            if (!string.IsNullOrEmpty(city))
            {
                queryBuilder.AddWhereClause(PROPERTY_CITY.Eq(city));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                queryBuilder.AddWhereClause(PROPERTY_MOBILENUMBER.Like(phone, MatchMode.Start));
            }

            queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));

            AddDefaultOrderByToQueryGenerator(sortFieldName, isdesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * limit);

            queryBuilder.SetMaxResults(limit);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);
 



        }

        public List<SPPaymentInfoEntity> FindAllByOrderByAndSPClientGroupIDAndDateAndProviceNoIntercept(List<SPClientEntity> spClientEntities, DateTime startDate, DateTime endDate, string province, string city, string phone, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CLIENTID.In(spClientEntities));


            if (startDate == DateTime.MinValue)
                startDate = DateTime.Now;


            if (endDate == DateTime.MinValue)
                endDate = DateTime.Now;

            if (!string.IsNullOrEmpty(province))
            {
                if (province.Equals("NULL"))
                {
                    queryBuilder.AddWhereClause(PROPERTY_PROVINCE.Eq(""));
                }
                else
                {
                    queryBuilder.AddWhereClause(PROPERTY_PROVINCE.Eq(province));
                }
            }

            if (!string.IsNullOrEmpty(city))
            {
                queryBuilder.AddWhereClause(PROPERTY_CITY.Eq(city));
            }


            if (!string.IsNullOrEmpty(phone))
            {
                queryBuilder.AddWhereClause(PROPERTY_MOBILENUMBER.Like(phone,MatchMode.Start));
            }

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDate.Date));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));

            queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));

            AddDefaultOrderByToQueryGenerator(sortFieldName, isdesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * limit);

            queryBuilder.SetMaxResults(limit);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);
        }

        public List<SPPaymentInfoEntity> FindAllNotSendData(int clientChannelId, DateTime startDate, DateTime endDate,int maxRetryCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            if (startDate == DateTime.MinValue)
                startDate = DateTime.Now.Date;


            if (endDate == DateTime.MinValue)
                endDate = DateTime.Now.Date;

            queryBuilder.AddWhereClause(PROPERTY_CHANNLECLIENTID.Eq(clientChannelId));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDate.Date));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));

            queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));
            queryBuilder.AddWhereClause(PROPERTY_SUCESSSTOSEND.Eq(false));
            queryBuilder.AddWhereClause(PROPERTY_ISSYCNDATA.Eq(true));

            queryBuilder.AddWhereClause(Or(PROPERTY_SYCNRETRYTIMES.IsNull(), PROPERTY_SYCNRETRYTIMES.Lt(maxRetryCount)));

            queryBuilder.AddOrderBy(PROPERTY_ID.Asc());

            return this.FindListByQueryBuilder(queryBuilder);
        }

        public List<SPPaymentInfoEntity> FindAllByChannelIDAndClientChannelIDAndPhoneListByOrderBy(SPChannelEntity channelId, int clientChannelId, List<string> phones, string sortFieldName, bool isDesc, int pageIndex, int limit, out int recordCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();


            if (channelId != null)
                queryBuilder.AddWhereClause(PROPERTY_CHANNELID.Eq(channelId));

            if (clientChannelId>0)
                queryBuilder.AddWhereClause(PROPERTY_CHANNLECLIENTID.Eq(clientChannelId));

            if (phones != null && phones.Count>0)
            {
                queryBuilder.AddWhereClause(PROPERTY_MOBILENUMBER.In(phones));         
            }

            AddDefaultOrderByToQueryGenerator(sortFieldName, isDesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * limit);

            queryBuilder.SetMaxResults(limit);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);
        }

        public List<SPPaymentInfoEntity> FindAllByChannelIDAndClientChannelIDAndPhoneList(SPChannelEntity channelId, int clientChannelId, List<string> phones)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();


            if (channelId != null)
                queryBuilder.AddWhereClause(PROPERTY_CHANNELID.Eq(channelId));

            if (clientChannelId > 0)
                queryBuilder.AddWhereClause(PROPERTY_CHANNLECLIENTID.Eq(clientChannelId));

            if (phones != null && phones.Count > 0)
            {
                queryBuilder.AddWhereClause(PROPERTY_MOBILENUMBER.In(phones));
            }

            queryBuilder.AddOrderBy(PROPERTY_ID.Asc());

            return FindListByQueryBuilder(queryBuilder);
        }

        public List<SPPaymentInfoEntity> FindAllByOrderByAndSPClientGroupIDAndDateAndProviceNoIntercept(List<SPClientEntity> spClientEntities,int spClientGroupID, DateTime startDate, DateTime endDate, string province, string city, string phone, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CLIENTID.In(spClientEntities));


            if (startDate == DateTime.MinValue)
                startDate = DateTime.Now;


            if (endDate == DateTime.MinValue)
                endDate = DateTime.Now;

            if (!string.IsNullOrEmpty(province))
            {
                if (province.Equals("NULL"))
                {
                    queryBuilder.AddWhereClause(PROPERTY_PROVINCE.Eq(""));
                }
                else
                {
                    queryBuilder.AddWhereClause(PROPERTY_PROVINCE.Eq(province));
                }
            }

            if (!string.IsNullOrEmpty(city))
            {
                queryBuilder.AddWhereClause(PROPERTY_CITY.Eq(city));
            }


            if (!string.IsNullOrEmpty(phone))
            {
                queryBuilder.AddWhereClause(PROPERTY_MOBILENUMBER.Like(phone, MatchMode.Start));
            }

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDate.Date));

            queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));

            queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));

            queryBuilder.AddWhereClause(PROPERTY_CLIENTGROUPID.Eq(spClientGroupID));

            AddDefaultOrderByToQueryGenerator(sortFieldName, isdesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * limit);

            queryBuilder.SetMaxResults(limit);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);
        }

        public List<SPPaymentInfoEntity> FindAllByOrderByAndCleintIDAndChanneLIDAndDateAndProviceNoIntercept1(SPClientEntity clientEntity, int spClientGroupId, DateTime startDate, DateTime endDate, string province, string city, string phone, string sortFieldName, bool isdesc, int pageIndex, int limit, out int recordCount)
        {
            var queryBuilder = new NHibernateDynamicQueryGenerator<SPPaymentInfoEntity>();

            queryBuilder.AddWhereClause(PROPERTY_CLIENTID.Eq(clientEntity));


            if (startDate != DateTime.MinValue)
            {
                queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Ge(startDate.Date));
            }


            if (endDate != DateTime.MinValue)
            {
                queryBuilder.AddWhereClause(PROPERTY_CREATEDATE.Lt(endDate.AddDays(1).Date));
            }

            if (!string.IsNullOrEmpty(province))
            {
                if (province.Equals("NULL"))
                {
                    queryBuilder.AddWhereClause(PROPERTY_PROVINCE.Eq(""));
                }
                else
                {
                    queryBuilder.AddWhereClause(PROPERTY_PROVINCE.Eq(province));
                }
            }

            if (!string.IsNullOrEmpty(city))
            {
                queryBuilder.AddWhereClause(PROPERTY_CITY.Eq(city));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                queryBuilder.AddWhereClause(PROPERTY_MOBILENUMBER.Like(phone, MatchMode.Start));
            }

            queryBuilder.AddWhereClause(PROPERTY_ISINTERCEPT.Eq(false));

            queryBuilder.AddWhereClause(PROPERTY_CLIENTGROUPID.Eq(spClientGroupId));

            AddDefaultOrderByToQueryGenerator(sortFieldName, isdesc, queryBuilder);

            queryBuilder.SetFirstResult((pageIndex - 1) * limit);

            queryBuilder.SetMaxResults(limit);

            return FindListByPageByQueryBuilder(queryBuilder, out recordCount);      

        }
    }
}
