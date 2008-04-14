/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统数据模块
	/// </summary>
	[Serializable]
	public abstract class SystemMoudleBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemMoudle";
		public static readonly string PROPERTY_NAME_MOUDLEID = "MoudleID";
		public static readonly string PROPERTY_NAME_MOUDLENAMECN = "MoudleNameCn";
		public static readonly string PROPERTY_NAME_MOUDLENAMEEN = "MoudleNameEn";
		public static readonly string PROPERTY_NAME_MOUDLENAMEDB = "MoudleNameDb";
		public static readonly string PROPERTY_NAME_MOUDLEDESCRIPTION = "MoudleDescription";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		public static readonly string PROPERTY_NAME_MOUDLEISSYSTEMMOUDLE = "MoudleIsSystemMoudle";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _moudle_id;
		private string _moudle_namecn;
		private string _moudle_nameen;
		private string _moudle_namedb;
		private string _moudle_description;
		private SystemApplication _application_id;
		private bool _moudle_issystemmoudle;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemMoudleBase()
		{
			_moudle_id = 0; 
			_moudle_namecn = String.Empty; 
			_moudle_nameen = String.Empty; 
			_moudle_namedb = String.Empty; 
			_moudle_description = String.Empty; 
			_application_id =  null; 
			_moudle_issystemmoudle = false; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int MoudleID
		{
			get { return _moudle_id; }
			set { _isChanged |= (_moudle_id != value); _moudle_id = value; }
		}
		/// <summary>
		/// 模块中文名
		/// </summary>		
		public virtual string MoudleNameCn
		{
			get { return _moudle_namecn; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for MoudleNameCn", value, value.ToString());
				
				_isChanged |= (_moudle_namecn != value); _moudle_namecn = value;
			}
		}
		/// <summary>
		/// 模块英文名
		/// </summary>		
		public virtual string MoudleNameEn
		{
			get { return _moudle_nameen; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for MoudleNameEn", value, value.ToString());
				
				_isChanged |= (_moudle_nameen != value); _moudle_nameen = value;
			}
		}
		/// <summary>
		/// 模块对应数据表名
		/// </summary>		
		public virtual string MoudleNameDb
		{
			get { return _moudle_namedb; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for MoudleNameDb", value, value.ToString());
				
				_isChanged |= (_moudle_namedb != value); _moudle_namedb = value;
			}
		}
		/// <summary>
		/// 模块描述
		/// </summary>		
		public virtual string MoudleDescription
		{
			get { return _moudle_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for MoudleDescription", value, value.ToString());
				
				_isChanged |= (_moudle_description != value); _moudle_description = value;
			}
		}
		/// <summary>
		/// 应用ID
		/// </summary>		
		public virtual SystemApplication ApplicationID
		{
			get { return _application_id; }
			set { _isChanged |= (_application_id != value); _application_id = value; }
		}
		/// <summary>
		/// 是否为系统模块
		/// </summary>		
		public virtual bool MoudleIsSystemMoudle
		{
			get { return _moudle_issystemmoudle; }
			set { _isChanged |= (_moudle_issystemmoudle != value); _moudle_issystemmoudle = value; }
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
			SystemMoudleBase castObj = (SystemMoudleBase)obj; 
			return ( castObj != null ) &&
				( this._moudle_id == castObj.MoudleID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _moudle_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemMoudleBase obj )
		{
			obj.MoudleNameCn = this._moudle_namecn;
			obj.MoudleNameEn = this._moudle_nameen;
			obj.MoudleNameDb = this._moudle_namedb;
			obj.MoudleDescription = this._moudle_description;
			obj.ApplicationID = this._application_id;
			obj.MoudleIsSystemMoudle = this._moudle_issystemmoudle;
		}
        #endregion
	}
}
