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
    public partial class SystemPersonalizationSettingsDataObject : BaseNHibernateDataObject<SystemPersonalizationSettingsEntity>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly IntProperty PROPERTY_PERSONALIZATIONID = new IntProperty(Property.ForName(SystemPersonalizationSettingsEntity.PROPERTY_NAME_PERSONALIZATIONID));		
		public static readonly EntityProperty<SystemApplicationEntity> PROPERTY_APPLICATIONID = new EntityProperty<SystemApplicationEntity>(Property.ForName(SystemPersonalizationSettingsEntity.PROPERTY_NAME_APPLICATIONID));
		#region applicationID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemPersonalizationSettingsEntity> InClude_ApplicationID_Query(NHibernateDynamicQueryGenerator<SystemPersonalizationSettingsEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemPersonalizationSettingsEntity.PROPERTY_NAME_APPLICATIONID, PROPERTY_APPLICATIONID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_APPLICATIONID_ALIAS_NAME = "ApplicationID_SystemPersonalizationSettingsEntity_Alias";
		public static readonly IntProperty PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = new IntProperty(Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationID"));
		public static readonly StringProperty PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = new StringProperty(Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationName"));
		public static readonly StringProperty PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE = new StringProperty(Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationCode"));
		public static readonly StringProperty PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = new StringProperty(Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationDescription"));
		public static readonly StringProperty PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = new StringProperty(Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationUrl"));
		public static readonly BoolProperty PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = new BoolProperty(Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".SystemApplicationIsSystemApplication"));
		public static readonly IntProperty PROPERTY_APPLICATIONID_ORDERINDEX = new IntProperty(Property.ForName(PROPERTY_APPLICATIONID_ALIAS_NAME + ".OrderIndex"));
		#endregion
		public static readonly EntityProperty<SystemUserEntity> PROPERTY_USERID = new EntityProperty<SystemUserEntity>(Property.ForName(SystemPersonalizationSettingsEntity.PROPERTY_NAME_USERID));
		#region userId字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemPersonalizationSettingsEntity> InClude_UserId_Query(NHibernateDynamicQueryGenerator<SystemPersonalizationSettingsEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemPersonalizationSettingsEntity.PROPERTY_NAME_USERID, PROPERTY_USERID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_USERID_ALIAS_NAME = "UserId_SystemPersonalizationSettingsEntity_Alias";
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
		public static readonly StringProperty PROPERTY_PATH = new StringProperty(Property.ForName(SystemPersonalizationSettingsEntity.PROPERTY_NAME_PATH));		
		public static readonly ByteArrayProperty PROPERTY_PAGESETTINGS = new ByteArrayProperty(Property.ForName(SystemPersonalizationSettingsEntity.PROPERTY_NAME_PAGESETTINGS));		
		public static readonly DateTimeProperty PROPERTY_LASTUPDATEDDATE = new DateTimeProperty(Property.ForName(SystemPersonalizationSettingsEntity.PROPERTY_NAME_LASTUPDATEDDATE));		
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "PersonalizationID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "PersonalizationID":
                    return typeof (int);
                case "ApplicationID":
                    return typeof (int);
                case "UserId":
                    return typeof (int);
                case "Path":
                    return typeof (string);
                case "PageSettings":
                    return typeof (byte[]);
                case "LastUpdatedDate":
                    return typeof (DateTime);
          }
			return typeof(string);
        }
		
		public List<SystemPersonalizationSettingsEntity> GetList_By_ApplicationID_SystemApplicationEntity(SystemApplicationEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemPersonalizationSettingsEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_APPLICATIONID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemPersonalizationSettingsEntity> GetPageList_By_ApplicationID_SystemApplicationEntity(string orderByColumnName, bool isDesc, SystemApplicationEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemPersonalizationSettingsEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_APPLICATIONID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		
		public List<SystemPersonalizationSettingsEntity> GetList_By_UserId_SystemUserEntity(SystemUserEntity fkentity)
		{
			NHibernateDynamicQueryGenerator<SystemPersonalizationSettingsEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_USERID.Eq(fkentity));

            return this.FindListByQueryBuilder(dynamicQueryGenerator);
		}
		
		
        public List<SystemPersonalizationSettingsEntity> GetPageList_By_UserId_SystemUserEntity(string orderByColumnName, bool isDesc, SystemUserEntity fkentity, PageQueryParams pageQueryParams)
        {
            NHibernateDynamicQueryGenerator<SystemPersonalizationSettingsEntity> dynamicQueryGenerator = this.GetNewQueryBuilder();

            dynamicQueryGenerator.AddWhereClause(PROPERTY_USERID.Eq(fkentity));

            AddDefaultOrderByToQueryGenerator(orderByColumnName, isDesc, dynamicQueryGenerator);

            return FindListByPageByQueryBuilder(dynamicQueryGenerator, pageQueryParams);
        }		
		

		
		
    }
}
