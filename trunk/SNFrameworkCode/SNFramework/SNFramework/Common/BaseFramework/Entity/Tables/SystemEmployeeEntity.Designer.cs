// --------------------------------------------------------------------------------------------------------------------
// <copyright company="foreveross" file="SystemEmployeeEntity.Designer.cs">
//   Copyright (c) Foreveross Enterprises. All rights reserved.
// </copyright>
// <summary>
//   Generated by MyGeneration Version # (1.3.0.9)
// </summary>
// --------------------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SystemEmployeeEntity  : BaseTableEntity<int>,ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemEmployeeEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_ORGANIZATIONID = "OrganizationID";
		public static readonly string PROPERTY_NAME_NUMBER = "Number";
		public static readonly string PROPERTY_NAME_FRISTNAME = "FristName";
		public static readonly string PROPERTY_NAME_MIDDLENAME = "MiddleName";
		public static readonly string PROPERTY_NAME_LASTNAME = "LastName";
		public static readonly string PROPERTY_NAME_FULLNAME = "FullName";
		public static readonly string PROPERTY_NAME_OFFICE1PHONENUMBER = "Office1PhoneNumber";
		public static readonly string PROPERTY_NAME_OFFICE2PHONENUMBER = "Office2PhoneNumber";
		public static readonly string PROPERTY_NAME_HOME1PHONENUMBER = "Home1PhoneNumber";
		public static readonly string PROPERTY_NAME_HOME2PHONENUMBER = "Home2PhoneNumber";
		public static readonly string PROPERTY_NAME_MOBILE1PHONENUMBER = "Mobile1PhoneNumber";
		public static readonly string PROPERTY_NAME_MOBILE2PHONENUMBER = "Mobile2PhoneNumber";
		public static readonly string PROPERTY_NAME_SEX = "Sex";
		public static readonly string PROPERTY_NAME_AGE = "Age";
		public static readonly string PROPERTY_NAME_BIRTHDAY = "Birthday";
		public static readonly string PROPERTY_NAME_HOMEPAGE = "HomePage";
		public static readonly string PROPERTY_NAME_COMMENTS = "Comments";
		public static readonly string PROPERTY_NAME_DEFAULTDEPARTMENTID = "DefaultDepartmentID";
		public static readonly string PROPERTY_NAME_DEFAULTPOSTID = "DefaultPostID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_EMAIL2 = "Email2";
		public static readonly string PROPERTY_NAME_EMAIL1 = "Email1";
		public static readonly string PROPERTY_NAME_ISACTIVE = "IsActive";
		public static readonly string PROPERTY_NAME_STATUS = "Status";
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region organizationID字段外键查询字段
        public const string PROPERTY_ORGANIZATIONID_ALIAS_NAME = "OrganizationID_SystemEmployeeEntity_Alias";
		public const string PROPERTY_ORGANIZATIONID_ID = "OrganizationID_SystemEmployeeEntity_Alias.Id";
		public const string PROPERTY_ORGANIZATIONID_NAME = "OrganizationID_SystemEmployeeEntity_Alias.Name";
		public const string PROPERTY_ORGANIZATIONID_SHORTNAME = "OrganizationID_SystemEmployeeEntity_Alias.ShortName";
		public const string PROPERTY_ORGANIZATIONID_CODE = "OrganizationID_SystemEmployeeEntity_Alias.Code";
		public const string PROPERTY_ORGANIZATIONID_DESCRIPTION = "OrganizationID_SystemEmployeeEntity_Alias.Description";
		public const string PROPERTY_ORGANIZATIONID_LOGOURL = "OrganizationID_SystemEmployeeEntity_Alias.LogoUrl";
		public const string PROPERTY_ORGANIZATIONID_TYPE = "OrganizationID_SystemEmployeeEntity_Alias.Type";
		public const string PROPERTY_ORGANIZATIONID_MASTERNAME = "OrganizationID_SystemEmployeeEntity_Alias.MasterName";
		public const string PROPERTY_ORGANIZATIONID_ISMAINORGANIZATION = "OrganizationID_SystemEmployeeEntity_Alias.IsMainOrganization";
		public const string PROPERTY_ORGANIZATIONID_PARENTID = "OrganizationID_SystemEmployeeEntity_Alias.ParentID";
		public const string PROPERTY_ORGANIZATIONID_ADDRESSID = "OrganizationID_SystemEmployeeEntity_Alias.AddressID";
		public const string PROPERTY_ORGANIZATIONID_TELPHONE = "OrganizationID_SystemEmployeeEntity_Alias.TelPhone";
		public const string PROPERTY_ORGANIZATIONID_FAXNUMBER = "OrganizationID_SystemEmployeeEntity_Alias.FaxNumber";
		public const string PROPERTY_ORGANIZATIONID_WEBSITE = "OrganizationID_SystemEmployeeEntity_Alias.WebSite";
		public const string PROPERTY_ORGANIZATIONID_EMAIL = "OrganizationID_SystemEmployeeEntity_Alias.Email";
		public const string PROPERTY_ORGANIZATIONID_CREATEBY = "OrganizationID_SystemEmployeeEntity_Alias.CreateBy";
		public const string PROPERTY_ORGANIZATIONID_CREATEAT = "OrganizationID_SystemEmployeeEntity_Alias.CreateAt";
		public const string PROPERTY_ORGANIZATIONID_LASTMODIFYBY = "OrganizationID_SystemEmployeeEntity_Alias.LastModifyBy";
		public const string PROPERTY_ORGANIZATIONID_LASTMODIFYAT = "OrganizationID_SystemEmployeeEntity_Alias.LastModifyAt";
		public const string PROPERTY_ORGANIZATIONID_LASTMODIFYCOMMENT = "OrganizationID_SystemEmployeeEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _id;
		private SystemOrganizationEntity _organizationID;
		private string _number;
		private string _fristName;
		private string _middleName;
		private string _lastName;
		private string _fullName;
		private string _office1PhoneNumber;
		private string _office2PhoneNumber;
		private string _home1PhoneNumber;
		private string _home2PhoneNumber;
		private string _mobile1PhoneNumber;
		private string _mobile2PhoneNumber;
		private int? _sex;
		private int? _age;
		private DateTime? _birthday;
		private string _homePage;
		private string _comments;
		private int? _defaultDepartmentID;
		private int? _defaultPostID;
		private int? _userID;
		private string _email2;
		private string _email1;
		private bool? _isActive;
		private string _status;
		private int? _createBy;
		private DateTime? _createAt;
		private int? _lastModifyBy;
		private DateTime? _lastModifyAt;
		private string _lastModifyComment;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemEmployeeEntity()
		{
			_id = 0;
			_organizationID = null;
			_number = null;
			_fristName = null;
			_middleName = null;
			_lastName = null;
			_fullName = null;
			_office1PhoneNumber = null;
			_office2PhoneNumber = null;
			_home1PhoneNumber = null;
			_home2PhoneNumber = null;
			_mobile1PhoneNumber = null;
			_mobile2PhoneNumber = null;
			_sex = null;
			_age = null;
			_birthday = null;
			_homePage = null;
			_comments = null;
			_defaultDepartmentID = null;
			_defaultPostID = null;
			_userID = null;
			_email2 = null;
			_email1 = null;
			_isActive = null;
			_status = null;
			_createBy = null;
			_createAt = null;
			_lastModifyBy = null;
			_lastModifyAt = null;
			_lastModifyComment = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemEmployeeEntity( int id, SystemOrganizationEntity organizationID, string number, string fristName, string middleName, string lastName, string fullName, string office1PhoneNumber, string office2PhoneNumber, string home1PhoneNumber, string home2PhoneNumber, string mobile1PhoneNumber, string mobile2PhoneNumber, int? sex, int? age, DateTime? birthday, string homePage, string comments, int? defaultDepartmentID, int? defaultPostID, int? userID, string email2, string email1, bool? isActive, string status, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_id = id;
			_organizationID = organizationID;
			_number = number;
			_fristName = fristName;
			_middleName = middleName;
			_lastName = lastName;
			_fullName = fullName;
			_office1PhoneNumber = office1PhoneNumber;
			_office2PhoneNumber = office2PhoneNumber;
			_home1PhoneNumber = home1PhoneNumber;
			_home2PhoneNumber = home2PhoneNumber;
			_mobile1PhoneNumber = mobile1PhoneNumber;
			_mobile2PhoneNumber = mobile2PhoneNumber;
			_sex = sex;
			_age = age;
			_birthday = birthday;
			_homePage = homePage;
			_comments = comments;
			_defaultDepartmentID = defaultDepartmentID;
			_defaultPostID = defaultPostID;
			_userID = userID;
			_email2 = email2;
			_email1 = email1;
			_isActive = isActive;
			_status = status;
			_createBy = createBy;
			_createAt = createAt;
			_lastModifyBy = lastModifyBy;
			_lastModifyAt = lastModifyAt;
			_lastModifyComment = lastModifyComment;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int Id
		{
			get { return _id; }

			set	
			{
				_isChanged |= (_id != value); _id = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SystemOrganizationEntity OrganizationID
		{
			get { return _organizationID; }

			set	
			{
				_isChanged |= (_organizationID != value); _organizationID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Number
		{
			get { return _number; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Number", value, value.ToString());
				_isChanged |= (_number != value); _number = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string FristName
		{
			get { return _fristName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FristName", value, value.ToString());
				_isChanged |= (_fristName != value); _fristName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string MiddleName
		{
			get { return _middleName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for MiddleName", value, value.ToString());
				_isChanged |= (_middleName != value); _middleName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LastName
		{
			get { return _lastName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for LastName", value, value.ToString());
				_isChanged |= (_lastName != value); _lastName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string FullName
		{
			get { return _fullName; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for FullName", value, value.ToString());
				_isChanged |= (_fullName != value); _fullName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Office1PhoneNumber
		{
			get { return _office1PhoneNumber; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Office1PhoneNumber", value, value.ToString());
				_isChanged |= (_office1PhoneNumber != value); _office1PhoneNumber = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Office2PhoneNumber
		{
			get { return _office2PhoneNumber; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Office2PhoneNumber", value, value.ToString());
				_isChanged |= (_office2PhoneNumber != value); _office2PhoneNumber = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Home1PhoneNumber
		{
			get { return _home1PhoneNumber; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Home1PhoneNumber", value, value.ToString());
				_isChanged |= (_home1PhoneNumber != value); _home1PhoneNumber = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Home2PhoneNumber
		{
			get { return _home2PhoneNumber; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Home2PhoneNumber", value, value.ToString());
				_isChanged |= (_home2PhoneNumber != value); _home2PhoneNumber = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Mobile1PhoneNumber
		{
			get { return _mobile1PhoneNumber; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Mobile1PhoneNumber", value, value.ToString());
				_isChanged |= (_mobile1PhoneNumber != value); _mobile1PhoneNumber = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Mobile2PhoneNumber
		{
			get { return _mobile2PhoneNumber; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Mobile2PhoneNumber", value, value.ToString());
				_isChanged |= (_mobile2PhoneNumber != value); _mobile2PhoneNumber = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? Sex
		{
			get { return _sex; }

			set	
			{
				_isChanged |= (_sex != value); _sex = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? Age
		{
			get { return _age; }

			set	
			{
				_isChanged |= (_age != value); _age = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? Birthday
		{
			get { return _birthday; }

			set	
			{
				_isChanged |= (_birthday != value); _birthday = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string HomePage
		{
			get { return _homePage; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for HomePage", value, value.ToString());
				_isChanged |= (_homePage != value); _homePage = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Comments
		{
			get { return _comments; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for Comments", value, value.ToString());
				_isChanged |= (_comments != value); _comments = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? DefaultDepartmentID
		{
			get { return _defaultDepartmentID; }

			set	
			{
				_isChanged |= (_defaultDepartmentID != value); _defaultDepartmentID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? DefaultPostID
		{
			get { return _defaultPostID; }

			set	
			{
				_isChanged |= (_defaultPostID != value); _defaultPostID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? UserID
		{
			get { return _userID; }

			set	
			{
				_isChanged |= (_userID != value); _userID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Email2
		{
			get { return _email2; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Email2", value, value.ToString());
				_isChanged |= (_email2 != value); _email2 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Email1
		{
			get { return _email1; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Email1", value, value.ToString());
				_isChanged |= (_email1 != value); _email1 = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual bool? IsActive
		{
			get { return _isActive; }

			set	
			{
				_isChanged |= (_isActive != value); _isActive = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Status
		{
			get { return _status; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for Status", value, value.ToString());
				_isChanged |= (_status != value); _status = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? CreateBy
		{
			get { return _createBy; }

			set	
			{
				_isChanged |= (_createBy != value); _createBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? CreateAt
		{
			get { return _createAt; }

			set	
			{
				_isChanged |= (_createAt != value); _createAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? LastModifyBy
		{
			get { return _lastModifyBy; }

			set	
			{
				_isChanged |= (_lastModifyBy != value); _lastModifyBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? LastModifyAt
		{
			get { return _lastModifyAt; }

			set	
			{
				_isChanged |= (_lastModifyAt != value); _lastModifyAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LastModifyComment
		{
			get { return _lastModifyComment; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for LastModifyComment", value, value.ToString());
				_isChanged |= (_lastModifyComment != value); _lastModifyComment = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SystemEmployeeEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override int GetDataEntityKey()
	    {
	        return this._id;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
