/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统设置
	/// </summary>
	[Serializable]
	public abstract class SystemSettingBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemSetting";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_SYSTEMNAME = "SystemName";
		public static readonly string PROPERTY_NAME_SYSTEMDESCRIPTION = "SystemDescription";
		public static readonly string PROPERTY_NAME_SYSTEMURL = "SystemUrl";
		public static readonly string PROPERTY_NAME_SYSTEMVERSION = "SystemVersion";
		public static readonly string PROPERTY_NAME_SYSTEMLISENCE = "SystemLisence";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _id;
		private string _systemname;
		private string _systemdescription;
		private string _systemurl;
		private string _systemversion;
		private string _systemlisence;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemSettingBase()
		{
			_id = 0; 
			_systemname = String.Empty; 
			_systemdescription = String.Empty; 
			_systemurl = String.Empty; 
			_systemversion = String.Empty; 
			_systemlisence = String.Empty; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int Id
		{
			get { return _id; }
			set { _isChanged |= (_id != value); _id = value; }
		}
		/// <summary>
		/// 系统名称
		/// </summary>		
		public virtual string SystemName
		{
			get { return _systemname; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemName", value, value.ToString());
				
				_isChanged |= (_systemname != value); _systemname = value;
			}
		}
		/// <summary>
		/// 系统描述
		/// </summary>		
		public virtual string SystemDescription
		{
			get { return _systemdescription; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for SystemDescription", value, value.ToString());
				
				_isChanged |= (_systemdescription != value); _systemdescription = value;
			}
		}
		/// <summary>
		/// 系统URL
		/// </summary>		
		public virtual string SystemUrl
		{
			get { return _systemurl; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemUrl", value, value.ToString());
				
				_isChanged |= (_systemurl != value); _systemurl = value;
			}
		}
		/// <summary>
		/// 系统版本
		/// </summary>		
		public virtual string SystemVersion
		{
			get { return _systemversion; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemVersion", value, value.ToString());
				
				_isChanged |= (_systemversion != value); _systemversion = value;
			}
		}
		/// <summary>
		/// 系统版权声明
		/// </summary>		
		public virtual string SystemLisence
		{
			get { return _systemlisence; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for SystemLisence", value, value.ToString());
				
				_isChanged |= (_systemlisence != value); _systemlisence = value;
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
			SystemSettingBase castObj = (SystemSettingBase)obj; 
			return ( castObj != null ) &&
				( this._id == castObj.Id );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemSettingBase obj )
		{
			obj.SystemName = this._systemname;
			obj.SystemDescription = this._systemdescription;
			obj.SystemUrl = this._systemurl;
			obj.SystemVersion = this._systemversion;
			obj.SystemLisence = this._systemlisence;
		}
        #endregion
	}
}
