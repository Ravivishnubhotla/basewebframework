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
    public partial class SPClientChannelSycnParamsDataObject : BaseNHibernateDataObject<SPClientChannelSycnParamsEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SPClientChannelSycnParamsEntity.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_NAME = Property.ForName(SPClientChannelSycnParamsEntity.PROPERTY_NAME_NAME);
		public static readonly Property PROPERTY_DESCRIPTION = Property.ForName(SPClientChannelSycnParamsEntity.PROPERTY_NAME_DESCRIPTION);
		public static readonly Property PROPERTY_ISENABLE = Property.ForName(SPClientChannelSycnParamsEntity.PROPERTY_NAME_ISENABLE);
		public static readonly Property PROPERTY_ISREQUIRED = Property.ForName(SPClientChannelSycnParamsEntity.PROPERTY_NAME_ISREQUIRED);
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID = Property.ForName(SPClientChannelSycnParamsEntity.PROPERTY_NAME_CLIENTCHANNELSETTINGID);
		#region clientChannelSettingID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPClientChannelSycnParamsEntity> InClude_ClientChannelSettingID_Query(NHibernateDynamicQueryGenerator<SPClientChannelSycnParamsEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPClientChannelSycnParamsEntity.PROPERTY_NAME_CLIENTCHANNELSETTINGID, PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME = "ClientChannelSettingID_SPClientChannelSycnParamsEntity_Alias";
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_ID = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".Id");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_NAME = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".Name");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_DESCRIPTION = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".Description");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_CHANNELID = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".ChannelID");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_CLINETID = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".ClinetID");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_INTERCEPTRATE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".InterceptRate");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_UPRATE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".UpRate");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_DOWNRATE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".DownRate");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_COMMANDTYPE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".CommandType");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_COMMANDCODE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".CommandCode");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_DISABLE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".Disable");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_COMMANDCOLUMN = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".CommandColumn");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_INTERCEPTRATETYPE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".InterceptRateType");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_SYNCDATA = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".SyncData");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_SYNCDATAURL = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".SyncDataUrl");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_OKMESSAGE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".OkMessage");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_FAILEDMESSAGE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".FailedMessage");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_SYNCTYPE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".SyncType");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_ORDERINDEX = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".OrderIndex");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_CHANNELCODE = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".ChannelCode");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_ALLOWFILTER = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".AllowFilter");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_ALLOWANDDISABLEAREA = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".AllowAndDisableArea");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_SETTLEMENTPERIOD = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".SettlementPeriod");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_DAYLIMIT = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".DayLimit");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_MONTHLIMIT = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".MonthLimit");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_SENDTEXT = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".SendText");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_GETWAY = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".Getway");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_DEFAULTNOINTERCEPTCOUNT = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".DefaultNoInterceptCount");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_HASDAYMONTHLIMIT = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".HasDayMonthLimit");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_DAYLIMITCOUNT = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".DayLimitCount");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_MONTHLIMITCOUNT = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".MonthLimitCount");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_HASDAYTOTALLIMIT = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".HasDayTotalLimit");
		public static readonly Property PROPERTY_CLIENTCHANNELSETTINGID_DAYTOTALLIMIT = Property.ForName(PROPERTY_CLIENTCHANNELSETTINGID_ALIAS_NAME + ".DayTotalLimit");
		#endregion
		public static readonly Property PROPERTY_MAPPINGPARAMS = Property.ForName(SPClientChannelSycnParamsEntity.PROPERTY_NAME_MAPPINGPARAMS);
		public static readonly Property PROPERTY_TITLE = Property.ForName(SPClientChannelSycnParamsEntity.PROPERTY_NAME_TITLE);
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "Id" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "Id":
                    return typeof (int);
                case "Name":
                    return typeof (string);
                case "Description":
                    return typeof (string);
                case "IsEnable":
                    return typeof (bool);
                case "IsRequired":
                    return typeof (bool);
                case "ClientChannelSettingID":
                    return typeof (int);
                case "MappingParams":
                    return typeof (string);
                case "Title":
                    return typeof (string);
          }
			return typeof(string);
        }
		
				public List<SPClientChannelSycnParamsEntity> GetList_By_SPClientChannelSettingEntity(SPClientChannelSettingEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPClientChannelSycnParamsEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CLIENTCHANNELSETTINGID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPClientChannelSycnParamsEntity> GetPageList_By_SPClientChannelSettingEntity(string orderByColumnName, bool isDesc, int pageIndex, int pageSize, SPClientChannelSettingEntity fkentity, out int recordCount)
        {
            NHibernateDynamicQueryGenerator<SPClientChannelSycnParamsEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CLIENTCHANNELSETTINGID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            dynamicQueryGenerator.SetFirstResult((pageIndex - 1) * pageSize);

            dynamicQueryGenerator.SetMaxResults(pageSize);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, out recordCount);
        }		
		

		
		
		
    }
}
