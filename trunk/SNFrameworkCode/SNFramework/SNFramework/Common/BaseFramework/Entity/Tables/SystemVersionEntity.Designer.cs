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
	public partial class SystemVersionEntity : ICloneable
	{
      #region 公共常量

		public static readonly string CLASS_FULL_NAME = "Legendigital.Framework.Common.BaseFramework.Entity.Tables.SystemVersionEntity";
		public static readonly string PROPERTY_NAME_ID = "Id";
		public static readonly string PROPERTY_NAME_OLDVERSION = "OldVersion";
		public static readonly string PROPERTY_NAME_NEWVERSION = "NewVersion";
		public static readonly string PROPERTY_NAME_OLDCHANGEFILELD = "OldChangeFileld";
		public static readonly string PROPERTY_NAME_NEWCHANGEFILELD = "NewChangeFileld";
		public static readonly string PROPERTY_NAME_PARENTDATATYPE = "ParentDataType";
		public static readonly string PROPERTY_NAME_PARENTDATAID = "ParentDataID";
		public static readonly string PROPERTY_NAME_CHANGEDATE = "ChangeDate";
		public static readonly string PROPERTY_NAME_CHANGEUSERID = "ChangeUserID";
		public static readonly string PROPERTY_NAME_CHANGEUSERNAME = "ChangeUserName";
		public static readonly string PROPERTY_NAME_COMMENT = "Comment";
		
        #endregion
	
 
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

		private bool _isChanged;		
		private bool _isDeleted;
		
		private int _id;
		private string _oldVersion;
		private string _newVersion;
		private string _oldChangeFileld;
		private string _newChangeFileld;
		private string _parentDataType;
		private int? _parentDataID;
		private DateTime? _changeDate;
		private int? _changeUserID;
		private int? _changeUserName;
		private string _comment;
		
		#endregion

		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemVersionEntity()
		{
			_id = 0;
			_oldVersion = null;
			_newVersion = null;
			_oldChangeFileld = null;
			_newChangeFileld = null;
			_parentDataType = null;
			_parentDataID = null;
			_changeDate = null;
			_changeUserID = null;
			_changeUserName = null;
			_comment = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemVersionEntity( int id, string oldVersion, string newVersion, string oldChangeFileld, string newChangeFileld, string parentDataType, int? parentDataID, DateTime? changeDate, int? changeUserID, int? changeUserName, string comment)
		{
			_id = id;
			_oldVersion = oldVersion;
			_newVersion = newVersion;
			_oldChangeFileld = oldChangeFileld;
			_newChangeFileld = newChangeFileld;
			_parentDataType = parentDataType;
			_parentDataID = parentDataID;
			_changeDate = changeDate;
			_changeUserID = changeUserID;
			_changeUserName = changeUserName;
			_comment = comment;
		}
		#endregion     
	
	    #region 公共属性

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int Id
		{
			get { return _id; }

			set	
			{
				_isChanged |= (_id != value); _id = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string OldVersion
		{
			get { return _oldVersion; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for OldVersion", value, value.ToString());
				_isChanged |= (_oldVersion != value); _oldVersion = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string NewVersion
		{
			get { return _newVersion; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for NewVersion", value, value.ToString());
				_isChanged |= (_newVersion != value); _newVersion = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string OldChangeFileld
		{
			get { return _oldChangeFileld; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for OldChangeFileld", value, value.ToString());
				_isChanged |= (_oldChangeFileld != value); _oldChangeFileld = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string NewChangeFileld
		{
			get { return _newChangeFileld; }

			set	
			{

				if( value != null && value.Length > 4000)
					throw new ArgumentOutOfRangeException("Invalid value for NewChangeFileld", value, value.ToString());
				_isChanged |= (_newChangeFileld != value); _newChangeFileld = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string ParentDataType
		{
			get { return _parentDataType; }

			set	
			{

				if( value != null && value.Length > 100)
					throw new ArgumentOutOfRangeException("Invalid value for ParentDataType", value, value.ToString());
				_isChanged |= (_parentDataType != value); _parentDataType = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? ParentDataID
		{
			get { return _parentDataID; }

			set	
			{
				_isChanged |= (_parentDataID != value); _parentDataID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? ChangeDate
		{
			get { return _changeDate; }

			set	
			{
				_isChanged |= (_changeDate != value); _changeDate = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? ChangeUserID
		{
			get { return _changeUserID; }

			set	
			{
				_isChanged |= (_changeUserID != value); _changeUserID = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? ChangeUserName
		{
			get { return _changeUserName; }

			set	
			{
				_isChanged |= (_changeUserName != value); _changeUserName = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string Comment
		{
			get { return _comment; }

			set	
			{

				if( value != null && value.Length > 400)
					throw new ArgumentOutOfRangeException("Invalid value for Comment", value, value.ToString());
				_isChanged |= (_comment != value); _comment = value;
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
			
			SystemVersionEntity castObj = (SystemVersionEntity)obj;
			
			return ( castObj != null ) && ( this._id == castObj.Id );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _id.GetHashCode();

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
