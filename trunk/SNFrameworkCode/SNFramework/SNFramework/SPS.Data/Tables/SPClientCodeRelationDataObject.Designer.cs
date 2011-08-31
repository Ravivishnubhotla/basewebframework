// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys;
using SPS.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace SPS.Data.Tables
{
    public partial class SPClientCodeRelationDataObject : BaseNHibernateDataObject<SPClientCodeRelationEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_ID));		
		public static readonly EntityProperty<SPCodeEntity> PROPERTY_CODEID = new EntityProperty<SPCodeEntity>(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_CODEID));
		#region codeID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPClientCodeRelationEntity> InClude_CodeID_Query(NHibernateDynamicQueryGenerator<SPClientCodeRelationEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPClientCodeRelationEntity.PROPERTY_NAME_CODEID, PROPERTY_CODEID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CODEID_ALIAS_NAME = "CodeID_SPClientCodeRelationEntity_Alias";
		public static readonly IntProperty PROPERTY_CODEID_ID = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_CODEID_NAME = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Name"));
		public static readonly StringProperty PROPERTY_CODEID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Description"));
		public static readonly StringProperty PROPERTY_CODEID_CODE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Code"));
		public static readonly EntityProperty<SPChannelEntity> PROPERTY_CODEID_CHANNELID = new EntityProperty<SPChannelEntity>(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".ChannelID"));
		public static readonly StringProperty PROPERTY_CODEID_MO = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Mo"));
		public static readonly StringProperty PROPERTY_CODEID_MOTYPE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".MOType"));
		public static readonly IntProperty PROPERTY_CODEID_ORDERINDEX = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".OrderIndex"));
		public static readonly StringProperty PROPERTY_CODEID_SPCODE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".SPCode"));
		public static readonly StringProperty PROPERTY_CODEID_PROVINCE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Province"));
		public static readonly StringProperty PROPERTY_CODEID_DISABLECITY = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".DisableCity"));
		public static readonly BoolProperty PROPERTY_CODEID_ISDIABLE = new BoolProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".IsDiable"));
		public static readonly StringProperty PROPERTY_CODEID_SPTYPE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".SPType"));
		public static readonly IntProperty PROPERTY_CODEID_CODELENGTH = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".CodeLength"));
		public static readonly IntProperty PROPERTY_CODEID_DAYLIMIT = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".DayLimit"));
		public static readonly IntProperty PROPERTY_CODEID_MONTHLIMIT = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".MonthLimit"));
		public static readonly DecimalProperty PROPERTY_CODEID_PRICE = new DecimalProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Price"));
		public static readonly StringProperty PROPERTY_CODEID_SENDTEXT = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".SendText"));
		public static readonly BoolProperty PROPERTY_CODEID_HASFILTERS = new BoolProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".HasFilters"));
		public static readonly IntProperty PROPERTY_CODEID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_CODEID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_CODEID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_CODEID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".LastModifyAt"));
		#endregion
		public static readonly EntityProperty<SPSClientEntity> PROPERTY_CLIENTID = new EntityProperty<SPSClientEntity>(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_CLIENTID));
		#region clientID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPClientCodeRelationEntity> InClude_ClientID_Query(NHibernateDynamicQueryGenerator<SPClientCodeRelationEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPClientCodeRelationEntity.PROPERTY_NAME_CLIENTID, PROPERTY_CLIENTID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CLIENTID_ALIAS_NAME = "ClientID_SPClientCodeRelationEntity_Alias";
		public static readonly IntProperty PROPERTY_CLIENTID_ID = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_CLIENTID_NAME = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".Name"));
		public static readonly StringProperty PROPERTY_CLIENTID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".Description"));
		public static readonly IntProperty PROPERTY_CLIENTID_USERID = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".UserID"));
		public static readonly BoolProperty PROPERTY_CLIENTID_ISDEFAULTCLIENT = new BoolProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".IsDefaultClient"));
		public static readonly BoolProperty PROPERTY_CLIENTID_SYNCDATA = new BoolProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SyncData"));
		public static readonly BoolProperty PROPERTY_CLIENTID_SYCNRESENDFAILEDDATA = new BoolProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SycnResendFailedData"));
		public static readonly IntProperty PROPERTY_CLIENTID_SYCNRETRYTIMES = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SycnRetryTimes"));
		public static readonly StringProperty PROPERTY_CLIENTID_SYNCTYPE = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SyncType"));
		public static readonly StringProperty PROPERTY_CLIENTID_SYCNDATAURL = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SycnDataUrl"));
		public static readonly StringProperty PROPERTY_CLIENTID_SYCNOKMESSAGE = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SycnOkMessage"));
		public static readonly StringProperty PROPERTY_CLIENTID_SYCNFAILEDMESSAGE = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SycnFailedMessage"));
		public static readonly StringProperty PROPERTY_CLIENTID_ALIAS = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".Alias"));
		public static readonly DecimalProperty PROPERTY_CLIENTID_INTERCEPTRATE = new DecimalProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".InterceptRate"));
		public static readonly DecimalProperty PROPERTY_CLIENTID_DEFAULTPRICE = new DecimalProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".DefaultPrice"));
		public static readonly IntProperty PROPERTY_CLIENTID_DEFAULTSHOWRECORDDAYS = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".DefaultShowRecordDays"));
		public static readonly IntProperty PROPERTY_CLIENTID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_CLIENTID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_CLIENTID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_CLIENTID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".LastModifyAt"));
		#endregion
		public static readonly DecimalProperty PROPERTY_PRICE = new DecimalProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_PRICE));		
		public static readonly DecimalProperty PROPERTY_INTERCEPTRATE = new DecimalProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_INTERCEPTRATE));		
		public static readonly BoolProperty PROPERTY_USECLIENTDEFAULTSYCNSETTING = new BoolProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_USECLIENTDEFAULTSYCNSETTING));		
		public static readonly BoolProperty PROPERTY_SYNCDATA = new BoolProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_SYNCDATA));		
		public static readonly BoolProperty PROPERTY_SYCNRESENDFAILEDDATA = new BoolProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_SYCNRESENDFAILEDDATA));		
		public static readonly StringProperty PROPERTY_SYCNRETRYTIMES = new StringProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_SYCNRETRYTIMES));		
		public static readonly StringProperty PROPERTY_SYNCTYPE = new StringProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_SYNCTYPE));		
		public static readonly StringProperty PROPERTY_SYCNDATAURL = new StringProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_SYCNDATAURL));		
		public static readonly StringProperty PROPERTY_SYCNOKMESSAGE = new StringProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_SYCNOKMESSAGE));		
		public static readonly StringProperty PROPERTY_SYCNFAILEDMESSAGE = new StringProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_SYCNFAILEDMESSAGE));		
		public static readonly DateTimeProperty PROPERTY_STARTDATE = new DateTimeProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_STARTDATE));		
		public static readonly DateTimeProperty PROPERTY_ENDDATE = new DateTimeProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_ENDDATE));		
		public static readonly BoolProperty PROPERTY_ISENABLE = new BoolProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_ISENABLE));		
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SPClientCodeRelationEntity.PROPERTY_NAME_LASTMODIFYAT));		
      
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
                case "CodeID":
                    return typeof (int);
                case "ClientID":
                    return typeof (int);
                case "Price":
                    return typeof (decimal);
                case "InterceptRate":
                    return typeof (decimal);
                case "UseClientDefaultSycnSetting":
                    return typeof (bool);
                case "SyncData":
                    return typeof (bool);
                case "SycnResendFailedData":
                    return typeof (bool);
                case "SycnRetryTimes":
                    return typeof (string);
                case "SyncType":
                    return typeof (string);
                case "SycnDataUrl":
                    return typeof (string);
                case "SycnOkMessage":
                    return typeof (string);
                case "SycnFailedMessage":
                    return typeof (string);
                case "StartDate":
                    return typeof (DateTime);
                case "EndDate":
                    return typeof (DateTime);
                case "IsEnable":
                    return typeof (bool);
                case "CreateBy":
                    return typeof (int);
                case "CreateAt":
                    return typeof (DateTime);
                case "LastModifyBy":
                    return typeof (int);
                case "LastModifyAt":
                    return typeof (DateTime);
          }
			return typeof(string);
        }
		
		public List<SPClientCodeRelationEntity> GetList_By_CodeID_SPCodeEntity(SPCodeEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPClientCodeRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CODEID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPClientCodeRelationEntity> GetPageList_By_CodeID_SPCodeEntity(string orderByColumnName, bool isDesc, SPCodeEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPClientCodeRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CODEID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SPClientCodeRelationEntity> GetList_By_ClientID_SPSClientEntity(SPSClientEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPClientCodeRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CLIENTID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPClientCodeRelationEntity> GetPageList_By_ClientID_SPSClientEntity(string orderByColumnName, bool isDesc, SPSClientEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPClientCodeRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CLIENTID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
