/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统应用
	/// </summary>
	[Serializable]
	public abstract class SystemApplicationBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemApplication";
		public static readonly string PROPERTY_NAME_SYSTEMAPPLICATIONID = "SystemApplicationID";
		public static readonly string PROPERTY_NAME_SYSTEMAPPLICATIONNAME = "SystemApplicationName";
		public static readonly string PROPERTY_NAME_SYSTEMAPPLICATIONDESCRIPTION = "SystemApplicationDescription";
		public static readonly string PROPERTY_NAME_SYSTEMAPPLICATIONURL = "SystemApplicationUrl";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _systemapplication_id;
		private string _systemapplication_name;
		private string _systemapplication_description;
		private string _systemapplication_url;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemApplicationBase()
		{
			_systemapplication_id = 0; 
			_systemapplication_name = String.Empty; 
			_systemapplication_description = String.Empty; 
			_systemapplication_url = String.Empty; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int SystemApplicationID
		{
			get { return _systemapplication_id; }
			set { _isChanged |= (_systemapplication_id != value); _systemapplication_id = value; }
		}
		/// <summary>
		/// 应用程序名称
		/// </summary>		
		public virtual string SystemApplicationName
		{
			get { return _systemapplication_name; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemApplicationName", value, value.ToString());
				
				_isChanged |= (_systemapplication_name != value); _systemapplication_name = value;
			}
		}
		/// <summary>
		/// 应用程序描述
		/// </summary>		
		public virtual string SystemApplicationDescription
		{
			get { return _systemapplication_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for SystemApplicationDescription", value, value.ToString());
				
				_isChanged |= (_systemapplication_description != value); _systemapplication_description = value;
			}
		}
		/// <summary>
		/// 应用程序链接
		/// </summary>		
		public virtual string SystemApplicationUrl
		{
			get { return _systemapplication_url; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemApplicationUrl", value, value.ToString());
				
				_isChanged |= (_systemapplication_url != value); _systemapplication_url = value;
			}
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
			SystemApplicationBase castObj = (SystemApplicationBase)obj; 
			return ( castObj != null ) &&
				( this._systemapplication_id == castObj.SystemApplicationID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _systemapplication_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemApplicationBase obj )
		{
			obj.SystemApplicationName = this._systemapplication_name;
			obj.SystemApplicationDescription = this._systemapplication_description;
			obj.SystemApplicationUrl = this._systemapplication_url;
		}
        #endregion
	}
}
