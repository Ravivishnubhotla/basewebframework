// Generated by MyGeneration Version # (1.3.0.9)
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Legendigital.Framework.Common.Entity;

namespace Legendigital.Framework.Common.BaseFramework.Entity.Tables
{
	/// <summary>
	///	System Moudle
	/// </summary>
	[DataContract]
	public partial class SystemMoudleEntity  : BaseTableEntity<int>  ,ICloneable
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
		public static readonly string PROPERTY_NAME_CREATEBY = "CreateBy";
		public static readonly string PROPERTY_NAME_CREATEAT = "CreateAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYBY = "LastModifyBy";
		public static readonly string PROPERTY_NAME_LASTMODIFYAT = "LastModifyAt";
		public static readonly string PROPERTY_NAME_LASTMODIFYCOMMENT = "LastModifyComment";
		
        #endregion
	
 
		#region applicationID字段外键查询字段
        public const string PROPERTY_APPLICATIONID_ALIAS_NAME = "ApplicationID_SystemMoudleEntity_Alias";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationID";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationName";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONCODE = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationCode";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationDescription";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationUrl";
		public const string PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = "ApplicationID_SystemMoudleEntity_Alias.SystemApplicationIsSystemApplication";
		public const string PROPERTY_APPLICATIONID_ORDERINDEX = "ApplicationID_SystemMoudleEntity_Alias.OrderIndex";
		public const string PROPERTY_APPLICATIONID_CREATEBY = "ApplicationID_SystemMoudleEntity_Alias.CreateBy";
		public const string PROPERTY_APPLICATIONID_CREATEAT = "ApplicationID_SystemMoudleEntity_Alias.CreateAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYBY = "ApplicationID_SystemMoudleEntity_Alias.LastModifyBy";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYAT = "ApplicationID_SystemMoudleEntity_Alias.LastModifyAt";
		public const string PROPERTY_APPLICATIONID_LASTMODIFYCOMMENT = "ApplicationID_SystemMoudleEntity_Alias.LastModifyComment";
		#endregion
      	
	
	
		 
		
		
		
		
	
        #region 私有成员变量

 
		
		private int _moudleID;
		private string _moudleNameCn;
		private string _moudleNameEn;
		private string _moudleNameDb;
		private string _moudleDescription;
		private SystemApplicationEntity _applicationID;
		private bool _moudleIsSystemMoudle;
		private int? _orderIndex;
		private int? _createBy;
		private DateTime? _createAt;
		private int? _lastModifyBy;
		private DateTime? _lastModifyAt;
		private string _lastModifyComment;
		
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
			_createBy = null;
			_createAt = null;
			_lastModifyBy = null;
			_lastModifyAt = null;
			_lastModifyComment = null;
		}
		#endregion

		#region 全构造函数
		/// <summary>
		/// 全构造函数
		/// </summary>
		public SystemMoudleEntity( int moudleID, string moudleNameCn, string moudleNameEn, string moudleNameDb, string moudleDescription, SystemApplicationEntity applicationID, bool moudleIsSystemMoudle, int? orderIndex, int? createBy, DateTime? createAt, int? lastModifyBy, DateTime? lastModifyAt, string lastModifyComment)
		{
			_moudleID = moudleID;
			_moudleNameCn = moudleNameCn;
			_moudleNameEn = moudleNameEn;
			_moudleNameDb = moudleNameDb;
			_moudleDescription = moudleDescription;
			_applicationID = applicationID;
			_moudleIsSystemMoudle = moudleIsSystemMoudle;
			_orderIndex = orderIndex;
			_createBy = createBy;
			_createAt = createAt;
			_lastModifyBy = lastModifyBy;
			_lastModifyAt = lastModifyAt;
			_lastModifyComment = lastModifyComment;
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
		/// 
		/// </summary>
		[DataMember]
		public virtual int? CreateBy
		{
			get { return _createBy; }

			set	
			{
				_isChanged |= (_createBy != value); _createBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? CreateAt
		{
			get { return _createAt; }

			set	
			{
				_isChanged |= (_createAt != value); _createAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual int? LastModifyBy
		{
			get { return _lastModifyBy; }

			set	
			{
				_isChanged |= (_lastModifyBy != value); _lastModifyBy = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual DateTime? LastModifyAt
		{
			get { return _lastModifyAt; }

			set	
			{
				_isChanged |= (_lastModifyAt != value); _lastModifyAt = value;
			}
		}

		/// <summary>
		/// 
		/// </summary>
		[DataMember]
		public virtual string LastModifyComment
		{
			get { return _lastModifyComment; }

			set	
			{

				if( value != null && value.Length > 600)
					throw new ArgumentOutOfRangeException("Invalid value for LastModifyComment", value, value.ToString());
				_isChanged |= (_lastModifyComment != value); _lastModifyComment = value;
			}
		}
	

		#endregion 

        

		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			 return this.CheckEquals(obj as SystemMoudleEntity);
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			return GetEntityHashCode();
		}
		#endregion
		
		public override int GetDataEntityKey()
	    {
	        return this._moudleID;
	    }
		
		
	
		#region ICloneable methods
		
		public virtual object Clone()
		{
			return this.MemberwiseClone();
		}
		
		#endregion
	
	}
}
