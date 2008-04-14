/*
在这里插入代码注释
*/
using System;
using Powerasp.Enterprise.Core.BaseManager.Domain;

namespace Powerasp.Enterprise.Core.BaseManager.BaseDomain
{
	/// <summary>
	///	系统资源
	/// </summary>
	[Serializable]
	public abstract class SystemResourcesBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Powerasp.Enterprise.Core.BaseManager.Domain.SystemResources";
		public static readonly string PROPERTY_NAME_RESOURCESID = "ResourcesID";
		public static readonly string PROPERTY_NAME_RESOURCESNAMECN = "ResourcesNameCn";
		public static readonly string PROPERTY_NAME_RESOURCESNAMEEN = "ResourcesNameEn";
		public static readonly string PROPERTY_NAME_RESOURCESDESCRIPTION = "ResourcesDescription";
		public static readonly string PROPERTY_NAME_RESOURCESTYPE = "ResourcesType";
		public static readonly string PROPERTY_NAME_RESOURCESLIMITEXPRESSION = "ResourcesLimitExpression";
		public static readonly string PROPERTY_NAME_RESOURCESISRELATEUSER = "ResourcesIsRelateUser";
		public static readonly string PROPERTY_NAME_MOUDLEID = "MoudleID";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _resources_id;
		private string _resources_namecn;
		private string _resources_nameen;
		private string _resources_description;
		private string _resources_type;
		private string _resources_limitexpression;
		private bool _resources_isrelateuser;
		private SystemMoudle _moudleid;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemResourcesBase()
		{
			_resources_id = 0; 
			_resources_namecn = String.Empty; 
			_resources_nameen = String.Empty; 
			_resources_description = String.Empty; 
			_resources_type = String.Empty; 
			_resources_limitexpression = String.Empty; 
			_resources_isrelateuser = false; 
			_moudleid =  null; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int ResourcesID
		{
			get { return _resources_id; }
			set { _isChanged |= (_resources_id != value); _resources_id = value; }
		}
		/// <summary>
		/// 资源中文名
		/// </summary>		
		public virtual string ResourcesNameCn
		{
			get { return _resources_namecn; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for ResourcesNameCn", value, value.ToString());
				
				_isChanged |= (_resources_namecn != value); _resources_namecn = value;
			}
		}
		/// <summary>
		/// 资源英文名
		/// </summary>		
		public virtual string ResourcesNameEn
		{
			get { return _resources_nameen; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for ResourcesNameEn", value, value.ToString());
				
				_isChanged |= (_resources_nameen != value); _resources_nameen = value;
			}
		}
		/// <summary>
		/// 资源描述
		/// </summary>		
		public virtual string ResourcesDescription
		{
			get { return _resources_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for ResourcesDescription", value, value.ToString());
				
				_isChanged |= (_resources_description != value); _resources_description = value;
			}
		}
		/// <summary>
		/// 资源类型
		/// </summary>		
		public virtual string ResourcesType
		{
			get { return _resources_type; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for ResourcesType", value, value.ToString());
				
				_isChanged |= (_resources_type != value); _resources_type = value;
			}
		}
		/// <summary>
		/// 资源限制条件
		/// </summary>		
		public virtual string ResourcesLimitExpression
		{
			get { return _resources_limitexpression; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for ResourcesLimitExpression", value, value.ToString());
				
				_isChanged |= (_resources_limitexpression != value); _resources_limitexpression = value;
			}
		}
		/// <summary>
		/// 资源是否于用户相关
		/// </summary>		
		public virtual bool ResourcesIsRelateUser
		{
			get { return _resources_isrelateuser; }
			set { _isChanged |= (_resources_isrelateuser != value); _resources_isrelateuser = value; }
		}
		/// <summary>
		/// 所属模块
		/// </summary>		
		public virtual SystemMoudle MoudleID
		{
			get { return _moudleid; }
			set { _isChanged |= (_moudleid != value); _moudleid = value; }
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
			SystemResourcesBase castObj = (SystemResourcesBase)obj; 
			return ( castObj != null ) &&
				( this._resources_id == castObj.ResourcesID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _resources_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemResourcesBase obj )
		{
			obj.ResourcesNameCn = this._resources_namecn;
			obj.ResourcesNameEn = this._resources_nameen;
			obj.ResourcesDescription = this._resources_description;
			obj.ResourcesType = this._resources_type;
			obj.ResourcesLimitExpression = this._resources_limitexpression;
			obj.ResourcesIsRelateUser = this._resources_isrelateuser;
			obj.MoudleID = this._moudleid;
		}
        #endregion
	}
}
