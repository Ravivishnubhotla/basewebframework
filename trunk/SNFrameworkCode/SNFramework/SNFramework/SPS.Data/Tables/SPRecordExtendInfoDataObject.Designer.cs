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
    public partial class SPRecordExtendInfoDataObject : BaseNHibernateDataObject<SPRecordExtendInfoEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_ID));		
		public static readonly EntityProperty<SPRecordEntity> PROPERTY_RECORDID = new EntityProperty<SPRecordEntity>(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_RECORDID));
		#region recordID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPRecordExtendInfoEntity> InClude_RecordID_Query(NHibernateDynamicQueryGenerator<SPRecordExtendInfoEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPRecordExtendInfoEntity.PROPERTY_NAME_RECORDID, PROPERTY_RECORDID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_RECORDID_ALIAS_NAME = "RecordID_SPRecordExtendInfoEntity_Alias";
		public static readonly IntProperty PROPERTY_RECORDID_ID = new IntProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_RECORDID_LINKID = new StringProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".LinkID"));
		public static readonly StringProperty PROPERTY_RECORDID_MO = new StringProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".Mo"));
		public static readonly StringProperty PROPERTY_RECORDID_MOBILE = new StringProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".Mobile"));
		public static readonly StringProperty PROPERTY_RECORDID_SPNUMBER = new StringProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".SpNumber"));
		public static readonly StringProperty PROPERTY_RECORDID_PROVINCE = new StringProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".Province"));
		public static readonly StringProperty PROPERTY_RECORDID_CITY = new StringProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".City"));
		public static readonly DateTimeProperty PROPERTY_RECORDID_CREATEDATE = new DateTimeProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".CreateDate"));
		public static readonly BoolProperty PROPERTY_RECORDID_ISREPORT = new BoolProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".IsReport"));
		public static readonly BoolProperty PROPERTY_RECORDID_ISINTERCEPT = new BoolProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".IsIntercept"));
		public static readonly BoolProperty PROPERTY_RECORDID_ISSYCNTOCLIENT = new BoolProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".IsSycnToClient"));
		public static readonly BoolProperty PROPERTY_RECORDID_ISSYCNSUCCESSED = new BoolProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".IsSycnSuccessed"));
		public static readonly BoolProperty PROPERTY_RECORDID_ISSTATOK = new BoolProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".IsStatOK"));
		public static readonly IntProperty PROPERTY_RECORDID_SYCNRETRYTIMES = new IntProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".SycnRetryTimes"));
		public static readonly EntityProperty<SPChannelEntity> PROPERTY_RECORDID_CHANNELID = new EntityProperty<SPChannelEntity>(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".ChannelID"));
		public static readonly EntityProperty<SPSClientEntity> PROPERTY_RECORDID_CLIENTID = new EntityProperty<SPSClientEntity>(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".ClientID"));
		public static readonly EntityProperty<SPCodeEntity> PROPERTY_RECORDID_CODEID = new EntityProperty<SPCodeEntity>(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".CodeID"));
		public static readonly DecimalProperty PROPERTY_RECORDID_PRICE = new DecimalProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".Price"));
		public static readonly IntProperty PROPERTY_RECORDID_COUNT = new IntProperty(Property.ForName(PROPERTY_RECORDID_ALIAS_NAME + ".Count"));
		#endregion
		public static readonly StringProperty PROPERTY_IP = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_IP));		
		public static readonly StringProperty PROPERTY_SSYCNDATAURL = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_SSYCNDATAURL));		
		public static readonly StringProperty PROPERTY_REQUESTCONTENT = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_REQUESTCONTENT));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD1 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD1));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD2 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD2));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD3 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD3));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD4 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD4));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD5 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD5));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD6 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD6));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD8 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD8));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD7 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD7));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD9 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD9));		
		public static readonly StringProperty PROPERTY_EXTENDFIELD10 = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_EXTENDFIELD10));		
		public static readonly StringProperty PROPERTY_STATE = new StringProperty(Property.ForName(SPRecordExtendInfoEntity.PROPERTY_NAME_STATE));		
      
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
                case "RecordID":
                    return typeof (int);
                case "Ip":
                    return typeof (string);
                case "SSycnDataUrl":
                    return typeof (string);
                case "RequestContent":
                    return typeof (string);
                case "ExtendField1":
                    return typeof (string);
                case "ExtendField2":
                    return typeof (string);
                case "ExtendField3":
                    return typeof (string);
                case "ExtendField4":
                    return typeof (string);
                case "ExtendField5":
                    return typeof (string);
                case "ExtendField6":
                    return typeof (string);
                case "ExtendField8":
                    return typeof (string);
                case "ExtendField7":
                    return typeof (string);
                case "ExtendField9":
                    return typeof (string);
                case "ExtendField10":
                    return typeof (string);
                case "State":
                    return typeof (string);
          }
			return typeof(string);
        }
		
		public List<SPRecordExtendInfoEntity> GetList_By_RecordID_SPRecordEntity(SPRecordEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPRecordExtendInfoEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_RECORDID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPRecordExtendInfoEntity> GetPageList_By_RecordID_SPRecordEntity(string orderByColumnName, bool isDesc, SPRecordEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPRecordExtendInfoEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_RECORDID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
