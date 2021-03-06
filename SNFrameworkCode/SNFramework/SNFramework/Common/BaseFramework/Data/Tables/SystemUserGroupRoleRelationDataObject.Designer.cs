// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemUserGroupRoleRelationDataObject.Designer.cs">
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
    public partial class SystemUserGroupRoleRelationDataObject : BaseNHibernateDataObject<SystemUserGroupRoleRelationEntity,int>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_USERGROUPROLEID = new IntProperty(Property.ForName(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_USERGROUPROLEID));		
		public static readonly EntityProperty<SystemRoleEntity> PROPERTY_ROLEID = new EntityProperty<SystemRoleEntity>(Property.ForName(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_ROLEID));
		#region roleID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> InClude_RoleID_Query(NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_ROLEID, PROPERTY_ROLEID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_ROLEID_ALIAS_NAME = "RoleID_SystemUserGroupRoleRelationEntity_Alias";
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
		public static readonly EntityProperty<SystemUserGroupEntity> PROPERTY_USERGROUPID = new EntityProperty<SystemUserGroupEntity>(Property.ForName(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_USERGROUPID));
		#region userGroupID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> InClude_UserGroupID_Query(NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_USERGROUPID, PROPERTY_USERGROUPID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_USERGROUPID_ALIAS_NAME = "UserGroupID_SystemUserGroupRoleRelationEntity_Alias";
		public static readonly IntProperty PROPERTY_USERGROUPID_GROUPID = new IntProperty(Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".GroupID"));
		public static readonly StringProperty PROPERTY_USERGROUPID_GROUPNAMECN = new StringProperty(Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".GroupNameCn"));
		public static readonly StringProperty PROPERTY_USERGROUPID_GROUPNAMEEN = new StringProperty(Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".GroupNameEn"));
		public static readonly StringProperty PROPERTY_USERGROUPID_GROUPDESCRIPTION = new StringProperty(Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".GroupDescription"));
		public static readonly IntProperty PROPERTY_USERGROUPID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_USERGROUPID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_USERGROUPID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_USERGROUPID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_USERGROUPID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
      












		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "UserGroupRoleID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "UserGroupRoleID":
                    return typeof (int);
                case "RoleID":
                    return typeof (int);
                case "UserGroupID":
                    return typeof (int);
          }
			return typeof(string);
        }

		#region 获取外键字段类型
		
		public override Type GetFieldTypeByFieldName(string fieldName, string parent_alias)
        {
            switch (parent_alias)
            {
	            case "RoleID_SystemUserGroupRoleRelationEntity_Alias":
					switch (fieldName)
					{
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.RoleID":
							return typeof (int);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.RoleName":
							return typeof (string);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.RoleCode":
							return typeof (string);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.RoleDescription":
							return typeof (string);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.RoleIsSystemRole":
							return typeof (bool);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.RoleType":
							return typeof (string);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.CreateBy":
							return typeof (int);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.CreateAt":
							return typeof (DateTime);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.LastModifyBy":
							return typeof (int);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.LastModifyAt":
							return typeof (DateTime);
                		case "RoleID_SystemUserGroupRoleRelationEntity_Alias.LastModifyComment":
							return typeof (string);
          			}
                    break;
	            case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias":
					switch (fieldName)
					{
                		case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias.GroupID":
							return typeof (int);
                		case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias.GroupNameCn":
							return typeof (string);
                		case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias.GroupNameEn":
							return typeof (string);
                		case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias.GroupDescription":
							return typeof (string);
                		case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias.CreateBy":
							return typeof (int);
                		case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias.CreateAt":
							return typeof (DateTime);
                		case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias.LastModifyBy":
							return typeof (int);
                		case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias.LastModifyAt":
							return typeof (DateTime);
                		case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias.LastModifyComment":
							return typeof (string);
          			}
                    break;
 
                default:
                    break;
            }

            return typeof(string);
        }
		
		#endregion

        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "RoleID_SystemUserGroupRoleRelationEntity_Alias":
                    queryGenerator.AddAlians(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_ROLEID, PROPERTY_ROLEID_ALIAS_NAME);
                    break;
	            case "UserGroupID_SystemUserGroupRoleRelationEntity_Alias":
                    queryGenerator.AddAlians(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_USERGROUPID, PROPERTY_USERGROUPID_ALIAS_NAME);
                    break;
                default:
                    break;
 
            }
        }
		
		
		
		public List<SystemUserGroupRoleRelationEntity> GetList_By_RoleID_SystemRoleEntity(SystemRoleEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemUserGroupRoleRelationEntity> GetPageList_By_RoleID_SystemRoleEntity(string orderByColumnName, bool isDesc, SystemRoleEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SystemUserGroupRoleRelationEntity> GetList_By_UserGroupID_SystemUserGroupEntity(SystemUserGroupEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_USERGROUPID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemUserGroupRoleRelationEntity> GetPageList_By_UserGroupID_SystemUserGroupEntity(string orderByColumnName, bool isDesc, SystemUserGroupEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_USERGROUPID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
