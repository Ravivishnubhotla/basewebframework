/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	用户组
	/// </summary>
	[Serializable]
	public abstract class SystemUserGroupBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemUserGroup";
		public static readonly string PROPERTY_NAME_GROUPID = "GroupID";
		public static readonly string PROPERTY_NAME_GROUPNAMECN = "GroupNameCn";
		public static readonly string PROPERTY_NAME_GROUPNAMEEN = "GroupNameEn";
		public static readonly string PROPERTY_NAME_GROUPDESCRIPTION = "GroupDescription";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _group_id;
		private string _group_namecn;
		private string _group_nameen;
		private string _group_description;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserGroupBase()
		{
			_group_id = 0; 
			_group_namecn = String.Empty; 
			_group_nameen = String.Empty; 
			_group_description = String.Empty; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int GroupID
		{
			get { return _group_id; }
			set { _isChanged |= (_group_id != value); _group_id = value; }
		}
		/// <summary>
		/// 用户组中文名
		/// </summary>		
		public virtual string GroupNameCn
		{
			get { return _group_namecn; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for GroupNameCn", value, value.ToString());
				
				_isChanged |= (_group_namecn != value); _group_namecn = value;
			}
		}
		/// <summary>
		/// 用户组英文名
		/// </summary>		
		public virtual string GroupNameEn
		{
			get { return _group_nameen; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for GroupNameEn", value, value.ToString());
				
				_isChanged |= (_group_nameen != value); _group_nameen = value;
			}
		}
		/// <summary>
		/// 用户组描述
		/// </summary>		
		public virtual string GroupDescription
		{
			get { return _group_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for GroupDescription", value, value.ToString());
				
				_isChanged |= (_group_description != value); _group_description = value;
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
			SystemUserGroupBase castObj = (SystemUserGroupBase)obj; 
			return ( castObj != null ) &&
				( this._group_id == castObj.GroupID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _group_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemUserGroupBase obj )
		{
			obj.GroupNameCn = this._group_namecn;
			obj.GroupNameEn = this._group_nameen;
			obj.GroupDescription = this._group_description;
		}
        #endregion
	}
}
