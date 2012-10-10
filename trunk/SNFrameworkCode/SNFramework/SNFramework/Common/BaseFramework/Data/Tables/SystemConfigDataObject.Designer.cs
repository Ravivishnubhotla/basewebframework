// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemConfigDataObject.Designer.cs">
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
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemConfigDataObject : BaseNHibernateDataObject<SystemConfigEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_SYSTEMCONFIGID = new IntProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_SYSTEMCONFIGID));		
		public static readonly StringProperty PROPERTY_CONFIGKEY = new StringProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_CONFIGKEY));		
		public static readonly StringProperty PROPERTY_CONFIGVALUE = new StringProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_CONFIGVALUE));		
		public static readonly StringProperty PROPERTY_CONFIGDATATYPE = new StringProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_CONFIGDATATYPE));		
		public static readonly StringProperty PROPERTY_CONFIGDESCRIPTION = new StringProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_CONFIGDESCRIPTION));		
		public static readonly IntProperty PROPERTY_SORTINDEX = new IntProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_SORTINDEX));		
		public static readonly EntityProperty<SystemConfigGroupEntity> PROPERTY_CONFIGGROUPID = new EntityProperty<SystemConfigGroupEntity>(Property.ForName(SystemConfigEntity.PROPERTY_NAME_CONFIGGROUPID));
		#region configGroupID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemConfigEntity> InClude_ConfigGroupID_Query(NHibernateDynamicQueryGenerator<SystemConfigEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemConfigEntity.PROPERTY_NAME_CONFIGGROUPID, PROPERTY_CONFIGGROUPID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_CONFIGGROUPID_ALIAS_NAME = "ConfigGroupID_SystemConfigEntity_Alias";
		public static readonly IntProperty PROPERTY_CONFIGGROUPID_ID = new IntProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_CONFIGGROUPID_NAME = new StringProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".Name"));
		public static readonly StringProperty PROPERTY_CONFIGGROUPID_CODE = new StringProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".Code"));
		public static readonly StringProperty PROPERTY_CONFIGGROUPID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".Description"));
		public static readonly BoolProperty PROPERTY_CONFIGGROUPID_ISENABLE = new BoolProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".IsEnable"));
		public static readonly BoolProperty PROPERTY_CONFIGGROUPID_ISSYSTEM = new BoolProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".IsSystem"));
		public static readonly IntProperty PROPERTY_CONFIGGROUPID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_CONFIGGROUPID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_CONFIGGROUPID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_CONFIGGROUPID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_CONFIGGROUPID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_CONFIGGROUPID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_LASTMODIFYAT));		
		public static readonly StringProperty PROPERTY_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(SystemConfigEntity.PROPERTY_NAME_LASTMODIFYCOMMENT));		
      












		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "SystemConfigID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "SystemConfigID":
                    return typeof (int);
                case "ConfigKey":
                    return typeof (string);
                case "ConfigValue":
                    return typeof (string);
                case "ConfigDataType":
                    return typeof (string);
                case "ConfigDescription":
                    return typeof (string);
                case "SortIndex":
                    return typeof (int);
                case "ConfigGroupID":
                    return typeof (int);
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
	            case "ConfigGroupID_SystemConfigEntity_Alias":
					switch (fieldName)
					{
                		case "ConfigGroupID_SystemConfigEntity_Alias.Id":
							return typeof (int);
                		case "ConfigGroupID_SystemConfigEntity_Alias.Name":
							return typeof (string);
                		case "ConfigGroupID_SystemConfigEntity_Alias.Code":
							return typeof (string);
                		case "ConfigGroupID_SystemConfigEntity_Alias.Description":
							return typeof (string);
                		case "ConfigGroupID_SystemConfigEntity_Alias.IsEnable":
							return typeof (bool);
                		case "ConfigGroupID_SystemConfigEntity_Alias.IsSystem":
							return typeof (bool);
                		case "ConfigGroupID_SystemConfigEntity_Alias.CreateBy":
							return typeof (int);
                		case "ConfigGroupID_SystemConfigEntity_Alias.CreateAt":
							return typeof (DateTime);
                		case "ConfigGroupID_SystemConfigEntity_Alias.LastModifyBy":
							return typeof (int);
                		case "ConfigGroupID_SystemConfigEntity_Alias.LastModifyAt":
							return typeof (DateTime);
                		case "ConfigGroupID_SystemConfigEntity_Alias.LastModifyComment":
							return typeof (string);
          			}
                    break;
 
                default:
                    break;
            }

            return typeof(string);
        }
		
		#endregion

        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemConfigEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "ConfigGroupID_SystemConfigEntity_Alias":
                    queryGenerator.AddAlians(SystemConfigEntity.PROPERTY_NAME_CONFIGGROUPID, PROPERTY_CONFIGGROUPID_ALIAS_NAME);
                    break;
                default:
                    break;
 
            }
        }
		
		
		
		public List<SystemConfigEntity> GetList_By_ConfigGroupID_SystemConfigGroupEntity(SystemConfigGroupEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemConfigEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CONFIGGROUPID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemConfigEntity> GetPageList_By_ConfigGroupID_SystemConfigGroupEntity(string orderByColumnName, bool isDesc, SystemConfigGroupEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemConfigEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_CONFIGGROUPID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
