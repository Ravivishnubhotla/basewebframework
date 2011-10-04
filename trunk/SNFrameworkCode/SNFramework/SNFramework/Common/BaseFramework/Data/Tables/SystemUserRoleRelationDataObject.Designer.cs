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
    public partial class SystemUserRoleRelationDataObject : BaseNHibernateDataObject<SystemUserRoleRelationEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_USERROLEID = new IntProperty(Property.ForName(SystemUserRoleRelationEntity.PROPERTY_NAME_USERROLEID));		
		public static readonly EntityProperty<SystemUserEntity> PROPERTY_USERID = new EntityProperty<SystemUserEntity>(Property.ForName(SystemUserRoleRelationEntity.PROPERTY_NAME_USERID));
		#region userID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> InClude_UserID_Query(NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemUserRoleRelationEntity.PROPERTY_NAME_USERID, PROPERTY_USERID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_USERID_ALIAS_NAME = "UserID_SystemUserRoleRelationEntity_Alias";
		public static readonly IntProperty PROPERTY_USERID_USERID = new IntProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".UserID"));
		public static readonly StringProperty PROPERTY_USERID_USERLOGINID = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".UserLoginID"));
		public static readonly StringProperty PROPERTY_USERID_USERNAME = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".UserName"));
		public static readonly StringProperty PROPERTY_USERID_USEREMAIL = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".UserEmail"));
		public static readonly StringProperty PROPERTY_USERID_USERPASSWORD = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".UserPassword"));
		public static readonly StringProperty PROPERTY_USERID_USERSTATUS = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".UserStatus"));
		public static readonly DateTimeProperty PROPERTY_USERID_USERCREATEDATE = new DateTimeProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".UserCreateDate"));
		public static readonly StringProperty PROPERTY_USERID_USERTYPE = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".UserType"));
		public static readonly EntityProperty<SystemDepartmentEntity> PROPERTY_USERID_DEPARTMENTID = new EntityProperty<SystemDepartmentEntity>(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".DepartmentID"));
		public static readonly StringProperty PROPERTY_USERID_MOBILEPIN = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".MobilePIN"));
		public static readonly IntProperty PROPERTY_USERID_PASSWORDFORMAT = new IntProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".PasswordFormat"));
		public static readonly StringProperty PROPERTY_USERID_PASSWORDQUESTION = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".PasswordQuestion"));
		public static readonly StringProperty PROPERTY_USERID_PASSWORDANSWER = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".PasswordAnswer"));
		public static readonly StringProperty PROPERTY_USERID_COMMENTS = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".Comments"));
		public static readonly BoolProperty PROPERTY_USERID_ISAPPROVED = new BoolProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".IsApproved"));
		public static readonly BoolProperty PROPERTY_USERID_ISLOCKEDOUT = new BoolProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".IsLockedOut"));
		public static readonly DateTimeProperty PROPERTY_USERID_LASTACTIVITYDATE = new DateTimeProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".LastActivityDate"));
		public static readonly DateTimeProperty PROPERTY_USERID_LASTLOGINDATE = new DateTimeProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".LastLoginDate"));
		public static readonly DateTimeProperty PROPERTY_USERID_LASTLOCKEDOUTDATE = new DateTimeProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".LastLockedOutDate"));
		public static readonly DateTimeProperty PROPERTY_USERID_LASTPASSWORDCHANGEDATE = new DateTimeProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".LastPasswordChangeDate"));
		public static readonly IntProperty PROPERTY_USERID_FAILEDPWDATTEMPTCNT = new IntProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".FailedPwdAttemptCnt"));
		public static readonly DateTimeProperty PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART = new DateTimeProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".FailedPwdAttemptWndStart"));
		public static readonly IntProperty PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT = new IntProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".FailedPwdAnsAttemptCnt"));
		public static readonly DateTimeProperty PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART = new DateTimeProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".FailedPwdAnsAttemptWndStart"));
		public static readonly BoolProperty PROPERTY_USERID_ISNEEDCHGPWD = new BoolProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".IsNeedChgPwd"));
		public static readonly StringProperty PROPERTY_USERID_PASSWORDSALT = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".PasswordSalt"));
		public static readonly StringProperty PROPERTY_USERID_LOWEREDEMAIL = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".LoweredEmail"));
		public static readonly IntProperty PROPERTY_USERID_CREATEBY = new IntProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".CreateBy"));
		public static readonly DateTimeProperty PROPERTY_USERID_CREATEAT = new DateTimeProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".CreateAt"));
		public static readonly IntProperty PROPERTY_USERID_LASTMODIFYBY = new IntProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".LastModifyBy"));
		public static readonly DateTimeProperty PROPERTY_USERID_LASTMODIFYAT = new DateTimeProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".LastModifyAt"));
		public static readonly StringProperty PROPERTY_USERID_LASTMODIFYCOMMENT = new StringProperty(Property.ForName(PROPERTY_USERID_ALIAS_NAME + ".LastModifyComment"));
		#endregion
		public static readonly EntityProperty<SystemRoleEntity> PROPERTY_ROLEID = new EntityProperty<SystemRoleEntity>(Property.ForName(SystemUserRoleRelationEntity.PROPERTY_NAME_ROLEID));
		#region roleID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> InClude_RoleID_Query(NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemUserRoleRelationEntity.PROPERTY_NAME_ROLEID, PROPERTY_ROLEID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_ROLEID_ALIAS_NAME = "RoleID_SystemUserRoleRelationEntity_Alias";
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
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "UserRoleID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "UserRoleID":
                    return typeof (int);
                case "UserID":
                    return typeof (int);
                case "RoleID":
                    return typeof (int);
          }
			return typeof(string);
        }
		
        public override void InClude_Parent_Table(string parent_alias, NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> queryGenerator)
        {
            switch (parent_alias)
            {
	            case "UserID_SystemUserRoleRelationEntity_Alias":
                    queryGenerator.AddAlians(SystemUserRoleRelationEntity.PROPERTY_NAME_USERID, PROPERTY_USERID_ALIAS_NAME);
                    break;
	            case "RoleID_SystemUserRoleRelationEntity_Alias":
                    queryGenerator.AddAlians(SystemUserRoleRelationEntity.PROPERTY_NAME_ROLEID, PROPERTY_ROLEID_ALIAS_NAME);
                    break;

 
            }
        }
		
		
		
		public List<SystemUserRoleRelationEntity> GetList_By_UserID_SystemUserEntity(SystemUserEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_USERID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemUserRoleRelationEntity> GetPageList_By_UserID_SystemUserEntity(string orderByColumnName, bool isDesc, SystemUserEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_USERID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SystemUserRoleRelationEntity> GetList_By_RoleID_SystemRoleEntity(SystemRoleEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemUserRoleRelationEntity> GetPageList_By_RoleID_SystemRoleEntity(string orderByColumnName, bool isDesc, SystemRoleEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemUserRoleRelationEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_ROLEID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
