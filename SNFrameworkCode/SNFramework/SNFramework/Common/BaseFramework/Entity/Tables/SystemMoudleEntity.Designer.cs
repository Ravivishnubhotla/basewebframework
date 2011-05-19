// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	System Moudle
	/// </summary>
	[DataContract]
	public partial class SystemMoudleEntity : ICloneable
	{
        #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemMoudleEntity";
		public static readonly string PROPERTY_NAME_MOUDLEID = "MoudleID";
		public static readonly string PROPERTY_NAME_MOUDLENAMECN = "MoudleNameCn";
		public static readonly string PROPERTY_NAME_MOUDLENAMEEN = "MoudleNameEn";
		public static readonly string PROPERTY_NAME_MOUDLENAMEDB = "MoudleNameDb";
		public static readonly string PROPERTY_NAME_MOUDLEDESCRIPTION = "MoudleDescription";
		public static readonly string PROPERTY_NAME_APPLICATIONID = "ApplicationID";
		public static readonly string PROPERTY_NAME_MOUDLEISSYSTEMMOUDLE = "MoudleIsSystemMoudle";
		public static readonly string PROPERTY_NAME_ORDERINDEX = "OrderIndex";
		
        #endregion
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _moudleID;
		private string _moudleNameCn;
		private string _moudleNameEn;
		private string _moudleNameDb;
		private string _moudleDescription;
		private SystemApplicationEntity _applicationID;
		private bool _moudleIsSystemMoudle;
		private int? _orderIndex;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemMoudleEntity()
		{
			_moudleID = 0;
			_moudleNameCn = String.Empty;
			_moudleNameEn = String.Empty;
			_moudleNameDb = String.Empty;
			_moudleDescription = String.Empty;
			_applicationID = null;
			_moudleIsSystemMoudle = false;
			_orderIndex = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemMoudleEntity( int moudleID, string moudleNameCn, string moudleNameEn, string moudleNameDb, string moudleDescription, SystemApplicationEntity applicationID, bool moudleIsSystemMoudle, int? orderIndex)
		{
			_moudleID = moudleID;
			_moudleNameCn = moudleNameCn;
			_moudleNameEn = moudleNameEn;
			_moudleNameDb = moudleNameDb;
			_moudleDescription = moudleDescription;
			_applicationID = applicationID;
			_moudleIsSystemMoudle = moudleIsSystemMoudle;
			_orderIndex = orderIndex;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// Primary Key
		/// </summary>
		[DataMember]
		public virtual int MoudleID
		{
			get { return _moudleID; }

			set	
			{
				_isChanged |= (_moudleID != value); _moudleID = value;
			}
		}

		/// <summary>
		/// Moudle Name
		/// </summary>
		[DataMember]
		public virtual string MoudleNameCn
		{
			get { return _moudleNameCn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for MoudleNameCn", value, value.ToString());
				_isChanged |= (_moudleNameCn != value); _moudleNameCn = value;
			}
		}

		/// <summary>
		/// Moudle Code
		/// </summary>
		[DataMember]
		public virtual string MoudleNameEn
		{
			get { return _moudleNameEn; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for MoudleNameEn", value, value.ToString());
				_isChanged |= (_moudleNameEn != value); _moudleNameEn = value;
			}
		}

		/// <summary>
		/// moudle of Table
		/// </summary>
		[DataMember]
		public virtual string MoudleNameDb
		{
			get { return _moudleNameDb; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for MoudleNameDb", value, value.ToString());
				_isChanged |= (_moudleNameDb != value); _moudleNameDb = value;
			}
		}

		/// <summary>
		/// Moudle Description
		/// </summary>
		[DataMember]
		public virtual string MoudleDescription
		{
			get { return _moudleDescription; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for MoudleDescription", value, value.ToString());
				_isChanged |= (_moudleDescription != value); _moudleDescription = value;
			}
		}

		/// <summary>
		/// Application ID
		/// </summary>
		[DataMember]
		public virtual SystemApplicationEntity ApplicationID
		{
			get { return _applicationID; }

			set	
			{
				_isChanged |= (_applicationID != value); _applicationID = value;
			}
		}

		/// <summary>
		/// Is System Moudle
		/// </summary>
		[DataMember]
		public virtual bool MoudleIsSystemMoudle
		{
			get { return _moudleIsSystemMoudle; }

			set	
			{
				_isChanged |= (_moudleIsSystemMoudle != value); _moudleIsSystemMoudle = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? OrderIndex
		{
			get { return _orderIndex; }

			set	
			{
				_isChanged |= (_orderIndex != value); _orderIndex = value;
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
			
			SystemMoudleEntity castObj = (SystemMoudleEntity)obj;
			
			return ( castObj != null ) && ( this._moudleID == castObj.MoudleID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _moudleID.GetHashCode();

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
