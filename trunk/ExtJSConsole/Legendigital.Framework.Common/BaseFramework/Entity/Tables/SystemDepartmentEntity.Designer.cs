// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	
	/// </summary>
	[DataContract]
	public partial class SystemDepartmentEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemDepartmentEntity";
		public static readonly string PROPERTY_NAME_DEPARTMENTID = "DepartmentID";
		public static readonly string PROPERTY_NAME_PARENTDEPARTMENTID = "ParentDepartmentID";
		public static readonly string PROPERTY_NAME_DEPARTMENTNAMECN = "DepartmentNameCn";
		public static readonly string PROPERTY_NAME_DEPARTMENTNAMEEN = "DepartmentNameEn";
		public static readonly string PROPERTY_NAME_DEPARTMENTDECRIPTION = "DepartmentDecription";
		public static readonly string PROPERTY_NAME_DEPARTMENTSORTINDEX = "DepartmentSortIndex";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _departmentID;
		private SystemDepartmentEntity _parentDepartmentID;
		private string _departmentNameCn;
		private string _departmentNameEn;
		private string _departmentDecription;
		private int? _departmentSortIndex;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemDepartmentEntity()
		{
			_departmentID = 0;
			_parentDepartmentID = null;
			_departmentNameCn = String.Empty;
			_departmentNameEn = String.Empty;
			_departmentDecription = null;
			_departmentSortIndex = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemDepartmentEntity( int departmentID, SystemDepartmentEntity parentDepartmentID, string departmentNameCn, string departmentNameEn, string departmentDecription, int? departmentSortIndex)
		{
			_departmentID = departmentID;
			_parentDepartmentID = parentDepartmentID;
			_departmentNameCn = departmentNameCn;
			_departmentNameEn = departmentNameEn;
			_departmentDecription = departmentDecription;
			_departmentSortIndex = departmentSortIndex;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int DepartmentID
		{
			get { return _departmentID; }

			set	
			{
				_isChanged |= (_departmentID != value); _departmentID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual SystemDepartmentEntity ParentDepartmentID
		{
			get { return _parentDepartmentID; }

			set	
			{
				_isChanged |= (_parentDepartmentID != value); _parentDepartmentID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DepartmentNameCn
		{
			get { return _departmentNameCn; }

			set	
			{

				if( value != null && value.Length > 800)
					throw new ArgumentOutOfRangeException("Invalid value for DepartmentNameCn", value, value.ToString());
				_isChanged |= (_departmentNameCn != value); _departmentNameCn = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DepartmentNameEn
		{
			get { return _departmentNameEn; }

			set	
			{

				if( value != null && value.Length > 800)
					throw new ArgumentOutOfRangeException("Invalid value for DepartmentNameEn", value, value.ToString());
				_isChanged |= (_departmentNameEn != value); _departmentNameEn = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string DepartmentDecription
		{
			get { return _departmentDecription; }

			set	
			{

				if( value != null && value.Length > 8000)
					throw new ArgumentOutOfRangeException("Invalid value for DepartmentDecription", value, value.ToString());
				_isChanged |= (_departmentDecription != value); _departmentDecription = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? DepartmentSortIndex
		{
			get { return _departmentSortIndex; }

			set	
			{
				_isChanged |= (_departmentSortIndex != value); _departmentSortIndex = value;
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
			
			SystemDepartmentEntity castObj = (SystemDepartmentEntity)obj;
			
			return ( castObj != null ) && ( this._departmentID == castObj.DepartmentID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _departmentID.GetHashCode();

			return hash; 
		}
		#endregion
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
