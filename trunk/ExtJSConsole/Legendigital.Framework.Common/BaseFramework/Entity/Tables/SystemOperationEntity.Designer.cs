// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	系统操作
	/// </summary>
	public partial class SystemOperationEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemOperationEntity";
		public static readonly string PROPERTY_NAME_OPERATIONID = "OperationID";
		public static readonly string PROPERTY_NAME_OPERATIONNAMECN = "OperationNameCn";
		public static readonly string PROPERTY_NAME_OPERATIONNAMEEN = "OperationNameEn";
		public static readonly string PROPERTY_NAME_OPERATIONDESCRIPTION = "OperationDescription";
		public static readonly string PROPERTY_NAME_ISSYSTEMOPERATION = "IsSystemOperation";
		public static readonly string PROPERTY_NAME_ISCANSINGLEOPERATION = "IsCanSingleOperation";
		public static readonly string PROPERTY_NAME_ISCANMUTILOPERATION = "IsCanMutilOperation";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_ISINLISTPAGE = "IsInListPage";
		public static readonly string PROPERTY_NAME_ISINSINGLEPAGE = "IsInSinglePage";
		public static readonly string PROPERTY_NAME_OPERATIONORDER = "OperationOrder";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _operationID;
		private string _operationNameCn;
		private string _operationNameEn;
		private string _operationDescription;
		private bool _isSystemOperation;
		private bool _isCanSingleOperation;
		private bool _isCanMutilOperation;
		private bool _isEnable;
		private bool _isInListPage;
		private bool _isInSinglePage;
		private int _operationOrder;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemOperationEntity()
		{
			_operationID = 0;
			_operationNameCn = null;
			_operationNameEn = null;
			_operationDescription = String.Empty;
			_isSystemOperation = false;
			_isCanSingleOperation = false;
			_isCanMutilOperation = false;
			_isEnable = false;
			_isInListPage = false;
			_isInSinglePage = false;
			_operationOrder = 9999;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemOperationEntity( int operationID, string operationNameCn, string operationNameEn, string operationDescription, bool isSystemOperation, bool isCanSingleOperation, bool isCanMutilOperation, bool isEnable, bool isInListPage, bool isInSinglePage, int operationOrder)
		{
			_operationID = operationID;
			_operationNameCn = operationNameCn;
			_operationNameEn = operationNameEn;
			_operationDescription = operationDescription;
			_isSystemOperation = isSystemOperation;
			_isCanSingleOperation = isCanSingleOperation;
			_isCanMutilOperation = isCanMutilOperation;
			_isEnable = isEnable;
			_isInListPage = isInListPage;
			_isInSinglePage = isInSinglePage;
			_operationOrder = operationOrder;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int OperationID
		{
			get { return _operationID; }

			set	
			{
				_isChanged |= (_operationID != value); _operationID = value;
			}
		}

		/// <summary>
		/// 操作中文名
		/// </summary>		
		public virtual string OperationNameCn
		{
			get { return _operationNameCn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for OperationNameCn", value, value.ToString());
				_isChanged |= (_operationNameCn != value); _operationNameCn = value;
			}
		}

		/// <summary>
		/// 操作代号
		/// </summary>		
		public virtual string OperationNameEn
		{
			get { return _operationNameEn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for OperationNameEn", value, value.ToString());
				_isChanged |= (_operationNameEn != value); _operationNameEn = value;
			}
		}

		/// <summary>
		/// 操作描述
		/// </summary>		
		public virtual string OperationDescription
		{
			get { return _operationDescription; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for OperationDescription", value, value.ToString());
				_isChanged |= (_operationDescription != value); _operationDescription = value;
			}
		}

		/// <summary>
		/// 是否为系统操作
		/// </summary>		
		public virtual bool IsSystemOperation
		{
			get { return _isSystemOperation; }

			set	
			{
				_isChanged |= (_isSystemOperation != value); _isSystemOperation = value;
			}
		}

		/// <summary>
		/// 是否可以单条数据操作
		/// </summary>		
		public virtual bool IsCanSingleOperation
		{
			get { return _isCanSingleOperation; }

			set	
			{
				_isChanged |= (_isCanSingleOperation != value); _isCanSingleOperation = value;
			}
		}

		/// <summary>
		/// 是否可以多条数据操作
		/// </summary>		
		public virtual bool IsCanMutilOperation
		{
			get { return _isCanMutilOperation; }

			set	
			{
				_isChanged |= (_isCanMutilOperation != value); _isCanMutilOperation = value;
			}
		}

		/// <summary>
		/// 是否生效
		/// </summary>		
		public virtual bool IsEnable
		{
			get { return _isEnable; }

			set	
			{
				_isChanged |= (_isEnable != value); _isEnable = value;
			}
		}

		/// <summary>
		/// 是否出现在列表页面
		/// </summary>		
		public virtual bool IsInListPage
		{
			get { return _isInListPage; }

			set	
			{
				_isChanged |= (_isInListPage != value); _isInListPage = value;
			}
		}

		/// <summary>
		/// 是否出现在详细页面
		/// </summary>		
		public virtual bool IsInSinglePage
		{
			get { return _isInSinglePage; }

			set	
			{
				_isChanged |= (_isInSinglePage != value); _isInSinglePage = value;
			}
		}

		/// <summary>
		/// 操作排序号
		/// </summary>		
		public virtual int OperationOrder
		{
			get { return _operationOrder; }

			set	
			{
				_isChanged |= (_operationOrder != value); _operationOrder = value;
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
			
			SystemOperationEntity castObj = (SystemOperationEntity)obj;
			
			return ( castObj != null ) && ( this._operationID == castObj.OperationID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _operationID.GetHashCode();

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
