// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPMonitoringRequestDataObject.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
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
    public partial class SPMonitoringRequestDataObject : BaseNHibernateDataObject<SPMonitoringRequestEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPMonitoringRequestEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_RECIEVEDCONTENT = new StringProperty(Property.ForName(SPMonitoringRequestEntity.PROPERTY_NAME_RECIEVEDCONTENT));		
		public static readonly DateTimeProperty PROPERTY_RECIEVEDDATE = new DateTimeProperty(Property.ForName(SPMonitoringRequestEntity.PROPERTY_NAME_RECIEVEDDATE));		
		public static readonly StringProperty PROPERTY_RECIEVEDIP = new StringProperty(Property.ForName(SPMonitoringRequestEntity.PROPERTY_NAME_RECIEVEDIP));		
		public static readonly StringProperty PROPERTY_RECIEVEDSENDURL = new StringProperty(Property.ForName(SPMonitoringRequestEntity.PROPERTY_NAME_RECIEVEDSENDURL));		
		public static readonly EntityProperty<SPChannelEntity> PROPERTY_CHANNELID = new EntityProperty<SPChannelEntity>(Property.ForName(SPMonitoringRequestEntity.PROPERTY_NAME_CHANNELID));
		#region channelID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPMonitoringRequestEntity> InClude_ChannelID_Query(NHibernateDynamicQueryGenerator<SPMonitoringRequestEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPMonitoringRequestEntity.PROPERTY_NAME_CHANNELID, PROPERTY_CHANNELID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CHANNELID_ALIAS_NAME = "ChannelID_SPMonitoringRequestEntity_Alias";
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
                case "RecievedContent":
                    return typeof (string);
                case "RecievedDate":
                    return typeof (DateTime);
                case "RecievedIP":
                    return typeof (string);
                case "RecievedSendUrl":
                    return typeof (string);
                case "ChannelID":
                    return typeof (int);
          }
			return typeof(string);
        }

		#region 获取外键字段类型
		
		public override Type GetFieldTypeByFieldName(string fieldName, string parent_alias)
        {
            switch (parent_alias)
            {
	            case "ChannelID_SPMonitoringRequestEntity_Alias":
					switch (fieldName)
					{
                		case "ChannelID_SPMonitoringRequestEntity_Alias.Id":
							return typeof (int);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.Name":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.Code":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.DataOkMessage":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.DataFailedMessage":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.Description":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.DataAdapterType":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.DataAdapterUrl":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.ChannelType":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.IVRFeeTimeType":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.IVRTimeFormat":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.IsStateReport":
							return typeof (bool);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.StateReportType":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.ReportOkMessage":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.ReportFailedMessage":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.StateReportParamName":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.StateReportParamValue":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.RequestTypeParamName":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.RequestTypeParamStateReportValue":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.RequestTypeParamDataReportValue":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.HasFilters":
							return typeof (bool);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.IsMonitorRequest":
							return typeof (bool);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.IsLogRequest":
							return typeof (bool);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.IsParamsConvert":
							return typeof (bool);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.IsAutoLinkID":
							return typeof (bool);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.AutoLinkIDFields":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.LogRequestType":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.Price":
							return typeof (decimal);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.DefaultRate":
							return typeof (decimal);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.ChannelDetailInfo":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.UpperID":
							return typeof (int);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.ChannelStatus":
							return typeof (string);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.IsDisable":
							return typeof (bool);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.CreateBy":
							return typeof (int);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.CreateAt":
							return typeof (DateTime);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.LastModifyBy":
							return typeof (int);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.LastModifyAt":
							return typeof (DateTime);
                		case "ChannelID_SPMonitoringRequestEntity_Alias.LastModifyComment":
							return typeof (string);
          			}
                    break;
 
                default:
                    break;
            }

            return typeof(string);
        }
		
		#endregion

        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SPMonitoringRequestEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "ChannelID_SPMonitoringRequestEntity_Alias":
                    queryGenerator.AddAlians(SPMonitoringRequestEntity.PROPERTY_NAME_CHANNELID, PROPERTY_CHANNELID_ALIAS_NAME);
                    break;
                default:
                    break;
 
            }
        }
		
		
		
		public List<SPMonitoringRequestEntity> GetList_By_ChannelID_SPChannelEntity(SPChannelEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPMonitoringRequestEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CHANNELID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPMonitoringRequestEntity> GetPageList_By_ChannelID_SPChannelEntity(string orderByColumnName, bool isDesc, SPChannelEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPMonitoringRequestEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CHANNELID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
