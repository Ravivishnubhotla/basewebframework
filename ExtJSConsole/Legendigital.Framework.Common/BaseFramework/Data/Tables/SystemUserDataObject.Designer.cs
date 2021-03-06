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
    public partial class SystemUserDataObject : BaseNHibernateDataObject<SystemUserEntity>
    {
				#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_USERID = Property.ForName(SystemUserEntity.PROPERTY_NAME_USERID);
		public static readonly Property PROPERTY_USERLOGINID = Property.ForName(SystemUserEntity.PROPERTY_NAME_USERLOGINID);
		public static readonly Property PROPERTY_USERNAME = Property.ForName(SystemUserEntity.PROPERTY_NAME_USERNAME);
		public static readonly Property PROPERTY_USEREMAIL = Property.ForName(SystemUserEntity.PROPERTY_NAME_USEREMAIL);
		public static readonly Property PROPERTY_USERPASSWORD = Property.ForName(SystemUserEntity.PROPERTY_NAME_USERPASSWORD);
		public static readonly Property PROPERTY_USERSTATUS = Property.ForName(SystemUserEntity.PROPERTY_NAME_USERSTATUS);
		public static readonly Property PROPERTY_USERCREATEDATE = Property.ForName(SystemUserEntity.PROPERTY_NAME_USERCREATEDATE);
		public static readonly Property PROPERTY_USERTYPE = Property.ForName(SystemUserEntity.PROPERTY_NAME_USERTYPE);
		public static readonly Property PROPERTY_DEPARTMENTID = Property.ForName(SystemUserEntity.PROPERTY_NAME_DEPARTMENTID);
		#region departmentID字段外键查询字段
        public static NHibernateDynamicQueryGenerator<SystemUserEntity> InClude_DepartmentID_Query(NHibernateDynamicQueryGenerator<SystemUserEntity> queryGenerator)
        {
            return queryGenerator.AddAlians(SystemUserEntity.PROPERTY_NAME_DEPARTMENTID, PROPERTY_DEPARTMENTID_ALIAS_NAME);
        }
        public static readonly string PROPERTY_DEPARTMENTID_ALIAS_NAME = "DepartmentID_SystemUserEntity_Alias";
		public static readonly Property PROPERTY_DEPARTMENTID_DEPARTMENTID = Property.ForName(PROPERTY_DEPARTMENTID_ALIAS_NAME + ".DepartmentID");
		public static readonly Property PROPERTY_DEPARTMENTID_PARENTDEPARTMENTID = Property.ForName(PROPERTY_DEPARTMENTID_ALIAS_NAME + ".ParentDepartmentID");
		public static readonly Property PROPERTY_DEPARTMENTID_DEPARTMENTNAMECN = Property.ForName(PROPERTY_DEPARTMENTID_ALIAS_NAME + ".DepartmentNameCn");
		public static readonly Property PROPERTY_DEPARTMENTID_DEPARTMENTNAMEEN = Property.ForName(PROPERTY_DEPARTMENTID_ALIAS_NAME + ".DepartmentNameEn");
		public static readonly Property PROPERTY_DEPARTMENTID_DEPARTMENTDECRIPTION = Property.ForName(PROPERTY_DEPARTMENTID_ALIAS_NAME + ".DepartmentDecription");
		public static readonly Property PROPERTY_DEPARTMENTID_DEPARTMENTSORTINDEX = Property.ForName(PROPERTY_DEPARTMENTID_ALIAS_NAME + ".DepartmentSortIndex");
		#endregion
		public static readonly Property PROPERTY_MOBILEPIN = Property.ForName(SystemUserEntity.PROPERTY_NAME_MOBILEPIN);
		public static readonly Property PROPERTY_PASSWORDFORMAT = Property.ForName(SystemUserEntity.PROPERTY_NAME_PASSWORDFORMAT);
		public static readonly Property PROPERTY_PASSWORDSALT = Property.ForName(SystemUserEntity.PROPERTY_NAME_PASSWORDSALT);
		public static readonly Property PROPERTY_LOWEREDEMAIL = Property.ForName(SystemUserEntity.PROPERTY_NAME_LOWEREDEMAIL);
		public static readonly Property PROPERTY_PASSWORDQUESTION = Property.ForName(SystemUserEntity.PROPERTY_NAME_PASSWORDQUESTION);
		public static readonly Property PROPERTY_PASSWORDANSWER = Property.ForName(SystemUserEntity.PROPERTY_NAME_PASSWORDANSWER);
		public static readonly Property PROPERTY_COMMENTS = Property.ForName(SystemUserEntity.PROPERTY_NAME_COMMENTS);
		public static readonly Property PROPERTY_ISAPPROVED = Property.ForName(SystemUserEntity.PROPERTY_NAME_ISAPPROVED);
		public static readonly Property PROPERTY_ISLOCKEDOUT = Property.ForName(SystemUserEntity.PROPERTY_NAME_ISLOCKEDOUT);
		public static readonly Property PROPERTY_LASTACTIVITYDATE = Property.ForName(SystemUserEntity.PROPERTY_NAME_LASTACTIVITYDATE);
		public static readonly Property PROPERTY_LASTLOGINDATE = Property.ForName(SystemUserEntity.PROPERTY_NAME_LASTLOGINDATE);
		public static readonly Property PROPERTY_LASTLOCKEDOUTDATE = Property.ForName(SystemUserEntity.PROPERTY_NAME_LASTLOCKEDOUTDATE);
		public static readonly Property PROPERTY_LASTPASSWORDCHANGEDATE = Property.ForName(SystemUserEntity.PROPERTY_NAME_LASTPASSWORDCHANGEDATE);
		public static readonly Property PROPERTY_FAILEDPWDATTEMPTCNT = Property.ForName(SystemUserEntity.PROPERTY_NAME_FAILEDPWDATTEMPTCNT);
		public static readonly Property PROPERTY_FAILEDPWDATTEMPTWNDSTART = Property.ForName(SystemUserEntity.PROPERTY_NAME_FAILEDPWDATTEMPTWNDSTART);
		public static readonly Property PROPERTY_FAILEDPWDANSATTEMPTCNT = Property.ForName(SystemUserEntity.PROPERTY_NAME_FAILEDPWDANSATTEMPTCNT);
		public static readonly Property PROPERTY_FAILEDPWDANSATTEMPTWNDSTART = Property.ForName(SystemUserEntity.PROPERTY_NAME_FAILEDPWDANSATTEMPTWNDSTART);
      
		#region 子类集合字段查询字段
	
		#endregion

		#endregion

		
		public override string[] PkPropertyName
        {
            get { return new string[] { "UserID" }; }
        }
		
		public override Type GetFieldTypeByFieldName(string fieldName)
        {
			switch (fieldName)
            {
                case "UserID":
                    return typeof (int);
                case "UserLoginID":
                    return typeof (string);
                case "UserName":
                    return typeof (string);
                case "UserEmail":
                    return typeof (string);
                case "UserPassword":
                    return typeof (string);
                case "UserStatus":
                    return typeof (string);
                case "UserCreateDate":
                    return typeof (DateTime);
                case "UserType":
                    return typeof (string);
                case "DepartmentID":
                    return typeof (int);
                case "MobilePIN":
                    return typeof (string);
                case "PasswordFormat":
                    return typeof (int);
                case "PasswordSalt":
                    return typeof (string);
                case "LoweredEmail":
                    return typeof (string);
                case "PasswordQuestion":
                    return typeof (string);
                case "PasswordAnswer":
                    return typeof (string);
                case "Comments":
                    return typeof (string);
                case "IsApproved":
                    return typeof (bool);
                case "IsLockedOut":
                    return typeof (bool);
                case "LastActivityDate":
                    return typeof (DateTime);
                case "LastLoginDate":
                    return typeof (DateTime);
                case "LastLockedOutDate":
                    return typeof (DateTime);
                case "LastPasswordChangeDate":
                    return typeof (DateTime);
                case "FailedPwdAttemptCnt":
                    return typeof (int);
                case "FailedPwdAttemptWndStart":
                    return typeof (DateTime);
                case "FailedPwdAnsAttemptCnt":
                    return typeof (int);
                case "FailedPwdAnsAttemptWndStart":
                    return typeof (DateTime);
          }
			return typeof(string);
        }
    }
}
