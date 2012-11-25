// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SPAdPackDataObject.Designer.cs">
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
    public partial class SPAdPackDataObject : BaseNHibernateDataObject<SPAdPackEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SPAdPackEntity.PROPERTY_NAME_ID));		
		public static readonly EntityProperty<SPAdvertisementEntity> PROPERTY_SPADID = new EntityProperty<SPAdvertisementEntity>(Property.ForName(SPAdPackEntity.PROPERTY_NAME_SPADID));
		#region sPAdID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SPAdPackEntity> InClude_SPAdID_Query(NHibernateDynamicQueryGenerator<SPAdPackEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SPAdPackEntity.PROPERTY_NAME_SPADID, PROPERTY_SPADID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_SPADID_ALIAS_NAME = "SPAdID_SPAdPackEntity_Alias";
		public static readonly IntProperty PROPERTY_SPADID_ID = new IntProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_SPADID_NAME = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".Name"));
		public static readonly StringProperty PROPERTY_SPADID_CODE = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".Code"));
		public static readonly StringProperty PROPERTY_SPADID_IMAGEURL = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".ImageUrl"));
		public static readonly StringProperty PROPERTY_SPADID_ADPRICE = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".AdPrice"));
		public static readonly StringProperty PROPERTY_SPADID_ACCOUNTTYPE = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".AccountType"));
		public static readonly StringProperty PROPERTY_SPADID_APPLYSTATUS = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".ApplyStatus"));
		public static readonly StringProperty PROPERTY_SPADID_ADTYPE = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".AdType"));
		public static readonly StringProperty PROPERTY_SPADID_ADTEXT = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".AdText"));
		public static readonly StringProperty PROPERTY_SPADID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".Description"));
		public static readonly BoolProperty PROPERTY_SPADID_ISDISABLE = new BoolProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".IsDisable"));
		public static readonly IntProperty PROPERTY_SPADID_ASSIGNEDCLIENT = new IntProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".AssignedClient"));
		public static readonly EntityProperty<SPUpperEntity> PROPERTY_SPADID_UPPERID = new EntityProperty<SPUpperEntity>(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".UpperID"));
		public static readonly IntProperty PROPERTY_SPADID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_SPADID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_SPADID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_SPADID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_SPADID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_SPADID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly StringProperty PROPERTY_NAME = new StringProperty(Property.ForName(SPAdPackEntity.PROPERTY_NAME_NAME));		
		public static readonly StringProperty PROPERTY_CODE = new StringProperty(Property.ForName(SPAdPackEntity.PROPERTY_NAME_CODE));		
		public static readonly StringProperty PROPERTY_DESCRIPTION = new StringProperty(Property.ForName(SPAdPackEntity.PROPERTY_NAME_DESCRIPTION));		
		public static readonly DecimalProperty PROPERTY_ADPRICE = new DecimalProperty(Property.ForName(SPAdPackEntity.PROPERTY_NAME_ADPRICE));		
      












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
                case "SPAdID":
                    return typeof (int);
                case "Name":
                    return typeof (string);
                case "Code":
                    return typeof (string);
                case "Description":
                    return typeof (string);
                case "AdPrice":
                    return typeof (decimal);
          }
			return typeof(string);
        }

		#region 获取外键字段类型
		
		public override Type GetFieldTypeByFieldName(string fieldName, string parent_alias)
        {
            switch (parent_alias)
            {
	            case "SPAdID_SPAdPackEntity_Alias":
					switch (fieldName)
					{
                		case "SPAdID_SPAdPackEntity_Alias.Id":
							return typeof (int);
                		case "SPAdID_SPAdPackEntity_Alias.Name":
							return typeof (string);
                		case "SPAdID_SPAdPackEntity_Alias.Code":
							return typeof (string);
                		case "SPAdID_SPAdPackEntity_Alias.ImageUrl":
							return typeof (string);
                		case "SPAdID_SPAdPackEntity_Alias.AdPrice":
							return typeof (string);
                		case "SPAdID_SPAdPackEntity_Alias.AccountType":
							return typeof (string);
                		case "SPAdID_SPAdPackEntity_Alias.ApplyStatus":
							return typeof (string);
                		case "SPAdID_SPAdPackEntity_Alias.AdType":
							return typeof (string);
                		case "SPAdID_SPAdPackEntity_Alias.AdText":
							return typeof (string);
                		case "SPAdID_SPAdPackEntity_Alias.Description":
							return typeof (string);
                		case "SPAdID_SPAdPackEntity_Alias.IsDisable":
							return typeof (bool);
                		case "SPAdID_SPAdPackEntity_Alias.AssignedClient":
							return typeof (int);
                		case "SPAdID_SPAdPackEntity_Alias.UpperID":
							return typeof (int);
                		case "SPAdID_SPAdPackEntity_Alias.CreateBy":
							return typeof (int);
                		case "SPAdID_SPAdPackEntity_Alias.CreateAt":
							return typeof (DateTime);
                		case "SPAdID_SPAdPackEntity_Alias.LastModifyBy":
							return typeof (int);
                		case "SPAdID_SPAdPackEntity_Alias.LastModifyAt":
							return typeof (DateTime);
                		case "SPAdID_SPAdPackEntity_Alias.LastModifyComment":
							return typeof (string);
          			}
                    break;
 
                default:
                    break;
            }

            return typeof(string);
        }
		
		#endregion

        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SPAdPackEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "SPAdID_SPAdPackEntity_Alias":
                    queryGenerator.AddAlians(SPAdPackEntity.PROPERTY_NAME_SPADID, PROPERTY_SPADID_ALIAS_NAME);
                    break;
                default:
                    break;
 
            }
        }
		
		
		
		public List<SPAdPackEntity> GetList_By_SPAdID_SPAdvertisementEntity(SPAdvertisementEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SPAdPackEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_SPADID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SPAdPackEntity> GetPageList_By_SPAdID_SPAdvertisementEntity(string orderByColumnName, bool isDesc, SPAdvertisementEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SPAdPackEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_SPADID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
