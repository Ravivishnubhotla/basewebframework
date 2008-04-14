/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统导航菜单
	/// </summary>
	[Serializable]
	public abstract class SystemMenuBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemMenu";
		public static readonly string PROPERTY_NAME_MENUID = "MenuID";
		public static readonly string PROPERTY_NAME_MENUNAME = "MenuName";
		public static readonly string PROPERTY_NAME_MENUDESCRIPTION = "MenuDescription";
		public static readonly string PROPERTY_NAME_MENUURL = "MenuUrl";
		public static readonly string PROPERTY_NAME_MENUURLTARGET = "MenuUrlTarget";
		public static readonly string PROPERTY_NAME_MENUISCATEGORY = "MenuIsCategory";
		public static readonly string PROPERTY_NAME_PARENTMENUID = "ParentMenuID";
		public static readonly string PROPERTY_NAME_MENUORDER = "MenuOrder";
		public static readonly string PROPERTY_NAME_MENUTYPE = "MenuType";
		public static readonly string PROPERTY_NAME_MENUISSYSTEMMENU = "MenuIsSystemMenu";
		public static readonly string PROPERTY_NAME_MENUISENABLE = "MenuIsEnable";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _menu_id;
		private string _menu_name;
		private string _menu_description;
		private string _menu_url;
		private string _menu_urltarget;
		private bool _menu_iscategory;
		private SystemMenu _parentmenu_id;
		private int _menu_order;
		private string _menu_type;
		private bool _menu_issystemmenu;
		private bool _menu_isenable;
		private SystemApplication _applicationid;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemMenuBase()
		{
			_menu_id = 0; 
			_menu_name = String.Empty; 
			_menu_description = String.Empty; 
			_menu_url = String.Empty; 
			_menu_urltarget = String.Empty; 
			_menu_iscategory = false; 
			_parentmenu_id =  null; 
			_menu_order = 0; 
			_menu_type = String.Empty; 
			_menu_issystemmenu = false; 
			_menu_isenable = false; 
			_applicationid =  null; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int MenuID
		{
			get { return _menu_id; }
			set { _isChanged |= (_menu_id != value); _menu_id = value; }
		}
		/// <summary>
		/// 菜单名称
		/// </summary>		
		public virtual string MenuName
		{
			get { return _menu_name; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for MenuName", value, value.ToString());
				
				_isChanged |= (_menu_name != value); _menu_name = value;
			}
		}
		/// <summary>
		/// 菜单描述
		/// </summary>		
		public virtual string MenuDescription
		{
			get { return _menu_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for MenuDescription", value, value.ToString());
				
				_isChanged |= (_menu_description != value); _menu_description = value;
			}
		}
		/// <summary>
		/// 菜单链接
		/// </summary>		
		public virtual string MenuUrl
		{
			get { return _menu_url; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for MenuUrl", value, value.ToString());
				
				_isChanged |= (_menu_url != value); _menu_url = value;
			}
		}
		/// <summary>
		/// 菜单链接目标
		/// </summary>		
		public virtual string MenuUrlTarget
		{
			get { return _menu_urltarget; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for MenuUrlTarget", value, value.ToString());
				
				_isChanged |= (_menu_urltarget != value); _menu_urltarget = value;
			}
		}
		/// <summary>
		/// 是否为菜单组
		/// </summary>		
		public virtual bool MenuIsCategory
		{
			get { return _menu_iscategory; }
			set { _isChanged |= (_menu_iscategory != value); _menu_iscategory = value; }
		}
		/// <summary>
		/// 父菜单ID
		/// </summary>		
		public virtual SystemMenu ParentMenuID
		{
			get { return _parentmenu_id; }
			set { _isChanged |= (_parentmenu_id != value); _parentmenu_id = value; }
		}
		/// <summary>
		/// 菜单次序
		/// </summary>		
		public virtual int MenuOrder
		{
			get { return _menu_order; }
			set { _isChanged |= (_menu_order != value); _menu_order = value; }
		}
		/// <summary>
		/// 菜单类型
		/// </summary>		
		public virtual string MenuType
		{
			get { return _menu_type; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for MenuType", value, value.ToString());
				
				_isChanged |= (_menu_type != value); _menu_type = value;
			}
		}
		/// <summary>
		/// 是否为系统菜单
		/// </summary>		
		public virtual bool MenuIsSystemMenu
		{
			get { return _menu_issystemmenu; }
			set { _isChanged |= (_menu_issystemmenu != value); _menu_issystemmenu = value; }
		}
		/// <summary>
		/// 菜单是否可用
		/// </summary>		
		public virtual bool MenuIsEnable
		{
			get { return _menu_isenable; }
			set { _isChanged |= (_menu_isenable != value); _menu_isenable = value; }
		}
		/// <summary>
		/// 应用ID
		/// </summary>		
		public virtual SystemApplication ApplicationID
		{
			get { return _applicationid; }
			set { _isChanged |= (_applicationid != value); _applicationid = value; }
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
			SystemMenuBase castObj = (SystemMenuBase)obj; 
			return ( castObj != null ) &&
				( this._menu_id == castObj.MenuID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _menu_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemMenuBase obj )
		{
			obj.MenuName = this._menu_name;
			obj.MenuDescription = this._menu_description;
			obj.MenuUrl = this._menu_url;
			obj.MenuUrlTarget = this._menu_urltarget;
			obj.MenuIsCategory = this._menu_iscategory;
			obj.ParentMenuID = this._parentmenu_id;
			obj.MenuOrder = this._menu_order;
			obj.MenuType = this._menu_type;
			obj.MenuIsSystemMenu = this._menu_issystemmenu;
			obj.MenuIsEnable = this._menu_isenable;
			obj.ApplicationID = this._applicationid;
		}
        #endregion
	}
}
