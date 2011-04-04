// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Text;
using NHibernate.Criterion;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery.Propertys;
using Legendigital.Framework.Common.Data.NHibernate.DynamicQuery;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.BaseFramework.Entity.Tables;
using Legendigital.Framework.Common.Data.NHibernate;


namespace Legendigital.Framework.Common.BaseFramework.Data.Tables
{
    public partial class SystemUserProfileDataObject : BaseNHibernateDataObject<SystemUserProfileEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_PROFILEID = new IntProperty(Property.ForName(SystemUserProfileEntity.PROPERTY_NAME_PROFILEID));		
		public static readonly EntityProperty<SystemUserEntity> PROPERTY_USERID = new EntityProperty<SystemUserEntity>(Property.ForName(SystemUserProfileEntity.PROPERTY_NAME_USERID));
		#region userID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemUserProfileEntity> InClude_UserID_Query(NHibernateDynamicQueryGenerator<SystemUserProfileEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemUserProfileEntity.PROPERTY_NAME_USERID, PROPERTY_USERID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_USERID_ALIAS_NAME = "UserID_SystemUserProfileEntity_Alias";
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
		#endregion
		public static readonly EntityProperty<SystemUserProfilePropertysEntity> PROPERTY_PROPERTYID = new EntityProperty<SystemUserProfilePropertysEntity>(Property.ForName(SystemUserProfileEntity.PROPERTY_NAME_PROPERTYID));
		#region propertyID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemUserProfileEntity> InClude_PropertyID_Query(NHibernateDynamicQueryGenerator<SystemUserProfileEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemUserProfileEntity.PROPERTY_NAME_PROPERTYID, PROPERTY_PROPERTYID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_PROPERTYID_ALIAS_NAME = "PropertyID_SystemUserProfileEntity_Alias";
		public static readonly IntProperty PROPERTY_PROPERTYID_PROPERTYID = new IntProperty(Property.ForName(PROPERTY_PROPERTYID_ALIAS_NAME + ".PropertyID"));
		public static readonly StringProperty PROPERTY_PROPERTYID_PROPERTYNAME = new StringProperty(Property.ForName(PROPERTY_PROPERTYID_ALIAS_NAME + ".PropertyName"));
		public static readonly StringProperty PROPERTY_PROPERTYID_PROPERTYDESCRIPTION = new StringProperty(Property.ForName(PROPERTY_PROPERTYID_ALIAS_NAME + ".PropertyDescription"));
		#endregion
		public static readonly StringProperty PROPERTY_PROPERTYVALUESSTRING = new StringProperty(Property.ForName(SystemUserProfileEntity.PROPERTY_NAME_PROPERTYVALUESSTRING));		
		public static readonly ByteArrayProperty PROPERTY_PROPERTYVALUESBINARY = new ByteArrayProperty(Property.ForName(SystemUserProfileEntity.PROPERTY_NAME_PROPERTYVALUESBINARY));		
		public static readonly DateTimeProperty PROPERTY_LASTUPDATEDDATE = new DateTimeProperty(Property.ForName(SystemUserProfileEntity.PROPERTY_NAME_LASTUPDATEDDATE));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "ProfileID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "ProfileID":
                    return typeof (int);
                case "UserID":
                    return typeof (int);
                case "PropertyID":
                    return typeof (int);
                case "PropertyValuesString":
                    return typeof (string);
                case "PropertyValuesBinary":
                    return typeof (byte[]);
                case "LastUpdatedDate":
                    return typeof (DateTime);
          }
			return typeof(string);
        }
		
		public List<SystemUserProfileEntity> GetList_By_UserID_SystemUserEntity(SystemUserEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemUserProfileEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_USERID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemUserProfileEntity> GetPageList_By_UserID_SystemUserEntity(string orderByColumnName, bool isDesc, SystemUserEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemUserProfileEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_USERID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SystemUserProfileEntity> GetList_By_PropertyID_SystemUserProfilePropertysEntity(SystemUserProfilePropertysEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemUserProfileEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_PROPERTYID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemUserProfileEntity> GetPageList_By_PropertyID_SystemUserProfilePropertysEntity(string orderByColumnName, bool isDesc, SystemUserProfilePropertysEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemUserProfileEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_PROPERTYID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}