/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统用户
	/// </summary>
	[Serializable]
	public abstract class SystemUserBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemUser";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_USERLOGINID = "UserLoginID";
		public static readonly string PROPERTY_NAME_USERNAME = "UserName";
		public static readonly string PROPERTY_NAME_USEREMAIL = "UserEmail";
		public static readonly string PROPERTY_NAME_USERPASSWORD = "UserPassword";
		public static readonly string PROPERTY_NAME_USERSTATUS = "UserStatus";
		public static readonly string PROPERTY_NAME_USERCREATEDATE = "UserCreateDate";
		public static readonly string PROPERTY_NAME_USERTYPE = "UserType";
		public static readonly string PROPERTY_NAME_DEPARTMENTID = "DepartmentID";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _user_id;
		private string _user_loginid;
		private string _user_name;
		private string _user_email;
		private string _user_password;
		private string _user_status;
		private DateTime? _user_create_date;
		private string _user_type;
		private SystemDepartment _department_id;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserBase()
		{
			_user_id = 0; 
			_user_loginid = String.Empty; 
			_user_name = String.Empty; 
			_user_email = String.Empty; 
			_user_password = String.Empty; 
			_user_status = String.Empty; 
			_user_create_date =  null;  
			_user_type = String.Empty; 
			_department_id =  null; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int UserID
		{
			get { return _user_id; }
			set { _isChanged |= (_user_id != value); _user_id = value; }
		}
		/// <summary>
		/// 用户登陆名
		/// </summary>		
		public virtual string UserLoginID
		{
			get { return _user_loginid; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserLoginID", value, value.ToString());
				
				_isChanged |= (_user_loginid != value); _user_loginid = value;
			}
		}
		/// <summary>
		/// 用户名称
		/// </summary>		
		public virtual string UserName
		{
			get { return _user_name; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserName", value, value.ToString());
				
				_isChanged |= (_user_name != value); _user_name = value;
			}
		}
		/// <summary>
		/// 用户邮件
		/// </summary>		
		public virtual string UserEmail
		{
			get { return _user_email; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserEmail", value, value.ToString());
				
				_isChanged |= (_user_email != value); _user_email = value;
			}
		}
		/// <summary>
		/// 用户密码
		/// </summary>		
		public virtual string UserPassword
		{
			get { return _user_password; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserPassword", value, value.ToString());
				
				_isChanged |= (_user_password != value); _user_password = value;
			}
		}
		/// <summary>
		/// 用户状态
		/// </summary>		
		public virtual string UserStatus
		{
			get { return _user_status; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserStatus", value, value.ToString());
				
				_isChanged |= (_user_status != value); _user_status = value;
			}
		}
		/// <summary>
		/// 用户创建时间
		/// </summary>		
		public virtual DateTime? UserCreateDate
		{
			get { return _user_create_date; }
			set { _isChanged |= (_user_create_date != value); _user_create_date = value; }
		}
		/// <summary>
		/// 用户类型
		/// </summary>		
		public virtual string UserType
		{
			get { return _user_type; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserType", value, value.ToString());
				
				_isChanged |= (_user_type != value); _user_type = value;
			}
		}
		/// <summary>
		/// 用户部门
		/// </summary>		
		public virtual SystemDepartment DepartmentID
		{
			get { return _department_id; }
			set { _isChanged |= (_department_id != value); _department_id = value; }
		}
		/// <summary>
		/// 返回对象是否被改变。
		/// </summary>
		public virtual bool IsChanged
		{
			get { return _isChanged; }
		}
		
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public virtual bool IsDeleted
		{
			get { return _isDeleted; }
		}
		
		#endregion 
		
		#region 公共方法
		
		/// <summary>
		/// mark the item as deleted
		/// </summary>
		public virtual void MarkAsDeleted()
		{
			_isDeleted = true;
			_isChanged = true;
		}
		
		
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			SystemUserBase castObj = (SystemUserBase)obj; 
			return ( castObj != null ) &&
				( this._user_id == castObj.UserID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _user_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemUserBase obj )
		{
			obj.UserLoginID = this._user_loginid;
			obj.UserName = this._user_name;
			obj.UserEmail = this._user_email;
			obj.UserPassword = this._user_password;
			obj.UserStatus = this._user_status;
			obj.UserCreateDate = this._user_create_date;
			obj.UserType = this._user_type;
			obj.DepartmentID = this._department_id;
		}
        #endregion
	}
}
