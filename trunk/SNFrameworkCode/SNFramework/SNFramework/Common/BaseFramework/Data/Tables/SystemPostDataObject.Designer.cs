// Generated by MyGeneration Version # (1.3.0.9)
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
    public partial class SystemPostDataObject : BaseNHibernateDataObject<SystemPostEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_ID = new IntProperty(Property.ForName(SystemPostEntity.PROPERTY_NAME_ID));		
		public static readonly StringProperty PROPERTY_NAME = new StringProperty(Property.ForName(SystemPostEntity.PROPERTY_NAME_NAME));		
		public static readonly StringProperty PROPERTY_CODE = new StringProperty(Property.ForName(SystemPostEntity.PROPERTY_NAME_CODE));		
		public static readonly StringProperty PROPERTY_DESCRIPTION = new StringProperty(Property.ForName(SystemPostEntity.PROPERTY_NAME_DESCRIPTION));		
		public static readonly EntityProperty<SystemOrganizationEntity> PROPERTY_ORGANIZATIONID = new EntityProperty<SystemOrganizationEntity>(Property.ForName(SystemPostEntity.PROPERTY_NAME_ORGANIZATIONID));
		#region organizationID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemPostEntity> InClude_OrganizationID_Query(NHibernateDynamicQueryGenerator<SystemPostEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemPostEntity.PROPERTY_NAME_ORGANIZATIONID, PROPERTY_ORGANIZATIONID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_ORGANIZATIONID_ALIAS_NAME = "OrganizationID_SystemPostEntity_Alias";
		public static readonly IntProperty PROPERTY_ORGANIZATIONID_ID = new IntProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".Id"));
		public static readonly StringProperty PROPERTY_ORGANIZATIONID_NAME = new StringProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".Name"));
		public static readonly StringProperty PROPERTY_ORGANIZATIONID_CODE = new StringProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".Code"));
		public static readonly StringProperty PROPERTY_ORGANIZATIONID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".Description"));
		public static readonly BoolProperty PROPERTY_ORGANIZATIONID_ISMAINORGANIZATION = new BoolProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".IsMainOrganization"));
		public static readonly IntProperty PROPERTY_ORGANIZATIONID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_ORGANIZATIONID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_ORGANIZATIONID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_ORGANIZATIONID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_ORGANIZATIONID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_ORGANIZATIONID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly IntProperty PROPERTY_CREATEBY = new IntProperty(Property.ForName(SystemPostEntity.PROPERTY_NAME_CREATEBY));		
		public static readonly DateTimeProperty PROPERTY_CREATEAT = new DateTimeProperty(Property.ForName(SystemPostEntity.PROPERTY_NAME_CREATEAT));		
		public static readonly IntProperty PROPERTY_LASTMODIFYBY = new IntProperty(Property.ForName(SystemPostEntity.PROPERTY_NAME_LASTMODIFYBY));		
		public static readonly DateTimeProperty PROPERTY_LASTMODIFYAT = new DateTimeProperty(Property.ForName(SystemPostEntity.PROPERTY_NAME_LASTMODIFYAT));		
		public static readonly StringProperty PROPERTY_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(SystemPostEntity.PROPERTY_NAME_LASTMODIFYCOMMENT));		
      
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
                case "Code":
                    return typeof (string);
                case "Description":
                    return typeof (string);
                case "OrganizationID":
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
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemPostEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "OrganizationID_SystemPostEntity_Alias":
                    queryGenerator.AddAlians(SystemPostEntity.PROPERTY_NAME_ORGANIZATIONID, PROPERTY_ORGANIZATIONID_ALIAS_NAME);
                    break;
                default:
                    break;
 
            }
        }
		
		
		
		public List<SystemPostEntity> GetList_By_OrganizationID_SystemOrganizationEntity(SystemOrganizationEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemPostEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ORGANIZATIONID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemPostEntity> GetPageList_By_OrganizationID_SystemOrganizationEntity(string orderByColumnName, bool isDesc, SystemOrganizationEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemPostEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ORGANIZATIONID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
