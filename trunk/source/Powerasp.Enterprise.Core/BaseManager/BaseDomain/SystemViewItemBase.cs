/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统视图字段
	/// </summary>
	[Serializable]
	public abstract class SystemViewItemBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemViewItem";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMID = "SystemViewItemID";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMNAMEEN = "SystemViewItemNameEn";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMNAMECN = "SystemViewItemNameCn";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMDESCRIPTION = "SystemViewItemDescription";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWITEMDISPLAYFORMAT = "SystemViewItemDisplayFormat";
		public static readonly string PROPERTY_NAME_SYSTEMVIEWID = "SystemViewID";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _systemviewitem_id;
		private string _systemviewitem_nameen;
		private string _systemviewitem_namecn;
		private string _systemviewitem_description;
		private string _systemviewitem_displayformat;
		private SystemView _systemview_id;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemViewItemBase()
		{
			_systemviewitem_id = 0; 
			_systemviewitem_nameen = String.Empty; 
			_systemviewitem_namecn = String.Empty; 
			_systemviewitem_description = String.Empty; 
			_systemviewitem_displayformat = String.Empty; 
			_systemview_id =  null; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int SystemViewItemID
		{
			get { return _systemviewitem_id; }
			set { _isChanged |= (_systemviewitem_id != value); _systemviewitem_id = value; }
		}
		/// <summary>
		/// 字段英文名
		/// </summary>		
		public virtual string SystemViewItemNameEn
		{
			get { return _systemviewitem_nameen; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemViewItemNameEn", value, value.ToString());
				
				_isChanged |= (_systemviewitem_nameen != value); _systemviewitem_nameen = value;
			}
		}
		/// <summary>
		/// 字段中文名
		/// </summary>		
		public virtual string SystemViewItemNameCn
		{
			get { return _systemviewitem_namecn; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for SystemViewItemNameCn", value, value.ToString());
				
				_isChanged |= (_systemviewitem_namecn != value); _systemviewitem_namecn = value;
			}
		}
		/// <summary>
		/// 字段描述
		/// </summary>		
		public virtual string SystemViewItemDescription
		{
			get { return _systemviewitem_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for SystemViewItemDescription", value, value.ToString());
				
				_isChanged |= (_systemviewitem_description != value); _systemviewitem_description = value;
			}
		}
		/// <summary>
		/// 字段显示格式
		/// </summary>		
		public virtual string SystemViewItemDisplayFormat
		{
			get { return _systemviewitem_displayformat; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for SystemViewItemDisplayFormat", value, value.ToString());
				
				_isChanged |= (_systemviewitem_displayformat != value); _systemviewitem_displayformat = value;
			}
		}
		/// <summary>
		/// 所属视图ID
		/// </summary>		
		public virtual SystemView SystemViewID
		{
			get { return _systemview_id; }
			set { _isChanged |= (_systemview_id != value); _systemview_id = value; }
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
			SystemViewItemBase castObj = (SystemViewItemBase)obj; 
			return ( castObj != null ) &&
				( this._systemviewitem_id == castObj.SystemViewItemID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _systemviewitem_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemViewItemBase obj )
		{
			obj.SystemViewItemNameEn = this._systemviewitem_nameen;
			obj.SystemViewItemNameCn = this._systemviewitem_namecn;
			obj.SystemViewItemDescription = this._systemviewitem_description;
			obj.SystemViewItemDisplayFormat = this._systemviewitem_displayformat;
			obj.SystemViewID = this._systemview_id;
		}
        #endregion
	}
}
