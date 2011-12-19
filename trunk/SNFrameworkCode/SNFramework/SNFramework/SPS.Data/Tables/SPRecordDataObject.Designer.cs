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
    public partial class SPRecordDataObject : BaseNHibernateDataObject<SPRecordEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_LINKID = new StringProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_LINKID));		
		public static readonly StringProperty PROPERTY_MO = new StringProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_MO));		
		public static readonly StringProperty PROPERTY_MOBILE = new StringProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_MOBILE));		
		public static readonly StringProperty PROPERTY_SPNUMBER = new StringProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_SPNUMBER));		
		public static readonly StringProperty PROPERTY_PROVINCE = new StringProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_PROVINCE));		
		public static readonly StringProperty PROPERTY_CITY = new StringProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_CITY));		
		public static readonly StringProperty PROPERTY_OPERATORTYPE = new StringProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_OPERATORTYPE));		
		public static readonly DateTimeProperty PROPERTY_CREATEDATE = new DateTimeProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_CREATEDATE));		
		public static readonly BoolProperty PROPERTY_ISREPORT = new BoolProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_ISREPORT));		
		public static readonly BoolProperty PROPERTY_ISINTERCEPT = new BoolProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_ISINTERCEPT));		
		public static readonly BoolProperty PROPERTY_ISSYCNTOCLIENT = new BoolProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_ISSYCNTOCLIENT));		
		public static readonly BoolProperty PROPERTY_ISSYCNSUCCESSED = new BoolProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_ISSYCNSUCCESSED));		
		public static readonly BoolProperty PROPERTY_ISSTATOK = new BoolProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_ISSTATOK));		
		public static readonly IntProperty PROPERTY_SYCNRETRYTIMES = new IntProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_SYCNRETRYTIMES));		
		public static readonly EntityProperty<SPChannelEntity> PROPERTY_CHANNELID = new EntityProperty<SPChannelEntity>(Property.ForName(SPRecordEntity.PROPERTY_NAME_CHANNELID));
		#region channelID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPRecordEntity> InClude_ChannelID_Query(NHibernateDynamicQueryGenerator<SPRecordEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPRecordEntity.PROPERTY_NAME_CHANNELID, PROPERTY_CHANNELID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CHANNELID_ALIAS_NAME = "ChannelID_SPRecordEntity_Alias";
		public static readonly IntProperty PROPERTY_CHANNELID_ID = new IntProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_CHANNELID_NAME = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Name"));
		public static readonly StringProperty PROPERTY_CHANNELID_CODE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Code"));
		public static readonly StringProperty PROPERTY_CHANNELID_DATAOKMESSAGE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".DataOkMessage"));
		public static readonly StringProperty PROPERTY_CHANNELID_DATAFAILEDMESSAGE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".DataFailedMessage"));
		public static readonly StringProperty PROPERTY_CHANNELID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Description"));
		public static readonly StringProperty PROPERTY_CHANNELID_DATAADAPTERTYPE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".DataAdapterType"));
		public static readonly StringProperty PROPERTY_CHANNELID_DATAADAPTERURL = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".DataAdapterUrl"));
		public static readonly StringProperty PROPERTY_CHANNELID_CHANNELTYPE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".ChannelType"));
		public static readonly StringProperty PROPERTY_CHANNELID_IVRFEETIMETYPE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".IVRFeeTimeType"));
		public static readonly StringProperty PROPERTY_CHANNELID_IVRTIMEFORMAT = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".IVRTimeFormat"));
		public static readonly BoolProperty PROPERTY_CHANNELID_ISSTATEREPORT = new BoolProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".IsStateReport"));
		public static readonly StringProperty PROPERTY_CHANNELID_STATEREPORTTYPE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".StateReportType"));
		public static readonly StringProperty PROPERTY_CHANNELID_REPORTOKMESSAGE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".ReportOkMessage"));
		public static readonly StringProperty PROPERTY_CHANNELID_REPORTFAILEDMESSAGE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".ReportFailedMessage"));
		public static readonly StringProperty PROPERTY_CHANNELID_STATEREPORTPARAMNAME = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".StateReportParamName"));
		public static readonly StringProperty PROPERTY_CHANNELID_STATEREPORTPARAMVALUE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".StateReportParamValue"));
		public static readonly StringProperty PROPERTY_CHANNELID_REQUESTTYPEPARAMNAME = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".RequestTypeParamName"));
		public static readonly StringProperty PROPERTY_CHANNELID_REQUESTTYPEPARAMSTATEREPORTVALUE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".RequestTypeParamStateReportValue"));
		public static readonly StringProperty PROPERTY_CHANNELID_REQUESTTYPEPARAMDATAREPORTVALUE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".RequestTypeParamDataReportValue"));
		public static readonly BoolProperty PROPERTY_CHANNELID_HASFILTERS = new BoolProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".HasFilters"));
		public static readonly BoolProperty PROPERTY_CHANNELID_ISMONITORREQUEST = new BoolProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".IsMonitorRequest"));
		public static readonly BoolProperty PROPERTY_CHANNELID_ISLOGREQUEST = new BoolProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".IsLogRequest"));
		public static readonly BoolProperty PROPERTY_CHANNELID_ISPARAMSCONVERT = new BoolProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".IsParamsConvert"));
		public static readonly BoolProperty PROPERTY_CHANNELID_ISAUTOLINKID = new BoolProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".IsAutoLinkID"));
		public static readonly StringProperty PROPERTY_CHANNELID_AUTOLINKIDFIELDS = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".AutoLinkIDFields"));
		public static readonly StringProperty PROPERTY_CHANNELID_LOGREQUESTTYPE = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".LogRequestType"));
		public static readonly DecimalProperty PROPERTY_CHANNELID_PRICE = new DecimalProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".Price"));
		public static readonly DecimalProperty PROPERTY_CHANNELID_DEFAULTRATE = new DecimalProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".DefaultRate"));
		public static readonly StringProperty PROPERTY_CHANNELID_CHANNELDETAILINFO = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".ChannelDetailInfo"));
		public static readonly EntityProperty<SPUpperEntity> PROPERTY_CHANNELID_UPPERID = new EntityProperty<SPUpperEntity>(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".UpperID"));
		public static readonly StringProperty PROPERTY_CHANNELID_CHANNELSTATUS = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".ChannelStatus"));
		public static readonly BoolProperty PROPERTY_CHANNELID_ISDISABLE = new BoolProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".IsDisable"));
		public static readonly IntProperty PROPERTY_CHANNELID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_CHANNELID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_CHANNELID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_CHANNELID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_CHANNELID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_CHANNELID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly EntityProperty<SPSClientEntity> PROPERTY_CLIENTID = new EntityProperty<SPSClientEntity>(Property.ForName(SPRecordEntity.PROPERTY_NAME_CLIENTID));
		#region clientID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPRecordEntity> InClude_ClientID_Query(NHibernateDynamicQueryGenerator<SPRecordEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPRecordEntity.PROPERTY_NAME_CLIENTID, PROPERTY_CLIENTID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CLIENTID_ALIAS_NAME = "ClientID_SPRecordEntity_Alias";
		public static readonly IntProperty PROPERTY_CLIENTID_ID = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_CLIENTID_NAME = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".Name"));
		public static readonly StringProperty PROPERTY_CLIENTID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".Description"));
		public static readonly IntProperty PROPERTY_CLIENTID_USERID = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".UserID"));
		public static readonly BoolProperty PROPERTY_CLIENTID_ISDEFAULTCLIENT = new BoolProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".IsDefaultClient"));
		public static readonly BoolProperty PROPERTY_CLIENTID_SYNCDATA = new BoolProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SyncData"));
		public static readonly IntProperty PROPERTY_CLIENTID_SYCNRETRYTIMES = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SycnRetryTimes"));
		public static readonly StringProperty PROPERTY_CLIENTID_SYNCTYPE = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SyncType"));
		public static readonly IntProperty PROPERTY_CLIENTID_SYCNNOTINTERCEPTCOUNT = new IntProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".SycnNotInterceptCount"));
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
		public static readonly StringProperty PROPERTY_CLIENTID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_CLIENTID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly EntityProperty<SPCodeEntity> PROPERTY_CODEID = new EntityProperty<SPCodeEntity>(Property.ForName(SPRecordEntity.PROPERTY_NAME_CODEID));
		#region codeID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPRecordEntity> InClude_CodeID_Query(NHibernateDynamicQueryGenerator<SPRecordEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPRecordEntity.PROPERTY_NAME_CODEID, PROPERTY_CODEID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CODEID_ALIAS_NAME = "CodeID_SPRecordEntity_Alias";
		public static readonly IntProperty PROPERTY_CODEID_ID = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_CODEID_NAME = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Name"));
		public static readonly StringProperty PROPERTY_CODEID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Description"));
		public static readonly StringProperty PROPERTY_CODEID_CODE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Code"));
		public static readonly StringProperty PROPERTY_CODEID_CODETYPE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".CodeType"));
		public static readonly EntityProperty<SPChannelEntity> PROPERTY_CODEID_CHANNELID = new EntityProperty<SPChannelEntity>(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".ChannelID"));
		public static readonly StringProperty PROPERTY_CODEID_MO = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Mo"));
		public static readonly StringProperty PROPERTY_CODEID_MOTYPE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".MOType"));
		public static readonly IntProperty PROPERTY_CODEID_MOLENGTH = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".MOLength"));
		public static readonly IntProperty PROPERTY_CODEID_ORDERINDEX = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".OrderIndex"));
		public static readonly StringProperty PROPERTY_CODEID_SPCODE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".SPCode"));
		public static readonly StringProperty PROPERTY_CODEID_SPCODETYPE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".SPCodeType"));
		public static readonly IntProperty PROPERTY_CODEID_SPCODELENGTH = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".SPCodeLength"));
		public static readonly BoolProperty PROPERTY_CODEID_HASFILTERS = new BoolProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".HasFilters"));
		public static readonly BoolProperty PROPERTY_CODEID_HASPARAMSCONVERT = new BoolProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".HasParamsConvert"));
		public static readonly StringProperty PROPERTY_CODEID_PROVINCE = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Province"));
		public static readonly StringProperty PROPERTY_CODEID_DISABLECITY = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".DisableCity"));
		public static readonly BoolProperty PROPERTY_CODEID_ISDIABLE = new BoolProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".IsDiable"));
		public static readonly StringProperty PROPERTY_CODEID_DAYLIMIT = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".DayLimit"));
		public static readonly StringProperty PROPERTY_CODEID_MONTHLIMIT = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".MonthLimit"));
		public static readonly DecimalProperty PROPERTY_CODEID_PRICE = new DecimalProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".Price"));
		public static readonly StringProperty PROPERTY_CODEID_SENDTEXT = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".SendText"));
		public static readonly IntProperty PROPERTY_CODEID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_CODEID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_CODEID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_CODEID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_CODEID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_CODEID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly EntityProperty<SPClientCodeRelationEntity> PROPERTY_CLIENTCODERELATIONID = new EntityProperty<SPClientCodeRelationEntity>(Property.ForName(SPRecordEntity.PROPERTY_NAME_CLIENTCODERELATIONID));
		#region clientCodeRelationID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPRecordEntity> InClude_ClientCodeRelationID_Query(NHibernateDynamicQueryGenerator<SPRecordEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPRecordEntity.PROPERTY_NAME_CLIENTCODERELATIONID, PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME = "ClientCodeRelationID_SPRecordEntity_Alias";
		public static readonly IntProperty PROPERTY_CLIENTCODERELATIONID_ID = new IntProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".Id"));
		public static readonly EntityProperty<SPCodeEntity> PROPERTY_CLIENTCODERELATIONID_CODEID = new EntityProperty<SPCodeEntity>(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".CodeID"));
		public static readonly EntityProperty<SPSClientEntity> PROPERTY_CLIENTCODERELATIONID_CLIENTID = new EntityProperty<SPSClientEntity>(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".ClientID"));
		public static readonly DecimalProperty PROPERTY_CLIENTCODERELATIONID_PRICE = new DecimalProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".Price"));
		public static readonly DecimalProperty PROPERTY_CLIENTCODERELATIONID_INTERCEPTRATE = new DecimalProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".InterceptRate"));
		public static readonly BoolProperty PROPERTY_CLIENTCODERELATIONID_USECLIENTDEFAULTSYCNSETTING = new BoolProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".UseClientDefaultSycnSetting"));
		public static readonly BoolProperty PROPERTY_CLIENTCODERELATIONID_SYNCDATA = new BoolProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".SyncData"));
		public static readonly StringProperty PROPERTY_CLIENTCODERELATIONID_SYCNRETRYTIMES = new StringProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".SycnRetryTimes"));
		public static readonly StringProperty PROPERTY_CLIENTCODERELATIONID_SYNCTYPE = new StringProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".SyncType"));
		public static readonly StringProperty PROPERTY_CLIENTCODERELATIONID_SYCNDATAURL = new StringProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".SycnDataUrl"));
		public static readonly StringProperty PROPERTY_CLIENTCODERELATIONID_SYCNOKMESSAGE = new StringProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".SycnOkMessage"));
		public static readonly StringProperty PROPERTY_CLIENTCODERELATIONID_SYCNFAILEDMESSAGE = new StringProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".SycnFailedMessage"));
		public static readonly DateTimeProperty PROPERTY_CLIENTCODERELATIONID_STARTDATE = new DateTimeProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".StartDate"));
		public static readonly DateTimeProperty PROPERTY_CLIENTCODERELATIONID_ENDDATE = new DateTimeProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".EndDate"));
		public static readonly BoolProperty PROPERTY_CLIENTCODERELATIONID_ISENABLE = new BoolProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".IsEnable"));
		public static readonly IntProperty PROPERTY_CLIENTCODERELATIONID_SYCNNOTINTERCEPTCOUNT = new IntProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".SycnNotInterceptCount"));
		public static readonly IntProperty PROPERTY_CLIENTCODERELATIONID_DEFAULTSHOWRECORDDAYS = new IntProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".DefaultShowRecordDays"));
		public static readonly IntProperty PROPERTY_CLIENTCODERELATIONID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_CLIENTCODERELATIONID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_CLIENTCODERELATIONID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_CLIENTCODERELATIONID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_CLIENTCODERELATIONID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly DecimalProperty PROPERTY_PRICE = new DecimalProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_PRICE));		
		public static readonly IntProperty PROPERTY_COUNT = new IntProperty(Property.ForName(SPRecordEntity.PROPERTY_NAME_COUNT));		
      
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
                case "LinkID":
                    return typeof (string);
                case "Mo":
                    return typeof (string);
                case "Mobile":
                    return typeof (string);
                case "SpNumber":
                    return typeof (string);
                case "Province":
                    return typeof (string);
                case "City":
                    return typeof (string);
                case "OperatorType":
                    return typeof (string);
                case "CreateDate":
                    return typeof (DateTime);
                case "IsReport":
                    return typeof (bool);
                case "IsIntercept":
                    return typeof (bool);
                case "IsSycnToClient":
                    return typeof (bool);
                case "IsSycnSuccessed":
                    return typeof (bool);
                case "IsStatOK":
                    return typeof (bool);
                case "SycnRetryTimes":
                    return typeof (int);
                case "ChannelID":
                    return typeof (int);
                case "ClientID":
                    return typeof (int);
                case "CodeID":
                    return typeof (int);
                case "ClientCodeRelationID":
                    return typeof (int);
                case "Price":
                    return typeof (decimal);
                case "Count":
                    return typeof (int);
          }
			return typeof(string);
        }
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SPRecordEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "ChannelID_SPRecordEntity_Alias":
                    queryGenerator.AddAlians(SPRecordEntity.PROPERTY_NAME_CHANNELID, PROPERTY_CHANNELID_ALIAS_NAME);
                    break;
	            case "ClientID_SPRecordEntity_Alias":
                    queryGenerator.AddAlians(SPRecordEntity.PROPERTY_NAME_CLIENTID, PROPERTY_CLIENTID_ALIAS_NAME);
                    break;
	            case "CodeID_SPRecordEntity_Alias":
                    queryGenerator.AddAlians(SPRecordEntity.PROPERTY_NAME_CODEID, PROPERTY_CODEID_ALIAS_NAME);
                    break;
	            case "ClientCodeRelationID_SPRecordEntity_Alias":
                    queryGenerator.AddAlians(SPRecordEntity.PROPERTY_NAME_CLIENTCODERELATIONID, PROPERTY_CLIENTCODERELATIONID_ALIAS_NAME);
                    break;
                default:
                    break;
 
            }
        }
		
		
		
		public List<SPRecordEntity> GetList_By_ChannelID_SPChannelEntity(SPChannelEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPRecordEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CHANNELID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPRecordEntity> GetPageList_By_ChannelID_SPChannelEntity(string orderByColumnName, bool isDesc, SPChannelEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPRecordEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CHANNELID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SPRecordEntity> GetList_By_ClientID_SPSClientEntity(SPSClientEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPRecordEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CLIENTID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPRecordEntity> GetPageList_By_ClientID_SPSClientEntity(string orderByColumnName, bool isDesc, SPSClientEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPRecordEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CLIENTID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SPRecordEntity> GetList_By_CodeID_SPCodeEntity(SPCodeEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPRecordEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CODEID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPRecordEntity> GetPageList_By_CodeID_SPCodeEntity(string orderByColumnName, bool isDesc, SPCodeEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPRecordEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CODEID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SPRecordEntity> GetList_By_ClientCodeRelationID_SPClientCodeRelationEntity(SPClientCodeRelationEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPRecordEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CLIENTCODERELATIONID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPRecordEntity> GetPageList_By_ClientCodeRelationID_SPClientCodeRelationEntity(string orderByColumnName, bool isDesc, SPClientCodeRelationEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPRecordEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CLIENTCODERELATIONID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
