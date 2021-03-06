// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPSClientDataObject.Designer.cs">
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
    public partial class SPSClientDataObject : BaseNHibernateDataObject<SPSClientEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_NAME = new StringProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_NAME));		
		public static readonly StringProperty PROPERTY_DESCRIPTION = new StringProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_DESCRIPTION));		
		public static readonly IntProperty PROPERTY_USERID = new IntProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_USERID));		
		public static readonly BoolProperty PROPERTY_ISDEFAULTCLIENT = new BoolProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_ISDEFAULTCLIENT));		
		public static readonly BoolProperty PROPERTY_SYNCDATA = new BoolProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_SYNCDATA));		
		public static readonly IntProperty PROPERTY_SYCNNOTINTERCEPTCOUNT = new IntProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_SYCNNOTINTERCEPTCOUNT));		
		public static readonly EntityProperty<SPSDataSycnSettingEntity> PROPERTY_SYNCDATASETTING = new EntityProperty<SPSDataSycnSettingEntity>(Property.ForName(SPSClientEntity.PROPERTY_NAME_SYNCDATASETTING));
		#region syncDataSetting字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPSClientEntity> InClude_SyncDataSetting_Query(NHibernateDynamicQueryGenerator<SPSClientEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPSClientEntity.PROPERTY_NAME_SYNCDATASETTING, PROPERTY_SYNCDATASETTING_ALIAS_NAME);
        }
        public static readonly string PROPERTY_SYNCDATASETTING_ALIAS_NAME = "SyncDataSetting_SPSClientEntity_Alias";
		public static readonly IntProperty PROPERTY_SYNCDATASETTING_ID = new IntProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".Id"));
		public static readonly IntProperty PROPERTY_SYNCDATASETTING_SYCNRETRYTIMES = new IntProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnRetryTimes"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYNCTYPE = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SyncType"));
		public static readonly BoolProperty PROPERTY_SYNCDATASETTING_SYCNMO = new BoolProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnMO"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYCNMOURL = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnMOUrl"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYCNMOOKMESSAGE = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnMOOkMessage"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYCNMOFAILEDMESSAGE = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnMOFailedMessage"));
		public static readonly BoolProperty PROPERTY_SYNCDATASETTING_SYCNMR = new BoolProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnMR"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYCNMRURL = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnMRUrl"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYCNMROKMESSAGE = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnMROkMessage"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYCNMRFAILEDMESSAGE = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnMRFailedMessage"));
		public static readonly BoolProperty PROPERTY_SYNCDATASETTING_SYCNSATE = new BoolProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnSate"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYCNSATEURL = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnSateUrl"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYCNSATEOKMESSAGE = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnSateOkMessage"));
		public static readonly StringProperty PROPERTY_SYNCDATASETTING_SYCNSATEFAILEDMESSAGE = new StringProperty(Property.ForName(PROPERTY_SYNCDATASETTING_ALIAS_NAME + ".SycnSateFailedMessage"));
		#endregion
		public static readonly StringProperty PROPERTY_ALIAS = new StringProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_ALIAS));		
		public static readonly BoolProperty PROPERTY_ISENABLE = new BoolProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_ISENABLE));		
		public static readonly DecimalProperty PROPERTY_INTERCEPTRATE = new DecimalProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_INTERCEPTRATE));		
		public static readonly DecimalProperty PROPERTY_DEFAULTPRICE = new DecimalProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_DEFAULTPRICE));		
		public static readonly IntProperty PROPERTY_DEFAULTSHOWRECORDDAYS = new IntProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_DEFAULTSHOWRECORDDAYS));		
		public static readonly StringProperty PROPERTY_CHANNELSTATUS = new StringProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_CHANNELSTATUS));		
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_LASTMODIFYAT));		
		public static readonly StringProperty PROPERTY_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(SPSClientEntity.PROPERTY_NAME_LASTMODIFYCOMMENT));		
      












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
                case "UserID":
                    return typeof (int);
                case "IsDefaultClient":
                    return typeof (bool);
                case "SyncData":
                    return typeof (bool);
                case "SycnNotInterceptCount":
                    return typeof (int);
                case "SyncDataSetting":
                    return typeof (int);
                case "Alias":
                    return typeof (string);
                case "IsEnable":
                    return typeof (bool);
                case "InterceptRate":
                    return typeof (decimal);
                case "DefaultPrice":
                    return typeof (decimal);
                case "DefaultShowRecordDays":
                    return typeof (int);
                case "ChannelStatus":
                    return typeof (string);
                case "CreateBy":
                    return typeof (int);
                case "CreateAt":
                    return typeof (DateTime);
                case "LastModifyBy":
                    return typeof (int);
                case "LastModifyAt":
                    return typeof (DateTime);
                case "LastModifyComment":
                    return typeof (string);
          }
			return typeof(string);
        }

		#region 获取外键字段类型
		
		public override Type GetFieldTypeByFieldName(string fieldName, string parent_alias)
        {
            switch (parent_alias)
            {
	            case "SyncDataSetting_SPSClientEntity_Alias":
					switch (fieldName)
					{
                		case "SyncDataSetting_SPSClientEntity_Alias.Id":
							return typeof (int);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnRetryTimes":
							return typeof (int);
                		case "SyncDataSetting_SPSClientEntity_Alias.SyncType":
							return typeof (string);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnMO":
							return typeof (bool);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnMOUrl":
							return typeof (string);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnMOOkMessage":
							return typeof (string);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnMOFailedMessage":
							return typeof (string);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnMR":
							return typeof (bool);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnMRUrl":
							return typeof (string);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnMROkMessage":
							return typeof (string);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnMRFailedMessage":
							return typeof (string);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnSate":
							return typeof (bool);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnSateUrl":
							return typeof (string);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnSateOkMessage":
							return typeof (string);
                		case "SyncDataSetting_SPSClientEntity_Alias.SycnSateFailedMessage":
							return typeof (string);
          			}
                    break;
 
                default:
                    break;
            }

            return typeof(string);
        }
		
		#endregion

        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SPSClientEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "SyncDataSetting_SPSClientEntity_Alias":
                    queryGenerator.AddAlians(SPSClientEntity.PROPERTY_NAME_SYNCDATASETTING, PROPERTY_SYNCDATASETTING_ALIAS_NAME);
                    break;
                default:
                    break;
 
            }
        }
		
		
		
		public List<SPSClientEntity> GetList_By_SyncDataSetting_SPSDataSycnSettingEntity(SPSDataSycnSettingEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPSClientEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_SYNCDATASETTING.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPSClientEntity> GetPageList_By_SyncDataSetting_SPSDataSycnSettingEntity(string orderByColumnName, bool isDesc, SPSDataSycnSettingEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPSClientEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_SYNCDATASETTING.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
