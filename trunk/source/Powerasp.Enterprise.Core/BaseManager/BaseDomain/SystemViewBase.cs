/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统视图
	/// </summary>
	[Serializable]
	public abstract class SystemViewBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemView";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWID = "SystemViewID";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWNAMECN = "SystemViewNameCn";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWNAMEEN = "SystemViewNameEn";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWDESCRIPTION = "SystemViewDescription";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _systemview_id;
		private string _systemview_namecn;
		private string _systemview_nameen;
		private SystemApplication _application_id;
		private string _systemview_description;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemViewBase()
		{
			_systemview_id = 0; 
			_systemview_namecn = String.Empty; 
			_systemview_nameen = String.Empty; 
			_application_id =  null; 
			_systemview_description = String.Empty; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int SystemViewID
		{
			get { return _systemview_id; }
			set { _isChanged |= (_systemview_id != value); _systemview_id = value; }
		}
		/// <summary>
		/// 视图中文名
		/// </summary>		
		public virtual string SystemViewNameCn
		{
			get { return _systemview_namecn; }
			set	
			{
				if ( value != null)
					if( value.Length > 10)
						throw new ArgumentOutOfRangeException("Invalid value for SystemViewNameCn", value, value.ToString());
				
				_isChanged |= (_systemview_namecn != value); _systemview_namecn = value;
			}
		}
		/// <summary>
		/// 视图英文名
		/// </summary>		
		public virtual string SystemViewNameEn
		{
			get { return _systemview_nameen; }
			set	
			{
				if ( value != null)
					if( value.Length > 10)
						throw new ArgumentOutOfRangeException("Invalid value for SystemViewNameEn", value, value.ToString());
				
				_isChanged |= (_systemview_nameen != value); _systemview_nameen = value;
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
		/// 视图描述
		/// </summary>		
		public virtual string SystemViewDescription
		{
			get { return _systemview_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 10)
						throw new ArgumentOutOfRangeException("Invalid value for SystemViewDescription", value, value.ToString());
				
				_isChanged |= (_systemview_description != value); _systemview_description = value;
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
			SystemViewBase castObj = (SystemViewBase)obj; 
			return ( castObj != null ) &&
				( this._systemview_id == castObj.SystemViewID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _systemview_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemViewBase obj )
		{
			obj.SystemViewNameCn = this._systemview_namecn;
			obj.SystemViewNameEn = this._systemview_nameen;
			obj.ApplicationID = this._application_id;
			obj.SystemViewDescription = this._systemview_description;
		}
        #endregion
	}
}
