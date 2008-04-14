/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	用户用户组对应关系
	/// </summary>
	[Serializable]
	public abstract class SystemUserGroupUserRelationBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemUserGroupUserRelation";
		public static readonly string PROPERTY_NAME_USERGROUPUSERID = "UserGroupUserID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_USERGROUPID = "UserGroupID";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _usergroupuserid;
		private SystemUser _userid;
		private SystemUserGroup _usergroupid;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserGroupUserRelationBase()
		{
			_usergroupuserid = 0; 
			_userid =  null; 
			_usergroupid =  null; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int UserGroupUserID
		{
			get { return _usergroupuserid; }
			set { _isChanged |= (_usergroupuserid != value); _usergroupuserid = value; }
		}
		/// <summary>
		/// 用户
		/// </summary>		
		public virtual SystemUser UserID
		{
			get { return _userid; }
			set { _isChanged |= (_userid != value); _userid = value; }
		}
		/// <summary>
		/// 用户组
		/// </summary>		
		public virtual SystemUserGroup UserGroupID
		{
			get { return _usergroupid; }
			set { _isChanged |= (_usergroupid != value); _usergroupid = value; }
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
			SystemUserGroupUserRelationBase castObj = (SystemUserGroupUserRelationBase)obj; 
			return ( castObj != null ) &&
				( this._usergroupuserid == castObj.UserGroupUserID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _usergroupuserid.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemUserGroupUserRelationBase obj )
		{
			obj.UserID = this._userid;
			obj.UserGroupID = this._usergroupid;
		}
        #endregion
	}
}
