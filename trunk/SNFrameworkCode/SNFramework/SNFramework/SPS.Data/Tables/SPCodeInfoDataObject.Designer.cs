// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPCodeInfoDataObject.Designer.cs">
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
    public partial class SPCodeInfoDataObject : BaseNHibernateDataObject<SPCodeInfoEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPCodeInfoEntity.PROPERTY_NAME_ID));		
		public static readonly EntityProperty<SPCodeEntity> PROPERTY_SPCODEID = new EntityProperty<SPCodeEntity>(Property.ForName(SPCodeInfoEntity.PROPERTY_NAME_SPCODEID));
		#region sPCodeID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPCodeInfoEntity> InClude_SPCodeID_Query(NHibernateDynamicQueryGenerator<SPCodeInfoEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPCodeInfoEntity.PROPERTY_NAME_SPCODEID, PROPERTY_SPCODEID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_SPCODEID_ALIAS_NAME = "SPCodeID_SPCodeInfoEntity_Alias";
		public static readonly IntProperty PROPERTY_SPCODEID_ID = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_SPCODEID_NAME = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".Name"));
		public static readonly StringProperty PROPERTY_SPCODEID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".Description"));
		public static readonly StringProperty PROPERTY_SPCODEID_CODE = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".Code"));
		public static readonly StringProperty PROPERTY_SPCODEID_CODETYPE = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".CodeType"));
		public static readonly EntityProperty<SPChannelEntity> PROPERTY_SPCODEID_CHANNELID = new EntityProperty<SPChannelEntity>(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".ChannelID"));
		public static readonly StringProperty PROPERTY_SPCODEID_MO = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".Mo"));
		public static readonly StringProperty PROPERTY_SPCODEID_MOTYPE = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".MOType"));
		public static readonly IntProperty PROPERTY_SPCODEID_MOLENGTH = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".MOLength"));
		public static readonly IntProperty PROPERTY_SPCODEID_ORDERINDEX = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".OrderIndex"));
		public static readonly StringProperty PROPERTY_SPCODEID_SPCODE = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".SPCode"));
		public static readonly StringProperty PROPERTY_SPCODEID_SPCODETYPE = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".SPCodeType"));
		public static readonly IntProperty PROPERTY_SPCODEID_SPCODELENGTH = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".SPCodeLength"));
		public static readonly BoolProperty PROPERTY_SPCODEID_HASFILTERS = new BoolProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".HasFilters"));
		public static readonly BoolProperty PROPERTY_SPCODEID_HASPARAMSCONVERT = new BoolProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".HasParamsConvert"));
		public static readonly BoolProperty PROPERTY_SPCODEID_ISDIABLE = new BoolProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".IsDiable"));
		public static readonly DecimalProperty PROPERTY_SPCODEID_PRICE = new DecimalProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".Price"));
		public static readonly StringProperty PROPERTY_SPCODEID_OPERATIONTYPE = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".OperationType"));
		public static readonly BoolProperty PROPERTY_SPCODEID_HASDAYTOTALLIMIT = new BoolProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".HasDayTotalLimit"));
		public static readonly IntProperty PROPERTY_SPCODEID_DAYTOTALLIMITCOUNT = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".DayTotalLimitCount"));
		public static readonly BoolProperty PROPERTY_SPCODEID_HASPHONELIMIT = new BoolProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".HasPhoneLimit"));
		public static readonly IntProperty PROPERTY_SPCODEID_PHONELIMITDAYCOUNT = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".PhoneLimitDayCount"));
		public static readonly IntProperty PROPERTY_SPCODEID_PHONELIMITMONTHCOUNT = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".PhoneLimitMonthCount"));
		public static readonly IntProperty PROPERTY_SPCODEID_PHONELIMITTYPE = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".PhoneLimitType"));
		public static readonly BoolProperty PROPERTY_SPCODEID_LIMITPROVINCE = new BoolProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".LimitProvince"));
		public static readonly StringProperty PROPERTY_SPCODEID_LIMITPROVINCEAREA = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".LimitProvinceArea"));
		public static readonly EntityProperty<SPCodeEntity> PROPERTY_SPCODEID_PARENTID = new EntityProperty<SPCodeEntity>(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".ParentID"));
		public static readonly BoolProperty PROPERTY_SPCODEID_ISMATCHCASE = new BoolProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".IsMatchCase"));
		public static readonly BoolProperty PROPERTY_SPCODEID_ISDAYTIMELIMIT = new BoolProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".IsDayTimeLimit"));
		public static readonly DateTimeProperty PROPERTY_SPCODEID_DAYTIMELIMITRANGESTART = new DateTimeProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".DayTimeLimitRangeStart"));
		public static readonly DateTimeProperty PROPERTY_SPCODEID_DAYTIMELIMITRANGEEND = new DateTimeProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".DayTimeLimitRangeEnd"));
		public static readonly StringProperty PROPERTY_SPCODEID_CHANNELSTATUS = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".ChannelStatus"));
		public static readonly IntProperty PROPERTY_SPCODEID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_SPCODEID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_SPCODEID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_SPCODEID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_SPCODEID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_SPCODEID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly StringProperty PROPERTY_PROVINCE = new StringProperty(Property.ForName(SPCodeInfoEntity.PROPERTY_NAME_PROVINCE));		
		public static readonly StringProperty PROPERTY_DISABLECITY = new StringProperty(Property.ForName(SPCodeInfoEntity.PROPERTY_NAME_DISABLECITY));		
		public static readonly StringProperty PROPERTY_DAYLIMIT = new StringProperty(Property.ForName(SPCodeInfoEntity.PROPERTY_NAME_DAYLIMIT));		
		public static readonly StringProperty PROPERTY_MONTHLIMIT = new StringProperty(Property.ForName(SPCodeInfoEntity.PROPERTY_NAME_MONTHLIMIT));		
		public static readonly StringProperty PROPERTY_SENDTEXT = new StringProperty(Property.ForName(SPCodeInfoEntity.PROPERTY_NAME_SENDTEXT));		
      












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
                case "SPCodeID":
                    return typeof (int);
                case "Province":
                    return typeof (string);
                case "DisableCity":
                    return typeof (string);
                case "DayLimit":
                    return typeof (string);
                case "MonthLimit":
                    return typeof (string);
                case "SendText":
                    return typeof (string);
          }
			return typeof(string);
        }

		#region 获取外键字段类型
		
		public override Type GetFieldTypeByFieldName(string fieldName, string parent_alias)
        {
            switch (parent_alias)
            {
	            case "SPCodeID_SPCodeInfoEntity_Alias":
					switch (fieldName)
					{
                		case "SPCodeID_SPCodeInfoEntity_Alias.Id":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.Name":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.Description":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.Code":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.CodeType":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.ChannelID":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.Mo":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.MOType":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.MOLength":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.OrderIndex":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.SPCode":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.SPCodeType":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.SPCodeLength":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.HasFilters":
							return typeof (bool);
                		case "SPCodeID_SPCodeInfoEntity_Alias.HasParamsConvert":
							return typeof (bool);
                		case "SPCodeID_SPCodeInfoEntity_Alias.IsDiable":
							return typeof (bool);
                		case "SPCodeID_SPCodeInfoEntity_Alias.Price":
							return typeof (decimal);
                		case "SPCodeID_SPCodeInfoEntity_Alias.OperationType":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.HasDayTotalLimit":
							return typeof (bool);
                		case "SPCodeID_SPCodeInfoEntity_Alias.DayTotalLimitCount":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.HasPhoneLimit":
							return typeof (bool);
                		case "SPCodeID_SPCodeInfoEntity_Alias.PhoneLimitDayCount":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.PhoneLimitMonthCount":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.PhoneLimitType":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.LimitProvince":
							return typeof (bool);
                		case "SPCodeID_SPCodeInfoEntity_Alias.LimitProvinceArea":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.ParentID":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.IsMatchCase":
							return typeof (bool);
                		case "SPCodeID_SPCodeInfoEntity_Alias.IsDayTimeLimit":
							return typeof (bool);
                		case "SPCodeID_SPCodeInfoEntity_Alias.DayTimeLimitRangeStart":
							return typeof (DateTime);
                		case "SPCodeID_SPCodeInfoEntity_Alias.DayTimeLimitRangeEnd":
							return typeof (DateTime);
                		case "SPCodeID_SPCodeInfoEntity_Alias.ChannelStatus":
							return typeof (string);
                		case "SPCodeID_SPCodeInfoEntity_Alias.CreateBy":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.CreateAt":
							return typeof (DateTime);
                		case "SPCodeID_SPCodeInfoEntity_Alias.LastModifyBy":
							return typeof (int);
                		case "SPCodeID_SPCodeInfoEntity_Alias.LastModifyAt":
							return typeof (DateTime);
                		case "SPCodeID_SPCodeInfoEntity_Alias.LastModifyComment":
							return typeof (string);
          			}
                    break;
 
                default:
                    break;
            }

            return typeof(string);
        }
		
		#endregion

        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SPCodeInfoEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "SPCodeID_SPCodeInfoEntity_Alias":
                    queryGenerator.AddAlians(SPCodeInfoEntity.PROPERTY_NAME_SPCODEID, PROPERTY_SPCODEID_ALIAS_NAME);
                    break;
                default:
                    break;
 
            }
        }
		
		
		
		public List<SPCodeInfoEntity> GetList_By_SPCodeID_SPCodeEntity(SPCodeEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPCodeInfoEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_SPCODEID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPCodeInfoEntity> GetPageList_By_SPCodeID_SPCodeEntity(string orderByColumnName, bool isDesc, SPCodeEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPCodeInfoEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_SPCODEID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
