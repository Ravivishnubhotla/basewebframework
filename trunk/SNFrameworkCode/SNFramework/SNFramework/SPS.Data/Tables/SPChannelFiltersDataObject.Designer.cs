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
    public partial class SPChannelFiltersDataObject : BaseNHibernateDataObject<SPChannelFiltersEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_ID));		
		public static readonly EntityProperty<SPChannelEntity> PROPERTY_CHANNELID = new EntityProperty<SPChannelEntity>(Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_CHANNELID));
		#region channelID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPChannelFiltersEntity> InClude_ChannelID_Query(NHibernateDynamicQueryGenerator<SPChannelFiltersEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPChannelFiltersEntity.PROPERTY_NAME_CHANNELID, PROPERTY_CHANNELID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CHANNELID_ALIAS_NAME = "ChannelID_SPChannelFiltersEntity_Alias";
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
		#endregion
		public static readonly StringProperty PROPERTY_PARAMSNAME = new StringProperty(Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_PARAMSNAME));		
		public static readonly StringProperty PROPERTY_FILTERTYPE = new StringProperty(Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_FILTERTYPE));		
		public static readonly StringProperty PROPERTY_FILTERVALUE = new StringProperty(Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_FILTERVALUE));		
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SPChannelFiltersEntity.PROPERTY_NAME_LASTMODIFYAT));		
      
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
                case "ChannelID":
                    return typeof (int);
                case "ParamsName":
                    return typeof (string);
                case "FilterType":
                    return typeof (string);
                case "FilterValue":
                    return typeof (string);
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
		
		public List<SPChannelFiltersEntity> GetList_By_ChannelID_SPChannelEntity(SPChannelEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPChannelFiltersEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CHANNELID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPChannelFiltersEntity> GetPageList_By_ChannelID_SPChannelEntity(string orderByColumnName, bool isDesc, SPChannelEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPChannelFiltersEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CHANNELID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
