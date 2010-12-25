// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemUserGroupRoleRelationDataObject : BaseNHibernateDataObject<SystemUserGroupRoleRelationEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_USERGROUPROLEID = Property.ForName(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_USERGROUPROLEID);
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_ROLEID);
		#region roleID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> InClude_RoleID_Query(NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_ROLEID, PROPERTY_ROLEID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_ROLEID_ALIAS_NAME = "RoleID_SystemUserGroupRoleRelationEntity_Alias";
		public static readonly Property PROPERTY_ROLEID_ROLEID = Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleID");
		public static readonly Property PROPERTY_ROLEID_ROLENAME = Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleName");
		public static readonly Property PROPERTY_ROLEID_ROLEDESCRIPTION = Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleDescription");
		public static readonly Property PROPERTY_ROLEID_ROLEISSYSTEMROLE = Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleIsSystemRole");
		public static readonly Property PROPERTY_ROLEID_ROLETYPE = Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".RoleType");
		public static readonly Property PROPERTY_ROLEID_CREATEBY = Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".CreateBy");
		public static readonly Property PROPERTY_ROLEID_CREATEDATE = Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".CreateDate");
		public static readonly Property PROPERTY_ROLEID_LASTUPDATEBY = Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".LastUpdateBy");
		public static readonly Property PROPERTY_ROLEID_LASTUPDATEDATE = Property.ForName(PROPERTY_ROLEID_ALIAS_NAME + ".LastUpdateDate");
		#endregion
		public static readonly Property PROPERTY_USERGROUPID = Property.ForName(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_USERGROUPID);
		#region userGroupID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> InClude_UserGroupID_Query(NHibernateDynamicQueryGenerator<SystemUserGroupRoleRelationEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemUserGroupRoleRelationEntity.PROPERTY_NAME_USERGROUPID, PROPERTY_USERGROUPID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_USERGROUPID_ALIAS_NAME = "UserGroupID_SystemUserGroupRoleRelationEntity_Alias";
		public static readonly Property PROPERTY_USERGROUPID_GROUPID = Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".GroupID");
		public static readonly Property PROPERTY_USERGROUPID_GROUPNAMECN = Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".GroupNameCn");
		public static readonly Property PROPERTY_USERGROUPID_GROUPNAMEEN = Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".GroupNameEn");
		public static readonly Property PROPERTY_USERGROUPID_GROUPDESCRIPTION = Property.ForName(PROPERTY_USERGROUPID_ALIAS_NAME + ".GroupDescription");
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
