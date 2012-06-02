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
    public partial class SystemPrivilegeInRolesDataObject : BaseNHibernateDataObject<SystemPrivilegeInRolesEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_PRIVILEGEROLEID = new IntProperty(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_PRIVILEGEROLEID));		
		public static readonly EntityProperty<SystemRoleEntity> PROPERTY_ROLEID = new EntityProperty<SystemRoleEntity>(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_ROLEID));
		#region roleID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> InClude_RoleID_Query(NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemPrivilegeInRolesEntity.PROPERTY_NAME_ROLEID, PROPERTY_ROLEID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_ROLEID_ALIAS_NAME = "RoleID_SystemPrivilegeInRolesEntity_Alias";
		public static readonly IntProperty PROPERTY_ROLEID_ROLEID = new IntProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleID"));
		public static readonly StringProperty PROPERTY_ROLEID_ROLENAME = new StringProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleName"));
		public static readonly StringProperty PROPERTY_ROLEID_ROLECODE = new StringProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleCode"));
		public static readonly StringProperty PROPERTY_ROLEID_ROLEDESCRIPTION = new StringProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleDescription"));
		public static readonly BoolProperty PROPERTY_ROLEID_ROLEISSYSTEMROLE = new BoolProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleIsSystemRole"));
		public static readonly StringProperty PROPERTY_ROLEID_ROLETYPE = new StringProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleType"));
		public static readonly IntProperty PROPERTY_ROLEID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_ROLEID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_ROLEID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_ROLEID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_ROLEID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly EntityProperty<SystemPrivilegeEntity> PROPERTY_PRIVILEGEID = new EntityProperty<SystemPrivilegeEntity>(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_PRIVILEGEID));
		#region privilegeID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> InClude_PrivilegeID_Query(NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemPrivilegeInRolesEntity.PROPERTY_NAME_PRIVILEGEID, PROPERTY_PRIVILEGEID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_PRIVILEGEID_ALIAS_NAME = "PrivilegeID_SystemPrivilegeInRolesEntity_Alias";
		public static readonly IntProperty PROPERTY_PRIVILEGEID_PRIVILEGEID = new IntProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".PrivilegeID"));
		public static readonly EntityProperty<SystemOperationEntity> PROPERTY_PRIVILEGEID_OPERATIONID = new EntityProperty<SystemOperationEntity>(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".OperationID"));
		public static readonly EntityProperty<SystemResourcesEntity> PROPERTY_PRIVILEGEID_RESOURCESID = new EntityProperty<SystemResourcesEntity>(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".ResourcesID"));
		public static readonly StringProperty PROPERTY_PRIVILEGEID_PRIVILEGECNNAME = new StringProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".PrivilegeCnName"));
		public static readonly StringProperty PROPERTY_PRIVILEGEID_PRIVILEGEENNAME = new StringProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".PrivilegeEnName"));
		public static readonly StringProperty PROPERTY_PRIVILEGEID_DEFAULTVALUE = new StringProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".DefaultValue"));
		public static readonly StringProperty PROPERTY_PRIVILEGEID_DESCRIPTION = new StringProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".Description"));
		public static readonly IntProperty PROPERTY_PRIVILEGEID_PRIVILEGEORDER = new IntProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".PrivilegeOrder"));
		public static readonly StringProperty PROPERTY_PRIVILEGEID_PRIVILEGETYPE = new StringProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".PrivilegeType"));
		public static readonly IntProperty PROPERTY_PRIVILEGEID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_PRIVILEGEID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_PRIVILEGEID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_PRIVILEGEID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_PRIVILEGEID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_PRIVILEGEID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly StringProperty PROPERTY_PRIVILEGEROLEVALUETYPE = new StringProperty(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_PRIVILEGEROLEVALUETYPE));		
		public static readonly StringProperty PROPERTY_ENABLETYPE = new StringProperty(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_ENABLETYPE));		
		public static readonly DateTimeProperty PROPERTY_CREATETIME = new DateTimeProperty(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_CREATETIME));		
		public static readonly DateTimeProperty PROPERTY_UPDATETIME = new DateTimeProperty(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_UPDATETIME));		
		public static readonly DateTimeProperty PROPERTY_EXPIRYTIME = new DateTimeProperty(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_EXPIRYTIME));		
		public static readonly BoolProperty PROPERTY_ENABLEPARAMETER = new BoolProperty(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_ENABLEPARAMETER));		
		public static readonly ByteArrayProperty PROPERTY_PRIVILEGEROLEVALUE = new ByteArrayProperty(Property.ForName(SystemPrivilegeInRolesEntity.PROPERTY_NAME_PRIVILEGEROLEVALUE));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "PrivilegeRoleID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "PrivilegeRoleID":
                    return typeof (int);
                case "RoleID":
                    return typeof (int);
                case "PrivilegeID":
                    return typeof (int);
                case "PrivilegeRoleValueType":
                    return typeof (string);
                case "EnableType":
                    return typeof (string);
                case "CreateTime":
                    return typeof (DateTime);
                case "UpdateTime":
                    return typeof (DateTime);
                case "ExpiryTime":
                    return typeof (DateTime);
                case "EnableParameter":
                    return typeof (bool);
                case "PrivilegeRoleValue":
                    return typeof (byte[]);
          }
			return typeof(string);
        }
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "RoleID_SystemPrivilegeInRolesEntity_Alias":
                    queryGenerator.AddAlians(SystemPrivilegeInRolesEntity.PROPERTY_NAME_ROLEID, PROPERTY_ROLEID_ALIAS_NAME);
                    break;
	            case "PrivilegeID_SystemPrivilegeInRolesEntity_Alias":
                    queryGenerator.AddAlians(SystemPrivilegeInRolesEntity.PROPERTY_NAME_PRIVILEGEID, PROPERTY_PRIVILEGEID_ALIAS_NAME);
                    break;
                default:
                    break;
 
            }
        }
		
		
		
		public List<SystemPrivilegeInRolesEntity> GetList_By_RoleID_SystemRoleEntity(SystemRoleEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemPrivilegeInRolesEntity> GetPageList_By_RoleID_SystemRoleEntity(string orderByColumnName, bool isDesc, SystemRoleEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SystemPrivilegeInRolesEntity> GetList_By_PrivilegeID_SystemPrivilegeEntity(SystemPrivilegeEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_PRIVILEGEID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemPrivilegeInRolesEntity> GetPageList_By_PrivilegeID_SystemPrivilegeEntity(string orderByColumnName, bool isDesc, SystemPrivilegeEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemPrivilegeInRolesEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_PRIVILEGEID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
